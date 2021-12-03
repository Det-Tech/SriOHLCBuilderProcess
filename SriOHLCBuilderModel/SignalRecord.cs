using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class SignalRecord
	{
		public DateTime Date { get; set; }
		public string Signal { get; set; }
		public double Price { get; set; }
	}
}
