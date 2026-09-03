using Business;
using System.Data;
using System.Text;
using GCRM.Domain;
using GCRM.Domain.Enums;
using GCRM.Shared;

namespace GCRM
{
    public partial class FUserGroupData : Form
    {
        DataSet DSUserGroup;
        DataTable DTPermissions;
        BindingSource BSPermissions;

        FAccessMode Mode = FAccessMode.Create;

        int Id;

        public FUserGroupData()
        {
            InitializeComponent();

            LoadPermissions();

            DSUserGroup = new DataSet();

            DTPermissions = new DataTable("DTPermissions");
            DTPermissions.Columns.Add("id", typeof(int));
            DTPermissions.Columns.Add("name", typeof(string));
            DTPermissions.Columns.Add("permitted", typeof(bool));
            DSUserGroup.Tables.Add(DTPermissions);


            BSPermissions = new BindingSource();
            BSPermissions.DataSource = DTPermissions;

            DataGridPermissions.DataSource = BSPermissions;

            LoadDefaultPermissions();
        }

        private void LoadPermissions()
        {
            DataGridPermissions.Enabled = Session.HasPermission("Usuarios.Grupos.Permisos.Editar");

            if (Session.HasPermission("Usuarios.Grupos.Permisos.Consultar") == false)
            {
                TabControlUserGroup.TabPages.Remove(TabPermissions);
            }
        }

        public void LoadDefaultPermissions()
        {
            using (new CursorWait())
            {
                DTPermissions.BeginLoadData();
                DTPermissions.Clear();

                foreach (TUserPermission permission in UsersHandler.UserPermissionsCatalog)
                {
                    DataRow row = DTPermissions.NewRow();

                    row["id"] = permission.Id;
                    row["name"] = permission.Name;
                    row["permitted"] = false;

                    DTPermissions.Rows.Add(row);
                }

                DTPermissions.EndLoadData();
            }
        }

        public void SetAccessMode(FAccessMode mode)
        {
            Mode = mode;

            TBName.Enabled = Mode != FAccessMode.Read;
            DataGridPermissions.Enabled = (Mode != FAccessMode.Read) && Session.HasPermission("Usuarios.Grupos.Permisos.Editar");

            BAccept.Visible = Mode != FAccessMode.Read;
            BCancel.Text = Mode == FAccessMode.Read ? "&Cerrar" : "&Cancel";
        }

        public void SetId(int id)
        {
            using (new CursorWait())
            {
                Id = id;

                Error error = UsersHandler.GetUserGroupById(id, out TUserGroup user_group);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                TBName.Text = user_group.Name;

                DTPermissions.BeginLoadData();
                DTPermissions.Clear();

                foreach (TUserPermission permission in user_group.Permissions)
                {
                    DataRow row = DTPermissions.NewRow();

                    row["id"] = permission.Id;
                    row["name"] = permission.Name;
                    row["permitted"] = permission.Permited;

                    DTPermissions.Rows.Add(row);
                }

                DTPermissions.EndLoadData();
            }
        }

        private bool ValidateInput()
        {
            StringBuilder errors = new StringBuilder();

            if (TBName.Text.Trim().Length == 0)
            {
                errors.AppendLine("Debe especificar el nombre");
            }

            if (errors.Length > 0)
            {
                Utilities.ShowErrorDialog(errors.ToString());
                return false;
            }

            return true;
        }

        private void BAccept_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                return;
            }

            using (new CursorWait())
            {
                TUserGroup user_group = new TUserGroup();

                user_group.Id = Id;
                user_group.Name = TBName.Text;

                List<TUserPermission> permissions = new List<TUserPermission>();

                foreach (DataRow row in DTPermissions.Rows)
                {
                    TUserPermission permission = new TUserPermission();

                    permission.Id = (int)row["id"];
                    permission.Name = (string)row["name"];
                    permission.Permited = (bool)row["permitted"];

                    permissions.Add(permission);
                }

                user_group.Permissions = permissions;

                Error error = UsersHandler.SaveUserGroup(user_group, Mode == FAccessMode.Update);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void DataGridPermissions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TBName_TextChanged(object sender, EventArgs e)
        {
            if (BSPermissions == null)
            {
                return;
            }

            string search = TBName.Text.Trim().Replace("'", "''");

            if (search.Length == 0)
            {
                BSPermissions.RemoveFilter();
            }
            else
            {
                BSPermissions.Filter = $"name LIKE '%{search}%'";
            }
        }
    }
}
