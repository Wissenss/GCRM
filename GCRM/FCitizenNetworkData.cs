using BrightIdeasSoftware;
using Business;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Interop;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
	public partial class FCitizenNetworkData : Form
	{
		// using Object List View are you? well... lets hope this doesn't screw us over latter down the line
		public class OLVM_NetworkMember
		{
			public OLVM_NetworkMember() { }
			public int MemberId { get; set; } = 0;
			public int ParentMemberId { get; set; } = 0;
			public string Name { get; set; } = "";
			public string Role { get; set; } = "";
			public string RoleDescription { get; set; } = "";
			public string ElectorCode { get; set; } = "";
			public string OCR { get; set; } = "";
			public string Section { get; set; } = "";
			public string Phone { get; set; } = "";
		}

		private List<OLVM_NetworkMember> members_models = new List<OLVM_NetworkMember>();
		private Dictionary<int, int> members_childrens_count = new Dictionary<int, int>();

		DataSet DSCitizenNetwork;
		DataTable DTMembers;
		DataTable DTRoles;

		FAccessMode Mode;
		int Id;
		TCitizen LeadCitizen;

		FCitizenNetworkMemberData MemberDlg;
		FCitizenNetworkRoleData RoleDlg;

		int citizen_structure_expand_level = 1;

		public FCitizenNetworkData()
		{
			InitializeComponent();

			LeadCitizen = new TCitizen();

			// configure object list tree view
			ObjectListMembers.ShowGroups = false;
			ObjectListMembers.FullRowSelect = true;
			ObjectListMembers.Scrollable = true;

			SetupColumns();
			SetupStyles();
			SetupTree();

			// create the datasource
			DSCitizenNetwork = new DataSet("DSCitizenNetwork");

			// create the members datatable
			DTMembers = new DataTable("DTMembers");

			DataColumn col_members_id = DTMembers.Columns.Add("id", typeof(int));
			col_members_id.AutoIncrement = true;
			col_members_id.AutoIncrementSeed = 1;

			DTMembers.Columns.Add("citizennetwork_id", typeof(int));
			DTMembers.Columns.Add("citizen_id", typeof(int));
			DTMembers.Columns.Add("role_id", typeof(int));
			DTMembers.Columns.Add("parent_member_id", typeof(int));
			DTMembers.Columns.Add("citizen_name", typeof(string));
			DTMembers.Columns.Add("role_name", typeof(string));
			DTMembers.Columns.Add("role_level", typeof(int));
			DSCitizenNetwork.Tables.Add(DTMembers);

			//// initialize members datagrid
			//DataGridUtilities.AddColumn(DataGridMembers, "colId", "Miembro Id", "id", false);
			//DataGridUtilities.AddColumn(DataGridMembers, "colCitizenNetworkId", "Estructura Id", "citizennetwork_id", false);
			//DataGridUtilities.AddColumn(DataGridMembers, "colCitizenId", "Ciudadano Id", "citizen_id", false);
			//DataGridUtilities.AddColumn(DataGridMembers, "colRoleId", "Rol Id", "role_id", false);
			//DataGridUtilities.AddColumn(DataGridMembers, "colParentMemberId", "Miembro Padre", "parent_member_id", false);
			//DataGridUtilities.AddColumn(DataGridMembers, "colRoleLevel", "Miembro Padre", "role_level", false);

			int display_index = 0;

			//DataGridUtilities.AddColumn(DataGridMembers, "colCitizenName", "Nombre", "citizen_name", true, display_index++, 100, 100, DataGridViewAutoSizeColumnMode.AllCells);
			//DataGridUtilities.AddColumn(DataGridMembers, "colRoleName", "Rol", "role_name", true, display_index++, 50, 50, DataGridViewAutoSizeColumnMode.Fill);

			//// bind the members datagrid
			//DataGridMembers.DataSource = DSCitizenNetwork;
			//DataGridMembers.DataMember = "DTMembers";

			// create the roles datatable
			DTRoles = new DataTable("DTRoles");

			DataColumn col_roles_id = DTRoles.Columns.Add("id", typeof(int));
			col_roles_id.AutoIncrement = true;
			col_roles_id.AutoIncrementSeed = 1;

			DTRoles.Columns.Add("citizennetwork_id", typeof(int));
			DTRoles.Columns.Add("name", typeof(string));
			DTRoles.Columns.Add("description", typeof(string));
			DTRoles.Columns.Add("level", typeof(int));
			DSCitizenNetwork.Tables.Add(DTRoles);

			// initialize roles datagrid
			DataGridUtilities.AddColumn(DataGridRoles, "colId", "Id", "id", false);
			DataGridUtilities.AddColumn(DataGridRoles, "colCitizenNetworkId", "EstructuraId", "citizennetwork_id", false);

			display_index = 0;

			DataGridUtilities.AddColumn(DataGridRoles, "colName", "Nombre", "name", true, display_index++, 100, 100, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridRoles, "colLevel", "Nivel", "level", true, display_index++, 100, 100, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridRoles, "colDescription", "Descripción", "description", true, display_index++, 100, 100, DataGridViewAutoSizeColumnMode.Fill);

			// bind the roles datagrid
			DataGridRoles.DataSource = DSCitizenNetwork;
			DataGridRoles.DataMember = "DTRoles";

			// member dialog
			MemberDlg = new FCitizenNetworkMemberData(DTRoles);

			// roles dialog
			RoleDlg = new FCitizenNetworkRoleData();

			LoadPermissions();
		}

		private void SetMode(FAccessMode mode)
		{
			Mode = mode;

			TextBoxName.Enabled = Mode != FAccessMode.Read;
			TextBoxDescription.Enabled = Mode != FAccessMode.Read;
			BSelectLeadCitizen.Enabled = Mode != FAccessMode.Read;

			BAddMember.Enabled = Mode != FAccessMode.Read;
			BEditMember.Enabled = Mode != FAccessMode.Read;
			BDeleteMember.Enabled = Mode != FAccessMode.Read;

			BAddRole.Enabled = Mode != FAccessMode.Read;
			BEditRole.Enabled = Mode != FAccessMode.Read;
			BDeleteRole.Enabled = Mode != FAccessMode.Read;
		}

		private void LoadPermissions()
		{
			using (new CursorWait())
			{
				BAddMember.Visible = Session.HasPermission("Network.Members.Crear");
				BEditMember.Visible = Session.HasPermission("Network.Members.Editar");
				BReadMember.Visible = Session.HasPermission("Network.Members.Consultar");
				BDeleteMember.Visible = Session.HasPermission("Network.Members.Eliminar");

				BAddRole.Visible = Session.HasPermission("Network.Roles.Crear");
				BEditMember.Visible = Session.HasPermission("Network.Roles.Editar");
				BReadRole.Visible = Session.HasPermission("Network.Roles.Consultar");
				BDeleteRole.Visible = Session.HasPermission("Network.Roles.Eliminar");
			}
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

				Text = $"Estructura - {network.Name}";

				// fill roles
				DTRoles.BeginLoadData();
				DTRoles.Clear();

				foreach (TCitizenNetworkRole role in network.Roles)
				{
					DataRow row = DTRoles.NewRow();

					int new_role_id = (int)row["id"]; // this value is autogenerated by DataTable column as autoincrement = true

					row["citizennetwork_id"] = role.CitizenNetworkId;
					row["name"] = role.Name;
					row["description"] = role.Description;
					row["level"] = role.Level;

					DTRoles.Rows.Add(row);

					// ugly... asign the correct (generated on frontend) id for the member

					foreach (TCitizenNetworkMember member in network.Members)
					{
						if (member.Role.Id == role.Id)
						{
							member.Role.Id = new_role_id;
						}
					}

					role.Id = new_role_id;
				}

				DTRoles.EndLoadData();

				// fill members

				// uglier... the same drill that in business logic

				// pre-sort the array
				network.Members = network.Members.OrderBy(m => m.ParentMemberId).ToList();

				// save original parent member ids
				List<int> original_parent_member_ids = network.Members.Select(m => m.ParentMemberId).ToList();

				DTMembers.BeginLoadData();
				DTMembers.Clear();

				foreach (TCitizenNetworkMember member in network.Members)
				{
					DataRow row = DTMembers.NewRow();

					//row["id"] = member.Id;
					row["citizennetwork_id"] = member.CitizenNetworkId;
					row["citizen_id"] = member.Citizen.Id;
					row["parent_member_id"] = member.ParentMemberId;
					row["role_id"] = member.Role.Id;
					row["citizen_name"] = member.Citizen.GetFullName();
					row["role_name"] = member.Role.Name;
					row["role_level"] = member.Role.Level;

					DTMembers.Rows.Add(row);

					// the actual fix
					int new_member_id = (int)row["id"];

					// finally the actual fix happens
					for (int i = 0; i < network.Members.Count(); i++)
					{
						TCitizenNetworkMember member_to_fix = network.Members[i];

						if (original_parent_member_ids[i] == member.Id)
						{
							member_to_fix.ParentMemberId = new_member_id;
						}
					}

					member.Id = new_member_id;
				}

				DTMembers.EndLoadData();

				//RefreshMembersStructure();

				// here to pupulate the object list view...
				members_models.Clear();

				foreach (TCitizenNetworkMember member in network.Members)
				{
					OLVM_NetworkMember model = new OLVM_NetworkMember()
					{
						MemberId = member.Id,
						ParentMemberId = member.ParentMemberId,
						Name = member.Citizen.GetFullName(),
						Role = member.Role.Name,
					};

					members_models.Add(model);
				}

				CountMemberChildren();

				// fill the actual control
				{
					//OLVM_NetworkMember root = new OLVM_NetworkMember()
					//{
					//	MemberId = 0,
					//	ParentMemberId = -1,
					//	Name = LeadCitizen.Name,
					//	Role = "Líder"
					//};

					List<OLVM_NetworkMember> roots = new List<OLVM_NetworkMember>();

					foreach (OLVM_NetworkMember member in members_models)
					{
						if (member.ParentMemberId == 0)
						{
							roots.Add(member);
						}
					}

					ObjectListMembers.Roots = roots;

					//foreach (OLVM_NetworkMember member in members_models)
					//{
					//	ObjectListMembers.AddObject(member);
					//	//ObjectListMembers.RefreshObject(member);
					//}

					//foreach (OLVM_NetworkMember member in members_models)
					//{
					//	ObjectListMembers.RefreshObject(member);
					//}

					//ObjectListMembers.RefreshObject(root);
				}

				//ObjectListMembers.SetObjects(members_models);
			}
		}


		private void CountMemberChildren()
		{
			members_childrens_count.Clear();

			foreach (OLVM_NetworkMember member in members_models)
			{
				if (members_childrens_count.Keys.Contains(member.MemberId) == false)
				{
					members_childrens_count[member.MemberId] = 0;
				}

				members_childrens_count[member.MemberId] = members_models.Count(m => m.ParentMemberId == member.MemberId);
			}

			//members_childrens_count[0] = members_models.Count();
		}
		
		private void SetupStyles()
		{
			ObjectListMembers.GridLines = true;
			ObjectListMembers.BorderStyle = BorderStyle.None;
			ObjectListMembers.HeaderUsesThemes = false;
			ObjectListMembers.HeaderMinimumHeight = 1;
			ObjectListMembers.HeaderFormatStyle = new HeaderFormatStyle();
			ObjectListMembers.HeaderFont = new System.Drawing.Font("Segoe UI", 9);
			ObjectListMembers.HeaderMaximumHeight = 16;
			ObjectListMembers.HeaderFormatStyle.SetBackColor(SystemColors.ControlLight);
			ObjectListMembers.HeaderFormatStyle.SetForeColor(SystemColors.WindowText);
			ObjectListMembers.CellVerticalAlignment = StringAlignment.Center;
			//ObjectListMembers.CellPadding = new Rectangle(2, 4, 2, 2);
			ObjectListMembers.RowHeight = 16;
			ObjectListMembers.UseCustomSelectionColors = true;
			ObjectListMembers.UseAlternatingBackColors = false;
			ObjectListMembers.ForeColor = SystemColors.WindowText;
			ObjectListMembers.BackColor = SystemColors.Window;
			ObjectListMembers.AlternateRowBackColor = System.Drawing.Color.WhiteSmoke;
			ObjectListMembers.SelectedBackColor = SystemColors.GradientInactiveCaption;
			ObjectListMembers.UnfocusedSelectedBackColor = SystemColors.GradientInactiveCaption;
			ObjectListMembers.SelectedForeColor = SystemColors.WindowText;
			ObjectListMembers.AllowColumnReorder = true;
		}

		private void SetupColumns()
		{
			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("Rol", "Role")
			{
				Width = 100,
			});

			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("Nombre", "Name")
			{
				FillsFreeSpace = true,
				UseFiltering = true,
			});


			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("Descripción", "RoleDescription")
			{
				Width = 120,
				IsVisible = false,
			});

			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("Clave Elector", "ElectorCode")
			{
				Width = 120,
			});

			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("OCR", "OCR")
			{
				Width = 120,
			});

			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("Sección", "Section")
			{
				Width = 120,
			});


			ObjectListMembers.RebuildColumns();
		}

		private void SetupTree()
		{
			ObjectListMembers.CanExpandGetter = delegate (object obj)
			{
				OLVM_NetworkMember member = obj as OLVM_NetworkMember;

				if (member == null)
					return false;

				if (members_childrens_count.ContainsKey(member.MemberId))
				{
					if (members_childrens_count[member.MemberId] > 0)
						return true;
				}

				return false;
			};

			ObjectListMembers.ChildrenGetter = delegate (object obj)
			{
				OLVM_NetworkMember member = (OLVM_NetworkMember)obj;

				List<OLVM_NetworkMember> children = new List<OLVM_NetworkMember>();

				if (member != null)
				{
					foreach (OLVM_NetworkMember child in members_models)
					{
						if (child.ParentMemberId == member.MemberId)
						{
							children.Add(child);
						}
					}
				}

				return children;
			};
		}

		/*
		private void RefreshMembersStructure()
		{
			using (new CursorWait())
			{
				TreeViewMembers.BeginUpdate();
				TreeViewMembers.Nodes.Clear();

				// first node of the tree is the lead
				TreeNode root_node = new TreeNode(LeadCitizen.GetFullName());

				TreeViewMembers.Nodes.Add(root_node);

				// second level are all children of this
				foreach (DataRow row in DTMembers.Rows)
				{
					if ((int)row["parent_member_id"] == 0)
					{
						TreeNode child_node = new TreeNode($"{(string)row["citizen_name"]} - {(string)row["role_name"]}");

						child_node.Tag = new TCitizenNetworkMember()
						{
							Id = (int)row["id"],
							ParentMemberId = (int)row["parent_member_id"],
							Role = new TCitizenNetworkRole()
							{
								Id = (int)row["role_id"],
								Name = (string)row["role_name"],
								Level = (int)row["role_level"]
							}
						};

						root_node.Nodes.Add(child_node);

						// then all others members
						PopulateTreeNode(ref child_node, ((TCitizenNetworkMember)child_node.Tag).Id);
					}
				}

				TreeViewMembers.EndUpdate();

				//TreeViewMembers.ExpandAll();
				TreeViewUtilities.ExpandToLevel(TreeViewMembers.Nodes, citizen_structure_expand_level);
			}
		}
		*/

		public void PopulateTreeNode(ref TreeNode node, int id)
		{
			foreach (DataRow row in DTMembers.Rows)
			{
				if ((int)row["parent_member_id"] == id)
				{
					TreeNode child_node = new TreeNode($"{(string)row["citizen_name"]} - {(string)row["role_name"]}");

					child_node.Tag = new TCitizenNetworkMember()
					{
						Id = (int)row["id"],
						ParentMemberId = (int)row["parent_member_id"],
						Role = new TCitizenNetworkRole()
						{
							Id = (int)row["role_id"],
							Name = (string)row["role_name"],
							Level = (int)row["role_level"]
						}
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
				network.Id = Id;
				network.Name = TextBoxName.Text.Trim();
				network.Description = TextBoxDescription.Text.Trim();
				network.LeadCitizen.Id = LeadCitizen.Id;

				// roles
				foreach (DataRow row in DTRoles.Rows)
				{
					TCitizenNetworkRole role = new TCitizenNetworkRole();

					role.Id = (int)row["id"];
					role.CitizenNetworkId = Id;
					role.Name = (string)row["name"];
					role.Description = (string)row["description"];
					role.Level = (int)row["level"];

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
					member.Role.Id = (int)row["role_id"];

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

		private void BAddRole_Click(object sender, EventArgs e)
		{
			TCitizenNetworkRole new_role = new TCitizenNetworkRole()
			{
				Id = 0,
				CitizenNetworkId = Id,
				Name = "",
			};

			RoleDlg.SetMode(FAccessMode.Create);
			RoleDlg.SetRole(new_role);

			if (RoleDlg.ShowDialog() == DialogResult.OK)
			{
				new_role = RoleDlg.GetRole();

				DTRoles.BeginLoadData();

				DataRow row = DTRoles.NewRow();

				//row["id"] = new_role.Id;
				row["citizennetwork_id"] = new_role.CitizenNetworkId;
				row["name"] = new_role.Name;
				row["description"] = new_role.Description;
				row["level"] = new_role.Level;

				DTRoles.Rows.Add(row);

				DTRoles.EndLoadData();
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

			RoleDlg.SetMode(FAccessMode.Update);
			RoleDlg.SetRole(role);

			if (RoleDlg.ShowDialog() == DialogResult.OK)
			{
				DataRow row = DTRoles.Rows[row_index];

				role = RoleDlg.GetRole();

				row.BeginEdit();

				row["id"] = role.Id;
				row["citizennetwork_id"] = Id;
				row["name"] = role.Name;
				row["description"] = role.Description;
				row["level"] = role.Level;

				row.EndEdit();
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

			RoleDlg.SetMode(FAccessMode.Read);
			RoleDlg.SetRole(role);
			RoleDlg.ShowDialog();
		}

		private void BDeleteRole_Click(object sender, EventArgs e)
		{
			int role_index;

			TCitizenNetworkRole role = GetSelectedRole(out role_index);

			if (role == null)
			{
				return;
			}

			if (Utilities.ShowDeleteConfirmDialog("¿Desea eliminar el rol de la estructura?") != DialogResult.Yes)
			{
				return;
			}

			// check the role isn't being used by no network member
			foreach (DataRow row in DTMembers.Rows)
			{
				if ((int)row["role_id"] == role.Id)
				{
					Utilities.ShowErrorDialog(Error.CitizenNetworkRoleInUse);
					return;
				}
			}

			DTRoles.Rows.RemoveAt(role_index);
		}
		
		private TCitizenNetworkMember GetSelectedMember(out int row_index)
		{
			row_index = 0;

			//if (DataGridMembers.SelectedRows.Count == 0)
			//{
			//	return null;
			//}

			//DataGridViewRow row = DataGridMembers.SelectedRows[0];

			//row_index = row.Index;

			//TCitizenNetworkMember member = new TCitizenNetworkMember()
			//{
			//	Id = (int)row.Cells["colId"].Value,
			//	CitizenNetworkId = Id,
			//	ParentMemberId = (int)row.Cells["colParentMemberId"].Value,

			//	Citizen = new TCitizen()
			//	{
			//		Id = (int)row.Cells["colCitizenId"].Value,
			//		Name = (string)row.Cells["colCitizenName"].Value,
			//	},

			//	Role = new TCitizenNetworkRole()
			//	{
			//		Id = (int)row.Cells["colRoleId"].Value,
			//		Name = (string)row.Cells["colRoleName"].Value
			//	}
			//};

			//return member;
			return null;
		}

		private TCitizenNetworkMember GetSelectedMemberParent()
		{
			//if (TreeViewMembers.Parent == null)
			//	return new TCitizenNetworkMember();

			//if (DataGridMembers.Parent.Tag == null)
			//	return new TCitizenNetworkMember();

			//TCitizenNetworkMember parent_member = DataGridMembers.Parent.Tag as TCitizenNetworkMember;

			//if (parent_member == null)
			//	return new TCitizenNetworkMember();

			//return parent_member;
			return null;
		}

		private void BSelectLeadCitizen_Click(object sender, EventArgs e)
		{
			using (FCitizenList citizen_list = new FCitizenList())
			{
				citizen_list.SetMode(FAccessMode.Select);

				if (citizen_list.ShowDialog() == DialogResult.OK)
				{
					LeadCitizen = citizen_list.GetSelectedCitizen();

					TextBoxLeadCitizen.Text = $"{LeadCitizen.Name} {LeadCitizen.PaternalName} {LeadCitizen.MaternalName}";

					LLeadCitizenInfo.Text = $"Tel. {LeadCitizen.Phone}";
					if (LeadCitizen.PhoneExtension != "")
					{
						LLeadCitizenInfo.Text += $" Ext. {LeadCitizen.PhoneExtension}";
					}

					LLeadCitizenInfo.Text += $" Cel. {LeadCitizen.Cellphone}";

					//RefreshMembersStructure();
				}
			}
		}

		private void BAddMember_Click(object sender, EventArgs e)
		{
			int row_index;

			TCitizenNetworkMember selected_member = GetSelectedMember(out row_index);

			if (selected_member == null)
			{
				selected_member = new TCitizenNetworkMember();
			}

			TCitizenNetworkMember member = new TCitizenNetworkMember();

			member.ParentMemberId = selected_member.Id;

			MemberDlg.SetMode(FAccessMode.Create);
			MemberDlg.SetMember(member, selected_member);

			if (MemberDlg.ShowDialog() == DialogResult.OK)
			{
				member = MemberDlg.GetMember();

				DTMembers.BeginLoadData();

				DataRow row = DTMembers.NewRow();

				row["citizennetwork_id"] = Id;
				row["parent_member_id"] = selected_member.Id;
				row["citizen_id"] = member.Citizen.Id;
				row["citizen_name"] = member.Citizen.GetFullName();
				row["role_id"] = member.Role.Id;
				row["role_name"] = member.Role.Name;
				row["role_level"] = member.Role.Level;

				DTMembers.Rows.Add(row);

				DTMembers.EndLoadData();

				//RefreshMembersStructure();
			}
		}

		private void BEditMember_Click(object sender, EventArgs e)
		{
			int selected_index;

			TCitizenNetworkMember member = GetSelectedMember(out selected_index);
			TCitizenNetworkMember parent_member = GetSelectedMemberParent();

			if (member == null)
			{
				return;
			}

			MemberDlg.SetMode(FAccessMode.Update);
			MemberDlg.SetMember(member, parent_member);

			if (MemberDlg.ShowDialog() == DialogResult.OK)
			{
				member = MemberDlg.GetMember();

				DataRow row = DTMembers.Rows[selected_index];

				row.BeginEdit();

				row["id"] = member.Id;
				row["citizennetwork_id"] = Id;
				row["parent_member_id"] = member.ParentMemberId;
				row["citizen_id"] = member.Citizen.Id;
				row["citizen_name"] = member.Citizen.Name;
				row["role_id"] = member.Role.Id;
				row["role_name"] = member.Role.Name;
				row["role_level"] = member.Role.Level;

				row.EndEdit();

				//RefreshMembersStructure();
			}
		}

		private void BReadMember_Click(object sender, EventArgs e)
		{
			int selected_index;

			TCitizenNetworkMember member = GetSelectedMember(out selected_index);
			TCitizenNetworkMember parent_member = GetSelectedMemberParent();

			if (member == null)
			{
				return;
			}

			MemberDlg.SetMode(FAccessMode.Read);
			MemberDlg.SetMember(member, parent_member);
			MemberDlg.ShowDialog();
		}

		private void BDeleteMember_Click(object sender, EventArgs e)
		{
			int member_index;

			TCitizenNetworkMember member = GetSelectedMember(out member_index);

			if (member == null)
			{
				return;
			}

			if (Utilities.ShowDeleteConfirmDialog("¿Desea eliminar el miembro de la estructura?") != DialogResult.Yes)
			{
				return;
			}

			// check the member doesn't have child members
			foreach (DataRow row in DTMembers.Rows)
			{
				if ((int)row["parent_member_id"] == member.Id)
				{
					Utilities.ShowErrorDialog(Error.CitizenNetworkMemberInUse);
					return;
				}
			}

			DTMembers.Rows.RemoveAt(member_index);

			//RefreshMembersStructure();
		}

		private void BPrint1x10_Click(object sender, EventArgs e)
		{
			// TODO: implement the 1x10 report
		}

		private void BExpandLevel_Click(object sender, EventArgs e)
		{

		}

		private void BContractLevel_Click(object sender, EventArgs e)
		{

		}

		private void ObjectListMembers_SelectedIndexChanged(object sender, EventArgs e)
		{

		}
	}
}
