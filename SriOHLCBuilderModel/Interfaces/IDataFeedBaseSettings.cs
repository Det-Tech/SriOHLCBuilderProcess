using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel.Interface
{
	public interface IDataFeedBaseSettings
	{
		string APIKey { get; set; }
		string SecretKey { get; set; }
		string RefreshToken { get; set; }
		string APIEndPoint { get; set; }
		string APIEndPointSandBox { get; set; }
	}
}
