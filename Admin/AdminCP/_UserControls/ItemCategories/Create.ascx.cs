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


public partial class ItemCategories_Create : System.Web.UI.UserControl
{
    TextBox txtTitle;
    TextBox txtShortDescription;
    TextBox txtMetaKeyWords;
    CuteEditor.Editor fckDescription;
    TextBox txtDescription;

    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion
    #region --------------TypeID--------------
    private CategoriesType _TypeID = CategoriesType.ItemCategories;
    public CategoriesType TypeID
    {
        get { return _TypeID; }
        set { _TypeID = value; }
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
    ItemsModulesOptions currentModule;

	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
        currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
        MLangsDetails1.ModuleTypeID = ModuleTypeID;
        MLangsDetails1.TypeOfDetails = DetailsTypes.Category;
        lblResult.Text = "";
		if(!IsPostBack)
		{
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
        HandleOptionalControls();
        PrepareValidation();
        SetTexts();
    }
    //-----------------------------------------------
    #endregion

    #region ---------------HandleOptionalControls---------------
    //-----------------------------------------------
    //HandleOptionalControls
    //-----------------------------------------------
    protected void HandleOptionalControls()
    {
        //-----------------------------------
        //Height	
        trHeight.Visible = currentModule.CategoryHasHeight;
        rfvHeight.Visible = currentModule.CategoryHasHeight && currentModule.CategoryRequiredHeight;
        //-----------------------------------
        //Width
        trWidth.Visible = currentModule.CategoryHasWidth;
        rfvWidth.Visible = currentModule.CategoryHasWidth && currentModule.CategoryRequiredWidth;
        //-----------------------------------
        //ItemDate
        trItemDate.Visible = currentModule.CategoryHasItemDate;
        //rfvItemDate.Visible = currentModule.CategoryHasItemDate && currentModule.CategoryRequiredItemDate;
        //-----------------------------------
        //HasPhotoExtension
        trPhotoExtension.Visible = currentModule.CategoryHasPhotoExtension;
        rfvPhoto.Visible = currentModule.CategoryHasPhotoExtension && currentModule.CategoryRequiredPhoto;
        //-----------------------------------
        //HasFileExtension
        trFileExtension.Visible = currentModule.CategoryHasFileExtension;
        rfvFile.Visible = currentModule.CategoryHasFileExtension && currentModule.CategoryRequiredFile;
        //-----------------------------------
        //trVideoExtension
        trVideoExtension.Visible = currentModule.CategoryHasVideoExtension;
        rfvVideo.Visible = currentModule.CategoryHasVideoExtension && currentModule.CategoryRequiredVideo;
        //-----------------------------------
        //trAudioExtension
        trAudioExtension.Visible = currentModule.CategoryHasAudioExtension;
        rfvAudio.Visible = currentModule.CategoryHasAudioExtension && currentModule.CategoryRequiredAudio;
        //-----------------------------------
        //trPhoto2Extension
        trPhoto2Extension.Visible = currentModule.CategoryHasPhoto2Extension;
        rfvPhoto2.Visible = currentModule.CategoryHasPhoto2Extension && currentModule.CategoryRequiredPhoto2;
        //-----------------------------------
        //trYouTubeCode
        trYoutubeCode.Visible = currentModule.CategoryHasYoutubeCode;
        rfvYoutubeCode.Visible = currentModule.CategoryHasYoutubeCode && currentModule.CategoryRequiredYoutubeCode;
        //-----------------------------------
        //trHasIsMain
        trHasIsMain.Visible = currentModule.CategoryHasIsMain;
        //-----------------------------------
        //HasIsAvailable
        trIsAvailable.Visible = currentModule.CategoryHasIsAvailable;
        //-----------------------------------
        //HasPriority
        if (currentModule.CategoryHasPriority)
        {
            trPriority.Visible = true;
            LoadPriorities();
        }
        else
        {
            trPriority.Visible = false;
        }
        //-----------------------------------
        lblCategoryAdminNote.Text = currentModule.CategoryAdminNote;
        //-----------------------------------
        //trGoogleLatitude
        trGoogleLatitude.Visible = currentModule.CategoryHasGoogleLatitude;
        rfvGoogleLatitude.Visible = currentModule.CategoryHasGoogleLatitude && currentModule.CategoryRequiredGoogleLatitude;
        //-----------------------------------
        //trGoogleLongitude
        trGoogleLongitude.Visible = currentModule.CategoryHasGoogleLongitude;
        rfvGoogleLongitude.Visible = currentModule.CategoryHasGoogleLongitude && currentModule.CategoryRequiredGoogleLongitude;
        //-----------------------------------
        //trOnlyForRegisered
        trOnlyForRegisered.Visible = currentModule.CategoryHasOnlyForRegisered;
        //-----------------------------------
        //Files publishing
        cbPublishPhoto.Visible = currentModule.CategoryHasPublishPhoto;
        cbPublishPhoto2.Visible = currentModule.CategoryHasPublishPhoto2;
        cbPublishFile.Visible = currentModule.CategoryHasPublishFile;
        cbPublishAudio.Visible = currentModule.CategoryHasPublishAudio;
        cbPublishVideo.Visible = currentModule.CategoryHasPublishVideo;
        cbPublishYoutbe.Visible = currentModule.CategoryHasPublishYoutbe;
        //-----------------------------------
        //-----------------------------------
        //trParents
        //-----------------------------------
        if (currentModule.CategoryLevel < 0 || currentModule.CategoryLevel > 1)
        {
            trParents.Visible = true;
            LoadParents();
        }
        else
        {
            trParents.Visible = false;
        }
        //-----------------------------------
    }
    //-----------------------------------------------
    #endregion

    #region ---------------PrepareValidation---------------
    //-----------------------------------------------
    //PrepareValidation
    //-----------------------------------------------
    protected void PrepareValidation()
    {
        //************************************************************************
        if (!string.IsNullOrEmpty(currentModule.CategoryPhotoAvailableExtension))
        {
            //Photo
            rxpPhoto.ValidationExpression = currentModule.CategoryGetPhotoValidationExpression();
            rxpPhoto.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.CategoryPhotoAvailableExtension;
        }
        else
        {
            rxpPhoto.Visible = false;
        }
        //---------------------------------
        //File
        if (!string.IsNullOrEmpty(currentModule.CategoryFileAvailableExtension))
        {
            rxpFile.ValidationExpression = currentModule.CategoryGetFileValidationExpression();
            rxpFile.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.CategoryFileAvailableExtension;
        }
        else
        {
            rxpFile.Visible = false;
        }
        //---------------------------------
        //Video
        if (!string.IsNullOrEmpty(currentModule.CategoryVideoAvailableExtension))
        {
            rxpVideo.ValidationExpression = currentModule.CategoryGetVideoValidationExpression();
            rxpVideo.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.CategoryVideoAvailableExtension;
        }
        else
        {
            rxpVideo.Visible = false;
        }
        //---------------------------------
        //Audio
        if (!string.IsNullOrEmpty(currentModule.CategoryAudioAvailableExtension))
        {
            rxpAudio.ValidationExpression = currentModule.CategoryGetAudioValidationExpression();
            rxpAudio.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.CategoryAudioAvailableExtension;
        }
        else
        {
            rxpAudio.Visible = false;
        }
        //---------------------------------
        //Photo2
        if (!string.IsNullOrEmpty(currentModule.CategoryPhoto2AvailableExtension))
        {
            rxpPhoto2.ValidationExpression = currentModule.CategoryGetPhoto2ValidationExpression();
            rxpPhoto2.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.CategoryPhoto2AvailableExtension;
        }
        else
        {
            rxpPhoto2.Visible = false;
        }
        //---------------------------------
    }
    //-----------------------------------------------
    #endregion

    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
        //------------------------------------------------------------------------------
        lblCategoryID.Text = DynamicResource.GetText(currentModule, "CategoryID");
        //------------------------------------------------------------------------------
        lblIsMain.Text = DynamicResource.GetText(currentModule, "IsMain");
        lblIsAvailable.Text = DynamicResource.GetText(currentModule, "IsAvailable");
        lblPriority.Text = DynamicResource.GetText(currentModule, "Priority");
        //------------------------------------------------------------------------------
        lblPhotoExtension.Text = DynamicResource.GetText(currentModule, "PhotoExtension");
        lblPhoto2Extension.Text = DynamicResource.GetText(currentModule, "Photo2Extension");
        lblFileExtension.Text = DynamicResource.GetText(currentModule, "FileExtension");
        lblVideoExtension.Text = DynamicResource.GetText(currentModule, "VideoExtension");
        lblAudioExtension.Text = DynamicResource.GetText(currentModule, "AudioExtension");
        //------------------------------------------------------------------------------
        lblHeight.Text = DynamicResource.GetText(currentModule, "Height");
        lblWidth.Text = DynamicResource.GetText(currentModule, "Width");
        //------------------------------------------------------------------------------
        lblItemDate.Text = DynamicResource.GetText(currentModule, "ItemDate");
        //------------------------------------------------------------------------------
        //Available Extension
        lblPhotoAvailableExtension.Text = currentModule.CategoryPhotoAvailableExtension.Replace(".", "");
        lblPhoto2AvailableExtension.Text = currentModule.CategoryPhoto2AvailableExtension.Replace(".", "");
        lblFileAvailableExtension.Text = currentModule.CategoryFileAvailableExtension.Replace(".", "");
        lblAudioAvailableExtension.Text = currentModule.CategoryAudioAvailableExtension.Replace(".", "");
        lblVideoAvailableExtension.Text = currentModule.CategoryVideoAvailableExtension.Replace(".", "");
        //------------------------------------------------------------------------------
        lblYoutubeCode.Text = DynamicResource.GetText(currentModule, "CategoryYoutubeCode");
        //------------------------------------------------------------------------------
        lblGoogleLatitude.Text = DynamicResource.GetText(currentModule, "GoogleLatitude");
        lblGoogleLongitude.Text = DynamicResource.GetText(currentModule, "GoogleLongitude");
        lblOnlyForRegisered.Text = DynamicResource.GetText(currentModule, "OnlyForRegisered");
        //------------------------------------------------------------------------------
        cbPublishPhoto.Text = DynamicResource.GetText(currentModule, "PublishPhoto");
        cbPublishPhoto2.Text = DynamicResource.GetText(currentModule, "PublishPhoto2");
        cbPublishFile.Text = DynamicResource.GetText(currentModule, "PublishFile");
        cbPublishAudio.Text = DynamicResource.GetText(currentModule, "PublishAudio");
        cbPublishVideo.Text = DynamicResource.GetText(currentModule, "PublishVideo");
        cbPublishYoutbe.Text = DynamicResource.GetText(currentModule, "PublishYoutbe");
        //------------------------------------------------------------------------------
    }
    //-----------------------------------------------
    #endregion

	#region ---------------LoadParents---------------
	//-----------------------------------------------
    //LoadParents
	//-----------------------------------------------
	private void LoadParents()
	{
        int categoriesDepth = currentModule.CategoryLevel;//NewsSiteSettings.Instance.CategoriesDepth;
        int depthLevel = categoriesDepth - 1;
        if (depthLevel < -1) depthLevel = -1;
        /*if (!currentModule.CategoryHasCategoryID)
        {
            Response.Redirect("/admincp");
        }
        else*/
        if (categoriesDepth == 1)
        {
            trParents.Visible = false;
        }
        else
        {
            ParentChildDropDownList n = new ParentChildDropDownList();
            DataTable dtSource = ItemCategoriesFactory.GetAllInDataTable(ModuleTypeID, Languages.Unknowen, false, OwnerID);
            n.DataBind(ddlParents, depthLevel, dtSource, "ParentID", "CategoryID", "Title");
            ddlParents.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "0"));

        }
	}
	//-----------------------------------------------
	#endregion

    #region ---------------LoadPriorities---------------
    //-----------------------------------------------
    //LoadPriorities
    //-----------------------------------------------
    protected void LoadPriorities()
    {
        int categoriesCount = ItemCategoriesFactory.GetCount(currentModule.ModuleTypeID, OwnerID);
        OurDropDownList.LoadPriorities(ddlPriority, categoriesCount, true);
    }
    //-----------------------------------------------
    #endregion


    #region ---------------btnSave_Click---------------
    //-----------------------------------------------
    //btnSave_Click
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid || (currentModule.CategoryHasItemDate && !ucItemDate.IsValid))
        {
            return;
        }
        //--------------------------------------------------
        ItemCategoriesEntity itemCategoriesObject = new ItemCategoriesEntity();
        //--------------------------------------------------
        #region Item Files properties

        // uploaded files extenssions
        string uploadedPhotoExtension = Path.GetExtension(fuPhoto.FileName);
        string uploadedFileExtension = Path.GetExtension(fuFile.FileName);
        string uploadedVideoExtension = Path.GetExtension(fuVideo.FileName);
        string uploadedAudioExtension = Path.GetExtension(fuAudio.FileName);
        string uploadedPhoto2Extension = Path.GetExtension(fuPhoto2.FileName);
        //---------------------------------------------------------------------

        #region Uploaded Files checks
        #region Uploaded photo file checks
        if (fuPhoto.HasFile)
        {
            if (!MoversFW.Photos.CheckIsImage(fuPhoto.PostedFile))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.InvalidPhotoFile;
                return;
            }
            /*
            //Check suported extention
            if (!SiteSettings.CheckUploadedFileExtension(uploadedPhotoExtension, currentModule.CategoryPhotoAvailableExtension))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.NotSuportedFileExtention + currentModule.CategoryPhotoAvailableExtension;
                return;
            }*/
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuPhoto.PostedFile.ContentLength, currentModule.CategoryPhotoMaxSize))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.UploadedFileGreaterThanMaxLength + currentModule.CategoryPhotoMaxSize;
                return;
            }
            //--------------------------------------------------------------------
        }
        #endregion
        #region Uploaded file checks
        //File
        if (fuFile.HasFile)
        {/*
            //Check suported extention
            if (!SiteSettings.CheckUploadedFileExtension(uploadedFileExtension, currentModule.CategoryFileAvailableExtension))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.NotSuportedFileExtention + currentModule.CategoryFileAvailableExtension;
                return;
            }*/
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuFile.PostedFile.ContentLength, currentModule.CategoryFileMaxSize))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.UploadedFileGreaterThanMaxLength + currentModule.CategoryFileMaxSize;
                return;
            }
        }
        //-----------------------------------------------------------------
        #endregion
        #region Uploaded video file checks
        //Video
        if (fuVideo.HasFile)
        {/*
            //Check suported extention
            if (!SiteSettings.CheckUploadedFileExtension(uploadedVideoExtension, currentModule.CategoryVideoAvailableExtension))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.NotSuportedVideoExtention + currentModule.CategoryVideoAvailableExtension;
                return;
            }*/
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuVideo.PostedFile.ContentLength, currentModule.CategoryVideoMaxSize))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.UploadedVideoGreaterThanMaxLength + currentModule.CategoryVideoMaxSize;
                return;
            }
        }
        //-----------------------------------------------------------------
        #endregion
        #region Uploaded audio file checks
        //Audio
        if (fuAudio.HasFile)
        {/*
            //Check suported extention
            if (!SiteSettings.CheckUploadedFileExtension(uploadedAudioExtension, currentModule.CategoryAudioAvailableExtension))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.NotSuportedAudioExtention + currentModule.CategoryVideoAvailableExtension;
                return;
            }*/
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuAudio.PostedFile.ContentLength, currentModule.CategoryAudioMaxSize))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.UploadedAudioGreaterThanMaxLength + currentModule.CategoryAudioMaxSize;
                return;
            }
        }
        //-----------------------------------------------------------------
        #endregion
        #region Uploaded photo2 file checks
        //-----------------------------------------------------------------
        //Photo2
        if (fuPhoto2.HasFile)
        {
            if (!MoversFW.Photos.CheckIsImage(fuPhoto2.PostedFile))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.InvalidPhotoFile;
                return;
            }/*
            //Check suported extention
            if (!SiteSettings.CheckUploadedFileExtension(uploadedPhoto2Extension, currentModule.CategoryPhoto2AvailableExtension))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.NotSuportedFileExtention + currentModule.CategoryPhoto2AvailableExtension;
                return;
            }*/
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuPhoto2.PostedFile.ContentLength, currentModule.CategoryPhoto2MaxSize))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.UploadedFileGreaterThanMaxLength + currentModule.CategoryPhoto2MaxSize;
                return;
            }
            //--------------------------------------------------------------------
        }
        //-----------------------------------------------------------------
        #endregion
        #endregion
        //-------------------------------------------------------------------------------------------
        #region Set properties
        //items files 
        itemCategoriesObject.PhotoExtension = uploadedPhotoExtension;
        itemCategoriesObject.FileExtension = uploadedFileExtension;
        itemCategoriesObject.VideoExtension = uploadedVideoExtension;
        itemCategoriesObject.AudioExtension = uploadedAudioExtension;
        itemCategoriesObject.Photo2Extension = uploadedPhoto2Extension;

        #endregion
        //-------------------------------------------------------------------------------------------
        #endregion
        //-------------------------------------------------------------------------------------------
        if (trParents.Visible)
            itemCategoriesObject.ParentID = Convert.ToInt32(ddlParents.SelectedValue);
        //-------------------------------------------------------------------------------------------
        itemCategoriesObject.TypeID = TypeID;
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------
        if (currentModule.CategoryHasPriority) itemCategoriesObject.Priority = Convert.ToInt32(ddlPriority.SelectedValue);
        //-------------------------------------------------------------------------------------------
        if (currentModule.CategoryHasHeight) itemCategoriesObject.Height = Convert.ToInt32(txtHeight.Text);
        if (currentModule.CategoryHasWidth) itemCategoriesObject.Width = Convert.ToInt32(txtWidth.Text);
        //-------------------------------------------------------------------------------------------
        //if (currentModule.CategoryHasItemDate && !string.IsNullOrEmpty(txtItemDate.Text)) itemCategoriesObject.ItemDate = Convert.ToDateTime(txtItemDate.Text);
        if (currentModule.CategoryHasItemDate && ucItemDate.Date != DateTime.MinValue) itemCategoriesObject.ItemDate = ucItemDate.Date;
        //-------------------------------------------------------------------------------------------
        //Check is  available 
        // logic of is available "if the module hasn't IsAvailable -> then  All items ara vailable "
        if (currentModule.CategoryHasIsAvailable) itemCategoriesObject.IsAvailable = cbIsAvailable.Checked;
        else itemCategoriesObject.IsAvailable = true;
        //-------------------------------------------------------------------------------------------
        itemCategoriesObject.IsMain = CbIsMain.Checked;
        //-------------------------------------------------------------------------------------------
        itemCategoriesObject.ModuleTypeID = ModuleTypeID;
        //-------------------------------------------------------------------------------------------
        itemCategoriesObject.YoutubeCode = txtYoutubeCode.Text;
        //-------------------------------------------------------------------------------------------
        if (currentModule.CategoryHasGoogleLatitude)
            itemCategoriesObject.GoogleLatitude = Convert.ToDouble(txtGoogleLatitude.Text);
        //-------------------------------------------------------------------------------------------
        if (currentModule.CategoryHasGoogleLongitude)
            itemCategoriesObject.GoogleLongitude = Convert.ToDouble(txtGoogleLongitude.Text);
        //-------------------------------------------------------------------------------------------
        itemCategoriesObject.OnlyForRegisered = cbOnlyForRegisered.Checked;
        //-------------------------------------------------------------------------------------------
        //Files publishing
        itemCategoriesObject.PublishPhoto = cbPublishPhoto.Checked;
        itemCategoriesObject.PublishPhoto2 = cbPublishPhoto2.Checked;
        itemCategoriesObject.PublishFile = cbPublishFile.Checked;
        itemCategoriesObject.PublishAudio = cbPublishAudio.Checked;
        itemCategoriesObject.PublishVideo = cbPublishVideo.Checked;
        itemCategoriesObject.PublishYoutbe = cbPublishYoutbe.Checked;
        //-------------------------------------------------------------------------------------------
        if (OwnerID != null)
            itemCategoriesObject.OwnerID = (Guid)OwnerID;
        //Details //---------------------------------------------------------------------------------
        AddDetails(itemCategoriesObject);
        //-------------------------------------------------------------------------------------------
        ExecuteCommandStatus status = ItemCategoriesFactory.Create(itemCategoriesObject,currentModule);
        //-------------------------------------------------------------------------------------------
        if (status == ExecuteCommandStatus.Done)
        {
            //------------------------------------------------------------------------
            SaveFiles(itemCategoriesObject);
            //------------------------------------------------------------------------
            lblResult.CssClass = "lblResult_Done";
            lblResult.Text = Resources.AdminText.AddingOperationDone;
            ClearControls();
            //------------------------------------------------------------------------
        }
        else if (status == ExecuteCommandStatus.AllreadyExists)
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.DuplicateItem;
        }
        else
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.AddingOperationFaild;
        }
    }
    //-----------------------------------------------
    #endregion


    //--------------------------------------------
    protected void AddDetails(ItemCategoriesEntity category)
    {
        MLanguagesDetailsControls ucArDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucArDetails");
        MLanguagesDetailsControls ucEnDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucEnDetails");
        //if(HasArabic)
        GetDetails(category, ucArDetails);
        //if(HasEngrabic)
        GetDetails(category, ucEnDetails);
        //----------------------------
    }
    //--------------------------------------------
    protected void GetDetails(ItemCategoriesEntity category, MLanguagesDetailsControls ucDetails)
    {
        LoadDetailsControls(ucDetails);
        if (ucDetails.Visible && ((currentModule.CategoryRequiredTitle && txtTitle.Text.Length > 0) || !currentModule.CategoryRequiredTitle))
        {
            ItemCategoriesDetailsEntity itemCategoriesDetailsObject = new ItemCategoriesDetailsEntity();
            itemCategoriesDetailsObject.LangID = ucDetails.Lang;
            itemCategoriesDetailsObject.Title = txtTitle.Text;
            itemCategoriesDetailsObject.ShortDescription = txtShortDescription.Text;
            itemCategoriesDetailsObject.KeyWords = txtMetaKeyWords.Text;
            //-----------------------------------------------------------
            if (currentModule.CategoryDetailsInHtmlEditor)
                itemCategoriesDetailsObject.Description = fckDescription.Text;
            else
                itemCategoriesDetailsObject.Description = txtDescription.Text;
            //-----------------------------------------------------------
            category.Details[itemCategoriesDetailsObject.LangID] = itemCategoriesDetailsObject;

        }
    }

    #region ---------------LoadDetailsControls---------------
    //-----------------------------------------------
    //LoadDetailsControls
    //-----------------------------------------------
    protected void LoadDetailsControls(MLanguagesDetailsControls ucDetails)
    {
        txtTitle = (TextBox)ucDetails.FindControl("txtTitle");
        txtShortDescription = (TextBox)ucDetails.FindControl("txtShortDescription");
        txtMetaKeyWords = (TextBox)ucDetails.FindControl("txtMetaKeyWords");
        fckDescription = (CuteEditor.Editor)ucDetails.FindControl("fckDescription");
        txtDescription = (TextBox)ucDetails.FindControl("txtDescription");
    }
    //-----------------------------------------------
    #endregion

    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    private void ClearControls()
    {
        //-----------------------------------
        cbIsAvailable.Checked = true;
        CbIsMain.Checked = false;
        //-----------------------------------
        LoadPriorities();
        ddlPriority.SelectedIndex = -1;
        //-----------------------------------
        txtHeight.Text = "";
        txtWidth.Text = "";
        //-----------------------------------
        ucItemDate.ClearControls();
        //-----------------------------------
        txtYoutubeCode.Text = "";
        //-----------------------------------
        MLangsDetails1.ClearControls();
        //-----------------------------------
        txtGoogleLatitude.Text = "";
        txtGoogleLongitude.Text = "";
        //-----------------------------------
        cbOnlyForRegisered.Checked = false;
        //-----------------------------------
        //Files publishing
        cbPublishPhoto.Visible = false;
        cbPublishPhoto2.Visible = false;
        cbPublishFile.Visible = false;
        cbPublishAudio.Visible = false;
        cbPublishVideo.Visible = false;
        cbPublishYoutbe.Visible = false;
        //-----------------------------------
    }
    //--------------------------------------------------------
    #endregion

    #region ---------------SaveFiles---------------
    //-----------------------------------------------
    //SaveFiles
    //-----------------------------------------------
    protected void SaveFiles(ItemCategoriesEntity itemCategoriesObject)
    {
        #region Save uploaded photo
        //Photo-----------------------------
        if (fuPhoto.HasFile)
        {
            //------------------------------------------------
            //Save new original photo
            fuPhoto.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesPhotoOriginals(itemCategoriesObject.OwnerName, itemCategoriesObject.ModuleTypeID, itemCategoriesObject.CategoryID)) + itemCategoriesObject.Photo);
            //Create new thumbnails
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_ItemCategoriesPhotoNormalThumbs(itemCategoriesObject.OwnerName, itemCategoriesObject.ModuleTypeID, itemCategoriesObject.CategoryID), ItemCategoriesFactory.CreateItemCategoriesPhotoName(itemCategoriesObject.CategoryID), fuPhoto.PostedFile, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight);
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_ItemCategoriesPhotoBigThumbs(itemCategoriesObject.OwnerName, itemCategoriesObject.ModuleTypeID, itemCategoriesObject.CategoryID), ItemCategoriesFactory.CreateItemCategoriesPhotoName(itemCategoriesObject.CategoryID), fuPhoto.PostedFile, SiteSettings.Photos_BigThumnailWidth, SiteSettings.Photos_BigThumnailHeight);
            //-------------------------------------------------------

        }
        #endregion

        #region Save uploaded file
        //File-----------------------------
        if (fuFile.HasFile)
        {
            //Save new original file
            fuFile.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles(itemCategoriesObject.OwnerName, itemCategoriesObject.ModuleTypeID, itemCategoriesObject.CategoryID)) + itemCategoriesObject.File);
        }
        #endregion

        #region Save uploaded video
        //Video-----------------------------
        if (fuVideo.HasFile)
        {
            fuVideo.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles(itemCategoriesObject.OwnerName, itemCategoriesObject.ModuleTypeID, itemCategoriesObject.CategoryID)) + itemCategoriesObject.Video);
        }
        #endregion

        #region Save uploaded audio
        //Audio-----------------------------
        if (fuAudio.HasFile)
        {
            fuAudio.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles(itemCategoriesObject.OwnerName, itemCategoriesObject.ModuleTypeID, itemCategoriesObject.CategoryID)) + itemCategoriesObject.Audio);
        }
        #endregion

        #region Save uploaded photo2
        //-------------------------------------------------------------------------------------
        //Photo2-----------------------------
        if (fuPhoto2.HasFile)
        {
            fuPhoto2.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles(itemCategoriesObject.OwnerName, itemCategoriesObject.ModuleTypeID, itemCategoriesObject.CategoryID)) + itemCategoriesObject.Photo2);
        }
        #endregion
    }
    //-----------------------------------------------
    #endregion
}

