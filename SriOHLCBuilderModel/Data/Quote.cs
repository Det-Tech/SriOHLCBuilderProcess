using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel.Data
{
	public class Quote
	{
        public double Ask { get; set; }
        public string AskPriceDisplay { get; set; }
        public double AskSize { get; set; }
        public string AssetType { get; set; }
        public double Bid { get; set; }
        public string BidPriceDisplay { get; set; }
        public double BidSize { get; set; }
        public double Close { get; set; }
        public string ClosePriceDisplay { get; set; }
        public string CountryCode { get; set; }
        public string Currency { get; set; }
        public double DailyOpenInterest { get; set; }
        public string DataFeed { get; set; }
        public string Description { get; set; }
        public double DisplayType { get; set; }
        public string Error { get; set; }
        public string Exchange { get; set; }
        public string ExpirationDate { get; set; }
        public string FirstNoticeDate { get; set; }
        public bool FractionalDisplay { get; set; }
        public bool Halted { get; set; }
        public double High { get; set; }
        public double High52Week { get; set; }
        public string High52WeekPriceDisplay { get; set; }
        public string High52WeekTimeStamp { get; set; }
        public string HighPriceDisplay { get; set; }
        public bool IsDelayed { get; set; }
        public double Last { get; set; }
        public string LastPriceDisplay { get; set; }
        public double LastSize { get; set; }
        public string LastTradingDate { get; set; }
        public string LastVenue { get; set; }
        public double Low { get; set; }
        public double Low52Week { get; set; }
        public string Low52WeekPriceDisplay { get; set; }
        public string Low52WeekTimeStamp { get; set; }
        public string LowPriceDisplay { get; set; }
        public double MaxPrice { get; set; }
        public string MaxPriceDisplay { get; set; }
        public double MinMove { get; set; }
        public double MinPrice { get; set; }
        public string MinPriceDisplay { get; set; }
        public string NameExt { get; set; }
        public double NetChange { get; set; }
        public double NetChangePct { get; set; }
        public double Open { get; set; }
        public string OpenPriceDisplay { get; set; }
        public double PointValue { get; set; }
        public double PreviousClose { get; set; }
        public string PreviousClosePriceDisplay { get; set; }
        public double PreviousVolume { get; set; }
        public List<string> Restrictions { get; set; }
        public double StrikePrice { get; set; }
        public string StrikePriceDisplay { get; set; }
        public string Symbol { get; set; }
        public string SymbolRoot { get; set; }
        public double TickSizeTier { get; set; }
        public string TradeTime { get; set; }
        public string Underlying { get; set; }
        public double Volume { get; set; }
        public double VWAP { get; set; }
        public string VWAPDisplay { get; set; }
    }
}
