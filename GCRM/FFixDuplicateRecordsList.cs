using System.Data;
using Business;
using GCRM.Domain.Enums;

namespace GCRM
{
	public partial class FFixDuplicateRecordsList : Form
	{
		public DataSet DSFixDuplicateRecordsList;
		public DataTable DTFixDuplicateRecordsList;
		public TEntityType Entity;

		public FFixDuplicateRecordsList()
		{
			InitializeComponent();

			DSFixDuplicateRecordsList = new DataSet();
			DTFixDuplicateRecordsList = new DataTable("DTFixDuplicateRecordsList");

			DataGridFixDuplicateRecordsList.DataSource = DSFixDuplicateRecordsList;
		}

		private void FFixDuplicateRecordsList_Load(object sender, EventArgs e)
		{
			BAttentionRequired.Visible = Entity == TEntityType.citizen
				? Session.HasPermission("Ciudadanos.SetAttentionRequired")
				: Session.HasPermission("Instituciones.SetAttentionRequired");
		}

		private void BAttentionRequired_Click(object sender, EventArgs e)
		{
			if (DataGridFixDuplicateRecordsList.SelectedRows.Count == 0)
				return;

			DataGridViewRow row = DataGridFixDuplicateRecordsList.SelectedRows[0];

			int id1 = (int)row.Cells["colId1"].Value;
			int id2 = (int)row.Cells["colId2"].Value;

			string reason1 = $"Se identificó un duplicado de este registro con el registro id {id2}.";
			string reason2 = $"Se identificó un duplicado de este registro con el registro id {id1}.";

			using (new CursorWait())
			{
				if (Entity == TEntityType.citizen)
				{
					CitizensHandler.SetCitizenAttentionRequired(id1, true, reason1);
					CitizensHandler.SetCitizenAttentionRequired(id2, true, reason2);
				}
				else
				{
					InstitutionsHandler.SetInstitutionAttentionRequired(id1, true, reason1);
					InstitutionsHandler.SetInstitutionAttentionRequired(id2, true, reason2);
				}
			}

			row.Cells["colAttentionRequired1"].Value = true;
			row.Cells["colAttentionRequiredReason1"].Value = reason1;
			row.Cells["colAttentionRequired2"].Value = true;
			row.Cells["colAttentionRequiredReason2"].Value = reason2;

			DataGridFixDuplicateRecordsList.InvalidateRow(row.Index);

			UpdateAttentionRequiredControls();
		}

		private void DataGridFixDuplicateRecordsList_SelectionChanged(object sender, EventArgs e)
		{
			UpdateAttentionRequiredControls();
		}

		private void UpdateAttentionRequiredControls()
		{
			DataGridViewRow row = DataGridFixDuplicateRecordsList.SelectedRows.Count > 0 ? DataGridFixDuplicateRecordsList.SelectedRows[0] : null;

			bool already_flagged = row != null && ((bool)row.Cells["colAttentionRequired1"].Value || (bool)row.Cells["colAttentionRequired2"].Value);

			BAttentionRequired.Enabled = row != null && !already_flagged;
		}

		private void DataGridFixDuplicateRecordsList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			if (e.RowIndex < 0)
				return;

			DataGridViewRow row = DataGridFixDuplicateRecordsList.Rows[e.RowIndex];

			if (row.Cells["colAttentionRequired1"].Value == null || row.Cells["colAttentionRequired2"].Value == null)
				return;

			bool already_flagged = (bool)row.Cells["colAttentionRequired1"].Value || (bool)row.Cells["colAttentionRequired2"].Value;

			if (already_flagged)
			{
				e.CellStyle.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
				e.CellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 150, 150);
			}
		}
	}
}
