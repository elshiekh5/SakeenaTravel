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


public partial class Items_Update : System.Web.UI.UserControl
{

    TextBox txtTitle;
    TextBox txtShortDescription;
    TextBox txtMetaKeyWords;
    CuteEditor.Editor fckDescription;
    TextBox txtDescription;
    TextBox txtAuthorName;
    TextBox txtAddress;
    TextBox txtExtraText_1;
    //-------------------------------------------
    ItemsEntity itemsObject;
    ItemsEntity selectedAuthor;
    ItemsModulesOptions currentModule;
    string oldPhotoExtension;
    string oldFileExtension;
    string oldVideoExtension;
    string oldAudioExtension;
    string oldPhoto2Extension;
    public string Banner = "";
    string oldEmail;
    string oldMobile;


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

    #region --------------ItemID--------------
    private int _ItemID = 0;
    public int ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
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
        //------------------------------------------------------------------------
        if (ItemID<=0 &&MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            ItemID = Convert.ToInt32(Request.QueryString["id"]);
        }
        //------------------------------------------------------------------------
        if (ItemID<=0)
        {
            if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubAdmin)
            {
                if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.UsersProfiles || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SubSitePages)
                { 
                    Response.Redirect("/AdminSub/"); 
                }
                /*else if (itemsObject.IsVisitorsParticipations)
                {
                    Response.Redirect("/AdminSub/Items/" + currentModule.Identifire + "/Participations/default.aspx");
                }*/
                else
                {
                    Response.Redirect("/AdminSub/Items/" + currentModule.Identifire + "/default.aspx");
                }
            }
            else
            {
                if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.UsersProfiles || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SubSitePages)
                {
                    Response.Redirect("/AdminCP/");
                }
                //else if (itemsObject.IsVisitorsParticipations)
                //{
                //    Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/Participations/default.aspx");
                //}
                else
                {
                    Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/default.aspx");
                }
            }
        }
        //------------------------------------------------------------------------
        //New code for pages
        //------------------------------
        if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents )
        {
            currentModule = SitePageOptions.GetPage(ItemID);
        }
        //------------------------------------------------------------------------
        MLangsDetails1.ModuleTypeID = ModuleTypeID;
        MLangsDetails1.ItemID = ItemID;
        lblResult.Text = "";
        if (!IsPostBack)
        {
            PrepareValidation();
            SetTexts();
            HandleOptionalControls();
            LoadData();
        }
        //------------------------------------------------------------------------
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
        //-----------------------------------
        //HasUrl
        trUrl.Visible = currentModule.HasUrl;
        rfvUrl.Visible = currentModule.HasUrl && currentModule.RequiredUrl;
        revUrl.ValidationExpression = DCValidation.GetUrlExpression();
        //-----------------------------------
        //HasEmail
        trEmail.Visible = currentModule.HasEmail;
        rfvEmail.Visible = currentModule.HasEmail && currentModule.RequiredEmail;
        //-----------------------------------
        //Height	
        trHeight.Visible = currentModule.HasHeight;
        rfvHeight.Visible = currentModule.HasHeight && currentModule.RequiredHeight;
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
        rfvMailBox.Visible = currentModule.HasMailBox && currentModule.RequiredMailBox;
        //-----------------------------------
        //trZipCode
        trZipCode.Visible = currentModule.HasZipCode;
        rfvZipCode.Visible = currentModule.HasZipCode && currentModule.RequiredZipCode;
        //-----------------------------------
        //Tels
        trTels.Visible = currentModule.HasTels;
        rfvTels.Visible = currentModule.HasTels && currentModule.RequiredTels;
        //-----------------------------------
        //Fax
        trFax.Visible = currentModule.HasFax;
        rfvFax.Visible = currentModule.HasFax && currentModule.RequiredFax;
        //-----------------------------------
        //Mobile
        trMobile.Visible = currentModule.HasMobile;
        rfvMobile.Visible = currentModule.HasMobile && currentModule.RequiredMobile;
        //-----------------------------------
        //HasPhotoExtension
        trPhotoExtension.Visible = currentModule.HasPhotoExtension;
        trPhotoPreview.Visible = currentModule.HasPhotoExtension;
        //rfvPhoto.Visible = currentModule.HasPhotoExtension && currentModule.RequiredPhoto;
        //-----------------------------------
        //HasFileExtension
        trFileExtension.Visible = currentModule.HasFileExtension;
        trFilePreview.Visible = currentModule.HasFileExtension;
        //rfvFile.Visible = currentModule.HasFileExtension && currentModule.RequiredFile;
        //-----------------------------------
        //trVideoExtension
        trVideoExtension.Visible = currentModule.HasVideoExtension;
        trVideoPreview.Visible = currentModule.HasVideoExtension;
        //rfvVideo.Visible = currentModule.HasVideoExtension && currentModule.RequiredVideo;
        //-----------------------------------
        //trAudioExtension
        trAudioExtension.Visible = currentModule.HasAudioExtension;
        trAudioPreview.Visible = currentModule.HasAudioExtension;
        //rfvAudio.Visible = currentModule.HasAudioExtension && currentModule.RequiredAudio;
        //-----------------------------------
        //trPhoto2Preview
        trPhoto2Extension.Visible = currentModule.HasPhoto2Extension;
        trPhoto2Preview.Visible = currentModule.HasPhoto2Extension;
        //rfvPhoto2.Visible = currentModule.HasPhoto2Extension && currentModule.RequiredPhoto2;
        //-----------------------------------
      
        //trHasIsMain
        trHasIsMain.Visible = currentModule.HasIsMain;
        //-----------------------------------
        //trHasSpecialOption
        trHasSpecialOption.Visible = currentModule.HasSpecialOption;
        //-----------------------------------
        //HasIsAvailable
        trIsAvailable.Visible = currentModule.HasIsAvailable;
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
        //Previews
        trDeletePhoto.Visible = !currentModule.RequiredPhoto;
        btnDeletePhoto2.Visible = !currentModule.RequiredPhoto2;
        //-------------------------------------------
        ibtnDeleteFile.Visible = !currentModule.RequiredFile;
        ibtnDeleteVideo.Visible = !currentModule.RequiredVideo;
        ibtnDeleteAudio.Visible = !currentModule.RequiredAudio;
        //-----------------------------------
        lblAdminNote.Text = currentModule.AdminNote;
        //--------------------------------------------------------------------
        //trGoogleLatitude
        trGoogleLatitude.Visible = currentModule.HasGoogleLatitude;
        rfvGoogleLatitude.Visible = currentModule.HasGoogleLatitude && currentModule.RequiredGoogleLatitude;
        //--------------------------------------------------------------------
        //trGoogleLongitude
        trGoogleLongitude.Visible = currentModule.HasGoogleLongitude;
        rfvGoogleLongitude.Visible = currentModule.HasGoogleLongitude && currentModule.RequiredGoogleLongitude;
        //--------------------------------------------------------------------
        //trPrice
        trPrice.Visible = currentModule.HasPrice;
        rfvPrice.Visible = currentModule.HasPrice && currentModule.RequiredPrice;
        //--------------------------------------------------------------------
        //trOnlyForRegisered
        trOnlyForRegisered.Visible = currentModule.HasOnlyForRegisered;
        //--------------------------------------------------------------------
        //Files publishing
        cbPublishPhoto.Visible = currentModule.HasPublishPhoto;
        cbPublishPhoto2.Visible = currentModule.HasPublishPhoto2;
        cbPublishFile.Visible = currentModule.HasPublishFile;
        cbPublishAudio.Visible = currentModule.HasPublishAudio;
        cbPublishVideo.Visible = currentModule.HasPublishVideo;
        cbPublishYoutbe.Visible = currentModule.HasPublishYoutbe;
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------
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
        //---------------------------------------------------------------------
        //--------------------------------------------------------------
        trType.Visible = currentModule.HasType;
        if (currentModule.HasType)
            Load_ddlType();
        //--------------------------------------------------------------
        rfvType.Visible = currentModule.RequiredType;
        //---------------------------------------------------------------------
        //FontAwsome icon 
        trIcon.Visible = currentModule.HasFontIcon;
        rfvIcon.Visible = currentModule.RequiredFontIcon;
        //---------------------------------------------------------------------
    }
    //-----------------------------------------------
    #endregion

    #region ---------------HandleVisitorsParticipationsControls---------------
    //-----------------------------------------------
    //HandleVisitorsParticipationsControls
    //-----------------------------------------------
    protected void HandleVisitorsParticipationsControls(bool IsVisitorsParticipations)
    {
        //-----------------------------------------------
        //Visitors Participations
        //----------------------------
        if (!IsVisitorsParticipations)
        {
            trSenderName.Visible = false;
            trSenderEMail.Visible = false;
            trSenderCountry.Visible = false;
            trToUserID.Visible = false;
            trIsReviewed.Visible = false;
            trReplyText.Visible = false;
            trReply.Visible = false;
        }
        else
        {
            //--------------------------------------------------------------
            trSenderName.Visible = currentModule.HasSenderName;
            trSenderEMail.Visible = currentModule.HasSenderEMail;
            //--------------------------------------------------------------
            trSenderCountry.Visible = currentModule.HasSenderCountryID;
            if (currentModule.HasSenderCountryID)
                LoadCountries();
            //--------------------------------------------------------------
            trIsReviewed.Visible = true;
            //--------------------------------------------------------------
            trReplyText.Visible = currentModule.HasReply;
            trReply.Visible = currentModule.HasReply;
            //--------------------------------------------------------------
            //ReplyInHtmlEditor
            //----------------------
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
            //--------------------------------------------------------------
            if (currentModule.HasRedirectToMember)
            {
                trToUserID.Visible = true;
                Load_ddlToUserID();
            }
            else
            {
                trToUserID.Visible = false;
            }
            //--------------------------------------------------------------
            rfvSenderEMail.Visible = currentModule.RequiredSenderEMail;
            rfvSenderName.Visible = currentModule.RequiredSenderName;
            rfvSenderCountry.Visible = currentModule.RequiredSenderCountryID;
            //--------------------------------------------------------------
        }
    }
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
        lblPhotoAvailableExtension.Text = currentModule.PhotoAvailableExtension.Replace(".","");
        lblPhoto2AvailableExtension.Text = currentModule.Photo2AvailableExtension.Replace(".", "");
        lblFileAvailableExtension.Text = currentModule.FileAvailableExtension.Replace(".", "");
        lblAudioAvailableExtension.Text = currentModule.AudioAvailableExtension.Replace(".", "");
        lblVideoAvailableExtension.Text = currentModule.VideoAvailableExtension.Replace(".", "");
        //--------------------------------------------------------------------
        lblYoutubeCode.Text = DynamicResource.GetText(currentModule, "YoutubeCode");
        lblAuthorID.Text = DynamicResource.GetText(currentModule, "AuthorID");
        //--------------------------------------------------------------------
        lblPrice.Text = DynamicResource.GetText(currentModule, "Price");
        lblGoogleLatitude.Text = DynamicResource.GetText(currentModule, "GoogleLatitude");
        lblGoogleLongitude.Text = DynamicResource.GetText(currentModule, "GoogleLongitude");
        lblOnlyForRegisered.Text = DynamicResource.GetText(currentModule, "OnlyForRegisered");
        //--------------------------------------------------------------------
        cbPublishPhoto.Text = DynamicResource.GetText(currentModule, "PublishPhoto");
        cbPublishPhoto2.Text = DynamicResource.GetText(currentModule, "PublishPhoto2");
        cbPublishFile.Text = DynamicResource.GetText(currentModule, "PublishFile");
        cbPublishAudio.Text = DynamicResource.GetText(currentModule, "PublishAudio");
        cbPublishVideo.Text = DynamicResource.GetText(currentModule, "PublishVideo");
        cbPublishYoutbe.Text = DynamicResource.GetText(currentModule, "PublishYoutbe");
        //--------------------------------------------------------------------
        //Visitors Participations
        lblSenderName.Text = DynamicResource.GetText(currentModule, "SenderName");
        lblSenderEMail.Text = DynamicResource.GetText(currentModule, "SenderEMail");
        lblSenderCountry.Text = DynamicResource.GetText(currentModule, "SenderCountry");
        lblToUserID.Text = DynamicResource.GetText(currentModule, "ToUserID");
        lblIsReviewed.Text = DynamicResource.GetText(currentModule, "IsReviewed");
        lblReply.Text = DynamicResource.GetText(currentModule, "Reply");
        //--------------------------------------------------------------------
        lblType.Text = DynamicResource.GetText(currentModule, "Type");
        //--------------------------------------------------------------------
        lblIcon.Text = DynamicResource.GetText(currentModule, "Icon");
        //--------------------------------------------------------------------

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

    //------------------------------------------------------------
    protected void Load_ddlToUserID()
    {
        List<UsersDataEntity> usersList = UsersDataFactory.GetAllByRole(currentModule.MemberRole, OwnerID,true);
        OurDropDownList.LoadDropDownList(usersList, ddlToUserID, "Name", "UserId", false);
        ddlToUserID.Items.Insert(0, new ListItem(Resources.User.Choose, Guid.Empty.ToString()));
    }
    //------------------------------------------------------------

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
        OurDropDownList.LoadPriorities(ddlPriority, itemsCount, false);
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

        ddlType.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
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
        itemsObject = ItemsFactory.GetObject(ItemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
        if (itemsObject != null)
        {
            /*if (itemsObject.ModuleTypeID == int.SitesOwnerMosahama)
             {
                 Banner = GetBannerCode(itemsObject.File, itemsObject.Width, itemsObject.Height);
             }*/
            //txtTitle.Text = itemsObject.Title;
            if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.UsersProfiles || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SubSitePages)
            {
                //this.Page.Title = itemsObject.Title;
            }
            if (trCategoryID.Visible)
            {
                ddlItemCategories.SelectedValue = itemsObject.CategoryID.ToString();
            }
            if (currentModule.HasPriority)
            {
                LoadPriorities();
                ddlPriority.SelectedValue = itemsObject.Priority.ToString();
            
            }
            //txtShortDescription.Text = itemsObject.ShortDescription;
            //txtDetails.Value = itemsObject.Description;
            //txtAuthorName.Text = itemsObject.AuthorName;
            //------------------------------------------
            txtUrl.Text = itemsObject.Url;
            cbIsAvailable.Checked = itemsObject.IsAvailable;
            //---------------------------------
            txtEmail.Text = itemsObject.Email;
            CbIsMain.Checked = itemsObject.IsMain;
            cbSpecialOption.Checked = itemsObject.SpecialOption;
            //-----------------------------------
            txtHeight.Text = itemsObject.Height.ToString();
            txtWidth.Text = itemsObject.Width.ToString();
            //-----------------------------------
            //txtItemDate.Text = itemsObject.ItemDateString;
            ucItemDate.Date = itemsObject.ItemDate;
            //-----------------------------------
            //txtItemEndDate.Text = itemsObject.ItemEndDateString;
            ucItemEndDate.Date = itemsObject.ItemEndDate;
            //-----------------------------------
            // txtAddress.Text = itemsObject.Address ;
            txtMailBox.Text = itemsObject.MailBox;
            txtZipCode.Text = itemsObject.ZipCode;
            txtTels.Text = itemsObject.Tels;
            txtFax.Text = itemsObject.Fax;
            txtMobile.Text = itemsObject.Mobile;
            //-----------------------------------
            #region ----------Item files----------
            #region ----------Photo----------
            //-------------------------------------------
            //Photo
            //-------------------------------------------
            if (!string.IsNullOrEmpty(itemsObject.PhotoExtension))
            {
                imgPhoto.ImageUrl = ItemsFactory.GetItemsPhotoThumbnail(itemsObject.ItemID, itemsObject.PhotoExtension, 100, 100, itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID);
                aPhotoPreview.HRef = ItemsFactory.GetItemsPhotoBigThumbnail(itemsObject.ItemID, itemsObject.PhotoExtension, itemsObject.OwnerName,itemsObject.ModuleTypeID,itemsObject.CategoryID);
                //imgPhoto.AlternateText = itemsObject.Title;
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
            if (!string.IsNullOrEmpty(itemsObject.FileExtension))
            {

                if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubSites || SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubAdmin)
                {
                    hlFile.HRef = "/"+itemsObject.OwnerName+"/SubSite/Items/ItemDownload.aspx?id=" + itemsObject.ItemID + "&type=1";
                }
                else
                {
                    hlFile.HRef = "/WebSite/ItemDownload.aspx?id=" + itemsObject.ItemID + "&type=1";
                }
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
            if (!string.IsNullOrEmpty(itemsObject.VideoExtension))
            {
                if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubSites || SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubAdmin)
                {
                    hlVideo.HRef = "/" + itemsObject.OwnerName + "/SubSite/Items/ItemDownload.aspx?id=" + itemsObject.ItemID + "&type=2";
                }
                else
                {
                    hlVideo.HRef = "/WebSite/ItemDownload.aspx?id=" + itemsObject.ItemID + "&type=2";
                }
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
            if (!string.IsNullOrEmpty(itemsObject.AudioExtension))
            {
                if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubSites || SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubAdmin)
                {
                    hlAudio.HRef = "/" + itemsObject.OwnerName + "/SubSite/Items/ItemDownload.aspx?id=" + itemsObject.ItemID + "&type=3";
                }
                else
                {
                    hlAudio.HRef = "/WebSite/ItemDownload.aspx?id=" + itemsObject.ItemID + "&type=3";
                }
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
            if (!string.IsNullOrEmpty(itemsObject.Photo2Extension))
            {
                imgPhoto2.ImageUrl = DCSiteUrls.GetPath_ItemsFiles(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID) + itemsObject.Photo2;
                aPhoto2Preview.HRef = DCSiteUrls.GetPath_ItemsFiles(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID) + itemsObject.Photo2;
                //imgPhoto2.AlternateText = itemsObject.Title;
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
            if (!string.IsNullOrEmpty(itemsObject.YoutubeCode))
            {
                txtYoutubeCode.Text = itemsObject.YoutubeCode;
                aYoutube.HRef = "/PopUps/Youtube.aspx?v=" + itemsObject.YoutubeCode;
            }
            else
            {
                aYoutube.Visible = false;
            }
            //-----------------------------------
            txtGoogleLatitude.Text = itemsObject.GoogleLatitude.ToString();
            txtGoogleLongitude.Text = itemsObject.GoogleLongitude.ToString();
            txtPrice.Text = itemsObject.Price;
            cbOnlyForRegisered.Checked = itemsObject.OnlyForRegisered;
            //-----------------------------------
            //Files publishing
            cbPublishPhoto.Checked = itemsObject.PublishPhoto;
            cbPublishPhoto2.Checked = itemsObject.PublishPhoto2;
            cbPublishFile.Checked = itemsObject.PublishFile;
            cbPublishAudio.Checked = itemsObject.PublishAudio;
            cbPublishVideo.Checked = itemsObject.PublishVideo;
            cbPublishYoutbe.Checked = itemsObject.PublishYoutbe;
            //-----------------------------------
            if (currentModule.HasAuthorID)
            {
                if (itemsObject.AuthorID > 0)
                {
                    ddlAuthorID.SelectedValue = itemsObject.AuthorID.ToString();
                    //txtAuthorName.Text = "";
                }

            }
            //----------------------------------------------------------/
            //Visitors Participations
            //----------------------------------------------------------/
            HandleVisitorsParticipationsControls(itemsObject.IsVisitorsParticipations);
            //----------------------------------------------------------
            if (itemsObject.IsVisitorsParticipations)
            {
                //----------------------------------------------------------
                trIsAvailable.Visible = true;
                //----------------------------------------------------------
                txtSenderName.Text = itemsObject.SenderName;
                txtSenderEMail.Text = itemsObject.SenderEMail;
                //----------------------------------------------------------
                //HasSenderCountryID
                if (currentModule.HasSenderCountryID)
                    ddlSenderCountry.SelectedValue = itemsObject.SenderCountryID.ToString();
                //----------------------------------------------------------
                //IsReviewed
                cbIsReviewed.Checked = itemsObject.IsReviewed;
                //----------------------------------------------------------
                //HasRedirectToMember
                if (currentModule.HasRedirectToMember)
                    ddlToUserID.SelectedValue = itemsObject.ToUserID.ToString();
                //----------------------------------------------------------
                if (currentModule.ReplyInHtmlEditor)
                    fckReply.Text = itemsObject.Reply;
                else
                    txtReply.Text = itemsObject.Reply;
                //----------------------------------------------------------
            }
            //----------------------------------------------------------/
            ddlType.SelectedValue = itemsObject.Type.ToString();
            //----------------------------------------------------------/
            LoadDetails(itemsObject);
            //----------------------------------------------------------/
            //IsSeen
            if (!itemsObject.IsSeen)
            {
                ItemsFactory.UpdateIsSeen(itemsObject.ItemID);
            }
            //-----------------------------------
            txtIconControl.Text = itemsObject.Icon;

        }
        else
        {
            if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubAdmin)
            {
                if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.UsersProfiles || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SubSitePages)
                {
                    Response.Redirect("/AdminSub/");
                }
                //else if (itemsObject.IsVisitorsParticipations)
                //{
                //    Response.Redirect("/AdminSub/Items/" + currentModule.Identifire + "/Participations/default.aspx");
                //}
                else
                {
                    Response.Redirect("/AdminSub/Items/" + currentModule.Identifire + "/default.aspx");
                }
            }
            else
            {
                if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.UsersProfiles || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SubSitePages)
                {
                    Response.Redirect("/AdminCP/");
                }
                //else if (itemsObject.IsVisitorsParticipations)
                //{
                //    Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/Participations/default.aspx");
                //}
                else
                {
                    Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/default.aspx");
                }
            }
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
        if (!Page.IsValid || (currentModule.HasItemDate && !ucItemDate.IsValid) || (currentModule.HasItemEndDate && !ucItemEndDate.IsValid))
        {
            return;
        }
        ItemsEntity itemsObject = ItemsFactory.GetObject(ItemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
        oldEmail = itemsObject.Email;
        oldMobile = itemsObject.Mobile;
        #region Item Files properties
        //Old files extension 
        oldPhotoExtension = itemsObject.PhotoExtension;
        oldFileExtension = itemsObject.FileExtension;
        oldVideoExtension = itemsObject.VideoExtension;
        oldAudioExtension = itemsObject.AudioExtension;
        oldPhoto2Extension = itemsObject.Photo2Extension;
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
            itemsObject.PhotoExtension = uploadedPhotoExtension;
        else
            itemsObject.PhotoExtension = oldPhotoExtension;
        //-----------------------
        //File
        if (fuFile.HasFile)
            itemsObject.FileExtension = uploadedFileExtension;
        else
            itemsObject.FileExtension = oldFileExtension;
        //------------------------------------
        //Video
        if (fuVideo.HasFile)
            itemsObject.VideoExtension = uploadedVideoExtension;
        else
            itemsObject.VideoExtension = oldVideoExtension;
        //------------------------------------
        //AudioExtension
        if (fuAudio.HasFile)
            itemsObject.AudioExtension = uploadedAudioExtension;
        else
            itemsObject.AudioExtension = oldAudioExtension;
        //------------------------------------
        //Photo2
        if (fuPhoto2.HasFile)
            itemsObject.Photo2Extension = uploadedPhoto2Extension;
        else
            itemsObject.Photo2Extension = oldPhoto2Extension;
        //------------------------------------
        #endregion
        #endregion

        //itemsObject.Title = txtTitle.Text;
        if (trCategoryID.Visible) itemsObject.CategoryID = Convert.ToInt32(ddlItemCategories.SelectedValue);
        //itemsObject.ShortDescription = txtShortDescription.Text;
        //itemsObject.Description = txtDetails.Value;
        itemsObject.Email = txtEmail.Text;
        //itemsObject.AuthorName = txtAuthorName.Text;
        if (currentModule.HasPriority) itemsObject.Priority = Convert.ToInt32(ddlPriority.SelectedValue);
        itemsObject.Url = txtUrl.Text;
        if (currentModule.HasHeight) itemsObject.Height = Convert.ToInt32(txtHeight.Text);
        if (currentModule.HasWidth) itemsObject.Width = Convert.ToInt32(txtWidth.Text);
        //-----------------------------------
        //if (currentModule.HasItemDate) itemsObject.ItemDate = Convert.ToDateTime(txtItemDate.Text);
        //if (currentModule.HasItemDate && ucItemDate.Date != DateTime.MinValue) itemsObject.ItemDate = ucItemDate.Date;
        if (currentModule.HasItemDate) itemsObject.ItemDate = ucItemDate.Date;
        //-----------------------------------
        //if (currentModule.HasItemEndDate) itemsObject.ItemEndDate = Convert.ToDateTime(txtItemEndDate.Text);
        //if (currentModule.HasItemEndDate && ucItemEndDate.Date != DateTime.MinValue) itemsObject.ItemEndDate = ucItemEndDate.Date;
        if (currentModule.HasItemEndDate) itemsObject.ItemEndDate = ucItemEndDate.Date;
        //-----------------------------------
        //itemsObject.Address = txtAddress.Text;
        itemsObject.MailBox = txtMailBox.Text;
        itemsObject.ZipCode = txtZipCode.Text;
        itemsObject.Tels = txtTels.Text;
        itemsObject.Fax = txtFax.Text;
        itemsObject.Mobile = txtMobile.Text;


        itemsObject.IsMain = CbIsMain.Checked;
        itemsObject.SpecialOption = cbSpecialOption.Checked;
        //-------------------------------
        itemsObject.YoutubeCode = txtYoutubeCode.Text;
        //-----------------------------------
        if (currentModule.HasGoogleLatitude)
            itemsObject.GoogleLatitude = Convert.ToDouble(txtGoogleLatitude.Text);
        //-----------------------------------
        if (currentModule.HasGoogleLongitude)
            itemsObject.GoogleLongitude = Convert.ToDouble(txtGoogleLongitude.Text);
        //-----------------------------------
        itemsObject.Price = txtPrice.Text;
        itemsObject.OnlyForRegisered = cbOnlyForRegisered.Checked;
        //-----------------------------------
        //Files publishing
        itemsObject.PublishPhoto = cbPublishPhoto.Checked;
        itemsObject.PublishPhoto2 = cbPublishPhoto2.Checked;
        itemsObject.PublishFile = cbPublishFile.Checked;
        itemsObject.PublishAudio = cbPublishAudio.Checked;
        itemsObject.PublishVideo = cbPublishVideo.Checked;
        itemsObject.PublishYoutbe = cbPublishYoutbe.Checked;
        //-----------------------------------
        if (currentModule.HasAuthorID)
        {
            int authorID = Convert.ToInt32(ddlAuthorID.SelectedValue);
            itemsObject.AuthorID = authorID;
        }
        //----------------------------------------------------------
        if (currentModule.ReplyInHtmlEditor)
            itemsObject.Reply = fckReply.Text;
        else
            itemsObject.Reply = txtReply.Text;
        //----------------------------------------------------------
        itemsObject.Icon = txtIconControl.Text;

        //----------------------------------------------------------/
        //Visitors Participations
        //----------------------------------------------------------/
        //----------------------------------------------------------
        //Administration data
        //-------------------------------------
        if (itemsObject.IsVisitorsParticipations)
        {
            //----------------------------------------------------------
            string username = HttpContext.Current.User.Identity.Name;
            //----------------------------------------------------------
            //IsReplied
            //------------------------------
            //only for one time
            if (!itemsObject.IsReplied && !string.IsNullOrEmpty(itemsObject.Reply))
            {
                itemsObject.IsReplied = true;
            }
            //----------------------------------------------------------
            //ActivatedBy
            //------------------------------
            if (!itemsObject.IsAvailable && cbIsAvailable.Checked == true)
            {
                itemsObject.ActivatedBy = username;
            }
            //----------------------------------------------------------
            //ReviewedBy
            //------------------------------
            if (!itemsObject.IsReviewed && cbIsReviewed.Checked == true)
            {
                itemsObject.ReviewedBy = username;
            }
            else if (!itemsObject.IsAvailable && cbIsAvailable.Checked == true)
            {
                itemsObject.ReviewedBy = username;
            }
            //----------------------------------------------------------

            itemsObject.SenderName = txtSenderName.Text;
            itemsObject.SenderEMail = txtSenderEMail.Text;
            //----------------------------------------------------------
            //HasSenderCountryID
            if (currentModule.HasSenderCountryID)
                itemsObject.SenderCountryID = Convert.ToInt32(ddlSenderCountry.SelectedValue);
            //----------------------------------------------------------
            //IsReviewed
            itemsObject.IsReviewed = cbIsReviewed.Checked || cbIsAvailable.Checked;
            //----------------------------------------------------------
            //HasRedirectToMember
            if (currentModule.HasRedirectToMember)
                itemsObject.ToUserID = new Guid(ddlToUserID.SelectedValue);
            //----------------------------------------------------------

            //----------------------------------------------------------
        }
        //----------------------------------------------------------/
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
        if (currentModule.HasType)
            itemsObject.Type = Convert.ToInt32(ddlType.SelectedValue);
        //-------------------------------------------------------------------------------------------
        //Details -----------------------
        AddDetails(itemsObject);
        //-------------------------------
        ExecuteCommandStatus status = ItemsFactory.Update(itemsObject,currentModule);
        if (status == ExecuteCommandStatus.Done)
        {
            //Save uploaded files
            SaveFiles(itemsObject);
            //--------------------------------------------------------------------------
            //RegisterInMailList
            if (currentModule.MailListAutomaticRegistration)
                ItemsFactory.UpdateMailListEmail(oldEmail, itemsObject);
            //--------------------------------------------------------------------------
            //RegisterInSms
            if (currentModule.SmsAutomaticRegistration)
                ItemsFactory.UpdateSmsMobileNo(oldMobile, itemsObject);
            //--------------------------------------------------------------------------
            //if this module as pages don't redirect 
            if (currentModule.ModuleType == ModuleTypes.StaticPages || currentModule.ModuleType == ModuleTypes.StaticContents)
            {
                lblResult.CssClass = "lblResult_Done";
                lblResult.Text = Resources.AdminText.UpdatingsOperationDone;
            }
            else
            {
                if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubAdmin)
                {
                    if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.UsersProfiles || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SubSitePages)
                    {
                        //Response.Redirect("/AdminSub/");
                        lblResult.CssClass = "lblResult_Done";
                        lblResult.Text = Resources.AdminText.SavingDataSuccessfuly;
                    }
                    else if (itemsObject.IsVisitorsParticipations)
                    {
                        Response.Redirect("/AdminSub/Items/" + currentModule.Identifire + "/Participations/default.aspx");
                    }
                    else
                    {
                        Response.Redirect("/AdminSub/Items/" + currentModule.Identifire + "/default.aspx");
                    }
                }
                else
                {
                    if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.UsersProfiles || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SubSitePages)
                    {
                        Response.Redirect("/AdminCP/");
                    }
                    else if (itemsObject.IsVisitorsParticipations)
                    {
                        Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/Participations/default.aspx");
                    }
                    else
                    {
                        Response.Redirect("/AdminCP/Items/" + currentModule.Identifire + "/default.aspx");
                    }
                }

            }
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
            //if has an old photo
            if (!string.IsNullOrEmpty(oldPhotoExtension))
            {
                //Delete old original photo
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoOriginals (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + ItemsFactory.CreateItemsPhotoName(itemsObject.ItemID) + oldPhotoExtension);
                //Delete old Thumbnails
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoNormalThumbs (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + ItemsFactory.CreateItemsPhotoName(itemsObject.ItemID) + MoversFW.Thumbs.thumbnailExetnsion);
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoBigThumbs (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + ItemsFactory.CreateItemsPhotoName(itemsObject.ItemID) + MoversFW.Thumbs.thumbnailExetnsion);
            }
            //------------------------------------------------
            //Save new original photo
            fuPhoto.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoOriginals (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Photo);
            //Create new thumbnails
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_ItemsPhotoNormalThumbs (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID), ItemsFactory.CreateItemsPhotoName(itemsObject.ItemID), fuPhoto.PostedFile, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight);
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_ItemsPhotoBigThumbs (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID), ItemsFactory.CreateItemsPhotoName(itemsObject.ItemID), fuPhoto.PostedFile, SiteSettings.Photos_BigThumnailWidth, SiteSettings.Photos_BigThumnailHeight);
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
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + ItemsFactory.CreateFileName(itemsObject.ItemID) + oldFileExtension);
            }
            //Save new original file
            fuFile.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.File);
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
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + ItemsFactory.CreateFileName(itemsObject.ItemID) + oldVideoExtension);
            }
            //Save new original video
            fuVideo.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Video);
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
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + ItemsFactory.CreateFileName(itemsObject.ItemID) + oldAudioExtension);
            }
            //Save new original audio
            fuAudio.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Audio);
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
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + ItemsFactory.CreateFileName(itemsObject.ItemID) + oldPhoto2Extension);
            }
            //Save new original Photo2
            fuPhoto2.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Photo2);
        }
        //------------------------------------------------
        #endregion
    }
    //-----------------------------------------------
    #endregion


    protected void btnDeletePhoto_Click(object sender, EventArgs e)
    {
        ItemsEntity item = ItemsFactory.GetObject(ItemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
        if (item != null)
        {
            //Photo-----------------------------
            if (!string.IsNullOrEmpty(item.PhotoExtension))
                {
                    //Delete old original photo
                    File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoOriginals(item.OwnerName, item.ModuleTypeID, item.CategoryID, item.ItemID)) + item.Photo);
                    //Delete old Thumbnails
                    File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoNormalThumbs (item.OwnerName, item.ModuleTypeID, item.CategoryID, item.ItemID)) + ItemsFactory.CreateItemsPhotoName(item.ItemID) + MoversFW.Thumbs.thumbnailExetnsion);
                    File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoBigThumbs (item.OwnerName, item.ModuleTypeID, item.CategoryID, item.ItemID)) + ItemsFactory.CreateItemsPhotoName(item.ItemID) + MoversFW.Thumbs.thumbnailExetnsion);
                }
                //------------------------------------------------

            trPhotoPreview.Visible = false;
            //-----------------------------

            item.PhotoExtension = "";
            ExecuteCommandStatus status = ItemsFactory.Update(item, currentModule);
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
    protected void btnDeletePhoto2_Click(object sender, EventArgs e)
    {
        ItemsEntity item = ItemsFactory.GetObject(ItemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
        if (item != null)
        {
            //Photo2-----------------------------
            if (!string.IsNullOrEmpty(item.Photo2Extension))
            {
                //Delete photo2
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (item.OwnerName, item.ModuleTypeID, item.CategoryID, item.ItemID)) + item.Photo2);
            }
            //------------------------------------------------

            trPhoto2Preview.Visible = false;
            //-----------------------------

            item.Photo2Extension = "";
            ExecuteCommandStatus status = ItemsFactory.Update(item, currentModule);
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
        ItemsEntity item = ItemsFactory.GetObject(ItemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
        if (item != null)
        {
            //File-----------------------------
            if (!string.IsNullOrEmpty(item.FileExtension))
            {
                //Delete file
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (item.OwnerName, item.ModuleTypeID, item.CategoryID, item.ItemID)) + item.File);
            }
            //------------------------------------------------

            trFilePreview.Visible = false;
            //-----------------------------

            item.FileExtension = "";
            ExecuteCommandStatus status = ItemsFactory.Update(item, currentModule);
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
        ItemsEntity item = ItemsFactory.GetObject(ItemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
        if (item != null)
        {
            //Video-----------------------------
            if (!string.IsNullOrEmpty(item.VideoExtension))
            {
                //Delete Video
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (item.OwnerName, item.ModuleTypeID, item.CategoryID, item.ItemID)) + item.Video);
            }
            //------------------------------------------------

            trVideoPreview.Visible = false;
            //-----------------------------

            item.VideoExtension = "";
            ExecuteCommandStatus status = ItemsFactory.Update(item, currentModule);
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
        ItemsEntity item = ItemsFactory.GetObject(ItemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
        if (item != null)
        {
            //Audio-----------------------------
            if (!string.IsNullOrEmpty(item.AudioExtension))
            {
                //Delete Audio
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles (item.OwnerName, item.ModuleTypeID, item.CategoryID, item.ItemID)) + item.Audio);
            }
            //------------------------------------------------

            trAudioPreview.Visible = false;
            //-----------------------------

            item.AudioExtension = "";
            ExecuteCommandStatus status = ItemsFactory.Update(item, currentModule);
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

    

    //--------------------------------------------
    protected void LoadDetails(ItemsEntity item)
    {
        MLanguagesDetailsControls ucArDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucArDetails");
        MLanguagesDetailsControls ucEnDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucEnDetails");
        //if(HasArabic)
        LoadDetails(item, ucArDetails);
        //if(HasEngrabic)
        LoadDetails(item, ucEnDetails);

        //details

        //--------------------------------------------
    }
    //--------------------------------------------
    protected void LoadDetails(ItemsEntity item, MLanguagesDetailsControls ucDetails)
    {
        LoadDetailsControls(ucDetails);
        if (item.Details[ucDetails.Lang] != null)
        {
            ItemsDetailsEntity itemDetailsObject = (ItemsDetailsEntity)item.Details[ucDetails.Lang];
            txtTitle.Text = itemDetailsObject.Title;
            txtShortDescription.Text = itemDetailsObject.ShortDescription;
            txtMetaKeyWords.Text = itemDetailsObject.KeyWords;

            //-----------------------------------------------------------
            if (currentModule.DetailsInHtmlEditor)
                fckDescription.Text = itemDetailsObject.Description;
            else
                txtDescription.Text = itemDetailsObject.Description;
            //-----------------------------------------------------------
            
            if (itemsObject.AuthorID > 0)
                txtAuthorName.Text = "";
            else
                txtAuthorName.Text = itemDetailsObject.AuthorName;
            txtAddress.Text = itemDetailsObject.Address;
            if (itemDetailsObject.ExtraData.Count>0)
            txtExtraText_1.Text = itemDetailsObject.ExtraData[0];
        }
    }

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
            if (currentModule.DetailsInHtmlEditor)
                itemDetailsObject.Description = fckDescription.Text;
            else
                itemDetailsObject.Description = txtDescription.Text;
            //-----------------------------------------------------------
            if (selectedAuthor == null && item.AuthorID > 0)
            {
                selectedAuthor = ItemsFactory.GetObject(item.AuthorID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
            }
            if (selectedAuthor != null && selectedAuthor.Details.Contains(ucDetails.Lang))
            {
                ItemsDetailsEntity selectedAuthorDetails = (ItemsDetailsEntity)selectedAuthor.Details[ucDetails.Lang];
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

    protected void ddlItemCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (currentModule.HasPriority)
        {
            LoadPriorities();
        }
    }
}

