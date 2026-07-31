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
            BCancel = new Button();
            BAccept = new Button();
            BExport = new Button();
            RadioUsers = new RadioButton();
            RadioGroups = new RadioButton();
            Users = new CheckedListBox();
            UserGroups = new CheckedListBox();
            LEvents = new Label();
            Events = new CheckedListBox();
            LFechaInicial = new Label();
            FechaInicial = new DateTimePicker();
            LFechaFinal = new Label();
            FechaFinal = new DateTimePicker();
            SuspendLayout();
            //
            // BCancel
            //
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(413, 385);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 10;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            //
            // BAccept
            //
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(332, 385);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 9;
            BAccept.Text = "&Ver";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            //
            // BExport
            //
            BExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BExport.Location = new Point(251, 385);
            BExport.Name = "BExport";
            BExport.Size = new Size(75, 23);
            BExport.TabIndex = 8;
            BExport.Text = "&Guardar";
            BExport.UseVisualStyleBackColor = true;
            BExport.Click += BExport_Click;
            //
            // RadioUsers
            //
            RadioUsers.AutoSize = true;
            RadioUsers.Checked = true;
            RadioUsers.Location = new Point(12, 12);
            RadioUsers.Name = "RadioUsers";
            RadioUsers.Size = new Size(75, 19);
            RadioUsers.TabIndex = 0;
            RadioUsers.TabStop = true;
            RadioUsers.Text = "Usuario(s)";
            RadioUsers.UseVisualStyleBackColor = true;
            RadioUsers.CheckedChanged += RadioUsers_CheckedChanged;
            //
            // RadioGroups
            //
            RadioGroups.AutoSize = true;
            RadioGroups.Location = new Point(120, 12);
            RadioGroups.Name = "RadioGroups";
            RadioGroups.Size = new Size(150, 19);
            RadioGroups.TabIndex = 1;
            RadioGroups.Text = "Grupo(s) de usuarios";
            RadioGroups.UseVisualStyleBackColor = true;
            //
            // Users
            //
            Users.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Users.CheckOnClick = true;
            Users.FormattingEnabled = true;
            Users.Location = new Point(12, 35);
            Users.Name = "Users";
            Users.Size = new Size(476, 94);
            Users.TabIndex = 2;
            //
            // UserGroups
            //
            UserGroups.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            UserGroups.CheckOnClick = true;
            UserGroups.FormattingEnabled = true;
            UserGroups.Location = new Point(12, 35);
            UserGroups.Name = "UserGroups";
            UserGroups.Size = new Size(476, 94);
            UserGroups.TabIndex = 3;
            UserGroups.Visible = false;
            //
            // LEvents
            //
            LEvents.AutoSize = true;
            LEvents.Location = new Point(12, 136);
            LEvents.Name = "LEvents";
            LEvents.Size = new Size(58, 15);
            LEvents.TabIndex = 4;
            LEvents.Text = "Evento(s)";
            //
            // Events
            //
            Events.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Events.CheckOnClick = true;
            Events.FormattingEnabled = true;
            Events.Location = new Point(12, 154);
            Events.Name = "Events";
            Events.Size = new Size(476, 94);
            Events.TabIndex = 5;
            //
            // LFechaInicial
            //
            LFechaInicial.AutoSize = true;
            LFechaInicial.Location = new Point(12, 258);
            LFechaInicial.Name = "LFechaInicial";
            LFechaInicial.Size = new Size(72, 15);
            LFechaInicial.TabIndex = 6;
            LFechaInicial.Text = "Fecha inicial";
            //
            // FechaInicial
            //
            FechaInicial.Format = DateTimePickerFormat.Short;
            FechaInicial.Location = new Point(100, 254);
            FechaInicial.Name = "FechaInicial";
            FechaInicial.Size = new Size(150, 23);
            FechaInicial.TabIndex = 7;
            //
            // LFechaFinal
            //
            LFechaFinal.AutoSize = true;
            LFechaFinal.Location = new Point(272, 258);
            LFechaFinal.Name = "LFechaFinal";
            LFechaFinal.Size = new Size(66, 15);
            LFechaFinal.TabIndex = 11;
            LFechaFinal.Text = "Fecha final";
            //
            // FechaFinal
            //
            FechaFinal.Format = DateTimePickerFormat.Short;
            FechaFinal.Location = new Point(350, 254);
            FechaFinal.Name = "FechaFinal";
            FechaFinal.Size = new Size(150, 23);
            FechaFinal.TabIndex = 12;
            //
            // FReport007
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 420);
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Controls.Add(FechaFinal);
            Controls.Add(LFechaFinal);
            Controls.Add(FechaInicial);
            Controls.Add(LFechaInicial);
            Controls.Add(Events);
            Controls.Add(LEvents);
            Controls.Add(UserGroups);
            Controls.Add(Users);
            Controls.Add(RadioGroups);
            Controls.Add(RadioUsers);
            Controls.Add(BCancel);
            Controls.Add(BAccept);
            Controls.Add(BExport);
            Name = "FReport007";
            Text = "007: Actividad de los usuarios";
            Load += FReport007_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BCancel;
        private Button BAccept;
        private Button BExport;
        private RadioButton RadioUsers;
        private RadioButton RadioGroups;
        private CheckedListBox Users;
        private CheckedListBox UserGroups;
        private Label LEvents;
        private CheckedListBox Events;
        private Label LFechaInicial;
        private DateTimePicker FechaInicial;
        private Label LFechaFinal;
        private DateTimePicker FechaFinal;
    }
}
