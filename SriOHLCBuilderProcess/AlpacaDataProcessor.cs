using Alpaca.Markets;
using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using SriOHLCBuilderModel.Enums;
using SriOHLCBuilderProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderProcess
{
	public partial class SriOHLCBuilderProcessor
	{
		private IAlpacaDataClient alpacaDataClient;

		void PrepareAlpacaAPI()
		{
			if (Config.AlpacaConfig.IsLive)
			{
				alpacaDataClient = Environments.Live.GetAlpacaDataClient(new SecretKey(Config.AlpacaConfig.APIKey, Config.AlpacaConfig.SecretKey));
			}
			else
			{
				alpacaDataClient = Environments.Paper.GetAlpacaDataClient(new SecretKey(Config.AlpacaConfig.APIKey, Config.AlpacaConfig.SecretKey));
			}
		}
		async Task<bool> ProcessAlpacaV1Data(List<string> symbols, DataTimeFrame timeFrame, string strPath, bool bCleanup)
		{
			Console.WriteLine("Start -------- " + DateTime.Now.ToString());
			string token = "";
			BarTimeFrame tf = Utils.GetTimeFrameForAPI(Config.General.TimeFrame, Config.General.DataFeedSource);

			List<RawData> bars = new List<RawData>();
			Dictionary<string, List<RawData>> barSets = new Dictionary<string, List<RawData>>();
			while (true)
			{
				if (bStopProcess)
					break;
				try
				{
					var request = new HistoricalBarsRequest(symbols, Config.General.StartDate, Config.General.EndDate, tf);
					request.Pagination.Size = (uint)Config.General.BarLimit;
					request.Pagination.Token = token;
					var barSet = await alpacaDataClient.GetHistoricalBarsAsync(request);
					foreach (var key in barSet.Items.Keys)
					{
						if (!barSets.ContainsKey(key))
						{
							Console.WriteLine(key);
							barSets[key] = new List<RawData>();
						}
						barSets[key].AddRange(barSet.Items[key].Select(bar => new RawData
						{
							Datetime = bar.TimeUtc.AddHours(-4),
							Open = (double)bar.Open,
							High = (double)bar.High,
							Low = (double)bar.Low,
							Close = (double)bar.Close,
							Volume = (double)bar.Volume,
						}));
					}

					token = barSet.NextPageToken;
					if (string.IsNullOrEmpty(token))
						break;
				}
				catch (Exception e)
				{
					Utils.WriteLog("ProcessSymbol", e.Message);
				}
			}

			//foreach (var symbol in barSets.Keys)
			//	ProcessAPIData(barSets[symbol], symbol, strPath);
			Console.WriteLine("End -------- " + DateTime.Now.ToString());

			return true;
		}

		async Task<bool> ProcessAlpacaV2Data(List<string> symbols, string strPath)
		{
			foreach (var symbol in symbols)
			{
				await ProcessAlpacaV2Data(symbol, strPath);
			}

			return true;
		}
		async Task<bool> ProcessAlpacaV2Data(string symbol, string strPath)
		{
			string token = "";
			BarTimeFrame tf = Utils.GetTimeFrameForAPI(Config.General.TimeFrame, Config.General.DataFeedSource);

			List<RawData> bars = new List<RawData>();
			while (true)
			{
				if (bStopProcess)
					break;
				try
				{
					var request = new HistoricalBarsRequest(symbol, Config.General.StartDate, Config.General.EndDate, tf);
					request.Pagination.Size = (uint)Config.General.BarLimit;
					request.Pagination.Token = token;
					var barSet = await alpacaDataClient.ListHistoricalBarsAsync(request);
					bars.AddRange(barSet.Items.Select(bar => new RawData
					{
						Datetime = bar.TimeUtc.AddHours(-4),
						Open = (double)bar.Open,
						High = (double)bar.High,
						Low = (double)bar.Low,
						Close = (double)bar.Close,
						Volume = (double)bar.Volume,
					}));

					token = barSet.NextPageToken;
					if (string.IsNullOrEmpty(token))
						break;
				}
				catch (Exception e)
				{
					Utils.WriteLog("ProcessSymbol", e.Message);
				}
			}

			ProcessAPIData(bars, symbol, strPath);

			return true;
		}
	}
}
