using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class AlpacaDataFeedSetting
	{
		public bool IsLive { get; set; }
		public string APIKey { get; set; }
		public string SecretKey { get; set; }
	}
}
