using Newtonsoft.Json;
using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderProcess
{
	public partial class SriOHLCBuilderProcessor
	{
		async Task<bool> ProcessOandaData(string symbol, string strPath)
		{
			var config = Config.PolygonConfig;

			using (var httpClient = new HttpClient())
			{
				try
				{

					string startTime = Config.General.StartDate.ToString("yyyy-MM-ddT00:00:00").Replace(":", "%3A");
					string endTime = Config.General.EndDate.ToString("yyyy-MM-ddT00:00:00").Replace(":", "%3A");
					string url = $"https://api-fxtrade.oanda.com/v3/instruments/{symbol}/candles?count={Config.General.BarLimit}&granularity={config.TimeSpanStr}" +
						$"&from={startTime}&to={endTime}";

					httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Config.General.OandaAccessToken);

					var response = await httpClient.GetAsync(url);

					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						var msg = await response.Content.ReadAsStringAsync();
						dynamic obj = JsonConvert.DeserializeObject(msg);
						if (obj.candles != null)
						{
							var dataListTemp = new List<RawData>();

							foreach (var child in obj.candles)
							{
								RawData data = new RawData();
								data.Open = child.mid.o;
								data.High = child.mid.h;
								data.Low = child.mid.l;
								data.Close = child.mid.c;
								data.Volume = child.volume;
								data.Symbol = symbol;
								data.Symbol = symbol.Replace(":", ".");
								data.Symbol = symbol.Replace("/", "");
								data.Datetime = child.time;
								data.Datetime = data.Datetime.AddHours(-4);
								dataListTemp.Add(data);
							}

							ProcessAPIData(dataListTemp, symbol.Replace(":", ".").Replace("/", ""), strPath);
						}
					}
				}
				catch
				{

				}
			}

			return true;
		}
	}
}
