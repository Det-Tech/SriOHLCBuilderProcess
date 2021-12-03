using SriOHLCBuilderModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class TSDataFeedSettings
	{
		public bool IsLive { get; set; }
		public bool UseMultipleTokens { get; set; } = true;
		public string APIKeyFile { get => "APIKeys.txt"; }
		public bool EnableSplitSymbolList { get; set; }
		public string SymbolListFolder { get; set; }
		public TSDataUnit Unit { get; set; }
		public int Interval { get; set; } = 1;
		public TSSessionTemplate SessionTemplate { get; set; }
		public TSDataType DataType { get; set; }
		public DateTime StartDate { get; set; } = DateTime.Now;
		public DateTime EndDate { get; set; } = DateTime.Now;
		public int BarsBack { get; set; }
		public int DaysBack { get; set; }
		public bool EnableAutoLastDate { get; set; }
		public int TickInterval { get; set; }
		public int TickBarsBack { get; set; }
		public VolCalType VolCal { get; set; }
		public bool Sum3Only { get; set; }
		public DataCleanUpType DataCleanUp { get; set; }
		public bool UseVolCal { get; set; }
		public bool EnableDataCleanup { get; set; }
		public bool EnableMinRowCleanup { get; set; }
		public int MinRowForCleanup { get; set; }
		public bool EnableVolCal { get; set; }
		public APIKeyModel[] Keys { get; set; } = new APIKeyModel[4];
	}
}
