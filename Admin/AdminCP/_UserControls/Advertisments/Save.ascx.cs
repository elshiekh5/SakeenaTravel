using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using System.IO;

public partial class AdminCP__UserControls_Advertisments_Save : AdminAddEditUserControl
{
    #region --------------PlaceType--------------
    private AdvPlaceTypes _PlaceType = AdvPlaceTypes.MasterWebSite;
    public AdvPlaceTypes PlaceType
    {
        get { return _PlaceType; }
        set { _PlaceType = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------OwnerID--------------
    private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
    public Guid OwnerID
    {
        get { return _OwnerID; }
        set { _OwnerID = value; }
    }
    //------------------------------------------
    #endregion

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            Load_ddlAdvPlaces();
            if (pageType == PagesTypes.AdminEdit)
            {
                hlFile.Visible = false;
                trAdvertisePreview.Visible = false;
            }
        }
        FirstLoad(lblResult, this.btnSave);
    }
    //-----------------------------------------------
    #endregion

    #region ---------------HandelControls---------------
    //-----------------------------------------------
    //HandelControls
    //-----------------------------------------------
    protected override void HandelControls()
    {
        #region ------------------Languages Handling---------------------
        //Languages Handling
        if (SiteSettings.Languages_HasMultiLanguages)
            SiteSettings.BuildDropDownListForDefaultPage(ddlLanguages);
        else
            trLanguages.Visible = false;
        #endregion
        trMaxApperance.Visible = SiteSettings.Adv_HasMaxApperance;
        trMaxClicks.Visible = SiteSettings.Adv_HasMaxClicks;
        trWeight.Visible = SiteSettings.Adv_HasWeight;
        trMaxApperance.Visible = SiteSettings.Adv_HasMaxApperance;
        trIsSmallAd.Visible = SiteSettings.Adv_EnableSeparatedAd;

    }
    #endregion

    #region ---------------LoadControls---------------
    //-----------------------------------------------
    //LoadControls
    //-----------------------------------------------
    protected override bool LoadControls()
    {
        int advertiseID = Convert.ToInt32(Request.QueryString["id"]);
        AdvertismentsEntity advertisments = AdvertismentsFactory.GetObject(advertiseID);
        if (advertisments != null)
        {
            if (SiteSettings.Languages_HasMultiLanguages)
                ddlLanguages.SelectedValue = ((int)advertisments.LangID).ToString();

            Load_ddlAdvPlaces();
            ddlAdvPlaces.SelectedValue = advertisments.PlaceID.ToString();
            txtUrl.Text = advertisments.Url;
            if (advertiseID == 45)
            {
                txtUrl.Enabled = false;
                ddlAdvPlaces.Enabled = false;
            }
            if (advertisments.FileExtension.Length > 0)
            {
                ltrAdvertiseFile.Text = AdvertismentsFactory.GetAdvertiseFileForAdmin(advertiseID);
                hlFile.NavigateUrl = advertisments.GetFileVirtualPath();
                hlFile.Text = Resources.AdminText.DownLoadExistFile;
            }
            else
            {
                hlFile.Visible = false;
                trAdvertisePreview.Visible = false;
            }
            //------------------------------------------
            ViewState["FileExtension"] = advertisments.FileExtension;
            //------------------------------------------
            //txtFileType.Text = advertisments.FileType.ToString();
            //------------------------------------------
            cbIsActive.Checked = advertisments.IsActive;
            //------------------------------------------
            if (SiteSettings.Adv_EnableSeparatedAd)
                cbIsSmall.Checked = advertisments.IsSmall;
            //------------------------------------------
            if (SiteSettings.Adv_HasWeight) ddlWeight.SelectedValue = advertisments.Weight.ToString();
            //------------------------------------------
            if (SiteSettings.Adv_HasMaxApperance) txtMaxApperance.Text = advertisments.MaxApperance.ToString();
            //------------------------------------------
            if (SiteSettings.Adv_HasMaxClicks) txtMaxClicks.Text = advertisments.MaxClicks.ToString();
            //------------------------------------------
            txtTitle.Text = advertisments.Title;
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
        AdvertismentsEntity advertisments = new AdvertismentsEntity();
        advertisments.AdvertiseID = Convert.ToInt32(Request.QueryString["id"]);
        if (SiteSettings.Languages_HasMultiLanguages)
            advertisments.LangID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        else
            advertisments.LangID = (Languages)SiteSettings.Languages_DefaultLanguageID;
        advertisments.PlaceID = Convert.ToInt32(ddlAdvPlaces.SelectedValue);
        advertisments.Url = txtUrl.Text;
        //-------------
        string fileExtension = (string)ViewState["FileExtension"];
        if (fuFile.HasFile)
        {
            string ext = Path.GetExtension(fuFile.FileName);
            //Check suported extention
            if (!SiteSettings.CheckUploadedFileExtension(ext, Resources.Advertisments.AdFileAvailableExtension))
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = Resources.AdminText.NotSuportedFileExtention + Resources.Advertisments.AdFileAvailableExtension;
                return null;
            }
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuFile.PostedFile.ContentLength, Resources.Advertisments.FileMaxSize))
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = Resources.AdminText.UploadedFileGreaterThanMaxLength + Resources.Advertisments.FileMaxSize;
                return null;
            }
            advertisments.FileExtension = ext;
        }
        else
        {
            advertisments.FileExtension = fileExtension != null ? fileExtension : "";
        }
        //-----------------------------------------------------------------
        if (advertisments.FileExtension.ToLower().Contains("swf"))
            advertisments.FileType = AdsTypes.Flash;
        else
            advertisments.FileType = AdsTypes.Photo;
        //-----------------------------------------------------------------
        advertisments.IsActive = cbIsActive.Checked;
        //-----------------------------------------------------------------
        if (SiteSettings.Adv_EnableSeparatedAd)
            advertisments.IsSmall = cbIsSmall.Checked;
        //-----------------------------------------------------------------
        if (SiteSettings.Adv_HasWeight) advertisments.Weight = Convert.ToInt32(ddlWeight.SelectedValue);
        //-----------------------------------------------------------------
        if (SiteSettings.Adv_HasMaxApperance && !string.IsNullOrEmpty(txtMaxApperance.Text)) advertisments.MaxApperance = Convert.ToInt32(txtMaxApperance.Text);
        //-----------------------------------------------------------------
        if (SiteSettings.Adv_HasMaxClicks && !string.IsNullOrEmpty(txtMaxClicks.Text)) advertisments.MaxClicks = Convert.ToInt32(txtMaxClicks.Text);
        //-----------------------------------------------------------------
        advertisments.Title = txtTitle.Text;
        //-----------------------------------------------------------------
        advertisments.OwnerID = (Guid)OwnerID;
        return advertisments;
    }
    #endregion

    #region ---------------SaveData---------------
    //-----------------------------------------------
    //SaveData
    //-----------------------------------------------
    protected override object SaveData()
    {
        AdvertismentsEntity ad = (AdvertismentsEntity)LoadObject();
        if (ad != null)
        {
            SPOperation operation;
            if (pageType == PagesTypes.AdminAdd)
                operation = SPOperation.Insert;
            else
                operation = SPOperation.Update;

            bool result = AdvertismentsFactory.Save(ad, operation);
            if (result) status = ExecuteCommandStatus.Done;
            else status = ExecuteCommandStatus.UnknownError;
        }
        return ad;
    }
    #endregion

    #region ---------------SaveFiles---------------
    //-----------------------------------------------
    //SaveFiles
    //-----------------------------------------------
    protected override void SaveFiles(object obj)
    {
        AdvertismentsEntity ad = (AdvertismentsEntity)obj;
        //File-----------------------------
        if (fuFile.HasFile)
        {
            if (pageType == PagesTypes.AdminEdit)
            {
                string fileExtension = (string)ViewState["FileExtension"];
                if (fileExtension.Length > 0)
                {
                    string oldFileVirtualPath = ad.GetFileVirtualPath(fileExtension);
                    string oldFilePhysicalPath = DCServer.MapPath(oldFileVirtualPath);
                    File.Delete(oldFilePhysicalPath);
                }
            }
            //-----------------------------------
            string newFilePhysicalPath = DCServer.MapPath(ad.GetFileVirtualPath());
            fuFile.PostedFile.SaveAs(newFilePhysicalPath);
        }

    }
    #endregion

    #region --------------Load_ddlAdvPlaces()--------------
    //---------------------------------------------------------
    //Load_ddlAdvPlaces
    //---------------------------------------------------------
    protected void Load_ddlAdvPlaces()
    {
        List<AdvPlacesEntity> AdvPlacesList = AdvPlacesFactory.GetAll(PlaceType);
        OurDropDownList.LoadDropDownList<AdvPlacesEntity>(AdvPlacesList, ddlAdvPlaces, "Title", "PlaceID", true);
    }
    //--------------------------------------------------------
    #endregion
}