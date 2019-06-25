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


public partial class AdminModuleOptions_Create : MasterAdminMasterPage
{

	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
		lblResult.Text="";
		if(!IsPostBack)
		{
            this.Page.Title = "ãæÏíæáÇÊ ÇáÚÑÖ";
            Load_ddlModuleType();
            LoadData();
		}
	}
	//-----------------------------------------------
	#endregion
        
    #region----------Load_ddlModuleType----------
    //-------------------------------------------------
    //Load_ddlModuleType
    //-------------------------------------------------
    protected void Load_ddlModuleType()
    {
        string[] names = Enum.GetNames(typeof(ModuleTypes));
        Array values = Enum.GetValues(typeof(ModuleTypes));
        for (int i = 0; i < names.Length; i++)
        {
            //ddlModuleType.Items.Add(new ListItem(names[i], values.GetValue(i).ToString()));
            ddlModuleType.Items.Add(new ListItem(names[i]));
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
        int moduleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            moduleTypeID = (int)Convert.ToInt32(Request.QueryString["id"]);
        }
        ItemsModulesOptions moduleOptions = ItemsModulesOptions.GetType(moduleTypeID);
        if (moduleTypeID > 0)
        {
            txtModuleTypeID.Text = moduleTypeID.ToString();
        }
        else
        { txtModuleTypeID.Text = ""; }
        if (moduleOptions.Identifire.ToLower() != "unknown")
        {
            txtIdentifire.Text = moduleOptions.Identifire;
        }
        else
        { 
            txtIdentifire.Text = "";
        }
        ddlModuleType.SelectedValue = moduleOptions.ModuleType.ToString();
        //------------------------------------------------------------------------------------------
        //Category options
        //------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------
        txtCategoryLevel.Text = moduleOptions.CategoryLevel.ToString();
        //---------------------------------------------------------------------------------
        cbCategoryHasTitle.Checked = moduleOptions.CategoryHasTitle;
        cbCategoryHasShortDescription.Checked = moduleOptions.CategoryHasShortDescription;
        cbCategoryHasDetails.Checked = moduleOptions.CategoryHasDetails;
        cbCategoryDetailsInHtmlEditor.Checked = moduleOptions.CategoryDetailsInHtmlEditor;
        //---------------------------------------------------------------------------------
        cbCategoryHasDate_Added.Checked = moduleOptions.CategoryHasDate_Added;
        cbCategoryHasItemDate.Checked = moduleOptions.CategoryHasItemDate;
        //---------------------------------------------------------------------------------
        cbCategoryHasVisitiesCount.Checked = moduleOptions.CategoryHasVisitsCount;
        cbCategoryHasIsMain.Checked = moduleOptions.CategoryHasIsMain;
        cbCategoryHasPriority.Checked = moduleOptions.CategoryHasPriority;
        cbCategoryHasIsAvailable.Checked = moduleOptions.CategoryHasIsAvailable;
        //---------------------------------------------------------------------------------
        txtCategoryListID.Text = moduleOptions.CategoryListID;
        //---------------------------------------------------------------------------------
        cbCategoryHasPhotoExtension.Checked = moduleOptions.CategoryHasPhotoExtension;
        txtCategoryPhotoAvailableExtension.Text = moduleOptions.CategoryPhotoAvailableExtension;
        txtCategoryPhotoMaxSize.Text = moduleOptions.CategoryPhotoMaxSize.ToString();
        //---------------------------------------------
        cbCategoryHasFileExtension.Checked = moduleOptions.CategoryHasFileExtension;
        txtCategoryFileAvailableExtension.Text = moduleOptions.CategoryFileAvailableExtension;
        txtCategoryFileMaxSize.Text = moduleOptions.CategoryFileMaxSize.ToString();
        //---------------------------------------------
        cbCategoryHasVideoExtension.Checked = moduleOptions.CategoryHasVideoExtension;
        txtCategoryVideoAvailableExtension.Text = moduleOptions.CategoryVideoAvailableExtension;
        txtCategoryVideoMaxSize.Text = moduleOptions.CategoryVideoMaxSize.ToString();
        //---------------------------------------------
        cbCategoryHasAudioExtension.Checked = moduleOptions.CategoryHasAudioExtension;
        txtCategoryAudioAvailableExtension.Text = moduleOptions.CategoryAudioAvailableExtension;
        txtCategoryAudioMaxSize.Text = moduleOptions.CategoryAudioMaxSize.ToString();
        //---------------------------------------------
        cbCategoryHasPhoto2Extension.Checked = moduleOptions.CategoryHasPhoto2Extension;
        txtCategoryPhoto2AvailableExtension.Text = moduleOptions.CategoryPhoto2AvailableExtension;
        txtCategoryPhoto2MaxSize.Text = moduleOptions.CategoryPhoto2MaxSize.ToString();
        //--------------------------------------------------------------
        cbCategoryHasYoutubeCode.Checked = moduleOptions.CategoryHasYoutubeCode;
        //---------------------------------------------------------------------------------
        cbCategoryHasHeight.Checked = moduleOptions.CategoryHasHeight;
        cbCategoryHasWidth.Checked = moduleOptions.CategoryHasWidth;
        //---------------------------------------------------------------------------------
        cbCategoryRequiredTitle.Checked = moduleOptions.CategoryRequiredTitle;
        cbCategoryRequiredShortDescription.Checked = moduleOptions.CategoryRequiredShortDescription;
        cbCategoryRequiredDetails.Checked = moduleOptions.CategoryRequiredDetails;
        //---------------------------------------------------------------------------------
        cbCategoryRequiredPhoto.Checked = moduleOptions.CategoryRequiredPhoto;
        cbCategoryRequiredFile.Checked = moduleOptions.CategoryRequiredFile;
        cbCategoryRequiredVideo.Checked = moduleOptions.CategoryRequiredVideo;
        cbCategoryRequiredAudio.Checked = moduleOptions.CategoryRequiredAudio;
        cbCategoryRequiredPhoto2.Checked = moduleOptions.CategoryRequiredPhoto2;
        //---------------------------------------------------------------------------------
        cbCategoryRequiredYoutubeCode.Checked = moduleOptions.CategoryRequiredYoutubeCode;
        //---------------------------------------------------------------------------------
        cbCategoryRequiredHeight.Checked = moduleOptions.CategoryRequiredHeight;
        cbCategoryRequiredWidth.Checked = moduleOptions.CategoryRequiredWidth;
        //---------------------------------------------------------------------------------
        cbCategoryRequiredItemDate.Checked = moduleOptions.CategoryRequiredItemDate;
        //---------------------------------------------------------------------------------
        txtCategoryAdminNote.Text = moduleOptions.CategoryAdminNote;
        //---------------------------------------------------------------------------------
        cbCategoryHasGoogleLatitude.Checked = moduleOptions.CategoryHasGoogleLatitude;
        cbCategoryHasGoogleLongitude.Checked = moduleOptions.CategoryHasGoogleLongitude;
        //---------------------------------------------------------------------------------
        cbCategoryHasOnlyForRegisered.Checked = moduleOptions.CategoryHasOnlyForRegisered;
        cbCategoryHasOwnerID.Checked = moduleOptions.CategoryHasOwnerID;
        //---------------------------------------------------------------------------------
        cbCategoryRequiredGoogleLatitude.Checked = moduleOptions.CategoryRequiredGoogleLatitude;
        cbCategoryRequiredGoogleLongitude.Checked = moduleOptions.CategoryRequiredGoogleLongitude;
        //---------------------------------------------------------------------------------
        cbCategoryHasPublishPhoto.Checked = moduleOptions.CategoryHasPublishPhoto;
        cbCategoryHasPublishPhoto2.Checked = moduleOptions.CategoryHasPublishPhoto2;
        cbCategoryHasPublishFile.Checked = moduleOptions.CategoryHasPublishFile;
        cbCategoryHasPublishAudio.Checked = moduleOptions.CategoryHasPublishAudio;
        cbCategoryHasPublishVideo.Checked = moduleOptions.CategoryHasPublishVideo;
        cbCategoryHasPublishYoutbe.Checked = moduleOptions.CategoryHasPublishYoutbe;
        //---------------------------------------------------------------------------------
        cbHasCategoryIntro.Checked = moduleOptions.HasCategoryIntro;
        //---------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------------
        cbHasDetails.Checked = moduleOptions.HasDetails;
        cbDetailsInHtmlEditor.Checked = moduleOptions.DetailsInHtmlEditor;
        cbHasShortDescription.Checked = moduleOptions.HasShortDescription;
        cbHasTitle.Checked = moduleOptions.HasTitle;
        cbHasTitleInDetailsPage.Checked = moduleOptions.HasTitleInDetailsPage;
        cbHasHeight.Checked = moduleOptions.HasHeight;
        cbHasWidth.Checked = moduleOptions.HasWidth;
        cbHasAddress.Checked = moduleOptions.HasAddress;
        cbHasMailBox.Checked = moduleOptions.HasMailBox;
        cbHasZipCode.Checked = moduleOptions.HasZipCode;
        cbHasTels.Checked = moduleOptions.HasTels;
        cbHasFax.Checked = moduleOptions.HasFax;
        cbHasMobile.Checked = moduleOptions.HasMobile;
        cbHasUrl.Checked = moduleOptions.HasUrl;
        cbHasEmail.Checked = moduleOptions.HasEmail;
        cbHasItemDate.Checked = moduleOptions.HasItemDate;
        cbHasItemEndDate.Checked = moduleOptions.HasItemEndDate;
        cbHasDate_Added.Checked = moduleOptions.HasDate_Added;
        cbHasIsMain.Checked = moduleOptions.HasIsMain;
        cbSpecialOption.Checked = moduleOptions.HasSpecialOption;
        cbHasPriority.Checked = moduleOptions.HasPriority;
        cbHasIsAvailable.Checked = moduleOptions.HasIsAvailable;
        cbHasYoutubeCode.Checked = moduleOptions.HasYoutubeCode;
        cbHasAuthorID.Checked = moduleOptions.HasAuthorID;
        cbHasAuthorName.Checked = moduleOptions.HasAuthorName;
        txtListID.Text = moduleOptions.ListID;
        //--------------------------------------------------------------
        txtPageItemCount_UserDefault.Text = moduleOptions.PageItemCount_UserDefault.ToString();
        txtPageItemCount_AdminDefault.Text = moduleOptions.PageItemCount_AdminDefault.ToString();
        txtCategoryPageItemCount_UserDefault.Text = moduleOptions.CategoryPageItemCount_UserDefault.ToString();
        txtCategoryPageItemCount_AdminDefault.Text = moduleOptions.CategoryPageItemCount_AdminDefault.ToString();
        //--------------------------------------------------------------
        cbListHasDate.Checked = moduleOptions.ListHasDate;
        //---------------------------------------------
        cbHasVisitiesCount.Checked = moduleOptions.HasVisitsCount;
        cbHasPrint.Checked = moduleOptions.HasPrint;
        cbHasTelFriend.Checked = moduleOptions.HasTelFriend;
        cbHasSaveAsDocument.Checked = moduleOptions.HasSaveAsDocument;
        cbHasComments.Checked = moduleOptions.HasComments;
        cbHasShare.Checked = moduleOptions.HasShare;
        cbHasRSS.Checked = moduleOptions.HasRSS;
        cbHasRating.Checked = moduleOptions.HasRating;
        //---------------------------------------------
        cbHasPhotoExtension.Checked = moduleOptions.HasPhotoExtension;
        txtPhotoAvailableExtension.Text = moduleOptions.PhotoAvailableExtension;
        txtPhotoMaxSize.Text = moduleOptions.PhotoMaxSize.ToString();
        cbHasFileExtension.Checked = moduleOptions.HasFileExtension;
        txtFileAvailableExtension.Text = moduleOptions.FileAvailableExtension;
        txtFileMaxSize.Text = moduleOptions.FileMaxSize.ToString();
        //--------------------------------------------------------------
        cbHasVideoExtension.Checked = moduleOptions.HasVideoExtension;
        txtVideoAvailableExtension.Text = moduleOptions.VideoAvailableExtension;
        txtVideoMaxSize.Text = moduleOptions.VideoMaxSize.ToString();
        cbHasAudioExtension.Checked = moduleOptions.HasAudioExtension;
        txtAudioAvailableExtension.Text = moduleOptions.AudioAvailableExtension;
        txtAudioMaxSize.Text = moduleOptions.AudioMaxSize.ToString();
        cbHasPhoto2Extension.Checked = moduleOptions.HasPhoto2Extension;
        txtPhoto2AvailableExtension.Text = moduleOptions.Photo2AvailableExtension;
        txtPhoto2MaxSize.Text = moduleOptions.Photo2MaxSize.ToString();
        //--------------------------------------------------------------
        cbHasMultiPhotos.Checked = moduleOptions.HasMultiPhotos;
        cbHasMessages.Checked = moduleOptions.HasMessages;
        txtMessagesModuleID.Text = moduleOptions.MessagesModuleID.ToString();
        txtResourceFile.Text = moduleOptions.ResourceFile;
        txtDefaultResourceFile.Text = moduleOptions.DefaultResourceFile;
        cbHasSpecialAdminText.Checked = moduleOptions.HasSpecialAdminText;
        cbRequiredTitle.Checked = moduleOptions.RequiredTitle;
        cbRequiredShortDescription.Checked = moduleOptions.RequiredShortDescription;
        cbRequiredDetails.Checked = moduleOptions.RequiredDetails;
        cbRequiredAuthorName.Checked = moduleOptions.RequiredAuthorName;
        cbRequiredHeight.Checked = moduleOptions.RequiredHeight;
        cbRequiredWidth.Checked = moduleOptions.RequiredWidth;
        cbRequiredAddress.Checked = moduleOptions.RequiredAddress;
        cbRequiredMailBox.Checked = moduleOptions.RequiredMailBox;
        cbRequiredZipCode.Checked = moduleOptions.RequiredZipCode;
        cbRequiredTels.Checked = moduleOptions.RequiredTels;
        cbRequiredFax.Checked = moduleOptions.RequiredFax;
        cbRequiredMobile.Checked = moduleOptions.RequiredMobile;
        cbRequiredUrl.Checked = moduleOptions.RequiredUrl;
        cbRequiredEmail.Checked = moduleOptions.RequiredEmail;
        cbRequiredItemDate.Checked = moduleOptions.RequiredItemDate;
        cbRequiredItemEndDate.Checked = moduleOptions.RequiredItemEndDate;
        cbRequiredPhoto.Checked = moduleOptions.RequiredPhoto;
        cbRequiredFile.Checked = moduleOptions.RequiredFile;
        cbRequiredVideo.Checked = moduleOptions.RequiredVideo;
        cbRequiredAudio.Checked = moduleOptions.RequiredAudio;
        cbRequiredPhoto2.Checked = moduleOptions.RequiredPhoto2;
        txtModuleRelatedPageID.Text = moduleOptions.ModuleRelatedPageID.ToString();
        //-------------------
        cbRequiredYoutubeCode.Checked = moduleOptions.RequiredYoutubeCode;
        //----------------------------------------------------------
        cbHasOwenFolder_Admin.Checked = moduleOptions.HasOwenFolder_Admin;
        cbHasOwenFolder_User.Checked = moduleOptions.HasOwenFolder_User;
        txtModuleSpecialPath.Text = moduleOptions.ModuleSpecialPath;
        //---------------------------------------------------------------------
        cbMailListAutomaticRegistration.Checked = moduleOptions.MailListAutomaticRegistration;
        cbMailListSendingMailActivation.Checked = moduleOptions.MailListSendingMailActivation;
        cbMailListAutomaticActivation.Checked = moduleOptions.MailListAutomaticActivation;
        cbSmsAutomaticRegistration.Checked = moduleOptions.SmsAutomaticRegistration;
        cbSmsSendingSmsActivation.Checked = moduleOptions.SmsSendingSmsActivation;
        cbSmsAutomaticActivation.Checked = moduleOptions.SmsAutomaticActivation;
        cbAddInAdminMenuAutmaticly.Checked = moduleOptions.AddInAdminMenuAutmaticly;
        //----------------------------------------------------------
        cbHasShortDescriptionInDetailsPage.Checked = moduleOptions.HasShortDescriptionInDetailsPage;
        txtAdminNote.Text = moduleOptions.AdminNote;
        //----------------------------------------------------------
        cbHasGoogleLatitude.Checked = moduleOptions.HasGoogleLatitude;
        cbHasGoogleLongitude.Checked = moduleOptions.HasGoogleLongitude;
        cbHasPrice.Checked = moduleOptions.HasPrice;
        cbHasOnlyForRegisered.Checked = moduleOptions.HasOnlyForRegisered;
        cbHasOwnerID.Checked = moduleOptions.HasOwnerID;
        //--------------------------
        cbRequiredGoogleLatitude.Checked = moduleOptions.RequiredGoogleLatitude;
        cbRequiredGoogleLongitude.Checked = moduleOptions.RequiredGoogleLongitude;
        cbRequiredPrice.Checked = moduleOptions.RequiredPrice;
        //--------------------------
        cbHasPublishPhoto.Checked = moduleOptions.HasPublishPhoto;
        cbHasPublishPhoto2.Checked = moduleOptions.HasPublishPhoto2;
        cbHasPublishFile.Checked = moduleOptions.HasPublishFile;
        cbHasPublishAudio.Checked = moduleOptions.HasPublishAudio;
        cbHasPublishVideo.Checked = moduleOptions.HasPublishVideo;
        cbHasPublishYoutbe.Checked = moduleOptions.HasPublishYoutbe;
        //-------------------------------------------------------------------------------------------
        //-----------------------------------------------
        //Visitors Participations
        //----------------------------
        cbAllowVisitorsParticipations.Checked = moduleOptions.AllowVisitorsParticipations;
        cbSendingOnlyByUsers.Checked = moduleOptions.SendingOnlyByUsers;

        cbHasSenderName.Checked = moduleOptions.HasSenderName;
        cbRequiredSenderName.Checked = moduleOptions.RequiredSenderName;

        cbHasSenderEMail.Checked = moduleOptions.HasSenderEMail;
        cbRequiredSenderEMail.Checked = moduleOptions.RequiredSenderEMail;

        cbHasSenderCountryID.Checked = moduleOptions.HasSenderCountryID;
        cbRequiredSenderCountryID.Checked = moduleOptions.RequiredSenderCountryID;

        cbHasRedirectToMember.Checked = moduleOptions.HasRedirectToMember;
        txtMemberRole.Text = moduleOptions.MemberRole;

        cbHasReply.Checked = moduleOptions.HasReply;
        cbReplyInHtmlEditor.Checked = moduleOptions.ReplyInHtmlEditor;
        cbRequiredReply.Checked = moduleOptions.RequiredReply;
        //-------------------------------------------------------------------------------------------
        cbAllowDublicateTitlesInItems.Checked = moduleOptions.AllowDublicateTitlesInItems;
        cbAllowDublicateTitlesInCategories.Checked = moduleOptions.AllowDublicateTitlesInCategories;
        cbShowInSiteDepartments.Checked = moduleOptions.ShowInSiteDepartments;
        //-------------------------------------------------------------------------------------------
        cbHasType.Checked = moduleOptions.HasType;
        txtTypesCount.Text = moduleOptions.TypesCount.ToString();
        cbRequiredType.Checked = moduleOptions.RequiredType;
        //-------------------------------------------------------------------------------------------
        cbDisplayCategoriesInAdminMenue.Checked=moduleOptions.DisplayCategoriesInAdminMenue;
        txtModuleMetaKeyWords.Text = moduleOptions.ModuleMetaKeyWords;
        txtModuleMetaDescription.Text = moduleOptions.ModuleMetaDescription;
        cbHasMetaKeyWords.Checked = moduleOptions.HasMetaKeyWords;
        cbHasMetaDescription.Checked = moduleOptions.HasMetaDescription;
        //-------------------------------------------------------------------------------------------
        cbHasSearch.Checked = moduleOptions.HasSearech;
        //-------------------------------------------------------------------------------------------
        cbFontIcon.Checked = moduleOptions.HasFontIcon;
        cbRequiredFontIcon.Checked = moduleOptions.RequiredFontIcon;
        //-------------------------------------------------------------------------------------------
        //txtModuleTitle.Text = moduleOptions.ModuleTitle;
        ResourcesFilesManager rfmArabic = new ResourcesFilesManager(ResourcesFilesManager.ModuleResourceFileArabic);
        txtModuleTitleArabic.Text = rfmArabic.GetNodeValue(moduleOptions.ModuleTitle);
        txtModuleAdminSpecialTitleArabic.Text = rfmArabic.GetNodeValue(moduleOptions.ModuleAdminSpecialTitle);
        //----------------------------------------------------
        ResourcesFilesManager rfmEnglish = new ResourcesFilesManager(ResourcesFilesManager.ModuleResourceFileEnglish);
        txtModuleTitleEnglish.Text = rfmEnglish.GetNodeValue(moduleOptions.ModuleTitle);
        txtModuleAdminSpecialTitleEnglish.Text = rfmEnglish.GetNodeValue(moduleOptions.ModuleAdminSpecialTitle);
        //-----------------------------------------------------------

    }
    //-----------------------------------------------
    #endregion
	
    #region ---------------btnSave_Click---------------
	//-----------------------------------------------
	//btnSave_Click
	//-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        //--------------------------------------------------------
        int moduleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            moduleTypeID = (int)Convert.ToInt32(Request.QueryString["id"]);
        }
        ItemsModulesOptions moduleOptions = ItemsModulesOptions.GetType(moduleTypeID);
        //--------------------------------------------------------
        if (moduleTypeID == (int)StandardItemsModuleTypes.UnKnowen)
            moduleOptions.ModuleTypeID = Convert.ToInt32(txtModuleTypeID.Text);
        //------------------------------------
        moduleOptions.Identifire = txtIdentifire.Text.Trim();
        moduleOptions.ModuleType = (ModuleTypes)Enum.Parse(typeof(ModuleTypes), ddlModuleType.SelectedValue);
        //------------------------------------------------------------------------------------------
        //Category options
        //------------------------------------------------------------------------------------------
        moduleOptions.CategoryLevel = Convert.ToInt32(txtCategoryLevel.Text);
        //--------------------------------------------------------
        moduleOptions.CategoryHasTitle = cbCategoryHasTitle.Checked;
        moduleOptions.CategoryHasShortDescription = cbCategoryHasShortDescription.Checked;
        moduleOptions.CategoryHasDetails = cbCategoryHasDetails.Checked;
        moduleOptions.CategoryDetailsInHtmlEditor = cbCategoryDetailsInHtmlEditor.Checked;
        //--------------------------------------------------------
        moduleOptions.CategoryHasHeight = cbCategoryHasHeight.Checked;
        moduleOptions.CategoryHasWidth = cbCategoryHasWidth.Checked;
        //--------------------------------------------------------
        moduleOptions.CategoryHasItemDate = cbCategoryHasItemDate.Checked;
        moduleOptions.CategoryHasDate_Added = cbCategoryHasDate_Added.Checked;
        //--------------------------------------------------------
        moduleOptions.CategoryHasVisitsCount = cbCategoryHasVisitiesCount.Checked;
        moduleOptions.CategoryHasIsMain = cbCategoryHasIsMain.Checked;
        moduleOptions.CategoryHasPriority = cbCategoryHasPriority.Checked;
        moduleOptions.CategoryHasIsAvailable = cbCategoryHasIsAvailable.Checked;
        //--------------------------------------------------------
        moduleOptions.CategoryListID = txtCategoryListID.Text;
        //--------------------------------------------------------
        moduleOptions.CategoryHasPhotoExtension = cbCategoryHasPhotoExtension.Checked;
        moduleOptions.CategoryPhotoAvailableExtension = txtCategoryPhotoAvailableExtension.Text;
        moduleOptions.CategoryPhotoMaxSize = Convert.ToInt32(txtCategoryPhotoMaxSize.Text);
        //------------------------------------
        moduleOptions.CategoryHasFileExtension = cbCategoryHasFileExtension.Checked;
        moduleOptions.CategoryFileAvailableExtension = txtCategoryFileAvailableExtension.Text;
        moduleOptions.CategoryFileMaxSize = Convert.ToInt32(txtCategoryFileMaxSize.Text);
        //------------------------------------
        moduleOptions.CategoryHasVideoExtension = cbCategoryHasVideoExtension.Checked;
        moduleOptions.CategoryVideoAvailableExtension = txtCategoryVideoAvailableExtension.Text;
        moduleOptions.CategoryVideoMaxSize = Convert.ToInt32(txtCategoryVideoMaxSize.Text);
        //------------------------------------
        moduleOptions.CategoryHasAudioExtension = cbCategoryHasAudioExtension.Checked;
        moduleOptions.CategoryAudioAvailableExtension = txtCategoryAudioAvailableExtension.Text;
        moduleOptions.CategoryAudioMaxSize = Convert.ToInt32(txtCategoryAudioMaxSize.Text);
        //------------------------------------
        moduleOptions.CategoryHasPhoto2Extension = cbCategoryHasPhoto2Extension.Checked;
        moduleOptions.CategoryPhoto2AvailableExtension = txtCategoryPhoto2AvailableExtension.Text;
        moduleOptions.CategoryPhoto2MaxSize = Convert.ToInt32(txtCategoryPhoto2MaxSize.Text);
        //--------------------------------------------------------
        moduleOptions.CategoryHasYoutubeCode = cbCategoryHasYoutubeCode.Checked;
        //--------------------------------------------------------
        moduleOptions.CategoryRequiredTitle = cbCategoryRequiredTitle.Checked;
        moduleOptions.CategoryRequiredShortDescription = cbCategoryRequiredShortDescription.Checked;
        moduleOptions.CategoryRequiredDetails = cbCategoryRequiredDetails.Checked;
        //--------------------------------------------------------
        moduleOptions.CategoryRequiredPhoto = cbCategoryRequiredPhoto.Checked;
        moduleOptions.CategoryRequiredFile = cbCategoryRequiredFile.Checked;
        moduleOptions.CategoryRequiredVideo = cbCategoryRequiredVideo.Checked;
        moduleOptions.CategoryRequiredAudio = cbCategoryRequiredAudio.Checked;
        moduleOptions.CategoryRequiredPhoto2 = cbCategoryRequiredPhoto2.Checked;
        //--------------------------------------------------------
        moduleOptions.CategoryRequiredHeight = cbCategoryRequiredHeight.Checked;
        moduleOptions.CategoryRequiredWidth = cbCategoryRequiredWidth.Checked;
        //--------------------------------------------------------
        moduleOptions.CategoryRequiredYoutubeCode = cbCategoryRequiredYoutubeCode.Checked;
        //--------------------------------------------------------
        moduleOptions.CategoryRequiredItemDate = cbCategoryRequiredItemDate.Checked;
        //--------------------------------------------------------
        moduleOptions.CategoryAdminNote = txtCategoryAdminNote.Text;
        //----------------------------------------------------------
        moduleOptions.CategoryHasGoogleLatitude = cbCategoryHasGoogleLatitude.Checked;
        moduleOptions.CategoryHasGoogleLongitude = cbCategoryHasGoogleLongitude.Checked;
        //----------------------------------------------------------
        moduleOptions.CategoryHasOnlyForRegisered = cbCategoryHasOnlyForRegisered.Checked;
        moduleOptions.CategoryHasOwnerID = cbCategoryHasOwnerID.Checked;
        //----------------------------------------------------------
        moduleOptions.CategoryRequiredGoogleLatitude = cbCategoryRequiredGoogleLatitude.Checked;
        moduleOptions.CategoryRequiredGoogleLongitude = cbCategoryRequiredGoogleLongitude.Checked;
        //----------------------------------------------------------
        moduleOptions.CategoryHasPublishPhoto = cbCategoryHasPublishPhoto.Checked;
        moduleOptions.CategoryHasPublishPhoto2 = cbCategoryHasPublishPhoto2.Checked;
        moduleOptions.CategoryHasPublishFile = cbCategoryHasPublishFile.Checked;
        moduleOptions.CategoryHasPublishAudio = cbCategoryHasPublishAudio.Checked;
        moduleOptions.CategoryHasPublishVideo = cbCategoryHasPublishVideo.Checked;
        moduleOptions.CategoryHasPublishYoutbe = cbCategoryHasPublishYoutbe.Checked;
        //----------------------------------------------------------
        moduleOptions.HasCategoryIntro = cbHasCategoryIntro.Checked;
        //----------------------------------------------------------
        //------------------------------------------------------------------------------------------
        moduleOptions.HasDetails = cbHasDetails.Checked;
        moduleOptions.DetailsInHtmlEditor = cbDetailsInHtmlEditor.Checked;
        moduleOptions.HasShortDescription = cbHasShortDescription.Checked;
        moduleOptions.HasTitle = cbHasTitle.Checked;
        moduleOptions.HasTitleInDetailsPage = cbHasTitleInDetailsPage.Checked;
        moduleOptions.HasHeight = cbHasHeight.Checked;
        moduleOptions.HasWidth = cbHasWidth.Checked;
        moduleOptions.HasAddress = cbHasAddress.Checked;
        moduleOptions.HasMailBox = cbHasMailBox.Checked;
        moduleOptions.HasZipCode = cbHasZipCode.Checked;
        moduleOptions.HasTels = cbHasTels.Checked;
        moduleOptions.HasFax = cbHasFax.Checked;
        moduleOptions.HasMobile = cbHasMobile.Checked;
        moduleOptions.HasUrl = cbHasUrl.Checked;
        moduleOptions.HasEmail = cbHasEmail.Checked;

        moduleOptions.HasItemDate = cbHasItemDate.Checked;
        moduleOptions.HasItemEndDate = cbHasItemEndDate.Checked;
        moduleOptions.HasDate_Added = cbHasDate_Added.Checked;

        moduleOptions.HasIsMain = cbHasIsMain.Checked;
        moduleOptions.HasSpecialOption = cbSpecialOption.Checked;

        moduleOptions.HasPriority = cbHasPriority.Checked;
        moduleOptions.HasIsAvailable = cbHasIsAvailable.Checked;
        moduleOptions.HasYoutubeCode = cbHasYoutubeCode.Checked;
        moduleOptions.HasAuthorID = cbHasAuthorID.Checked;
        moduleOptions.HasAuthorName = cbHasAuthorName.Checked;
        moduleOptions.ListID = txtListID.Text;
        //--------------------------------------------------------------
        moduleOptions.PageItemCount_UserDefault = Convert.ToInt32(txtPageItemCount_UserDefault.Text);
        moduleOptions.PageItemCount_AdminDefault = Convert.ToInt32(txtPageItemCount_AdminDefault.Text);
        moduleOptions.CategoryPageItemCount_UserDefault = Convert.ToInt32(txtCategoryPageItemCount_UserDefault.Text);
        moduleOptions.CategoryPageItemCount_AdminDefault = Convert.ToInt32(txtCategoryPageItemCount_AdminDefault.Text);
        //--------------------------------------------------------------

        moduleOptions.ListHasDate = cbListHasDate.Checked;
        //---------------------------------------------
        moduleOptions.HasVisitsCount = cbHasVisitiesCount.Checked;
        moduleOptions.HasPrint = cbHasPrint.Checked;
        moduleOptions.HasTelFriend = cbHasTelFriend.Checked;
        moduleOptions.HasSaveAsDocument = cbHasSaveAsDocument.Checked;
        moduleOptions.HasComments = cbHasComments.Checked;
        moduleOptions.HasShare = cbHasShare.Checked;
        moduleOptions.HasRSS = cbHasRSS.Checked;
        moduleOptions.HasRating = cbHasRating.Checked;
        //---------------------------------------------
        moduleOptions.HasPhotoExtension = cbHasPhotoExtension.Checked;

        moduleOptions.PhotoAvailableExtension = txtPhotoAvailableExtension.Text;
        moduleOptions.PhotoMaxSize = Convert.ToInt32(txtPhotoMaxSize.Text);
        moduleOptions.HasFileExtension = cbHasFileExtension.Checked;
        moduleOptions.FileAvailableExtension = txtFileAvailableExtension.Text;
        moduleOptions.FileMaxSize = Convert.ToInt32(txtFileMaxSize.Text);
        moduleOptions.HasVideoExtension = cbHasVideoExtension.Checked;
        moduleOptions.VideoAvailableExtension = txtVideoAvailableExtension.Text;
        moduleOptions.VideoMaxSize = Convert.ToInt32(txtVideoMaxSize.Text);
        moduleOptions.HasAudioExtension = cbHasAudioExtension.Checked;
        moduleOptions.AudioAvailableExtension = txtAudioAvailableExtension.Text;
        moduleOptions.AudioMaxSize = Convert.ToInt32(txtAudioMaxSize.Text);
        moduleOptions.HasPhoto2Extension = cbHasPhoto2Extension.Checked;
        moduleOptions.Photo2AvailableExtension = txtPhoto2AvailableExtension.Text;
        moduleOptions.Photo2MaxSize = Convert.ToInt32(txtPhoto2MaxSize.Text);
        moduleOptions.HasMultiPhotos = cbHasMultiPhotos.Checked;
        moduleOptions.HasMessages = cbHasMessages.Checked;
        if (cbHasMessages.Checked && !string.IsNullOrEmpty(txtMessagesModuleID.Text))
            moduleOptions.MessagesModuleID = Convert.ToInt32(txtMessagesModuleID.Text);
        moduleOptions.ResourceFile = txtResourceFile.Text;
        moduleOptions.DefaultResourceFile = txtDefaultResourceFile.Text;
        moduleOptions.HasSpecialAdminText = cbHasSpecialAdminText.Checked;
        
        moduleOptions.RequiredTitle = cbRequiredTitle.Checked;
        moduleOptions.RequiredShortDescription = cbRequiredShortDescription.Checked;
        moduleOptions.RequiredDetails = cbRequiredDetails.Checked;
        moduleOptions.RequiredAuthorName = cbRequiredAuthorName.Checked;
        moduleOptions.RequiredHeight = cbRequiredHeight.Checked;
        moduleOptions.RequiredWidth = cbRequiredWidth.Checked;
        moduleOptions.RequiredAddress = cbRequiredAddress.Checked;
        moduleOptions.RequiredMailBox = cbRequiredMailBox.Checked;
        moduleOptions.RequiredZipCode = cbRequiredZipCode.Checked;
        moduleOptions.RequiredTels = cbRequiredTels.Checked;
        moduleOptions.RequiredFax = cbRequiredFax.Checked;
        moduleOptions.RequiredMobile = cbRequiredMobile.Checked;
        moduleOptions.RequiredUrl = cbRequiredUrl.Checked;
        moduleOptions.RequiredEmail = cbRequiredEmail.Checked;
        moduleOptions.RequiredItemDate = cbRequiredItemDate.Checked;
        moduleOptions.RequiredItemEndDate = cbRequiredItemEndDate.Checked;
        moduleOptions.RequiredPhoto = cbRequiredPhoto.Checked;
        moduleOptions.RequiredFile = cbRequiredFile.Checked;
        moduleOptions.RequiredVideo = cbRequiredVideo.Checked;
        moduleOptions.RequiredAudio = cbRequiredAudio.Checked;
        moduleOptions.RequiredPhoto2 = cbRequiredPhoto2.Checked;
        moduleOptions.ModuleRelatedPageID = Convert.ToInt32(txtModuleRelatedPageID.Text);
        //---------------------------------------------------------------------
        moduleOptions.ModuleTitle = moduleOptions.CreateModuleTitleIdentifire();
        moduleOptions.ModuleAdminSpecialTitle = moduleOptions.CreateModuleAdminSpecialTitleIdentifire();
        //---------------------------------------------------------------------
        moduleOptions.HasOwenFolder_Admin = cbHasOwenFolder_Admin.Checked;
        moduleOptions.HasOwenFolder_User = cbHasOwenFolder_User.Checked;
        moduleOptions.ModuleSpecialPath = txtModuleSpecialPath.Text;
        //---------------------------------------------------------------------

        moduleOptions.MailListAutomaticRegistration = cbMailListAutomaticRegistration.Checked;
        moduleOptions.MailListSendingMailActivation = cbMailListSendingMailActivation.Checked;
        moduleOptions.MailListAutomaticActivation = cbMailListAutomaticActivation.Checked;
        moduleOptions.SmsAutomaticRegistration = cbSmsAutomaticRegistration.Checked;
        moduleOptions.SmsSendingSmsActivation = cbSmsSendingSmsActivation.Checked;
        moduleOptions.SmsAutomaticActivation = cbSmsAutomaticActivation.Checked;
        moduleOptions.AddInAdminMenuAutmaticly = cbAddInAdminMenuAutmaticly.Checked;
        //-----------------------------------------------------------------------
        //-------------------
        moduleOptions.RequiredYoutubeCode = cbRequiredYoutubeCode.Checked;
        //----------------------------------------------------------
        moduleOptions.HasShortDescriptionInDetailsPage = cbHasShortDescriptionInDetailsPage.Checked;
        moduleOptions.AdminNote = txtAdminNote.Text;
        //----------------------------------------------------------
        moduleOptions.HasGoogleLatitude = cbHasGoogleLatitude.Checked;
        moduleOptions.HasGoogleLongitude = cbHasGoogleLongitude.Checked;
        moduleOptions.HasPrice = cbHasPrice.Checked;
        moduleOptions.HasOnlyForRegisered = cbHasOnlyForRegisered.Checked;
        moduleOptions.HasOwnerID = cbHasOwnerID.Checked;
        //--------------------------
        moduleOptions.RequiredGoogleLatitude = cbRequiredGoogleLatitude.Checked;
        moduleOptions.RequiredGoogleLongitude = cbRequiredGoogleLongitude.Checked;
        moduleOptions.RequiredPrice = cbRequiredPrice.Checked;
        //--------------------------
        moduleOptions.HasPublishPhoto = cbHasPublishPhoto.Checked;
        moduleOptions.HasPublishPhoto2 = cbHasPublishPhoto2.Checked;
        moduleOptions.HasPublishFile = cbHasPublishFile.Checked;
        moduleOptions.HasPublishAudio = cbHasPublishAudio.Checked;
        moduleOptions.HasPublishVideo = cbHasPublishVideo.Checked;
        moduleOptions.HasPublishYoutbe = cbHasPublishYoutbe.Checked;
        //-------------------------------------------------------------------------------------------
        //-----------------------------------------------
        //Visitors Participations
        //----------------------------
        moduleOptions.AllowVisitorsParticipations = cbAllowVisitorsParticipations.Checked;
        moduleOptions.SendingOnlyByUsers = cbSendingOnlyByUsers.Checked;

        moduleOptions.HasSenderName = cbHasSenderName.Checked;
        moduleOptions.RequiredSenderName = cbRequiredSenderName.Checked;

        moduleOptions.HasSenderEMail = cbHasSenderEMail.Checked;
        moduleOptions.RequiredSenderEMail = cbRequiredSenderEMail.Checked;

        moduleOptions.HasSenderCountryID = cbHasSenderCountryID.Checked;
        moduleOptions.RequiredSenderCountryID = cbRequiredSenderCountryID.Checked;

        moduleOptions.HasRedirectToMember = cbHasRedirectToMember.Checked;
        moduleOptions.MemberRole = txtMemberRole.Text;

        moduleOptions.HasReply = cbHasReply.Checked;
        moduleOptions.ReplyInHtmlEditor = cbReplyInHtmlEditor.Checked;
        moduleOptions.RequiredReply = cbRequiredReply.Checked;
        //-------------------------------------------------------------------------------------------
        moduleOptions.AllowDublicateTitlesInItems = cbAllowDublicateTitlesInItems.Checked;
        moduleOptions.AllowDublicateTitlesInCategories = cbAllowDublicateTitlesInCategories.Checked;
        moduleOptions.ShowInSiteDepartments = cbShowInSiteDepartments.Checked;
        //-------------------------------------------------------------------------------------------
        moduleOptions.HasType = cbHasType.Checked;
        moduleOptions.TypesCount = Convert.ToInt32(txtTypesCount.Text);
        moduleOptions.RequiredType = cbRequiredType.Checked;
        //-------------------------------------------------------------------------------------------
        moduleOptions.DisplayCategoriesInAdminMenue = cbDisplayCategoriesInAdminMenue.Checked;
        moduleOptions.ModuleMetaKeyWords = txtModuleMetaKeyWords.Text;
        moduleOptions.ModuleMetaDescription = txtModuleMetaDescription.Text;
        moduleOptions.HasMetaKeyWords = cbHasMetaKeyWords.Checked;
        moduleOptions.HasMetaDescription = cbHasMetaDescription.Checked;
        //-------------------------------------------------------------------------------------------
        //-------------------------------------------------------------------------------------------
        moduleOptions.HasFontIcon = cbFontIcon.Checked;
        moduleOptions.RequiredFontIcon = cbRequiredFontIcon.Checked;
        //-------------------------------------------------------------------------------------------
        moduleOptions.HasSearech = cbHasSearch.Checked;
        //-------------------------------------------------------------------------------------------
        SiteModulesManager sm = SiteModulesManager.Instance;
        bool status = sm.SaveModule(moduleOptions);
        //-----------------------------------------------------------------------
        if (status)
        {
            //--------------------------------------------------------------------
            ResourcesFilesManager.SaveResourcesData(moduleOptions.ModuleTitle, txtModuleTitleArabic.Text, txtModuleTitleEnglish.Text);
            //--------------------------------------------------------------------
            if (txtModuleAdminSpecialTitleArabic.Text.Trim().Length == 0)
            { txtModuleAdminSpecialTitleArabic.Text = txtModuleTitleArabic.Text; }
            //--------------------------------------------------------------------
            if (txtModuleAdminSpecialTitleEnglish.Text.Trim().Length == 0)
            { txtModuleAdminSpecialTitleEnglish.Text = txtModuleTitleEnglish.Text; }
            //--------------------------------------------------------------------
            ResourcesFilesManager.SaveResourcesData(moduleOptions.ModuleAdminSpecialTitle, txtModuleAdminSpecialTitleArabic.Text, txtModuleAdminSpecialTitleEnglish.Text);
            //--------------------------------------------------------------------
            if (!MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
            {
                lblResult.ForeColor = Color.Blue;
                lblResult.Text = Resources.AdminText.AddingOperationDone;
                ClearControls();
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
        else
        {
            lblResult.ForeColor = Color.Red;
            lblResult.Text = Resources.AdminText.AddingOperationFaild;
        }
    }
    //-----------------------------------------------
    #endregion

    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    private void ClearControls()
    {
        LoadData();
        /*
        txtModuleTypeID.Text = "";
        txtIdentifire.Text = "";
        ddlModuleType.SelectedIndex=-1;
        //------------------------------------------------------------------------------------------
        //Category options
        //------------------------------------------------------------------------------------------
        txtCategoryLevel.Text = "0";
        cbCategoryHasTitle.Checked = false;
        cbCategoryHasShortDescription.Checked = false;
        cbCategoryHasDetails.Checked = false;
        cbCategoryDetailsInHtmlEditor.Checked = true;

        cbCategoryHasHeight.Checked = false;
        cbCategoryHasWidth.Checked = false;

        cbCategoryHasItemDate.Checked = false;
        cbCategoryHasDate_Added.Checked = false;
        cbCategoryHasIsMain.Checked = false;
        cbCategoryHasPriority.Checked = false;
        cbCategoryHasIsAvailable.Checked = true;
        cbCategoryHasYoutubeCode.Checked = false;

        txtCategoryListID.Text = "";

        //----------------------------------------
        cbCategoryHasVisitiesCount.Checked = false;

        //----------------------------------------
        txtCategoryPhotoMaxSize.Text = "";
        txtCategoryFileMaxSize.Text = "";
        txtCategoryVideoMaxSize.Text = "";
        txtCategoryAudioMaxSize.Text = "";
        txtCategoryPhoto2MaxSize.Text = "";

        cbCategoryRequiredTitle.Checked = false;
        cbCategoryRequiredShortDescription.Checked = false;
        cbCategoryRequiredDetails.Checked = false;
        cbCategoryRequiredHeight.Checked = false;
        cbCategoryRequiredWidth.Checked = false;
        cbCategoryRequiredItemDate.Checked = false;
        cbCategoryRequiredPhoto.Checked = false;
        cbCategoryRequiredFile.Checked = false;
        cbCategoryRequiredVideo.Checked = false;
        cbCategoryRequiredAudio.Checked = false;
        cbCategoryRequiredPhoto2.Checked = false;

        //-------------------------------------------

        txtCategoryPhotoAvailableExtension.Text = "";
        txtCategoryFileAvailableExtension.Text = "";
        txtCategoryVideoAvailableExtension.Text = "";
        txtCategoryAudioAvailableExtension.Text = "";
        txtCategoryPhoto2AvailableExtension.Text = "";

        cbCategoryRequiredYoutubeCode.Checked = false;
        //----------------------------------------------------------

        txtCategoryAdminNote.Text = "";
        //----------------------------------------------------------
        cbCategoryHasGoogleLatitude.Checked = false;
        cbCategoryHasGoogleLongitude.Checked = false;

        cbCategoryHasOnlyForRegisered.Checked = false;
        cbCategoryHasOwnerID.Checked = false;
        //--------------------------
        cbCategoryRequiredGoogleLatitude.Checked = false;
        cbCategoryRequiredGoogleLongitude.Checked = false;

        //--------------------------
        cbCategoryHasPublishPhoto.Checked = false;
        cbCategoryHasPublishPhoto2.Checked = false;
        cbCategoryHasPublishFile.Checked = false;
        cbCategoryHasPublishAudio.Checked = false;
        cbCategoryHasPublishVideo.Checked = false;
        cbCategoryHasPublishYoutbe.Checked = false;
        //----------------------------------------------------------
        cbHasCategoryIntro.Checked = false;
        //------------------------------------------------------------------------------------------
        cbHasDetails.Checked = false;
        cbDetailsInHtmlEditor.Checked = true;
        cbHasShortDescription.Checked = false;
        cbHasTitle.Checked = false;
        cbHasTitleInDetailsPage.Checked = false;
        cbHasHeight.Checked = false;
        cbHasWidth.Checked = false;
        cbHasAddress.Checked = false;
        cbHasMailBox.Checked = false;
        cbHasZipCode.Checked = false;
        cbHasTels.Checked = false;
        cbHasFax.Checked = false;
        cbHasMobile.Checked = false;
        cbHasUrl.Checked = false;
        cbHasEmail.Checked = false;
        cbHasItemDate.Checked = false;
        cbHasDate_Added.Checked = false;
        cbHasIsMain.Checked = false;
        cbHasPriority.Checked = false;
        cbHasIsAvailable.Checked = true;
        cbHasYoutubeCode.Checked = false;
        cbHasAuthorID.Checked = false;
        cbHasAuthorName.Checked = false;
        txtListID.Text = "";
        cbListHasDate.Checked = false;
        //----------------------------------------
        cbHasVisitiesCount.Checked = false;
        cbHasPrint.Checked = false;
        cbHasTelFriend.Checked = false;
        cbHasSaveAsDocument.Checked = false;
        cbHasComments.Checked = false;
        cbHasShare.Checked = false;
        cbHasRSS.Checked = false;
        cbHasRating.Checked = false;
        //----------------------------------------
        txtPhotoMaxSize.Text = "";
        txtFileMaxSize.Text = "";
        txtVideoMaxSize.Text = "";
        txtAudioMaxSize.Text = "";
        txtPhoto2MaxSize.Text = "";
        cbHasMultiPhotos.Checked = false;
        cbHasMessages.Checked = false;
        txtResourceFile.Text = "";
        txtDefaultResourceFile.Text = "";
        
        cbRequiredTitle.Checked = false;
        cbRequiredShortDescription.Checked = false;
        cbRequiredDetails.Checked = false;
        cbRequiredAuthorName.Checked = false;
        cbRequiredHeight.Checked = false;
        cbRequiredWidth.Checked = false;
        cbRequiredAddress.Checked = false;
        cbRequiredMailBox.Checked = false;
        cbRequiredZipCode.Checked = false;
        cbRequiredTels.Checked = false;
        cbRequiredFax.Checked = false;
        cbRequiredMobile.Checked = false;
        cbRequiredUrl.Checked = false;
        cbRequiredEmail.Checked = false;
        cbRequiredItemDate.Checked = false;
        cbRequiredPhoto.Checked = false;
        cbRequiredFile.Checked = false;
        cbRequiredVideo.Checked = false;
        cbRequiredAudio.Checked = false;
        cbRequiredPhoto2.Checked = false;
        txtModuleRelatedPageID.Text = "-1";
        //-------------------------------------------
        //txtModuleTitle.Text = "";
        txtModuleTitleArabic.Text = "";
        txtModuleTitleEnglish.Text = "";
        //-------------------------------------------
        cbHasOwenFolder_Admin.Checked = false;
        cbHasOwenFolder_User.Checked = false;
        cbMailListAutomaticRegistration.Checked = false;
        cbMailListSendingMailActivation.Checked = false;
        cbMailListAutomaticActivation.Checked = false;
        cbSmsAutomaticRegistration.Checked = false;
        cbSmsSendingSmsActivation.Checked = false;
        cbSmsAutomaticActivation.Checked = false;
        txtPhotoAvailableExtension.Text = "";
        txtFileAvailableExtension.Text = "";
        txtVideoAvailableExtension.Text = "";
        txtAudioAvailableExtension.Text = "";
        txtPhoto2AvailableExtension.Text = "";

        cbRequiredYoutubeCode.Checked = false;
        //----------------------------------------------------------
        cbHasShortDescriptionInDetailsPage.Checked = false;
        txtAdminNote.Text = "";
        //----------------------------------------------------------
        cbHasGoogleLatitude.Checked = false;
        cbHasGoogleLongitude.Checked = false;
        cbHasPrice.Checked = false;
        cbHasOnlyForRegisered.Checked = false;
        cbHasOwnerID.Checked = false;
        //--------------------------
        cbRequiredGoogleLatitude.Checked = false;
        cbRequiredGoogleLongitude.Checked = false;
        cbRequiredPrice.Checked = false;
        //--------------------------
        cbHasPublishPhoto.Checked = false;
        cbHasPublishPhoto2.Checked = false;
        cbHasPublishFile.Checked = false;
        cbHasPublishAudio.Checked = false;
        cbHasPublishVideo.Checked = false;
        cbHasPublishYoutbe.Checked = false;
        //-------------------------------------------------------------------------------------------
        //-----------------------------------------------
        //Visitors Participations
        //----------------------------
        cbAllowVisitorsParticipations.Checked = false;
        cbSendingOnlyByUsers.Checked = false;

        cbHasSenderName.Checked = false;
        cbRequiredSenderName.Checked = false;

        cbHasSenderEMail.Checked = false;
        cbRequiredSenderEMail.Checked = false;

        cbHasSenderCountryID.Checked = false;
        cbRequiredSenderCountryID.Checked = false;

        cbHasRedirectToMember.Checked = false;
        txtMemberRole.Text = "";

        cbHasReply.Checked = false;
        cbReplyInHtmlEditor.Checked = false;
        cbRequiredReply.Checked = false;
        //-------------------------------------------------------------------------------------------
      * */
    }
    //--------------------------------------------------------
    #endregion
   
}
