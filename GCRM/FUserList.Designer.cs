namespace GCRM
{
	partial class FUserList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FUserList));
			toolStrip1 = new ToolStrip();
			BAdd = new ToolStripButton();
			BEdit = new ToolStripButton();
			BRead = new ToolStripButton();
			BRefresh = new ToolStripButton();
			DataGridUsers = new DataGridView();
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colUsername = new DataGridViewTextBoxColumn();
			colPasswordHash = new DataGridViewTextBoxColumn();
			toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridUsers).BeginInit();
			SuspendLayout();
			// 
			// toolStrip1
			// 
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(new ToolStripItem[] { BAdd, BEdit, BRead, BRefresh });
			toolStrip1.Location = new Point(0, 0);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.RenderMode = ToolStripRenderMode.System;
			toolStrip1.Size = new Size(521, 40);
			toolStrip1.TabIndex = 0;
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
			BAdd.Size = new Size(66, 36);
			BAdd.Text = "Nuevo";
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
			BEdit.Text = "Editar";
			BEdit.Click += BEdit_Click;
			// 
			// BRead
			// 
			BRead.Image = Properties.Resources.Fatcow_Farm_Fresh_Magnifier_16;
			BRead.ImageScaling = ToolStripItemImageScaling.None;
			BRead.ImageTransparentColor = Color.Magenta;
			BRead.Margin = new Padding(1, 2, 1, 2);
			BRead.Name = "BRead";
			BRead.Padding = new Padding(2, 8, 2, 8);
			BRead.Size = new Size(82, 36);
			BRead.Text = "Consultar";
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
			BRefresh.Text = "Actualizar";
			BRefresh.Click += BRefresh_Click;
			// 
			// DataGridUsers
			// 
			DataGridUsers.AllowUserToAddRows = false;
			DataGridUsers.AllowUserToDeleteRows = false;
			DataGridUsers.AllowUserToOrderColumns = true;
			DataGridUsers.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			DataGridUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridUsers.BackgroundColor = SystemColors.Control;
			DataGridUsers.BorderStyle = BorderStyle.None;
			DataGridUsers.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridUsers.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Control;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridUsers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridUsers.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colUsername, colPasswordHash });
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGridUsers.DefaultCellStyle = dataGridViewCellStyle3;
			DataGridUsers.Dock = DockStyle.Fill;
			DataGridUsers.EnableHeadersVisualStyles = false;
			DataGridUsers.Location = new Point(0, 40);
			DataGridUsers.MultiSelect = false;
			DataGridUsers.Name = "DataGridUsers";
			DataGridUsers.ReadOnly = true;
			DataGridUsers.RowHeadersVisible = false;
			DataGridUsers.RowTemplate.Height = 20;
			DataGridUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridUsers.Size = new Size(521, 289);
			DataGridUsers.StandardTab = true;
			DataGridUsers.TabIndex = 1;
			// 
			// colId
			// 
			colId.DataPropertyName = "id";
			colId.HeaderText = "Id";
			colId.Name = "colId";
			colId.ReadOnly = true;
			colId.Visible = false;
			// 
			// colName
			// 
			colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colName.DataPropertyName = "name";
			colName.DividerWidth = 1;
			colName.HeaderText = "Nombre";
			colName.Name = "colName";
			colName.ReadOnly = true;
			// 
			// colUsername
			// 
			colUsername.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colUsername.DataPropertyName = "username";
			colUsername.HeaderText = "Usuario";
			colUsername.Name = "colUsername";
			colUsername.ReadOnly = true;
			// 
			// colPasswordHash
			// 
			colPasswordHash.DataPropertyName = "password_hash";
			colPasswordHash.HeaderText = "Hash Clave";
			colPasswordHash.Name = "colPasswordHash";
			colPasswordHash.ReadOnly = true;
			colPasswordHash.Visible = false;
			// 
			// FUserList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(521, 329);
			Controls.Add(DataGridUsers);
			Controls.Add(toolStrip1);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FUserList";
			ShowIcon = false;
			Text = "Usuarios";
			Load += FUserList_Load;
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DataGridUsers).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip toolStrip1;
		private DataGridView DataGridUsers;
		private ToolStripButton BAdd;
		private ToolStripButton BEdit;
		private ToolStripButton BRead;
		private ToolStripButton BRefresh;
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colUsername;
		private DataGridViewTextBoxColumn colPasswordHash;
	}
}