namespace GCRM
{
	partial class FUserGroupData
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
			DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
			DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
			TabControlUserGroup = new TabControl();
			TabGeneral = new TabPage();
			label1 = new Label();
			TBName = new TextBox();
			LName = new Label();
			TabPermissions = new TabPage();
			DataGridPermissions = new DataGridView();
			BCancel = new Button();
			BAccept = new Button();
			colId = new DataGridViewTextBoxColumn();
			colName = new DataGridViewTextBoxColumn();
			colPermitted = new DataGridViewCheckBoxColumn();
			TabControlUserGroup.SuspendLayout();
			TabGeneral.SuspendLayout();
			TabPermissions.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)DataGridPermissions).BeginInit();
			SuspendLayout();
			// 
			// TabControlUserGroup
			// 
			TabControlUserGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			TabControlUserGroup.Controls.Add(TabGeneral);
			TabControlUserGroup.Controls.Add(TabPermissions);
			TabControlUserGroup.Location = new Point(1, 1);
			TabControlUserGroup.Name = "TabControlUserGroup";
			TabControlUserGroup.SelectedIndex = 0;
			TabControlUserGroup.Size = new Size(357, 195);
			TabControlUserGroup.TabIndex = 15;
			// 
			// TabGeneral
			// 
			TabGeneral.Controls.Add(label1);
			TabGeneral.Controls.Add(TBName);
			TabGeneral.Controls.Add(LName);
			TabGeneral.Location = new Point(4, 24);
			TabGeneral.Name = "TabGeneral";
			TabGeneral.Padding = new Padding(3);
			TabGeneral.Size = new Size(349, 167);
			TabGeneral.TabIndex = 0;
			TabGeneral.Text = "General";
			TabGeneral.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			label1.Location = new Point(65, 37);
			label1.Name = "label1";
			label1.Size = new Size(277, 67);
			label1.TabIndex = 8;
			label1.Text = "Los usuarios que pertenezcan a este grupo tendran todos los permisos del grupo y únicamente los permisos del grupo, aquellos permisos que tenga el usuario individualmente serán ignorados.";
			// 
			// TBName
			// 
			TBName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
			TBName.Location = new Point(65, 6);
			TBName.Name = "TBName";
			TBName.Size = new Size(277, 23);
			TBName.TabIndex = 7;
			// 
			// LName
			// 
			LName.AutoSize = true;
			LName.Location = new Point(8, 9);
			LName.Name = "LName";
			LName.Size = new Size(51, 15);
			LName.TabIndex = 6;
			LName.Text = "Nombre";
			// 
			// TabPermissions
			// 
			TabPermissions.Controls.Add(DataGridPermissions);
			TabPermissions.Location = new Point(4, 24);
			TabPermissions.Name = "TabPermissions";
			TabPermissions.Padding = new Padding(3);
			TabPermissions.Size = new Size(349, 167);
			TabPermissions.TabIndex = 1;
			TabPermissions.Text = "Permisos";
			TabPermissions.UseVisualStyleBackColor = true;
			// 
			// DataGridPermissions
			// 
			DataGridPermissions.AllowUserToAddRows = false;
			DataGridPermissions.AllowUserToDeleteRows = false;
			DataGridPermissions.AllowUserToResizeRows = false;
			dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
			dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle1.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle1.SelectionForeColor = SystemColors.ControlText;
			DataGridPermissions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			DataGridPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			DataGridPermissions.BackgroundColor = SystemColors.Control;
			DataGridPermissions.BorderStyle = BorderStyle.None;
			DataGridPermissions.CellBorderStyle = DataGridViewCellBorderStyle.None;
			DataGridPermissions.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			DataGridPermissions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle2.ForeColor = SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = SystemColors.ControlLight;
			dataGridViewCellStyle2.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
			DataGridPermissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			DataGridPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			DataGridPermissions.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPermitted });
			dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle4.BackColor = SystemColors.Window;
			dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
			dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
			dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientInactiveCaption;
			dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
			dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
			DataGridPermissions.DefaultCellStyle = dataGridViewCellStyle4;
			DataGridPermissions.Dock = DockStyle.Fill;
			DataGridPermissions.EditMode = DataGridViewEditMode.EditOnEnter;
			DataGridPermissions.EnableHeadersVisualStyles = false;
			DataGridPermissions.Location = new Point(3, 3);
			DataGridPermissions.MultiSelect = false;
			DataGridPermissions.Name = "DataGridPermissions";
			DataGridPermissions.RowHeadersVisible = false;
			DataGridPermissions.RowTemplate.Height = 20;
			DataGridPermissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
			DataGridPermissions.ShowCellToolTips = false;
			DataGridPermissions.Size = new Size(343, 161);
			DataGridPermissions.StandardTab = true;
			DataGridPermissions.TabIndex = 9;
			// 
			// BCancel
			// 
			BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BCancel.Location = new Point(272, 202);
			BCancel.Name = "BCancel";
			BCancel.Size = new Size(75, 23);
			BCancel.TabIndex = 14;
			BCancel.Text = "&Cancelar";
			BCancel.UseVisualStyleBackColor = true;
			BCancel.Click += BCancel_Click;
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(194, 202);
			BAccept.Name = "BAccept";
			BAccept.Size = new Size(75, 23);
			BAccept.TabIndex = 13;
			BAccept.Text = "&Aceptar";
			BAccept.UseVisualStyleBackColor = true;
			BAccept.Click += BAccept_Click;
			// 
			// colId
			// 
			colId.DataPropertyName = "id";
			colId.FillWeight = 23.2558136F;
			colId.HeaderText = "Id";
			colId.Name = "colId";
			colId.ReadOnly = true;
			// 
			// colName
			// 
			colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			colName.DataPropertyName = "name";
			colName.FillWeight = 176.744186F;
			colName.HeaderText = "Permiso";
			colName.Name = "colName";
			colName.ReadOnly = true;
			// 
			// colPermitted
			// 
			colPermitted.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
			colPermitted.DataPropertyName = "permitted";
			dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.NullValue = false;
			colPermitted.DefaultCellStyle = dataGridViewCellStyle3;
			colPermitted.FlatStyle = FlatStyle.System;
			colPermitted.HeaderText = "";
			colPermitted.MinimumWidth = 25;
			colPermitted.Name = "colPermitted";
			colPermitted.Resizable = DataGridViewTriState.False;
			colPermitted.Width = 25;
			// 
			// FUserGroupData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(359, 237);
			ControlBox = false;
			Controls.Add(TabControlUserGroup);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			Name = "FUserGroupData";
			Text = "Grupo de usuarios - Nuevo";
			TabControlUserGroup.ResumeLayout(false);
			TabGeneral.ResumeLayout(false);
			TabGeneral.PerformLayout();
			TabPermissions.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)DataGridPermissions).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private TabControl TabControlUserGroup;
		private TabPage TabGeneral;
		private TextBox TBName;
		private Label LName;
		private TabPage TabPermissions;
		private Button BCancel;
		private Button BAccept;
		private Label label1;
		private DataGridView DataGridPermissions;
		private DataGridViewTextBoxColumn colId;
		private DataGridViewTextBoxColumn colName;
		private DataGridViewCheckBoxColumn colPermitted;
	}
}