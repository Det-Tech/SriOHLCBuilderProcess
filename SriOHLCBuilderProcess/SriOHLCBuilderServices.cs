using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderProcess
{
	public static class SriOHLCBuilderServices
	{
		public static int GetLevelCountFromCsv(string csvPath)
		{
			try
			{
				string[] lines = System.IO.File.ReadAllLines(csvPath);
				if (lines.Length < 1)
					return 0;

				string[] items = lines[0].Split(',');
				if (items.Length < 18)
					return 0;

				int nLevel = items.Length - 18;
				if (string.IsNullOrEmpty(items[items.Length - 1]))
					nLevel--;

				return nLevel;
			}
			catch
			{
				return 0;
			}
		}
		public static List<RDataRecord> LoadRDataFromCsv(string csvPath, bool bReadAll = true)
		{
			List<RDataRecord> dataList = new List<RDataRecord>();
			try
			{
				string[] lines = System.IO.File.ReadAllLines(csvPath).Skip(1).ToArray();
				foreach (var line in lines)
				{
					if (string.IsNullOrEmpty(line))
						continue;

					string[] items = line.Split(',');

					if (items.Length < 18)
						continue;

					RDataRecord data = new RDataRecord();
					string strDateTime = items[0] + " " + items[1];
					
					data.Datetime = DateTime.Parse(strDateTime);

					if (bReadAll)
					{
						data.Open = double.Parse(items[2]);
						data.High = double.Parse(items[3]);
						data.Low = double.Parse(items[4]);
						data.Close = double.Parse(items[5]);
						data.Volume = double.Parse(items[6]);
					}
					data.Change = double.Parse(items[17]);

					dataList.Add(data);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			return dataList;
		}

		public static List<RDataRecord> LoadRDataFromCsvForSignal(string csvPath)
		{
			List<RDataRecord> dataList = new List<RDataRecord>();
			try
			{
				string[] lines = System.IO.File.ReadAllLines(csvPath).Skip(1).ToArray();
				foreach (var line in lines)
				{
					if (string.IsNullOrEmpty(line))
						continue;

					string[] items = line.Split(',');

					if (items.Length < 18)
						continue;

					RDataRecord data = new RDataRecord();
					string strDateTime = items[0] + " " + items[1];

					data.Datetime = DateTime.Parse(strDateTime);
					data.Stcb = double.Parse(items[7]);
					data.Stcs = double.Parse(items[8]);
					data.Close = double.Parse(items[5]);
					data.Volume = double.Parse(items[6]);
					data.Change = double.Parse(items[17]);

					dataList.Add(data);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			return dataList;
		}

		public static List<RawData> LoadRawDataFromCsv(string csvPath, bool bReadAll = true)
		{
			List<RawData> dataList = new List<RawData>();
			if (!File.Exists(csvPath))
				return dataList;

			try
			{
				string[] lines = System.IO.File.ReadAllLines(csvPath).Skip(1).ToArray();
				foreach (var line in lines)
				{
					if (string.IsNullOrEmpty(line))
						continue;

					string[] items = line.Split(',');

					if (items.Length < 7)
						continue;

					RawData data = new RawData();
					string strDateTime = items[0] + " " + items[1];

					data.Datetime = DateTime.Parse(strDateTime);
					data.Open = double.Parse(items[2]);
					data.High = double.Parse(items[3]);
					data.Low = double.Parse(items[4]);
					data.Close = double.Parse(items[5]);
					data.Volume = double.Parse(items[6]);

					//if (!bReadAll && (data.Datetime > GlobalData.Config.General.EndDate || data.Datetime < GlobalData.Config.General.StartDate))
					//	continue;

					if (data.Close == 0)
						continue;

					dataList.Add(data);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}

			return dataList;
		}

		public static void ClearFolder(string path)
		{
			if (!Directory.Exists(path))
				return;

			DirectoryInfo di = new DirectoryInfo(path);

			try
			{
				foreach (FileInfo file in di.GetFiles())
				{
					file.Delete();
				}
				foreach (DirectoryInfo dir in di.GetDirectories())
				{
					dir.Delete(true);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
		public static void AddMissingBar(List<RawData> barset, int interval, int offset = 0)
		{
			for (int i = 0; i < barset.Count() - 1; i++)
			{
				var prev = barset[i];
				var next = barset[i + 1];
				
				if (prev.Datetime.ToUniversalTime().Date != next.Datetime.ToUniversalTime().Date)
					continue;
				
				int diffMins = (int)(next.Datetime - prev.Datetime).TotalMinutes;
				int missingItemCount = diffMins / interval - 1;

				if (missingItemCount <= 0)
					continue;

				for (int k = 0; k < missingItemCount; k++)
				{
					var newBar = ObjectCopier.Clone(prev);
					newBar.Datetime = newBar.Datetime.AddMinutes(interval);
					barset.Insert(i + 1 + k, newBar);
				}

				i += missingItemCount;      //skip new items
			}
		}

		public static List<string> CustomStringSplit(string str)
		{
			if (str.IndexOf('\"') < 0)
				return str.Split(',').ToList();

			List<int> quoteMark = new List<int>();
			for (int i = 0; i < str.Length; i++)
			{
				if (str[i] == '\"')
					quoteMark.Add(i);
			}

			List<string> quotedString = new List<string>();
			for (int i = quoteMark.Count - 1; i >= 0; i -= 2)
			{
				string subStr = str.Substring(quoteMark[i - 1], quoteMark[i] - quoteMark[i - 1] + 1);
				str = str.Replace(subStr, "   ");
				quotedString.Insert(0, subStr.Replace("\"", ""));
			}

			List<string> items = str.Split(',').ToList();
			int counter = 0;

			for (int i = 0; i < items.Count; i++)
			{
				if (items[i] == "   ")
					items[i] = quotedString[counter++];
			}

			return items;
		}

		public static Dictionary<string, List<RDataRecord>> LoadRDataFromFolder(string folder)
		{
			string[] files = Directory.GetFiles(folder, "*.csv");
			Dictionary<string, List<RDataRecord>> rdata = new Dictionary<string, List<RDataRecord>>();

			foreach (var file in files)
			{
				string fileName = Path.GetFileName(file);
				string symbol = fileName.ToUpper().Replace("-R.CSV", "");
				rdata[symbol] = LoadRDataFromCsvForSignal(file);
			}

			return rdata;
		}

		public static List<TreeItem> LoadTreeInfoFromFile(string filePath)
		{
			List<TreeItem> treeList = new List<TreeItem>();
			Dictionary<string, TreeItem> tempDict = new Dictionary<string, TreeItem>();
			if (!File.Exists(filePath))
				return treeList;


			using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				StreamReader sr = new StreamReader(fs);

				string line;
				line = sr.ReadLine();

				while ((line = sr.ReadLine()) != null)
				{
					try
					{
						var items = CustomStringSplit(line);
						if (items.Count() < 4)
							continue;

						var treeItem = new TreeItem();
						treeItem.Symbol = items[0];
						treeItem.Company = items[1];
						treeItem.Sector = items[2];
						treeItem.Industry = items[3];

						treeList.Add(treeItem);
					}
					catch (Exception e)
					{
						Utils.WriteLog("tree file format error", e.Message);
					}
				}
				sr.Close();
			}

			return treeList.OrderBy(x => x.Symbol).ToList();
		}
	}
}
