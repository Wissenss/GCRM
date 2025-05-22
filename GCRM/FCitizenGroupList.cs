using GCRM.Application;
using GCRM.Domain;
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
	public partial class FCitizenGroupList : Form
	{
		DataSet DSGroups;
		DataTable DTGroups;

		CitizenGroupService CitizenGroupService;

		FCitizenGroupData CitizenGroupDataDlg;

		public FCitizenGroupList()
		{
			InitializeComponent();

			CitizenGroupService = new CitizenGroupService();

			// create data source, data table
			DSGroups = new DataSet();

			DTGroups = new DataTable("DTGroups");
			DTGroups.Columns.Add("id", typeof(int));
			DTGroups.Columns.Add("name", typeof(string));
			DTGroups.Columns.Add("description", typeof(string));
			DSGroups.Tables.Add(DTGroups);

			// configure grid
			int displayIndex = 0;

			DataGridGroups.AutoGenerateColumns = false;

			DataGridUtilities.AddColumn(DataGridGroups, "colName", "Grupo", "name", true, displayIndex++);
			DataGridUtilities.AddColumn(DataGridGroups, "colDescription", "Descripción", "description", true, displayIndex++);
			DataGridUtilities.AddColumn(DataGridGroups, "colId", "Id", "id", false, displayIndex++);

			DataGridGroups.DataSource = DSGroups;
			DataGridGroups.DataMember = DTGroups.TableName;

			CitizenGroupDataDlg = new FCitizenGroupData();
		}

		public void LoadList()
		{
			using (new CursorWait())
			{
				List<TCitizenGroup> allGroups = CitizenGroupService.GetAllGroups();

				DTGroups.BeginLoadData();
				DTGroups.Clear();

				foreach (TCitizenGroup group in allGroups)
				{
					DataRow row = DTGroups.NewRow();

					row["id"] = group.Id;
					row["name"] = group.Name;
					row["description"] = group.Description;

					DTGroups.Rows.Add(row);
				}

				DTGroups.EndLoadData();

				DataGridGroups.Refresh();
			}

			UpdateStatusStrip();
		}

		private void UpdateStatusStrip()
		{
			TSSLRecordCount.Text = $"Total: {DTGroups.Rows.Count}";
		}

		private void BAdd_Click(object sender, EventArgs e)
		{
			CitizenGroupDataDlg.Clear();

			if (CitizenGroupDataDlg.ShowDialog() == DialogResult.OK)
			{
				LoadList();
			}
		}

		private void BEdit_Click(object sender, EventArgs e)
		{
			using (FCitizenGroupData dlg = new FCitizenGroupData())
			{

			}
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

	}
}
