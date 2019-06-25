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
            this.Page.Title = "≈⁄œ«œ«  «· ⁄·Ìﬁ« ";
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
        txtComments_AllowDays.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Comments_AllowDays];

        txtComments_RefuseLimmets.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Comments_RefuseLimmets];

        cbComments_Enable.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Comments_Enable]);

        txtComments_CommentsPerPage.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Comments_CommentsPerPage];

       cbComments_HasCommentTitle.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Comments_HasCommentTitle]);

        cbComments_HasCountry.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Comments_HasCountry]);

        cbComments_HasSenderEmail.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Comments_HasSenderEmail]);
        //--------------------------------------------------------------------------------------------------------------------------------

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
        //-----------------------------------------------------------
        SiteSettings.AllSiteSettings[SiteSettingItems.Comments_AllowDays] = txtComments_AllowDays.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.Comments_RefuseLimmets] = txtComments_RefuseLimmets.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.Comments_Enable] = cbComments_Enable.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.Comments_CommentsPerPage] = txtComments_CommentsPerPage.Text;

        SiteSettings.AllSiteSettings[SiteSettingItems.Comments_HasCommentTitle] = cbComments_HasCommentTitle.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.Comments_HasCountry] = cbComments_HasCountry.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.Comments_HasSenderEmail] = cbComments_HasSenderEmail.Checked;

        //-----------------------------------------------------------
        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";

    }
    //-----------------------------------------------
    #endregion

}

