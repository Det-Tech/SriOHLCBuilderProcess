using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel.Data
{
	[Serializable]
	public class RawData
	{
		public DateTime Datetime { get; set; }
		public double Open { get; set; }
		public double High { get; set; }
		public double Low { get; set; }
		public double Close { get; set; }
		public double Volume { get; set; }
		public string Symbol { get; set; }
		public RawData()
		{

		}

		public virtual string Header()
		{
			return "Date,Time,Open,High,Low,Close,Volume";
		}
		public override string ToString()
		{
			string nfRound = "0." + new string('#', GlobalData.Config.General.RoundPoints);
			string nf = "0.##";
			string ret = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}",
				",", Datetime.ToString("MM/dd/yyyy"), Datetime.ToString("HH:mm:ss"),
				Open.ToString(nf), High.ToString(nf), Low.ToString(nf), Close.ToString(GlobalData.Config.General.RoundClose ? nfRound : nf),
				Volume.ToString(GlobalData.Config.General.RoundVolume ? nfRound : nf));

			return ret;
		}
	}
}
