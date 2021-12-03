using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel.Data
{
	[Serializable]
	public class RawDataUDVol : RawData
	{
		public double UpVolume { get; set; }
		public double DownVolume { get; set; }

		public override string Header()
		{
			bool addOI = false;

			return "Date,Time,Open,High,Low,Close,UpVol,DwVol" + (addOI ? ",OI" : "");
		}
		public override string ToString()
		{
			bool addOI = false;
			string nfRound = "0.##";
			string nf = "0.##";
			string ret = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}",
				",", Datetime.ToString("MM/dd/yyyy"), Datetime.ToString("HH:mm:ss"),
				Open.ToString(nf), High.ToString(nf), Low.ToString(nf), Close.ToString(GlobalData.Config.General.RoundClose ? nfRound : nf),
				UpVolume.ToString(GlobalData.Config.General.RoundVolume ? nfRound : nf), DownVolume.ToString(GlobalData.Config.General.RoundVolume ? nfRound : nf));

			return ret;
		}
	}

	[Serializable]
	public class RawDataUDTicksVol : RawData
	{
		public double UpVolume { get; set; }
		public double DownVolume { get; set; }
		public double UpTick { get; set; }
		public double DownTick { get; set; }

		public override string Header()
		{
			bool addOI = false;
			return "Date,Time,Open,High,Low,Close,UpTicks,DownTicks,UpVol,DwVol" + (addOI ? ",OI" : "");
		}
		public override string ToString()
		{
			bool addOI = false;
			string nfRound = "0.##";
			string nf = "0.##";
			string ret = string.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}{0}{8}{0}{9}{0}{10}",
				",", Datetime.ToString("MM/dd/yyyy"), Datetime.ToString("HH:mm:ss"),
				Open.ToString(nf), High.ToString(nf), Low.ToString(nf), Close.ToString(GlobalData.Config.General.RoundClose ? nfRound : nf),
				UpTick.ToString(GlobalData.Config.General.RoundVolume ? nfRound : nf), DownTick.ToString(GlobalData.Config.General.RoundVolume ? nfRound : nf),
				UpVolume.ToString(GlobalData.Config.General.RoundVolume ? nfRound : nf), DownVolume.ToString(GlobalData.Config.General.RoundVolume ? nfRound : nf));

			return ret;
		}
	}
}
