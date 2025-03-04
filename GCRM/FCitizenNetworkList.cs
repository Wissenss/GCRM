using Business;
using QuestPDF.Fluent;
using Reporter;
using System.Data;

namespace GCRM
{
	public partial class FCitizenNetworkList : Form
	{
		DataSet DSCitizenNetworks;
		DataTable DTCitizenNetworks;

		FAccessMode Modo;

		public FCitizenNetworkList()
		{
			InitializeComponent();

			// create datasource
			DSCitizenNetworks = new DataSet("DSCitizenNetworks");

			DTCitizenNetworks = new DataTable("DTCitizenNetworks");
			DTCitizenNetworks.Columns.Add("id", typeof(int));
			DTCitizenNetworks.Columns.Add("lead_citizen_id", typeof(int));
			DTCitizenNetworks.Columns.Add("parent_network_id", typeof(int));
			DTCitizenNetworks.Columns.Add("name", typeof(string));
			DTCitizenNetworks.Columns.Add("description", typeof(string));
			DSCitizenNetworks.Tables.Add(DTCitizenNetworks);

			// initialize citizen networks data grid
			DataGridCitizenNetworks.AutoGenerateColumns = false;

			DataGridUtilities.AddColumn(DataGridCitizenNetworks, "colId", "Id", "id", false);
			DataGridUtilities.AddColumn(DataGridCitizenNetworks, "colLeadCitizenId", "Ciudadano Lider Id", "lead_citizen_id", false);
			DataGridUtilities.AddColumn(DataGridCitizenNetworks, "colParentNetworkId", "Estructura ciudadana padre", "parent_network_id", false);

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridCitizenNetworks, "colName", "Estructura", "name", true, display_index++, 100, 100, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridCitizenNetworks, "colDescription", "Descripción", "description", true, display_index++, 100, 100, DataGridViewAutoSizeColumnMode.Fill);

			// bind the grid with the datasource
			DataGridCitizenNetworks.DataSource = DSCitizenNetworks;
			DataGridCitizenNetworks.DataMember = "DTCitizenNetworks";

			// hide structure
			BShowStructure.Checked = false;
			BShowStructure_Click(this, null);

			LoadPermissions();
		}

		private void LoadPermissions()
		{
			using (new CursorWait())
			{
				BAdd.Visible = Session.HasPermission("Network.Crear");
				BEdit.Visible = Session.HasPermission("Network.Editar");
				BRead.Visible = Session.HasPermission("Network.Consultar");
				BDelete.Visible = Session.HasPermission("Network.Eliminar");
			}
		}

		private void LoadList()
		{
			using (new CursorWait())
			{
				List<TCitizenNetwork> citizen_network_list;

				Error error = CitizenNetworksHandler.GetCitizenNetworks(out citizen_network_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTCitizenNetworks.BeginLoadData();
				DTCitizenNetworks.Clear();

				foreach (TCitizenNetwork network in citizen_network_list)
				{
					DataRow row = DTCitizenNetworks.NewRow();

					row["id"] = network.Id;
					row["lead_citizen_id"] = network.LeadCitizen.Id;
					row["parent_network_id"] = network.ParentNetworkId;
					row["name"] = network.Name;
					row["description"] = network.Description;

					DTCitizenNetworks.Rows.Add(row);
				}

				DTCitizenNetworks.EndLoadData();

				// populate treeview
				TreeViewNetwroksStructure.BeginUpdate();
				TreeViewNetwroksStructure.Nodes.Clear();

				foreach (DataRow row in DTCitizenNetworks.Rows)
				{
					if ((int)row["parent_network_id"] == 0)
					{
						TreeNode head_node = new TreeNode((string)row["name"]);

						TreeViewNetwroksStructure.Nodes.Add(head_node);

						PopulateTreeNode(ref head_node, (int)row["id"]);
					}
				}

				TreeViewNetwroksStructure.EndUpdate();
				TreeViewNetwroksStructure.ExpandAll();

				TSSLRecordCount.Text = $"Registros: {DTCitizenNetworks.Rows.Count}";
			}
		}

		public void PopulateTreeNode(ref TreeNode node, int id)
		{
			foreach (DataRow row in DTCitizenNetworks.Rows)
			{
				if ((int)row["parent_network_id"] == id)
				{
					TreeNode child_node = new TreeNode((string)row["name"]);

					node.Nodes.Add(child_node);

					PopulateTreeNode(ref child_node, (int)row["id"]);
				}
			}
		}

		private void FCitizenNetworkList_Load(object sender, EventArgs e)
		{
			LoadList();
		}

		private int GetSelectedCitizenNetworkId()
		{
			if (DataGridCitizenNetworks.SelectedRows.Count == 0)
			{
				return 0;
			}

			DataGridViewRow row = DataGridCitizenNetworks.SelectedRows[0];

			int id = (int)row.Cells["colId"].Value;

			return id;
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			using (FCitizenNetworkData citizen_network_dlg = new FCitizenNetworkData())
			{
				if (citizen_network_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			int id = GetSelectedCitizenNetworkId();

			if (id == 0)
			{
				return;
			}

			using (FCitizenNetworkData citizen_network_dlg = new FCitizenNetworkData())
			{
				citizen_network_dlg.SetAccessMode(FAccessMode.Update);
				citizen_network_dlg.SetId(id);

				if (citizen_network_dlg.ShowDialog() == DialogResult.OK)
				{
					LoadList();
				}
			}
		}

		private void BPrint_Click(object sender, EventArgs e)
		{
			int id = GetSelectedCitizenNetworkId();

			if (id == 0)
				return;

			TCitizenNetwork network;

			Error error = CitizenNetworksHandler.GetCitizenNetworkById(id, out network);

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			R002DocumentModel model = new R002DocumentModel();

			model.Network = network;

			R002Document document = new R002Document(model);

			document.GeneratePdfAndShow();
		}

		private void BShowStructure_Click(object sender, EventArgs e)
		{
			if (BShowStructure.Checked)
			{
				splitContainer1.Panel2.Show();
				splitContainer1.Panel2Collapsed = false;
			}
			else
			{
				splitContainer1.Panel2Collapsed = true;
				splitContainer1.Panel2.Hide();
			}
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private void TreeViewNetwroksStructure_DrawNode(object sender, DrawTreeNodeEventArgs e)
		{
			System.Drawing.Color background_color = SystemColors.Control;
			System.Drawing.Color foreground_color = SystemColors.WindowText;

			System.Drawing.Font font = e.Node.NodeFont ?? e.Node.TreeView.Font;

			if (e.Node == e.Node.TreeView.SelectedNode)
			{
				background_color = SystemColors.GradientInactiveCaption;
			}

			SolidBrush brush = new SolidBrush(background_color);

			e.Graphics.FillRectangle(brush, e.Bounds.X, e.Bounds.Y, TreeViewNetwroksStructure.Width - (e.Bounds.X - TreeViewNetwroksStructure.Location.X), e.Bounds.Height);
			TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, foreground_color, TextFormatFlags.GlyphOverhangPadding);
		}
	}
}
