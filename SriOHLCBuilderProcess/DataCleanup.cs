using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SriOHLCBuilderProcess
{
	public partial class SriOHLCBuilderProcessor
	{
		List<ExceptionInfo> perExceptionList;
		void Cleanup(string symbol, List<RawData> dataList, DataCleanupSettings config, int multiplier)
		{
			double percentThreshold = 0;

			if (config.UsePerException && (perExceptionList == null || perExceptionList.Count == 0))
			{
				perExceptionList = LoadPerException(config.PerExceptionFile);
			}
			if (config.UsePerException)
			{
				var item = perExceptionList.Where(x => x.Multiplier == multiplier).FirstOrDefault();
				if (item != null)
					percentThreshold = item.Exception;
			}
			else
				percentThreshold = config.ExceptionPercent;
			for (int i = 1; i < dataList.Count; i++)
			{
				double percent = Math.Abs(100 * (dataList[i].Close - dataList[i - 1].Close) / dataList[i - 1].Close);
				if (percent < percentThreshold)
				{
					dataList.RemoveAt(i--);
				}
			}
		}

		List<ExceptionInfo> LoadPerException(string filename)
		{
			List<ExceptionInfo> exceptions = new List<ExceptionInfo>();
			try
			{
				string[] lines = File.ReadAllLines(filename);
				for (int i = 1; i < lines.Length; i++)
				{
					string[] items = lines[i].Split(',');
					if (items.Length < 2)
						continue;
				
					ExceptionInfo info = new ExceptionInfo();
					info.Multiplier = int.Parse(items[0]);
					info.Exception = double.Parse(items[1]);
					exceptions.Add(info);
				}
			}
			catch
			{

			}

			return exceptions;
		}
	}

	public class ExceptionInfo
	{
		public int Multiplier { get; set; }
		public double Exception { get; set; }
	}
}
