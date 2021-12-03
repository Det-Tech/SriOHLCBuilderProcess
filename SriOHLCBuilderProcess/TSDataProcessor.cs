using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using SriOHLCBuilderModel.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SriOHLCBuilderProcess
{
	public partial class SriOHLCBuilderProcessor
	{
		TradeStationWebApi tsApi = new TradeStationWebApi();
		void ProcessTradeStationData(List<string> symbols, string strPath)
		{
			foreach (var symbol in symbols)
			{
				ProcessTradeStationData(symbol, strPath);
			}
		}

		void ProcessTradeStationData(string symbol, string strPath)
		{
			IEnumerable<BarChart> bars = new List<BarChart>();

			if (!tsApi.PrepareAPI())
				return;

			string LastDate = Config.TradeStationConfig.EndDate.ToString("MM-dd-yyyy");
			if (Config.TradeStationConfig.EnableAutoLastDate)
				LastDate = DateTime.Now.AddDays(1).ToString("MM-dd-yyyy");

			if (Config.TradeStationConfig.DataType == TSDataType.DateRange)
			{
				bars = tsApi.GetBarChartDateRange(symbol, Config.TradeStationConfig.Interval.ToString(), Config.TradeStationConfig.Unit.ToString(),
					Config.TradeStationConfig.StartDate.ToString("MM-dd-yyyy"), Config.TradeStationConfig.EndDate.ToString("MM-dd-yyyy"),
					Config.TradeStationConfig.SessionTemplate.ToString());
			}
			else if (Config.TradeStationConfig.DataType == TSDataType.BarsBack)
			{
				bars = tsApi.GetBarChart(symbol, Config.TradeStationConfig.Interval.ToString(),
					Config.TradeStationConfig.Unit.ToString(), Config.TradeStationConfig.BarsBack.ToString(),
					LastDate, Config.TradeStationConfig.SessionTemplate.ToString());
			}
			else if (Config.TradeStationConfig.DataType == TSDataType.DaysBack)
			{
				bars = tsApi.GetBarChartDaysBack(symbol, Config.TradeStationConfig.Interval.ToString(),
					Config.TradeStationConfig.Unit.ToString(), Config.TradeStationConfig.SessionTemplate.ToString(), Config.TradeStationConfig.DaysBack.ToString(),
					LastDate);
			}

			if (bars == null)
			{
				if (tsApi.LastStatus == System.Net.HttpStatusCode.Forbidden)
					ProcessNotifier(ProcessState.LimitExceeded, 0);

				//Thread.Sleep(3000);
				return;
			}

			List<RawData> dataList = new List<RawData>();
			foreach (var bar in bars)
			{
				RawData newData = new RawData();
				newData.Datetime = bar.TimeStamp.AddHours(-4);
				newData.Open = bar.Open;
				newData.High = bar.High;
				newData.Low = bar.Low;
				newData.Close = bar.Close;
				newData.Volume = bar.TotalVolume;
				dataList.Add(newData);
			}
			if (dataList != null && dataList.Count > 0)
			{
				dataList = dataList.OrderBy(x => x.Datetime).ToList();
				ProcessAPIData(dataList, symbol, Config.General.InputFolder);
			}
		}

		public List<string> GetStockSymbolListForTs(string path)
		{
			List<string> symbolList = new List<string>();
			if (string.IsNullOrEmpty(path))
				return symbolList;

			string[] files = Directory.GetFiles(path, "*.txt");
			foreach (var file in files)
			{
				try
				{
					using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						StreamReader sr = new StreamReader(fs);

						string line;

						while ((line = sr.ReadLine()) != null)
						{
							symbolList.Add(line);
						}

						sr.Close();
					}
				}
				catch (Exception e)
				{
					Utils.WriteLog("Failed to load symbol list from the input file.", e.ToString());
					return symbolList;
				}
			}

			return symbolList;
		}
	}
}
