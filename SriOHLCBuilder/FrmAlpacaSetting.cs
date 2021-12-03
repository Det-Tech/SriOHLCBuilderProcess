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
	public partial class FrmAlpacaSetting : Form
	{
		AlpacaDataFeedSetting config;
		public FrmAlpacaSetting()
		{
			InitializeComponent();
		}

		public FrmAlpacaSetting(AlpacaDataFeedSetting config_) : this()
		{
			config = config_;

			txtAPIKey.Text = config.APIKey;
			txtSecretKey.Text = config.SecretKey;
			radioLive.Checked = config.IsLive;
			radioPaper.Checked = !config.IsLive;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			config.APIKey = txtAPIKey.Text;
			config.SecretKey = txtSecretKey.Text;
			config.IsLive = radioLive.Checked;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
