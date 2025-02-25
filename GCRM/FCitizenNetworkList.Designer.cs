namespace GCRM
{
	partial class FCitizenNetworkList
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FCitizenNetworkList));
			DataGridCitizenNetworks = new DataGridView();
			StatusStrip = new StatusStrip();
			TSSLRecordCount = new ToolStripStatusLabel();
			ToolStrip = new ToolStrip();
			BAdd = new ToolStripButton();
			BEdit = new ToolStripButton();
			BRead = new ToolStripButton();
			BRefresh = new ToolStripButton();
			BDelete = new ToolStripButton();
			((System.ComponentModel.ISupportInitialize)DataGridCitizenNetworks).BeginInit();
			StatusStrip.SuspendLayout();
			ToolStrip.SuspendLayout();
			SuspendLayout();
			// 
			// DataGridCitizenNetworks
			// 
			DataGridCitizenNetworks.AllowUserToAddRows = false;
			DataGridCitizenNetworks.AllowUserToDeleteRows = false;
			DataGridCitizenNetworks.AllowUserToOrderColumns = true;
			DataGridCitizenNetworks.AllowUserToResizeRows = false;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
			DataGridCitizenNetworks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			DataGridCitizenNetworks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridCitizenNetworks.BackgroundColor = SystemColors.Control;
			DataGridCitizenNetworks.BorderStyle = BorderStyle.None;
			DataGridCitizenNetworks.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridCitizenNetworks.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridCitizenNetworks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			DataGridCitizenNetworks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			DataGridCitizenNetworks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Window;
			dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
			DataGridCitizenNetworks.DefaultCellStyle = dataGridViewCellStyle6;
			DataGridCitizenNetworks.Dock = DockStyle.Fill;
			DataGridCitizenNetworks.EnableHeadersVisualStyles = false;
			DataGridCitizenNetworks.Location = new Point(0, 40);
			DataGridCitizenNetworks.MultiSelect = false;
			DataGridCitizenNetworks.Name = "DataGridCitizenNetworks";
			DataGridCitizenNetworks.ReadOnly = true;
			DataGridCitizenNetworks.RowHeadersVisible = false;
			DataGridCitizenNetworks.RowTemplate.Height = 20;
			DataGridCitizenNetworks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridCitizenNetworks.ShowCellToolTips = false;
			DataGridCitizenNetworks.Size = new Size(800, 388);
			DataGridCitizenNetworks.StandardTab = true;
			DataGridCitizenNetworks.TabIndex = 10;
			// 
			// StatusStrip
			// 
			StatusStrip.Items.AddRange(new ToolStripItem[] { TSSLRecordCount });
			StatusStrip.Location = new Point(0, 428);
			StatusStrip.Name = "StatusStrip";
			StatusStrip.Size = new Size(800, 22);
			StatusStrip.TabIndex = 11;
			StatusStrip.Text = "statusStrip1";
			// 
			// TSSLRecordCount
			// 
			TSSLRecordCount.Font = new Font("Segoe UI Variable Small Light", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
			TSSLRecordCount.Name = "TSSLRecordCount";
			TSSLRecordCount.Size = new Size(78, 17);
			TSSLRecordCount.Text = "Registros: 524";
			// 
			// ToolStrip
			// 
			ToolStrip.GripStyle = ToolStripGripStyle.Hidden;
			ToolStrip.Items.AddRange(new ToolStripItem[] { BAdd, BEdit, BRead, BRefresh, BDelete });
			ToolStrip.Location = new Point(0, 0);
			ToolStrip.Name = "ToolStrip";
			ToolStrip.RenderMode = ToolStripRenderMode.System;
			ToolStrip.Size = new Size(800, 40);
			ToolStrip.TabIndex = 9;
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
			BDelete.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete_16;
			BDelete.ImageScaling = ToolStripItemImageScaling.None;
			BDelete.ImageTransparentColor = Color.Magenta;
			BDelete.Name = "BDelete";
			BDelete.Size = new Size(59, 37);
			BDelete.Text = "&Borrar";
			// 
			// FCitizenNetworkList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(DataGridCitizenNetworks);
			Controls.Add(StatusStrip);
			Controls.Add(ToolStrip);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FCitizenNetworkList";
			Text = "Estructuras";
			((System.ComponentModel.ISupportInitialize)DataGridCitizenNetworks).EndInit();
			StatusStrip.ResumeLayout(false);
			StatusStrip.PerformLayout();
			ToolStrip.ResumeLayout(false);
			ToolStrip.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private DataGridView DataGridCitizenNetworks;
		private StatusStrip StatusStrip;
		private ToolStripStatusLabel TSSLRecordCount;
		private ToolStrip ToolStrip;
		private ToolStripButton BAdd;
		private ToolStripButton BEdit;
		private ToolStripButton BRead;
		private ToolStripButton BRefresh;
		private ToolStripButton BDelete;
	}
}