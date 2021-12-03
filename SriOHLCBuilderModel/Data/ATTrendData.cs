using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel.Data
{
	public class ATTrendData : RawData
	{
		public int PlotColor { get; set; }
		public int Stcb { get; set; }
		public int Stcs { get; set; }
		public double Value1 { get; set; }
		public int Value11 { get; set; }
		public double Value18 { get; set; }
		public double OC { get; set; }
		public double CC { get; set; }
		public double SumOC { get; set; }
		public double SumCC { get; set; }
		public bool BuyOK { get; set; }
		public bool SellOK { get; set; }
		public double BuyStop { get; set; }
		public double SellStop { get; set; }
		public double HH { get; set; }
		public double LL { get; set; }
		public double HHLL { get; set; }
		public List<int> LValues { get; set; } = new List<int>();
		public ATTrendData()
		{

		}

		public ATTrendData(RawData raw)
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
