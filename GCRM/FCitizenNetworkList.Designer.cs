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
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
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
			toolStripSeparator1 = new ToolStripSeparator();
			BPrint = new ToolStripButton();
			toolStripSeparator2 = new ToolStripSeparator();
			BShowStructure = new ToolStripButton();
			BExcelExport = new ToolStripButton();
			splitContainer1 = new SplitContainer();
			TreeViewNetwroksStructure = new TreeView();
			panel1 = new Panel();
			label2 = new Label();
			SaveFileDialog = new SaveFileDialog();
			((System.ComponentModel.ISupportInitialize)DataGridCitizenNetworks).BeginInit();
			StatusStrip.SuspendLayout();
			ToolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			panel1.SuspendLayout();
			SuspendLayout();
			// 
			// DataGridCitizenNetworks
			// 
			DataGridCitizenNetworks.AllowUserToAddRows = false;
			DataGridCitizenNetworks.AllowUserToDeleteRows = false;
			DataGridCitizenNetworks.AllowUserToOrderColumns = true;
			DataGridCitizenNetworks.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			DataGridCitizenNetworks.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridCitizenNetworks.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridCitizenNetworks.BackgroundColor = SystemColors.Control;
			DataGridCitizenNetworks.BorderStyle = BorderStyle.None;
			DataGridCitizenNetworks.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridCitizenNetworks.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridCitizenNetworks.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridCitizenNetworks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridCitizenNetworks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGridCitizenNetworks.DefaultCellStyle = dataGridViewCellStyle3;
			DataGridCitizenNetworks.Dock = DockStyle.Fill;
			DataGridCitizenNetworks.EnableHeadersVisualStyles = false;
			DataGridCitizenNetworks.Location = new Point(0, 0);
			DataGridCitizenNetworks.MultiSelect = false;
			DataGridCitizenNetworks.Name = "DataGridCitizenNetworks";
			DataGridCitizenNetworks.ReadOnly = true;
			DataGridCitizenNetworks.RowHeadersVisible = false;
			DataGridCitizenNetworks.RowTemplate.Height = 20;
			DataGridCitizenNetworks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridCitizenNetworks.ShowCellToolTips = false;
			DataGridCitizenNetworks.Size = new Size(494, 388);
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
			ToolStrip.Items.AddRange(new ToolStripItem[] { BAdd, BEdit, BRead, BRefresh, BDelete, toolStripSeparator1, BPrint, toolStripSeparator2, BShowStructure, BExcelExport });
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
			BDelete.Click += BDelete_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 40);
			// 
			// BPrint
			// 
			BPrint.Image = Properties.Resources.Fatcow_Farm_Fresh_Printer_16;
			BPrint.ImageScaling = ToolStripItemImageScaling.None;
			BPrint.ImageTransparentColor = Color.Magenta;
			BPrint.Name = "BPrint";
			BPrint.Size = new Size(73, 37);
			BPrint.Text = "Im&primir";
			BPrint.Click += BPrint_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Alignment = ToolStripItemAlignment.Right;
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 40);
			toolStripSeparator2.Visible = false;
			// 
			// BShowStructure
			// 
			BShowStructure.Alignment = ToolStripItemAlignment.Right;
			BShowStructure.Checked = true;
			BShowStructure.CheckOnClick = true;
			BShowStructure.CheckState = CheckState.Checked;
			BShowStructure.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_16;
			BShowStructure.ImageTransparentColor = Color.Magenta;
			BShowStructure.Name = "BShowStructure";
			BShowStructure.Size = new Size(99, 37);
			BShowStructure.Text = "&Ver Estructura";
			BShowStructure.Visible = false;
			BShowStructure.Click += BShowStructure_Click;
			// 
			// BExcelExport
			// 
			BExcelExport.Image = Properties.Resources.Fatcow_Farm_Fresh_Export_excel_16;
			BExcelExport.ImageScaling = ToolStripItemImageScaling.None;
			BExcelExport.ImageTransparentColor = Color.Magenta;
			BExcelExport.Name = "BExcelExport";
			BExcelExport.Size = new Size(70, 37);
			BExcelExport.Text = "E&xportar";
			BExcelExport.Click += BExcelExport_Click;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 40);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(DataGridCitizenNetworks);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(TreeViewNetwroksStructure);
			splitContainer1.Panel2.Controls.Add(panel1);
			splitContainer1.Size = new Size(800, 388);
			splitContainer1.SplitterDistance = 494;
			splitContainer1.TabIndex = 12;
			// 
			// TreeViewNetwroksStructure
			// 
			TreeViewNetwroksStructure.AllowDrop = true;
			TreeViewNetwroksStructure.BackColor = SystemColors.Control;
			TreeViewNetwroksStructure.BorderStyle = BorderStyle.None;
			TreeViewNetwroksStructure.Dock = DockStyle.Fill;
			TreeViewNetwroksStructure.DrawMode = TreeViewDrawMode.OwnerDrawText;
			TreeViewNetwroksStructure.FullRowSelect = true;
			TreeViewNetwroksStructure.HideSelection = false;
			TreeViewNetwroksStructure.Location = new Point(0, 17);
			TreeViewNetwroksStructure.Name = "TreeViewNetwroksStructure";
			TreeViewNetwroksStructure.Size = new Size(302, 371);
			TreeViewNetwroksStructure.TabIndex = 4;
			TreeViewNetwroksStructure.DrawNode += TreeViewNetwroksStructure_DrawNode;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ControlLight;
			panel1.Controls.Add(label2);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(302, 17);
			panel1.TabIndex = 3;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Dock = DockStyle.Fill;
			label2.Location = new Point(0, 0);
			label2.Name = "label2";
			label2.Size = new Size(60, 15);
			label2.TabIndex = 2;
			label2.Text = "Estructura";
			// 
			// FCitizenNetworkList
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(splitContainer1);
			Controls.Add(StatusStrip);
			Controls.Add(ToolStrip);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Name = "FCitizenNetworkList";
			Text = "Estructuras";
			Load += FCitizenNetworkList_Load;
			((System.ComponentModel.ISupportInitialize)DataGridCitizenNetworks).EndInit();
			StatusStrip.ResumeLayout(false);
			StatusStrip.PerformLayout();
			ToolStrip.ResumeLayout(false);
			ToolStrip.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
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
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton BPrint;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton BShowStructure;
		private SplitContainer splitContainer1;
		private Panel panel1;
		private Label label2;
		private TreeView TreeViewNetwroksStructure;
		private ToolStripButton BExcelExport;
		private SaveFileDialog SaveFileDialog;
	}
}