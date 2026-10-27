namespace GCRM
{
	partial class FUserGroupList
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
            DataGridUserGroups = new DataGridView();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridUserGroups).BeginInit();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { BAdd, BEdit, BRead, BRefresh });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(512, 40);
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
            BRead.Image = Properties.Resources.Fatcow_Farm_Fresh_Information_16;
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
            // DataGridUserGroups
            // 
            DataGridUserGroups.AllowUserToAddRows = false;
            DataGridUserGroups.AllowUserToDeleteRows = false;
            DataGridUserGroups.AllowUserToOrderColumns = true;
            DataGridUserGroups.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            DataGridUserGroups.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGridUserGroups.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridUserGroups.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DataGridUserGroups.BackgroundColor = SystemColors.Control;
            DataGridUserGroups.BorderStyle = BorderStyle.None;
            DataGridUserGroups.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridUserGroups.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridUserGroups.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGridUserGroups.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridUserGroups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DataGridUserGroups.DefaultCellStyle = dataGridViewCellStyle3;
            DataGridUserGroups.Dock = DockStyle.Fill;
            DataGridUserGroups.EnableHeadersVisualStyles = false;
            DataGridUserGroups.ImeMode = ImeMode.NoControl;
            DataGridUserGroups.Location = new Point(0, 40);
            DataGridUserGroups.MultiSelect = false;
            DataGridUserGroups.Name = "DataGridUserGroups";
            DataGridUserGroups.ReadOnly = true;
            DataGridUserGroups.RowHeadersVisible = false;
            DataGridUserGroups.RowTemplate.Height = 20;
            DataGridUserGroups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridUserGroups.ShowCellToolTips = false;
            DataGridUserGroups.Size = new Size(512, 279);
            DataGridUserGroups.StandardTab = true;
            DataGridUserGroups.TabIndex = 8;
            // 
            // FUserGroupList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 319);
            Controls.Add(DataGridUserGroups);
            Controls.Add(toolStrip1);
            Name = "FUserGroupList";
            ShowIcon = false;
            Text = "Grupos de usuarios";
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridUserGroups).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
		private ToolStripButton BAdd;
		private ToolStripButton BEdit;
		private ToolStripButton BRead;
		private ToolStripButton BRefresh;
		private DataGridView DataGridUserGroups;
	}
}