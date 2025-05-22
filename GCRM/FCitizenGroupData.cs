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
	public partial class FCitizenGroupData : Form
	{
		private int Id;

		DataSet DSGroup;
		DataTable DTMembers;

		FAccessMode Mode = FAccessMode.Create;

		CitizenGroupService CitizenGroupService;

		public FCitizenGroupData()
		{
			InitializeComponent();

			CitizenGroupService = new CitizenGroupService();

			// create dataset / table
			DSGroup = new DataSet();

			DTMembers = new DataTable("DTMembers");
			DTMembers.Columns.Add("id", typeof(int));
			DTMembers.Columns.Add("fullname", typeof(string));
			DTMembers.Columns.Add("notes", typeof(string));
			DSGroup.Tables.Add(DTMembers);

			//configura members datagrid
			int displayIndex = 0;

			DataGridUtilities.AddColumn(DataGridMembers, "colId", "Id", "id", false, displayIndex++).ReadOnly = true;
			DataGridUtilities.AddColumn(DataGridMembers, "colFullname", "Nombre", "fullname", true, displayIndex++).ReadOnly = true;
			DataGridUtilities.AddColumn(DataGridMembers, "colNotes", "Notas", "notes", true, displayIndex++).ReadOnly = false;

			DataGridMembers.DataSource = DSGroup;
			DataGridMembers.DataMember = DTMembers.TableName;

			Clear();
		}

		public void SetId(int id)
		{
			Id = id;

			using (new CursorWait())
			{
				TCitizenGroup citizenGroup = CitizenGroupService.GetGroup(Id);

				TBName.Text = citizenGroup.Name;
				TBDescription.Text = citizenGroup.Description;

				// load the member list
				List<TCitizen> members = CitizenGroupService.GetGroupMembers(Id);

				DTMembers.BeginLoadData();
				DTMembers.Clear();

				foreach (TCitizen member in members)
				{
					DataRow row = DTMembers.NewRow();

					row["id"] = member.Id;
					row["fullname"] = member.FullName;

					DTMembers.Rows.Add(row);
				}

				DTMembers.EndLoadData();
			}
		}

		public void Clear()
		{
			TBName.Clear();
			TBDescription.Clear();
			DTMembers.Clear();

			Mode = FAccessMode.Create;
			Id = 0;
		}

		public void Configure()
		{

		}

		public void SetMode(FAccessMode mode)
		{
			Mode = mode;

			TBName.ReadOnly = Mode == FAccessMode.Read;
			TBDescription.ReadOnly = Mode == FAccessMode.Read;

			BAddMember.Enabled = Mode != FAccessMode.Read;
			BEditMember.Enabled = Mode != FAccessMode.Read;
			BDeleteMember.Enabled = Mode != FAccessMode.Read;
			DataGridMembers.ReadOnly = Mode == FAccessMode.Read;
		}

		private bool ValidateInput()
		{
			StringBuilder errors = new StringBuilder();

			if (TBName.Text.Trim().Length == 0)
				errors.AppendLine("Debe especificar el nombre");

			if (TBDescription.Text.Trim().Length == 0)
				errors.AppendLine("Debe especificar la descripción");

			if (errors.Length > 0)
			{
				Utilities.ShowValidationErrorDialog(errors);
				return false;
			}

			return true;
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			if (ValidateInput() == false) return;

			TCitizenGroup group = new TCitizenGroup();

			group.Name = TBName.Text.Trim();
			group.Description = TBDescription.Text.Trim();

			group.Members = new List<TCitizen>();

			foreach(DataRow row in DTMembers.Rows)
			{
				TCitizen member = new TCitizen();

				member.Id = (int)row["id"];

				group.Members.Add(member);
			}

			if (Mode == FAccessMode.Create)
				CitizenGroupService.AddGroup(group);
			else
				CitizenGroupService.UpdateGroup(group);

			DialogResult = DialogResult.OK;
		}
	}
}
