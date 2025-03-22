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
			tabPage1 = new TabPage();
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
			tabPage2 = new TabPage();
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
			LInstitutionSectorAndCategory = new Label();
			LInstitutionRoleDescription = new Label();
			ComboBoxInstitutionRole = new ComboBox();
			LInstitutionRole = new Label();
			ComboBoxInstitution = new ComboBox();
			LInstitution = new Label();
			TabElectoral = new TabPage();
			pictureBox1 = new PictureBox();
			VoterSection = new TextBox();
			LVoterSection = new Label();
			VoterCIC = new TextBox();
			LVoterCIC = new Label();
			VoterOCR = new TextBox();
			LVoterOCR = new Label();
			VoterCode = new TextBox();
			LElectorCode = new Label();
			ComboBoxCategory = new ComboBox();
			LCategory = new Label();
			TabControlCitizen.SuspendLayout();
			tabPage1.SuspendLayout();
			tabPage2.SuspendLayout();
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
			TabControlCitizen.Controls.Add(tabPage1);
			TabControlCitizen.Controls.Add(tabPage2);
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
			// tabPage1
			// 
			tabPage1.Controls.Add(LCategory);
			tabPage1.Controls.Add(ComboBoxCategory);
			tabPage1.Controls.Add(MaskedTextBoxCURP);
			tabPage1.Controls.Add(LMaternalName);
			tabPage1.Controls.Add(TextBoxMaternalName);
			tabPage1.Controls.Add(LPaternalName);
			tabPage1.Controls.Add(TextBoxPaternalName);
			tabPage1.Controls.Add(ComboBoxPoliticalParty);
			tabPage1.Controls.Add(LPoliticalParty);
			tabPage1.Controls.Add(LTitleFull);
			tabPage1.Controls.Add(LCURP);
			tabPage1.Controls.Add(TextBoxObservations);
			tabPage1.Controls.Add(label1);
			tabPage1.Controls.Add(ComboBoxSex);
			tabPage1.Controls.Add(label2);
			tabPage1.Controls.Add(LBirthday);
			tabPage1.Controls.Add(ComboBoxTitle);
			tabPage1.Controls.Add(LTitle);
			tabPage1.Controls.Add(DatePickerBirthday);
			tabPage1.Controls.Add(LName);
			tabPage1.Controls.Add(TextBoxName);
			tabPage1.Location = new Point(4, 24);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(396, 313);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "General";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// MaskedTextBoxCURP
			// 
			MaskedTextBoxCURP.Location = new Point(79, 180);
			MaskedTextBoxCURP.Mask = "AAAAAAAAAAAAAAAAAA";
			MaskedTextBoxCURP.Name = "MaskedTextBoxCURP";
			MaskedTextBoxCURP.PromptChar = ' ';
			MaskedTextBoxCURP.Size = new Size(308, 23);
			MaskedTextBoxCURP.TabIndex = 6;
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
			TextBoxMaternalName.TabIndex = 3;
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
			TextBoxPaternalName.TabIndex = 2;
			// 
			// ComboBoxPoliticalParty
			// 
			ComboBoxPoliticalParty.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxPoliticalParty.FormattingEnabled = true;
			ComboBoxPoliticalParty.Location = new Point(79, 282);
			ComboBoxPoliticalParty.Name = "ComboBoxPoliticalParty";
			ComboBoxPoliticalParty.Size = new Size(94, 23);
			ComboBoxPoliticalParty.TabIndex = 8;
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
			TextBoxObservations.Size = new Size(308, 67);
			TextBoxObservations.TabIndex = 7;
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
			ComboBoxSex.TabIndex = 4;
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
			DatePickerBirthday.TabIndex = 5;
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
			TextBoxName.TabIndex = 1;
			// 
			// tabPage2
			// 
			tabPage2.Controls.Add(TextBoxEmail);
			tabPage2.Controls.Add(LEmail);
			tabPage2.Controls.Add(LAssitantCellphone);
			tabPage2.Controls.Add(LAssistantPhone);
			tabPage2.Controls.Add(LAssitantName);
			tabPage2.Controls.Add(LAssistent);
			tabPage2.Controls.Add(ComboBoxAssistant);
			tabPage2.Controls.Add(TextBoxCellphone);
			tabPage2.Controls.Add(LCellphone);
			tabPage2.Controls.Add(TextBoxPhoneExtension);
			tabPage2.Controls.Add(LPhoneExtension);
			tabPage2.Controls.Add(TextBoxPhone);
			tabPage2.Controls.Add(LPhone);
			tabPage2.Location = new Point(4, 24);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(396, 283);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "Contacto";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// TextBoxEmail
			// 
			TextBoxEmail.Location = new Point(65, 67);
			TextBoxEmail.Name = "TextBoxEmail";
			TextBoxEmail.Size = new Size(186, 23);
			TextBoxEmail.TabIndex = 3;
			// 
			// LEmail
			// 
			LEmail.AutoSize = true;
			LEmail.Location = new Point(7, 70);
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
			LAssitantCellphone.Location = new Point(65, 190);
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
			LAssistantPhone.Location = new Point(65, 170);
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
			LAssitantName.Location = new Point(65, 150);
			LAssitantName.Name = "LAssitantName";
			LAssitantName.Size = new Size(149, 15);
			LAssitantName.TabIndex = 36;
			LAssitantName.Text = "Nombre Asistente Apellido";
			// 
			// LAssistent
			// 
			LAssistent.AutoSize = true;
			LAssistent.Location = new Point(7, 122);
			LAssistent.Name = "LAssistent";
			LAssistent.Size = new Size(55, 15);
			LAssistent.TabIndex = 21;
			LAssistent.Text = "Asistente";
			// 
			// ComboBoxAssistant
			// 
			ComboBoxAssistant.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxAssistant.FormattingEnabled = true;
			ComboBoxAssistant.Location = new Point(65, 119);
			ComboBoxAssistant.Name = "ComboBoxAssistant";
			ComboBoxAssistant.Size = new Size(325, 23);
			ComboBoxAssistant.TabIndex = 4;
			ComboBoxAssistant.SelectedIndexChanged += ComboBoxAssistant_SelectedIndexChanged;
			// 
			// TextBoxCellphone
			// 
			TextBoxCellphone.Location = new Point(65, 38);
			TextBoxCellphone.Name = "TextBoxCellphone";
			TextBoxCellphone.Size = new Size(186, 23);
			TextBoxCellphone.TabIndex = 2;
			// 
			// LCellphone
			// 
			LCellphone.AutoSize = true;
			LCellphone.Location = new Point(7, 41);
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
			TextBoxPhone.Location = new Point(65, 9);
			TextBoxPhone.Name = "TextBoxPhone";
			TextBoxPhone.Size = new Size(186, 23);
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
			TabAddress.Size = new Size(396, 283);
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
			TabRol.Controls.Add(LInstitutionSectorAndCategory);
			TabRol.Controls.Add(LInstitutionRoleDescription);
			TabRol.Controls.Add(ComboBoxInstitutionRole);
			TabRol.Controls.Add(LInstitutionRole);
			TabRol.Controls.Add(ComboBoxInstitution);
			TabRol.Controls.Add(LInstitution);
			TabRol.Location = new Point(4, 24);
			TabRol.Name = "TabRol";
			TabRol.Padding = new Padding(3);
			TabRol.Size = new Size(396, 283);
			TabRol.TabIndex = 2;
			TabRol.Text = "Cargo";
			TabRol.UseVisualStyleBackColor = true;
			// 
			// LInstitutionSectorAndCategory
			// 
			LInstitutionSectorAndCategory.AutoSize = true;
			LInstitutionSectorAndCategory.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LInstitutionSectorAndCategory.ForeColor = SystemColors.HotTrack;
			LInstitutionSectorAndCategory.Location = new Point(74, 38);
			LInstitutionSectorAndCategory.Name = "LInstitutionSectorAndCategory";
			LInstitutionSectorAndCategory.Size = new Size(157, 15);
			LInstitutionSectorAndCategory.TabIndex = 39;
			LInstitutionSectorAndCategory.Text = "Gobierno - Gobierno Federal";
			// 
			// LInstitutionRoleDescription
			// 
			LInstitutionRoleDescription.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
			LInstitutionRoleDescription.ForeColor = SystemColors.HotTrack;
			LInstitutionRoleDescription.Location = new Point(74, 89);
			LInstitutionRoleDescription.Name = "LInstitutionRoleDescription";
			LInstitutionRoleDescription.Size = new Size(313, 129);
			LInstitutionRoleDescription.TabIndex = 38;
			LInstitutionRoleDescription.Text = "Descripción del cargo seleccionado esta persona se encarga de realizar las tareas que le dige su jefe y demás";
			// 
			// ComboBoxInstitutionRole
			// 
			ComboBoxInstitutionRole.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxInstitutionRole.FormattingEnabled = true;
			ComboBoxInstitutionRole.Location = new Point(74, 59);
			ComboBoxInstitutionRole.Name = "ComboBoxInstitutionRole";
			ComboBoxInstitutionRole.Size = new Size(316, 23);
			ComboBoxInstitutionRole.TabIndex = 3;
			ComboBoxInstitutionRole.SelectedValueChanged += ComboBoxInstitutionRole_SelectedValueChanged;
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
			ComboBoxInstitution.Location = new Point(74, 9);
			ComboBoxInstitution.Name = "ComboBoxInstitution";
			ComboBoxInstitution.Size = new Size(316, 23);
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
			TabElectoral.Size = new Size(396, 283);
			TabElectoral.TabIndex = 4;
			TabElectoral.Text = "Electoral";
			TabElectoral.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			pictureBox1.Image = Properties.Resources.credencial_modeloEG;
			pictureBox1.Location = new Point(10, 6);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new Size(377, 145);
			pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 8;
			pictureBox1.TabStop = false;
			// 
			// VoterSection
			// 
			VoterSection.Location = new Point(132, 244);
			VoterSection.Name = "VoterSection";
			VoterSection.Size = new Size(258, 23);
			VoterSection.TabIndex = 3;
			// 
			// LVoterSection
			// 
			LVoterSection.AutoSize = true;
			LVoterSection.Location = new Point(10, 247);
			LVoterSection.Name = "LVoterSection";
			LVoterSection.Size = new Size(48, 15);
			LVoterSection.TabIndex = 6;
			LVoterSection.Text = "Sección";
			// 
			// VoterCIC
			// 
			VoterCIC.Location = new Point(132, 215);
			VoterCIC.Name = "VoterCIC";
			VoterCIC.Size = new Size(258, 23);
			VoterCIC.TabIndex = 2;
			// 
			// LVoterCIC
			// 
			LVoterCIC.AutoSize = true;
			LVoterCIC.Location = new Point(10, 218);
			LVoterCIC.Name = "LVoterCIC";
			LVoterCIC.Size = new Size(109, 15);
			LVoterCIC.TabIndex = 4;
			LVoterCIC.Text = "Id. Credencial (CIC)";
			// 
			// VoterOCR
			// 
			VoterOCR.Location = new Point(132, 186);
			VoterOCR.Name = "VoterOCR";
			VoterOCR.Size = new Size(258, 23);
			VoterOCR.TabIndex = 1;
			// 
			// LVoterOCR
			// 
			LVoterOCR.AutoSize = true;
			LVoterOCR.Location = new Point(10, 189);
			LVoterOCR.Name = "LVoterOCR";
			LVoterOCR.Size = new Size(116, 15);
			LVoterOCR.TabIndex = 2;
			LVoterOCR.Text = "Id. Ciudadano (OCR)";
			// 
			// VoterCode
			// 
			VoterCode.Location = new Point(132, 157);
			VoterCode.Name = "VoterCode";
			VoterCode.Size = new Size(258, 23);
			VoterCode.TabIndex = 0;
			// 
			// LElectorCode
			// 
			LElectorCode.AutoSize = true;
			LElectorCode.Location = new Point(10, 160);
			LElectorCode.Name = "LElectorCode";
			LElectorCode.Size = new Size(91, 15);
			LElectorCode.TabIndex = 0;
			LElectorCode.Text = "Clave de elector";
			// 
			// ComboBoxCategory
			// 
			ComboBoxCategory.DropDownStyle = ComboBoxStyle.DropDownList;
			ComboBoxCategory.FormattingEnabled = true;
			ComboBoxCategory.Location = new Point(79, 35);
			ComboBoxCategory.Name = "ComboBoxCategory";
			ComboBoxCategory.Size = new Size(308, 23);
			ComboBoxCategory.TabIndex = 40;
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
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
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
		private TabPage tabPage1;
		private TabPage tabPage2;
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
		private Label LInstitutionRoleDescription;
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
	}
}