using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class TreeItem
	{
		public string Symbol { get; set; }
		public string Company { get; set; }
		public string Sector { get; set; }
		public string Industry { get; set; }
		public override string ToString()
		{
			return $"{Symbol},{Company},{Sector},{Industry}";
		}
	}
}
