using SriOHLCBuilderModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SriOHLCBuilder
{
	public partial class FrmAWS3Config : Form
	{
		private AWSS3Settings config { get; }
		public FrmAWS3Config()
		{
			InitializeComponent();
		}
		public FrmAWS3Config(AWSS3Settings config_) : this()
		{
			config = config_;

			
			chkUseAWSS3.Checked = config.UseAWSUpload;
			txtAWSAccessKey.Text = config.AccessKey;
			txtAWSSecretKey.Text = config.SecretKey;
			cmbAWSRegion.Text = config.Region;
			txtAWSCannedACL.Text = config.CannedACL;
			txtBucketName.Text = config.BucketName;
			txtAWSEncrytionKey.Text = config.EncryptionKey;
			cmbCompressionFormat.Text = config.GzipFormat;
			chkGZipIndividual.Checked = config.UseGZipIndividual;
			chkGzipFolder.Checked = config.UseGZipFolder;
			txtGzipFolderName.Text = config.GZipFolderName;
			chkGzipUsePassword.Checked = config.GZipUsePasswordProtect;
			txtGzipPassword.Text = config.GZipPassword;

			groupAWSInfo.Enabled = chkUseAWSS3.Checked;
			groupGZipSetting.Enabled = chkUseAWSS3.Checked;

		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			config.UseAWSUpload = chkUseAWSS3.Checked;
			config.AccessKey = txtAWSAccessKey.Text;
			config.SecretKey = txtAWSSecretKey.Text;
			config.Region = cmbAWSRegion.Text;
			config.BucketName = txtBucketName.Text;
			config.CannedACL = txtAWSCannedACL.Text;
			config.EncryptionKey = txtAWSEncrytionKey.Text;

			config.GzipFormat = cmbCompressionFormat.Text;
			config.UseGZipIndividual = chkGZipIndividual.Checked;
			config.UseGZipFolder = chkGzipFolder.Checked;
			config.GZipFolderName = txtGzipFolderName.Text;
			config.GZipUsePasswordProtect = chkGzipUsePassword.Checked;
			config.GZipPassword = txtGzipPassword.Text;

			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void chkUseAWSS3_CheckedChanged(object sender, EventArgs e)
		{
			groupAWSInfo.Enabled = chkUseAWSS3.Checked;
			groupGZipSetting.Enabled = chkUseAWSS3.Checked;
		}
	}
}
