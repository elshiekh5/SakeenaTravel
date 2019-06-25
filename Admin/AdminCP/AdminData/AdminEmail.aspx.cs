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

public partial class AdminEmailPage : AdminMasterPage
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
            this.Page.Title = Resources.AdmininstrationData.Page_AdminEmails;
            HandelControls();
            LoadData();
        }
    }
    //-----------------------------------------------
    #endregion
    #region ---------------HandelControls---------------
    //-----------------------------------------------
    //HandelControls
    //-----------------------------------------------
    protected void HandelControls()
    {
        trAdminEmail.Visible = SiteSettings.Admininstration_HasAdminEmail;
        trAdminBccEmail.Visible = SiteSettings.Admininstration_HasAdminBccEmail;
    }
    #endregion
    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        SiteSettingsFactory.LoadAllSettings();
        txtAdmininstration_AdminEmail.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Admininstration_AdminEmail];
        txtAdmininstration_AdminBccEmail.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Admininstration_AdminBccEmail];
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

        SiteSettings.AllSiteSettings[SiteSettingItems.Admininstration_AdminEmail] = txtAdmininstration_AdminEmail.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Admininstration_AdminBccEmail] = txtAdmininstration_AdminBccEmail.Text;
        SiteSettingsFactory.SaveAllSettingsCollections();

        lblResult.CssClass = "operation_done";
        lblResult.Text = Resources.AdminText.SavingDataSuccessfuly;
        //-----------------------------------------------------------
    }
    //-----------------------------------------------
    #endregion

}

