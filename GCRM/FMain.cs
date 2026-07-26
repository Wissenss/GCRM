using Business;
using Business.Business;
using Connection;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Reflection;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();

            LoadBirhdayList();
            LoadWarningList();
        }

        private void BUsers_Click(object sender, EventArgs e)
        {
            if (Session.HasPermission("Usuarios.Consultar"))
            {
                using (FUserList user_list_dlg = new FUserList())
                {
                    user_list_dlg.ShowDialog();
                }
            }
            else
            {
                using (FUserData user_data_dlg = new FUserData())
                {
                    user_data_dlg.SetAccessMode(FAccessMode.Update);
                    user_data_dlg.SetId(Session.User.Id);

                    if (user_data_dlg.ShowDialog() == DialogResult.OK)
                    {
                        //Session.Refresh();
                    }
                }
            }
        }

        private void RefreshStatusStrip()
        {
            LToolStripUsername.Text = $"Usuario: {Session.User.Username}";

            if (Session.User.Group.Id != 0)
                LToolStripUsername.Text += $" - {Session.User.Group.Name}";

            LToolStripServer.Text = $"Servidor: {ConnectionSettings.Host}:{ConnectionSettings.Port} - {ConnectionSettings.Database}";

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fileVersionInfo.ProductVersion;
            LToolstripVersion.Text = $"Versi�n: {version}";
        }

        private void LoadBirhdayList()
        {
            using (new CursorWait())
            {
                List<TCitizen> citizens_on_birthday;

                Error error = CitizensHandler.GetCitizensWhosBirhdayFallsOn(DateTime.Today, out citizens_on_birthday);

                if (error != 0)
                {
                    return;
                }

                BirthdayPanel.Visible = citizens_on_birthday.Count > 0;

                ListBoxBirhdays.Items.Clear();

                foreach (TCitizen citizen in citizens_on_birthday)
                {
                    ListBoxBirhdays.Items.Add($" - {citizen.Name} {citizen.PaternalName} {citizen.MaternalName}");
                }

                BirthdayPanelContent.MinimumSize = new Size(0, ListBoxBirhdays.ItemHeight * citizens_on_birthday.Count + 10);

                BirthdayPanel.Refresh();
            }
        }

        private void LoadWarningList()
        {
            using (new CursorWait())
            {
                Error error = CitizensHandler.GetAttentionRequiredCitizenCount(out int citizen_count);

                if (error != 0)
                    return;

                error = InstitutionsHandler.GetAttentionRequiredInstitutionCount(out int institution_count);

                if (error != 0)
                    return;

                WarningPanel.Visible = citizen_count > 0 || institution_count > 0;

                ListBoxWarnings.Items.Clear();

                if (citizen_count > 0)
                    if (citizen_count == 1)
                        ListBoxWarnings.Items.Add($" - {citizen_count} ciudadano requiere atención");
                    else
                        ListBoxWarnings.Items.Add($" - {citizen_count} ciudadanos requieren atención");

                if (institution_count > 0)
                    if (institution_count == 1)
                        ListBoxWarnings.Items.Add($" - {institution_count} institución requiere atención");
                    else        
                        ListBoxWarnings.Items.Add($" - {institution_count} instituciónes requieren atención");

                WarningPanelContent.MinimumSize = new Size(0, ListBoxWarnings.ItemHeight * ListBoxWarnings.Items.Count + 10);

                WarningPanel.Refresh();
            }
        }
        
        private void FMain_Load(object sender, EventArgs e)
        {
            RefreshStatusStrip();

            BUsers.Text = Session.HasPermission("Usuarios.Consultar") ? "&Usuarios" : "&Usuario";

            LoadPermissions();

            LoadSettings();
        }

        private void LoadSettings()
        {
            BackgroundImage.Image = null;

            byte[] raw_background_img = SettingsHandler.GetSetting<byte[]>("Interface.BackgroundImage", null, 0, false);

            if (raw_background_img != null)
            {
                using (MemoryStream ms = new MemoryStream(raw_background_img))
                {
                    BackgroundImage.Image = Image.FromStream(ms);
                }
            }

            SettingsUtilities.TryLoadTabControlConfiguration(TabControl, "main_tab_control");
            SettingsUtilities.TryLoadFormConfiguration(this, "main_form");
        }

        private void LoadPermissions()
        {
            using (new CursorWait())
            {
                BCitizens.Visible = Session.HasPermission("Ciudadanos.Consultar");
                BRelationships.Visible = Session.HasPermission("Ciudadanos.Relaciones.Consultar");
                BInstitutions.Visible = Session.HasPermission("Instituciones.Consultar");

                BCitizenNetworks.Visible = Session.HasPermission("Network.Consultar");

                BEmails.Visible = Session.HasPermission("Emails.Consultar");

                BQueries.Visible = Session.HasPermission("Queries.Run");

                BUserGroups.Visible = Session.HasPermission("Usuarios.Grupos.Consultar");

                BEventLog.Visible = Session.HasPermission("EventLog.Consultar");

                BBackup.Visible = Session.HasPermission("Backups.Consultar");

                BSync.Enabled = Session.User.CardDavSyncEnabled;

                if (Session.HasPermission("Network.Consultar") == false)
                {
                    TabControl.TabPages.Remove(TabElectoral);
                }
            }
        }

        private void FMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void BConnection_Click(object sender, EventArgs e)
        {
            using (FConnection connection_dl = new FConnection())
            {
                if (Session.HasPermission("Conexion.Editar"))
                {
                    connection_dl.SetAccessMode(FAccessMode.Update);
                }

                if (connection_dl.ShowDialog() == DialogResult.OK)
                {
                    RefreshStatusStrip();
                }
            }
        }

        private void BInstitutions_Click(object sender, EventArgs e)
        {
            using (FInstitutionList institution_list_dlg = new FInstitutionList())
            {
                institution_list_dlg.ShowDialog();

                LoadWarningList();
            }
        }

        private void BCitizens_Click(object sender, EventArgs e)
        {
            using (FCitizenList citizen_list_dlg = new FCitizenList())
            {
                citizen_list_dlg.ShowDialog();

                LoadWarningList();
            }
        }

        private void BAbout_Click(object sender, EventArgs e)
        {
            using (FAbout about_dlg = new FAbout())
            {
                about_dlg.ShowDialog();
            }
        }

        private void BCitizenNetworks_Click(object sender, EventArgs e)
        {
            using (FCitizenNetworkList citizen_network_list_dlg = new FCitizenNetworkList())
            {
                citizen_network_list_dlg.ShowDialog();
            }
        }

        private void BEmails_Click(object sender, EventArgs e)
        {
            using (FEmailList emails_dlg = new FEmailList())
            {
                emails_dlg.ShowDialog();
            }
        }

        private void BSettings_Click(object sender, EventArgs e)
        {
            using (FSettings setting_dlg = new FSettings())
            {
                if (setting_dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadSettings();
                }
            }
        }

        private void BQueries_Click(object sender, EventArgs e)
        {
            using (FQueries query_dlg = new FQueries())
            {
                query_dlg.ShowDialog();
            }
        }

        private void BEventLog_Click(object sender, EventArgs e)
        {
            using (FEventLog event_log_dlg = new FEventLog())
            {
                event_log_dlg.ShowDialog();
            }
        }

        private async void BSync_Click(object sender, EventArgs e)
        {
            if (Utilities.ShowConfirmDialog("�Est� seguro que desea sincronizar los contactos?") != DialogResult.Yes)
            {
                return;
            }

            using (FEmailSync email_sync_dlg = new FEmailSync())
            {
                email_sync_dlg.TextBoxCardDavURL.Text = Session.User.CardDavURL;
                email_sync_dlg.TextBoxUsername.Text = Session.User.CardDavUsername;
                email_sync_dlg.TextBoxPassword.Text = Session.User.CardDavPassword;

                email_sync_dlg.BSync_Click(this, null);
            }
        }

        private void BUserGroups_Click(object sender, EventArgs e)
        {
            using (FUserGroupList user_group_list_dlg = new FUserGroupList())
            {
                user_group_list_dlg.ShowDialog();
            }
        }

        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            SettingsUtilities.TrySaveTabControlConfiguration(TabControl, "main_tab_control");
            SettingsUtilities.TrySaveFormConfiguration(this, "main_form");
        }

        private void BRelationships_Click(object sender, EventArgs e)
        {
            using (FCitizenRelationshipList list_dlg = new FCitizenRelationshipList())
            {
                list_dlg.ShowDialog();
            }
        }

        private void BCitizenGroups_Click(object sender, EventArgs e)
        {
            using (FCitizenGroupList list_dlg = new FCitizenGroupList())
            {
                list_dlg.ShowDialog();
            }
        }

        private void BBackup_Click(object sender, EventArgs e)
        {
            using (FBackup backup_dlg = new FBackup())
            {
                backup_dlg.ShowDialog();
            }
        }
    }
}
