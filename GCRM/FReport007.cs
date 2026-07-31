using Business;
using GCRM.Domain;
using GCRM.Domain.Enums;
using QuestPDF.Fluent;
using Reporter;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GCRM
{
    public partial class FReport007 : Form
    {
        class EventItem
        {
            public TEventLogType Type;
            public string Name = "";

            public override string ToString() => Name;
        }

        DataSet DSFilters;
        DataTable DTUsers;
        DataTable DTUserGroups;

        public FReport007()
        {
            InitializeComponent();

            DSFilters = new DataSet();

            DTUsers = new DataTable();
            DTUsers.Columns.Add("id", typeof(int));
            DTUsers.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTUsers);

            DTUserGroups = new DataTable();
            DTUserGroups.Columns.Add("id", typeof(int));
            DTUserGroups.Columns.Add("name", typeof(string));
            DSFilters.Tables.Add(DTUserGroups);
        }

        List<TUser> AllUsers = new List<TUser>();

        void LoadCatalogs()
        {
            using (new CursorWait())
            {
                Error error = UsersHandler.GetUsers(out AllUsers);

                if (error != Error.None)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                DTUsers.BeginLoadData();
                DTUsers.Clear();

                foreach (TUser user in AllUsers)
                    DTUsers.Rows.Add(user.Id, user.Name);

                DTUsers.EndLoadData();

                Users.DataSource = DTUsers;
                Users.ValueMember = "id";
                Users.DisplayMember = "name";

                error = UsersHandler.GetUserGroups(out List<TUserGroup> user_groups);

                if (error != Error.None)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                DTUserGroups.BeginLoadData();
                DTUserGroups.Clear();

                foreach (TUserGroup user_group in user_groups)
                    DTUserGroups.Rows.Add(user_group.Id, user_group.Name);

                DTUserGroups.EndLoadData();

                UserGroups.DataSource = DTUserGroups;
                UserGroups.ValueMember = "id";
                UserGroups.DisplayMember = "name";

                List<EventItem> event_items = new List<EventItem>();

                foreach (TEventLogType type in Enum.GetValues(typeof(TEventLogType)))
                {
                    if (type == TEventLogType.unknown)
                        continue;

                    event_items.Add(new EventItem { Type = type, Name = GCRM.Shared.BConstants.GetEventLogTypeName(type) });
                }

                Events.Items.Clear();
                Events.Items.AddRange(event_items.ToArray());

                FechaInicial.Value = DateTime.Today.AddDays(-7);
                FechaFinal.Value = DateTime.Today;
            }
        }

        private void FReport007_Load(object sender, EventArgs e)
        {
            LoadCatalogs();
        }

        private void RadioUsers_CheckedChanged(object sender, EventArgs e)
        {
            Users.Visible = RadioUsers.Checked;
            UserGroups.Visible = RadioUsers.Checked == false;
        }

        List<int> GetCheckedIds(CheckedListBox list_box, string value_column)
        {
            List<int> ids = new List<int>();

            foreach (int index in list_box.CheckedIndices)
                ids.Add((int)((DataRowView)list_box.Items[index])[value_column]);

            return ids;
        }

        private bool TryBuildDocument(out R007Document document)
        {
            document = null;

            using CursorWait cursor_wait = new CursorWait();

            R007DocumentModel model = new R007DocumentModel();

            model.DateFrom = FechaInicial.Value.Date;
            model.DateTo = FechaFinal.Value.Date;

            if (model.DateFrom > model.DateTo)
            {
                MessageBox.Show("La fecha inicial no puede ser posterior a la fecha final.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool user_filter_applied;

            if (RadioUsers.Checked)
            {
                List<int> user_ids = GetCheckedIds(Users, "id");

                user_filter_applied = user_ids.Count > 0;

                model.Users = AllUsers.Where(u => user_ids.Contains(u.Id)).ToList();
            }
            else
            {
                List<int> group_ids = GetCheckedIds(UserGroups, "id");

                user_filter_applied = group_ids.Count > 0;

                model.UserGroups = DTUserGroups.Rows.Cast<DataRow>()
                    .Where(r => group_ids.Contains((int)r["id"]))
                    .Select(r => new TUserGroup { Id = (int)r["id"], Name = (string)r["name"] })
                    .ToList();

                model.Users = AllUsers.Where(u => group_ids.Contains(u.Group.Id)).ToList();
            }

            model.EventTypes = Events.CheckedItems.Cast<EventItem>().Select(i => i.Type).ToList();

            List<int> filter_user_ids = model.Users.Select(u => u.Id).ToList();

            // an explicit filter that resolves to no users (e.g. an empty group) must return nothing, not
            // everything, so we skip the query instead of sending an empty id list
            if (user_filter_applied && filter_user_ids.Count == 0)
            {
                model.Logs = new List<TEventLog>();
            }
            else
            {
                Error error = EventLogHandler.GetEventLogs(out model.Logs, filter_user_ids, model.EventTypes, model.DateFrom, model.DateTo.AddDays(1));

                if (error != Error.None)
                {
                    Utilities.ShowErrorDialog(error);
                    return false;
                }
            }

            document = new R007Document(model);

            return true;
        }

        private void BAccept_Click(object sender, EventArgs e)
        {
            if (TryBuildDocument(out R007Document document))
                document.GeneratePdfAndShow();
        }

        private void BExport_Click(object sender, EventArgs e)
        {
            if (TryBuildDocument(out R007Document document) == false)
                return;

            using SaveFileDialog dialog = new SaveFileDialog()
            {
                Filter = "Archivos PDF (*.pdf)|*.pdf",
                FileName = "R007_ActividadUsuarios.pdf"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                document.GeneratePdf(dialog.FileName);
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
