
namespace SriOHLCBuilder
{
	partial class FrmCalSettings
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
			this.chkSTTrend = new System.Windows.Forms.CheckBox();
			this.chkATTrend = new System.Windows.Forms.CheckBox();
			this.groupSTTrend = new System.Windows.Forms.GroupBox();
			this.txtSTPd = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtSTFactor = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.groupATTrend = new System.Windows.Forms.GroupBox();
			this.txtATRisk = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.chkEnableCalAvg = new System.Windows.Forms.CheckBox();
			this.groupCalAvg = new System.Windows.Forms.GroupBox();
			this.txtLavg4End = new System.Windows.Forms.TextBox();
			this.txtLavg4Start = new System.Windows.Forms.TextBox();
			this.label30 = new System.Windows.Forms.Label();
			this.txtLavg3End = new System.Windows.Forms.TextBox();
			this.txtLavg3Start = new System.Windows.Forms.TextBox();
			this.label29 = new System.Windows.Forms.Label();
			this.txtLavg2End = new System.Windows.Forms.TextBox();
			this.txtLavg2Start = new System.Windows.Forms.TextBox();
			this.label28 = new System.Windows.Forms.Label();
			this.label27 = new System.Windows.Forms.Label();
			this.txtLavg1End = new System.Windows.Forms.TextBox();
			this.label26 = new System.Windows.Forms.Label();
			this.txtLavg1Start = new System.Windows.Forms.TextBox();
			this.label25 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.chkUseLavgForL = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbLavgToUse = new System.Windows.Forms.ComboBox();
			this.cmbSignalLavg = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.chkCalSignal = new System.Windows.Forms.CheckBox();
			this.chkAlignedOutputFile = new System.Windows.Forms.CheckBox();
			this.chkOutputOnlyCompletedRows = new System.Windows.Forms.CheckBox();
			this.chkOutputNewFormat = new System.Windows.Forms.CheckBox();
			this.chkOutputOnlyXInterval = new System.Windows.Forms.CheckBox();
			this.btnBrowseIntervalFile = new System.Windows.Forms.Button();
			this.txtXIntervalFile = new System.Windows.Forms.TextBox();
			this.groupSTTrend.SuspendLayout();
			this.groupATTrend.SuspendLayout();
			this.groupCalAvg.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkSTTrend
			// 
			this.chkSTTrend.AutoSize = true;
			this.chkSTTrend.Location = new System.Drawing.Point(196, 10);
			this.chkSTTrend.Name = "chkSTTrend";
			this.chkSTTrend.Size = new System.Drawing.Size(71, 17);
			this.chkSTTrend.TabIndex = 43;
			this.chkSTTrend.Text = "ST Trend";
			this.chkSTTrend.UseVisualStyleBackColor = true;
			this.chkSTTrend.CheckedChanged += new System.EventHandler(this.chkSTTrend_CheckedChanged);
			// 
			// chkATTrend
			// 
			this.chkATTrend.AutoSize = true;
			this.chkATTrend.Location = new System.Drawing.Point(24, 10);
			this.chkATTrend.Name = "chkATTrend";
			this.chkATTrend.Size = new System.Drawing.Size(71, 17);
			this.chkATTrend.TabIndex = 42;
			this.chkATTrend.Text = "AT Trend";
			this.chkATTrend.UseVisualStyleBackColor = true;
			this.chkATTrend.CheckedChanged += new System.EventHandler(this.chkATTrend_CheckedChanged);
			// 
			// groupSTTrend
			// 
			this.groupSTTrend.Controls.Add(this.txtSTPd);
			this.groupSTTrend.Controls.Add(this.label17);
			this.groupSTTrend.Controls.Add(this.txtSTFactor);
			this.groupSTTrend.Controls.Add(this.label21);
			this.groupSTTrend.Location = new System.Drawing.Point(185, 12);
			this.groupSTTrend.Name = "groupSTTrend";
			this.groupSTTrend.Size = new System.Drawing.Size(165, 85);
			this.groupSTTrend.TabIndex = 41;
			this.groupSTTrend.TabStop = false;
			// 
			// txtSTPd
			// 
			this.txtSTPd.Location = new System.Drawing.Point(76, 51);
			this.txtSTPd.Name = "txtSTPd";
			this.txtSTPd.Size = new System.Drawing.Size(66, 20);
			this.txtSTPd.TabIndex = 41;
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(31, 54);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(20, 13);
			this.label17.TabIndex = 40;
			this.label17.Text = "Pd";
			// 
			// txtSTFactor
			// 
			this.txtSTFactor.Location = new System.Drawing.Point(76, 22);
			this.txtSTFactor.Name = "txtSTFactor";
			this.txtSTFactor.Size = new System.Drawing.Size(66, 20);
			this.txtSTFactor.TabIndex = 39;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(14, 25);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(37, 13);
			this.label21.TabIndex = 38;
			this.label21.Text = "Factor";
			// 
			// groupATTrend
			// 
			this.groupATTrend.Controls.Add(this.txtATRisk);
			this.groupATTrend.Controls.Add(this.label15);
			this.groupATTrend.Location = new System.Drawing.Point(12, 12);
			this.groupATTrend.Name = "groupATTrend";
			this.groupATTrend.Size = new System.Drawing.Size(161, 85);
			this.groupATTrend.TabIndex = 40;
			this.groupATTrend.TabStop = false;
			// 
			// txtATRisk
			// 
			this.txtATRisk.Location = new System.Drawing.Point(74, 27);
			this.txtATRisk.Name = "txtATRisk";
			this.txtATRisk.Size = new System.Drawing.Size(62, 20);
			this.txtATRisk.TabIndex = 39;
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(25, 30);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(28, 13);
			this.label15.TabIndex = 38;
			this.label15.Text = "Risk";
			// 
			// chkEnableCalAvg
			// 
			this.chkEnableCalAvg.AutoSize = true;
			this.chkEnableCalAvg.Location = new System.Drawing.Point(23, 100);
			this.chkEnableCalAvg.Name = "chkEnableCalAvg";
			this.chkEnableCalAvg.Size = new System.Drawing.Size(63, 17);
			this.chkEnableCalAvg.TabIndex = 88;
			this.chkEnableCalAvg.Text = "Cal-Avg";
			this.chkEnableCalAvg.UseVisualStyleBackColor = true;
			// 
			// groupCalAvg
			// 
			this.groupCalAvg.Controls.Add(this.txtLavg4End);
			this.groupCalAvg.Controls.Add(this.txtLavg4Start);
			this.groupCalAvg.Controls.Add(this.label30);
			this.groupCalAvg.Controls.Add(this.txtLavg3End);
			this.groupCalAvg.Controls.Add(this.txtLavg3Start);
			this.groupCalAvg.Controls.Add(this.label29);
			this.groupCalAvg.Controls.Add(this.txtLavg2End);
			this.groupCalAvg.Controls.Add(this.txtLavg2Start);
			this.groupCalAvg.Controls.Add(this.label28);
			this.groupCalAvg.Controls.Add(this.label27);
			this.groupCalAvg.Controls.Add(this.txtLavg1End);
			this.groupCalAvg.Controls.Add(this.label26);
			this.groupCalAvg.Controls.Add(this.txtLavg1Start);
			this.groupCalAvg.Controls.Add(this.label25);
			this.groupCalAvg.Location = new System.Drawing.Point(12, 103);
			this.groupCalAvg.Name = "groupCalAvg";
			this.groupCalAvg.Size = new System.Drawing.Size(338, 176);
			this.groupCalAvg.TabIndex = 89;
			this.groupCalAvg.TabStop = false;
			// 
			// txtLavg4End
			// 
			this.txtLavg4End.Location = new System.Drawing.Point(206, 137);
			this.txtLavg4End.Name = "txtLavg4End";
			this.txtLavg4End.Size = new System.Drawing.Size(80, 20);
			this.txtLavg4End.TabIndex = 94;
			// 
			// txtLavg4Start
			// 
			this.txtLavg4Start.Location = new System.Drawing.Point(110, 137);
			this.txtLavg4Start.Name = "txtLavg4Start";
			this.txtLavg4Start.Size = new System.Drawing.Size(80, 20);
			this.txtLavg4Start.TabIndex = 93;
			// 
			// label30
			// 
			this.label30.AutoSize = true;
			this.label30.Location = new System.Drawing.Point(52, 140);
			this.label30.Name = "label30";
			this.label30.Size = new System.Drawing.Size(37, 13);
			this.label30.TabIndex = 92;
			this.label30.Text = "Lavg4";
			// 
			// txtLavg3End
			// 
			this.txtLavg3End.Location = new System.Drawing.Point(206, 107);
			this.txtLavg3End.Name = "txtLavg3End";
			this.txtLavg3End.Size = new System.Drawing.Size(80, 20);
			this.txtLavg3End.TabIndex = 91;
			// 
			// txtLavg3Start
			// 
			this.txtLavg3Start.Location = new System.Drawing.Point(110, 107);
			this.txtLavg3Start.Name = "txtLavg3Start";
			this.txtLavg3Start.Size = new System.Drawing.Size(80, 20);
			this.txtLavg3Start.TabIndex = 90;
			// 
			// label29
			// 
			this.label29.AutoSize = true;
			this.label29.Location = new System.Drawing.Point(52, 110);
			this.label29.Name = "label29";
			this.label29.Size = new System.Drawing.Size(37, 13);
			this.label29.TabIndex = 89;
			this.label29.Text = "Lavg3";
			// 
			// txtLavg2End
			// 
			this.txtLavg2End.Location = new System.Drawing.Point(206, 74);
			this.txtLavg2End.Name = "txtLavg2End";
			this.txtLavg2End.Size = new System.Drawing.Size(80, 20);
			this.txtLavg2End.TabIndex = 88;
			// 
			// txtLavg2Start
			// 
			this.txtLavg2Start.Location = new System.Drawing.Point(110, 74);
			this.txtLavg2Start.Name = "txtLavg2Start";
			this.txtLavg2Start.Size = new System.Drawing.Size(80, 20);
			this.txtLavg2Start.TabIndex = 87;
			// 
			// label28
			// 
			this.label28.AutoSize = true;
			this.label28.Location = new System.Drawing.Point(52, 77);
			this.label28.Name = "label28";
			this.label28.Size = new System.Drawing.Size(37, 13);
			this.label28.TabIndex = 86;
			this.label28.Text = "Lavg2";
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Location = new System.Drawing.Point(232, 21);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(26, 13);
			this.label27.TabIndex = 85;
			this.label27.Text = "End";
			// 
			// txtLavg1End
			// 
			this.txtLavg1End.Location = new System.Drawing.Point(206, 42);
			this.txtLavg1End.Name = "txtLavg1End";
			this.txtLavg1End.Size = new System.Drawing.Size(80, 20);
			this.txtLavg1End.TabIndex = 84;
			// 
			// label26
			// 
			this.label26.AutoSize = true;
			this.label26.Location = new System.Drawing.Point(136, 21);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(29, 13);
			this.label26.TabIndex = 83;
			this.label26.Text = "Start";
			// 
			// txtLavg1Start
			// 
			this.txtLavg1Start.Location = new System.Drawing.Point(110, 42);
			this.txtLavg1Start.Name = "txtLavg1Start";
			this.txtLavg1Start.Size = new System.Drawing.Size(80, 20);
			this.txtLavg1Start.TabIndex = 82;
			// 
			// label25
			// 
			this.label25.AutoSize = true;
			this.label25.Location = new System.Drawing.Point(52, 45);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(37, 13);
			this.label25.TabIndex = 81;
			this.label25.Text = "Lavg1";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(359, 326);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(105, 27);
			this.btnOK.TabIndex = 90;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(484, 326);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(105, 27);
			this.btnCancel.TabIndex = 91;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// chkUseLavgForL
			// 
			this.chkUseLavgForL.AutoSize = true;
			this.chkUseLavgForL.Location = new System.Drawing.Point(368, 12);
			this.chkUseLavgForL.Name = "chkUseLavgForL";
			this.chkUseLavgForL.Size = new System.Drawing.Size(131, 17);
			this.chkUseLavgForL.TabIndex = 92;
			this.chkUseLavgForL.Text = "Use Lavg For L1 to Lx";
			this.chkUseLavgForL.UseVisualStyleBackColor = true;
			this.chkUseLavgForL.CheckedChanged += new System.EventHandler(this.chkUseLavgForL_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(388, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 13);
			this.label1.TabIndex = 93;
			this.label1.Text = "Lavg to Use";
			// 
			// cmbLavgToUse
			// 
			this.cmbLavgToUse.AutoCompleteCustomSource.AddRange(new string[] {
            "Lavg1",
            "Lavg2",
            "Lavg3",
            "Lavg4"});
			this.cmbLavgToUse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLavgToUse.FormattingEnabled = true;
			this.cmbLavgToUse.Items.AddRange(new object[] {
            "Lavg1",
            "Lavg2",
            "Lavg3",
            "Lavg4"});
			this.cmbLavgToUse.Location = new System.Drawing.Point(477, 39);
			this.cmbLavgToUse.Name = "cmbLavgToUse";
			this.cmbLavgToUse.Size = new System.Drawing.Size(103, 21);
			this.cmbLavgToUse.TabIndex = 94;
			// 
			// cmbSignalLavg
			// 
			this.cmbSignalLavg.AutoCompleteCustomSource.AddRange(new string[] {
            "Lavg1",
            "Lavg2",
            "Lavg3",
            "Lavg4"});
			this.cmbSignalLavg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSignalLavg.FormattingEnabled = true;
			this.cmbSignalLavg.Items.AddRange(new object[] {
            "Lavg1",
            "Lavg2",
            "Lavg3",
            "Lavg4"});
			this.cmbSignalLavg.Location = new System.Drawing.Point(475, 116);
			this.cmbSignalLavg.Name = "cmbSignalLavg";
			this.cmbSignalLavg.Size = new System.Drawing.Size(103, 21);
			this.cmbSignalLavg.TabIndex = 97;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(388, 119);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 13);
			this.label2.TabIndex = 96;
			this.label2.Text = "Signal Lavg";
			// 
			// chkCalSignal
			// 
			this.chkCalSignal.AutoSize = true;
			this.chkCalSignal.Location = new System.Drawing.Point(368, 89);
			this.chkCalSignal.Name = "chkCalSignal";
			this.chkCalSignal.Size = new System.Drawing.Size(73, 17);
			this.chkCalSignal.TabIndex = 95;
			this.chkCalSignal.Text = "Cal Signal";
			this.chkCalSignal.UseVisualStyleBackColor = true;
			this.chkCalSignal.CheckedChanged += new System.EventHandler(this.chkCalSignal_CheckedChanged);
			// 
			// chkAlignedOutputFile
			// 
			this.chkAlignedOutputFile.AutoSize = true;
			this.chkAlignedOutputFile.Location = new System.Drawing.Point(368, 164);
			this.chkAlignedOutputFile.Name = "chkAlignedOutputFile";
			this.chkAlignedOutputFile.Size = new System.Drawing.Size(115, 17);
			this.chkAlignedOutputFile.TabIndex = 98;
			this.chkAlignedOutputFile.Text = "Aligned Output File";
			this.chkAlignedOutputFile.UseVisualStyleBackColor = true;
			// 
			// chkOutputOnlyCompletedRows
			// 
			this.chkOutputOnlyCompletedRows.AutoSize = true;
			this.chkOutputOnlyCompletedRows.Location = new System.Drawing.Point(368, 209);
			this.chkOutputOnlyCompletedRows.Name = "chkOutputOnlyCompletedRows";
			this.chkOutputOnlyCompletedRows.Size = new System.Drawing.Size(159, 17);
			this.chkOutputOnlyCompletedRows.TabIndex = 99;
			this.chkOutputOnlyCompletedRows.Text = "Output Only Complete Rows";
			this.chkOutputOnlyCompletedRows.UseVisualStyleBackColor = true;
			// 
			// chkOutputNewFormat
			// 
			this.chkOutputNewFormat.AutoSize = true;
			this.chkOutputNewFormat.Location = new System.Drawing.Point(368, 252);
			this.chkOutputNewFormat.Name = "chkOutputNewFormat";
			this.chkOutputNewFormat.Size = new System.Drawing.Size(118, 17);
			this.chkOutputNewFormat.TabIndex = 100;
			this.chkOutputNewFormat.Text = "Output New Format";
			this.chkOutputNewFormat.UseVisualStyleBackColor = true;
			// 
			// chkOutputOnlyXInterval
			// 
			this.chkOutputOnlyXInterval.AutoSize = true;
			this.chkOutputOnlyXInterval.Location = new System.Drawing.Point(12, 295);
			this.chkOutputOnlyXInterval.Name = "chkOutputOnlyXInterval";
			this.chkOutputOnlyXInterval.Size = new System.Drawing.Size(160, 17);
			this.chkOutputOnlyXInterval.TabIndex = 101;
			this.chkOutputOnlyXInterval.Text = "Output Only X Interval Rows";
			this.chkOutputOnlyXInterval.UseVisualStyleBackColor = true;
			this.chkOutputOnlyXInterval.CheckedChanged += new System.EventHandler(this.chkOutputOnlyXInterval_CheckedChanged);
			// 
			// btnBrowseIntervalFile
			// 
			this.btnBrowseIntervalFile.Location = new System.Drawing.Point(322, 325);
			this.btnBrowseIntervalFile.Name = "btnBrowseIntervalFile";
			this.btnBrowseIntervalFile.Size = new System.Drawing.Size(27, 22);
			this.btnBrowseIntervalFile.TabIndex = 103;
			this.btnBrowseIntervalFile.Text = "...";
			this.btnBrowseIntervalFile.UseVisualStyleBackColor = true;
			this.btnBrowseIntervalFile.Click += new System.EventHandler(this.btnBrowseIntervalFile_Click);
			// 
			// txtXIntervalFile
			// 
			this.txtXIntervalFile.Location = new System.Drawing.Point(54, 326);
			this.txtXIntervalFile.Name = "txtXIntervalFile";
			this.txtXIntervalFile.Size = new System.Drawing.Size(268, 20);
			this.txtXIntervalFile.TabIndex = 102;
			// 
			// FrmCalSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(601, 365);
			this.Controls.Add(this.btnBrowseIntervalFile);
			this.Controls.Add(this.txtXIntervalFile);
			this.Controls.Add(this.chkOutputOnlyXInterval);
			this.Controls.Add(this.chkOutputNewFormat);
			this.Controls.Add(this.chkOutputOnlyCompletedRows);
			this.Controls.Add(this.chkAlignedOutputFile);
			this.Controls.Add(this.cmbSignalLavg);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.chkCalSignal);
			this.Controls.Add(this.cmbLavgToUse);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.chkUseLavgForL);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.chkEnableCalAvg);
			this.Controls.Add(this.groupCalAvg);
			this.Controls.Add(this.chkSTTrend);
			this.Controls.Add(this.chkATTrend);
			this.Controls.Add(this.groupSTTrend);
			this.Controls.Add(this.groupATTrend);
			this.Name = "FrmCalSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Cal Settings";
			this.groupSTTrend.ResumeLayout(false);
			this.groupSTTrend.PerformLayout();
			this.groupATTrend.ResumeLayout(false);
			this.groupATTrend.PerformLayout();
			this.groupCalAvg.ResumeLayout(false);
			this.groupCalAvg.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkSTTrend;
		private System.Windows.Forms.CheckBox chkATTrend;
		private System.Windows.Forms.GroupBox groupSTTrend;
		private System.Windows.Forms.TextBox txtSTPd;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox txtSTFactor;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox groupATTrend;
		private System.Windows.Forms.TextBox txtATRisk;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.CheckBox chkEnableCalAvg;
		private System.Windows.Forms.GroupBox groupCalAvg;
		private System.Windows.Forms.TextBox txtLavg4End;
		private System.Windows.Forms.TextBox txtLavg4Start;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox txtLavg3End;
		private System.Windows.Forms.TextBox txtLavg3Start;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox txtLavg2End;
		private System.Windows.Forms.TextBox txtLavg2Start;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox txtLavg1End;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.TextBox txtLavg1Start;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.CheckBox chkUseLavgForL;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbLavgToUse;
		private System.Windows.Forms.ComboBox cmbSignalLavg;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.CheckBox chkCalSignal;
		private System.Windows.Forms.CheckBox chkAlignedOutputFile;
		private System.Windows.Forms.CheckBox chkOutputOnlyCompletedRows;
		private System.Windows.Forms.CheckBox chkOutputNewFormat;
		private System.Windows.Forms.CheckBox chkOutputOnlyXInterval;
		private System.Windows.Forms.Button btnBrowseIntervalFile;
		private System.Windows.Forms.TextBox txtXIntervalFile;
	}
}