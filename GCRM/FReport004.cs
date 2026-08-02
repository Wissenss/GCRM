using Business;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;
using QuestPDF.Fluent;
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
    public partial class FReport004 : Form
    {
        DataSet DSFilters;
        DataTable DTCategories;
        DataTable DTSectors;

        public FReport004()
        {
            InitializeComponent();

            DSFilters = new DataSet();

            DTCategories = new DataTable();
            DTCategories.Columns.Add("id", typeof(int));
            DTCategories.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTCategories);

            DTSectors = new DataTable();
            DTSectors.Columns.Add("value", typeof(int));
            DTSectors.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTSectors);
        }

        private void LoadCatalogs()
        {
            using (new CursorWait())
            {
                Error error = InstitutionsHandler.GetInstitutionCategories(out List<TInstitutionCategory> category_list);

                if (error != Error.None)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                DTCategories.BeginLoadData();
                DTCategories.Clear();

                foreach (TInstitutionCategory category in category_list)
                {
                    DataRow row = DTCategories.NewRow();

                    row["id"] = category.Id;
                    row["name"] = category.Name;

                    DTCategories.Rows.Add(row);
                }

                DTCategories.EndLoadData();

                Category.DataSource = DTCategories;
                Category.ValueMember = "id";
                Category.DisplayMember = "name";

                if (DTCategories.Rows.Count > 0)
                    Category.SelectedIndex = 0;

                DTSectors.BeginLoadData();
                DTSectors.Clear();

                foreach (TSocietySector sector in Enum.GetValues(typeof(TSocietySector)))
                {
                    DataRow row = DTSectors.NewRow();

                    row["value"] = (int)sector;
                    row["name"] = BConstants.GetSocietySectorName(sector);

                    DTSectors.Rows.Add(row);
                }

                DTSectors.EndLoadData();

                Sector.DataSource = DTSectors;
                Sector.ValueMember = "value";
                Sector.DisplayMember = "name";
                Sector.SelectedIndex = 0;
            }
        }

        private void FReport004_Load(object sender, EventArgs e)
        {
            LoadCatalogs();
        }

        private void CheckBoxFilterCategory_CheckedChanged(object sender, EventArgs e)
        {
            Category.Enabled = CheckBoxFilterCategory.Checked;
        }

        private void CheckBoxFilterSector_CheckedChanged(object sender, EventArgs e)
        {
            Sector.Enabled = CheckBoxFilterSector.Checked;
        }

        private bool TryBuildDocument(out R004Document document)
        {
            document = null;

            Error error = InstitutionsHandler.GetInstitutions(out List<TInstitution> institution_list);

            if (error != Error.None)
            {
                Utilities.ShowErrorDialog(error);
                return false;
            }

            R004DocumentModel model = new R004DocumentModel();

            int category_id = 0;
            TSocietySector? sector = null;

            if (CheckBoxFilterCategory.Checked)
            {
                category_id = (int)Category.SelectedValue;

                error = InstitutionsHandler.GetInstitutionCategoryById(category_id, out TInstitutionCategory category);

                if (error != Error.None)
                {
                    Utilities.ShowErrorDialog(error);
                    return false;
                }

                model.Category = category;
            }

            if (CheckBoxFilterSector.Checked)
            {
                sector = (TSocietySector)Sector.SelectedValue;
                model.SocietySector = sector;
            }

            foreach (TInstitution institution in institution_list)
            {
                if (category_id != 0 && institution.Category.Id != category_id)
                    continue;

                if (sector != null && institution.Sector != sector)
                    continue;

                model.Institutions.Add(institution);
            }

            document = new R004Document(model);

            return true;
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BGenerate_Click(object sender, EventArgs e)
        {
            if (TryBuildDocument(out R004Document document))
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
            if (TryBuildDocument(out R004Document document) == false)
                return;

            using SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                FileName = "R004_CatalogoInstituciones.pdf"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                document.GeneratePdf(dialog.FileName);
        }
    }
}
