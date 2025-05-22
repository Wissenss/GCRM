namespace GCRM
{
	partial class FCitizenGroupData
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
			label1 = new Label();
			TBName = new TextBox();
			label2 = new Label();
			TBDescription = new TextBox();
			TabControl = new TabControl();
			TabMembers = new TabPage();
			DataGridMembers = new DataGridView();
			toolStrip1 = new ToolStrip();
			BAddMember = new ToolStripButton();
			BEditMember = new ToolStripButton();
			BReadMember = new ToolStripButton();
			BDeleteMember = new ToolStripButton();
			BCancel = new Button();
			BAccept = new Button();
			TabControl.SuspendLayout();
			TabMembers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridMembers).BeginInit();
			toolStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 15);
			label1.Name = "label1";
			label1.Size = new Size(51, 15);
			label1.TabIndex = 0;
			label1.Text = "Nombre";
			// 
			// TBName
			// 
			TBName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TBName.Location = new Point(87, 12);
			TBName.Name = "TBName";
			TBName.Size = new Size(727, 23);
			TBName.TabIndex = 1;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 44);
			label2.Name = "label2";
			label2.Size = new Size(69, 15);
			label2.TabIndex = 2;
			label2.Text = "Descripción";
			// 
			// TBDescription
			// 
			TBDescription.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TBDescription.Location = new Point(87, 41);
			TBDescription.Multiline = true;
			TBDescription.Name = "TBDescription";
			TBDescription.Size = new Size(727, 66);
			TBDescription.TabIndex = 3;
			// 
			// TabControl
			// 
			TabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			TabControl.Controls.Add(TabMembers);
			TabControl.Location = new Point(87, 113);
			TabControl.Name = "TabControl";
			TabControl.SelectedIndex = 0;
			TabControl.Size = new Size(727, 322);
			TabControl.TabIndex = 4;
			// 
			// TabMembers
			// 
			TabMembers.Controls.Add(DataGridMembers);
			TabMembers.Controls.Add(toolStrip1);
			TabMembers.Location = new Point(4, 24);
			TabMembers.Name = "TabMembers";
			TabMembers.Padding = new Padding(3);
			TabMembers.Size = new Size(719, 294);
			TabMembers.TabIndex = 0;
			TabMembers.Text = "Miembros";
			TabMembers.UseVisualStyleBackColor = true;
			// 
			// DataGridMembers
			// 
			DataGridMembers.AllowUserToAddRows = false;
			DataGridMembers.AllowUserToDeleteRows = false;
			DataGridMembers.AllowUserToOrderColumns = true;
			DataGridMembers.AllowUserToResizeRows = false;
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
			DataGridMembers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
			DataGridMembers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridMembers.BackgroundColor = SystemColors.Control;
			DataGridMembers.BorderStyle = BorderStyle.None;
			DataGridMembers.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridMembers.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridMembers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
			DataGridMembers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			DataGridMembers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle6.BackColor = SystemColors.Window;
			dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
			DataGridMembers.DefaultCellStyle = dataGridViewCellStyle6;
			DataGridMembers.Dock = DockStyle.Fill;
			DataGridMembers.EnableHeadersVisualStyles = false;
			DataGridMembers.ImeMode = ImeMode.NoControl;
			DataGridMembers.Location = new Point(3, 28);
			DataGridMembers.MultiSelect = false;
			DataGridMembers.Name = "DataGridMembers";
			DataGridMembers.RowHeadersVisible = false;
			DataGridMembers.RowTemplate.Height = 20;
			DataGridMembers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridMembers.ShowCellToolTips = false;
			DataGridMembers.Size = new Size(713, 263);
			DataGridMembers.StandardTab = true;
			DataGridMembers.TabIndex = 11;
			// 
			// toolStrip1
			// 
			toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
			toolStrip1.Items.AddRange(new ToolStripItem[] { BAddMember, BEditMember, BReadMember, BDeleteMember });
			toolStrip1.Location = new Point(3, 3);
			toolStrip1.Name = "toolStrip1";
			toolStrip1.RenderMode = ToolStripRenderMode.System;
			toolStrip1.Size = new Size(713, 25);
			toolStrip1.TabIndex = 12;
			toolStrip1.Text = "toolStrip1";
			// 
			// BAddMember
			// 
			BAddMember.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
			BAddMember.ImageTransparentColor = Color.Magenta;
			BAddMember.Name = "BAddMember";
			BAddMember.Size = new Size(69, 22);
			BAddMember.Text = "&Agregar";
			// 
			// BEditMember
			// 
			BEditMember.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_16;
			BEditMember.ImageTransparentColor = Color.Magenta;
			BEditMember.Name = "BEditMember";
			BEditMember.Size = new Size(57, 22);
			BEditMember.Text = "&Editar";
			// 
			// BReadMember
			// 
			BReadMember.Image = Properties.Resources.Fatcow_Farm_Fresh_Information_16;
			BReadMember.ImageTransparentColor = Color.Magenta;
			BReadMember.Name = "BReadMember";
			BReadMember.Size = new Size(78, 22);
			BReadMember.Text = "&Consultar";
			// 
			// BDeleteMember
			// 
			BDeleteMember.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete_16;
			BDeleteMember.ImageTransparentColor = Color.Magenta;
			BDeleteMember.Name = "BDeleteMember";
			BDeleteMember.Size = new Size(70, 22);
			BDeleteMember.Text = "&Eliminar";
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(739, 441);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 40;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(661, 441);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 39;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// FCitizenGroupData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(826, 476);
			ControlBox = false;
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Controls.Add(TabControl);
			Controls.Add(TBDescription);
			Controls.Add(label2);
			Controls.Add(TBName);
			Controls.Add(label1);
			Name = "FCitizenGroupData";
			Text = "Grupo ciudadano - Nuevo";
			TabControl.ResumeLayout(false);
			TabMembers.ResumeLayout(false);
			TabMembers.PerformLayout();
			((System.ComponentModel.ISupportInitialize)DataGridMembers).EndInit();
			toolStrip1.ResumeLayout(false);
			toolStrip1.PerformLayout();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private TextBox TBName;
		private Label label2;
		private TextBox TBDescription;
		private TabControl TabControl;
		private TabPage TabMembers;
		private DataGridView DataGridMembers;
		private ToolStrip toolStrip1;
		private ToolStripButton BAddMember;
		private ToolStripButton BEditMember;
		private ToolStripButton BReadMember;
		private ToolStripButton BDeleteMember;
		private Button BCancel;
		private Button BAccept;
	}
}