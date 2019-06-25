using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using System.Data;
using System.Data.OleDb;

public partial class AdminCP__UserControls_SMS_Users_Import_Export_ImportFromExcelFile : System.Web.UI.UserControl
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {

            HandelControls();
        }
    }

    #endregion

    #region --------------Load_ddlSmsGroups()--------------
    //---------------------------------------------------------
    //Load_ddlSmsGroups
    //---------------------------------------------------------
    protected void Load_ddlSmsGroups()
    {
        List<SMSGroupsEntity> SmsGroupsList = SMSGroupsFactory.GetAllInList();
        OurDropDownList.LoadDropDownList<SMSGroupsEntity>(SmsGroupsList, ddlSmsGroups, "Name", "GroupID", true);

    }
    //--------------------------------------------------------
    #endregion

    

    #region ---------------HandelControls---------------
    //-----------------------------------------------
    //HandelControls
    //-----------------------------------------------
    protected void HandelControls()
    {
        #region ------------------Languages Handling---------------------
        //Languages Handling
        if (SiteSettings.Languages_HasMultiLanguages)
            SiteSettings.BuildDropDownListForDefaultPage(ddlLanguages);
        else
            trLanguages.Visible = false;
        #endregion
        //-------------------------------------------
        if (SiteSettings.Sms_HasGroups)
            Load_ddlSmsGroups();
        else
            trGroups.Visible = false;
        //-------------------------------------------
    }
    #endregion

    #region ---------------btnSave_Click---------------
    //-----------------------------------------------
    //btnSave_Click
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        if (FuFile.HasFile)
        {
            try
            {
                string FileName = DCServer.MapPath(DCSiteUrls.GetPath_Sms_SMSFiles() + FuFile.FileName);
                FuFile.SaveAs(FileName);
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + DCServer.MapPath(DCSiteUrls.GetPath_Sms_SMSFiles() + FuFile.FileName) + ";" + "Extended Properties=Excel 8.0;";

                // Create connection object by using the preceding connection string.
                OleDbConnection objConn = new OleDbConnection(sConnectionString);

                // Open connection with the database.
                objConn.Open();

                // The code to follow uses a SQL SELECT command to display the data from the worksheet.

                // Create new OleDbCommand to return data from worksheet.
                OleDbCommand objCmdSelect = new OleDbCommand("SELECT * FROM [Sheet1$]", objConn);

                // Create new OleDbDataAdapter that is used to build a DataSet
                // based on the preceding SQL SELECT statement.
                OleDbDataAdapter objAdapter1 = new OleDbDataAdapter();

                // Pass the Select command to the adapter.
                objAdapter1.SelectCommand = objCmdSelect;

                // Create new DataSet to hold information from the worksheet.
                DataSet objDataset1 = new DataSet();

                // Fill the DataSet with the information from the worksheet.
                objAdapter1.Fill(objDataset1, "XLData");
                //---------------------------------------------------------------------
                SMSNumbersEntity smsUser = new SMSNumbersEntity();
                //---------------------------------------------------------------------
                //props
                //---------------------------------------------------------------------
                Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
                if (SiteSettings.Languages_HasMultiLanguages)
                    langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
                //-----------------------
                smsUser.LangID = langID;
                //-----------------------
                if (SiteSettings.Sms_HasGroups)
                    smsUser.GroupID = Convert.ToInt32(ddlSmsGroups.SelectedValue);
                //-----------------------
                smsUser.ModuleTypeID = (int)StandardItemsModuleTypes.SMS;
                //-----------------------
                smsUser.IsActive = cbIsActive.Checked;
                //--------------------------------------

                int successfullyNumbersCount = 0;
                string existsNumbers = "";
                int existsNumbersCount = 0;
                string failedNumbers = "";
                int failednumbersCount = 0;
                string notmobileNumbers = "";
                int notNumbersCount = 0;
                //---------------------------------------------------------------------
                string newRecord = "";
                string name = "";
                string number = "";
                bool isMobile = false;
                //---------------------------------------------------------------------
                ExecuteCommandStatus status;
                //---------------------------------------------------------------------
                for (int i = 0; i < objDataset1.Tables[0].Rows.Count; i++)
                {

                    name = "";
                    number = "";
                    newRecord = "";
                    isMobile = false;
                    try
                    {
                        number = objDataset1.Tables[0].Rows[i].ItemArray[0].ToString();
                        name = objDataset1.Tables[0].Rows[i].ItemArray[1].ToString();
                        if (string.IsNullOrEmpty(name))
                        {
                            newRecord = number;
                        }
                        else
                        {
                            newRecord = number + " - " + name;
                        }
                        isMobile = DCValidation.IsMobileNumber(number);
                        if (isMobile)
                        {
                            smsUser.Numbers = number;
                            smsUser.Name = name;
                            status = SMSNumbersFactory.Create(smsUser);
                            switch (status)
                            {
                                case ExecuteCommandStatus.Done:
                                    ++successfullyNumbersCount;
                                    break;
                                case ExecuteCommandStatus.AllreadyExists:
                                    existsNumbers += newRecord + "<br>";
                                    ++existsNumbersCount;
                                    break;
                                case ExecuteCommandStatus.UnknownError:
                                    failedNumbers += newRecord + "<br>";
                                    ++failednumbersCount;
                                    break;
                                default:
                                    failedNumbers += newRecord + "<br>";
                                    ++failednumbersCount;
                                    break;
                            }
                        }
                        else
                        {
                            notmobileNumbers += newRecord + "<br>";
                            ++notNumbersCount;
                        }
                    }
                    catch (Exception ex2)
                    {
                        notmobileNumbers += newRecord + "<br>";
                        ++notNumbersCount;
                    }


                }
                objConn.Close();
                //---------------------------------------------------------------------------------------------
                lblSuccessfulyRecords.Text = string.Format(Resources.SmsAdmin.ImportSuccessfulyCount, successfullyNumbersCount);
                lblNotMobileNumbers.Text = string.Format(Resources.SmsAdmin.NotImportNotNumbersCount, notNumbersCount) + " <br />" + notmobileNumbers;
                lblExistsMobileNumbers.Text = string.Format(Resources.SmsAdmin.NotImportAlradyExistCount, existsNumbersCount) + " <br />" + existsNumbers;
                lblFailedMobileNumbers.Text = string.Format(Resources.SmsAdmin.NotImportFailiarCount, failednumbersCount) + " <br />" + failedNumbers;
                //---------------------------------------------------------------------------------------------
            }
            catch (Exception ex)
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = Resources.SmsAdmin.FileNotSupportedFile;
            }
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.SmsAdmin.FileNotFound;
        }
    }
    //-----------------------------------------
    #endregion

    private void ClearControls()
    {
        ddlLanguages.SelectedIndex = -1;
        ddlSmsGroups.SelectedIndex = -1;
        cbIsActive.Checked = false;
    }
    //-----------------------------------------------------------------
}