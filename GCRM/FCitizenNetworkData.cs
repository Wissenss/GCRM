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
			DTRoles.Columns.Add("id", typeof(int));
			DTRoles.Columns.Add("citizen_network_id", typeof(int));
			DTRoles.Columns.Add("name", typeof(string));
			DSCitizenNetwork.Tables.Add(DTRoles);

			// initialize roles datagrid
			DataGridUtilities.AddColumn(DataGridRoles, "colId", "Id", "id", false);
			DataGridUtilities.AddColumn(DataGridRoles, "colCitizenNetworkId", "EstructuraId", "citizennetwork_id", false);

			display_index = 0;

			DataGridUtilities.AddColumn(DataGridRoles, "colName", "Nombre", "name", true, display_index++, 100, 100, DataGridViewAutoSizeColumnMode.Fill);

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
	}
}
