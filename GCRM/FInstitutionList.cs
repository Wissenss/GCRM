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
	public partial class FInstitutionList : Form
	{
		public FInstitutionList()
		{
			InitializeComponent();

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

				//TreeView.Nodes.Add("BaseNode");

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
	}
}
