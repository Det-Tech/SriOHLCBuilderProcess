
namespace SriOHLCBuilder
{
	partial class FrmAlpacaSetting
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
			this.radioLive = new System.Windows.Forms.RadioButton();
			this.radioPaper = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.txtAPIKey = new System.Windows.Forms.TextBox();
			this.txtSecretKey = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// radioLive
			// 
			this.radioLive.AutoSize = true;
			this.radioLive.Location = new System.Drawing.Point(119, 23);
			this.radioLive.Name = "radioLive";
			this.radioLive.Size = new System.Drawing.Size(45, 17);
			this.radioLive.TabIndex = 0;
			this.radioLive.TabStop = true;
			this.radioLive.Text = "Live";
			this.radioLive.UseVisualStyleBackColor = true;
			// 
			// radioPaper
			// 
			this.radioPaper.AutoSize = true;
			this.radioPaper.Location = new System.Drawing.Point(202, 23);
			this.radioPaper.Name = "radioPaper";
			this.radioPaper.Size = new System.Drawing.Size(53, 17);
			this.radioPaper.TabIndex = 1;
			this.radioPaper.TabStop = true;
			this.radioPaper.Text = "Paper";
			this.radioPaper.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(39, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(42, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "APIKey";
			// 
			// txtAPIKey
			// 
			this.txtAPIKey.Location = new System.Drawing.Point(119, 55);
			this.txtAPIKey.Name = "txtAPIKey";
			this.txtAPIKey.Size = new System.Drawing.Size(224, 20);
			this.txtAPIKey.TabIndex = 3;
			// 
			// txtSecretKey
			// 
			this.txtSecretKey.Location = new System.Drawing.Point(119, 91);
			this.txtSecretKey.Name = "txtSecretKey";
			this.txtSecretKey.Size = new System.Drawing.Size(224, 20);
			this.txtSecretKey.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(25, 94);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "SecretKey";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(167, 134);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 6;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(268, 134);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FrmAlpacaSetting
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(373, 176);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.txtSecretKey);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtAPIKey);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.radioPaper);
			this.Controls.Add(this.radioLive);
			this.Name = "FrmAlpacaSetting";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Alpaca V2 Setting";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.RadioButton radioLive;
		private System.Windows.Forms.RadioButton radioPaper;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtAPIKey;
		private System.Windows.Forms.TextBox txtSecretKey;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
	}
}