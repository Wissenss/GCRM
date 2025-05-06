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
	public partial class FCitizenRelationshipListFilters : Form
	{
		DataSet DSFilters;
		DataTable DTUsers;
		DataTable DTCitizens;
		DataTable DTRelatedTo;
		DataTable DTRelationshipRole;

		public FCitizenRelationshipListFilters()
		{
			InitializeComponent();

			DSFilters = new DataSet();

			DTUsers = new DataTable();
			DTUsers.Columns.Add("id", typeof(int));
			DTUsers.Columns.Add("name", typeof(string));
			DSFilters.Tables.Add(DTUsers);

			DTCitizens = new DataTable();
			DTCitizens.Columns.Add("id", typeof(int));
			DTCitizens.Columns.Add("name", typeof(string));
			DSFilters.Tables.Add(DTCitizens);

			DTRelatedTo = new DataTable();
			DTRelatedTo.Columns.Add("id", typeof(int));
			DTRelatedTo.Columns.Add("name", typeof(string));
			DSFilters.Tables.Add(DTRelatedTo);

			DTRelationshipRole = new DataTable();
			DTRelationshipRole.Columns.Add("id", typeof(int));
			DTRelationshipRole.Columns.Add("name", typeof(string));
			DSFilters.Tables.Add(DTRelationshipRole);

			LoadDatasets();
		}

		private void LoadDatasets()
		{
			using (new CursorWait())
			{
				// users
				Error error = UsersHandler.GetUsers(out List<TUser> users_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTUsers.BeginLoadData();
				DTUsers.Clear();

				foreach (TUser user in users_list)
				{
					DataRow row = DTUsers.NewRow();

					row["id"] = user.Id;
					row["name"] = user.Name;

					DTUsers.Rows.Add(row);
				}

				DTUsers.EndLoadData();

				User.DataSource = DTUsers;
				User.ValueMember = "id";
				User.DisplayMember = "name";
				User.SelectedIndex = 0;

				// citizen
				error = CitizensHandler.GetCitizens(out List<TCitizen> citizen_list);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTCitizens.BeginLoadData();
				DTCitizens.Clear();

				foreach (TCitizen citizen in citizen_list)
				{
					DataRow row = DTUsers.NewRow();

					row["id"] = citizen.Id;
					row["name"] = citizen.Name;

					DTUsers.Rows.Add(row);
				}

				DTCitizens.EndLoadData();

				Citizen.DataSource = DTUsers;
				Citizen.ValueMember = "id";
				Citizen.DisplayMember = "name";
				Citizen.SelectedIndex = 0;

				// realated to
				DTRelatedTo.BeginLoadData();
				DTRelatedTo.Clear();

				foreach (TCitizen citizen in citizen_list)
				{
					DataRow row = DTRelatedTo.NewRow();

					row["id"] = citizen.Id;
					row["name"] = citizen.Name;

					DTRelatedTo.Rows.Add(row);
				}

				DTRelatedTo.EndLoadData();

				RelatedTo.DataSource = DTRelatedTo;
				RelatedTo.ValueMember = "id";
				RelatedTo.DisplayMember = "name";
				RelatedTo.SelectedIndex = 0;

				// relationship role
				error = CitizensHandler.GetCitizenRelationshipRoles(out List<TCitizenRelationshipRole> roles);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTRelationshipRole.BeginLoadData();
				DTRelationshipRole.Clear();

				foreach (TCitizenRelationshipRole role in roles)
				{
					DataRow row = DTRelationshipRole.NewRow();

					row["id"] = role.Id;
					row["name"] = role.Name;

					DTRelationshipRole.Rows.Add(row);
				}

				DTRelationshipRole.EndLoadData();

				RelationshipRole.DataSource = DTRelationshipRole;
				RelationshipRole.ValueMember = "id";
				RelationshipRole.DisplayMember = "name";
				RelationshipRole.SelectedIndex = 0;
			}
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		private void FilterUser_CheckedChanged(object sender, EventArgs e)
		{
			User.Enabled = FilterUser.Checked;
		}

		private void FilterCitizen_CheckedChanged(object sender, EventArgs e)
		{
			Citizen.Enabled = FilterCitizen.Checked;
		}

		private void FilterRelatedTo_CheckedChanged(object sender, EventArgs e)
		{
			RelatedTo.Enabled = FilterRelatedTo.Checked;
		}

		private void FilterRelationshipRole_CheckedChanged(object sender, EventArgs e)
		{
			RelationshipRole.Enabled = FilterRelationshipRole.Checked;
		}

		private void FilterMinAffinity_CheckedChanged(object sender, EventArgs e)
		{
			MinAffinity.Enabled = FilterMinAffinity.Checked;
		}

		private void FilterMaxAffinity_CheckedChanged(object sender, EventArgs e)
		{
			MaxAffinity.Enabled = FilterMaxAffinity.Checked;
		}
	}
}
