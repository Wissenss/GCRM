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
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            TabControlUserGroup = new TabControl();
            TabGeneral = new TabPage();
            label1 = new Label();
            TBName = new TextBox();
            LName = new Label();
            TabPermissions = new TabPage();
            TextBoxUserGroup = new TextBox();
            DataGridPermissions = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPermitted = new DataGridViewCheckBoxColumn();
            BCancel = new Button();
            BAccept = new Button();
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
            TabControlUserGroup.Location = new Point(1, 38);
            TabControlUserGroup.Margin = new Padding(3, 4, 3, 4);
            TabControlUserGroup.Name = "TabControlUserGroup";
            TabControlUserGroup.SelectedIndex = 0;
            TabControlUserGroup.Size = new Size(408, 223);
            TabControlUserGroup.TabIndex = 15;
            // 
            // TabGeneral
            // 
            TabGeneral.Controls.Add(label1);
            TabGeneral.Controls.Add(LName);
            TabGeneral.Location = new Point(4, 29);
            TabGeneral.Margin = new Padding(3, 4, 3, 4);
            TabGeneral.Name = "TabGeneral";
            TabGeneral.Padding = new Padding(3, 4, 3, 4);
            TabGeneral.Size = new Size(400, 190);
            TabGeneral.TabIndex = 0;
            TabGeneral.Text = "General";
            TabGeneral.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Location = new Point(74, 49);
            label1.Name = "label1";
            label1.Size = new Size(317, 89);
            label1.TabIndex = 8;
            label1.Text = "Los usuarios que pertenezcan a este grupo tendran todos los permisos del grupo y únicamente los permisos del grupo, aquellos permisos que tenga el usuario individualmente serán ignorados.";
            // 
            // TBName
            // 
            TBName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TBName.Location = new Point(12, 3);
            TBName.Margin = new Padding(3, 4, 3, 4);
            TBName.Name = "TBName";
            TBName.Size = new Size(381, 27);
            TBName.TabIndex = 7;
            TBName.TextChanged += TBName_TextChanged;
            // 
            // LName
            // 
            LName.AutoSize = true;
            LName.Location = new Point(9, 12);
            LName.Name = "LName";
            LName.Size = new Size(64, 20);
            LName.TabIndex = 6;
            LName.Text = "Nombre";
            // 
            // TabPermissions
            // 
            TabPermissions.Controls.Add(TextBoxUserGroup);
            TabPermissions.Controls.Add(DataGridPermissions);
            TabPermissions.Location = new Point(4, 29);
            TabPermissions.Margin = new Padding(3, 4, 3, 4);
            TabPermissions.Name = "TabPermissions";
            TabPermissions.Padding = new Padding(3, 4, 3, 4);
            TabPermissions.Size = new Size(400, 227);
            TabPermissions.TabIndex = 1;
            TabPermissions.Text = "Permisos";
            TabPermissions.UseVisualStyleBackColor = true;
            // 
            // TextBoxUserGroup
            // 
            TextBoxUserGroup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxUserGroup.Location = new Point(0, 0);
            TextBoxUserGroup.Name = "TextBoxUserGroup";
            TextBoxUserGroup.Size = new Size(400, 27);
            TextBoxUserGroup.TabIndex = 10;
            // 
            // DataGridPermissions
            // 
            DataGridPermissions.AllowUserToAddRows = false;
            DataGridPermissions.AllowUserToDeleteRows = false;
            DataGridPermissions.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle9.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle9.SelectionForeColor = SystemColors.ControlText;
            DataGridPermissions.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            DataGridPermissions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            DataGridPermissions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridPermissions.BackgroundColor = SystemColors.Control;
            DataGridPermissions.BorderStyle = BorderStyle.None;
            DataGridPermissions.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridPermissions.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridPermissions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle10.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle10.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle10.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            DataGridPermissions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            DataGridPermissions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataGridPermissions.Columns.AddRange(new DataGridViewColumn[] { colId, colName, colPermitted });
            dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = SystemColors.Window;
            dataGridViewCellStyle12.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle12.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle12.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle12.WrapMode = DataGridViewTriState.False;
            DataGridPermissions.DefaultCellStyle = dataGridViewCellStyle12;
            DataGridPermissions.EditMode = DataGridViewEditMode.EditOnEnter;
            DataGridPermissions.EnableHeadersVisualStyles = false;
            DataGridPermissions.Location = new Point(3, 28);
            DataGridPermissions.Margin = new Padding(3, 4, 3, 4);
            DataGridPermissions.MultiSelect = false;
            DataGridPermissions.Name = "DataGridPermissions";
            DataGridPermissions.RowHeadersVisible = false;
            DataGridPermissions.RowHeadersWidth = 51;
            DataGridPermissions.RowTemplate.Height = 20;
            DataGridPermissions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridPermissions.ShowCellToolTips = false;
            DataGridPermissions.Size = new Size(392, 191);
            DataGridPermissions.StandardTab = true;
            DataGridPermissions.TabIndex = 9;
            DataGridPermissions.CellContentClick += DataGridPermissions_CellContentClick;
            // 
            // colId
            // 
            colId.DataPropertyName = "id";
            colId.FillWeight = 23.2558136F;
            colId.HeaderText = "Id";
            colId.MinimumWidth = 6;
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colName
            // 
            colName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colName.DataPropertyName = "name";
            colName.FillWeight = 176.744186F;
            colName.HeaderText = "Permiso";
            colName.MinimumWidth = 6;
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPermitted
            // 
            colPermitted.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            colPermitted.DataPropertyName = "permitted";
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.NullValue = false;
            colPermitted.DefaultCellStyle = dataGridViewCellStyle11;
            colPermitted.FlatStyle = FlatStyle.System;
            colPermitted.HeaderText = "";
            colPermitted.MinimumWidth = 25;
            colPermitted.Name = "colPermitted";
            colPermitted.Resizable = DataGridViewTriState.False;
            colPermitted.Width = 25;
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(311, 269);
            BCancel.Margin = new Padding(3, 4, 3, 4);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(86, 31);
            BCancel.TabIndex = 14;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // BAccept
            // 
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(222, 269);
            BAccept.Margin = new Padding(3, 4, 3, 4);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(86, 31);
            BAccept.TabIndex = 13;
            BAccept.Text = "&Aceptar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            // 
            // FUserGroupData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(410, 316);
            ControlBox = false;
            Controls.Add(TabControlUserGroup);
            Controls.Add(TBName);
            Controls.Add(BCancel);
            Controls.Add(BAccept);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FUserGroupData";
            Text = "Grupo de usuarios - Nuevo";
            TabControlUserGroup.ResumeLayout(false);
            TabGeneral.ResumeLayout(false);
            TabGeneral.PerformLayout();
            TabPermissions.ResumeLayout(false);
            TabPermissions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridPermissions).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private TextBox TextBoxUserGroup;
    }
}