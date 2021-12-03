using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel.Data
{
	[Serializable]
	public class RDataRecord : RawData
	{
		public double Stcb { get; set; }
		public double Stcs { get; set; }
		public string Trend { get; set; }
		public double UpperBand { get; set; }
		public double LowerBand { get; set; }
		public double MidLine { get; set; }
		public double Lavg1 { get; set; }
		public double Lavg2 { get; set; }
		public double Lavg3 { get; set; }
		public double Lavg4 { get; set; }
		public double Change { get; set; }
		public List<double> LValues { get; set; } = new List<double>();

		public RDataRecord()
		{

		}

		public RDataRecord(ATTrendData data)
		{
			Datetime = data.Datetime;
			Open = data.Open;
			High = data.High;
			Low = data.Low;
			Close = data.Close;
			Volume = data.Volume;
			if (data.Stcb != 0)
				LValues.Add(data.Stcb);
			else if (data.Stcs != 0)
				LValues.Add(data.Stcs);
			else
				LValues.Add(0);
		}

		public RDataRecord(STTrendData data)
		{
			Datetime = data.Datetime;
			Open = data.Open;
			High = data.High;
			Low = data.Low;
			Close = data.Close;
			Volume = data.Volume;
			LValues.Add(data.STTrend);
		}
		public override string Header()
		{
			string header = "Date,Time,Open,High,Low,Close,Volume,Stcb,Stcs,Trend,UpperBand,LowerBand,MidLine,Lavg1,Lavg2,Lavg3,Lavg4,Change";
			//for (int i = 0; i < LValues.Count; i++)
			//{
			//	header += "L" + (i + 1).ToString();
			//	if (i < LValues.Count - 1)
			//		header += ",";
			//}
			return header;
		}
		public override string ToString()
		{
			string nf = "0.##";
			string nfRound = "0.##";// "0." + new string('#', GlobalData.Config.General.RoundPoints);

			string retString = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},",
				Datetime.ToString("MM/dd/yyyy"), Datetime.ToString("HH:mm:ss"),
				Open.ToString(nf), High.ToString(nf), Low.ToString(nf), Close.ToString(GlobalData.Config.General.RoundClose ? nfRound : nf),
				Volume.ToString(GlobalData.Config.General.RoundVolume ? nfRound : nf), Stcb.ToString(nf), Stcs.ToString(nf), Trend,
				"", "", "", Lavg1.ToString(nf),
				Lavg2.ToString(nf), Lavg3.ToString(nf), Lavg4.ToString(nf), Change.ToString(GlobalData.Config.General.RoundChange ? nfRound : nf));

			retString += string.Join(",", LValues.Select(x => x.ToString()));
			return retString;
		}

		public string Body(bool addLevels)
		{
			string nf = "0.##";
			string nfRound = "0.##";// + new string('#', GlobalData.Config.General.RoundPoints);

			string retString = string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},",
				Datetime.ToString("MM/dd/yyyy"), Datetime.ToString("HH:mm:ss"),
				Open.ToString(nf), High.ToString(nf), Low.ToString(nf), Close.ToString(GlobalData.Config.General.RoundClose ? nfRound : nf),
				Volume.ToString(GlobalData.Config.General.RoundVolume ? nfRound : nf), Stcb.ToString(nf), Stcs.ToString(nf), Trend,
				"", "", "", Lavg1.ToString(nf),
				Lavg2.ToString(nf), Lavg3.ToString(nf), Lavg4.ToString(nf), Change.ToString(GlobalData.Config.General.RoundChange ? nfRound : nf));

			if (addLevels)
				retString += string.Join(",", LValues.Select(x => x.ToString()));

			return retString;
		}
	}
}
