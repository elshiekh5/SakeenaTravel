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

public partial class AdminSiteSettings_AdmininstrationSettings : MasterAdminMasterPage
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
            this.Page.Title = "≈⁄œ«œ«  «·≈‘—«›";
            LoadData();
        }
    }
    //-----------------------------------------------
    #endregion

    #region --------------Load_ddlSystemCountries()--------------
    //---------------------------------------------------------
    //Load_ddlSystemCountries
    //---------------------------------------------------------
    protected void Load_ddlSystemCountries()
    {
        List<SystemCountriesEntity> SystemCountriesList = SystemCountriesFactory.GetAll();
        if (SystemCountriesList != null && SystemCountriesList.Count > 0)
        {
            ddlSystemCountries.DataSource = SystemCountriesList;
            ddlSystemCountries.DataTextField = "country_ar";
            ddlSystemCountries.DataValueField = "id";
            ddlSystemCountries.DataBind();
            // ddlSystemCountries.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
            ddlSystemCountries.Enabled = true;
        }
        else
        {
            ddlSystemCountries.Items.Clear();
            ddlSystemCountries.Items.Insert(0, new ListItem(Resources.AdminText.ThereIsNoData, "-1"));
            ddlSystemCountries.Enabled = false;
        }

    }
    //--------------------------------------------------------
    #endregion

    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        // old code
        SiteSettingsFactory.LoadAllSettings();
        Load_ddlSystemCountries();
        //--------------------------------------------------------------------------------------------------------------------------------
        cbAdmininstration_HasAdminEmail.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Admininstration_HasAdminEmail]);

        cbAdmininstration_HasAdminBccEmail.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Admininstration_HasAdminBccEmail]);
        //--------------------------------------------------------------------------------------------------------------------------------
        ddlSystemCountries.SelectedValue = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Admininstration_SiteDefaultCountryID];
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
        //------------------------------------------------------------------------------------------------------------

        SiteSettings.AllSiteSettings[SiteSettingItems.Admininstration_HasAdminEmail] = cbAdmininstration_HasAdminEmail.Checked;

        SiteSettings.AllSiteSettings[SiteSettingItems.Admininstration_HasAdminBccEmail] = cbAdmininstration_HasAdminBccEmail.Checked;
        //--------------------------------------------------------------------------------------------------------------------------------
        SiteSettings.AllSiteSettings[SiteSettingItems.Admininstration_SiteDefaultCountryID] = Convert.ToInt32(ddlSystemCountries.SelectedValue);
        //------------------------------------------------------------------------------------------------------------
        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";

    }
    //-----------------------------------------------
    #endregion

}

