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
	public partial class FColumnChooser : Form
	{
		DataSet DSColumns;
		DataTable DTColumns;

		DataGridView DataGrid;

		public FColumnChooser(DataGridView data_grid)
		{
			InitializeComponent();

			DSColumns = new DataSet();

			DTColumns = new DataTable("DTColumns");
			DTColumns.Columns.Add("index", typeof(int));
			DTColumns.Columns.Add("name", typeof(string));
			DTColumns.Columns.Add("visible", typeof(bool));
			DSColumns.Tables.Add(DTColumns);

			DataGridColumns.DataSource = DSColumns;
			DataGridColumns.DataMember = "DTColumns";

			SetDataGrid(data_grid);
		}

		public void SetDataGrid(DataGridView data_grid)
		{
			DataGrid = data_grid;

			LoadColumns();
		}

		private void LoadColumns()
		{
			DTColumns.BeginLoadData();
			DTColumns.Clear();

			foreach (DataGridViewColumn column in DataGrid.Columns)
			{
				DataRow row = DTColumns.NewRow();

				row["index"] = column.Index;
				row["name"] = column.HeaderText;
				row["visible"] = column.Visible;

				DTColumns.Rows.Add(row);
			}

			DTColumns.EndLoadData();
		}

		private void FColumnChooser_Load(object sender, EventArgs e)
		{
			LoadColumns();
		}

		private int GetSelectedColumnIndex()
		{
			return DataGridUtilities.GetSelectedId(DataGridColumns, "colIndex");
		}

		private void BAccept_Click(object sender, EventArgs e)
		{
			foreach (DataRow row in DTColumns.Rows)
			{
				int index = (int)row["index"];
				bool visible = (bool)row["visible"];

				DataGrid.Columns[index].Visible = visible;
			}

			DialogResult = DialogResult.OK;
		}

		private void BCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
	}
}
