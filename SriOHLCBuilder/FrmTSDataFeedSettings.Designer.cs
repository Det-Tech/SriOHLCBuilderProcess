
namespace SriOHLCBuilder
{
	partial class FrmTSDataFeedSettings
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
			this.label1 = new System.Windows.Forms.Label();
			this.cmbUnit = new System.Windows.Forms.ComboBox();
			this.cmbSessionTemplate = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbDateType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.chkAutoLastDate = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtInterval = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.dtStartDate = new System.Windows.Forms.DateTimePicker();
			this.dtEndDate = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.txtBarsback = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtDaysBack = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label10 = new System.Windows.Forms.Label();
			this.radSim = new System.Windows.Forms.RadioButton();
			this.radLive = new System.Windows.Forms.RadioButton();
			this.chkUseMultipleToken = new System.Windows.Forms.CheckBox();
			this.label11 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(31, 94);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Unit";
			// 
			// cmbUnit
			// 
			this.cmbUnit.FormattingEnabled = true;
			this.cmbUnit.Items.AddRange(new object[] {
            "Minute",
            "Daily",
            "Weekly",
            "Monthly"});
			this.cmbUnit.Location = new System.Drawing.Point(141, 91);
			this.cmbUnit.Name = "cmbUnit";
			this.cmbUnit.Size = new System.Drawing.Size(121, 21);
			this.cmbUnit.TabIndex = 1;
			this.cmbUnit.SelectedIndexChanged += new System.EventHandler(this.cmbUnit_SelectedIndexChanged);
			// 
			// cmbSessionTemplate
			// 
			this.cmbSessionTemplate.FormattingEnabled = true;
			this.cmbSessionTemplate.Items.AddRange(new object[] {
            "USEQPre",
            "USEQPost",
            "USEQPreAndPost",
            "Default"});
			this.cmbSessionTemplate.Location = new System.Drawing.Point(141, 161);
			this.cmbSessionTemplate.Name = "cmbSessionTemplate";
			this.cmbSessionTemplate.Size = new System.Drawing.Size(121, 21);
			this.cmbSessionTemplate.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(31, 164);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Session Template";
			// 
			// cmbDateType
			// 
			this.cmbDateType.FormattingEnabled = true;
			this.cmbDateType.Items.AddRange(new object[] {
            "DateRange",
            "BarsBack",
            "DaysBack"});
			this.cmbDateType.Location = new System.Drawing.Point(141, 197);
			this.cmbDateType.Name = "cmbDateType";
			this.cmbDateType.Size = new System.Drawing.Size(121, 21);
			this.cmbDateType.TabIndex = 5;
			this.cmbDateType.SelectedIndexChanged += new System.EventHandler(this.cmbDateType_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(31, 200);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(54, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "DataType";
			// 
			// chkAutoLastDate
			// 
			this.chkAutoLastDate.AutoSize = true;
			this.chkAutoLastDate.Location = new System.Drawing.Point(25, 379);
			this.chkAutoLastDate.Name = "chkAutoLastDate";
			this.chkAutoLastDate.Size = new System.Drawing.Size(97, 17);
			this.chkAutoLastDate.TabIndex = 6;
			this.chkAutoLastDate.Text = "Auto Last Date";
			this.chkAutoLastDate.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(31, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 7;
			this.label4.Text = "Interval";
			// 
			// txtInterval
			// 
			this.txtInterval.Location = new System.Drawing.Point(141, 125);
			this.txtInterval.Name = "txtInterval";
			this.txtInterval.Size = new System.Drawing.Size(121, 20);
			this.txtInterval.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(135, 242);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(55, 13);
			this.label5.TabIndex = 9;
			this.label5.Text = "Start Date";
			// 
			// dtStartDate
			// 
			this.dtStartDate.CustomFormat = "MM/dd/yyyy";
			this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtStartDate.Location = new System.Drawing.Point(202, 236);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new System.Drawing.Size(104, 20);
			this.dtStartDate.TabIndex = 10;
			// 
			// dtEndDate
			// 
			this.dtEndDate.CustomFormat = "MM/dd/yyyy";
			this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtEndDate.Location = new System.Drawing.Point(202, 271);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new System.Drawing.Size(104, 20);
			this.dtEndDate.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(138, 275);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(52, 13);
			this.label6.TabIndex = 11;
			this.label6.Text = "End Date";
			// 
			// txtBarsback
			// 
			this.txtBarsback.Location = new System.Drawing.Point(202, 307);
			this.txtBarsback.Name = "txtBarsback";
			this.txtBarsback.Size = new System.Drawing.Size(104, 20);
			this.txtBarsback.TabIndex = 14;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(134, 310);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "Bars Back";
			// 
			// txtDaysBack
			// 
			this.txtDaysBack.Location = new System.Drawing.Point(202, 342);
			this.txtDaysBack.Name = "txtDaysBack";
			this.txtDaysBack.Size = new System.Drawing.Size(104, 20);
			this.txtDaysBack.TabIndex = 16;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(131, 345);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(59, 13);
			this.label8.TabIndex = 15;
			this.label8.Text = "Days Back";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(37, 410);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(119, 32);
			this.btnOK.TabIndex = 60;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(220, 410);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(119, 32);
			this.btnCancel.TabIndex = 61;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(30, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(64, 13);
			this.label10.TabIndex = 62;
			this.label10.Text = "Active Base";
			// 
			// radSim
			// 
			this.radSim.AutoSize = true;
			this.radSim.Location = new System.Drawing.Point(220, 20);
			this.radSim.Name = "radSim";
			this.radSim.Size = new System.Drawing.Size(42, 17);
			this.radSim.TabIndex = 64;
			this.radSim.TabStop = true;
			this.radSim.Text = "Sim";
			this.radSim.UseVisualStyleBackColor = true;
			// 
			// radLive
			// 
			this.radLive.AutoSize = true;
			this.radLive.Location = new System.Drawing.Point(137, 20);
			this.radLive.Name = "radLive";
			this.radLive.Size = new System.Drawing.Size(45, 17);
			this.radLive.TabIndex = 63;
			this.radLive.TabStop = true;
			this.radLive.Text = "Live";
			this.radLive.UseVisualStyleBackColor = true;
			this.radLive.CheckedChanged += new System.EventHandler(this.radLive_CheckedChanged);
			// 
			// chkUseMultipleToken
			// 
			this.chkUseMultipleToken.AutoSize = true;
			this.chkUseMultipleToken.Checked = true;
			this.chkUseMultipleToken.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUseMultipleToken.Location = new System.Drawing.Point(34, 53);
			this.chkUseMultipleToken.Name = "chkUseMultipleToken";
			this.chkUseMultipleToken.Size = new System.Drawing.Size(163, 17);
			this.chkUseMultipleToken.TabIndex = 65;
			this.chkUseMultipleToken.Text = "Use Multiple Refresh Tokens";
			this.chkUseMultipleToken.UseVisualStyleBackColor = true;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(203, 54);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(67, 13);
			this.label11.TabIndex = 67;
			this.label11.Text = "(APIKeys.txt)";
			// 
			// FrmTSDataFeedSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(376, 454);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.chkUseMultipleToken);
			this.Controls.Add(this.radSim);
			this.Controls.Add(this.radLive);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtDaysBack);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.txtBarsback);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.dtEndDate);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.dtStartDate);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtInterval);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.chkAutoLastDate);
			this.Controls.Add(this.cmbDateType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbSessionTemplate);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbUnit);
			this.Controls.Add(this.label1);
			this.Name = "FrmTSDataFeedSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TSDataFeed Configuration";
			this.Load += new System.EventHandler(this.FrmTSDataFeedSettings_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbUnit;
		private System.Windows.Forms.ComboBox cmbSessionTemplate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbDateType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chkAutoLastDate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtInterval;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dtStartDate;
		private System.Windows.Forms.DateTimePicker dtEndDate;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtBarsback;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDaysBack;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.RadioButton radSim;
		private System.Windows.Forms.RadioButton radLive;
		private System.Windows.Forms.CheckBox chkUseMultipleToken;
		private System.Windows.Forms.Label label11;
	}
}