namespace GCRM
{
	partial class FEmailList
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
			ToolStrip = new ToolStrip();
			BAdd = new ToolStripButton();
			BEdit = new ToolStripButton();
			BRead = new ToolStripButton();
			BRefresh = new ToolStripButton();
			BDelete = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			BWebmail = new ToolStripButton();
			DataGridEmails = new DataGridView();
			ToolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridEmails).BeginInit();
			SuspendLayout();
			// 
			// ToolStrip
			// 
			ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
			ToolStrip.Items.AddRange(new ToolStripItem[] { BAdd, BEdit, BRead, BRefresh, BDelete, toolStripSeparator1, BWebmail });
			ToolStrip.Location = new Point(0, 0);
			ToolStrip.Name = "ToolStrip";
			ToolStrip.RenderMode = ToolStripRenderMode.System;
			ToolStrip.Size = new Size(800, 40);
			ToolStrip.TabIndex = 5;
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
			BEdit.Visible = false;
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
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 40);
			// 
			// BWebmail
			// 
			BWebmail.Image = Properties.Resources.Fatcow_Farm_Fresh_Earth_night_16;
			BWebmail.ImageScaling = ToolStripItemImageScaling.None;
			BWebmail.ImageTransparentColor = Color.Magenta;
			BWebmail.Margin = new Padding(1, 2, 1, 2);
			BWebmail.Name = "BWebmail";
			BWebmail.Padding = new Padding(2, 8, 2, 8);
			BWebmail.Size = new Size(78, 36);
			BWebmail.Text = "Webmail";
			BWebmail.Click += BWebmail_Click;
			// 
			// DataGridEmails
			// 
			DataGridEmails.AllowUserToAddRows = false;
			DataGridEmails.AllowUserToDeleteRows = false;
			DataGridEmails.AllowUserToOrderColumns = true;
			DataGridEmails.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			DataGridEmails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridEmails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridEmails.BackgroundColor = SystemColors.Control;
			DataGridEmails.BorderStyle = BorderStyle.None;
			DataGridEmails.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridEmails.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridEmails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridEmails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridEmails.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGridEmails.DefaultCellStyle = dataGridViewCellStyle3;
			DataGridEmails.Dock = DockStyle.Fill;
			DataGridEmails.EnableHeadersVisualStyles = false;
			DataGridEmails.Location = new Point(0, 40);
			DataGridEmails.MultiSelect = false;
			DataGridEmails.Name = "DataGridEmails";
			DataGridEmails.ReadOnly = true;
			DataGridEmails.RowHeadersVisible = false;
			DataGridEmails.RowTemplate.Height = 20;
			DataGridEmails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridEmails.ShowCellToolTips = false;
			DataGridEmails.Size = new Size(800, 410);
			DataGridEmails.StandardTab = true;
			DataGridEmails.TabIndex = 8;
			// 
			// FEmailList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(DataGridEmails);
			Controls.Add(ToolStrip);
			Name = "FEmailList";
			ShowIcon = false;
			Text = "Emails";
			Load += FEmailList_Load;
			ToolStrip.ResumeLayout(false);
			ToolStrip.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DataGridEmails).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ToolStrip ToolStrip;
		private ToolStripButton BAdd;
		private ToolStripButton BEdit;
		private ToolStripButton BRead;
		private ToolStripButton BRefresh;
		private ToolStripButton BDelete;
		private DataGridView DataGridEmails;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton BWebmail;
	}
}