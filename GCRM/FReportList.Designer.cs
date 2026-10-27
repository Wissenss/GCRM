namespace GCRM
{
    partial class FReportList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FReportList));
            DataGridReports = new DataGridView();
            colClave = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            statusStrip1 = new StatusStrip();
            ToolStrip = new ToolStrip();
            BFilter = new ToolStripButton();
            BGenerate = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            BSearch = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)DataGridReports).BeginInit();
            ToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // DataGridReports
            // 
            DataGridReports.AllowUserToAddRows = false;
            DataGridReports.AllowUserToDeleteRows = false;
            DataGridReports.AllowUserToOrderColumns = true;
            DataGridReports.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            DataGridReports.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGridReports.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DataGridReports.BackgroundColor = SystemColors.Control;
            DataGridReports.BorderStyle = BorderStyle.None;
            DataGridReports.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridReports.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridReports.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGridReports.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridReports.Columns.AddRange(new DataGridViewColumn[] { colClave, colNombre, colDescripcion });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DataGridReports.DefaultCellStyle = dataGridViewCellStyle3;
            DataGridReports.Dock = DockStyle.Fill;
            DataGridReports.EnableHeadersVisualStyles = false;
            DataGridReports.ImeMode = ImeMode.NoControl;
            DataGridReports.Location = new Point(0, 40);
            DataGridReports.MultiSelect = false;
            DataGridReports.Name = "DataGridReports";
            DataGridReports.ReadOnly = true;
            DataGridReports.RowHeadersVisible = false;
            DataGridReports.RowTemplate.Height = 20;
            DataGridReports.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridReports.ShowCellToolTips = false;
            DataGridReports.Size = new Size(841, 384);
            DataGridReports.StandardTab = true;
            DataGridReports.TabIndex = 10;
            // 
            // colClave
            // 
            colClave.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colClave.DataPropertyName = "key";
            colClave.DividerWidth = 1;
            colClave.HeaderText = "Clave";
            colClave.Name = "colClave";
            colClave.ReadOnly = true;
            colClave.Width = 60;
            // 
            // colNombre
            // 
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colNombre.DataPropertyName = "name";
            colNombre.DividerWidth = 1;
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            colNombre.Width = 75;
            // 
            // colDescripcion
            // 
            colDescripcion.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colDescripcion.DataPropertyName = "description";
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new Point(0, 424);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(841, 22);
            statusStrip1.TabIndex = 11;
            statusStrip1.Text = "statusStrip1";
            // 
            // ToolStrip
            // 
            ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            ToolStrip.Items.AddRange(new ToolStripItem[] { BFilter, BGenerate, toolStripSeparator4, BSearch });
            ToolStrip.Location = new Point(0, 0);
            ToolStrip.Name = "ToolStrip";
            ToolStrip.RenderMode = ToolStripRenderMode.System;
            ToolStrip.Size = new Size(841, 40);
            ToolStrip.TabIndex = 12;
            ToolStrip.Text = "toolStrip1";
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
            // BGenerate
            // 
            BGenerate.Image = Properties.Resources.Fatcow_Farm_Fresh_Printer_16;
            BGenerate.ImageTransparentColor = Color.Magenta;
            BGenerate.Margin = new Padding(1, 2, 1, 2);
            BGenerate.Name = "BGenerate";
            BGenerate.Padding = new Padding(2, 8, 2, 8);
            BGenerate.Size = new Size(72, 36);
            BGenerate.Text = "&Generar";
            BGenerate.Click += BGenerate_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Alignment = ToolStripItemAlignment.Right;
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 40);
            toolStripSeparator4.Visible = false;
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
            // FReportList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 446);
            Controls.Add(DataGridReports);
            Controls.Add(ToolStrip);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FReportList";
            Text = "Reportes";
            Load += FReportList_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridReports).EndInit();
            ToolStrip.ResumeLayout(false);
            ToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView DataGridReports;
        private DataGridViewTextBoxColumn colClave;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDescripcion;
        private StatusStrip statusStrip1;
        private ToolStrip ToolStrip;
        private ToolStripButton BFilter;
        private ToolStripButton BGenerate;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton BSearch;
    }
}