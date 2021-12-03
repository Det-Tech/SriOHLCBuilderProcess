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
	public partial class FrmTDAmeritradeSetting : Form
	{
		TDAmeritradeSettings config;
		public FrmTDAmeritradeSetting()
		{
			InitializeComponent();
		}

		public FrmTDAmeritradeSetting(TDAmeritradeSettings config_) : this()
		{
			config = config_;
			txtAPIKey.Text = config.APIKey;
			txtRefreshToken.Text = config.RefreshToken;
			cmbPeriodType.SelectedIndex = (int)config.PeriodType;
			txtPeriod.Text = config.Period.ToString();
			cmbFrequencyType.SelectedIndex = (int)config.FrequencyType;
			cmbFrequency.SelectedIndex = (int)config.Frequency;
			radioByToken.Checked = !config.UseAPIKey;
			radioByKey.Checked = config.UseAPIKey;
			cmbNeedExtendedHours.SelectedIndex = config.NeedExtendedHoursData ? 0 : 1;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			config.UseAPIKey = radioByKey.Checked;
			config.APIKey = txtAPIKey.Text;
			config.RefreshToken = txtRefreshToken.Text;
			config.PeriodType = (PeriodType)cmbPeriodType.SelectedIndex;

			int val = 0;
			config.Period = int.TryParse(txtPeriod.Text, out val) ? val : 0;
			config.FrequencyType = (FrequencyType)cmbFrequencyType.SelectedIndex;
			config.Frequency = (Frequency)cmbFrequency.SelectedIndex;
			config.NeedExtendedHoursData = cmbNeedExtendedHours.SelectedIndex == 0;
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
