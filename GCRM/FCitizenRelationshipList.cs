using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
	public partial class FCitizenRelationshipList : Form
	{
		DataSet DSRelationships;
		DataTable DTRelationships;

		FColumnChooser ColumnChooserDlg;
		FCitizenRelationshipListFilters Filters;

		public FCitizenRelationshipList()
		{
			InitializeComponent();

			DSRelationships = new DataSet();

			DTRelationships = new DataTable();
			DTRelationships.Columns.Add("id", typeof(int));
			DTRelationships.Columns.Add("user_id", typeof(int));
			DTRelationships.Columns.Add("user_name", typeof(string));
			DTRelationships.Columns.Add("citizen_id", typeof(int));
			DTRelationships.Columns.Add("citizen_fullname", typeof(string));
			DTRelationships.Columns.Add("related_citizen_id", typeof(int));
			DTRelationships.Columns.Add("related_citizen_fullname", typeof(string));
			DTRelationships.Columns.Add("citizen_relationship_role_id", typeof(int));
			DTRelationships.Columns.Add("citizen_relationship_role_name", typeof(string));
			DTRelationships.Columns.Add("affinity_score", typeof(double));
			DTRelationships.Columns.Add("known_start_date", typeof(bool));
			DTRelationships.Columns.Add("known_end_date", typeof(bool));
			DTRelationships.Columns.Add("start_date", typeof(DateTime));
			DTRelationships.Columns.Add("end_date", typeof(DateTime));
			DSRelationships.Tables.Add(DTRelationships);

			DataGridRelationships.AutoGenerateColumns = false;

			int display_index = 0;

			DataGridUtilities.AddColumn(DataGridRelationships, "colCitizenFullname", "Ciudadano", "citizen_fullname", true, display_index++, 150, 20);
			DataGridUtilities.AddColumn(DataGridRelationships, "colRelatedToFullname", "Relacionado con", "related_citizen_fullname", true, display_index++, 150, 20);
			DataGridUtilities.AddColumn(DataGridRelationships, "colRoleName", "Relación", "citizen_relationship_role_name", true, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridRelationships, "colAffinityScore", "Afinidad", "affinity_score", true, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridRelationships, "colStartDate", "Inicio", "start_date", true, display_index++, 100, 20);
			DataGridUtilities.AddColumn(DataGridRelationships, "colEndDate", "Termino", "end_date", true, display_index++, 100, 20);

			DataGridUtilities.AddColumn(DataGridRelationships, "colId", "Id", "id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridRelationships, "colUserId", "Usuario Id", "user_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridRelationships, "colUserName", "Usuario", "user_name", false, display_index++);
			DataGridUtilities.AddColumn(DataGridRelationships, "colCitizenId", "Ciudadano Id", "citizen_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridRelationships, "colRelatedCitizenId", "Ciudadano Relacionado Id", "related_citizen_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridRelationships, "colRoleId", "Rol Id", "citizen_relationship_role_id", false, display_index++);
			DataGridUtilities.AddColumn(DataGridRelationships, "colKnownStartDate", "Incio conocido", "known_start_date", false, display_index++);
			DataGridUtilities.AddColumn(DataGridRelationships, "colKnownEndDate", "Fin conocido", "known_end_date", false, display_index++);

			DataGridRelationships.DataSource = DSRelationships;
			DataGridRelationships.DataMember = DTRelationships.TableName;

			ColumnChooserDlg = new FColumnChooser(DataGridRelationships);
			Filters = new FCitizenRelationshipListFilters();
		}

		private void LoadList()
		{
			using (new CursorWait())
			{
				Error error = CitizensHandler.GetCitizenRelationships(out List<TCitizenRelationship> relationships);

				if (error != 0)
				{
					Utilities.ShowErrorDialog(error);
					return;
				}

				DTRelationships.BeginLoadData();
				DTRelationships.Clear();

				foreach (var relation in relationships)
				{
					DataRow row = DTRelationships.NewRow();

					row["id"] = relation.Id;
					row["user_id"] = relation.User.Id;
					row["user_name"] = relation.User.Name;
					row["citizen_id"] = relation.Citizen.Id;
					row["citizen_fullname"] = relation.Citizen.FullName;
					row["related_citizen_id"] = relation.RelatedTo.Id;
					row["related_citizen_fullname"] = relation.RelatedTo.FullName;
					row["citizen_relationship_role_id"] = relation.Role.Id;
					row["citizen_relationship_role_name"] = relation.Role.Name;
					row["affinity_score"] = relation.AffinityScore;
					row["known_start_date"] = relation.KnownStartDate;
					row["known_end_date"] = relation.KnownEndDate;

					if (relation.KnownStartDate)
						row["start_date"] = relation.StartDate;

					if (relation.KnownEndDate)
						row["end_date"] = relation.EndDate;

					DTRelationships.Rows.Add(row);
				}

				DTRelationships.EndLoadData();
			}

			UpdateStatusStrip();
		}

		private void BRelationshipRoles_Click(object sender, EventArgs e)
		{
			using (FCitizenRelationshipRoleList role_list_dlg = new FCitizenRelationshipRoleList())
			{
				role_list_dlg.ShowDialog();
			}
		}

		private void BRefresh_Click(object sender, EventArgs e)
		{
			LoadList();
		}

		private void BFields_Click(object sender, EventArgs e)
		{
			ColumnChooserDlg.ShowDialog();
		}

		private void FCitizenRelationshipList_Load(object sender, EventArgs e)
		{
			LoadList();

			SettingsUtilities.TryLoadFormConfiguration(this, "relationships\\main_form");
			DataGridUtilities.TryLoadConfiguration(DataGridRelationships, "relationships\\main_data_grid");
		}

		private void FCitizenRelationshipList_FormClosing(object sender, FormClosingEventArgs e)
		{
			DataGridUtilities.TrySaveConfiguration(DataGridRelationships, "relationships\\main_data_grid");
			SettingsUtilities.TrySaveFormConfiguration(this, "relationships\\main_form");
		}

		private void FilterList()
		{
			string filter = "true";
			string search = TextBoxSearch.Text.Trim();

			if (BSearch.Checked && search.Length > 0)
			{
				filter += DataGridUtilities.GetFilterCondititonForTextSearch(DataGridRelationships, DTRelationships, search);
			}

			if (Filters.FilterUser.Checked)
				filter += $" and user_id = {(int)Filters.User.SelectedValue}";

			if (Filters.FilterCitizen.Checked)
				filter += $" and citizen_id = {(int)Filters.Citizen.SelectedValue}";

			if (Filters.FilterRelatedTo.Checked)
				filter += $" and realted_citizen_id = {(int)Filters.RelatedTo.SelectedValue}";

			if (Filters.FilterRelationshipRole.Checked)
				filter += $" and citizen_relationship_role_id = {(int)Filters.RelationshipRole.SelectedValue}";

			if (Filters.FilterMinAffinity.Checked)
				filter += $" and affinity_score >= {Filters.MinAffinity.Value}";

			if (Filters.FilterMaxAffinity.Checked)
				filter += $" and affinity_score <= {Filters.MaxAffinity.Value}";

			DTRelationships.DefaultView.RowFilter = filter;
			DataGridRelationships.DataSource = DTRelationships;
			DataGridRelationships.Refresh();

			UpdateStatusStrip();
		}

		private void UpdateStatusStrip()
		{
			TSSLRecordCount.Text = $"Total: {DataGridRelationships.RowCount}";

			TSSLFilters.Text = "";

			// the filters label
			string filtros = "";

			if (Filters.FilterUser.Checked)
				filtros += $" Usuario = {Filters.User.Text}, ";

			if (Filters.FilterCitizen.Checked)
				filtros += $" Ciudadano = {Filters.Citizen.Text}, ";

			if (Filters.FilterRelatedTo.Checked)
				filtros += $" Relación con = {Filters.RelatedTo.Text}, ";

			if (Filters.FilterRelationshipRole.Checked)
				filtros += $" Vínculo = {Filters.RelationshipRole.Text}, ";

			if (Filters.FilterMinAffinity.Checked)
				filtros += $" Afinidad >= {Filters.MinAffinity.Value}, ";

			if (Filters.FilterMaxAffinity.Checked)
				filtros += $" Afinidad <= {Filters.MaxAffinity.Value}, ";

			if (filtros.Length > 0)
			{
				TSSLFilters.Text = $"  Filtros: {filtros.TrimEnd(',', ' ')}";
			}
			else
			{
				TSSLFilters.Text = "";
			}
		}

		private void BSearch_Click(object sender, EventArgs e)
		{
			PanelSearch.Visible = BSearch.Checked;

			if (BSearch.Checked)
				TextBoxSearch.Focus();

			FilterList();
		}

		private void TextBoxSearch_TextChanged(object sender, EventArgs e)
		{
			FilterList();
		}

		private void FExcelExport_Click(object sender, EventArgs e)
		{
			SaveFileDialog.DefaultExt = $".xlsx";
			SaveFileDialog.FileName = $"listado_relaciones_{DateTime.Now.ToString("yyyyMMdd")}";
			SaveFileDialog.Filter = $"Excel (*.xlsx) | *.xlsx | Todos (*.*) | *.*";

			if (SaveFileDialog.ShowDialog() != DialogResult.OK)
				return;

			DataGridUtilities.ExportToExcel(DataGridRelationships, SaveFileDialog.FileName);
		}

		private void BFilter_Click(object sender, EventArgs e)
		{
			if (Filters.ShowDialog() == DialogResult.OK)
			{
				FilterList();
			}
		}
	}
}
