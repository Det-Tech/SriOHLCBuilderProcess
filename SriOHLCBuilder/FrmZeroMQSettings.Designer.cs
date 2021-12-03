
namespace SriOHLCBuilder
{
	partial class FrmZeroMQSettings
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
			this.chkSendZMQ = new System.Windows.Forms.CheckBox();
			this.groupBoxZMQ = new System.Windows.Forms.GroupBox();
			this.chkSendPerSymbol = new System.Windows.Forms.CheckBox();
			this.chkSendPerCycle = new System.Windows.Forms.CheckBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBoxZMQ.SuspendLayout();
			this.SuspendLayout();
			// 
			// chkSendZMQ
			// 
			this.chkSendZMQ.AutoSize = true;
			this.chkSendZMQ.Location = new System.Drawing.Point(19, 8);
			this.chkSendZMQ.Name = "chkSendZMQ";
			this.chkSendZMQ.Size = new System.Drawing.Size(134, 17);
			this.chkSendZMQ.TabIndex = 30;
			this.chkSendZMQ.Text = "Send NetMQ Message";
			this.chkSendZMQ.UseVisualStyleBackColor = true;
			this.chkSendZMQ.CheckedChanged += new System.EventHandler(this.chkSendZMQ_CheckedChanged);
			// 
			// groupBoxZMQ
			// 
			this.groupBoxZMQ.Controls.Add(this.chkSendPerSymbol);
			this.groupBoxZMQ.Controls.Add(this.chkSendPerCycle);
			this.groupBoxZMQ.Controls.Add(this.txtPort);
			this.groupBoxZMQ.Controls.Add(this.label15);
			this.groupBoxZMQ.Controls.Add(this.txtIP);
			this.groupBoxZMQ.Controls.Add(this.label14);
			this.groupBoxZMQ.Location = new System.Drawing.Point(12, 12);
			this.groupBoxZMQ.Name = "groupBoxZMQ";
			this.groupBoxZMQ.Size = new System.Drawing.Size(294, 167);
			this.groupBoxZMQ.TabIndex = 31;
			this.groupBoxZMQ.TabStop = false;
			// 
			// chkSendPerSymbol
			// 
			this.chkSendPerSymbol.AutoSize = true;
			this.chkSendPerSymbol.Location = new System.Drawing.Point(23, 104);
			this.chkSendPerSymbol.Name = "chkSendPerSymbol";
			this.chkSendPerSymbol.Size = new System.Drawing.Size(145, 17);
			this.chkSendPerSymbol.TabIndex = 31;
			this.chkSendPerSymbol.Text = "Out Message Per Symbol";
			this.chkSendPerSymbol.UseVisualStyleBackColor = true;
			// 
			// chkSendPerCycle
			// 
			this.chkSendPerCycle.AutoSize = true;
			this.chkSendPerCycle.Location = new System.Drawing.Point(23, 137);
			this.chkSendPerCycle.Name = "chkSendPerCycle";
			this.chkSendPerCycle.Size = new System.Drawing.Size(137, 17);
			this.chkSendPerCycle.TabIndex = 30;
			this.chkSendPerCycle.Text = "Out Message Per Cycle";
			this.chkSendPerCycle.UseVisualStyleBackColor = true;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(99, 63);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(59, 20);
			this.txtPort.TabIndex = 29;
			this.txtPort.Text = "12345";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(52, 66);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(26, 13);
			this.label15.TabIndex = 28;
			this.label15.Text = "Port";
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(99, 31);
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(143, 20);
			this.txtIP.TabIndex = 27;
			this.txtIP.Text = "127.0.0.1";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(20, 34);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(58, 13);
			this.label14.TabIndex = 26;
			this.label14.Text = "IP Address";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(61, 185);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(81, 26);
			this.button1.TabIndex = 32;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(173, 185);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(81, 26);
			this.button2.TabIndex = 33;
			this.button2.Text = "Cancel";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// FrmZeroMQSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(315, 223);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.chkSendZMQ);
			this.Controls.Add(this.groupBoxZMQ);
			this.Name = "FrmZeroMQSettings";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "NetMQ Settings";
			this.groupBoxZMQ.ResumeLayout(false);
			this.groupBoxZMQ.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkSendZMQ;
		private System.Windows.Forms.GroupBox groupBoxZMQ;
		private System.Windows.Forms.CheckBox chkSendPerCycle;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox chkSendPerSymbol;
	}
}