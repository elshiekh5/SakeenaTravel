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


public partial class AdminMessagesModuleOptions_Create : MasterAdminMasterPage
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
            this.Page.Title = "„ÊœÌÊ·«  «·—”«∆·";
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
            ddlModuleType.Items.Add(new ListItem(names[i], values.GetValue(i).ToString()));
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
        MessagesModuleOptions messagesModuleOptions = MessagesModuleOptions.GetType(moduleTypeID);
        //------------------------------------------------------------
        if (moduleTypeID > 0)
        {
            txtModuleTypeID.Text = moduleTypeID.ToString();
        }
        else
        {
            txtModuleTypeID.Text = "";
        }
        if (messagesModuleOptions.Identifire.ToLower() != "unknown")
        {
            txtIdentifire.Text = messagesModuleOptions.Identifire;
        }
        else 
        {
            txtIdentifire.Text = "";
        }
        //------------------------------------------------------------
        ddlModuleType.SelectedValue = messagesModuleOptions.ModuleType.ToString();
        cbSendingOnlyByUsers.Checked = messagesModuleOptions.SendingOnlyByUsers;
        cbHasName.Checked = messagesModuleOptions.HasName;
        cbNameSeprated.Checked = messagesModuleOptions.HasNameSeparated;
        cbHasMobile.Checked = messagesModuleOptions.HasMobile;
        cbHasEMail.Checked = messagesModuleOptions.HasEMail;
        cbHasCountryID.Checked = messagesModuleOptions.HasCountryID;
        cbHasNationalityID.Checked = messagesModuleOptions.HasNationalityID;
        cbHasAddress.Checked = messagesModuleOptions.HasAddress;
        cbHasJobTel.Checked = messagesModuleOptions.HasJobTel;
        cbHasType.Checked = messagesModuleOptions.HasType;
        txtTypesCount.Text = messagesModuleOptions.TypesCount.ToString();
        cbHasTitle.Checked = messagesModuleOptions.HasTitle;
        cbHasDetails.Checked = messagesModuleOptions.HasDetails;
        cbDetailsInHtmlEditor.Checked = messagesModuleOptions.DetailsInHtmlEditor;
        cbHasUserId.Checked = messagesModuleOptions.HasUserId;
        cbHasToItemID.Checked = messagesModuleOptions.HasToItemID;
        txtToItemModuleType.Text = messagesModuleOptions.ToItemModuleType.ToString();
        cbEnableSendMailToItem.Checked = messagesModuleOptions.EnableSendMailToItem;
        cbHasShortDescription.Checked = messagesModuleOptions.HasShortDescription;
        cbHasReply.Checked = messagesModuleOptions.HasReply;
        cbHasAttachmentsInReplay.Checked = messagesModuleOptions.HasAttachmentsInReplay;
        cbReplyInHtmlEditor.Checked = messagesModuleOptions.ReplyInHtmlEditor;
        cbHasIsAvailable.Checked = messagesModuleOptions.HasIsAvailable;
        txtCategoryLevel.Text = messagesModuleOptions.CategoryLevel.ToString();
        cbHasRedirectToMember.Checked = messagesModuleOptions.HasRedirectToMember;
        txtMemberRole.Text = messagesModuleOptions.MemberRole;
        cbHasEmpNo.Checked = messagesModuleOptions.HasEmpNo;
        cbHasBirthDate.Checked = messagesModuleOptions.HasBirthDate;
        cbHasCityID.Checked = messagesModuleOptions.HasCityID;
        cbHasUserCityName.Checked = messagesModuleOptions.HasUserCityName;
        cbHasGender.Checked = messagesModuleOptions.HasGender;
        cbHasHasEmailService.Checked = messagesModuleOptions.HasHasEmailService;
        cbMailListAutomaticRegistration.Checked = messagesModuleOptions.MailListAutomaticRegistration;
        cbMailListSendingMailActivation.Checked = messagesModuleOptions.MailListSendingMailActivation;
        cbMailListAutomaticActivation.Checked = messagesModuleOptions.MailListAutomaticActivation;
        cbHasHasSmsService.Checked = messagesModuleOptions.HasHasSmsService;
        cbSmsAutomaticRegistration.Checked = messagesModuleOptions.SmsAutomaticRegistration;
        cbSmsSendingSmsActivation.Checked = messagesModuleOptions.SmsSendingSmsActivation;
        cbSmsAutomaticActivation.Checked = messagesModuleOptions.SmsAutomaticActivation;
        cbHasNotes2.Checked = messagesModuleOptions.HasNotes2;
        cbHasNotes1.Checked = messagesModuleOptions.HasNotes1;
        cbHasTel.Checked = messagesModuleOptions.HasTel;
        cbHasAgeRang.Checked = messagesModuleOptions.HasAgeRang;
        cbHasEducationLevel.Checked = messagesModuleOptions.HasEducationLevel;
        cbHasSocialStatus.Checked = messagesModuleOptions.HasSocialStatus;
        cbHasFax.Checked = messagesModuleOptions.HasFax;
        cbHasMailBox.Checked = messagesModuleOptions.HasMailBox;
        cbHasZipCode.Checked = messagesModuleOptions.HasZipCode;
        cbHasJobID.Checked = messagesModuleOptions.HasJobID;
        cbHasJobText.Checked = messagesModuleOptions.HasJobText;
        cbHasUrl.Checked = messagesModuleOptions.HasUrl;
        cbHasCompany.Checked = messagesModuleOptions.HasCompany;
        cbHasActivitiesID.Checked = messagesModuleOptions.HasActivitiesID;
        cbHasPhotoExtension.Checked = messagesModuleOptions.HasPhotoExtension;
        txtPhotoAvailableExtension.Text = messagesModuleOptions.PhotoAvailableExtension;
        //------------------------------------------
        txtPhotoMaxSize.Text = messagesModuleOptions.PhotoMaxSize.ToString();
        cbHasFileExtension.Checked = messagesModuleOptions.HasFileExtension;
        txtFileAvailableExtension.Text = messagesModuleOptions.FileAvailableExtension;
        //------------------------------------------
        txtFileMaxSize.Text = messagesModuleOptions.FileMaxSize.ToString();
        cbHasOwenFolder_Admin.Checked = messagesModuleOptions.HasOwenFolder_Admin;
        cbHasOwenFolder_User.Checked = messagesModuleOptions.HasOwenFolder_User;
        txtModuleSpecialPath.Text = messagesModuleOptions.ModuleSpecialPath;
        //---------------------------------------------------------------

        //---------------------------------------------------------------
        cbHasExportData.Checked = messagesModuleOptions.HasExportData;
        //---------------------------------------------------------------
        cbRequiredName.Checked = messagesModuleOptions.RequiredName;
        cbRequiredMobile.Checked = messagesModuleOptions.RequiredMobile;
        cbRequiredEMail.Checked = messagesModuleOptions.RequiredEMail;
        cbRequiredCountryID.Checked = messagesModuleOptions.RequiredCountryID;
        cbRequiredNationalityID.Checked = messagesModuleOptions.RequiredNationalityID;
        cbRequiredAddress.Checked = messagesModuleOptions.RequiredAddress;
        cbRequiredJobTel.Checked = messagesModuleOptions.RequiredJobTel;
        cbRequiredType.Checked = messagesModuleOptions.RequiredType;
        cbRequiredTitle.Checked = messagesModuleOptions.RequiredTitle;
        cbRequiredDetails.Checked = messagesModuleOptions.RequiredDetails;
        cbRequiredToItemID.Checked = messagesModuleOptions.RequiredToItemID;
        cbRequiredShortDescription.Checked = messagesModuleOptions.RequiredShortDescription;
        cbRequiredReply.Checked = messagesModuleOptions.RequiredReply;
        cbRequiredEmpNo.Checked = messagesModuleOptions.RequiredEmpNo;
        cbRequiredBirthDate.Checked = messagesModuleOptions.RequiredBirthDate;
        cbRequiredCityID.Checked = messagesModuleOptions.RequiredCityID;
        cbRequiredGender.Checked = messagesModuleOptions.RequiredGender;
        cbRequiredNotes2.Checked = messagesModuleOptions.RequiredNotes2;
        cbRequiredNotes1.Checked = messagesModuleOptions.RequiredNotes1;
        cbRequiredTel.Checked = messagesModuleOptions.RequiredTel;
        cbRequiredUserCityName.Checked = messagesModuleOptions.RequiredUserCityName;
        cbRequiredAgeRang.Checked = messagesModuleOptions.RequiredAgeRang;
        cbRequiredEducationLevel.Checked = messagesModuleOptions.RequiredEducationLevel;
        cbRequiredSocialStatus.Checked = messagesModuleOptions.RequiredSocialStatus;
        cbRequiredFax.Checked = messagesModuleOptions.RequiredFax;
        cbRequiredMailBox.Checked = messagesModuleOptions.RequiredMailBox;
        cbRequiredZipCode.Checked = messagesModuleOptions.RequiredZipCode;
        cbRequiredJobID.Checked = messagesModuleOptions.RequiredJobID;
        cbRequiredJobText.Checked = messagesModuleOptions.RequiredJobText;
        cbRequiredUrl.Checked = messagesModuleOptions.RequiredUrl;
        cbRequiredPhotoExtension.Checked = messagesModuleOptions.RequiredPhotoExtension;
        cbRequiredCompany.Checked = messagesModuleOptions.RequiredCompany;
        cbRequiredActivitiesID.Checked = messagesModuleOptions.RequiredActivitiesID;
        cbRequiredFile.Checked = messagesModuleOptions.RequiredFile;
        txtResourceFile.Text = messagesModuleOptions.ResourceFile;
        txtDefaultResourceFile.Text = messagesModuleOptions.DefaultResourceFile;
        cbHasSpecialAdminText.Checked = messagesModuleOptions.HasSpecialAdminText;

        cbAddInAdminMenuAutmaticly.Checked = messagesModuleOptions.AddInAdminMenuAutmaticly;
        //-------------------------------------------
        cbHasVisitiesCount.Checked = messagesModuleOptions.HasVisitsCount;
        cbHasPrint.Checked = messagesModuleOptions.HasPrint;
        cbHasTelFriend.Checked = messagesModuleOptions.HasTelFriend;
        cbHasSaveAsDocument.Checked = messagesModuleOptions.HasSaveAsDocument;
        cbHasComments.Checked = messagesModuleOptions.HasComments;
        cbHasShare.Checked = messagesModuleOptions.HasShare;
        cbHasRSS.Checked = messagesModuleOptions.HasRSS;
        cbHasRating.Checked = messagesModuleOptions.HasRating;
        //-------------------------------------------
        //-----------------------------------------------------------
        //New Columns nnnnnnnnnnnnnnnnnnnnnnnnnnn---------
        //-----------------------------------
        cbHasItemDate.Checked = messagesModuleOptions.HasItemDate;
        cbHasDate_Added.Checked = messagesModuleOptions.HasDate_Added;
        cbHasIsMain.Checked = messagesModuleOptions.HasIsMain;
        cbHasPriority.Checked = messagesModuleOptions.HasPriority;
        cbHasYoutubeCode.Checked = messagesModuleOptions.HasYoutubeCode;
        //--------------------------------------------------------------
        cbHasVideoExtension.Checked = messagesModuleOptions.HasVideoExtension;
        txtVideoAvailableExtension.Text = messagesModuleOptions.VideoAvailableExtension;
        txtVideoMaxSize.Text = messagesModuleOptions.VideoMaxSize.ToString();
        cbHasAudioExtension.Checked = messagesModuleOptions.HasAudioExtension;
        txtAudioAvailableExtension.Text = messagesModuleOptions.AudioAvailableExtension;
        txtAudioMaxSize.Text = messagesModuleOptions.AudioMaxSize.ToString();
        cbHasPhoto2Extension.Checked = messagesModuleOptions.HasPhoto2Extension;
        txtPhoto2AvailableExtension.Text = messagesModuleOptions.Photo2AvailableExtension;
        txtPhoto2MaxSize.Text = messagesModuleOptions.Photo2MaxSize.ToString();
        //--------------------------------------------------------------
        cbHasHeight.Checked = messagesModuleOptions.HasHeight;
        cbHasWidth.Checked = messagesModuleOptions.HasWidth;
        //--------------------------------------------------------------
        cbRequiredItemDate.Checked = messagesModuleOptions.RequiredItemDate;
        cbRequiredHeight.Checked = messagesModuleOptions.RequiredHeight;
        cbRequiredWidth.Checked = messagesModuleOptions.RequiredWidth;
        cbRequiredVideo.Checked = messagesModuleOptions.RequiredVideo;
        cbRequiredAudio.Checked = messagesModuleOptions.RequiredAudio;
        cbRequiredPhoto2.Checked = messagesModuleOptions.RequiredPhoto2;
        //-----------------------------------
        //End of New Columns nnnnnnnnnnnnnnnnnnnnnnnnnnn---------
        //-------------------
        cbRequiredYoutubeCode.Checked = messagesModuleOptions.RequiredYoutubeCode;
        txtModuleRelatedPageID.Text = messagesModuleOptions.ModuleRelatedPageID.ToString();
        txtListID.Text = messagesModuleOptions.ListID;
        cbListHasDate.Checked = messagesModuleOptions.ListHasDate;
        //----------------------------------------------------------
        cbHasShortDescriptionInDetailsPage.Checked = messagesModuleOptions.HasShortDescriptionInDetailsPage;
        cbShortDescriptionAllowToUser.Checked = messagesModuleOptions.ShortDescriptionAllowToUser;
        cbDetailsAllowHtmlEditorForUser.Checked = messagesModuleOptions.DetailsAllowHtmlEditorForUser;
        //----------------------------------------------------------
        txtAdminNote.Text = messagesModuleOptions.AdminNote;
        //----------------------------------------------------------
        cbHasGoogleLatitude.Checked = messagesModuleOptions.HasGoogleLatitude;
        cbHasGoogleLongitude.Checked = messagesModuleOptions.HasGoogleLongitude;
        cbHasPrice.Checked = messagesModuleOptions.HasPrice;
        cbHasOnlyForRegisered.Checked = messagesModuleOptions.HasOnlyForRegisered;
        cbHasOwnerID.Checked = messagesModuleOptions.HasOwnerID;
        //--------------------------
        cbRequiredGoogleLatitude.Checked = messagesModuleOptions.RequiredGoogleLatitude;
        cbRequiredGoogleLongitude.Checked = messagesModuleOptions.RequiredGoogleLongitude;
        cbRequiredPrice.Checked = messagesModuleOptions.RequiredPrice;
        //--------------------------
        cbHasPublishPhoto.Checked = messagesModuleOptions.HasPublishPhoto;
        cbHasPublishPhoto2.Checked = messagesModuleOptions.HasPublishPhoto2;
        cbHasPublishFile.Checked = messagesModuleOptions.HasPublishFile;
        cbHasPublishAudio.Checked = messagesModuleOptions.HasPublishAudio;
        cbHasPublishVideo.Checked = messagesModuleOptions.HasPublishVideo;
        cbHasPublishYoutbe.Checked = messagesModuleOptions.HasPublishYoutbe;
        //-------------------------------------------------------------------------------------------
        txtPageItemCount_UserDefault.Text = messagesModuleOptions.PageItemCount_UserDefault.ToString();
        txtPageItemCount_AdminDefault.Text = messagesModuleOptions.PageItemCount_AdminDefault.ToString();
        cbShowInSiteDepartments.Checked = messagesModuleOptions.ShowInSiteDepartments;
        //-------------------------------------------------------------------------------------------
        txtTableRowsPriorities.Text = messagesModuleOptions.TableRowsPriorities;
        //-------------------------------------------------------------------------------------------
        cbHasSearch.Checked = messagesModuleOptions.HasSearech;
        //-------------------------------------------------------------------------------------------
        cbDisplayCategoriesInAdminMenue.Checked = messagesModuleOptions.DisplayCategoriesInAdminMenue;
        txtModuleMetaKeyWords.Text = messagesModuleOptions.ModuleMetaKeyWords;
        txtModuleMetaDescription.Text = messagesModuleOptions.ModuleMetaDescription;
        cbHasMetaKeyWords.Checked = messagesModuleOptions.HasMetaKeyWords;
        cbHasMetaDescription.Checked = messagesModuleOptions.HasMetaDescription;
        cbUserCanSendMeta.Checked = messagesModuleOptions.UserCanSendMeta;
        //-------------------------------------------------------------------------------------------
        ResourcesFilesManager rfmArabic = new ResourcesFilesManager(ResourcesFilesManager.ModuleResourceFileArabic);
        txtModuleTitleArabic.Text = rfmArabic.GetNodeValue(messagesModuleOptions.ModuleTitle);
        txtModuleAdminSpecialTitleArabic.Text = rfmArabic.GetNodeValue(messagesModuleOptions.ModuleAdminSpecialTitle);
        //----------------------------------------------------
        ResourcesFilesManager rfmEnglish = new ResourcesFilesManager(ResourcesFilesManager.ModuleResourceFileEnglish);
        txtModuleTitleEnglish.Text = rfmEnglish.GetNodeValue(messagesModuleOptions.ModuleTitle);
        txtModuleAdminSpecialTitleEnglish.Text = rfmEnglish.GetNodeValue(messagesModuleOptions.ModuleAdminSpecialTitle);
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
        MessagesModuleOptions messagesModuleOptions = MessagesModuleOptions.GetType(moduleTypeID);
        //--------------------------------------------------------
        if (moduleTypeID == (int)StandardItemsModuleTypes.UnKnowen)
            messagesModuleOptions.ModuleTypeID = Convert.ToInt32(txtModuleTypeID.Text);
        //------------------------------------
        messagesModuleOptions.Identifire = txtIdentifire.Text.Trim();
        messagesModuleOptions.ModuleType = (ModuleTypes)Enum.Parse(typeof(ModuleTypes), ddlModuleType.SelectedValue);
        //--------------------------------------------------------
        messagesModuleOptions.SendingOnlyByUsers = cbSendingOnlyByUsers.Checked;

        //-------------------------------------------------------
        messagesModuleOptions.HasName = cbHasName.Checked;
        messagesModuleOptions.HasNameSeparated = cbNameSeprated.Checked ;
        //-------------------------------------------------------
        messagesModuleOptions.HasMobile = cbHasMobile.Checked;
        messagesModuleOptions.HasEMail = cbHasEMail.Checked;
        messagesModuleOptions.HasCountryID = cbHasCountryID.Checked;
        messagesModuleOptions.HasNationalityID = cbHasNationalityID.Checked;
        messagesModuleOptions.HasAddress = cbHasAddress.Checked;
        messagesModuleOptions.HasJobTel = cbHasJobTel.Checked;
        messagesModuleOptions.HasType = cbHasType.Checked;
        messagesModuleOptions.TypesCount = Convert.ToInt32(txtTypesCount.Text);
        messagesModuleOptions.HasTitle = cbHasTitle.Checked;
        messagesModuleOptions.HasDetails = cbHasDetails.Checked;
        messagesModuleOptions.DetailsInHtmlEditor = cbDetailsInHtmlEditor.Checked;
        messagesModuleOptions.HasUserId = cbHasUserId.Checked;
        messagesModuleOptions.HasToItemID = cbHasToItemID.Checked;
        messagesModuleOptions.ToItemModuleType = (int)Convert.ToInt32(txtToItemModuleType.Text);
        messagesModuleOptions.EnableSendMailToItem = cbEnableSendMailToItem.Checked;
        messagesModuleOptions.HasShortDescription = cbHasShortDescription.Checked;
        messagesModuleOptions.HasReply = cbHasReply.Checked;
        messagesModuleOptions.HasAttachmentsInReplay = cbHasAttachmentsInReplay.Checked;
        messagesModuleOptions.ReplyInHtmlEditor = cbReplyInHtmlEditor.Checked;
        messagesModuleOptions.HasIsAvailable = cbHasIsAvailable.Checked;
        messagesModuleOptions.CategoryLevel = Convert.ToInt32(txtCategoryLevel.Text);
        messagesModuleOptions.HasRedirectToMember = cbHasRedirectToMember.Checked;
        messagesModuleOptions.MemberRole = txtMemberRole.Text;
        messagesModuleOptions.HasEmpNo = cbHasEmpNo.Checked;
        messagesModuleOptions.HasBirthDate = cbHasBirthDate.Checked;
        messagesModuleOptions.HasCityID = cbHasCityID.Checked;
        messagesModuleOptions.HasUserCityName = cbHasUserCityName.Checked;
        messagesModuleOptions.HasGender = cbHasGender.Checked;
        messagesModuleOptions.HasHasEmailService = cbHasHasEmailService.Checked;
        messagesModuleOptions.MailListAutomaticRegistration = cbMailListAutomaticRegistration.Checked;
        messagesModuleOptions.MailListSendingMailActivation = cbMailListSendingMailActivation.Checked;
        messagesModuleOptions.MailListAutomaticActivation = cbMailListAutomaticActivation.Checked;
        messagesModuleOptions.HasHasSmsService = cbHasHasSmsService.Checked;
        messagesModuleOptions.SmsAutomaticRegistration = cbSmsAutomaticRegistration.Checked;
        messagesModuleOptions.SmsSendingSmsActivation = cbSmsSendingSmsActivation.Checked;
        messagesModuleOptions.SmsAutomaticActivation = cbSmsAutomaticActivation.Checked;
        messagesModuleOptions.HasNotes2 = cbHasNotes2.Checked;
        messagesModuleOptions.HasNotes1 = cbHasNotes1.Checked;
        messagesModuleOptions.HasTel = cbHasTel.Checked;
        messagesModuleOptions.HasAgeRang = cbHasAgeRang.Checked;
        messagesModuleOptions.HasEducationLevel = cbHasEducationLevel.Checked;
        messagesModuleOptions.HasSocialStatus = cbHasSocialStatus.Checked;
        messagesModuleOptions.HasFax = cbHasFax.Checked;
        messagesModuleOptions.HasMailBox = cbHasMailBox.Checked;
        messagesModuleOptions.HasZipCode = cbHasZipCode.Checked;
        messagesModuleOptions.HasJobID = cbHasJobID.Checked;
        messagesModuleOptions.HasJobText = cbHasJobText.Checked;
        messagesModuleOptions.HasUrl = cbHasUrl.Checked;
        messagesModuleOptions.HasCompany = cbHasCompany.Checked;
        messagesModuleOptions.HasActivitiesID = cbHasActivitiesID.Checked;
        messagesModuleOptions.HasPhotoExtension = cbHasPhotoExtension.Checked;
        messagesModuleOptions.PhotoAvailableExtension = txtPhotoAvailableExtension.Text;
        messagesModuleOptions.PhotoMaxSize = Convert.ToInt32(txtPhotoMaxSize.Text);
        //-----------------------------------------------------------------
        messagesModuleOptions.HasFileExtension = cbHasFileExtension.Checked;
        messagesModuleOptions.FileAvailableExtension = txtFileAvailableExtension.Text;
        messagesModuleOptions.FileMaxSize = Convert.ToInt32(txtFileMaxSize.Text);
        //-----------------------------------------------------------------
        messagesModuleOptions.HasOwenFolder_Admin = cbHasOwenFolder_Admin.Checked;
        messagesModuleOptions.HasOwenFolder_User = cbHasOwenFolder_User.Checked;
        messagesModuleOptions.ModuleSpecialPath = txtModuleSpecialPath.Text;

        //---------------------------------------------------------------
        messagesModuleOptions.HasExportData = cbHasExportData.Checked;
        //---------------------------------------------------------------------
        messagesModuleOptions.ModuleTitle = messagesModuleOptions.CreateModuleTitleIdentifire();
        messagesModuleOptions.ModuleAdminSpecialTitle = messagesModuleOptions.CreateModuleAdminSpecialTitleIdentifire();
        //---------------------------------------------------------------------
        messagesModuleOptions.RequiredName = cbRequiredName.Checked;
        messagesModuleOptions.RequiredMobile = cbRequiredMobile.Checked;
        messagesModuleOptions.RequiredEMail = cbRequiredEMail.Checked;
        messagesModuleOptions.RequiredCountryID = cbRequiredCountryID.Checked;
        messagesModuleOptions.RequiredNationalityID = cbRequiredNationalityID.Checked;
        messagesModuleOptions.RequiredAddress = cbRequiredAddress.Checked;
        messagesModuleOptions.RequiredJobTel = cbRequiredJobTel.Checked;
        messagesModuleOptions.RequiredType = cbRequiredType.Checked;
        messagesModuleOptions.RequiredTitle = cbRequiredTitle.Checked;
        messagesModuleOptions.RequiredDetails = cbRequiredDetails.Checked;
        messagesModuleOptions.RequiredToItemID = cbRequiredToItemID.Checked;
        messagesModuleOptions.RequiredShortDescription = cbRequiredShortDescription.Checked;
        messagesModuleOptions.RequiredReply = cbRequiredReply.Checked;
        messagesModuleOptions.RequiredEmpNo = cbRequiredEmpNo.Checked;
        messagesModuleOptions.RequiredBirthDate = cbRequiredBirthDate.Checked;
        messagesModuleOptions.RequiredCityID = cbRequiredCityID.Checked;
        messagesModuleOptions.RequiredGender = cbRequiredGender.Checked;
        messagesModuleOptions.RequiredNotes2 = cbRequiredNotes2.Checked;
        messagesModuleOptions.RequiredNotes1 = cbRequiredNotes1.Checked;
        messagesModuleOptions.RequiredTel = cbRequiredTel.Checked;
        messagesModuleOptions.RequiredUserCityName = cbRequiredUserCityName.Checked;
        messagesModuleOptions.RequiredAgeRang = cbRequiredAgeRang.Checked;
        messagesModuleOptions.RequiredEducationLevel = cbRequiredEducationLevel.Checked;
        messagesModuleOptions.RequiredSocialStatus = cbRequiredSocialStatus.Checked;
        messagesModuleOptions.RequiredFax = cbRequiredFax.Checked;
        messagesModuleOptions.RequiredMailBox = cbRequiredMailBox.Checked;
        messagesModuleOptions.RequiredZipCode = cbRequiredZipCode.Checked;
        messagesModuleOptions.RequiredJobID = cbRequiredJobID.Checked;
        messagesModuleOptions.RequiredJobText = cbRequiredJobText.Checked;
        messagesModuleOptions.RequiredUrl = cbRequiredUrl.Checked;
        messagesModuleOptions.RequiredPhotoExtension = cbRequiredPhotoExtension.Checked;
        messagesModuleOptions.RequiredCompany = cbRequiredCompany.Checked;
        messagesModuleOptions.RequiredActivitiesID = cbRequiredActivitiesID.Checked;
        messagesModuleOptions.RequiredFile = cbRequiredFile.Checked;
        messagesModuleOptions.ResourceFile = txtResourceFile.Text;
        messagesModuleOptions.DefaultResourceFile = txtDefaultResourceFile.Text;
        messagesModuleOptions.HasSpecialAdminText = cbHasSpecialAdminText.Checked;

        messagesModuleOptions.AddInAdminMenuAutmaticly = cbAddInAdminMenuAutmaticly.Checked;
        //---------------------------------------------
        messagesModuleOptions.HasVisitsCount = cbHasVisitiesCount.Checked;
        messagesModuleOptions.HasPrint = cbHasPrint.Checked;
        messagesModuleOptions.HasTelFriend = cbHasTelFriend.Checked;
        messagesModuleOptions.HasSaveAsDocument = cbHasSaveAsDocument.Checked;
        messagesModuleOptions.HasComments = cbHasComments.Checked;
        messagesModuleOptions.HasShare = cbHasShare.Checked;
        messagesModuleOptions.HasRSS = cbHasRSS.Checked;
        messagesModuleOptions.HasRating = cbHasRating.Checked;
        //---------------------------------------------
        //New Columns nnnnnnnnnnnnnnnnnnnnnnnnnnn---------
        //-----------------------------------
        messagesModuleOptions.HasItemDate = cbHasItemDate.Checked;
        messagesModuleOptions.HasDate_Added = cbHasDate_Added.Checked;
        messagesModuleOptions.HasIsMain = cbHasIsMain.Checked;
        messagesModuleOptions.HasPriority = cbHasPriority.Checked;
        messagesModuleOptions.HasYoutubeCode = cbHasYoutubeCode.Checked;
        //--------------------------------------------------------------
        messagesModuleOptions.HasVideoExtension = cbHasVideoExtension.Checked;
        messagesModuleOptions.VideoAvailableExtension = txtVideoAvailableExtension.Text;
        messagesModuleOptions.VideoMaxSize =Convert.ToInt32(txtVideoMaxSize.Text);
        messagesModuleOptions.HasAudioExtension = cbHasAudioExtension.Checked;
        messagesModuleOptions.AudioAvailableExtension = txtAudioAvailableExtension.Text;
        messagesModuleOptions.AudioMaxSize = Convert.ToInt32(txtAudioMaxSize.Text);
        messagesModuleOptions.HasPhoto2Extension = cbHasPhoto2Extension.Checked;
        messagesModuleOptions.Photo2AvailableExtension = txtPhoto2AvailableExtension.Text;
        messagesModuleOptions.Photo2MaxSize = Convert.ToInt32(txtPhoto2MaxSize.Text);
        //--------------------------------------------------------------
        messagesModuleOptions.HasHeight = cbHasHeight.Checked;
        messagesModuleOptions.HasWidth = cbHasWidth.Checked;
        //--------------------------------------------------------------
        messagesModuleOptions.RequiredItemDate = cbRequiredItemDate.Checked;
        messagesModuleOptions.RequiredHeight = cbRequiredHeight.Checked;
        messagesModuleOptions.RequiredWidth = cbRequiredWidth.Checked;
        messagesModuleOptions.RequiredVideo = cbRequiredVideo.Checked;
        messagesModuleOptions.RequiredAudio = cbRequiredAudio.Checked;
        messagesModuleOptions.RequiredPhoto2 = cbRequiredPhoto2.Checked;
        //-----------------------------------
        //End of New Columns nnnnnnnnnnnnnnnnnnnnnnnnnnn---------
        //-----------------------------------------------------------------------
        //-------------------
        messagesModuleOptions.RequiredYoutubeCode = cbRequiredYoutubeCode.Checked;
        messagesModuleOptions.ModuleRelatedPageID = Convert.ToInt32(txtModuleRelatedPageID.Text); 
        messagesModuleOptions.ListID = txtListID.Text;
        messagesModuleOptions.ListHasDate = cbListHasDate.Checked;
        //----------------------------------------------------------
        messagesModuleOptions.HasShortDescriptionInDetailsPage = cbHasShortDescriptionInDetailsPage.Checked;
        messagesModuleOptions.ShortDescriptionAllowToUser = cbShortDescriptionAllowToUser.Checked;
        messagesModuleOptions.DetailsAllowHtmlEditorForUser = cbDetailsAllowHtmlEditorForUser.Checked;
        //----------------------------------------------------------
        messagesModuleOptions.AdminNote = txtAdminNote.Text;
        //----------------------------------------------------------
        messagesModuleOptions.HasGoogleLatitude = cbHasGoogleLatitude.Checked;
        messagesModuleOptions.HasGoogleLongitude = cbHasGoogleLongitude.Checked;
        messagesModuleOptions.HasPrice = cbHasPrice.Checked;
        messagesModuleOptions.HasOnlyForRegisered = cbHasOnlyForRegisered.Checked;
        messagesModuleOptions.HasOwnerID = cbHasOwnerID.Checked;
        //--------------------------
        messagesModuleOptions.RequiredGoogleLatitude = cbRequiredGoogleLatitude.Checked;
        messagesModuleOptions.RequiredGoogleLongitude = cbRequiredGoogleLongitude.Checked;
        messagesModuleOptions.RequiredPrice = cbRequiredPrice.Checked;
        //--------------------------
        messagesModuleOptions.HasPublishPhoto = cbHasPublishPhoto.Checked;
        messagesModuleOptions.HasPublishPhoto2 = cbHasPublishPhoto2.Checked;
        messagesModuleOptions.HasPublishFile = cbHasPublishFile.Checked;
        messagesModuleOptions.HasPublishAudio = cbHasPublishAudio.Checked;
        messagesModuleOptions.HasPublishVideo = cbHasPublishVideo.Checked;
        messagesModuleOptions.HasPublishYoutbe = cbHasPublishYoutbe.Checked;
        //-------------------------------------------------------------------------------------------
        messagesModuleOptions.PageItemCount_UserDefault = Convert.ToInt32(txtPageItemCount_UserDefault.Text);
        messagesModuleOptions.PageItemCount_AdminDefault = Convert.ToInt32(txtPageItemCount_AdminDefault.Text);
        messagesModuleOptions.ShowInSiteDepartments = cbShowInSiteDepartments.Checked;
        //-------------------------------------------------------------------------------------------
        messagesModuleOptions.TableRowsPriorities = txtTableRowsPriorities.Text;
        //-------------------------------------------------------------------------------------------
        messagesModuleOptions.HasSearech = cbHasSearch.Checked;
        //-------------------------------------------------------------------------------------------
        messagesModuleOptions.DisplayCategoriesInAdminMenue = cbDisplayCategoriesInAdminMenue.Checked;
        messagesModuleOptions.ModuleMetaKeyWords = txtModuleMetaKeyWords.Text;
        messagesModuleOptions.ModuleMetaDescription = txtModuleMetaDescription.Text;
        messagesModuleOptions.HasMetaKeyWords = cbHasMetaKeyWords.Checked;
        messagesModuleOptions.HasMetaDescription = cbHasMetaDescription.Checked;
        messagesModuleOptions.UserCanSendMeta = cbUserCanSendMeta.Checked;
        //-------------------------------------------------------------------------------------------
        SiteModulesManager sm = SiteModulesManager.Instance;
        bool status = sm.SaveModule(messagesModuleOptions);
        //-----------------------------------------------------------------------
        if (status)
        {
            //--------------------------------------------------------------------
            ResourcesFilesManager.SaveResourcesData(messagesModuleOptions.ModuleTitle, txtModuleTitleArabic.Text, txtModuleTitleEnglish.Text);
            //--------------------------------------------------------------------
            if (txtModuleAdminSpecialTitleArabic.Text.Trim().Length == 0)
            { txtModuleAdminSpecialTitleArabic.Text = txtModuleTitleArabic.Text; }
            //--------------------------------------------------------------------
            if (txtModuleAdminSpecialTitleEnglish.Text.Trim().Length == 0)
            { txtModuleAdminSpecialTitleEnglish.Text = txtModuleTitleEnglish.Text; }
            //--------------------------------------------------------------------
            ResourcesFilesManager.SaveResourcesData(messagesModuleOptions.ModuleAdminSpecialTitle, txtModuleAdminSpecialTitleArabic.Text, txtModuleAdminSpecialTitleEnglish.Text);
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
    }
    //--------------------------------------------------------
    #endregion

    
}
