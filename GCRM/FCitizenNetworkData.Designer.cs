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
			DataGridViewCellStyle dataGridViewCellStyle25 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle26 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle27 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle28 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle29 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle30 = new DataGridViewCellStyle();
			TreeViewMembers = new TreeView();
			PanelMembers = new Panel();
			splitContainer1 = new SplitContainer();
			DataGridMembers = new DataGridView();
			panel1 = new Panel();
			label2 = new Label();
			StatusStripMembers = new StatusStrip();
			ToolStripMembers = new ToolStrip();
			BDown = new ToolStripButton();
			BUp = new ToolStripButton();
			BShowTree = new ToolStripButton();
			BAddMember = new ToolStripButton();
			BEditMember = new ToolStripButton();
			BReadMember = new ToolStripButton();
			BDeleteMember = new ToolStripButton();
			toolStripSeparator1 = new ToolStripSeparator();
			BPrint1x10 = new ToolStripButton();
			LName = new Label();
			TextBoxName = new TextBox();
			label1 = new Label();
			LLeadCitizenInfo = new Label();
			BCancel = new Button();
			BAccept = new Button();
			BSelectLeadCitizen = new Button();
			LDescription = new Label();
			TextBoxDescription = new TextBox();
			TabControlNetwork = new TabControl();
			TabMembers = new TabPage();
			TabRoles = new TabPage();
			DataGridRoles = new DataGridView();
			ToolStripRoles = new ToolStrip();
			BAddRole = new ToolStripButton();
			BEditRole = new ToolStripButton();
			BReadRole = new ToolStripButton();
			BDeleteRole = new ToolStripButton();
			TextBoxLeadCitizen = new TextBox();
			PanelMembers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
			splitContainer1.Panel1.SuspendLayout();
			splitContainer1.Panel2.SuspendLayout();
			splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridMembers).BeginInit();
			panel1.SuspendLayout();
			ToolStripMembers.SuspendLayout();
			TabControlNetwork.SuspendLayout();
			TabMembers.SuspendLayout();
			TabRoles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridRoles).BeginInit();
			ToolStripRoles.SuspendLayout();
			SuspendLayout();
			// 
			// TreeViewMembers
			// 
			TreeViewMembers.BackColor = SystemColors.Control;
			TreeViewMembers.BorderStyle = BorderStyle.None;
			TreeViewMembers.Dock = DockStyle.Fill;
			TreeViewMembers.Location = new Point(0, 17);
			TreeViewMembers.Name = "TreeViewMembers";
			TreeViewMembers.Size = new Size(644, 413);
			TreeViewMembers.TabIndex = 0;
			// 
			// PanelMembers
			// 
			PanelMembers.Controls.Add(splitContainer1);
			PanelMembers.Controls.Add(StatusStripMembers);
			PanelMembers.Controls.Add(ToolStripMembers);
			PanelMembers.Dock = DockStyle.Fill;
			PanelMembers.Location = new Point(2, 2);
			PanelMembers.Margin = new Padding(0);
			PanelMembers.Name = "PanelMembers";
			PanelMembers.Size = new Size(961, 483);
			PanelMembers.TabIndex = 1;
			// 
			// splitContainer1
			// 
			splitContainer1.Dock = DockStyle.Fill;
			splitContainer1.Location = new Point(0, 31);
			splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			splitContainer1.Panel1.Controls.Add(DataGridMembers);
			// 
			// splitContainer1.Panel2
			// 
			splitContainer1.Panel2.Controls.Add(TreeViewMembers);
			splitContainer1.Panel2.Controls.Add(panel1);
			splitContainer1.Size = new Size(961, 430);
			splitContainer1.SplitterDistance = 313;
			splitContainer1.TabIndex = 2;
			// 
			// DataGridMembers
			// 
			DataGridMembers.AllowUserToAddRows = false;
			DataGridMembers.AllowUserToDeleteRows = false;
			DataGridMembers.AllowUserToOrderColumns = true;
			DataGridMembers.AllowUserToResizeRows = false;
			dataGridViewCellStyle25.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle25.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle25.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle25.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle25.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle25.SelectionForeColor = SystemColors.ControlText;
			DataGridMembers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
			DataGridMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridMembers.BackgroundColor = SystemColors.Control;
			DataGridMembers.BorderStyle = BorderStyle.None;
			DataGridMembers.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridMembers.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle26.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle26.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle26.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle26.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle26.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle26.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle26.WrapMode = DataGridViewTriState.True;
			DataGridMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
			DataGridMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle27.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle27.BackColor = SystemColors.Window;
			dataGridViewCellStyle27.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle27.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle27.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle27.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle27.WrapMode = DataGridViewTriState.False;
			DataGridMembers.DefaultCellStyle = dataGridViewCellStyle27;
			DataGridMembers.Dock = DockStyle.Fill;
			DataGridMembers.EnableHeadersVisualStyles = false;
			DataGridMembers.Location = new Point(0, 0);
			DataGridMembers.MultiSelect = false;
			DataGridMembers.Name = "DataGridMembers";
			DataGridMembers.ReadOnly = true;
			DataGridMembers.RowHeadersVisible = false;
			DataGridMembers.RowTemplate.Height = 20;
			DataGridMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridMembers.ShowCellToolTips = false;
			DataGridMembers.Size = new Size(313, 430);
			DataGridMembers.StandardTab = true;
			DataGridMembers.TabIndex = 8;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ControlLight;
			panel1.Controls.Add(label2);
			panel1.Dock = DockStyle.Top;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(644, 17);
			panel1.TabIndex = 2;
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
			// StatusStripMembers
			// 
			StatusStripMembers.Location = new Point(0, 461);
			StatusStripMembers.Name = "StatusStripMembers";
			StatusStripMembers.Size = new Size(961, 22);
			StatusStripMembers.TabIndex = 1;
			StatusStripMembers.Text = "statusStrip1";
			// 
			// ToolStripMembers
			// 
			ToolStripMembers.GripMargin = new Padding(0);
			ToolStripMembers.GripStyle = ToolStripGripStyle.Hidden;
			ToolStripMembers.Items.AddRange(new ToolStripItem[] { BDown, BUp, BShowTree, BAddMember, BEditMember, BReadMember, BDeleteMember, toolStripSeparator1, BPrint1x10 });
			ToolStripMembers.Location = new Point(0, 0);
			ToolStripMembers.Name = "ToolStripMembers";
			ToolStripMembers.RenderMode = ToolStripRenderMode.System;
			ToolStripMembers.Size = new Size(961, 31);
			ToolStripMembers.TabIndex = 1;
			ToolStripMembers.Text = "Miembros";
			// 
			// BDown
			// 
			BDown.Alignment = ToolStripItemAlignment.Right;
			BDown.DisplayStyle = ToolStripItemDisplayStyle.Image;
			BDown.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_arrow_down_24;
			BDown.ImageScaling = ToolStripItemImageScaling.None;
			BDown.ImageTransparentColor = Color.Magenta;
			BDown.Margin = new Padding(2, 1, 2, 2);
			BDown.Name = "BDown";
			BDown.Size = new Size(28, 28);
			BDown.Text = "Abajo";
			BDown.Visible = false;
			// 
			// BUp
			// 
			BUp.Alignment = ToolStripItemAlignment.Right;
			BUp.DisplayStyle = ToolStripItemDisplayStyle.Image;
			BUp.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_arrow_up_24;
			BUp.ImageScaling = ToolStripItemImageScaling.None;
			BUp.ImageTransparentColor = Color.Magenta;
			BUp.Margin = new Padding(2, 1, 2, 2);
			BUp.Name = "BUp";
			BUp.Size = new Size(28, 28);
			BUp.Text = "Arriba";
			BUp.Visible = false;
			// 
			// BShowTree
			// 
			BShowTree.Alignment = ToolStripItemAlignment.Right;
			BShowTree.Checked = true;
			BShowTree.CheckOnClick = true;
			BShowTree.CheckState = CheckState.Checked;
			BShowTree.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_24;
			BShowTree.ImageScaling = ToolStripItemImageScaling.None;
			BShowTree.ImageTransparentColor = Color.Magenta;
			BShowTree.Margin = new Padding(2, 1, 2, 2);
			BShowTree.Name = "BShowTree";
			BShowTree.Size = new Size(107, 28);
			BShowTree.Text = "&Ver Estructura";
			BShowTree.Visible = false;
			// 
			// BAddMember
			// 
			BAddMember.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_Add_24;
			BAddMember.ImageScaling = ToolStripItemImageScaling.None;
			BAddMember.ImageTransparentColor = Color.Magenta;
			BAddMember.Margin = new Padding(2, 1, 2, 2);
			BAddMember.Name = "BAddMember";
			BAddMember.Size = new Size(77, 28);
			BAddMember.Text = "&Agregar";
			BAddMember.Click += BAddMember_Click;
			// 
			// BEditMember
			// 
			BEditMember.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_design_24;
			BEditMember.ImageScaling = ToolStripItemImageScaling.None;
			BEditMember.ImageTransparentColor = Color.Magenta;
			BEditMember.Margin = new Padding(2, 1, 2, 2);
			BEditMember.Name = "BEditMember";
			BEditMember.Size = new Size(65, 28);
			BEditMember.Text = "&Editar";
			// 
			// BReadMember
			// 
			BReadMember.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_magnifier_24;
			BReadMember.ImageScaling = ToolStripItemImageScaling.None;
			BReadMember.ImageTransparentColor = Color.Magenta;
			BReadMember.Margin = new Padding(2, 1, 2, 2);
			BReadMember.Name = "BReadMember";
			BReadMember.Size = new Size(86, 28);
			BReadMember.Text = "&Consultar";
			// 
			// BDeleteMember
			// 
			BDeleteMember.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_delete_24;
			BDeleteMember.ImageScaling = ToolStripItemImageScaling.None;
			BDeleteMember.ImageTransparentColor = Color.Magenta;
			BDeleteMember.Margin = new Padding(2, 1, 2, 2);
			BDeleteMember.Name = "BDeleteMember";
			BDeleteMember.Size = new Size(67, 28);
			BDeleteMember.Text = "&Borrar";
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 31);
			// 
			// BPrint1x10
			// 
			BPrint1x10.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_document_24;
			BPrint1x10.ImageScaling = ToolStripItemImageScaling.None;
			BPrint1x10.ImageTransparentColor = Color.Magenta;
			BPrint1x10.Margin = new Padding(2, 1, 2, 2);
			BPrint1x10.Name = "BPrint1x10";
			BPrint1x10.Size = new Size(107, 28);
			BPrint1x10.Text = "Im&primir 1x10";
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
			TextBoxName.Location = new Point(86, 12);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(898, 23);
			TextBoxName.TabIndex = 24;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(13, 73);
			label1.Name = "label1";
			label1.Size = new Size(33, 15);
			label1.TabIndex = 26;
			label1.Text = "Líder";
			// 
			// LLeadCitizenInfo
			// 
			LLeadCitizenInfo.AutoSize = true;
			LLeadCitizenInfo.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LLeadCitizenInfo.ForeColor = SystemColors.HotTrack;
			LLeadCitizenInfo.Location = new Point(86, 101);
			LLeadCitizenInfo.Name = "LLeadCitizenInfo";
			LLeadCitizenInfo.Size = new Size(64, 15);
			LLeadCitizenInfo.TabIndex = 36;
			LLeadCitizenInfo.Text = "Ciudadano";
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(909, 646);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 38;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(831, 646);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 37;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// BSelectLeadCitizen
			// 
			BSelectLeadCitizen.Location = new Point(347, 70);
			BSelectLeadCitizen.Name = "BSelectLeadCitizen";
			BSelectLeadCitizen.Size = new Size(80, 23);
			BSelectLeadCitizen.TabIndex = 39;
			BSelectLeadCitizen.Text = "Seleccionar";
			BSelectLeadCitizen.UseVisualStyleBackColor = true;
			BSelectLeadCitizen.Visible = false;
			// 
			// LDescription
			// 
			LDescription.AutoSize = true;
			LDescription.Location = new Point(11, 44);
			LDescription.Name = "LDescription";
			LDescription.Size = new Size(69, 15);
			LDescription.TabIndex = 41;
			LDescription.Text = "Descripción";
			// 
			// TextBoxDescription
			// 
			TextBoxDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxDescription.Location = new Point(86, 41);
			TextBoxDescription.Name = "TextBoxDescription";
			TextBoxDescription.Size = new Size(898, 23);
			TextBoxDescription.TabIndex = 40;
			// 
			// TabControlNetwork
			// 
			TabControlNetwork.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			TabControlNetwork.Controls.Add(TabMembers);
			TabControlNetwork.Controls.Add(TabRoles);
			TabControlNetwork.Location = new Point(11, 125);
			TabControlNetwork.Name = "TabControlNetwork";
			TabControlNetwork.SelectedIndex = 0;
			TabControlNetwork.Size = new Size(973, 515);
			TabControlNetwork.TabIndex = 42;
			// 
			// TabMembers
			// 
			TabMembers.Controls.Add(PanelMembers);
			TabMembers.Location = new Point(4, 24);
			TabMembers.Margin = new Padding(0);
			TabMembers.Name = "TabMembers";
			TabMembers.Padding = new Padding(2);
			TabMembers.Size = new Size(965, 487);
			TabMembers.TabIndex = 0;
			TabMembers.Text = "Miembros";
			TabMembers.UseVisualStyleBackColor = true;
			// 
			// TabRoles
			// 
			TabRoles.Controls.Add(DataGridRoles);
			TabRoles.Controls.Add(ToolStripRoles);
			TabRoles.Location = new Point(4, 24);
			TabRoles.Margin = new Padding(0);
			TabRoles.Name = "TabRoles";
			TabRoles.Padding = new Padding(2);
			TabRoles.Size = new Size(965, 487);
			TabRoles.TabIndex = 1;
			TabRoles.Text = "Roles";
			TabRoles.UseVisualStyleBackColor = true;
			// 
			// DataGridRoles
			// 
			DataGridRoles.AllowUserToAddRows = false;
			DataGridRoles.AllowUserToDeleteRows = false;
			DataGridRoles.AllowUserToOrderColumns = true;
			DataGridRoles.AllowUserToResizeRows = false;
			dataGridViewCellStyle28.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle28.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle28.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle28.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle28.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle28.SelectionForeColor = SystemColors.ControlText;
			DataGridRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle28;
			DataGridRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridRoles.BackgroundColor = SystemColors.Control;
			DataGridRoles.BorderStyle = BorderStyle.None;
			DataGridRoles.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridRoles.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridRoles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle29.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle29.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle29.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle29.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle29.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle29.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle29.WrapMode = DataGridViewTriState.True;
			DataGridRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle29;
			DataGridRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle30.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle30.BackColor = SystemColors.Window;
			dataGridViewCellStyle30.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle30.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle30.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle30.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle30.WrapMode = DataGridViewTriState.False;
			DataGridRoles.DefaultCellStyle = dataGridViewCellStyle30;
			DataGridRoles.Dock = DockStyle.Fill;
			DataGridRoles.EnableHeadersVisualStyles = false;
			DataGridRoles.Location = new Point(2, 33);
			DataGridRoles.MultiSelect = false;
			DataGridRoles.Name = "DataGridRoles";
			DataGridRoles.ReadOnly = true;
			DataGridRoles.RowHeadersVisible = false;
			DataGridRoles.RowTemplate.Height = 20;
			DataGridRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridRoles.ShowCellToolTips = false;
			DataGridRoles.Size = new Size(961, 452);
			DataGridRoles.StandardTab = true;
			DataGridRoles.TabIndex = 9;
			// 
			// ToolStripRoles
			// 
			ToolStripRoles.GripStyle = ToolStripGripStyle.Hidden;
			ToolStripRoles.Items.AddRange(new ToolStripItem[] { BAddRole, BEditRole, BReadRole, BDeleteRole });
			ToolStripRoles.Location = new Point(2, 2);
			ToolStripRoles.Name = "ToolStripRoles";
			ToolStripRoles.RenderMode = ToolStripRenderMode.System;
			ToolStripRoles.Size = new Size(961, 31);
			ToolStripRoles.TabIndex = 10;
			ToolStripRoles.Text = "toolStrip1";
			// 
			// BAddRole
			// 
			BAddRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_24;
			BAddRole.ImageScaling = ToolStripItemImageScaling.None;
			BAddRole.ImageTransparentColor = Color.Magenta;
			BAddRole.Name = "BAddRole";
			BAddRole.Size = new Size(77, 28);
			BAddRole.Text = "&Agregar";
			BAddRole.Click += BAddRole_Click;
			// 
			// BEditRole
			// 
			BEditRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_24;
			BEditRole.ImageScaling = ToolStripItemImageScaling.None;
			BEditRole.ImageTransparentColor = Color.Magenta;
			BEditRole.Name = "BEditRole";
			BEditRole.Size = new Size(65, 28);
			BEditRole.Text = "&Editar";
			BEditRole.Click += BEditRole_Click;
			// 
			// BReadRole
			// 
			BReadRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Magnifier_24;
			BReadRole.ImageScaling = ToolStripItemImageScaling.None;
			BReadRole.ImageTransparentColor = Color.Magenta;
			BReadRole.Name = "BReadRole";
			BReadRole.Size = new Size(86, 28);
			BReadRole.Text = "&Consultar";
			BReadRole.Click += BReadRole_Click;
			// 
			// BDeleteRole
			// 
			BDeleteRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete_24;
			BDeleteRole.ImageScaling = ToolStripItemImageScaling.None;
			BDeleteRole.ImageTransparentColor = Color.Magenta;
			BDeleteRole.Name = "BDeleteRole";
			BDeleteRole.Size = new Size(67, 28);
			BDeleteRole.Text = "&Borrar";
			BDeleteRole.Click += BDeleteRole_Click;
			// 
			// TextBoxLeadCitizen
			// 
			TextBoxLeadCitizen.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxLeadCitizen.Location = new Point(86, 70);
			TextBoxLeadCitizen.Name = "TextBoxLeadCitizen";
			TextBoxLeadCitizen.ReadOnly = true;
			TextBoxLeadCitizen.Size = new Size(255, 23);
			TextBoxLeadCitizen.TabIndex = 43;
			// 
			// FCitizenNetworkData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(996, 681);
			Controls.Add(TextBoxLeadCitizen);
			Controls.Add(TabControlNetwork);
			Controls.Add(LDescription);
			Controls.Add(TextBoxDescription);
			Controls.Add(BSelectLeadCitizen);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Controls.Add(LLeadCitizenInfo);
			Controls.Add(label1);
			Controls.Add(LName);
			Controls.Add(TextBoxName);
			Name = "FCitizenNetworkData";
			ShowIcon = false;
			Text = "Estructura - Nueva";
			PanelMembers.ResumeLayout(false);
			PanelMembers.PerformLayout();
			splitContainer1.Panel1.ResumeLayout(false);
			splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
			splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)DataGridMembers).EndInit();
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			ToolStripMembers.ResumeLayout(false);
			ToolStripMembers.PerformLayout();
			TabControlNetwork.ResumeLayout(false);
			TabMembers.ResumeLayout(false);
			TabRoles.ResumeLayout(false);
			TabRoles.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DataGridRoles).EndInit();
			ToolStripRoles.ResumeLayout(false);
			ToolStripRoles.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TreeView TreeViewMembers;
		private Panel PanelMembers;
		private ToolStrip ToolStripMembers;
		private SplitContainer splitContainer1;
		private DataGridView DataGridMembers;
		private Label LName;
		private TextBox TextBoxName;
		private Label label1;
		private Label LLeadCitizenInfo;
		private Button BCancel;
		private Button BAccept;
		private Button BSelectLeadCitizen;
		private ToolStripButton BAddMember;
		private ToolStripButton BDeleteMember;
		private ToolStripButton BPrint1x10;
		private ToolStripButton BUp;
		private ToolStripButton BDown;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton BEditMember;
		private ToolStripButton BReadMember;
		private ToolStripButton BShowTree;
		private Label LDescription;
		private TextBox TextBoxDescription;
		private StatusStrip StatusStripMembers;
		private TabControl TabControlNetwork;
		private TabPage TabMembers;
		private TabPage TabRoles;
		private DataGridView DataGridRoles;
		private TextBox TextBoxLeadCitizen;
		private ToolStrip ToolStripRoles;
		private ToolStripButton BAddRole;
		private ToolStripButton BEditRole;
		private ToolStripButton BReadRole;
		private ToolStripButton BDeleteRole;
		private Panel panel1;
		private Label label2;
	}
}