
namespace SriOHLCBuilder
{
	partial class FrmTwelveDataSetting
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
			this.label2 = new System.Windows.Forms.Label();
			this.txtAPIkey = new System.Windows.Forms.TextBox();
			this.txtEndPoint = new System.Windows.Forms.TextBox();
			this.txtExchangeCode = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtCountryCode = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.cmbPrepost = new System.Windows.Forms.ComboBox();
			this.chkPrepost = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(50, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "API Key";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Enabled = false;
			this.label2.Location = new System.Drawing.Point(45, 54);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "EndPoint";
			// 
			// txtAPIkey
			// 
			this.txtAPIkey.Location = new System.Drawing.Point(113, 19);
			this.txtAPIkey.Name = "txtAPIkey";
			this.txtAPIkey.Size = new System.Drawing.Size(245, 20);
			this.txtAPIkey.TabIndex = 2;
			// 
			// txtEndPoint
			// 
			this.txtEndPoint.Enabled = false;
			this.txtEndPoint.Location = new System.Drawing.Point(113, 51);
			this.txtEndPoint.Name = "txtEndPoint";
			this.txtEndPoint.Size = new System.Drawing.Size(245, 20);
			this.txtEndPoint.TabIndex = 3;
			// 
			// txtExchangeCode
			// 
			this.txtExchangeCode.Location = new System.Drawing.Point(113, 85);
			this.txtExchangeCode.Name = "txtExchangeCode";
			this.txtExchangeCode.Size = new System.Drawing.Size(95, 20);
			this.txtExchangeCode.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Exchange Code";
			// 
			// txtCountryCode
			// 
			this.txtCountryCode.Location = new System.Drawing.Point(113, 120);
			this.txtCountryCode.Name = "txtCountryCode";
			this.txtCountryCode.Size = new System.Drawing.Size(95, 20);
			this.txtCountryCode.TabIndex = 7;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Country Code";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(64, 157);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(31, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Type";
			// 
			// cmbType
			// 
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Items.AddRange(new object[] {
            "N/A",
            "Stock",
            "Index",
            "ETF",
            "REIT"});
			this.cmbType.Location = new System.Drawing.Point(113, 154);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(95, 21);
			this.cmbType.TabIndex = 9;
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(175, 223);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(83, 27);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(275, 223);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(83, 27);
			this.btnCancel.TabIndex = 11;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// cmbPrepost
			// 
			this.cmbPrepost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPrepost.FormattingEnabled = true;
			this.cmbPrepost.Items.AddRange(new object[] {
            "false",
            "true"});
			this.cmbPrepost.Location = new System.Drawing.Point(113, 190);
			this.cmbPrepost.Name = "cmbPrepost";
			this.cmbPrepost.Size = new System.Drawing.Size(95, 21);
			this.cmbPrepost.TabIndex = 13;
			// 
			// chkPrepost
			// 
			this.chkPrepost.AutoSize = true;
			this.chkPrepost.Location = new System.Drawing.Point(33, 194);
			this.chkPrepost.Name = "chkPrepost";
			this.chkPrepost.Size = new System.Drawing.Size(62, 17);
			this.chkPrepost.TabIndex = 14;
			this.chkPrepost.Text = "Prepost";
			this.chkPrepost.UseVisualStyleBackColor = true;
			this.chkPrepost.CheckedChanged += new System.EventHandler(this.chkPrepost_CheckedChanged);
			// 
			// FrmTwelveDataSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(382, 262);
			this.Controls.Add(this.chkPrepost);
			this.Controls.Add(this.cmbPrepost);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbType);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtCountryCode);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtExchangeCode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtEndPoint);
			this.Controls.Add(this.txtAPIkey);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "FrmTwelveDataSetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "TwelveData Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtAPIkey;
		private System.Windows.Forms.TextBox txtEndPoint;
		private System.Windows.Forms.TextBox txtExchangeCode;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtCountryCode;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cmbPrepost;
		private System.Windows.Forms.CheckBox chkPrepost;
	}
}