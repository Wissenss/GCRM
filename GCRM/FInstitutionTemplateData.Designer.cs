namespace GCRM
{
	partial class FInstitutionTemplateData
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
			TabControlTemplate = new TabControl();
			TabGeneral = new TabPage();
			LDescription = new Label();
			TextBoxDescription = new TextBox();
			LName = new Label();
			TextBoxName = new TextBox();
			TabRoles = new TabPage();
			DataGridTemplateRoles = new DataGridView();
			toolStrip1 = new ToolStrip();
			BAddRole = new ToolStripButton();
			BEditRole = new ToolStripButton();
			BDeleteRole = new ToolStripButton();
			BCancel = new Button();
			BAccept = new Button();
			TabControlTemplate.SuspendLayout();
			TabGeneral.SuspendLayout();
			TabRoles.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridTemplateRoles).BeginInit();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// TabControlTemplate
			// 
			TabControlTemplate.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			TabControlTemplate.Controls.Add(TabGeneral);
			TabControlTemplate.Controls.Add(TabRoles);
			TabControlTemplate.Location = new Point(1, 1);
			TabControlTemplate.Margin = new Padding(1);
			TabControlTemplate.Name = "TabControlTemplate";
			TabControlTemplate.SelectedIndex = 0;
			TabControlTemplate.Size = new Size(360, 224);
			TabControlTemplate.TabIndex = 1;
			// 
			// TabGeneral
			// 
			TabGeneral.Controls.Add(LDescription);
			TabGeneral.Controls.Add(TextBoxDescription);
			TabGeneral.Controls.Add(LName);
			TabGeneral.Controls.Add(TextBoxName);
			TabGeneral.Location = new Point(4, 24);
			TabGeneral.Name = "TabGeneral";
			TabGeneral.Padding = new Padding(3);
			TabGeneral.Size = new Size(352, 196);
			TabGeneral.TabIndex = 0;
			TabGeneral.Text = "General";
			TabGeneral.UseVisualStyleBackColor = true;
			// 
			// LDescription
			// 
			LDescription.AutoSize = true;
			LDescription.Location = new Point(10, 48);
			LDescription.Name = "LDescription";
			LDescription.Size = new Size(69, 15);
			LDescription.TabIndex = 10;
			LDescription.Text = "Descripción";
			// 
			// TextBoxDescription
			// 
			TextBoxDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxDescription.Location = new Point(82, 43);
			TextBoxDescription.Multiline = true;
			TextBoxDescription.Name = "TextBoxDescription";
			TextBoxDescription.Size = new Size(262, 147);
			TextBoxDescription.TabIndex = 5;
			// 
			// LName
			// 
			LName.AutoSize = true;
			LName.Location = new Point(10, 20);
			LName.Name = "LName";
			LName.Size = new Size(51, 15);
			LName.TabIndex = 6;
			LName.Text = "Nombre";
			// 
			// TextBoxName
			// 
			TextBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TextBoxName.Location = new Point(82, 14);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(262, 23);
			TextBoxName.TabIndex = 3;
			// 
			// TabRoles
			// 
			TabRoles.Controls.Add(DataGridTemplateRoles);
			TabRoles.Controls.Add(toolStrip1);
			TabRoles.Location = new Point(4, 24);
			TabRoles.Name = "TabRoles";
			TabRoles.Padding = new Padding(3);
			TabRoles.Size = new Size(352, 196);
			TabRoles.TabIndex = 1;
			TabRoles.Text = "Cargos";
			TabRoles.UseVisualStyleBackColor = true;
			// 
			// DataGridTemplateRoles
			// 
			DataGridTemplateRoles.AllowUserToAddRows = false;
			DataGridTemplateRoles.AllowUserToDeleteRows = false;
			DataGridTemplateRoles.AllowUserToOrderColumns = true;
			DataGridTemplateRoles.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			DataGridTemplateRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridTemplateRoles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridTemplateRoles.BackgroundColor = SystemColors.Control;
			DataGridTemplateRoles.BorderStyle = BorderStyle.None;
			DataGridTemplateRoles.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridTemplateRoles.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridTemplateRoles.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridTemplateRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridTemplateRoles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = SystemColors.Window;
			dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
			DataGridTemplateRoles.DefaultCellStyle = dataGridViewCellStyle3;
			DataGridTemplateRoles.Dock = DockStyle.Fill;
			DataGridTemplateRoles.EnableHeadersVisualStyles = false;
			DataGridTemplateRoles.ImeMode = ImeMode.NoControl;
			DataGridTemplateRoles.Location = new Point(3, 28);
			DataGridTemplateRoles.MultiSelect = false;
			DataGridTemplateRoles.Name = "DataGridTemplateRoles";
			DataGridTemplateRoles.ReadOnly = true;
			DataGridTemplateRoles.RowHeadersVisible = false;
			DataGridTemplateRoles.RowTemplate.Height = 20;
			DataGridTemplateRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridTemplateRoles.ShowCellToolTips = false;
			DataGridTemplateRoles.Size = new Size(346, 165);
			DataGridTemplateRoles.StandardTab = true;
			DataGridTemplateRoles.TabIndex = 8;
			// 
			// toolStrip1
			// 
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(new ToolStripItem[] { BAddRole, BEditRole, BDeleteRole });
			toolStrip1.Location = new Point(3, 3);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.RenderMode = ToolStripRenderMode.System;
			toolStrip1.Size = new Size(346, 25);
			toolStrip1.TabIndex = 1;
			toolStrip1.Text = "ToolStripInstitutionPositions";
			// 
			// BAddRole
			// 
			BAddRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
			BAddRole.ImageScaling = ToolStripItemImageScaling.None;
			BAddRole.ImageTransparentColor = Color.Magenta;
			BAddRole.Margin = new Padding(1, 2, 1, 2);
			BAddRole.Name = "BAddRole";
			BAddRole.Padding = new Padding(2, 0, 2, 0);
			BAddRole.Size = new Size(73, 21);
			BAddRole.Text = "&Agregar";
			BAddRole.Click += BAddRole_Click;
			// 
			// BEditRole
			// 
			BEditRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_16;
			BEditRole.ImageScaling = ToolStripItemImageScaling.None;
			BEditRole.ImageTransparentColor = Color.Magenta;
			BEditRole.Margin = new Padding(1, 2, 1, 2);
			BEditRole.Name = "BEditRole";
			BEditRole.Padding = new Padding(2, 0, 2, 0);
			BEditRole.Size = new Size(61, 21);
			BEditRole.Text = "&Editar";
			BEditRole.Click += BEditRole_Click;
			// 
			// BDeleteRole
			// 
			BDeleteRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Cancel_16;
			BDeleteRole.ImageTransparentColor = Color.Magenta;
			BDeleteRole.Margin = new Padding(1, 2, 1, 2);
			BDeleteRole.Name = "BDeleteRole";
			BDeleteRole.Padding = new Padding(2, 0, 2, 0);
			BDeleteRole.Size = new Size(63, 21);
			BDeleteRole.Text = "&Borrar";
			BDeleteRole.Visible = false;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(274, 229);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 4;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(196, 229);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 3;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// FInstitutionTemplateData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(361, 264);
			ControlBox = false;
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Controls.Add(TabControlTemplate);
			Name = "FInstitutionTemplateData";
			ShowIcon = false;
			ShowInTaskbar = false;
			Text = "Plantilla - Nueva";
			TabControlTemplate.ResumeLayout(false);
			TabGeneral.ResumeLayout(false);
			TabGeneral.PerformLayout();
			TabRoles.ResumeLayout(false);
			TabRoles.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DataGridTemplateRoles).EndInit();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
		}

		#endregion

		private TabControl TabControlTemplate;
		private TabPage TabGeneral;
		private Label LDescription;
		private TextBox TextBoxDescription;
		private Label LName;
		private TextBox TextBoxName;
		private TabPage TabRoles;
		private DataGridView DataGridTemplateRoles;
		private ToolStrip toolStrip1;
		private ToolStripButton BAddRole;
		private ToolStripButton BEditRole;
		private ToolStripButton BDeleteRole;
		private Button BCancel;
		private Button BAccept;
	}
}