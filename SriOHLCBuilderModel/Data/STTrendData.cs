using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel.Data
{
	public class STTrendData : RawData
	{
		public double TrueHigh { get; set; }
		public double TrueLow { get; set; }
		public double TrueRange { get; set; }
		public double ATR { get; set; }
		public double Up { get; set; }
		public double Down { get; set; }
		public double TrendUp { get; set; }
		public double TrendDown { get; set; }
		public double MyTrend { get; set; }
		public double STPrice { get; set; }
		public double STTrend { get; set; }
		public List<int> LValues { get; set; } = new List<int>();
		public STTrendData()
		{

		}

		public STTrendData(RawData raw)
		{
			Datetime = raw.Datetime;
			Open = raw.Open;
			High = raw.High;
			Low = raw.Low;
			Close = raw.Close;
			Volume = raw.Volume;
		}
	}
}
