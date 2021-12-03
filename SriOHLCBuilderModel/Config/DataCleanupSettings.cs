using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class DataCleanupSettings
	{
		public bool Enable { get; set; }
		public string CleanupOutputFolder { get; set; }
		public double ExceptionPercent { get; set; }
		public bool UsePerException { get; set; }
		public string PerExceptionFile { get; set; }

	}
}
