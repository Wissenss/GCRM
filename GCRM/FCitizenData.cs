using Business;
using DocumentFormat.OpenXml.Bibliography;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace GCRM
{
	public partial class FCitizenData : Form
	{
		DataSet DSCitizen;
		DataTable DTCitizens;
		DataTable DTInstitution;
		DataTable DTInstitution2;
		DataTable DTInstitution3;
		DataTable DTInstitutionRole;
		DataTable DTInstitution2Role;
		DataTable DTInstitution3Role;
		DataTable DTCategories;
		DataTable DTRelationshipRoles;

		FAccessMode AccessMode = FAccessMode.Create;
		int Id;
		int AddressId;
		int RelationshipId;

		public FCitizenData()
		{
			InitializeComponent();

			DSCitizen = new DataSet();

			DTCitizens = new DataTable("DTCitizens");
			DTCitizens.Columns.Add("id", typeof(int));
			DTCitizens.Columns.Add("name", typeof(string));
			DSCitizen.Tables.Add(DTCitizens);

			DTInstitution = new DataTable("DTInstitution");
			DTInstitution.Columns.Add("id", typeof(int));
			DTInstitution.Columns.Add("name", typeof(string));
			DSCitizen.Tables.Add(DTInstitution);

			DTInstitution2 = new DataTable("DTInstitution2");
			DTInstitution2.Columns.Add("id", typeof(int));
			DTInstitution2.Columns.Add("name", typeof(string));
			DSCitizen.Tables.Add(DTInstitution2);

			DTInstitution3 = new DataTable("DTInstitution3");
			DTInstitution3.Columns.Add("id", typeof(int));
			DTInstitution3.Columns.Add("name", typeof(string));
			DSCitizen.Tables.Add(DTInstitution3);

			DTInstitutionRole = new DataTable("DTInstitutionRoles");
			DTInstitutionRole.Columns.Add("id", typeof(int));
			DTInstitutionRole.Columns.Add("name", typeof(string));
			DTInstitutionRole.Columns.Add("institution_id", typeof(int));
			DTInstitutionRole.Columns.Add("template_id", typeof(int));
			DTInstitutionRole.Columns.Add("is_template_role", typeof(int));
			DTInstitutionRole.Columns.Add("description", typeof(string));
			DSCitizen.Tables.Add(DTInstitutionRole);

			DTInstitution2Role = new DataTable("DTInstitution2Roles");
			DTInstitution2Role.Columns.Add("id", typeof(int));
			DTInstitution2Role.Columns.Add("name", typeof(string));
			DTInstitution2Role.Columns.Add("institution_id", typeof(int));
			DTInstitution2Role.Columns.Add("template_id", typeof(int));
			DTInstitution2Role.Columns.Add("is_template_role", typeof(int));
			DTInstitution2Role.Columns.Add("description", typeof(string));
			DSCitizen.Tables.Add(DTInstitution2Role);

			DTInstitution3Role = new DataTable("DTInstitution3Roles");
			DTInstitution3Role.Columns.Add("id", typeof(int));
			DTInstitution3Role.Columns.Add("name", typeof(string));
			DTInstitution3Role.Columns.Add("institution_id", typeof(int));
			DTInstitution3Role.Columns.Add("template_id", typeof(int));
			DTInstitution3Role.Columns.Add("is_template_role", typeof(int));
			DTInstitution3Role.Columns.Add("description", typeof(string));
			DSCitizen.Tables.Add(DTInstitution3Role);

			DTCategories = new DataTable("DTCategories");
			DTCategories.Columns.Add("id", typeof(int));
			DTCategories.Columns.Add("name", typeof(string));
			DTCategories.Columns.Add("description", typeof(string));
			DSCitizen.Tables.Add(DTCategories);

			DTRelationshipRoles = new DataTable("DTRelationshipRoles");
			DTRelationshipRoles.Columns.Add("id", typeof(int));
			DTRelationshipRoles.Columns.Add("name", typeof(string));
			DSCitizen.Tables.Add(DTRelationshipRoles);

			ComboBoxAssistant.DataSource = DTCitizens;
			ComboBoxAssistant.ValueMember = "id";
			ComboBoxAssistant.DisplayMember = "name";

			ComboBoxTitle.DataSource = Catalogs.DTCitizenTitles;
			ComboBoxTitle.ValueMember = "value";
			ComboBoxTitle.DisplayMember = "text";

			ComboBoxSex.DataSource = Catalogs.DTSex;
			ComboBoxSex.ValueMember = "value";
			ComboBoxSex.DisplayMember = "text";

			ComboBoxPoliticalParty.DataSource = Catalogs.DTPoliticalParties;
			ComboBoxPoliticalParty.ValueMember = "value";
			ComboBoxPoliticalParty.DisplayMember = "text";

			ComboBoxCountry.DataSource = Catalogs.DTCountries;
			ComboBoxCountry.ValueMember = "value";
			ComboBoxCountry.DisplayMember = "text";

			ComboBoxInstitution.DataSource = DTInstitution;
			ComboBoxInstitution.ValueMember = "id";
			ComboBoxInstitution.DisplayMember = "name";
			ComboBoxInstitutionRole.DataSource = DTInstitutionRole;
			ComboBoxInstitutionRole.ValueMember = "id";
			ComboBoxInstitutionRole.DisplayMember = "name";

			Insitution2.DataSource = DTInstitution2;
			Insitution2.ValueMember = "id";
			Insitution2.DisplayMember = "name";
			Institution2Role.DataSource = DTInstitution2Role;
			Institution2Role.ValueMember = "id";
			Institution2Role.DisplayMember = "name";

			Institution3.DataSource = DTInstitution3;
			Institution3.ValueMember = "id";
			Institution3.DisplayMember = "name";
			Institution3Role.DataSource = DTInstitution3Role;
			Institution3Role.ValueMember = "id";
			Institution3Role.DisplayMember = "name";

			LAssitantName.Text = "";
			LAssistantPhone.Text = "";
			LAssitantCellphone.Text = "";

			LoadDTInstitutions();
			LoadDTInstitutionRoles(DTInstitutionRole, ComboBoxInstitutionRole, 0, 0);
			LoadDTInstitutionRoles(DTInstitution2Role, Institution2Role, 0, 0);
			LoadDTInstitutionRoles(DTInstitution3Role, Institution3Role, 0, 0);
			LoadDTCitizens();
			LoadDTCategories();
			LoadDTRelationshipRoles();

			LInstitutionSectorAndCategory.Text = "";
			LInstitution2SectorAndCategory.Text = "";
			LInstitution3SectorAndCategory.Text = "";

			LoadPermissions();
			LoadBirthdayFields();

			PoliticalRegisterDate.Value = DateTime.Now;
		}

		private void LoadPermissions()
		{
			if (Session.HasPermission("Ciudadanos.Electoral.Consultar") == false)
			{
				TabControlCitizen.TabPages.Remove(TabElectoral);
			}

			if (Session.HasPermission("Ciudadanos.Relaciones.Personal.Consultar") == false || Session.HasPermission("Ciudadanos.Relaciones.Consultar"))
			{

			}
		}

		private void LoadDTCategories()
		{
			List<TCitizenCategory> categories;

			Error error = CitizensHandler.GetCitizenCategories(out categories);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			DTCategories.BeginLoadData();
			DTCategories.Clear();

			DataRow row = DTCategories.NewRow();

			row["id"] = 0;
			row["name"] = "Ninguna";
			row["description"] = "";

			DTCategories.Rows.Add(row);

			foreach (TCitizenCategory category in categories)
			{
				row = DTCategories.NewRow();

				row["id"] = category.Id;
				row["name"] = category.Name;
				row["description"] = category.Description;

				DTCategories.Rows.Add(row);
			}

			DTCategories.EndLoadData();

			ComboBoxCategory.DataSource = DTCategories;
			ComboBoxCategory.ValueMember = "id";
			ComboBoxCategory.DisplayMember = "name";
		}

		private void LoadDTInstitutions()
		{
			using (new CursorWait())
			{
				List<TInstitution> institutions_list;

				Error error = InstitutionsHandler.GetInstitutions(out institutions_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				institutions_list.Insert(0, new TInstitution()
				{
					Id = 0,
					Name = "Ninguna",
					Sector = TSocietySector.None,
				});

				DTInstitution.BeginLoadData();
				DTInstitution2.BeginLoadData();
				DTInstitution3.BeginLoadData();
				DTInstitution.Clear();
				DTInstitution2.Clear();
				DTInstitution3.Clear();

				foreach (TInstitution institution in institutions_list)
				{
					DataRow row = DTInstitution.NewRow();
					DataRow row2 = DTInstitution2.NewRow();
					DataRow row3 = DTInstitution3.NewRow();

					row["id"] = institution.Id;
					row["name"] = institution.Name;
					row2["id"] = institution.Id;
					row2["name"] = institution.Name;
					row3["id"] = institution.Id;
					row3["name"] = institution.Name;

					DTInstitution.Rows.Add(row);
					DTInstitution2.Rows.Add(row2);
					DTInstitution3.Rows.Add(row3);
				}

				DTInstitution.EndLoadData();
				DTInstitution2.EndLoadData();
				DTInstitution3.EndLoadData();

				ComboBoxInstitutionRole.DataSource = DTInstitutionRole;
				ComboBoxInstitutionRole.ValueMember = "id";
				ComboBoxInstitutionRole.DisplayMember = "name";
				ComboBoxInstitution.SelectedIndex = 0;

				Insitution2.DataSource = DTInstitution2;
				Insitution2.ValueMember = "id";
				Insitution2.DisplayMember = "name";
				Insitution2.SelectedIndex = 0;

				Institution3.DataSource = DTInstitution3;
				Institution3.ValueMember = "id";
				Institution3.DisplayMember = "name";
				Institution3.SelectedIndex = 0;
			}
		}

		private void LoadDTCitizens()
		{
			using (new CursorWait())
			{
				List<TCitizen> citizen_list;

				Error error = CitizensHandler.GetCitizens(out citizen_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTCitizens.BeginLoadData();
				DTCitizens.Clear();

				DataRow row = DTCitizens.NewRow();

				row["id"] = 0;
				row["name"] = "Sin Asistente";

				DTCitizens.Rows.Add(row);

				foreach (TCitizen citizen in citizen_list)
				{
					row = DTCitizens.NewRow();

					row["id"] = citizen.Id;
					row["name"] = citizen.Name;

					DTCitizens.Rows.Add(row);
				}

				DTCitizens.EndLoadData();
			}
		}

		private void LoadDTRelationshipRoles()
		{
			using (new CursorWait())
			{
				Error error = CitizensHandler.GetCitizenRelationshipRoles(out List<TCitizenRelationshipRole> roles);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				roles.Insert(0, new TCitizenRelationshipRole()
				{
					Id = 0,
					Name = "Sin definir"
				});

				DTRelationshipRoles.BeginLoadData();
				DTRelationshipRoles.Clear();

				foreach (var role in roles)
				{
					DataRow row = DTRelationshipRoles.NewRow();

					row["id"] = role.Id;
					row["name"] = role.Name;

					DTRelationshipRoles.Rows.Add(row);
				}

				DTRelationshipRoles.EndLoadData();

				Relationship.DataSource = DTRelationshipRoles;
				Relationship.ValueMember = "id";
				Relationship.DisplayMember = "name";
				Relationship.SelectedValue = 0;
			}
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			ComboBoxTitle.Enabled = AccessMode != FAccessMode.Read;
			TextBoxName.Enabled = AccessMode != FAccessMode.Read;
			TextBoxPaternalName.Enabled = AccessMode != FAccessMode.Read;
			TextBoxMaternalName.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxSex.Enabled = AccessMode != FAccessMode.Read;

			KnownBirthday.Enabled = AccessMode != FAccessMode.Read;
			BDayMonth.Enabled = AccessMode != FAccessMode.Read;
			BDayDay.Enabled = AccessMode != FAccessMode.Read;
			BDayYear.Enabled = AccessMode != FAccessMode.Read;

			MaskedTextBoxCURP.Enabled = AccessMode != FAccessMode.Read;
			TextBoxObservations.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxPoliticalParty.Enabled = AccessMode != FAccessMode.Read;

			TextBoxPhone.Enabled = AccessMode != FAccessMode.Read;
			TextBoxPhoneExtension.Enabled = AccessMode != FAccessMode.Read;
			Phone2.Enabled = AccessMode != FAccessMode.Read;
			Phone2Extension.Enabled = AccessMode != FAccessMode.Read;
			Phone3.Enabled = AccessMode != FAccessMode.Read;
			Phone3Extension.Enabled = AccessMode != FAccessMode.Read;

			TextBoxCellphone.Enabled = AccessMode != FAccessMode.Read;
			TextBoxEmail.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxAssistant.Enabled = AccessMode != FAccessMode.Read;

			TextBoxStreet.Enabled = AccessMode != FAccessMode.Read;
			TextBoxNumber.Enabled = AccessMode != FAccessMode.Read;
			TextBoxInteriorNumber.Enabled = AccessMode != FAccessMode.Read;
			TextBoxCity.Enabled = AccessMode != FAccessMode.Read;
			TextBoxState.Enabled = AccessMode != FAccessMode.Read;
			TextBoxPostalCode.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxCountry.Enabled = AccessMode != FAccessMode.Read;
			TextBoxDistrict.Enabled = AccessMode != FAccessMode.Read;

			ComboBoxInstitution.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxInstitutionRole.Enabled = AccessMode != FAccessMode.Read;

			Insitution2.Enabled = AccessMode != FAccessMode.Read;
			Institution2Role.Enabled = AccessMode != FAccessMode.Read;

			Institution3.Enabled = AccessMode != FAccessMode.Read;
			Institution3Role.Enabled = AccessMode != FAccessMode.Read;

			VoterCode.Enabled = AccessMode != FAccessMode.Read;
			VoterOCR.Enabled = AccessMode != FAccessMode.Read;
			VoterCIC.Enabled = AccessMode != FAccessMode.Read;
			VoterSection.Enabled = AccessMode != FAccessMode.Read;

			ComboBoxCategory.Enabled = AccessMode != FAccessMode.Read;

			PoliticalRegisterDate.Enabled = AccessMode != FAccessMode.Read;
			IsPoliticalActivist.Enabled = AccessMode != FAccessMode.Read;
			KnownPoliticalRegisterDate.Enabled = AccessMode != FAccessMode.Read;

			BGenerateCURP.Enabled = AccessMode != FAccessMode.Read;

			RelationshipEnabled.Enabled = AccessMode != FAccessMode.Read;
			Relationship.Enabled = AccessMode != FAccessMode.Read;
			NAffinity.Enabled = AccessMode != FAccessMode.Read;
			KnownStartDate.Enabled = AccessMode != FAccessMode.Read;
			KnownEndDate.Enabled = AccessMode != FAccessMode.Read;
			StartDate.Enabled = AccessMode != FAccessMode.Read;
			EndDate.Enabled = AccessMode != FAccessMode.Read;
			RelationshipNotes.Enabled = AccessMode != FAccessMode.Read;

			BAccept.Visible = AccessMode != FAccessMode.Read;
			BCancel.Text = AccessMode != FAccessMode.Read ? "&Cancelar" : "&Cerrar";
		}

		public void SetId(int id)
		{
			using (new CursorWait())
			{
				Id = id;

				TCitizen citizen;

				Error error = CitizensHandler.GetCitizenById(Id, out citizen);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				ComboBoxTitle.SelectedValue = citizen.Title;
				TextBoxName.Text = citizen.Name;
				TextBoxPaternalName.Text = citizen.PaternalName;
				TextBoxMaternalName.Text = citizen.MaternalName;
				ComboBoxSex.SelectedValue = citizen.Sex;

				KnownBirthday.Checked = citizen.KnownBirthday;

				if (KnownBirthday.Checked)
				{
					BDayMonth.SelectedIndex = citizen.Birthday.Month - 1;
					BDayDay.SelectedIndex = citizen.Birthday.Day - 1;

					if (citizen.KnownBirthyear)
						BDayYear.SelectedIndex = citizen.Birthday.Year - 1914 + 1;
					else
						BDayYear.SelectedIndex = 0;
				}

				MaskedTextBoxCURP.Text = citizen.CURP;
				TextBoxObservations.Text = citizen.Observations;
				ComboBoxPoliticalParty.SelectedValue = citizen.PoliticalParty;

				TextBoxPhone.Text = citizen.Phone.Number;
				TextBoxPhoneExtension.Text = citizen.Phone.Extension;
				Phone2.Text = citizen.Phone2.Number;
				Phone2Extension.Text = citizen.Phone2.Extension;
				Phone3.Text = citizen.Phone3.Number;
				Phone3Extension.Text = citizen.Phone3.Extension;
				TextBoxCellphone.Text = citizen.Cellphone;
				ComboBoxAssistant.SelectedValue = citizen.Assistant.Id;
				TextBoxEmail.Text = citizen.Email;

				AddressId = citizen.Address.Id;
				TextBoxStreet.Text = citizen.Address.Street;
				TextBoxNumber.Text = citizen.Address.Number;
				TextBoxInteriorNumber.Text = citizen.Address.InteriorNumber;
				TextBoxCity.Text = citizen.Address.City;
				TextBoxState.Text = citizen.Address.State;
				TextBoxPostalCode.Text = citizen.Address.PostalCode;
				ComboBoxCountry.SelectedValue = citizen.Address.Country;
				TextBoxDistrict.Text = citizen.Address.District;

				ComboBoxInstitution.SelectedValue = citizen.Institution.Id;
				//ComboBoxInstitutionRole.SelectedValue = citizen.Role.Id;
				SelectInstitutionRoleValue(ComboBoxInstitutionRole, DTInstitutionRole, citizen.Role.Id, citizen.Role.InstitutionTemplateId);

				Insitution2.SelectedValue = citizen.Institution2.Id;
				//Institution2Role.SelectedValue = citizen.Role2.Id;
				SelectInstitutionRoleValue(Institution2Role, DTInstitution2Role, citizen.Role2.Id, citizen.Role2.InstitutionTemplateId);

				Institution3.SelectedValue = citizen.Institution3.Id;
				//Institution3Role.SelectedValue = citizen.Role3.Id;
				SelectInstitutionRoleValue(Institution3Role, DTInstitution3Role, citizen.Role3.Id, citizen.Role3.InstitutionTemplateId);

				ComboBoxCategory.SelectedValue = citizen.Category.Id;

				VoterCode.Text = citizen.VoterCode;
				VoterOCR.Text = citizen.VoterOCR;
				VoterCIC.Text = citizen.VoterCIC;
				VoterSection.Text = citizen.VoterSection;

				PoliticalRegisterDate.Value = citizen.PoliticalRegisterDate;
				IsPoliticalActivist.Checked = citizen.IsPoliticalActivist;
				KnownPoliticalRegisterDate.Checked = citizen.KnownPoliticalRegisterDate;

				if (citizen.KnownPoliticalRegisterDate == false)
					PoliticalRegisterDate.Value = DateTime.Now;

				IsPoliticalActivist_CheckedChanged(this, null);
				KnownPoliticalRegisterDate_CheckedChanged(this, null);

				RelationshipId = citizen.UserRelationship.Id;
				RelationshipEnabled.Checked = citizen.UserRelationship.Enabled;
				Relationship.SelectedValue = citizen.UserRelationship.Role.Id;
				NAffinity.Value = (decimal)citizen.UserRelationship.AffinityScore;
				KnownStartDate.Checked = citizen.UserRelationship.KnownStartDate;
				KnownEndDate.Checked = citizen.UserRelationship.KnownEndDate;
				RelationshipNotes.Text = citizen.UserRelationship.Notes;

				if (citizen.UserRelationship.KnownStartDate)
					StartDate.Value = citizen.UserRelationship.StartDate;
				else
					StartDate.Value = DateTime.Now;

				if (citizen.UserRelationship.KnownEndDate)
					EndDate.Value = citizen.UserRelationship.EndDate;
				else	
					EndDate.Value = DateTime.Now;

				RelationshipEnabled_CheckedChanged(this, null);
				KnownStartDate_CheckedChanged(this, null);
				KnownEndDate_CheckedChanged(this, null);

				Text = $"Ciudadano - {citizen.FullName}";
			}
		}

		private void LoadBirthdayFields()
		{
			BDayMonth.Items.Clear();
			BDayDay.Items.Clear();
			BDayYear.Items.Clear();

			for (int i = 0; i < 12; i++)
			{
				string raw_month_name = DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames[i];

				BDayMonth.Items.Add(raw_month_name.ToUpper().First() + raw_month_name.Substring(1));
			}

			BDayMonth.SelectedIndex = 0;

			for (int i = 1; i <= 31; i++)
			{
				BDayDay.Items.Add(i.ToString());
			}

			BDayDay.SelectedIndex = 0;

			BDayYear.Items.Add("???");

			for (int i = 1914; i <= DateTime.Now.Year; i++)
			{
				BDayYear.Items.Add(i.ToString());
			}

			BDayYear.SelectedIndex = 0;
		}

		private void FCitizenData_Load(object sender, EventArgs e)
		{
		}

		private void ComboBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				TCitizenTitle title = (TCitizenTitle)ComboBoxTitle.SelectedValue;
				LTitleFull.Text = "- " + BConstants.GetCitizenFullTitle(title);
			}
			catch
			{

			}
		}

		private void ComboBoxAssistant_SelectedIndexChanged(object sender, EventArgs e)
		{
			int id = (int)ComboBoxAssistant.SelectedValue;

			if (id == 0)
			{
				LAssitantName.Text = "";
				LAssistantPhone.Text = "";
				LAssitantCellphone.Text = "";
			}
			else
			{
				TCitizen assistant;

				Error error = CitizensHandler.GetCitizenAssistantById(id, out assistant);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				LAssitantName.Text = $"{assistant.FullName}";
				LAssistantPhone.Text = $"{assistant.Phone.FullNumberWithPrefix}";
				LAssitantCellphone.Text = $"Cel. {assistant.Cellphone}";
			}
		}

		private void ComboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				TCountry country = (TCountry)ComboBoxCountry.SelectedValue;

				LCountryFullName.Text = "- " + BConstants.GetCountryOfficialName(country);
			}
			catch { }
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			string curp = MaskedTextBoxCURP.Text.Trim().ToLower();
			string name = TextBoxName.Text.Trim().ToLower();
			string paternal_name = TextBoxPaternalName.Text.Trim().ToLower();
			string maternal_name = TextBoxMaternalName.Text.Trim().ToLower();
			DateTime birthday;
			TSex sex = (TSex)ComboBoxSex.SelectedValue;

			try
			{
				birthday = GetSelectedBirthday();
			}
			catch (ArgumentOutOfRangeException ex)
			{
				errors.Append("La fecha de nacimiento seleccionada es inválida");
			}

			if (name.Length == 0)
			{
				errors.AppendLine("Debe especificar el nombre");
			}

			if (paternal_name.Length == 0)
			{
				errors.AppendLine("Debe especificar el apellido paterno");
			}

			// #39 - citizens with only one last name can't be saved
			//if (maternal_name.Length == 0)
			//{
			//	errors.AppendLine("Debe especificar el apellido materno");
			//}

			if (sex == TSex.Unknown)
			{
				errors.AppendLine("Debe especificar el sexo");
			}

			// check for actions that requiere authorization
			List<TUserPermission> actions_to_authorize = new List<TUserPermission>();

			if (curp.Length == 0)
			{
				if (Session.HasPermission("Ciudadanos.NoEspecificarCURP") == false)
				{
					actions_to_authorize.Add(new TUserPermission(313, "Ciudadanos.NoEspecificarCURP"));
				}
			}
			else if (curp.Length != 18)
			{
				errors.AppendLine("La longitud del CURP no es la adecuada. La clave CURP debe ser conformada por 18 dígitos");
			}
			else
			{
				string re_curp = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";

				Regex rx = new Regex(re_curp, RegexOptions.Compiled | RegexOptions.IgnoreCase);

				if (rx.IsMatch(curp) == false)
				{
					errors.Append("El CURP no es adecuado. Asegurese que cumple con el formato especificado por la RENAPO, por ejemplo: \"KOHI710516HTCFIB63\"");
				}
			}

			// TODO: validate congruence with citizen data #20

			if ((int)ComboBoxInstitution.SelectedValue == 0 && Session.HasPermission("Ciudadanos.NoEspecificarInstitucion") == false)
			{
				actions_to_authorize.Add(new TUserPermission(312, "Ciudadanos.NoEspecificarInstitucion"));
			}

			if ((int)ComboBoxInstitutionRole.SelectedValue == 0 && Session.HasPermission("Ciudadanos.NoEspecificarCargo") == false)
			{
				actions_to_authorize.Add(new TUserPermission(313, "Ciudadanos.NoEspecificarCargo"));
			}

			if (
				TextBoxPhone.Text.Trim().Length == 0 &&
				TextBoxCellphone.Text.Trim().Length == 0 &&
				Session.HasPermission("Ciudadanos.NoEspecificarContacto") == false
				)
			{
				actions_to_authorize.Add(new TUserPermission(311, "Ciudadanos.NoEspecificarContacto"));
			}

			// validate relationship
			if (RelationshipEnabled.Checked)
			{
				if ((int)Relationship.SelectedValue == 0)
					errors.AppendLine("Debe especificar la relación");

				if (KnownStartDate.Checked && KnownEndDate.Checked && StartDate.Value > EndDate.Value)
					errors.AppendLine("La fecha de inicio de la relación no pude ser posterior a la de término");
			}

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
				return false;
			}

			if (actions_to_authorize.Count > 0)
			{
				using (FAuthorization authorization_dlg = new FAuthorization())
				{
					authorization_dlg.RequieredPermissions = actions_to_authorize;

					if (authorization_dlg.ShowDialog() != DialogResult.OK)
					{
						return false;
					}
				}
			}

			return true;
		}

		private DateTime GetSelectedBirthday()
		{
			return new DateTime(BDayYear.SelectedIndex == 0 ? 4 : BDayYear.SelectedIndex + 1914 - 1, BDayMonth.SelectedIndex + 1, BDayDay.SelectedIndex + 1);
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			if (ValidateInput() == false)
			{
				return;
			}

			DateTime now = DateTime.Now;

			using (new CursorWait())
			{
				TCitizen citizen = new TCitizen()
				{
					Id = Id,
					Title = (TCitizenTitle)ComboBoxTitle.SelectedValue,
					Name = TextBoxName.Text.Trim(),
					PaternalName = TextBoxPaternalName.Text.Trim(),
					MaternalName = TextBoxMaternalName.Text.Trim(),
					Sex = (TSex)ComboBoxSex.SelectedValue,
					CURP = MaskedTextBoxCURP.Text.Trim().ToUpper(),
					Observations = TextBoxObservations.Text.Trim(),
					PoliticalParty = (TPoliticalParty)ComboBoxPoliticalParty.SelectedValue,

					Cellphone = TextBoxCellphone.Text.Trim(),
					Email = TextBoxEmail.Text.Trim(),

					Author = new TUser()
					{
						Id = Session.User.Id,
					},

					CreatedDate = now,

					LastEditor = new TUser()
					{
						Id = Session.User.Id,
					},
					EditDate = now,

					VoterCode = VoterCode.Text.Trim(),
					VoterOCR = VoterOCR.Text.Trim(),
					VoterCIC = VoterCIC.Text.Trim(),
					VoterSection = VoterSection.Text.Trim(),

					Category = new TCitizenCategory()
					{
						Id = (int)ComboBoxCategory.SelectedValue
					},

					Institution = new TInstitution()
					{
						Id = (int)ComboBoxInstitution.SelectedValue
					},

					Institution2 = new TInstitution()
					{
						Id = (int)Insitution2.SelectedValue
					},

					Institution3 = new TInstitution()
					{
						Id = (int)Institution3.SelectedValue
					},
				};

				GetSelectedRoleValue(ComboBoxInstitutionRole, DTInstitutionRole, out citizen.Role.Id, out citizen.Role.InstitutionTemplateId);
				GetSelectedRoleValue(Institution2Role, DTInstitution2Role, out citizen.Role2.Id, out citizen.Role2.InstitutionTemplateId);
				GetSelectedRoleValue(Institution3Role, DTInstitution3Role, out citizen.Role3.Id, out citizen.Role3.InstitutionTemplateId);

				citizen.Phone.Number = TextBoxPhone.Text.Trim();
				citizen.Phone.Extension = TextBoxPhoneExtension.Text.Trim();
				citizen.Phone2.Number = Phone2.Text.Trim();
				citizen.Phone2.Extension = Phone2Extension.Text.Trim();
				citizen.Phone3.Number = Phone3.Text.Trim();
				citizen.Phone3.Extension = Phone3Extension.Text.Trim();

				citizen.KnownBirthday = KnownBirthday.Checked;
				citizen.KnownBirthyear = BDayYear.SelectedIndex != 0;
				citizen.Birthday = GetSelectedBirthday();

				citizen.IsPoliticalActivist = IsPoliticalActivist.Checked;
				citizen.KnownPoliticalRegisterDate = KnownPoliticalRegisterDate.Checked;
				citizen.PoliticalRegisterDate = PoliticalRegisterDate.Value;

				citizen.Assistant = new TCitizen();

				if (ComboBoxAssistant.SelectedValue != null)
				{
					citizen.Assistant.Id = (int)ComboBoxAssistant.SelectedValue;
				}

				citizen.Address = new TAddress()
				{
					Id = AddressId,
					Street = TextBoxStreet.Text.Trim(),
					Number = TextBoxNumber.Text.Trim(),
					InteriorNumber = TextBoxInteriorNumber.Text.Trim(),
					City = TextBoxCity.Text.Trim(),
					State = TextBoxState.Text.Trim(),
					PostalCode = TextBoxPostalCode.Text.Trim(),
					Country = (TCountry)ComboBoxCountry.SelectedValue,
					District = TextBoxDistrict.Text.Trim(),
				};

				citizen.UserRelationship = new TCitizenRelationship()
				{
					Id = RelationshipId,
					Citizen = new TCitizen()
					{
						Id = Session.User.Citizen.Id,
					},
					RelatedTo = new TCitizen()
					{
						Id = Id,
					},
					Role = new TCitizenRelationshipRole()
					{
						Id = (int)Relationship.SelectedValue
					},
					AffinityScore = (double)NAffinity.Value,
					KnownStartDate = KnownStartDate.Checked,
					KnownEndDate = KnownEndDate.Checked,
					StartDate = StartDate.Value,
					EndDate = EndDate.Value,
					Notes = RelationshipNotes.Text.Trim(),
					User = Session.User,
					Enabled = RelationshipEnabled.Checked
				};

				Error error = CitizensHandler.SaveCitizen(citizen, AccessMode == FAccessMode.Update);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DialogResult = DialogResult.OK;
			}
		}

		private void SelectInstitutionRoleValue(ComboBox combobox, DataTable datatable, int role_id, int template_id)
		{
			for (int i = 0; i < datatable.Rows.Count; i++)
			{
				DataRow row = datatable.Rows[i];

				if ((int)row["id"] == role_id && (int)row["template_id"] == template_id)
				{
					combobox.SelectedIndex = i;
					break;
				}
			}
		}

		private void GetSelectedRoleValue(ComboBox combobox, DataTable datatable, out int role_id, out int template_id)
		{
			int index = combobox.SelectedIndex;

			DataRow row = datatable.Rows[index];

			role_id = (int)row["id"];
			template_id = (int)row["template_id"];
		}

		private void LoadDTInstitutionRoles(DataTable datatable, ComboBox combobox, int institution_id, int institution_template_id)
		{
			using (new CursorWait())
			{
				List<TInstitutionRole> role_list = new List<TInstitutionRole>();

				if (institution_id != 0)
				{
					Error error = InstitutionsHandler.GetInstitutionRoles(institution_id, institution_template_id, out role_list);

					if (error != 0)
					{
						Utilities.ShowErrorDialog(error);
						return;
					}
				}

				role_list.Insert(0, new TInstitutionRole()
				{
					Id = 0,
					Name = "Ninguno",
					Description = "",
				});

				datatable.BeginLoadData();
				datatable.Clear();

				// se agregan los roles de normal 
				foreach (TInstitutionRole role in role_list)
				{
					DataRow row = datatable.NewRow();

					row["id"] = role.Id;
					row["name"] = role.Name;
					row["description"] = role.Description;
					row["institution_id"] = role.InstitutionId;
					row["template_id"] = role.InstitutionTemplateId;
					row["is_template_role"] = role.IsTemplateRole;

					datatable.Rows.Add(row);
				}

				datatable.EndLoadData();

				combobox.DataSource = datatable;
				combobox.ValueMember = "id";
				combobox.DisplayMember = "name";
				combobox.SelectedIndex = 0;
			}
		}

		private void OnInstitutionSelectedValueChanged(ComboBox combobox_institution, DataTable datatables_roles, ComboBox combobox_roles, Label label)
		{
			using (new CursorWait())
			{
				int id = 0;

				if (combobox_institution.SelectedValue != null)
				{
					id = (int)combobox_institution.SelectedValue;
				}

				label.Text = "";

				TInstitution institution = new TInstitution();

				if (id != 0)
				{
					Error error = InstitutionsHandler.GetInstitutionById(id, out institution);

					if (error != 0)
					{
						Utilities.ShowErrorDialog(error);
						return;
					}

					label.Text = $"{BConstants.GetSocietySectorName(institution.Sector)} - {institution.Category.Name}";
				}

				LoadDTInstitutionRoles(datatables_roles, combobox_roles, id, institution.Template.Id);
			}
		}

		private void ComboBoxInstitution_SelectedValueChanged(object sender, EventArgs e)
		{
			ComboBoxInstitutionRole.Enabled = false;
			BAccept.Enabled = false;

			OnInstitutionSelectedValueChanged(ComboBoxInstitution, DTInstitutionRole, ComboBoxInstitutionRole, LInstitutionSectorAndCategory);

			ComboBoxInstitutionRole.Enabled = true && AccessMode != FAccessMode.Read;
			BAccept.Enabled = AccessMode != FAccessMode.Read;
		}

		private void Insitution2_SelectedValueChanged(object sender, EventArgs e)
		{
			Institution2Role.Enabled = false;
			BAccept.Enabled = false;

			OnInstitutionSelectedValueChanged(Insitution2, DTInstitution2Role, Institution2Role, LInstitution2SectorAndCategory);

			Institution2Role.Enabled = AccessMode != FAccessMode.Read;
			BAccept.Enabled = AccessMode != FAccessMode.Read;
		}

		private void Institution3_SelectedValueChanged(object sender, EventArgs e)
		{
			Institution3Role.Enabled = false;
			BAccept.Enabled = false;

			OnInstitutionSelectedValueChanged(Institution3, DTInstitution3Role, Institution3Role, LInstitution3SectorAndCategory);

			Institution3Role.Enabled = AccessMode != FAccessMode.Read;
			BAccept.Enabled = AccessMode != FAccessMode.Read;
		}

		private void LCURP_Click(object sender, EventArgs e)
		{
			string url = "https://www.gob.mx/curp/";

			Utilities.OpenUrl(url);
		}

		private void FCitizenData_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				BCancel_Click(this, null);
			}
		}

		private void IsPoliticalActivist_CheckedChanged(object sender, EventArgs e)
		{
			KnownPoliticalRegisterDate.Enabled = IsPoliticalActivist.Checked && AccessMode != FAccessMode.Read;
			PoliticalRegisterDate.Enabled = IsPoliticalActivist.Checked && KnownPoliticalRegisterDate.Checked && AccessMode != FAccessMode.Read;

			PoliticalRegisterDate.Refresh();
		}

		private void BGenerateCURP_Click(object sender, EventArgs e)
		{
			string paternal_name = TextBoxPaternalName.Text.Trim().ToLower();
			string maternal_name = TextBoxMaternalName.Text.Trim().ToLower();
			string name = TextBoxName.Text.Trim().ToLower();
			DateTime bday = GetSelectedBirthday();
			TSex sex = (TSex)ComboBoxSex.SelectedValue;

			// validate necessary inputs
			StringBuilder errors = new StringBuilder();

			if (paternal_name.Length == 0)
				errors.AppendLine("Debe especificar el apellido paterno");

			if (maternal_name.Length == 0)
				errors.AppendLine("Debe especificar el apellido materno");

			if (name.Length == 0)
				errors.AppendLine("Debe especificar el nombre");

			if (sex == TSex.Unknown)
				errors.AppendLine("Debe especificar el sexo");

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
				return;
			}

			// if the curp is allready provided, confirm action before overwriting
			if (MaskedTextBoxCURP.Text.Trim().Length > 0)
			{
				if (Utilities.ShowConfirmDialog("¿Desea volver a generar la clave CURP? Este proceso remplazará la ya existente") != DialogResult.Yes)
				{
					return;
				}
			}

			// generate the actual curp
			// in conformance with https://sre.gob.mx/component/phocadownload/category/2-marco-normativo?download=1116:instructivo-normativo-para-la-asignacion-de-la-clave-unica-de-registro-de-poblacion-dof-18-10-2021-texto-vigente

			char[] curp = new char[18];

			// 1 - letra inicial del primer apellido
			curp[0] = paternal_name.First();

			// 2 - primera vocal interna del primer apellido
			curp[1] = 'X';

			foreach (char letter in paternal_name.Trim().Substring(1))
			{
				if (Utilities.IsVowel(letter))
				{
					curp[1] = letter;
					break;
				}
			}

			// 3 - letra inicial del segundo apellido
			curp[2] = maternal_name.First();

			// 4 - primera letra del nombre
			curp[3] = name.First();

			// 5 - penultimo digito del año de nacimiento // si no se conoce se esta dejando como 0 por convencion
			curp[4] = '0';

			if (BDayYear.SelectedIndex != 0)
			{
				curp[4] = (char)(bday.Year.ToString()[bday.Year.ToString().Length - 2]);
			}

			// 6 - ultimo digito del año de nacimiento // si no se conoce se esta dejando como 0 por convencion
			curp[5] = '0';

			if (BDayYear.SelectedIndex != 0)
			{
				curp[4] = (char)(bday.Year.ToString().Last());
			}

			// 7 - primer digito del mes de nacimiento, cuando es menor a 10 se pone un 0
			curp[6] = bday.Month < 10 ? '0' : bday.Month.ToString().First();

			// 8 segundo digito del mes de nacimiento
			curp[7] = bday.Month.ToString().Last();

			// 9 primer digito del día de nacimiento, cuando es menor a 10 se pone un 0
			curp[8] = bday.Day < 10 ? '0' : bday.Day.ToString().First();

			// 10 segundo digito del dia de nacimiento
			curp[9] = bday.Day.ToString().Last();

			// 11 - sexo: H para hombre, M para mujer
			curp[10] = sex == TSex.Female ? 'M' : 'H';

			// 12, 13 - lugar de nacimiento codificado en dos posiciones codificado conforme al catálogo de la CURP // este se esta dejando en AS por convención
			curp[11] = 'A';
			curp[12] = 'S';

			// 14 - primera consonante interna del primer apellido
			curp[13] = 'X';

			foreach (char letter in paternal_name.Substring(1))
			{
				if (!Utilities.IsVowel(letter))
				{
					curp[13] = letter;
					break;
				}
			}

			// 15 - primera consonante interna del segundo apellido
			curp[14] = 'X';

			foreach (char letter in maternal_name.Substring(1))
			{
				if (!Utilities.IsVowel(letter))
				{
					curp[14] = letter;
					break;
				}
			}

			// 16 - primera consonante interna del nombre
			curp[15] = 'X';

			foreach (char letter in name.Substring(1))
			{
				if (!Utilities.IsVowel(letter))
				{
					curp[15] = letter;
					break;
				}
			}

			// 17 - caracter diferenciador, shalala shalala // por convencion este se deja en 0
			curp[16] = '0';

			// 18 - caracter verificador, shalala shalala // por convenvion se deja en 0
			curp[17] = '0';

			MaskedTextBoxCURP.Text = (new string(curp)).ToUpper();
		}

		private void KnownBirthday_CheckedChanged(object sender, EventArgs e)
		{
			BDayMonth.Enabled = KnownBirthday.Checked && AccessMode != FAccessMode.Read;
			BDayDay.Enabled = KnownBirthday.Checked && AccessMode != FAccessMode.Read;
			BDayYear.Enabled = KnownBirthday.Checked && AccessMode != FAccessMode.Read;
		}

		private void KnownPoliticalRegisterDate_CheckedChanged(object sender, EventArgs e)
		{
			PoliticalRegisterDate.Enabled = KnownPoliticalRegisterDate.Checked && IsPoliticalActivist.Checked && AccessMode != FAccessMode.Read;

			PoliticalRegisterDate.Refresh();
		}

		private void RelationshipEnabled_CheckedChanged(object sender, EventArgs e)
		{
			Relationship.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
			NAffinity.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
			KnownStartDate.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
			StartDate.Enabled = RelationshipEnabled.Checked && KnownStartDate.Checked && AccessMode != FAccessMode.Read;
			KnownEndDate.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
			EndDate.Enabled = RelationshipEnabled.Checked && KnownEndDate.Checked && AccessMode != FAccessMode.Read;
			RelationshipNotes.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
		}

		private void KnownStartDate_CheckedChanged(object sender, EventArgs e)
		{
			StartDate.Enabled = KnownStartDate.Checked && AccessMode != FAccessMode.Read && RelationshipEnabled.Checked;
		}

		private void KnownEndDate_CheckedChanged(object sender, EventArgs e)
		{
			EndDate.Enabled = KnownEndDate.Checked && AccessMode != FAccessMode.Read && RelationshipEnabled.Checked;
		}
	}
}
