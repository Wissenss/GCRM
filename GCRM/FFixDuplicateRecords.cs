using System.Data;
using Business;
using GCRM.Domain;
using GCRM.Domain.Enums;

namespace GCRM
{
	public partial class FFixDuplicateRecords : Form
	{
		DataTable DTMethods;
		DataTable DTEntities;

		public FFixDuplicateRecords()
		{
			InitializeComponent();

			DTMethods = new DataTable("DTMethods");
			DTMethods.Columns.Add("value", typeof(TDuplicateMatchMethod));
			DTMethods.Columns.Add("text", typeof(string));
			DTMethods.Rows.Add(TDuplicateMatchMethod.levenshtein_distance, "Distancia Levenshtein");

			Method.DataSource = DTMethods;
			Method.ValueMember = "value";
			Method.DisplayMember = "text";

			DTEntities = new DataTable("DTEntities");
			DTEntities.Columns.Add("value", typeof(TEntityType));
			DTEntities.Columns.Add("text", typeof(string));
			DTEntities.Rows.Add(TEntityType.institution, "Instituciones");
			DTEntities.Rows.Add(TEntityType.citizen, "Ciudadanos");

			Entity.DataSource = DTEntities;
			Entity.ValueMember = "value";
			Entity.DisplayMember = "text";
		}

		private void BSearch_Click(object sender, EventArgs e)
		{
			TEntityType entity = (TEntityType)Entity.SelectedValue;
			int threshold = (int)Threshold.Value;

			List<TDuplicateMatch> matches;
			Error error;

			using (new CursorWait())
			{
				error = entity == TEntityType.citizen
					? CitizensHandler.GetDuplicateCitizens(threshold, out matches)
					: InstitutionsHandler.GetDuplicateInstitutions(threshold, out matches);
			}

			if (error != 0)
			{
				Utilities.ShowErrorDialog(error);
				return;
			}

			using (FFixDuplicateRecordsList list_dlg = new FFixDuplicateRecordsList())
			{
				list_dlg.Text = entity == TEntityType.citizen ? "Ciudadanos duplicados" : "Instituciones duplicadas";
				list_dlg.Entity = entity;

				list_dlg.DTFixDuplicateRecordsList.Columns.Add("id1", typeof(int));
				list_dlg.DTFixDuplicateRecordsList.Columns.Add("name1", typeof(string));
				list_dlg.DTFixDuplicateRecordsList.Columns.Add("attention_required1", typeof(bool));
				list_dlg.DTFixDuplicateRecordsList.Columns.Add("attention_required_reason1", typeof(string));
				list_dlg.DTFixDuplicateRecordsList.Columns.Add("id2", typeof(int));
				list_dlg.DTFixDuplicateRecordsList.Columns.Add("name2", typeof(string));
				list_dlg.DTFixDuplicateRecordsList.Columns.Add("attention_required2", typeof(bool));
				list_dlg.DTFixDuplicateRecordsList.Columns.Add("attention_required_reason2", typeof(string));
				list_dlg.DTFixDuplicateRecordsList.Columns.Add("distance", typeof(int));

				int display_index = 0;

				DataGridUtilities.AddColumn(list_dlg.DataGridFixDuplicateRecordsList, "colId1", "Id", "id1", true, display_index++, 60, 20);
				DataGridUtilities.AddColumn(list_dlg.DataGridFixDuplicateRecordsList, "colName1", "Nombre", "name1", true, display_index++, 200, 20, DataGridViewAutoSizeColumnMode.Fill);
				DataGridUtilities.AddColumn(list_dlg.DataGridFixDuplicateRecordsList, "colAttentionRequired1", "Atención requerida", "attention_required1", false, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.None, DataGridColumnType.CheckBox);
				DataGridUtilities.AddColumn(list_dlg.DataGridFixDuplicateRecordsList, "colAttentionRequiredReason1", "Motivo", "attention_required_reason1", false, display_index++, 150, 20);
				DataGridUtilities.AddColumn(list_dlg.DataGridFixDuplicateRecordsList, "colId2", "Id", "id2", true, display_index++, 60, 20);
				DataGridUtilities.AddColumn(list_dlg.DataGridFixDuplicateRecordsList, "colName2", "Nombre", "name2", true, display_index++, 200, 20, DataGridViewAutoSizeColumnMode.Fill);
				DataGridUtilities.AddColumn(list_dlg.DataGridFixDuplicateRecordsList, "colAttentionRequired2", "Atención requerida", "attention_required2", false, display_index++, 100, 20, DataGridViewAutoSizeColumnMode.None, DataGridColumnType.CheckBox);
				DataGridUtilities.AddColumn(list_dlg.DataGridFixDuplicateRecordsList, "colAttentionRequiredReason2", "Motivo", "attention_required_reason2", false, display_index++, 150, 20);
				DataGridUtilities.AddColumn(list_dlg.DataGridFixDuplicateRecordsList, "colDistance", "Distancia", "distance", true, display_index++, 80, 20);

				list_dlg.DTFixDuplicateRecordsList.BeginLoadData();

				foreach (TDuplicateMatch match in matches)
				{
					DataRow row = list_dlg.DTFixDuplicateRecordsList.NewRow();

					row["id1"] = match.Entity1Id;
					row["name1"] = match.Entity1Name;
					row["attention_required1"] = match.Entity1AttentionRequired;
					row["attention_required_reason1"] = match.Entity1AttentionRequiredReason;
					row["id2"] = match.Entity2Id;
					row["name2"] = match.Entity2Name;
					row["attention_required2"] = match.Entity2AttentionRequired;
					row["attention_required_reason2"] = match.Entity2AttentionRequiredReason;
					row["distance"] = match.Distance;

					list_dlg.DTFixDuplicateRecordsList.Rows.Add(row);
				}

				list_dlg.DTFixDuplicateRecordsList.EndLoadData();

				list_dlg.DataGridFixDuplicateRecordsList.DataSource = list_dlg.DTFixDuplicateRecordsList;

				list_dlg.ShowDialog();
			}
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
