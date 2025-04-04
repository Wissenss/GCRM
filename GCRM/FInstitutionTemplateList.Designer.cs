namespace GCRM
{
	partial class FInstitutionTemplateList
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
			toolStrip1 = new ToolStrip();
			BAdd = new ToolStripButton();
			BEdit = new ToolStripButton();
			BRead = new ToolStripButton();
			BRefresh = new ToolStripButton();
			BDelete = new ToolStripButton();
			DataGridInstitutionTemplates = new DataGridView();
			colName = new DataGridViewTextBoxColumn();
			colId = new DataGridViewTextBoxColumn();
			colDescription = new DataGridViewTextBoxColumn();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridInstitutionTemplates).BeginInit();
			SuspendLayout();
			// 
			// toolStrip1
			// 
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(new ToolStripItem[] { BAdd, BEdit, BRead, BRefresh, BDelete });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.RenderMode = ToolStripRenderMode.System;
			toolStrip1.Size = new Size(532, 40);
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
			// 
			// BDelete
			// 
			BDelete.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete1;
			BDelete.ImageScaling = ToolStripItemImageScaling.None;
			BDelete.ImageTransparentColor = Color.Magenta;
			BDelete.Name = "BDelete";
			BDelete.Size = new Size(59, 37);
			BDelete.Text = "&Borrar";
			BDelete.Click += BDelete_Click;
			// 
			// DataGridInstitutionTemplates
			// 
			DataGridInstitutionTemplates.AllowUserToAddRows = false;
			DataGridInstitutionTemplates.AllowUserToDeleteRows = false;
			DataGridInstitutionTemplates.AllowUserToOrderColumns = true;
			DataGridInstitutionTemplates.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			DataGridInstitutionTemplates.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridInstitutionTemplates.BackgroundColor = SystemColors.Control;
			DataGridInstitutionTemplates.BorderStyle = BorderStyle.None;
			DataGridInstitutionTemplates.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridInstitutionTemplates.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridInstitutionTemplates.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridInstitutionTemplates.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridInstitutionTemplates.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridInstitutionTemplates.Columns.AddRange(new DataGridViewColumn[] { colName, colId, colDescription });
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGridInstitutionTemplates.DefaultCellStyle = dataGridViewCellStyle3;
			DataGridInstitutionTemplates.Dock = DockStyle.Fill;
			DataGridInstitutionTemplates.EnableHeadersVisualStyles = false;
			DataGridInstitutionTemplates.Location = new Point(0, 40);
			DataGridInstitutionTemplates.MultiSelect = false;
			DataGridInstitutionTemplates.Name = "DataGridInstitutionTemplates";
			DataGridInstitutionTemplates.ReadOnly = true;
			DataGridInstitutionTemplates.RowHeadersVisible = false;
			DataGridInstitutionTemplates.RowTemplate.Height = 20;
			DataGridInstitutionTemplates.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridInstitutionTemplates.ShowCellToolTips = false;
			DataGridInstitutionTemplates.Size = new Size(532, 292);
			DataGridInstitutionTemplates.StandardTab = true;
			DataGridInstitutionTemplates.TabIndex = 3;
			// 
			// colName
			// 
			colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			colName.DataPropertyName = "name";
			colName.DividerWidth = 1;
			colName.HeaderText = "Name";
			colName.Name = "colName";
			colName.ReadOnly = true;
			colName.Width = 63;
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
			// colDescription
			// 
			colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colDescription.DataPropertyName = "description";
			colDescription.HeaderText = "Description";
			colDescription.Name = "colDescription";
			colDescription.ReadOnly = true;
			// 
			// FInstitutionTemplateList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(532, 332);
			Controls.Add(DataGridInstitutionTemplates);
			Controls.Add(toolStrip1);
			Name = "FInstitutionTemplateList";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "Plantillas de instituciones";
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DataGridInstitutionTemplates).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip toolStrip1;
		private ToolStripButton BAdd;
		private ToolStripButton BEdit;
		private ToolStripButton BRead;
		private ToolStripButton BRefresh;
		private ToolStripButton BDelete;
		private DataGridView DataGridInstitutionTemplates;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colDescription;
	}
}