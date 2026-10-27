namespace GCRM
{
	partial class FColumnChooser
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            BAccept = new Button();
            BCancel = new Button();
            DataGridColumns = new DataGridView();
            colName = new DataGridViewTextBoxColumn();
            colIndex = new DataGridViewTextBoxColumn();
            colVisible = new DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DataGridColumns).BeginInit();
            SuspendLayout();
            // 
            // BAccept
            // 
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(178, 220);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 4;
            BAccept.Text = "&Aplicar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(259, 220);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 5;
            BCancel.Text = "&Cerrar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // DataGridColumns
            // 
            DataGridColumns.AllowUserToAddRows = false;
            DataGridColumns.AllowUserToDeleteRows = false;
            DataGridColumns.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
            DataGridColumns.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            DataGridColumns.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridColumns.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridColumns.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            DataGridColumns.BackgroundColor = SystemColors.Control;
            DataGridColumns.BorderStyle = BorderStyle.Fixed3D;
            DataGridColumns.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridColumns.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridColumns.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DataGridColumns.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DataGridColumns.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridColumns.Columns.AddRange(new DataGridViewColumn[] { colName, colIndex, colVisible });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            DataGridColumns.DefaultCellStyle = dataGridViewCellStyle4;
            DataGridColumns.EditMode = DataGridViewEditMode.EditOnEnter;
            DataGridColumns.EnableHeadersVisualStyles = false;
            DataGridColumns.Location = new Point(12, 12);
            DataGridColumns.MultiSelect = false;
            DataGridColumns.Name = "DataGridColumns";
            DataGridColumns.RowHeadersVisible = false;
            DataGridColumns.RowTemplate.Height = 20;
            DataGridColumns.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridColumns.ShowCellToolTips = false;
            DataGridColumns.Size = new Size(322, 202);
            DataGridColumns.StandardTab = true;
            DataGridColumns.TabIndex = 8;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "name";
            colName.HeaderText = "Columna";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colIndex
            // 
            colIndex.DataPropertyName = "index";
            colIndex.HeaderText = "Index";
            colIndex.Name = "colIndex";
            colIndex.ReadOnly = true;
            colIndex.Visible = false;
            // 
            // colVisible
            // 
            colVisible.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colVisible.DataPropertyName = "visible";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.NullValue = false;
            colVisible.DefaultCellStyle = dataGridViewCellStyle3;
            colVisible.FlatStyle = FlatStyle.System;
            colVisible.HeaderText = "";
            colVisible.MinimumWidth = 25;
            colVisible.Name = "colVisible";
            colVisible.Resizable = DataGridViewTriState.False;
            colVisible.Width = 25;
            // 
            // FColumnChooser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 255);
            ControlBox = false;
            Controls.Add(DataGridColumns);
            Controls.Add(BAccept);
            Controls.Add(BCancel);
            Name = "FColumnChooser";
            ShowIcon = false;
            Text = "Columnas";
            Load += FColumnChooser_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridColumns).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button BAccept;
		private Button BCancel;
		private DataGridView DataGridColumns;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colIndex;
		private DataGridViewCheckBoxColumn colVisible;
	}
}