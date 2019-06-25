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


public partial class ItemCategories_Update : System.Web.UI.UserControl
{

    TextBox txtTitle;
    TextBox txtShortDescription;
    TextBox txtMetaKeyWords;
    CuteEditor.Editor fckDescription;
    TextBox txtDescription;
    //-------------------------------------------
    ItemCategoriesEntity category;
    ItemsModulesOptions currentModule;
    string oldPhotoExtension;
    string oldFileExtension;
    string oldVideoExtension;
    string oldAudioExtension;
    string oldPhoto2Extension;
    public string Banner = "";

    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
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
        currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
        //------------------------------------------------------------------------
        //New code for pages
        //------------------------------
        if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents)
        {
            if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {
                int pageID = Convert.ToInt32(Request.QueryString["id"]);
                currentModule = SitePageOptions.GetPage(pageID);
            }
            else
            {
                Response.Redirect("/AdminCP/");
            }
        }
        //------------------------------------------------------------------------
        MLangsDetails1.ModuleTypeID = ModuleTypeID;
        MLangsDetails1.TypeOfDetails = DetailsTypes.Category;
        lblResult.Text = "";
        if (!IsPostBack)
        {
            PrepareValidation();
            SetTexts();
            HandleOptionalControls();
            LoadData();
        }
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
        trPhotoPreview.Visible = currentModule.CategoryHasPhotoExtension;
        //rfvPhoto.Visible = currentModule.CategoryHasPhotoExtension && currentModule.CategoryRequiredPhoto;
        //-----------------------------------
        //HasFileExtension
        trFileExtension.Visible = currentModule.CategoryHasFileExtension;
        trFilePreview.Visible = currentModule.CategoryHasFileExtension;
        //rfvFile.Visible = currentModule.CategoryHasFileExtension && currentModule.CategoryRequiredFile;
        //-----------------------------------
        //trVideoExtension
        trVideoExtension.Visible = currentModule.CategoryHasVideoExtension;
        trVideoPreview.Visible = currentModule.CategoryHasVideoExtension;
        //rfvVideo.Visible = currentModule.CategoryHasVideoExtension && currentModule.CategoryRequiredVideo;
        //-----------------------------------
        //trAudioExtension
        trAudioExtension.Visible = currentModule.CategoryHasAudioExtension;
        trAudioPreview.Visible = currentModule.CategoryHasAudioExtension;
        //rfvAudio.Visible = currentModule.CategoryHasAudioExtension && currentModule.CategoryRequiredAudio;
        //-----------------------------------
        //trPhoto2Preview
        trPhoto2Extension.Visible = currentModule.CategoryHasPhoto2Extension;
        trPhoto2Preview.Visible = currentModule.CategoryHasPhoto2Extension;
        //rfvPhoto2.Visible = currentModule.CategoryHasPhoto2Extension && currentModule.CategoryRequiredPhoto2;
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
        //trYouTubeCode
        trYoutubeCode.Visible = currentModule.CategoryHasYoutubeCode;
        rfvYoutubeCode.Visible = currentModule.CategoryHasYoutubeCode && currentModule.CategoryRequiredYoutubeCode;
        //-----------------------------------
        //Previews
        trDeletePhoto.Visible = !currentModule.CategoryRequiredPhoto;
        btnDeletePhoto2.Visible = !currentModule.CategoryRequiredPhoto2;
        //-------------------------------------------
        ibtnDeleteFile.Visible = !currentModule.CategoryRequiredFile;
        ibtnDeleteVideo.Visible = !currentModule.CategoryRequiredVideo;
        ibtnDeleteAudio.Visible = !currentModule.CategoryRequiredAudio;
        //-----------------------------------
        lblAdminNote.Text = currentModule.CategoryAdminNote;
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
    }
    //-----------------------------------------------
    #endregion

    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
        lblParents.Text = DynamicResource.GetText(currentModule, "CategoryID");
        lblPhotoExtension.Text = DynamicResource.GetText(currentModule, "PhotoExtension");
        lblFileExtension.Text = DynamicResource.GetText(currentModule, "FileExtension");
        lblIsMain.Text = DynamicResource.GetText(currentModule, "IsMain");
        lblIsAvailable.Text = DynamicResource.GetText(currentModule, "IsAvailable");

        lblVideoExtension.Text = DynamicResource.GetText(currentModule, "VideoExtension");
        lblAudioExtension.Text = DynamicResource.GetText(currentModule, "AudioExtension");
        lblPriority.Text = DynamicResource.GetText(currentModule, "Priority");
        lblPhoto2Extension.Text = DynamicResource.GetText(currentModule, "Photo2Extension");
        //-----------------------------------------------
        lblHeight.Text = DynamicResource.GetText(currentModule, "Height");
        lblWidth.Text = DynamicResource.GetText(currentModule, "Width");
        lblItemDate.Text = DynamicResource.GetText(currentModule, "ItemDate");
        //-----------------------------------------------
        //Available Extension
        lblPhotoAvailableExtension.Text = currentModule.CategoryPhotoAvailableExtension.Replace(".", "");
        lblPhoto2AvailableExtension.Text = currentModule.CategoryPhoto2AvailableExtension.Replace(".", "");
        lblFileAvailableExtension.Text = currentModule.CategoryFileAvailableExtension.Replace(".", "");
        lblAudioAvailableExtension.Text = currentModule.CategoryAudioAvailableExtension.Replace(".", "");
        lblVideoAvailableExtension.Text = currentModule.CategoryVideoAvailableExtension.Replace(".", "");
        //-----------------------------------------------
        lblYoutubeCode.Text = DynamicResource.GetText(currentModule, "CategoryYoutubeCode");
        //-----------------------------------------------
        lblGoogleLatitude.Text = DynamicResource.GetText(currentModule, "GoogleLatitude");
        lblGoogleLongitude.Text = DynamicResource.GetText(currentModule, "GoogleLongitude");
        lblOnlyForRegisered.Text = DynamicResource.GetText(currentModule, "OnlyForRegisered");
        //----------------
        cbPublishPhoto.Text = DynamicResource.GetText(currentModule, "PublishPhoto");
        cbPublishPhoto2.Text = DynamicResource.GetText(currentModule, "PublishPhoto2");
        cbPublishFile.Text = DynamicResource.GetText(currentModule, "PublishFile");
        cbPublishAudio.Text = DynamicResource.GetText(currentModule, "PublishAudio");
        cbPublishVideo.Text = DynamicResource.GetText(currentModule, "PublishVideo");
        cbPublishYoutbe.Text = DynamicResource.GetText(currentModule, "PublishYoutbe");
        //-----------------------------------------------
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


    #region ---------------LoadPriorities---------------
    //-----------------------------------------------
    //LoadPriorities
    //-----------------------------------------------
    protected void LoadPriorities()
    {
        int categoriesCount = ItemCategoriesFactory.GetCount(currentModule.ModuleTypeID,OwnerID);
        OurDropDownList.LoadPriorities(ddlPriority, categoriesCount, false);
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadParents---------------
    //-----------------------------------------------
    //LoadParents
    //-----------------------------------------------
    private void LoadParents()
    {
        int categoriesDepth = currentModule.CategoryLevel;
        int depthLevel = categoriesDepth - 1;
        if (depthLevel < -1) depthLevel = -1;
        if (categoriesDepth == 1)
        {
            trParents.Visible = false;
        }
        else
        {
            ParentChildDropDownList n = new ParentChildDropDownList();
            DataTable dtSource = ItemCategoriesFactory.GetAllInDataTable(ModuleTypeID, Languages.Unknowen, false,OwnerID);
            n.DataBind(ddlParents, depthLevel, dtSource, "ParentID", "CategoryID", "Title");
            ddlParents.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "0"));
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

        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            int categoryID = Convert.ToInt32(Request.QueryString["id"]);
            category = ItemCategoriesFactory.GetObject(categoryID, Languages.Unknowen,OwnerID);
            if (category != null)
            {

                //----------------------------------------------------------------------------------
                if (trParents.Visible)
                    ddlParents.SelectedValue = category.ParentID.ToString();
                //----------------------------------------------------------------------------------
                if (currentModule.CategoryHasPriority)
                    ddlPriority.SelectedValue = category.Priority.ToString();
                //------------------------------------------
                cbIsAvailable.Checked = category.IsAvailable;
                //---------------------------------
                CbIsMain.Checked = category.IsMain;
                //-----------------------------------
                txtHeight.Text = category.Height.ToString();
                txtWidth.Text = category.Width.ToString();
                //-----------------------------------
                //txtItemDate.Text = category.ItemDateString;
                ucItemDate.Date = category.ItemDate;
                //-----------------------------------
                #region ----------Item files----------
                #region ----------Photo----------
                //-------------------------------------------
                //Photo
                //-------------------------------------------
                if (!string.IsNullOrEmpty(category.PhotoExtension))
                {
                    imgPhoto.ImageUrl = ItemCategoriesFactory.GetItemCategoriesPhotoThumbnail(category.CategoryID, category.PhotoExtension, 100, 100, category.OwnerName, category.ModuleTypeID);
                    ancor.HRef = ItemCategoriesFactory.GetItemCategoriesPhotoBigThumbnail(category.CategoryID, category.PhotoExtension, category.OwnerName, category.ModuleTypeID);
                    //imgPhoto.AlternateText = category.Title;
                }
                else
                {
                    trPhotoPreview.Visible = false;

                }
                //------------------------------------------
                //------------------------------------------
                #endregion
                #region ----------File----------
                //-------------------------------------------
                //File
                //-------------------------------------------
                if (!string.IsNullOrEmpty(category.FileExtension))
                {
                    hlFile.HRef = "/WebSite/CategoriesDownload.aspx?id=" + category.CategoryID + "&type=1";
                }
                else
                {
                    hlFile.Visible = false;
                    ibtnDeleteFile.Visible = false;
                }
                //------------------------------------------
                //------------------------------------------
                #endregion
                #region ----------Video----------
                //-------------------------------------------
                //Video
                //-------------------------------------------
                //VideoExtension
                if (!string.IsNullOrEmpty(category.VideoExtension))
                {
                    hlVideo.HRef = "/WebSite/CategoriesDownload.aspx?id=" + category.CategoryID + "&type=2";
                }
                else
                {
                    hlVideo.Visible = false;
                    ibtnDeleteVideo.Visible = false;
                }
                //------------------------------------------
                //------------------------------------------
                #endregion
                #region ----------Audio----------
                //-------------------------------------------
                //Audio
                //-------------------------------------------
                if (!string.IsNullOrEmpty(category.AudioExtension))
                {
                    hlAudio.HRef = "/WebSite/CategoriesDownload.aspx?id=" + category.CategoryID + "&type=3";
                }
                else
                {
                    hlAudio.Visible = false;
                    ibtnDeleteAudio.Visible = false;
                }
                //------------------------------------------
                //------------------------------------------
                #endregion
                #region ----------Photo2----------
                //-------------------------------------------
                //Photo2
                //-------------------------------------------
                if (!string.IsNullOrEmpty(category.Photo2Extension))
                {
                    imgPhoto2.ImageUrl = DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID) + category.Photo2;
                    aImgPhoto2Viewer.HRef = DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID) + category.Photo2;
                }
                else
                {
                    trPhoto2Preview.Visible = false;
                }
                //------------------------------------------
                //------------------------------------------
                #endregion

                #endregion
                //-----------------------------------
                if (!string.IsNullOrEmpty(category.YoutubeCode))
                {
                    txtYoutubeCode.Text = category.YoutubeCode;
                    aYoutube.HRef = "/PopUps/Youtube.aspx?v=" + category.YoutubeCode;
                }
                else
                {
                    aYoutube.Visible = false;
                }
                //-----------------------------------
                txtGoogleLatitude.Text = category.GoogleLatitude.ToString();
                txtGoogleLongitude.Text = category.GoogleLongitude.ToString();
                //-----------------------------------
                cbOnlyForRegisered.Checked = category.OnlyForRegisered;
                //-----------------------------------
                //Files publishing
                cbPublishPhoto.Checked = category.PublishPhoto;
                cbPublishPhoto2.Checked = category.PublishPhoto2;
                cbPublishFile.Checked = category.PublishFile;
                cbPublishAudio.Checked = category.PublishAudio;
                cbPublishVideo.Checked = category.PublishVideo;
                cbPublishYoutbe.Checked = category.PublishYoutbe;
                //-----------------------------------
                LoadDetails(category);
                //-----------------------------------
            }
            else
            {
                Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/Cats/default.aspx");
            }
        }
        else
        {
            Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/Cats/default.aspx");
        }
    }
    //-----------------------------------------------
    #endregion



    #region ---------------btnSave_Click---------------
    //-----------------------------------------------
    //btnSave_Click
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            //------------------------------------------------------------------------------------------
            if (!Page.IsValid || (currentModule.CategoryHasItemDate && !ucItemDate.IsValid))
            {
                return;
            }
            //------------------------------------------------------------------------------------------
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ItemCategoriesEntity category = ItemCategoriesFactory.GetObject(id, Languages.Unknowen, OwnerID);
            if (category != null)
            {
                //------------------------------------------------------------------------------------------
                #region Item Files properties
                //Old files extension 
                oldPhotoExtension = category.PhotoExtension;
                oldFileExtension = category.FileExtension;
                oldVideoExtension = category.VideoExtension;
                oldAudioExtension = category.AudioExtension;
                oldPhoto2Extension = category.Photo2Extension;
                //---------------------------
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
                    }/*
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
                #region Set properties
                //items files 
                //Photo
                if (fuPhoto.HasFile)
                    category.PhotoExtension = uploadedPhotoExtension;
                else
                    category.PhotoExtension = oldPhotoExtension;
                //-----------------------
                //File
                if (fuFile.HasFile)
                    category.FileExtension = uploadedFileExtension;
                else
                    category.FileExtension = oldFileExtension;
                //------------------------------------
                //Video
                if (fuVideo.HasFile)
                    category.VideoExtension = uploadedVideoExtension;
                else
                    category.VideoExtension = oldVideoExtension;
                //------------------------------------
                //AudioExtension
                if (fuAudio.HasFile)
                    category.AudioExtension = uploadedAudioExtension;
                else
                    category.AudioExtension = oldAudioExtension;
                //------------------------------------
                //Photo2
                if (fuPhoto2.HasFile)
                    category.Photo2Extension = uploadedPhoto2Extension;
                else
                    category.Photo2Extension = oldPhoto2Extension;
                //------------------------------------
                #endregion
                #endregion
                //------------------------------------------------------------------------------------------
                category.CategoryID = Convert.ToInt32(Request.QueryString["id"]);
                //------------------------------------------------------------------------------------------
                if (trParents.Visible)
                    category.ParentID = Convert.ToInt32(ddlParents.SelectedValue);
                //------------------------------------------------------------------------------------------
                if (currentModule.CategoryHasPriority) category.Priority = Convert.ToInt32(ddlPriority.SelectedValue);
                //------------------------------------------------------------------------------------------
                if (currentModule.CategoryHasHeight) category.Height = Convert.ToInt32(txtHeight.Text);
                if (currentModule.CategoryHasWidth) category.Width = Convert.ToInt32(txtWidth.Text);
                //------------------------------------------------------------------------------------------
                //if (currentModule.CategoryHasItemDate) category.ItemDate = Convert.ToDateTime(txtItemDate.Text);
                //if (currentModule.CategoryHasItemDate && ucItemDate.Date != DateTime.MinValue) category.ItemDate = ucItemDate.Date;
                if (currentModule.CategoryHasItemDate) category.ItemDate = ucItemDate.Date;
                //------------------------------------------------------------------------------------------
                //Check is  available 
                // logic of is available "if the module hasn't IsAvailable -> then  All items ara vailable "
                if (currentModule.CategoryHasIsAvailable) category.IsAvailable = cbIsAvailable.Checked;
                else category.IsAvailable = true;
                //-------------------------------------------------------------------------------------------
                category.IsMain = CbIsMain.Checked;
                //------------------------------------------------------------------------------------------
                category.YoutubeCode = txtYoutubeCode.Text;
                //------------------------------------------------------------------------------------------
                if (currentModule.CategoryHasGoogleLatitude)
                    category.GoogleLatitude = Convert.ToDouble(txtGoogleLatitude.Text);
                //------------------------------------------------------------------------------------------
                if (currentModule.CategoryHasGoogleLongitude)
                    category.GoogleLongitude = Convert.ToDouble(txtGoogleLongitude.Text);
                //------------------------------------------------------------------------------------------
                category.OnlyForRegisered = cbOnlyForRegisered.Checked;
                //------------------------------------------------------------------------------------------
                //Files publishing
                category.PublishPhoto = cbPublishPhoto.Checked;
                category.PublishPhoto2 = cbPublishPhoto2.Checked;
                category.PublishFile = cbPublishFile.Checked;
                category.PublishAudio = cbPublishAudio.Checked;
                category.PublishVideo = cbPublishVideo.Checked;
                category.PublishYoutbe = cbPublishYoutbe.Checked;
                //------------------------------------------------------------------------------------------
                //Details ----------------------------------------------------------------------------------
                AddDetails(category);
                //-------------------------------
                ExecuteCommandStatus status = ItemCategoriesFactory.Update(category, currentModule);
                if (status == ExecuteCommandStatus.Done)
                {
                    //--------------------------------------------------------------------------
                    //Save uploaded files
                    SaveFiles(category);
                    //--------------------------------------------------------------------------
                    //if this module as pages don't redirect 
                    Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/Cats/default.aspx");

                    //--------------------------------------------------------------------------
                }
                else if (status == ExecuteCommandStatus.AllreadyExists)
                {
                    lblResult.CssClass = "lblResult_Faild";
                    lblResult.Text = Resources.AdminText.DuplicateItem;
                }
                else
                {
                    lblResult.CssClass = "lblResult_Faild";
                    lblResult.Text = Resources.AdminText.UpdatingOperationFaild;
                }
            }
            else
            {
                //------------------------------------------------
                Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/Cats/default.aspx");
                //------------------------------------------------
            }
        }
        else
        {
            if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents)
            { Response.Redirect("/Admin/"); }
            else
            { Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/Cats/default.aspx"); }
        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------SaveFiles---------------
    //-----------------------------------------------
    //SaveFiles
    //-----------------------------------------------
    protected void SaveFiles(ItemCategoriesEntity category)
    {
        #region Save uploaded photo
        //Photo-----------------------------
        if (fuPhoto.HasFile)
        {
            //if has an old photo
            if (!string.IsNullOrEmpty(oldPhotoExtension))
            {
                //Delete old original photo
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesPhotoOriginals (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + ItemCategoriesFactory.CreateItemCategoriesPhotoName(category.CategoryID) + oldPhotoExtension);
                //Delete old Thumbnails
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesPhotoNormalThumbs (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + ItemCategoriesFactory.CreateItemCategoriesPhotoName(category.CategoryID) + MoversFW.Thumbs.thumbnailExetnsion);
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesPhotoBigThumbs(category.OwnerName,category.ModuleTypeID,category.CategoryID)) + ItemCategoriesFactory.CreateItemCategoriesPhotoName(category.CategoryID) + MoversFW.Thumbs.thumbnailExetnsion);
            }
            //------------------------------------------------
            //Save new original photo
            fuPhoto.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesPhotoOriginals (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + category.Photo);
            //Create new thumbnails
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_ItemCategoriesPhotoNormalThumbs (category.OwnerName,category.ModuleTypeID,category.CategoryID), ItemCategoriesFactory.CreateItemCategoriesPhotoName(category.CategoryID), fuPhoto.PostedFile, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight);
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_ItemCategoriesPhotoBigThumbs(category.OwnerName,category.ModuleTypeID,category.CategoryID), ItemCategoriesFactory.CreateItemCategoriesPhotoName(category.CategoryID), fuPhoto.PostedFile, SiteSettings.Photos_BigThumnailWidth, SiteSettings.Photos_BigThumnailHeight);
        }
        //------------------------------------------------
        #endregion


        #region Save uploaded file
        //File-----------------------------
        if (fuFile.HasFile)
        {
            //if has an old file
            if (!string.IsNullOrEmpty(oldFileExtension))
            {
                //Delete old original file
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + ItemCategoriesFactory.CreateFileName(category.CategoryID) + oldFileExtension);
            }
            //Save new original file
            fuFile.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + category.File);
        }
        //------------------------------------------------
        #endregion

        #region Save uploaded video
        //Video-----------------------------
        if (fuVideo.HasFile)
        {
            //if has an old video
            if (!string.IsNullOrEmpty(oldVideoExtension))
            {
                //Delete old original video
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + ItemCategoriesFactory.CreateFileName(category.CategoryID) + oldVideoExtension);
            }
            //Save new original video
            fuVideo.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + category.Video);
        }
        //------------------------------------------------
        #endregion
        #region Save uploaded audio
        //Audio-----------------------------
        if (fuAudio.HasFile)
        {
            //if has an old audio
            if (!string.IsNullOrEmpty(oldAudioExtension))
            {
                //Delete old original audio
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + ItemCategoriesFactory.CreateFileName(category.CategoryID) + oldAudioExtension);
            }
            //Save new original audio
            fuAudio.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + category.Audio);
        }
        //------------------------------------------------
        #endregion

        #region Save uploaded photo2

        //Photo2-----------------------------
        if (fuPhoto2.HasFile)
        {
            //if has an old Photo2
            if (!string.IsNullOrEmpty(oldPhoto2Extension))
            {
                //Delete old original Photo2
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + ItemCategoriesFactory.CreateFileName(category.CategoryID) + oldPhoto2Extension);
            }
            //Save new original Photo2
            fuPhoto2.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + category.Photo2);
        }
        //------------------------------------------------
        #endregion
    }
    //-----------------------------------------------
    #endregion

    //----------------------------------------------------------------------------
    protected void btnDeletePhoto_Click(object sender, EventArgs e)
    {
        int categoryID = Convert.ToInt32(Request.QueryString["id"]);
        ItemCategoriesEntity category = ItemCategoriesFactory.GetObject(categoryID, Languages.Unknowen, OwnerID);
        if (category != null)
        {
            //Photo-----------------------------
            if (!string.IsNullOrEmpty(category.PhotoExtension))
            {
                //Delete old original photo
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesPhotoOriginals (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + category.Photo);
                //Delete old Thumbnails
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesPhotoNormalThumbs (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + ItemCategoriesFactory.CreateItemCategoriesPhotoName(category.CategoryID) + MoversFW.Thumbs.thumbnailExetnsion);
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesPhotoBigThumbs(category.OwnerName,category.ModuleTypeID,category.CategoryID)) + ItemCategoriesFactory.CreateItemCategoriesPhotoName(category.CategoryID) + MoversFW.Thumbs.thumbnailExetnsion);
            }
            //------------------------------------------------

            trPhotoPreview.Visible = false;
            //-----------------------------

            category.PhotoExtension = "";
            ExecuteCommandStatus status = ItemCategoriesFactory.Update(category, currentModule);
            if (status == ExecuteCommandStatus.Done)
            {

                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.AdminText.DeletingOprationDone;
            }

            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.DeletingOprationFaild;
            }

        }
    }
    //----------------------------------------------------------------------------
    protected void btnDeletePhoto2_Click(object sender, EventArgs e)
    {
        int categoryID = Convert.ToInt32(Request.QueryString["id"]);
        ItemCategoriesEntity category = ItemCategoriesFactory.GetObject(categoryID, Languages.Unknowen,OwnerID);
        if (category != null)
        {
            //Photo2-----------------------------
            if (!string.IsNullOrEmpty(category.Photo2Extension))
            {
                //Delete photo2
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + category.Photo2);
            }
            //------------------------------------------------

            trPhoto2Preview.Visible = false;
            //-----------------------------

            category.Photo2Extension = "";
            ExecuteCommandStatus status = ItemCategoriesFactory.Update(category, currentModule);
            if (status == ExecuteCommandStatus.Done)
            {

                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.AdminText.DeletingOprationDone;
            }

            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.DeletingOprationFaild;
            }

        }
    }
    //----------------------------------------------------------------------------
    protected void ibtnDeleteFile_Click(object sender, ImageClickEventArgs e)
    {
        int categoryID = Convert.ToInt32(Request.QueryString["id"]);
        ItemCategoriesEntity category = ItemCategoriesFactory.GetObject(categoryID, Languages.Unknowen, OwnerID);
        if (category != null)
        {
            //File-----------------------------
            if (!string.IsNullOrEmpty(category.FileExtension))
            {
                //Delete file
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + category.File);
            }
            //------------------------------------------------

            trFilePreview.Visible = false;
            //-----------------------------

            category.FileExtension = "";
            ExecuteCommandStatus status = ItemCategoriesFactory.Update(category, currentModule);
            if (status == ExecuteCommandStatus.Done)
            {

                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.AdminText.DeletingOprationDone;
            }

            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.DeletingOprationFaild;
            }

        }
    }
    //----------------------------------------------------------------------------
    protected void ibtnDeleteVideo_Click(object sender, ImageClickEventArgs e)
    {
        int categoryID = Convert.ToInt32(Request.QueryString["id"]);
        ItemCategoriesEntity category = ItemCategoriesFactory.GetObject(categoryID, Languages.Unknowen, OwnerID);
        if (category != null)
        {
            //Video-----------------------------
            if (!string.IsNullOrEmpty(category.VideoExtension))
            {
                //Delete Video
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + category.Video);
            }
            //------------------------------------------------

            trVideoPreview.Visible = false;
            //-----------------------------

            category.VideoExtension = "";
            ExecuteCommandStatus status = ItemCategoriesFactory.Update(category, currentModule);
            if (status == ExecuteCommandStatus.Done)
            {

                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.AdminText.DeletingOprationDone;
            }

            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.DeletingOprationFaild;
            }

        }
    }
    //----------------------------------------------------------------------------
    protected void ibtnDeleteAudio_Click(object sender, ImageClickEventArgs e)
    {
        int categoryID = Convert.ToInt32(Request.QueryString["id"]);
        ItemCategoriesEntity category = ItemCategoriesFactory.GetObject(categoryID, Languages.Unknowen, OwnerID);
        if (category != null)
        {
            //Audio-----------------------------
            if (!string.IsNullOrEmpty(category.AudioExtension))
            {
                //Delete Audio
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemCategoriesFiles (category.OwnerName,category.ModuleTypeID,category.CategoryID)) + category.Audio);
            }
            //------------------------------------------------

            trAudioPreview.Visible = false;
            //-----------------------------

            category.AudioExtension = "";
            ExecuteCommandStatus status = ItemCategoriesFactory.Update(category, currentModule);
            if (status == ExecuteCommandStatus.Done)
            {

                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.AdminText.DeletingOprationDone;
            }

            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.DeletingOprationFaild;
            }

        }
    }
    //----------------------------------------------------------------------------

    

    //*****************************************************************

    //--------------------------------------------
    protected void LoadDetails(ItemCategoriesEntity category)
    {
        MLanguagesDetailsControls ucArDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucArDetails");
        MLanguagesDetailsControls ucEnDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucEnDetails");
        //if(HasArabic)
        LoadDetails(category, ucArDetails);
        //if(HasEngrabic)
        LoadDetails(category, ucEnDetails);
        //--------------------------------------------
    }
    //--------------------------------------------
    protected void LoadDetails(ItemCategoriesEntity category, MLanguagesDetailsControls ucDetails)
    {
        LoadDetailsControls(ucDetails);
        if (category.Details[ucDetails.Lang] != null)
        {
            ItemCategoriesDetailsEntity categoryDetailsObject = (ItemCategoriesDetailsEntity)category.Details[ucDetails.Lang];
            txtTitle.Text = categoryDetailsObject.Title;
            txtShortDescription.Text = categoryDetailsObject.ShortDescription;
            txtMetaKeyWords.Text = categoryDetailsObject.KeyWords;
            //-----------------------------------------------------------
            if (currentModule.CategoryDetailsInHtmlEditor)
                fckDescription.Text = categoryDetailsObject.Description;
            else
                txtDescription.Text = categoryDetailsObject.Description;
            //-----------------------------------------------------------

        }
    }
   
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
            ItemCategoriesDetailsEntity categoryDetailsObject = new ItemCategoriesDetailsEntity();
            categoryDetailsObject.LangID = ucDetails.Lang;
            categoryDetailsObject.Title = txtTitle.Text;
            categoryDetailsObject.ShortDescription = txtShortDescription.Text;
            categoryDetailsObject.KeyWords = txtMetaKeyWords.Text;

            //-----------------------------------------------------------
            if (currentModule.CategoryDetailsInHtmlEditor)
                categoryDetailsObject.Description = fckDescription.Text;
            else
                categoryDetailsObject.Description = txtDescription.Text;
            //-----------------------------------------------------------
            category.Details[categoryDetailsObject.LangID] = categoryDetailsObject;

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
    //*****************************************************************


}

