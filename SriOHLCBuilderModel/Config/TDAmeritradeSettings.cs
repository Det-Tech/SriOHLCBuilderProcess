using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class TDAmeritradeSettings
	{
		public bool UseAPIKey { get; set; } = true;
		public string APIKey { get; set; }
		public string RefreshToken { get; set; }
		public PeriodType PeriodType { get; set; }
		public int Period { get; set; }
		public FrequencyType FrequencyType { get; set; }
		public Frequency Frequency { get; set; }
		public bool NeedExtendedHoursData { get; set; }
	}

	public enum PeriodType { day, month, year, ytd}
	public enum FrequencyType { minute, daily, weekly, monthly}
	public enum Frequency { F1, F5, F10, F15, F30}
}
