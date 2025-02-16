namespace GCRM
{
	partial class FInstitutionList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInstitutionList));
			toolStrip1 = new ToolStrip();
			BAdd = new ToolStripButton();
			BEdit = new ToolStripButton();
			BRead = new ToolStripButton();
			BRefresh = new ToolStripButton();
			DataGridInstitutions = new DataGridView();
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colSocietySector = new DataGridViewTextBoxColumn();
			colSocietySectorName = new DataGridViewTextBoxColumn();
			colCategoryId = new DataGridViewTextBoxColumn();
			colCategoryName = new DataGridViewTextBoxColumn();
			colDescription = new DataGridViewTextBoxColumn();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridInstitutions).BeginInit();
			SuspendLayout();
			// 
			// toolStrip1
			// 
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(new ToolStripItem[] { BAdd, BEdit, BRead, BRefresh });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.RenderMode = ToolStripRenderMode.System;
			toolStrip1.Size = new Size(756, 40);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "toolStrip1";
			// 
			// BAdd
			// 
			BAdd.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
			BAdd.ImageScaling = ToolStripItemImageScaling.None;
			BAdd.ImageTransparentColor = Color.Magenta;
			BAdd.Margin = new Padding(1, 2, 1, 2);
			BAdd.Name = "BAdd";
			BAdd.Padding = new Padding(2, 8, 2, 8);
			BAdd.Size = new Size(73, 36);
			BAdd.Text = "&Agregar";
			BAdd.Click += BAdd_Click;
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
			BEdit.Click += BEdit_Click;
			// 
			// BRead
			// 
			BRead.Image = Properties.Resources.Fatcow_Farm_Fresh_Magnifier_16;
			BRead.ImageTransparentColor = Color.Magenta;
			BRead.Margin = new Padding(1, 2, 1, 2);
			BRead.Name = "BRead";
			BRead.Padding = new Padding(2, 8, 2, 8);
			BRead.Size = new Size(82, 36);
			BRead.Text = "&Consultar";
			BRead.Click += BRead_Click;
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
			// DataGridInstitutions
			// 
			DataGridInstitutions.AllowUserToAddRows = false;
			DataGridInstitutions.AllowUserToDeleteRows = false;
			DataGridInstitutions.AllowUserToOrderColumns = true;
			DataGridInstitutions.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
			DataGridInstitutions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridInstitutions.BackgroundColor = SystemColors.Control;
			DataGridInstitutions.BorderStyle = BorderStyle.None;
			DataGridInstitutions.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridInstitutions.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridInstitutions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridInstitutions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridInstitutions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridInstitutions.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colSocietySector, colSocietySectorName, colCategoryId, colCategoryName, colDescription });
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGridInstitutions.DefaultCellStyle = dataGridViewCellStyle3;
			DataGridInstitutions.Dock = DockStyle.Fill;
			DataGridInstitutions.EnableHeadersVisualStyles = false;
			DataGridInstitutions.Location = new Point(0, 40);
			DataGridInstitutions.MultiSelect = false;
			DataGridInstitutions.Name = "DataGridInstitutions";
			DataGridInstitutions.ReadOnly = true;
			DataGridInstitutions.RowHeadersVisible = false;
			DataGridInstitutions.RowTemplate.Height = 20;
			DataGridInstitutions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridInstitutions.Size = new Size(756, 405);
			DataGridInstitutions.StandardTab = true;
			DataGridInstitutions.TabIndex = 3;
			// 
			// colId
			// 
			colId.DataPropertyName = "id";
			colId.DividerWidth = 1;
			colId.HeaderText = "Id";
			colId.Name = "colId";
			colId.ReadOnly = true;
			colId.Visible = false;
			// 
			// colName
			// 
			colName.DataPropertyName = "name";
			colName.DividerWidth = 1;
			colName.HeaderText = "Nombre";
			colName.Name = "colName";
			colName.ReadOnly = true;
			colName.Width = 150;
			// 
			// colSocietySector
			// 
			colSocietySector.DataPropertyName = "society_sector";
			colSocietySector.DividerWidth = 1;
			colSocietySector.HeaderText = "Id Sector";
			colSocietySector.Name = "colSocietySector";
			colSocietySector.ReadOnly = true;
			colSocietySector.Visible = false;
			// 
			// colSocietySectorName
			// 
			colSocietySectorName.DataPropertyName = "society_sector_name";
			colSocietySectorName.DividerWidth = 1;
			colSocietySectorName.HeaderText = "Sector";
			colSocietySectorName.Name = "colSocietySectorName";
			colSocietySectorName.ReadOnly = true;
			// 
			// colCategoryId
			// 
			colCategoryId.DataPropertyName = "category_id";
			colCategoryId.DividerWidth = 1;
			colCategoryId.HeaderText = "Id Categoría";
			colCategoryId.Name = "colCategoryId";
			colCategoryId.ReadOnly = true;
			colCategoryId.Visible = false;
			// 
			// colCategoryName
			// 
			colCategoryName.DataPropertyName = "category_name";
			colCategoryName.DividerWidth = 1;
			colCategoryName.HeaderText = "Categoría";
			colCategoryName.Name = "colCategoryName";
			colCategoryName.ReadOnly = true;
			// 
			// colDescription
			// 
			colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colDescription.DataPropertyName = "description";
			colDescription.HeaderText = "Descripción";
			colDescription.Name = "colDescription";
			colDescription.ReadOnly = true;
			// 
			// FInstitutionList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(756, 445);
			Controls.Add(DataGridInstitutions);
			Controls.Add(toolStrip1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FInstitutionList";
			ShowIcon = false;
			Text = "Instituciones";
			Load += FInstitutionList_Load;
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DataGridInstitutions).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip toolStrip1;
		private ToolStripButton BAdd;
		private ToolStripButton BEdit;
		private ToolStripButton BRead;
		private ToolStripButton BRefresh;
		private DataGridView DataGridInstitutions;
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colSocietySector;
		private DataGridViewTextBoxColumn colSocietySectorName;
		private DataGridViewTextBoxColumn colCategoryId;
		private DataGridViewTextBoxColumn colCategoryName;
		private DataGridViewTextBoxColumn colDescription;
	}
}