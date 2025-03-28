namespace GCRM
{
	partial class FEventLog
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
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
			ToolStrip = new ToolStrip();
			BRefresh = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			BFields = new ToolStripButton();
			BFilter = new ToolStripButton();
			toolStripSeparator4 = new ToolStripSeparator();
			BSearch = new ToolStripButton();
			BPurgeLog = new ToolStripButton();
			BDetail = new ToolStripButton();
			DataGridLogs = new DataGridView();
			SplitContainer = new SplitContainer();
			LUser = new Label();
			LLUser = new Label();
			LEntity = new Label();
			LLEntity = new Label();
			LDate = new Label();
			LLDate = new Label();
			LName = new Label();
			Message = new TextBox();
			ToolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridLogs).BeginInit();
			((System.ComponentModel.ISupportInitialize)SplitContainer).BeginInit();
			SplitContainer.Panel1.SuspendLayout();
			SplitContainer.Panel2.SuspendLayout();
			SplitContainer.SuspendLayout();
			SuspendLayout();
			// 
			// ToolStrip
			// 
			ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
			ToolStrip.Items.AddRange(new ToolStripItem[] { BRefresh, toolStripSeparator1, BFields, BFilter, toolStripSeparator4, BSearch, BPurgeLog, BDetail });
			ToolStrip.Location = new Point(0, 0);
			ToolStrip.Name = "ToolStrip";
			ToolStrip.RenderMode = ToolStripRenderMode.System;
			ToolStrip.Size = new Size(897, 40);
			ToolStrip.TabIndex = 5;
			ToolStrip.Text = "toolStrip1";
			// 
			// BRefresh
			// 
			BRefresh.Alignment = ToolStripItemAlignment.Right;
			BRefresh.Image = Properties.Resources.Fatcow_Farm_Fresh_Database_refresh_16;
			BRefresh.ImageScaling = ToolStripItemImageScaling.None;
			BRefresh.ImageTransparentColor = Color.Magenta;
			BRefresh.Margin = new Padding(1, 2, 1, 2);
			BRefresh.Name = "BRefresh";
			BRefresh.Padding = new Padding(2, 8, 2, 8);
			BRefresh.Size = new Size(83, 36);
			BRefresh.Text = "Actualiza&r";
			BRefresh.Click += BRefresh_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 40);
			// 
			// BFields
			// 
			BFields.Alignment = ToolStripItemAlignment.Right;
			BFields.Image = Properties.Resources.Fatcow_Farm_Fresh_Layouts_header_select_16;
			BFields.ImageScaling = ToolStripItemImageScaling.None;
			BFields.ImageTransparentColor = Color.Magenta;
			BFields.Margin = new Padding(1, 2, 1, 2);
			BFields.Name = "BFields";
			BFields.Padding = new Padding(2, 8, 2, 8);
			BFields.Size = new Size(75, 36);
			BFields.Text = "Cam&pos";
			BFields.Visible = false;
			// 
			// BFilter
			// 
			BFilter.Alignment = ToolStripItemAlignment.Right;
			BFilter.Image = Properties.Resources.Fatcow_Farm_Fresh_Filter_16;
			BFilter.ImageTransparentColor = Color.Magenta;
			BFilter.Margin = new Padding(1, 2, 1, 2);
			BFilter.Name = "BFilter";
			BFilter.Padding = new Padding(2, 8, 2, 8);
			BFilter.Size = new Size(61, 36);
			BFilter.Text = "&Filtrar";
			BFilter.Click += BFilter_Click;
			// 
			// toolStripSeparator4
			// 
			toolStripSeparator4.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator4.Name = "toolStripSeparator4";
			toolStripSeparator4.Size = new Size(6, 40);
			// 
			// BSearch
			// 
			BSearch.Alignment = ToolStripItemAlignment.Right;
			BSearch.CheckOnClick = true;
			BSearch.Image = Properties.Resources.Fatcow_Farm_Fresh_Find_16;
			BSearch.ImageTransparentColor = Color.Magenta;
			BSearch.Margin = new Padding(1, 2, 1, 2);
			BSearch.Name = "BSearch";
			BSearch.Padding = new Padding(2, 8, 2, 8);
			BSearch.Size = new Size(66, 36);
			BSearch.Text = "&Buscar";
			BSearch.Visible = false;
			// 
			// BPurgeLog
			// 
			BPurgeLog.Image = Properties.Resources.Fatcow_Farm_Fresh_Broom_16;
			BPurgeLog.ImageScaling = ToolStripItemImageScaling.None;
			BPurgeLog.ImageTransparentColor = Color.Magenta;
			BPurgeLog.Margin = new Padding(1, 2, 1, 2);
			BPurgeLog.Name = "BPurgeLog";
			BPurgeLog.Padding = new Padding(2, 8, 2, 8);
			BPurgeLog.Size = new Size(71, 36);
			BPurgeLog.Text = "&Limpiar";
			BPurgeLog.Visible = false;
			// 
			// BDetail
			// 
			BDetail.Alignment = ToolStripItemAlignment.Right;
			BDetail.Checked = true;
			BDetail.CheckOnClick = true;
			BDetail.CheckState = CheckState.Checked;
			BDetail.Image = Properties.Resources.Fatcow_Farm_Fresh_Document_inspect_16;
			BDetail.ImageAlign = ContentAlignment.MiddleRight;
			BDetail.ImageTransparentColor = Color.Magenta;
			BDetail.Margin = new Padding(1, 2, 1, 2);
			BDetail.Name = "BDetail";
			BDetail.Padding = new Padding(2, 8, 2, 8);
			BDetail.Size = new Size(67, 36);
			BDetail.Text = "&Detalle";
			BDetail.Click += BDetail_Click;
			// 
			// DataGridLogs
			// 
			DataGridLogs.AllowUserToAddRows = false;
			DataGridLogs.AllowUserToDeleteRows = false;
			DataGridLogs.AllowUserToOrderColumns = true;
			DataGridLogs.AllowUserToResizeRows = false;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
			DataGridLogs.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			DataGridLogs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridLogs.BackgroundColor = SystemColors.Control;
			DataGridLogs.BorderStyle = BorderStyle.None;
			DataGridLogs.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridLogs.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridLogs.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			DataGridLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			DataGridLogs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Window;
			dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
			DataGridLogs.DefaultCellStyle = dataGridViewCellStyle6;
			DataGridLogs.Dock = DockStyle.Fill;
			DataGridLogs.EnableHeadersVisualStyles = false;
			DataGridLogs.ImeMode = ImeMode.NoControl;
			DataGridLogs.Location = new Point(0, 0);
			DataGridLogs.MultiSelect = false;
			DataGridLogs.Name = "DataGridLogs";
			DataGridLogs.ReadOnly = true;
			DataGridLogs.RowHeadersVisible = false;
			DataGridLogs.RowTemplate.Height = 20;
			DataGridLogs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridLogs.ShowCellToolTips = false;
			DataGridLogs.Size = new Size(513, 501);
			DataGridLogs.StandardTab = true;
			DataGridLogs.TabIndex = 8;
			DataGridLogs.SelectionChanged += DataGridLogs_SelectionChanged;
			// 
			// SplitContainer
			// 
			SplitContainer.BackColor = SystemColors.ControlLightLight;
			SplitContainer.Dock = DockStyle.Fill;
			SplitContainer.Location = new Point(0, 40);
			SplitContainer.Name = "SplitContainer";
			// 
			// SplitContainer.Panel1
			// 
			SplitContainer.Panel1.BackColor = SystemColors.Control;
			SplitContainer.Panel1.Controls.Add(DataGridLogs);
			// 
			// SplitContainer.Panel2
			// 
			SplitContainer.Panel2.BackColor = SystemColors.Control;
			SplitContainer.Panel2.Controls.Add(LUser);
			SplitContainer.Panel2.Controls.Add(LLUser);
			SplitContainer.Panel2.Controls.Add(LEntity);
			SplitContainer.Panel2.Controls.Add(LLEntity);
			SplitContainer.Panel2.Controls.Add(LDate);
			SplitContainer.Panel2.Controls.Add(LLDate);
			SplitContainer.Panel2.Controls.Add(LName);
			SplitContainer.Panel2.Controls.Add(Message);
			SplitContainer.Panel2.Padding = new Padding(5);
			SplitContainer.Size = new Size(897, 501);
			SplitContainer.SplitterDistance = 513;
			SplitContainer.SplitterWidth = 5;
			SplitContainer.TabIndex = 9;
			// 
			// LUser
			// 
			LUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			LUser.Location = new Point(200, 427);
			LUser.Name = "LUser";
			LUser.Size = new Size(170, 15);
			LUser.TabIndex = 7;
			LUser.Text = "Josefina Vazquez";
			LUser.TextAlign = ContentAlignment.MiddleRight;
			// 
			// LLUser
			// 
			LLUser.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			LLUser.AutoSize = true;
			LLUser.Location = new Point(8, 427);
			LLUser.Name = "LLUser";
			LLUser.Size = new Size(37, 15);
			LLUser.TabIndex = 6;
			LLUser.Text = "Autor";
			// 
			// LEntity
			// 
			LEntity.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			LEntity.Location = new Point(200, 447);
			LEntity.Name = "LEntity";
			LEntity.Size = new Size(170, 15);
			LEntity.TabIndex = 5;
			LEntity.Text = "Usuario";
			LEntity.TextAlign = ContentAlignment.MiddleRight;
			// 
			// LLEntity
			// 
			LLEntity.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			LLEntity.AutoSize = true;
			LLEntity.Location = new Point(8, 447);
			LLEntity.Name = "LLEntity";
			LLEntity.Size = new Size(47, 15);
			LLEntity.TabIndex = 4;
			LLEntity.Text = "Entidad";
			// 
			// LDate
			// 
			LDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			LDate.Location = new Point(200, 467);
			LDate.Name = "LDate";
			LDate.Size = new Size(170, 15);
			LDate.TabIndex = 3;
			LDate.Text = "2025/02/17";
			LDate.TextAlign = ContentAlignment.MiddleRight;
			// 
			// LLDate
			// 
			LLDate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			LLDate.AutoSize = true;
			LLDate.Location = new Point(8, 467);
			LLDate.Name = "LLDate";
			LLDate.Size = new Size(38, 15);
			LLDate.TabIndex = 2;
			LLDate.Text = "Fecha";
			// 
			// LName
			// 
			LName.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
			LName.AutoSize = true;
			LName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LName.Location = new Point(8, 407);
			LName.Name = "LName";
			LName.Size = new Size(71, 15);
			LName.TabIndex = 1;
			LName.Text = "Alta Usuario";
			// 
			// Message
			// 
			Message.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			Message.BorderStyle = BorderStyle.FixedSingle;
			Message.Location = new Point(8, 8);
			Message.Multiline = true;
			Message.Name = "Message";
			Message.ReadOnly = true;
			Message.ScrollBars = ScrollBars.Both;
			Message.Size = new Size(362, 392);
			Message.TabIndex = 0;
			// 
			// FEventLog
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(897, 541);
			Controls.Add(SplitContainer);
			Controls.Add(ToolStrip);
			Name = "FEventLog";
			ShowIcon = false;
			Text = "Bitácora";
			Load += FEventLog_Load;
			ToolStrip.ResumeLayout(false);
			ToolStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DataGridLogs).EndInit();
			SplitContainer.Panel1.ResumeLayout(false);
			SplitContainer.Panel2.ResumeLayout(false);
			SplitContainer.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)SplitContainer).EndInit();
			SplitContainer.ResumeLayout(false);
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip ToolStrip;
		private ToolStripButton BRefresh;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton BFields;
		private ToolStripButton BFilter;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripButton BSearch;
		private DataGridView DataGridLogs;
		private ToolStripButton BPurgeLog;
		private ToolStripButton BDetail;
		private SplitContainer SplitContainer;
		private TextBox Message;
		private Label LName;
		private Label LLDate;
		private Label LDate;
		private Label LEntity;
		private Label LLEntity;
		private Label LUser;
		private Label LLUser;
	}
}