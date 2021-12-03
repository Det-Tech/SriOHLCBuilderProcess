using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderProcess
{
	public partial class SriOHLCBuilderProcessor
	{
		void ProcessLocalData(List<string> symbols, int multiplier, string strPath)
		{
			var barSet = LoadDataFromLocal(symbols, strPath);

			foreach (var symbol in symbols)
			{
				if (!barSet.ContainsKey(symbol))
					continue;

				var bars = barSet[symbol].ToList();

				ProcessAPIData(bars, symbol, strPath);

				procSymbolCounter++;
				if (procSymbolCounter < procSymbolTotal)
					worker.ReportProgress(procSymbolCounter * 100 / procSymbolTotal);
			}
		}
		void ProcessLocalData(string symbol, string strPath)
		{
			var bars = LoadDataFromLocal(symbol, Config.LocalDataFeedConfig.DataFolder);

			if (bars == null)
				return;

			ProcessAPIData(bars, symbol, strPath);
		}
	}
}
