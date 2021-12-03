using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class CalSettings
	{
		public ATTrendSettings AT { get; set; } = new ATTrendSettings();
		public STTrendSettings ST { get; set; } = new STTrendSettings();
		public bool EnableCalAvg { get; set; }
		public int LAvg1Start { get; set; }
		public int LAvg2Start { get; set; }
		public int LAvg3Start { get; set; }
		public int LAvg4Start { get; set; }
		public int LAvg1End { get; set; }
		public int LAvg2End { get; set; }
		public int LAvg3End { get; set; }
		public int LAvg4End { get; set; }
		public bool UseLavgForL { get; set; }
		public int LavgToUse { get; set; }
		public bool CalSignal { get; set; }
		public int SignalLavg { get; set; }
		public bool AlignedOutputFile { get; set; }
		public bool OutputOnlyCompleteRow { get; set; }
		public bool OutputNewFormat { get; set; }
		public bool OutputOnlyXRows { get; set; }
		public string OutputXIntervalFile { get; set; }
	}
}
