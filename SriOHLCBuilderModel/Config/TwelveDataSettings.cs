using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class TwelveDataSettings
	{
		public string APIKey { get; set; }
		public string EndPoint { get; set; } = "https://api.twelvedata.com";
		public string Exchange { get; set; }
		public string Country { get; set; }
		public string Type { get; set; }
		public string Prepost { get; set; }
		public bool EnablePrepost { get; set; }
	}
}
