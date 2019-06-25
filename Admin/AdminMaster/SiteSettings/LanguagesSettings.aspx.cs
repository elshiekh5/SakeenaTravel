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
            this.Page.Title = "≈⁄œ«œ«  «··€« ";
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
        //Languages Options
        ddlDefaultLanguageID.SelectedValue  = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Languages_DefaultLanguageID];
        ddlAdminLanguageID.SelectedValue = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Languages_AdminLanguageID];
        //txtLanguages_LanguagesCount.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Languages_LanguagesCount];
        cbLanguages_HasArabicLanguages.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Languages_HasArabicLanguages]);
        cbLanguages_HasEnglishLanguages.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Languages_HasEnglishLanguages]);
        //----------------------------------------------------------------------------------------------------------------
    }//
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
        //----------------------------------------------------------------------------------------------------------------
        //Languages Options
        SiteSettings.AllSiteSettings[SiteSettingItems.Languages_DefaultLanguageID] = ddlDefaultLanguageID.SelectedValue;
        SiteSettings.AllSiteSettings[SiteSettingItems.Languages_AdminLanguageID] = ddlAdminLanguageID.SelectedValue;
        SiteSettings.AllSiteSettings[SiteSettingItems.Languages_HasArabicLanguages] = cbLanguages_HasArabicLanguages.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.Languages_HasEnglishLanguages] = cbLanguages_HasEnglishLanguages.Checked;
        //----------------------------------------------------------------------------------------------------------------
       
        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";

    }
    //-----------------------------------------------
    #endregion

}

