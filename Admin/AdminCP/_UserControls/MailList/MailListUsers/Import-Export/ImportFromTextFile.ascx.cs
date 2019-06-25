using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using System.IO;

public partial class AdminCP__UserControls_MailList_MailListUsers_Import_Export_ImportFromTextFile : System.Web.UI.UserControl
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

    #region ---------------SaveData---------------
    //-----------------------------------------------
    //SaveData
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        //--------------------------------------
        if (fuNumbers.HasFile)
        {
            if (fuNumbers.PostedFile.ContentType == "text/plain")
            {
                string fileName = DCServer.MapPath(DCSiteUrls.GetPath_MailList_AttachmentDir() + fuNumbers.FileName);
                fuNumbers.SaveAs(fileName);
                //---------------------------------------
                string[] mailsToImport = File.ReadAllLines(fileName);
                int count = 0;
                //---------------------------------------

                int successfullyMailsCount = 0;
                string existsMails = "";
                int existsMailsCount = 0;
                string failedMails = "";
                int failedMailsCount = 0;
                string notMails = "";
                int notMailsCount = 0;
                //---------------------------------------------------------------------
                MailListUsersEntity mailUser = new MailListUsersEntity();
                ExecuteCommandStatus status;
                //---------------------------------------------------------------------
                //props
                //---------------------------------------------------------------------
                Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
                if (SiteSettings.Languages_HasMultiLanguages)
                {
                    langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
                }
                //-------------------------------------------
                mailUser.LangID = langID;
                //-------------------------------------------
                mailUser.IsActive = cbIsActive.Checked;
                //-------------------------------------------
                if (ddlMailListGroups.SelectedValue != "-1")
                {
                    mailUser.GroupID = Convert.ToInt32(ddlMailListGroups.SelectedValue);
                    mailUser.Groups = "#" + mailUser.GroupID + "#";
                }
                //---------------------------------------------------------------------
                bool isEmail = false;
                //---------------------------------------------------------------------
                foreach (string email in mailsToImport)
                {
                    try
                    {

                        isEmail = false;
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
                //---------------------------------------------------------------------------------------------
                lblSuccessfulyMails.Text = string.Format(Resources.MailListAdmin.ImportSuccessfulyCount, successfullyMailsCount);
                lblNotMails.Text = string.Format(Resources.MailListAdmin.NotImportNotMailsCount, notMailsCount) + " <br />" + notMails;
                lblExistsMails.Text = string.Format(Resources.MailListAdmin.NotImportAlradyExistCount, existsMailsCount) + " <br />" + existsMails;
                lblFailedMails.Text = string.Format(Resources.MailListAdmin.NotImportFailiarCount, failedMailsCount) + " <br />" + failedMails;
                //---------------------------------------------------------------------------------------------

            }
            else
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
        //--------------------------------------
    }
    #endregion

}