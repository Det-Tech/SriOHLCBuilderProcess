using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel.Enums
{
	public enum DataTimeFrame { Tick, Second, Minute, Minute5, Minute15, Hour, Day, Week, Month, Quarter, Year, Minute30, Minute45, Hour2, Hour4 };
	public enum DataFeedSouce { PolygonV2, AlpacaV2, TradeStation, TDAmeritrade, TwelveData, OandaData, OnlyLocalData };
	public enum WebSocketSource { AlapcaV2, Polygon, TradeStation, GlobalDataFeed, TwelveDataFeed, TDAmeriTrade }
	public enum TSDataUnit { Minute, Daily, Weekly, Monthly }
	public enum TSSessionTemplate { USEQPre, USEQPost, USEQPreAndPost, Default };
	public enum TSDataType { DateRange, BarsBack, DaysBack }
	public enum VolCalType { UpDownVol, UpDownTicks, OutputTicksVol, UpDownVolAsVol, UpDownTickAsVol, OutputPTVInVol }
	public enum DataCleanUpType { Mismatch, MismatchWithZero, PriceMismatch, VolumeMismatch }
	public enum ColumnForLevelType { Close, Change, Volume }
	public enum ColumnToOutputType { Volume, Change }
}
