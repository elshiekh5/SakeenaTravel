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

public partial class AdminSiteSettings_OtherLinks : AdminMasterPage
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
            this.Page.Title = Resources.SocialLinks.SocialLinksModuleTitle;
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
        txtOtherLinks_Facebook.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.OtherLinks_Facebook];

        txtOtherLinks_Twitter.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.OtherLinks_Twitter];

        txtOtherLinks_YouTube.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.OtherLinks_YouTube];

        txtOtherLinks_LinkedIn.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.OtherLinks_LinkedIn];

        txtOtherLinks_GooglePlus.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.OtherLinks_GooglePlus];
        

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

        SiteSettings.AllSiteSettings[SiteSettingItems.OtherLinks_Facebook] = txtOtherLinks_Facebook.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.OtherLinks_Twitter] = txtOtherLinks_Twitter.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.OtherLinks_YouTube] = txtOtherLinks_YouTube.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.OtherLinks_LinkedIn] = txtOtherLinks_LinkedIn.Text;
        
        SiteSettings.AllSiteSettings[SiteSettingItems.OtherLinks_GooglePlus] = txtOtherLinks_GooglePlus.Text;
        
        //-----------------------------------------------------------
        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = Resources.AdminText.SavingDataSuccessfuly;

    }
    //-----------------------------------------------
    #endregion

}

