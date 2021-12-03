using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SriOHLCBuilder
{
	public class Utils
	{
		public static string GetFolderPath(string initPath = "")
		{
			VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
			folderBrowserDialog.SelectedPath = initPath;
			if (folderBrowserDialog.ShowDialog().GetValueOrDefault())
			{
				return folderBrowserDialog.SelectedPath;
			}

			return initPath;
		}
		public static string GetFilePath(string filter, string initPath = "")
		{
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = filter;
			dlg.InitialDirectory = initPath;
			if (dlg.ShowDialog() == DialogResult.OK)
				return dlg.FileName;

			return "";
		}
	}
}
