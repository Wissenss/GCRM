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
    public partial class FReport005 : Form
    {
        public FReport005()
        {
            InitializeComponent();
        }

        private void LoadCatalogs()
        {
            using (new CursorWait())
            {
                Catalogs.LoadDTInstitutions();

                Institution.DataSource = Catalogs.DTInstitutions;
                Institution.ValueMember = "id";
                Institution.DisplayMember = "name";

                if (Catalogs.DTInstitutions.Rows.Count > 0)
                    Institution.SelectedIndex = 0;
            }
        }

        private void FReport005_Load(object sender, EventArgs e)
        {
            LoadCatalogs();
        }

        private async void BAccept_Click(object sender, EventArgs e)
        {
            R005DocumentModel model = new R005DocumentModel();

            Error error = InstitutionsHandler.GetInstitutionById((int)Institution.SelectedValue, out model.Institution);

            if (error != Error.None)
            {
                Utilities.ShowErrorDialog(error);
                return;
            }

            error = CitizensHandler.GetCitizensWithRoleInInstitution(model.Institution.Id, out model.Citizens);

            if (error != Error.None)
            {
                Utilities.ShowErrorDialog(error);
                return;
            }

            var doc = new R005Document(model);

            doc.GeneratePdfAndShow();
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
