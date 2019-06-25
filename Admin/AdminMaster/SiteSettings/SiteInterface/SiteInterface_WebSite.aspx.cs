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

public partial class SiteInterface_WebSite : MasterAdminMasterPage
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
            this.Page.Title = "≈⁄œ«œ«  «·⁄—÷ ··„Êﬁ⁄";
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
        //SiteInterface Options 
        cbSiteInterface_HasWebsiteBaseControls.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.SiteInterface_HasWebsiteBaseControls]);
        txtSiteInterface_InnerWebsiteWidth.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.SiteInterface_InnerWebsiteWidth];
        //----------------------------------------------------------------------------------------------------------------
        //Photos Options
        txtPhotos_WebSite_MicroThumnailWidth.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_MicroThumnailWidth];
        txtPhotos_WebSite_MicroThumnailHeight.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_MicroThumnailHeight];
        txtPhotos_WebSite_MiniThumnailWidth.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_MiniThumnailWidth];
        txtPhotos_WebSite_MiniThumnailHeight.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_MiniThumnailHeight];
        txtPhotos_WebSite_NormalThumnailWidth.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_NormalThumnailWidth];
        txtPhotos_WebSite_NormalThumnailHeight.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_NormalThumnailHeight];
        txtPhotos_WebSite_BigThumnailWidth.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_BigThumnailWidth];
        txtPhotos_WebSite_BigThumnailHeight.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_BigThumnailHeight];
        //----------------------------------------------------------------------------------------------------------------
        txtPhotos_PhotosAvailbleExtensions.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_PhotosAvailbleExtensions];
        txtPhotos_WebSite_VListWidth.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_VListWidth];
        txtPhotos_WebSite_VListHeight.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_VListHeight];
        txtPhotos_WebSite_HListWidth.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_HListWidth];
        txtPhotos_WebSite_HListHeight.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_HListHeight];
        txtPhotos_WebSite_DetailsPageWidth.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_DetailsPageWidth];
        txtPhotos_WebSite_DetailsPageHeight.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_DetailsPageHeight];
        cbPhotos_SavePhotoDimensions.Checked = Convert.ToBoolean(SiteSettings.AllSiteSettings[SiteSettingItems.Photos_SavePhotoDimensions]);
        //---------------------------------------
       

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
        //SiteInterface Options
        SiteSettings.AllSiteSettings[SiteSettingItems.SiteInterface_HasWebsiteBaseControls] = cbSiteInterface_HasWebsiteBaseControls.Checked;
        SiteSettings.AllSiteSettings[SiteSettingItems.SiteInterface_InnerWebsiteWidth] = txtSiteInterface_InnerWebsiteWidth.Text;
        //----------------------------------------------------------------------------------------------------------------
        //Photos Options
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_MicroThumnailWidth] = txtPhotos_WebSite_MicroThumnailWidth.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_MicroThumnailHeight] = txtPhotos_WebSite_MicroThumnailHeight.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_MiniThumnailWidth] = txtPhotos_WebSite_MiniThumnailWidth.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_MiniThumnailHeight] = txtPhotos_WebSite_MiniThumnailHeight.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_NormalThumnailWidth] = txtPhotos_WebSite_NormalThumnailWidth.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_NormalThumnailHeight] = txtPhotos_WebSite_NormalThumnailHeight.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_BigThumnailWidth] = txtPhotos_WebSite_BigThumnailWidth.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_BigThumnailHeight] = txtPhotos_WebSite_BigThumnailHeight.Text;
        //----------------------------------------------------------------------------------------------------------------
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_PhotosAvailbleExtensions] = txtPhotos_PhotosAvailbleExtensions.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_VListWidth] = txtPhotos_WebSite_VListWidth.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_VListHeight] = txtPhotos_WebSite_VListHeight.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_HListWidth] = txtPhotos_WebSite_HListWidth.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_HListHeight] = txtPhotos_WebSite_HListHeight.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_DetailsPageWidth] = txtPhotos_WebSite_DetailsPageWidth.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_WebSite_DetailsPageHeight] = txtPhotos_WebSite_DetailsPageHeight.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.Photos_SavePhotoDimensions] = cbPhotos_SavePhotoDimensions.Checked;
        //----------------------------------------------------------------------------------------------------------------

        SiteSettingsFactory.SaveAllSettingsCollections();
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";

    }
    //-----------------------------------------------
    #endregion

}

