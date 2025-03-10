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
			components = new System.ComponentModel.Container();
			DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			PanelMembers = new Panel();
			panel1 = new Panel();
			ObjectListMembers = new BrightIdeasSoftware.TreeListView();
			StatusStripMembers = new StatusStrip();
			ToolStripMembers = new ToolStrip();
			BContractLevel = new ToolStripButton();
			BExpandLevel = new ToolStripButton();
			BAddRoot = new ToolStripButton();
			toolStripSeparator2 = new ToolStripSeparator();
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
			SaveFileDialog = new SaveFileDialog();
			PanelMembers.SuspendLayout();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)ObjectListMembers).BeginInit();
			ToolStripMembers.SuspendLayout();
			TabControlNetwork.SuspendLayout();
			TabMembers.SuspendLayout();
			TabRoles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridRoles).BeginInit();
			ToolStripRoles.SuspendLayout();
			SuspendLayout();
			// 
			// PanelMembers
			// 
			PanelMembers.Controls.Add(panel1);
			PanelMembers.Controls.Add(StatusStripMembers);
			PanelMembers.Controls.Add(ToolStripMembers);
			PanelMembers.Dock = DockStyle.Fill;
			PanelMembers.Location = new Point(2, 2);
			PanelMembers.Margin = new Padding(0);
			PanelMembers.Name = "PanelMembers";
			PanelMembers.Size = new Size(961, 483);
			PanelMembers.TabIndex = 1;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ControlLight;
			panel1.Controls.Add(ObjectListMembers);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 31);
			panel1.Margin = new Padding(0);
			panel1.Name = "panel1";
			panel1.Padding = new Padding(0, 2, 0, 0);
			panel1.Size = new Size(961, 452);
			panel1.TabIndex = 4;
			// 
			// ObjectListMembers
			// 
			ObjectListMembers.BackColor = SystemColors.Control;
			ObjectListMembers.BorderStyle = BorderStyle.None;
			ObjectListMembers.Dock = DockStyle.Fill;
			ObjectListMembers.Location = new Point(0, 2);
			ObjectListMembers.Margin = new Padding(0, 3, 0, 0);
			ObjectListMembers.Name = "ObjectListMembers";
			ObjectListMembers.ShowGroups = false;
			ObjectListMembers.Size = new Size(961, 450);
			ObjectListMembers.TabIndex = 3;
			ObjectListMembers.View = View.Details;
			ObjectListMembers.VirtualMode = true;
			// 
			// StatusStripMembers
			// 
			StatusStripMembers.Location = new Point(0, 461);
			StatusStripMembers.Name = "StatusStripMembers";
			StatusStripMembers.Size = new Size(961, 22);
			StatusStripMembers.TabIndex = 1;
			StatusStripMembers.Text = "statusStrip1";
			StatusStripMembers.Visible = false;
			// 
			// ToolStripMembers
			// 
			ToolStripMembers.GripMargin = new Padding(0);
			ToolStripMembers.GripStyle = ToolStripGripStyle.Hidden;
			ToolStripMembers.Items.AddRange(new ToolStripItem[] { BContractLevel, BExpandLevel, BAddRoot, toolStripSeparator2, BAddMember, BEditMember, BReadMember, BDeleteMember, toolStripSeparator1, BPrint1x10 });
			ToolStripMembers.Location = new Point(0, 0);
			ToolStripMembers.Name = "ToolStripMembers";
			ToolStripMembers.RenderMode = ToolStripRenderMode.System;
			ToolStripMembers.Size = new Size(961, 31);
			ToolStripMembers.TabIndex = 1;
			ToolStripMembers.Text = "Miembros";
			// 
			// BContractLevel
			// 
			BContractLevel.Alignment = ToolStripItemAlignment.Right;
			BContractLevel.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_arrow_up_24;
			BContractLevel.ImageScaling = ToolStripItemImageScaling.None;
			BContractLevel.ImageTransparentColor = Color.Magenta;
			BContractLevel.Margin = new Padding(2, 1, 2, 2);
			BContractLevel.Name = "BContractLevel";
			BContractLevel.Size = new Size(81, 28);
			BContractLevel.Text = "Contraer";
			BContractLevel.Click += BContractLevel_Click;
			// 
			// BExpandLevel
			// 
			BExpandLevel.Alignment = ToolStripItemAlignment.Right;
			BExpandLevel.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_arrow_down_24;
			BExpandLevel.ImageScaling = ToolStripItemImageScaling.None;
			BExpandLevel.ImageTransparentColor = Color.Magenta;
			BExpandLevel.Margin = new Padding(2, 1, 2, 2);
			BExpandLevel.Name = "BExpandLevel";
			BExpandLevel.Size = new Size(80, 28);
			BExpandLevel.Text = "Expandir";
			BExpandLevel.Click += BExpandLevel_Click;
			// 
			// BAddRoot
			// 
			BAddRoot.Image = Properties.Resources.Fatcow_Farm_Fresh_Node_24;
			BAddRoot.ImageScaling = ToolStripItemImageScaling.None;
			BAddRoot.ImageTransparentColor = Color.Magenta;
			BAddRoot.Name = "BAddRoot";
			BAddRoot.Size = new Size(92, 28);
			BAddRoot.Text = "Nueva Red";
			BAddRoot.Click += BAddRoot_Click;
			// 
			// toolStripSeparator2
			// 
			toolStripSeparator2.Name = "toolStripSeparator2";
			toolStripSeparator2.Size = new Size(6, 31);
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
			BEditMember.Visible = false;
			BEditMember.Click += BEditMember_Click;
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
			BReadMember.Visible = false;
			BReadMember.Click += BReadMember_Click;
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
			BDeleteMember.Click += BDeleteMember_Click;
			// 
			// toolStripSeparator1
			// 
			toolStripSeparator1.Name = "toolStripSeparator1";
			toolStripSeparator1.Size = new Size(6, 31);
			// 
			// BPrint1x10
			// 
			BPrint1x10.Image = Properties.Resources.Fatcow_Farm_Fresh_Printer_16;
			BPrint1x10.ImageScaling = ToolStripItemImageScaling.None;
			BPrint1x10.ImageTransparentColor = Color.Magenta;
			BPrint1x10.Margin = new Padding(2, 1, 2, 2);
			BPrint1x10.Name = "BPrint1x10";
			BPrint1x10.Size = new Size(99, 28);
			BPrint1x10.Text = "Imprimir 1x10";
			BPrint1x10.Click += BPrint1x10_Click;
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
			label1.Size = new Size(63, 15);
			label1.TabIndex = 26;
			label1.Text = "Encargado";
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
			BSelectLeadCitizen.Click += BSelectLeadCitizen_Click;
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
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			DataGridRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridRoles.BackgroundColor = SystemColors.Control;
			DataGridRoles.BorderStyle = BorderStyle.None;
			DataGridRoles.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridRoles.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridRoles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGridRoles.DefaultCellStyle = dataGridViewCellStyle3;
			DataGridRoles.Dock = DockStyle.Fill;
			DataGridRoles.EnableHeadersVisualStyles = false;
			DataGridRoles.Location = new Point(2, 35);
			DataGridRoles.MultiSelect = false;
			DataGridRoles.Name = "DataGridRoles";
			DataGridRoles.ReadOnly = true;
			DataGridRoles.RowHeadersVisible = false;
			DataGridRoles.RowTemplate.Height = 20;
			DataGridRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridRoles.ShowCellToolTips = false;
			DataGridRoles.Size = new Size(961, 450);
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
			ToolStripRoles.Size = new Size(961, 33);
			ToolStripRoles.TabIndex = 10;
			ToolStripRoles.Text = "toolStrip1";
			// 
			// BAddRole
			// 
			BAddRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
			BAddRole.ImageScaling = ToolStripItemImageScaling.None;
			BAddRole.ImageTransparentColor = Color.Magenta;
			BAddRole.Margin = new Padding(2, 1, 2, 2);
			BAddRole.Name = "BAddRole";
			BAddRole.Padding = new Padding(0, 5, 2, 5);
			BAddRole.Size = new Size(71, 30);
			BAddRole.Text = "&Agregar";
			BAddRole.Click += BAddRole_Click;
			// 
			// BEditRole
			// 
			BEditRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_16;
			BEditRole.ImageScaling = ToolStripItemImageScaling.None;
			BEditRole.ImageTransparentColor = Color.Magenta;
			BEditRole.Margin = new Padding(2, 1, 2, 2);
			BEditRole.Name = "BEditRole";
			BEditRole.Padding = new Padding(0, 5, 2, 5);
			BEditRole.Size = new Size(59, 30);
			BEditRole.Text = "&Editar";
			BEditRole.Click += BEditRole_Click;
			// 
			// BReadRole
			// 
			BReadRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Magnifier_16;
			BReadRole.ImageScaling = ToolStripItemImageScaling.None;
			BReadRole.ImageTransparentColor = Color.Magenta;
			BReadRole.Margin = new Padding(2, 1, 2, 2);
			BReadRole.Name = "BReadRole";
			BReadRole.Padding = new Padding(0, 5, 2, 5);
			BReadRole.Size = new Size(80, 30);
			BReadRole.Text = "&Consultar";
			BReadRole.Click += BReadRole_Click;
			// 
			// BDeleteRole
			// 
			BDeleteRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete_16;
			BDeleteRole.ImageScaling = ToolStripItemImageScaling.None;
			BDeleteRole.ImageTransparentColor = Color.Magenta;
			BDeleteRole.Margin = new Padding(2, 1, 2, 2);
			BDeleteRole.Name = "BDeleteRole";
			BDeleteRole.Padding = new Padding(0, 5, 2, 5);
			BDeleteRole.Size = new Size(61, 30);
			BDeleteRole.Text = "&Borrar";
			BDeleteRole.Click += BDeleteRole_Click;
			// 
			// TextBoxLeadCitizen
			// 
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
			panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)ObjectListMembers).EndInit();
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
		private Panel PanelMembers;
		private ToolStrip ToolStripMembers;
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
		private ToolStripButton BExpandLevel;
		private ToolStripButton BContractLevel;
		private ToolStripSeparator toolStripSeparator1;
		private ToolStripButton BEditMember;
		private ToolStripButton BReadMember;
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
		private BrightIdeasSoftware.TreeListView ObjectListMembers;
		private Panel panel1;
		private ToolStripButton BExportList;
		private ToolStripSeparator toolStripSeparator2;
		private ToolStripButton BAddRoot;
		private ToolStripSeparator toolStripSeparator3;
		private ToolStripButton BPrintList;
		private SaveFileDialog SaveFileDialog;
	}
}