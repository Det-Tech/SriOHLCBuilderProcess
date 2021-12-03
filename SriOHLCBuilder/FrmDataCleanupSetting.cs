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
	public partial class FrmDataCleanupSetting : Form
	{
		DataCleanupSettings config;
		public FrmDataCleanupSetting(DataCleanupSettings config_)
		{
			config = config_;
			InitializeComponent();

			BindSetting(false);
			panelSettings.Enabled = chkEnableDataCleanup.Checked;
		}

		private void chkEnableDataCleanup_CheckedChanged(object sender, EventArgs e)
		{
			panelSettings.Enabled = chkEnableDataCleanup.Checked;
		}

		void BindSetting(bool fromControl)
		{
			if (fromControl)
			{
				config.Enable = chkEnableDataCleanup.Checked;
				config.UsePerException = chkUsePerException.Checked;
				config.CleanupOutputFolder = txtOutputFolder.Text;
				try
				{
					config.ExceptionPercent = double.Parse(txtExceptionPercent.Text);
				}
				catch
				{

				}
				config.PerExceptionFile = txtPerExceptionFile.Text;
			}
			else
			{
				chkEnableDataCleanup.Checked = config.Enable;
				txtOutputFolder.Text = config.CleanupOutputFolder;
				chkUsePerException.Checked = config.UsePerException;
				txtExceptionPercent.Text = config.ExceptionPercent.ToString();
				txtPerExceptionFile.Text = config.PerExceptionFile;
			}
		}

		private void btnBrowseOutputFolder_Click(object sender, EventArgs e)
		{
			txtOutputFolder.Text = Utils.GetFolderPath(txtOutputFolder.Text);
		}

		private void btnBrowsePerExceptionFile_Click(object sender, EventArgs e)
		{
			txtPerExceptionFile.Text = Utils.GetFilePath("CSV Files|*.csv");
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			BindSetting(true);
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
