using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderProcess
{
	public partial class SriOHLCBuilderProcessor
	{
		public List<ATTrendData> CalcATTrend(List<RawData> dataSet, ATTrendSettings config)
		{
			var value10 = (2 * config.Risk) + 3;
			var value20 = (20 + 50) + (config.Risk - 3);
			var value21 = (50 - 20) + (3 - config.Risk);
			var value11 = value10;

			List<ATTrendData> ATDataSet = dataSet.Select(x => new ATTrendData(x)).ToList();

			for (int i = 0; i < ATDataSet.Count; i++)
			{
				var data = ATDataSet[i];
				if (i > 10)
				{
					data.Value18 = Math.Abs(data.Close - ATDataSet[i - 3].Close);
					if (data.Open - data.Close > data.Value18 * 2)
						data.OC = 1;
					else
						data.OC = 0;

					if (ATDataSet[i - 3].Close - ATDataSet[i].Close > data.Value18 * 4.6)
						data.CC = 1;
					else
						data.CC = 0;

					for (int j = i; j > i - 9; j--)
						data.SumOC = ATDataSet[j].OC;
					for (int j = i; j > i - 6; j--)
						data.SumCC = ATDataSet[j].CC;

					data.Value11 = data.SumOC >= 1 ? 3 : value10;
					data.Value11 = data.SumCC >= 1 ? 4 : value10;

					data.HH = double.MinValue;
					data.LL = double.MaxValue;
					for (int j = i; j > i - data.Value11 && j >= 0; j--)
					{
						if (data.HH < ATDataSet[j].High)
							data.HH = ATDataSet[j].High;

						if (data.LL > ATDataSet[j].Low)
							data.LL = ATDataSet[j].Low;
					}

					data.HHLL = data.HH - data.LL;

					if (data.HHLL != 0)
						data.Value1 = 100 - (100 * (data.HH - data.Close) / data.HHLL);
					else
						data.Value1 = 0;

					if (data.Value1 > value20)
					{
						data.PlotColor = 1;
						data.BuyOK = true;
						data.SellOK = false;
					}
					else if (data.Value1 < value21)
					{
						data.PlotColor = -1;
						data.BuyOK = false;
						data.SellOK = true;
					}
					else
					{
						data.PlotColor = 0;
						data.BuyOK = ATDataSet[i - 1].BuyOK;
						data.SellOK = ATDataSet[i - 1].SellOK;
					}

					data.BuyStop = data.Low - 0.5 * data.Value18;
					data.SellStop = data.High - 0.5 * data.Value18;

					if (ATDataSet[i - 1].SellOK && data.BuyOK && data.Close > ATDataSet[i - 1].Close)
						data.Stcb = 1;
					if (ATDataSet[i - 1].BuyOK && data.SellOK && data.Close < ATDataSet[i - 1].Close)
						data.Stcs = -1;

					if (data.Stcs == 0 && data.Stcb == 0)
					{
						data.Stcs = ATDataSet[i - 1].Stcs;
						data.Stcb = ATDataSet[i - 1].Stcb;
					}
				}
				else
				{
					double sum = 0;
					for (int j = i; j >= 0 && j >= i - 10; j--)
					{
						sum += ATDataSet[j].High - ATDataSet[j].Low;
					}
					sum /= Math.Min(i + 1, 10);
					ATDataSet[i].Value18 = sum;
				}
			}

			return ATDataSet;
		}

		public List<STTrendData> CalcSTTrend(List<RawData> dataSet, STTrendSettings config)
		{
			List<STTrendData> STDataSet = dataSet.Select(x => new STTrendData(x)).ToList();

			for (int i = 0; i < STDataSet.Count; i++)
			{
				var data = STDataSet[i];
				var prevData = new STTrendData();
				if (i > 0)
					prevData = STDataSet[i - 1];
				else
					prevData.TrendDown = 99999;

				if (prevData.Close > data.High)
					data.TrueHigh = prevData.Close;
				else
					data.TrueHigh = data.High;

				if (prevData.Close < data.Low)
					data.TrueLow = prevData.Close;
				else
					data.TrueLow = data.Low;

				data.TrueRange = data.TrueHigh - data.TrueLow;

				if (i > 10)
				{
					for (int j = i; j >= 0 && j > i - config.Pd; j--)
						data.ATR += STDataSet[j].TrueRange;

					data.ATR /= Math.Min(i + 1, config.Pd);
				}
				else
					data.ATR = double.MaxValue;

				double factorATR = (config.Factor * data.ATR);
				data.Up = (data.High + data.Low) / 2 - factorATR;
				data.Down = (data.High + data.Low) / 2 + factorATR;

				if (prevData.Close > prevData.TrendUp)
					data.TrendUp = Math.Max(prevData.TrendUp, data.Up);
				else
					data.TrendUp = prevData.Up;

				if (prevData.Close < prevData.TrendDown)
					data.TrendDown = Math.Min(prevData.TrendDown, data.Down);
				else
					data.TrendDown = prevData.Down;

				if (data.Close > prevData.TrendDown)
					data.MyTrend = 1;
				else if (data.Close < prevData.TrendUp)
					data.MyTrend = -1;
				else
					data.MyTrend = prevData.MyTrend;

				if (data.MyTrend == 1)
				{
					data.STPrice = data.TrendUp;
					data.STTrend = 1;
				}
				else
				{
					data.STPrice = data.TrendDown;
					if (data.STPrice >= 99999)
						data.STPrice = 0;
					data.STTrend = -1;
				}
			}

			return STDataSet;
		}
	}
}
