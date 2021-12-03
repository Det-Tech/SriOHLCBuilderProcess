using SriOHLCBuilderModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class GeneralSettings
	{
		public DataFeedSouce DataFeedSource { get; set; }
		public string SymbolListFile { get; set; }
		public string InputFolder { get; set; }
		public string OutputFolder { get; set; }
		public string MultiplierFile { get; set; }
		public string MultiplierScheduleFile { get; set; }
		public bool EnableMarketTimeOnly { get; set; } = true;
		public DateTime MarketStartTime { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 9, 30, 0);
		public DateTime MarketEndTime { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 16, 0, 0);
		public bool IsStaticMode { get; set; } = true;
		public bool AppendUpdatedData { get; set; }
		public bool EnableCloseBarUpdate { get; set; }
		public int CloseBarUpdateMode { get; set; }
		public bool EnableCalendarAutoUpdate { get; set; }
		public int AutoUpdateDelay { get; set; }
		public int RoundPoints { get; set; } = 2;
		public bool RoundClose { get; set; }
		public bool RoundChange { get; set; }
		public bool RoundVolume { get; set; }
		public DataTimeFrame TimeFrame { get; set; }
		public int BarLimit { get; set; } = 100;
		public int[] Multipliers { get; set; }
		public DateTime StartDate { get; set; } = DateTime.Now.AddDays(-7);
		public DateTime EndDate { get; set; } = DateTime.Now;
		public bool BackfillUpate { get; set; }
		public bool BuildTodayBarOnly { get; set; }
		public DateTime BuildHistoryEndDate { get; set; } = DateTime.Now;
		public bool DontCalVol { get; set; }
		public bool AutoBuildEOD { get; set; }
		public bool UseCloseBarTimestamp { get; set; }
		public bool LastTimestampException { get; set; }
		public string TimeSpanStr { get; set; }
		public string OandaAccessToken { get; set; }
	}
}
