using Business;
using System.Data;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
	public partial class FEventLogFilters : Form
	{
		DataSet DSLogsFilters;
		DataTable DTUsers;

		public FEventLogFilters()
		{
			InitializeComponent();

			DSLogsFilters = new DataSet();

			DTUsers = new DataTable("DTUsers");
			DTUsers.Columns.Add("id", typeof(int));
			DTUsers.Columns.Add("name", typeof(string));
			DSLogsFilters.Tables.Add(DTUsers);

			User.DataSource = DSLogsFilters;

			using (new CursorWait())
			{
				Error error = UsersHandler.GetUsers(out List<TUser> users);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTUsers.BeginLoadData();
				DTUsers.Clear();

				foreach (TUser user in users)
				{
					DTUsers.Rows.Add(user.Id, user.Name);
				}

				DTUsers.EndLoadData();
			}

			User.DataSource = DTUsers;
			User.DisplayMember = "name";
			User.ValueMember = "id";

			ComboboxUtilities.SetEnumDataSource<TEventLogType>(ActionType);
			ComboboxUtilities.SetEnumDataSource<TEntityType>(EntityType);
		}

		private void FilterEntityId_CheckedChanged(object sender, EventArgs e)
		{
			EntityId.Enabled = FilterEntityId.Checked;
		}

		private void FilterEntityType_CheckedChanged(object sender, EventArgs e)
		{
			EntityType.Enabled = FilterEntityType.Checked;
		}

		private void CheckBoxFilterType_CheckedChanged(object sender, EventArgs e)
		{
			ActionType.Enabled = FilterActionType.Checked;
		}

		private void FilterUser_CheckedChanged(object sender, EventArgs e)
		{
			User.Enabled = FilterUser.Checked;
		}

		private void FilterDate_CheckedChanged(object sender, EventArgs e)
		{
			DateFrom.Enabled = FilterDate.Checked;
			DateTo.Enabled = FilterDate.Checked;
			LDateTo.Enabled = FilterDate.Checked;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
