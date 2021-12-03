
namespace SriOHLCBuilder
{
	partial class FrmDataCleanupSetting
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
			this.chkEnableDataCleanup = new System.Windows.Forms.CheckBox();
			this.panelSettings = new System.Windows.Forms.Panel();
			this.btnBrowseOutputFolder = new System.Windows.Forms.Button();
			this.txtOutputFolder = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnBrowsePerExceptionFile = new System.Windows.Forms.Button();
			this.txtPerExceptionFile = new System.Windows.Forms.TextBox();
			this.chkUsePerException = new System.Windows.Forms.CheckBox();
			this.txtExceptionPercent = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.panelSettings.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkEnableDataCleanup
			// 
			this.chkEnableDataCleanup.AutoSize = true;
			this.chkEnableDataCleanup.Location = new System.Drawing.Point(25, 12);
			this.chkEnableDataCleanup.Name = "chkEnableDataCleanup";
			this.chkEnableDataCleanup.Size = new System.Drawing.Size(59, 17);
			this.chkEnableDataCleanup.TabIndex = 0;
			this.chkEnableDataCleanup.Text = "Enable";
			this.chkEnableDataCleanup.UseVisualStyleBackColor = true;
			this.chkEnableDataCleanup.CheckedChanged += new System.EventHandler(this.chkEnableDataCleanup_CheckedChanged);
			// 
			// panelSettings
			// 
			this.panelSettings.Controls.Add(this.btnBrowseOutputFolder);
			this.panelSettings.Controls.Add(this.txtOutputFolder);
			this.panelSettings.Controls.Add(this.label2);
			this.panelSettings.Controls.Add(this.btnBrowsePerExceptionFile);
			this.panelSettings.Controls.Add(this.txtPerExceptionFile);
			this.panelSettings.Controls.Add(this.chkUsePerException);
			this.panelSettings.Controls.Add(this.txtExceptionPercent);
			this.panelSettings.Controls.Add(this.label1);
			this.panelSettings.Location = new System.Drawing.Point(25, 40);
			this.panelSettings.Name = "panelSettings";
			this.panelSettings.Size = new System.Drawing.Size(384, 165);
			this.panelSettings.TabIndex = 1;
			// 
			// btnBrowseOutputFolder
			// 
			this.btnBrowseOutputFolder.Location = new System.Drawing.Point(349, 8);
			this.btnBrowseOutputFolder.Name = "btnBrowseOutputFolder";
			this.btnBrowseOutputFolder.Size = new System.Drawing.Size(27, 22);
			this.btnBrowseOutputFolder.TabIndex = 105;
			this.btnBrowseOutputFolder.Text = "...";
			this.btnBrowseOutputFolder.UseVisualStyleBackColor = true;
			this.btnBrowseOutputFolder.Click += new System.EventHandler(this.btnBrowseOutputFolder_Click);
			// 
			// txtOutputFolder
			// 
			this.txtOutputFolder.Location = new System.Drawing.Point(136, 9);
			this.txtOutputFolder.Name = "txtOutputFolder";
			this.txtOutputFolder.Size = new System.Drawing.Size(213, 20);
			this.txtOutputFolder.TabIndex = 104;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(113, 13);
			this.label2.TabIndex = 103;
			this.label2.Text = "Cleanup Output Folder";
			// 
			// btnBrowsePerExceptionFile
			// 
			this.btnBrowsePerExceptionFile.Location = new System.Drawing.Point(349, 125);
			this.btnBrowsePerExceptionFile.Name = "btnBrowsePerExceptionFile";
			this.btnBrowsePerExceptionFile.Size = new System.Drawing.Size(27, 22);
			this.btnBrowsePerExceptionFile.TabIndex = 102;
			this.btnBrowsePerExceptionFile.Text = "...";
			this.btnBrowsePerExceptionFile.UseVisualStyleBackColor = true;
			this.btnBrowsePerExceptionFile.Click += new System.EventHandler(this.btnBrowsePerExceptionFile_Click);
			// 
			// txtPerExceptionFile
			// 
			this.txtPerExceptionFile.Location = new System.Drawing.Point(39, 126);
			this.txtPerExceptionFile.Name = "txtPerExceptionFile";
			this.txtPerExceptionFile.Size = new System.Drawing.Size(310, 20);
			this.txtPerExceptionFile.TabIndex = 101;
			// 
			// chkUsePerException
			// 
			this.chkUsePerException.AutoSize = true;
			this.chkUsePerException.Location = new System.Drawing.Point(17, 91);
			this.chkUsePerException.Name = "chkUsePerException";
			this.chkUsePerException.Size = new System.Drawing.Size(155, 17);
			this.chkUsePerException.TabIndex = 2;
			this.chkUsePerException.Text = "Per TimeFrame Exception%";
			this.chkUsePerException.UseVisualStyleBackColor = true;
			// 
			// txtExceptionPercent
			// 
			this.txtExceptionPercent.Location = new System.Drawing.Point(106, 48);
			this.txtExceptionPercent.Name = "txtExceptionPercent";
			this.txtExceptionPercent.Size = new System.Drawing.Size(114, 20);
			this.txtExceptionPercent.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 51);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Exception%";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(86, 211);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(99, 30);
			this.btnOK.TabIndex = 2;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(247, 211);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(99, 30);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FrmDataCleanupSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(431, 253);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.panelSettings);
			this.Controls.Add(this.chkEnableDataCleanup);
			this.Name = "FrmDataCleanupSetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Data Cleanup Settings";
			this.panelSettings.ResumeLayout(false);
			this.panelSettings.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkEnableDataCleanup;
		private System.Windows.Forms.Panel panelSettings;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtExceptionPercent;
		private System.Windows.Forms.CheckBox chkUsePerException;
		private System.Windows.Forms.Button btnBrowsePerExceptionFile;
		private System.Windows.Forms.TextBox txtPerExceptionFile;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnBrowseOutputFolder;
		private System.Windows.Forms.TextBox txtOutputFolder;
		private System.Windows.Forms.Label label2;
	}
}