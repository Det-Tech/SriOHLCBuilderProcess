using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SriOHLCBuilderModel.Data
{
	public class GlobalData
	{
		public static SriOHLCBuilderSettings Config { get; set; } = new SriOHLCBuilderSettings();
		public static string AppName = "SriOHLCBuilder";
		public static string CalendarFileName = "market_calendar_file.csv";
		public static bool IsEODGen { get; set; }
		public static bool LoadSettings()
		{
			string strFilePath = "config.xml";
			try
			{
				XmlSerializer serializer = new XmlSerializer(typeof(SriOHLCBuilderSettings));
				using (FileStream fs = new FileStream(strFilePath, FileMode.Open))
				{
					Config = (SriOHLCBuilderSettings)serializer.Deserialize(fs);
					fs.Close();
				}
			}
			catch (Exception)
			{
				return false;
			}

			return true;
		}

		public static bool SaveSettings()
		{
			string strFilePath = "config.xml";

			XmlSerializer serializer = new XmlSerializer(typeof(SriOHLCBuilderSettings));
			using (FileStream fs = new FileStream(strFilePath, FileMode.Create))
			{
				serializer.Serialize(fs, Config);
				fs.Close();
			}
			return true;
		}

		public static string GetCalendarFilePath() => Path.Combine(Environment.CurrentDirectory, CalendarFileName);
	}
}
