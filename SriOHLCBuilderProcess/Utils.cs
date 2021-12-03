using Alpaca.Markets;
using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using SriOHLCBuilderModel.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderProcess
{
	public static class Utils
	{
		public static string GetNameFromTimeFrame(DataTimeFrame tf)
		{
			string name = "";
			switch (tf)
			{
				case DataTimeFrame.Tick:
					name = "Tick";
					break;
				case DataTimeFrame.Second:
					name = "1S";
					break;
				case DataTimeFrame.Minute:
					name = "1Min";
					break;
				case DataTimeFrame.Minute5:
					name = "5Min";
					break;
				case DataTimeFrame.Minute15:
					name = "15Min";
					break;
				case DataTimeFrame.Minute30:
					name = "30Min";
					break;
				case DataTimeFrame.Minute45:
					name = "45Min";
					break;
				case DataTimeFrame.Hour:
					name = "1Hour";
					break;
				case DataTimeFrame.Hour2:
					name = "2Hour";
					break;
				case DataTimeFrame.Hour4:
					name = "4Hour";
					break;
				case DataTimeFrame.Day:
					name = "1D";
					break;
				case DataTimeFrame.Week:
					name = "Week";
					break;
				case DataTimeFrame.Month:
					name = "Month";
					break;
				case DataTimeFrame.Quarter:
					name = "Quarter";
					break;
				case DataTimeFrame.Year:
					name = "Year";
					break;
				default:
					name = "1Min";
					break;
			}

			return name;
		}
		public static DataTimeFrame GetTimeFrameFromName(string itemName)
		{
			DataTimeFrame dataTimeFrame = DataTimeFrame.Minute;
			switch (itemName)
			{
				case "Tick":
					dataTimeFrame = DataTimeFrame.Tick;
					break;
				case "1Min":
					dataTimeFrame = DataTimeFrame.Minute;
					break;
				case "5Min":
					dataTimeFrame = DataTimeFrame.Minute5;
					break;
				case "15Min":
					dataTimeFrame = DataTimeFrame.Minute15;
					break;
				case "30Min":
					dataTimeFrame = DataTimeFrame.Minute30;
					break;
				case "45Min":
					dataTimeFrame = DataTimeFrame.Minute45;
					break;
				case "1Hour":
					dataTimeFrame = DataTimeFrame.Hour;
					break;
				case "2Hour":
					dataTimeFrame = DataTimeFrame.Hour2;
					break;
				case "4Hour":
					dataTimeFrame = DataTimeFrame.Hour4;
					break;
				case "1D":
					dataTimeFrame = DataTimeFrame.Day;
					break;
				case "Week":
					dataTimeFrame = DataTimeFrame.Week;
					break;
				case "Month":
					dataTimeFrame = DataTimeFrame.Month;
					break;
				case "Quarter":
					dataTimeFrame = DataTimeFrame.Quarter;
					break;
				case "Year":
					dataTimeFrame = DataTimeFrame.Year;
					break;
				default:
					dataTimeFrame = DataTimeFrame.Minute;
					break;
			}

			return dataTimeFrame;
		}
		public static BarTimeFrame GetTimeFrameForAPI(DataTimeFrame tf, DataFeedSouce dataFeed)
		{
			if (dataFeed == DataFeedSouce.AlpacaV2)
			{
				if (tf == DataTimeFrame.Minute)
					return BarTimeFrame.Minute;
				if (tf == DataTimeFrame.Hour)
					return BarTimeFrame.Hour;
				if (tf == DataTimeFrame.Day)
					return BarTimeFrame.Day;
			}

			return BarTimeFrame.Minute;
		}

		public static int GetTimeSpanFromTimeFrame(DataTimeFrame tf)
		{
			int span = 0;
			switch(tf)
			{
				case DataTimeFrame.Minute:
					span = 1;
					break;
				case DataTimeFrame.Hour:
					span = 60;
					break;
				case DataTimeFrame.Day:
					span = 1440;
					break;
				case DataTimeFrame.Week:
					span = 10080;
					break;
				default:
					span = 1;
					break;
			}

			return span;
		}

		public static void WriteLog(string content, string message = null)
		{
			string dateTime = DateTime.Now.ToString();
			try
			{
				File.AppendAllText("error.log", dateTime + " : " + content + " - " + message + Environment.NewLine);
			}
			catch
			{

			}
		}

		public static List<int> LoadMultiplier(string file)
		{
			try
			{
				string[] multiplier = File.ReadAllLines(file);
				if (multiplier.Length == 0)
					return null;

				return multiplier.Select(x => int.Parse(x)).ToList();
			}
			catch
			{
				return null;
			}
		}

		public static Dictionary<int, List<IntervalTimeData>> LoadIntervalFromFile(string filename)
		{
			Dictionary<int, List<IntervalTimeData>> intervals = new Dictionary<int, List<IntervalTimeData>>();

			try
			{
				string[] lines = File.ReadAllLines(filename);
				if (lines.Length == 0)
					return intervals;


				string[] headerItems = lines[0].Split(',');
				List<int> multipliers = new List<int>();
				foreach (var header in headerItems)
				{
					int multiplier = 0;
					if (int.TryParse(header, out multiplier))
					{
						intervals[multiplier] = new List<IntervalTimeData>();
						multipliers.Add(multiplier);
					}
				}

				for (int i = 1; i < lines.Length; i++)
				{
					string[] items = lines[i].Split(',');
					if (items.Length == 0)
						continue;

					for (int j = 0; j < items.Length; j++)
					{
						DateTime tm = new DateTime();
						bool bret = DateTime.TryParseExact(items[j], "H:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out tm);

						if (bret)
						{
							IntervalTimeData itd = new IntervalTimeData();
							itd.Hour = tm.Hour;
							itd.Minute = tm.Minute;
							itd.Second = 0;
							intervals[multipliers[j]].Add(itd);
						}
					}
				}
			}
			catch (Exception e)
			{
				WriteLog(e.ToString());
			}
			return intervals;
		}

		public static void OutputBars(string filename, List<RawData> bars, bool bAppend)
		{
			if (bars.Count == 0)
				return;

			try
			{
				List<string> contents = new List<string>();
				if (!bAppend)
					contents.Add(bars[0].Header());
				foreach (var bar in bars)
					contents.Add(bar.ToString());

				if (bAppend)
					File.AppendAllLines(filename, contents);
				else
					File.WriteAllLines(filename, contents);
			}
			catch (Exception e)
			{
				WriteLog(e.ToString());
			}
		}
	}
}
