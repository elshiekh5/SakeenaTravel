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
            this.Page.Title = "≈⁄œ«œ«  «· ’ÊÌ ";
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
        //Vote Options
        cbVote_CloseDuplicateVotingByCookie.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Vote_CloseDuplicateVotingByCookie]);
        txtVote_MaxChoices.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Vote_MaxChoices];
        txtVote_ImageMaxLength.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Vote_ImageMaxLength];
        txtVote_ImageMinLength.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Vote_ImageMinLength];
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
        //Vote Options
        SiteSettings.AllSiteSettings[SiteSettingItems.Vote_CloseDuplicateVotingByCookie] = cbVote_CloseDuplicateVotingByCookie.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.Vote_MaxChoices] = txtVote_MaxChoices.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Vote_ImageMaxLength] = txtVote_ImageMaxLength.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Vote_ImageMinLength] = txtVote_ImageMinLength.Text;
        //----------------------------------------------------------------------------------------------------------------
        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";

    }
    //-----------------------------------------------
    #endregion

}

