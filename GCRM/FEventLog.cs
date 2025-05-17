using Business;
using System.Data;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
	public partial class FEventLog : Form
	{
		DataSet DSLogs;
		DataTable DTLogs;

		FEventLogFilters filters_dlg;

		public FEventLog()
		{
			InitializeComponent();

			filters_dlg = new FEventLogFilters();

			int display_index = 0;

			DSLogs = new DataSet();

			DTLogs = new DataTable();

			DTLogs = new DataTable("DTLogs");
			DTLogs.Columns.Add("id", typeof(int));
			DTLogs.Columns.Add("date", typeof(DateTime));
			DTLogs.Columns.Add("message", typeof(string));
			DTLogs.Columns.Add("user_id", typeof(int));
			DTLogs.Columns.Add("user_name", typeof(string));
			DTLogs.Columns.Add("primary_entity_id", typeof(int));
			DTLogs.Columns.Add("primary_entity_type", typeof(TEntityType));
			DTLogs.Columns.Add("type", typeof(TEventLogType));
			DTLogs.Columns.Add("type_name", typeof(string));

			DSLogs.Tables.Add(DTLogs);

			DataGridLogs.AutoGenerateColumns = false;

			DataGridUtilities.AddColumn(DataGridLogs, "colUserId", "Id Usuario", "user_id", false, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridLogs, "colType", "Id Tipo", "type", false, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridLogs, "colMessage", "Mensaje", "message", false, display_index++, 200, 150, DataGridViewAutoSizeColumnMode.Fill);

			DataGridUtilities.AddColumn(DataGridLogs, "colId", "Id", "id", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridLogs, "colDate", "Fecha", "date", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridLogs, "colTypeName", "Evento", "type_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridLogs, "colUserName", "Autor", "user_name", true, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridLogs, "colPrimaryEntityId", "Id Entidad", "primary_entity_id", true, display_index++, 200, 20, DataGridViewAutoSizeColumnMode.AllCells);
			DataGridUtilities.AddColumn(DataGridLogs, "colPrimaryEntityType", "Tipo Entidad", "primary_entity_type", true, display_index++, 200, 150, DataGridViewAutoSizeColumnMode.Fill);

			DataGridLogs.DataSource = DSLogs;
			DataGridLogs.DataMember = DTLogs.TableName;
		}

		private void LoadList()
		{
			using (new CursorWait())
			{
				List<TEventLog> logs;

				Error error = EventLogHandler.GetEventLogs(out logs);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTLogs.BeginLoadData();
				DTLogs.Clear();

				foreach (TEventLog log in logs)
				{
					DataRow row = DTLogs.NewRow();

					row["id"] = log.Id;
					row["date"] = log.DateTime;
					row["message"] = log.Message;
					row["user_id"] = log.User.Id;
					row["user_name"] = log.User.Name;
					row["primary_entity_id"] = log.PrimaryEntity.Id;
					row["primary_entity_type"] = log.PrimaryEntity.EntityType;
					row["type"] = log.Type;
					row["type_name"] = BConstants.GetEventLogTypeName(log.Type);

					DTLogs.Rows.Add(row);
				}

				DTLogs.EndLoadData();
			}
		}

		private void FEventLog_Load(object sender, EventArgs e)
		{
			LoadList();
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private void BDetail_Click(object sender, EventArgs e)
		{
			SplitContainer.Panel2Collapsed = !BDetail.Checked;
		}

		private void DataGridLogs_SelectionChanged(object sender, EventArgs e)
		{
			if (DataGridLogs.SelectedRows.Count == 0)
			{
				return;
			}

			DataGridViewRow row = DataGridLogs.SelectedRows[0];

			Message.Text = row.Cells["colMessage"].Value?.ToString();
			LName.Text = row.Cells["colTypeName"].Value?.ToString();
			LUser.Text = row.Cells["colUserName"].Value?.ToString();

			if (row.Cells["colPrimaryEntityType"].Value != null)
				LEntity.Text = ((TEntityType)row.Cells["colPrimaryEntityType"].Value).ToString();
			
			LDate.Text = row.Cells["colDate"].Value?.ToString();
		}

		private void BFilter_Click(object sender, EventArgs e)
		{
			if (filters_dlg.ShowDialog() == DialogResult.OK)
			{
				string filters = "true";

				if (filters_dlg.FilterUser.Checked)
					filters += "  AND user_id = " + filters_dlg.User.SelectedValue;
					
				if (filters_dlg.FilterActionType.Checked)
					filters += "  AND type = " + (int)filters_dlg.ActionType.SelectedItem;

				if (filters_dlg.FilterDate.Checked)
					filters += "  AND date >= '" + filters_dlg.DateFrom.Value.ToString("yyyy-MM-dd") + "' AND date <= '" + filters_dlg.DateTo.Value.ToString("yyyy-MM-dd") + " 23:59:59" + "'";

				if (filters_dlg.FilterEntityType.Checked)
					filters += "  AND primary_entity_type = " + (int)filters_dlg.EntityType.SelectedItem;

				if (filters_dlg.FilterEntityId.Checked)
					filters += "  AND primary_entity_id = " + filters_dlg.EntityId.Value;

				DTLogs.DefaultView.RowFilter = filters;
				DataGridLogs.DataSource = DTLogs;
			}
		}
	}
}
