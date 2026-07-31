using Business;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCRM
{
    public partial class FReportList : Form
    {
        DataSet DSReports;
        DataTable DTReports;

        public FReportList()
        {
            InitializeComponent();

            DSReports = new DataSet("DSReports");

            DTReports = new DataTable("DTReports", "DTReports");
            DTReports.Columns.Add("key", typeof(string));
            DTReports.Columns.Add("name", typeof(string));
            DTReports.Columns.Add("description", typeof(string));
            DSReports.Tables.Add(DTReports);

            DataGridReports.DataSource = DSReports;
            DataGridReports.DataMember = "DTReports";
        }

        private void AddItem(string key, string name, string description)
        {
            if (Session.HasPermission($"Reportes.Generar.{key}") == false)
                return;

            DataRow row = DTReports.NewRow();

            row["key"] = key;
            row["name"] = name;
            row["description"] = description;

            DTReports.Rows.Add(row);
        }

        private void LoadList()
        {
            using (new CursorWait())
            {
                DTReports.BeginLoadData();
                DTReports.Rows.Clear();

                AddItem("R001", "Catálogo de ciudadanos", "Listado de ciudadanos, con filtros opcionales");
                AddItem("R004", "Catálogo de instituciones", "Listado de instituciones, con filtros opcionales");
                AddItem("R005", "Institución", "Información de la institución y de su plantilla actual");
                AddItem("R006", "Ciudadano", "Información del ciudadano y de sus instituciones y cargos");

                DTReports.EndLoadData();
            }
        }

        private void FReportList_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void BGenerate_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = DataGridReports.SelectedRows[0];

            string key = (string)row.Cells[0].Value;

            switch (key)
            {
                case "R001": (new FReport001()).ShowDialog(); break;
                case "R004": (new FReport004()).ShowDialog(); break;
                case "R005": (new FReport005()).ShowDialog(); break;
                case "R006": (new FReport006()).ShowDialog(); break;
            }
        }
    }
}
