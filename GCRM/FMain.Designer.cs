namespace GCRM
{
	partial class FMain
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FMain));
            statusStrip1 = new StatusStrip();
            LToolStripUsername = new ToolStripStatusLabel();
            LToolStripServer = new ToolStripStatusLabel();
            LToolstripVersion = new ToolStripStatusLabel();
            toolStrip1 = new ToolStrip();
            BCitizens = new ToolStripButton();
            ToolStripSeparator4 = new ToolStripSeparator();
            BCitizenGroups = new ToolStripButton();
            BRelationships = new ToolStripButton();
            ToolStripSeparator2 = new ToolStripSeparator();
            BInstitutions = new ToolStripButton();
            ToolStripSeparator7 = new ToolStripSeparator();
            BReportList = new ToolStripButton();
            TabControl = new TabControl();
            TabPageCatalogs = new TabPage();
            TabElectoral = new TabPage();
            toolStrip3 = new ToolStrip();
            BCitizenNetworks = new ToolStripButton();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripButton1 = new ToolStripButton();
            TabOthers = new TabPage();
            ToolStripOther = new ToolStrip();
            BSettings = new ToolStripButton();
            BUsers = new ToolStripButton();
            BUserGroups = new ToolStripButton();
            BConnection = new ToolStripButton();
            BAbout = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            BEmails = new ToolStripButton();
            BSync = new ToolStripButton();
            toolStripSeparator5 = new ToolStripSeparator();
            BQueries = new ToolStripButton();
            BEventLog = new ToolStripButton();
            toolStripSeparator8 = new ToolStripSeparator();
            BFixDuplicates = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            BBackup = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            ListBoxBirhdays = new ListBox();
            LBirthdayList = new Label();
            PictureBoxBirthdayList = new PictureBox();
            BackgroundImage = new PictureBox();
            BirthdayPanel = new Panel();
            BirthdayPanelContent = new Panel();
            BirthdayPanelTopBar = new Panel();
            NotificationsPanel = new Panel();
            WarningPanel = new Panel();
            WarningPanelContent = new Panel();
            ListBoxWarnings = new ListBox();
            WarningPanelTopBar = new Panel();
            label1 = new Label();
            PictureBoxWarning = new PictureBox();
            statusStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            TabControl.SuspendLayout();
            TabPageCatalogs.SuspendLayout();
            TabElectoral.SuspendLayout();
            toolStrip3.SuspendLayout();
            TabOthers.SuspendLayout();
            ToolStripOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxBirthdayList).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BackgroundImage).BeginInit();
            BirthdayPanel.SuspendLayout();
            BirthdayPanelContent.SuspendLayout();
            BirthdayPanelTopBar.SuspendLayout();
            NotificationsPanel.SuspendLayout();
            WarningPanel.SuspendLayout();
            WarningPanelContent.SuspendLayout();
            WarningPanelTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxWarning).BeginInit();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { LToolStripUsername, LToolStripServer, LToolstripVersion });
            statusStrip1.Location = new Point(0, 526);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Padding = new Padding(1, 0, 16, 0);
            statusStrip1.Size = new Size(915, 25);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // LToolStripUsername
            // 
            LToolStripUsername.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LToolStripUsername.Name = "LToolStripUsername";
            LToolStripUsername.Size = new Size(299, 19);
            LToolStripUsername.Spring = true;
            LToolStripUsername.Text = "Usuario: ausuario - agroup";
            LToolStripUsername.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LToolStripServer
            // 
            LToolStripServer.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LToolStripServer.Name = "LToolStripServer";
            LToolStripServer.Size = new Size(299, 19);
            LToolStripServer.Spring = true;
            LToolStripServer.Text = "Server - tcp://localhost:8095";
            LToolStripServer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // LToolstripVersion
            // 
            LToolstripVersion.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LToolstripVersion.ForeColor = SystemColors.InfoText;
            LToolstripVersion.Name = "LToolstripVersion";
            LToolstripVersion.Size = new Size(299, 19);
            LToolstripVersion.Spring = true;
            LToolstripVersion.Text = "Versión - 0.0.0.1 - alpha";
            LToolstripVersion.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = DockStyle.Fill;
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { BCitizens, ToolStripSeparator4, BCitizenGroups, BRelationships, ToolStripSeparator2, BInstitutions, ToolStripSeparator7, BReportList });
            toolStrip1.Location = new Point(3, 4);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(901, 78);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "ToolStripCatalogos";
            // 
            // BCitizens
            // 
            BCitizens.Image = Properties.Resources.Fatcow_Farm_Fresh_User_32;
            BCitizens.ImageScaling = ToolStripItemImageScaling.None;
            BCitizens.ImageTransparentColor = Color.Magenta;
            BCitizens.Name = "BCitizens";
            BCitizens.Size = new Size(91, 75);
            BCitizens.Text = "&Ciudadanos";
            BCitizens.TextImageRelation = TextImageRelation.ImageAboveText;
            BCitizens.Click += BCitizens_Click;
            // 
            // ToolStripSeparator4
            // 
            ToolStripSeparator4.Name = "ToolStripSeparator4";
            ToolStripSeparator4.Size = new Size(6, 78);
            // 
            // BCitizenGroups
            // 
            BCitizenGroups.Image = Properties.Resources.Fatcow_Farm_Fresh_Users_5_32;
            BCitizenGroups.ImageScaling = ToolStripItemImageScaling.None;
            BCitizenGroups.ImageTransparentColor = Color.Magenta;
            BCitizenGroups.Name = "BCitizenGroups";
            BCitizenGroups.Padding = new Padding(10, 0, 10, 0);
            BCitizenGroups.Size = new Size(80, 75);
            BCitizenGroups.Text = "&Grupos";
            BCitizenGroups.TextImageRelation = TextImageRelation.ImageAboveText;
            BCitizenGroups.Visible = false;
            BCitizenGroups.Click += BCitizenGroups_Click;
            // 
            // BRelationships
            // 
            BRelationships.Image = Properties.Resources.Fatcow_Farm_Fresh_Group_link_32;
            BRelationships.ImageScaling = ToolStripItemImageScaling.None;
            BRelationships.ImageTransparentColor = Color.Magenta;
            BRelationships.Name = "BRelationships";
            BRelationships.Padding = new Padding(5, 0, 5, 0);
            BRelationships.Size = new Size(94, 75);
            BRelationships.Text = "&Relaciones";
            BRelationships.TextImageRelation = TextImageRelation.ImageAboveText;
            BRelationships.Click += BRelationships_Click;
            // 
            // ToolStripSeparator2
            // 
            ToolStripSeparator2.Name = "ToolStripSeparator2";
            ToolStripSeparator2.Size = new Size(6, 78);
            // 
            // BInstitutions
            // 
            BInstitutions.Image = Properties.Resources.Fatcow_Farm_Fresh_Entity_32;
            BInstitutions.ImageScaling = ToolStripItemImageScaling.None;
            BInstitutions.ImageTransparentColor = Color.Magenta;
            BInstitutions.Name = "BInstitutions";
            BInstitutions.Size = new Size(95, 75);
            BInstitutions.Text = "&Instituciones";
            BInstitutions.TextImageRelation = TextImageRelation.ImageAboveText;
            BInstitutions.Click += BInstitutions_Click;
            // 
            // ToolStripSeparator7
            // 
            ToolStripSeparator7.Name = "ToolStripSeparator7";
            ToolStripSeparator7.Size = new Size(6, 78);
            // 
            // BReportList
            // 
            BReportList.Image = Properties.Resources.Fatcow_Farm_Fresh_Report_32;
            BReportList.ImageScaling = ToolStripItemImageScaling.None;
            BReportList.ImageTransparentColor = Color.Magenta;
            BReportList.Name = "BReportList";
            BReportList.Size = new Size(72, 75);
            BReportList.Text = "R&eportes";
            BReportList.TextImageRelation = TextImageRelation.ImageAboveText;
            BReportList.Click += BReportList_Click;
            // 
            // TabControl
            // 
            TabControl.Controls.Add(TabPageCatalogs);
            TabControl.Controls.Add(TabElectoral);
            TabControl.Controls.Add(TabOthers);
            TabControl.Dock = DockStyle.Top;
            TabControl.Location = new Point(0, 0);
            TabControl.Margin = new Padding(3, 4, 3, 4);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(915, 119);
            TabControl.TabIndex = 1;
            // 
            // TabPageCatalogs
            // 
            TabPageCatalogs.Controls.Add(toolStrip1);
            TabPageCatalogs.Location = new Point(4, 29);
            TabPageCatalogs.Margin = new Padding(3, 4, 3, 4);
            TabPageCatalogs.Name = "TabPageCatalogs";
            TabPageCatalogs.Padding = new Padding(3, 4, 3, 4);
            TabPageCatalogs.Size = new Size(907, 86);
            TabPageCatalogs.TabIndex = 0;
            TabPageCatalogs.Text = "General";
            TabPageCatalogs.UseVisualStyleBackColor = true;
            // 
            // TabElectoral
            // 
            TabElectoral.Controls.Add(toolStrip3);
            TabElectoral.Location = new Point(4, 29);
            TabElectoral.Margin = new Padding(3, 4, 3, 4);
            TabElectoral.Name = "TabElectoral";
            TabElectoral.Padding = new Padding(3, 4, 3, 4);
            TabElectoral.Size = new Size(907, 86);
            TabElectoral.TabIndex = 2;
            TabElectoral.Text = "Electoral";
            TabElectoral.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            toolStrip3.Dock = DockStyle.Fill;
            toolStrip3.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip3.ImageScalingSize = new Size(20, 20);
            toolStrip3.Items.AddRange(new ToolStripItem[] { BCitizenNetworks, toolStripSeparator3, toolStripButton1 });
            toolStrip3.Location = new Point(3, 4);
            toolStrip3.Name = "toolStrip3";
            toolStrip3.RenderMode = ToolStripRenderMode.System;
            toolStrip3.Size = new Size(901, 78);
            toolStrip3.TabIndex = 1;
            toolStrip3.Text = "ToolStripCatalogos";
            // 
            // BCitizenNetworks
            // 
            BCitizenNetworks.Image = Properties.Resources.Fatcow_Farm_Fresh_Chart_organisation_32;
            BCitizenNetworks.ImageScaling = ToolStripItemImageScaling.None;
            BCitizenNetworks.ImageTransparentColor = Color.Magenta;
            BCitizenNetworks.Name = "BCitizenNetworks";
            BCitizenNetworks.Size = new Size(84, 75);
            BCitizenNetworks.Text = "Estructuras";
            BCitizenNetworks.TextImageRelation = TextImageRelation.ImageAboveText;
            BCitizenNetworks.Click += BCitizenNetworks_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 78);
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.Fatcow_Farm_Fresh_Form_design_32;
            toolStripButton1.ImageScaling = ToolStripItemImageScaling.None;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(77, 75);
            toolStripButton1.Text = "&Encuestas";
            toolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton1.Visible = false;
            // 
            // TabOthers
            // 
            TabOthers.Controls.Add(ToolStripOther);
            TabOthers.Location = new Point(4, 29);
            TabOthers.Margin = new Padding(3, 4, 3, 4);
            TabOthers.Name = "TabOthers";
            TabOthers.Padding = new Padding(3, 4, 3, 4);
            TabOthers.Size = new Size(907, 86);
            TabOthers.TabIndex = 1;
            TabOthers.Text = "Otros";
            TabOthers.UseVisualStyleBackColor = true;
            // 
            // ToolStripOther
            // 
            ToolStripOther.Dock = DockStyle.Fill;
            ToolStripOther.GripStyle = ToolStripGripStyle.Hidden;
            ToolStripOther.ImageScalingSize = new Size(20, 20);
            ToolStripOther.Items.AddRange(new ToolStripItem[] { BSettings, BUsers, BUserGroups, BConnection, BAbout, toolStripSeparator1, BEmails, BSync, toolStripSeparator5, BQueries, BEventLog, toolStripSeparator8, BFixDuplicates, toolStripSeparator6, BBackup, toolStripButton2 });
            ToolStripOther.Location = new Point(3, 4);
            ToolStripOther.Name = "ToolStripOther";
            ToolStripOther.RenderMode = ToolStripRenderMode.System;
            ToolStripOther.Size = new Size(901, 78);
            ToolStripOther.TabIndex = 0;
            ToolStripOther.Text = "toolStrip2";
            // 
            // BSettings
            // 
            BSettings.Alignment = ToolStripItemAlignment.Right;
            BSettings.Image = Properties.Resources.Fatcow_Farm_Fresh_Cog_32;
            BSettings.ImageScaling = ToolStripItemImageScaling.None;
            BSettings.ImageTransparentColor = Color.Magenta;
            BSettings.Name = "BSettings";
            BSettings.Size = new Size(60, 75);
            BSettings.Text = "&Ajustes";
            BSettings.TextImageRelation = TextImageRelation.ImageAboveText;
            BSettings.Click += BSettings_Click;
            // 
            // BUsers
            // 
            BUsers.Image = Properties.Resources.Fatcow_Farm_Fresh_User_suit_32;
            BUsers.ImageScaling = ToolStripItemImageScaling.None;
            BUsers.ImageTransparentColor = Color.Magenta;
            BUsers.Margin = new Padding(1, 2, 1, 2);
            BUsers.Name = "BUsers";
            BUsers.Size = new Size(69, 74);
            BUsers.Text = "&Usuarios";
            BUsers.TextImageRelation = TextImageRelation.ImageAboveText;
            BUsers.Click += BUsers_Click;
            // 
            // BUserGroups
            // 
            BUserGroups.Image = Properties.Resources.Fatcow_Farm_Fresh_Reseller_programm_32;
            BUserGroups.ImageScaling = ToolStripItemImageScaling.None;
            BUserGroups.ImageTransparentColor = Color.Magenta;
            BUserGroups.Margin = new Padding(1, 2, 1, 2);
            BUserGroups.Name = "BUserGroups";
            BUserGroups.Size = new Size(60, 74);
            BUserGroups.Text = "&Grupos";
            BUserGroups.TextImageRelation = TextImageRelation.ImageAboveText;
            BUserGroups.Click += BUserGroups_Click;
            // 
            // BConnection
            // 
            BConnection.Alignment = ToolStripItemAlignment.Right;
            BConnection.Image = Properties.Resources.Fatcow_Farm_Fresh_Connect_32;
            BConnection.ImageScaling = ToolStripItemImageScaling.None;
            BConnection.ImageTransparentColor = Color.Magenta;
            BConnection.Margin = new Padding(1, 2, 1, 2);
            BConnection.Name = "BConnection";
            BConnection.Size = new Size(75, 74);
            BConnection.Text = "&Conexión";
            BConnection.TextImageRelation = TextImageRelation.ImageAboveText;
            BConnection.Click += BConnection_Click;
            // 
            // BAbout
            // 
            BAbout.Alignment = ToolStripItemAlignment.Right;
            BAbout.Image = Properties.Resources.Fatcow_Farm_Fresh_Help_32;
            BAbout.ImageScaling = ToolStripItemImageScaling.None;
            BAbout.ImageTransparentColor = Color.Magenta;
            BAbout.Margin = new Padding(1, 2, 1, 2);
            BAbout.Name = "BAbout";
            BAbout.Size = new Size(79, 74);
            BAbout.Text = "&Acerca de";
            BAbout.TextImageRelation = TextImageRelation.ImageAboveText;
            BAbout.ToolTipText = "Acerca de";
            BAbout.Click += BAbout_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Margin = new Padding(1, 2, 1, 2);
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 74);
            // 
            // BEmails
            // 
            BEmails.Image = Properties.Resources.Fatcow_Farm_Fresh_Email_accounts_32;
            BEmails.ImageScaling = ToolStripItemImageScaling.None;
            BEmails.ImageTransparentColor = Color.Magenta;
            BEmails.Margin = new Padding(1, 2, 1, 2);
            BEmails.Name = "BEmails";
            BEmails.Size = new Size(56, 74);
            BEmails.Text = "&Emails";
            BEmails.TextImageRelation = TextImageRelation.ImageAboveText;
            BEmails.Click += BEmails_Click;
            // 
            // BSync
            // 
            BSync.Image = Properties.Resources.Fatcow_Farm_Fresh_Update_contact_info_32;
            BSync.ImageScaling = ToolStripItemImageScaling.None;
            BSync.ImageTransparentColor = Color.Magenta;
            BSync.Margin = new Padding(1, 2, 1, 2);
            BSync.Name = "BSync";
            BSync.Size = new Size(86, 74);
            BSync.Text = "&Sincronizar";
            BSync.TextImageRelation = TextImageRelation.ImageAboveText;
            BSync.Click += BSync_Click;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 78);
            // 
            // BQueries
            // 
            BQueries.Image = Properties.Resources.Fatcow_Farm_Fresh_Query_design_32;
            BQueries.ImageScaling = ToolStripItemImageScaling.None;
            BQueries.ImageTransparentColor = Color.Magenta;
            BQueries.Margin = new Padding(1, 2, 1, 2);
            BQueries.Name = "BQueries";
            BQueries.Size = new Size(76, 74);
            BQueries.Text = "&Consultas";
            BQueries.TextImageRelation = TextImageRelation.ImageAboveText;
            BQueries.Click += BQueries_Click;
            // 
            // BEventLog
            // 
            BEventLog.Image = Properties.Resources.Fatcow_Farm_Fresh_Date_time_functions_32;
            BEventLog.ImageScaling = ToolStripItemImageScaling.None;
            BEventLog.ImageTransparentColor = Color.Magenta;
            BEventLog.Margin = new Padding(1, 2, 1, 2);
            BEventLog.Name = "BEventLog";
            BEventLog.Size = new Size(68, 74);
            BEventLog.Text = "&Bitácora";
            BEventLog.TextImageRelation = TextImageRelation.ImageAboveText;
            BEventLog.Click += BEventLog_Click;
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(6, 78);
            // 
            // BFixDuplicates
            // 
            BFixDuplicates.Image = Properties.Resources.Fatcow_Farm_Fresh_Combine_rows_32;
            BFixDuplicates.ImageScaling = ToolStripItemImageScaling.None;
            BFixDuplicates.ImageTransparentColor = Color.Magenta;
            BFixDuplicates.Margin = new Padding(1, 2, 1, 2);
            BFixDuplicates.Name = "BFixDuplicates";
            BFixDuplicates.Size = new Size(104, 74);
            BFixDuplicates.Text = "B. &Duplicados";
            BFixDuplicates.TextImageRelation = TextImageRelation.ImageAboveText;
            BFixDuplicates.Click += BFixDuplicates_Click;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 78);
            // 
            // BBackup
            // 
            BBackup.Alignment = ToolStripItemAlignment.Right;
            BBackup.Image = Properties.Resources.Fatcow_Farm_Fresh_Database_save_32;
            BBackup.ImageScaling = ToolStripItemImageScaling.None;
            BBackup.ImageTransparentColor = Color.Magenta;
            BBackup.Margin = new Padding(1, 2, 1, 2);
            BBackup.Name = "BBackup";
            BBackup.Size = new Size(79, 74);
            BBackup.Text = "&Respaldar";
            BBackup.TextImageRelation = TextImageRelation.ImageAboveText;
            BBackup.ToolTipText = "Respaldar";
            BBackup.Click += BBackup_Click;
            // 
            // toolStripButton2
            // 
            toolStripButton2.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton2.Image = (Image)resources.GetObject("toolStripButton2.Image");
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(29, 24);
            toolStripButton2.Text = "toolStripButton2";
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // ListBoxBirhdays
            // 
            ListBoxBirhdays.BackColor = SystemColors.GradientInactiveCaption;
            ListBoxBirhdays.BorderStyle = BorderStyle.None;
            ListBoxBirhdays.Dock = DockStyle.Fill;
            ListBoxBirhdays.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ListBoxBirhdays.FormattingEnabled = true;
            ListBoxBirhdays.Location = new Point(6, 7);
            ListBoxBirhdays.Margin = new Padding(6, 27, 6, 7);
            ListBoxBirhdays.Name = "ListBoxBirhdays";
            ListBoxBirhdays.SelectionMode = SelectionMode.None;
            ListBoxBirhdays.Size = new Size(358, 0);
            ListBoxBirhdays.TabIndex = 2;
            // 
            // LBirthdayList
            // 
            LBirthdayList.AutoSize = true;
            LBirthdayList.Dock = DockStyle.Fill;
            LBirthdayList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LBirthdayList.ForeColor = SystemColors.ControlText;
            LBirthdayList.Location = new Point(27, 7);
            LBirthdayList.Name = "LBirthdayList";
            LBirthdayList.Size = new Size(185, 20);
            LBirthdayList.TabIndex = 3;
            LBirthdayList.Text = "Cumpleaños el día de hoy";
            // 
            // PictureBoxBirthdayList
            // 
            PictureBoxBirthdayList.Dock = DockStyle.Left;
            PictureBoxBirthdayList.Image = Properties.Resources.Fatcow_Farm_Fresh_Cake_16;
            PictureBoxBirthdayList.Location = new Point(6, 7);
            PictureBoxBirthdayList.Margin = new Padding(3, 4, 3, 4);
            PictureBoxBirthdayList.Name = "PictureBoxBirthdayList";
            PictureBoxBirthdayList.Size = new Size(21, 20);
            PictureBoxBirthdayList.TabIndex = 4;
            PictureBoxBirthdayList.TabStop = false;
            // 
            // BackgroundImage
            // 
            BackgroundImage.BackColor = Color.Transparent;
            BackgroundImage.Dock = DockStyle.Fill;
            BackgroundImage.Location = new Point(0, 119);
            BackgroundImage.Margin = new Padding(3, 4, 3, 4);
            BackgroundImage.Name = "BackgroundImage";
            BackgroundImage.Size = new Size(915, 407);
            BackgroundImage.SizeMode = PictureBoxSizeMode.CenterImage;
            BackgroundImage.TabIndex = 5;
            BackgroundImage.TabStop = false;
            // 
            // BirthdayPanel
            // 
            BirthdayPanel.AutoSize = true;
            BirthdayPanel.BackColor = SystemColors.GradientInactiveCaption;
            BirthdayPanel.BorderStyle = BorderStyle.FixedSingle;
            BirthdayPanel.Controls.Add(BirthdayPanelContent);
            BirthdayPanel.Controls.Add(BirthdayPanelTopBar);
            BirthdayPanel.Dock = DockStyle.Top;
            BirthdayPanel.Location = new Point(0, 0);
            BirthdayPanel.Margin = new Padding(3, 4, 3, 4);
            BirthdayPanel.Name = "BirthdayPanel";
            BirthdayPanel.Size = new Size(367, 50);
            BirthdayPanel.TabIndex = 6;
            // 
            // BirthdayPanelContent
            // 
            BirthdayPanelContent.AutoSize = true;
            BirthdayPanelContent.Controls.Add(ListBoxBirhdays);
            BirthdayPanelContent.Dock = DockStyle.Fill;
            BirthdayPanelContent.Location = new Point(0, 34);
            BirthdayPanelContent.Margin = new Padding(3, 4, 3, 4);
            BirthdayPanelContent.MinimumSize = new Size(229, 0);
            BirthdayPanelContent.Name = "BirthdayPanelContent";
            BirthdayPanelContent.Padding = new Padding(6, 7, 1, 7);
            BirthdayPanelContent.Size = new Size(365, 14);
            BirthdayPanelContent.TabIndex = 6;
            // 
            // BirthdayPanelTopBar
            // 
            BirthdayPanelTopBar.AutoSize = true;
            BirthdayPanelTopBar.BackColor = SystemColors.InactiveCaption;
            BirthdayPanelTopBar.Controls.Add(LBirthdayList);
            BirthdayPanelTopBar.Controls.Add(PictureBoxBirthdayList);
            BirthdayPanelTopBar.Dock = DockStyle.Top;
            BirthdayPanelTopBar.Location = new Point(0, 0);
            BirthdayPanelTopBar.Margin = new Padding(3, 4, 3, 13);
            BirthdayPanelTopBar.MinimumSize = new Size(229, 0);
            BirthdayPanelTopBar.Name = "BirthdayPanelTopBar";
            BirthdayPanelTopBar.Padding = new Padding(6, 7, 6, 7);
            BirthdayPanelTopBar.Size = new Size(365, 34);
            BirthdayPanelTopBar.TabIndex = 5;
            // 
            // NotificationsPanel
            // 
            NotificationsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            NotificationsPanel.Controls.Add(WarningPanel);
            NotificationsPanel.Controls.Add(BirthdayPanel);
            NotificationsPanel.Location = new Point(8, 127);
            NotificationsPanel.Margin = new Padding(3, 4, 3, 4);
            NotificationsPanel.Name = "NotificationsPanel";
            NotificationsPanel.Size = new Size(367, 387);
            NotificationsPanel.TabIndex = 7;
            // 
            // WarningPanel
            // 
            WarningPanel.AutoSize = true;
            WarningPanel.BorderStyle = BorderStyle.FixedSingle;
            WarningPanel.Controls.Add(WarningPanelContent);
            WarningPanel.Controls.Add(WarningPanelTopBar);
            WarningPanel.Dock = DockStyle.Top;
            WarningPanel.Location = new Point(0, 50);
            WarningPanel.Margin = new Padding(3, 4, 3, 4);
            WarningPanel.Name = "WarningPanel";
            WarningPanel.Size = new Size(367, 50);
            WarningPanel.TabIndex = 7;
            // 
            // WarningPanelContent
            // 
            WarningPanelContent.AutoSize = true;
            WarningPanelContent.BackColor = Color.MistyRose;
            WarningPanelContent.Controls.Add(ListBoxWarnings);
            WarningPanelContent.Dock = DockStyle.Fill;
            WarningPanelContent.Location = new Point(0, 34);
            WarningPanelContent.Margin = new Padding(3, 4, 3, 4);
            WarningPanelContent.MinimumSize = new Size(229, 0);
            WarningPanelContent.Name = "WarningPanelContent";
            WarningPanelContent.Padding = new Padding(6, 7, 1, 7);
            WarningPanelContent.Size = new Size(365, 14);
            WarningPanelContent.TabIndex = 8;
            // 
            // ListBoxWarnings
            // 
            ListBoxWarnings.BackColor = Color.MistyRose;
            ListBoxWarnings.BorderStyle = BorderStyle.None;
            ListBoxWarnings.Dock = DockStyle.Fill;
            ListBoxWarnings.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ListBoxWarnings.FormattingEnabled = true;
            ListBoxWarnings.Location = new Point(6, 7);
            ListBoxWarnings.Margin = new Padding(6, 27, 6, 7);
            ListBoxWarnings.Name = "ListBoxWarnings";
            ListBoxWarnings.SelectionMode = SelectionMode.None;
            ListBoxWarnings.Size = new Size(358, 0);
            ListBoxWarnings.TabIndex = 0;
            // 
            // WarningPanelTopBar
            // 
            WarningPanelTopBar.AutoSize = true;
            WarningPanelTopBar.BackColor = Color.LightCoral;
            WarningPanelTopBar.Controls.Add(label1);
            WarningPanelTopBar.Controls.Add(PictureBoxWarning);
            WarningPanelTopBar.Dock = DockStyle.Top;
            WarningPanelTopBar.Location = new Point(0, 0);
            WarningPanelTopBar.Margin = new Padding(3, 4, 3, 13);
            WarningPanelTopBar.MinimumSize = new Size(229, 0);
            WarningPanelTopBar.Name = "WarningPanelTopBar";
            WarningPanelTopBar.Padding = new Padding(6, 7, 6, 7);
            WarningPanelTopBar.Size = new Size(365, 34);
            WarningPanelTopBar.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 7);
            label1.Name = "label1";
            label1.Size = new Size(360, 20);
            label1.TabIndex = 1;
            label1.Text = "Existen los siguientes problemas con la información";
            // 
            // PictureBoxWarning
            // 
            PictureBoxWarning.Dock = DockStyle.Left;
            PictureBoxWarning.Image = Properties.Resources.Fatcow_Farm_Fresh_Error_16;
            PictureBoxWarning.Location = new Point(6, 7);
            PictureBoxWarning.Margin = new Padding(3, 4, 3, 4);
            PictureBoxWarning.Name = "PictureBoxWarning";
            PictureBoxWarning.Size = new Size(21, 20);
            PictureBoxWarning.TabIndex = 0;
            PictureBoxWarning.TabStop = false;
            // 
            // FMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(915, 551);
            Controls.Add(NotificationsPanel);
            Controls.Add(BackgroundImage);
            Controls.Add(TabControl);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            MinimumSize = new Size(683, 518);
            Name = "FMain";
            Text = "GCRM";
            FormClosing += FMain_FormClosing;
            FormClosed += FMain_FormClosed;
            Load += FMain_Load;
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            TabControl.ResumeLayout(false);
            TabPageCatalogs.ResumeLayout(false);
            TabPageCatalogs.PerformLayout();
            TabElectoral.ResumeLayout(false);
            TabElectoral.PerformLayout();
            toolStrip3.ResumeLayout(false);
            toolStrip3.PerformLayout();
            TabOthers.ResumeLayout(false);
            TabOthers.PerformLayout();
            ToolStripOther.ResumeLayout(false);
            ToolStripOther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxBirthdayList).EndInit();
            ((System.ComponentModel.ISupportInitialize)BackgroundImage).EndInit();
            BirthdayPanel.ResumeLayout(false);
            BirthdayPanel.PerformLayout();
            BirthdayPanelContent.ResumeLayout(false);
            BirthdayPanelTopBar.ResumeLayout(false);
            BirthdayPanelTopBar.PerformLayout();
            NotificationsPanel.ResumeLayout(false);
            NotificationsPanel.PerformLayout();
            WarningPanel.ResumeLayout(false);
            WarningPanel.PerformLayout();
            WarningPanelContent.ResumeLayout(false);
            WarningPanelTopBar.ResumeLayout(false);
            WarningPanelTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBoxWarning).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private StatusStrip statusStrip1;
		private ToolStrip toolStrip1;
		private ToolStripButton BCitizens;
		private ToolStripButton BInstitutions;
		private TabControl TabControl;
		private TabPage TabPageCatalogs;
		private TabPage TabOthers;
		private ToolStrip ToolStripOther;
		private ToolStripButton BSettings;
		private ToolStripSeparator ToolStripSeparator2;
		private ToolStripButton BUsers;
		private ToolStripStatusLabel LToolstripVersion;
		private ToolStripStatusLabel LToolStripServer;
		private ToolStripStatusLabel LToolStripUsername;
		private ToolStripButton BConnection;
		private ListBox ListBoxBirhdays;
		private Label LBirthdayList;
		private PictureBox PictureBoxBirthdayList;
		private ToolStripButton BAbout;
		private TabPage TabElectoral;
		private ToolStrip toolStrip3;
		private ToolStripButton BCitizenNetworks;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton BQueries;
		private ToolStripButton BEventLog;
		private ToolStripButton BSync;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripButton toolStripButton1;
		private ToolStripButton BUserGroups;
		private PictureBox BackgroundImage;
		private Panel BirthdayPanel;
		private Panel BirthdayPanelTopBar;
		private Panel BirthdayPanelContent;
		private ToolStripButton BEmails;
		private ToolStripSeparator ToolStripSeparator4;
		private ToolStripButton BRelationships;
		private ToolStripButton BCitizenGroups;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripButton BBackup;
        private Panel NotificationsPanel;
        private Panel WarningPanel;
        private Panel WarningPanelTopBar;
        private PictureBox PictureBoxWarning;
        private Label label1;
        private Panel WarningPanelContent;
        private ListBox ListBoxWarnings;
        private ToolStripSeparator ToolStripSeparator7;
        private ToolStripButton BReportList;
        private ToolStripButton BFixDuplicates;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripButton toolStripButton2;
    }
}
