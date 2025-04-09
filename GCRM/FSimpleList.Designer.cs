namespace GCRM
{
	partial class FSimpleList
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
			DataGridSimpleList = new DataGridView();
			((System.ComponentModel.ISupportInitialize)DataGridSimpleList).BeginInit();
			SuspendLayout();
			// 
			// DataGridSimpleList
			// 
			DataGridSimpleList.AllowUserToAddRows = false;
			DataGridSimpleList.AllowUserToDeleteRows = false;
			DataGridSimpleList.AllowUserToOrderColumns = true;
			DataGridSimpleList.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			DataGridSimpleList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridSimpleList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridSimpleList.BackgroundColor = SystemColors.Control;
			DataGridSimpleList.BorderStyle = BorderStyle.None;
			DataGridSimpleList.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridSimpleList.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridSimpleList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridSimpleList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridSimpleList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGridSimpleList.DefaultCellStyle = dataGridViewCellStyle3;
			DataGridSimpleList.Dock = DockStyle.Fill;
			DataGridSimpleList.EnableHeadersVisualStyles = false;
			DataGridSimpleList.ImeMode = ImeMode.NoControl;
			DataGridSimpleList.Location = new Point(0, 0);
			DataGridSimpleList.MultiSelect = false;
			DataGridSimpleList.Name = "DataGridSimpleList";
			DataGridSimpleList.ReadOnly = true;
			DataGridSimpleList.RowHeadersVisible = false;
			DataGridSimpleList.RowTemplate.Height = 20;
			DataGridSimpleList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridSimpleList.ShowCellToolTips = false;
			DataGridSimpleList.Size = new Size(582, 305);
			DataGridSimpleList.StandardTab = true;
			DataGridSimpleList.TabIndex = 9;
			// 
			// FSimpleList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(582, 305);
			Controls.Add(DataGridSimpleList);
			Name = "FSimpleList";
			ShowIcon = false;
			Text = "Lista simple";
			((System.ComponentModel.ISupportInitialize)DataGridSimpleList).EndInit();
			ResumeLayout(false);
		}

		#endregion

		public DataGridView DataGridSimpleList;
	}
}