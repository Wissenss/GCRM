using Business;
using System.Data;
using System.Text;

namespace GCRM
{
	public partial class FInstitutionData : Form
	{
		FAccessMode AccessMode = FAccessMode.Create;
		int Id;

		DataSet DSInstitution;
		DataTable DTInstitutionRoles;
		DataTable DTInstitutions;
		DataTable DTInstitutionCategories;

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
			DSInstitution.Tables.Add(DTInstitutionRoles);

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colId", "Id", "id", false);
			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colParentRoleId", "Id Rol Padre", "parent_role_id", false);
			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colDelete", "Eliminar", "delete", false);
			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colName", "Cargo", "name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridInstitutionRoles, "colDescription", "Descripción", "description", true, display_index++, 200, 20, DataGridViewAutoSizeColumnMode.Fill);

			DataGridInstitutionRoles.DataSource = DSInstitution;
			DataGridInstitutionRoles.DataMember = DTInstitutionRoles.TableName;

			// configure the category data table
			DTInstitutionCategories = new DataTable("DTInstitutionCategories");
			DTInstitutionCategories.Columns.Add("id", typeof(int));
			DTInstitutionCategories.Columns.Add("name", typeof(string));
			DSInstitution.Tables.Add(DTInstitutionCategories);

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

			LoadInstitutions();
			LoadInstitutionCategories();
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

				LoadInstitutions();

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
			ComboBoxParentInstitution.SelectedValue = institution.ParentInstitutionId;
			ComboBoxCategory.SelectedValue = institution.Category.Id;

			DTInstitutionRoles.BeginLoadData();
			DTInstitutionRoles.Clear();

			foreach (TInstitutionRole role in institution.Roles)
			{
				DataRow row = DTInstitutionRoles.NewRow();

				row["id"] = role.Id;
				row["name"] = role.Name;
				row["parent_role_id"] = role.InstitutionId;
				row["description"] = role.Description;
				row["delete"] = false;

				DTInstitutionRoles.Rows.Add(row);
			}

			DTInstitutionRoles.EndLoadData();
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
					ParentInstitutionId = (int)ComboBoxParentInstitution.SelectedValue,
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

				foreach (DataRow row in DTInstitutionRoles.Rows)
				{
					// si se quiere eliminar el rol, no se agrega a la lista
					if ((bool)row["delete"] == true)
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
			using (FInstitutionRole role_dlg = new FInstitutionRole())
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

			using (FInstitutionRole role_dlg = new FInstitutionRole())
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
						if ((int)row["id"] == id)
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
		}

		private void DataGridInstitutionRoles_SelectionChanged(object sender, EventArgs e)
		{
			if (DataGridInstitutionRoles.SelectedRows.Count == 0)
				return;

			DataGridViewRow row = DataGridInstitutionRoles.SelectedRows[0];

			bool delete = (bool)row.Cells["colDelete"].Value;

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
		}
	}
}
