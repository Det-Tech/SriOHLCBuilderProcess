
namespace SriOHLCBuilder
{
	partial class FrmAWS3Config
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.chkUseAWSS3 = new System.Windows.Forms.CheckBox();
			this.groupAWSInfo = new System.Windows.Forms.GroupBox();
			this.txtAWSEncrytionKey = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtAWSCannedACL = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.cmbAWSRegion = new System.Windows.Forms.ComboBox();
			this.txtBucketName = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAWSSecretKey = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtAWSAccessKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupGZipSetting = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.chkGzipUsePassword = new System.Windows.Forms.CheckBox();
			this.chkGzipFolder = new System.Windows.Forms.CheckBox();
			this.chkGZipIndividual = new System.Windows.Forms.CheckBox();
			this.txtGzipPassword = new System.Windows.Forms.TextBox();
			this.cmbCompressionFormat = new System.Windows.Forms.ComboBox();
			this.txtGzipFolderName = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.groupAWSInfo.SuspendLayout();
			this.groupGZipSetting.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkUseAWSS3
			// 
			this.chkUseAWSS3.AutoSize = true;
			this.chkUseAWSS3.Location = new System.Drawing.Point(20, 20);
			this.chkUseAWSS3.Name = "chkUseAWSS3";
			this.chkUseAWSS3.Size = new System.Drawing.Size(118, 17);
			this.chkUseAWSS3.TabIndex = 0;
			this.chkUseAWSS3.Text = "Output To AWS S3";
			this.chkUseAWSS3.UseVisualStyleBackColor = true;
			this.chkUseAWSS3.CheckedChanged += new System.EventHandler(this.chkUseAWSS3_CheckedChanged);
			// 
			// groupAWSInfo
			// 
			this.groupAWSInfo.Controls.Add(this.txtAWSEncrytionKey);
			this.groupAWSInfo.Controls.Add(this.label7);
			this.groupAWSInfo.Controls.Add(this.txtAWSCannedACL);
			this.groupAWSInfo.Controls.Add(this.label6);
			this.groupAWSInfo.Controls.Add(this.cmbAWSRegion);
			this.groupAWSInfo.Controls.Add(this.txtBucketName);
			this.groupAWSInfo.Controls.Add(this.label5);
			this.groupAWSInfo.Controls.Add(this.label4);
			this.groupAWSInfo.Controls.Add(this.txtAWSSecretKey);
			this.groupAWSInfo.Controls.Add(this.label3);
			this.groupAWSInfo.Controls.Add(this.txtAWSAccessKey);
			this.groupAWSInfo.Controls.Add(this.label2);
			this.groupAWSInfo.Location = new System.Drawing.Point(20, 54);
			this.groupAWSInfo.Name = "groupAWSInfo";
			this.groupAWSInfo.Size = new System.Drawing.Size(329, 228);
			this.groupAWSInfo.TabIndex = 10;
			this.groupAWSInfo.TabStop = false;
			this.groupAWSInfo.Text = "AWS Connection Info";
			// 
			// txtAWSEncrytionKey
			// 
			this.txtAWSEncrytionKey.Location = new System.Drawing.Point(115, 192);
			this.txtAWSEncrytionKey.Name = "txtAWSEncrytionKey";
			this.txtAWSEncrytionKey.Size = new System.Drawing.Size(197, 20);
			this.txtAWSEncrytionKey.TabIndex = 11;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(20, 195);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(78, 13);
			this.label7.TabIndex = 10;
			this.label7.Text = "Encryption Key";
			// 
			// txtAWSCannedACL
			// 
			this.txtAWSCannedACL.Location = new System.Drawing.Point(115, 159);
			this.txtAWSCannedACL.Name = "txtAWSCannedACL";
			this.txtAWSCannedACL.Size = new System.Drawing.Size(123, 20);
			this.txtAWSCannedACL.TabIndex = 9;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(20, 162);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(67, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Canned ACL";
			// 
			// cmbAWSRegion
			// 
			this.cmbAWSRegion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAWSRegion.FormattingEnabled = true;
			this.cmbAWSRegion.Items.AddRange(new object[] {
            "USEast1",
            "AFSouth1",
            "MESouth1",
            "CACentral1",
            "CNNorthWest1",
            "CNNorth1",
            "USGovCloudWest1",
            "SAEast1",
            "APSoutheast2",
            "APSoutheast1",
            "APSouth1",
            "APNortheast3",
            "USGovCloudEast1",
            "APNortheast1",
            "APNortheast2",
            "USWest1",
            "USWest2",
            "EUNorth1",
            "EUWest1",
            "USEast2",
            "EUWest3",
            "EUCentral1",
            "EUSouth1",
            "APEast1",
            "EUWest2"});
			this.cmbAWSRegion.Location = new System.Drawing.Point(115, 95);
			this.cmbAWSRegion.Name = "cmbAWSRegion";
			this.cmbAWSRegion.Size = new System.Drawing.Size(123, 21);
			this.cmbAWSRegion.TabIndex = 7;
			// 
			// txtBucketName
			// 
			this.txtBucketName.Location = new System.Drawing.Point(115, 127);
			this.txtBucketName.Name = "txtBucketName";
			this.txtBucketName.Size = new System.Drawing.Size(123, 20);
			this.txtBucketName.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(20, 130);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Bucket Name";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(20, 98);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Region";
			// 
			// txtAWSSecretKey
			// 
			this.txtAWSSecretKey.Location = new System.Drawing.Point(115, 64);
			this.txtAWSSecretKey.Name = "txtAWSSecretKey";
			this.txtAWSSecretKey.Size = new System.Drawing.Size(197, 20);
			this.txtAWSSecretKey.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(20, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(59, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Secret Key";
			// 
			// txtAWSAccessKey
			// 
			this.txtAWSAccessKey.Location = new System.Drawing.Point(115, 30);
			this.txtAWSAccessKey.Name = "txtAWSAccessKey";
			this.txtAWSAccessKey.Size = new System.Drawing.Size(197, 20);
			this.txtAWSAccessKey.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(20, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Access Key";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(63, 479);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(106, 27);
			this.btnOK.TabIndex = 11;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(183, 479);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(106, 27);
			this.btnCancel.TabIndex = 12;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// groupGZipSetting
			// 
			this.groupGZipSetting.Controls.Add(this.label8);
			this.groupGZipSetting.Controls.Add(this.chkGzipUsePassword);
			this.groupGZipSetting.Controls.Add(this.chkGzipFolder);
			this.groupGZipSetting.Controls.Add(this.chkGZipIndividual);
			this.groupGZipSetting.Controls.Add(this.txtGzipPassword);
			this.groupGZipSetting.Controls.Add(this.cmbCompressionFormat);
			this.groupGZipSetting.Controls.Add(this.txtGzipFolderName);
			this.groupGZipSetting.Controls.Add(this.label10);
			this.groupGZipSetting.Controls.Add(this.label12);
			this.groupGZipSetting.Controls.Add(this.label13);
			this.groupGZipSetting.Location = new System.Drawing.Point(20, 288);
			this.groupGZipSetting.Name = "groupGZipSetting";
			this.groupGZipSetting.Size = new System.Drawing.Size(329, 178);
			this.groupGZipSetting.TabIndex = 13;
			this.groupGZipSetting.TabStop = false;
			this.groupGZipSetting.Text = "Upload Settings";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(134, 142);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "Password";
			// 
			// chkGzipUsePassword
			// 
			this.chkGzipUsePassword.AutoSize = true;
			this.chkGzipUsePassword.Location = new System.Drawing.Point(15, 141);
			this.chkGzipUsePassword.Name = "chkGzipUsePassword";
			this.chkGzipUsePassword.Size = new System.Drawing.Size(103, 17);
			this.chkGzipUsePassword.TabIndex = 14;
			this.chkGzipUsePassword.Text = "PasswordProect";
			this.chkGzipUsePassword.UseVisualStyleBackColor = true;
			// 
			// chkGzipFolder
			// 
			this.chkGzipFolder.AutoSize = true;
			this.chkGzipFolder.Location = new System.Drawing.Point(239, 68);
			this.chkGzipFolder.Name = "chkGzipFolder";
			this.chkGzipFolder.Size = new System.Drawing.Size(73, 17);
			this.chkGzipFolder.TabIndex = 13;
			this.chkGzipFolder.Text = "Zip Folder";
			this.chkGzipFolder.UseVisualStyleBackColor = true;
			// 
			// chkGZipIndividual
			// 
			this.chkGZipIndividual.AutoSize = true;
			this.chkGZipIndividual.Enabled = false;
			this.chkGZipIndividual.Location = new System.Drawing.Point(126, 68);
			this.chkGZipIndividual.Name = "chkGZipIndividual";
			this.chkGZipIndividual.Size = new System.Drawing.Size(95, 17);
			this.chkGZipIndividual.TabIndex = 12;
			this.chkGZipIndividual.Text = "Individual Files";
			this.chkGZipIndividual.UseVisualStyleBackColor = true;
			// 
			// txtGzipPassword
			// 
			this.txtGzipPassword.Location = new System.Drawing.Point(218, 138);
			this.txtGzipPassword.Name = "txtGzipPassword";
			this.txtGzipPassword.Size = new System.Drawing.Size(94, 20);
			this.txtGzipPassword.TabIndex = 11;
			// 
			// cmbCompressionFormat
			// 
			this.cmbCompressionFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCompressionFormat.FormattingEnabled = true;
			this.cmbCompressionFormat.Items.AddRange(new object[] {
            "zip",
            "gzip"});
			this.cmbCompressionFormat.Location = new System.Drawing.Point(126, 30);
			this.cmbCompressionFormat.Name = "cmbCompressionFormat";
			this.cmbCompressionFormat.Size = new System.Drawing.Size(112, 21);
			this.cmbCompressionFormat.TabIndex = 7;
			// 
			// txtGzipFolderName
			// 
			this.txtGzipFolderName.Location = new System.Drawing.Point(218, 107);
			this.txtGzipFolderName.Name = "txtGzipFolderName";
			this.txtGzipFolderName.Size = new System.Drawing.Size(94, 20);
			this.txtGzipFolderName.TabIndex = 6;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(134, 110);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(62, 13);
			this.label10.TabIndex = 5;
			this.label10.Text = "Root Folder";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(7, 70);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(66, 13);
			this.label12.TabIndex = 2;
			this.label12.Text = "Output Type";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(7, 33);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(102, 13);
			this.label13.TabIndex = 0;
			this.label13.Text = "Compression Format";
			// 
			// FrmAWS3Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(369, 516);
			this.Controls.Add(this.groupGZipSetting);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.groupAWSInfo);
			this.Controls.Add(this.chkUseAWSS3);
			this.Name = "FrmAWS3Config";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "AWS S3 Settings";
			this.groupAWSInfo.ResumeLayout(false);
			this.groupAWSInfo.PerformLayout();
			this.groupGZipSetting.ResumeLayout(false);
			this.groupGZipSetting.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkUseAWSS3;
		private System.Windows.Forms.GroupBox groupAWSInfo;
		private System.Windows.Forms.TextBox txtAWSSecretKey;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtAWSAccessKey;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtBucketName;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbAWSRegion;
		private System.Windows.Forms.TextBox txtAWSEncrytionKey;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtAWSCannedACL;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupGZipSetting;
		private System.Windows.Forms.TextBox txtGzipPassword;
		private System.Windows.Forms.ComboBox cmbCompressionFormat;
		private System.Windows.Forms.TextBox txtGzipFolderName;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox chkGzipFolder;
		private System.Windows.Forms.CheckBox chkGZipIndividual;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.CheckBox chkGzipUsePassword;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}