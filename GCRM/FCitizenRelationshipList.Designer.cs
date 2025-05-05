namespace GCRM
{
	partial class FCitizenRelationshipList
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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			DataGridRelationships = new DataGridView();
			ToolStrip = new ToolStrip();
			BAdd = new ToolStripButton();
			BEdit = new ToolStripButton();
			BRead = new ToolStripButton();
			BRefresh = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			BFields = new ToolStripButton();
			BFilter = new ToolStripButton();
			BDelete = new ToolStripButton();
			toolStripSeparator2 = new ToolStripSeparator();
			FExcelExport = new ToolStripButton();
			BPrint = new ToolStripButton();
			toolStripSeparator4 = new ToolStripSeparator();
			BSearch = new ToolStripButton();
			toolStripSeparator5 = new ToolStripSeparator();
			BRelationshipRoles = new ToolStripButton();
			BRelationships = new ToolStripButton();
			PanelSearch = new Panel();
			TextBoxSearch = new TextBox();
			statusStrip1 = new StatusStrip();
			TSSLRecordCount = new ToolStripStatusLabel();
			TSSLFilters = new ToolStripStatusLabel();
			((System.ComponentModel.ISupportInitialize)DataGridRelationships).BeginInit();
			ToolStrip.SuspendLayout();
			PanelSearch.SuspendLayout();
			statusStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// DataGridRelationships
			// 
			DataGridRelationships.AllowUserToAddRows = false;
			DataGridRelationships.AllowUserToDeleteRows = false;
			DataGridRelationships.AllowUserToOrderColumns = true;
			DataGridRelationships.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			DataGridRelationships.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridRelationships.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridRelationships.BackgroundColor = SystemColors.Control;
			DataGridRelationships.BorderStyle = BorderStyle.None;
			DataGridRelationships.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridRelationships.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridRelationships.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridRelationships.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridRelationships.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGridRelationships.DefaultCellStyle = dataGridViewCellStyle3;
			DataGridRelationships.Dock = DockStyle.Fill;
			DataGridRelationships.EnableHeadersVisualStyles = false;
			DataGridRelationships.ImeMode = ImeMode.NoControl;
			DataGridRelationships.Location = new Point(0, 79);
			DataGridRelationships.MultiSelect = false;
			DataGridRelationships.Name = "DataGridRelationships";
			DataGridRelationships.ReadOnly = true;
			DataGridRelationships.RowHeadersVisible = false;
			DataGridRelationships.RowTemplate.Height = 20;
			DataGridRelationships.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridRelationships.ShowCellToolTips = false;
			DataGridRelationships.Size = new Size(1088, 495);
			DataGridRelationships.StandardTab = true;
			DataGridRelationships.TabIndex = 9;
			// 
			// ToolStrip
			// 
			ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
			ToolStrip.Items.AddRange(new ToolStripItem[] { BAdd, BEdit, BRead, BRefresh, toolStripSeparator1, BFields, BFilter, BDelete, toolStripSeparator2, FExcelExport, BPrint, toolStripSeparator4, BSearch, toolStripSeparator5, BRelationshipRoles, BRelationships });
			ToolStrip.Location = new Point(0, 0);
			ToolStrip.Name = "ToolStrip";
			ToolStrip.RenderMode = ToolStripRenderMode.System;
			ToolStrip.Size = new Size(1088, 40);
			ToolStrip.TabIndex = 8;
			ToolStrip.Text = "toolStrip1";
			// 
			// BAdd
			// 
			BAdd.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			BAdd.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
			BAdd.ImageScaling = ToolStripItemImageScaling.None;
			BAdd.ImageTransparentColor = Color.Magenta;
			BAdd.Margin = new Padding(1, 2, 1, 2);
			BAdd.Name = "BAdd";
			BAdd.Padding = new Padding(2, 8, 2, 8);
			BAdd.Size = new Size(73, 36);
			BAdd.Text = "&Agregar";
			BAdd.Visible = false;
			// 
			// BEdit
			// 
			BEdit.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_16;
			BEdit.ImageScaling = ToolStripItemImageScaling.None;
			BEdit.ImageTransparentColor = Color.Magenta;
			BEdit.Margin = new Padding(1, 2, 1, 2);
			BEdit.Name = "BEdit";
			BEdit.Padding = new Padding(2, 8, 2, 8);
			BEdit.Size = new Size(61, 36);
			BEdit.Text = "&Editar";
			BEdit.Visible = false;
			// 
			// BRead
			// 
			BRead.Image = Properties.Resources.Fatcow_Farm_Fresh_Information_16;
			BRead.ImageTransparentColor = Color.Magenta;
			BRead.Margin = new Padding(1, 2, 1, 2);
			BRead.Name = "BRead";
			BRead.Padding = new Padding(2, 8, 2, 8);
			BRead.Size = new Size(82, 36);
			BRead.Text = "&Consultar";
			BRead.Visible = false;
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
			BFields.Click += BFields_Click;
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
			BFilter.Visible = false;
			// 
			// BDelete
			// 
			BDelete.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete_16;
			BDelete.ImageScaling = ToolStripItemImageScaling.None;
			BDelete.ImageTransparentColor = Color.Magenta;
			BDelete.Name = "BDelete";
			BDelete.Size = new Size(59, 37);
			BDelete.Text = "&Borrar";
			BDelete.Visible = false;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 40);
			toolStripSeparator2.Visible = false;
			// 
			// FExcelExport
			// 
			FExcelExport.Image = Properties.Resources.Fatcow_Farm_Fresh_Export_excel_16;
			FExcelExport.ImageScaling = ToolStripItemImageScaling.None;
			FExcelExport.ImageTransparentColor = Color.Magenta;
			FExcelExport.Margin = new Padding(1, 2, 1, 2);
			FExcelExport.Name = "FExcelExport";
			FExcelExport.Padding = new Padding(2, 8, 2, 8);
			FExcelExport.Size = new Size(74, 36);
			FExcelExport.Text = "E&xportar";
			FExcelExport.Visible = false;
			// 
			// BPrint
			// 
			BPrint.Image = Properties.Resources.Fatcow_Farm_Fresh_Printer_16;
			BPrint.ImageTransparentColor = Color.Magenta;
			BPrint.Margin = new Padding(1, 2, 1, 2);
			BPrint.Name = "BPrint";
			BPrint.Padding = new Padding(2, 8, 2, 8);
			BPrint.Size = new Size(77, 36);
			BPrint.Text = "&Imprimir";
			BPrint.Visible = false;
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
			BSearch.Click += BSearch_Click;
			// 
			// toolStripSeparator5
			// 
			toolStripSeparator5.Name = "toolStripSeparator5";
			toolStripSeparator5.Size = new Size(6, 40);
			// 
			// BRelationshipRoles
			// 
			BRelationshipRoles.Image = Properties.Resources.Fatcow_Farm_Fresh_Link_16;
			BRelationshipRoles.ImageScaling = ToolStripItemImageScaling.None;
			BRelationshipRoles.ImageTransparentColor = Color.Magenta;
			BRelationshipRoles.Name = "BRelationshipRoles";
			BRelationshipRoles.Size = new Size(140, 37);
			BRelationshipRoles.Text = "&Vínculos Relacionales";
			BRelationshipRoles.Click += BRelationshipRoles_Click;
			// 
			// BRelationships
			// 
			BRelationships.Image = Properties.Resources.Fatcow_Farm_Fresh_Small_business_16;
			BRelationships.ImageScaling = ToolStripItemImageScaling.None;
			BRelationships.ImageTransparentColor = Color.Magenta;
			BRelationships.Name = "BRelationships";
			BRelationships.Size = new Size(102, 37);
			BRelationships.Text = "Compromisos";
			BRelationships.Visible = false;
			// 
			// PanelSearch
			// 
			PanelSearch.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			PanelSearch.Controls.Add(TextBoxSearch);
			PanelSearch.Dock = DockStyle.Top;
			PanelSearch.Location = new Point(0, 40);
			PanelSearch.Name = "PanelSearch";
			PanelSearch.Size = new Size(1088, 39);
			PanelSearch.TabIndex = 10;
			PanelSearch.Visible = false;
			// 
			// TextBoxSearch
			// 
			TextBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxSearch.Location = new Point(8, 8);
			TextBoxSearch.Name = "TextBoxSearch";
			TextBoxSearch.PlaceholderText = "Ingrese el texto a buscar...";
			TextBoxSearch.Size = new Size(2051, 23);
			TextBoxSearch.TabIndex = 1;
			TextBoxSearch.TextChanged += TextBoxSearch_TextChanged;
			// 
			// statusStrip1
			// 
			statusStrip1.Items.AddRange(new ToolStripItem[] { TSSLRecordCount, TSSLFilters });
			statusStrip1.Location = new Point(0, 574);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new Size(1088, 22);
			statusStrip1.TabIndex = 11;
			statusStrip1.Text = "statusStrip1";
			// 
			// TSSLRecordCount
			// 
			TSSLRecordCount.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			TSSLRecordCount.Margin = new Padding(0, 3, 5, 2);
			TSSLRecordCount.Name = "TSSLRecordCount";
			TSSLRecordCount.Size = new Size(78, 17);
			TSSLRecordCount.Text = "Registros: 524";
			// 
			// TSSLFilters
			// 
			TSSLFilters.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			TSSLFilters.Margin = new Padding(0, 3, 5, 2);
			TSSLFilters.Name = "TSSLFilters";
			TSSLFilters.Size = new Size(0, 17);
			TSSLFilters.TextAlign = ContentAlignment.MiddleLeft;
			// 
			// FCitizenRelationshipList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1088, 596);
			Controls.Add(DataGridRelationships);
			Controls.Add(statusStrip1);
			Controls.Add(PanelSearch);
			Controls.Add(ToolStrip);
			Name = "FCitizenRelationshipList";
			ShowIcon = false;
			Text = "Relaciones Ciudadanas";
			FormClosing += FCitizenRelationshipList_FormClosing;
			Load += FCitizenRelationshipList_Load;
			((System.ComponentModel.ISupportInitialize)DataGridRelationships).EndInit();
			ToolStrip.ResumeLayout(false);
			ToolStrip.PerformLayout();
			PanelSearch.ResumeLayout(false);
			PanelSearch.PerformLayout();
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView DataGridRelationships;
		private ToolStrip ToolStrip;
		private ToolStripButton BAdd;
		private ToolStripButton BEdit;
		private ToolStripButton BRead;
		private ToolStripButton BRefresh;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton BFields;
		private ToolStripButton BFilter;
		private ToolStripButton BDelete;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton FExcelExport;
		private ToolStripButton BPrint;
		private ToolStripSeparator toolStripSeparator4;
		private ToolStripButton BSearch;
		private ToolStripSeparator toolStripSeparator5;
		private ToolStripButton BRelationships;
		private ToolStripButton BRelationshipRoles;
		private Panel PanelSearch;
		private TextBox TextBoxSearch;
		private StatusStrip statusStrip1;
		private ToolStripStatusLabel TSSLRecordCount;
		private ToolStripStatusLabel TSSLFilters;
	}
}