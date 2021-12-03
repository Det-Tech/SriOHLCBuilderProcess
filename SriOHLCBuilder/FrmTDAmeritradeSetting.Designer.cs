
namespace SriOHLCBuilder
{
	partial class FrmTDAmeritradeSetting
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTDAmeritradeSetting));
			this.txtRefreshToken = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.radioByKey = new System.Windows.Forms.RadioButton();
			this.radioByToken = new System.Windows.Forms.RadioButton();
			this.txtAPIKey = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmbPeriodType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPeriod = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbFrequencyType = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbNeedExtendedHours = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.cmbFrequency = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// txtRefreshToken
			// 
			this.txtRefreshToken.Location = new System.Drawing.Point(122, 78);
			this.txtRefreshToken.Name = "txtRefreshToken";
			this.txtRefreshToken.Size = new System.Drawing.Size(290, 20);
			this.txtRefreshToken.TabIndex = 23;
			this.txtRefreshToken.Text = resources.GetString("txtRefreshToken.Text");
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(27, 81);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(78, 13);
			this.label6.TabIndex = 22;
			this.label6.Text = "Refresh Token";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(58, 14);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "Call API ";
			// 
			// radioByKey
			// 
			this.radioByKey.AutoSize = true;
			this.radioByKey.Location = new System.Drawing.Point(295, 12);
			this.radioByKey.Name = "radioByKey";
			this.radioByKey.Size = new System.Drawing.Size(78, 17);
			this.radioByKey.TabIndex = 20;
			this.radioByKey.TabStop = true;
			this.radioByKey.Text = "By API Key";
			this.radioByKey.UseVisualStyleBackColor = true;
			// 
			// radioByToken
			// 
			this.radioByToken.AutoSize = true;
			this.radioByToken.Checked = true;
			this.radioByToken.Location = new System.Drawing.Point(122, 12);
			this.radioByToken.Name = "radioByToken";
			this.radioByToken.Size = new System.Drawing.Size(109, 17);
			this.radioByToken.TabIndex = 19;
			this.radioByToken.TabStop = true;
			this.radioByToken.Text = "By Access Token";
			this.radioByToken.UseVisualStyleBackColor = true;
			// 
			// txtAPIKey
			// 
			this.txtAPIKey.Location = new System.Drawing.Point(122, 45);
			this.txtAPIKey.Name = "txtAPIKey";
			this.txtAPIKey.Size = new System.Drawing.Size(290, 20);
			this.txtAPIKey.TabIndex = 18;
			this.txtAPIKey.Text = "KTBAEPPWUCX8KSO7ANNEKHF3A88IU2T5";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(42, 48);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 13);
			this.label9.TabIndex = 17;
			this.label9.Text = "TD API Key";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(41, 114);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 24;
			this.label1.Text = "Period Type";
			// 
			// cmbPeriodType
			// 
			this.cmbPeriodType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPeriodType.FormattingEnabled = true;
			this.cmbPeriodType.Items.AddRange(new object[] {
			"day",
			"month",
			"year",
			"ytd"});
			this.cmbPeriodType.Location = new System.Drawing.Point(122, 111);
			this.cmbPeriodType.Name = "cmbPeriodType";
			this.cmbPeriodType.Size = new System.Drawing.Size(109, 21);
			this.cmbPeriodType.TabIndex = 25;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(265, 114);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(37, 13);
			this.label2.TabIndex = 26;
			this.label2.Text = "Period";
			// 
			// txtPeriod
			// 
			this.txtPeriod.Location = new System.Drawing.Point(308, 111);
			this.txtPeriod.Name = "txtPeriod";
			this.txtPeriod.Size = new System.Drawing.Size(104, 20);
			this.txtPeriod.TabIndex = 27;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(245, 153);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 30;
			this.label3.Text = "Frequency";
			// 
			// cmbFrequencyType
			// 
			this.cmbFrequencyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFrequencyType.FormattingEnabled = true;
			this.cmbFrequencyType.Items.AddRange(new object[] {
			"minute",
			"daily",
			"weekly",
			"monthly"});
			this.cmbFrequencyType.Location = new System.Drawing.Point(122, 150);
			this.cmbFrequencyType.Name = "cmbFrequencyType";
			this.cmbFrequencyType.Size = new System.Drawing.Size(109, 21);
			this.cmbFrequencyType.TabIndex = 29;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(21, 153);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(84, 13);
			this.label5.TabIndex = 28;
			this.label5.Text = "Frequency Type";
			// 
			// cmbNeedExtendedHours
			// 
			this.cmbNeedExtendedHours.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbNeedExtendedHours.FormattingEnabled = true;
			this.cmbNeedExtendedHours.Items.AddRange(new object[] {
			"true",
			"false"});
			this.cmbNeedExtendedHours.Location = new System.Drawing.Point(181, 191);
			this.cmbNeedExtendedHours.Name = "cmbNeedExtendedHours";
			this.cmbNeedExtendedHours.Size = new System.Drawing.Size(121, 21);
			this.cmbNeedExtendedHours.TabIndex = 33;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(21, 194);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(135, 13);
			this.label7.TabIndex = 32;
			this.label7.Text = "Need ExtendedHours Data";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(217, 229);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(92, 30);
			this.btnOK.TabIndex = 34;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(320, 229);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(92, 30);
			this.btnCancel.TabIndex = 35;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// cmbFrequency
			// 
			this.cmbFrequency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbFrequency.FormattingEnabled = true;
			this.cmbFrequency.Items.AddRange(new object[] {
			"1",
			"5",
			"10",
			"15",
			"30"});
			this.cmbFrequency.Location = new System.Drawing.Point(308, 150);
			this.cmbFrequency.Name = "cmbFrequency";
			this.cmbFrequency.Size = new System.Drawing.Size(104, 21);
			this.cmbFrequency.TabIndex = 36;
			// 
			// FrmTDAmeritradeSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(438, 276);
			this.Controls.Add(this.cmbFrequency);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbNeedExtendedHours);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cmbFrequencyType);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtPeriod);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbPeriodType);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtRefreshToken);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.radioByKey);
			this.Controls.Add(this.radioByToken);
			this.Controls.Add(this.txtAPIKey);
			this.Controls.Add(this.label9);
			this.Name = "FrmTDAmeritradeSetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TDAmeritrade Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtRefreshToken;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton radioByKey;
		private System.Windows.Forms.RadioButton radioByToken;
		private System.Windows.Forms.TextBox txtAPIKey;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cmbPeriodType;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtPeriod;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cmbFrequencyType;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbNeedExtendedHours;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cmbFrequency;
	}
}