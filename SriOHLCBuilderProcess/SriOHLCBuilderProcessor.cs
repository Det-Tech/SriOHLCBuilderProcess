using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alpaca.Markets;
using SriOHLCBuilderModel;
using System.Net.Http;
using WebSocket4Net;
using System.Security.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TwelveDataSharp;
using PusherServer;
using SriOHLCBuilderModel.Enums;
using SriOHLCBuilderModel.Data;

namespace SriOHLCBuilderProcess
{
	public partial class SriOHLCBuilderProcessor
	{
		private const int RDataItemCount = 117;
		public delegate void ProcessNotifierDelegate(ProcessState state, int param);
		public delegate void MessageSenderDeleagate(string msg);
		public ProcessNotifierDelegate ProcessNotifier { get; set; }
		public MessageSenderDeleagate MessageSender { get; set; }
		public enum ProcessState { None, Start, Stop, Progress, Pause, Complete, ConnectionError, TimeOut, Waiting, UnknownError, SocketConnected, Appended, Calendar, ROutputStart, ROutputCompleted, TrimRawData, CleanupTree, CleanupStockList, LimitExceeded }
		protected List<string> symbolListAll { get; set; } = new List<string>();
		private bool bStopProcess;
		private int procSymbolCounter = 0;
		private int procSymbolTotal = 0;
		public List<DataTimeFrame> TimeFrames { get; set; }
		private List<DayTradeTime> tradeTimeList = new List<DayTradeTime>();

		private Dictionary<string, List<RawData>> baseData = new Dictionary<string, List<RawData>>();
		private Dictionary<string, List<RawData>> newData = new Dictionary<string, List<RawData>>();
		private Dictionary<int, Dictionary<string, List<RawData>>> bufferData = new Dictionary<int, Dictionary<string, List<RawData>>>();
		Dictionary<DataTimeFrame, int> tfIntervals = new Dictionary<DataTimeFrame, int>();
		List<int> multipliers = new List<int>();
		Dictionary<int, List<IntervalTimeData>> intervals = new Dictionary<int, List<IntervalTimeData>>();
		BackgroundWorker worker = new BackgroundWorker();
		BackgroundWorker workerTSTick = new BackgroundWorker();
		bool historyMode = false;
		public SriOHLCBuilderSettings Config
		{
			get
			{
				return GlobalData.Config;
			}
		}
		public bool StopROutput { get; set; }

		bool bWorkerIsRunning = false;

		public SriOHLCBuilderProcessor()
		{
			tfIntervals.Add(DataTimeFrame.Second, 1);
			tfIntervals.Add(DataTimeFrame.Minute, 1);
			tfIntervals.Add(DataTimeFrame.Minute5, 5);
			tfIntervals.Add(DataTimeFrame.Minute15, 15);
			tfIntervals.Add(DataTimeFrame.Hour, 60);
			tfIntervals.Add(DataTimeFrame.Day, 1440);
			tfIntervals.Add(DataTimeFrame.Week, 10080);
			tfIntervals.Add(DataTimeFrame.Month, 43200);
			tfIntervals.Add(DataTimeFrame.Quarter, 129600);
			tfIntervals.Add(DataTimeFrame.Year, 518400);

			worker.WorkerReportsProgress = true;
			worker.DoWork += worker_DoWork;
			worker.ProgressChanged += worker_ProgressChanged;
			worker.RunWorkerCompleted += worker_RunWorkerCompleted;
		}

		private void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			Config.General.Multipliers = Utils.LoadMultiplier(Config.General.MultiplierFile).ToArray();
			intervals = Utils.LoadIntervalFromFile(Config.General.MultiplierScheduleFile);

			int nThreadCount = Environment.ProcessorCount;

			int nNeedApiCallCount = symbolListAll.Count / 50;

			nThreadCount = Math.Min(nThreadCount, nNeedApiCallCount);

			if (nThreadCount == 0)
				nThreadCount = 1;

			if (Config.General.DataFeedSource == DataFeedSouce.AlpacaV2)
				PrepareAlpacaAPI();

			var query = symbolListAll
					.Select((p, index) => new { p, GroupIndex = index % nThreadCount })
					.GroupBy(p => p.GroupIndex)
					.ToArray();

			nThreadCount = query.Length;

			ProcessNotifier?.Invoke(ProcessState.Start, symbolListAll.Count);

			Task[] tasks = new Task[nThreadCount];

			List<PolygonDataFeedSettings> polygonConfigs = new List<PolygonDataFeedSettings>();
			
			polygonConfigs.Add(Config.PolygonConfig);

			procSymbolCounter = 0;
			procSymbolTotal = symbolListAll.Count;

			for (int i = 0; i < nThreadCount; i++)
			{
				var symbols = query[i].Select(p => p.p).ToList();

				tasks[i] = Task.Run(() => Run(symbols));
			}
			Task.WaitAll(tasks);

			if (Config.NetMQConfig.EnableZMQ)
			{
				if (Config.NetMQConfig.SendPerCycle)
					MessageSender?.Invoke(Config.General.OutputFolder);

				MessageSender?.Invoke("Cycle completed!");
			}

			if (Config.AWSS3Config.UseAWSUpload)
			{
				AWSS3Uploader uploader = new AWSS3Uploader();
				var taskUploader = Task.Run(() => uploader.UploadFilesAsFolder(Config.General.OutputFolder, "Bars", Config.AWSS3Config));
			}
		}
		private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			ProcessNotifier?.Invoke(ProcessState.Progress, e.ProgressPercentage);
		}
		private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			ProcessNotifier?.Invoke(ProcessState.Complete, 0);
			bWorkerIsRunning = false;
			bStopProcess = false;
		}
		public void Start(bool bHistoryMode = false)
		{
			if (bWorkerIsRunning)
				return;

			historyMode = bHistoryMode;
			bWorkerIsRunning = true;
			worker.RunWorkerAsync();
		}
		public bool CheckMinBaseData()
		{
			bool bRet = true;
			var dataSet = LoadDataFromLocal(symbolListAll, Config.General.InputFolder);
			intervals = Utils.LoadIntervalFromFile(Config.General.MultiplierScheduleFile);
			multipliers = Utils.LoadMultiplier(Config.General.MultiplierFile);
			int lastMultplier = multipliers.Last();

			if (!intervals.ContainsKey(lastMultplier))
			{
				Utils.WriteLog($"The schedule of multiplier {lastMultplier} does not exist.");
				return false;
			}

			var schedule = intervals[lastMultplier];
			int minDays = (30 + schedule.Count - 1) / schedule.Count;

			foreach (var symbol in symbolListAll)
			{
				if (dataSet.ContainsKey(symbol))
				{
					var bars = dataSet[symbol];
					int dayCount = 1;
					DateTime baseDate = bars[0].Datetime.Date;
					for (int i = 1; i < bars.Count; i++)
					{
						if (bars[i].Datetime.Date != baseDate)
						{
							baseDate = bars[i].Datetime.Date;
							dayCount++;
						}
					}

					if (dayCount < minDays)
					{
						Utils.WriteLog($"The data for symbol {symbol} is not enough({dayCount}/{minDays}).");
						bRet = false;
					}
				}
				else
				{
					Utils.WriteLog($"The data for symbol {symbol} does not exist.");
					bRet = false;
				}
			}

			return bRet;
		}
		public void ClearOriginalData()
		{
			baseData.Clear();
		}
		private string GetSymbolFromPath(string path)
		{
			FileInfo file = new FileInfo(path);
			string[] info = file.Name.Split('-');
			if (info.Length >= 2)
				return info[0];

			return null;
		}

		public void PrepareAPIClient()
		{

		}

		private void OutputRawDataToFile(List<RawData> dataList, string symbol, string outputPath)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Date,Time,Open,High,Low,Close,Volume");

			foreach (var data in dataList)
				sb.Append(data).AppendLine();

			try
			{
				if (!Directory.Exists(outputPath))
					Directory.CreateDirectory(outputPath);

				string strFilePath = Path.Combine(outputPath, symbol + ".csv");
				File.WriteAllText(strFilePath, sb.ToString());
			}
			catch (Exception ex)
			{
				Console.Write(ex);
			}
		}

		public async Task Run(List<string> symbols)
		{
			bStopProcess = false;

			List<DataTimeFrame> timeFrames = new List<DataTimeFrame>();

			if (bStopProcess)
				return;

			var startTime = DateTime.Now;
			if (Config.General.DataFeedSource == DataFeedSouce.TwelveData && !historyMode)
			{
				await ProcessSymbolForTwelve(symbols);
			}
			else
				await ProcessSymbol(symbols);

			double elapsed = (DateTime.Now - startTime).TotalMilliseconds;
			if (elapsed < 500)
			{
				int timeToWait = Math.Max(0, (int)(500 - elapsed));
				System.Threading.Thread.Sleep(timeToWait);
			}

			if (bStopProcess)
				ProcessNotifier?.Invoke(ProcessState.Stop, 0);

			bStopProcess = false;

			StopROutput = true;
		}
		private double GetCloseBarValue(double open, double high, double low, double close)
		{
			if (Config.General.CloseBarUpdateMode == 0)     //HLC
				return (high + low + close) / 3.0;
			else if (Config.General.CloseBarUpdateMode == 1)    //OHLC
				return (open + high + low + close) / 4.0;
			else if (Config.General.CloseBarUpdateMode == 2)    //HL
				return (high + low) / 2.0;
			else
			{
				if (close > open)
					return high;
				else if (close < open)
					return low;
				else
					return close;
			}
		}

		private DateTime GetLastDataTimeFromFile(string filePath)
		{
			if (File.Exists(filePath))
			{
				try
				{
					using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						StreamReader sr = new StreamReader(fs);

						string line, lastLine = "";
						bool bFirstLine = true;
						while ((line = sr.ReadLine()) != null)
						{
							if (bFirstLine)
							{
								bFirstLine = false;
								continue;
							}
							if (!string.IsNullOrEmpty(line))
								lastLine = line;
						}
						sr.Close();

						string[] items = lastLine.Split(',');

						if (items.Length < 2)
							return new DateTime(1970, 1, 1);

						return DateTime.Parse(items[0] + " " + items[1]);
					}
				}
				catch (Exception e)
				{
					Utils.WriteLog("Error reading File " + filePath, e.Message);
					return new DateTime(1970, 1, 1);
				}
			}
			else
				return new DateTime(1970, 1, 1);
		}

		Dictionary<string, List<RawData>> LoadDataFromLocal(List<string> symbols, string folder)
		{
			Dictionary<string, List<RawData>> localData = new Dictionary<string, List<RawData>>();

			foreach (var symbol in symbols)
			{
				localData[symbol] = LoadDataFromLocal(symbol, folder);
			}

			return localData;
		}
		List<RawData> LoadDataFromLocal(string symbol, string folder)
		{
			string symbol_ = symbol.Replace(":", ".");
			symbol_ = symbol.Replace("/", "");
			string filePath = Path.Combine(folder, symbol_ + ".csv");

			if (!File.Exists(filePath))
				return null;
			
			var localData = SriOHLCBuilderServices.LoadRawDataFromCsv(filePath, false);

			return localData;
		}
		private void ProcessAPIData(IReadOnlyList<RawData> bars, string symbol, string strFilePath)
		{
			symbol = symbol.Replace(":", "");
			symbol = symbol.Replace("\\", "");
			symbol = symbol.Replace("/", "");

			if (!Directory.Exists(strFilePath))
				Directory.CreateDirectory(strFilePath);

			var strOutputFile = Path.Combine(strFilePath, symbol + ".csv");

			StringBuilder sb = new StringBuilder();

			//create header only in non-append mode
			if ((!Config.General.AppendUpdatedData && !Config.General.BackfillUpate) || !File.Exists(strOutputFile))
			{
				sb.AppendLine("Date,Time,Open,High,Low,Close,Volume");
			}

			List<string> dataList = new List<string>();

			List<RawData> rawDataList = new List<RawData>();
			TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
			foreach (var bar in bars)
			{
				DateTime barTime = bar.Datetime;		//compare by EST time

				if (Config.General.EnableMarketTimeOnly && (int)Config.General.TimeFrame < 6)
				{
					DateTime startTime = new DateTime(barTime.Year, barTime.Month, barTime.Day,
												Config.General.MarketStartTime.Hour, Config.General.MarketStartTime.Minute, 0);
					DateTime endTime = new DateTime(barTime.Year, barTime.Month, barTime.Day,
												Config.General.MarketEndTime.Hour, Config.General.MarketEndTime.Minute, 0);

					if (barTime < startTime || barTime > endTime)
						continue;
				}

				RawData inputData = bar;

				if (Config.General.EnableCloseBarUpdate)
				{
					inputData.Close = GetCloseBarValue(bar.Open, bar.High, bar.Low, bar.Close);
				}

				if (inputData.Close == 0)
					continue;

				rawDataList.Add(inputData);
				dataList.Add(inputData.ToString());
			}

			//find last row
			DateTime lastDataTime = Config.General.BackfillUpate ? GetLastDataTimeFromFile(strOutputFile) : DateTime.Now.AddHours(2);

			int nLastRow = -1;

			if (rawDataList.Count == 0)
				return;

			if (rawDataList.Last().Datetime < lastDataTime)
			{
				if (Config.General.BackfillUpate)
					nLastRow = dataList.Count - 1;
			}
			else
			{
				for (int i = 0; i < rawDataList.Count; i++)
				{
					if (rawDataList[i].Datetime == lastDataTime)
					{
						nLastRow = i;
						break;
					}
					else if (rawDataList[i].Datetime > lastDataTime)
					{
						nLastRow = i - 1;
						break;
					}
				}
			}

			for (int i = nLastRow + 1; i < dataList.Count; i++)
			{
				sb.Append(dataList[i]).Append(Environment.NewLine);
			}

			if (nLastRow >= 0 && (Config.General.BackfillUpate || Config.General.AppendUpdatedData))
				rawDataList = rawDataList.Skip(nLastRow + 1).ToList();

			//if backfill enabled, load original date to generate R File
			if (!baseData.ContainsKey(symbol))
				baseData[symbol] = SriOHLCBuilderServices.LoadRawDataFromCsv(strOutputFile);

			if (!newData.ContainsKey(symbol))
				newData[symbol] = new List<RawData>();

			newData[symbol].AddRange(rawDataList);

			try
			{
				if (Config.General.AppendUpdatedData || Config.General.BackfillUpate)
					File.AppendAllText(strOutputFile, sb.ToString());
				else
					File.WriteAllText(strOutputFile, sb.ToString());
			}
			catch (Exception e)
			{
				Utils.WriteLog("Error writing stock data for " + symbol, e.Message);
			}
		}
		string GetTimeFrameSuffix(DataTimeFrame tf)
		{
			if (tf == DataTimeFrame.Minute)
				return "M";
			else if (tf == DataTimeFrame.Hour)
				return "H";
			else if (tf == DataTimeFrame.Day)
				return "D";
			else if (tf == DataTimeFrame.Week)
				return "D";
			else if (tf == DataTimeFrame.Month)
				return "MO";

			return "";
		}
		private async Task<bool> ProcessSymbol(List<string> symbols)
		{
			BarBuilder barBuilder = new BarBuilder();
			bool bRet = true;

			foreach (var symbol in symbols)
			{
				string strFolder = Config.General.InputFolder;
				if (historyMode)
				{
					ProcessLocalData(symbol, strFolder);
				}
				else
				{
					switch (Config.General.DataFeedSource)
					{
						case DataFeedSouce.OnlyLocalData:
							ProcessLocalData(symbol, strFolder);
							break;
						case DataFeedSouce.AlpacaV2:
							await ProcessAlpacaV2Data(symbol, strFolder);
							break;
						case DataFeedSouce.TradeStation:
							ProcessTradeStationData(symbol, strFolder);
							break;
						case DataFeedSouce.TDAmeritrade:
							await ProcessTDAmeritradeData(symbol, strFolder);
							break;
						case DataFeedSouce.PolygonV2:
							await ProcessPolygonData(symbol, strFolder);
							break;
						case DataFeedSouce.OandaData:
							await ProcessOandaData(symbol, strFolder);
							break;
					}
				}

				string symbol_ = symbol.Replace(":", ".");
				
				if (!newData.ContainsKey(symbol_))
					continue;

				for (int i = 0; i < Config.General.Multipliers.Length; i++)
				{
					int multiplier = Config.General.Multipliers[i];
					if (!bufferData.ContainsKey(multiplier))
						bufferData[multiplier] = new Dictionary<string, List<RawData>>();

					if (!bufferData[multiplier].ContainsKey(symbol_))
						bufferData[multiplier][symbol_] = new List<RawData>();

					string outputFolder = Path.Combine(Config.General.OutputFolder, multiplier + GetTimeFrameSuffix(Config.General.TimeFrame));

					if (!Directory.Exists(outputFolder))
						Directory.CreateDirectory(outputFolder);
					
					string filename = Path.Combine(outputFolder, symbol_ + ".csv");
					List<RawData> barData = new List<RawData>();
					bool dataExisting = File.Exists(filename) && Config.General.BackfillUpate;

					if (!File.Exists(filename) && baseData.ContainsKey(symbol_) && Config.General.BackfillUpate)
						barData.AddRange(baseData[symbol_]);
					else if (multiplier != 1)
						barData.AddRange(bufferData[multiplier][symbol_]);

					barData.AddRange(newData[symbol_]);
					
					if (barData.Count == 0)
						continue;

					var interval = intervals.ContainsKey(multiplier) ? intervals[multiplier] : null;
					var newBar = barBuilder.BuildBar(barData, multiplier, interval, Config.General.TimeFrame,
						historyMode ? false : Config.General.BuildTodayBarOnly,
						historyMode ? Config.General.BuildHistoryEndDate : DateTime.Now,
						Config.General.DontCalVol, Config.General.UseCloseBarTimestamp,
						Config.General.LastTimestampException);

					if (newBar != null)
					{
						if (newBar.Count < barData.Count / multiplier)
						{

						}
						Utils.OutputBars(filename, newBar, dataExisting);

						//Cleanup
						if (Config.DataCleanupConfig.Enable)
						{
							Cleanup(symbol, newBar, Config.DataCleanupConfig, multiplier);
							string cleanupOutputFolder = Path.Combine(Config.DataCleanupConfig.CleanupOutputFolder, multiplier + GetTimeFrameSuffix(Config.General.TimeFrame));
							if (!Directory.Exists(cleanupOutputFolder))
								Directory.CreateDirectory(cleanupOutputFolder);
							string cleanupFile = Path.Combine(cleanupOutputFolder, symbol + ".csv");
							Utils.OutputBars(cleanupFile, newBar, dataExisting);

						}
						if (Config.NetMQConfig.SendPerSymbol && i == Config.General.Multipliers.Length - 1)
						{
							MessageSender?.Invoke(filename);
						}

						bufferData[multiplier][symbol_].Clear();
					}
					else
					{
						bufferData[multiplier][symbol_].AddRange(newData[symbol_]);
					}
				}

				newData[symbol_].Clear();

				procSymbolCounter++;
				if (procSymbolCounter < procSymbolTotal)
					worker.ReportProgress(procSymbolCounter * 100 / procSymbolTotal);
			}

			return bRet;
		}

		private async Task<bool> ProcessSymbolForTwelve(List<string> symbols)
		{
			BarBuilder barBuilder = new BarBuilder();
			bool bRet = true;

			await ProcessTwelveData(symbols, Config.General.InputFolder);

			foreach (var symbol in symbols)
			{
				if (!baseData.ContainsKey(symbol))
					return false;

				string symbol_ = symbol.Replace(":", ".");


				for (int i = 0; i < Config.General.Multipliers.Length; i++)
				{
					int multiplier = Config.General.Multipliers[i];

					string outputFolder = Path.Combine(Config.General.OutputFolder, multiplier + GetTimeFrameSuffix(Config.General.TimeFrame));
					if (!Directory.Exists(outputFolder))
						Directory.CreateDirectory(outputFolder);
					string filename = Path.Combine(outputFolder, symbol_ + ".csv");
					
					List<RawData> barData = new List<RawData>();

					bool dataExisting = File.Exists(filename) && Config.General.BackfillUpate;
					if (!File.Exists(filename) && baseData.ContainsKey(symbol_) && Config.General.BackfillUpate)
						barData.AddRange(baseData[symbol_]);

					barData.AddRange(newData[symbol_]);

					var interval = intervals.ContainsKey(multiplier) ? intervals[multiplier] : null;
					var newBar = barBuilder.BuildBar(barData, multiplier, interval, Config.General.TimeFrame,
						historyMode ? false : Config.General.BuildTodayBarOnly,
						historyMode ? Config.General.BuildHistoryEndDate : DateTime.Now,
						Config.General.DontCalVol, Config.General.UseCloseBarTimestamp,
						Config.General.LastTimestampException);

					if (newBar != null)
					{

						Utils.OutputBars(filename, newBar, dataExisting);

						if (Config.NetMQConfig.SendPerSymbol && i == Config.General.Multipliers.Length - 1)
						{
							MessageSender?.Invoke(filename);
						}
					}
				}

				procSymbolCounter++;
				if (procSymbolCounter < procSymbolTotal)
					worker.ReportProgress(procSymbolCounter * 100 / procSymbolTotal);
			}

			return bRet;
		}
		bool IsBarScheduled(int multiplier)
		{
			if (historyMode)
				return true;

			if (!intervals.ContainsKey(multiplier))
				return false;

			for (int i = 0; i < intervals[multiplier].Count; i++)
			{
				var intervalData = intervals[multiplier][i];
				if (intervalData.Hour == DateTime.Now.Hour && intervalData.Minute == DateTime.Now.Minute)
					return true;
			}

			return false;
		}
		public bool PrepareStockSymbolList(string fileName, bool bAdd = false)
		{
			try
			{
				using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					StreamReader sr = new StreamReader(fs);

					string line;

					if (!bAdd)
						symbolListAll.Clear();

					while ((line = sr.ReadLine()) != null)
					{
						if (string.IsNullOrEmpty(line))
							continue;

						symbolListAll.Add(line);
					}

					sr.Close();
				}
			}
			catch (Exception e)
			{
				Utils.WriteLog("Failed to load symbol list from the input file.", e.Message);
				return false;
			}

			return true;
		}

		public void Stop()
		{
			bStopProcess = true;
		}

		public void Pause()
		{
		}
		
		string GetOutputPathWithTimeFrame(DataTimeFrame tf)
		{
			string strTimeFrame = Utils.GetNameFromTimeFrame(tf);

			string path = Path.Combine(Config.General.OutputFolder, strTimeFrame);

			return path;
		}

		List<RawData> updatedData = new List<RawData>();
		DateTime lastFetchTime = DateTime.Now;

		public void PrepareCalendarListFromFile()
		{
			tradeTimeList.Clear();
			try
			{
				TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

				using (var fs = new FileStream(GlobalData.GetCalendarFilePath(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
				{
					StreamReader sr = new StreamReader(fs);
					string line = sr.ReadLine();        //header row
					while ((line = sr.ReadLine()) != null)
					{
						string[] items = line.Split(',');
						if (items.Length < 3)
							continue;

						try
						{
							var dayTradeTime = new DayTradeTime();
							dayTradeTime.Open = TimeZoneInfo.ConvertTimeToUtc(DateTime.ParseExact(items[0] + " " + items[1],
															"MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture), estTimeZone);
							dayTradeTime.Close = TimeZoneInfo.ConvertTimeToUtc(DateTime.ParseExact(items[0] + " " + items[2],
															"MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture), estTimeZone);

							tradeTimeList.Add(dayTradeTime);
						}
						catch
						{

						}
					}
					sr.Close();
				}
			}
			catch (Exception e)
			{
				Utils.WriteLog("Error reading calendar File", e.Message);
			}
		}

		//time to check in UTC timezone
		public bool IsTimeInMarketHour(DateTime time)
		{
			foreach (var day in tradeTimeList)
			{
				if (time.Date == day.Open.Date)
				{
					Config.General.MarketStartTime = day.Open.ToLocalTime();
					Config.General.MarketEndTime = day.Close.ToLocalTime();

					if (time >= day.Open && time < day.Close)
						return true;

					break;
				}
			}
			return false;
		}

		public bool IsLocalTimeInMarketHour(DateTime localTime)
		{
			DateTime now = DateTime.Now;

			DateTime startTime = new DateTime(now.Year, now.Month, now.Day,
													GlobalData.Config.General.MarketStartTime.Hour, GlobalData.Config.General.MarketStartTime.Minute, 0);
			DateTime endTime = new DateTime(now.Year, now.Month, now.Day,
										GlobalData.Config.General.MarketEndTime.Hour, GlobalData.Config.General.MarketEndTime.Minute, 0);

			if (startTime > now || endTime < now)
				return false;

			return true;
		}
	}
}
