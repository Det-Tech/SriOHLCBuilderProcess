using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class APIKeyModel
	{
		public string APIKey { get; set; }
		public string SecretKey { get; set; }
		public string RefreshToken { get; set; }

		public static APIKeyModel[] LoadFromFile(string file)
		{
			APIKeyModel[] keys = new APIKeyModel[] { new APIKeyModel(), new APIKeyModel(), new APIKeyModel() , new APIKeyModel() };
			try
			{
				string[] lines = System.IO.File.ReadAllLines(file);
				foreach (var line in lines)
				{
					string[] items = line.Split(':').Select(x => x.Trim()).ToArray();
					if (items.Length <= 1)
						continue;

					int TempVal = -1;
					int index = int.TryParse(items[0].Substring(items[0].Length - 1), out TempVal) ? TempVal : -1;
					if (index < 1 || index > 4)
						continue;

					if (items[0].IndexOf("KEY") >= 0)
						keys[index - 1].APIKey = items[1];
					else if (items[0].IndexOf("SECRET") >= 0)
						keys[index - 1].SecretKey = items[1];
					else if (items[0].IndexOf("REFRESH") >= 0)
						keys[index - 1].RefreshToken = items[1];
				}
			}
			catch
			{

			}

			return keys.Where(x => x.APIKey != null).ToArray();
		}
	}
}
