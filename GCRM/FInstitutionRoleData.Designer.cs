namespace GCRM
{
	partial class FInstitutionRoleData
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
            BCancel = new Button();
            BAccept = new Button();
            LName = new Label();
            TextBoxName = new TextBox();
            TextBoxDescription = new TextBox();
            LDescription = new Label();
            DataGridVariations = new DataGridView();
            TabControl = new TabControl();
            TabGeneral = new TabPage();
            TabVariaciones = new TabPage();
            toolStrip1 = new ToolStrip();
            BAddVariation = new ToolStripButton();
            BEditVariation = new ToolStripButton();
            BDeleteVariation = new ToolStripButton();
            LAnnotation = new Label();
            ((System.ComponentModel.ISupportInitialize)DataGridVariations).BeginInit();
            TabControl.SuspendLayout();
            TabGeneral.SuspendLayout();
            TabVariaciones.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(318, 193);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 5;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // BAccept
            // 
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(237, 193);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 4;
            BAccept.Text = "&Aceptar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            // 
            // LName
            // 
            LName.AutoSize = true;
            LName.Location = new Point(7, 9);
            LName.Name = "LName";
            LName.Size = new Size(51, 15);
            LName.TabIndex = 6;
            LName.Text = "Nombre";
            // 
            // TextBoxName
            // 
            TextBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxName.Location = new Point(82, 6);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(299, 23);
            TextBoxName.TabIndex = 0;
            // 
            // TextBoxDescription
            // 
            TextBoxDescription.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxDescription.Location = new Point(82, 35);
            TextBoxDescription.Multiline = true;
            TextBoxDescription.Name = "TextBoxDescription";
            TextBoxDescription.Size = new Size(299, 116);
            TextBoxDescription.TabIndex = 1;
            // 
            // LDescription
            // 
            LDescription.AutoSize = true;
            LDescription.Location = new Point(6, 38);
            LDescription.Name = "LDescription";
            LDescription.Size = new Size(69, 15);
            LDescription.TabIndex = 8;
            LDescription.Text = "Descripción";
            // 
            // DataGridVariations
            // 
            DataGridVariations.AllowUserToAddRows = false;
            DataGridVariations.AllowUserToDeleteRows = false;
            DataGridVariations.AllowUserToOrderColumns = true;
            DataGridVariations.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.ControlText;
            DataGridVariations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            DataGridVariations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DataGridVariations.BackgroundColor = SystemColors.Control;
            DataGridVariations.BorderStyle = BorderStyle.None;
            DataGridVariations.CellBorderStyle = DataGridViewCellBorderStyle.None;
            DataGridVariations.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            DataGridVariations.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = SystemColors.ControlLight;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.ControlLight;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.True;
            DataGridVariations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            DataGridVariations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            DataGridVariations.DefaultCellStyle = dataGridViewCellStyle6;
            DataGridVariations.Dock = DockStyle.Fill;
            DataGridVariations.EnableHeadersVisualStyles = false;
            DataGridVariations.ImeMode = ImeMode.NoControl;
            DataGridVariations.Location = new Point(3, 28);
            DataGridVariations.Margin = new Padding(0);
            DataGridVariations.MultiSelect = false;
            DataGridVariations.Name = "DataGridVariations";
            DataGridVariations.ReadOnly = true;
            DataGridVariations.RowHeadersVisible = false;
            DataGridVariations.RowTemplate.Height = 20;
            DataGridVariations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridVariations.ShowCellToolTips = false;
            DataGridVariations.Size = new Size(382, 126);
            DataGridVariations.StandardTab = true;
            DataGridVariations.TabIndex = 3;
            // 
            // TabControl
            // 
            TabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabControl.Controls.Add(TabGeneral);
            TabControl.Controls.Add(TabVariaciones);
            TabControl.Location = new Point(1, 1);
            TabControl.Margin = new Padding(1);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(396, 185);
            TabControl.TabIndex = 10;
            TabControl.SelectedIndexChanged += TabControl_SelectedIndexChanged;
            // 
            // TabGeneral
            // 
            TabGeneral.Controls.Add(LName);
            TabGeneral.Controls.Add(TextBoxName);
            TabGeneral.Controls.Add(LDescription);
            TabGeneral.Controls.Add(TextBoxDescription);
            TabGeneral.Location = new Point(4, 24);
            TabGeneral.Name = "TabGeneral";
            TabGeneral.Padding = new Padding(3);
            TabGeneral.Size = new Size(388, 157);
            TabGeneral.TabIndex = 0;
            TabGeneral.Text = "General";
            TabGeneral.UseVisualStyleBackColor = true;
            // 
            // TabVariaciones
            // 
            TabVariaciones.Controls.Add(DataGridVariations);
            TabVariaciones.Controls.Add(toolStrip1);
            TabVariaciones.Location = new Point(4, 24);
            TabVariaciones.Name = "TabVariaciones";
            TabVariaciones.Padding = new Padding(3);
            TabVariaciones.Size = new Size(388, 157);
            TabVariaciones.TabIndex = 1;
            TabVariaciones.Text = "Variaciones";
            TabVariaciones.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.Items.AddRange(new ToolStripItem[] { BAddVariation, BEditVariation, BDeleteVariation });
            toolStrip1.Location = new Point(3, 3);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolStrip1.Size = new Size(382, 25);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // BAddVariation
            // 
            BAddVariation.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
            BAddVariation.ImageTransparentColor = Color.Magenta;
            BAddVariation.Name = "BAddVariation";
            BAddVariation.Size = new Size(69, 22);
            BAddVariation.Text = "&Agregar";
            BAddVariation.Click += BAddVariation_Click;
            // 
            // BEditVariation
            // 
            BEditVariation.Image = Properties.Resources.Fatcow_Farm_Fresh_Pencil_16;
            BEditVariation.ImageTransparentColor = Color.Magenta;
            BEditVariation.Name = "BEditVariation";
            BEditVariation.Size = new Size(57, 22);
            BEditVariation.Text = "&Editar";
            BEditVariation.Click += BEditVariation_Click;
            // 
            // BDeleteVariation
            // 
            BDeleteVariation.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete_16;
            BDeleteVariation.ImageTransparentColor = Color.Magenta;
            BDeleteVariation.Name = "BDeleteVariation";
            BDeleteVariation.Size = new Size(59, 22);
            BDeleteVariation.Text = "&Borrar";
            BDeleteVariation.Click += BDeleteVariation_Click;
            // 
            // LAnnotation
            // 
            LAnnotation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LAnnotation.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            LAnnotation.ForeColor = SystemColors.HotTrack;
            LAnnotation.Location = new Point(5, 190);
            LAnnotation.Name = "LAnnotation";
            LAnnotation.Size = new Size(226, 26);
            LAnnotation.TabIndex = 11;
            LAnnotation.Text = "las variaciones de cargos son meramente cosméticas, no representan un rol distinto";
            LAnnotation.Visible = false;
            // 
            // FInstitutionRoleData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 225);
            ControlBox = false;
            Controls.Add(LAnnotation);
            Controls.Add(TabControl);
            Controls.Add(BCancel);
            Controls.Add(BAccept);
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(400, 260);
            Name = "FInstitutionRoleData";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Cargo - Nuevo";
            ((System.ComponentModel.ISupportInitialize)DataGridVariations).EndInit();
            TabControl.ResumeLayout(false);
            TabGeneral.ResumeLayout(false);
            TabGeneral.PerformLayout();
            TabVariaciones.ResumeLayout(false);
            TabVariaciones.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BCancel;
		private Button BAccept;
		private Label LName;
		private TextBox TextBoxName;
		private TextBox TextBoxDescription;
		private Label LDescription;
		private DataGridView DataGridVariations;
        private TabControl TabControl;
        private TabPage TabGeneral;
        private TabPage TabVariaciones;
        private ToolStrip toolStrip1;
        private ToolStripButton BAddVariation;
        private ToolStripButton BEditVariation;
        private ToolStripButton BDeleteVariation;
        private Label LAnnotation;
    }
}