using Business;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace GCRM
{
	public partial class FCitizenData : Form
	{
		DataSet DSCitizen;
		DataTable DTCitizens;
		DataTable DTInstitution;
		DataTable DTInstitutionRoles;

		FAccessMode AccessMode = FAccessMode.Create;
		int Id;
		int AddressId;

		public FCitizenData()
		{
			InitializeComponent();

			DSCitizen = new DataSet();

			DTCitizens = new DataTable("DTCitizens");
			DTCitizens.Columns.Add("id", typeof(int));
			DTCitizens.Columns.Add("name", typeof(string));
			DSCitizen.Tables.Add(DTCitizens);

			DTInstitution = new DataTable("DTInstitutions");
			DTInstitution.Columns.Add("id", typeof(int));
			DTInstitution.Columns.Add("name", typeof(string));
			DSCitizen.Tables.Add(DTInstitution);

			DTInstitutionRoles = new DataTable("DTInstitutionRoles");
			DTInstitutionRoles.Columns.Add("id", typeof(int));
			DTInstitutionRoles.Columns.Add("name", typeof(string));
			DSCitizen.Tables.Add(DTInstitutionRoles);

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

			ComboBoxInstitutionRole.DataSource = DTInstitutionRoles;
			ComboBoxInstitutionRole.ValueMember = "id";
			ComboBoxInstitutionRole.DisplayMember = "name";

			LAssitantName.Text = "";
			LAssistantPhone.Text = "";
			LAssitantCellphone.Text = "";

			LoadDTInstitutions();
			LoadDTInstitutionRoles();
			LoadDTCitizens();

			LInstitutionSectorAndCategory.Text = "";
			LInstitutionRoleDescription.Text = "";

			ComboBoxInstitution.SelectedIndex = 0;

			LoadPermissions();
		}

		private void LoadPermissions()
		{
			if (Session.HasPermission("Ciudadanos.Electoral.Consultar") == false)
			{
				TabControlCitizen.TabPages.Remove(TabElectoral);
			}
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

				TInstitution null_institution;

				error = InstitutionsHandler.GetNullInstitution(out null_institution);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				institutions_list.Insert(0, null_institution);

				DTInstitution.BeginLoadData();
				DTInstitution.Clear();

				foreach (TInstitution institution in institutions_list)
				{
					DataRow row = DTInstitution.NewRow();

					row["id"] = institution.Id;
					row["name"] = institution.Name;

					DTInstitution.Rows.Add(row);
				}

				DTInstitution.EndLoadData();
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

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			ComboBoxTitle.Enabled = AccessMode != FAccessMode.Read;
			TextBoxName.Enabled = AccessMode != FAccessMode.Read;
			TextBoxPaternalName.Enabled = AccessMode != FAccessMode.Read;
			TextBoxMaternalName.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxSex.Enabled = AccessMode != FAccessMode.Read;
			DatePickerBirthday.Enabled = AccessMode != FAccessMode.Read;
			MaskedTextBoxCURP.Enabled = AccessMode != FAccessMode.Read;
			TextBoxObservations.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxPoliticalParty.Enabled = AccessMode != FAccessMode.Read;

			TextBoxPhone.Enabled = AccessMode != FAccessMode.Read;
			TextBoxPhoneExtension.Enabled = AccessMode != FAccessMode.Read;
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

			VoterCode.Enabled = AccessMode != FAccessMode.Read;
			VoterOCR.Enabled = AccessMode != FAccessMode.Read;
			VoterCIC.Enabled = AccessMode != FAccessMode.Read;
			VoterSection.Enabled = AccessMode != FAccessMode.Read;

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
				DatePickerBirthday.Value = citizen.Birthday;
				MaskedTextBoxCURP.Text = citizen.CURP;
				TextBoxObservations.Text = citizen.Observations;
				ComboBoxPoliticalParty.SelectedValue = citizen.PoliticalParty;

				TextBoxPhone.Text = citizen.Phone;
				TextBoxPhoneExtension.Text = citizen.PhoneExtension;
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
				ComboBoxInstitutionRole.SelectedValue = citizen.Role.Id;

				VoterCode.Text = citizen.VoterCode;
				VoterOCR.Text = citizen.VoterOCR;
				VoterCIC.Text = citizen.VoterCIC;
				VoterSection.Text = citizen.VoterSection;

				Text = $"Ciudadano - {citizen.Name} {citizen.PaternalName} {citizen.MaternalName}";
			}
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

				LAssitantName.Text = $"{assistant.Name} {assistant.PaternalName} {assistant.MaternalName}";
				LAssistantPhone.Text = $"Tel. {assistant.Phone} Ext. {assistant.PhoneExtension}";
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
			DateTime birthday = DatePickerBirthday.Value;
			TSex sex = (TSex)ComboBoxSex.SelectedValue;

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
					Birthday = DatePickerBirthday.Value,
					CURP = MaskedTextBoxCURP.Text.Trim().ToUpper(),
					Observations = TextBoxObservations.Text.Trim(),
					PoliticalParty = (TPoliticalParty)ComboBoxPoliticalParty.SelectedValue,

					Phone = TextBoxPhone.Text.Trim(),
					PhoneExtension = TextBoxPhoneExtension.Text.Trim(),
					Cellphone = TextBoxCellphone.Text.Trim(),
					Email = TextBoxEmail.Text.Trim(),

					Author = new TUser()
					{
						Id = Session.User.Id,
					},

					CreatedDate = now,
					EditById = Session.User.Id,
					EditDate = now,

					VoterCode = VoterCode.Text.Trim(),
					VoterOCR = VoterOCR.Text.Trim(),
					VoterCIC = VoterCIC.Text.Trim(),
					VoterSection = VoterSection.Text.Trim()
				};

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

				citizen.Institution = new TInstitution();

				if (ComboBoxInstitution.SelectedValue != null)
				{
					citizen.Institution.Id = (int)ComboBoxInstitution.SelectedValue;
				}

				citizen.Role = new TInstitutionRole();

				if (ComboBoxInstitutionRole.SelectedValue != null)
				{
					citizen.Role.Id = (int)ComboBoxInstitutionRole.SelectedValue;
				}

				Error error = CitizensHandler.SaveCitizen(citizen, AccessMode == FAccessMode.Update);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DialogResult = DialogResult.OK;
			}
		}

		private void LoadDTInstitutionRoles()
		{
			using (new CursorWait())
			{
				int institution_id = (int)ComboBoxInstitution.SelectedValue;

				List<TInstitutionRole> role_list;

				Error error = 0;

				if (institution_id == 0)
				{
					error = InstitutionsHandler.GetNullInstitutionRoles(out role_list);
				}
				else
				{
					error = InstitutionsHandler.GetInstitutionRoles(institution_id, out role_list);
				}

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTInstitutionRoles.BeginLoadData();
				DTInstitutionRoles.Clear();

				foreach (TInstitutionRole role in role_list)
				{
					DataRow row = DTInstitutionRoles.NewRow();

					row["id"] = role.Id;
					row["name"] = role.Name;

					DTInstitutionRoles.Rows.Add(row);
				}

				DTInstitutionRoles.EndLoadData();

				ComboBoxInstitutionRole.DataSource = DTInstitutionRoles;
				ComboBoxInstitutionRole.ValueMember = "id";
				ComboBoxInstitutionRole.DisplayMember = "name";

				if (role_list.Count > 0)
				{
					ComboBoxInstitutionRole.SelectedValue = role_list[0].Id;
				}
				else
				{
					ComboBoxInstitutionRole.SelectedValue = null;
				}
			}
		}

		private void ComboBoxInstitution_SelectedValueChanged(object sender, EventArgs e)
		{
			if (ComboBoxInstitution.SelectedValue == null)
			{
				return;
			}

			using (new CursorWait())
			{
				try
				{
					int id = (int)ComboBoxInstitution.SelectedValue;

					if (id == 0)
					{
						LInstitutionSectorAndCategory.Text = "";
					}
					else
					{
						TInstitution institution;

						Error error = InstitutionsHandler.GetInstitutionById(id, out institution);

						if (error != 0)
						{
							Utilities.ShowErrorDialog(error);
							return;
						}

						LInstitutionSectorAndCategory.Text = $"{BConstants.GetSocietySectorName(institution.Sector)} - {institution.Category.Name}";
					}

					LoadDTInstitutionRoles();
				}
				catch
				{
				}
			}
		}

		private void ComboBoxInstitutionRole_SelectedValueChanged(object sender, EventArgs e)
		{
			if (ComboBoxInstitutionRole.SelectedValue == null)
			{
				return;
			}

			using (new CursorWait())
			{
				try
				{
					int id = (int)ComboBoxInstitutionRole.SelectedValue;

					if (id == 0)
					{
						LInstitutionRoleDescription.Text = "";
						return;
					}

					TInstitutionRole role;

					Error error = InstitutionsHandler.GetInstitutionRoleById(id, out role);

					if (error != 0)
					{
						Utilities.ShowErrorDialog(error);
						return;
					}

					LInstitutionRoleDescription.Text = role.Description;
				}
				catch
				{

				}
			}
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

	}
}
