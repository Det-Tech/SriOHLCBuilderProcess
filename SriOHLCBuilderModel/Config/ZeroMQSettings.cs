using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class ZeroMQSettings
	{
		public bool EnableZMQ { get; set; }
		public string IP { get; set; } = "127.0.0.1";
		public int Port { get; set; }
		public bool SendPerCycle { get; set; }
		public bool SendPerSymbol { get; set; }

	}
}
