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
			BAccept = new Button();
			BCancel = new Button();
			TabControlCitizen = new TabControl();
			TabGeneral = new TabPage();
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
			LBirthday = new Label();
			ComboBoxTitle = new ComboBox();
			LTitle = new Label();
			DatePickerBirthday = new DateTimePicker();
			LName = new Label();
			TextBoxName = new TextBox();
			TabContacto = new TabPage();
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
			panel2 = new Panel();
			panel1 = new Panel();
			LInstitution3SectorAndCategory = new Label();
			Institution3Role = new ComboBox();
			LInstitution3Role = new Label();
			Institution3 = new ComboBox();
			LInstitution3 = new Label();
			LInstitution2SectorAndCategory = new Label();
			Institution2Role = new ComboBox();
			LInsitution2Role = new Label();
			Insitution2 = new ComboBox();
			LInstitution2 = new Label();
			LInstitutionSectorAndCategory = new Label();
			ComboBoxInstitutionRole = new ComboBox();
			LInstitutionRole = new Label();
			ComboBoxInstitution = new ComboBox();
			LInstitution = new Label();
			TabElectoral = new TabPage();
			PoliticalRegisterDate = new DateTimePicker();
			LPoliticalRegisterDate = new Label();
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
			TabControlCitizen.SuspendLayout();
			TabGeneral.SuspendLayout();
			TabContacto.SuspendLayout();
			TabAddress.SuspendLayout();
			TabRol.SuspendLayout();
			TabElectoral.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			SuspendLayout();
			// 
			// BAccept
			// 
			BAccept.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			BAccept.Location = new Point(242, 348);
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
			BCancel.Location = new Point(320, 348);
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
			TabControlCitizen.Controls.Add(TabContacto);
			TabControlCitizen.Controls.Add(TabAddress);
			TabControlCitizen.Controls.Add(TabRol);
			TabControlCitizen.Controls.Add(TabElectoral);
			TabControlCitizen.Location = new Point(1, 1);
			TabControlCitizen.MaximumSize = new Size(424, 350);
			TabControlCitizen.MinimumSize = new Size(404, 311);
			TabControlCitizen.Name = "TabControlCitizen";
			TabControlCitizen.SelectedIndex = 0;
			TabControlCitizen.Size = new Size(404, 341);
			TabControlCitizen.SizeMode = TabSizeMode.Fixed;
			TabControlCitizen.TabIndex = 0;
			// 
			// TabGeneral
			// 
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
			TabGeneral.Controls.Add(LBirthday);
			TabGeneral.Controls.Add(ComboBoxTitle);
			TabGeneral.Controls.Add(LTitle);
			TabGeneral.Controls.Add(DatePickerBirthday);
			TabGeneral.Controls.Add(LName);
			TabGeneral.Controls.Add(TextBoxName);
			TabGeneral.Location = new Point(4, 24);
			TabGeneral.Name = "TabGeneral";
			TabGeneral.Padding = new Padding(3);
			TabGeneral.Size = new Size(396, 313);
			TabGeneral.TabIndex = 0;
			TabGeneral.Text = "General";
			TabGeneral.UseVisualStyleBackColor = true;
			// 
			// BGenerateCURP
			// 
			BGenerateCURP.Image = Properties.Resources.Fatcow_Farm_Fresh_Widgets_16;
			BGenerateCURP.Location = new Point(359, 180);
			BGenerateCURP.Name = "BGenerateCURP";
			BGenerateCURP.Size = new Size(31, 23);
			BGenerateCURP.TabIndex = 42;
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
			ComboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxCategory.FormattingEnabled = true;
			ComboBoxCategory.Location = new Point(79, 35);
			ComboBoxCategory.Name = "ComboBoxCategory";
			ComboBoxCategory.Size = new Size(311, 23);
			ComboBoxCategory.TabIndex = 1;
			// 
			// MaskedTextBoxCURP
			// 
			MaskedTextBoxCURP.Location = new Point(79, 180);
			MaskedTextBoxCURP.Mask = "AAAAAAAAAAAAAAAAAA";
			MaskedTextBoxCURP.Name = "MaskedTextBoxCURP";
			MaskedTextBoxCURP.PromptChar = ' ';
			MaskedTextBoxCURP.Size = new Size(274, 23);
			MaskedTextBoxCURP.TabIndex = 7;
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
			TextBoxMaternalName.Location = new Point(79, 122);
			TextBoxMaternalName.Name = "TextBoxMaternalName";
			TextBoxMaternalName.Size = new Size(311, 23);
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
			TextBoxPaternalName.Location = new Point(79, 93);
			TextBoxPaternalName.Name = "TextBoxPaternalName";
			TextBoxPaternalName.Size = new Size(311, 23);
			TextBoxPaternalName.TabIndex = 3;
			// 
			// ComboBoxPoliticalParty
			// 
			ComboBoxPoliticalParty.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxPoliticalParty.FormattingEnabled = true;
			ComboBoxPoliticalParty.Location = new Point(79, 282);
			ComboBoxPoliticalParty.Name = "ComboBoxPoliticalParty";
			ComboBoxPoliticalParty.Size = new Size(94, 23);
			ComboBoxPoliticalParty.TabIndex = 9;
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
			LTitleFull.Location = new Point(179, 9);
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
			TextBoxObservations.Location = new Point(79, 209);
			TextBoxObservations.Multiline = true;
			TextBoxObservations.Name = "TextBoxObservations";
			TextBoxObservations.Size = new Size(311, 67);
			TextBoxObservations.TabIndex = 8;
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
			ComboBoxSex.Size = new Size(78, 23);
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
			// LBirthday
			// 
			LBirthday.AutoSize = true;
			LBirthday.Location = new Point(173, 154);
			LBirthday.Name = "LBirthday";
			LBirthday.Size = new Size(69, 15);
			LBirthday.TabIndex = 26;
			LBirthday.Text = "Nacimiento";
			// 
			// ComboBoxTitle
			// 
			ComboBoxTitle.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxTitle.FormattingEnabled = true;
			ComboBoxTitle.Location = new Point(79, 6);
			ComboBoxTitle.Name = "ComboBoxTitle";
			ComboBoxTitle.Size = new Size(94, 23);
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
			// DatePickerBirthday
			// 
			DatePickerBirthday.CustomFormat = "dd/MM/yyyy";
			DatePickerBirthday.Format = DateTimePickerFormat.Custom;
			DatePickerBirthday.Location = new Point(248, 151);
			DatePickerBirthday.Name = "DatePickerBirthday";
			DatePickerBirthday.Size = new Size(142, 23);
			DatePickerBirthday.TabIndex = 6;
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
			TextBoxName.Location = new Point(79, 64);
			TextBoxName.Name = "TextBoxName";
			TextBoxName.Size = new Size(311, 23);
			TextBoxName.TabIndex = 2;
			// 
			// TabContacto
			// 
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
			TabContacto.Size = new Size(396, 313);
			TabContacto.TabIndex = 1;
			TabContacto.Text = "Contacto";
			TabContacto.UseVisualStyleBackColor = true;
			// 
			// Phone3Extension
			// 
			Phone3Extension.Location = new Point(289, 67);
			Phone3Extension.Name = "Phone3Extension";
			Phone3Extension.Size = new Size(101, 23);
			Phone3Extension.TabIndex = 46;
			// 
			// LPhone3Extension
			// 
			LPhone3Extension.AutoSize = true;
			LPhone3Extension.Location = new Point(257, 70);
			LPhone3Extension.Name = "LPhone3Extension";
			LPhone3Extension.Size = new Size(25, 15);
			LPhone3Extension.TabIndex = 48;
			LPhone3Extension.Text = "Ext.";
			// 
			// Phone3
			// 
			Phone3.Location = new Point(75, 67);
			Phone3.Name = "Phone3";
			Phone3.Size = new Size(176, 23);
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
			Phone2Extension.Location = new Point(289, 38);
			Phone2Extension.Name = "Phone2Extension";
			Phone2Extension.Size = new Size(101, 23);
			Phone2Extension.TabIndex = 42;
			// 
			// LPhone2Extension
			// 
			LPhone2Extension.AutoSize = true;
			LPhone2Extension.Location = new Point(257, 41);
			LPhone2Extension.Name = "LPhone2Extension";
			LPhone2Extension.Size = new Size(25, 15);
			LPhone2Extension.TabIndex = 44;
			LPhone2Extension.Text = "Ext.";
			// 
			// Phone2
			// 
			Phone2.Location = new Point(75, 38);
			Phone2.Name = "Phone2";
			Phone2.Size = new Size(176, 23);
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
			TextBoxEmail.Location = new Point(75, 125);
			TextBoxEmail.Name = "TextBoxEmail";
			TextBoxEmail.Size = new Size(315, 23);
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
			LAssitantCellphone.Location = new Point(75, 225);
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
			LAssistantPhone.Location = new Point(75, 205);
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
			LAssitantName.Location = new Point(75, 185);
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
			ComboBoxAssistant.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxAssistant.FormattingEnabled = true;
			ComboBoxAssistant.Location = new Point(75, 154);
			ComboBoxAssistant.Name = "ComboBoxAssistant";
			ComboBoxAssistant.Size = new Size(315, 23);
			ComboBoxAssistant.TabIndex = 4;
			ComboBoxAssistant.SelectedIndexChanged += ComboBoxAssistant_SelectedIndexChanged;
			// 
			// TextBoxCellphone
			// 
			TextBoxCellphone.Location = new Point(75, 96);
			TextBoxCellphone.Name = "TextBoxCellphone";
			TextBoxCellphone.Size = new Size(176, 23);
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
			TextBoxPhoneExtension.Location = new Point(289, 9);
			TextBoxPhoneExtension.Name = "TextBoxPhoneExtension";
			TextBoxPhoneExtension.Size = new Size(101, 23);
			TextBoxPhoneExtension.TabIndex = 1;
			// 
			// LPhoneExtension
			// 
			LPhoneExtension.AutoSize = true;
			LPhoneExtension.Location = new Point(257, 12);
			LPhoneExtension.Name = "LPhoneExtension";
			LPhoneExtension.Size = new Size(25, 15);
			LPhoneExtension.TabIndex = 16;
			LPhoneExtension.Text = "Ext.";
			// 
			// TextBoxPhone
			// 
			TextBoxPhone.Location = new Point(75, 9);
			TextBoxPhone.Name = "TextBoxPhone";
			TextBoxPhone.Size = new Size(176, 23);
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
			TabAddress.Size = new Size(396, 313);
			TabAddress.TabIndex = 3;
			TabAddress.Text = "Dirección";
			TabAddress.UseVisualStyleBackColor = true;
			// 
			// TextBoxDistrict
			// 
			TextBoxDistrict.Location = new Point(54, 67);
			TextBoxDistrict.Name = "TextBoxDistrict";
			TextBoxDistrict.Size = new Size(336, 23);
			TextBoxDistrict.TabIndex = 38;
			// 
			// LDistrict
			// 
			LDistrict.AutoSize = true;
			LDistrict.Location = new Point(7, 70);
			LDistrict.Name = "LDistrict";
			LDistrict.Size = new Size(45, 15);
			LDistrict.TabIndex = 39;
			LDistrict.Text = "Distrito";
			// 
			// LCountryFullName
			// 
			LCountryFullName.AutoSize = true;
			LCountryFullName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LCountryFullName.ForeColor = SystemColors.HotTrack;
			LCountryFullName.Location = new Point(165, 186);
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
			ComboBoxCountry.Location = new Point(54, 183);
			ComboBoxCountry.Name = "ComboBoxCountry";
			ComboBoxCountry.Size = new Size(105, 23);
			ComboBoxCountry.TabIndex = 6;
			ComboBoxCountry.SelectedIndexChanged += ComboBoxCountry_SelectedIndexChanged;
			// 
			// TextBoxCity
			// 
			TextBoxCity.Location = new Point(54, 96);
			TextBoxCity.Name = "TextBoxCity";
			TextBoxCity.Size = new Size(105, 23);
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
			TextBoxState.Location = new Point(54, 125);
			TextBoxState.Name = "TextBoxState";
			TextBoxState.Size = new Size(105, 23);
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
			TextBoxPostalCode.Location = new Point(54, 154);
			TextBoxPostalCode.Name = "TextBoxPostalCode";
			TextBoxPostalCode.Size = new Size(105, 23);
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
			TextBoxInteriorNumber.Location = new Point(238, 38);
			TextBoxInteriorNumber.Name = "TextBoxInteriorNumber";
			TextBoxInteriorNumber.Size = new Size(101, 23);
			TextBoxInteriorNumber.TabIndex = 2;
			// 
			// LInteriorNumber
			// 
			LInteriorNumber.AutoSize = true;
			LInteriorNumber.Location = new Point(165, 41);
			LInteriorNumber.Name = "LInteriorNumber";
			LInteriorNumber.Size = new Size(67, 15);
			LInteriorNumber.TabIndex = 16;
			LInteriorNumber.Text = "No. Interior";
			// 
			// TextBoxNumber
			// 
			TextBoxNumber.Location = new Point(54, 38);
			TextBoxNumber.Name = "TextBoxNumber";
			TextBoxNumber.Size = new Size(105, 23);
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
			TextBoxStreet.Location = new Point(54, 9);
			TextBoxStreet.Name = "TextBoxStreet";
			TextBoxStreet.Size = new Size(336, 23);
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
			TabRol.Controls.Add(panel2);
			TabRol.Controls.Add(panel1);
			TabRol.Controls.Add(LInstitution3SectorAndCategory);
			TabRol.Controls.Add(Institution3Role);
			TabRol.Controls.Add(LInstitution3Role);
			TabRol.Controls.Add(Institution3);
			TabRol.Controls.Add(LInstitution3);
			TabRol.Controls.Add(LInstitution2SectorAndCategory);
			TabRol.Controls.Add(Institution2Role);
			TabRol.Controls.Add(LInsitution2Role);
			TabRol.Controls.Add(Insitution2);
			TabRol.Controls.Add(LInstitution2);
			TabRol.Controls.Add(LInstitutionSectorAndCategory);
			TabRol.Controls.Add(ComboBoxInstitutionRole);
			TabRol.Controls.Add(LInstitutionRole);
			TabRol.Controls.Add(ComboBoxInstitution);
			TabRol.Controls.Add(LInstitution);
			TabRol.Location = new Point(4, 24);
			TabRol.Name = "TabRol";
			TabRol.Padding = new Padding(3);
			TabRol.Size = new Size(396, 313);
			TabRol.TabIndex = 2;
			TabRol.Text = "Cargos";
			TabRol.UseVisualStyleBackColor = true;
			// 
			// panel2
			// 
			panel2.BackColor = SystemColors.AppWorkspace;
			panel2.Location = new Point(7, 198);
			panel2.Name = "panel2";
			panel2.Size = new Size(380, 1);
			panel2.TabIndex = 52;
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.AppWorkspace;
			panel1.Location = new Point(7, 96);
			panel1.Name = "panel1";
			panel1.Size = new Size(380, 1);
			panel1.TabIndex = 51;
			// 
			// LInstitution3SectorAndCategory
			// 
			LInstitution3SectorAndCategory.AutoSize = true;
			LInstitution3SectorAndCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LInstitution3SectorAndCategory.ForeColor = SystemColors.HotTrack;
			LInstitution3SectorAndCategory.Location = new Point(83, 240);
			LInstitution3SectorAndCategory.Name = "LInstitution3SectorAndCategory";
			LInstitution3SectorAndCategory.Size = new Size(143, 15);
			LInstitution3SectorAndCategory.TabIndex = 50;
			LInstitution3SectorAndCategory.Text = "Educativo - Universidades";
			// 
			// Institution3Role
			// 
			Institution3Role.DropDownStyle = ComboBoxStyle.DropDownList;
			Institution3Role.FormattingEnabled = true;
			Institution3Role.Location = new Point(83, 261);
			Institution3Role.Name = "Institution3Role";
			Institution3Role.Size = new Size(307, 23);
			Institution3Role.TabIndex = 49;
			// 
			// LInstitution3Role
			// 
			LInstitution3Role.AutoSize = true;
			LInstitution3Role.Location = new Point(7, 264);
			LInstitution3Role.Name = "LInstitution3Role";
			LInstitution3Role.Size = new Size(48, 15);
			LInstitution3Role.TabIndex = 48;
			LInstitution3Role.Text = "Cargo 3";
			// 
			// Institution3
			// 
			Institution3.AutoCompleteMode = AutoCompleteMode.Append;
			Institution3.AutoCompleteSource = AutoCompleteSource.ListItems;
			Institution3.DropDownStyle = ComboBoxStyle.DropDownList;
			Institution3.FormattingEnabled = true;
			Institution3.Location = new Point(83, 211);
			Institution3.Name = "Institution3";
			Institution3.Size = new Size(307, 23);
			Institution3.TabIndex = 47;
			Institution3.SelectedValueChanged += Institution3_SelectedValueChanged;
			// 
			// LInstitution3
			// 
			LInstitution3.AutoSize = true;
			LInstitution3.Location = new Point(5, 214);
			LInstitution3.Name = "LInstitution3";
			LInstitution3.Size = new Size(72, 15);
			LInstitution3.TabIndex = 46;
			LInstitution3.Text = "Institución 3";
			// 
			// LInstitution2SectorAndCategory
			// 
			LInstitution2SectorAndCategory.AutoSize = true;
			LInstitution2SectorAndCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LInstitution2SectorAndCategory.ForeColor = SystemColors.HotTrack;
			LInstitution2SectorAndCategory.Location = new Point(83, 139);
			LInstitution2SectorAndCategory.Name = "LInstitution2SectorAndCategory";
			LInstitution2SectorAndCategory.Size = new Size(78, 15);
			LInstitution2SectorAndCategory.TabIndex = 45;
			LInstitution2SectorAndCategory.Text = "Social - OSCs";
			// 
			// Institution2Role
			// 
			Institution2Role.DropDownStyle = ComboBoxStyle.DropDownList;
			Institution2Role.FormattingEnabled = true;
			Institution2Role.Location = new Point(83, 160);
			Institution2Role.Name = "Institution2Role";
			Institution2Role.Size = new Size(307, 23);
			Institution2Role.TabIndex = 43;
			// 
			// LInsitution2Role
			// 
			LInsitution2Role.AutoSize = true;
			LInsitution2Role.Location = new Point(7, 163);
			LInsitution2Role.Name = "LInsitution2Role";
			LInsitution2Role.Size = new Size(48, 15);
			LInsitution2Role.TabIndex = 42;
			LInsitution2Role.Text = "Cargo 2";
			// 
			// Insitution2
			// 
			Insitution2.AutoCompleteMode = AutoCompleteMode.Append;
			Insitution2.AutoCompleteSource = AutoCompleteSource.ListItems;
			Insitution2.DropDownStyle = ComboBoxStyle.DropDownList;
			Insitution2.FormattingEnabled = true;
			Insitution2.Location = new Point(83, 110);
			Insitution2.Name = "Insitution2";
			Insitution2.Size = new Size(307, 23);
			Insitution2.TabIndex = 41;
			Insitution2.SelectedValueChanged += Insitution2_SelectedValueChanged;
			// 
			// LInstitution2
			// 
			LInstitution2.AutoSize = true;
			LInstitution2.Location = new Point(5, 113);
			LInstitution2.Name = "LInstitution2";
			LInstitution2.Size = new Size(72, 15);
			LInstitution2.TabIndex = 40;
			LInstitution2.Text = "Institución 2";
			// 
			// LInstitutionSectorAndCategory
			// 
			LInstitutionSectorAndCategory.AutoSize = true;
			LInstitutionSectorAndCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LInstitutionSectorAndCategory.ForeColor = SystemColors.HotTrack;
			LInstitutionSectorAndCategory.Location = new Point(83, 38);
			LInstitutionSectorAndCategory.Name = "LInstitutionSectorAndCategory";
			LInstitutionSectorAndCategory.Size = new Size(157, 15);
			LInstitutionSectorAndCategory.TabIndex = 39;
			LInstitutionSectorAndCategory.Text = "Gobierno - Gobierno Federal";
			// 
			// ComboBoxInstitutionRole
			// 
			ComboBoxInstitutionRole.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxInstitutionRole.FormattingEnabled = true;
			ComboBoxInstitutionRole.Location = new Point(83, 59);
			ComboBoxInstitutionRole.Name = "ComboBoxInstitutionRole";
			ComboBoxInstitutionRole.Size = new Size(307, 23);
			ComboBoxInstitutionRole.TabIndex = 3;
			// 
			// LInstitutionRole
			// 
			LInstitutionRole.AutoSize = true;
			LInstitutionRole.Location = new Point(7, 62);
			LInstitutionRole.Name = "LInstitutionRole";
			LInstitutionRole.Size = new Size(39, 15);
			LInstitutionRole.TabIndex = 2;
			LInstitutionRole.Text = "Cargo";
			// 
			// ComboBoxInstitution
			// 
			ComboBoxInstitution.AutoCompleteMode = AutoCompleteMode.Append;
			ComboBoxInstitution.AutoCompleteSource = AutoCompleteSource.ListItems;
			ComboBoxInstitution.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxInstitution.FormattingEnabled = true;
			ComboBoxInstitution.Location = new Point(83, 9);
			ComboBoxInstitution.Name = "ComboBoxInstitution";
			ComboBoxInstitution.Size = new Size(307, 23);
			ComboBoxInstitution.TabIndex = 1;
			ComboBoxInstitution.SelectedValueChanged += ComboBoxInstitution_SelectedValueChanged;
			// 
			// LInstitution
			// 
			LInstitution.AutoSize = true;
			LInstitution.Location = new Point(5, 12);
			LInstitution.Name = "LInstitution";
			LInstitution.Size = new Size(63, 15);
			LInstitution.TabIndex = 0;
			LInstitution.Text = "Institución";
			// 
			// TabElectoral
			// 
			TabElectoral.Controls.Add(PoliticalRegisterDate);
			TabElectoral.Controls.Add(LPoliticalRegisterDate);
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
			TabElectoral.Size = new Size(396, 313);
			TabElectoral.TabIndex = 4;
			TabElectoral.Text = "Electoral";
			TabElectoral.UseVisualStyleBackColor = true;
			// 
			// PoliticalRegisterDate
			// 
			PoliticalRegisterDate.CustomFormat = "dd/MM/yyyy";
			PoliticalRegisterDate.Enabled = false;
			PoliticalRegisterDate.Format = DateTimePickerFormat.Custom;
			PoliticalRegisterDate.Location = new Point(134, 281);
			PoliticalRegisterDate.Name = "PoliticalRegisterDate";
			PoliticalRegisterDate.Size = new Size(256, 23);
			PoliticalRegisterDate.TabIndex = 11;
			// 
			// LPoliticalRegisterDate
			// 
			LPoliticalRegisterDate.AutoSize = true;
			LPoliticalRegisterDate.Enabled = false;
			LPoliticalRegisterDate.Location = new Point(10, 285);
			LPoliticalRegisterDate.Name = "LPoliticalRegisterDate";
			LPoliticalRegisterDate.Size = new Size(118, 15);
			LPoliticalRegisterDate.TabIndex = 10;
			LPoliticalRegisterDate.Text = "Inscripción al padrón";
			// 
			// IsPoliticalActivist
			// 
			IsPoliticalActivist.AutoSize = true;
			IsPoliticalActivist.Location = new Point(134, 256);
			IsPoliticalActivist.Name = "IsPoliticalActivist";
			IsPoliticalActivist.Size = new Size(87, 19);
			IsPoliticalActivist.TabIndex = 9;
			IsPoliticalActivist.Text = "Es militante";
			IsPoliticalActivist.UseVisualStyleBackColor = true;
			IsPoliticalActivist.CheckedChanged += IsPoliticalActivist_CheckedChanged;
			// 
			// pictureBox1
			// 
			pictureBox1.Image = Properties.Resources.credencial_modeloEG;
			pictureBox1.Location = new Point(10, 6);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(377, 128);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 8;
			pictureBox1.TabStop = false;
			// 
			// VoterSection
			// 
			VoterSection.Location = new Point(134, 227);
			VoterSection.Name = "VoterSection";
			VoterSection.Size = new Size(256, 23);
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
			VoterCIC.Location = new Point(134, 198);
			VoterCIC.Name = "VoterCIC";
			VoterCIC.Size = new Size(256, 23);
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
			VoterOCR.Location = new Point(134, 169);
			VoterOCR.Name = "VoterOCR";
			VoterOCR.Size = new Size(256, 23);
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
			VoterCode.Location = new Point(134, 140);
			VoterCode.Name = "VoterCode";
			VoterCode.Size = new Size(256, 23);
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
			// FCitizenData
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSize = true;
			AutoSizeMode = AutoSizeMode.GrowAndShrink;
			ClientSize = new Size(404, 381);
			ControlBox = false;
			Controls.Add(TabControlCitizen);
			Controls.Add(BCancel);
			Controls.Add(BAccept);
			KeyPreview = true;
			MaximumSize = new Size(440, 430);
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
			TabContacto.ResumeLayout(false);
			TabContacto.PerformLayout();
			TabAddress.ResumeLayout(false);
			TabAddress.PerformLayout();
			TabRol.ResumeLayout(false);
			TabRol.PerformLayout();
			TabElectoral.ResumeLayout(false);
			TabElectoral.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
		private Label LBirthday;
		private ComboBox ComboBoxTitle;
		private Label LTitle;
		private DateTimePicker DatePickerBirthday;
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
		private ComboBox ComboBoxInstitution;
		private Label LInstitution;
		private ComboBox ComboBoxInstitutionRole;
		private Label LInstitutionRole;
		private TextBox TextBoxEmail;
		private Label LEmail;
		private Label LInstitutionSectorAndCategory;
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
		private Label LInstitution2SectorAndCategory;
		private ComboBox Institution2Role;
		private Label LInsitution2Role;
		private ComboBox Insitution2;
		private Label LInstitution2;
		private Label LInstitution3SectorAndCategory;
		private ComboBox Institution3Role;
		private Label LInstitution3Role;
		private ComboBox Institution3;
		private Label LInstitution3;
		private Panel panel2;
		private Panel panel1;
		private CheckBox IsPoliticalActivist;
		private Label LPoliticalRegisterDate;
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
	}
}