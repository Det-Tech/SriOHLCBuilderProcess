using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using SriOHLCBuilderModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SriOHLCBuilderProcess
{
	public partial class SriOHLCBuilderProcessor
	{
		async Task<bool> ProcessTDAmeritradeData(List<string> symbols, string strPath)
		{
			var config = Config.TDAmeritradeConfig;

			int frequency = 1;
			switch (config.Frequency)
			{
				case Frequency.F1:
					frequency = 1;
					break;
				case Frequency.F5:
					frequency = 5;
					break;
				case Frequency.F10:
					frequency = 10;
					break;
				case Frequency.F15:
					frequency = 15;
					break;
				case Frequency.F30:
					frequency = 30;
					break;
			}

			using (var httpClient = new HttpClient())
			{
				foreach (var symbol in symbols)
				{
					try
					{
						string url = $"https://api.tdameritrade.com/v1/marketdata/{symbol}/pricehistory?" +
					$"periodType={config.PeriodType}&period={config.Period}&frequencyType={config.FrequencyType}&frequency={frequency}&needExtendedHoursData={config.NeedExtendedHoursData}";

						if (!config.UseAPIKey)
						{
							while (string.IsNullOrEmpty(tdAccessToken) || (DateTime.Now - tdLastTokenTime).TotalSeconds >= 1790)      //generally expires in 1800S 
							{
								if (!await GetAccessToken())
									Thread.Sleep(1000);
							}
						}

						if (config.UseAPIKey)
							url += $"&apikey={config.APIKey}";
						else
						{
							httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tdAccessToken);
						}

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
									data.Open = child.open;
									data.High = child.high;
									data.Low = child.low;
									data.Close = child.close;
									data.Volume = child.volume;
									data.Symbol = symbol;
									data.Symbol = symbol.Replace(":", ".");
									data.Symbol = symbol.Replace("/", "");
									TimeSpan time = TimeSpan.FromMilliseconds((double)child.datetime);
									data.Datetime = new DateTime(1970, 1, 1) + time;
									data.Datetime = data.Datetime.ToLocalTime();
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
			}

			return true;
		}

		async Task<bool> ProcessTDAmeritradeData(string symbol, string strPath)
		{
			var config = Config.TDAmeritradeConfig;

			int frequency = 1;
			switch (config.Frequency)
			{
				case Frequency.F1:
					frequency = 1;
					break;
				case Frequency.F5:
					frequency = 5;
					break;
				case Frequency.F10:
					frequency = 10;
					break;
				case Frequency.F15:
					frequency = 15;
					break;
				case Frequency.F30:
					frequency = 30;
					break;
			}

			using (var httpClient = new HttpClient())
			{
				try
				{
					string url = $"https://api.tdameritrade.com/v1/marketdata/{symbol}/pricehistory?" +
				$"periodType={config.PeriodType}&period={config.Period}&frequencyType={config.FrequencyType}&frequency={frequency}&needExtendedHoursData={config.NeedExtendedHoursData}";

					if (!config.UseAPIKey)
					{
						while (string.IsNullOrEmpty(tdAccessToken) || (DateTime.Now - tdLastTokenTime).TotalSeconds >= 1790)      //generally expires in 1800S 
						{
							if (!await GetAccessToken())
								Thread.Sleep(1000);
						}
					}

					if (config.UseAPIKey)
						url += $"&apikey={config.APIKey}";
					else
					{
						httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", tdAccessToken);
					}

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
								data.Open = child.open;
								data.High = child.high;
								data.Low = child.low;
								data.Close = child.close;
								data.Volume = child.volume;
								data.Symbol = symbol;
								data.Symbol = symbol.Replace(":", ".");
								data.Symbol = symbol.Replace("/", "");
								TimeSpan time = TimeSpan.FromMilliseconds((double)child.datetime);
								data.Datetime = new DateTime(1970, 1, 1) + time;
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
		string tdAccessToken = "";
		DateTime tdLastTokenTime = new DateTime();
		public async Task<bool> GetAccessToken()
		{
			using (HttpClient client = new HttpClient())
			{
				Config.TDAmeritradeConfig.RefreshToken = Uri.UnescapeDataString(Config.TDAmeritradeConfig.RefreshToken);
				var formContent = new FormUrlEncodedContent(new[]
				{
					new KeyValuePair<string, string>("grant_type", "refresh_token"),
					new KeyValuePair<string, string>("refresh_token", Config.TDAmeritradeConfig.RefreshToken),
					new KeyValuePair<string, string>("client_id", Config.TDAmeritradeConfig.APIKey)
				});

				try
				{
					var response = await client.PostAsync("https://api.tdameritrade.com/v1/oauth2/token", formContent);
					if (response.StatusCode == System.Net.HttpStatusCode.OK)
					{
						var result = await response.Content.ReadAsStringAsync();
						try
						{
							var json = JObject.Parse(result);
							tdAccessToken = (string)json["access_token"];
							tdLastTokenTime = DateTime.Now;
						}
						catch (Exception)
						{
							return false;
						}
					}
					else
					{
						return false;
					}
				}
				catch (Exception)
				{
					return false;
				}
			}

			return true;
		}
	}
}
