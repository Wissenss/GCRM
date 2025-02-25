namespace GCRM
{
	partial class FCitizenNetworkData
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
			treeView1 = new TreeView();
			PanelMembers = new Panel();
			splitContainer1 = new SplitContainer();
			DataGridCitizens = new DataGridView();
			ToolStripMembers = new ToolStrip();
			toolStripLabel1 = new ToolStripLabel();
			BAdd = new ToolStripButton();
			LName = new Label();
			TextBoxName = new TextBox();
			label1 = new Label();
			comboBox1 = new ComboBox();
			LLeadCitizenName = new Label();
			BCancel = new Button();
			BAccept = new Button();
			BSelectLeadCitizen = new Button();
			BDelete = new ToolStripButton();
			PanelMembers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridCitizens).BeginInit();
			ToolStripMembers.SuspendLayout();
			SuspendLayout();
			// 
			// treeView1
			// 
			treeView1.BackColor = SystemColors.Control;
			treeView1.BorderStyle = BorderStyle.None;
			treeView1.Dock = DockStyle.Fill;
			treeView1.Location = new Point(0, 0);
			treeView1.Name = "treeView1";
			treeView1.Size = new Size(335, 354);
			treeView1.TabIndex = 0;
			// 
			// PanelMembers
			// 
			PanelMembers.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			PanelMembers.BorderStyle = BorderStyle.FixedSingle;
			PanelMembers.Controls.Add(splitContainer1);
			PanelMembers.Controls.Add(ToolStripMembers);
			PanelMembers.Location = new Point(12, 95);
			PanelMembers.Name = "PanelMembers";
			PanelMembers.Size = new Size(597, 381);
			PanelMembers.TabIndex = 1;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 25);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(DataGridCitizens);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(treeView1);
			splitContainer1.Size = new Size(595, 354);
			splitContainer1.SplitterDistance = 256;
			splitContainer1.TabIndex = 2;
			// 
			// DataGridCitizens
			// 
			DataGridCitizens.AllowUserToAddRows = false;
			DataGridCitizens.AllowUserToDeleteRows = false;
			DataGridCitizens.AllowUserToOrderColumns = true;
			DataGridCitizens.AllowUserToResizeRows = false;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
			DataGridCitizens.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			DataGridCitizens.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridCitizens.BackgroundColor = SystemColors.Control;
			DataGridCitizens.BorderStyle = BorderStyle.None;
			DataGridCitizens.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridCitizens.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridCitizens.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			DataGridCitizens.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			DataGridCitizens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Window;
			dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
			DataGridCitizens.DefaultCellStyle = dataGridViewCellStyle6;
			DataGridCitizens.Dock = DockStyle.Fill;
			DataGridCitizens.EnableHeadersVisualStyles = false;
			DataGridCitizens.Location = new Point(0, 0);
			DataGridCitizens.MultiSelect = false;
			DataGridCitizens.Name = "DataGridCitizens";
			DataGridCitizens.ReadOnly = true;
			DataGridCitizens.RowHeadersVisible = false;
			DataGridCitizens.RowTemplate.Height = 20;
			DataGridCitizens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridCitizens.ShowCellToolTips = false;
			DataGridCitizens.Size = new Size(256, 354);
			DataGridCitizens.StandardTab = true;
			DataGridCitizens.TabIndex = 8;
			// 
			// ToolStripMembers
			// 
			ToolStripMembers.GripStyle = ToolStripGripStyle.Hidden;
			ToolStripMembers.Items.AddRange(new ToolStripItem[] { toolStripLabel1, BDelete, BAdd });
			ToolStripMembers.Location = new Point(0, 0);
			ToolStripMembers.Name = "ToolStripMembers";
			ToolStripMembers.RenderMode = ToolStripRenderMode.System;
			ToolStripMembers.Size = new Size(595, 25);
			ToolStripMembers.TabIndex = 1;
			ToolStripMembers.Text = "Miembros";
			// 
			// toolStripLabel1
			// 
			toolStripLabel1.Name = "toolStripLabel1";
			toolStripLabel1.Size = new Size(61, 22);
			toolStripLabel1.Text = "Miembros";
			// 
			// BAdd
			// 
			BAdd.Alignment = ToolStripItemAlignment.Right;
			BAdd.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
			BAdd.ImageScaling = ToolStripItemImageScaling.None;
			BAdd.ImageTransparentColor = Color.Magenta;
			BAdd.Name = "BAdd";
			BAdd.Size = new Size(62, 22);
			BAdd.Text = "&Añadir";
			// 
			// LName
			// 
			LName.AutoSize = true;
			LName.Location = new Point(11, 15);
			LName.Name = "LName";
			LName.Size = new Size(51, 15);
			LName.TabIndex = 25;
			LName.Text = "Nombre";
			// 
			// TextBoxName
			// 
			TextBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxName.Location = new Point(68, 12);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(541, 23);
			TextBoxName.TabIndex = 24;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(13, 44);
			label1.Name = "label1";
			label1.Size = new Size(33, 15);
			label1.TabIndex = 26;
			label1.Text = "Lider";
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Location = new Point(68, 41);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(255, 23);
			comboBox1.TabIndex = 27;
			// 
			// LLeadCitizenName
			// 
			LLeadCitizenName.AutoSize = true;
			LLeadCitizenName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LLeadCitizenName.ForeColor = SystemColors.HotTrack;
			LLeadCitizenName.Location = new Point(68, 72);
			LLeadCitizenName.Name = "LLeadCitizenName";
			LLeadCitizenName.Size = new Size(64, 15);
			LLeadCitizenName.TabIndex = 36;
			LLeadCitizenName.Text = "Ciudadano";
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(534, 482);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 38;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(456, 482);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 37;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			// 
			// BSelectLeadCitizen
			// 
			BSelectLeadCitizen.Location = new Point(329, 41);
			BSelectLeadCitizen.Name = "BSelectLeadCitizen";
			BSelectLeadCitizen.Size = new Size(80, 23);
			BSelectLeadCitizen.TabIndex = 39;
			BSelectLeadCitizen.Text = "Seleccionar";
			BSelectLeadCitizen.UseVisualStyleBackColor = true;
			// 
			// BDelete
			// 
			BDelete.Alignment = ToolStripItemAlignment.Right;
			BDelete.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete_16;
			BDelete.ImageTransparentColor = Color.Magenta;
			BDelete.Name = "BDelete";
			BDelete.Size = new Size(59, 22);
			BDelete.Text = "&Borrar";
			// 
			// FCitizenNetworkData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(621, 517);
			Controls.Add(BSelectLeadCitizen);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Controls.Add(LLeadCitizenName);
			Controls.Add(comboBox1);
			Controls.Add(label1);
			Controls.Add(LName);
			Controls.Add(TextBoxName);
			Controls.Add(PanelMembers);
			Name = "FCitizenNetworkData";
			ShowIcon = false;
			Text = "Estructura - Nueva";
			PanelMembers.ResumeLayout(false);
			PanelMembers.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)DataGridCitizens).EndInit();
			ToolStripMembers.ResumeLayout(false);
			ToolStripMembers.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TreeView treeView1;
		private Panel PanelMembers;
		private ToolStrip ToolStripMembers;
		private ToolStripLabel toolStripLabel1;
		private SplitContainer splitContainer1;
		private DataGridView DataGridCitizens;
		private Label LName;
		private TextBox TextBoxName;
		private Label label1;
		private ComboBox comboBox1;
		private Label LLeadCitizenName;
		private Button BCancel;
		private Button BAccept;
		private Button BSelectLeadCitizen;
		private ToolStripButton BAdd;
		private ToolStripButton BDelete;
	}
}