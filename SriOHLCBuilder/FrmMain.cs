using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SriOHLCBuilderModel;
using SriOHLCBuilderProcess;
using Ookii.Dialogs.Wpf;
using SriOHLCBuilderModel.Data;
using SriOHLCBuilderModel.Enums;

namespace SriOHLCBuilder
{
	public partial class FrmMain : Form
	{
		private bool bProcessStarted = false;
		private bool bWebSocketProcessStarted = false;
		private NetMQSender msgSender;
		string csvFilter = "CSV Files|*.csv";
		string textFilter = "Text Files(*.txt)|*.txt";
		private SriOHLCBuilderProcessor processor;
		private SriOHLCBuilderSettings Config { get => GlobalData.Config; }
		public FrmMain()
		{
			InitializeComponent();
			processor = new SriOHLCBuilderProcessor();
			processor.ProcessNotifier = new SriOHLCBuilderProcessor.ProcessNotifierDelegate(ProcessNotifier);
			processor.MessageSender = new SriOHLCBuilderProcessor.MessageSenderDeleagate(SendMessage);
			GlobalData.LoadSettings();
			timerUpdate.Tick += UpdateTick;
			BindSettings(false);

			msgSender = new NetMQSender();
			UpdateControlStateByDataFeed();

			if (Config.NetMQConfig.EnableZMQ)
				msgSender.Start(Config.NetMQConfig.IP, Config.NetMQConfig.Port);
		}

		private void UpdateTick(object sender, EventArgs e)
		{
			if (DateTime.Now.Second - Config.General.AutoUpdateDelay == 0 && bProcessStarted)
				DoAutoUpdate(sender, e);
		}

		private void SendMessage(string msg)
		{
			msgSender.SendMessage(msg);
			Console.WriteLine(msg);
		}
		private void SelectText(TextBox textBox)
		{
			textBox.Focus();
			textBox.SelectAll();
		}

		public bool BindSettings(bool bFromControl, bool bShowError = false)
		{
			bool bRet = true;
			if (bFromControl)
			{
				try
				{
					Config.General.BarLimit = int.Parse(txtBars.Text);
					int barMaxLimit = 99999;
					int barMinLimit = 0;

					if (Config.General.DataFeedSource == DataFeedSouce.PolygonV2)
					{
						barMinLimit = 1;
						barMaxLimit = 50000;
					}
					else if (Config.General.DataFeedSource == DataFeedSouce.AlpacaV2)
					{
						barMinLimit = 1;
						barMaxLimit = 10000;
					}
					else if (Config.General.DataFeedSource == DataFeedSouce.TradeStation)
					{
						barMinLimit = 1;
						barMaxLimit = 50000;
					}
					else if (Config.General.DataFeedSource == DataFeedSouce.TDAmeritrade)
					{
						barMinLimit = 1;
						barMaxLimit = 50000;
					}
					else if (Config.General.DataFeedSource == DataFeedSouce.OandaData)
					{
						barMinLimit = 1;
						barMaxLimit = 5000;
					}
					else if (Config.General.DataFeedSource == DataFeedSouce.TwelveData)
					{
						barMinLimit = 1;
						barMaxLimit = 5000;
					}

					if (Config.General.BarLimit < barMinLimit || Config.General.BarLimit > barMaxLimit)
					{
						if (bShowError)
						{
							MessageBox.Show("#Bar is invalid", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
							SelectText(txtBars);
							return false;
						}
					}
				}
				catch
				{
					bRet = false;
					if (bShowError)
					{
						MessageBox.Show("#Bar is invalid", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						SelectText(txtBars);
						return false;
					}
				}

				Config.General.InputFolder = txtInputFolder.Text;
				Config.General.OutputFolder = txtOutputFolder.Text;
				Config.General.MultiplierFile = txtMultiplierFile.Text;
				Config.General.MultiplierScheduleFile = txtMultiplierSchedule.Text;
				Config.General.SymbolListFile = txtSymbolListFile.Text;

				Config.General.EnableMarketTimeOnly = chkMarketHoursOnly.Checked;
				Config.General.MarketStartTime = dateTimeStart.Value;
				Config.General.MarketEndTime = dateTimeEnd.Value;

				Config.General.IsStaticMode = radioProcessStatic.Checked;
				
				Config.General.AppendUpdatedData = chkAppendData.Checked;
				Config.General.EnableCloseBarUpdate = chkCloseBarUpdate.Checked;

				if (radioHLC.Checked)
					Config.General.CloseBarUpdateMode = 0;
				else if (radioOHLC.Checked)
					Config.General.CloseBarUpdateMode = 1;
				else if (radioHL.Checked)
					Config.General.CloseBarUpdateMode = 2;
				else if (radioCO.Checked)
					Config.General.CloseBarUpdateMode = 3;

				Config.General.EnableCalendarAutoUpdate = chkCalendarAutoStart.Checked;

				Config.General.BackfillUpate = chkBackfillUpdate.Checked;
				int tempValInt = 0;
				Config.General.AutoUpdateDelay = int.TryParse(txtDelay.Text, out tempValInt) ? tempValInt : 0;
				Config.General.RoundPoints = int.TryParse(txtRounding.Text, out tempValInt) ? tempValInt : 0;

				if (Config.General.RoundPoints == 0)
					Config.General.RoundPoints = 2;

				if (Config.General.DataFeedSource == DataFeedSouce.PolygonV2)
					Config.PolygonConfig.APIKey = txtAPIKey.Text;
				else if (Config.General.DataFeedSource == DataFeedSouce.OandaData)
					Config.General.OandaAccessToken = txtAPIKey.Text;

				Config.PolygonConfig.Unadjusted = cmbUnadjusted.SelectedIndex == 1 ? true : false;
				Config.PolygonConfig.Sort = cmbSort.Text;

				Config.General.RoundChange = chkRoundChange.Checked;
				Config.General.RoundClose = chkRoundClose.Checked;
				Config.General.RoundVolume = chkRoundVol.Checked;
				Config.General.DataFeedSource = (DataFeedSouce)cmbDataFeedType.SelectedIndex;
				Config.General.TimeFrame = SriOHLCBuilderProcess.Utils.GetTimeFrameFromName(cmbTimeFrame.Text);
				Config.General.StartDate = dtStartDate.Value;
				Config.General.EndDate = dtEndDate.Value;

				Config.General.DontCalVol = chkDontCalVol.Checked;
				Config.General.BuildTodayBarOnly = chkCalTodayOnly.Checked;
				Config.General.AutoBuildEOD = chkAutoBuildEOD.Checked;
				Config.General.BuildHistoryEndDate = dtBuildHistoryEndDate.Value;

				Config.General.UseCloseBarTimestamp = chkUseCloseTimestamp.Checked;
				Config.General.LastTimestampException = chkLastTimestampException.Checked;

				Config.General.TimeSpanStr = cmbTimeFrame.Text;

				//Local Data
				Config.LocalDataFeedConfig.DataFolder = txtLocalDataFolder.Text;
			}
			else
			{
				//General
				txtBars.Text = Config.General.BarLimit.ToString();

				txtInputFolder.Text = Config.General.InputFolder;
				txtOutputFolder.Text = Config.General.OutputFolder;
				txtMultiplierFile.Text = Config.General.MultiplierFile;
				txtSymbolListFile.Text = Config.General.SymbolListFile;
				txtMultiplierFile.Text = Config.General.MultiplierFile;
				txtMultiplierSchedule.Text = Config.General.MultiplierScheduleFile;
				chkMarketHoursOnly.Checked = Config.General.EnableMarketTimeOnly;

				dateTimeStart.Enabled = dateTimeEnd.Enabled = Config.General.EnableMarketTimeOnly;

				dateTimeStart.Value = Config.General.MarketStartTime;
				dateTimeEnd.Value = Config.General.MarketEndTime;

				radioProcessStatic.Checked = Config.General.IsStaticMode;
				radioProcessAuto.Checked = !Config.General.IsStaticMode;

				chkAppendData.Checked = Config.General.AppendUpdatedData;
				chkAppendData.Enabled = !Config.General.IsStaticMode;

				chkCloseBarUpdate.Checked = Config.General.EnableCloseBarUpdate;
				radioHLC.Enabled = radioOHLC.Enabled = radioHL.Enabled = radioCO.Enabled = Config.General.EnableCloseBarUpdate;
				radioHLC.Checked = Config.General.CloseBarUpdateMode == 0;
				radioOHLC.Checked = Config.General.CloseBarUpdateMode == 1;
				radioHL.Checked = Config.General.CloseBarUpdateMode == 2;
				radioCO.Checked = Config.General.CloseBarUpdateMode == 3;

				chkCalendarAutoStart.Checked = Config.General.EnableCalendarAutoUpdate;

				dateTimeStart.Enabled = dateTimeEnd.Enabled = !Config.General.EnableCalendarAutoUpdate;

				chkBackfillUpdate.Checked = Config.General.BackfillUpate;

				txtDelay.Text = Config.General.AutoUpdateDelay.ToString();

				txtRounding.Text = Config.General.RoundPoints.ToString();
				chkRoundChange.Checked = Config.General.RoundChange;
				chkRoundClose.Checked = Config.General.RoundClose;
				chkRoundVol.Checked = Config.General.RoundVolume;

				cmbDataFeedType.SelectedIndex = (int)Config.General.DataFeedSource;
				dtStartDate.Value = Config.General.StartDate;
				dtEndDate.Value = Config.General.EndDate;
				
				if (Config.General.DataFeedSource == DataFeedSouce.PolygonV2)
					txtAPIKey.Text = Config.PolygonConfig.APIKey;
				else if (Config.General.DataFeedSource == DataFeedSouce.OandaData)
					txtAPIKey.Text = Config.General.OandaAccessToken;

				cmbUnadjusted.SelectedIndex = Config.PolygonConfig.Unadjusted ? 1 : 0;
				cmbSort.SelectedIndex = Config.PolygonConfig.Sort == "desc" ? 1 : 0;

				chkDontCalVol.Checked = Config.General.DontCalVol;
				chkCalTodayOnly.Checked = Config.General.BuildTodayBarOnly;
				chkAutoBuildEOD.Checked = Config.General.AutoBuildEOD;
				dtBuildHistoryEndDate.Value = Config.General.BuildHistoryEndDate;

				chkUseCloseTimestamp.Checked = Config.General.UseCloseBarTimestamp;
				chkLastTimestampException.Checked = Config.General.LastTimestampException;

				txtLocalDataFolder.Text = Config.LocalDataFeedConfig.DataFolder;

				ShowControlsByDataFeed();
			}

			return bRet;
		}
		private bool CheckStartConditions()
		{
			bool bRet = true;

			if (string.IsNullOrEmpty(txtOutputFolder.Text))
			{
				MessageBox.Show("Please enter Output Data Path", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				SelectText(txtOutputFolder);
				return false;
			}

			if (string.IsNullOrEmpty(txtSymbolListFile.Text))
			{
				MessageBox.Show("Please select a symbollist file", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				SelectText(txtMultiplierFile);
				return false;
			}
			else if (!File.Exists(txtSymbolListFile.Text))
			{
				MessageBox.Show("The symbollist file does not exist", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				SelectText(txtMultiplierFile);
				return false;
			}

			if (string.IsNullOrEmpty(txtBars.Text))
			{
				MessageBox.Show("Please enter #Bars", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				SelectText(txtBars);
				return false;
			}

			return bRet;
		}
		private void FrmMain_Load(object sender, EventArgs e)
		{

		}
		private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to exit?", GlobalData.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				e.Cancel = true;
				return;
			}

			BindSettings(true);

			if (Config.NetMQConfig.EnableZMQ)
				msgSender.Stop();

			GlobalData.SaveSettings();
		}

		private void btnStart_Click(object sender, EventArgs e)
		{
			if (!bProcessStarted)
			{
				if (!CheckStartConditions())
				{
					bProcessStarted = false;
					return;
				}
				if (!BindSettings(true, true))
				{
					bProcessStarted = false;
					return;
				}

				GlobalData.SaveSettings();

				if (Config.General.EnableCalendarAutoUpdate)
				{
					if (File.Exists(GlobalData.GetCalendarFilePath()))
						processor.PrepareCalendarListFromFile();
					else
					{
						MessageBox.Show("Calendar File does not exist!", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						bProcessStarted = false;
						return;
					}
				}


				if (!processor.PrepareStockSymbolList(Config.General.SymbolListFile))
				{
					MessageBox.Show("Failed to load symbollist", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
					bProcessStarted = false;
					return;
				}

				bProcessStarted = true;

				EnableAllControls(false);

				processor.ClearOriginalData();

				if (!Config.General.EnableCalendarAutoUpdate || Config.General.IsStaticMode)
				{
					processor.StopROutput = false;
					processor.TimeFrames = null;
					processor.Start();
				}
				else
					DoAutoUpdate(null, null);

				btnStart.Text = "Stop";
			}
			else
			{
				processor.Stop();
				btnStart.Text = "Start";
				bProcessStarted = false;
				lblProcessStatus.Text = "Cancelled by user";
				statusProgressBar.Visible = false;
				statusProgressBar.Value = 0;
				EnableAllControls(true);
			}
		}

		private void EnableAllControls(bool bEnable)
		{
			groupGeneral.Enabled = bEnable;
			groupDataType.Enabled = bEnable;
		}
		private void btnBrowseInputDataPath_Click(object sender, EventArgs e)
		{
			txtInputFolder.Text = Utils.GetFolderPath(txtInputFolder.Text);
		}

		private void ProcessNotifier(SriOHLCBuilderProcessor.ProcessState state, int param)
		{
			switch (state)
			{
				case SriOHLCBuilderProcessor.ProcessState.Start:
					bProcessStarted = true;
					BeginInvoke(new Action(() => EnableAllControls(false)));
					BeginInvoke(new Action(() => lblProcessStatus.Text = "Starting..."));
					BeginInvoke(new Action(() => statusProgressBar.Maximum = 100));
					BeginInvoke(new Action(() => statusProgressBar.Value = 0));
					BeginInvoke(new Action(() => statusProgressBar.Visible = true));
					break;
				case SriOHLCBuilderProcessor.ProcessState.Progress:
					BeginInvoke(new Action(() => statusProgressBar.Value = param));
					if (!bWebSocketProcessStarted)
						BeginInvoke(new Action(() => lblProcessStatus.Text = "Overall Progress"));
					break;
				case SriOHLCBuilderProcessor.ProcessState.Pause:
					BeginInvoke(new Action(() => btnStart.Text = "Resume"));
					bProcessStarted = false;
					break;
				case SriOHLCBuilderProcessor.ProcessState.Stop:
					
					BeginInvoke(new Action(() => EnableAllControls(true)));
					BeginInvoke(new Action(() => btnStart.Text = "Start"));
					BeginInvoke(new Action(() => statusProgressBar.Visible = false));
					BeginInvoke(new Action(() => statusProgressBar.Value = 0));
					if (param == -1)
						BeginInvoke(new Action(() => lblProcessStatus.Text = "Connection Error"));
					else
						BeginInvoke(new Action(() => lblProcessStatus.Text = "Cancelled by user"));
					bProcessStarted = false;

					if (Config.NetMQConfig.EnableZMQ)
						msgSender.Stop();

					break;
				case SriOHLCBuilderProcessor.ProcessState.Complete:
					
					if (Config.General.IsStaticMode)
					{
						bProcessStarted = false;
						BeginInvoke(new Action(() => EnableAllControls(true)));
						BeginInvoke(new Action(() => btnStart.Text = "Start"));
						BeginInvoke(new Action(() => statusProgressBar.Visible = false));
						BeginInvoke(new Action(() => statusProgressBar.Value = 0));
						BeginInvoke(new Action(() => lblProcessStatus.Text = "Download Completed"));
					}
					else
					{
						BeginInvoke(new Action(() => statusProgressBar.Value = 0));
						BeginInvoke(new Action(() => lblProcessStatus.Text = "Waiting for Auto Update..."));
					}

					//if (Config.NetMQConfig.EnableZMQ)
					//	msgSender.Stop();
					break;
				case SriOHLCBuilderProcessor.ProcessState.ConnectionError:
					BeginInvoke(new Action(() => lblProcessStatus.Text = "Connection Error. Trying again..."));
					break;
				//case AlpacaDLProcessor.ProcessState.Waiting:
				//	BeginInvoke(new Action(() => statusProgressBar.Value = 0));
				//	BeginInvoke(new Action(() => lblProcessStatus.Text = "Waiting for Auto Update..."));
				//	break;
				case SriOHLCBuilderProcessor.ProcessState.Appended:
					BeginInvoke(new Action(() => lblProcessStatus.Text = param.ToString() + " Symbols Appended"));
					break;
				case SriOHLCBuilderProcessor.ProcessState.Calendar:
					if (param == 1)
						BeginInvoke(new Action(() => MessageBox.Show("Calendar File generated successfully!", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information)));
					else
						BeginInvoke(new Action(() => MessageBox.Show("An error occurred while generating Calendar File.", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)));
					break;

				case SriOHLCBuilderProcessor.ProcessState.TrimRawData:
					if (param == 1)
					{
						BeginInvoke(new Action(() => TrimControlEnable(false)));
					}
					else if (param == 2)
					{
						BeginInvoke(new Action(() => MessageBox.Show("Trim Completed!", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information)));
						BeginInvoke(new Action(() => TrimControlEnable(true)));
					}
					else
					{
						BeginInvoke(new Action(() => MessageBox.Show("An error occurred while trimming output files.", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning)));
						BeginInvoke(new Action(() => TrimControlEnable(true)));
					}
					break;
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			processor.Stop();
			Application.Exit();
		}
		private void btnBrowseSymbolList_Click(object sender, EventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = "Stock Symbol List|*.txt";
			if (openDlg.ShowDialog() == DialogResult.OK)
			{
				Config.General.SymbolListFile = openDlg.FileName;
				txtMultiplierFile.Text = openDlg.FileName;
			}
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			
		}

		private void chkMarketHoursOnly_CheckedChanged(object sender, EventArgs e)
		{
			dateTimeStart.Enabled = dateTimeEnd.Enabled = chkMarketHoursOnly.Checked;
		}

		private void radioProcessStatic_CheckedChanged(object sender, EventArgs e)
		{
			//chkAppendData.Enabled = radioProcessAuto.Checked;
		}
		private bool CanAutoUpdate()
		{
			if (Config.General.EnableCalendarAutoUpdate)
			{
				return processor.IsTimeInMarketHour(DateTime.UtcNow);
			}
			else
			{
				DateTime now = DateTime.Now;

				DateTime startTime = new DateTime(now.Year, now.Month, now.Day,
														Config.General.MarketStartTime.Hour, Config.General.MarketStartTime.Minute, 0);
				DateTime endTime = new DateTime(now.Year, now.Month, now.Day,
											Config.General.MarketEndTime.Hour, Config.General.MarketEndTime.Minute, 0);

				if (startTime > now || endTime < now)
					return false;
			}

			return true;
		}
		/// <summary>
		/// Check whether auto update is available in every 1 min.
		/// Do update if time is between open and close
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DoAutoUpdate(object sender, EventArgs e)
		{
			if (!Config.General.IsStaticMode)
			{
				if (!CanAutoUpdate())
				{
					BeginInvoke(new Action(() => lblProcessStatus.Text = "Waiting for market open..."));
					return;
				}
				else
				{
					DateTime now = DateTime.Now;

					List<DataTimeFrame> timeFrames = new List<DataTimeFrame>();

					if (e == null)
					{
						timeFrames.Add(Config.General.TimeFrame);
					}
					else
					{
						bool isStartTime = now.Hour == Config.General.MarketStartTime.Hour && now.Minute == Config.General.MarketStartTime.Minute;
						bool isEndTime = now.Hour == Config.General.MarketEndTime.Hour && now.Minute == Config.General.MarketEndTime.Minute;

						if (Config.General.TimeFrame == DataTimeFrame.Day && (isEndTime || isStartTime))
						{
							timeFrames.Add(DataTimeFrame.Day);      //perform 1D update
						}

						if (Config.General.TimeFrame == DataTimeFrame.Minute)
						{
							timeFrames.Add(DataTimeFrame.Minute);  //TimeFrame.Minute
						}

						if (Config.General.TimeFrame == DataTimeFrame.Minute5 && (now.Minute % 5 == 0 || isStartTime))
						{
							timeFrames.Add(DataTimeFrame.Minute5);  //TimeFrame.FiveMinute
						}

						if (Config.General.TimeFrame == DataTimeFrame.Minute15 && (now.Minute % 15 == 0 || isStartTime))
						{
							timeFrames.Add(DataTimeFrame.Minute15);  //TimeFrame.FiveMinute
						}

						if (Config.General.TimeFrame == DataTimeFrame.Hour && (now.Minute % 60 == 0 || isStartTime))
						{
							timeFrames.Add(DataTimeFrame.Hour);  //TimeFrame.15Mins
						}
					}
					if (timeFrames.Count >= 1)
					{
						processor.StopROutput = false;

						processor.TimeFrames = timeFrames;

						processor.Start();
					}
				}
			}
		}
		private void chkCloseBarUpdate_CheckedChanged(object sender, EventArgs e)
		{
			radioHLC.Enabled = radioHL.Enabled = radioOHLC.Enabled = radioCO.Enabled = chkCloseBarUpdate.Checked;
		}

		private void radioProcessStatic_Click(object sender, EventArgs e)
		{
			RadioButton[] buttons = { radioProcessStatic, radioProcessAuto };

			foreach (var btn in buttons)
			{
				btn.Checked = sender == btn;
				chkAppendData.Enabled = sender == radioProcessAuto;
				txtDelay.Enabled = sender == radioProcessAuto;
			}
		}

		private void radioHL_Click(object sender, EventArgs e)
		{
			RadioButton[] buttons = { radioHLC, radioHL, radioOHLC, radioCO};

			foreach (var btn in buttons)
			{
				btn.Checked = sender == btn;
			}
		}
		private void chkCalendarAutoStart_CheckedChanged(object sender, EventArgs e)
		{
			dateTimeStart.Enabled = dateTimeEnd.Enabled = !(chkCalendarAutoStart.Checked);
		}

		private void chkCalendarWebSocket_CheckedChanged(object sender, EventArgs e)
		{
			dateTimeStart.Enabled = dateTimeEnd.Enabled = !(chkCalendarAutoStart.Checked);
		}

		private string GetFolderPath(string initPath = "")
		{
			VistaFolderBrowserDialog folderBrowserDialog = new VistaFolderBrowserDialog();
			folderBrowserDialog.SelectedPath = initPath;
			if (folderBrowserDialog.ShowDialog().GetValueOrDefault())
			{
				return folderBrowserDialog.SelectedPath;
			}

			return "";
		}

		private void TrimControlEnable(bool bEnable)
		{

		}

		private void txtSymbolListFile_TextChanged(object sender, EventArgs e)
		{

		}

		private void label3_Click(object sender, EventArgs e)
		{

		}

		private void radioProcessAuto_CheckedChanged(object sender, EventArgs e)
		{

		}

		private void cmbDataFeedType_SelectedIndexChanged(object sender, EventArgs e)
		{
			Config.General.DataFeedSource = (DataFeedSouce)cmbDataFeedType.SelectedIndex;
			UpdateControlStateByDataFeed();

			if (Config.General.DataFeedSource == DataFeedSouce.PolygonV2)
				txtAPIKey.Text = Config.PolygonConfig.APIKey;
			else if (Config.General.DataFeedSource == DataFeedSouce.OandaData)
				txtAPIKey.Text = Config.General.OandaAccessToken;

		}

		void UpdateControlStateByDataFeed()
		{
			UpdateTimeFrameItems(Config.General.DataFeedSource);

			if (Config.General.DataFeedSource == DataFeedSouce.PolygonV2)
			{
				dtStartDate.Enabled = dtEndDate.Enabled = true;
				lblBarLimit.Text = "Limit(1~50000)";
				lblTimeFrame.Text = "TimeSpan";
				btnDatafeedConfig.Visible = false;
			}
			else if (Config.General.DataFeedSource == DataFeedSouce.AlpacaV2)
			{
				lblBarLimit.Text = "Limit(1~10000)";
				btnDatafeedConfig.Visible = true;
			}
			else if (Config.General.DataFeedSource == DataFeedSouce.TradeStation)
			{
				lblBarLimit.Text = "Limit(1~50000)";
				btnDatafeedConfig.Visible = true;
			}
			else if (Config.General.DataFeedSource == DataFeedSouce.TDAmeritrade)
			{
				lblBarLimit.Text = "Limit(1~50000)";
				btnDatafeedConfig.Visible = true;
			}
			else if (Config.General.DataFeedSource == DataFeedSouce.OnlyLocalData)
			{
				radioProcessAuto.Checked = false;
				radioProcessStatic.Checked = true;
				chkBackfillUpdate.Checked = true;
			}
			else if (Config.General.DataFeedSource == DataFeedSouce.TwelveData)
			{
				lblBarLimit.Text = "Limit(1~5000)";
				btnDatafeedConfig.Visible = true;
			}
			else if (Config.General.DataFeedSource == DataFeedSouce.OandaData)
			{
				lblBarLimit.Text = "Limit(1~5000)";
				btnDatafeedConfig.Visible = false;
			}

			cmbUnadjusted.Enabled = cmbSort.Enabled = Config.General.DataFeedSource == DataFeedSouce.PolygonV2;
			panelPolygonDataFeedSetting.Visible = Config.General.DataFeedSource == DataFeedSouce.PolygonV2 ||
				Config.General.DataFeedSource == DataFeedSouce.OandaData;
			ShowControlsByDataFeed();
		}

		private void UpdateTimeFrameItems(DataFeedSouce dataSource)
		{
			cmbTimeFrame.Items.Clear();

			if (Config.General.DataFeedSource == DataFeedSouce.OandaData)
			{
				cmbTimeFrame.Items.Add("S5");
				cmbTimeFrame.Items.Add("M1");
				cmbTimeFrame.Items.Add("H1");
				cmbTimeFrame.Items.Add("D");
				cmbTimeFrame.Text = Config.General.TimeSpanStr;
			}
			else
			{
				List<DataTimeFrame> timeFrames = new List<DataTimeFrame>();

				timeFrames.Add(DataTimeFrame.Minute);
				timeFrames.Add(DataTimeFrame.Hour);
				timeFrames.Add(DataTimeFrame.Day);

				int selectedIndex = 0;
				for (int i = 0; i < timeFrames.Count; i++)
				{
					cmbTimeFrame.Items.Add(SriOHLCBuilderProcess.Utils.GetNameFromTimeFrame(timeFrames[i]));
					if (Config.General.TimeFrame == timeFrames[i])
						selectedIndex = i;
				}

				cmbTimeFrame.SelectedIndex = selectedIndex;
			}
			
		}

		private void btnTSDataFeedConfig_Click(object sender, EventArgs e)
		{
			
		}

		private void btnRefreshToken_Click(object sender, EventArgs e)
		{
			
		}

		void ShowControlsByDataFeed()
		{
			txtBars.Enabled = Config.General.DataFeedSource != DataFeedSouce.OnlyLocalData;
			panelPolygonDataFeedSetting.Visible = Config.General.DataFeedSource == DataFeedSouce.PolygonV2 ||
				Config.General.DataFeedSource == DataFeedSouce.OandaData;

			panelLocalData.Visible = Config.General.DataFeedSource == DataFeedSouce.OnlyLocalData;
		}

		private void cmbTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		
		private void btnTest_Click(object sender, EventArgs e)
		{
			processor.Test();
		}

		private void btnBrowseInputFolder_Click(object sender, EventArgs e)
		{
			txtInputFolder.Text = Utils.GetFolderPath(txtInputFolder.Text);
		}

		private void btnBrowseOutputFolder_Click(object sender, EventArgs e)
		{
			txtOutputFolder.Text = Utils.GetFolderPath(txtOutputFolder.Text);
		}

		private void btnBrowseSymbolListFile_Click(object sender, EventArgs e)
		{
			txtSymbolListFile.Text = Utils.GetFilePath(textFilter);
		}

		private void btnBrowseMultiplerFile_Click(object sender, EventArgs e)
		{
			txtMultiplierFile.Text = Utils.GetFilePath(textFilter);
		}

		private void btnGenEODFiles_Click(object sender, EventArgs e)
		{
			if (!bProcessStarted)
			{
				if (!CheckStartConditions())
				{
					bProcessStarted = false;
					return;
				}
				if (!BindSettings(true, true))
				{
					bProcessStarted = false;
					return;
				}

				GlobalData.SaveSettings();

				if (Config.General.EnableCalendarAutoUpdate)
				{
					if (File.Exists(GlobalData.GetCalendarFilePath()))
						processor.PrepareCalendarListFromFile();
					else
					{
						MessageBox.Show("Calendar File does not exist!", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						bProcessStarted = false;
						return;
					}
				}


				if (!processor.PrepareStockSymbolList(Config.General.SymbolListFile))
				{
					MessageBox.Show("Failed to load symbollist", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
					bProcessStarted = false;
					return;
				}

				bProcessStarted = true;

				EnableAllControls(false);

				processor.ClearOriginalData();

				processor.StopROutput = false;
				processor.TimeFrames = null;

				processor.Start();
			}
			else
			{
				processor.Stop();
				bProcessStarted = false;
				lblProcessStatus.Text = "Cancelled by user";
				statusProgressBar.Visible = false;
				statusProgressBar.Value = 0;
				EnableAllControls(true);
			}
		}

		private void btnCalSetting_Click(object sender, EventArgs e)
		{
			FrmCalSettings frm = new FrmCalSettings(Config.Cal);
			frm.ShowDialog();
		}

		private void btnZeroMQ_Click(object sender, EventArgs e)
		{
			FrmZeroMQSettings frm = new FrmZeroMQSettings(Config.NetMQConfig);
			if (frm.ShowDialog() == DialogResult.OK)
			{
				msgSender.Stop();
				if (Config.NetMQConfig.EnableZMQ)
					msgSender.Start(Config.NetMQConfig.IP, Config.NetMQConfig.Port);
			}
		}

		private void btnDatafeedConfig_Click(object sender, EventArgs e)
		{
			DataFeedSouce datafeed = (DataFeedSouce)cmbDataFeedType.SelectedIndex;

			switch (datafeed)
			{
				case DataFeedSouce.AlpacaV2:
					FrmAlpacaSetting frmAlpcaa = new FrmAlpacaSetting(Config.AlpacaConfig);
					frmAlpcaa.ShowDialog();
					break;
				case DataFeedSouce.TradeStation:
					FrmTSDataFeedSettings frmTS = new FrmTSDataFeedSettings(Config.TradeStationConfig);
					frmTS.ShowDialog();
					break;
				case DataFeedSouce.TDAmeritrade:
					FrmTDAmeritradeSetting frmTD = new FrmTDAmeritradeSetting(Config.TDAmeritradeConfig);
					frmTD.ShowDialog();
					break;
				case DataFeedSouce.TwelveData:
					FrmTwelveDataSetting frmTw = new FrmTwelveDataSetting(Config.TwelveDataConfig);
					frmTw.ShowDialog();
					break;
			}
		}

		private void btnBuildHistory_Click(object sender, EventArgs e)
		{
			
			if (!CheckStartConditions())
			{
				return;
			}
			if (!BindSettings(true, true))
			{
				return;
			}

			GlobalData.SaveSettings();

			if (!processor.PrepareStockSymbolList(Config.General.SymbolListFile))
			{
				MessageBox.Show("Failed to load symbollist", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			processor.ClearOriginalData();

			processor.Start(true);
		}

		private void btnAWSSetting_Click(object sender, EventArgs e)
		{
			FrmAWS3Config frm = new FrmAWS3Config(Config.AWSS3Config);
			frm.ShowDialog();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			txtMultiplierSchedule.Text = Utils.GetFilePath(csvFilter);
		}

		private void btnMinBaseCheck_Click(object sender, EventArgs e)
		{
			if (!processor.PrepareStockSymbolList(Config.General.SymbolListFile))
			{
				MessageBox.Show("Failed to load symbollist", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			BindSettings(true);

			bool bRet = processor.CheckMinBaseData();
			if (bRet)
				MessageBox.Show("The Base Data is enough!", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			else
				MessageBox.Show("The Base Data is not enough!" + 
					Environment.NewLine + "Please see log file for details.", GlobalData.AppName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}

		private void btnBrowseLocalDataFolder_Click(object sender, EventArgs e)
		{
			txtLocalDataFolder.Text = GetFolderPath(txtLocalDataFolder.Text);
		}

		private void btnDataCleanup_Click(object sender, EventArgs e)
		{
			FrmDataCleanupSetting frm = new FrmDataCleanupSetting(Config.DataCleanupConfig);
			frm.ShowDialog();
		}
	}
}
