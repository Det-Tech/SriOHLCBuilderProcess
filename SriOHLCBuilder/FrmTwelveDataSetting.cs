using SriOHLCBuilder;
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
	public partial class FrmTwelveDataSetting : Form
	{
		TwelveDataSettings config;
		public FrmTwelveDataSetting()
		{
			InitializeComponent();
		}

		public FrmTwelveDataSetting(TwelveDataSettings config_) : this()
		{
			config = config_;

			txtAPIkey.Text = config.APIKey;
			txtEndPoint.Text = config.EndPoint;
			txtExchangeCode.Text = config.Exchange;
			txtCountryCode.Text = config.Country;
			cmbType.Text = config.Type;
			if (string.IsNullOrEmpty(cmbType.Text))
				cmbType.Text = "N/A";

			cmbPrepost.Text = config.Prepost;
			chkPrepost.Checked = config.EnablePrepost;
			cmbPrepost.Enabled = chkPrepost.Checked;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			config.APIKey = txtAPIkey.Text;
			//config.EndPoint = txtEndPoint.Text;
			config.Exchange = txtExchangeCode.Text;
			config.Country = txtCountryCode.Text;
			config.Type = cmbType.Text;
			if (cmbType.Text == "N/A")
				config.Type = "";
			config.Prepost = cmbPrepost.Text;
			config.EnablePrepost = chkPrepost.Checked;

			this.Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void chkPrepost_CheckedChanged(object sender, EventArgs e)
		{
			cmbPrepost.Enabled = chkPrepost.Checked;
		}
	}
}
