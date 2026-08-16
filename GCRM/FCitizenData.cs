using Business;
using System.Data;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;
using WeCantSpell.Hunspell;

namespace GCRM
{
    public partial class FCitizenData : Form
    {
        DataSet DSCitizen;
        DataTable DTCitizens;
        DataTable DTCitizenRoles;
        DataTable DTCategories;
        DataTable DTRelationshipRoles;

        FAccessMode AccessMode = FAccessMode.Create;
        int Id;
        int AddressId;
        int RelationshipId;

        int Phone1Id;
        int Phone2Id;
        int Phone3Id;
        int CellphoneId;
        int PhoneSyncId;

        int VerificationAuthorId;

        public FCitizenData()
        {
            InitializeComponent();

            DSCitizen = new DataSet();

            DTCitizens = new DataTable("DTCitizens");
            DTCitizens.Columns.Add("id", typeof(int));
            DTCitizens.Columns.Add("name", typeof(string));
            DSCitizen.Tables.Add(DTCitizens);

            DTCitizenRoles = new DataTable("DTCitizenRoles");
            DTCitizenRoles.Columns.Add("position", typeof(int));
            DTCitizenRoles.Columns.Add("institution_id", typeof(int));
            DTCitizenRoles.Columns.Add("institution_name", typeof(string));
            DTCitizenRoles.Columns.Add("role_id", typeof(int));
            DTCitizenRoles.Columns.Add("role_name", typeof(string));
            DTCitizenRoles.Columns.Add("role_template_id", typeof(int));
            DTCitizenRoles.Columns.Add("variation_id", typeof(int));
            DTCitizenRoles.Columns.Add("variation_name", typeof(string));
            DTCitizenRoles.Columns.Add("is_active", typeof(bool));
            DTCitizenRoles.Columns.Add("is_start_defined", typeof(bool));
            DTCitizenRoles.Columns.Add("started_at", typeof(DateTime));
            DTCitizenRoles.Columns.Add("is_end_defined", typeof(bool));
            DTCitizenRoles.Columns.Add("ended_at", typeof(DateTime));
            DTCitizenRoles.Columns.Add("role_display", typeof(string));
            DSCitizen.Tables.Add(DTCitizenRoles);

            DataGridRoles.AutoGenerateColumns = false;

            int roles_display_index = 0;

            DataGridUtilities.AddColumn(DataGridRoles, "colPosition", "#", "position", true, roles_display_index++, 30, 25, DataGridViewAutoSizeColumnMode.None);
            DataGridUtilities.AddColumn(DataGridRoles, "colInstitution", "Institución", "institution_name", true, roles_display_index++, 180, 20, DataGridViewAutoSizeColumnMode.None);
            DataGridUtilities.AddColumn(DataGridRoles, "colRole", "Cargo", "role_display", true, roles_display_index++, 220, 40, DataGridViewAutoSizeColumnMode.None);
            DataGridUtilities.AddColumn(DataGridRoles, "colActive", "Activo", "is_active", true, roles_display_index++, 50, 20, DataGridViewAutoSizeColumnMode.None, DataGridColumnType.CheckBox);

            DataGridViewColumn start_date_column = DataGridUtilities.AddColumn(DataGridRoles, "colStartedAt", "Inicio", "started_at", true, roles_display_index++, 90, 20, DataGridViewAutoSizeColumnMode.None);
            start_date_column.DefaultCellStyle.Format = "d";

            DataGridViewColumn end_date_column = DataGridUtilities.AddColumn(DataGridRoles, "colEndedAt", "Fin", "ended_at", true, roles_display_index++, 90, 20, DataGridViewAutoSizeColumnMode.None);
            end_date_column.DefaultCellStyle.Format = "d";

            //DataGridUtilities.AddColumn(DataGridRoles, "colInstitutionId", "InstitutionId", "institution_id", false);
            //DataGridUtilities.AddColumn(DataGridRoles, "colRoleId", "RoleId", "role_id", false);
            //DataGridUtilities.AddColumn(DataGridRoles, "colRoleTemplateId", "RoleTemplateId", "role_template_id", false);
            //DataGridUtilities.AddColumn(DataGridRoles, "colVariationId", "VariationId", "variation_id", false);

            DataGridRoles.DataSource = DSCitizen;
            DataGridRoles.DataMember = DTCitizenRoles.TableName;
            DTCitizenRoles.DefaultView.Sort = "position";

            DTCategories = new DataTable("DTCategories");
            DTCategories.Columns.Add("id", typeof(int));
            DTCategories.Columns.Add("name", typeof(string));
            DTCategories.Columns.Add("description", typeof(string));
            DSCitizen.Tables.Add(DTCategories);

            DTRelationshipRoles = new DataTable("DTRelationshipRoles");
            DTRelationshipRoles.Columns.Add("id", typeof(int));
            DTRelationshipRoles.Columns.Add("name", typeof(string));
            DSCitizen.Tables.Add(DTRelationshipRoles);

            ComboBoxAssistant.DataSource = DTCitizens;
            ComboBoxAssistant.ValueMember = "id";
            ComboBoxAssistant.DisplayMember = "name";

            ComboBoxTitle.DataSource = Catalogs.DTCitizenTitles;
            ComboBoxTitle.ValueMember = "value";
            ComboBoxTitle.DisplayMember = "text";

            ComboBoxSex.DataSource = Catalogs.DTSex;
            ComboBoxSex.ValueMember = "value";
            ComboBoxSex.DisplayMember = "text";

            ComboBoxPoliticalParty.DataSource = Catalogs.DTPoliticalParties;
            ComboBoxPoliticalParty.ValueMember = "value";
            ComboBoxPoliticalParty.DisplayMember = "text";

            ComboBoxCountry.DataSource = Catalogs.DTCountries;
            ComboBoxCountry.ValueMember = "value";
            ComboBoxCountry.DisplayMember = "text";

            LAssitantName.Text = "";
            LAssistantPhone.Text = "";
            LAssitantCellphone.Text = "";

            LoadDTCitizens();
            LoadDTCategories();
            LoadDTRelationshipRoles();

            LoadPermissions();
            LoadBirthdayFields();

            PoliticalRegisterDate.Value = DateTime.Now;
        }

        private void LoadPermissions()
        {
            if (Session.HasPermission("Ciudadanos.Electoral.Consultar") == false)
            {
                TabControlCitizen.TabPages.Remove(TabElectoral);
            }

            if (Session.HasPermission("Ciudadanos.Relaciones.Personal.Consultar") == false)
            {
                TabControlCitizen.TabPages.Remove(TabRelationships);
            }
        }

        private void LoadDTCategories()
        {
            List<TCitizenCategory> categories;

            Error error = CitizensHandler.GetCitizenCategories(out categories);

            if (error != 0)
            {
                Utilities.ShowErrorDialog(error);
                return;
            }

            DTCategories.BeginLoadData();
            DTCategories.Clear();

            DataRow row = DTCategories.NewRow();

            row["id"] = 0;
            row["name"] = "Ninguna";
            row["description"] = "";

            DTCategories.Rows.Add(row);

            foreach (TCitizenCategory category in categories)
            {
                row = DTCategories.NewRow();

                row["id"] = category.Id;
                row["name"] = category.Name;
                row["description"] = category.Description;

                DTCategories.Rows.Add(row);
            }

            DTCategories.EndLoadData();

            ComboBoxCategory.DataSource = DTCategories;
            ComboBoxCategory.ValueMember = "id";
            ComboBoxCategory.DisplayMember = "name";
        }

        private void LoadDTCitizens()
        {
            using (new CursorWait())
            {
                List<TCitizen> citizen_list;

                Error error = CitizensHandler.GetCitizens(out citizen_list);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                DTCitizens.BeginLoadData();
                DTCitizens.Clear();

                DataRow row = DTCitizens.NewRow();

                row["id"] = 0;
                row["name"] = "Sin Asistente";

                DTCitizens.Rows.Add(row);

                foreach (TCitizen citizen in citizen_list)
                {
                    row = DTCitizens.NewRow();

                    row["id"] = citizen.Id;
                    row["name"] = citizen.Name;

                    DTCitizens.Rows.Add(row);
                }

                DTCitizens.EndLoadData();
            }
        }

        private void LoadDTRelationshipRoles()
        {
            using (new CursorWait())
            {
                Error error = CitizensHandler.GetCitizenRelationshipRoles(out List<TCitizenRelationshipRole> roles);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                roles.Insert(0, new TCitizenRelationshipRole()
                {
                    Id = 0,
                    Name = "Sin definir"
                });

                DTRelationshipRoles.BeginLoadData();
                DTRelationshipRoles.Clear();

                foreach (var role in roles)
                {
                    DataRow row = DTRelationshipRoles.NewRow();

                    row["id"] = role.Id;
                    row["name"] = role.Name;

                    DTRelationshipRoles.Rows.Add(row);
                }

                DTRelationshipRoles.EndLoadData();

                Relationship.DataSource = DTRelationshipRoles;
                Relationship.ValueMember = "id";
                Relationship.DisplayMember = "name";
                Relationship.SelectedValue = 0;
            }
        }

        public void SetAccessMode(FAccessMode mode)
        {
            AccessMode = mode;

            ComboBoxTitle.Enabled = AccessMode != FAccessMode.Read;
            TextBoxName.Enabled = AccessMode != FAccessMode.Read;
            TextBoxPaternalName.Enabled = AccessMode != FAccessMode.Read;
            TextBoxMaternalName.Enabled = AccessMode != FAccessMode.Read;
            ComboBoxSex.Enabled = AccessMode != FAccessMode.Read;

            KnownBirthday.Enabled = AccessMode != FAccessMode.Read;
            BDayMonth.Enabled = AccessMode != FAccessMode.Read;
            BDayDay.Enabled = AccessMode != FAccessMode.Read;
            BDayYear.Enabled = AccessMode != FAccessMode.Read;

            MaskedTextBoxCURP.Enabled = AccessMode != FAccessMode.Read;
            TextBoxObservations.Enabled = AccessMode != FAccessMode.Read;
            ComboBoxPoliticalParty.Enabled = AccessMode != FAccessMode.Read;

            TextBoxPhone.Enabled = AccessMode != FAccessMode.Read;
            TextBoxPhoneExtension.Enabled = AccessMode != FAccessMode.Read;
            Phone2.Enabled = AccessMode != FAccessMode.Read;
            Phone2Extension.Enabled = AccessMode != FAccessMode.Read;
            Phone3.Enabled = AccessMode != FAccessMode.Read;
            Phone3Extension.Enabled = AccessMode != FAccessMode.Read;

            TextBoxCellphone.Enabled = AccessMode != FAccessMode.Read;
            TextBoxEmail.Enabled = AccessMode != FAccessMode.Read;
            ComboBoxAssistant.Enabled = AccessMode != FAccessMode.Read;

            TextBoxStreet.Enabled = AccessMode != FAccessMode.Read;
            TextBoxNumber.Enabled = AccessMode != FAccessMode.Read;
            TextBoxInteriorNumber.Enabled = AccessMode != FAccessMode.Read;
            TextBoxCity.Enabled = AccessMode != FAccessMode.Read;
            TextBoxState.Enabled = AccessMode != FAccessMode.Read;
            TextBoxPostalCode.Enabled = AccessMode != FAccessMode.Read;
            ComboBoxCountry.Enabled = AccessMode != FAccessMode.Read;
            TextBoxDistrict.Enabled = AccessMode != FAccessMode.Read;

            DataGridRoles.Enabled = AccessMode != FAccessMode.Read;
            BAddRole.Enabled = AccessMode != FAccessMode.Read;
            BPositionUpRole.Enabled = AccessMode != FAccessMode.Read;
            BPositionDownRole.Enabled = AccessMode != FAccessMode.Read;
            UpdateRoleButtonsState();

            VoterCode.Enabled = AccessMode != FAccessMode.Read;
            VoterOCR.Enabled = AccessMode != FAccessMode.Read;
            VoterCIC.Enabled = AccessMode != FAccessMode.Read;
            VoterSection.Enabled = AccessMode != FAccessMode.Read;

            ComboBoxCategory.Enabled = AccessMode != FAccessMode.Read;

            PoliticalRegisterDate.Enabled = AccessMode != FAccessMode.Read;
            IsPoliticalActivist.Enabled = AccessMode != FAccessMode.Read;
            KnownPoliticalRegisterDate.Enabled = AccessMode != FAccessMode.Read;

            BGenerateCURP.Enabled = AccessMode != FAccessMode.Read;

            RelationshipEnabled.Enabled = AccessMode != FAccessMode.Read;
            Relationship.Enabled = AccessMode != FAccessMode.Read;
            NAffinity.Enabled = AccessMode != FAccessMode.Read;
            KnownStartDate.Enabled = AccessMode != FAccessMode.Read;
            KnownEndDate.Enabled = AccessMode != FAccessMode.Read;
            StartDate.Enabled = AccessMode != FAccessMode.Read;
            EndDate.Enabled = AccessMode != FAccessMode.Read;
            RelationshipNotes.Enabled = AccessMode != FAccessMode.Read;
            NumPriorityScore.Enabled = AccessMode != FAccessMode.Read;

            TelSyncEnabled.Enabled = AccessMode != FAccessMode.Read;
            PhoneSync.Enabled = AccessMode != FAccessMode.Read;
            PhoneSyncExtension.Enabled = AccessMode != FAccessMode.Read;

            Verified.Enabled = AccessMode != FAccessMode.Read;

            BAccept.Visible = AccessMode != FAccessMode.Read;
            BCancel.Text = AccessMode != FAccessMode.Read ? "&Cancelar" : "&Cerrar";
        }

        public void SetId(int id)
        {
            using (new CursorWait())
            {
                Id = id;

                TCitizen citizen;

                Error error = CitizensHandler.GetCitizenById(Id, out citizen);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                ComboBoxTitle.SelectedValue = citizen.Title;
                TextBoxName.Text = citizen.Name;
                TextBoxPaternalName.Text = citizen.PaternalName;
                TextBoxMaternalName.Text = citizen.MaternalName;
                ComboBoxSex.SelectedValue = citizen.Sex;

                KnownBirthday.Checked = citizen.KnownBirthday;

                if (KnownBirthday.Checked)
                {
                    BDayMonth.SelectedIndex = citizen.Birthday.Month - 1;
                    BDayDay.SelectedIndex = citizen.Birthday.Day - 1;

                    if (citizen.KnownBirthyear)
                        BDayYear.SelectedIndex = citizen.Birthday.Year - 1914 + 1;
                    else
                        BDayYear.SelectedIndex = 0;
                }

                MaskedTextBoxCURP.Text = citizen.CURP;
                TextBoxObservations.Text = citizen.Observations;
                ComboBoxPoliticalParty.SelectedValue = citizen.PoliticalParty;

                Phone1Id = citizen.Phone.Id;
                TextBoxPhone.Text = citizen.Phone.Number;
                TextBoxPhoneExtension.Text = citizen.Phone.Extension;
                Phone2Id = citizen.Phone.Id;
                Phone2.Text = citizen.Phone2.Number;
                Phone2Extension.Text = citizen.Phone2.Extension;
                Phone3Id = citizen.Phone.Id;
                Phone3.Text = citizen.Phone3.Number;
                Phone3Extension.Text = citizen.Phone3.Extension;
                CellphoneId = citizen.Cellphone.Id;
                TextBoxCellphone.Text = citizen.Cellphone.FullNumber;
                PhoneSyncId = citizen.CardDavSyncNumber.Id;
                PhoneSync.Text = citizen.CardDavSyncNumber.Number;
                PhoneSyncExtension.Text = citizen.CardDavSyncNumber.Extension;
                TelSyncEnabled.Checked = citizen.CardDavSyncNumber.CarddavSync;

                ComboBoxAssistant.SelectedValue = citizen.Assistant.Id;
                TextBoxEmail.Text = citizen.Email;

                AddressId = citizen.Address.Id;
                TextBoxStreet.Text = citizen.Address.Street;
                TextBoxNumber.Text = citizen.Address.Number;
                TextBoxInteriorNumber.Text = citizen.Address.InteriorNumber;
                TextBoxCity.Text = citizen.Address.City;
                TextBoxState.Text = citizen.Address.State;
                TextBoxPostalCode.Text = citizen.Address.PostalCode;
                ComboBoxCountry.SelectedValue = citizen.Address.Country;
                TextBoxDistrict.Text = citizen.Address.District;

                LoadCitizenRoleGrid(citizen);

                ComboBoxCategory.SelectedValue = citizen.Category.Id;

                VoterCode.Text = citizen.VoterCode;
                VoterOCR.Text = citizen.VoterOCR;
                VoterCIC.Text = citizen.VoterCIC;
                VoterSection.Text = citizen.VoterSection;

                PoliticalRegisterDate.Value = citizen.PoliticalRegisterDate;
                IsPoliticalActivist.Checked = citizen.IsPoliticalActivist;
                KnownPoliticalRegisterDate.Checked = citizen.KnownPoliticalRegisterDate;

                if (citizen.KnownPoliticalRegisterDate == false)
                    PoliticalRegisterDate.Value = DateTime.Now;

                IsPoliticalActivist_CheckedChanged(this, null);
                KnownPoliticalRegisterDate_CheckedChanged(this, null);

                RelationshipId = citizen.UserRelationship.Id;
                RelationshipEnabled.Checked = citizen.UserRelationship.Enabled;
                Relationship.SelectedValue = citizen.UserRelationship.Role.Id;
                NAffinity.Value = (decimal)citizen.UserRelationship.AffinityScore;
                KnownStartDate.Checked = citizen.UserRelationship.KnownStartDate;
                KnownEndDate.Checked = citizen.UserRelationship.KnownEndDate;
                RelationshipNotes.Text = citizen.UserRelationship.Notes;
                NumPriorityScore.Value = (decimal)citizen.UserRelationship.PriorityScore;

                if (citizen.UserRelationship.KnownStartDate)
                    StartDate.Value = citizen.UserRelationship.StartDate;
                else
                    StartDate.Value = DateTime.Now;

                if (citizen.UserRelationship.KnownEndDate)
                    EndDate.Value = citizen.UserRelationship.EndDate;
                else
                    EndDate.Value = DateTime.Now;

                RelationshipEnabled_CheckedChanged(this, null);
                KnownStartDate_CheckedChanged(this, null);
                KnownEndDate_CheckedChanged(this, null);

                VerificationAuthorId = citizen.VerifiedBy.Id;
                VerificationAuthor.Text = citizen.VerifiedBy.Name;
                VerificationDate.Value = citizen.Verified ? citizen.VerifiedAt : DateTime.Now;

                Verified.CheckedChanged -= Verified_CheckedChanged;
                Verified.Checked = citizen.Verified;
                Verified.CheckedChanged += Verified_CheckedChanged;

                Text = $"Ciudadano - {citizen.FullName}";
            }
        }

        private void LoadBirthdayFields()
        {
            BDayMonth.Items.Clear();
            BDayDay.Items.Clear();
            BDayYear.Items.Clear();

            for (int i = 0; i < 12; i++)
            {
                string raw_month_name = DateTimeFormatInfo.CurrentInfo.AbbreviatedMonthNames[i];

                BDayMonth.Items.Add(raw_month_name.ToUpper().First() + raw_month_name.Substring(1));
            }

            BDayMonth.SelectedIndex = 0;

            for (int i = 1; i <= 31; i++)
            {
                BDayDay.Items.Add(i.ToString());
            }

            BDayDay.SelectedIndex = 0;

            BDayYear.Items.Add("???");

            for (int i = 1914; i <= DateTime.Now.Year; i++)
            {
                BDayYear.Items.Add(i.ToString());
            }

            BDayYear.SelectedIndex = 0;
        }

        private void FCitizenData_Load(object sender, EventArgs e)
        {
        }

        private void ComboBoxTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TCitizenTitle title = (TCitizenTitle)ComboBoxTitle.SelectedValue;
                LTitleFull.Text = "- " + BConstants.GetCitizenFullTitle(title);
            }
            catch
            {

            }
        }

        private void ComboBoxAssistant_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = (int)ComboBoxAssistant.SelectedValue;

            if (id == 0)
            {
                LAssitantName.Text = "";
                LAssistantPhone.Text = "";
                LAssitantCellphone.Text = "";
            }
            else
            {
                TCitizen assistant;

                Error error = CitizensHandler.GetCitizenAssistantById(id, out assistant);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                LAssitantName.Text = $"{assistant.FullName}";
                LAssistantPhone.Text = $"{assistant.Phone.FullNumberWithPrefix}";
                LAssitantCellphone.Text = $"Cel. {assistant.Cellphone.FullNumber}";
            }
        }

        private void ComboBoxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TCountry country = (TCountry)ComboBoxCountry.SelectedValue;

                LCountryFullName.Text = "- " + BConstants.GetCountryOfficialName(country);
            }
            catch { }
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool ValidateInput()
        {
            StringBuilder errors = new StringBuilder();

            string curp = MaskedTextBoxCURP.Text.Trim().ToLower();
            string name = TextBoxName.Text.Trim().ToLower();
            string paternal_name = TextBoxPaternalName.Text.Trim().ToLower();
            string maternal_name = TextBoxMaternalName.Text.Trim().ToLower();
            DateTime birthday;
            TSex sex = (TSex)ComboBoxSex.SelectedValue;

            try
            {
                birthday = GetSelectedBirthday();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                errors.Append("La fecha de nacimiento seleccionada es inválida");
            }

            if (name.Length == 0)
            {
                errors.AppendLine("Debe especificar el nombre");
            }

            if (paternal_name.Length == 0)
            {
                errors.AppendLine("Debe especificar el apellido paterno");
            }

            // #39 - citizens with only one last name can't be saved
            //
            //if (maternal_name.Length == 0)
            //{
            //	errors.AppendLine("Debe especificar el apellido materno");
            //}

            if (sex == TSex.Unknown)
            {
                errors.AppendLine("Debe especificar el sexo");
            }

            // check for actions that requiere authorization
            List<TUserPermission> actions_to_authorize = new List<TUserPermission>();

            if (curp.Length == 0)
            {
                if (Session.HasPermission("Ciudadanos.NoEspecificarCURP") == false)
                {
                    actions_to_authorize.Add(new TUserPermission(313, "Ciudadanos.NoEspecificarCURP"));
                }
            }
            else if (curp.Length != 18)
            {
                errors.AppendLine("La longitud del CURP no es la adecuada. La clave CURP debe ser conformada por 18 dígitos");
            }
            else
            {
                string re_curp = @"^([A-Z][AEIOUX][A-Z]{2}\d{2}(?:0[1-9]|1[0-2])(?:0[1-9]|[12]\d|3[01])[HM](?:AS|B[CS]|C[CLMSH]|D[FG]|G[TR]|HG|JC|M[CNS]|N[ETL]|OC|PL|Q[TR]|S[PLR]|T[CSL]|VZ|YN|ZS)[B-DF-HJ-NP-TV-Z]{3}[A-Z\d])(\d)$";

                Regex rx = new Regex(re_curp, RegexOptions.Compiled | RegexOptions.IgnoreCase);

                if (rx.IsMatch(curp) == false)
                {
                    errors.Append("El CURP no es adecuado. Asegurese que cumple con el formato especificado por la RENAPO, por ejemplo: \"KOHI710516HTCFIB63\"");
                }
            }

            // TODO: validate congruence with citizen data #20

            //if (has_primary_role == false && Session.HasPermission("Ciudadanos.NoEspecificarInstitucion") == false)
            //{
            //    actions_to_authorize.Add(new TUserPermission(312, "Ciudadanos.NoEspecificarInstitucion"));
            //}

            if (DTCitizenRoles.Rows.Count == 0 && Session.HasPermission("Ciudadanos.NoEspecificarRolInstitucion") == false)
            {
                actions_to_authorize.Add(new TUserPermission(313, "Ciudadanos.NoEspecificarRolInstitucion"));
            }

            if (
                TextBoxPhone.Text.Trim().Length == 0 &&
                TextBoxCellphone.Text.Trim().Length == 0 &&
                Session.HasPermission("Ciudadanos.NoEspecificarContacto") == false
                )
            {
                actions_to_authorize.Add(new TUserPermission(311, "Ciudadanos.NoEspecificarContacto"));
            }

            // validate relationship
            if (RelationshipEnabled.Checked)
            {
                if ((int)Relationship.SelectedValue == 0)
                    errors.AppendLine("Debe especificar la relación");

                if (KnownStartDate.Checked && KnownEndDate.Checked && StartDate.Value > EndDate.Value)
                    errors.AppendLine("La fecha de inicio de la relación no pude ser posterior a la de término");
            }

            if (errors.Length > 0)
            {
                Utilities.ShowValidationErrorDialog(errors);
                return false;
            }

            if (actions_to_authorize.Count > 0)
            {
                using (FAuthorization authorization_dlg = new FAuthorization())
                {
                    authorization_dlg.RequieredPermissions = actions_to_authorize;

                    if (authorization_dlg.ShowDialog() != DialogResult.OK)
                    {
                        return false;
                    }
                }
            }

            // spell check - this is merely a warning, user may choose to ignore it
            {
                List<(string Word, SpellCheckResult Result, List<string> Suggestions)> spellErrors = new List<(string, SpellCheckResult, List<string>)>();

                spellErrors.AddRange(SpellUtilities.Check(TextBoxName.Text.Trim()));
                spellErrors.AddRange(SpellUtilities.Check(TextBoxMaternalName.Text.Trim()));
                spellErrors.AddRange(SpellUtilities.Check(TextBoxPaternalName.Text.Trim()));
                spellErrors.AddRange(SpellUtilities.Check(TextBoxObservations.Text.Trim()));

                if (spellErrors.Count > 0)
                {
                    StringBuilder spellErrorsText = new StringBuilder();

                    spellErrorsText.AppendLine("Se encontraron los siguientes errores de ortografía:");

                    foreach (var spellError in spellErrors)
                    {
                        spellErrorsText.AppendLine($"Palabra: {spellError.Word} - Sugerencias: {string.Join(", ", spellError.Suggestions)}");
                    }

                    spellErrorsText.AppendLine();
                    spellErrorsText.Append("¿Desea continuar de todas formas?");

                    if (Utilities.ShowConfirmDialog(spellErrorsText.ToString()) != DialogResult.Yes)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private DateTime GetSelectedBirthday()
        {
            return new DateTime(BDayYear.SelectedIndex == 0 ? 4 : BDayYear.SelectedIndex + 1914 - 1, BDayMonth.SelectedIndex + 1, BDayDay.SelectedIndex + 1);
        }

        private void BAccept_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                return;
            }

            DateTime now = DateTime.Now;

            using (new CursorWait())
            {
                TCitizen citizen = new TCitizen()
                {
                    Id = Id,
                    Title = (TCitizenTitle)ComboBoxTitle.SelectedValue,
                    Name = TextBoxName.Text.Trim(),
                    PaternalName = TextBoxPaternalName.Text.Trim(),
                    MaternalName = TextBoxMaternalName.Text.Trim(),
                    Sex = (TSex)ComboBoxSex.SelectedValue,
                    CURP = MaskedTextBoxCURP.Text.Trim().ToUpper(),
                    Observations = TextBoxObservations.Text.Trim(),
                    PoliticalParty = (TPoliticalParty)ComboBoxPoliticalParty.SelectedValue,

                    Email = TextBoxEmail.Text.Trim(),

                    Author = new TUser()
                    {
                        Id = Session.User.Id,
                    },

                    CreatedDate = now,

                    LastEditor = new TUser()
                    {
                        Id = Session.User.Id,
                    },
                    EditDate = now,

                    VoterCode = VoterCode.Text.Trim(),
                    VoterOCR = VoterOCR.Text.Trim(),
                    VoterCIC = VoterCIC.Text.Trim(),
                    VoterSection = VoterSection.Text.Trim(),

                    Category = new TCitizenCategory()
                    {
                        Id = (int)ComboBoxCategory.SelectedValue
                    },
                };

                FillCitizenInstitutionRoles(citizen);

                citizen.Phone.Id = Phone1Id;
                citizen.Phone.Number = TextBoxPhone.Text.Trim();
                citizen.Phone.Extension = TextBoxPhoneExtension.Text.Trim();
                citizen.Phone2.Id = Phone2Id;
                citizen.Phone2.Number = Phone2.Text.Trim();
                citizen.Phone2.Extension = Phone2Extension.Text.Trim();
                citizen.Phone3.Id = Phone3Id;
                citizen.Phone3.Number = Phone3.Text.Trim();
                citizen.Phone3.Extension = Phone3Extension.Text.Trim();
                citizen.Cellphone.Id = CellphoneId;
                citizen.Cellphone.Number = TextBoxCellphone.Text.Trim();
                citizen.CardDavSyncNumber.Id = PhoneSyncId;
                citizen.CardDavSyncNumber.Number = PhoneSync.Text.Trim();
                citizen.CardDavSyncNumber.Extension = PhoneSyncExtension.Text.Trim();
                citizen.CardDavSyncNumber.CarddavSync = TelSyncEnabled.Checked;

                citizen.KnownBirthday = KnownBirthday.Checked;
                citizen.KnownBirthyear = BDayYear.SelectedIndex != 0;
                citizen.Birthday = GetSelectedBirthday();

                citizen.IsPoliticalActivist = IsPoliticalActivist.Checked;
                citizen.KnownPoliticalRegisterDate = KnownPoliticalRegisterDate.Checked;
                citizen.PoliticalRegisterDate = PoliticalRegisterDate.Value;

                citizen.Verified = Verified.Checked;
                citizen.VerifiedAt = VerificationDate.Value;
                citizen.VerifiedBy = new TUser()
                {
                    Id = VerificationAuthorId
                };

                citizen.Assistant = new TCitizen();

                if (ComboBoxAssistant.SelectedValue != null)
                {
                    citizen.Assistant.Id = (int)ComboBoxAssistant.SelectedValue;
                }

                citizen.Address = new TAddress()
                {
                    Id = AddressId,
                    Street = TextBoxStreet.Text.Trim(),
                    Number = TextBoxNumber.Text.Trim(),
                    InteriorNumber = TextBoxInteriorNumber.Text.Trim(),
                    City = TextBoxCity.Text.Trim(),
                    State = TextBoxState.Text.Trim(),
                    PostalCode = TextBoxPostalCode.Text.Trim(),
                    Country = (TCountry)ComboBoxCountry.SelectedValue,
                    District = TextBoxDistrict.Text.Trim(),
                };

                citizen.UserRelationship = new TCitizenRelationship()
                {
                    Id = RelationshipId,
                    Citizen = new TCitizen()
                    {
                        Id = Session.User.Citizen.Id,
                    },
                    RelatedTo = new TCitizen()
                    {
                        Id = Id,
                    },
                    Role = new TCitizenRelationshipRole()
                    {
                        Id = Relationship.SelectedValue as int? ?? 0
                    },
                    AffinityScore = (double)NAffinity.Value,
                    KnownStartDate = KnownStartDate.Checked,
                    KnownEndDate = KnownEndDate.Checked,
                    StartDate = StartDate.Value,
                    EndDate = EndDate.Value,
                    Notes = RelationshipNotes.Text.Trim(),
                    User = Session.User,
                    Enabled = RelationshipEnabled.Checked,
                    PriorityScore = (double)NumPriorityScore.Value,
                };

                Error error = CitizensHandler.SaveCitizen(citizen, AccessMode == FAccessMode.Update);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void LoadCitizenRoleGrid(TCitizen citizen)
        {
            DTCitizenRoles.BeginLoadData();
            DTCitizenRoles.Clear();

            AddCitizenRoleRowIfSet(citizen.InstitutionRole);
            AddCitizenRoleRowIfSet(citizen.InstitutionRole2);
            AddCitizenRoleRowIfSet(citizen.InstitutionRole3);

            DTCitizenRoles.EndLoadData();

            UpdateRoleButtonsState();
        }

        private void AddCitizenRoleRowIfSet(TCitizenInstitutionRole citizen_role)
        {
            if (citizen_role.Institution.Id == 0)
            {
                return;
            }

            DataRow row = DTCitizenRoles.NewRow();

            FillCitizenRoleRow(row, citizen_role);

            DTCitizenRoles.Rows.Add(row);
        }

        private void FillCitizenRoleRow(DataRow row, TCitizenInstitutionRole citizen_role)
        {
            row["position"] = citizen_role.Position;
            row["institution_id"] = citizen_role.Institution.Id;
            row["institution_name"] = citizen_role.Institution.Name;
            row["role_id"] = citizen_role.Role.Id;
            row["role_name"] = citizen_role.Role.Name;
            row["role_template_id"] = citizen_role.Role.InstitutionTemplateId;
            row["variation_id"] = citizen_role.Variation.Id;
            row["variation_name"] = citizen_role.Variation.Name;
            row["role_display"] = citizen_role.DisplayName;
            row["is_active"] = citizen_role.IsActive;
            row["is_start_defined"] = citizen_role.IsStartDefined;
            row["started_at"] = citizen_role.IsStartDefined ? citizen_role.StartedAt : DateTime.MinValue;
            row["is_end_defined"] = citizen_role.IsEndDefined;
            row["ended_at"] = citizen_role.IsEndDefined ? citizen_role.EndedAt : DateTime.MinValue;
        }

        private TCitizenInstitutionRole RowToCitizenRole(DataRow row)
        {
            return new TCitizenInstitutionRole()
            {
                Position = (int)row["position"],
                Institution = new TInstitution()
                {
                    Id = (int)row["institution_id"],
                    Name = (string)row["institution_name"],
                },
                Role = new TInstitutionRole()
                {
                    Id = (int)row["role_id"],
                    Name = (string)row["role_name"],
                    InstitutionTemplateId = (int)row["role_template_id"],
                },
                Variation = new TInstitutionRoleVariation()
                {
                    Id = (int)row["variation_id"],
                    Name = (string)row["variation_name"],
                },
                IsActive = (bool)row["is_active"],
                IsStartDefined = (bool)row["is_start_defined"],
                StartedAt = (DateTime)row["started_at"],
                IsEndDefined = (bool)row["is_end_defined"],
                EndedAt = (DateTime)row["ended_at"],
            };
        }

        private void FillCitizenInstitutionRoles(TCitizen citizen)
        {
            citizen.InstitutionRole = new TCitizenInstitutionRole() { Position = 1 };
            citizen.InstitutionRole2 = new TCitizenInstitutionRole() { Position = 2 };
            citizen.InstitutionRole3 = new TCitizenInstitutionRole() { Position = 3 };

            foreach (DataRow row in DTCitizenRoles.Rows)
            {
                TCitizenInstitutionRole citizen_role = RowToCitizenRole(row);

                switch (citizen_role.Position)
                {
                    case 1:
                        citizen.InstitutionRole = citizen_role;
                        break;
                    case 2:
                        citizen.InstitutionRole2 = citizen_role;
                        break;
                    case 3:
                        citizen.InstitutionRole3 = citizen_role;
                        break;
                }
            }
        }

        private void RenumberCitizenRoles()
        {
            int position = 1;

            foreach (DataRow row in DTCitizenRoles.Select("", "position"))
            {
                row["position"] = position;
                position++;
            }
        }

        private void UpdateRoleButtonsState()
        {
            bool has_selection = DataGridRoles.SelectedRows.Count > 0;

            BAddRole.Enabled = DTCitizenRoles.Rows.Count < 3 && AccessMode != FAccessMode.Read && Session.HasPermission("Ciudadanos.RolInstitucion.Crear");
            BEditRole.Enabled = has_selection && AccessMode != FAccessMode.Read && Session.HasPermission("Ciudadanos.RolInstitucion.Editar");
            BDeleteRole.Enabled = has_selection && AccessMode != FAccessMode.Read && Session.HasPermission("Ciudadanos.RolInstitucion.Eliminar");

            bool can_move = has_selection && AccessMode != FAccessMode.Read;

            BPositionUpRole.Enabled = can_move;
            BPositionDownRole.Enabled = can_move;
        }

        private void DataGridRoles_SelectionChanged(object sender, EventArgs e)
        {
            UpdateRoleButtonsState();
        }

        private void DataGridRoles_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = DataGridRoles.Columns[e.ColumnIndex];

            if ((column.Name == "colStartedAt" || column.Name == "colEndedAt") && e.Value is DateTime date && date == DateTime.MinValue)
            {
                e.Value = "";
                e.FormattingApplied = true;
            }

            DataGridViewRow row = DataGridRoles.Rows[e.RowIndex];

            if (row.Cells["colActive"].Value is bool is_active && is_active == false)
            {
                e.CellStyle.Font = new Font(DataGridRoles.Font, FontStyle.Italic);
                e.CellStyle.ForeColor = Color.Gray;
                e.CellStyle.SelectionForeColor = Color.Gray;
            }
        }

        private void BAddRole_Click(object sender, EventArgs e)
        {
            if (DTCitizenRoles.Rows.Count >= 3)
            {
                StringBuilder errors = new StringBuilder();

                errors.AppendLine("Un ciudadano no puede tener más de 3 cargos");

                Utilities.ShowValidationErrorDialog(errors);
                return;
            }

            using (FCitizenInstitutionRoleData dlg = new FCitizenInstitutionRoleData())
            {
                dlg.SetAccessMode(FAccessMode.Create);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TCitizenInstitutionRole citizen_role = dlg.GetValues();

                    citizen_role.Position = DTCitizenRoles.Rows.Count + 1;

                    DataRow row = DTCitizenRoles.NewRow();

                    FillCitizenRoleRow(row, citizen_role);

                    DTCitizenRoles.Rows.Add(row);

                    UpdateRoleButtonsState();
                }
            }
        }

        private void BEditRole_Click(object sender, EventArgs e)
        {
            if (DataGridRoles.SelectedRows.Count == 0)
            {
                return;
            }

            DataRowView row_view = (DataRowView)DataGridRoles.SelectedRows[0].DataBoundItem;

            TCitizenInstitutionRole citizen_role = RowToCitizenRole(row_view.Row);

            using (FCitizenInstitutionRoleData dlg = new FCitizenInstitutionRoleData())
            {
                dlg.SetAccessMode(AccessMode);
                dlg.SetValues(citizen_role);

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    TCitizenInstitutionRole updated_citizen_role = dlg.GetValues();

                    updated_citizen_role.Position = citizen_role.Position;

                    row_view.Row.BeginEdit();

                    FillCitizenRoleRow(row_view.Row, updated_citizen_role);

                    row_view.Row.EndEdit();
                }
            }
        }

        private void BDeleteRole_Click(object sender, EventArgs e)
        {
            if (DataGridRoles.SelectedRows.Count == 0)
            {
                return;
            }

            if (Utilities.ShowConfirmDialog("¿Desea eliminar el cargo seleccionado?") != DialogResult.Yes)
            {
                return;
            }

            DataRowView row_view = (DataRowView)DataGridRoles.SelectedRows[0].DataBoundItem;

            row_view.Row.Delete();

            // purge the deleted row now: FillCitizenInstitutionRoles iterates DTCitizenRoles.Rows directly,
            // which (unlike Select()/DefaultView) still includes rows in the Deleted state
            DTCitizenRoles.AcceptChanges();

            RenumberCitizenRoles();

            UpdateRoleButtonsState();
        }

        private void MoveSelectedRole(int direction)
        {
            if (DataGridRoles.SelectedRows.Count == 0)
            {
                return;
            }

            DataRowView row_view = (DataRowView)DataGridRoles.SelectedRows[0].DataBoundItem;

            int current_position = (int)row_view.Row["position"];
            int target_position = current_position + direction;

            if (target_position < 1 || target_position > DTCitizenRoles.Rows.Count)
            {
                return;
            }

            foreach (DataRow row in DTCitizenRoles.Rows)
            {
                if ((int)row["position"] == target_position)
                {
                    row["position"] = current_position;
                    break;
                }
            }

            row_view.Row["position"] = target_position;
        }

        private void BPositionUpRole_Click(object sender, EventArgs e)
        {
            MoveSelectedRole(-1);
        }

        private void BPositionDownRole_Click(object sender, EventArgs e)
        {
            MoveSelectedRole(1);
        }

        private void LCURP_Click(object sender, EventArgs e)
        {
            string url = "https://www.gob.mx/curp/";

            Utilities.OpenUrl(url);
        }

        private void FCitizenData_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                BCancel_Click(this, null);
            }
        }

        private void IsPoliticalActivist_CheckedChanged(object sender, EventArgs e)
        {
            KnownPoliticalRegisterDate.Enabled = IsPoliticalActivist.Checked && AccessMode != FAccessMode.Read;
            PoliticalRegisterDate.Enabled = IsPoliticalActivist.Checked && KnownPoliticalRegisterDate.Checked && AccessMode != FAccessMode.Read;

            PoliticalRegisterDate.Refresh();
        }

        private void BGenerateCURP_Click(object sender, EventArgs e)
        {
            string paternal_name = TextBoxPaternalName.Text.Trim().ToLower();
            string maternal_name = TextBoxMaternalName.Text.Trim().ToLower();
            string name = TextBoxName.Text.Trim().ToLower();
            DateTime bday = GetSelectedBirthday();
            TSex sex = (TSex)ComboBoxSex.SelectedValue;

            // validate necessary inputs
            StringBuilder errors = new StringBuilder();

            if (paternal_name.Length == 0)
                errors.AppendLine("Debe especificar el apellido paterno");

            if (maternal_name.Length == 0)
                errors.AppendLine("Debe especificar el apellido materno");

            if (name.Length == 0)
                errors.AppendLine("Debe especificar el nombre");

            if (sex == TSex.Unknown)
                errors.AppendLine("Debe especificar el sexo");

            if (errors.Length > 0)
            {
                Utilities.ShowValidationErrorDialog(errors);
                return;
            }

            // if the curp is allready provided, confirm action before overwriting
            if (MaskedTextBoxCURP.Text.Trim().Length > 0)
            {
                if (Utilities.ShowConfirmDialog("¿Desea volver a generar la clave CURP? Este proceso remplazará la ya existente") != DialogResult.Yes)
                {
                    return;
                }
            }

            // generate the actual curp
            // in conformance with https://sre.gob.mx/component/phocadownload/category/2-marco-normativo?download=1116:instructivo-normativo-para-la-asignacion-de-la-clave-unica-de-registro-de-poblacion-dof-18-10-2021-texto-vigente

            char[] curp = new char[18];

            // 1 - letra inicial del primer apellido
            curp[0] = paternal_name.First();

            // 2 - primera vocal interna del primer apellido
            curp[1] = 'X';

            foreach (char letter in paternal_name.Trim().Substring(1))
            {
                if (Utilities.IsVowel(letter))
                {
                    curp[1] = letter;
                    break;
                }
            }

            // 3 - letra inicial del segundo apellido
            curp[2] = maternal_name.First();

            // 4 - primera letra del nombre
            curp[3] = name.First();

            // 5 - penultimo digito del año de nacimiento // si no se conoce se esta dejando como 0 por convencion
            curp[4] = '0';

            if (BDayYear.SelectedIndex != 0)
            {
                curp[4] = (char)(bday.Year.ToString()[bday.Year.ToString().Length - 2]);
            }

            // 6 - ultimo digito del año de nacimiento // si no se conoce se esta dejando como 0 por convencion
            curp[5] = '0';

            if (BDayYear.SelectedIndex != 0)
            {
                curp[4] = (char)(bday.Year.ToString().Last());
            }

            // 7 - primer digito del mes de nacimiento, cuando es menor a 10 se pone un 0
            curp[6] = bday.Month < 10 ? '0' : bday.Month.ToString().First();

            // 8 segundo digito del mes de nacimiento
            curp[7] = bday.Month.ToString().Last();

            // 9 primer digito del día de nacimiento, cuando es menor a 10 se pone un 0
            curp[8] = bday.Day < 10 ? '0' : bday.Day.ToString().First();

            // 10 segundo digito del dia de nacimiento
            curp[9] = bday.Day.ToString().Last();

            // 11 - sexo: H para hombre, M para mujer
            curp[10] = sex == TSex.Female ? 'M' : 'H';

            // 12, 13 - lugar de nacimiento codificado en dos posiciones codificado conforme al catálogo de la CURP // este se esta dejando en AS por convención
            curp[11] = 'A';
            curp[12] = 'S';

            // 14 - primera consonante interna del primer apellido
            curp[13] = 'X';

            foreach (char letter in paternal_name.Substring(1))
            {
                if (!Utilities.IsVowel(letter))
                {
                    curp[13] = letter;
                    break;
                }
            }

            // 15 - primera consonante interna del segundo apellido
            curp[14] = 'X';

            foreach (char letter in maternal_name.Substring(1))
            {
                if (!Utilities.IsVowel(letter))
                {
                    curp[14] = letter;
                    break;
                }
            }

            // 16 - primera consonante interna del nombre
            curp[15] = 'X';

            foreach (char letter in name.Substring(1))
            {
                if (!Utilities.IsVowel(letter))
                {
                    curp[15] = letter;
                    break;
                }
            }

            // 17 - caracter diferenciador, shalala shalala // por convencion este se deja en 0
            curp[16] = '0';

            // 18 - caracter verificador, shalala shalala // por convenvion se deja en 0
            curp[17] = '0';

            MaskedTextBoxCURP.Text = (new string(curp)).ToUpper();
        }

        private void KnownBirthday_CheckedChanged(object sender, EventArgs e)
        {
            BDayMonth.Enabled = KnownBirthday.Checked && AccessMode != FAccessMode.Read;
            BDayDay.Enabled = KnownBirthday.Checked && AccessMode != FAccessMode.Read;
            BDayYear.Enabled = KnownBirthday.Checked && AccessMode != FAccessMode.Read;
        }

        private void KnownPoliticalRegisterDate_CheckedChanged(object sender, EventArgs e)
        {
            PoliticalRegisterDate.Enabled = KnownPoliticalRegisterDate.Checked && IsPoliticalActivist.Checked && AccessMode != FAccessMode.Read;

            PoliticalRegisterDate.Refresh();
        }

        private void RelationshipEnabled_CheckedChanged(object sender, EventArgs e)
        {
            Relationship.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
            NAffinity.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
            KnownStartDate.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
            StartDate.Enabled = RelationshipEnabled.Checked && KnownStartDate.Checked && AccessMode != FAccessMode.Read;
            KnownEndDate.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
            EndDate.Enabled = RelationshipEnabled.Checked && KnownEndDate.Checked && AccessMode != FAccessMode.Read;
            RelationshipNotes.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
            NumPriorityScore.Enabled = RelationshipEnabled.Checked && AccessMode != FAccessMode.Read;
        }

        private void KnownStartDate_CheckedChanged(object sender, EventArgs e)
        {
            StartDate.Enabled = KnownStartDate.Checked && AccessMode != FAccessMode.Read && RelationshipEnabled.Checked;
        }

        private void KnownEndDate_CheckedChanged(object sender, EventArgs e)
        {
            EndDate.Enabled = KnownEndDate.Checked && AccessMode != FAccessMode.Read && RelationshipEnabled.Checked;
        }

        private void Verified_CheckedChanged(object sender, EventArgs e)
        {
            if (Verified.Checked == true)
            {
                if (Utilities.ShowConfirmDialog("¿Desea marcar este ciudadano como verificado? \n\n Al hacer esto asume la responsabilidad en la veracidad del registro") != DialogResult.Yes)
                {
                    Verified.Checked = false;

                    return;
                }

                VerificationAuthorId = Session.User.Id;
                VerificationAuthor.Text = Session.User.Name;
                VerificationDate.Value = DateTime.Now;
            }
        }
    }
}
