using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using System.Data.OleDb;
using System.Data;

public partial class AdminCP__UserControls_MailList_MailListUsers_Import_Export_ImportFromExcelFile : System.Web.UI.UserControl
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        //---------------------------------------------------------------------------------------------
        lblSuccessfulyMails.Text = "";
        lblNotMails.Text = "";
        lblExistsMails.Text = "";
        lblFailedMails.Text = "";
        //----------------------------------------------------------------------------------------------
        if (!IsPostBack)
        {
            HandelControls();
        }
    }

    #endregion

    #region --------------Load_ddlMailListGroups()--------------
    //---------------------------------------------------------
    //Load_ddlMailListGroups
    //---------------------------------------------------------
    protected void Load_ddlMailListGroups()
    {
        List<MailListGroupsEntity> mailListGroupsList = MailListGroupsFactory.GetAll();
        OurDropDownList.LoadDropDownList<MailListGroupsEntity>(mailListGroupsList, ddlMailListGroups, "Name", "GroupID", true);

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
        if (SiteSettings.MailList_HasGroups)
            Load_ddlMailListGroups();
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
        if (fuFile.HasFile)
        {
            try
            {
                string fileName = DCServer.MapPath(DCSiteUrls.GetPath_MailList_AttachmentDir() + fuFile.FileName);
                fuFile.SaveAs(fileName);
                String sConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + fileName + ";" + "Extended Properties=Excel 8.0;";

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
                ExecuteCommandStatus status;
                int successfullyMailsCount = 0;
                string existsMails = "";
                int existsMailsCount = 0;
                string failedMails = "";
                int failedMailsCount = 0;
                string notMails = "";
                int notMailsCount = 0;
                //---------------------------------------------------------------------
                MailListUsersEntity mailUser = new MailListUsersEntity();
                //---------------------------------------------------------------------
                //props
                //---------------------------------------------------------------------
                Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
                if (SiteSettings.Languages_HasMultiLanguages)
                {
                    langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
                }
                //------------------------------------------------
                mailUser.LangID = langID;
                //------------------------------------------------
                if (SiteSettings.MailList_HasGroups)
                {
                    mailUser.GroupID = Convert.ToInt32(ddlMailListGroups.SelectedValue);
                    mailUser.Groups = "#" + mailUser.GroupID + "#";
                }
                //------------------------------------------------
                mailUser.ModuleTypeID = (int)StandardItemsModuleTypes.MailList;
                //--------------------------------------
                mailUser.IsActive = cbIsActive.Checked;
                //--------------------------------------
                bool isEmail = false;
                string email = "";
                //--------------------------------------
                for (int i = 0; i < objDataset1.Tables[0].Rows.Count; i++)
                {
                    isEmail = false;
                    email = objDataset1.Tables[0].Rows[i].ItemArray[0].ToString();
                    try
                    {

                        isEmail = DCValidation.IsEmail(email);

                        if (isEmail)
                        {
                            mailUser.Email = email;
                            status = MailListUsersFactory.Create(mailUser);
                            switch (status)
                            {
                                case ExecuteCommandStatus.Done:
                                    ++successfullyMailsCount;
                                    break;
                                case ExecuteCommandStatus.AllreadyExists:
                                    existsMails += email + "<br>";
                                    ++existsMailsCount;
                                    break;
                                case ExecuteCommandStatus.UnknownError:
                                    failedMails += email + "<br>";
                                    ++failedMailsCount;
                                    break;
                                default:
                                    failedMails += email + "<br>";
                                    ++failedMailsCount;
                                    break;
                            }
                        }
                        else
                        {
                            notMails += email + "<br>";
                            ++notMailsCount;
                        }
                    }
                    catch (Exception ex)
                    {
                        notMails += email + "<br>";
                        ++notMailsCount;
                    }
                }
                objConn.Close();
                //---------------------------------------------------------------------------------------------
                lblSuccessfulyMails.Text = string.Format(Resources.MailListAdmin.ImportSuccessfulyCount, successfullyMailsCount);
                lblNotMails.Text = string.Format(Resources.MailListAdmin.NotImportNotMailsCount, notMailsCount) + " <br />" + notMails;
                lblExistsMails.Text = string.Format(Resources.MailListAdmin.NotImportAlradyExistCount, existsMailsCount) + " <br />" + existsMails;
                lblFailedMails.Text = string.Format(Resources.MailListAdmin.NotImportFailiarCount, failedMailsCount) + " <br />" + failedMails;
                //---------------------------------------------------------------------------------------------
                //ClearControls();
            }
            catch (Exception ex)
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = Resources.MailListAdmin.FileNotSupportedFile;
            }
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.MailListAdmin.FileNotFound;
        }
    }
    //-----------------------------------------
    #endregion
}