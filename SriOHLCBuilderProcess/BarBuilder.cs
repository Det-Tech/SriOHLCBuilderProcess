using SriOHLCBuilderModel.Data;
using SriOHLCBuilderModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderProcess
{
	public class BarBuilder
	{
		int FindBaseIndex(List<RawData> baseDataSet, IntervalTimeData schedule, DataTimeFrame timeFrame, int multiplier, bool todayOnly)
		{
			var baseDat = baseDataSet[0].Datetime;

			//if (!todayOnly && baseDat.Hour == 9 && baseDat.Minute == 30)
			//	return 0;

			int spanMinute = Utils.GetTimeSpanFromTimeFrame(timeFrame);
			spanMinute *= multiplier;

			DateTime baseTime = new DateTime(baseDat.Year, baseDat.Month, baseDat.Day, schedule.Hour, schedule.Minute, 0);
			if (todayOnly)
				baseTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, schedule.Hour, schedule.Minute, 0);
			baseTime.AddMinutes(spanMinute);

			for (int i = 0; i < baseDataSet.Count; i++)
			{
				if (todayOnly && baseDataSet[i].Datetime.Date != DateTime.Now.Date)
					continue;

				if (baseDataSet[i].Datetime > baseTime)
				{
					baseTime = baseTime.AddMinutes(spanMinute);
					i--;
					continue;
				}
				if (baseDataSet[i].Datetime.Date == baseTime.Date &&
					baseDataSet[i].Datetime.Hour == baseTime.Hour &&
					baseDataSet[i].Datetime.Minute == baseTime.Minute)
					return i;
			}

			return -1;
		}
		DateTime GetScheduleTimeStamp(List<IntervalTimeData> schedule, DateTime roughTime, ref int missingCount)
		{
			for (int i = 0; i < schedule.Count - 1; i++)
			{
				DateTime dtBefore = new DateTime(roughTime.Year, roughTime.Month, roughTime.Day, schedule[i].Hour, schedule[i].Minute, 0);
				DateTime dtAfter = new DateTime(roughTime.Year, roughTime.Month, roughTime.Day, schedule[i + 1].Hour, schedule[i + 1].Minute, 0);

				if (roughTime >= dtBefore && roughTime < dtAfter)
				{
					missingCount = (int)(roughTime - dtBefore).TotalMinutes;
					return dtBefore;
				}
			}

			return roughTime;
		}
		public List<RawData> BuildBar(List<RawData> baseDataSet, int multiplier, List<IntervalTimeData> schedule, DataTimeFrame tf,
			bool todayOnly, DateTime endDate, bool dontCalVolume = false, bool useCloseBarTime = false,
			bool lastTimestampException = false)
		{
			if (multiplier == 1)
				return baseDataSet;

			int lastTimestampCount = 0;
			if (lastTimestampException && schedule?.Count > 1)
			{
				DateTime lastTime = new DateTime(1970, 1, 1, schedule.Last().Hour, schedule.Last().Minute, 0);
				DateTime beforeLastTime = new DateTime(1970, 1, 1, schedule[schedule.Count - 2].Hour, schedule[schedule.Count - 2].Minute, 0);
				lastTimestampCount = (int)((lastTime - beforeLastTime).TotalMinutes);
			}
			if (baseDataSet.Count == 0)
				return null;

			if (baseDataSet.Count < multiplier)
				return null;

			List<RawData> newBars = new List<RawData>();
			if (tf == DataTimeFrame.Day || tf == DataTimeFrame.Hour)
			{
				for (int i = 0; i < baseDataSet.Count; i += multiplier)
					newBars.Add(baseDataSet[i]);
			}
			else
			{
				IntervalTimeData baseInterval = new IntervalTimeData();
				if (schedule == null || schedule.Count == 0)
					baseInterval = new IntervalTimeData { Hour = 9, Minute = 30 };
				else
					baseInterval = schedule[0];
				int baseIndex = FindBaseIndex(baseDataSet, baseInterval, tf, multiplier, todayOnly);
				if (baseIndex < 0)
					return null;

				int timespan = Utils.GetTimeSpanFromTimeFrame(tf) * multiplier;
				//add first bar
				//newBars.Add(baseDataSet[baseIndex]);
				DateTime baseTime = baseDataSet[baseIndex].Datetime;
				for (int i = baseIndex; i < baseDataSet.Count; i += multiplier)
				{
					var baseData = baseDataSet[i];

					RawData newData = new RawData();
					int missingCount = 0;

					if (schedule != null && schedule.Count > 0)
					{
						if (useCloseBarTime)
						{
							DateTime lastTime = baseDataSet[Math.Min(i + multiplier, baseDataSet.Count - 1)].Datetime;
							baseTime = GetScheduleTimeStamp(schedule, lastTime, ref missingCount);
						}
						else
							baseTime = GetScheduleTimeStamp(schedule, baseDataSet[i].Datetime, ref missingCount);
					}

					if (baseTime.Date > endDate.Date)
						break;

					if (todayOnly && (baseTime.Date != DateTime.Now.Date))
						continue;

					newData.Datetime = baseTime;
					newData.Open = baseData.Open;
					newData.Low = double.MaxValue;

					i -= missingCount;

					if (i > baseDataSet.Count - multiplier)
						i = baseDataSet.Count - multiplier;

					for (int j = i; j < i + multiplier; j++)
					{
						if (j < 0)
							continue;

						var subData = baseDataSet[j];
						if (newData.Low > subData.Low)
							newData.Low = subData.Low;
						if (newData.High < subData.High)
							newData.High = subData.High;

						if (!dontCalVolume)
							newData.Volume += subData.Volume;
					}
					newData.Close = baseDataSet[i + multiplier - 1].Close;
					newBars.Add(newData);

					if (lastTimestampException && newData.Datetime.Hour == 16 && lastTimestampCount > 0 && !useCloseBarTime)
					{
						newData.Volume = 0;
						newData.High = 0;
						newData.Open = baseDataSet[i - lastTimestampCount + 1].Open;
						newData.Low = double.MaxValue;

						for (int j = i - lastTimestampCount + 1; j <= i; j++)
						{
							if (j < 0)
								continue;

							var subData = baseDataSet[j];
							if (newData.Low > subData.Low)
								newData.Low = subData.Low;
							if (newData.High < subData.High)
								newData.High = subData.High;

							if (!dontCalVolume)
								newData.Volume += subData.Volume;
						}
						newData.Close = baseDataSet[i].Close;
					}
					if (schedule == null || schedule.Count == 0)
					{
						if (baseTime.Hour >= 16)
						{
							i -= (multiplier - 1);
						}

						baseTime = baseTime.AddMinutes(timespan);
						if (baseTime.Hour >= 16 && baseTime.Minute > 0)
						{
							baseTime = new DateTime(baseTime.Year, baseTime.Month, baseTime.Day, 9, 30, 0).AddDays(1);
						}
					}

					if (i >= baseDataSet.Count - multiplier)
						break;
				}
			}
			if (newBars.Count >= 2)
			{
				DateTime lastTime = newBars.Last().Datetime;
				int repeatCount = 0;
				for (int i = newBars.Count - 2; i >= 0; i--)
				{
					if (newBars[i].Datetime == lastTime)
						repeatCount++;
				}

				for (int i = 0; i < repeatCount; i++)
					newBars.RemoveAt(newBars.Count - 1);
			}
			return newBars;
		}
	}
}
