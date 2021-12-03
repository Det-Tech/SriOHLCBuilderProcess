using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Ionic.Zip;
using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Data;
using SriOHLCBuilderProcess;

namespace SriOHLCBuilderProcess
{
	public class AWSS3Uploader
	{
		IAmazonS3 client;
		static bool stopProcess;
		public static void StopUpload()
		{
			stopProcess = true;
		}
		public void PrepareClient(AWSS3Settings config)
		{
			var awsCredentials = new Amazon.Runtime.BasicAWSCredentials(config.AccessKey, config.SecretKey);

			RegionEndpoint region = RegionEndpoint.USEast1;
			switch (config.Region)
			{
				case "USEast1":
					region = RegionEndpoint.USEast1;
					break;
				case "AFSouth1":
					region = RegionEndpoint.AFSouth1;
					break;
				case "MESouth1":
					region = RegionEndpoint.MESouth1;
					break;
				case "CACentral1":
					region = RegionEndpoint.CACentral1;
					break;
				case "CNNorthWest1":
					region = RegionEndpoint.CNNorthWest1;
					break;
				case "CNNorth1":
					region = RegionEndpoint.CNNorth1;
					break;
				case "USGovCloudWest1":
					region = RegionEndpoint.USGovCloudWest1;
					break;
				case "SAEast1":
					region = RegionEndpoint.SAEast1;
					break;
				case "APSoutheast2":
					region = RegionEndpoint.APSoutheast2;
					break;
				case "APSoutheast1":
					region = RegionEndpoint.APSoutheast1;
					break;
				case "APSouth1":
					region = RegionEndpoint.APSouth1;
					break;
				case "APNortheast3":
					region = RegionEndpoint.APNortheast3;
					break;
				case "USGovCloudEast1":
					region = RegionEndpoint.USGovCloudEast1;
					break;
				case "APNortheast1":
					region = RegionEndpoint.APNortheast1;
					break;
				case "APNortheast2":
					region = RegionEndpoint.APNortheast2;
					break;
				case "USWest1":
					region = RegionEndpoint.USWest1;
					break;
				case "USWest2":
					region = RegionEndpoint.USWest2;
					break;
				case "EUNorth1":
					region = RegionEndpoint.EUNorth1;
					break;
				case "EUWest1":
					region = RegionEndpoint.EUWest1;
					break;
				case "USEast2":
					region = RegionEndpoint.USEast2;
					break;
				case "EUWest3":
					region = RegionEndpoint.EUWest3;
					break;
				case "EUCentral1":
					region = RegionEndpoint.EUCentral1;
					break;
				case "EUSouth1":
					region = RegionEndpoint.EUSouth1;
					break;
				case "APEast1":
					region = RegionEndpoint.APEast1;
					break;
				case "EUWest2":
					region = RegionEndpoint.EUWest2;
					break;
			}
			client = new AmazonS3Client(awsCredentials, region);
		}
		public void UploadFile(string file, string type, AWSS3Settings config)
		{
			if (client == null)
				PrepareClient(config);

			// create a TransferUtility instance passing it the IAmazonS3 created in the first step
			TransferUtility utility = new TransferUtility(client);
			// making a TransferUtilityUploadRequest instance
			TransferUtilityUploadRequest request = new TransferUtilityUploadRequest();

			request.BucketName = config.BucketName; //no subdirectory just bucket name

			request.Key = (string.IsNullOrEmpty(type) ? "" : (type + "/")) + Path.GetFileName(file); //file name up in S3
			request.FilePath = file; //local file name
			utility.Upload(request); //commensing the transfer
		}

		public void UploadFilesInFolder(string folder, string type, AWSS3Settings config)
		{
			try
			{
				string[] files = Directory.GetFiles(folder);
				string extension = "." + config.GzipFormat;
				extension = extension.Replace("gzip", "gz");
				foreach (var file in files)
				{
					if (stopProcess)
						break;

					string filename = Path.GetFileNameWithoutExtension(file);

					using (ZipFile zip = new ZipFile())
					{
						if (config.GZipUsePasswordProtect)
							zip.Password = config.GZipPassword;
						zip.AddFile(file, "");
						zip.Save(filename);
					}
					UploadFile(filename, type, config);
					File.Delete(filename);
				}
			}
			catch (Exception e)
			{
				Utils.WriteLog(e.Message);
			}
		}

		public bool UploadFilesAsFolder(string folder, string type, AWSS3Settings config)
		{
			try
			{
				string[] files = Directory.GetFiles(folder, "*.csv", SearchOption.AllDirectories);
				string extension = "." + config.GzipFormat;
				extension = extension.Replace("gzip", "gz");
				using (ZipFile zip = new ZipFile())
				{
					if (config.GZipUsePasswordProtect)
						zip.Password = config.GZipPassword;

					foreach (var file in files)
					{
						if (stopProcess)
							break;

						string lastFolderName = Path.GetFileName(Path.GetDirectoryName(file));

						zip.AddFile(file, lastFolderName);
					}

					string zipFilename = Path.Combine(folder, config.GZipFolderName + extension);
					zip.Save(zipFilename);
					UploadFile(zipFilename, type, config);
					File.Delete(zipFilename);
					return true;
				}
			}
			catch (Exception e)
			{
				Utils.WriteLog(e.Message);
				return false;
			}

		}
	}
}
