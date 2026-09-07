using Business;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using GCRM.Domain;
using GCRM.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GCRM
{
    /// <summary>
    /// Interaction logic for FExcelImport.xaml
    /// </summary>
    public partial class FExcelImportCitizens : Window
    {
        DataTable CitizensTable = new DataTable();

        DataTable DTInstitutions = new DataTable("DTInstitutions");
        DataTable DTInstitutionRoles = new DataTable("DTInstitutionRoles");

        List<TInstitutionRole> InstitutionRoleList = new List<TInstitutionRole>();

        int RecordIndex = 0;

        public FExcelImportCitizens()
        {
            InitializeComponent();

            // input table definition

            CitizensTable.Columns.Add("Name", typeof(string));
            CitizensTable.Columns.Add("PaternalName", typeof(string));
            CitizensTable.Columns.Add("MaternalName", typeof(string));
            CitizensTable.Columns.Add("Phone", typeof(string));
            CitizensTable.Columns.Add("PhoneExtension", typeof(string));
            CitizensTable.Columns.Add("Cellphone", typeof(string));
            CitizensTable.Columns.Add("InstitutionName", typeof(string));
            CitizensTable.Columns.Add("InstitutionRoleName", typeof(string));
            CitizensTable.Columns.Add("Sex", typeof(string));

            CitizensTable.Columns.Add("InstitutionId", typeof(int));
            CitizensTable.Columns.Add("InstitutionRoleId", typeof(int));

            DataGridInput.ItemsSource = CitizensTable.DefaultView;
            DataGridOutput.ItemsSource = CitizensTable.DefaultView;

            // institution / institution role combo boxes

            DTInstitutions.Columns.Add("id", typeof(int));
            DTInstitutions.Columns.Add("name", typeof(string));

            DTInstitutionRoles.Columns.Add("id", typeof(int));
            DTInstitutionRoles.Columns.Add("name", typeof(string));
            DTInstitutionRoles.Columns.Add("template_id", typeof(int));
            DTInstitutionRoles.Columns.Add("is_template_role", typeof(bool));

            CmbInstitution.ItemsSource = DTInstitutions.DefaultView;
            CmbInstitution.DisplayMemberPath = "name";
            CmbInstitution.SelectedValuePath = "id";

            CmbInstitutionRole.ItemsSource = DTInstitutionRoles.DefaultView;
            CmbInstitutionRole.DisplayMemberPath = "name";
            CmbInstitutionRole.SelectedValuePath = "id";

            CmbSex.ItemsSource = Catalogs.DTSex.DefaultView;
            CmbSex.DisplayMemberPath = "text";
            CmbSex.SelectedValuePath = "value";
            CmbSex.SelectedIndex = 0;

            LoadInstitutions();
            LoadInstitutionRoles(0);
        }

        private void OnClick_SelectFile(object sender, RoutedEventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
                dlg.Title = "Select an Excel File";

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    TbFilePath.Text = dlg.FileName;
                }
            }
        }

        private void OnChecked_SelStartRow(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownStartRow.IsEnabled = isChecked;
        }

        private void OnChecked_SelEndRow(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownEndRow.IsEnabled = isChecked;
        }

        private void OnChecked_SelColName(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownName.IsEnabled = isChecked;
        }

        private void OnChecked_SelColPaternalName(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownPaternalName.IsEnabled = isChecked;
        }

        private void OnChecked_SelColMaternalName(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownMaternalName.IsEnabled = isChecked;
        }

        private void OnChecked_SelColTelephone(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownTelephone.IsEnabled = isChecked;
        }

        private void OnChecked_SelColTelephoneExt(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownTelephoneExt.IsEnabled = isChecked;
        }

        private void OnChecked_SelColCellPhone(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownCellPhone.IsEnabled = isChecked;
        }

        private void OnChecked_SelColInstitution(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownInstitution.IsEnabled = isChecked;
        }

        private void OnChecked_SelColInstitutionRole(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownInstitutionRole.IsEnabled = isChecked;
        }

        private void OnChecked_SelColSex(object sender, RoutedEventArgs e)
        {
            bool isChecked = ((System.Windows.Controls.CheckBox)sender).IsChecked ?? false;

            UpDownSex.IsEnabled = isChecked;
        }

        private void OnClick_BtnNext(object sender, RoutedEventArgs e)
        {
            // this is sort of like a state machine, current state is determined by the current visible tab
            
            if (TabCtrl.SelectedItem == TabOrigin)
            {
                if (ValidateSettings() == false)
                    return;

                LoadInputData();

                TabCtrl.SelectedItem = TabReviewInput;

                BtnAbort.IsEnabled = true;
                BtnBack.IsEnabled = true;
                BtnNext.IsEnabled = true;
                BtnFinish.IsEnabled = false;
            }
            else if (TabCtrl.SelectedItem == TabReviewInput)
            {
                LoadCitizenData();

                TabCtrl.SelectedItem = TabAddCitizen;

                BtnAbort.IsEnabled = true;
                BtnBack.IsEnabled = true;
                BtnNext.IsEnabled = true;
                BtnFinish.IsEnabled = false;
            }
            else if (TabCtrl.SelectedItem == TabAddCitizen)
            {
                // update the current record in the data table with the values from the text boxes
                
                if (ValidateCitizenData() == false)
                    return;

                UpdateCitizenData();

                // increase the record index and check if we have reached the end of the data table

                RecordIndex++;

                if (RecordIndex >= CitizensTable.Rows.Count)
                {
                    // if we have reached the end of the data table, go to review output tab
                    
                    TabCtrl.SelectedItem = TabReviewOutput;
                    BtnAbort.IsEnabled = true;
                    BtnBack.IsEnabled = true;
                    BtnNext.IsEnabled = true;
                    BtnFinish.IsEnabled = false;
                    BtnNext.Content = "Iniciar importación";
                }
                else
                {
                    // else, go to the next record and update the text boxes with the values from the data table
                    
                    LoadCitizenData();
                }
            }
            else if (TabCtrl.SelectedItem == TabReviewOutput)
            {
                TabCtrl.SelectedItem = TabImport;
                BtnAbort.IsEnabled = false;
                BtnBack.IsEnabled = false;
                BtnNext.IsEnabled = false;
                BtnFinish.IsEnabled = false;
                BtnNext.Content = "Iniciar importación";

                // at this point the records have been reviewed individually, so they are ready to be created in the database

                List<TCitizen> citizensToImport = new List<TCitizen>();

                foreach (DataRow row in CitizensTable.Rows)
                {
                    TCitizen citizen = new TCitizen()
                    {
                        Name = row["Name"].ToString(),
                        PaternalName = row["PaternalName"].ToString(),
                        MaternalName = row["MaternalName"].ToString(),
                    };

                    citizen.InstitutionRole.Institution.Id = (int)row["InstitutionId"];
                    citizen.InstitutionRole.Institution.Name = row["InstitutionName"].ToString();
                    citizen.InstitutionRole.Role.Id = (int)row["InstitutionRoleId"];
                    citizen.InstitutionRole.Role.Name = row["InstitutionRoleName"].ToString();

                    citizensToImport.Add(citizen);
                }

                PbImport.Maximum = citizensToImport.Count;
                PbImport.Value = 0;

                Error error = CitizensHandler.ImportCitizens(citizensToImport, out string importLog, index =>
                {
                    PbImport.Value = index + 1;
                    LblImportProgress.Content = $"{index + 1} / {citizensToImport.Count}";
                });

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                }

                System.Windows.Forms.MessageBox.Show(importLog, "Log de importación", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.None);

                BtnFinish.IsEnabled = true;
            }
        }

        private void OnClick_BtnBack(object sender, RoutedEventArgs e)
        {
            if (TabCtrl.SelectedItem == TabReviewInput)
            {
                CitizensTable.Clear();

                TabCtrl.SelectedItem = TabOrigin;

                BtnAbort.IsEnabled = true;
                BtnBack.IsEnabled = false;
                BtnNext.IsEnabled = true;
                BtnFinish.IsEnabled = false;
            }
            else if (TabCtrl.SelectedItem == TabAddCitizen)
            {
                if (RecordIndex == 0)
                {
                    TabCtrl.SelectedItem = TabReviewInput;

                    BtnAbort.IsEnabled = true;
                    BtnBack.IsEnabled = true;
                    BtnNext.IsEnabled = true;
                    BtnFinish.IsEnabled = false;
                }
                else
                {
                    RecordIndex--;

                    LoadCitizenData();
                }
            }
            else if (TabCtrl.SelectedItem == TabReviewOutput)
            {
                RecordIndex = CitizensTable.Rows.Count - 1;
                
                LoadCitizenData();
                
                TabCtrl.SelectedItem = TabAddCitizen;
                
                BtnAbort.IsEnabled = true;
                BtnBack.IsEnabled = true;
                BtnNext.IsEnabled = true;
                BtnFinish.IsEnabled = false;
            }
            else if (TabCtrl.SelectedItem == TabReviewOutput)
            {
                BtnNext.Content = "Siguiente";
            }
        }

        private bool ValidateSettings()
        {
            StringBuilder errors = new StringBuilder();

            if (File.Exists(TbFilePath.Text) == false)
                errors.AppendLine(" El archivo seleccinado no fue encontrado");

            List<string> validExtensions = new List<string> { ".xls", ".xlsx", ".xlsm" };

            if (validExtensions.Contains(System.IO.Path.GetExtension(TbFilePath.Text).ToLower()) == false)
                errors.AppendLine(" El archivo seleccinado tiene un formato incorrecto");

            if (errors.Length > 0)
            {
                Utilities.ShowErrorDialog(errors.ToString());

                return false;
            } 

            return true;
        }

        private bool ValidateCitizenData()
        {
            TCitizen citizen = new TCitizen()
            {
                Name = TbName.Text.Trim(),
                PaternalName = TbPaternalName.Text.Trim(),
                MaternalName = TbMaternalName.Text.Trim()
            };

            Error error = CitizensHandler.ValidateCitizen(citizen, out List<string> errors);
            
            if (errors.Count > 0)
            {
                Utilities.ShowErrorDialog(string.Join("\n", errors));

                return false;
            }

            return true;
        }

        private void LoadInstitutions()
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

            CmbInstitution.SelectedIndex = 0;
        }

        private void LoadInstitutionRoles(int institution_id)
        {
            InstitutionRoleList = new List<TInstitutionRole>();

            if (institution_id != 0)
            {
                Error error = InstitutionsHandler.GetInstitutionById(institution_id, out TInstitution institution);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }

                error = InstitutionsHandler.GetInstitutionRoles(institution_id, institution.Template.Id, out InstitutionRoleList);

                if (error != 0)
                {
                    Utilities.ShowErrorDialog(error);
                    return;
                }
            }

            InstitutionRoleList.Insert(0, new TInstitutionRole()
            {
                Id = 0,
                Name = "Ninguno",
            });

            DTInstitutionRoles.BeginLoadData();
            DTInstitutionRoles.Clear();

            foreach (TInstitutionRole role in InstitutionRoleList)
            {
                DataRow row = DTInstitutionRoles.NewRow();

                row["id"] = role.Id;
                row["name"] = role.Name;
                row["template_id"] = role.InstitutionTemplateId;
                row["is_template_role"] = role.IsTemplateRole;

                DTInstitutionRoles.Rows.Add(row);
            }

            DTInstitutionRoles.EndLoadData();

            CmbInstitutionRole.SelectedIndex = 0;
        }

        private void CmbInstitution_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int institution_id = CmbInstitution.SelectedValue is int id ? id : 0;

            LoadInstitutionRoles(institution_id);
        }

        private void BAddInstitution_Click(object sender, RoutedEventArgs e)
        {
            using (FInstitutionData institution_dlg = new FInstitutionData())
            {
                institution_dlg.SetAccessMode(FAccessMode.Create);

                if (institution_dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }

                LoadInstitutions();

                CmbInstitution.SelectedValue = institution_dlg.GetId();
            }
        }

        private void BAddInstitutionRole_Click(object sender, RoutedEventArgs e)
        {
            int institution_id = CmbInstitution.SelectedValue is int id ? id : 0;

            if (institution_id == 0)
            {
                Utilities.ShowErrorDialog("Debe seleccionar una institución antes de agregar un cargo.");
                return;
            }

            using (FInstitutionRoleData role_dlg = new FInstitutionRoleData())
            {
                role_dlg.SetAccessMode(FAccessMode.Create);

                if (role_dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK)
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

                LoadInstitutionRoles(institution_id);

                CmbInstitutionRole.SelectedValue = role.Id;
            }
        }

        private void LoadCitizenData()
        {
            if (CitizensTable.Rows.Count == 0)
                return;

            DataRow currentRow = CitizensTable.Rows[RecordIndex];

            TbName.Text = currentRow["Name"].ToString();
            TbPaternalName.Text = currentRow["PaternalName"].ToString();
            TbMaternalName.Text = currentRow["MaternalName"].ToString();
            TbPhone.Text = currentRow["Phone"].ToString();
            TbPhoneExtension.Text = currentRow["PhoneExtension"].ToString();
            TbCellPhone.Text = currentRow["Cellphone"].ToString();

            Error error = Error.None;

            string institutionName = currentRow["InstitutionName"].ToString().Trim();

            CmbInstitution.SelectedValue = 0;

            if (institutionName != string.Empty)
            {
                error = InstitutionsHandler.GetInstitutionByName(institutionName, out TInstitution institution);

                if (error != 0)
                {
                    if (error == Error.InstitutionNotFound)
                    {
                        Utilities.ShowErrorDialog($"La institución '{institutionName}' no fue encontrada.");
                    }
                    else
                    {
                        Utilities.ShowErrorDialog(error);
                    }
                }
                else
                {
                    CmbInstitution.SelectedValue = institution.Id;
                }
            }

            string institutionRoleName = currentRow["InstitutionRoleName"].ToString().Trim();

            CmbInstitutionRole.SelectedValue = 0;

            if (institutionRoleName != string.Empty)
            {
                error = InstitutionsHandler.GetInstitutionRoleByName((int)CmbInstitution.SelectedValue, institutionRoleName, out TInstitutionRole role);

                if (error != 0)
                {
                    if (error == Error.InstitutionRoleNotFound)
                    {
                        Utilities.ShowErrorDialog($"El rol de institución '{institutionRoleName}' no fue encontrado para la institución seleccionada.");
                    }
                    else
                    { 
                        Utilities.ShowErrorDialog(error); 
                    }
                }
                else
                {
                    CmbInstitutionRole.SelectedValue = role.Id;
                }
            }

            string sexText = currentRow["Sex"].ToString().Trim();

            CmbSex.SelectedIndex = 0;

            if (sexText != string.Empty)
            {
                bool sexMatched = false;

                foreach (DataRowView sexRow in Catalogs.DTSex.DefaultView)
                {
                    if (string.Equals(sexRow["text"].ToString(), sexText, StringComparison.OrdinalIgnoreCase))
                    {
                        CmbSex.SelectedValue = sexRow["value"];
                        sexMatched = true;
                        break;
                    }
                }

                if (sexMatched == false)
                {
                    Utilities.ShowErrorDialog($"El sexo '{sexText}' no es válido.");
                }
            }

            LblCitizenInfo.Content = $"Información del Ciudadano - Registro {RecordIndex + 1} / {CitizensTable.Rows.Count}";
        }

        private void UpdateCitizenData()
        {
            if (CitizensTable.Rows.Count == 0)
                return;

            DataRow currentRow = CitizensTable.Rows[RecordIndex];

            currentRow["Name"] = TbName.Text;
            currentRow["PaternalName"] = TbPaternalName.Text;
            currentRow["MaternalName"] = TbMaternalName.Text;
            currentRow["Phone"] = TbPhone.Text;
            currentRow["PhoneExtension"] = TbPhoneExtension.Text;
            currentRow["Cellphone"] = TbCellPhone.Text;

            int institutionId = CmbInstitution.SelectedValue is int selectedInstitutionId ? selectedInstitutionId : 0;

            currentRow["InstitutionId"] = institutionId;
            currentRow["InstitutionName"] = institutionId != 0 && CmbInstitution.SelectedItem is DataRowView institutionRow ? institutionRow["name"].ToString() : string.Empty;

            int institutionRoleId = CmbInstitutionRole.SelectedValue is int selectedRoleId ? selectedRoleId : 0;

            currentRow["InstitutionRoleId"] = institutionRoleId;
            currentRow["InstitutionRoleName"] = institutionRoleId != 0 && CmbInstitutionRole.SelectedItem is DataRowView roleRow ? roleRow["name"].ToString() : string.Empty;

            currentRow["Sex"] = CmbSex.SelectedItem is DataRowView sexSelectedRow ? sexSelectedRow["text"].ToString() : string.Empty;
        }

        private void LoadInputData()
        {
            string filePath = TbFilePath.Text;
            int startRow = (int)UpDownStartRow.Value;
            int endRow = (int)UpDownEndRow.Value;
            int rowIndex = 0;
            int colIndex = 0;

            // open excel file and read data, using the configured columns and rows

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (SpreadsheetDocument document = SpreadsheetDocument.Open(stream, false))
                    {
                        WorkbookPart workbookPart = document.WorkbookPart;

                        Sheet sheet = workbookPart.Workbook.Descendants<Sheet>().FirstOrDefault();

                        WorksheetPart worksheetPart = (WorksheetPart)workbookPart.GetPartById(sheet.Id);

                        SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                        foreach (Row row in sheetData.Elements<Row>())
                        {
                            if (SelStartRow.IsChecked == true && rowIndex < startRow)
                            {
                                rowIndex++;
                                continue;
                            }

                            if (SelEndRow.IsChecked == true && rowIndex > endRow)
                            {
                                break;
                            }

                            DataRow dataRow = CitizensTable.NewRow();

                            colIndex = 0;

                            foreach (Cell cell in row.Elements<Cell>())
                            {
                                if (SelColName.IsChecked == true && colIndex == UpDownName.Value)
                                {
                                    dataRow["Name"] = ExcelUtilities.GetCellValueAsString(cell, workbookPart);
                                }
                                else if (SelColPaternalName.IsChecked == true && colIndex == UpDownPaternalName.Value)
                                {
                                    dataRow["PaternalName"] = ExcelUtilities.GetCellValueAsString(cell, workbookPart);
                                }
                                else if (SelColMaternalName.IsChecked == true && colIndex == UpDownMaternalName.Value)
                                {
                                    dataRow["MaternalName"] = ExcelUtilities.GetCellValueAsString(cell, workbookPart);
                                }
                                else if (SelColTelephone.IsChecked == true && colIndex == UpDownTelephone.Value)
                                {
                                    dataRow["Phone"] = ExcelUtilities.GetCellValueAsString(cell, workbookPart);
                                }
                                else if (SelColTelephoneExt.IsChecked == true && colIndex == UpDownTelephoneExt.Value)
                                {
                                    dataRow["PhoneExtension"] = ExcelUtilities.GetCellValueAsString(cell, workbookPart);
                                }
                                else if (SelColCellPhone.IsChecked == true && colIndex == UpDownCellPhone.Value)
                                {
                                    dataRow["Cellphone"] = ExcelUtilities.GetCellValueAsString(cell, workbookPart);
                                }
                                else if (SelColInstitution.IsChecked == true && colIndex == UpDownInstitution.Value)
                                {
                                    dataRow["InstitutionName"] = ExcelUtilities.GetCellValueAsString(cell, workbookPart);
                                }
                                else if (SelColInstitutionRole.IsChecked == true && colIndex == UpDownInstitutionRole.Value)
                                {
                                    dataRow["InstitutionRoleName"] = ExcelUtilities.GetCellValueAsString(cell, workbookPart);
                                }
                                else if (SelColSex.IsChecked == true && colIndex == UpDownSex.Value)
                                {
                                    dataRow["Sex"] = ExcelUtilities.GetCellValueAsString(cell, workbookPart);
                                }

                                colIndex++;
                            }

                            CitizensTable.Rows.Add(dataRow);

                            rowIndex++;
                        }

                        LblTotalRecords.Content = $"Se encontraron {CitizensTable.Rows.Count} registros. Asegurese que la información sea correcta y las columnas correspondan antes de continuar...";

                        RecordIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Utilities.ShowExceptionDialog(ex);
            }

            ColName.Visibility = SelColName.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            ColPaternalName.Visibility = SelColPaternalName.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            ColMaternalName.Visibility = SelColMaternalName.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            ColPhone.Visibility = SelColTelephone.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            ColPhoneExtension.Visibility = SelColTelephoneExt.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            ColCellphone.Visibility = SelColCellPhone.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            ColInstitutionName.Visibility = SelColInstitution.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            ColInstitutionRoleName.Visibility = SelColInstitutionRole.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            ColSex.Visibility = SelColSex.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void BtnAbort_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnFinish_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FExcelImportCitizensWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Utilities.ShowConfirmDialog("¿Está seguro que desea abortar el proceso y salir del asistente de importación? La información no guardada se perderá.") == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
