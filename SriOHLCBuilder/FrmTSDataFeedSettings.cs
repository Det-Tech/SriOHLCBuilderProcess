using SriOHLCBuilderModel;
using SriOHLCBuilderModel.Enums;
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
	public partial class FrmTSDataFeedSettings : Form
	{
		TSDataFeedSettings config;
		public FrmTSDataFeedSettings()
		{
			InitializeComponent();
		}

		public FrmTSDataFeedSettings(TSDataFeedSettings config_) : this()
		{
			config = config_;


			cmbUnit.SelectedIndex = (int)config.Unit;
			txtInterval.Text = config.Interval.ToString();
			cmbSessionTemplate.SelectedIndex = (int)config.SessionTemplate;
			cmbDateType.SelectedIndex = (int)config.DataType;
			dtStartDate.Value = config.StartDate;
			dtEndDate.Value = config.EndDate;
			txtBarsback.Text = config.BarsBack.ToString();
			txtDaysBack.Text = config.DaysBack.ToString();
			chkAutoLastDate.Checked = config.EnableAutoLastDate;
			radLive.Checked = config.IsLive;
			radSim.Checked = !config.IsLive;
			chkUseMultipleToken.Checked = config.UseMultipleTokens;

			//chkUseSymbolSplit.Checked = config.EnableSplitSymbolList;
			//txtSymbolListFolder.Text = config.SymbolListFolder;
			//radUpDownVol.Checked = config.VolCal == VolCalType.UpDownVol;
			//radUpDownTicks.Checked = config.VolCal == VolCalType.UpDownTicks;
			//radOutputTicks.Checked = config.VolCal == VolCalType.OutputTicksVol;
			//radUpDownVolAsVol.Checked = config.VolCal == VolCalType.UpDownVolAsVol;
			//radUpDownTickAsVol.Checked = config.VolCal == VolCalType.UpDownTickAsVol;
			//radOutputPTVinVol.Checked = config.VolCal == VolCalType.OutputPTVInVol;

			//chkSum3Only.Checked = config.Sum3Only;

			//radMismatch.Checked = config.DataCleanUp == DataCleanUpType.Mismatch;
			//radMismatchWithZero.Checked = config.DataCleanUp == DataCleanUpType.MismatchWithZero;
			//radPriceMismatch.Checked = config.DataCleanUp == DataCleanUpType.PriceMismatch;
			//radVolumeMismatch.Checked = config.DataCleanUp == DataCleanUpType.VolumeMismatch;

			//chkDataCleanup.Checked = config.EnableDataCleanup;
			
			//chkVolCal.Checked = config.EnableVolCal;
			//groupVolCal.Enabled = chkVolCal.Checked;

			//groupDataCleanup.Enabled = chkDataCleanup.Checked;

			//txtTickInterval.Text = config.TickInterval.ToString();
			//txtMinRowsCleanup.Text = config.MinRowForCleanup.ToString();

			//chkMinRowsCleanup.Checked = config.EnableMinRowCleanup;
			//txtMinRowsCleanup.Enabled = chkMinRowsCleanup.Checked;
		}
		private void btnOK_Click(object sender, EventArgs e)
		{
			
			config.Unit = (TSDataUnit)cmbUnit.SelectedIndex;

			int tempValInt = 0;
			config.Interval = int.TryParse(txtInterval.Text, out tempValInt) ? tempValInt : 0;
			config.SessionTemplate = (TSSessionTemplate)cmbSessionTemplate.SelectedIndex;
			config.DataType = (TSDataType)cmbDateType.SelectedIndex;
			config.StartDate = dtStartDate.Value;
			config.EndDate = dtEndDate.Value;
			config.BarsBack = int.TryParse(txtBarsback.Text, out tempValInt) ? tempValInt : 0;
			config.DaysBack = int.TryParse(txtDaysBack.Text, out tempValInt) ? tempValInt : 0;
			config.EnableAutoLastDate = chkAutoLastDate.Checked;
			config.UseMultipleTokens = chkUseMultipleToken.Checked;
			config.IsLive = radLive.Checked;

			//config.EnableSplitSymbolList = chkUseSymbolSplit.Checked;
			//config.SymbolListFolder = txtSymbolListFolder.Text;
			//if (radUpDownVol.Checked)
			//	config.VolCal = VolCalType.UpDownVol;
			//else if (radUpDownTicks.Checked)
			//	config.VolCal = VolCalType.UpDownTicks;
			//else if (radOutputTicks.Checked)
			//	config.VolCal = VolCalType.OutputTicksVol;
			//else if (radUpDownVolAsVol.Checked)
			//	config.VolCal = VolCalType.UpDownVolAsVol;
			//else if (radUpDownTickAsVol.Checked)
			//	config.VolCal = VolCalType.UpDownTickAsVol;
			//else if (radOutputPTVinVol.Checked)
			//	config.VolCal = VolCalType.OutputPTVInVol;

			//if (radMismatch.Checked)
			//	config.DataCleanUp = DataCleanUpType.Mismatch;
			//else if (radMismatchWithZero.Checked)
			//	config.DataCleanUp = DataCleanUpType.MismatchWithZero;
			//else if (radPriceMismatch.Checked)
			//	config.DataCleanUp = DataCleanUpType.PriceMismatch;
			//else if (radVolumeMismatch.Checked)
			//	config.DataCleanUp = DataCleanUpType.VolumeMismatch;

			//config.EnableDataCleanup = chkDataCleanup.Checked;

			//config.Sum3Only = chkSum3Only.Checked;

			//config.EnableVolCal = chkVolCal.Checked;
			//config.TickInterval = int.TryParse(txtTickInterval.Text, out tempValInt) ? tempValInt : 0;
			//config.EnableMinRowCleanup = chkMinRowsCleanup.Checked;
			//config.MinRowForCleanup = int.TryParse(txtMinRowsCleanup.Text, out tempValInt) ? tempValInt : 0;

			if (config.DataType == TSDataType.BarsBack && (config.BarsBack < 0 || config.BarsBack > 57600))
			{
				MessageBox.Show("Invalid BarsBack");
				return;
			}

			if (config.DataType == TSDataType.DaysBack && config.DaysBack <= 0)
			{
				MessageBox.Show("Invalid DaysBack");
				return;
			}
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void radLive_CheckedChanged(object sender, EventArgs e)
		{
			
		}

		private void cmbDateType_SelectedIndexChanged(object sender, EventArgs e)
		{
			dtStartDate.Enabled = cmbDateType.SelectedIndex == 0;
			dtEndDate.Enabled = cmbDateType.SelectedIndex == 0 || cmbDateType.SelectedIndex == 1 || cmbDateType.SelectedIndex == 2;
			txtBarsback.Enabled = cmbDateType.SelectedIndex == 1;
			txtDaysBack.Enabled = cmbDateType.SelectedIndex == 2;
		}

		private void cmbUnit_SelectedIndexChanged(object sender, EventArgs e)
		{
			txtInterval.Text = "1";
		}

		private void btnGetToken_Click(object sender, EventArgs e)
		{

		}

		private void FrmTSDataFeedSettings_Load(object sender, EventArgs e)
		{

		}
	}
}
