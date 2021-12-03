using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SriOHLCBuilderModel
{
	public class AWSS3Settings
	{
		public bool UseAWSUpload { get; set; }
		public string AccessKey { get; set; }
		public string SecretKey { get; set; }
		public string Region { get; set; } = "USEast1";
		public string BucketName { get; set; }
		public string CannedACL { get; set; }
		public string EncryptionKey { get; set; }
		public string GzipFormat { get; set; } = "zip";
		public bool UseGZipFolder { get; set; } = true;
		public bool UseGZipIndividual { get; set; }
		public string GZipFolderName { get; set; }
		public bool GZipUsePasswordProtect { get; set; }
		public string GZipPassword { get; set; }
		public bool MarketView { get; set; }
		public bool AllSignalReport { get; set; }
		public bool AllMarketHistorical { get; set; }
		public bool IndustryReport { get; set; }
		public bool IndustryHistorical { get; set; }
		public bool SectorReport { get; set; }
		public bool SectorHistorical { get; set; }
		public bool UploadMasterFiles { get; set; }
		public bool MasterZip { get; set; }
		public bool MasterUnzip { get; set; }
		public string MasterFolder { get; set; }
		public string MasterZipFolder { get; set; }
		public bool MasterProtect { get; set; }
		public string MasterPassword { get; set; }
		public string MasterZipFormat { get; set; } = "zip";
		public bool UploadOutputNew { get; set; }
		public bool UploadOutputOld { get; set; }
	}
}
