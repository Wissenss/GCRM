using Business;
using System.Data;
using System.Text;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
	public partial class FInstitutionData : Form
	{
		FAccessMode AccessMode = FAccessMode.Create;
		int Id;
		int AddressId;

		DataSet DSInstitution;
		DataTable DTInstitutionRoles;
		DataTable DTInstitutions;
		DataTable DTInstitutionCategories;
		DataTable DTTemplates;

		public FInstitutionData()
		{
			InitializeComponent();

			// configure the roles grid
			DSInstitution = new DataSet();

			DTInstitutionRoles = new DataTable("DTInstitutionRoles");
			DTInstitutionRoles.Columns.Add("id", typeof(int));
			DTInstitutionRoles.Columns.Add("name", typeof(string));
			DTInstitutionRoles.Columns.Add("parent_role_id", typeof(int));
			DTInstitutionRoles.Columns.Add("description", typeof(string));
			DTInstitutionRoles.Columns.Add("delete", typeof(bool));
			DTInstitutionRoles.Columns.Add("template_id", typeof(int));
			DTInstitutionRoles.Columns.Add("citizens_with_role", typeof(int));
			DSInstitution.Tables.Add(DTInstitutionRoles);

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colId", "Id", "id", false);
			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colParentRoleId", "Id Rol Padre", "parent_role_id", false);
			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colDelete", "Eliminar", "delete", false);
			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colTemplateId", "Id Plantilla", "template_id", false);
			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colName", "Cargo", "name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colDescription", "Descripción", "description", true, display_index++, 200, 20, DataGridViewAutoSizeColumnMode.Fill);
			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colCitizensWithRole", "Usos", "citizens_with_role", true, display_index++, 200, 20, DataGridViewAutoSizeColumnMode.AllCells);

			DataGridInstitutionRoles.DataSource = DSInstitution;
			DataGridInstitutionRoles.DataMember = DTInstitutionRoles.TableName;

			// configure the category data table
			DTInstitutionCategories = new DataTable("DTInstitutionCategories");
			DTInstitutionCategories.Columns.Add("id", typeof(int));
			DTInstitutionCategories.Columns.Add("name", typeof(string));
			DSInstitution.Tables.Add(DTInstitutionCategories);

			// configure the templates data table
			DTTemplates = new DataTable("DTTemplates");
			DTTemplates.Columns.Add("id", typeof(int));
			DTTemplates.Columns.Add("name", typeof(string));
			DTTemplates.Columns.Add("description", typeof(string));
			DSInstitution.Tables.Add(DTTemplates);

			// configure the sectors combo box
			ComboBoxSocietySector.DataSource = Catalogs.DTSocietySector;
			ComboBoxSocietySector.ValueMember = "value";
			ComboBoxSocietySector.DisplayMember = "text";

			// configure the categories combo box
			ComboBoxCategory.DataSource = DTInstitutionCategories;
			ComboBoxCategory.ValueMember = "id";
			ComboBoxCategory.DisplayMember = "name";

			// configure parent institution combobox
			DTInstitutions = new DataTable("DTInstitutions");
			DTInstitutions.Columns.Add("id", typeof(int));
			DTInstitutions.Columns.Add("name", typeof(string));
			DSInstitution.Tables.Add(DTInstitutions);

			ComboBoxParentInstitution.DataSource = DTInstitutions;
			ComboBoxParentInstitution.ValueMember = "id";
			ComboBoxParentInstitution.DisplayMember = "name";

			// configure the country combo box
			ComboBoxCountry.DataSource = Catalogs.DTCountries;
			ComboBoxCountry.ValueMember = "value";
			ComboBoxCountry.DisplayMember = "text";

			Template.DataSource = DTTemplates;
			Template.ValueMember = "id";
			Template.DisplayMember = "name";

			LoadInstitutions();
			LoadInstitutionCategories();
			LoadTemplates();
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			ComboBoxSocietySector.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxCategory.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxParentInstitution.Enabled = AccessMode != FAccessMode.Read;
			TextBoxName.Enabled = AccessMode != FAccessMode.Read;
			TextBoxDescription.Enabled = AccessMode != FAccessMode.Read;
			TextBoxAcronym.Enabled = AccessMode != FAccessMode.Read;

			BAddRole.Enabled = AccessMode != FAccessMode.Read;
			BEditRole.Enabled = AccessMode != FAccessMode.Read;
			BDeleteRole.Enabled = AccessMode != FAccessMode.Read;

			Template.Enabled = AccessMode != FAccessMode.Read;

			TextBoxStreet.Enabled = AccessMode != FAccessMode.Read;
			TextBoxNumber.Enabled = AccessMode != FAccessMode.Read;
			TextBoxInteriorNumber.Enabled = AccessMode != FAccessMode.Read;
			TextBoxCity.Enabled = AccessMode != FAccessMode.Read;
			TextBoxState.Enabled = AccessMode != FAccessMode.Read;
			TextBoxPostalCode.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxCountry.Enabled = AccessMode != FAccessMode.Read;
			TextBoxDistrict.Enabled = AccessMode != FAccessMode.Read;

			BAccept.Visible = AccessMode != FAccessMode.Read;
			BCancel.Text = AccessMode != FAccessMode.Read ? "&Cancelar" : "&Cerrar";
		}

		public void SetId(int id)
		{
			using (new CursorWait())
			{
				Id = id;

				TInstitution institution;

				Error error = InstitutionsHandler.GetInstitutionById(Id, out institution);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				FillFromInstitution(institution);

				Text = $"Institución - {institution.Name}";
			}
		}

		public void DuplicateId(int id)
		{
			using (new CursorWait())
			{
				Id = 0;

				TInstitution institution;

				Error error = InstitutionsHandler.GetInstitutionById(id, out institution);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				FillFromInstitution(institution);

				LoadInstitutions();

				Text = $"Institución - Nueva";
			}
		}

		private void FillFromInstitution(TInstitution institution)
		{
			ComboBoxSocietySector.SelectedValue = institution.Sector;
			TextBoxName.Text = institution.Name;
			TextBoxDescription.Text = institution.Description;
			TextBoxAcronym.Text = institution.Acronym;
			ComboBoxCategory.SelectedValue = institution.Category.Id;

			Template.SelectedValue = institution.Template.Id;

			AddressId = institution.Address.Id;
			TextBoxStreet.Text = institution.Address.Street;
			TextBoxNumber.Text = institution.Address.Number;
			TextBoxInteriorNumber.Text = institution.Address.InteriorNumber;
			TextBoxCity.Text = institution.Address.City;
			TextBoxState.Text = institution.Address.State;
			TextBoxPostalCode.Text = institution.Address.PostalCode;
			ComboBoxCountry.SelectedValue = institution.Address.Country;
			TextBoxDistrict.Text = institution.Address.District;

			DTInstitutionRoles.BeginLoadData();
			DTInstitutionRoles.Clear();

			int citizens_with_template_roles = 0;

			foreach (TInstitutionRole role in institution.Roles)
			{
				DataRow row = DTInstitutionRoles.NewRow();

				row["id"] = role.Id;
				row["name"] = role.Name;
				row["parent_role_id"] = role.InstitutionId;
				row["description"] = role.Description;
				row["delete"] = false;
				row["template_id"] = role.InstitutionTemplateId;
				row["citizens_with_role"] = role.NoCitizensWithThisRole;

				if (role.IsTemplateRole == true)
				{
					citizens_with_template_roles += role.NoCitizensWithThisRole;
				}

				DTInstitutionRoles.Rows.Add(row);
			}

			Template.Enabled = (citizens_with_template_roles == 0 && AccessMode != FAccessMode.Read) || AccessMode == FAccessMode.Create;

			DTInstitutionRoles.EndLoadData();

			LoadInstitutions();

			ComboBoxParentInstitution.SelectedValue = institution.ParentInstitution.Id;
		}

		private void LoadInstitutions()
		{
			using (new CursorWait())
			{
				List<TInstitution> institution_list;

				Error error = InstitutionsHandler.GetInstitutions(out institution_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTInstitutions.BeginLoadData();
				DTInstitutions.Clear();

				DataRow row = DTInstitutions.NewRow();

				row["id"] = 0;
				row["name"] = "Ninguna";

				DTInstitutions.Rows.Add(row);

				foreach (TInstitution institution in institution_list)
				{
					if (institution.Id == Id)
					{
						continue;
					}

					row = DTInstitutions.NewRow();

					row["id"] = institution.Id;
					row["name"] = institution.Name;

					DTInstitutions.Rows.Add(row);
				}

				DTInstitutions.EndLoadData();
			}
		}

		private void LoadInstitutionCategories()
		{
			using (new CursorWait())
			{
				List<TInstitutionCategory> category_list;

				Error error = InstitutionsHandler.GetInstitutionCategories(out category_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				category_list.Insert(0, new TInstitutionCategory()
				{
					Id = 0,
					Name = "Ninguna",
					Description = ""
				});

				DTInstitutionCategories.BeginLoadData();
				DTInstitutionCategories.Clear();

				foreach (TInstitutionCategory category in category_list)
				{
					DataRow row = DTInstitutionCategories.NewRow();

					row["id"] = category.Id;
					row["name"] = category.Name;

					DTInstitutionCategories.Rows.Add(row);
				}

				DTInstitutionCategories.EndLoadData();

				ComboBoxCategory.DataSource = DTInstitutionCategories;
				ComboBoxCategory.ValueMember = "id";
				ComboBoxCategory.DisplayMember = "name";
				ComboBoxCategory.SelectedIndex = 0;
			}
		}

		private void LoadTemplates()
		{
			using (new CursorWait())
			{
				Error error = InstitutionsHandler.GetInstitutionTemplates(out List<TInstitutionTemplate> templates);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				templates.Add(new TInstitutionTemplate()
				{
					Id = 0,
					Name = "Ninguna",
					Description = ""
				});

				DTTemplates.BeginLoadData();
				DTTemplates.Clear();

				foreach (TInstitutionTemplate template in templates)
				{
					DataRow row = DTTemplates.NewRow();

					row["id"] = template.Id;
					row["name"] = template.Name;
					row["description"] = template.Description;

					DTTemplates.Rows.Add(row);
				}

				DTTemplates.EndLoadData();

				Template.DataSource = DTTemplates;
				Template.ValueMember = "id";
				Template.DisplayMember = "name";
				Template.SelectedValue = 0;
			}
		}

		private void LoadPermissions()
		{
			using (new CursorWait())
			{
				BAddRole.Visible = Session.HasPermission("Instituciones.Roles.Crear");
				BEditRole.Visible = Session.HasPermission("Instituciones.Roles.Editar");
				BDeleteRole.Visible = Session.HasPermission("Instituciones.Roles.Eliminar");

				if (Session.HasPermission("Instituciones.Roles.Consultar") == false)
				{
					TabControlInstitution.TabPages.RemoveAt(1);
				}
			}
		}

		private void FInstitutionData_Load(object sender, EventArgs e)
		{
			LoadPermissions();
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (TextBoxName.Text.Trim().Length == 0)
			{
				errors.AppendLine("Debe especificar el nombre de la institución");
			}

			bool has_roles = false;

			foreach (DataRow row in DTInstitutionRoles.Rows)
			{
				if ((bool)row["delete"] == false)
				{
					has_roles = true;
					break;
				}
			}

			if (has_roles == false)
			{
				errors.AppendLine("La institución debe tener al menos un cargo definido");
			}

			if ((TSocietySector)ComboBoxSocietySector.SelectedValue == TSocietySector.None)
			{
				errors.AppendLine("Debe especificar el sector social al que pertenece la institución");
			}

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
				return false;
			}

			return true;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			if (ValidateInput() == false)
			{
				return;
			}

			using (new CursorWait())
			{
				TInstitution institution = new TInstitution()
				{
					Id = Id,
					Name = TextBoxName.Text.Trim(),
					Sector = (TSocietySector)ComboBoxSocietySector.SelectedValue,
					Category = new TInstitutionCategory()
					{
						Id = (int)ComboBoxCategory.SelectedValue,
					},
					Description = TextBoxDescription.Text.Trim(),
					Acronym = TextBoxAcronym.Text.Trim(),
					ParentInstitution = new TInstitution()
					{
						Id = (int)ComboBoxParentInstitution.SelectedValue,
					},
					Roles = new List<TInstitutionRole>(),
					Author = new TUser()
					{
						Id = Session.User.Id,
					},
					CreatedDate = DateTime.Now,
					LastEditor = new TUser()
					{
						Id = Session.User.Id,
					},
					EditDate = DateTime.Now
				};

				institution.Template.Id = (int)Template.SelectedValue;

				institution.Address = new TAddress()
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

				foreach (DataRow row in DTInstitutionRoles.Rows)
				{
					// si se quiere eliminar el rol, no se agrega a la lista
					if ((bool)row["delete"] == true)
					{
						continue;
					}

					// si viene del template, tampoco se agrega
					if ((int)row["template_id"] != 0)
					{
						continue;
					}

					TInstitutionRole role = new TInstitutionRole()
					{
						Id = (int)row["id"],
						Name = (string)row["name"],
						ParentRoleId = (int)row["parent_role_id"],
						Description = (string)row["description"],
					};

					institution.Roles.Add(role);
				}

				Error error = InstitutionsHandler.SaveInstitution(institution, AccessMode == FAccessMode.Update);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DialogResult = DialogResult.OK;
			}
		}

		private void BAddRole_Click(object sender, EventArgs e)
		{
			using (FInstitutionRoleData role_dlg = new FInstitutionRoleData())
			{
				if (role_dlg.ShowDialog() == DialogResult.OK)
				{
					string name;
					string description;

					role_dlg.GetValues(out name, out description);

					DataRow row = DTInstitutionRoles.NewRow();

					row["id"] = 0;
					row["name"] = name;
					row["parent_role_id"] = 0;
					row["description"] = description;
					row["delete"] = false;
					row["template_id"] = 0;

					DTInstitutionRoles.Rows.Add(row);
				}
			}
		}

		private int GetSelectedInstitutionRoleId()
		{
			if (DataGridInstitutionRoles.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = DataGridInstitutionRoles.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			return id;
		}

		private void BEditRole_Click(object sender, EventArgs e)
		{
			int id = GetSelectedInstitutionRoleId();

			if (id == 0)
			{
				return;
			}

			using (FInstitutionRoleData role_dlg = new FInstitutionRoleData())
			{
				DataGridViewRow selected_row = DataGridInstitutionRoles.SelectedRows[0];

				string name = (string)selected_row.Cells["colName"].Value;
				string description = (string)selected_row.Cells["colDescription"].Value;

				role_dlg.SetValues(name, description);

				if (role_dlg.ShowDialog() == DialogResult.OK)
				{
					role_dlg.GetValues(out name, out description);

					foreach (DataRow row in DTInstitutionRoles.Rows)
					{
						if ((int)row["id"] == id && (int)row["template_id"] == 0)
						{
							row.BeginEdit();

							row["name"] = name;
							row["description"] = description;

							row.EndEdit();
						}
					}
				}
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void BDeleteRole_Click(object sender, EventArgs e)
		{
			if (DataGridInstitutionRoles.SelectedRows.Count == 0)
				return;

			DataGridViewRow row = DataGridInstitutionRoles.SelectedRows[0];

			bool delete = (bool)row.Cells["colDelete"].Value;

			row.Cells["colDelete"].Value = !delete;

			DataGridInstitutionRoles.InvalidateRow(row.Index);

			DataGridInstitutionRoles_SelectionChanged(null, null);
		}

		private void DataGridInstitutionRoles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			DataGridViewRow row = DataGridInstitutionRoles.Rows[e.RowIndex];

			if (row.Cells["colDelete"].Value == null)
				return;

			if ((bool)row.Cells["colDelete"].Value)
			{
				e.CellStyle.BackColor = Color.FromArgb(255, 200, 200);
				e.CellStyle.SelectionBackColor = Color.FromArgb(255, 150, 150);
			}

			//if ((int)row.Cells["colTemplateId"].Value > 0)
			//{
			//	e.CellStyle.BackColor = Color.FromArgb(224, 224, 224);
			//	e.CellStyle.SelectionBackColor = Color.FromArgb(200, 200, 200);
			//}
		}

		private void DataGridInstitutionRoles_SelectionChanged(object sender, EventArgs e)
		{
			if (DataGridInstitutionRoles.SelectedRows.Count == 0)
				return;

			DataGridViewRow row = DataGridInstitutionRoles.SelectedRows[0];

			bool delete = (bool)row.Cells["colDelete"].Value;
			int template_id = (int)row.Cells["colTemplateId"].Value;

			BDeleteRole.Enabled = template_id == 0;

			if (delete)
			{
				BDeleteRole.Text = "&Restaurar";
				BDeleteRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Cancel_16;
			}
			else
			{
				BDeleteRole.Text = "&Borrar";
				BDeleteRole.Image = Properties.Resources.Fatcow_Farm_Fresh_Delete_16;
			}

			if (AccessMode == FAccessMode.Read)
			{
				BDeleteRole.Enabled = false;
			}
		}

		private void Template_SelectedIndexChanged(object sender, EventArgs e)
		{
			using (new CursorWait())
			{
				int id = (int)Template.SelectedValue;

				DTInstitutionRoles.BeginLoadData();

				List<DataRow> rows_to_delete = new List<DataRow>();

				foreach (DataRow row in DTInstitutionRoles.Rows)
				{
					if ((int)row["template_id"] != 0)
					{
						rows_to_delete.Add(row);
					}
				}

				foreach (DataRow row in rows_to_delete)
				{
					row.Delete();
				}

				DTInstitutionRoles.EndLoadData();

				if (id == 0)
					return;

				Error error = InstitutionsHandler.GetInstitutionTemplateRoles(id, 0, out List<TInstitutionRole> roles);

				DTInstitutionRoles.BeginLoadData();

				foreach (TInstitutionRole role in roles)
				{
					DataRow row = DTInstitutionRoles.NewRow();

					row["id"] = role.Id;
					row["name"] = role.Name;
					row["parent_role_id"] = 0;
					row["description"] = role.Description;
					row["delete"] = false;
					row["template_id"] = role.InstitutionTemplateId;

					DTInstitutionRoles.Rows.Add(row);
				}

				DTInstitutionRoles.EndLoadData();
			}
		}

		private void BSearchCitizensWithRole_Click(object sender, EventArgs e)
		{
			if (DataGridInstitutionRoles.SelectedRows.Count == 0)
				return;

			// get selected role info
			DataGridViewRow row = DataGridInstitutionRoles.SelectedRows[0];

			int role_id = (int)row.Cells["colId"].Value;
			int institution_id = Id;
			string role_name = (string)row.Cells["colName"].Value;	

			using (FSimpleList list_dlg = new FSimpleList())
			{
				// configure the list dialog
				list_dlg.Text = $"Ciudadanos con cargo - \"{role_name}\"";
				
				list_dlg.DTSimpleList.Columns.Add("name", typeof(string));	

				int display_index = 0;

				DataGridUtilities.AddColumn(list_dlg.DataGridSimpleList, "colName", "Ciudadano", "name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.Fill);
				
				// load the citizen list
				List<TCitizen> citizens_with_role;

				using (new CursorWait())
				{
					Error error = CitizensHandler.GetCitizensWithInstitutionRole(institution_id, role_id, out citizens_with_role);

					if (error != 0)
					{
						Utilities.ShowErrorDialog(error);
						return;
					}

					list_dlg.DTSimpleList.BeginLoadData();
					list_dlg.DTSimpleList.Clear();

					foreach (TCitizen citizen in citizens_with_role)
					{
						DataRow row_citizen = list_dlg.DTSimpleList.NewRow();

						row_citizen["name"] = $"{BConstants.GetCitizenBriefTitle(citizen.Title, citizen.Sex)} {citizen.FullNameWithFirstCapitals}";

						list_dlg.DTSimpleList.Rows.Add(row_citizen);
					}

					list_dlg.DTSimpleList.EndLoadData();

					list_dlg.DataGridSimpleList.DataSource = list_dlg.DTSimpleList;
				}

				// show the list
				list_dlg.ShowDialog();
			}
		}
	}
}
