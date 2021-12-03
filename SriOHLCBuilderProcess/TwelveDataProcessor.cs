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
using System.Threading.Tasks;
using TwelveDataSharp;
using TwelveDataSharp.Interfaces;
using TwelveDataSharp.Library.ResponseModels;
using WebSocket4Net;

namespace SriOHLCBuilderProcess
{
    public class TimeSeriesStocks
    {
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("values")]
        public List<Value> Values { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public partial class Meta
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("interval")]
        public string Interval { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("exchange_timezone")]
        public string ExchangeTimezone { get; set; }

        [JsonProperty("exchange")]
        public string Exchange { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class Value
    {
        [JsonProperty("datetime")]
        public DateTime Datetime { get; set; }

        [JsonProperty("open")]
        public string Open { get; set; }

        [JsonProperty("high")]
        public string High { get; set; }

        [JsonProperty("low")]
        public string Low { get; set; }

        [JsonProperty("close")]
        public string Close { get; set; }

        [JsonProperty("volume")]
        public long Volume { get; set; }
    }
    public partial class SriOHLCBuilderProcessor
    {
		async Task<bool> ProcessTwelveData(List<string> symbols, string strPath)
		{
            int maxSymbolCount = Math.Min(symbols.Count, 120);

            for (int i = 0; i < symbols.Count; i += maxSymbolCount)
            {
                List<string> subSymbolList = new List<string>();
                for (int j = i; j < Math.Min(i + maxSymbolCount, symbols.Count); j++)
                    subSymbolList.Add(symbols[j]);

                var dataSet = await GetTimeSeriesAsync(subSymbolList, GetTimeFrameName(Config.General.TimeFrame), Config.TwelveDataConfig.Exchange,
                    GlobalData.Config.TwelveDataConfig.Country, Config.TwelveDataConfig.Type);

                if (dataSet != null)
                {
                    foreach (var symbol in subSymbolList)
                    {
                        if (dataSet.ContainsKey(symbol))
                            ProcessAPIData(dataSet[symbol], symbol, strPath);
                    }
                }
            }
            return true;
		}

        public async Task<List<RawData>> GetTimeSeriesAsync(string symbol, string interval, string exchange, string country, string type)
        {
            try
            {
                string endpoint = "https://api.twelvedata.com/time_series?symbol=" + symbol + "&interval=" + interval +
                                  "&apikey=" + Config.TwelveDataConfig.APIKey + "&exchange=" + 
                                  exchange + "&country=" + country + "&type=" + type + "&outputsize=" + Config.General.BarLimit;

                if (Config.TwelveDataConfig.EnablePrepost)
                    endpoint += "&prepost=" + Config.TwelveDataConfig.Prepost;
                using (var _client = new HttpClient())
				{
                    var response = await _client.GetAsync(endpoint);
                    string responseString = await response.Content.ReadAsStringAsync();

                    try
					{
                        var jsonResponse = JsonConvert.DeserializeObject<TimeSeriesStocks>(responseString);
                        List<RawData> values = new List<RawData>();
                        var tsStockValues = jsonResponse?.Values;
                        if (tsStockValues != null)
                        {
                            values.AddRange(tsStockValues.Select(v => new RawData()
                            {
                                Datetime = v?.Datetime.AddHours(-4) ?? DateTime.MinValue,
                                Open = Convert.ToDouble(v?.Open),
                                High = Convert.ToDouble(v?.High),
                                Low = Convert.ToDouble(v?.Low),
                                Close = Convert.ToDouble(v?.Close),
                                Volume = v.Volume
                            }));
                        }

                        values.Reverse();
                        return values;
                    }
                    catch(Exception e)
					{
                        Utils.WriteLog(e.Message);
                        return null;
					}
                }
            }
            catch (Exception e)
            {
                Utils.WriteLog(e.Message);
                return null;
            }
        }

        public async Task<Dictionary<string, List<RawData>>> GetTimeSeriesAsync(List<string> symbols, string interval, string exchange, string country, string type)
        {

            Dictionary<string, List<RawData>> dataSet = new Dictionary<string, List<RawData>>();

            int symbolsPerCall = 100000 / Config.General.BarLimit;

            for (int k = 0; k < symbols.Count; k += symbolsPerCall)
            {
                try
                {
                    string symbolString = "";
                    for (int j = k; j < Math.Min(k + symbolsPerCall, symbols.Count); j++)
                        symbolString += symbols[j] + ",";

                    symbolString = symbolString.Substring(0, symbolString.Length - 1);

                    string endpoint = "https://api.twelvedata.com/time_series?symbol=" + symbolString + "&interval=" + interval +
                                      "&apikey=" + Config.TwelveDataConfig.APIKey + "&exchange=" +
                                      exchange + "&country=" + country + "&outputsize=" + Config.General.BarLimit;
                    if (!string.IsNullOrEmpty(type))
                        endpoint += "&type=" + type;

                    if (Config.TwelveDataConfig.EnablePrepost)
                        endpoint += "&prepost=" + Config.TwelveDataConfig.Prepost;

                    using (var _client = new HttpClient())
                    {
                        var response = await _client.GetAsync(endpoint);
                        string responseString = await response.Content.ReadAsStringAsync();

                        if (responseString == null)
                            return dataSet;

                        var jsonResponse = JObject.Parse(responseString);

                        foreach (var symbol in symbols)
                        {
                            if (jsonResponse == null || !jsonResponse.ContainsKey(symbol))
                                continue;

                            var jsonResponseForSymbol = JsonConvert.DeserializeObject<TimeSeriesStocks>(jsonResponse[symbol].ToString());
                            List<RawData> values = new List<RawData>();
                            var tsStockValues = jsonResponseForSymbol?.Values;
                            if (tsStockValues != null)
                            {
                                values.AddRange(tsStockValues.Select(v => new RawData()
                                {
                                    Datetime = v?.Datetime.AddHours(-4) ?? DateTime.MinValue,
                                    Open = Convert.ToDouble(v?.Open),
                                    High = Convert.ToDouble(v?.High),
                                    Low = Convert.ToDouble(v?.Low),
                                    Close = Convert.ToDouble(v?.Close),
                                    Volume = v.Volume
                                }));
                            }
                            values.Reverse();
                            dataSet[symbol] = values;
                        }

                    }
                }
                catch
                {

                }
            }
            return dataSet;
        }

        string GetTimeFrameName(DataTimeFrame tf)
		{
            string tfName = "";
			switch (tf)
			{
                case DataTimeFrame.Minute:
                    tfName = "1min";
                    break;
                case DataTimeFrame.Minute5:
                    tfName = "5min";
                    break;
                case DataTimeFrame.Minute15:
                    tfName = "15min";
                    break;
                case DataTimeFrame.Minute30:
                    tfName = "30min";
                    break;
                case DataTimeFrame.Minute45:
                    tfName = "45min";
                    break;
                case DataTimeFrame.Hour:
                    tfName = "1h";
                    break;
                case DataTimeFrame.Hour2:
                    tfName = "2h";
                    break;
                case DataTimeFrame.Hour4:
                    tfName = "4h";
                    break;
                case DataTimeFrame.Day:
                    tfName = "1day";
                    break;
                case DataTimeFrame.Week:
                    tfName = "1week";
                    break;
                case DataTimeFrame.Month:
                    tfName = "1month";
                    break;
                default:
                    tfName = "1min";
                    break;
            }

            return tfName;
		}
    }
}
