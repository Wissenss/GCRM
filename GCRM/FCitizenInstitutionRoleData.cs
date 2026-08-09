using Business;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GCRM
{
    public partial class FCitizenInstitutionRoleData : Form
    {
        FAccessMode AccessMode = FAccessMode.Create;

        public int Position;

        DataTable DTInstitutions;
        DataTable DTRoles;
        DataTable DTVariations;

        List<TInstitutionRole> RoleList = new List<TInstitutionRole>();

        public FCitizenInstitutionRoleData()
        {
            InitializeComponent();

            DTInstitutions = new DataTable("DTInstitutions");
            DTInstitutions.Columns.Add("id", typeof(int));
            DTInstitutions.Columns.Add("name", typeof(string));

            DTRoles = new DataTable("DTRoles");
            DTRoles.Columns.Add("id", typeof(int));
            DTRoles.Columns.Add("name", typeof(string));
            DTRoles.Columns.Add("template_id", typeof(int));
            DTRoles.Columns.Add("is_template_role", typeof(bool));

            DTVariations = new DataTable("DTVariations");
            DTVariations.Columns.Add("id", typeof(int));
            DTVariations.Columns.Add("name", typeof(string));

            ComboBoxInstitution.DataSource = DTInstitutions;
            ComboBoxInstitution.ValueMember = "id";
            ComboBoxInstitution.DisplayMember = "name";

            ComboBoxRole.DataSource = DTRoles;
            ComboBoxRole.ValueMember = "id";
            ComboBoxRole.DisplayMember = "name";

            comboBoxRoleVariation.DataSource = DTVariations;
            comboBoxRoleVariation.ValueMember = "id";
            comboBoxRoleVariation.DisplayMember = "name";

            LoadInstitutions();
            LoadRoles(0);
        }

        public void SetAccessMode(FAccessMode mode)
        {
            AccessMode = mode;

            ComboBoxInstitution.Enabled = AccessMode != FAccessMode.Read;
            ComboBoxRole.Enabled = AccessMode != FAccessMode.Read;
            UpdateVariationComboState();
            CheckBoxActive.Enabled = AccessMode != FAccessMode.Read;
            CheckBoxStartDefined.Enabled = AccessMode != FAccessMode.Read;
            CheckBoxEndDefined.Enabled = AccessMode != FAccessMode.Read;
            DateTimePickerStart.Enabled = AccessMode != FAccessMode.Read && CheckBoxStartDefined.Checked;
            DateTimePickerEnd.Enabled = AccessMode != FAccessMode.Read && CheckBoxEndDefined.Checked;

            UpdateNewRoleButtonState();
            UpdateNewRoleVariationButtonState();
        }

        private void LoadInstitutions()
        {
            using (new CursorWait())
            {
                Error error = InstitutionsHandler.GetInstitutions(out List<TInstitution> institutions);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                DTInstitutions.BeginLoadData();
                DTInstitutions.Clear();

                DataRow none_row = DTInstitutions.NewRow();

                none_row["id"] = 0;
                none_row["name"] = "Ninguna";

                DTInstitutions.Rows.Add(none_row);

                foreach (TInstitution institution in institutions)
                {
                    DataRow row = DTInstitutions.NewRow();

                    row["id"] = institution.Id;
                    row["name"] = institution.Name;

                    DTInstitutions.Rows.Add(row);
                }

                DTInstitutions.EndLoadData();

                ComboBoxInstitution.SelectedIndex = 0;
            }
        }

        private void LoadRoles(int institution_id)
        {
            using (new CursorWait())
            {
                RoleList = new List<TInstitutionRole>();

                LInstitutionSectorAndCategory.Text = "";

                if (institution_id != 0)
                {
                    Error error = InstitutionsHandler.GetInstitutionById(institution_id, out TInstitution institution);

                    if (error != 0)
                    {
                        Utilities.ShowErrorDialog(error);
                        return;
                    }

                    LInstitutionSectorAndCategory.Text = $"{BConstants.GetSocietySectorName(institution.Sector)} - {institution.Category.Name}";

                    error = InstitutionsHandler.GetInstitutionRoles(institution_id, institution.Template.Id, out RoleList);

                    if (error != 0)
                    {
                        Utilities.ShowErrorDialog(error);
                        return;
                    }
                }

                RoleList.Insert(0, new TInstitutionRole()
                {
                    Id = 0,
                    Name = "Ninguno",
                });

                DTRoles.BeginLoadData();
                DTRoles.Clear();

                foreach (TInstitutionRole role in RoleList)
                {
                    DataRow row = DTRoles.NewRow();

                    row["id"] = role.Id;
                    row["name"] = role.Name;
                    row["template_id"] = role.InstitutionTemplateId;
                    row["is_template_role"] = role.IsTemplateRole;

                    DTRoles.Rows.Add(row);
                }

                DTRoles.EndLoadData();

                ComboBoxRole.SelectedIndex = 0;
            }
        }

        private void LoadVariations()
        {
            DTVariations.BeginLoadData();
            DTVariations.Clear();

            DataRow none_row = DTVariations.NewRow();

            none_row["id"] = 0;
            none_row["name"] = "";

            DTVariations.Rows.Add(none_row);

            int index = ComboBoxRole.SelectedIndex;

            if (index >= 0 && index < RoleList.Count)
            {
                foreach (TInstitutionRoleVariation variation in RoleList[index].Variation)
                {
                    DataRow row = DTVariations.NewRow();

                    row["id"] = variation.Id;
                    row["name"] = variation.Name;

                    DTVariations.Rows.Add(row);
                }
            }

            DTVariations.EndLoadData();

            comboBoxRoleVariation.SelectedIndex = 0;

            UpdateVariationComboState();
            UpdateNewRoleVariationButtonState();
        }

        private void UpdateVariationComboState()
        {
            bool has_variations = DTVariations.Rows.Count > 1;

            comboBoxRoleVariation.Enabled = has_variations && AccessMode != FAccessMode.Read;
        }

        private void SelectRole(int role_id, int template_id)
        {
            for (int i = 0; i < DTRoles.Rows.Count; i++)
            {
                DataRow row = DTRoles.Rows[i];

                if ((int)row["id"] == role_id && (int)row["template_id"] == template_id)
                {
                    ComboBoxRole.SelectedIndex = i;
                    break;
                }
            }

            LoadVariations();
        }

        private void SelectVariation(int variation_id)
        {
            for (int i = 0; i < DTVariations.Rows.Count; i++)
            {
                DataRow row = DTVariations.Rows[i];

                if ((int)row["id"] == variation_id)
                {
                    comboBoxRoleVariation.SelectedIndex = i;
                    break;
                }
            }
        }

        private void GetSelectedRole(out int role_id, out string role_name, out int template_id, out bool is_template_role)
        {
            int index = ComboBoxRole.SelectedIndex;

            DataRow row = DTRoles.Rows[index];

            role_id = (int)row["id"];
            role_name = (string)row["name"];
            template_id = (int)row["template_id"];
            is_template_role = (bool)row["is_template_role"];
        }

        private void GetSelectedVariation(out int variation_id, out string variation_name)
        {
            int index = comboBoxRoleVariation.SelectedIndex;

            DataRow row = DTVariations.Rows[index];

            variation_id = (int)row["id"];
            variation_name = (string)row["name"];
        }

        public void SetValues(TCitizenInstitutionRole citizen_institution_role)
        {
            Position = citizen_institution_role.Position;

            ComboBoxInstitution.SelectedValue = citizen_institution_role.Institution.Id;

            LoadRoles(citizen_institution_role.Institution.Id);

            SelectRole(citizen_institution_role.Role.Id, citizen_institution_role.Role.InstitutionTemplateId);

            SelectVariation(citizen_institution_role.Variation.Id);

            CheckBoxActive.Checked = citizen_institution_role.IsActive;

            CheckBoxStartDefined.Checked = citizen_institution_role.IsStartDefined;

            if (citizen_institution_role.IsStartDefined)
            {
                DateTimePickerStart.Value = citizen_institution_role.StartedAt;
            }

            CheckBoxEndDefined.Checked = citizen_institution_role.IsEndDefined;

            if (citizen_institution_role.IsEndDefined)
            {
                DateTimePickerEnd.Value = citizen_institution_role.EndedAt;
            }
        }

        public TCitizenInstitutionRole GetValues()
        {
            GetSelectedRole(out int role_id, out string role_name, out int template_id, out bool is_template_role);
            GetSelectedVariation(out int variation_id, out string variation_name);

            return new TCitizenInstitutionRole()
            {
                Position = Position,
                Institution = new TInstitution()
                {
                    Id = (int)ComboBoxInstitution.SelectedValue,
                    Name = ComboBoxInstitution.Text,
                },
                Role = new TInstitutionRole()
                {
                    Id = role_id,
                    Name = role_name,
                    InstitutionTemplateId = template_id,
                },
                Variation = new TInstitutionRoleVariation()
                {
                    Id = variation_id,
                    Name = variation_name,
                },
                IsActive = CheckBoxActive.Checked,
                IsStartDefined = CheckBoxStartDefined.Checked,
                StartedAt = CheckBoxStartDefined.Checked ? DateTimePickerStart.Value.Date : default,
                IsEndDefined = CheckBoxEndDefined.Checked,
                EndedAt = CheckBoxEndDefined.Checked ? DateTimePickerEnd.Value.Date : default,
            };
        }

        private bool ValidateInput()
        {
            StringBuilder errors = new StringBuilder();

            if ((int)ComboBoxInstitution.SelectedValue == 0)
            {
                errors.AppendLine("Debe especificar la institución");
            }

            if ((int)ComboBoxRole.SelectedValue == 0 && Session.HasPermission("Ciudadanos.RolInstitucion.NoEspecificarRol") == false)
            {
                errors.AppendLine("Debe especificar el cargo");
            }

            if (CheckBoxStartDefined.Checked && CheckBoxEndDefined.Checked && DateTimePickerEnd.Value.Date < DateTimePickerStart.Value.Date)
            {
                errors.AppendLine("La fecha de fin no puede ser anterior a la fecha de inicio");
            }

            if (errors.Length > 0)
            {
                Utilities.ShowValidationErrorDialog(errors);
                return false;
            }

            return true;
        }

        private void UpdateNewRoleButtonState()
        {
            bool institution_selected = ComboBoxInstitution.SelectedValue is int id && id != 0;

            BAddRole.Enabled = institution_selected && AccessMode != FAccessMode.Read && Session.HasPermission("Instituciones.Roles.Crear");
        }

        private void UpdateNewRoleVariationButtonState()
        {
            bool role_selected = ComboBoxRole.SelectedValue is int id && id != 0;

            bool is_template_role = false;

            if (role_selected)
            {
                GetSelectedRole(out _, out _, out _, out is_template_role);
            }

            // template roles have no institution_roles row, and institution_role_variations.institution_role_id
            // is a NOT NULL FK to institution_roles(id), so variations can't be attached to them
            BAddRoleVariation.Enabled = role_selected && !is_template_role && AccessMode != FAccessMode.Read && Session.HasPermission("Instituciones.Roles.Crear");
        }

        private void ComboBoxInstitution_SelectedIndexChanged(object sender, EventArgs e)
        {
            int institution_id = ComboBoxInstitution.SelectedValue is int id ? id : 0;

            LoadRoles(institution_id);

            UpdateNewRoleButtonState();
        }

        private void ComboBoxRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadVariations();
        }

        private void CheckBoxStartDefined_CheckedChanged(object sender, EventArgs e)
        {
            DateTimePickerStart.Enabled = CheckBoxStartDefined.Checked && AccessMode != FAccessMode.Read;
        }

        private void CheckBoxEndDefined_CheckedChanged(object sender, EventArgs e)
        {
            DateTimePickerEnd.Enabled = CheckBoxEndDefined.Checked && AccessMode != FAccessMode.Read;
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

        private void BAddRole_Click(object sender, EventArgs e)
        {
            int institution_id = (int)ComboBoxInstitution.SelectedValue;

            using (FInstitutionRoleData role_dlg = new FInstitutionRoleData())
            {
                role_dlg.SetAccessMode(FAccessMode.Create);

                if (role_dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                TInstitutionRole role = role_dlg.GetValues();

                Error error = InstitutionsHandler.SaveInstitutionRole(institution_id, role);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                LoadRoles(institution_id);

                SelectRole(role.Id, role.InstitutionTemplateId);
            }
        }

        private void BAddRoleVariation_Click(object sender, EventArgs e)
        {
            int role_id = (int)ComboBoxRole.SelectedValue;

            using (FInstitutionRoleVariation variation_dlg = new FInstitutionRoleVariation())
            {
                variation_dlg.SetAccessMode(FAccessMode.Create);

                if (variation_dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                TInstitutionRoleVariation variation = variation_dlg.GetValues();

                Error error = InstitutionsHandler.SaveInstitutionRoleVariation(role_id, variation);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                RoleList[ComboBoxRole.SelectedIndex].Variation.Add(variation);

                LoadVariations();

                SelectVariation(variation.Id);
            }
        }
    }
}
