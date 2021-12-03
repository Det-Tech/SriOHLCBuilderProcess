using SriOHLCBuilderModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SriOHLCBuilderModel
{
	public class SriOHLCBuilderSettings
	{
		public GeneralSettings General { get; set; } = new GeneralSettings();
		public PolygonDataFeedSettings PolygonConfig { get; set; } = new PolygonDataFeedSettings();
		[XmlIgnore]
		public List<PolygonDataFeedSettings> PolygonConfigEODATST { get; set; } = new List<PolygonDataFeedSettings>();
		public LocalDataFeedSettings LocalDataFeedConfig { get; set; } = new LocalDataFeedSettings();
		public CalSettings Cal { get; set; } = new CalSettings();
		public ZeroMQSettings NetMQConfig { get; set; } = new ZeroMQSettings();
		public AlpacaDataFeedSetting AlpacaConfig { get; set; } = new AlpacaDataFeedSetting();
		public TSDataFeedSettings TradeStationConfig { get; set; } = new TSDataFeedSettings();
		public TDAmeritradeSettings TDAmeritradeConfig { get; set; } = new TDAmeritradeSettings();
		public AWSS3Settings AWSS3Config { get; set; } = new AWSS3Settings();
		public TwelveDataSettings TwelveDataConfig { get; set; } = new TwelveDataSettings();
		public DataCleanupSettings DataCleanupConfig { get; set; } = new DataCleanupSettings();
	}
}
