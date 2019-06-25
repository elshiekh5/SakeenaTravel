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
            this.Page.Title = "»Ì«‰«  «·„Êﬁ⁄";
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
        //Site Options
        txtSite_SiteTitle.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Site_SiteTitle];
        txtSite_WebsiteDomain.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Site_WebsiteDomain];
        txtSite_AdminPageSize.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Site_AdminPageSize];
        cbSite_AllowDublicateTitles.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Site_AllowDublicateTitles]);
        txtSite_Comment.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Site_Comment];
        txtSite_WebsiteDesignFolder.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Site_WebsiteDesignFolder];
        cbSite_HasMultiLanguageDesign.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Site_HasMultiLanguageDesign]);
        cbSite_HasAdminMainImages.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Site_HasAdminMainImages]);
        txtSite_IpCountryService.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Site_IpCountryService];
        txtSite_IpWebServicePassword.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Site_IpWebServicePassword];
        //----------------------------------------------------------------------------------------------------------------
        txtSite_AdminUrl.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Site_AdminUrl];
        //----------------------------------------------------------------------------------------------------------------
        txtSite_CookieName.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Site_CookieName];
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
        //----------------------------------------------------------------------------------------------------------------
        //Site Options
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_SiteTitle] = txtSite_SiteTitle.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_WebsiteDomain] = txtSite_WebsiteDomain.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_AdminPageSize] = txtSite_AdminPageSize.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_AllowDublicateTitles] = cbSite_AllowDublicateTitles.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_Comment] = txtSite_Comment.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_WebsiteDesignFolder] = txtSite_WebsiteDesignFolder.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_HasMultiLanguageDesign] = cbSite_HasMultiLanguageDesign.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_HasAdminMainImages] = cbSite_HasAdminMainImages.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_IpCountryService] = txtSite_IpCountryService.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_IpWebServicePassword] = txtSite_IpWebServicePassword.Text;
        //----------------------------------------------------------------------------------------------------------------
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_AdminUrl] = txtSite_AdminUrl.Text;
        //--------------------------------------
        //----------------------------------------------------------------------------------------------------------------
        SiteSettings.AllSiteSettings[SiteSettingItems.Site_CookieName] = txtSite_CookieName.Text;
        //----------------------------------------------------------------------------------------------------------------
        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";

    }
    //-----------------------------------------------
    #endregion

}

