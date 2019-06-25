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

public partial class AdminSiteSettings_Captcha : MasterAdminMasterPage
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
            this.Page.Title = "≈⁄œ«œ«  «·ﬂ«» ‘«";
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
        cbCaptcha_AllowInMessagesModules.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Captcha_AllowInMessagesModules]);
        cbCaptcha_AllowInSendComment.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Captcha_AllowInSendComment]);
        cbCaptcha_AllowInTellAFfiend.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Captcha_AllowInTellAFfiend]);
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
        SiteSettings.AllSiteSettings[SiteSettingItems.Captcha_AllowInMessagesModules] = cbCaptcha_AllowInMessagesModules.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.Captcha_AllowInSendComment] = cbCaptcha_AllowInSendComment.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.Captcha_AllowInTellAFfiend] = cbCaptcha_AllowInTellAFfiend.Checked;
        //----------------------------------------------------------------------------------------------------------------
        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";

    }
    //-----------------------------------------------
    #endregion

}

