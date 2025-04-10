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
			toolStripSeparator2 = new ToolStripSeparator();
			BInstitutions = new ToolStripButton();
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
			ListBoxBirhdays = new ListBox();
			LBirthdayList = new Label();
			PictureBoxBirthdayList = new PictureBox();
			BackgroundImage = new PictureBox();
			BirthdayPanel = new Panel();
			BirthdayPanelContent = new Panel();
			BirthdayPanelTopBar = new Panel();
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
			SuspendLayout();
			// 
			// statusStrip1
			// 
			statusStrip1.Items.AddRange(new ToolStripItem[] { LToolStripUsername, LToolStripServer, LToolstripVersion });
			statusStrip1.Location = new Point(0, 390);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new Size(801, 22);
			statusStrip1.TabIndex = 0;
			statusStrip1.Text = "statusStrip1";
			// 
			// LToolStripUsername
			// 
			LToolStripUsername.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			LToolStripUsername.Name = "LToolStripUsername";
			LToolStripUsername.Size = new Size(262, 17);
			LToolStripUsername.Spring = true;
			LToolStripUsername.Text = "Usuario: ausuario - agroup";
			LToolStripUsername.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// LToolStripServer
			// 
			LToolStripServer.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			LToolStripServer.Name = "LToolStripServer";
			LToolStripServer.Size = new Size(262, 17);
			LToolStripServer.Spring = true;
			LToolStripServer.Text = "Server - tcp://localhost:8095";
			LToolStripServer.TextAlign = ContentAlignment.MiddleRight;
			// 
			// LToolstripVersion
			// 
			LToolstripVersion.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			LToolstripVersion.ForeColor = SystemColors.InfoText;
			LToolstripVersion.Name = "LToolstripVersion";
			LToolstripVersion.Size = new Size(262, 17);
			LToolstripVersion.Spring = true;
			LToolstripVersion.Text = "Versión - 0.0.0.1 - alpha";
			LToolstripVersion.TextAlign = ContentAlignment.MiddleRight;
			// 
			// toolStrip1
			// 
			toolStrip1.Dock = DockStyle.Fill;
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(new ToolStripItem[] { BCitizens, toolStripSeparator2, BInstitutions });
			toolStrip1.Location = new Point(3, 3);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.RenderMode = ToolStripRenderMode.System;
			toolStrip1.Size = new Size(787, 55);
			toolStrip1.TabIndex = 0;
			toolStrip1.Text = "ToolStripCatalogos";
			// 
			// BCitizens
			// 
			BCitizens.Image = Properties.Resources.Fatcow_Farm_Fresh_User_32;
			BCitizens.ImageScaling = ToolStripItemImageScaling.None;
			BCitizens.ImageTransparentColor = Color.Magenta;
			BCitizens.Name = "BCitizens";
			BCitizens.Size = new Size(74, 52);
			BCitizens.Text = "&Ciudadanos";
			BCitizens.TextImageRelation = TextImageRelation.ImageAboveText;
			BCitizens.Click += BCitizens_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 55);
			// 
			// BInstitutions
			// 
			BInstitutions.Image = Properties.Resources.Fatcow_Farm_Fresh_Entity_32;
			BInstitutions.ImageScaling = ToolStripItemImageScaling.None;
			BInstitutions.ImageTransparentColor = Color.Magenta;
			BInstitutions.Name = "BInstitutions";
			BInstitutions.Size = new Size(78, 52);
			BInstitutions.Text = "&Instituciones";
			BInstitutions.TextImageRelation = TextImageRelation.ImageAboveText;
			BInstitutions.Click += BInstitutions_Click;
			// 
			// TabControl
			// 
			TabControl.Controls.Add(TabPageCatalogs);
			TabControl.Controls.Add(TabElectoral);
			TabControl.Controls.Add(TabOthers);
			TabControl.Dock = DockStyle.Top;
			TabControl.Location = new Point(0, 0);
			TabControl.Name = "TabControl";
			TabControl.SelectedIndex = 0;
			TabControl.Size = new Size(801, 89);
			TabControl.TabIndex = 1;
			// 
			// TabPageCatalogs
			// 
			TabPageCatalogs.Controls.Add(toolStrip1);
			TabPageCatalogs.Location = new Point(4, 24);
			TabPageCatalogs.Name = "TabPageCatalogs";
			TabPageCatalogs.Padding = new Padding(3);
			TabPageCatalogs.Size = new Size(793, 61);
			TabPageCatalogs.TabIndex = 0;
			TabPageCatalogs.Text = "Catálogos";
			TabPageCatalogs.UseVisualStyleBackColor = true;
			// 
			// TabElectoral
			// 
			TabElectoral.Controls.Add(toolStrip3);
			TabElectoral.Location = new Point(4, 24);
			TabElectoral.Name = "TabElectoral";
			TabElectoral.Padding = new Padding(3);
			TabElectoral.Size = new Size(793, 61);
			TabElectoral.TabIndex = 2;
			TabElectoral.Text = "Electoral";
			TabElectoral.UseVisualStyleBackColor = true;
			// 
			// toolStrip3
			// 
			toolStrip3.Dock = DockStyle.Fill;
			toolStrip3.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip3.Items.AddRange(new ToolStripItem[] { BCitizenNetworks, toolStripSeparator3, toolStripButton1 });
			toolStrip3.Location = new Point(3, 3);
			toolStrip3.Name = "toolStrip3";
			toolStrip3.RenderMode = ToolStripRenderMode.System;
			toolStrip3.Size = new Size(787, 55);
			toolStrip3.TabIndex = 1;
			toolStrip3.Text = "ToolStripCatalogos";
			// 
			// BCitizenNetworks
			// 
			BCitizenNetworks.Image = Properties.Resources.Fatcow_Farm_Fresh_Chart_organisation_32;
			BCitizenNetworks.ImageScaling = ToolStripItemImageScaling.None;
			BCitizenNetworks.ImageTransparentColor = Color.Magenta;
			BCitizenNetworks.Name = "BCitizenNetworks";
			BCitizenNetworks.Size = new Size(69, 52);
			BCitizenNetworks.Text = "Estructuras";
			BCitizenNetworks.TextImageRelation = TextImageRelation.ImageAboveText;
			BCitizenNetworks.Click += BCitizenNetworks_Click;
			// 
			// toolStripSeparator3
			// 
			toolStripSeparator3.Name = "toolStripSeparator3";
			toolStripSeparator3.Size = new Size(6, 55);
			// 
			// toolStripButton1
			// 
			toolStripButton1.Image = Properties.Resources.Fatcow_Farm_Fresh_Form_design_32;
			toolStripButton1.ImageScaling = ToolStripItemImageScaling.None;
			toolStripButton1.ImageTransparentColor = Color.Magenta;
			toolStripButton1.Name = "toolStripButton1";
			toolStripButton1.Size = new Size(63, 52);
			toolStripButton1.Text = "&Encuestas";
			toolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText;
			toolStripButton1.Visible = false;
			// 
			// TabOthers
			// 
			TabOthers.Controls.Add(ToolStripOther);
			TabOthers.Location = new Point(4, 24);
			TabOthers.Name = "TabOthers";
			TabOthers.Padding = new Padding(3);
			TabOthers.Size = new Size(793, 61);
			TabOthers.TabIndex = 1;
			TabOthers.Text = "Otros";
			TabOthers.UseVisualStyleBackColor = true;
			// 
			// ToolStripOther
			// 
			ToolStripOther.Dock = DockStyle.Fill;
			ToolStripOther.GripStyle = ToolStripGripStyle.Hidden;
			ToolStripOther.Items.AddRange(new ToolStripItem[] { BSettings, BUsers, BUserGroups, BConnection, BAbout, toolStripSeparator1, BEmails, BSync, toolStripSeparator5, BQueries, BEventLog });
			ToolStripOther.Location = new Point(3, 3);
			ToolStripOther.Name = "ToolStripOther";
			ToolStripOther.RenderMode = ToolStripRenderMode.System;
			ToolStripOther.Size = new Size(787, 55);
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
			BSettings.Size = new Size(49, 52);
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
			BUsers.Size = new Size(56, 51);
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
			BUserGroups.Size = new Size(49, 51);
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
			BConnection.Size = new Size(61, 51);
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
			BAbout.Size = new Size(63, 51);
			BAbout.Text = "&Acerca de";
			BAbout.TextImageRelation = TextImageRelation.ImageAboveText;
			BAbout.ToolTipText = "Acerca de";
			BAbout.Click += BAbout_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Margin = new Padding(1, 2, 1, 2);
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 51);
			// 
			// BEmails
			// 
			BEmails.Image = Properties.Resources.Fatcow_Farm_Fresh_Email_accounts_32;
			BEmails.ImageScaling = ToolStripItemImageScaling.None;
			BEmails.ImageTransparentColor = Color.Magenta;
			BEmails.Margin = new Padding(1, 2, 1, 2);
			BEmails.Name = "BEmails";
			BEmails.Size = new Size(45, 51);
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
			BSync.Size = new Size(69, 51);
			BSync.Text = "&Sincronizar";
			BSync.TextImageRelation = TextImageRelation.ImageAboveText;
			BSync.Click += BSync_Click;
			// 
			// toolStripSeparator5
			// 
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new Size(6, 55);
			// 
			// BQueries
			// 
			BQueries.Image = Properties.Resources.Fatcow_Farm_Fresh_Query_design_32;
			BQueries.ImageScaling = ToolStripItemImageScaling.None;
			BQueries.ImageTransparentColor = Color.Magenta;
			BQueries.Margin = new Padding(1, 2, 1, 2);
			BQueries.Name = "BQueries";
			BQueries.Size = new Size(63, 51);
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
			BEventLog.Size = new Size(54, 51);
			BEventLog.Text = "&Bitácora";
			BEventLog.TextImageRelation = TextImageRelation.ImageAboveText;
			BEventLog.Click += BEventLog_Click;
			// 
			// ListBoxBirhdays
			// 
			ListBoxBirhdays.BackColor = SystemColors.GradientInactiveCaption;
			ListBoxBirhdays.BorderStyle = BorderStyle.None;
			ListBoxBirhdays.Dock = DockStyle.Fill;
			ListBoxBirhdays.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			ListBoxBirhdays.FormattingEnabled = true;
			ListBoxBirhdays.ItemHeight = 15;
			ListBoxBirhdays.Location = new Point(5, 5);
			ListBoxBirhdays.Margin = new Padding(5, 20, 5, 5);
			ListBoxBirhdays.Name = "ListBoxBirhdays";
			ListBoxBirhdays.SelectionMode = SelectionMode.None;
			ListBoxBirhdays.Size = new Size(295, 0);
			ListBoxBirhdays.TabIndex = 2;
			// 
			// LBirthdayList
			// 
			LBirthdayList.AutoSize = true;
			LBirthdayList.Dock = DockStyle.Fill;
			LBirthdayList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LBirthdayList.ForeColor = SystemColors.ControlText;
			LBirthdayList.Location = new Point(23, 5);
			LBirthdayList.Name = "LBirthdayList";
			LBirthdayList.Size = new Size(143, 15);
			LBirthdayList.TabIndex = 3;
			LBirthdayList.Text = "Cumpleaños el día de hoy";
			// 
			// PictureBoxBirthdayList
			// 
			PictureBoxBirthdayList.Dock = DockStyle.Left;
			PictureBoxBirthdayList.Image = Properties.Resources.Fatcow_Farm_Fresh_Cake_16;
			PictureBoxBirthdayList.Location = new Point(5, 5);
			PictureBoxBirthdayList.Name = "PictureBoxBirthdayList";
			PictureBoxBirthdayList.Size = new Size(18, 15);
			PictureBoxBirthdayList.TabIndex = 4;
			PictureBoxBirthdayList.TabStop = false;
			// 
			// BackgroundImage
			// 
			BackgroundImage.BackColor = Color.Transparent;
			BackgroundImage.Dock = DockStyle.Fill;
			BackgroundImage.Location = new Point(0, 89);
			BackgroundImage.Name = "BackgroundImage";
			BackgroundImage.Size = new Size(801, 301);
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
			BirthdayPanel.Location = new Point(7, 95);
			BirthdayPanel.Name = "BirthdayPanel";
			BirthdayPanel.Size = new Size(303, 37);
			BirthdayPanel.TabIndex = 6;
			// 
			// BirthdayPanelContent
			// 
			BirthdayPanelContent.AutoSize = true;
			BirthdayPanelContent.Controls.Add(ListBoxBirhdays);
			BirthdayPanelContent.Dock = DockStyle.Fill;
			BirthdayPanelContent.Location = new Point(0, 25);
			BirthdayPanelContent.MinimumSize = new Size(200, 0);
			BirthdayPanelContent.Name = "BirthdayPanelContent";
			BirthdayPanelContent.Padding = new Padding(5, 5, 1, 5);
			BirthdayPanelContent.Size = new Size(301, 10);
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
			BirthdayPanelTopBar.Margin = new Padding(3, 3, 3, 10);
			BirthdayPanelTopBar.MinimumSize = new Size(200, 0);
			BirthdayPanelTopBar.Name = "BirthdayPanelTopBar";
			BirthdayPanelTopBar.Padding = new Padding(5);
			BirthdayPanelTopBar.Size = new Size(301, 25);
			BirthdayPanelTopBar.TabIndex = 5;
			// 
			// FMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(801, 412);
			Controls.Add(BirthdayPanel);
			Controls.Add(BackgroundImage);
			Controls.Add(TabControl);
			Controls.Add(statusStrip1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			MinimumSize = new Size(600, 400);
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
		private ToolStripSeparator toolStripSeparator2;
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
		private ToolStripButton BEmails;
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
	}
}
