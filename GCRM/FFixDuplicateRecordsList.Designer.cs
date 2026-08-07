namespace GCRM
{
	partial class FFixDuplicateRecordsList
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
            DataGridFixDuplicateRecordsList = new DataGridView();
            StatusStrip = new StatusStrip();
            ToolStrip = new ToolStrip();
            BAttentionRequired = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)DataGridFixDuplicateRecordsList).BeginInit();
            ToolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // DataGridFixDuplicateRecordsList
            // 
            DataGridFixDuplicateRecordsList.AllowUserToAddRows = false;
            DataGridFixDuplicateRecordsList.AllowUserToDeleteRows = false;
            DataGridFixDuplicateRecordsList.AllowUserToOrderColumns = true;
            DataGridFixDuplicateRecordsList.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            DataGridFixDuplicateRecordsList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            DataGridFixDuplicateRecordsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridFixDuplicateRecordsList.BackgroundColor = SystemColors.Control;
            DataGridFixDuplicateRecordsList.BorderStyle = BorderStyle.None;
            DataGridFixDuplicateRecordsList.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridFixDuplicateRecordsList.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridFixDuplicateRecordsList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            DataGridFixDuplicateRecordsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            DataGridFixDuplicateRecordsList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            DataGridFixDuplicateRecordsList.DefaultCellStyle = dataGridViewCellStyle6;
            DataGridFixDuplicateRecordsList.Dock = DockStyle.Fill;
            DataGridFixDuplicateRecordsList.EnableHeadersVisualStyles = false;
            DataGridFixDuplicateRecordsList.ImeMode = ImeMode.NoControl;
            DataGridFixDuplicateRecordsList.Location = new Point(0, 28);
            DataGridFixDuplicateRecordsList.MultiSelect = false;
            DataGridFixDuplicateRecordsList.Name = "DataGridFixDuplicateRecordsList";
            DataGridFixDuplicateRecordsList.ReadOnly = true;
            DataGridFixDuplicateRecordsList.RowHeadersVisible = false;
            DataGridFixDuplicateRecordsList.RowTemplate.Height = 20;
            DataGridFixDuplicateRecordsList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridFixDuplicateRecordsList.ShowCellToolTips = false;
            DataGridFixDuplicateRecordsList.Size = new Size(582, 255);
            DataGridFixDuplicateRecordsList.StandardTab = true;
            DataGridFixDuplicateRecordsList.TabIndex = 9;
            DataGridFixDuplicateRecordsList.CellFormatting += DataGridFixDuplicateRecordsList_CellFormatting;
            DataGridFixDuplicateRecordsList.SelectionChanged += DataGridFixDuplicateRecordsList_SelectionChanged;
            //
            // StatusStrip
            // 
            StatusStrip.Location = new Point(0, 283);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(582, 22);
            StatusStrip.TabIndex = 10;
            StatusStrip.Text = "statusStrip1";
            // 
            // ToolStrip
            // 
            ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
            ToolStrip.Items.AddRange(new ToolStripItem[] { BAttentionRequired });
            ToolStrip.Location = new Point(0, 0);
            ToolStrip.Name = "ToolStrip";
            ToolStrip.RenderMode = ToolStripRenderMode.System;
            ToolStrip.Size = new Size(582, 28);
            ToolStrip.TabIndex = 11;
            ToolStrip.Text = "toolStrip1";
            // 
            // BAttentionRequired
            // 
            BAttentionRequired.Image = Properties.Resources.Fatcow_Farm_Fresh_Bookmark_red_16;
            BAttentionRequired.ImageTransparentColor = Color.Magenta;
            BAttentionRequired.Margin = new Padding(1, 2, 1, 2);
            BAttentionRequired.Name = "BAttentionRequired";
            BAttentionRequired.Padding = new Padding(0, 2, 0, 2);
            BAttentionRequired.Size = new Size(123, 24);
            BAttentionRequired.Text = "Necesita Atención";
            BAttentionRequired.Click += BAttentionRequired_Click;
            //
            // FFixDuplicateRecordsList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 305);
            Controls.Add(DataGridFixDuplicateRecordsList);
            Controls.Add(StatusStrip);
            Controls.Add(ToolStrip);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FFixDuplicateRecordsList";
            ShowIcon = false;
            Text = "Registros duplicados";
            Load += FFixDuplicateRecordsList_Load;
            ((System.ComponentModel.ISupportInitialize)DataGridFixDuplicateRecordsList).EndInit();
            ToolStrip.ResumeLayout(false);
            ToolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView DataGridFixDuplicateRecordsList;
        private StatusStrip StatusStrip;
        private ToolStrip ToolStrip;
        private ToolStripButton BAttentionRequired;
    }
}
