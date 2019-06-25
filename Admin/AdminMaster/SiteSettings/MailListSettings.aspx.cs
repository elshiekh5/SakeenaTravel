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
            this.Page.Title = "≈⁄œ«œ«  «·ﬁ«∆„… «·»—ÌœÌ…";
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
        //--------------------------------------------------------------------------------------------------------------------------------

        cbMailList_HasGroups.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasGroups]);

        cbMailList_HasArchive.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasArchive]);
        //Import---------------------------------------------
        cbMailList_HasImportFromTxtFile.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasImportFromTxtFile]);

        cbMailList_HasImportFromExcellFile.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasImportFromExcellFile]);

        //Export---------------------------------------------
        cbMailList_HasExportToExcellFile.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasExportToExcellFile]);

        //Design---------------------------------------------
        cbMailList_HasEmailDesign.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasEmailDesign]);

        //--------------------------------------------------------------------------------------------------------------------------------

        txtMailList_MailSMTP.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailSMTP];

        txtMailList_MailSMTPPort.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailSMTPPort];

        txtMailList_MailUserName.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailUserName];

        txtMailList_MailPassWord.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailPassWord];

        txtMailList_MailFrom.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailFrom];

        txtMailList_MailFromCon.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailFromCon];

        txtMailList_MailFromName.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailFromName];

        txtMailList_MailMaxNoOfTries.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailMaxNoOfTries];

        txtMailList_MaxBccCount.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MaxBccCount];

        txtMailList_SendingTo.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_SendingTo];

        cbMailList_HasAttachments.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasAttachments]);

        txtMailList_MaxAttachFilesCount.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MaxAttachFilesCount];

        txtMailList_MaxAllAttachSize.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MaxAllAttachSize];

        txtMailList_SendingIntervalBySeconds.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.MailList_SendingIntervalBySeconds];

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

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasGroups] = cbMailList_HasGroups.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasArchive] = cbMailList_HasArchive.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasImportFromTxtFile] = cbMailList_HasImportFromTxtFile.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasImportFromExcellFile] = cbMailList_HasImportFromExcellFile.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasExportToExcellFile] = cbMailList_HasExportToExcellFile.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasEmailDesign] = cbMailList_HasEmailDesign.Checked;

        //------------------------------------------------------------------------------------------------------------
        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailSMTP] = txtMailList_MailSMTP.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailSMTPPort] = txtMailList_MailSMTPPort.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailUserName] = txtMailList_MailUserName.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailPassWord] = txtMailList_MailPassWord.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailFrom] = txtMailList_MailFrom.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailFromCon] = txtMailList_MailFromCon.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailFromName] = txtMailList_MailFromName.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MailMaxNoOfTries] = txtMailList_MailMaxNoOfTries.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MaxBccCount] = txtMailList_MaxBccCount.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_SendingTo] = txtMailList_SendingTo.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasAttachments] = cbMailList_HasAttachments.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MaxAttachFilesCount] = txtMailList_MaxAttachFilesCount.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_MaxAllAttachSize] = txtMailList_MaxAllAttachSize.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_SendingIntervalBySeconds] = txtMailList_SendingIntervalBySeconds.Text;
        //----------------------------------------------------------------------------------------------------------------
        //-----------------------------------------------------------
        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";

    }
    //-----------------------------------------------
    #endregion

}

