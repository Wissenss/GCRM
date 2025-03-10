using BrightIdeasSoftware;
using Business;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Presentation;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Extensions.Logging.Abstractions;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using Reporter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Interop;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace GCRM
{
	public partial class FCitizenNetworkData : Form
	{
		private List<TCitizenNetworkMember> Members = new List<TCitizenNetworkMember>();
		private Dictionary<int, int> MembersChildrensCount = new Dictionary<int, int>();

		DataSet DSCitizenNetwork;
		DataTable DTRoles;

		FAccessMode Mode;
		int Id;
		TCitizen LeadCitizen;

		FCitizenNetworkMemberData MemberDlg;
		FCitizenNetworkRoleData RoleDlg;

		int member_autoinc = 1;
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
			SetupDragAndDrop();
			SetupStyles();
			SetupTree();

			// create the datasource
			DSCitizenNetwork = new DataSet("DSCitizenNetwork");

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

			int display_index = 0;

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

		private void LoadPermissions()
		{
			using (new CursorWait())
			{
				BAddRoot.Visible = Session.HasPermission("Network.Members.Crear");
				BAddMember.Visible = Session.HasPermission("Network.Members.Crear");
				BEditMember.Visible = Session.HasPermission("Network.Members.Editar");
				BReadMember.Visible = Session.HasPermission("Network.Members.Consultar");
				BDeleteMember.Visible = Session.HasPermission("Network.Members.Eliminar");

				BAddRole.Visible = Session.HasPermission("Network.Roles.Crear");
				BEditRole.Visible = Session.HasPermission("Network.Roles.Editar");
				BReadRole.Visible = Session.HasPermission("Network.Roles.Consultar");
				BDeleteRole.Visible = Session.HasPermission("Network.Roles.Eliminar");
			}
		}

		public void SetAccessMode(FAccessMode mode)
		{
			Mode = mode;

			TextBoxName.Enabled = Mode != FAccessMode.Read;
			TextBoxDescription.Enabled = Mode != FAccessMode.Read;
			BSelectLeadCitizen.Enabled = Mode != FAccessMode.Read;

			BAddRoot.Enabled = Mode != FAccessMode.Read;
			BAddMember.Enabled = Mode != FAccessMode.Read;
			BEditMember.Enabled = Mode != FAccessMode.Read;
			BDeleteMember.Enabled = Mode != FAccessMode.Read;

			BAddRole.Enabled = Mode != FAccessMode.Read;
			BEditRole.Enabled = Mode != FAccessMode.Read;
			BDeleteRole.Enabled = Mode != FAccessMode.Read;
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

				// save original member member ids
				List<int> original_parent_member_ids = network.Members.Select(m => m.ParentMemberId).ToList();

				foreach (TCitizenNetworkMember member in network.Members)
				{
					int new_member_id = member_autoinc++;

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

				// Pupulate the members object list view...
				Members.Clear();
				Members.AddRange(network.Members);
				PopulateObjectListMembers();
			}
		}

		private void PopulateObjectListMembers()
		{
			CountMemberChildren();

			List<TCitizenNetworkMember> roots = new List<TCitizenNetworkMember>();

			foreach (TCitizenNetworkMember member in Members)
			{
				if (member.ParentMemberId == 0)
				{
					roots.Add(member);
				}
			}

			ObjectListMembers.Roots = roots;
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
				network.Members.AddRange(Members);

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

		#region Roles

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
				Level = (int)row.Cells["colLevel"].Value,
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
			//foreach (DataRow row in DTMembers.Rows)
			//{
			//	if ((int)row["role_id"] == role.Id)
			//	{
			//		Utilities.ShowErrorDialog(Error.CitizenNetworkRoleInUse);
			//		return;
			//	}
			//}

			DTRoles.Rows.RemoveAt(role_index);
		}

		#endregion

		#region Members

		// object tree view control
		// ------------------------------------------------
		private void CountMemberChildren()
		{
			MembersChildrensCount.Clear();

			foreach (TCitizenNetworkMember member in Members)
			{
				if (MembersChildrensCount.Keys.Contains(member.Id) == false)
				{
					MembersChildrensCount[member.Id] = 0;
				}

				MembersChildrensCount[member.Id] = Members.Count(m => m.ParentMemberId == member.Id);
			}
		}

		private void SetupStyles()
		{
			ObjectListMembers.GridLines = true;
			ObjectListMembers.BorderStyle = BorderStyle.None;
			ObjectListMembers.HeaderUsesThemes = false;
			ObjectListMembers.HeaderMinimumHeight = 1;
			ObjectListMembers.HeaderFormatStyle = new HeaderFormatStyle();
			ObjectListMembers.HeaderMaximumHeight = 16;
			ObjectListMembers.HeaderFormatStyle.SetBackColor(SystemColors.ControlLight);
			ObjectListMembers.HeaderFormatStyle.SetForeColor(SystemColors.WindowText);
			ObjectListMembers.HeaderFormatStyle.SetFont(new System.Drawing.Font("Segoe UI", 9));
			ObjectListMembers.CellVerticalAlignment = StringAlignment.Center;
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
			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("Rol", "Role.Name")
			{
				Width = 150,
			});

			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("Nombre", "Citizen.FullName")
			{
				FillsFreeSpace = true,
				UseFiltering = true,
			});

			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("Descripción", "Role.Description")
			{
				Width = 120,
				IsVisible = false,
			});

			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("Clave Elector", "Citizen.VoterCode")
			{
				Width = 120,
			});

			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("OCR", "Citizen.VoterOCR")
			{
				Width = 120,
			});

			ObjectListMembers.AllColumns.Add(new BrightIdeasSoftware.OLVColumn("Sección", "Citizen.VoterSection")
			{
				Width = 120,
			});

			ObjectListMembers.RebuildColumns();
		}

		private void SetupDragAndDrop()
		{
			ObjectListMembers.AllowDrop = true;
			ObjectListMembers.IsSimpleDragSource = true;
			ObjectListMembers.IsSimpleDropSink = true;

			SimpleDropSink drop_sink = new SimpleDropSink()
			{
				CanDropOnSubItem = true,
				FeedbackColor = SystemColors.GradientInactiveCaption,
			};

			drop_sink.FeedbackColor = SystemColors.GradientInactiveCaption;

			drop_sink.Billboard.BackColor = SystemColors.Info;

			ObjectListMembers.DropSink = drop_sink;

			ObjectListMembers.Refresh();

			ObjectListMembers.ModelCanDrop += delegate (object sender, ModelDropEventArgs e)
			{
				e.Effect = DragDropEffects.None;

				if (Session.HasPermission("Network.Members.Hierarchy.Editar") == false)
				{
					e.InfoMessage = "El usuario no cuenta con permisos para realizar esta acción.";
					return;
				}

				if (e.TargetModel == null)
					return;

				TCitizenNetworkMember target_member = e.TargetModel as TCitizenNetworkMember;

				if (target_member == null)
				{
					return;
				}

				foreach (object source in e.SourceModels)
				{
					if (target_member == source)
						return;

					TCitizenNetworkMember source_member = source as TCitizenNetworkMember;

					if (source_member != null)
					{
						if (source_member.Role.Level <= target_member.Role.Level)
						{
							e.InfoMessage = $"Un miembro con rol {source_member.Role.Name} no puede estar debajo de otro con rol {target_member.Role.Name}";
							return;
						}
					}
				}

				e.Effect = DragDropEffects.All;
			};

			ObjectListMembers.ModelDropped += delegate (object sender, ModelDropEventArgs e)
			{
				TCitizenNetworkMember target_member = e.TargetModel as TCitizenNetworkMember;

				if (e.TargetModel == null)
					return;

				foreach (object model in e.SourceModels)
				{
					TCitizenNetworkMember source = model as TCitizenNetworkMember;

					if (source == null)
						continue;

					source.ParentMemberId = target_member.Id;
				}

				PopulateObjectListMembers();

				ObjectListMembers.Expand(target_member);

				ObjectListMembers.SelectObjects(e.SourceModels);
			};
		}

		private bool MembersCanExpandGetter(object obj)
		{
			TCitizenNetworkMember member = obj as TCitizenNetworkMember;

			if (member == null)
				return false;

			if (MembersChildrensCount.ContainsKey(member.Id))
			{
				if (MembersChildrensCount[member.Id] > 0)
					return true;
			}

			return false;
		}

		private List<TCitizenNetworkMember> MembersChildrenGetter(object obj)
		{
			TCitizenNetworkMember member = (TCitizenNetworkMember)obj;

			List<TCitizenNetworkMember> children = new List<TCitizenNetworkMember>();

			if (member != null)
			{
				foreach (TCitizenNetworkMember child in Members)
				{
					if (child.ParentMemberId == member.Id)
					{
						children.Add(child);
					}
				}
			}

			return children;
		}

		private void SetupTree()
		{
			ObjectListMembers.CanExpandGetter = delegate (object obj)
			{
				return MembersCanExpandGetter(obj);
			};

			ObjectListMembers.ChildrenGetter = delegate (object obj)
			{
				return MembersChildrenGetter(obj);
			};
		}

		// ------------------------------------------------

		private TCitizenNetworkMember GetSelectedMember()
		{
			TCitizenNetworkMember member = ObjectListMembers.SelectedObject as TCitizenNetworkMember;

			if (member == null)
			{
				return null;
			}

			return member;
		}

		private TCitizenNetworkMember GetSelectedMemberParent()
		{
			TCitizenNetworkMember member = ObjectListMembers.SelectedObject as TCitizenNetworkMember;

			if (member == null)
			{
				return null;
			}

			if (member.ParentMemberId == 0)
			{
				return null;
			}

			foreach (TCitizenNetworkMember parent in Members)
			{
				if (member.ParentMemberId == parent.Id)
				{
					return parent;
				}
			}

			return null;
		}

		private TCitizenNetworkMember GetMemberById(int member_id)
		{
			TCitizenNetworkMember member = null;

			foreach (TCitizenNetworkMember m in Members)
			{
				if (m.Id == member_id)
				{
					member = m;
					break;
				}
			}

			return member;
		}

		private TCitizenNetworkMember GetMemberParentMember(int member_id)
		{
			TCitizenNetworkMember member = GetMemberById(member_id);

			foreach (TCitizenNetworkMember parent in Members)
			{
				if (member.ParentMemberId == parent.Id)
				{
					return parent;
				}
			}

			return null;
		}

		private TCitizenNetworkMember GetMemberRootMember(int member_id)
		{
			TCitizenNetworkMember member = GetMemberById(member_id);

			if (member == null)
				throw new Exception("no member with the given Id!");

			while (member.ParentMemberId != 0)
			{
				member = GetMemberById(member.ParentMemberId);
			}

			return member;
		}

		private void BPrint1x10_Click(object sender, EventArgs e)
		{
			TCitizenNetworkMember selected_member = GetSelectedMember();

			if (selected_member == null)
			{
				Utilities.ShowValidationErrorDialog("Debe seleccionar un miembro.");
				return;
			}

			TCitizenNetworkMember lead_member = GetMemberRootMember(selected_member.Id);

			R002DocumentModel model = new R002DocumentModel()
			{
				Network = new TCitizenNetwork()
				{
					Name = TextBoxName.Text.Trim(),
					Description = TextBoxDescription.Text.Trim(),
				},
				LeadMember = lead_member,
				ReferentMember = selected_member,
				Members = MembersChildrenGetter(selected_member)
			};

			IDocument document = new R002Document(model);

			document.GeneratePdfAndShow();
		}

		private void BAddRoot_Click(object sender, EventArgs e)
		{
			TCitizenNetworkMember member = new TCitizenNetworkMember();

			int role_id = 0;
			int min_level = 10 * 10 * 10 * 10;

			foreach (DataRow row in DTRoles.Rows)
			{
				if ((int)row["level"] < min_level)
				{
					role_id = (int)row["id"];
				}
			}

			member.Role.Id = role_id;

			MemberDlg.SetMode(FAccessMode.Create);
			MemberDlg.SetMember(member, new TCitizenNetworkMember());

			if (MemberDlg.ShowDialog() == DialogResult.OK)
			{
				member = MemberDlg.GetMember();

				member.Id = member_autoinc++;

				Members.Add(member);

				PopulateObjectListMembers();
			}
		}

		private void BAddMember_Click(object sender, EventArgs e)
		{
			TCitizenNetworkMember selected_member = GetSelectedMember();

			if (selected_member == null)
			{
				Utilities.ShowValidationErrorDialog("Debe seleccionar un miembro padre.");
				return;
			}

			TCitizenNetworkMember member = new TCitizenNetworkMember();

			member.ParentMemberId = selected_member.Id;

			MemberDlg.SetMode(FAccessMode.Create);
			MemberDlg.SetMember(member, selected_member);

			if (MemberDlg.ShowDialog() == DialogResult.OK)
			{
				member = MemberDlg.GetMember();

				member.Id = member_autoinc++;

				Members.Add(member);

				PopulateObjectListMembers();

				ObjectListMembers.Expand(selected_member);
			}
		}

		private void BEditMember_Click(object sender, EventArgs e)
		{
			// TODO
		}

		private void BReadMember_Click(object sender, EventArgs e)
		{
			// TODO
		}

		private void BDeleteMember_Click(object sender, EventArgs e)
		{
			TCitizenNetworkMember member = GetSelectedMember();

			if (member == null)
			{
				Utilities.ShowValidationErrorDialog("Debe seleccionar un miembro.");
				return;
			}

			if (Utilities.ShowDeleteConfirmDialog("¿Desea eliminar el miembro de la estructura?") != DialogResult.Yes)
			{
				return;
			}

			if (MembersChildrensCount.ContainsKey(member.Id))
			{
				if (MembersChildrensCount[member.Id] > 0)
				{
					Utilities.ShowValidationErrorDialog("No se puede eliminar un miembro que cuenta con otros realacionados.");
					return;
				}
			}

			Members.Remove(member);
			PopulateObjectListMembers();
		}

		private void BExpandLevel_Click(object sender, EventArgs e)
		{
			ObjectListMembers.ExpandAll();
		}

		private void BContractLevel_Click(object sender, EventArgs e)
		{
			ObjectListMembers.CollapseAll();
		}

		#endregion
	}
}
