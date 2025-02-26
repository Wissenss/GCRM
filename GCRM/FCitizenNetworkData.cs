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

	public partial class FCitizenNetworkData : Form
	{
		DataSet DSCitizenNetwork;
		DataTable DTMembers;
		DataTable DTRoles;

		FAccessMode Mode;
		int Id;
		TCitizen LeadCitizen;

		public FCitizenNetworkData()
		{
			InitializeComponent();

			LeadCitizen = new TCitizen();

			// create the datasource
			DSCitizenNetwork = new DataSet("DSCitizenNetwork");

			// create the members datatable
			DTMembers = new DataTable("DTMembers");
			DTMembers.Columns.Add("id", typeof(int));
			DTMembers.Columns.Add("citizennetwork_id", typeof(int));
			DTMembers.Columns.Add("citizen_id", typeof(int));
			DTMembers.Columns.Add("citizennetwork_citizen_role_id", typeof(int));
			DTMembers.Columns.Add("parent_member_id", typeof(int));
			DTMembers.Columns.Add("citizen_name", typeof(string));
			DTMembers.Columns.Add("rol_name", typeof(string));
			DSCitizenNetwork.Tables.Add(DTMembers);

			// initialize members datagrid
			DataGridUtilities.AddColumn(DataGridMembers, "colId", "Miembro Id", "id", false);
			DataGridUtilities.AddColumn(DataGridMembers, "colCitizenNetworkId", "Estructura Id", "citizennetwork_id", false);
			DataGridUtilities.AddColumn(DataGridMembers, "colCitizenId", "Ciudadano Id", "citizen_id", false);
			DataGridUtilities.AddColumn(DataGridMembers, "colCitizenNetworkCitizenRoleId", "Rol Id", "citizennetwork_citizen_role_id", false);
			DataGridUtilities.AddColumn(DataGridMembers, "colParentMemberId", "Miembro Padre", "parent_member_id", false);

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridMembers, "colCitizenName", "Nombre", "citizen_name", true, display_index++, 100, 100, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridMembers, "colRolName", "Rol", "rol_name", true, display_index++, 50, 50, DataGridViewAutoSizeColumnMode.Fill);

			// bind the members datagrid
			DataGridMembers.DataSource = DSCitizenNetwork;
			DataGridMembers.DataMember = "DTMembers";

			// create the roles datatable
			DTRoles = new DataTable("DTRoles");
			DTRoles.Columns.Add("id", typeof(int));
			DTRoles.Columns.Add("citizennetwork_id", typeof(int));
			DTRoles.Columns.Add("name", typeof(string));
			DTRoles.Columns.Add("description", typeof(string));
			DSCitizenNetwork.Tables.Add(DTRoles);

			// initialize roles datagrid
			DataGridUtilities.AddColumn(DataGridRoles, "colId", "Id", "id", false);
			DataGridUtilities.AddColumn(DataGridRoles, "colCitizenNetworkId", "EstructuraId", "citizennetwork_id", false);

			display_index = 0;

			DataGridUtilities.AddColumn(DataGridRoles, "colName", "Nombre", "name", true, display_index++, 100, 100, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridRoles, "colDescription", "Descripción", "description", true, display_index++, 100, 100, DataGridViewAutoSizeColumnMode.Fill);

			// bind the roles datagrid
			DataGridRoles.DataSource = DSCitizenNetwork;
			DataGridRoles.DataMember = "DTRoles";
		}

		public void SetAccessMode(FAccessMode mode)
		{
			Mode = mode;
		}

		public void SetId(int id)
		{
			using (new CursorWait())
			{
				Id = id;

				TCitizenNetwork network;

				Error error = CitizenNetworksHandler.GetCitizenNetworkById(Id, out network);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				// fill general data	
				TextBoxName.Text = network.Name;
				TextBoxDescription.Text = network.Description;
				TextBoxLeadCitizen.Text = $"{network.LeadCitizen.Name} {network.LeadCitizen.PaternalName} {network.LeadCitizen.MaternalName}";
				LLeadCitizenInfo.Text = $"Tel. {network.LeadCitizen.Phone} Cel. {network.LeadCitizen.Cellphone}";

				LeadCitizen = network.LeadCitizen;

				// fill roles
				DTRoles.BeginLoadData();
				DTRoles.Clear();

				foreach (TCitizenNetworkRole role in network.Roles)
				{
					DataRow row = DTRoles.NewRow();

					row["id"] = role.Id;
					row["citizennetwork_id"] = role.CitizenNetworkId;
					row["name"] = role.Name;
					row["description"] = role.Description;

					DTRoles.Rows.Add(row);
				}

				DTRoles.EndLoadData();

				// fill members
				DTMembers.BeginLoadData();
				DTMembers.Clear();

				foreach (TCitizenNetworkMember member in network.Members)
				{
					DataRow row = DTMembers.NewRow();

					row["id"] = member.Id;
					row["citizennetwork_id"] = member.CitizenNetworkId;
					row["citizen_id"] = member.Citizen.Id;
					row["parent_member_id"] = member.ParentMemberId;
					row["citizennetwork_citizen_role_id"] = member.Role.Id;
					row["citizen_name"] = member.Citizen.Name;
					row["rol_name"] = member.Role.Name;

					DTMembers.Rows.Add(row);
				}

				DTMembers.EndLoadData();
			}
		}

		private void RefreshMembersStructure()
		{
			using (new CursorWait())
			{
				TreeViewMembers.BeginUpdate();
				TreeViewMembers.Nodes.Clear();

				// first node of the tree is the lead
				TreeNode root_node = new TreeNode(LeadCitizen.Name);

				TreeViewMembers.Nodes.Add(root_node);

				// then all others are should be children of this
				PopulateTreeNode(ref root_node, 0);

				TreeViewMembers.EndUpdate();

				TreeViewMembers.ExpandAll();
			}
		}

		public void PopulateTreeNode(ref TreeNode node, int id)
		{
			foreach (DataRow row in DTMembers.Rows)
			{
				if ((int)row["parent_member_id"] == id)
				{
					TreeNode child_node = new TreeNode((string)row["name"]);

					child_node.Tag = new TCitizenNetworkMember()
					{
						Id = (int)row["id"],
						ParentMemberId = (int)row["parent_member_id"]
					};

					node.Nodes.Add(child_node);

					PopulateTreeNode(ref child_node, (int)row["id"]);
				}
			}
		}

		private bool ValidateInput()
		{
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
				TCitizenNetwork network = new TCitizenNetwork();

				// general data
				network.Name = TextBoxName.Text.Trim();
				network.Description = TextBoxDescription.Text.Trim();
				network.LeadCitizen.Id = 0;

				// roles
				foreach (DataRow row in DTRoles.Rows)
				{
					TCitizenNetworkRole role = new TCitizenNetworkRole();

					role.Id = (int)row["id"];
					role.CitizenNetworkId = Id;
					role.Name = (string)row["name"];
					role.Description = (string)row["description"];

					network.Roles.Add(role);
				}

				// members
				foreach (DataRow row in DTMembers.Rows)
				{
					TCitizenNetworkMember member = new TCitizenNetworkMember();

					member.Id = (int)row["id"];
					member.CitizenNetworkId = Id;
					member.Citizen.Id = (int)row["citizen_id"];
					member.ParentMemberId = (int)row["parent_member_id"];
					member.Role.Id = (int)row["citizennetwork_citizen_role_id"];

					network.Members.Add(member);
				}

				Error error = CitizenNetworksHandler.SaveCitizenNetwork(network, Mode == FAccessMode.Update);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DialogResult = DialogResult.OK;
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private TCitizenNetworkRole GetSelectedRole(out int row_index)
		{
			row_index = 0;

			if (DataGridRoles.SelectedRows.Count == 0)
			{
				return null;
			}

			DataGridViewRow row = DataGridRoles.SelectedRows[0];

			row_index = row.Index;

			TCitizenNetworkRole role = new TCitizenNetworkRole()
			{
				Id = (int)row.Cells["colId"].Value,
				CitizenNetworkId = Id,
				Name = (string)row.Cells["colName"].Value,
				Description = (string)row.Cells["colDescription"].Value,
			};

			return role;
		}

		private int GetSelectedMemberId()
		{
			if (DataGridMembers.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = DataGridMembers.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			return id;
		}

		private void BAddRole_Click(object sender, EventArgs e)
		{
			using (FCitizenNetworkRoleData role_data_dlt = new FCitizenNetworkRoleData())
			{
				TCitizenNetworkRole new_role = new TCitizenNetworkRole()
				{
					Id = 0,
					CitizenNetworkId = Id,
					Name = "",
				};

				role_data_dlt.SetMode(FAccessMode.Create);
				role_data_dlt.SetRole(new_role);

				if (role_data_dlt.ShowDialog() == DialogResult.OK)
				{
					new_role = role_data_dlt.GetRole();

					DTRoles.BeginLoadData();

					DataRow row = DTRoles.NewRow();

					row["id"] = new_role.Id;
					row["citizennetwork_id"] = new_role.CitizenNetworkId;
					row["name"] = new_role.Name;
					row["description"] = new_role.Description;

					DTRoles.Rows.Add(row);

					DTRoles.EndLoadData();
				}
			}
		}

		private void BEditRole_Click(object sender, EventArgs e)
		{
			int row_index;

			TCitizenNetworkRole role = GetSelectedRole(out row_index);

			if (role == null)
			{
				return;
			}

			using (FCitizenNetworkRoleData role_data_dlg = new FCitizenNetworkRoleData())
			{
				role_data_dlg.SetMode(FAccessMode.Update);
				role_data_dlg.SetRole(role);

				if (role_data_dlg.ShowDialog() == DialogResult.OK)
				{
					DataRow row = DTRoles.Rows[row_index];

					role = role_data_dlg.GetRole();

					row.BeginEdit();

					row["id"] = role.Id;
					row["citizennetwork_id"] = Id;
					row["name"] = role.Name;
					row["description"] = role.Description;

					row.EndEdit();
				}
			}
		}

		private void BReadRole_Click(object sender, EventArgs e)
		{
			int row_index;

			TCitizenNetworkRole role = GetSelectedRole(out row_index);

			if (role == null)
			{
				return;
			}

			using (FCitizenNetworkRoleData role_data_dlg = new FCitizenNetworkRoleData())
			{
				role_data_dlg.SetMode(FAccessMode.Read);
				role_data_dlg.SetRole(role);

				role_data_dlg.ShowDialog();
			}
		}

		private void BDeleteRole_Click(object sender, EventArgs e)
		{
			int role_index;

			TCitizenNetworkRole role = GetSelectedRole(out role_index);

			if (role == null)
			{
				return;
			}

			// TODO: check the role isn't being used by no network member

			if (Utilities.ShowDeleteConfirmDialog("¿Desea eliminar el rol de la estructura?") != DialogResult.OK)
			{
				return;
			}

			DTRoles.Rows.RemoveAt(role_index);
		}

		private void BAddMember_Click(object sender, EventArgs e)
		{
			
		}
	}
}
