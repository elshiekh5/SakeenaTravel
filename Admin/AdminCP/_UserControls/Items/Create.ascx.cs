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


public partial class Items_Create : System.Web.UI.UserControl
{
    TextBox txtTitle;
    TextBox txtShortDescription;
    TextBox txtMetaKeyWords;
    CuteEditor.Editor fckDescription;
    TextBox txtDescription;
    TextBox txtAuthorName;
    TextBox txtAddress;
    TextBox txtExtraText_1;

    ItemsEntity selectedAuthor;

    ItemsModulesOptions currentModule;

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

    #region --------------Sender--------------
    private UsersTypes _Sender = UsersTypes.Admin;
    public UsersTypes Sender
    {
        get { return _Sender; }
        set { _Sender = value; }
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
        MLangsDetails1.ModuleTypeID = ModuleTypeID;
        lblResult.Text = "";
		if(!IsPostBack)
		{
            PrepareValidation();
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
        //HasCategory
        if (currentModule.CategoryLevel != 0)
        {
            trCategoryID.Visible = true;
            Load_ddlItemCategories();
        }
        else
        {
            trCategoryID.Visible = false;
        }
        //-----------------------------------
        //HasUrl
        trUrl.Visible = currentModule.HasUrl;
        rfvUrl.Visible = currentModule.HasUrl&&currentModule.RequiredUrl;
        revUrl.ValidationExpression = DCValidation.GetUrlExpression();

        //-----------------------------------
        //HasEmail
        trEmail.Visible = currentModule.HasEmail;
        rfvEmail.Visible = currentModule.HasEmail&&currentModule.RequiredEmail;
        //-----------------------------------
        //Height	
        trHeight.Visible = currentModule.HasHeight;
        rfvHeight.Visible = currentModule.HasHeight&&currentModule.RequiredHeight;
        //-----------------------------------
        //Width
        trWidth.Visible = currentModule.HasWidth;
        rfvWidth.Visible = currentModule.HasWidth && currentModule.RequiredWidth;
        //-----------------------------------
        //ItemDate
        trItemDate.Visible = currentModule.HasItemDate;
        //rfvItemDate.Visible = currentModule.HasItemDate && currentModule.RequiredItemDate;
        //-----------------------------------
        //ItemEndDate
        trItemEndDate.Visible = currentModule.HasItemEndDate;
        //rfvItemEndDate.Visible = currentModule.HasItemEndDate && currentModule.RequiredItemEndDate;
        //-----------------------------------
        //MailBox
        trMailBox.Visible = currentModule.HasMailBox;
        rfvMailBox.Visible = currentModule.HasMailBox&&currentModule.RequiredMailBox;
        //-----------------------------------
        //trZipCode
        trZipCode.Visible = currentModule.HasZipCode;
        rfvZipCode.Visible = currentModule.HasZipCode&&currentModule.RequiredZipCode;
        //-----------------------------------
        //Tels
        trTels.Visible = currentModule.HasTels;
        rfvTels.Visible = currentModule.HasTels&&currentModule.RequiredTels;
        //-----------------------------------
        //Fax
        trFax.Visible = currentModule.HasFax;
        rfvFax.Visible = currentModule.HasFax&&currentModule.RequiredFax;
        //-----------------------------------
        //Mobile
        trMobile.Visible = currentModule.HasMobile;
        rfvMobile.Visible = currentModule.HasMobile && currentModule.RequiredMobile;
        //-----------------------------------
        //HasPhotoExtension
        trPhotoExtension.Visible = currentModule.HasPhotoExtension;
        rfvPhoto.Visible = currentModule.HasPhotoExtension&&currentModule.RequiredPhoto;
        //-----------------------------------
        //HasFileExtension
        trFileExtension.Visible = currentModule.HasFileExtension;
        rfvFile.Visible = currentModule.HasFileExtension&&currentModule.RequiredFile;
        //-----------------------------------
        //trVideoExtension
        trVideoExtension.Visible = currentModule.HasVideoExtension;
        rfvVideo.Visible = currentModule.HasVideoExtension&&currentModule.RequiredVideo;
        //-----------------------------------
        //trAudioExtension
        trAudioExtension.Visible = currentModule.HasAudioExtension;
        rfvAudio.Visible = currentModule.HasAudioExtension&&currentModule.RequiredAudio;
        //-----------------------------------
        //trPhoto2Extension
        trPhoto2Extension.Visible = currentModule.HasPhoto2Extension;
        rfvPhoto2.Visible = currentModule.HasPhoto2Extension && currentModule.RequiredPhoto2;
        //-----------------------------------
        //trHasIsMain
        trHasIsMain.Visible = currentModule.HasIsMain && Sender == UsersTypes.Admin;
        //-----------------------------------
        //trHasIsMain
        trHasSpecialOption.Visible = currentModule.HasSpecialOption && Sender == UsersTypes.Admin;
        //-----------------------------------
        //HasIsAvailable
        trIsAvailable.Visible = currentModule.HasIsAvailable && Sender== UsersTypes.Admin;
        //-----------------------------------
        //HasPriority
        if (currentModule.HasPriority)
        {
            //----------------------------
            //HasCategory
            //----------------------------
            if (currentModule.CategoryLevel != 0)
            {
               
                ddlItemCategories.AutoPostBack = true;
                ddlItemCategories.SelectedIndexChanged += new EventHandler(this.ddlItemCategories_SelectedIndexChanged);
            }
            
            //----------------------------
            trPriority.Visible = true;
            LoadPriorities();
        }
        else
        {
            trPriority.Visible = false;
        }
        //-----------------------------------
        //trYouTubeCode
        trYoutubeCode.Visible = currentModule.HasYoutubeCode;
        rfvYoutubeCode.Visible = currentModule.HasYoutubeCode && currentModule.RequiredYoutubeCode;

        //-----------------------------------
        //trAuthorID
        trAuthorID.Visible = currentModule.HasAuthorID;
        if (currentModule.HasAuthorID) Load_ddlAuthorID();
        //-----------------------------------
        lblAdminNote.Text = currentModule.AdminNote;
        //-----------------------------------
        //trGoogleLatitude
        trGoogleLatitude.Visible = currentModule.HasGoogleLatitude;
        rfvGoogleLatitude.Visible = currentModule.HasGoogleLatitude && currentModule.RequiredGoogleLatitude;
        //-----------------------------------
        //trGoogleLongitude
        trGoogleLongitude.Visible = currentModule.HasGoogleLongitude;
        rfvGoogleLongitude.Visible = currentModule.HasGoogleLongitude && currentModule.RequiredGoogleLongitude;
        //-----------------------------------
        //trPrice
        trPrice.Visible = currentModule.HasPrice;
        rfvPrice.Visible = currentModule.HasPrice && currentModule.RequiredPrice;
        //-----------------------------------
        //trOnlyForRegisered
        trOnlyForRegisered.Visible = currentModule.HasOnlyForRegisered;
        //-----------------------------------
        //Files publishing
        cbPublishPhoto.Visible = currentModule.HasPublishPhoto;
        cbPublishPhoto2.Visible = currentModule.HasPublishPhoto2;
        cbPublishFile.Visible = currentModule.HasPublishFile;
        cbPublishAudio.Visible = currentModule.HasPublishAudio;
        cbPublishVideo.Visible = currentModule.HasPublishVideo;
        cbPublishYoutbe.Visible = currentModule.HasPublishYoutbe;
        //-----------------------------------------------
        //Visitors Participations
        //----------------------------
        if (Sender == UsersTypes.Admin)
        {
            trSenderName.Visible = false;
            trSenderEMail.Visible = false;
            trSenderCountry.Visible = false;
        }
        else
        {
            trSenderName.Visible = currentModule.HasSenderName;
            trSenderEMail.Visible = currentModule.HasSenderEMail;
            trSenderCountry.Visible = currentModule.HasSenderCountryID;
            if (currentModule.HasSenderCountryID)
                LoadCountries();
            //--------------------------------------------------------------
            rfvSenderEMail.Visible = currentModule.RequiredSenderEMail;
            rfvSenderName.Visible = currentModule.RequiredSenderName;
            rfvSenderCountry.Visible = currentModule.RequiredSenderCountryID;
            //--------------------------------------------------------------

        }
        //-----------------------------------------------
        if (!currentModule.HasTitle
        && !currentModule.HasShortDescription
        && !currentModule.HasDetails
        && !currentModule.HasDetails
        && !currentModule.HasAuthorName
        && !currentModule.HasAddress
        && !currentModule.HasExtraText_1)
        {
            trDetailsText.Visible = false;
            trDetailsControl.Visible = false; 
        }
        //-----------------------------------------------
        trType.Visible = currentModule.HasType;
        if (currentModule.HasType)
            Load_ddlType();
        rfvType.Visible = currentModule.RequiredType;
        //---------------------------------------------------------------------
        //FontAwsome icon 
        trIcon.Visible = currentModule.HasFontIcon;
        rfvIcon.Visible = currentModule.RequiredFontIcon;
        //---------------------------------------------------------------------

    }
	//-----------------------------------------------
	#endregion

    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
        lblCategoryID.Text = DynamicResource.GetText(currentModule, "CategoryID");
        lblPhotoExtension.Text = DynamicResource.GetText(currentModule, "PhotoExtension");
        lblFileExtension.Text = DynamicResource.GetText(currentModule, "FileExtension");
        lblUrl.Text = DynamicResource.GetText(currentModule, "Url");
        lblEmail.Text = DynamicResource.GetText(currentModule, "Email");
        lblIsMain.Text = DynamicResource.GetText(currentModule, "IsMain");

        lblSpecialOption.Text = DynamicResource.GetText(currentModule, "SpecialOption");

        lblIsAvailable.Text = DynamicResource.GetText(currentModule, "IsAvailable");

        lblVideoExtension.Text = DynamicResource.GetText(currentModule, "VideoExtension");
        lblAudioExtension.Text = DynamicResource.GetText(currentModule, "AudioExtension");
        lblPriority.Text = DynamicResource.GetText(currentModule, "Priority");
        lblPhoto2Extension.Text = DynamicResource.GetText(currentModule, "Photo2Extension");
        //-----------------------------------------------
        lblHeight.Text = DynamicResource.GetText(currentModule, "Height");
        lblWidth.Text = DynamicResource.GetText(currentModule, "Width");
        lblItemDate.Text = DynamicResource.GetText(currentModule, "ItemDate");
        lblItemEndDate.Text = DynamicResource.GetText(currentModule, "ItemEndDate");
        lblMailBox.Text = DynamicResource.GetText(currentModule, "MailBox");
        lblZipCode.Text = DynamicResource.GetText(currentModule, "ZipCode");
        lblTels.Text = DynamicResource.GetText(currentModule, "Tels");
        lblFax.Text = DynamicResource.GetText(currentModule, "Fax");
        lblMobile.Text = DynamicResource.GetText(currentModule, "Mobile");
        //-----------------------------------------------
        //Available Extension
        lblPhotoAvailableExtension.Text = currentModule.PhotoAvailableExtension.Replace(".", "");
        lblPhoto2AvailableExtension.Text = currentModule.Photo2AvailableExtension.Replace(".", "");
        lblFileAvailableExtension.Text = currentModule.FileAvailableExtension.Replace(".", "");
        lblAudioAvailableExtension.Text = currentModule.AudioAvailableExtension.Replace(".", "");
        lblVideoAvailableExtension.Text = currentModule.VideoAvailableExtension.Replace(".", "");
        //-----------------------------------------------
        lblYoutubeCode.Text = DynamicResource.GetText(currentModule, "YoutubeCode");
        lblAuthorID.Text = DynamicResource.GetText(currentModule, "AuthorID");
        //-----------------------------------------------
        lblPrice.Text = DynamicResource.GetText(currentModule, "Price");
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
        //Visitors Participations
        lblSenderName.Text = DynamicResource.GetText(currentModule, "SenderName");
        lblSenderEMail.Text = DynamicResource.GetText(currentModule, "SenderEMail");
        lblSenderCountry.Text = DynamicResource.GetText(currentModule, "SenderCountry");
        //-----------------------------------------------
        lblType.Text = DynamicResource.GetText(currentModule, "Type");
        //-----------------------------------------------
        lblIcon.Text = DynamicResource.GetText(currentModule, "Icon");

    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadCountries---------------
    //-----------------------------------------------
    //LoadCountries
    //-----------------------------------------------
    protected void LoadCountries()
    {
        List<SystemCountriesEntity> countriesList = SystemCountriesFactory.GetAll();
        string DataTextField = "country_ar";
        Languages lang = SiteSettings.GetCurrentLanguage();
        if (lang != Languages.Ar)
            DataTextField = "country";

        if (countriesList != null && countriesList.Count > 0)
        {
            ddlSenderCountry.DataSource = countriesList;
            ddlSenderCountry.DataTextField = DataTextField;
            ddlSenderCountry.DataValueField = "id";
            ddlSenderCountry.DataBind();
            ddlSenderCountry.Items.Insert(0, new ListItem(Resources.User.Choose, "-1"));
            ddlSenderCountry.SelectedValue = SiteSettings.Admininstration_SiteDefaultCountryID.ToString();
            ddlSenderCountry.Enabled = true;
        }
        else
        {
            ddlSenderCountry.Items.Clear();
            ddlSenderCountry.Items.Insert(0, new ListItem(Resources.User.NoData, "-1"));
            ddlSenderCountry.Enabled = false;
        }

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
        if (!string.IsNullOrEmpty(currentModule.PhotoAvailableExtension))
        {
            //Photo
            rxpPhoto.ValidationExpression = currentModule.GetPhotoValidationExpression();
            rxpPhoto.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.PhotoAvailableExtension;
        }
        else
        {
            rxpPhoto.Visible = false;
        }
        //---------------------------------
        //File
        if (!string.IsNullOrEmpty(currentModule.FileAvailableExtension))
        {
            rxpFile.ValidationExpression = currentModule.GetFileValidationExpression();
            rxpFile.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.FileAvailableExtension;
        }
        else
        {
            rxpFile.Visible = false;
        }
        //---------------------------------
        //Video
        if (!string.IsNullOrEmpty(currentModule.VideoAvailableExtension))
        {
            rxpVideo.ValidationExpression = currentModule.GetVideoValidationExpression();
            rxpVideo.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.VideoAvailableExtension;
        }
        else
        {
            rxpVideo.Visible = false;
        }
        //---------------------------------
        //Audio
        if (!string.IsNullOrEmpty(currentModule.AudioAvailableExtension))
        {
            rxpAudio.ValidationExpression = currentModule.GetAudioValidationExpression();
            rxpAudio.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.AudioAvailableExtension;
        }
        else
        {
            rxpAudio.Visible = false;
        }
        //---------------------------------
        //Photo2
        if (!string.IsNullOrEmpty(currentModule.Photo2AvailableExtension))
        {
            rxpPhoto2.ValidationExpression = currentModule.GetPhoto2ValidationExpression();
            rxpPhoto2.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.Photo2AvailableExtension;
        }
        else
        {
            rxpPhoto2.Visible = false;
        }
        //---------------------------------
    }
    //-----------------------------------------------
    #endregion
    
    #region ---------------Load_ddlItemCategories---------------
    //-----------------------------------------------
    //Load_ddlItemCategories
    //-----------------------------------------------
    private void Load_ddlItemCategories()
    {
        int categoriesDepth = currentModule.CategoryLevel;//NewsSiteSettings.Instance.CategoriesDepth;
        ParentChildDropDownList n = new ParentChildDropDownList();
        DataTable dtSource = ItemCategoriesFactory.GetAllInDataTable(ModuleTypeID, Languages.Unknowen, false, OwnerID);
        n.DataBind(ddlItemCategories, categoriesDepth, dtSource, "ParentID", "CategoryID", "Title");
        ddlItemCategories.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadPriorities---------------
    //-----------------------------------------------
    //LoadPriorities
    //-----------------------------------------------
    protected void LoadPriorities()
    {
        int categoryid = -1;
        if (trCategoryID.Visible)
        {
            categoryid = Convert.ToInt32(ddlItemCategories.SelectedValue);
        }
        int itemsCount = ItemsFactory.GetCount(currentModule.ModuleTypeID, categoryid, OwnerID);
        OurDropDownList.LoadPriorities(ddlPriority, itemsCount, true);
    }
    //-----------------------------------------------
    #endregion

    #region --------------Load_ddlAuthorID()--------------
    //---------------------------------------------------------
    //Load_ddlAuthorID
    //---------------------------------------------------------
    protected void Load_ddlAuthorID()
    {
        List<ItemsEntity> ItemsList = ItemsFactory.GetAllForAdmin((int)StandardItemsModuleTypes.Authors, OwnerID);
        if (ItemsList != null && ItemsList.Count > 0)
        {
            ddlAuthorID.DataSource = ItemsList;
            ddlAuthorID.DataTextField = "Title";
            ddlAuthorID.DataValueField = "ItemID";
            ddlAuthorID.DataBind();
            ddlAuthorID.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
            ddlAuthorID.Enabled = true;
        }
        else
        {
            ddlAuthorID.Items.Clear();
            ddlAuthorID.Items.Insert(0, new ListItem(Resources.AdminText.ThereIsNoData, "-1"));
            ddlAuthorID.Enabled = false;
        }
    }
    //--------------------------------------------------------
    #endregion

    #region --------------Load_ddlType()--------------
    //---------------------------------------------------------
    //Load_ddlType
    //---------------------------------------------------------
    protected void Load_ddlType()
    {

        ddlType.Items.Insert(0, new ListItem(Resources.User.Choose, "-1"));
        string text = "";
        string id = "";
        for (int i = 1; i <= currentModule.TypesCount; i++)
        {
            id = i.ToString();
            text = DynamicResource.GetText(currentModule, "Type_" + i);
            ddlType.Items.Add(new ListItem(text, id));
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
		HandleOptionalControls();
		
        SetTexts();

	}
	//-----------------------------------------------
	#endregion

    #region ---------------btnSave_Click---------------
    //-----------------------------------------------
    //btnSave_Click
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid || (currentModule.HasItemDate && !ucItemDate.IsValid) || (currentModule.HasItemEndDate && !ucItemEndDate.IsValid))
        {
            return;
        }
        //--------------------------------------------------
        ItemsEntity itemsObject = new ItemsEntity();
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
            if (!SiteSettings.CheckUploadedFileExtension(uploadedPhotoExtension, currentModule.PhotoAvailableExtension))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.NotSuportedFileExtention + currentModule.PhotoAvailableExtension;
                return;
            }*/
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuPhoto.PostedFile.ContentLength, currentModule.PhotoMaxSize))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.UploadedFileGreaterThanMaxLength + currentModule.PhotoMaxSize;
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
            if (!SiteSettings.CheckUploadedFileExtension(uploadedFileExtension, currentModule.FileAvailableExtension))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.NotSuportedFileExtention + currentModule.FileAvailableExtension;
                return;
            }*/
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuFile.PostedFile.ContentLength, currentModule.FileMaxSize))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.UploadedFileGreaterThanMaxLength + currentModule.FileMaxSize;
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
            if (!SiteSettings.CheckUploadedFileExtension(uploadedVideoExtension, currentModule.VideoAvailableExtension))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.NotSuportedVideoExtention + currentModule.VideoAvailableExtension;
                return;
            }*/
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuVideo.PostedFile.ContentLength, currentModule.VideoMaxSize))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.UploadedVideoGreaterThanMaxLength + currentModule.VideoMaxSize;
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
            if (!SiteSettings.CheckUploadedFileExtension(uploadedAudioExtension, currentModule.AudioAvailableExtension))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.NotSuportedAudioExtention + currentModule.VideoAvailableExtension;
                return;
            }*/
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuAudio.PostedFile.ContentLength, currentModule.AudioMaxSize))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.UploadedAudioGreaterThanMaxLength + currentModule.AudioMaxSize;
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
            if (!SiteSettings.CheckUploadedFileExtension(uploadedPhoto2Extension, currentModule.Photo2AvailableExtension))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.NotSuportedFileExtention + currentModule.Photo2AvailableExtension;
                return;
            }*/
            //Check max length
            if (!SiteSettings.CheckUploadedFileLength(fuPhoto2.PostedFile.ContentLength, currentModule.Photo2MaxSize))
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.UploadedFileGreaterThanMaxLength + currentModule.Photo2MaxSize;
                return;
            }
            //--------------------------------------------------------------------
        }
        //-----------------------------------------------------------------
        #endregion
        #endregion

        

        #region Set properties
        //items files 
        itemsObject.PhotoExtension = uploadedPhotoExtension;
        itemsObject.FileExtension = uploadedFileExtension;
        itemsObject.VideoExtension = uploadedVideoExtension;
        itemsObject.AudioExtension = uploadedAudioExtension;
        itemsObject.Photo2Extension = uploadedPhoto2Extension;
        //------------------------------------------------------
        #endregion
        #endregion

        //itemsObject.Title = txtTitle.Text;
        if (trCategoryID.Visible)
            itemsObject.CategoryID = Convert.ToInt32(ddlItemCategories.SelectedValue);
        //itemsObject.ShortDescription = txtShortDescription.Text;
        //itemsObject.Description = txtDetails.Value;
        itemsObject.Email = txtEmail.Text;
        
       // itemsObject.AuthorName = txtAuthorName.Text;
        if (currentModule.HasPriority && Sender == UsersTypes.Admin) itemsObject.Priority = Convert.ToInt32(ddlPriority.SelectedValue);
        itemsObject.Url = txtUrl.Text;
        if (currentModule.HasHeight) itemsObject.Height = Convert.ToInt32(txtHeight.Text);
        if (currentModule.HasWidth) itemsObject.Width = Convert.ToInt32(txtWidth.Text);
        //if (currentModule.HasItemDate && !string.IsNullOrEmpty(txtItemDate.Text)) itemsObject.ItemDate = Convert.ToDateTime(txtItemDate.Text);
        if (currentModule.HasItemDate && ucItemDate.Date != DateTime.MinValue) itemsObject.ItemDate = ucItemDate.Date;
        //-----------------------------------
        //ItemEndDate
        //if (currentModule.HasItemEndDate && !string.IsNullOrEmpty(txtItemEndDate.Text)) itemsObject.ItemEndDate = Convert.ToDateTime(txtItemEndDate.Text);
        if (currentModule.HasItemEndDate && ucItemEndDate.Date != DateTime.MinValue) itemsObject.ItemEndDate = ucItemEndDate.Date;

        //itemsObject.Address = txtAddress.Text;
        itemsObject.MailBox = txtMailBox.Text;
        itemsObject.ZipCode = txtZipCode.Text;
        itemsObject.Tels = txtTels.Text;
        itemsObject.Fax = txtFax.Text;
        itemsObject.Mobile = txtMobile.Text;
        //-------------------------------------------------------------------------------------------
        itemsObject.IsMain = CbIsMain.Checked;
        itemsObject.SpecialOption = cbSpecialOption.Checked;
        itemsObject.ModuleTypeID = ModuleTypeID;
        //-----------------------------------
        itemsObject.YoutubeCode = txtYoutubeCode.Text;
        //---------------------------------------------------------------------------------------------------------
        if(currentModule.HasGoogleLatitude)
            itemsObject.GoogleLatitude = Convert.ToDouble(txtGoogleLatitude.Text);
        //---------------------------------------------------------------------------------------------------------
        if (currentModule.HasGoogleLongitude)
            itemsObject.GoogleLongitude = Convert.ToDouble(txtGoogleLongitude.Text);
        //---------------------------------------------------------------------------------------------------------
        itemsObject.Price = txtPrice.Text;
        itemsObject.OnlyForRegisered = cbOnlyForRegisered.Checked;
        //---------------------------------------------------------------------------------------------------------
        //Files publishing
        itemsObject.PublishPhoto = cbPublishPhoto.Checked;
        itemsObject.PublishPhoto2 = cbPublishPhoto2.Checked;
        itemsObject.PublishFile = cbPublishFile.Checked;
        itemsObject.PublishAudio = cbPublishAudio.Checked;
        itemsObject.PublishVideo = cbPublishVideo.Checked;
        itemsObject.PublishYoutbe = cbPublishYoutbe.Checked;
        //---------------------------------------------------------------------------------------------------------
        if (currentModule.HasAuthorID)
        {
            int authorID = Convert.ToInt32(ddlAuthorID.SelectedValue);
            itemsObject.AuthorID = authorID;
            if (authorID > 0)
            {
                itemsObject.AuthorName = ddlAuthorID.SelectedItem.Text;
                selectedAuthor = ItemsFactory.GetObject(authorID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
            }
        }
        //-------------------------------------------------------------------------------------------
        //Check is  available 
        // logic of is available "if the module hasn't IsAvailable -> then  All items ara vailable "
        if (currentModule.HasIsAvailable && Sender == UsersTypes.Admin)
        {
            itemsObject.IsAvailable = cbIsAvailable.Checked;
        }
        else if (Sender == UsersTypes.User)
        {
            itemsObject.IsAvailable = false;
        }
        else
        {
            itemsObject.IsAvailable = true;
        }
        //-------------------------------------------------------------------------------------------
        itemsObject.Icon = txtIconControl.Text;

        //-----------------------------------------------
        //Visitors Participations
        //----------------------------
        if (Sender == UsersTypes.User || Sender == UsersTypes.SuperUser)
        {
            //----------------------------------------------------------------------------------------
            if (this.Page.User != null && this.Page.User.Identity.IsAuthenticated && !UsersDataFactory.IsCurrentUserTheAdmin())
            {
                MembershipUser user = Membership.GetUser(this.Page.User.Identity.Name);
                Guid userID = new Guid(user.ProviderUserKey.ToString());
                itemsObject.UserId = userID;
                UsersDataEntity userData = UsersDataFactory.GetUsersDataObject(userID, OwnerID);
                itemsObject.SenderName = userData.Name;
                itemsObject.SenderEMail = user.Email;

            }
            else
            {
                itemsObject.SenderName = txtSenderName.Text;
                itemsObject.SenderEMail = txtSenderEMail.Text;
            }
            //----------------------------------------------------------------------------------------
            //HasSenderCountryID
            if(currentModule.HasSenderCountryID)
                itemsObject.SenderCountryID = Convert.ToInt32(ddlSenderCountry.SelectedValue);
            //----------------------------------------------------------------------------------------
            itemsObject.IsVisitorsParticipations = true;
        }
        //----------------------------------------------------------------------------------------
        if (OwnerID!=null)
            itemsObject.OwnerID = (Guid)OwnerID;
        //-------------------------------------------------------------------------------------------
        if (currentModule.HasType)
            itemsObject.Type = Convert.ToInt32(ddlType.SelectedValue);
        //-------------------------------------------------------------------------------------------

        //Details -----------------------
        AddDetails(itemsObject);
        //----------------------------------------------------------------------------------------
        if (itemsObject.Details.Count == 0)
        {
            if (SiteSettings.Languages_HasArabicLanguages)
            {
                ItemsDetailsEntity arabicDetails = new ItemsDetailsEntity();
                arabicDetails.LangID = Languages.Ar;
                itemsObject.Details[Languages.Ar] = arabicDetails;
            }
            if (SiteSettings.Languages_HasEnglishLanguages)
            {
                ItemsDetailsEntity englishDetails = new ItemsDetailsEntity();
                englishDetails.LangID = Languages.En;
                itemsObject.Details[Languages.En] = englishDetails;
            }
        }
        //----------------------------------------------------------------------------------------

        //ItemsDetailsEntity d = itemsObject.Details[Languages.Ar];
        //if(selectedAuthor!=n)
        //-------------------------------
        ExecuteCommandStatus status = ItemsFactory.Create(itemsObject,currentModule);
        if (status == ExecuteCommandStatus.Done)
        {
            SaveFiles(itemsObject);
            //------------------------------------------------------------------------
            //RegisterInMailList
            if (currentModule.MailListAutomaticRegistration && !string.IsNullOrEmpty(itemsObject.Email))
                ItemsFactory.RegisterInMailList(itemsObject);
            //------------------------------------------------------------------------
            //RegisterInSms
            if (currentModule.SmsAutomaticRegistration && !string.IsNullOrEmpty(itemsObject.Mobile))
                ItemsFactory.RegisterInSms(itemsObject);
            //------------------------------------------------------------------------
            lblResult.CssClass = "lblResult_Done";
            lblResult.Text = Resources.AdminText.AddingOperationDone;
            ClearControls();
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
    protected void AddDetails(ItemsEntity item)
    {
        MLanguagesDetailsControls ucArDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucArDetails");
        MLanguagesDetailsControls ucEnDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucEnDetails");
        //if(HasArabic)
        GetDetails(item, ucArDetails);
        //if(HasEngrabic)
        GetDetails(item, ucEnDetails);
        //----------------------------
    }
    //--------------------------------------------
    protected void GetDetails(ItemsEntity item, MLanguagesDetailsControls ucDetails)
    {
        LoadDetailsControls(ucDetails);
        if (ucDetails.Visible && ((currentModule.RequiredTitle && txtTitle.Text.Length > 0) || !currentModule.RequiredTitle))
        {
            ItemsDetailsEntity itemDetailsObject = new ItemsDetailsEntity();
            itemDetailsObject.LangID = ucDetails.Lang;
            itemDetailsObject.Title = txtTitle.Text;
            itemDetailsObject.ShortDescription = txtShortDescription.Text;
            itemDetailsObject.KeyWords = txtMetaKeyWords.Text;
            //-----------------------------------------------------------
            if(currentModule.DetailsInHtmlEditor)
                itemDetailsObject.Description = fckDescription.Text;
            else
                itemDetailsObject.Description = txtDescription.Text;
            //-----------------------------------------------------------
            if (selectedAuthor != null&&selectedAuthor.Details.Contains(ucDetails.Lang))
            { 
                ItemsDetailsEntity selectedAuthorDetails =(ItemsDetailsEntity) selectedAuthor.Details[ucDetails.Lang];
                itemDetailsObject.AuthorName = selectedAuthorDetails.Title;
            }
            else
            {
                itemDetailsObject.AuthorName = txtAuthorName.Text;
            }
            itemDetailsObject.Address = txtAddress.Text;
            itemDetailsObject.ExtraData.Add(txtExtraText_1.Text);
            item.Details[itemDetailsObject.LangID] = itemDetailsObject;

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
        txtAuthorName = (TextBox)ucDetails.FindControl("txtAuthorName");
        txtAddress = (TextBox)ucDetails.FindControl("txtAddress");
        txtExtraText_1 = (TextBox)ucDetails.FindControl("txtExtraText_1");
    }
    //-----------------------------------------------
    #endregion

    #region ---------------SaveFiles---------------
    //-----------------------------------------------
    //SaveFiles
    //-----------------------------------------------
    protected void SaveFiles(ItemsEntity itemsObject)
    {
            #region Save uploaded photo
            //Photo-----------------------------
            if (fuPhoto.HasFile)
            {
                //------------------------------------------------
                //Save new original photo
                fuPhoto.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoOriginals(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Photo);
                //Create new thumbnails
                MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_ItemsPhotoNormalThumbs(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID), ItemsFactory.CreateItemsPhotoName(itemsObject.ItemID), fuPhoto.PostedFile, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight);
                MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_ItemsPhotoBigThumbs(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID), ItemsFactory.CreateItemsPhotoName(itemsObject.ItemID), fuPhoto.PostedFile, SiteSettings.Photos_BigThumnailWidth, SiteSettings.Photos_BigThumnailHeight);
                //-------------------------------------------------------

            }
            #endregion

            #region Save uploaded file
            //File-----------------------------
            if (fuFile.HasFile)
            {
                //Save new original file
                fuFile.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.File);
            }
            #endregion

            #region Save uploaded video
            //Video-----------------------------
            if (fuVideo.HasFile)
            {
                fuVideo.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Video);
            }
            #endregion

            #region Save uploaded audio
            //Audio-----------------------------
            if (fuAudio.HasFile)
            {
                fuAudio.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Audio);
            }
            #endregion

            #region Save uploaded photo2
            //-------------------------------------------------------------------------------------
            //Photo2-----------------------------
            if (fuPhoto2.HasFile)
            {
                fuPhoto2.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Photo2);
            }
            #endregion
    }
    //-----------------------------------------------
    #endregion

    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    private void ClearControls()
    {
        //txtTitle.Text = "";
        //ddlItemCategories.SelectedIndex = -1;
        //txtShortDescription.Text = "";
        //txtDetails.Value = "";
        txtUrl.Text = "";
        txtEmail.Text = "";
        cbIsAvailable.Checked = true;
        CbIsMain.Checked = false;
        cbSpecialOption.Checked = false;
        LoadPriorities();
        ddlPriority.SelectedIndex = -1;
        //txtAuthorName.Text = "";
        //-----------------------------------
        txtHeight.Text = "";
        txtWidth.Text = "";
        ucItemDate.ClearControls();
        ucItemEndDate.ClearControls();
       // txtAddress.Text = "";
        txtMailBox.Text = "";
        txtZipCode.Text = "";
        txtTels.Text = "";
        txtFax.Text = "";
        txtMobile.Text = "";
        //-----------------------------------
        txtYoutubeCode.Text = "";
        ddlAuthorID.SelectedIndex = -1;
        //-----------------------------------
        MLangsDetails1.ClearControls();
        //-----------------------------------
        txtGoogleLatitude.Text="";
        txtGoogleLongitude.Text="";
        txtPrice.Text="";
        cbOnlyForRegisered.Checked=false;
        //-----------------------------------
        //Files publishing
        cbPublishPhoto.Visible = false;
        cbPublishPhoto2.Visible = false;
        cbPublishFile.Visible = false;
        cbPublishAudio.Visible = false;
        cbPublishVideo.Visible = false;
        cbPublishYoutbe.Visible = false;
        //-----------------------------------
        //SenderName-------------------------
        txtSenderName.Text = "";
        txtSenderEMail.Text = "";
        ddlSenderCountry.SelectedIndex=-1;
        //-----------------------------------
        ddlType.SelectedIndex = -1;
        //-----------------------------------
        txtIconControl.Text = "";
    }
    //--------------------------------------------------------
    #endregion

 
    protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        if (e.Value.Length > 0)
            e.IsValid = true;
        else
            e.IsValid = false;
    }

    protected void ddlItemCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (currentModule.HasPriority)
        {
            LoadPriorities();
        }
    }
}

