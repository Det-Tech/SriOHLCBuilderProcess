namespace SriOHLCBuilder
{
	partial class FrmMain
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
			this.components = new System.ComponentModel.Container();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.timerUpdate = new System.Windows.Forms.Timer(this.components);
			this.groupDataType = new System.Windows.Forms.GroupBox();
			this.panelLocalData = new System.Windows.Forms.Panel();
			this.btnBrowseLocalDataFolder = new System.Windows.Forms.Button();
			this.txtLocalDataFolder = new System.Windows.Forms.TextBox();
			this.chkLastTimestampException = new System.Windows.Forms.CheckBox();
			this.chkUseCloseTimestamp = new System.Windows.Forms.CheckBox();
			this.btnDatafeedConfig = new System.Windows.Forms.Button();
			this.panelPolygonDataFeedSetting = new System.Windows.Forms.Panel();
			this.lblPolygonKey = new System.Windows.Forms.Label();
			this.txtAPIKey = new System.Windows.Forms.TextBox();
			this.lblSort = new System.Windows.Forms.Label();
			this.cmbSort = new System.Windows.Forms.ComboBox();
			this.chkRoundVol = new System.Windows.Forms.CheckBox();
			this.chkRoundClose = new System.Windows.Forms.CheckBox();
			this.lblUnadjusted = new System.Windows.Forms.Label();
			this.chkRoundChange = new System.Windows.Forms.CheckBox();
			this.cmbUnadjusted = new System.Windows.Forms.ComboBox();
			this.txtRounding = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.dtEndDate = new System.Windows.Forms.DateTimePicker();
			this.dtStartDate = new System.Windows.Forms.DateTimePicker();
			this.label6 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.cmbDataFeedType = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.cmbTimeFrame = new System.Windows.Forms.ComboBox();
			this.txtDelay = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.chkBackfillUpdate = new System.Windows.Forms.CheckBox();
			this.chkCalendarAutoStart = new System.Windows.Forms.CheckBox();
			this.radioCO = new System.Windows.Forms.RadioButton();
			this.radioHL = new System.Windows.Forms.RadioButton();
			this.radioOHLC = new System.Windows.Forms.RadioButton();
			this.radioHLC = new System.Windows.Forms.RadioButton();
			this.chkCloseBarUpdate = new System.Windows.Forms.CheckBox();
			this.chkAppendData = new System.Windows.Forms.CheckBox();
			this.label10 = new System.Windows.Forms.Label();
			this.radioProcessAuto = new System.Windows.Forms.RadioButton();
			this.radioProcessStatic = new System.Windows.Forms.RadioButton();
			this.label9 = new System.Windows.Forms.Label();
			this.chkMarketHoursOnly = new System.Windows.Forms.CheckBox();
			this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
			this.dateTimeStart = new System.Windows.Forms.DateTimePicker();
			this.txtBars = new System.Windows.Forms.TextBox();
			this.lblBarLimit = new System.Windows.Forms.Label();
			this.lblTimeFrame = new System.Windows.Forms.Label();
			this.btnBrowseMultiplerFile = new System.Windows.Forms.Button();
			this.txtMultiplierFile = new System.Windows.Forms.TextBox();
			this.lblMultiplier = new System.Windows.Forms.Label();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.lblProcessStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.statusProgressBar = new System.Windows.Forms.ToolStripProgressBar();
			this.groupGeneral = new System.Windows.Forms.GroupBox();
			this.dtBuildHistoryEndDate = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.chkAutoBuildEOD = new System.Windows.Forms.CheckBox();
			this.chkCalTodayOnly = new System.Windows.Forms.CheckBox();
			this.chkDontCalVol = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtMultiplierSchedule = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.btnBrowseSymbolListFile = new System.Windows.Forms.Button();
			this.txtSymbolListFile = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnBrowseOutputFolder = new System.Windows.Forms.Button();
			this.txtOutputFolder = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnBrowseInputFolder = new System.Windows.Forms.Button();
			this.txtInputFolder = new System.Windows.Forms.TextBox();
			this.btnZeroMQ = new System.Windows.Forms.Button();
			this.btnBuildHistory = new System.Windows.Forms.Button();
			this.btnAWSSetting = new System.Windows.Forms.Button();
			this.btnMinBaseCheck = new System.Windows.Forms.Button();
			this.btnDataCleanup = new System.Windows.Forms.Button();
			this.groupDataType.SuspendLayout();
			this.panelLocalData.SuspendLayout();
			this.panelPolygonDataFeedSetting.SuspendLayout();
			this.statusStrip1.SuspendLayout();
			this.groupGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnStart
			// 
			this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.btnStart.Location = new System.Drawing.Point(14, 597);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(182, 31);
			this.btnStart.TabIndex = 43;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnExit
			// 
			this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.btnExit.Location = new System.Drawing.Point(395, 666);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(181, 31);
			this.btnExit.TabIndex = 48;
			this.btnExit.Text = "Exit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// timerUpdate
			// 
			this.timerUpdate.Enabled = true;
			this.timerUpdate.Interval = 1000;
			// 
			// groupDataType
			// 
			this.groupDataType.Controls.Add(this.panelLocalData);
			this.groupDataType.Controls.Add(this.chkLastTimestampException);
			this.groupDataType.Controls.Add(this.chkUseCloseTimestamp);
			this.groupDataType.Controls.Add(this.btnDatafeedConfig);
			this.groupDataType.Controls.Add(this.panelPolygonDataFeedSetting);
			this.groupDataType.Controls.Add(this.lblSort);
			this.groupDataType.Controls.Add(this.cmbSort);
			this.groupDataType.Controls.Add(this.chkRoundVol);
			this.groupDataType.Controls.Add(this.chkRoundClose);
			this.groupDataType.Controls.Add(this.lblUnadjusted);
			this.groupDataType.Controls.Add(this.chkRoundChange);
			this.groupDataType.Controls.Add(this.cmbUnadjusted);
			this.groupDataType.Controls.Add(this.txtRounding);
			this.groupDataType.Controls.Add(this.label19);
			this.groupDataType.Controls.Add(this.dtEndDate);
			this.groupDataType.Controls.Add(this.dtStartDate);
			this.groupDataType.Controls.Add(this.label6);
			this.groupDataType.Controls.Add(this.label12);
			this.groupDataType.Controls.Add(this.label8);
			this.groupDataType.Controls.Add(this.cmbDataFeedType);
			this.groupDataType.Controls.Add(this.label7);
			this.groupDataType.Controls.Add(this.cmbTimeFrame);
			this.groupDataType.Controls.Add(this.txtDelay);
			this.groupDataType.Controls.Add(this.label18);
			this.groupDataType.Controls.Add(this.chkBackfillUpdate);
			this.groupDataType.Controls.Add(this.chkCalendarAutoStart);
			this.groupDataType.Controls.Add(this.radioCO);
			this.groupDataType.Controls.Add(this.radioHL);
			this.groupDataType.Controls.Add(this.radioOHLC);
			this.groupDataType.Controls.Add(this.radioHLC);
			this.groupDataType.Controls.Add(this.chkCloseBarUpdate);
			this.groupDataType.Controls.Add(this.chkAppendData);
			this.groupDataType.Controls.Add(this.label10);
			this.groupDataType.Controls.Add(this.radioProcessAuto);
			this.groupDataType.Controls.Add(this.radioProcessStatic);
			this.groupDataType.Controls.Add(this.label9);
			this.groupDataType.Controls.Add(this.chkMarketHoursOnly);
			this.groupDataType.Controls.Add(this.dateTimeEnd);
			this.groupDataType.Controls.Add(this.dateTimeStart);
			this.groupDataType.Controls.Add(this.txtBars);
			this.groupDataType.Controls.Add(this.lblBarLimit);
			this.groupDataType.Controls.Add(this.lblTimeFrame);
			this.groupDataType.Location = new System.Drawing.Point(9, 276);
			this.groupDataType.Name = "groupDataType";
			this.groupDataType.Size = new System.Drawing.Size(574, 309);
			this.groupDataType.TabIndex = 50;
			this.groupDataType.TabStop = false;
			this.groupDataType.Text = "Download Settings";
			// 
			// panelLocalData
			// 
			this.panelLocalData.Controls.Add(this.btnBrowseLocalDataFolder);
			this.panelLocalData.Controls.Add(this.txtLocalDataFolder);
			this.panelLocalData.Location = new System.Drawing.Point(280, 11);
			this.panelLocalData.Name = "panelLocalData";
			this.panelLocalData.Size = new System.Drawing.Size(282, 38);
			this.panelLocalData.TabIndex = 76;
			this.panelLocalData.Visible = false;
			// 
			// btnBrowseLocalDataFolder
			// 
			this.btnBrowseLocalDataFolder.Location = new System.Drawing.Point(249, 8);
			this.btnBrowseLocalDataFolder.Name = "btnBrowseLocalDataFolder";
			this.btnBrowseLocalDataFolder.Size = new System.Drawing.Size(27, 22);
			this.btnBrowseLocalDataFolder.TabIndex = 80;
			this.btnBrowseLocalDataFolder.Text = "...";
			this.btnBrowseLocalDataFolder.UseVisualStyleBackColor = true;
			this.btnBrowseLocalDataFolder.Click += new System.EventHandler(this.btnBrowseLocalDataFolder_Click);
			// 
			// txtLocalDataFolder
			// 
			this.txtLocalDataFolder.Location = new System.Drawing.Point(12, 9);
			this.txtLocalDataFolder.Name = "txtLocalDataFolder";
			this.txtLocalDataFolder.Size = new System.Drawing.Size(237, 20);
			this.txtLocalDataFolder.TabIndex = 79;
			// 
			// chkLastTimestampException
			// 
			this.chkLastTimestampException.AutoSize = true;
			this.chkLastTimestampException.Location = new System.Drawing.Point(383, 276);
			this.chkLastTimestampException.Name = "chkLastTimestampException";
			this.chkLastTimestampException.Size = new System.Drawing.Size(150, 17);
			this.chkLastTimestampException.TabIndex = 75;
			this.chkLastTimestampException.Text = "Last Timestamp Exception";
			this.chkLastTimestampException.UseVisualStyleBackColor = true;
			// 
			// chkUseCloseTimestamp
			// 
			this.chkUseCloseTimestamp.AutoSize = true;
			this.chkUseCloseTimestamp.Location = new System.Drawing.Point(383, 246);
			this.chkUseCloseTimestamp.Name = "chkUseCloseTimestamp";
			this.chkUseCloseTimestamp.Size = new System.Drawing.Size(147, 17);
			this.chkUseCloseTimestamp.TabIndex = 74;
			this.chkUseCloseTimestamp.Text = "Use Close Bar Timestamp";
			this.chkUseCloseTimestamp.UseVisualStyleBackColor = true;
			// 
			// btnDatafeedConfig
			// 
			this.btnDatafeedConfig.Location = new System.Drawing.Point(280, 20);
			this.btnDatafeedConfig.Name = "btnDatafeedConfig";
			this.btnDatafeedConfig.Size = new System.Drawing.Size(75, 23);
			this.btnDatafeedConfig.TabIndex = 73;
			this.btnDatafeedConfig.Text = "Settings";
			this.btnDatafeedConfig.UseVisualStyleBackColor = true;
			this.btnDatafeedConfig.Click += new System.EventHandler(this.btnDatafeedConfig_Click);
			// 
			// panelPolygonDataFeedSetting
			// 
			this.panelPolygonDataFeedSetting.Controls.Add(this.lblPolygonKey);
			this.panelPolygonDataFeedSetting.Controls.Add(this.txtAPIKey);
			this.panelPolygonDataFeedSetting.Location = new System.Drawing.Point(280, 15);
			this.panelPolygonDataFeedSetting.Name = "panelPolygonDataFeedSetting";
			this.panelPolygonDataFeedSetting.Size = new System.Drawing.Size(282, 29);
			this.panelPolygonDataFeedSetting.TabIndex = 72;
			// 
			// lblPolygonKey
			// 
			this.lblPolygonKey.AutoSize = true;
			this.lblPolygonKey.Location = new System.Drawing.Point(10, 10);
			this.lblPolygonKey.Name = "lblPolygonKey";
			this.lblPolygonKey.Size = new System.Drawing.Size(45, 13);
			this.lblPolygonKey.TabIndex = 67;
			this.lblPolygonKey.Text = "API Key";
			// 
			// txtAPIKey
			// 
			this.txtAPIKey.Location = new System.Drawing.Point(57, 5);
			this.txtAPIKey.Name = "txtAPIKey";
			this.txtAPIKey.Size = new System.Drawing.Size(210, 20);
			this.txtAPIKey.TabIndex = 68;
			// 
			// lblSort
			// 
			this.lblSort.AutoSize = true;
			this.lblSort.Location = new System.Drawing.Point(446, 115);
			this.lblSort.Name = "lblSort";
			this.lblSort.Size = new System.Drawing.Size(26, 13);
			this.lblSort.TabIndex = 70;
			this.lblSort.Text = "Sort";
			// 
			// cmbSort
			// 
			this.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSort.FormattingEnabled = true;
			this.cmbSort.Items.AddRange(new object[] {
            "asc",
            "desc"});
			this.cmbSort.Location = new System.Drawing.Point(483, 113);
			this.cmbSort.Name = "cmbSort";
			this.cmbSort.Size = new System.Drawing.Size(79, 21);
			this.cmbSort.TabIndex = 71;
			// 
			// chkRoundVol
			// 
			this.chkRoundVol.AutoSize = true;
			this.chkRoundVol.Location = new System.Drawing.Point(319, 276);
			this.chkRoundVol.Name = "chkRoundVol";
			this.chkRoundVol.Size = new System.Drawing.Size(41, 17);
			this.chkRoundVol.TabIndex = 64;
			this.chkRoundVol.Text = "Vol";
			this.chkRoundVol.UseVisualStyleBackColor = true;
			// 
			// chkRoundClose
			// 
			this.chkRoundClose.AutoSize = true;
			this.chkRoundClose.Location = new System.Drawing.Point(250, 276);
			this.chkRoundClose.Name = "chkRoundClose";
			this.chkRoundClose.Size = new System.Drawing.Size(52, 17);
			this.chkRoundClose.TabIndex = 63;
			this.chkRoundClose.Text = "Close";
			this.chkRoundClose.UseVisualStyleBackColor = true;
			// 
			// lblUnadjusted
			// 
			this.lblUnadjusted.AutoSize = true;
			this.lblUnadjusted.Location = new System.Drawing.Point(259, 116);
			this.lblUnadjusted.Name = "lblUnadjusted";
			this.lblUnadjusted.Size = new System.Drawing.Size(61, 13);
			this.lblUnadjusted.TabIndex = 68;
			this.lblUnadjusted.Text = "Unadjusted";
			// 
			// chkRoundChange
			// 
			this.chkRoundChange.AutoSize = true;
			this.chkRoundChange.Location = new System.Drawing.Point(179, 277);
			this.chkRoundChange.Name = "chkRoundChange";
			this.chkRoundChange.Size = new System.Drawing.Size(63, 17);
			this.chkRoundChange.TabIndex = 62;
			this.chkRoundChange.Text = "Change";
			this.chkRoundChange.UseVisualStyleBackColor = true;
			// 
			// cmbUnadjusted
			// 
			this.cmbUnadjusted.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbUnadjusted.FormattingEnabled = true;
			this.cmbUnadjusted.Items.AddRange(new object[] {
            "False",
            "True"});
			this.cmbUnadjusted.Location = new System.Drawing.Point(330, 112);
			this.cmbUnadjusted.Name = "cmbUnadjusted";
			this.cmbUnadjusted.Size = new System.Drawing.Size(79, 21);
			this.cmbUnadjusted.TabIndex = 69;
			// 
			// txtRounding
			// 
			this.txtRounding.Location = new System.Drawing.Point(105, 277);
			this.txtRounding.Name = "txtRounding";
			this.txtRounding.Size = new System.Drawing.Size(63, 20);
			this.txtRounding.TabIndex = 61;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(24, 280);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(75, 13);
			this.label19.TabIndex = 60;
			this.label19.Text = "Use Rounding";
			// 
			// dtEndDate
			// 
			this.dtEndDate.CustomFormat = "MM/dd/yyyy";
			this.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtEndDate.Location = new System.Drawing.Point(268, 145);
			this.dtEndDate.Name = "dtEndDate";
			this.dtEndDate.Size = new System.Drawing.Size(90, 20);
			this.dtEndDate.TabIndex = 66;
			// 
			// dtStartDate
			// 
			this.dtStartDate.CustomFormat = "MM/dd/yyyy";
			this.dtStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtStartDate.Location = new System.Drawing.Point(139, 145);
			this.dtStartDate.Name = "dtStartDate";
			this.dtStartDate.Size = new System.Drawing.Size(90, 20);
			this.dtStartDate.TabIndex = 65;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(240, 150);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(14, 13);
			this.label6.TabIndex = 63;
			this.label6.Text = "~";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(89, 150);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(30, 13);
			this.label12.TabIndex = 62;
			this.label12.Text = "Date";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(28, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(91, 13);
			this.label8.TabIndex = 59;
			this.label8.Text = "Primary DataFeed";
			// 
			// cmbDataFeedType
			// 
			this.cmbDataFeedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDataFeedType.FormattingEnabled = true;
			this.cmbDataFeedType.Items.AddRange(new object[] {
            "Polygon.IO V2",
            "Alpaca V2",
            "TradeStation",
            "TDAmeritrade",
            "TwelveData",
            "OandaData",
            "Local Base"});
			this.cmbDataFeedType.Location = new System.Drawing.Point(140, 20);
			this.cmbDataFeedType.Name = "cmbDataFeedType";
			this.cmbDataFeedType.Size = new System.Drawing.Size(100, 21);
			this.cmbDataFeedType.TabIndex = 58;
			this.cmbDataFeedType.SelectedIndexChanged += new System.EventHandler(this.cmbDataFeedType_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(240, 182);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(14, 13);
			this.label7.TabIndex = 57;
			this.label7.Text = "~";
			// 
			// cmbTimeFrame
			// 
			this.cmbTimeFrame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTimeFrame.FormattingEnabled = true;
			this.cmbTimeFrame.Items.AddRange(new object[] {
            "1Min",
            "1H",
            "1D"});
			this.cmbTimeFrame.Location = new System.Drawing.Point(140, 79);
			this.cmbTimeFrame.Name = "cmbTimeFrame";
			this.cmbTimeFrame.Size = new System.Drawing.Size(89, 21);
			this.cmbTimeFrame.TabIndex = 56;
			this.cmbTimeFrame.SelectedIndexChanged += new System.EventHandler(this.cmbTimeFrame_SelectedIndexChanged);
			// 
			// txtDelay
			// 
			this.txtDelay.Location = new System.Drawing.Point(483, 49);
			this.txtDelay.Name = "txtDelay";
			this.txtDelay.Size = new System.Drawing.Size(79, 20);
			this.txtDelay.TabIndex = 54;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(415, 54);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(57, 13);
			this.label18.TabIndex = 53;
			this.label18.Text = "Delay(sec)";
			// 
			// chkBackfillUpdate
			// 
			this.chkBackfillUpdate.AutoSize = true;
			this.chkBackfillUpdate.Location = new System.Drawing.Point(175, 247);
			this.chkBackfillUpdate.Name = "chkBackfillUpdate";
			this.chkBackfillUpdate.Size = new System.Drawing.Size(144, 17);
			this.chkBackfillUpdate.TabIndex = 49;
			this.chkBackfillUpdate.Text = "Backfill Update Base File";
			this.chkBackfillUpdate.UseVisualStyleBackColor = true;
			// 
			// chkCalendarAutoStart
			// 
			this.chkCalendarAutoStart.AutoSize = true;
			this.chkCalendarAutoStart.Location = new System.Drawing.Point(20, 246);
			this.chkCalendarAutoStart.Name = "chkCalendarAutoStart";
			this.chkCalendarAutoStart.Size = new System.Drawing.Size(133, 17);
			this.chkCalendarAutoStart.TabIndex = 46;
			this.chkCalendarAutoStart.Text = "Auto Start By Calendar";
			this.chkCalendarAutoStart.UseVisualStyleBackColor = true;
			this.chkCalendarAutoStart.CheckedChanged += new System.EventHandler(this.chkCalendarAutoStart_CheckedChanged);
			// 
			// radioCO
			// 
			this.radioCO.AutoCheck = false;
			this.radioCO.AutoSize = true;
			this.radioCO.Location = new System.Drawing.Point(374, 213);
			this.radioCO.Name = "radioCO";
			this.radioCO.Size = new System.Drawing.Size(101, 17);
			this.radioCO.TabIndex = 44;
			this.radioCO.Text = "C > O OR C < O";
			this.radioCO.UseVisualStyleBackColor = true;
			this.radioCO.Click += new System.EventHandler(this.radioHL_Click);
			// 
			// radioHL
			// 
			this.radioHL.AutoCheck = false;
			this.radioHL.AutoSize = true;
			this.radioHL.Location = new System.Drawing.Point(319, 213);
			this.radioHL.Name = "radioHL";
			this.radioHL.Size = new System.Drawing.Size(39, 17);
			this.radioHL.TabIndex = 33;
			this.radioHL.Text = "HL";
			this.radioHL.UseVisualStyleBackColor = true;
			this.radioHL.Click += new System.EventHandler(this.radioHL_Click);
			// 
			// radioOHLC
			// 
			this.radioOHLC.AutoCheck = false;
			this.radioOHLC.AutoSize = true;
			this.radioOHLC.Location = new System.Drawing.Point(250, 215);
			this.radioOHLC.Name = "radioOHLC";
			this.radioOHLC.Size = new System.Drawing.Size(54, 17);
			this.radioOHLC.TabIndex = 32;
			this.radioOHLC.Text = "OHLC";
			this.radioOHLC.UseVisualStyleBackColor = true;
			this.radioOHLC.Click += new System.EventHandler(this.radioHL_Click);
			// 
			// radioHLC
			// 
			this.radioHLC.AutoCheck = false;
			this.radioHLC.AutoSize = true;
			this.radioHLC.Location = new System.Drawing.Point(175, 215);
			this.radioHLC.Name = "radioHLC";
			this.radioHLC.Size = new System.Drawing.Size(46, 17);
			this.radioHLC.TabIndex = 31;
			this.radioHLC.Text = "HLC";
			this.radioHLC.UseVisualStyleBackColor = true;
			this.radioHLC.Click += new System.EventHandler(this.radioHL_Click);
			// 
			// chkCloseBarUpdate
			// 
			this.chkCloseBarUpdate.AutoSize = true;
			this.chkCloseBarUpdate.Location = new System.Drawing.Point(20, 215);
			this.chkCloseBarUpdate.Name = "chkCloseBarUpdate";
			this.chkCloseBarUpdate.Size = new System.Drawing.Size(103, 17);
			this.chkCloseBarUpdate.TabIndex = 40;
			this.chkCloseBarUpdate.Text = "CloseBarUpdate";
			this.chkCloseBarUpdate.UseVisualStyleBackColor = true;
			this.chkCloseBarUpdate.CheckedChanged += new System.EventHandler(this.chkCloseBarUpdate_CheckedChanged);
			// 
			// chkAppendData
			// 
			this.chkAppendData.AutoSize = true;
			this.chkAppendData.Location = new System.Drawing.Point(310, 52);
			this.chkAppendData.Name = "chkAppendData";
			this.chkAppendData.Size = new System.Drawing.Size(89, 17);
			this.chkAppendData.TabIndex = 39;
			this.chkAppendData.Text = "Append Data";
			this.chkAppendData.UseVisualStyleBackColor = true;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(51, 183);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(68, 13);
			this.label10.TabIndex = 33;
			this.label10.Text = "MarketHours";
			// 
			// radioProcessAuto
			// 
			this.radioProcessAuto.AutoCheck = false;
			this.radioProcessAuto.AutoSize = true;
			this.radioProcessAuto.Location = new System.Drawing.Point(212, 52);
			this.radioProcessAuto.Name = "radioProcessAuto";
			this.radioProcessAuto.Size = new System.Drawing.Size(85, 17);
			this.radioProcessAuto.TabIndex = 32;
			this.radioProcessAuto.Text = "Auto Update";
			this.radioProcessAuto.UseVisualStyleBackColor = true;
			this.radioProcessAuto.CheckedChanged += new System.EventHandler(this.radioProcessAuto_CheckedChanged);
			this.radioProcessAuto.Click += new System.EventHandler(this.radioProcessStatic_Click);
			// 
			// radioProcessStatic
			// 
			this.radioProcessStatic.AutoCheck = false;
			this.radioProcessStatic.AutoSize = true;
			this.radioProcessStatic.Checked = true;
			this.radioProcessStatic.Location = new System.Drawing.Point(140, 53);
			this.radioProcessStatic.Name = "radioProcessStatic";
			this.radioProcessStatic.Size = new System.Drawing.Size(52, 17);
			this.radioProcessStatic.TabIndex = 31;
			this.radioProcessStatic.TabStop = true;
			this.radioProcessStatic.Text = "Static";
			this.radioProcessStatic.UseVisualStyleBackColor = true;
			this.radioProcessStatic.CheckedChanged += new System.EventHandler(this.radioProcessStatic_CheckedChanged);
			this.radioProcessStatic.Click += new System.EventHandler(this.radioProcessStatic_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(50, 54);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(72, 13);
			this.label9.TabIndex = 30;
			this.label9.Text = "Process Type";
			// 
			// chkMarketHoursOnly
			// 
			this.chkMarketHoursOnly.AutoSize = true;
			this.chkMarketHoursOnly.Location = new System.Drawing.Point(419, 181);
			this.chkMarketHoursOnly.Name = "chkMarketHoursOnly";
			this.chkMarketHoursOnly.Size = new System.Drawing.Size(137, 17);
			this.chkMarketHoursOnly.TabIndex = 27;
			this.chkMarketHoursOnly.Text = "MarketHours Data Only";
			this.chkMarketHoursOnly.UseVisualStyleBackColor = true;
			this.chkMarketHoursOnly.CheckedChanged += new System.EventHandler(this.chkMarketHoursOnly_CheckedChanged);
			// 
			// dateTimeEnd
			// 
			this.dateTimeEnd.CustomFormat = "hh:mm tt";
			this.dateTimeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimeEnd.Location = new System.Drawing.Point(268, 178);
			this.dateTimeEnd.Name = "dateTimeEnd";
			this.dateTimeEnd.ShowUpDown = true;
			this.dateTimeEnd.Size = new System.Drawing.Size(90, 20);
			this.dateTimeEnd.TabIndex = 26;
			this.dateTimeEnd.Value = new System.DateTime(2020, 6, 2, 16, 0, 0, 0);
			// 
			// dateTimeStart
			// 
			this.dateTimeStart.CustomFormat = "hh:mm tt";
			this.dateTimeStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimeStart.Location = new System.Drawing.Point(139, 179);
			this.dateTimeStart.Name = "dateTimeStart";
			this.dateTimeStart.ShowUpDown = true;
			this.dateTimeStart.Size = new System.Drawing.Size(90, 20);
			this.dateTimeStart.TabIndex = 25;
			this.dateTimeStart.Value = new System.DateTime(2020, 6, 2, 9, 30, 0, 0);
			// 
			// txtBars
			// 
			this.txtBars.Location = new System.Drawing.Point(139, 112);
			this.txtBars.Name = "txtBars";
			this.txtBars.Size = new System.Drawing.Size(90, 20);
			this.txtBars.TabIndex = 23;
			// 
			// lblBarLimit
			// 
			this.lblBarLimit.AutoSize = true;
			this.lblBarLimit.Location = new System.Drawing.Point(29, 115);
			this.lblBarLimit.Name = "lblBarLimit";
			this.lblBarLimit.Size = new System.Drawing.Size(85, 13);
			this.lblBarLimit.TabIndex = 22;
			this.lblBarLimit.Text = "#Bar(1 ~ 50000)";
			// 
			// lblTimeFrame
			// 
			this.lblTimeFrame.AutoSize = true;
			this.lblTimeFrame.Location = new System.Drawing.Point(61, 82);
			this.lblTimeFrame.Name = "lblTimeFrame";
			this.lblTimeFrame.Size = new System.Drawing.Size(59, 13);
			this.lblTimeFrame.TabIndex = 0;
			this.lblTimeFrame.Text = "TimeFrame";
			// 
			// btnBrowseMultiplerFile
			// 
			this.btnBrowseMultiplerFile.Location = new System.Drawing.Point(500, 109);
			this.btnBrowseMultiplerFile.Name = "btnBrowseMultiplerFile";
			this.btnBrowseMultiplerFile.Size = new System.Drawing.Size(27, 22);
			this.btnBrowseMultiplerFile.TabIndex = 81;
			this.btnBrowseMultiplerFile.Text = "...";
			this.btnBrowseMultiplerFile.UseVisualStyleBackColor = true;
			this.btnBrowseMultiplerFile.Click += new System.EventHandler(this.btnBrowseMultiplerFile_Click);
			// 
			// txtMultiplierFile
			// 
			this.txtMultiplierFile.Location = new System.Drawing.Point(190, 111);
			this.txtMultiplierFile.Name = "txtMultiplierFile";
			this.txtMultiplierFile.Size = new System.Drawing.Size(310, 20);
			this.txtMultiplierFile.TabIndex = 66;
			// 
			// lblMultiplier
			// 
			this.lblMultiplier.AutoSize = true;
			this.lblMultiplier.Location = new System.Drawing.Point(93, 113);
			this.lblMultiplier.Name = "lblMultiplier";
			this.lblMultiplier.Size = new System.Drawing.Size(67, 13);
			this.lblMultiplier.TabIndex = 67;
			this.lblMultiplier.Text = "Multiplier File";
			// 
			// statusStrip1
			// 
			this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProcessStatus,
            this.statusProgressBar});
			this.statusStrip1.Location = new System.Drawing.Point(0, 709);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(592, 22);
			this.statusStrip1.SizingGrip = false;
			this.statusStrip1.TabIndex = 51;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// lblProcessStatus
			// 
			this.lblProcessStatus.Name = "lblProcessStatus";
			this.lblProcessStatus.Size = new System.Drawing.Size(577, 17);
			this.lblProcessStatus.Spring = true;
			// 
			// statusProgressBar
			// 
			this.statusProgressBar.Name = "statusProgressBar";
			this.statusProgressBar.Size = new System.Drawing.Size(350, 16);
			this.statusProgressBar.Visible = false;
			// 
			// groupGeneral
			// 
			this.groupGeneral.Controls.Add(this.dtBuildHistoryEndDate);
			this.groupGeneral.Controls.Add(this.label4);
			this.groupGeneral.Controls.Add(this.chkAutoBuildEOD);
			this.groupGeneral.Controls.Add(this.chkCalTodayOnly);
			this.groupGeneral.Controls.Add(this.chkDontCalVol);
			this.groupGeneral.Controls.Add(this.button1);
			this.groupGeneral.Controls.Add(this.txtMultiplierSchedule);
			this.groupGeneral.Controls.Add(this.label3);
			this.groupGeneral.Controls.Add(this.btnBrowseMultiplerFile);
			this.groupGeneral.Controls.Add(this.label13);
			this.groupGeneral.Controls.Add(this.btnBrowseSymbolListFile);
			this.groupGeneral.Controls.Add(this.txtSymbolListFile);
			this.groupGeneral.Controls.Add(this.label2);
			this.groupGeneral.Controls.Add(this.btnBrowseOutputFolder);
			this.groupGeneral.Controls.Add(this.txtOutputFolder);
			this.groupGeneral.Controls.Add(this.label1);
			this.groupGeneral.Controls.Add(this.btnBrowseInputFolder);
			this.groupGeneral.Controls.Add(this.txtInputFolder);
			this.groupGeneral.Controls.Add(this.txtMultiplierFile);
			this.groupGeneral.Controls.Add(this.lblMultiplier);
			this.groupGeneral.Location = new System.Drawing.Point(9, 8);
			this.groupGeneral.Name = "groupGeneral";
			this.groupGeneral.Size = new System.Drawing.Size(574, 262);
			this.groupGeneral.TabIndex = 55;
			this.groupGeneral.TabStop = false;
			this.groupGeneral.Text = "General Settings";
			// 
			// dtBuildHistoryEndDate
			// 
			this.dtBuildHistoryEndDate.CustomFormat = "MM/dd/yyyy";
			this.dtBuildHistoryEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtBuildHistoryEndDate.Location = new System.Drawing.Point(188, 215);
			this.dtBuildHistoryEndDate.Name = "dtBuildHistoryEndDate";
			this.dtBuildHistoryEndDate.Size = new System.Drawing.Size(90, 20);
			this.dtBuildHistoryEndDate.TabIndex = 105;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 220);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(131, 13);
			this.label4.TabIndex = 104;
			this.label4.Text = "Build the History End Date";
			// 
			// chkAutoBuildEOD
			// 
			this.chkAutoBuildEOD.AutoSize = true;
			this.chkAutoBuildEOD.Location = new System.Drawing.Point(343, 184);
			this.chkAutoBuildEOD.Name = "chkAutoBuildEOD";
			this.chkAutoBuildEOD.Size = new System.Drawing.Size(153, 17);
			this.chkAutoBuildEOD.TabIndex = 103;
			this.chkAutoBuildEOD.Text = "Auto Build the History EOD";
			this.chkAutoBuildEOD.UseVisualStyleBackColor = true;
			// 
			// chkCalTodayOnly
			// 
			this.chkCalTodayOnly.AutoSize = true;
			this.chkCalTodayOnly.Location = new System.Drawing.Point(188, 184);
			this.chkCalTodayOnly.Name = "chkCalTodayOnly";
			this.chkCalTodayOnly.Size = new System.Drawing.Size(132, 17);
			this.chkCalTodayOnly.TabIndex = 102;
			this.chkCalTodayOnly.Text = "Build Today\'s Bar Only";
			this.chkCalTodayOnly.UseVisualStyleBackColor = true;
			// 
			// chkDontCalVol
			// 
			this.chkDontCalVol.AutoSize = true;
			this.chkDontCalVol.Location = new System.Drawing.Point(43, 184);
			this.chkDontCalVol.Name = "chkDontCalVol";
			this.chkDontCalVol.Size = new System.Drawing.Size(116, 17);
			this.chkDontCalVol.TabIndex = 101;
			this.chkDontCalVol.Text = "Don\'t Calculate Vol";
			this.chkDontCalVol.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(500, 141);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(27, 22);
			this.button1.TabIndex = 100;
			this.button1.Text = "...";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtMultiplierSchedule
			// 
			this.txtMultiplierSchedule.Location = new System.Drawing.Point(190, 142);
			this.txtMultiplierSchedule.Name = "txtMultiplierSchedule";
			this.txtMultiplierSchedule.Size = new System.Drawing.Size(310, 20);
			this.txtMultiplierSchedule.TabIndex = 98;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(45, 145);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 13);
			this.label3.TabIndex = 99;
			this.label3.Text = "Multiplier Schedule File";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(81, 82);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(79, 13);
			this.label13.TabIndex = 97;
			this.label13.Text = "Symbol List File";
			// 
			// btnBrowseSymbolListFile
			// 
			this.btnBrowseSymbolListFile.Location = new System.Drawing.Point(500, 77);
			this.btnBrowseSymbolListFile.Name = "btnBrowseSymbolListFile";
			this.btnBrowseSymbolListFile.Size = new System.Drawing.Size(27, 22);
			this.btnBrowseSymbolListFile.TabIndex = 96;
			this.btnBrowseSymbolListFile.Text = "...";
			this.btnBrowseSymbolListFile.UseVisualStyleBackColor = true;
			this.btnBrowseSymbolListFile.Click += new System.EventHandler(this.btnBrowseSymbolListFile_Click);
			// 
			// txtSymbolListFile
			// 
			this.txtSymbolListFile.Location = new System.Drawing.Point(190, 78);
			this.txtSymbolListFile.Name = "txtSymbolListFile";
			this.txtSymbolListFile.Size = new System.Drawing.Size(310, 20);
			this.txtSymbolListFile.TabIndex = 95;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(89, 50);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 13);
			this.label2.TabIndex = 85;
			this.label2.Text = "Output Folder";
			// 
			// btnBrowseOutputFolder
			// 
			this.btnBrowseOutputFolder.Location = new System.Drawing.Point(500, 46);
			this.btnBrowseOutputFolder.Name = "btnBrowseOutputFolder";
			this.btnBrowseOutputFolder.Size = new System.Drawing.Size(27, 22);
			this.btnBrowseOutputFolder.TabIndex = 84;
			this.btnBrowseOutputFolder.Text = "...";
			this.btnBrowseOutputFolder.UseVisualStyleBackColor = true;
			this.btnBrowseOutputFolder.Click += new System.EventHandler(this.btnBrowseOutputFolder_Click);
			// 
			// txtOutputFolder
			// 
			this.txtOutputFolder.Location = new System.Drawing.Point(190, 46);
			this.txtOutputFolder.Name = "txtOutputFolder";
			this.txtOutputFolder.Size = new System.Drawing.Size(310, 20);
			this.txtOutputFolder.TabIndex = 83;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(51, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 13);
			this.label1.TabIndex = 82;
			this.label1.Text = "Input Base File Folder";
			// 
			// btnBrowseInputFolder
			// 
			this.btnBrowseInputFolder.Location = new System.Drawing.Point(500, 16);
			this.btnBrowseInputFolder.Name = "btnBrowseInputFolder";
			this.btnBrowseInputFolder.Size = new System.Drawing.Size(27, 22);
			this.btnBrowseInputFolder.TabIndex = 81;
			this.btnBrowseInputFolder.Text = "...";
			this.btnBrowseInputFolder.UseVisualStyleBackColor = true;
			this.btnBrowseInputFolder.Click += new System.EventHandler(this.btnBrowseInputFolder_Click);
			// 
			// txtInputFolder
			// 
			this.txtInputFolder.Location = new System.Drawing.Point(190, 17);
			this.txtInputFolder.Name = "txtInputFolder";
			this.txtInputFolder.Size = new System.Drawing.Size(310, 20);
			this.txtInputFolder.TabIndex = 80;
			// 
			// btnZeroMQ
			// 
			this.btnZeroMQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.btnZeroMQ.Location = new System.Drawing.Point(205, 631);
			this.btnZeroMQ.Name = "btnZeroMQ";
			this.btnZeroMQ.Size = new System.Drawing.Size(182, 31);
			this.btnZeroMQ.TabIndex = 59;
			this.btnZeroMQ.Text = "NetMQ";
			this.btnZeroMQ.UseVisualStyleBackColor = true;
			this.btnZeroMQ.Click += new System.EventHandler(this.btnZeroMQ_Click);
			// 
			// btnBuildHistory
			// 
			this.btnBuildHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.btnBuildHistory.Location = new System.Drawing.Point(205, 597);
			this.btnBuildHistory.Name = "btnBuildHistory";
			this.btnBuildHistory.Size = new System.Drawing.Size(182, 31);
			this.btnBuildHistory.TabIndex = 60;
			this.btnBuildHistory.Text = "Build the History";
			this.btnBuildHistory.UseVisualStyleBackColor = true;
			this.btnBuildHistory.Click += new System.EventHandler(this.btnBuildHistory_Click);
			// 
			// btnAWSSetting
			// 
			this.btnAWSSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.btnAWSSetting.Location = new System.Drawing.Point(395, 597);
			this.btnAWSSetting.Name = "btnAWSSetting";
			this.btnAWSSetting.Size = new System.Drawing.Size(181, 31);
			this.btnAWSSetting.TabIndex = 61;
			this.btnAWSSetting.Text = "AWS S3 Upload";
			this.btnAWSSetting.UseVisualStyleBackColor = true;
			this.btnAWSSetting.Click += new System.EventHandler(this.btnAWSSetting_Click);
			// 
			// btnMinBaseCheck
			// 
			this.btnMinBaseCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.btnMinBaseCheck.Location = new System.Drawing.Point(14, 631);
			this.btnMinBaseCheck.Name = "btnMinBaseCheck";
			this.btnMinBaseCheck.Size = new System.Drawing.Size(182, 31);
			this.btnMinBaseCheck.TabIndex = 62;
			this.btnMinBaseCheck.Text = "Min Base Data Check";
			this.btnMinBaseCheck.UseVisualStyleBackColor = true;
			this.btnMinBaseCheck.Click += new System.EventHandler(this.btnMinBaseCheck_Click);
			// 
			// btnDataCleanup
			// 
			this.btnDataCleanup.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
			this.btnDataCleanup.Location = new System.Drawing.Point(395, 631);
			this.btnDataCleanup.Name = "btnDataCleanup";
			this.btnDataCleanup.Size = new System.Drawing.Size(181, 31);
			this.btnDataCleanup.TabIndex = 63;
			this.btnDataCleanup.Text = "Data Cleanup";
			this.btnDataCleanup.UseVisualStyleBackColor = true;
			this.btnDataCleanup.Click += new System.EventHandler(this.btnDataCleanup_Click);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(592, 731);
			this.Controls.Add(this.btnDataCleanup);
			this.Controls.Add(this.btnMinBaseCheck);
			this.Controls.Add(this.btnAWSSetting);
			this.Controls.Add(this.btnBuildHistory);
			this.Controls.Add(this.btnZeroMQ);
			this.Controls.Add(this.groupGeneral);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.groupDataType);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnStart);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "SriOHLCBuilder V3.5.3";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
			this.Load += new System.EventHandler(this.FrmMain_Load);
			this.groupDataType.ResumeLayout(false);
			this.groupDataType.PerformLayout();
			this.panelLocalData.ResumeLayout(false);
			this.panelLocalData.PerformLayout();
			this.panelPolygonDataFeedSetting.ResumeLayout(false);
			this.panelPolygonDataFeedSetting.PerformLayout();
			this.statusStrip1.ResumeLayout(false);
			this.statusStrip1.PerformLayout();
			this.groupGeneral.ResumeLayout(false);
			this.groupGeneral.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.Timer timerUpdate;
		private System.Windows.Forms.GroupBox groupDataType;
		private System.Windows.Forms.Label lblTimeFrame;
		private System.Windows.Forms.TextBox txtBars;
		private System.Windows.Forms.Label lblBarLimit;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripStatusLabel lblProcessStatus;
		private System.Windows.Forms.ToolStripProgressBar statusProgressBar;
		private System.Windows.Forms.CheckBox chkMarketHoursOnly;
		private System.Windows.Forms.DateTimePicker dateTimeEnd;
		private System.Windows.Forms.DateTimePicker dateTimeStart;
		private System.Windows.Forms.RadioButton radioProcessAuto;
		private System.Windows.Forms.RadioButton radioProcessStatic;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.CheckBox chkAppendData;
		private System.Windows.Forms.RadioButton radioCO;
		private System.Windows.Forms.RadioButton radioHL;
		private System.Windows.Forms.RadioButton radioOHLC;
		private System.Windows.Forms.RadioButton radioHLC;
		private System.Windows.Forms.CheckBox chkCloseBarUpdate;
		private System.Windows.Forms.CheckBox chkBackfillUpdate;
		private System.Windows.Forms.TextBox txtDelay;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox txtRounding;
		private System.Windows.Forms.CheckBox chkRoundChange;
		private System.Windows.Forms.CheckBox chkRoundClose;
		private System.Windows.Forms.CheckBox chkRoundVol;
		private System.Windows.Forms.CheckBox chkCalendarAutoStart;
		private System.Windows.Forms.ComboBox cmbTimeFrame;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cmbDataFeedType;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.DateTimePicker dtEndDate;
		private System.Windows.Forms.DateTimePicker dtStartDate;
		private System.Windows.Forms.Label lblMultiplier;
		private System.Windows.Forms.TextBox txtMultiplierFile;
		private System.Windows.Forms.Label lblUnadjusted;
		private System.Windows.Forms.ComboBox cmbUnadjusted;
		private System.Windows.Forms.Label lblSort;
		private System.Windows.Forms.ComboBox cmbSort;
		private System.Windows.Forms.Panel panelPolygonDataFeedSetting;
		private System.Windows.Forms.Label lblPolygonKey;
		private System.Windows.Forms.TextBox txtAPIKey;
		private System.Windows.Forms.GroupBox groupGeneral;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnBrowseOutputFolder;
		private System.Windows.Forms.TextBox txtOutputFolder;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnBrowseInputFolder;
		private System.Windows.Forms.TextBox txtInputFolder;
		private System.Windows.Forms.Button btnBrowseMultiplerFile;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btnBrowseSymbolListFile;
		private System.Windows.Forms.TextBox txtSymbolListFile;
		private System.Windows.Forms.Button btnZeroMQ;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtMultiplierSchedule;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnDatafeedConfig;
		private System.Windows.Forms.CheckBox chkDontCalVol;
		private System.Windows.Forms.CheckBox chkCalTodayOnly;
		private System.Windows.Forms.CheckBox chkAutoBuildEOD;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtBuildHistoryEndDate;
		private System.Windows.Forms.Button btnBuildHistory;
		private System.Windows.Forms.Button btnAWSSetting;
		private System.Windows.Forms.Button btnMinBaseCheck;
		private System.Windows.Forms.CheckBox chkUseCloseTimestamp;
		private System.Windows.Forms.CheckBox chkLastTimestampException;
		private System.Windows.Forms.Panel panelLocalData;
		private System.Windows.Forms.Button btnBrowseLocalDataFolder;
		private System.Windows.Forms.TextBox txtLocalDataFolder;
		private System.Windows.Forms.Button btnDataCleanup;
	}
}

