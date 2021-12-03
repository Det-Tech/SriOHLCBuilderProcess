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
	public partial class FrmZeroMQSettings : Form
	{
		ZeroMQSettings config;
		public FrmZeroMQSettings()
		{
			InitializeComponent();
		}

		public FrmZeroMQSettings(ZeroMQSettings config_) : this()
		{
			config = config_;

			chkSendZMQ.Checked = config.EnableZMQ;
			txtIP.Text = config.IP;
			txtPort.Text = config.Port.ToString();
			chkSendPerCycle.Checked = config.SendPerCycle;
			chkSendPerSymbol.Checked = config.SendPerSymbol;

			groupBoxZMQ.Enabled = chkSendZMQ.Checked;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			config.EnableZMQ = chkSendZMQ.Checked;
			config.IP = txtIP.Text;
			config.Port = int.Parse(txtPort.Text);
			config.SendPerCycle = chkSendPerCycle.Checked;
			config.SendPerSymbol = chkSendPerSymbol.Checked;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void chkSendZMQ_CheckedChanged(object sender, EventArgs e)
		{
			groupBoxZMQ.Enabled = chkSendZMQ.Checked;
		}
	}
}
