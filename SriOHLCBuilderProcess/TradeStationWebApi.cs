using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using SriOHLCBuilderModel.Enums;

namespace SriOHLCBuilderProcess
{
    class TradeStationWebApi
    {
        public delegate void ProcData(List<RawData> dataList, string symbol, DataTimeFrame timeFrame, string folderPath, bool bClean, bool bRealTimeData); 
        private string Key { get; set; }
        private string Secret { get; set; }
        private string RefreshToken { get; set; }
        private string Host { get; set; }
        public HttpStatusCode LastStatus { get; set; }
        private string RedirectUri { get; set; } = "http://localhost:1125";
        string TSDataAPIEndPoint { get; set; } = "https://api.tradestation.com/v2";
        string TSDataAPIEndPointSim { get; set; } = "https://sim.api.tradestation.com/v2";
        private AccessToken Token { get; set; }
        int keyCounter;
        int apiCallCounter;
        string path = Environment.CurrentDirectory;
        public APIKeyModel[] Keys { get; set; }
        DateTime apiStartTime = DateTime.Now;
        DateTime lastAccessTokenTime;
        public TradeStationWebApi()
		{
            apiStartTime = DateTime.Now;
            lastAccessTokenTime = new DateTime();
        }

        public bool PrepareAPI()
		{
            Host = GlobalData.Config.TradeStationConfig.IsLive ? TSDataAPIEndPoint : TSDataAPIEndPointSim;

            if (Keys == null)
                Keys = APIKeyModel.LoadFromFile("APIKeys.txt");
            if (apiCallCounter >= 500 && GlobalData.Config.TradeStationConfig.UseMultipleTokens)
			{
                keyCounter = (keyCounter + 1) % Keys.Length;
                if (keyCounter == 0)
				{
                    double elpasedSeconds = (DateTime.Now - apiStartTime).TotalSeconds;
                    if (elpasedSeconds < 300)
					{
                        int waitTo = 300 - (int)elpasedSeconds + 5;
                        while (!StopStream && --waitTo > 0)
                            System.Threading.Thread.Sleep(1000);
					}
                    if (StopStream)
                        return false;

                    apiStartTime = DateTime.Now;
				}
                lastAccessTokenTime = new DateTime();
                apiCallCounter = 0;
			}

            Key = Keys[keyCounter].APIKey;
            Secret = Keys[keyCounter].SecretKey;
            RefreshToken = Keys[keyCounter].RefreshToken;
            apiCallCounter++;

            if ((DateTime.Now - lastAccessTokenTime).TotalSeconds >= 1190)      //1200 seconds maximum
            {
                int nRetryCounter = 0;
                do
                {
                    Token = GetAccessToken(RefreshToken, "");
                    lastAccessTokenTime = DateTime.Now;
                } while (Token == null && nRetryCounter++ < 3);

                if (Token == null)
                    return false;
            }

            return true;
		}
        public TradeStationWebApi(string key, string secret, string host, string redirecturi)
        {
            this.Key = key;
            this.Secret = secret;
            this.RedirectUri = redirecturi;

            this.Host = host;

            // Disable Tls 1.0 and use Tls 1.2
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            // these two lines are only needed if .net 4.5 is not installed
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.DefaultConnectionLimit = 9999;

            string refresh_token = "";
            try
            {
                refresh_token = System.IO.File.ReadAllText(path + "\\RefreshToken.txt");
                this.Token = GetAccessToken(refresh_token, "");
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
            }
            if (refresh_token == "")
            {
                this.Token = GetAccessToken(GetAuthorizationCode());
                System.IO.File.WriteAllText(Path.Combine(path, "RefreshToken.txt"), this.Token.refresh_token);
            }
            try
            {
                if (this.Token != null)
                {
                    System.IO.File.WriteAllText(Path.Combine(path, "Token.txt"), this.Token.access_token);
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
            }
        }

        private string GetAuthorizationCode()
        {
            var url = string.Format("{0}/{1}", this.Host,
                    string.Format(
                        "authorize?client_id={0}&response_type=code&redirect_uri={1}",
                        this.Key,
                        "http://localhost:1125/"));

            Process.Start(url);

            using (var listener = new HttpListener())
            {
                listener.Prefixes.Add("http://localhost:1125/");
                listener.Start();

                var context = listener.GetContext();
                var req = context.Request;
                var res = context.Response;

                listener.Stop();
                return req.QueryString.Get("code");
            }
        }

        public AccessToken GetAccessToken(string authcode)
        {
            var request = WebRequest.Create(string.Format("{0}/security/authorize", this.Host)) as HttpWebRequest;
            request.Method = "POST";
            var postData =
                string.Format(
                    "grant_type=authorization_code&code={0}&client_id={1}&redirect_uri={2}&client_secret={3}",
                    authcode,
                    this.Key,
                    this.RedirectUri,
                    this.Secret);
            var byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            try
            {
                return GetDeserializedResponse<AccessToken>(request);
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
                return null;
            }
        }
        private AccessToken GetAccessToken(string refresh_token, string refresh)
        {

            var request = WebRequest.Create(string.Format("{0}/security/authorize", this.Host)) as HttpWebRequest;
            request.Method = "POST";
            var postData =
                string.Format(
                    "grant_type=refresh_token&reponse_type=token&refresh_token={0}&client_id={1}&redirect_uri={2}&client_secret={3}",
                    refresh_token,
                    this.Key,
                    this.RedirectUri,
                    this.Secret);
            var byteArray = Encoding.UTF8.GetBytes(postData);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;

            var dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            try
            {
                return GetDeserializedResponse<AccessToken>(request);
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
                return null;
            }
        }

        private static T GetDeserializedResponse<T>(WebRequest request)
        {
            var response = request.GetResponse() as HttpWebResponse;
            var receiveStream = response.GetResponseStream();
            var readStream = new StreamReader(receiveStream, Encoding.UTF8);
            var ser = new JavaScriptSerializer();
            ser.MaxJsonLength = int.MaxValue;
            var json = readStream.ReadToEnd();
            var scrubbedJson =
                json.Replace(
                    "\"__type\":\"EquitiesOptionsOrderConfirmation:#TradeStation.Web.Services.DataContracts\",", ""); // hack
            var deserializaed = ser.Deserialize<T>(scrubbedJson);
            response.Close();
            readStream.Close();
            return deserializaed;
        }
        internal IEnumerable<Quote> GetQuote(string symbols)
        {
            var resourceUri = new Uri(string.Format("{0}/data/quote/{1}?access_token={2}", this.Host,
                symbols, this.Token.access_token));

            var request = WebRequest.Create(resourceUri) as HttpWebRequest;
            request.Method = "GET";

            try
            {
                return GetDeserializedResponse<IEnumerable<Quote>>(request);
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
                return null;
            }
        }
        internal IEnumerable<Symbol> SymbolSuggest(string suggestText)
        {
            var resourceUri = new Uri(string.Format("{0}/{1}/{2}?access_token={3}", this.Host, "data/symbols/suggest", suggestText, this.Token.access_token));

            var request = WebRequest.Create(resourceUri) as HttpWebRequest;
            request.Method = "GET";

            try
            {
                return GetDeserializedResponse<IEnumerable<Symbol>>(request);
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
                return null;
            }
        }
        internal IEnumerable<BarChart> GetBarChart(string symbol, string interval, string unit, string barsBack, string endDate, string SessionTemplate)
        {
            var resourceUri =
                new Uri(string.Format("{0}/stream/barchart/{1}/{2}/{3}/{4}/{5}?SessionTemplate={6}&access_token={7}"
                , this.Host, symbol, interval, unit, barsBack, endDate, SessionTemplate, this.Token.access_token));

            var request = WebRequest.Create(resourceUri) as HttpWebRequest;
            request.Accept = "application/vnd.tradestation.streams+json";
            request.Method = "GET";

            var response = request.GetResponse() as HttpWebResponse;
            LastStatus = response.StatusCode;

            if (response.StatusCode == HttpStatusCode.Forbidden)
			{

			}
            else if (response.StatusCode == HttpStatusCode.OK)
			{
                var receiveStream = response.GetResponseStream();
                var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                var ser = new JavaScriptSerializer();
                ser.MaxJsonLength = int.MaxValue;
                var json = "";
				try
				{
                    json = readStream.ReadToEnd();
                    var scrubbedJson = json.Replace("END", "").Trim(); // hack
                    scrubbedJson = scrubbedJson.Replace("{\"Close\"", ",{\"Close\"") + "]";
                    scrubbedJson = '[' + scrubbedJson.Remove(0, 1);
                    var deserializaed = ser.Deserialize<IEnumerable<BarChart>>(scrubbedJson);
                    response.Close();
                    readStream.Close();
                    deserializaed = deserializaed.OrderBy(x => x.TimeStamp);
                    return deserializaed;
                }
                catch (Exception e)
				{
                    Utils.WriteLog(e.ToString());
				}
            }
            return null;
            
        }
        public bool StopStream { get; set; }
        internal async void GetTickBars(string symbol, int interval, int barsBack,string session, int procInterval, ProcData procFunc, string outputPath)
        {
            while (!StopStream)
			{
                if (!PrepareAPI())
                    break;

                var resourceUri =
                new Uri(string.Format("{0}/stream/tickbars/{1}/{2}/{3}?SessionTemplate={4}&access_token={5}&heartbeat=true"
                , this.Host, symbol, interval, barsBack, session, this.Token.access_token));

                using (var client = new HttpClient())
                {
                    try
                    {
                        var response = await client.GetAsync(resourceUri, HttpCompletionOption.ResponseHeadersRead);
                        if (response.StatusCode == HttpStatusCode.Forbidden)
                        {
                        }
                        else
                        {
                            var receiveStream = await response.Content.ReadAsStreamAsync();
                            using (var readStream = new StreamReader(receiveStream, Encoding.UTF8))
                            {
                                var ser = new JavaScriptSerializer();
                                ser.MaxJsonLength = int.MaxValue;
                                DateTime startTime = DateTime.Now;
                                List<string> strList = new List<string>();

                                while (!StopStream)
                                {
                                    string json = "";
                                    json = readStream.ReadLine();
                                    if (json?.IndexOf("expired") >= 0)
                                        break;

                                    if (string.IsNullOrEmpty(json))
                                    {
                                        break;
                                    }

                                    strList.Add(json);

                                    double elapsed = (DateTime.Now - startTime).TotalSeconds;
                                    if (elapsed > procInterval)
                                    {
                                        var dataList = new List<RawData>();

                                        foreach (var data in strList)
                                        {
                                            if (data == null || data.IndexOf("TotalVolume") < 0)
                                                continue;

                                            var item = ser.Deserialize<TickBar>(data);
                                            RawData rawData = new RawData();
                                            rawData.Datetime = item.TimeStamp;
                                            rawData.Close = item.Close;
                                            rawData.Volume = item.TotalVolume;
                                            dataList.Add(rawData);
                                        }
                                        dataList = dataList.OrderBy(x => x.Datetime).ToList();
                                        procFunc?.Invoke(dataList, symbol, DataTimeFrame.Minute, outputPath, false, true);
                                        startTime = DateTime.Now;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        string err = ex.ToString();
                        if (err.IndexOf("RROR") >= 0)
						{

						}

                        Utils.WriteLog(err);
                        Utils.WriteLog("Reconnecting to Tick stream....");
                    }

                    if (StopStream)
                        break;
                    System.Threading.Thread.Sleep(60000);
                }
            }
		}

        internal IEnumerable<BarChart> GetBarChartStartingOnDate(string symbol, string interval, string unit, string StartDate, string SessionTemplate)
        {
            var resourceUri =
                new Uri(string.Format("{0}/stream/barchart/{1}/{2}/{3}/{4}?SessionTemplate={5}&access_token={6}"
                , this.Host, symbol, interval, unit, StartDate, SessionTemplate, this.Token.access_token));
            var request = WebRequest.Create(resourceUri) as HttpWebRequest;
            request.Accept = "application/vnd.tradestation.streams+json";
            request.Method = "GET";

            try
            {
                var response = request.GetResponse() as HttpWebResponse;
                LastStatus = response.StatusCode;
                if (response.StatusCode == HttpStatusCode.Forbidden)
                {

                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    var receiveStream = response.GetResponseStream();
                    var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    var ser = new JavaScriptSerializer();
                    ser.MaxJsonLength = int.MaxValue;
                    var json = readStream.ReadToEnd();
                    var scrubbedJson = json.Replace("END", "").Trim(); // hack
                    scrubbedJson = scrubbedJson.Replace("{\"Close\"", ",{\"Close\"") + "]";
                    scrubbedJson = '[' + scrubbedJson.Remove(0, 1);
                    var deserializaed = ser.Deserialize<IEnumerable<BarChart>>(scrubbedJson);
                    response.Close();
                    readStream.Close();
                    return deserializaed;
                }
                return null;
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
                return null;
            }
        }
        internal IEnumerable<BarChart> GetBarChartDateRange(string symbol, string interval, string unit, string StartDate, string EndDate, string SessionTemplate)
        {
            var resourceUri =
                new Uri(string.Format("{0}/stream/barchart/{1}/{2}/{3}/{4}/{5}?SessionTemplate={6}&access_token={7}"
                , this.Host, symbol, interval, unit, StartDate, EndDate, SessionTemplate, this.Token.access_token));
            var request = WebRequest.Create(resourceUri) as HttpWebRequest;
            request.Accept = "application/vnd.tradestation.streams+json";
            request.Method = "GET";

            try
            {
                var response = request.GetResponse() as HttpWebResponse;
                LastStatus = response.StatusCode;

                if (response.StatusCode == HttpStatusCode.Forbidden)
                {
                    
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    var receiveStream = response.GetResponseStream();
                    var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    var ser = new JavaScriptSerializer();
                    ser.MaxJsonLength = int.MaxValue;
                    var json = readStream.ReadToEnd();
                    var scrubbedJson = json.Replace("END", "").Trim(); // hack
                    scrubbedJson = scrubbedJson.Replace("{\"Close\"", ",{\"Close\"") + "]";
                    scrubbedJson = '[' + scrubbedJson.Remove(0, 1);
                    var deserializaed = ser.Deserialize<IEnumerable<BarChart>>(scrubbedJson);
                    response.Close();
                    readStream.Close();
                    deserializaed = deserializaed.OrderBy(x => x.TimeStamp);
                    return deserializaed;
                }
                return null;
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
                return null;
            }
        }
        internal IEnumerable<BarChart> GetBarChartDaysBack(string symbol, string interval, string unit, string SessionTemplate, string daysBack, string lastDate)
        {
            var resourceUri =
                new Uri(string.Format("{0}/stream/barchart/{1}/{2}/{3}?SessionTemplate={4}&daysBack={5}&lastDate={6}&access_token={7}"
                , this.Host, symbol, interval, unit, SessionTemplate, daysBack, lastDate, this.Token.access_token));
            var request = WebRequest.Create(resourceUri) as HttpWebRequest;
            request.Accept = "application/vnd.tradestation.streams+json";
            request.Method = "GET";

            try
            {
                var response = request.GetResponse() as HttpWebResponse;
                LastStatus = response.StatusCode;
                if (response.StatusCode == HttpStatusCode.Forbidden)
				{
                    
				}
                else if (response.StatusCode == HttpStatusCode.OK)
				{
                    var receiveStream = response.GetResponseStream();
                    var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    var ser = new JavaScriptSerializer();
                    ser.MaxJsonLength = int.MaxValue;
                    var json = readStream.ReadToEnd();
                    var scrubbedJson = json.Replace("END", "").Trim(); // hack
                    scrubbedJson = scrubbedJson.Replace("{\"Close\"", ",{\"Close\"") + "]";
                    scrubbedJson = '[' + scrubbedJson.Remove(0, 1);
                    var deserializaed = ser.Deserialize<IEnumerable<BarChart>>(scrubbedJson);
                    response.Close();
                    readStream.Close();
                    return deserializaed;
                }

                return null;
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
                return null;
            }
        }
        internal IEnumerable<Symbol> SearchSymbols(string criteria)
        {
            var resourceUri = new Uri(string.Format("{0}/{1}/{2}?access_token={3}",
                this.Host, "data/symbols/search", criteria, this.Token.access_token));

            var request = WebRequest.Create(resourceUri) as HttpWebRequest;
            request.Method = "GET";

            try
            {
                return GetDeserializedResponse<IEnumerable<Symbol>>(request);
            }
            catch (Exception ex)
            {
                ErrorLog(ex);
                return null;
            }
        }
        private void ErrorLog(Exception ex)
        {
            //string logfile = path + "\\error.log";
            //if (!File.Exists(logfile))
            //{
            //    // Create a file to write to.
            //    using (StreamWriter sw = File.CreateText(logfile))
            //    {
            //        sw.WriteLine(ex.ToString());
            //    }
            //}
            //else
            //{
            //    using (StreamWriter sw = File.AppendText(logfile))
            //    {
            //        sw.WriteLine(ex.ToString());
            //    }
            //}
            Utils.WriteLog(ex.ToString());
        }

		internal string GetRefreshToken()
		{
            this.Token = GetAccessToken(GetAuthorizationCode());
            if (this.Token == null)
                return null;

            return this.Token.refresh_token;
		}
	}
}
