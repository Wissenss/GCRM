namespace GCRM
{
    partial class FReport007
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
            BCancel = new Button();
            BSave = new Button();
            LFilterType = new Label();
            FilterType = new ComboBox();
            FilterItems = new CheckedListBox();
            CMSCheckedList = new ContextMenuStrip(components);
            MISelectAll = new ToolStripMenuItem();
            MISelectNone = new ToolStripMenuItem();
            MIInvertSelection = new ToolStripMenuItem();
            Events = new CheckedListBox();
            LFechaInicial = new Label();
            FechaInicial = new DateTimePicker();
            LFechaFinal = new Label();
            FechaFinal = new DateTimePicker();
            LEvents = new Label();
            BGenerate = new Button();
            CMSCheckedList.SuspendLayout();
            SuspendLayout();
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(326, 301);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 12;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // BSave
            // 
            BSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BSave.Location = new Point(12, 301);
            BSave.Name = "BSave";
            BSave.Size = new Size(75, 23);
            BSave.TabIndex = 10;
            BSave.Text = "&Guardar";
            BSave.UseVisualStyleBackColor = true;
            BSave.Visible = false;
            BSave.Click += BSave_Click;
            // 
            // LFilterType
            // 
            LFilterType.AutoSize = true;
            LFilterType.Location = new Point(12, 15);
            LFilterType.Name = "LFilterType";
            LFilterType.Size = new Size(58, 15);
            LFilterType.TabIndex = 0;
            LFilterType.Text = "Filtrar por";
            // 
            // FilterType
            // 
            FilterType.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FilterType.DropDownStyle = ComboBoxStyle.DropDownList;
            FilterType.FormattingEnabled = true;
            FilterType.Items.AddRange(new object[] { "Usuarios", "Grupos de usuarios" });
            FilterType.Location = new Point(76, 12);
            FilterType.Name = "FilterType";
            FilterType.Size = new Size(325, 23);
            FilterType.TabIndex = 1;
            FilterType.SelectedIndexChanged += FilterType_SelectedIndexChanged;
            // 
            // FilterItems
            // 
            FilterItems.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            FilterItems.CheckOnClick = true;
            FilterItems.ContextMenuStrip = CMSCheckedList;
            FilterItems.FormattingEnabled = true;
            FilterItems.Location = new Point(76, 41);
            FilterItems.Name = "FilterItems";
            FilterItems.Size = new Size(325, 94);
            FilterItems.TabIndex = 2;
            // 
            // CMSCheckedList
            // 
            CMSCheckedList.Items.AddRange(new ToolStripItem[] { MISelectAll, MISelectNone, MIInvertSelection });
            CMSCheckedList.Name = "CMSCheckedList";
            CMSCheckedList.Size = new Size(181, 70);
            // 
            // MISelectAll
            // 
            MISelectAll.Name = "MISelectAll";
            MISelectAll.Size = new Size(180, 22);
            MISelectAll.Text = "Seleccionar todos";
            MISelectAll.Click += MISelectAll_Click;
            // 
            // MISelectNone
            // 
            MISelectNone.Name = "MISelectNone";
            MISelectNone.Size = new Size(180, 22);
            MISelectNone.Text = "Deseleccionar todos";
            MISelectNone.Click += MISelectNone_Click;
            // 
            // MIInvertSelection
            // 
            MIInvertSelection.Name = "MIInvertSelection";
            MIInvertSelection.Size = new Size(180, 22);
            MIInvertSelection.Text = "Invertir selección";
            MIInvertSelection.Click += MIInvertSelection_Click;
            // 
            // Events
            // 
            Events.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Events.CheckOnClick = true;
            Events.ContextMenuStrip = CMSCheckedList;
            Events.FormattingEnabled = true;
            Events.Location = new Point(76, 147);
            Events.Name = "Events";
            Events.Size = new Size(325, 94);
            Events.TabIndex = 5;
            // 
            // LFechaInicial
            // 
            LFechaInicial.AutoSize = true;
            LFechaInicial.Location = new Point(12, 257);
            LFechaInicial.Name = "LFechaInicial";
            LFechaInicial.Size = new Size(38, 15);
            LFechaInicial.TabIndex = 6;
            LFechaInicial.Text = "Fecha";
            // 
            // FechaInicial
            // 
            FechaInicial.Format = DateTimePickerFormat.Short;
            FechaInicial.Location = new Point(76, 253);
            FechaInicial.Name = "FechaInicial";
            FechaInicial.Size = new Size(150, 23);
            FechaInicial.TabIndex = 7;
            // 
            // LFechaFinal
            // 
            LFechaFinal.AutoSize = true;
            LFechaFinal.Location = new Point(231, 257);
            LFechaFinal.Name = "LFechaFinal";
            LFechaFinal.Size = new Size(16, 15);
            LFechaFinal.TabIndex = 8;
            LFechaFinal.Text = "al";
            // 
            // FechaFinal
            // 
            FechaFinal.Format = DateTimePickerFormat.Short;
            FechaFinal.Location = new Point(251, 253);
            FechaFinal.Name = "FechaFinal";
            FechaFinal.Size = new Size(150, 23);
            FechaFinal.TabIndex = 9;
            // 
            // LEvents
            // 
            LEvents.AutoSize = true;
            LEvents.Location = new Point(12, 147);
            LEvents.Name = "LEvents";
            LEvents.Size = new Size(48, 15);
            LEvents.TabIndex = 4;
            LEvents.Text = "Eventos";
            // 
            // BGenerate
            // 
            BGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BGenerate.Location = new Point(245, 301);
            BGenerate.Name = "BGenerate";
            BGenerate.Size = new Size(75, 23);
            BGenerate.TabIndex = 11;
            BGenerate.Text = "G&enerar";
            BGenerate.UseVisualStyleBackColor = true;
            BGenerate.Click += BGenerate_Click;
            // 
            // FReport007
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 336);
            ControlBox = false;
            Controls.Add(LEvents);
            Controls.Add(FechaFinal);
            Controls.Add(LFechaFinal);
            Controls.Add(FechaInicial);
            Controls.Add(LFechaInicial);
            Controls.Add(Events);
            Controls.Add(FilterItems);
            Controls.Add(FilterType);
            Controls.Add(LFilterType);
            Controls.Add(BCancel);
            Controls.Add(BGenerate);
            Controls.Add(BSave);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FReport007";
            Text = "007: Actividad de los usuarios";
            Load += FReport007_Load;
            CMSCheckedList.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BCancel;
        private Button BSave;
        private Label LFilterType;
        private ComboBox FilterType;
        private CheckedListBox FilterItems;
        private CheckedListBox Events;
        private Label LFechaInicial;
        private DateTimePicker FechaInicial;
        private Label LFechaFinal;
        private DateTimePicker FechaFinal;
        private Label LEvents;
        private ContextMenuStrip CMSCheckedList;
        private ToolStripMenuItem MISelectAll;
        private ToolStripMenuItem MISelectNone;
        private ToolStripMenuItem MIInvertSelection;
        private Button BGenerate;
    }
}
