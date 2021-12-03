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
	public partial class FrmCalSettings : Form
	{
		private CalSettings config;
		public FrmCalSettings()
		{
			InitializeComponent();
		}

		public FrmCalSettings(CalSettings config_) : this()
		{
			config = config_;

			chkEnableCalAvg.Checked = config.EnableCalAvg;
			txtLavg1Start.Text = config.LAvg1Start.ToString();
			txtLavg2Start.Text = config.LAvg2Start.ToString();
			txtLavg3Start.Text = config.LAvg3Start.ToString();
			txtLavg4Start.Text = config.LAvg4Start.ToString();

			txtLavg1End.Text = config.LAvg1End.ToString();
			txtLavg2End.Text = config.LAvg2End.ToString();
			txtLavg3End.Text = config.LAvg3End.ToString();
			txtLavg4End.Text = config.LAvg4End.ToString();

			//cal settings
			txtATRisk.Text = config.AT.Risk.ToString();

			txtSTFactor.Text = config.ST.Factor.ToString();
			txtSTPd.Text = config.ST.Pd.ToString();

			chkATTrend.Checked = config.AT.Enabled;
			chkSTTrend.Checked = config.ST.Enabled;
			//

			cmbSignalLavg.Enabled = chkCalSignal.Checked;
			cmbLavgToUse.Enabled = chkUseLavgForL.Checked;

			chkUseLavgForL.Checked = config.UseLavgForL;
			cmbLavgToUse.SelectedIndex = config.LavgToUse;
			chkCalSignal.Checked = config.CalSignal;
			cmbSignalLavg.SelectedIndex = config.SignalLavg;
			chkAlignedOutputFile.Checked = config.AlignedOutputFile;
			chkOutputOnlyCompletedRows.Checked = config.OutputOnlyCompleteRow;
			chkOutputNewFormat.Checked = config.OutputNewFormat;

			groupATTrend.Enabled = chkATTrend.Checked;
			groupSTTrend.Enabled = chkSTTrend.Checked;
			chkAlignedOutputFile.Enabled = chkATTrend.Checked & chkSTTrend.Checked;

			chkOutputOnlyXInterval.Checked = config.OutputOnlyXRows;
			txtXIntervalFile.Text = config.OutputXIntervalFile;

			txtXIntervalFile.Enabled = btnBrowseIntervalFile.Enabled = chkOutputOnlyXInterval.Checked;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			int tempValInt = 0;

			config.LAvg1Start = int.TryParse(txtLavg1Start.Text, out tempValInt) ? tempValInt : 0;
			config.LAvg2Start = int.TryParse(txtLavg2Start.Text, out tempValInt) ? tempValInt : 0;
			config.LAvg3Start = int.TryParse(txtLavg3Start.Text, out tempValInt) ? tempValInt : 0;
			config.LAvg4Start = int.TryParse(txtLavg4Start.Text, out tempValInt) ? tempValInt : 0;

			config.LAvg1End = int.TryParse(txtLavg1End.Text, out tempValInt) ? tempValInt : 0;
			config.LAvg2End = int.TryParse(txtLavg2End.Text, out tempValInt) ? tempValInt : 0;
			config.LAvg3End = int.TryParse(txtLavg3End.Text, out tempValInt) ? tempValInt : 0;
			config.LAvg4End = int.TryParse(txtLavg4End.Text, out tempValInt) ? tempValInt : 0;

			config.EnableCalAvg = chkEnableCalAvg.Checked;

			//cal settings
			config.AT.Risk = int.TryParse(txtATRisk.Text, out tempValInt) ? tempValInt : 0;

			config.ST.Factor = int.TryParse(txtSTFactor.Text, out tempValInt) ? tempValInt : 0;
			config.ST.Pd = int.TryParse(txtSTPd.Text, out tempValInt) ? tempValInt : 0;

			config.AT.Enabled = chkATTrend.Checked;
			config.ST.Enabled = chkSTTrend.Checked;
			//

			config.UseLavgForL = chkUseLavgForL.Checked;
			config.LavgToUse = cmbLavgToUse.SelectedIndex;
			config.CalSignal = chkCalSignal.Checked;
			config.SignalLavg = cmbSignalLavg.SelectedIndex;
			config.AlignedOutputFile = chkAlignedOutputFile.Checked && chkATTrend.Checked && chkSTTrend.Checked;
			config.OutputOnlyCompleteRow = chkOutputOnlyCompletedRows.Checked;
			config.OutputNewFormat = chkOutputNewFormat.Checked;

			config.OutputOnlyXRows = chkOutputOnlyXInterval.Checked;
			config.OutputXIntervalFile = txtXIntervalFile.Text;
			Close();
		}

		private void chkUseLavgForL_CheckedChanged(object sender, EventArgs e)
		{
			cmbLavgToUse.Enabled = chkUseLavgForL.Checked;
		}

		private void chkCalSignal_CheckedChanged(object sender, EventArgs e)
		{
			cmbSignalLavg.Enabled = chkCalSignal.Checked;
		}

		private void chkATTrend_CheckedChanged(object sender, EventArgs e)
		{
			groupATTrend.Enabled = chkATTrend.Checked;
			chkAlignedOutputFile.Enabled = chkATTrend.Checked && chkSTTrend.Checked;
			chkAlignedOutputFile.Checked = chkAlignedOutputFile.Checked && chkATTrend.Checked && chkSTTrend.Checked;
		}

		private void chkSTTrend_CheckedChanged(object sender, EventArgs e)
		{
			groupSTTrend.Enabled = chkSTTrend.Checked;
			chkAlignedOutputFile.Enabled = chkATTrend.Checked & chkSTTrend.Checked;
			chkAlignedOutputFile.Checked = chkAlignedOutputFile.Checked && chkATTrend.Checked && chkSTTrend.Checked;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void chkOutputOnlyXInterval_CheckedChanged(object sender, EventArgs e)
		{
			txtXIntervalFile.Enabled = btnBrowseIntervalFile.Enabled = chkOutputOnlyXInterval.Checked;
		}

		private void btnBrowseIntervalFile_Click(object sender, EventArgs e)
		{
			txtXIntervalFile.Text = Utils.GetFilePath("CSV Files|*.csv");
		}
	}
}
