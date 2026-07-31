using Business;
using GCRM.Domain;
using QuestPDF.Companion;
using QuestPDF.Fluent;
using QuestPDF.Previewer;
using Reporter;
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
    public partial class FReport006 : Form
    {
        DataSet DSCitizens;
        DataTable DTCitizens;

        public FReport006()
        {
            InitializeComponent();

            DSCitizens = new DataSet();

            DTCitizens = new DataTable();
            DTCitizens.Columns.Add("id", typeof(int));
            DTCitizens.Columns.Add("name", typeof(string));
            DSCitizens.Tables.Add(DTCitizens);
        }

        private void LoadCatalogs()
        {
            using (new CursorWait())
            {
                Error error = CitizensHandler.GetCitizens(out List<TCitizen> citizen_list);

                if (error != Error.None)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                DTCitizens.BeginLoadData();
                DTCitizens.Clear();

                foreach (TCitizen citizen in citizen_list)
                {
                    DataRow row = DTCitizens.NewRow();

                    row["id"] = citizen.Id;
                    row["name"] = citizen.FullNameWithFirstCapitals;

                    DTCitizens.Rows.Add(row);
                }

                DTCitizens.EndLoadData();

                Citizen.DataSource = DTCitizens;
                Citizen.ValueMember = "id";
                Citizen.DisplayMember = "name";

                if (DTCitizens.Rows.Count > 0)
                    Citizen.SelectedIndex = 0;
            }
        }

        private void FReport006_Load(object sender, EventArgs e)
        {
            LoadCatalogs();
        }

        private async void BAccept_Click(object sender, EventArgs e)
        {
            R006DocumentModel model = new R006DocumentModel();

            Error error = CitizensHandler.GetCitizenById((int)Citizen.SelectedValue, out model.Citizen);

            if (error != Error.None)
            {
                Utilities.ShowErrorDialog(error);
                return;
            }

            var doc = new R006Document(model);

            doc.GeneratePdfAndShow();
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
