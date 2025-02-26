using Business;
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

				TSSLRecordCount.Text = $"Registros: {DTCitizenNetworks.Rows.Count}";
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
	}
}
