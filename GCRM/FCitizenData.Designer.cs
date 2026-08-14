namespace GCRM
{
	partial class FCitizenData
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
            BAccept = new Button();
            BCancel = new Button();
            TabControlCitizen = new TabControl();
            TabGeneral = new TabPage();
            BDayYear = new ComboBox();
            BDayDay = new ComboBox();
            BDayMonth = new ComboBox();
            KnownBirthday = new CheckBox();
            BGenerateCURP = new Button();
            LCategory = new Label();
            ComboBoxCategory = new ComboBox();
            MaskedTextBoxCURP = new MaskedTextBox();
            LMaternalName = new Label();
            TextBoxMaternalName = new TextBox();
            LPaternalName = new Label();
            TextBoxPaternalName = new TextBox();
            ComboBoxPoliticalParty = new ComboBox();
            LPoliticalParty = new Label();
            LTitleFull = new Label();
            LCURP = new Label();
            TextBoxObservations = new TextBox();
            label1 = new Label();
            ComboBoxSex = new ComboBox();
            label2 = new Label();
            ComboBoxTitle = new ComboBox();
            LTitle = new Label();
            LName = new Label();
            TextBoxName = new TextBox();
            TabRelationships = new TabPage();
            NumPriorityScore = new NumericUpDown();
            label4 = new Label();
            EndDate = new DateTimePicker();
            KnownEndDate = new CheckBox();
            RelationshipEnabled = new CheckBox();
            RelationshipNotes = new TextBox();
            LRelationshipNotes = new Label();
            StartDate = new DateTimePicker();
            KnownStartDate = new CheckBox();
            LRelationship = new Label();
            Relationship = new ComboBox();
            NAffinity = new NumericUpDown();
            LAffinity = new Label();
            TabElectoral = new TabPage();
            KnownPoliticalRegisterDate = new CheckBox();
            PoliticalRegisterDate = new DateTimePicker();
            IsPoliticalActivist = new CheckBox();
            pictureBox1 = new PictureBox();
            VoterSection = new TextBox();
            LVoterSection = new Label();
            VoterCIC = new TextBox();
            LVoterCIC = new Label();
            VoterOCR = new TextBox();
            LVoterOCR = new Label();
            VoterCode = new TextBox();
            LElectorCode = new Label();
            TabContacto = new TabPage();
            PhoneSyncExtension = new TextBox();
            label3 = new Label();
            PhoneSync = new TextBox();
            LPhoneSync = new Label();
            TelSyncEnabled = new CheckBox();
            Phone3Extension = new TextBox();
            LPhone3Extension = new Label();
            Phone3 = new TextBox();
            LPhone3 = new Label();
            Phone2Extension = new TextBox();
            LPhone2Extension = new Label();
            Phone2 = new TextBox();
            LPhone2 = new Label();
            TextBoxEmail = new TextBox();
            LEmail = new Label();
            LAssitantCellphone = new Label();
            LAssistantPhone = new Label();
            LAssitantName = new Label();
            LAssistent = new Label();
            ComboBoxAssistant = new ComboBox();
            TextBoxCellphone = new TextBox();
            LCellphone = new Label();
            TextBoxPhoneExtension = new TextBox();
            LPhoneExtension = new Label();
            TextBoxPhone = new TextBox();
            LPhone = new Label();
            TabAddress = new TabPage();
            TextBoxDistrict = new TextBox();
            LDistrict = new Label();
            LCountryFullName = new Label();
            LCountry = new Label();
            ComboBoxCountry = new ComboBox();
            TextBoxCity = new TextBox();
            LCity = new Label();
            TextBoxState = new TextBox();
            LState = new Label();
            TextBoxPostalCode = new TextBox();
            LPostalCode = new Label();
            TextBoxInteriorNumber = new TextBox();
            LInteriorNumber = new Label();
            TextBoxNumber = new TextBox();
            LNumber = new Label();
            TextBoxStreet = new TextBox();
            LStreet = new Label();
            TabRol = new TabPage();
            DataGridRoles = new DataGridView();
            ToolStripRoles = new ToolStrip();
            BAddRole = new ToolStripButton();
            BEditRole = new ToolStripButton();
            BDeleteRole = new ToolStripButton();
            BPositionUpRole = new ToolStripButton();
            BPositionDownRole = new ToolStripButton();
            TabOtros = new TabPage();
            VerificationAuthor = new TextBox();
            LVerificationAuthor = new Label();
            LVerificationDate = new Label();
            VerificationDate = new DateTimePicker();
            Verified = new CheckBox();
            TabControlCitizen.SuspendLayout();
            TabGeneral.SuspendLayout();
            TabRelationships.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NumPriorityScore).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NAffinity).BeginInit();
            TabElectoral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            TabContacto.SuspendLayout();
            TabAddress.SuspendLayout();
            TabRol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridRoles).BeginInit();
            ToolStripRoles.SuspendLayout();
            TabOtros.SuspendLayout();
            SuspendLayout();
            // 
            // BAccept
            // 
            BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BAccept.Location = new Point(360, 353);
            BAccept.Name = "BAccept";
            BAccept.Size = new Size(75, 23);
            BAccept.TabIndex = 1;
            BAccept.Text = "&Aceptar";
            BAccept.UseVisualStyleBackColor = true;
            BAccept.Click += BAccept_Click;
            // 
            // BCancel
            // 
            BCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BCancel.Location = new Point(438, 353);
            BCancel.Name = "BCancel";
            BCancel.Size = new Size(75, 23);
            BCancel.TabIndex = 2;
            BCancel.Text = "&Cancelar";
            BCancel.UseVisualStyleBackColor = true;
            BCancel.Click += BCancel_Click;
            // 
            // TabControlCitizen
            // 
            TabControlCitizen.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabControlCitizen.Controls.Add(TabGeneral);
            TabControlCitizen.Controls.Add(TabRelationships);
            TabControlCitizen.Controls.Add(TabElectoral);
            TabControlCitizen.Controls.Add(TabContacto);
            TabControlCitizen.Controls.Add(TabAddress);
            TabControlCitizen.Controls.Add(TabRol);
            TabControlCitizen.Controls.Add(TabOtros);
            TabControlCitizen.Location = new Point(1, 1);
            TabControlCitizen.MinimumSize = new Size(404, 311);
            TabControlCitizen.Name = "TabControlCitizen";
            TabControlCitizen.SelectedIndex = 0;
            TabControlCitizen.Size = new Size(522, 346);
            TabControlCitizen.SizeMode = TabSizeMode.Fixed;
            TabControlCitizen.TabIndex = 0;
            // 
            // TabGeneral
            // 
            TabGeneral.Controls.Add(BDayYear);
            TabGeneral.Controls.Add(BDayDay);
            TabGeneral.Controls.Add(BDayMonth);
            TabGeneral.Controls.Add(KnownBirthday);
            TabGeneral.Controls.Add(BGenerateCURP);
            TabGeneral.Controls.Add(LCategory);
            TabGeneral.Controls.Add(ComboBoxCategory);
            TabGeneral.Controls.Add(MaskedTextBoxCURP);
            TabGeneral.Controls.Add(LMaternalName);
            TabGeneral.Controls.Add(TextBoxMaternalName);
            TabGeneral.Controls.Add(LPaternalName);
            TabGeneral.Controls.Add(TextBoxPaternalName);
            TabGeneral.Controls.Add(ComboBoxPoliticalParty);
            TabGeneral.Controls.Add(LPoliticalParty);
            TabGeneral.Controls.Add(LTitleFull);
            TabGeneral.Controls.Add(LCURP);
            TabGeneral.Controls.Add(TextBoxObservations);
            TabGeneral.Controls.Add(label1);
            TabGeneral.Controls.Add(ComboBoxSex);
            TabGeneral.Controls.Add(label2);
            TabGeneral.Controls.Add(ComboBoxTitle);
            TabGeneral.Controls.Add(LTitle);
            TabGeneral.Controls.Add(LName);
            TabGeneral.Controls.Add(TextBoxName);
            TabGeneral.Location = new Point(4, 24);
            TabGeneral.Name = "TabGeneral";
            TabGeneral.Padding = new Padding(3);
            TabGeneral.Size = new Size(514, 318);
            TabGeneral.TabIndex = 0;
            TabGeneral.Text = "General";
            TabGeneral.UseVisualStyleBackColor = true;
            // 
            // BDayYear
            // 
            BDayYear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BDayYear.DropDownStyle = ComboBoxStyle.DropDownList;
            BDayYear.FormattingEnabled = true;
            BDayYear.Location = new Point(444, 151);
            BDayYear.Name = "BDayYear";
            BDayYear.Size = new Size(64, 23);
            BDayYear.TabIndex = 9;
            // 
            // BDayDay
            // 
            BDayDay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BDayDay.DropDownStyle = ComboBoxStyle.DropDownList;
            BDayDay.FormattingEnabled = true;
            BDayDay.Location = new Point(398, 151);
            BDayDay.Name = "BDayDay";
            BDayDay.Size = new Size(40, 23);
            BDayDay.TabIndex = 8;
            // 
            // BDayMonth
            // 
            BDayMonth.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BDayMonth.DropDownStyle = ComboBoxStyle.DropDownList;
            BDayMonth.FormattingEnabled = true;
            BDayMonth.Location = new Point(328, 151);
            BDayMonth.Name = "BDayMonth";
            BDayMonth.Size = new Size(64, 23);
            BDayMonth.TabIndex = 7;
            // 
            // KnownBirthday
            // 
            KnownBirthday.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            KnownBirthday.AutoSize = true;
            KnownBirthday.Checked = true;
            KnownBirthday.CheckState = CheckState.Checked;
            KnownBirthday.Location = new Point(241, 153);
            KnownBirthday.Name = "KnownBirthday";
            KnownBirthday.Size = new Size(88, 19);
            KnownBirthday.TabIndex = 6;
            KnownBirthday.Text = "Nacimiento";
            KnownBirthday.UseVisualStyleBackColor = true;
            KnownBirthday.CheckedChanged += KnownBirthday_CheckedChanged;
            // 
            // BGenerateCURP
            // 
            BGenerateCURP.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BGenerateCURP.Image = Properties.Resources.Fatcow_Farm_Fresh_Widgets_16;
            BGenerateCURP.Location = new Point(477, 180);
            BGenerateCURP.Name = "BGenerateCURP";
            BGenerateCURP.Size = new Size(31, 23);
            BGenerateCURP.TabIndex = 11;
            BGenerateCURP.TextImageRelation = TextImageRelation.ImageBeforeText;
            BGenerateCURP.UseVisualStyleBackColor = true;
            BGenerateCURP.Click += BGenerateCURP_Click;
            // 
            // LCategory
            // 
            LCategory.AutoSize = true;
            LCategory.Location = new Point(7, 38);
            LCategory.Name = "LCategory";
            LCategory.Size = new Size(58, 15);
            LCategory.TabIndex = 41;
            LCategory.Text = "Categoría";
            // 
            // ComboBoxCategory
            // 
            ComboBoxCategory.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxCategory.FormattingEnabled = true;
            ComboBoxCategory.Location = new Point(79, 35);
            ComboBoxCategory.Name = "ComboBoxCategory";
            ComboBoxCategory.Size = new Size(429, 23);
            ComboBoxCategory.TabIndex = 1;
            // 
            // MaskedTextBoxCURP
            // 
            MaskedTextBoxCURP.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            MaskedTextBoxCURP.Location = new Point(79, 180);
            MaskedTextBoxCURP.Mask = "AAAAAAAAAAAAAAAAAA";
            MaskedTextBoxCURP.Name = "MaskedTextBoxCURP";
            MaskedTextBoxCURP.PromptChar = ' ';
            MaskedTextBoxCURP.Size = new Size(392, 23);
            MaskedTextBoxCURP.TabIndex = 10;
            // 
            // LMaternalName
            // 
            LMaternalName.AutoSize = true;
            LMaternalName.Location = new Point(7, 124);
            LMaternalName.Name = "LMaternalName";
            LMaternalName.Size = new Size(66, 15);
            LMaternalName.TabIndex = 39;
            LMaternalName.Text = "A. Materno";
            // 
            // TextBoxMaternalName
            // 
            TextBoxMaternalName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxMaternalName.Location = new Point(79, 122);
            TextBoxMaternalName.Name = "TextBoxMaternalName";
            TextBoxMaternalName.Size = new Size(429, 23);
            TextBoxMaternalName.TabIndex = 4;
            // 
            // LPaternalName
            // 
            LPaternalName.AutoSize = true;
            LPaternalName.Location = new Point(7, 95);
            LPaternalName.Name = "LPaternalName";
            LPaternalName.Size = new Size(62, 15);
            LPaternalName.TabIndex = 37;
            LPaternalName.Text = "A. Paterno";
            // 
            // TextBoxPaternalName
            // 
            TextBoxPaternalName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxPaternalName.Location = new Point(79, 93);
            TextBoxPaternalName.Name = "TextBoxPaternalName";
            TextBoxPaternalName.Size = new Size(429, 23);
            TextBoxPaternalName.TabIndex = 3;
            // 
            // ComboBoxPoliticalParty
            // 
            ComboBoxPoliticalParty.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxPoliticalParty.FormattingEnabled = true;
            ComboBoxPoliticalParty.Location = new Point(79, 282);
            ComboBoxPoliticalParty.Name = "ComboBoxPoliticalParty";
            ComboBoxPoliticalParty.Size = new Size(116, 23);
            ComboBoxPoliticalParty.TabIndex = 13;
            // 
            // LPoliticalParty
            // 
            LPoliticalParty.AutoSize = true;
            LPoliticalParty.Location = new Point(7, 285);
            LPoliticalParty.Name = "LPoliticalParty";
            LPoliticalParty.Size = new Size(45, 15);
            LPoliticalParty.TabIndex = 28;
            LPoliticalParty.Text = "Partido";
            // 
            // LTitleFull
            // 
            LTitleFull.AutoSize = true;
            LTitleFull.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LTitleFull.ForeColor = SystemColors.HotTrack;
            LTitleFull.Location = new Point(201, 9);
            LTitleFull.Name = "LTitleFull";
            LTitleFull.Size = new Size(72, 15);
            LTitleFull.TabIndex = 35;
            LTitleFull.Text = "- Ciudadano";
            // 
            // LCURP
            // 
            LCURP.AutoSize = true;
            LCURP.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            LCURP.Location = new Point(7, 182);
            LCURP.Name = "LCURP";
            LCURP.Size = new Size(37, 15);
            LCURP.TabIndex = 33;
            LCURP.Text = "CURP";
            LCURP.Click += LCURP_Click;
            // 
            // TextBoxObservations
            // 
            TextBoxObservations.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxObservations.Location = new Point(79, 209);
            TextBoxObservations.Multiline = true;
            TextBoxObservations.Name = "TextBoxObservations";
            TextBoxObservations.Size = new Size(429, 67);
            TextBoxObservations.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(7, 211);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 31;
            label1.Text = "Notas";
            // 
            // ComboBoxSex
            // 
            ComboBoxSex.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxSex.FormattingEnabled = true;
            ComboBoxSex.Location = new Point(79, 151);
            ComboBoxSex.Name = "ComboBoxSex";
            ComboBoxSex.Size = new Size(116, 23);
            ComboBoxSex.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 154);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 27;
            label2.Text = "Sexo";
            // 
            // ComboBoxTitle
            // 
            ComboBoxTitle.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxTitle.FormattingEnabled = true;
            ComboBoxTitle.Location = new Point(79, 6);
            ComboBoxTitle.Name = "ComboBoxTitle";
            ComboBoxTitle.Size = new Size(116, 23);
            ComboBoxTitle.TabIndex = 0;
            ComboBoxTitle.SelectedIndexChanged += ComboBoxTitle_SelectedIndexChanged;
            // 
            // LTitle
            // 
            LTitle.AutoSize = true;
            LTitle.Location = new Point(7, 9);
            LTitle.Name = "LTitle";
            LTitle.Size = new Size(38, 15);
            LTitle.TabIndex = 24;
            LTitle.Text = "Título";
            // 
            // LName
            // 
            LName.AutoSize = true;
            LName.Location = new Point(7, 66);
            LName.Name = "LName";
            LName.Size = new Size(51, 15);
            LName.TabIndex = 23;
            LName.Text = "Nombre";
            // 
            // TextBoxName
            // 
            TextBoxName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxName.Location = new Point(79, 64);
            TextBoxName.Name = "TextBoxName";
            TextBoxName.Size = new Size(429, 23);
            TextBoxName.TabIndex = 2;
            // 
            // TabRelationships
            // 
            TabRelationships.Controls.Add(NumPriorityScore);
            TabRelationships.Controls.Add(label4);
            TabRelationships.Controls.Add(EndDate);
            TabRelationships.Controls.Add(KnownEndDate);
            TabRelationships.Controls.Add(RelationshipEnabled);
            TabRelationships.Controls.Add(RelationshipNotes);
            TabRelationships.Controls.Add(LRelationshipNotes);
            TabRelationships.Controls.Add(StartDate);
            TabRelationships.Controls.Add(KnownStartDate);
            TabRelationships.Controls.Add(LRelationship);
            TabRelationships.Controls.Add(Relationship);
            TabRelationships.Controls.Add(NAffinity);
            TabRelationships.Controls.Add(LAffinity);
            TabRelationships.Location = new Point(4, 24);
            TabRelationships.Name = "TabRelationships";
            TabRelationships.Size = new Size(514, 318);
            TabRelationships.TabIndex = 5;
            TabRelationships.Text = "Relación";
            TabRelationships.UseVisualStyleBackColor = true;
            // 
            // NumPriorityScore
            // 
            NumPriorityScore.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NumPriorityScore.Enabled = false;
            NumPriorityScore.Location = new Point(65, 89);
            NumPriorityScore.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            NumPriorityScore.Name = "NumPriorityScore";
            NumPriorityScore.Size = new Size(440, 23);
            NumPriorityScore.TabIndex = 38;
            NumPriorityScore.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 91);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 37;
            label4.Text = "Prioridad";
            // 
            // EndDate
            // 
            EndDate.Enabled = false;
            EndDate.Format = DateTimePickerFormat.Short;
            EndDate.Location = new Point(125, 147);
            EndDate.Name = "EndDate";
            EndDate.Size = new Size(118, 23);
            EndDate.TabIndex = 36;
            // 
            // KnownEndDate
            // 
            KnownEndDate.AutoSize = true;
            KnownEndDate.Enabled = false;
            KnownEndDate.Location = new Point(64, 150);
            KnownEndDate.Name = "KnownEndDate";
            KnownEndDate.Size = new Size(45, 19);
            KnownEndDate.TabIndex = 35;
            KnownEndDate.Text = "Fin ";
            KnownEndDate.UseVisualStyleBackColor = true;
            KnownEndDate.CheckedChanged += KnownEndDate_CheckedChanged;
            // 
            // RelationshipEnabled
            // 
            RelationshipEnabled.AutoSize = true;
            RelationshipEnabled.Location = new Point(65, 6);
            RelationshipEnabled.Name = "RelationshipEnabled";
            RelationshipEnabled.Size = new Size(80, 19);
            RelationshipEnabled.TabIndex = 34;
            RelationshipEnabled.Text = "Habilitada";
            RelationshipEnabled.UseVisualStyleBackColor = true;
            RelationshipEnabled.CheckedChanged += RelationshipEnabled_CheckedChanged;
            // 
            // RelationshipNotes
            // 
            RelationshipNotes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            RelationshipNotes.Enabled = false;
            RelationshipNotes.Location = new Point(65, 176);
            RelationshipNotes.Multiline = true;
            RelationshipNotes.Name = "RelationshipNotes";
            RelationshipNotes.Size = new Size(440, 136);
            RelationshipNotes.TabIndex = 32;
            // 
            // LRelationshipNotes
            // 
            LRelationshipNotes.AutoSize = true;
            LRelationshipNotes.Location = new Point(7, 179);
            LRelationshipNotes.Name = "LRelationshipNotes";
            LRelationshipNotes.Size = new Size(38, 15);
            LRelationshipNotes.TabIndex = 33;
            LRelationshipNotes.Text = "Notas";
            // 
            // StartDate
            // 
            StartDate.Enabled = false;
            StartDate.Format = DateTimePickerFormat.Short;
            StartDate.Location = new Point(125, 118);
            StartDate.Name = "StartDate";
            StartDate.Size = new Size(118, 23);
            StartDate.TabIndex = 5;
            // 
            // KnownStartDate
            // 
            KnownStartDate.AutoSize = true;
            KnownStartDate.Enabled = false;
            KnownStartDate.Location = new Point(64, 121);
            KnownStartDate.Name = "KnownStartDate";
            KnownStartDate.Size = new Size(55, 19);
            KnownStartDate.TabIndex = 4;
            KnownStartDate.Text = "Inicio";
            KnownStartDate.UseVisualStyleBackColor = true;
            KnownStartDate.CheckedChanged += KnownStartDate_CheckedChanged;
            // 
            // LRelationship
            // 
            LRelationship.AutoSize = true;
            LRelationship.Location = new Point(7, 34);
            LRelationship.Name = "LRelationship";
            LRelationship.Size = new Size(47, 15);
            LRelationship.TabIndex = 3;
            LRelationship.Text = "Vínculo";
            // 
            // Relationship
            // 
            Relationship.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Relationship.DropDownStyle = ComboBoxStyle.DropDownList;
            Relationship.Enabled = false;
            Relationship.FormattingEnabled = true;
            Relationship.Location = new Point(65, 31);
            Relationship.Name = "Relationship";
            Relationship.Size = new Size(440, 23);
            Relationship.TabIndex = 2;
            // 
            // NAffinity
            // 
            NAffinity.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            NAffinity.Enabled = false;
            NAffinity.Location = new Point(65, 60);
            NAffinity.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            NAffinity.Name = "NAffinity";
            NAffinity.Size = new Size(440, 23);
            NAffinity.TabIndex = 1;
            // 
            // LAffinity
            // 
            LAffinity.AutoSize = true;
            LAffinity.Location = new Point(7, 62);
            LAffinity.Name = "LAffinity";
            LAffinity.Size = new Size(52, 15);
            LAffinity.TabIndex = 0;
            LAffinity.Text = "Afinidad";
            // 
            // TabElectoral
            // 
            TabElectoral.Controls.Add(KnownPoliticalRegisterDate);
            TabElectoral.Controls.Add(PoliticalRegisterDate);
            TabElectoral.Controls.Add(IsPoliticalActivist);
            TabElectoral.Controls.Add(pictureBox1);
            TabElectoral.Controls.Add(VoterSection);
            TabElectoral.Controls.Add(LVoterSection);
            TabElectoral.Controls.Add(VoterCIC);
            TabElectoral.Controls.Add(LVoterCIC);
            TabElectoral.Controls.Add(VoterOCR);
            TabElectoral.Controls.Add(LVoterOCR);
            TabElectoral.Controls.Add(VoterCode);
            TabElectoral.Controls.Add(LElectorCode);
            TabElectoral.Location = new Point(4, 24);
            TabElectoral.Name = "TabElectoral";
            TabElectoral.Padding = new Padding(3);
            TabElectoral.Size = new Size(514, 318);
            TabElectoral.TabIndex = 4;
            TabElectoral.Text = "Electoral";
            TabElectoral.UseVisualStyleBackColor = true;
            // 
            // KnownPoliticalRegisterDate
            // 
            KnownPoliticalRegisterDate.AutoSize = true;
            KnownPoliticalRegisterDate.Location = new Point(132, 280);
            KnownPoliticalRegisterDate.Name = "KnownPoliticalRegisterDate";
            KnownPoliticalRegisterDate.Size = new Size(137, 19);
            KnownPoliticalRegisterDate.TabIndex = 12;
            KnownPoliticalRegisterDate.Text = "Inscripción al padrón";
            KnownPoliticalRegisterDate.UseVisualStyleBackColor = true;
            KnownPoliticalRegisterDate.CheckedChanged += KnownPoliticalRegisterDate_CheckedChanged;
            // 
            // PoliticalRegisterDate
            // 
            PoliticalRegisterDate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PoliticalRegisterDate.CustomFormat = "dd/MM/yyyy";
            PoliticalRegisterDate.Enabled = false;
            PoliticalRegisterDate.Format = DateTimePickerFormat.Custom;
            PoliticalRegisterDate.Location = new Point(277, 278);
            PoliticalRegisterDate.Name = "PoliticalRegisterDate";
            PoliticalRegisterDate.Size = new Size(228, 23);
            PoliticalRegisterDate.TabIndex = 11;
            // 
            // IsPoliticalActivist
            // 
            IsPoliticalActivist.AutoSize = true;
            IsPoliticalActivist.Location = new Point(132, 256);
            IsPoliticalActivist.Name = "IsPoliticalActivist";
            IsPoliticalActivist.Size = new Size(87, 19);
            IsPoliticalActivist.TabIndex = 9;
            IsPoliticalActivist.Text = "Es militante";
            IsPoliticalActivist.UseVisualStyleBackColor = true;
            IsPoliticalActivist.CheckedChanged += IsPoliticalActivist_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Image = Properties.Resources.credencial_modeloEG;
            pictureBox1.Location = new Point(10, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(495, 125);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // VoterSection
            // 
            VoterSection.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VoterSection.Location = new Point(132, 227);
            VoterSection.Name = "VoterSection";
            VoterSection.Size = new Size(373, 23);
            VoterSection.TabIndex = 3;
            // 
            // LVoterSection
            // 
            LVoterSection.AutoSize = true;
            LVoterSection.Location = new Point(10, 230);
            LVoterSection.Name = "LVoterSection";
            LVoterSection.Size = new Size(48, 15);
            LVoterSection.TabIndex = 6;
            LVoterSection.Text = "Sección";
            // 
            // VoterCIC
            // 
            VoterCIC.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VoterCIC.Location = new Point(132, 198);
            VoterCIC.Name = "VoterCIC";
            VoterCIC.Size = new Size(373, 23);
            VoterCIC.TabIndex = 2;
            // 
            // LVoterCIC
            // 
            LVoterCIC.AutoSize = true;
            LVoterCIC.Location = new Point(10, 201);
            LVoterCIC.Name = "LVoterCIC";
            LVoterCIC.Size = new Size(109, 15);
            LVoterCIC.TabIndex = 4;
            LVoterCIC.Text = "Id. Credencial (CIC)";
            // 
            // VoterOCR
            // 
            VoterOCR.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VoterOCR.Location = new Point(132, 169);
            VoterOCR.Name = "VoterOCR";
            VoterOCR.Size = new Size(373, 23);
            VoterOCR.TabIndex = 1;
            // 
            // LVoterOCR
            // 
            LVoterOCR.AutoSize = true;
            LVoterOCR.Location = new Point(10, 172);
            LVoterOCR.Name = "LVoterOCR";
            LVoterOCR.Size = new Size(116, 15);
            LVoterOCR.TabIndex = 2;
            LVoterOCR.Text = "Id. Ciudadano (OCR)";
            // 
            // VoterCode
            // 
            VoterCode.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VoterCode.Location = new Point(132, 140);
            VoterCode.Name = "VoterCode";
            VoterCode.Size = new Size(373, 23);
            VoterCode.TabIndex = 0;
            // 
            // LElectorCode
            // 
            LElectorCode.AutoSize = true;
            LElectorCode.Location = new Point(10, 143);
            LElectorCode.Name = "LElectorCode";
            LElectorCode.Size = new Size(91, 15);
            LElectorCode.TabIndex = 0;
            LElectorCode.Text = "Clave de elector";
            // 
            // TabContacto
            // 
            TabContacto.Controls.Add(PhoneSyncExtension);
            TabContacto.Controls.Add(label3);
            TabContacto.Controls.Add(PhoneSync);
            TabContacto.Controls.Add(LPhoneSync);
            TabContacto.Controls.Add(TelSyncEnabled);
            TabContacto.Controls.Add(Phone3Extension);
            TabContacto.Controls.Add(LPhone3Extension);
            TabContacto.Controls.Add(Phone3);
            TabContacto.Controls.Add(LPhone3);
            TabContacto.Controls.Add(Phone2Extension);
            TabContacto.Controls.Add(LPhone2Extension);
            TabContacto.Controls.Add(Phone2);
            TabContacto.Controls.Add(LPhone2);
            TabContacto.Controls.Add(TextBoxEmail);
            TabContacto.Controls.Add(LEmail);
            TabContacto.Controls.Add(LAssitantCellphone);
            TabContacto.Controls.Add(LAssistantPhone);
            TabContacto.Controls.Add(LAssitantName);
            TabContacto.Controls.Add(LAssistent);
            TabContacto.Controls.Add(ComboBoxAssistant);
            TabContacto.Controls.Add(TextBoxCellphone);
            TabContacto.Controls.Add(LCellphone);
            TabContacto.Controls.Add(TextBoxPhoneExtension);
            TabContacto.Controls.Add(LPhoneExtension);
            TabContacto.Controls.Add(TextBoxPhone);
            TabContacto.Controls.Add(LPhone);
            TabContacto.Location = new Point(4, 24);
            TabContacto.Name = "TabContacto";
            TabContacto.Padding = new Padding(3);
            TabContacto.Size = new Size(514, 318);
            TabContacto.TabIndex = 1;
            TabContacto.Text = "Contacto";
            TabContacto.UseVisualStyleBackColor = true;
            // 
            // PhoneSyncExtension
            // 
            PhoneSyncExtension.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            PhoneSyncExtension.Location = new Point(407, 276);
            PhoneSyncExtension.Name = "PhoneSyncExtension";
            PhoneSyncExtension.Size = new Size(101, 23);
            PhoneSyncExtension.TabIndex = 51;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(376, 279);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 53;
            label3.Text = "Ext.";
            // 
            // PhoneSync
            // 
            PhoneSync.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            PhoneSync.Location = new Point(97, 276);
            PhoneSync.Name = "PhoneSync";
            PhoneSync.Size = new Size(273, 23);
            PhoneSync.TabIndex = 50;
            // 
            // LPhoneSync
            // 
            LPhoneSync.AutoSize = true;
            LPhoneSync.Location = new Point(7, 279);
            LPhoneSync.Name = "LPhoneSync";
            LPhoneSync.Size = new Size(84, 15);
            LPhoneSync.TabIndex = 52;
            LPhoneSync.Text = "Teléfono Sync.";
            // 
            // TelSyncEnabled
            // 
            TelSyncEnabled.AutoSize = true;
            TelSyncEnabled.Location = new Point(97, 251);
            TelSyncEnabled.Name = "TelSyncEnabled";
            TelSyncEnabled.Size = new Size(332, 19);
            TelSyncEnabled.TabIndex = 49;
            TelSyncEnabled.Text = "Sincronizar número de contacto con el directorio CardDav";
            TelSyncEnabled.UseVisualStyleBackColor = true;
            // 
            // Phone3Extension
            // 
            Phone3Extension.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Phone3Extension.Location = new Point(407, 67);
            Phone3Extension.Name = "Phone3Extension";
            Phone3Extension.Size = new Size(101, 23);
            Phone3Extension.TabIndex = 46;
            // 
            // LPhone3Extension
            // 
            LPhone3Extension.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LPhone3Extension.AutoSize = true;
            LPhone3Extension.Location = new Point(376, 70);
            LPhone3Extension.Name = "LPhone3Extension";
            LPhone3Extension.Size = new Size(25, 15);
            LPhone3Extension.TabIndex = 48;
            LPhone3Extension.Text = "Ext.";
            // 
            // Phone3
            // 
            Phone3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Phone3.Location = new Point(97, 67);
            Phone3.Name = "Phone3";
            Phone3.Size = new Size(273, 23);
            Phone3.TabIndex = 45;
            // 
            // LPhone3
            // 
            LPhone3.AutoSize = true;
            LPhone3.Location = new Point(7, 70);
            LPhone3.Name = "LPhone3";
            LPhone3.Size = new Size(62, 15);
            LPhone3.TabIndex = 47;
            LPhone3.Text = "Teléfono 3";
            // 
            // Phone2Extension
            // 
            Phone2Extension.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Phone2Extension.Location = new Point(407, 38);
            Phone2Extension.Name = "Phone2Extension";
            Phone2Extension.Size = new Size(101, 23);
            Phone2Extension.TabIndex = 42;
            // 
            // LPhone2Extension
            // 
            LPhone2Extension.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LPhone2Extension.AutoSize = true;
            LPhone2Extension.Location = new Point(376, 41);
            LPhone2Extension.Name = "LPhone2Extension";
            LPhone2Extension.Size = new Size(25, 15);
            LPhone2Extension.TabIndex = 44;
            LPhone2Extension.Text = "Ext.";
            // 
            // Phone2
            // 
            Phone2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Phone2.Location = new Point(97, 38);
            Phone2.Name = "Phone2";
            Phone2.Size = new Size(273, 23);
            Phone2.TabIndex = 41;
            // 
            // LPhone2
            // 
            LPhone2.AutoSize = true;
            LPhone2.Location = new Point(7, 41);
            LPhone2.Name = "LPhone2";
            LPhone2.Size = new Size(62, 15);
            LPhone2.TabIndex = 43;
            LPhone2.Text = "Teléfono 2";
            // 
            // TextBoxEmail
            // 
            TextBoxEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxEmail.Location = new Point(97, 125);
            TextBoxEmail.Name = "TextBoxEmail";
            TextBoxEmail.Size = new Size(411, 23);
            TextBoxEmail.TabIndex = 3;
            // 
            // LEmail
            // 
            LEmail.AutoSize = true;
            LEmail.Location = new Point(7, 128);
            LEmail.Name = "LEmail";
            LEmail.Size = new Size(41, 15);
            LEmail.TabIndex = 40;
            LEmail.Text = "E-mail";
            // 
            // LAssitantCellphone
            // 
            LAssitantCellphone.AutoSize = true;
            LAssitantCellphone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LAssitantCellphone.ForeColor = SystemColors.HotTrack;
            LAssitantCellphone.Location = new Point(97, 221);
            LAssitantCellphone.Name = "LAssitantCellphone";
            LAssitantCellphone.Size = new Size(105, 15);
            LAssitantCellphone.TabIndex = 38;
            LAssitantCellphone.Text = "Cel. 446 843 2332";
            // 
            // LAssistantPhone
            // 
            LAssistantPhone.AutoSize = true;
            LAssistantPhone.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LAssistantPhone.ForeColor = SystemColors.HotTrack;
            LAssistantPhone.Location = new Point(97, 203);
            LAssistantPhone.Name = "LAssistantPhone";
            LAssistantPhone.Size = new Size(157, 15);
            LAssistantPhone.TabIndex = 37;
            LAssistantPhone.Text = "Tel. 449 253 2334 Ext. 2932";
            // 
            // LAssitantName
            // 
            LAssitantName.AutoSize = true;
            LAssitantName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LAssitantName.ForeColor = SystemColors.HotTrack;
            LAssitantName.Location = new Point(97, 185);
            LAssitantName.Name = "LAssitantName";
            LAssitantName.Size = new Size(149, 15);
            LAssitantName.TabIndex = 36;
            LAssitantName.Text = "Nombre Asistente Apellido";
            // 
            // LAssistent
            // 
            LAssistent.AutoSize = true;
            LAssistent.Location = new Point(7, 157);
            LAssistent.Name = "LAssistent";
            LAssistent.Size = new Size(55, 15);
            LAssistent.TabIndex = 21;
            LAssistent.Text = "Asistente";
            // 
            // ComboBoxAssistant
            // 
            ComboBoxAssistant.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ComboBoxAssistant.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxAssistant.FormattingEnabled = true;
            ComboBoxAssistant.Location = new Point(97, 154);
            ComboBoxAssistant.Name = "ComboBoxAssistant";
            ComboBoxAssistant.Size = new Size(411, 23);
            ComboBoxAssistant.TabIndex = 4;
            ComboBoxAssistant.SelectedIndexChanged += ComboBoxAssistant_SelectedIndexChanged;
            // 
            // TextBoxCellphone
            // 
            TextBoxCellphone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxCellphone.Location = new Point(97, 96);
            TextBoxCellphone.Name = "TextBoxCellphone";
            TextBoxCellphone.Size = new Size(273, 23);
            TextBoxCellphone.TabIndex = 2;
            // 
            // LCellphone
            // 
            LCellphone.AutoSize = true;
            LCellphone.Location = new Point(7, 99);
            LCellphone.Name = "LCellphone";
            LCellphone.Size = new Size(44, 15);
            LCellphone.TabIndex = 18;
            LCellphone.Text = "Celular";
            // 
            // TextBoxPhoneExtension
            // 
            TextBoxPhoneExtension.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            TextBoxPhoneExtension.Location = new Point(407, 9);
            TextBoxPhoneExtension.Name = "TextBoxPhoneExtension";
            TextBoxPhoneExtension.Size = new Size(101, 23);
            TextBoxPhoneExtension.TabIndex = 1;
            // 
            // LPhoneExtension
            // 
            LPhoneExtension.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LPhoneExtension.AutoSize = true;
            LPhoneExtension.Location = new Point(376, 12);
            LPhoneExtension.Name = "LPhoneExtension";
            LPhoneExtension.Size = new Size(25, 15);
            LPhoneExtension.TabIndex = 16;
            LPhoneExtension.Text = "Ext.";
            // 
            // TextBoxPhone
            // 
            TextBoxPhone.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxPhone.Location = new Point(97, 9);
            TextBoxPhone.Name = "TextBoxPhone";
            TextBoxPhone.Size = new Size(273, 23);
            TextBoxPhone.TabIndex = 0;
            // 
            // LPhone
            // 
            LPhone.AutoSize = true;
            LPhone.Location = new Point(7, 12);
            LPhone.Name = "LPhone";
            LPhone.Size = new Size(53, 15);
            LPhone.TabIndex = 14;
            LPhone.Text = "Teléfono";
            // 
            // TabAddress
            // 
            TabAddress.Controls.Add(TextBoxDistrict);
            TabAddress.Controls.Add(LDistrict);
            TabAddress.Controls.Add(LCountryFullName);
            TabAddress.Controls.Add(LCountry);
            TabAddress.Controls.Add(ComboBoxCountry);
            TabAddress.Controls.Add(TextBoxCity);
            TabAddress.Controls.Add(LCity);
            TabAddress.Controls.Add(TextBoxState);
            TabAddress.Controls.Add(LState);
            TabAddress.Controls.Add(TextBoxPostalCode);
            TabAddress.Controls.Add(LPostalCode);
            TabAddress.Controls.Add(TextBoxInteriorNumber);
            TabAddress.Controls.Add(LInteriorNumber);
            TabAddress.Controls.Add(TextBoxNumber);
            TabAddress.Controls.Add(LNumber);
            TabAddress.Controls.Add(TextBoxStreet);
            TabAddress.Controls.Add(LStreet);
            TabAddress.Location = new Point(4, 24);
            TabAddress.Name = "TabAddress";
            TabAddress.Padding = new Padding(3);
            TabAddress.Size = new Size(514, 318);
            TabAddress.TabIndex = 3;
            TabAddress.Text = "Dirección";
            TabAddress.UseVisualStyleBackColor = true;
            // 
            // TextBoxDistrict
            // 
            TextBoxDistrict.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxDistrict.Location = new Point(57, 67);
            TextBoxDistrict.Name = "TextBoxDistrict";
            TextBoxDistrict.Size = new Size(448, 23);
            TextBoxDistrict.TabIndex = 38;
            // 
            // LDistrict
            // 
            LDistrict.AutoSize = true;
            LDistrict.Location = new Point(7, 70);
            LDistrict.Name = "LDistrict";
            LDistrict.Size = new Size(48, 15);
            LDistrict.TabIndex = 39;
            LDistrict.Text = "Colonia";
            // 
            // LCountryFullName
            // 
            LCountryFullName.AutoSize = true;
            LCountryFullName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LCountryFullName.ForeColor = SystemColors.HotTrack;
            LCountryFullName.Location = new Point(183, 186);
            LCountryFullName.Name = "LCountryFullName";
            LCountryFullName.Size = new Size(155, 15);
            LCountryFullName.TabIndex = 37;
            LCountryFullName.Text = "- Estados Unidos Mexicanos";
            // 
            // LCountry
            // 
            LCountry.AutoSize = true;
            LCountry.Location = new Point(7, 186);
            LCountry.Name = "LCountry";
            LCountry.Size = new Size(28, 15);
            LCountry.TabIndex = 25;
            LCountry.Text = "País";
            // 
            // ComboBoxCountry
            // 
            ComboBoxCountry.FormattingEnabled = true;
            ComboBoxCountry.Location = new Point(57, 183);
            ComboBoxCountry.Name = "ComboBoxCountry";
            ComboBoxCountry.Size = new Size(120, 23);
            ComboBoxCountry.TabIndex = 6;
            ComboBoxCountry.SelectedIndexChanged += ComboBoxCountry_SelectedIndexChanged;
            // 
            // TextBoxCity
            // 
            TextBoxCity.Location = new Point(57, 96);
            TextBoxCity.Name = "TextBoxCity";
            TextBoxCity.Size = new Size(120, 23);
            TextBoxCity.TabIndex = 3;
            TextBoxCity.Text = "Aguascalientes";
            // 
            // LCity
            // 
            LCity.AutoSize = true;
            LCity.Location = new Point(6, 99);
            LCity.Name = "LCity";
            LCity.Size = new Size(45, 15);
            LCity.TabIndex = 22;
            LCity.Text = "Ciudad";
            // 
            // TextBoxState
            // 
            TextBoxState.Location = new Point(57, 125);
            TextBoxState.Name = "TextBoxState";
            TextBoxState.Size = new Size(120, 23);
            TextBoxState.TabIndex = 4;
            TextBoxState.Text = "Aguascalientes";
            // 
            // LState
            // 
            LState.AutoSize = true;
            LState.Location = new Point(6, 128);
            LState.Name = "LState";
            LState.Size = new Size(42, 15);
            LState.TabIndex = 20;
            LState.Text = "Estado";
            // 
            // TextBoxPostalCode
            // 
            TextBoxPostalCode.Location = new Point(57, 154);
            TextBoxPostalCode.Name = "TextBoxPostalCode";
            TextBoxPostalCode.Size = new Size(120, 23);
            TextBoxPostalCode.TabIndex = 5;
            // 
            // LPostalCode
            // 
            LPostalCode.AutoSize = true;
            LPostalCode.Location = new Point(6, 157);
            LPostalCode.Name = "LPostalCode";
            LPostalCode.Size = new Size(28, 15);
            LPostalCode.TabIndex = 18;
            LPostalCode.Text = "C.P.";
            // 
            // TextBoxInteriorNumber
            // 
            TextBoxInteriorNumber.Location = new Point(256, 38);
            TextBoxInteriorNumber.Name = "TextBoxInteriorNumber";
            TextBoxInteriorNumber.Size = new Size(101, 23);
            TextBoxInteriorNumber.TabIndex = 2;
            // 
            // LInteriorNumber
            // 
            LInteriorNumber.AutoSize = true;
            LInteriorNumber.Location = new Point(183, 41);
            LInteriorNumber.Name = "LInteriorNumber";
            LInteriorNumber.Size = new Size(67, 15);
            LInteriorNumber.TabIndex = 16;
            LInteriorNumber.Text = "No. Interior";
            // 
            // TextBoxNumber
            // 
            TextBoxNumber.Location = new Point(57, 38);
            TextBoxNumber.Name = "TextBoxNumber";
            TextBoxNumber.Size = new Size(120, 23);
            TextBoxNumber.TabIndex = 1;
            // 
            // LNumber
            // 
            LNumber.AutoSize = true;
            LNumber.Location = new Point(6, 41);
            LNumber.Name = "LNumber";
            LNumber.Size = new Size(26, 15);
            LNumber.TabIndex = 14;
            LNumber.Text = "No.";
            // 
            // TextBoxStreet
            // 
            TextBoxStreet.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            TextBoxStreet.Location = new Point(57, 9);
            TextBoxStreet.Name = "TextBoxStreet";
            TextBoxStreet.Size = new Size(448, 23);
            TextBoxStreet.TabIndex = 0;
            // 
            // LStreet
            // 
            LStreet.AutoSize = true;
            LStreet.Location = new Point(7, 12);
            LStreet.Name = "LStreet";
            LStreet.Size = new Size(33, 15);
            LStreet.TabIndex = 12;
            LStreet.Text = "Calle";
            // 
            // TabRol
            // 
            TabRol.Controls.Add(DataGridRoles);
            TabRol.Controls.Add(ToolStripRoles);
            TabRol.Location = new Point(4, 24);
            TabRol.Name = "TabRol";
            TabRol.Padding = new Padding(3);
            TabRol.Size = new Size(514, 318);
            TabRol.TabIndex = 2;
            TabRol.Text = "Cargos";
            TabRol.UseVisualStyleBackColor = true;
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
            DataGridRoles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
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
            DataGridRoles.ImeMode = ImeMode.NoControl;
            DataGridRoles.Location = new Point(3, 28);
            DataGridRoles.MultiSelect = false;
            DataGridRoles.Name = "DataGridRoles";
            DataGridRoles.ReadOnly = true;
            DataGridRoles.RowHeadersVisible = false;
            DataGridRoles.RowTemplate.Height = 20;
            DataGridRoles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DataGridRoles.ShowCellToolTips = false;
            DataGridRoles.Size = new Size(508, 287);
            DataGridRoles.StandardTab = true;
            DataGridRoles.TabIndex = 0;
            DataGridRoles.CellFormatting += DataGridRoles_CellFormatting;
            DataGridRoles.SelectionChanged += DataGridRoles_SelectionChanged;
            // 
            // ToolStripRoles
            // 
            ToolStripRoles.GripStyle = ToolStripGripStyle.Hidden;
            ToolStripRoles.Items.AddRange(new ToolStripItem[] { BAddRole, BEditRole, BDeleteRole, BPositionUpRole, BPositionDownRole });
            ToolStripRoles.Location = new Point(3, 3);
            ToolStripRoles.Name = "ToolStripRoles";
            ToolStripRoles.RenderMode = ToolStripRenderMode.System;
            ToolStripRoles.Size = new Size(508, 25);
            ToolStripRoles.TabIndex = 1;
            ToolStripRoles.Text = "ToolStripRoles";
            // 
            // BAddRole
            // 
            BAddRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Add_16;
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
            BDeleteRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete_16;
            BDeleteRole.ImageTransparentColor = Color.Magenta;
            BDeleteRole.Margin = new Padding(1, 2, 1, 2);
            BDeleteRole.Name = "BDeleteRole";
            BDeleteRole.Padding = new Padding(2, 0, 2, 0);
            BDeleteRole.Size = new Size(63, 21);
            BDeleteRole.Text = "&Borrar";
            BDeleteRole.Click += BDeleteRole_Click;
            // 
            // BPositionUpRole
            // 
            BPositionUpRole.Alignment = ToolStripItemAlignment.Right;
            BPositionUpRole.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BPositionUpRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Bullet_arrow_up_16;
            BPositionUpRole.ImageTransparentColor = Color.Magenta;
            BPositionUpRole.Margin = new Padding(1, 2, 1, 2);
            BPositionUpRole.Name = "BPositionUpRole";
            BPositionUpRole.Padding = new Padding(2, 0, 2, 0);
            BPositionUpRole.Size = new Size(24, 21);
            BPositionUpRole.Text = "Bajar posición";
            BPositionUpRole.Click += BPositionUpRole_Click;
            // 
            // BPositionDownRole
            // 
            BPositionDownRole.Alignment = ToolStripItemAlignment.Right;
            BPositionDownRole.DisplayStyle = ToolStripItemDisplayStyle.Image;
            BPositionDownRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Bullet_arrow_down_16;
            BPositionDownRole.ImageTransparentColor = Color.Magenta;
            BPositionDownRole.Margin = new Padding(1, 2, 1, 2);
            BPositionDownRole.Name = "BPositionDownRole";
            BPositionDownRole.Padding = new Padding(2, 0, 2, 0);
            BPositionDownRole.Size = new Size(24, 21);
            BPositionDownRole.Text = "Subir posición";
            BPositionDownRole.Click += BPositionDownRole_Click;
            // 
            // TabOtros
            // 
            TabOtros.Controls.Add(VerificationAuthor);
            TabOtros.Controls.Add(LVerificationAuthor);
            TabOtros.Controls.Add(LVerificationDate);
            TabOtros.Controls.Add(VerificationDate);
            TabOtros.Controls.Add(Verified);
            TabOtros.Location = new Point(4, 24);
            TabOtros.Name = "TabOtros";
            TabOtros.Size = new Size(514, 318);
            TabOtros.TabIndex = 6;
            TabOtros.Text = "Otros";
            TabOtros.UseVisualStyleBackColor = true;
            // 
            // VerificationAuthor
            // 
            VerificationAuthor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            VerificationAuthor.Enabled = false;
            VerificationAuthor.Location = new Point(127, 73);
            VerificationAuthor.Name = "VerificationAuthor";
            VerificationAuthor.Size = new Size(378, 23);
            VerificationAuthor.TabIndex = 51;
            // 
            // LVerificationAuthor
            // 
            LVerificationAuthor.AutoSize = true;
            LVerificationAuthor.Location = new Point(41, 78);
            LVerificationAuthor.Name = "LVerificationAuthor";
            LVerificationAuthor.Size = new Size(80, 15);
            LVerificationAuthor.TabIndex = 47;
            LVerificationAuthor.Text = "Verificado por";
            // 
            // LVerificationDate
            // 
            LVerificationDate.AutoSize = true;
            LVerificationDate.Location = new Point(19, 50);
            LVerificationDate.Name = "LVerificationDate";
            LVerificationDate.Size = new Size(102, 15);
            LVerificationDate.TabIndex = 46;
            LVerificationDate.Text = "Fecha verificación";
            // 
            // VerificationDate
            // 
            VerificationDate.Enabled = false;
            VerificationDate.Format = DateTimePickerFormat.Short;
            VerificationDate.Location = new Point(127, 44);
            VerificationDate.Name = "VerificationDate";
            VerificationDate.Size = new Size(378, 23);
            VerificationDate.TabIndex = 45;
            // 
            // Verified
            // 
            Verified.AutoSize = true;
            Verified.Location = new Point(127, 19);
            Verified.Name = "Verified";
            Verified.Size = new Size(78, 19);
            Verified.TabIndex = 44;
            Verified.Text = "Verificado";
            Verified.UseVisualStyleBackColor = true;
            Verified.CheckedChanged += Verified_CheckedChanged;
            // 
            // FCitizenData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(522, 386);
            ControlBox = false;
            Controls.Add(TabControlCitizen);
            Controls.Add(BCancel);
            Controls.Add(BAccept);
            KeyPreview = true;
            Name = "FCitizenData";
            ShowIcon = false;
            ShowInTaskbar = false;
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Ciudadano - Nuevo ";
            Load += FCitizenData_Load;
            KeyDown += FCitizenData_KeyDown;
            TabControlCitizen.ResumeLayout(false);
            TabGeneral.ResumeLayout(false);
            TabGeneral.PerformLayout();
            TabRelationships.ResumeLayout(false);
            TabRelationships.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NumPriorityScore).EndInit();
            ((System.ComponentModel.ISupportInitialize)NAffinity).EndInit();
            TabElectoral.ResumeLayout(false);
            TabElectoral.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            TabContacto.ResumeLayout(false);
            TabContacto.PerformLayout();
            TabAddress.ResumeLayout(false);
            TabAddress.PerformLayout();
            TabRol.ResumeLayout(false);
            TabRol.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DataGridRoles).EndInit();
            ToolStripRoles.ResumeLayout(false);
            ToolStripRoles.PerformLayout();
            TabOtros.ResumeLayout(false);
            TabOtros.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BAccept;
		private Button BCancel;
		private TabControl TabControlCitizen;
		private TabPage TabGeneral;
		private TabPage TabContacto;
		private TabPage TabRol;
		private ComboBox ComboBoxPoliticalParty;
		private Label LPoliticalParty;
		private Label LTitleFull;
		private Label LCURP;
		private TextBox TextBoxObservations;
		private Label label1;
		private ComboBox ComboBoxSex;
		private Label label2;
		private ComboBox ComboBoxTitle;
		private Label LTitle;
		private Label LName;
		private TextBox TextBoxName;
		private TabPage TabAddress;
		private TextBox TextBoxCity;
		private Label LCity;
		private TextBox TextBoxState;
		private Label LState;
		private TextBox TextBoxPostalCode;
		private Label LPostalCode;
		private TextBox TextBoxInteriorNumber;
		private Label LInteriorNumber;
		private TextBox TextBoxNumber;
		private Label LNumber;
		private TextBox TextBoxStreet;
		private Label LStreet;
		private TextBox TextBoxPhone;
		private Label LPhone;
		private TextBox TextBoxPhoneExtension;
		private Label LPhoneExtension;
		private TextBox TextBoxCellphone;
		private Label LCellphone;
		private ComboBox ComboBoxAssistant;
		private Label LAssistent;
		private Label LAssitantName;
		private Label LAssistantPhone;
		private Label LAssitantCellphone;
		private Label LCountry;
		private ComboBox ComboBoxCountry;
		private Label LCountryFullName;
		private Label LPaternalName;
		private TextBox TextBoxPaternalName;
		private Label LMaternalName;
		private TextBox TextBoxMaternalName;
		private TextBox TextBoxEmail;
		private Label LEmail;
		private MaskedTextBox MaskedTextBoxCURP;
		private TabPage TabElectoral;
		private TextBox VoterCode;
		private Label LElectorCode;
		private TextBox VoterOCR;
		private Label LVoterOCR;
		private TextBox VoterSection;
		private Label LVoterSection;
		private TextBox VoterCIC;
		private Label LVoterCIC;
		private PictureBox pictureBox1;
		private TextBox TextBoxDistrict;
		private Label LDistrict;
		private ComboBox ComboBoxCategory;
		private Label LCategory;
		private CheckBox IsPoliticalActivist;
		private DateTimePicker PoliticalRegisterDate;
		private Button BGenerateCURP;
		private TextBox Phone3Extension;
		private Label LPhone3Extension;
		private TextBox Phone3;
		private Label LPhone3;
		private TextBox Phone2Extension;
		private Label LPhone2Extension;
		private TextBox Phone2;
		private Label LPhone2;
		private ComboBox BDayDay;
		private ComboBox BDayMonth;
		private CheckBox KnownBirthday;
		private ComboBox BDayYear;
		private CheckBox KnownPoliticalRegisterDate;
		private TabPage TabRelationships;
		private Label LRelationship;
		private ComboBox Relationship;
		private NumericUpDown NAffinity;
		private Label LAffinity;
		private DateTimePicker StartDate;
		private CheckBox KnownStartDate;
		private TextBox RelationshipNotes;
		private Label LRelationshipNotes;
		private CheckBox RelationshipEnabled;
		private DateTimePicker EndDate;
		private CheckBox KnownEndDate;
		private TextBox PhoneSyncExtension;
		private Label label3;
		private TextBox PhoneSync;
		private Label LPhoneSync;
		private CheckBox TelSyncEnabled;
		private NumericUpDown NumPriorityScore;
		private Label label4;
        private TabPage TabOtros;
        private Label LVerificationDate;
        private DateTimePicker VerificationDate;
        private CheckBox Verified;
        private Label LVerificationAuthor;
        private TextBox VerificationAuthor;
        private DataGridView DataGridRoles;
        private ToolStrip ToolStripRoles;
        private ToolStripButton BAddRole;
        private ToolStripButton BEditRole;
        private ToolStripButton BDeleteRole;
        private ToolStripButton BPositionUpRole;
        private ToolStripButton BPositionDownRole;
    }
}