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
			BInstitutionCategories = new ToolStripButton();
			TabControl = new TabControl();
			TabPageCatalogs = new TabPage();
			TabOthers = new TabPage();
			toolStrip2 = new ToolStrip();
			BSettings = new ToolStripButton();
			BUsers = new ToolStripButton();
			BConnection = new ToolStripButton();
			BAbout = new ToolStripButton();
			ListBoxBirhdays = new ListBox();
			LBirthdayList = new Label();
			PictureBoxBirthdayList = new PictureBox();
			statusStrip1.SuspendLayout();
			toolStrip1.SuspendLayout();
			TabControl.SuspendLayout();
			TabPageCatalogs.SuspendLayout();
			TabOthers.SuspendLayout();
			toolStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)PictureBoxBirthdayList).BeginInit();
			SuspendLayout();
			// 
			// statusStrip1
			// 
			statusStrip1.Items.AddRange(new ToolStripItem[] { LToolStripUsername, LToolStripServer, LToolstripVersion });
			statusStrip1.Location = new Point(0, 461);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new Size(835, 22);
			statusStrip1.TabIndex = 0;
			statusStrip1.Text = "statusStrip1";
			// 
			// LToolStripUsername
			// 
			LToolStripUsername.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			LToolStripUsername.Name = "LToolStripUsername";
			LToolStripUsername.Size = new Size(273, 17);
			LToolStripUsername.Spring = true;
			LToolStripUsername.Text = "Usuario: ausuario";
			LToolStripUsername.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// LToolStripServer
			// 
			LToolStripServer.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			LToolStripServer.Name = "LToolStripServer";
			LToolStripServer.Size = new Size(273, 17);
			LToolStripServer.Spring = true;
			LToolStripServer.Text = "Server - tcp://localhost:8095";
			LToolStripServer.TextAlign = ContentAlignment.MiddleRight;
			// 
			// LToolstripVersion
			// 
			LToolstripVersion.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			LToolstripVersion.ForeColor = SystemColors.InfoText;
			LToolstripVersion.Name = "LToolstripVersion";
			LToolstripVersion.Size = new Size(273, 17);
			LToolstripVersion.Spring = true;
			LToolstripVersion.Text = "Versión - 0.0.0.1 - alpha";
			LToolstripVersion.TextAlign = ContentAlignment.MiddleRight;
			// 
			// toolStrip1
			// 
			toolStrip1.Dock = DockStyle.Fill;
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(new ToolStripItem[] { BCitizens, toolStripSeparator2, BInstitutions, BInstitutionCategories });
			toolStrip1.Location = new Point(3, 3);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.RenderMode = ToolStripRenderMode.System;
			toolStrip1.Size = new Size(821, 55);
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
			// BInstitutionCategories
			// 
			BInstitutionCategories.Image = Properties.Resources.Fatcow_Farm_Fresh_Module_32;
			BInstitutionCategories.ImageScaling = ToolStripItemImageScaling.None;
			BInstitutionCategories.ImageTransparentColor = Color.Magenta;
			BInstitutionCategories.Name = "BInstitutionCategories";
			BInstitutionCategories.Size = new Size(93, 52);
			BInstitutionCategories.Text = "Cat. de Institu...";
			BInstitutionCategories.TextImageRelation = TextImageRelation.ImageAboveText;
			BInstitutionCategories.Click += BInstitutionCategories_Click;
			// 
			// TabControl
			// 
			TabControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TabControl.Controls.Add(TabPageCatalogs);
			TabControl.Controls.Add(TabOthers);
			TabControl.Location = new Point(0, 0);
			TabControl.Name = "TabControl";
			TabControl.SelectedIndex = 0;
			TabControl.Size = new Size(835, 89);
			TabControl.TabIndex = 1;
			// 
			// TabPageCatalogs
			// 
			TabPageCatalogs.Controls.Add(toolStrip1);
			TabPageCatalogs.Location = new Point(4, 24);
			TabPageCatalogs.Name = "TabPageCatalogs";
			TabPageCatalogs.Padding = new Padding(3);
			TabPageCatalogs.Size = new Size(827, 61);
			TabPageCatalogs.TabIndex = 0;
			TabPageCatalogs.Text = "Catálogos";
			TabPageCatalogs.UseVisualStyleBackColor = true;
			// 
			// TabOthers
			// 
			TabOthers.Controls.Add(toolStrip2);
			TabOthers.Location = new Point(4, 24);
			TabOthers.Name = "TabOthers";
			TabOthers.Padding = new Padding(3);
			TabOthers.Size = new Size(827, 61);
			TabOthers.TabIndex = 1;
			TabOthers.Text = "Otros";
			TabOthers.UseVisualStyleBackColor = true;
			// 
			// toolStrip2
			// 
			toolStrip2.Dock = DockStyle.Fill;
			toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip2.Items.AddRange(new ToolStripItem[] { BSettings, BUsers, BConnection, BAbout });
			toolStrip2.Location = new Point(3, 3);
			toolStrip2.Name = "toolStrip2";
			toolStrip2.RenderMode = ToolStripRenderMode.System;
			toolStrip2.Size = new Size(821, 55);
			toolStrip2.TabIndex = 0;
			toolStrip2.Text = "toolStrip2";
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
			BSettings.Visible = false;
			// 
			// BUsers
			// 
			BUsers.Image = Properties.Resources.Fatcow_Farm_Fresh_User_suit_32;
			BUsers.ImageScaling = ToolStripItemImageScaling.None;
			BUsers.ImageTransparentColor = Color.Magenta;
			BUsers.Name = "BUsers";
			BUsers.Size = new Size(56, 52);
			BUsers.Text = "&Usuarios";
			BUsers.TextImageRelation = TextImageRelation.ImageAboveText;
			BUsers.Click += BUsers_Click;
			// 
			// BConnection
			// 
			BConnection.Alignment = ToolStripItemAlignment.Right;
			BConnection.Image = Properties.Resources.Fatcow_Farm_Fresh_Connect_32;
			BConnection.ImageScaling = ToolStripItemImageScaling.None;
			BConnection.ImageTransparentColor = Color.Magenta;
			BConnection.Name = "BConnection";
			BConnection.Size = new Size(62, 52);
			BConnection.Text = "&Conexión";
			BConnection.TextImageRelation = TextImageRelation.ImageAboveText;
			BConnection.Click += BConnection_Click;
			// 
			// BAbout
			// 
			BAbout.Alignment = ToolStripItemAlignment.Right;
			BAbout.Image = Properties.Resources.Fatcow_Farm_Fresh_Information_32;
			BAbout.ImageScaling = ToolStripItemImageScaling.None;
			BAbout.ImageTransparentColor = Color.Magenta;
			BAbout.Name = "BAbout";
			BAbout.Size = new Size(63, 52);
			BAbout.Text = "Acerca de";
			BAbout.TextImageRelation = TextImageRelation.ImageAboveText;
			BAbout.Click += BAbout_Click;
			// 
			// ListBoxBirhdays
			// 
			ListBoxBirhdays.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
			ListBoxBirhdays.BackColor = SystemColors.Control;
			ListBoxBirhdays.BorderStyle = BorderStyle.None;
			ListBoxBirhdays.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			ListBoxBirhdays.FormattingEnabled = true;
			ListBoxBirhdays.ItemHeight = 15;
			ListBoxBirhdays.Location = new Point(27, 115);
			ListBoxBirhdays.Name = "ListBoxBirhdays";
			ListBoxBirhdays.Size = new Size(306, 330);
			ListBoxBirhdays.TabIndex = 2;
			// 
			// LBirthdayList
			// 
			LBirthdayList.AutoSize = true;
			LBirthdayList.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LBirthdayList.ForeColor = SystemColors.HotTrack;
			LBirthdayList.Location = new Point(27, 96);
			LBirthdayList.Name = "LBirthdayList";
			LBirthdayList.Size = new Size(103, 15);
			LBirthdayList.TabIndex = 3;
			LBirthdayList.Text = "Feliz cumpleaños!";
			// 
			// PictureBoxBirthdayList
			// 
			PictureBoxBirthdayList.Image = Properties.Resources.Fatcow_Farm_Fresh_Cake_16;
			PictureBoxBirthdayList.Location = new Point(11, 95);
			PictureBoxBirthdayList.Name = "PictureBoxBirthdayList";
			PictureBoxBirthdayList.Size = new Size(16, 16);
			PictureBoxBirthdayList.TabIndex = 4;
			PictureBoxBirthdayList.TabStop = false;
			// 
			// FMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(835, 483);
			Controls.Add(PictureBoxBirthdayList);
			Controls.Add(LBirthdayList);
			Controls.Add(ListBoxBirhdays);
			Controls.Add(TabControl);
			Controls.Add(statusStrip1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FMain";
			Text = "GCRM";
			FormClosed += FMain_FormClosed;
			Load += FMain_Load;
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			TabControl.ResumeLayout(false);
			TabPageCatalogs.ResumeLayout(false);
			TabPageCatalogs.PerformLayout();
			TabOthers.ResumeLayout(false);
			TabOthers.PerformLayout();
			toolStrip2.ResumeLayout(false);
			toolStrip2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)PictureBoxBirthdayList).EndInit();
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
		private ToolStrip toolStrip2;
		private ToolStripButton BSettings;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton BInstitutionCategories;
		private ToolStripButton BUsers;
		private ToolStripStatusLabel LToolstripVersion;
		private ToolStripStatusLabel LToolStripServer;
		private ToolStripStatusLabel LToolStripUsername;
		private ToolStripButton BConnection;
		private ListBox ListBoxBirhdays;
		private Label LBirthdayList;
		private PictureBox PictureBoxBirthdayList;
		private ToolStripButton BAbout;
	}
}
