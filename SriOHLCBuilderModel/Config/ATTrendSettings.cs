using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class ATTrendSettings
	{
		public bool Enabled { get; set; }
		public int Bars { get; set; }
		public int Risk { get; set; }
		public int LookbackPeriod { get; set; }
	}
}
