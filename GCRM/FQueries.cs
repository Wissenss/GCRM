using Connection;
using Npgsql;
using Npgsql.Schema;
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
	public partial class FQueries : Form
	{
		private string sql_directory;

		private DataSet DSQueries;
		private DataTable DTQueryResult;

		public FQueries()
		{
			InitializeComponent();

			sql_directory = Path.Join(Environment.CurrentDirectory, @"\SQL\");

			DSQueries = new DataSet("DSQueries");

			DTQueryResult = new DataTable("DTQueryResult");

			DSQueries.Tables.Add(DTQueryResult);

			DataGridResults.DataSource = DSQueries;
			DataGridResults.DataMember = "DTQueryResult";
		}

		public void LoadQueries()
		{
			if (Directory.Exists(sql_directory) == false)
			{
				Directory.CreateDirectory(sql_directory);
			}

			ComboBoxQueries.Items.Clear();

			foreach (string file_path in Directory.GetFiles(sql_directory))
			{
				string file = Path.GetFileName(file_path);

				if (file.StartsWith("query_") && file.EndsWith(".sql"))
				{
					ComboBoxQueries.Items.Add(file);
				}
			}

			if (ComboBoxQueries.Items.Count > 0)
			{
				ComboBoxQueries.SelectedIndex = 0;
			}
		}

		private void FQueries_Load(object sender, EventArgs e)
		{
			LoadQueries();
		}

		private void ComboBoxQueries_TextChanged(object sender, EventArgs e)
		{
			//using (new CursorWait())
			//{
			//	string file_path = Path.Join(sql_directory, ComboBoxQueries.Text);

			//	string sql = File.ReadAllText(file_path);

			//	TextBoxQueryText.Text = sql;
			//}
		}

		private void CreateDataGridFromReader(NpgsqlDataReader reader)
		{
			DataGridResults.Columns.Clear();

			int display_index = 0;

			foreach (NpgsqlDbColumn column in reader.GetColumnSchema())
			{
				DataGridUtilities.AddColumn(DataGridResults, $"col{column.ColumnName}", column.ColumnName, column.ColumnName, true, display_index++, 2, 2, DataGridViewAutoSizeColumnMode.AllCells);
			}
		}

		private void CreateDataTableFromReader(NpgsqlDataReader reader)
		{
			DTQueryResult.Columns.Clear();

			foreach (NpgsqlDbColumn column in reader.GetColumnSchema())
			{
				DTQueryResult.Columns.Add(column.ColumnName, column.DataType);
			}
		}

		private void FillDataTableFromReader(NpgsqlDataReader reader)
		{
			DTQueryResult.BeginLoadData();
			DTQueryResult.Clear();

			while (reader.Read())
			{
				DataRow row = DTQueryResult.NewRow();

				int reader_index = 0;

				foreach (NpgsqlDbColumn column in reader.GetColumnSchema())
				{
					row[column.ColumnName] = Convert.ChangeType(reader.GetValue(reader_index++), column.DataType);
				}

				DTQueryResult.Rows.Add(row);
			}

			DTQueryResult.EndLoadData();
		}

		private void BRun_Click(object sender, EventArgs e)
		{
			using (new CursorWait())
			{
				string file_path = Path.Join(sql_directory, ComboBoxQueries.Text);

				string sql = File.ReadAllText(file_path);

				var conn = ConnectionPool.GetConnection();

				try
				{
					using (var cmd = new NpgsqlCommand(sql, conn))
					using (var reader = cmd.ExecuteReader())
					{
						CreateDataGridFromReader(reader);
						CreateDataTableFromReader(reader);
						FillDataTableFromReader(reader);
					}
				}
				catch (Exception ex)
				{
					Utilities.ShowExceptionDialog(ex);
				}
				finally
				{
					ConnectionPool.ReleaseConnection(ref conn);
				}
			}
		}
	}
}
