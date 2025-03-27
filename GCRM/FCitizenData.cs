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
		DataTable DTInstitution2;
		DataTable DTInstitution3;
		DataTable DTInstitutionRole;
		DataTable DTInstitution2Role;
		DataTable DTInstitution3Role;
		DataTable DTCategories;

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
			DSCitizen.Tables.Add(DTInstitutionRole);

			DTInstitution2Role = new DataTable("DTInstitution2Roles");
			DTInstitution2Role.Columns.Add("id", typeof(int));
			DTInstitution2Role.Columns.Add("name", typeof(string));
			DSCitizen.Tables.Add(DTInstitution2Role);

			DTInstitution3Role = new DataTable("DTInstitution3Roles");
			DTInstitution3Role.Columns.Add("id", typeof(int));
			DTInstitution3Role.Columns.Add("name", typeof(string));
			DSCitizen.Tables.Add(DTInstitution3Role);

			DTCategories = new DataTable("DTCategories");
			DTCategories.Columns.Add("id", typeof(int));
			DTCategories.Columns.Add("name", typeof(string));
			DTCategories.Columns.Add("description", typeof(string));
			DSCitizen.Tables.Add(DTCategories);

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
			LoadDTInstitutionRoles(DTInstitutionRole, ComboBoxInstitutionRole, 0);
			LoadDTInstitutionRoles(DTInstitution2Role, Institution2Role, 0);
			LoadDTInstitutionRoles(DTInstitution3Role, Institution3Role, 0);
			LoadDTCitizens();
			LoadDTCategories();

			LInstitutionSectorAndCategory.Text = "";
			LInstitution2SectorAndCategory.Text = "";
			LInstitution3SectorAndCategory.Text = "";

			LoadPermissions();
		}

		private void LoadPermissions()
		{
			if (Session.HasPermission("Ciudadanos.Electoral.Consultar") == false)
			{
				TabControlCitizen.TabPages.Remove(TabElectoral);
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
					ParentInstitutionId = 0,
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

			Insitution2.Enabled = AccessMode != FAccessMode.Read;
			Institution2Role.Enabled = AccessMode != FAccessMode.Read;

			Institution3.Enabled = AccessMode != FAccessMode.Read;
			Institution3Role.Enabled = AccessMode != FAccessMode.Read;

			VoterCode.Enabled = AccessMode != FAccessMode.Read;
			VoterOCR.Enabled = AccessMode != FAccessMode.Read;
			VoterCIC.Enabled = AccessMode != FAccessMode.Read;
			VoterSection.Enabled = AccessMode != FAccessMode.Read;

			ComboBoxCategory.Enabled = AccessMode != FAccessMode.Read;

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

				Insitution2.SelectedValue = citizen.Institution2.Id;
				Institution2Role.SelectedValue = citizen.Role2.Id;

				Institution3.SelectedValue = citizen.Institution3.Id;
				Institution3Role.SelectedValue = citizen.Role3.Id;

				ComboBoxCategory.SelectedValue = citizen.Category.Id;

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

					Role = new TInstitutionRole()
					{
						Id = (int)ComboBoxInstitutionRole.SelectedValue
					},

					Institution2 = new TInstitution()
					{
						Id = (int)Insitution2.SelectedValue
					},

					Role2 = new TInstitutionRole()
					{
						Id = (int)Institution2Role.SelectedValue
					},

					Institution3 = new TInstitution()
					{
						Id = (int)Institution3.SelectedValue
					},

					Role3 = new TInstitutionRole()
					{
						Id = (int)Institution3Role.SelectedValue
					},
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

				Error error = CitizensHandler.SaveCitizen(citizen, AccessMode == FAccessMode.Update);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DialogResult = DialogResult.OK;
			}
		}

		private void LoadDTInstitutionRoles(DataTable datatable, ComboBox combobox, int institution_id)
		{
			using (new CursorWait())
			{
				List<TInstitutionRole> role_list = new List<TInstitutionRole>();

				if (institution_id != 0)
				{
					Error error = InstitutionsHandler.GetInstitutionRoles(institution_id, out role_list);

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

				foreach (TInstitutionRole role in role_list)
				{
					DataRow row = datatable.NewRow();

					row["id"] = role.Id;
					row["name"] = role.Name;

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

				if (id != 0)
				{
					Error error = InstitutionsHandler.GetInstitutionById(id, out TInstitution institution);

					if (error != 0)
					{
						Utilities.ShowErrorDialog(error);
						return;
					}

					label.Text = $"{BConstants.GetSocietySectorName(institution.Sector)} - {institution.Category.Name}";
				}

				LoadDTInstitutionRoles(datatables_roles, combobox_roles, id);
			}
		}

		private void ComboBoxInstitution_SelectedValueChanged(object sender, EventArgs e)
		{
			OnInstitutionSelectedValueChanged(ComboBoxInstitution, DTInstitutionRole, ComboBoxInstitutionRole, LInstitutionSectorAndCategory);
		}

		private void Insitution2_SelectedValueChanged(object sender, EventArgs e)
		{
			OnInstitutionSelectedValueChanged(Insitution2, DTInstitution2Role, Institution2Role, LInstitution2SectorAndCategory);
		}

		private void Institution3_SelectedValueChanged(object sender, EventArgs e)
		{
			OnInstitutionSelectedValueChanged(Institution3, DTInstitution3Role, Institution3Role, LInstitution3SectorAndCategory);
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
