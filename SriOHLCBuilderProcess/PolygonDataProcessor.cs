using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using SriOHLCBuilderModel.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebSocket4Net;

namespace SriOHLCBuilderProcess
{
	public partial class SriOHLCBuilderProcessor
	{
		async Task<bool> ProcessPolygonData(List<string> symbols, int multiplier, string strPath)
		{
			using (var httpClient = new HttpClient())
			{
				foreach (var symbol in symbols)
				{
					if (bStopProcess)
						break;
					await ProcessPolygonData(symbol, strPath);
				}
			}

			return true;
		}

		async Task<bool> ProcessPolygonData(string symbol, string strPath)
		{
			ServicePointManager.ServerCertificateValidationCallback =
				delegate (object sender, X509Certificate certificate, X509Chain
	 chain, SslPolicyErrors sslPolicyErrors)
				{
					return true;
				};
			using (var httpClient = new HttpClient())
			{

				string timeSpan = "minute";
				switch (Config.General.TimeFrame)
				{
					case DataTimeFrame.Minute:
						timeSpan = "minute";
						break;
					case DataTimeFrame.Hour:
						timeSpan = "hour";
						break;
					case DataTimeFrame.Day:
						timeSpan = "day";
						break;
					case DataTimeFrame.Week:
						timeSpan = "week";
						break;
					case DataTimeFrame.Month:
						timeSpan = "month";
						break;
					case DataTimeFrame.Quarter:
						timeSpan = "quarter";
						break;
					case DataTimeFrame.Year:
						timeSpan = "year";
						break;
				}

				List<RawData> dataList = new List<RawData>();
				DateTime startDate = Config.General.StartDate;
				int requestCounter = 0;
				while (true)
				{
					if (bStopProcess)
						break;

					int multiplier = 1;
					string url = string.Format("{0}/{1}/range/{2}/{3}/{4}/{5}?unadjuested={6}&sort={7}&limit={8}&apiKey={9}"
					, "https://api.polygon.io/v2/aggs/ticker", symbol, multiplier,
					timeSpan, startDate.ToString("yyyy-MM-dd"), Config.General.EndDate.ToString("yyyy-MM-dd"),
					Config.PolygonConfig.Unadjusted, Config.PolygonConfig.Sort, Config.General.BarLimit, Config.PolygonConfig.APIKey);

					var response = await httpClient.GetAsync(url);

					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						var msg = await response.Content.ReadAsStringAsync();
						dynamic obj = JsonConvert.DeserializeObject(msg);
						if (obj.results != null)
						{
							var dataListTemp = new List<RawData>();
							foreach (var child in obj.results)
							{
								RawData data = new RawData();
								data.Open = child.o;
								data.High = child.h;
								data.Low = child.l;
								data.Close = child.c;
								data.Volume = child.v;
								data.Symbol = symbol;
								data.Symbol = symbol.Replace(":", ".");
								data.Symbol = symbol.Replace("/", "");
								TimeSpan time = TimeSpan.FromMilliseconds((double)child.t);
								//data.Datetime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) + time;
								data.Datetime = new DateTime(1970, 1, 1) + time;
								data.Datetime = data.Datetime.AddHours(-4);
								dataListTemp.Add(data);
							}

							if (dataList.Count > 0)
							{
								RawData firstItem = dataListTemp.First();
								int nLastItem = 0;
								for (int kk = dataList.Count - 1; kk >= 0; kk--)
								{
									if (dataList[kk].Datetime == firstItem.Datetime)
									{
										nLastItem = kk;
										break;
									}
									else if (dataList[kk].Datetime < firstItem.Datetime)
									{
										nLastItem = kk - 1;
										break;
									}
								}

								dataListTemp = dataListTemp.Skip(dataList.Count - nLastItem).ToList();
							}
							dataList.AddRange(dataListTemp);
							if (dataList.Last().Datetime.Date >= Config.General.EndDate.Date || dataListTemp.Count == 0)
								break;

							startDate = dataList.Last().Datetime.Date;
						}
						else
						{
							requestCounter++;
							if (requestCounter > 2)
								break;
							System.Threading.Thread.Sleep(61000);
						}
					}
					else
						break;
				}

				ProcessAPIData(dataList, symbol.Replace(":", ".").Replace("/", ""), strPath);
			}

			return true;
		}
		DataTimeFrame GetTimeFrameFromString(string str)
		{
			if (str == "Minute")
				return DataTimeFrame.Minute;
			if (str == "Hour")
				return DataTimeFrame.Hour;
			else if (str == "Day")
				return DataTimeFrame.Day;
			else if (str == "Week")
				return DataTimeFrame.Week;
			else if (str == "Month")
				return DataTimeFrame.Month;

			return DataTimeFrame.Minute;
		}
	
		double GetLevelValue(double val, CalSettings config)
		{
			return val;
		}
		void CalcSignalFromLavg(List<RDataRecord> dataList)
		{
			if (dataList.Count == 0)
				return;

			List<int> lavgValues = new List<int>();
			foreach (var data in dataList)
			{
				switch (Config.Cal.SignalLavg)
				{
					case 0:
						lavgValues.Add(Math.Sign(data.Lavg1));
						break;
					case 2:
						lavgValues.Add(Math.Sign(data.Lavg2));
						break;
					case 3:
						lavgValues.Add(Math.Sign(data.Lavg3));
						break;
					case 4:
						lavgValues.Add(Math.Sign(data.Lavg4));
						break;
				}

				data.Stcb = data.Stcs = 0;
			}

			int prevSignal = lavgValues[0];

			for (int i = 1; i < lavgValues.Count; i++)
			{
				if (prevSignal != lavgValues[i] && lavgValues[i] != 0)
				{
					if (lavgValues[i] == 1)
					{
						dataList[i].Stcb = dataList[i].Close;
					}
					else
					{
						dataList[i].Stcs = dataList[i].Close;
					}
					prevSignal = lavgValues[i];
				}
			}
		}
		void CalcLevelFromLavg(List<RDataRecord> dataList)
		{
			if (dataList.Count == 0)
				return;

			int level = dataList[0].LValues.Count;

			foreach (var data in dataList)
				data.LValues.Clear();

			if (level > 0)
			{
				for (int i = 1; i < dataList.Count; i++)
				{
					double[] lavgsCur = new double[] { dataList[i].Lavg1, dataList[i].Lavg2, dataList[i].Lavg3, dataList[i].Lavg4 };
					double[] lavgsPrev = new double[] { dataList[i - 1].Lavg1, dataList[i - 1].Lavg2, dataList[i - 1].Lavg3, dataList[i - 1].Lavg4 };

					double curChange = lavgsCur[Config.Cal.LavgToUse];
					double prevChange = lavgsPrev[Config.Cal.LavgToUse];

					var data = dataList[i];

					for (int j = 1; j <= level; j++)
					{
						if (i < j)
							break;

						if (j == 1)
						{
							dataList[i].LValues.Add(GetLevelValue(curChange + prevChange, null));
							continue;
						}

						dataList[i].LValues.Add(GetLevelValue(dataList[i - 1].LValues[j - 1 - 1] + curChange, null));
					}
				}
			}
		}
		void CalLavg(List<RDataRecord> dataList)
		{

			var config = Config.Cal;

			for (int i = 0; i < dataList.Count; i++)
			{
				var data = dataList[i];
				var lCount = dataList[i].LValues.Count;

				if (config.LAvg1Start <= lCount)
				{
					double sum = 0;
					int lEnd = Math.Min(config.LAvg1End - 1, lCount - 1);
					for (int j = config.LAvg1Start - 1; j <= lEnd; j++)
						sum += data.LValues[j];

					data.Lavg1 = sum / (config.LAvg1End - config.LAvg1Start + 1);
				}

				if (config.LAvg2Start <= lCount)
				{
					double sum = 0;
					int lEnd = Math.Min(config.LAvg2End - 1, lCount - 1);
					for (int j = config.LAvg2Start - 1; j <= lEnd; j++)
						sum += data.LValues[j];

					data.Lavg2 = sum / (config.LAvg2End - config.LAvg2Start + 1);
				}

				if (config.LAvg3Start <= lCount)
				{
					double sum = 0;
					int lEnd = Math.Min(config.LAvg3End - 1, lCount - 1);
					for (int j = config.LAvg3Start - 1; j <= lEnd; j++)
						sum += data.LValues[j];

					data.Lavg3 = sum / (config.LAvg3End - config.LAvg3Start + 1);
				}

				if (config.LAvg4Start <= lCount)
				{
					double sum = 0;
					int lEnd = Math.Min(config.LAvg4End - 1, lCount - 1);
					for (int j = config.LAvg4Start - 1; j <= lEnd; j++)
						sum += data.LValues[j];

					data.Lavg4 = sum / (config.LAvg4End - config.LAvg4Start + 1);
				}
			}
		}

		void OutputData(string symbol, List<RDataRecord> mergeResult, string suffix)
		{
			var dataSet = mergeResult;
			string filename = "";

			string outputPath;
			if (Config.Cal.OutputNewFormat)
			{
				outputPath = Path.Combine(Config.General.OutputFolder, "new");
				filename = Path.Combine(outputPath, symbol + ".csv");
			}
			else
			{
				outputPath = Path.Combine(Config.General.OutputFolder, "old");
				filename = Path.Combine(outputPath, symbol + "-" + suffix + ".csv");
			}
			if (!Directory.Exists(outputPath))
				Directory.CreateDirectory(outputPath);

			string header = "";
			if (Config.Cal.OutputNewFormat)
				header = "Date,Time,Close,Lavg1,Lavg2,Lavg3,Lavg4";
			else
			{
				header = dataSet[0].Header() + ",";
				header += string.Join(",", Config.General.Multipliers.Select(x => "L" + x));
			}
			StringBuilder sb = new StringBuilder();

			sb.AppendLine(header);
			int level = dataSet.Last().LValues.Count;
			for (int i = 0; i < dataSet.Count; i++)
			{
				var data = dataSet[i];

				if (Config.Cal.OutputOnlyCompleteRow && i < level)
					continue;

				if (Config.Cal.OutputNewFormat)
					sb.AppendFormat("{0},{1},{2},{3},{4},{5},{6}", 
						data.Datetime.ToString("M/d/yy"), data.Datetime.ToString("HH:mm"),
						data.Close, data.Lavg1, data.Lavg2, data.Lavg3, data.Lavg4).AppendLine();
				else
					sb.AppendLine(data.ToString());
			}

			try
			{
				File.WriteAllText(filename, sb.ToString());

				if (Config.NetMQConfig.EnableZMQ && Config.NetMQConfig.SendPerSymbol)
					MessageSender?.Invoke(filename);
			}
			catch
			{

			}
		}
	}
}
