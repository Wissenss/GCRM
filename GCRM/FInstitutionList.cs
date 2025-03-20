using Business;
using System.Data;

namespace GCRM
{
	public partial class FInstitutionList : Form
	{
		public FInstitutionList()
		{
			InitializeComponent();

			DataGridInstitutions.AutoGenerateColumns = false;

			DataGridInstitutions.DataSource = Catalogs.DSCatalogs;
			DataGridInstitutions.DataMember = "DTInstitutions";
		}

		public void LoadList()
		{
			using (new CursorWait())
			{
				Catalogs.LoadDTInstitutions();

				TreeView.BeginUpdate();
				TreeView.Nodes.Clear();

				foreach (DataRow row in Catalogs.DTInstitutions.Rows)
				{
					if ((int)row["parent_institution_id"] == 0)
					{
						TreeNode head_node = new TreeNode((string)row["name"]);

						TreeView.Nodes.Add(head_node);

						PopulateTreeNode(ref head_node, (int)row["id"]);
					}
				}

				TreeView.EndUpdate();

				TreeView.ExpandAll();
			}
		}

		public void PopulateTreeNode(ref TreeNode node, int id)
		{
			foreach (DataRow row in Catalogs.DTInstitutions.Rows)
			{
				if ((int)row["parent_institution_id"] == id)
				{
					TreeNode child_node = new TreeNode((string)row["name"]);

					node.Nodes.Add(child_node);

					PopulateTreeNode(ref child_node, (int)row["id"]);
				}
			}
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private void LoadPermissions()
		{
			using (new CursorWait())
			{
				BAdd.Visible = Session.HasPermission("Instituciones.Crear");
				BEdit.Visible = Session.HasPermission("Instituciones.Editar");
				BRead.Visible = Session.HasPermission("Instituciones.Consultar");
				BDelete.Visible = Session.HasPermission("Instituciones.Eliminar");
			}
		}

		private void FInstitutionList_Load(object sender, EventArgs e)
		{
			LoadPermissions();

			LoadList();
		}

		private int GetSelectedInstitutionId()
		{
			if (DataGridInstitutions.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = DataGridInstitutions.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			return id;
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FInstitutionData institution_data_dlg = new FInstitutionData())
			{
				institution_data_dlg.SetAccessMode(FAccessMode.Create);

				if (institution_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int id = GetSelectedInstitutionId();

			if (id == 0)
			{
				return;
			}

			using (FInstitutionData institution_data_dlg = new FInstitutionData())
			{
				institution_data_dlg.SetAccessMode(FAccessMode.Update);
				institution_data_dlg.SetId(id);

				if (institution_data_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BRead_Click(object sender, EventArgs e)
		{
			int id = GetSelectedInstitutionId();

			if (id == 0)
			{
				return;
			}

			using (FInstitutionData institution_data_dlg = new FInstitutionData())
			{
				institution_data_dlg.SetAccessMode(FAccessMode.Read);
				institution_data_dlg.SetId(id);

				institution_data_dlg.ShowDialog();
			}
		}

		private void BDelete_Click(object sender, EventArgs e)
		{
			int id = GetSelectedInstitutionId();



			DialogResult result = MessageBox.Show(
			 "¿Está seguro de que desea eliminar esta institución?",
			 "Confirmar eliminación",
			 MessageBoxButtons.YesNo,
			 MessageBoxIcon.Warning
			 );

			if (result != DialogResult.Yes || id == 0)
			{
				return;
			}

			Error error = InstitutionsHandler.DeleteInstitutionById(id);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			LoadList();
		}

		private void BShowHierarchy_Click(object sender, EventArgs e)
		{
			SplitContainer.Panel2Collapsed = BShowHierarchy.Checked == false;
		}

		private void BSearch_Click(object sender, EventArgs e)
		{
			PanelSearch.Visible = BSearch.Checked;

			FilterList();
		}

		private void FilterList()
		{
			string filter = "true";
			string search = TextBoxSearch.Text.Trim();

			if (BSearch.Checked && search.Length > 0)
			{
				filter += @$" and (
												name like '%{search}%' OR
												society_sector_name like '%{search}%' OR
												category_name like '%{search}%' OR
												description like '%{search}%'
									    )";
			}

			Catalogs.DTInstitutions.DefaultView.RowFilter = filter;

			DataGridInstitutions.DataSource = Catalogs.DTInstitutions;
			DataGridInstitutions.Refresh();
		}

		private void FInstitutionList_Leave(object sender, EventArgs e)
		{
			// clear the filter so when this global datatable is use somewhere we keep on seeng all rows
			Catalogs.DTInstitutions.DefaultView.RowFilter = "";
		}

		private void TextBoxSearch_TextChanged(object sender, EventArgs e)
		{
			FilterList();
		}
	}
}
