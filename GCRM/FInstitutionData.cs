using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
	public partial class FInstitutionData : Form
	{
		FAccessMode AccessMode = FAccessMode.Create;
		int Id;

		DataSet DSInstitution;
		DataTable DTInstitutionRoles;

		public FInstitutionData()
		{
			InitializeComponent();

			// configure the roles grid
			DSInstitution = new DataSet();

			DTInstitutionRoles = new DataTable("DTInstitutionRoles");
			DTInstitutionRoles.Columns.Add("id", typeof(int));
			DTInstitutionRoles.Columns.Add("name", typeof(string));
			DTInstitutionRoles.Columns.Add("institution_id", typeof(int));
			DTInstitutionRoles.Columns.Add("parent_role_id", typeof(int));
			DTInstitutionRoles.Columns.Add("description", typeof(string));
			DSInstitution.Tables.Add(DTInstitutionRoles);

			DataGridInstitutionRoles.AutoGenerateColumns = false;
			DataGridInstitutionRoles.DataSource = DSInstitution;
			DataGridInstitutionRoles.DataMember = "DTInstitutionRoles";
			DataGridInstitutionRoles.Columns["colId"].Visible = false;

			// configure the sectors combo box
			ComboBoxSocietySector.DataSource = Catalogs.DTSocietySector;
			ComboBoxSocietySector.ValueMember = "value";
			ComboBoxSocietySector.DisplayMember = "text";

			// configure the categories combo box
			ComboBoxCategory.DataSource = Catalogs.DTInstitutionCategories;
			ComboBoxCategory.ValueMember = "id";
			ComboBoxCategory.DisplayMember = "name";
		}

		public void SetAccessMode(FAccessMode mode)
		{
			AccessMode = mode;

			ComboBoxSocietySector.Enabled = AccessMode != FAccessMode.Read;
			ComboBoxCategory.Enabled = AccessMode != FAccessMode.Read;
			TextBoxName.Enabled = AccessMode != FAccessMode.Read;
			TextBoxDescription.Enabled = AccessMode != FAccessMode.Read;

			BAddRole.Enabled = AccessMode != FAccessMode.Read;
			BEditRole.Enabled = AccessMode != FAccessMode.Read;

			BAccept.Visible = AccessMode != FAccessMode.Read;
			BCancel.Text = AccessMode != FAccessMode.Read ? "&Cancelar" : "&Cerrar";
		}

		public void SetId(int id)
		{
			Id = id;

			TInstitution institution;

			Error error = InstitutionsHandler.GetInstitutionById(Id, out institution);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			ComboBoxSocietySector.SelectedValue = institution.Sector;
			ComboBoxCategory.SelectedValue = institution.Category.Id;
			TextBoxName.Text = institution.Name;
			TextBoxDescription.Text = institution.Description;

			DTInstitutionRoles.BeginLoadData();
			DTInstitutionRoles.Clear();

			foreach (TInstitutionRole role in institution.Roles)
			{
				DataRow row = DTInstitutionRoles.NewRow();

				row["id"] = role.Id;
				row["name"] = role.Name;
				row["institution_id"] = role.InstitutionId;
				row["parent_role_id"] = role.InstitutionId;
				row["description"] = role.Description;

				DTInstitutionRoles.Rows.Add(row);
			}

			DTInstitutionRoles.EndLoadData();
		}

		private void LoadPermissions()
		{
			BAddRole.Visible = Session.HasPermission("Instituciones.Roles.Crear");
			BEditRole.Visible = Session.HasPermission("Instituciones.Roles.Editar");

			if (Session.HasPermission("Instituciones.Roles.Consultar") == false)
			{
				TabControlInstitution.TabPages.RemoveAt(1);
			}
		}

		private void FInstitutionData_Load(object sender, EventArgs e)
		{
			LoadPermissions();

			Catalogs.LoadDTInstitutionCategories();
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (TextBoxName.Text.Trim().Length == 0)
			{
				errors.AppendLine("Debe especificar el nombre de la institución");
			}

			if (DataGridInstitutionRoles.Rows.Count == 0)
			{
				errors.AppendLine("La institución debe tener al menos un cargo definido");
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
				Roles = new List<TInstitutionRole>()
			};

			foreach (DataRow row in DTInstitutionRoles.Rows)
			{
				TInstitutionRole role = new TInstitutionRole()
				{
					Id = (int)row["id"],
					Name = (string)row["name"],
					InstitutionId = (int)row["institution_id"],
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
					row["institution_id"] = Id;
					row["parent_role_id"] = 0;
					row["description"] = description;

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
	}
}
