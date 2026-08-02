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

        private bool TryBuildDocument(out R005Document document)
        {
            document = null;

            R005DocumentModel model = new R005DocumentModel();

            Error error = InstitutionsHandler.GetInstitutionById((int)Institution.SelectedValue, out model.Institution);

            if (error != Error.None)
            {
                Utilities.ShowErrorDialog(error);
                return false;
            }

            error = CitizensHandler.GetCitizensWithRoleInInstitution(model.Institution.Id, out model.Citizens);

            if (error != Error.None)
            {
                Utilities.ShowErrorDialog(error);
                return false;
            }

            document = new R005Document(model);

            return true;
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BGenerate_Click(object sender, EventArgs e)
        {
            if (TryBuildDocument(out R005Document document))
            {
                using (FDocumentViewer viewer = new FDocumentViewer())
                {
                    viewer.PrintSettings.Landscape = false;
                    viewer.LoadDocument(document);
                    viewer.ShowDialog();
                }
            }
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            if (TryBuildDocument(out R005Document document) == false)
                return;

            using SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                FileName = "R005_Institucion.pdf"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                document.GeneratePdf(dialog.FileName);
        }
    }
}
