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

public partial class AdminAdvPlaces_Update : MasterAdminAddEditPage
{
	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
        FirstLoad(lblResult, this.btnSave);
        if (!IsPostBack)
        {
            this.Page.Title = "«·≈⁄·«‰« ";
        }
	}
	//-----------------------------------------------
	#endregion

    #region ---------------HandelControls---------------
    //-----------------------------------------------
    //HandelControls
    //-----------------------------------------------
    protected override void HandelControls()
    {
        trDefaultFilePath.Visible = SiteSettings.Adv_HasDefaultFile;
        trIsRandom.Visible = SiteSettings.Adv_HasIsRandom;
        trEnableSeparatedAd.Visible = SiteSettings.Adv_EnableSeparatedAd;
        trEnableSeparatedCount.Visible = SiteSettings.Adv_EnableSeparatedAd;
    }
    #endregion

    #region ---------------LoadControls---------------
    //-----------------------------------------------
    //LoadControls
    //-----------------------------------------------
    protected override bool LoadControls()
    {
        int placeID = Convert.ToInt32(Request.QueryString["id"]);
        AdvPlacesEntity advPlaces = AdvPlacesFactory.GetObject(placeID);
        if (advPlaces != null)
        {
            txtPlaceID.Text = advPlaces.PlaceID.ToString();
            txtPlaceIdentifier.Text = advPlaces.PlaceIdentifier;
            txtTitle.Text = advPlaces.Title;
            txtWidth.Text = advPlaces.Width.ToString();
            txtHeight.Text = advPlaces.Height.ToString();
            txtDefaultFilePath.Text = advPlaces.DefaultFilePath;
           // txtDefaultFileType.Text = advPlaces.DefaultFileType.ToString();
            //-----------------------------------------------------------------
            if (SiteSettings.Adv_HasIsRandom)
                cbIsRandom.Checked = advPlaces.IsRandom;
            //-----------------------------------------------------------------
            if (SiteSettings.Adv_EnableSeparatedAd)
            {
                cbEnableSeparatedAd.Checked = advPlaces.EnableSeparatedAd;
                txtEnableSeparatedCount.Text = advPlaces.EnableSeparatedCount.ToString();
            }
            //-----------------------------------------------------------------
            ddlPlaceType.SelectedValue = ((int)advPlaces.PlaceType).ToString();
            //-----------------------------------------------------------------

            return true;
        }
        else
        {
            return false;
        }
    }
    #endregion

    #region ---------------LoadObject---------------
    //-----------------------------------------------
    //LoadObject
    //-----------------------------------------------
    protected override object LoadObject()
    {
        AdvPlacesEntity advPlaces = new AdvPlacesEntity();
        advPlaces.PlaceID = Convert.ToInt32(txtPlaceID.Text);
        advPlaces.PlaceIdentifier = txtPlaceIdentifier.Text.Trim();
        advPlaces.Title = txtTitle.Text;
        advPlaces.Width = Convert.ToInt32(txtWidth.Text);
        advPlaces.Height = Convert.ToInt32(txtHeight.Text);
        if (!string.IsNullOrEmpty(txtDefaultFilePath.Text))
        {
            advPlaces.DefaultFilePath = txtDefaultFilePath.Text;
            if (txtDefaultFilePath.Text.ToLower().Contains("swf"))
                advPlaces.DefaultFileType = AdsTypes.Flash;
            else
                advPlaces.DefaultFileType = AdsTypes.Photo;
        }
        if (SiteSettings.Adv_HasIsRandom)
            advPlaces.IsRandom = cbIsRandom.Checked;
        //-----------------------------------------------------------------
        if (SiteSettings.Adv_EnableSeparatedAd)
        {
            advPlaces.EnableSeparatedAd = cbEnableSeparatedAd.Checked;
            advPlaces.EnableSeparatedCount = Convert.ToInt32(txtEnableSeparatedCount.Text);
        }
        //-----------------------------------------------------------------
        advPlaces.PlaceType = (AdvPlaceTypes)Convert.ToInt32(ddlPlaceType.SelectedValue);
        //-----------------------------------------------------------------
        return advPlaces;
    }
    #endregion

    #region ---------------SaveData---------------
    //-----------------------------------------------
    //SaveData
    //-----------------------------------------------
    protected override object SaveData()
    {
        AdvPlacesEntity advPlace = (AdvPlacesEntity)LoadObject();
        if (advPlace != null)
        {
            SPOperation operation;
            if (pageType == PagesTypes.AdminAdd)
                operation = SPOperation.Insert;
            else
                operation = SPOperation.Update;

            status = AdvPlacesFactory.Save(advPlace, operation);
        }
        return advPlace;
    }
    #endregion

}

