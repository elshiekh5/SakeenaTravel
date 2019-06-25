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
using System.Net.Mail;

public partial class Messages_Update : System.Web.UI.UserControl
{
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

    #region --------------DefaultPagePath--------------
    private string _DefaultPagePath = null;
    public string DefaultPagePath
    {
        get { return _DefaultPagePath; }
        set { _DefaultPagePath = value; }
    }
    //------------------------------------------
    #endregion
    MessagesModuleOptions currentModule;
    string oldPhotoExtension;
    string oldFileExtension;
    string oldVideoExtension;
    string oldAudioExtension;
    string oldPhoto2Extension;
    string oldEmail;
    string oldMobile;
    List<string> attachmentsPathes;

	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
        currentModule = MessagesModuleOptions.GetType(ModuleTypeID);
        lblResult.Text = "";
		if(!IsPostBack)
		{
            MessagesFactory.ReArrangeTable(currentModule, tblControls);
            HandleOptionalControls();
            PrepareValidation();
            SetTexts();
            LoadData();
		}
	}
	//-----------------------------------------------
	#endregion

    #region --------------Load_ddlType()--------------
    //---------------------------------------------------------
    //Load_ddlType
    //---------------------------------------------------------
    protected void Load_ddlType()
    {

        ddlType.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
        string text = "";
        string id = "";
        for (int i = 1; i <= currentModule.TypesCount; i++)
        {
            id = i.ToString();
            text = DynamicResource.GetMessageModuleText(currentModule, "Type_" + i);
            ddlType.Items.Add(new ListItem(text, id));
        }
    }
    //--------------------------------------------------------
    #endregion
    #region --------------LoadCountries()--------------
    //---------------------------------------------------------
    //LoadCountries
    //---------------------------------------------------------
    protected void LoadCountries()
    {
        List<SystemCountriesEntity> countriesList = SystemCountriesFactory.GetAll();
        string DataTextField = "country_ar";
        Languages lang = SiteSettings.GetCurrentLanguage();
        if (lang != Languages.Ar)
            DataTextField = "country";
        OurDropDownList.LoadDropDownList(countriesList, ddlCountries, DataTextField, "id", true);
    }
    //------------------------------------------------------------
    #endregion

    #region ---------------LoadNationalityID---------------
    //-----------------------------------------------
    //LoadNationalityID
    //-----------------------------------------------
    protected void LoadNationalityID()
    {
        List<SystemCountriesEntity> countriesList = SystemCountriesFactory.GetAll();
        string DataTextField = "country_ar";
        Languages lang = SiteSettings.GetCurrentLanguage();
        if (lang != Languages.Ar)
            DataTextField = "country";

        if (countriesList != null && countriesList.Count > 0)
        {
            ddlNationalityID.DataSource = countriesList;
            ddlNationalityID.DataTextField = DataTextField;
            ddlNationalityID.DataValueField = "id";
            ddlNationalityID.DataBind();
            ddlNationalityID.Items.Insert(0, new ListItem(Resources.User.Choose, "-1"));
            ddlNationalityID.SelectedValue = SiteSettings.Admininstration_SiteDefaultCountryID.ToString();
            ddlNationalityID.Enabled = true;
        }
        else
        {
            ddlNationalityID.Items.Clear();
            ddlNationalityID.Items.Insert(0, new ListItem(Resources.User.NoData, "-1"));
            ddlNationalityID.Enabled = false;
        }

    }
    //-----------------------------------------------
    #endregion

    #region --------------Load_ddlCities()--------------
    //---------------------------------------------------------
    //Load_ddlCities
    //---------------------------------------------------------
    protected void Load_ddlCities()
    {
        int countryID = Convert.ToInt32(ddlCountries.SelectedValue);
        if (countryID > 0)
        {
            List<CitiesEntity> CitiesList = CitiesFactory.GetAll(countryID);
            if (CitiesList != null && CitiesList.Count > 0)
            {
                ddlCities.DataSource = CitiesList;
                ddlCities.DataTextField = "NameAr";
                Languages lang = SiteSettings.GetCurrentLanguage();
                if (lang != Languages.Ar)
                    ddlCities.DataTextField = "NameEn";

                ddlCities.DataValueField = "CityID";
                ddlCities.DataBind();
                ddlCities.Items.Insert(0, new ListItem(Resources.User.Choose, "-1"));
                ddlCities.Enabled = true;
            }
            else
            {
                ddlCities.Items.Clear();
                ddlCities.Items.Insert(0, new ListItem(Resources.User.ThereIsNoData, "-1"));
                ddlCities.Enabled = false;
            }
        }
        else
        {
            ddlCities.Items.Clear();
            ddlCities.Items.Insert(0, new ListItem(Resources.User.ThereIsNoData, "-1"));
            ddlCities.Enabled = false;
        }
    }
    //--------------------------------------------------------
    #endregion
    #region --------------Load_ddlToUserID()--------------
    //---------------------------------------------------------
    //Load_ddlToUserID
    //---------------------------------------------------------
    protected void Load_ddlToUserID()
    {
        List<UsersDataEntity> usersList = UsersDataFactory.GetAllByRole(currentModule.MemberRole, OwnerID);
        OurDropDownList.LoadDropDownList(usersList, ddlToUserID, "Name", "UserId", false);
        ddlToUserID.Items.Insert(0, new ListItem(Resources.User.Choose, Guid.Empty.ToString()));
    }
    //------------------------------------------------------------
    #endregion

    #region --------------Load_ddlItems()--------------
    //---------------------------------------------------------
    //Load_ddlItems
    //---------------------------------------------------------
    protected void Load_ddlItems()
    {
        List<ItemsEntity> ItemsList = ItemsFactory.GetAll(currentModule.ToItemModuleType, true,OwnerID);
        OurDropDownList.LoadDropDownList<ItemsEntity>(ItemsList, ddlItems, "Title", "ItemID", false);
    }
    //--------------------------------------------------------
    #endregion

    #region ---------------HandleOptionalControls---------------
    //-----------------------------------------------
    //HandleOptionalControls
    //-----------------------------------------------
    protected void HandleOptionalControls()
    {
        //----------------------------------------------------------------------
        //HasName
        trName.Visible = currentModule.HasName && !currentModule.HasNameSeparated ;
        trNameSeparated.Visible = currentModule.HasName && currentModule.HasNameSeparated;
        //----------------------------------------------------------------------
        if (trNameSeparated.Visible)
        {
            txtFName.Attributes.Add("onfocus", "ClearText('" + txtFName.ClientID + "','" + DynamicResource.GetMessageModuleText(currentModule, "FName") + "')");
            txtMname.Attributes.Add("onfocus", "ClearText('" + txtMname.ClientID + "','" + DynamicResource.GetMessageModuleText(currentModule, "Mname") + "')");
            txtLName.Attributes.Add("onfocus", "ClearText('" + txtLName.ClientID + "','" + DynamicResource.GetMessageModuleText(currentModule, "LName") + "')");
        }
        //----------------------------------------------------------------------
        trMobile.Visible = currentModule.HasMobile;
        trEMail.Visible = currentModule.HasEMail;
        if (currentModule.HasCountryID)
        {
            trCountryID.Visible = true;
            LoadCountries();
        }
        else
        {
            trCountryID.Visible = false;
        }
        //----------------------------------------------------------------------
        if (currentModule.HasNationalityID)
        {
            trNationalityID.Visible = true;
            LoadNationalityID();
        }
        else
        {
            trNationalityID.Visible = false;
        }
        //----------------------------------------------------------------------
        if (currentModule.CategoryLevel !=0)
        {
            trCategoryID.Visible = true;
            LoadCategories();
        }
        else
        {
            trCategoryID.Visible = false;
        }
        //----------------------------------------------------------------------
        if (currentModule.HasRedirectToMember)
        {
            trToUserID.Visible = true;
            Load_ddlToUserID();
        }
        else
        {
            trToUserID.Visible = false;
        }
        trAddress.Visible = currentModule.HasAddress;
        
        trJobTel.Visible = currentModule.HasJobTel;
        trType.Visible = currentModule.HasType;
        if (currentModule.HasType)
            Load_ddlType();
        trTitle.Visible = currentModule.HasTitle;
        trDetailsText.Visible = currentModule.HasDetails;
        trDetailsControl.Visible = currentModule.HasDetails;
        //----------------------------------------------------------------------
        //DetailsInHtmlEditor
        //----------------------------------------------------------------------
        if (currentModule.DetailsInHtmlEditor)
        {
            fckDetails.Visible = true;
            txtDetails.Visible = false;
        }
        else
        {
            fckDetails.Visible = false;
            txtDetails.Visible = true;
        }
        //----------------------------------------------------------------------
        if (currentModule.HasToItemID)
        {
            Load_ddlItems();
            trToItemID.Visible = true;
        }
        else
            trToItemID.Visible = false;
        //----------------------------------------------------------------------
        trIsAvailable.Visible = currentModule.HasIsAvailable;
        //----------------------------------------------------------------------
        trReplyText.Visible = currentModule.HasReply;
        trReply.Visible = currentModule.HasReply;
        //----------------------------------------------------------------------
        //ReplyInHtmlEditor
        //----------------------------------------------------------------------
        if (currentModule.ReplyInHtmlEditor)
        {
            fckReply.Visible = true;
            txtReply.Visible = false;
        }
        else
        {
            fckReply.Visible = false;
            txtReply.Visible = true;
        }
        //----------------------------------------------------------------------
        trAgeRang.Visible = currentModule.HasAgeRang;
        trGender.Visible = currentModule.HasGender;
        trBirthDate.Visible = currentModule.HasBirthDate;
        trSocialStatus.Visible = currentModule.HasSocialStatus;
        trEducationLevel.Visible = currentModule.HasEducationLevel;

        trEmpNo.Visible = currentModule.HasEmpNo;

        trCityID.Visible = currentModule.HasCityID;
        if (currentModule.HasCityID)
        {
            Load_ddlCities();
        }
        trUserCityName.Visible = currentModule.HasUserCityName;
        trTel.Visible = currentModule.HasTel;
        trHasSmsService.Visible = currentModule.HasHasSmsService;
        trHasEmailService.Visible = currentModule.HasHasEmailService;


        trFax.Visible = currentModule.HasFax;
        trMailBox.Visible = currentModule.HasMailBox;
        trZipCode.Visible = currentModule.HasZipCode;
        trJobID.Visible = currentModule.HasJobID;
        trJobText.Visible = currentModule.HasJobText;
        trUrl.Visible = currentModule.HasUrl;
        
        trCompany.Visible = currentModule.HasCompany;
        trActivitiesID.Visible = currentModule.HasActivitiesID;
        //----------------------------------------------------------------------
        //HasPhotoExtension
        trPhotoExtension.Visible = currentModule.HasPhotoExtension;
        trPhotoPreview.Visible = currentModule.HasPhotoExtension;
        rfvPhoto.Visible = false;
        //----------------------------------------------------------------------
        //HasFileExtension
        trFileExtension.Visible = currentModule.HasFileExtension;
        trFilePreview.Visible = currentModule.HasFileExtension;
        //rfvFile.Visible = currentModule.HasFileExtension && currentModule.RequiredFile;
        //----------------------------------------------------------------------
        //Height	
        trHeight.Visible = currentModule.HasHeight;
        rfvHeight.Visible = currentModule.HasHeight && currentModule.RequiredHeight;
        //----------------------------------------------------------------------
        //Width
        trWidth.Visible = currentModule.HasWidth;
        rfvWidth.Visible = currentModule.HasWidth && currentModule.RequiredWidth;
        //----------------------------------------------------------------------
        //ItemDate
        trItemDate.Visible = currentModule.HasItemDate;
        //rfvItemDate.Visible = currentModule.HasItemDate && currentModule.RequiredItemDate;
        //----------------------------------------------------------------------
        //trVideoExtension
        trVideoExtension.Visible = currentModule.HasVideoExtension;
        trVideoPreview.Visible = currentModule.HasVideoExtension;
        //rfvVideo.Visible = currentModule.HasVideoExtension && currentModule.RequiredVideo;
        //----------------------------------------------------------------------
        //trAudioExtension
        trAudioExtension.Visible = currentModule.HasAudioExtension;
        trAudioPreview.Visible = currentModule.HasAudioExtension;
        //rfvAudio.Visible = currentModule.HasAudioExtension && currentModule.RequiredAudio;
        //----------------------------------------------------------------------
        //trPhoto2Preview
        trPhoto2Extension.Visible = currentModule.HasPhoto2Extension;
        trPhoto2Preview.Visible = currentModule.HasPhoto2Extension;
        //rfvPhoto2.Visible = currentModule.HasPhoto2Extension && currentModule.RequiredPhoto2;
        //----------------------------------------------------------------------
        //trHasIsMain
        trHasIsMain.Visible = currentModule.HasIsMain;
        //----------------------------------------------------------------------
        //HasPriority
        if (currentModule.HasPriority)
        {
            trPriority.Visible = true;
            LoadPriorities();
        }
        else
        {
            trPriority.Visible = false;
        }
        //----------------------------------------------------------------------
        //trYouTubeCode
        trYoutubeCode.Visible = currentModule.HasYoutubeCode;
        //----------------------------------------------------------------------
        trShortDescription.Visible = (currentModule.HasShortDescription||currentModule.HasMetaDescription);
        //-----------------------------------
        //Previews
        ibtnDeletePhoto.Visible = !currentModule.RequiredPhotoExtension;
        ibtnDeleteFile.Visible = !currentModule.RequiredFile;
        btnDeletePhoto2.Visible = !currentModule.RequiredPhoto2;
        ibtnDeleteVideo.Visible = !currentModule.RequiredVideo;
        ibtnDeleteAudio.Visible = !currentModule.RequiredAudio;
        //----------------------------------------------------------------------
        lblAdminNote.Text = currentModule.AdminNote;
        //----------------------------------------------------------------------
        //trGoogleLatitude
        trGoogleLatitude.Visible = currentModule.HasGoogleLatitude;
        rfvGoogleLatitude.Visible = currentModule.HasGoogleLatitude && currentModule.RequiredGoogleLatitude;
        //----------------------------------------------------------------------
        //trGoogleLongitude
        trGoogleLongitude.Visible = currentModule.HasGoogleLongitude;
        rfvGoogleLongitude.Visible = currentModule.HasGoogleLongitude && currentModule.RequiredGoogleLongitude;
        //----------------------------------------------------------------------
        //trPrice
        trPrice.Visible = currentModule.HasPrice;
        rfvPrice.Visible = currentModule.HasPrice && currentModule.RequiredPrice;
        //----------------------------------------------------------------------
        //trOnlyForRegisered
        trOnlyForRegisered.Visible = currentModule.HasOnlyForRegisered;
        //----------------------------------------------------------------------
        //Files publishing
        cbPublishPhoto.Visible = currentModule.HasPublishPhoto;
        cbPublishPhoto2.Visible = currentModule.HasPublishPhoto2;
        cbPublishFile.Visible = currentModule.HasPublishFile;
        cbPublishAudio.Visible = currentModule.HasPublishAudio;
        cbPublishVideo.Visible = currentModule.HasPublishVideo;
        cbPublishYoutbe.Visible = currentModule.HasPublishYoutbe;
        //----------------------------------------------------------------------
        trMetaKeyWords.Visible = currentModule.HasMetaKeyWords;
        //----------------------------------------------------------------------
        //-------------------------------------------
        //Attatchments
        trAttatch1.Visible = currentModule.HasAttachmentsInReplay;
        trAttatch2.Visible = currentModule.HasAttachmentsInReplay;
        trAttatch3.Visible = currentModule.HasAttachmentsInReplay;
        //-------------------------------------------
    }
    //-----------------------------------------------
    #endregion

    #region ---------------PrepareValidation---------------
    //-----------------------------------------------
    //PrepareValidation
    //-----------------------------------------------
    public void PrepareValidation()
    {
        //************************************************************************
        if (!string.IsNullOrEmpty(currentModule.PhotoAvailableExtension))
        {
            //Photo
            rxpPhoto.ValidationExpression = currentModule.GetPhotoValidationExpression();
            rxpPhoto.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.PhotoAvailableExtension;
            //-----------------------------------------------------------------------------
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
        //************************************************************************
        rfvName.Visible = currentModule.RequiredName;
        rfvMobile.Visible = currentModule.RequiredMobile;
        rfvEMail.Visible = currentModule.RequiredEMail;
        rfvCountryID.Visible = currentModule.RequiredCountryID;
        rfvNationalityID.Visible = currentModule.RequiredNationalityID;
        rfvAddress.Visible = currentModule.RequiredAddress;
        rfvJobTel.Visible = currentModule.RequiredJobTel;
        rfvType.Visible = currentModule.RequiredType;
        rfvTitle.Visible = currentModule.RequiredTitle;
        rfvDetails.Visible = (currentModule.RequiredDetails && !currentModule.DetailsInHtmlEditor);
        rfvToItemID.Visible = currentModule.RequiredToItemID;
        //-----------------------------------------------------------
        rfvJobID.Visible = currentModule.RequiredJobID;
        rfvJobText.Visible = currentModule.RequiredJobText;
        rfvEmpNo.Visible = currentModule.RequiredEmpNo;
        rfvCityID.Visible = currentModule.RequiredCityID;
        rfvUserCityName.Visible = currentModule.RequiredUserCityName;
        rfvCompany.Visible = currentModule.RequiredCompany;
        rfvActivitiesID.Visible = currentModule.RequiredActivitiesID;
        rfvUrl.Visible = currentModule.RequiredUrl;
        rfvTel.Visible = currentModule.RequiredTel;
        rfvMobile.Visible = currentModule.RequiredMobile;
        rfvFax.Visible = currentModule.RequiredFax;
        rfvMailBox.Visible = currentModule.RequiredMailBox;
        rfvZipCode.Visible = currentModule.RequiredZipCode;
        rfvAgeRang.Visible = currentModule.RequiredAgeRang;
        rfvGender.Visible = currentModule.RequiredGender;
        // ucDateBirthDate = currentModule.Required.XXXXXXXXXX;
        rfvSocialStatus.Visible = currentModule.RequiredSocialStatus;
        rfvEducationLevel.Visible = currentModule.RequiredEducationLevel;
        //---------------------------------
        rfvYoutubeCode.Visible = currentModule.HasYoutubeCode && currentModule.RequiredYoutubeCode;
        //---------------------------------
        rfvShortDescription.Visible = currentModule.HasYoutubeCode && currentModule.RequiredShortDescription;
    }
    //-----------------------------------------------
    #endregion

    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
        //---------------------------------------------------------------------------------
        lblName.Text = DynamicResource.GetMessageModuleText(currentModule, "Name");
        //---------------------------------------------------------------------------------
        lblNameSeparated.Text = DynamicResource.GetMessageModuleText(currentModule, "Name");
        txtFName.Text = DynamicResource.GetMessageModuleText(currentModule, "FName");
        rfvFName.InitialValue = txtFName.Text;
        txtMname.Text = DynamicResource.GetMessageModuleText(currentModule, "Mname");
        rfvMName.InitialValue = txtMname.Text;
        txtLName.Text = DynamicResource.GetMessageModuleText(currentModule, "LName");
        rfvLName.InitialValue = txtLName.Text;
        //---------------------------------------------------------------------------------
        lblEmail.Text = DynamicResource.GetMessageModuleText(currentModule, "Email");
        lblMobile.Text = DynamicResource.GetMessageModuleText(currentModule, "Mobile");
        lblCountryID.Text = DynamicResource.GetMessageModuleText(currentModule, "CountryID");
        lblNationalityID.Text = DynamicResource.GetMessageModuleText(currentModule, "NationalityID");
        lblAddress.Text = DynamicResource.GetMessageModuleText(currentModule, "Address");
        lblJobTel.Text = DynamicResource.GetMessageModuleText(currentModule, "JobTel");
        lblType.Text = DynamicResource.GetMessageModuleText(currentModule, "Type");
        lblTitle.Text = DynamicResource.GetMessageModuleText(currentModule, "Title");
        lblToItemID.Text = DynamicResource.GetMessageModuleText(currentModule, "ToItemID");
        lblDetails.Text = DynamicResource.GetMessageModuleText(currentModule, "Details");

        lblEmpNo.Text = DynamicResource.GetMessageModuleText(currentModule, "EmpNo");
        lblBirthDate.Text = DynamicResource.GetMessageModuleText(currentModule, "BirthDate");
        lblCityID.Text = DynamicResource.GetMessageModuleText(currentModule, "CityID");
        lblUserCityName.Text = DynamicResource.GetMessageModuleText(currentModule, "UserCityName");
        lblGender.Text = DynamicResource.GetMessageModuleText(currentModule, "Gender");
        lblHasEmailService.Text = DynamicResource.GetMessageModuleText(currentModule, "HasEmailService");
        lblHasSmsService.Text = DynamicResource.GetMessageModuleText(currentModule, "HasSmsService");
        //lblNotes2.Text = DynamicResource.GetMessageModuleText(currentModule, "Notes2");
        //lblNotes1.Text = DynamicResource.GetMessageModuleText(currentModule, "Notes1");
        lblTel.Text = DynamicResource.GetMessageModuleText(currentModule, "Tel");
        lblAgeRang.Text = DynamicResource.GetMessageModuleText(currentModule, "AgeRang");
        lblEducationLevel.Text = DynamicResource.GetMessageModuleText(currentModule, "EducationLevel");
        ddlEducationLevel.Items[1].Text = DynamicResource.GetMessageModuleText(currentModule, "EducationLevel_1");
        ddlEducationLevel.Items[2].Text = DynamicResource.GetMessageModuleText(currentModule, "EducationLevel_2");
        ddlEducationLevel.Items[3].Text = DynamicResource.GetMessageModuleText(currentModule, "EducationLevel_3");
        //ddlEducationLevel.Items[4].Text = DynamicResource.GetMessageModuleText(currentModule, "EducationLevel_4");
        //ddlEducationLevel.Items[5].Text = DynamicResource.GetMessageModuleText(currentModule, "EducationLevel_5");

        lblSocialStatus.Text = DynamicResource.GetMessageModuleText(currentModule, "SocialStatus");
        lblFax.Text = DynamicResource.GetMessageModuleText(currentModule, "Fax");
        lblMailBox.Text = DynamicResource.GetMessageModuleText(currentModule, "MailBox");
        lblZipCode.Text = DynamicResource.GetMessageModuleText(currentModule, "ZipCode");
        lblJobID.Text = DynamicResource.GetMessageModuleText(currentModule, "JobID");
        lblJobText.Text = DynamicResource.GetMessageModuleText(currentModule, "JobText");
        lblUrl.Text = DynamicResource.GetMessageModuleText(currentModule, "Url");
        lblPhotoExtension.Text = DynamicResource.GetMessageModuleText(currentModule, "PhotoExtension");
        lblCompany.Text = DynamicResource.GetMessageModuleText(currentModule, "Company");
        lblActivitiesID.Text = DynamicResource.GetMessageModuleText(currentModule, "ActivitiesID");
        lblFileExtension.Text = DynamicResource.GetMessageModuleText(currentModule, "FileExtension");
        lblSendingDate.Text = DynamicResource.GetMessageModuleText(currentModule, "DateAdded");
        //-----------------------------------------
        lblToUserID.Text = DynamicResource.GetMessageModuleText(currentModule, "ToUserID");
        lblIsAvailable.Text = DynamicResource.GetMessageModuleText(currentModule, "IsAvailable");
        lblReply.Text = DynamicResource.GetMessageModuleText(currentModule, "Reply");
        //-----------------------------------------
        //-----------------------------------------------------------
        //New Columns nnnnnnnnnnnnnnnnnnnnnnnnnnn---------
        //-----------------------------------
        lblIsMain.Text = DynamicResource.GetMessageModuleText(currentModule, "IsMain");
        lblVideoExtension.Text = DynamicResource.GetMessageModuleText(currentModule, "VideoExtension");
        lblAudioExtension.Text = DynamicResource.GetMessageModuleText(currentModule, "AudioExtension");
        lblPriority.Text = DynamicResource.GetMessageModuleText(currentModule, "Priority");
        lblPhoto2Extension.Text = DynamicResource.GetMessageModuleText(currentModule, "Photo2Extension");
        lblHeight.Text = DynamicResource.GetMessageModuleText(currentModule, "Height");
        lblWidth.Text = DynamicResource.GetMessageModuleText(currentModule, "Width");
        lblItemDate.Text = DynamicResource.GetMessageModuleText(currentModule, "ItemDate");
        //Available Extension
        lblPhotoAvailableExtension.Text = currentModule.PhotoAvailableExtension.Replace(".", "");
        lblPhoto2AvailableExtension.Text = currentModule.Photo2AvailableExtension.Replace(".", "");
        lblFileAvailableExtension.Text = currentModule.FileAvailableExtension.Replace(".", "");
        lblAudioAvailableExtension.Text = currentModule.AudioAvailableExtension.Replace(".", "");
        lblVideoAvailableExtension.Text = currentModule.VideoAvailableExtension.Replace(".", "");
        //-----------------------------------------------
        lblYoutubeCode.Text = DynamicResource.GetMessageModuleText(currentModule, "YoutubeCode");
        //-----------------------------------
        //End of New Columns nnnnnnnnnnnnnnnnnnnnnnnnnnn---------
        lblShortDescription.Text = DynamicResource.GetMessageModuleText(currentModule, "ShortDescription");
        //--------------------------------------------------------------------
        lblPrice.Text = DynamicResource.GetMessageModuleText(currentModule, "Price");
        lblGoogleLatitude.Text = DynamicResource.GetMessageModuleText(currentModule, "GoogleLatitude");
        lblGoogleLongitude.Text = DynamicResource.GetMessageModuleText(currentModule, "GoogleLongitude");
        lblOnlyForRegisered.Text = DynamicResource.GetMessageModuleText(currentModule, "OnlyForRegisered");
        //--------------------------------------------------------------------
        cbPublishPhoto.Text = DynamicResource.GetMessageModuleText(currentModule, "PublishPhoto");
        cbPublishPhoto2.Text = DynamicResource.GetMessageModuleText(currentModule, "PublishPhoto2");
        cbPublishFile.Text = DynamicResource.GetMessageModuleText(currentModule, "PublishFile");
        cbPublishAudio.Text = DynamicResource.GetMessageModuleText(currentModule, "PublishAudio");
        cbPublishVideo.Text = DynamicResource.GetMessageModuleText(currentModule, "PublishVideo");
        cbPublishYoutbe.Text = DynamicResource.GetMessageModuleText(currentModule, "PublishYoutbe");
        //--------------------------------------------------------------------
        lblMetaKeyWords.Text = DynamicResource.GetMessageModuleText(currentModule, "MetaKeyWords");
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadCategories---------------
    //-----------------------------------------------
    //LoadCategories
    //-----------------------------------------------
    private void LoadCategories()
    {
        int categoriesDepth = currentModule.CategoryLevel;//NewsSiteSettings.Instance.CategoriesDepth;
        ParentChildDropDownList n = new ParentChildDropDownList();
        DataTable dtSource = ItemCategoriesFactory.GetAllInDataTable(ModuleTypeID, Languages.Ar, false, OwnerID);
        n.DataBind(ddlCategoryID, categoriesDepth, dtSource, "ParentID", "CategoryID", "Title");
        ddlCategoryID.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
    }
    //-----------------------------------------------
    #endregion
    #region ---------------LoadPriorities---------------
    //-----------------------------------------------
    //LoadPriorities
    //-----------------------------------------------
    protected void LoadPriorities()
    {
        int messagesCount = MessagesFactory.GetCount(currentModule.ModuleTypeID, OwnerID);
        OurDropDownList.LoadPriorities(ddlPriority, messagesCount, false);
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
            int messageID = Convert.ToInt32(Request.QueryString["id"]);
            MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, OwnerID);
            if (msg != null)
            {
                //------------------------------------------------
                if (currentModule.HasName && !currentModule.HasNameSeparated)
                {
                    txtName.Text = msg.Name;
                }
                else if (currentModule.HasName && currentModule.HasNameSeparated)
                {
                    //------------------------------------------------------------
                    string[] names = msg.Name.Split(new Char[] { ',' });
                    string fname = "", mname = "", lname = "";
                    fname = names[0];
                    if (names.Length > 1)
                        mname = names[1];
                    if (names.Length > 2)
                        lname = names[2];
                    txtFName.Text = fname;
                    txtMname.Text = mname;
                    txtLName.Text = lname;
                    //------------------------------------------------------------
                }
                txtMobile.Text = msg.Mobile;
                txtEMail.Text = msg.EMail;
                if(currentModule.HasCountryID)
                    ddlCountries.SelectedValue = msg.CountryID.ToString();
                //--------------------------------------------------------------------------
                if (currentModule.HasNationalityID)
                    ddlNationalityID.SelectedValue = msg.NationalityID.ToString();
                //--------------------------------------------------------------------------
                if (currentModule.CategoryLevel != 0)
                    ddlCategoryID.SelectedValue = msg.CategoryID.ToString();
                txtAddress.Text = msg.Address;
                txtJobTel.Text = msg.JobTel;
                ddlType.SelectedValue = msg.Type.ToString();
                txtTitle.Text = msg.Title;
                //-------------------------------------
                if (currentModule.DetailsInHtmlEditor)
                    fckDetails.Text = msg.Details;
                else
                    txtDetails.Text = msg.Details;
                //-------------------------------------
                ddlItems.SelectedValue = msg.ToItemID.ToString();
                cbIsAvailable.Checked = msg.IsAvailable;
                ddlToUserID.SelectedValue = msg.ToUserID.ToString();
                //------------------------------------------------
                if (currentModule.HasEmpNo)
                    txtEmpNo.Text = msg.EmpNo.ToString();
                #region ----------Photo----------
                //-------------------------------------------
                //Photo
                //-------------------------------------------
                if (currentModule.HasPhotoExtension && !string.IsNullOrEmpty(msg.PhotoExtension))
                {
                    imgPhoto.ImageUrl = MessagesFactory.GetPhotoThumbnail(msg.MessageID, msg.PhotoExtension, 100, 100, msg.OwnerName,msg.ModuleTypeID,msg.CategoryID);
                    ancor.HRef = MessagesFactory.GetPhotoBigThumbnail(msg.MessageID, msg.PhotoExtension, msg.OwnerName, msg.ModuleTypeID, msg.CategoryID);
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
                if (!string.IsNullOrEmpty(msg.FileExtension))
                {
                    hlFile.HRef = "/WebSite/FileDownload.aspx?id=" + msg.MessageID + "&type=1";
                }
                else
                {
                    hlFile.Visible = false;
                    ibtnDeleteFile.Visible = false;
                }
                //------------------------------------------
                //------------------------------------------
                #endregion
                //------------------------------------------------------------
                if (currentModule.HasAgeRang)
                    ddlAgeRang.SelectedValue = msg.AgeRang.ToString();
                if (currentModule.HasGender)
                    ddlGender.SelectedValue = ((int)msg.Gender).ToString();
                if (currentModule.HasBirthDate)
                    ucDateBirthDate.Date = Convert.ToDateTime(msg.BirthDate);
                if (currentModule.HasSocialStatus)
                    ddlSocialStatus.SelectedValue = msg.SocialStatus.ToString();
                if (currentModule.HasEducationLevel)
                    ddlEducationLevel.SelectedValue = msg.EducationLevel.ToString();
                
                if (currentModule.HasCityID)
                    ddlCities.SelectedValue = msg.CityID.ToString();
                //------------------------------------------------------------
                if (currentModule.HasUserCityName)
                    txtUserCityName.Text = msg.UserCityName.ToString();
                if (currentModule.HasTel)
                    txtTel.Text = msg.Tel;
                
                if (currentModule.HasHasSmsService)
                    cbHasSmsService.Checked = msg.HasSmsService;
                if (currentModule.HasHasEmailService)
                    cbHasEmailService.Checked = msg.HasEmailService;
                //------------------------------------------------------------
                if (currentModule.HasFax)
                    txtFax.Text = msg.Fax;
                if (currentModule.HasMailBox)
                    txtMailBox.Text = msg.MailBox;
                if (currentModule.HasZipCode)
                    txtZipCode.Text = msg.ZipCode;
                if (currentModule.HasJobID)
                    txtJobID.Text = msg.JobID.ToString();
                if (currentModule.HasJobText)
                    txtJobText.Text = msg.JobText;
                if (currentModule.HasUrl)
                    txtUrl.Text = msg.Url;
                //------------------------------------------------------------
                if (currentModule.HasCompany)
                    txtCompany.Text = msg.Company;
                if (currentModule.HasActivitiesID)
                    ddlActivitiesID.SelectedValue = msg.ActivitiesID.ToString();
                //------------------------------------------------------------
                //-------------------------------------
                if (currentModule.ReplyInHtmlEditor)
                    fckReply.Text = msg.Reply;
                else
                    txtReply.Text = msg.Reply;
                //-------------------------------------
                lblDate.Text = General.ConvertDateToHijri2(msg.Date_Added) +" "+ Resources.User.Mofeq +" "+ msg.Date_Added.ToLongDateString();
                if (msg.UserId != Guid.Empty)
                {
                    MembershipUser user = Membership.GetUser(msg.UserId);
                    Guid userID = msg.UserId;
                    msg.UserId = userID;
                    UsersDataEntity userData = UsersDataFactory.GetUsersDataObject(userID, OwnerID);
                    txtName.Text = userData.Name;
                    txtEMail.Text = user.Email;
                }
                //-----------------------------------------------------------
                //New Columns nnnnnnnnnnnnnnnnnnnnnnnnnnn---------
                //-----------------------------------
                if (currentModule.HasPriority)
                {
                    ddlPriority.SelectedValue = msg.Priority.ToString();
                }
                CbIsMain.Checked = msg.IsMain;
                txtHeight.Text = msg.Height.ToString();
                txtWidth.Text = msg.Width.ToString();
                //txtItemDate.Text = msg.ItemDateString;
                ucItemDate.Date = msg.ItemDate;
                #region ----------Item files----------
                #region ----------Video----------
                //-------------------------------------------
                //Video
                //-------------------------------------------
                //VideoExtension
                if (!string.IsNullOrEmpty(msg.VideoExtension))
                {
                    hlVideo.HRef = "/WebSite/FileDownload.aspx?id=" + msg.MessageID + "&type=2";
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
                if (!string.IsNullOrEmpty(msg.AudioExtension))
                {
                    hlAudio.HRef = "/WebSite/FileDownload.aspx?id=" + msg.MessageID + "&type=3";
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
                if (!string.IsNullOrEmpty(msg.Photo2Extension))
                {
                    imgPhoto2.ImageUrl = DCSiteUrls.GetPath_MessagesFiles(msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID) + msg.Photo2;
                    ancor.HRef = DCSiteUrls.GetPath_MessagesFiles(msg.OwnerName, msg.ModuleTypeID, msg.CategoryID,msg.MessageID) + msg.Photo2;
                    //imgPhoto2.AlternateText = msg.Title;
                }
                else
                {
                    trPhoto2Preview.Visible = false;
                }
                //------------------------------------------
                //------------------------------------------
                #endregion
                //-----------------------------------
                if (!string.IsNullOrEmpty(msg.YoutubeCode))
                {
                    txtYoutubeCode.Text = msg.YoutubeCode;
                    aYoutube.HRef = "/PopUps/Youtube.aspx?v=" + msg.YoutubeCode;
                }
                else
                {
                    aYoutube.Visible = false;
                }
                #endregion
                //-----------------------------------
                //End of New Columns nnnnnnnnnnnnnnnnnnnnnnnnnnn---------
                //-----------------------------------
                txtGoogleLatitude.Text = msg.GoogleLatitude.ToString();
                txtGoogleLongitude.Text = msg.GoogleLongitude.ToString();
                txtPrice.Text = msg.Price;
                cbOnlyForRegisered.Checked = msg.OnlyForRegisered;
                //-----------------------------------
                //Files publishing
                cbPublishPhoto.Checked = msg.PublishPhoto;
                cbPublishPhoto2.Checked = msg.PublishPhoto2;
                cbPublishFile.Checked = msg.PublishFile;
                cbPublishAudio.Checked = msg.PublishAudio;
                cbPublishVideo.Checked = msg.PublishVideo;
                cbPublishYoutbe.Checked = msg.PublishYoutbe;
                //-----------------------------------
                txtShortDescription.Text = msg.ShortDescription;
                //-----------------------------------
                txtMetaKeyWords.Text = msg.KeyWords;
                //-----------------------------------
            }
            else
            {
                if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubAdmin)
                {
                    Response.Redirect("/AdminSub/Messages/" + currentModule.Identifire + "/default.aspx");
                }
                else
                {
                    Response.Redirect("/AdminCP/Messages/" + currentModule.Identifire + "/default.aspx");
                }
            }
        }
        else
        {
            if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubAdmin)
            {
                Response.Redirect("/AdminSub/Messages/" + currentModule.Identifire + "/default.aspx");
            }
            else
            {
                Response.Redirect("/AdminCP/Messages/" + currentModule.Identifire + "/default.aspx");
            }
        }
    }
	//-----------------------------------------------
	#endregion
    #region --------------SendReplyByMail()--------------
    //---------------------------------------------------------
    //SendReplyByMail
    //---------------------------------------------------------
    protected void SendReplyByMail(string subject, string body)
    {
        try
        {
            MailListEmailsEntity mail = new MailListEmailsEntity();
            mail.To.Add(txtEMail.Text);
            mail.Subject = subject;
            mail.Body = body;
            //------------------------------------------------------------------------
            if (SiteSettings.Admininstration_HasAdminBccEmail)
            {
                string AdminbccMail = SiteSettings.Admininstration_AdminBccEmail;
                mail.Bcc.Add(AdminbccMail);
            }
            //------------------------------------------------------------------------
            #region Attachments
            if (SiteSettings.MailList_HasAttachments)
            {
                //-----------------------------------------------------------------
                attachmentsPathes = new List<string>();
                MailListEmailsFactory.AddAttatchPath(attachmentsPathes, fuAttach1);
                MailListEmailsFactory.AddAttatchPath(attachmentsPathes, fuAttach2);
                MailListEmailsFactory.AddAttatchPath(attachmentsPathes, fuAttach3);
                //-----------------------------------------------------------------
            }
            //-----------------------------------------------
            if (attachmentsPathes != null)
            {
                foreach (string item in attachmentsPathes)
                {
                    mail.AttachmentsFilesPathes.Add(item);
                    mail.Attachments.Add(new Attachment(item));
                }
            }
            //-----------------------------------------------
            #endregion
            MailListEmailsFactory.Send(mail);
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "aaaaa", "<script>alert('" + Resources.AdminText.SendingOperationDone + "');</script>");
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
    //---------------------------------------------------------
    #endregion
    #region --------------btnSave_Click()--------------
    //---------------------------------------------------------
    //btnSave_Click
    //---------------------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            if (!Page.IsValid)
            {
                return;
            }
            int messageID = Convert.ToInt32(Request.QueryString["id"]);
            MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, OwnerID);
            oldEmail = msg.EMail;
            oldMobile = msg.Mobile;

            #region Item Files properties
            //Old files extension 
            oldPhotoExtension = msg.PhotoExtension;
            oldFileExtension = msg.FileExtension;
            oldVideoExtension = msg.VideoExtension;
            oldAudioExtension = msg.AudioExtension;
            oldPhoto2Extension = msg.Photo2Extension;
            //---------------------------
            // uploaded files extenssions
            string uploadedPhotoExtension = Path.GetExtension(fuPhoto.FileName);
            string uploadedFileExtension = Path.GetExtension(fuFile.FileName);
            string uploadedVideoExtension = Path.GetExtension(fuVideo.FileName);
            string uploadedAudioExtension = Path.GetExtension(fuAudio.FileName);
            string uploadedPhoto2Extension = Path.GetExtension(fuPhoto2.FileName);
            //---------------------------------------------------------------------
            #endregion

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
            //Photo
            if (fuPhoto.HasFile)
                msg.PhotoExtension = uploadedPhotoExtension;
            else
                msg.PhotoExtension = oldPhotoExtension;
            //-----------------------
            //File
            if (fuFile.HasFile)
                msg.FileExtension = uploadedFileExtension;
            else
                msg.FileExtension = oldFileExtension;
            //------------------------------------
            //Video
            if (fuVideo.HasFile)
                msg.VideoExtension = uploadedVideoExtension;
            else
                msg.VideoExtension = oldVideoExtension;
            //------------------------------------
            //AudioExtension
            if (fuAudio.HasFile)
                msg.AudioExtension = uploadedAudioExtension;
            else
                msg.AudioExtension = oldAudioExtension;
            //------------------------------------
            //Photo2
            if (fuPhoto2.HasFile)
                msg.Photo2Extension = uploadedPhoto2Extension;
            else
                msg.Photo2Extension = oldPhoto2Extension;
            //------------------------------------
            #endregion

            msg.ModuleTypeID = ModuleTypeID;
            if (currentModule.HasName && !currentModule.HasNameSeparated)
            {
                msg.Name = txtName.Text;
            }
            else if (currentModule.HasName && currentModule.HasNameSeparated)
            {
                //------------------------------------------------------------
                string fname = txtFName.Text.Replace(',', ' ');
                string mname = txtMname.Text.Replace(',', ' ');
                string lname = txtLName.Text.Replace(',', ' ');
                msg.Name = fname + "," + mname + "," + lname;
                //------------------------------------------------------------
            }
            msg.EMail = txtEMail.Text;
            msg.Mobile = txtMobile.Text;
            //--------------------------------------------------------------------------
            if (currentModule.HasCountryID)
                msg.CountryID = Convert.ToInt32(ddlCountries.SelectedValue);
            //--------------------------------------------------------------------------
            if (currentModule.HasNationalityID)
                msg.NationalityID = Convert.ToInt32(ddlNationalityID.SelectedValue);
            //--------------------------------------------------------------------------
            if (currentModule.CategoryLevel != 0)
                msg.CategoryID = Convert.ToInt32(ddlCategoryID.SelectedValue);
            //--------------------------------------------------------------------------
            msg.Address = txtAddress.Text;
            msg.JobTel = txtJobTel.Text;
            if (currentModule.HasType)
                msg.Type = Convert.ToInt32(ddlType.SelectedValue);
            msg.Title = txtTitle.Text;
            //-------------------------------------
            if (currentModule.DetailsInHtmlEditor)
                msg.Details = fckDetails.Text;
            else
                msg.Details = txtDetails.Text;
            //-------------------------------------

            if (currentModule.HasToItemID)
                msg.ToItemID = Convert.ToInt32(ddlItems.SelectedValue);
            if (currentModule.HasRedirectToMember)
            {
                msg.ToUserID = new Guid(ddlToUserID.SelectedValue);
            }
            msg.IsAvailable = cbIsAvailable.Checked;
            //-------------------------------------
            if (currentModule.ReplyInHtmlEditor)
                msg.Reply = fckReply.Text;
            else
                msg.Reply = txtReply.Text;
            //-------------------------------------
            if (trEmpNo.Visible)
                msg.EmpNo = Convert.ToInt32(txtEmpNo.Text);
            //------------------------------------------------------------
            if (trAgeRang.Visible)
                msg.AgeRang = Convert.ToInt32(ddlAgeRang.SelectedValue);
            if (trGender.Visible)
                msg.Gender = (Gender)Convert.ToInt32(ddlGender.SelectedValue);
            if (trBirthDate.Visible)
            {
                msg.BirthDate = ucDateBirthDate.Date.ToShortDateString();
            }
            if (trSocialStatus.Visible)
                msg.SocialStatus = Convert.ToInt32(ddlSocialStatus.SelectedValue);
            if (trEducationLevel.Visible)
                msg.EducationLevel = Convert.ToInt32(ddlEducationLevel.SelectedValue);

            if (trCityID.Visible)
                msg.CityID = Convert.ToInt32(ddlCities.SelectedValue);
            //------------------------------------------------------------
            msg.UserCityName = txtUserCityName.Text;
            msg.Tel = txtTel.Text;

            msg.HasSmsService = cbHasSmsService.Checked;
            msg.HasEmailService = cbHasEmailService.Checked;
            //------------------------------------------------------------
            msg.Fax = txtFax.Text;
            msg.MailBox = txtMailBox.Text;
            msg.ZipCode = txtZipCode.Text;
            if (trJobID.Visible)
                msg.JobID = Convert.ToInt32(txtJobID.Text);
            msg.JobText = txtJobText.Text;
            msg.Url = txtUrl.Text;

            //------------------------------------------------------------
            msg.Company = txtCompany.Text;
            if (trActivitiesID.Visible)
                msg.ActivitiesID = Convert.ToInt32(ddlActivitiesID.SelectedValue);
            //-----------------------------------------------------------
            //New Columns nnnnnnnnnnnnnnnnnnnnnnnnnnn---------
            //-----------------------------------
            if (currentModule.HasPriority) msg.Priority = Convert.ToInt32(ddlPriority.SelectedValue);
            //-------------------------------
            if (currentModule.HasHeight) msg.Height = Convert.ToInt32(txtHeight.Text);
            //-------------------------------
            if (currentModule.HasWidth) msg.Width = Convert.ToInt32(txtWidth.Text);
            //-------------------------------
            //if (currentModule.HasItemDate) msg.ItemDate = Convert.ToDateTime(txtItemDate.Text);
            //if (currentModule.HasItemDate && ucItemDate.Date != DateTime.MinValue) msg.ItemDate = ucItemDate.Date;
            if (currentModule.HasItemDate) msg.ItemDate = ucItemDate.Date;
            //-------------------------------
            msg.IsMain = CbIsMain.Checked;
            //-------------------------------
            msg.YoutubeCode = txtYoutubeCode.Text;
            //-----------------------------------
            if (currentModule.HasGoogleLatitude)
                msg.GoogleLatitude = txtGoogleLatitude.Text;
            //-----------------------------------
            if (currentModule.HasGoogleLongitude)
                msg.GoogleLongitude = txtGoogleLongitude.Text;
            //-----------------------------------
            msg.Price = txtPrice.Text;
            msg.OnlyForRegisered = cbOnlyForRegisered.Checked;
            //-----------------------------------
            //Files publishing
            msg.PublishPhoto = cbPublishPhoto.Checked;
            msg.PublishPhoto2 = cbPublishPhoto2.Checked;
            msg.PublishFile = cbPublishFile.Checked;
            msg.PublishAudio = cbPublishAudio.Checked;
            msg.PublishVideo = cbPublishVideo.Checked;
            msg.PublishYoutbe = cbPublishYoutbe.Checked;
            //-----------------------------------
            if (!msg.IsReplied)
            {
                if (!string.IsNullOrEmpty(msg.Reply))
                    msg.IsReplied = true;
            }
            
            //-----------------------------------
            //End of New Columns nnnnnnnnnnnnnnnnnnnnnnnnnnn---------
            msg.ShortDescription = txtShortDescription.Text;
            //-----------------------------------
            msg.KeyWords = txtMetaKeyWords.Text;
            //-----------------------------------
            bool status = MessagesFactory.Update(msg);
            if (status)
            {
                SaveFiles(msg);
                //-------------------------------------------------------------------------
                //RegisterInMailList
                if (currentModule.MailListAutomaticRegistration || msg.HasEmailService)
                    MessagesFactory.UpdateMailListEmail(oldEmail, msg);
                //-------------------------------------------------------------------------
                //RegisterInSms
                if (currentModule.SmsAutomaticRegistration || msg.HasSmsService)
                    MessagesFactory.UpdateSmsMobileNo(oldMobile, msg);
                //-------------------------------------------------------------------------
                string reply = txtReply.Text;
                if (currentModule.ReplyInHtmlEditor)
                    reply = fckReply.Text;
                //-------------------------------------
                if (currentModule.HasReply && !string.IsNullOrEmpty(reply))
                {
                    string mailSubject = DynamicResource.GetMessageModuleText(currentModule, "ReplyMailSubject");
                    SendReplyByMail(mailSubject, reply);
                }
                //-------------------------------------
                if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubAdmin)
                {
                    if (!string.IsNullOrEmpty(DefaultPagePath))
                    {
                        Response.Redirect(DefaultPagePath);
                    }
                    else
                    {
                        Response.Redirect("/AdminSub/Messages/" + currentModule.Identifire + "/default.aspx");
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(DefaultPagePath))
                    {
                        Response.Redirect(DefaultPagePath);
                    }
                    else
                    {
                        Response.Redirect("/AdminCP/Messages/" + currentModule.Identifire + "/default.aspx");
                    }
                }
            }
            else
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = Resources.AdminText.UpdatingOperationFaild;
            }
        }
        else
        {
            if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubAdmin)
            {
                Response.Redirect("/AdminSub/Messages/" + currentModule.Identifire + "/default.aspx");
            }
            else
            {
                Response.Redirect("/AdminCP/Messages/" + currentModule.Identifire + "/default.aspx");
            }
        }
    }
    //--------------------------------------------------
    #endregion
    #region ---------------SaveFiles---------------
    //-----------------------------------------------
    //SaveFiles
    //-----------------------------------------------
    protected void SaveFiles(MessagesEntity msg)
    {
        #region Save uploaded photo
        //Photo-----------------------------
        if (fuPhoto.HasFile)
        {
            //if has an old photo
            if (!string.IsNullOrEmpty(oldPhotoExtension))
            {
                //Delete old original photo
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesPhotoOriginals(msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + MessagesFactory.CreatePhotoName(msg.MessageID) + oldPhotoExtension);
                //Delete old Thumbnails
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesPhotoNormalThumbs(msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + MessagesFactory.CreatePhotoName(msg.MessageID) + MoversFW.Thumbs.thumbnailExetnsion);
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesPhotoBigThumbs(msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + MessagesFactory.CreatePhotoName(msg.MessageID) + MoversFW.Thumbs.thumbnailExetnsion);
            }
            //------------------------------------------------
            //Save new original photo
            fuPhoto.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_MessagesPhotoOriginals (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + msg.Photo);
            //Create new thumbnails
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_MessagesPhotoNormalThumbs (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID), MessagesFactory.CreatePhotoName(msg.MessageID), fuPhoto.PostedFile, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight);
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_MessagesPhotoBigThumbs (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID), MessagesFactory.CreatePhotoName(msg.MessageID), fuPhoto.PostedFile, SiteSettings.Photos_BigThumnailWidth, SiteSettings.Photos_BigThumnailHeight);
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
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + MessagesFactory.CreateFileName(msg.MessageID) + oldFileExtension);
            }
            //Save new original file
            fuFile.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + msg.File);
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
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + MessagesFactory.CreateFileName(msg.MessageID)+ oldVideoExtension);
            }
            //Save new original video
            fuVideo.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + msg.Video);
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
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + MessagesFactory.CreateFileName(msg.MessageID)+ oldAudioExtension);
            }
            //Save new original audio
            fuAudio.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + msg.Audio);
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
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + MessagesFactory.CreateFileName(msg.MessageID)+ oldPhoto2Extension);
            }
            //Save new original Photo2
            fuPhoto2.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + msg.Photo2);
        }
        //------------------------------------------------
        #endregion
    }
    //-----------------------------------------------
    #endregion

    #region ---------------DeletePhoto---------------
    //-----------------------------------------------
    //DeletePhoto
    //-----------------------------------------------
    protected void ibtnDeletePhoto_Click(object sender, ImageClickEventArgs e)
    {
        int messageID = Convert.ToInt32(Request.QueryString["id"]);
        MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, OwnerID);
        if (msg != null)
        {
            //Photo-----------------------------
            if (!string.IsNullOrEmpty(msg.PhotoExtension))
            {
                //Delete old original photo
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesPhotoOriginals (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + msg.Photo);
                //Delete old Thumbnails
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesPhotoNormalThumbs (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + MessagesFactory.CreatePhotoName(msg.MessageID) + MoversFW.Thumbs.thumbnailExetnsion);
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesPhotoBigThumbs (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + MessagesFactory.CreatePhotoName(msg.MessageID) + MoversFW.Thumbs.thumbnailExetnsion);
            }
            //------------------------------------------------

            trPhotoPreview.Visible = false;
            //-----------------------------

            msg.PhotoExtension = "";
            bool status = MessagesFactory.Update(msg);
            if (status)
            {

                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.User.DeletingOprationDone;
            }

            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.User.DeletingOprationFaild;
            }

        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------DeleteFile---------------
    //-----------------------------------------------
    //DeleteFile
    //-----------------------------------------------
    protected void ibtnDeleteFile_Click(object sender, ImageClickEventArgs e)
    {
        int messageID = Convert.ToInt32(Request.QueryString["id"]);
        MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, OwnerID);
        if (msg != null)
        {
            //File-----------------------------
            if (!string.IsNullOrEmpty(msg.FileExtension))
            {
                //Delete file
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + msg.File);
            }
            //------------------------------------------------

            trFilePreview.Visible = false;
            //-----------------------------

            msg.FileExtension = "";
            bool status = MessagesFactory.Update(msg);
            if (status)
            {

                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.User.DeletingOprationDone;
            }

            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.User.DeletingOprationFaild;
            }

        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------DeletePhoto2---------------
    //-----------------------------------------------
    //DeletePhoto2
    //-----------------------------------------------
    protected void btnDeletePhoto2_Click(object sender, EventArgs e)
    {
        int messageID = Convert.ToInt32(Request.QueryString["id"]);
        MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, OwnerID);
        if (msg != null)
        {
            //Photo2-----------------------------
            if (!string.IsNullOrEmpty(msg.Photo2Extension))
            {
                //Delete photo2
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + msg.Photo2);
            }
            //------------------------------------------------

            trPhoto2Preview.Visible = false;
            //-----------------------------

            msg.Photo2Extension = "";
            bool status = MessagesFactory.Update(msg);
            if (status)
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
    #endregion

    #region ---------------DeleteVideo---------------
    //-----------------------------------------------
    //DeleteVideo
    //-----------------------------------------------
    protected void ibtnDeleteVideo_Click(object sender, ImageClickEventArgs e)
    {
        int messageID = Convert.ToInt32(Request.QueryString["id"]);
        MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, OwnerID);
        if (msg != null)
        {
            //Video-----------------------------
            if (!string.IsNullOrEmpty(msg.VideoExtension))
            {
                //Delete Video
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + msg.Video);
            }
            //------------------------------------------------

            trVideoPreview.Visible = false;
            //-----------------------------

            msg.VideoExtension = "";
            bool status = MessagesFactory.Update(msg);
            if (status)
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
    #endregion

    #region ---------------DeleteAudio---------------
    //-----------------------------------------------
    //DeleteAudio
    //-----------------------------------------------
    protected void ibtnDeleteAudio_Click(object sender, ImageClickEventArgs e)
    {
        int messageID = Convert.ToInt32(Request.QueryString["id"]);
        MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, OwnerID);
        if (msg != null)
        {
            //Audio-----------------------------
            if (!string.IsNullOrEmpty(msg.AudioExtension))
            {
                //Delete Audio
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_MessagesFiles (msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID)) + msg.Audio);
            }
            //------------------------------------------------

            trAudioPreview.Visible = false;
            //-----------------------------

            msg.AudioExtension = "";
            bool status = MessagesFactory.Update(msg);
            if (status)
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
    #endregion

    
}

