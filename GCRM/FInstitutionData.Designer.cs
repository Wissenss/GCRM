namespace GCRM
{
	partial class FInstitutionData
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
			BCancel = new Button();
			BAccept = new Button();
			TabGeneral = new TabPage();
			ComboBoxCategory = new ComboBox();
			ComboBoxParentInstitution = new ComboBox();
			LParentInstitution = new Label();
			LInstitutionCategory = new Label();
			LDescription = new Label();
			TextBoxDescription = new TextBox();
			ComboBoxSocietySector = new ComboBox();
			LSocietySector = new Label();
			LName = new Label();
			TextBoxName = new TextBox();
			TabControlInstitution = new TabControl();
			TabPositions = new TabPage();
			DataGridInstitutionRoles = new DataGridView();
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colInstitutionId = new DataGridViewTextBoxColumn();
			colParentRoleId = new DataGridViewTextBoxColumn();
			colDescription = new DataGridViewTextBoxColumn();
			toolStrip1 = new ToolStrip();
			BAddRole = new ToolStripButton();
			BEditRole = new ToolStripButton();
			TabGeneral.SuspendLayout();
			TabControlInstitution.SuspendLayout();
			TabPositions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridInstitutionRoles).BeginInit();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(307, 356);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 2;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(229, 356);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 1;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// TabGeneral
			// 
			TabGeneral.Controls.Add(ComboBoxCategory);
			TabGeneral.Controls.Add(ComboBoxParentInstitution);
			TabGeneral.Controls.Add(LParentInstitution);
			TabGeneral.Controls.Add(LInstitutionCategory);
			TabGeneral.Controls.Add(LDescription);
			TabGeneral.Controls.Add(TextBoxDescription);
			TabGeneral.Controls.Add(ComboBoxSocietySector);
			TabGeneral.Controls.Add(LSocietySector);
			TabGeneral.Controls.Add(LName);
			TabGeneral.Controls.Add(TextBoxName);
			TabGeneral.Location = new Point(4, 24);
			TabGeneral.Name = "TabGeneral";
			TabGeneral.Padding = new Padding(3);
			TabGeneral.Size = new Size(383, 323);
			TabGeneral.TabIndex = 0;
			TabGeneral.Text = "General";
			TabGeneral.UseVisualStyleBackColor = true;
			// 
			// ComboBoxCategory
			// 
			ComboBoxCategory.FormattingEnabled = true;
			ComboBoxCategory.Location = new Point(82, 43);
			ComboBoxCategory.Name = "ComboBoxCategory";
			ComboBoxCategory.Size = new Size(143, 23);
			ComboBoxCategory.TabIndex = 14;
			// 
			// ComboBoxParentInstitution
			// 
			ComboBoxParentInstitution.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxParentInstitution.FlatStyle = FlatStyle.System;
			ComboBoxParentInstitution.FormattingEnabled = true;
			ComboBoxParentInstitution.Location = new Point(82, 72);
			ComboBoxParentInstitution.Name = "ComboBoxParentInstitution";
			ComboBoxParentInstitution.Size = new Size(295, 23);
			ComboBoxParentInstitution.TabIndex = 12;
			// 
			// LParentInstitution
			// 
			LParentInstitution.AutoSize = true;
			LParentInstitution.Location = new Point(7, 75);
			LParentInstitution.Name = "LParentInstitution";
			LParentInstitution.Size = new Size(62, 15);
			LParentInstitution.TabIndex = 13;
			LParentInstitution.Text = "Inst. padre";
			// 
			// LInstitutionCategory
			// 
			LInstitutionCategory.AutoSize = true;
			LInstitutionCategory.Location = new Point(7, 46);
			LInstitutionCategory.Name = "LInstitutionCategory";
			LInstitutionCategory.Size = new Size(58, 15);
			LInstitutionCategory.TabIndex = 11;
			LInstitutionCategory.Text = "Categoría";
			// 
			// LDescription
			// 
			LDescription.AutoSize = true;
			LDescription.Location = new Point(7, 132);
			LDescription.Name = "LDescription";
			LDescription.Size = new Size(69, 15);
			LDescription.TabIndex = 10;
			LDescription.Text = "Descripción";
			// 
			// TextBoxDescription
			// 
			TextBoxDescription.Location = new Point(82, 130);
			TextBoxDescription.Multiline = true;
			TextBoxDescription.Name = "TextBoxDescription";
			TextBoxDescription.Size = new Size(295, 69);
			TextBoxDescription.TabIndex = 3;
			// 
			// ComboBoxSocietySector
			// 
			ComboBoxSocietySector.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxSocietySector.FlatStyle = FlatStyle.System;
			ComboBoxSocietySector.FormattingEnabled = true;
			ComboBoxSocietySector.Location = new Point(82, 15);
			ComboBoxSocietySector.Name = "ComboBoxSocietySector";
			ComboBoxSocietySector.Size = new Size(143, 23);
			ComboBoxSocietySector.TabIndex = 0;
			// 
			// LSocietySector
			// 
			LSocietySector.AutoSize = true;
			LSocietySector.Location = new Point(7, 15);
			LSocietySector.Name = "LSocietySector";
			LSocietySector.Size = new Size(40, 15);
			LSocietySector.TabIndex = 7;
			LSocietySector.Text = "Sector";
			// 
			// LName
			// 
			LName.AutoSize = true;
			LName.Location = new Point(7, 103);
			LName.Name = "LName";
			LName.Size = new Size(51, 15);
			LName.TabIndex = 6;
			LName.Text = "Nombre";
			// 
			// TextBoxName
			// 
			TextBoxName.Location = new Point(82, 100);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(295, 23);
			TextBoxName.TabIndex = 2;
			// 
			// TabControlInstitution
			// 
			TabControlInstitution.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			TabControlInstitution.Controls.Add(TabGeneral);
			TabControlInstitution.Controls.Add(TabPositions);
			TabControlInstitution.Location = new Point(1, 1);
			TabControlInstitution.Margin = new Padding(1);
			TabControlInstitution.Name = "TabControlInstitution";
			TabControlInstitution.SelectedIndex = 0;
			TabControlInstitution.Size = new Size(391, 351);
			TabControlInstitution.TabIndex = 0;
			// 
			// TabPositions
			// 
			TabPositions.Controls.Add(DataGridInstitutionRoles);
			TabPositions.Controls.Add(toolStrip1);
			TabPositions.Location = new Point(4, 24);
			TabPositions.Name = "TabPositions";
			TabPositions.Padding = new Padding(3);
			TabPositions.Size = new Size(383, 323);
			TabPositions.TabIndex = 1;
			TabPositions.Text = "Cargos";
			TabPositions.UseVisualStyleBackColor = true;
			// 
			// DataGridInstitutionRoles
			// 
			DataGridInstitutionRoles.AllowUserToAddRows = false;
			DataGridInstitutionRoles.AllowUserToDeleteRows = false;
			DataGridInstitutionRoles.AllowUserToOrderColumns = true;
			DataGridInstitutionRoles.AllowUserToResizeRows = false;
			DataGridInstitutionRoles.BackgroundColor = SystemColors.Control;
			DataGridInstitutionRoles.BorderStyle = BorderStyle.None;
			DataGridInstitutionRoles.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridInstitutionRoles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = SystemColors.Control;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
			DataGridInstitutionRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			DataGridInstitutionRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridInstitutionRoles.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colInstitutionId, colParentRoleId, colDescription });
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.Window;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
			DataGridInstitutionRoles.DefaultCellStyle = dataGridViewCellStyle2;
			DataGridInstitutionRoles.Dock = DockStyle.Fill;
			DataGridInstitutionRoles.EnableHeadersVisualStyles = false;
			DataGridInstitutionRoles.Location = new Point(3, 28);
			DataGridInstitutionRoles.MultiSelect = false;
			DataGridInstitutionRoles.Name = "DataGridInstitutionRoles";
			DataGridInstitutionRoles.ReadOnly = true;
			DataGridInstitutionRoles.RowHeadersVisible = false;
			DataGridInstitutionRoles.RowTemplate.Height = 20;
			DataGridInstitutionRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridInstitutionRoles.Size = new Size(377, 292);
			DataGridInstitutionRoles.StandardTab = true;
			DataGridInstitutionRoles.TabIndex = 0;
			// 
			// colId
			// 
			colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			colId.DataPropertyName = "id";
			colId.HeaderText = "Id";
			colId.Name = "colId";
			colId.ReadOnly = true;
			colId.Visible = false;
			// 
			// colName
			// 
			colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			colName.DataPropertyName = "name";
			colName.HeaderText = "Cargo";
			colName.Name = "colName";
			colName.ReadOnly = true;
			colName.Width = 63;
			// 
			// colInstitutionId
			// 
			colInstitutionId.DataPropertyName = "institution_id";
			colInstitutionId.HeaderText = "Id Institución";
			colInstitutionId.Name = "colInstitutionId";
			colInstitutionId.ReadOnly = true;
			colInstitutionId.Visible = false;
			// 
			// colParentRoleId
			// 
			colParentRoleId.DataPropertyName = "parent_role_id";
			colParentRoleId.HeaderText = "Id Cargo Padre";
			colParentRoleId.Name = "colParentRoleId";
			colParentRoleId.ReadOnly = true;
			colParentRoleId.Visible = false;
			// 
			// colDescription
			// 
			colDescription.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colDescription.DataPropertyName = "description";
			colDescription.HeaderText = "Descripción";
			colDescription.Name = "colDescription";
			colDescription.ReadOnly = true;
			// 
			// toolStrip1
			// 
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(new ToolStripItem[] { BAddRole, BEditRole });
			toolStrip1.Location = new Point(3, 3);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.RenderMode = ToolStripRenderMode.System;
			toolStrip1.Size = new Size(377, 25);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "ToolStripInstitutionPositions";
			// 
			// BAddRole
			// 
			BAddRole.DisplayStyle = ToolStripItemDisplayStyle.Text;
			BAddRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
			BAddRole.ImageScaling = ToolStripItemImageScaling.None;
			BAddRole.ImageTransparentColor = Color.Magenta;
			BAddRole.Name = "BAddRole";
			BAddRole.Size = new Size(53, 22);
			BAddRole.Text = "&Agregar";
			BAddRole.Click += BAddRole_Click;
			// 
			// BEditRole
			// 
			BEditRole.DisplayStyle = ToolStripItemDisplayStyle.Text;
			BEditRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_16;
			BEditRole.ImageScaling = ToolStripItemImageScaling.None;
			BEditRole.ImageTransparentColor = Color.Magenta;
			BEditRole.Name = "BEditRole";
			BEditRole.Size = new Size(41, 22);
			BEditRole.Text = "&Editar";
			BEditRole.Click += BEditRole_Click;
			// 
			// FInstitutionData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(394, 391);
			ControlBox = false;
			Controls.Add(TabControlInstitution);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			MaximumSize = new Size(420, 450);
			Name = "FInstitutionData";
			ShowIcon = false;
			ShowInTaskbar = false;
			SizeGripStyle = SizeGripStyle.Hide;
			Text = "Institución - Nueva";
			Load += FInstitutionData_Load;
			TabGeneral.ResumeLayout(false);
			TabGeneral.PerformLayout();
			TabControlInstitution.ResumeLayout(false);
			TabPositions.ResumeLayout(false);
			TabPositions.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DataGridInstitutionRoles).EndInit();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private Button BCancel;
		private Button BAccept;
		private TabPage TabGeneral;
		private TabControl TabControlInstitution;
		private TabPage TabPositions;
		private Label LName;
		private TextBox TextBoxName;
		private Label LSocietySector;
		private ComboBox ComboBoxSocietySector;
		private TextBox TextBoxDescription;
		private Label LDescription;
		private ToolStrip toolStrip1;
		private Label LInstitutionCategory;
		private DataGridView DataGridInstitutionRoles;
		private ToolStripButton BAddRole;
		private ToolStripButton BEditRole;
		private ComboBox ComboBoxParentInstitution;
		private Label LParentInstitution;
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewTextBoxColumn colInstitutionId;
		private DataGridViewTextBoxColumn colParentRoleId;
		private DataGridViewTextBoxColumn colDescription;
		private ComboBox ComboBoxCategory;
	}
}