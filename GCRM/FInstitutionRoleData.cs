using Business;
using GCRM.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GCRM
{
    public partial class FInstitutionRoleData : Form
    {
        FAccessMode AccessMode = FAccessMode.Create;

        DataTable DTVariations;

        public FInstitutionRoleData()
        {
            InitializeComponent();

            DTVariations = new DataTable("DTVariations");
            DTVariations.Columns.Add("id", typeof(int));
            DTVariations.Columns.Add("name", typeof(string));

            DataGridVariations.AutoGenerateColumns = false;

            int display_index = 0;

            DataGridUtilities.AddColumn(DataGridVariations, "colId", "Id", "id", false);
            DataGridUtilities.AddColumn(DataGridVariations, "colName", "Nombre", "name", true, display_index++, 200, 20, DataGridViewAutoSizeColumnMode.Fill);

            DataGridVariations.DataSource = DTVariations;
        }

        public void SetAccessMode(FAccessMode mode)
        {
            AccessMode = mode;

            TextBoxName.Enabled = AccessMode != FAccessMode.Read;
            TextBoxDescription.Enabled = AccessMode != FAccessMode.Read;
            DataGridVariations.Enabled = AccessMode != FAccessMode.Read;
            BAddVariation.Enabled = AccessMode != FAccessMode.Read;
            BEditVariation.Enabled = AccessMode != FAccessMode.Read;
            BDeleteVariation.Enabled = AccessMode != FAccessMode.Read;
        }

        public void SetValues(string name = "", string description = "")
        {
            TextBoxName.Text = name;
            TextBoxDescription.Text = description;

            Text = $"Cargo - {name}";
        }

        public void GetValues(out string name, out string description)
        {
            name = TextBoxName.Text;
            description = TextBoxDescription.Text;
        }

        public void SetVariations(List<TInstitutionRoleVariation> variations)
        {
            DTVariations.BeginLoadData();
            DTVariations.Clear();

            foreach (TInstitutionRoleVariation variation in variations)
            {
                DataRow row = DTVariations.NewRow();

                row["id"] = variation.Id;
                row["name"] = variation.Name;

                DTVariations.Rows.Add(row);
            }

            DTVariations.EndLoadData();
        }

        public List<TInstitutionRoleVariation> GetVariations()
        {
            List<TInstitutionRoleVariation> variations = new List<TInstitutionRoleVariation>();

            foreach (DataRow row in DTVariations.Rows)
            {
                variations.Add(new TInstitutionRoleVariation()
                {
                    Id = (int)row["id"],
                    Name = ((string)row["name"]).Trim()
                });
            }

            return variations;
        }

        public TInstitutionRole GetValues()
        {
            return new TInstitutionRole()
            {
                Name = TextBoxName.Text,
                Description = TextBoxDescription.Text,
                Variation = GetVariations()
            };
        }

        private bool ValidateInput()
        {
            StringBuilder errors = new StringBuilder();

            if (TextBoxName.Text.Trim().Length == 0)
            {
                errors.AppendLine("Debe especificar el nombre del cargo");
            }

            foreach (DataRow row in DTVariations.Rows)
            {
                if (((string)row["name"]).Trim().Length == 0)
                {
                    errors.AppendLine("Debe especificar el nombre de la variante");
                    break;
                }
            }

            if (errors.Length > 0)
            {
                Utilities.ShowValidationErrorDialog(errors);
                return false;
            }

            // spell check - this is merely a warning, user may choose to ignore it
            if (Session.SpellCheck)
            {
                List<Control> toCheck = new List<Control>()
                {
                    TextBoxName
                };

                if (SpellUtilities.CheckInputWithDialog(toCheck) != DialogResult.OK)
                {
                    return false;
                }
            }

            return true;
        }

        private void BAccept_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BAddVariation_Click(object sender, EventArgs e)
        {
            using (FInstitutionRoleVariation variation_dlg = new FInstitutionRoleVariation())
            {
                if (variation_dlg.ShowDialog() == DialogResult.OK)
                {
                    variation_dlg.GetValues(out string name);

                    DataRow row = DTVariations.NewRow();

                    row["id"] = 0;
                    row["name"] = name;

                    DTVariations.Rows.Add(row);
                }
            }
        }

        private void BEditVariation_Click(object sender, EventArgs e)
        {
            if (DataGridVariations.SelectedRows.Count == 0)
                return;

            DataGridViewRow selected_row = DataGridVariations.SelectedRows[0];

            DataRowView selected_row_view = (DataRowView)selected_row.DataBoundItem;

            using (FInstitutionRoleVariation variation_dlg = new FInstitutionRoleVariation())
            {
                variation_dlg.SetValues((string)selected_row_view.Row["name"]);

                if (variation_dlg.ShowDialog() == DialogResult.OK)
                {
                    variation_dlg.GetValues(out string name);

                    selected_row_view.Row.BeginEdit();

                    selected_row_view.Row["name"] = name;

                    selected_row_view.Row.EndEdit();
                }
            }
        }

        private void BDeleteVariation_Click(object sender, EventArgs e)
        {
            if (DataGridVariations.SelectedRows.Count == 0)
                return;

            DataGridViewRow selected_row = DataGridVariations.SelectedRows[0];

            (selected_row.DataBoundItem as DataRowView)?.Row.Delete();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            LAnnotation.Visible = TabControl.SelectedTab == TabVariaciones;
        }
    }
}
