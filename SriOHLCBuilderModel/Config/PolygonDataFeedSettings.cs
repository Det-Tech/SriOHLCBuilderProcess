using SriOHLCBuilderModel.Enums;
using SriOHLCBuilderModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class PolygonDataFeedSettings : IDataFeedBaseSettings
	{
		public string APIKey { get; set; }
		public string SecretKey { get; set; }
		public string RefreshToken { get; set; }
		public string APIEndPoint { get; set; }
		public string APIEndPointSandBox { get; set; }
		public string Sort { get; set; } = "asc";
		public bool Unadjusted { get; set; }
		public string TimeSpanStr { get; set; }
	}
}
