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

public partial class AdminSiteSettings_SpecialModulesSettings : MasterAdminMasterPage
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
            this.Page.Title = "≈⁄œ«œ«  «·„ÊœÌÊ·«  «·Œ«’…";
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
        cbMailList_HasMaillist.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasMaillist]);
        cbSms_HasSms.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasSms]);
        cbVote_Enabled.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Vote_Enabled]);
        cbSpecialModules_AdvertismentsEnabled.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_AdvertismentsEnabled]);
        cbSpecialModules_CitisEnabled.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_CitisEnabled]);
        cbSpecialModules_ShareLinksEnabled.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_ShareLinksEnabled]);
        cbSpecialModules_SecurityEnabled.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_SecurityEnabled]);
        cbSpecialModules_VisitorsCountEnabled.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_VisitorsCountEnabled]);
        cbSpecialModules_StatisticsEnabled.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_StatisticsEnabled]);
        cbSpecialModules_GoogleStatisticsEnabled.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_GoogleStatisticsEnabled]);
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
        //Special Modules Options
        SiteSettings.AllSiteSettings[SiteSettingItems.MailList_HasMaillist] = cbMailList_HasMaillist.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.Sms_HasSms] = cbSms_HasSms.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.Vote_Enabled] = cbVote_Enabled.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_AdvertismentsEnabled] = cbSpecialModules_AdvertismentsEnabled.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_CitisEnabled] = cbSpecialModules_CitisEnabled.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_ShareLinksEnabled] = cbSpecialModules_ShareLinksEnabled.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_SecurityEnabled] = cbSpecialModules_SecurityEnabled.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_VisitorsCountEnabled] = cbSpecialModules_VisitorsCountEnabled.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_StatisticsEnabled] = cbSpecialModules_StatisticsEnabled.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.SpecialModules_GoogleStatisticsEnabled] = cbSpecialModules_GoogleStatisticsEnabled.Checked;
        //----------------------------------------------------------------------------------------------------------------
        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";

    }
    //-----------------------------------------------
    #endregion

}

