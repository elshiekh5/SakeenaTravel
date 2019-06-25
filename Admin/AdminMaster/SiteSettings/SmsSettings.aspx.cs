using System;using DCCMSNameSpace;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;

public partial class AdminSiteSettings_Comments : MasterAdminMasterPage
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
            this.Page.Title = " ≈⁄œ«œ«  ÃÊ«· «·„Êﬁ⁄";
            LoadData();
        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        // old code
        SiteSettingsFactory.LoadAllSettings();
        //----------------------------------------------------------------------------------------------------------------
        //SMS
        //--------------------------------------------------------------------------------------------------------------------------------

        cbSms_HasGroups.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasGroups]);

        cbSms_HasArchive.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasArchive]);
        //Import---------------------------------------------
        cbSms_HasImportFromTxtFile.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasImportFromTxtFile]);

        cbSms_HasImportFromExcellFile.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasImportFromExcellFile]);

        //Export---------------------------------------------
        cbSms_HasExportToExcellFile.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasExportToExcellFile]);
        //--------------------------------------------------------------------------------------------------------------------------------
        
        string url = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Sms_URL];
        txtSms_URL.Text = Encryption.Decrypt(url);

        txtSms_AccountUserName.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Sms_AccountUserName];

        txtSms_AccountPassword.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Sms_AccountPassword];

        txtSms_Numbers.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Sms_Numbers];

        txtSms_Sender.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Sms_Sender];

        txtSms_Message.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Sms_Message];

        txtSms_SMSKey.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Sms_SMSKey];


        //----------------------------------------------------------------------------------------------------------------
       

    }
    //-----------------------------------------------
    #endregion

    #region ---------------Save---------------
    //-----------------------------------------------
    //Save
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        //------------------------------------------------------------------------------------------------------------
        //SMS
        //------------------------------------------------------------------------------------------------------------

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasGroups] = cbSms_HasGroups.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasArchive] = cbSms_HasArchive.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasImportFromTxtFile] = cbSms_HasImportFromTxtFile.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasImportFromExcellFile] = cbSms_HasImportFromExcellFile.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasExportToExcellFile] = cbSms_HasExportToExcellFile.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_URL] =Encryption.Encrypt(txtSms_URL.Text);

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_AccountUserName] = txtSms_AccountUserName.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_AccountPassword] = txtSms_AccountPassword.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_Numbers] = txtSms_Numbers.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_Sender] = txtSms_Sender.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_Message] = txtSms_Message.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_SMSKey] = txtSms_SMSKey.Text;

        //----------------------------------------------------------------------------------------------------------------
        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";
    }
    //-----------------------------------------------
    #endregion

}

