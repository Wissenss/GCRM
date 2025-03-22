namespace GCRM
{
	partial class FQueries
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
			DataGridResults = new DataGridView();
			panel1 = new Panel();
			BExport = new Button();
			BRun = new Button();
			ComboBoxQueries = new ComboBox();
			LQueries = new Label();
			StatusStrip = new StatusStrip();
			TSSLRecordCount = new ToolStripStatusLabel();
			SaveFileDialog = new SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)DataGridResults).BeginInit();
			panel1.SuspendLayout();
			StatusStrip.SuspendLayout();
			SuspendLayout();
			// 
			// DataGridResults
			// 
			DataGridResults.AllowUserToAddRows = false;
			DataGridResults.AllowUserToDeleteRows = false;
			DataGridResults.AllowUserToOrderColumns = true;
			DataGridResults.AllowUserToResizeRows = false;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
			DataGridResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			DataGridResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridResults.BackgroundColor = SystemColors.ControlLight;
			DataGridResults.BorderStyle = BorderStyle.None;
			DataGridResults.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridResults.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			DataGridResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			DataGridResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Window;
			dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
			DataGridResults.DefaultCellStyle = dataGridViewCellStyle6;
			DataGridResults.Dock = DockStyle.Fill;
			DataGridResults.EnableHeadersVisualStyles = false;
			DataGridResults.Location = new Point(0, 44);
			DataGridResults.MultiSelect = false;
			DataGridResults.Name = "DataGridResults";
			DataGridResults.ReadOnly = true;
			DataGridResults.RowHeadersVisible = false;
			DataGridResults.RowTemplate.Height = 20;
			DataGridResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridResults.ShowCellToolTips = false;
			DataGridResults.Size = new Size(489, 282);
			DataGridResults.StandardTab = true;
			DataGridResults.TabIndex = 10;
			// 
			// panel1
			// 
			panel1.Controls.Add(BExport);
			panel1.Controls.Add(BRun);
			panel1.Controls.Add(ComboBoxQueries);
			panel1.Controls.Add(LQueries);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(489, 44);
			panel1.TabIndex = 11;
			// 
			// BExport
			// 
			BExport.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BExport.Location = new Point(402, 10);
			BExport.Name = "BExport";
			BExport.Size = new Size(75, 23);
			BExport.TabIndex = 3;
			BExport.Text = "Exportar";
			BExport.UseVisualStyleBackColor = true;
			BExport.Click += BExport_Click;
			// 
			// BRun
			// 
			BRun.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			BRun.Location = new Point(321, 9);
			BRun.Name = "BRun";
			BRun.Size = new Size(75, 23);
			BRun.TabIndex = 2;
			BRun.Text = "Ejecutar";
			BRun.UseVisualStyleBackColor = true;
			BRun.Click += BRun_Click;
			// 
			// ComboBoxQueries
			// 
			ComboBoxQueries.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			ComboBoxQueries.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxQueries.FormattingEnabled = true;
			ComboBoxQueries.Location = new Point(72, 10);
			ComboBoxQueries.Name = "ComboBoxQueries";
			ComboBoxQueries.Size = new Size(243, 23);
			ComboBoxQueries.TabIndex = 1;
			ComboBoxQueries.TextChanged += ComboBoxQueries_TextChanged;
			// 
			// LQueries
			// 
			LQueries.AutoSize = true;
			LQueries.Location = new Point(12, 14);
			LQueries.Name = "LQueries";
			LQueries.Size = new Size(54, 15);
			LQueries.TabIndex = 0;
			LQueries.Text = "Consulta";
			// 
			// StatusStrip
			// 
			StatusStrip.Items.AddRange(new ToolStripItem[] { TSSLRecordCount });
			StatusStrip.Location = new Point(0, 326);
			StatusStrip.Name = "StatusStrip";
			StatusStrip.Size = new Size(489, 22);
			StatusStrip.TabIndex = 12;
			StatusStrip.Text = "statusStrip1";
			// 
			// TSSLRecordCount
			// 
			TSSLRecordCount.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			TSSLRecordCount.Name = "TSSLRecordCount";
			TSSLRecordCount.Size = new Size(174, 17);
			TSSLRecordCount.Text = "524 registros obtenidos en 53 ms";
			TSSLRecordCount.Visible = false;
			// 
			// FQueries
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(489, 348);
			Controls.Add(DataGridResults);
			Controls.Add(panel1);
			Controls.Add(StatusStrip);
			MaximumSize = new Size(1920, 1080);
			MinimumSize = new Size(505, 387);
			Name = "FQueries";
			ShowIcon = false;
			Text = "Consultas";
			Load += FQueries_Load;
			((System.ComponentModel.ISupportInitialize)DataGridResults).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			StatusStrip.ResumeLayout(false);
			StatusStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView DataGridResults;
		private Panel panel1;
		private Button BRun;
		private ComboBox ComboBoxQueries;
		private Label LQueries;
		private StatusStrip StatusStrip;
		private ToolStripStatusLabel TSSLRecordCount;
		private Button BExport;
		private SaveFileDialog SaveFileDialog;
	}
}