using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using System.IO;

public partial class AdminCP__UserControls_SMS_Users_Import_Export_ImportFromTextFile : System.Web.UI.UserControl
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        //---------------------------------------------------------------------------------------------
        lblSuccessfulyRecords.Text = "";
        lblNotMobileNumbers.Text = "";
        lblExistsMobileNumbers.Text = "";
        lblFailedMobileNumbers.Text = "";
        //----------------------------------------------------------------------------------------------
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
        if (fuFile.HasFile)
        {
            if (fuFile.PostedFile.ContentType == "text/plain")
            {
                string fileName = DCServer.MapPath(DCSiteUrls.GetPath_Sms_SMSFiles() + fuFile.FileName);
                fuFile.SaveAs(fileName);
                //---------------------------------------
                string[] mobileNumbersToImport = File.ReadAllLines(fileName);
                int count = 0;
                //---------------------------------------

                int successfullyNumbersCount = 0;
                string existsNumbers = "";
                int existsNumbersCount = 0;
                string failedNumbers = "";
                int failednumbersCount = 0;
                string notmobileNumbers = "";
                int notNumbersCount = 0;
                //---------------------------------------------------------------------
                //---------------------------------------------------------------------
                SMSNumbersEntity smsUser = new SMSNumbersEntity();
                //---------------------------------------------------------------------
                //props
                //---------------------------------------------------------------------
                Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
                if (SiteSettings.Languages_HasMultiLanguages)
                {
                    langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
                }
                //-------------------------------------------
                smsUser.LangID = langID;
                //-------------------------------------------
                smsUser.IsActive = cbIsActive.Checked;
                //-------------------------------------------
                if (ddlSmsGroups.SelectedValue != "-1")
                {
                    smsUser.GroupID = Convert.ToInt32(ddlSmsGroups.SelectedValue);
                }
                //---------------------------------------------------------------------
                char[] Splitter = { '-' };
                string[] record = null;
                string name = "";
                string number = "";
                bool isMobile = false;
                //---------------------------------------------------------------------
                ExecuteCommandStatus status;
                //---------------------------------------------------------------------
                foreach (string newRecord in mobileNumbersToImport)
                {
                    name = "";
                    number = "";
                    isMobile = false;
                    try
                    {
                        record = newRecord.Split(Splitter);
                        switch (record.Length)
                        {
                            case 1:
                                number = record[0].Trim();
                                isMobile = DCValidation.IsMobileNumber(number);
                                break;
                            case 2:
                                number = record[0].Trim();
                                name = record[1].Trim();
                                isMobile = DCValidation.IsMobileNumber(number);
                                break;
                            default:
                                break;
                        }
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
                    catch (Exception wx)
                    {
                        notmobileNumbers += newRecord + "<br>";
                        ++notNumbersCount;
                    }


                }
                //---------------------------------------------------------------------------------------------
                lblSuccessfulyRecords.Text = string.Format(Resources.SmsAdmin.ImportSuccessfulyCount, successfullyNumbersCount);
                lblNotMobileNumbers.Text = string.Format(Resources.SmsAdmin.NotImportNotNumbersCount, notNumbersCount) + " <br />" + notmobileNumbers;
                lblExistsMobileNumbers.Text = string.Format(Resources.SmsAdmin.NotImportAlradyExistCount, existsNumbersCount) + " <br />" + existsNumbers;
                lblFailedMobileNumbers.Text = string.Format(Resources.SmsAdmin.NotImportFailiarCount, failednumbersCount) + " <br />" + failedNumbers;
                //---------------------------------------------------------------------------------------------

            }
            else
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
        //--------------------------------------
    }
    #endregion
}