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
            this.Page.Title = "ÕÝÍÇÊ ÇáãæÞÚ";
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
        //------------------------------------------------------------------------------------------
        int pageID = -1;
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            pageID = (int)Convert.ToInt32(Request.QueryString["id"]);
        }
        SitePageOptions page = SitePageOptions.GetPage(pageID);
        if (pageID > 0)
        {
            txtPageID.Text = pageID.ToString();
        }
        else
        {
            txtPageID.Text = "";
        }
        if (page.Identifire.ToLower() != "unknown")
        {
            txtIdentifire.Text = page.Identifire;
        }
        else
        {
            txtIdentifire.Text = "";
        }

        txtPageTitle.Text = page.Title;
        //------------------------------------------------------------------------------------------
        cbHasDetails.Checked = page.HasDetails;
        cbDetailsInHtmlEditor.Checked = page.DetailsInHtmlEditor;
        cbHasShortDescription.Checked = page.HasShortDescription;
        cbHasTitle.Checked = page.HasTitle;
        cbHasTitleInDetailsPage.Checked = page.HasTitleInDetailsPage;
        cbHasHeight.Checked = page.HasHeight;
        cbHasWidth.Checked = page.HasWidth;
        cbHasAddress.Checked = page.HasAddress;
        cbHasMailBox.Checked = page.HasMailBox;
        cbHasZipCode.Checked = page.HasZipCode;
        cbHasTels.Checked = page.HasTels;
        cbHasFax.Checked = page.HasFax;
        cbHasMobile.Checked = page.HasMobile;
        cbHasUrl.Checked = page.HasUrl;
        cbHasEmail.Checked = page.HasEmail;
        cbHasItemDate.Checked = page.HasItemDate;
        cbHasDate_Added.Checked = page.HasDate_Added;
        cbHasIsMain.Checked = page.HasIsMain;
        cbHasPriority.Checked = page.HasPriority;
        cbHasIsAvailable.Checked = page.HasIsAvailable;
        cbHasYoutubeCode.Checked = page.HasYoutubeCode;
        cbHasAuthorID.Checked = page.HasAuthorID;
        cbHasAuthorName.Checked = page.HasAuthorName;
        //---------------------------------------------
        cbHasVisitiesCount.Checked = page.HasVisitsCount;
        cbHasPrint.Checked = page.HasPrint;
        cbHasTelFriend.Checked = page.HasTelFriend;
        cbHasSaveAsDocument.Checked = page.HasSaveAsDocument;
        cbHasComments.Checked = page.HasComments;
        cbHasShare.Checked = page.HasShare;
        cbHasRSS.Checked = page.HasRSS;
        cbHasRating.Checked = page.HasRating;
        //---------------------------------------------
        cbHasPhotoExtension.Checked = page.HasPhotoExtension;
        txtPhotoAvailableExtension.Text = page.PhotoAvailableExtension;
        txtPhotoMaxSize.Text = page.PhotoMaxSize.ToString();
        cbHasFileExtension.Checked = page.HasFileExtension;
        txtFileAvailableExtension.Text = page.FileAvailableExtension;
        txtFileMaxSize.Text = page.FileMaxSize.ToString();
        //--------------------------------------------------------------
        cbHasVideoExtension.Checked = page.HasVideoExtension;
        txtVideoAvailableExtension.Text = page.VideoAvailableExtension;
        txtVideoMaxSize.Text = page.VideoMaxSize.ToString();
        cbHasAudioExtension.Checked = page.HasAudioExtension;
        txtAudioAvailableExtension.Text = page.AudioAvailableExtension;
        txtAudioMaxSize.Text = page.AudioMaxSize.ToString();
        cbHasPhoto2Extension.Checked = page.HasPhoto2Extension;
        txtPhoto2AvailableExtension.Text = page.Photo2AvailableExtension;
        txtPhoto2MaxSize.Text = page.Photo2MaxSize.ToString();
        //--------------------------------------------------------------
        cbHasMultiPhotos.Checked = page.HasMultiPhotos;
        cbHasMessages.Checked = page.HasMessages;
        txtResourceFile.Text = page.ResourceFile;
        txtDefaultResourceFile.Text = page.DefaultResourceFile;
       
        cbRequiredTitle.Checked = page.RequiredTitle;
        cbRequiredShortDescription.Checked = page.RequiredShortDescription;
        cbRequiredDetails.Checked = page.RequiredDetails;
        cbRequiredAuthorName.Checked = page.RequiredAuthorName;
        cbRequiredHeight.Checked = page.RequiredHeight;
        cbRequiredWidth.Checked = page.RequiredWidth;
        cbRequiredAddress.Checked = page.RequiredAddress;
        cbRequiredMailBox.Checked = page.RequiredMailBox;
        cbRequiredZipCode.Checked = page.RequiredZipCode;
        cbRequiredTels.Checked = page.RequiredTels;
        cbRequiredFax.Checked = page.RequiredFax;
        cbRequiredMobile.Checked = page.RequiredMobile;
        cbRequiredUrl.Checked = page.RequiredUrl;
        cbRequiredEmail.Checked = page.RequiredEmail;
        cbRequiredItemDate.Checked = page.RequiredItemDate;
        cbRequiredPhoto.Checked = page.RequiredPhoto;
        cbRequiredFile.Checked = page.RequiredFile;
        cbRequiredVideo.Checked = page.RequiredVideo;
        cbRequiredAudio.Checked = page.RequiredAudio;
        cbRequiredPhoto2.Checked = page.RequiredPhoto2;
        //-------------------
        cbRequiredYoutubeCode.Checked = page.RequiredYoutubeCode;
        //----------------------------------------------------------
        cbHasOwenFolder_Admin.Checked = page.HasOwenFolder_Admin;
        cbHasOwenFolder_User.Checked = page.HasOwenFolder_User;
        txtModuleSpecialPath.Text = page.ModuleSpecialPath;
        //----------------------------------------------------------
        cbMailListAutomaticRegistration.Checked = page.MailListAutomaticRegistration;
        cbMailListSendingMailActivation.Checked = page.MailListSendingMailActivation;
        cbMailListAutomaticActivation.Checked = page.MailListAutomaticActivation;
        cbSmsAutomaticRegistration.Checked = page.SmsAutomaticRegistration;
        cbSmsSendingSmsActivation.Checked = page.SmsSendingSmsActivation;
        cbSmsAutomaticActivation.Checked = page.SmsAutomaticActivation;
        cbAddInAdminMenuAutmaticly.Checked = page.AddInAdminMenuAutmaticly;
        //----------------------------------------------------------
        cbHasShortDescriptionInDetailsPage.Checked = page.HasShortDescriptionInDetailsPage;
        txtAdminNote.Text = page.AdminNote;
        //----------------------------------------------------------
        cbHasGoogleLatitude.Checked = page.HasGoogleLatitude;
        cbHasGoogleLongitude.Checked = page.HasGoogleLongitude;
        cbHasPrice.Checked = page.HasPrice;
        cbHasOnlyForRegisered.Checked = page.HasOnlyForRegisered;
        cbHasOwnerID.Checked = page.HasOwnerID;
        //--------------------------
        cbRequiredGoogleLatitude.Checked = page.RequiredGoogleLatitude;
        cbRequiredGoogleLongitude.Checked = page.RequiredGoogleLongitude;
        cbRequiredPrice.Checked = page.RequiredPrice;
        //--------------------------
        cbHasPublishPhoto.Checked = page.HasPublishPhoto;
        cbHasPublishPhoto2.Checked = page.HasPublishPhoto2;
        cbHasPublishFile.Checked = page.HasPublishFile;
        cbHasPublishAudio.Checked = page.HasPublishAudio;
        cbHasPublishVideo.Checked = page.HasPublishVideo;
        cbHasPublishYoutbe.Checked = page.HasPublishYoutbe;
        //-------------------------------------------------------------------------------------------
        //-----------------------------------------------
        //Visitors Participations
        //----------------------------
        cbAllowVisitorsParticipations.Checked = page.AllowVisitorsParticipations;
        cbSendingOnlyByUsers.Checked = page.SendingOnlyByUsers;

        cbHasSenderName.Checked = page.HasSenderName;
        cbRequiredSenderName.Checked = page.RequiredSenderName;

        cbHasSenderEMail.Checked = page.HasSenderEMail;
        cbRequiredSenderEMail.Checked = page.RequiredSenderEMail;

        cbHasSenderCountryID.Checked = page.HasSenderCountryID;
        cbRequiredSenderCountryID.Checked = page.RequiredSenderCountryID;

        cbHasRedirectToMember.Checked = page.HasRedirectToMember;
        txtMemberRole.Text = page.MemberRole;

        cbHasReply.Checked = page.HasReply;
        cbReplyInHtmlEditor.Checked = page.ReplyInHtmlEditor;
        cbRequiredReply.Checked = page.RequiredReply;
        //-------------------------------------------------------------------------------------------
        cbShowInSiteDepartments.Checked = page.ShowInSiteDepartments;
        //-------------------------------------------------------------------------------------------
        cbHasMetaKeyWords.Checked = page.HasMetaKeyWords;
        cbHasMetaDescription.Checked = page.HasMetaDescription;
        //-------------------------------------------------------------------------------------------
        //txtModuleTitle.Text = page.ModuleTitle;
       /* ResourcesFilesManager rfmArabic = new ResourcesFilesManager(ResourcesFilesManager.ModuleResourceFileArabic);
        ResourcesFilesManager rfmEnglish = new ResourcesFilesManager(ResourcesFilesManager.ModuleResourceFileEnglish);
        txtModuleTitleArabic.Text = rfmArabic.GetNodeValue(page.ModuleTitle);
        txtModuleTitleEnglish.Text = rfmEnglish.GetNodeValue(page.ModuleTitle);*/
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
        //------------------------------------------------------------------------------------------
        if (!Page.IsValid)
        {
            return;
        }
        //--------------------------------------------------------
        int pageID = (int)StandardItemsModuleTypes.UnKnowen;
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            pageID = (int)Convert.ToInt32(Request.QueryString["id"]);
        }
        SitePageOptions page = SitePageOptions.GetPage(pageID);
        //--------------------------------------------------------
        if (pageID == (int)StandardItemsModuleTypes.UnKnowen)
            page.PageID = Convert.ToInt32(txtPageID.Text);
        //------------------------------------
        page.Identifire = txtIdentifire.Text.Trim();
        page.Title = txtPageTitle.Text;
        //------------------------------------------------------------------------------------------
        page.HasDetails = cbHasDetails.Checked;
        page.DetailsInHtmlEditor = cbDetailsInHtmlEditor.Checked;
        page.HasShortDescription = cbHasShortDescription.Checked;
        page.HasTitle = cbHasTitle.Checked;
        page.HasTitleInDetailsPage = cbHasTitleInDetailsPage.Checked;
        page.HasHeight = cbHasHeight.Checked;
        page.HasWidth = cbHasWidth.Checked;
        page.HasAddress = cbHasAddress.Checked;
        page.HasMailBox = cbHasMailBox.Checked;
        page.HasZipCode = cbHasZipCode.Checked;
        page.HasTels = cbHasTels.Checked;
        page.HasFax = cbHasFax.Checked;
        page.HasMobile = cbHasMobile.Checked;
        page.HasUrl = cbHasUrl.Checked;
        page.HasEmail = cbHasEmail.Checked;

        page.HasItemDate = cbHasItemDate.Checked;
        page.HasDate_Added = cbHasDate_Added.Checked;

        page.HasIsMain = cbHasIsMain.Checked;
        page.HasPriority = cbHasPriority.Checked;
        page.HasIsAvailable = cbHasIsAvailable.Checked;
        page.HasYoutubeCode = cbHasYoutubeCode.Checked;
        page.HasAuthorID = cbHasAuthorID.Checked;
        page.HasAuthorName = cbHasAuthorName.Checked;
        //---------------------------------------------
        page.HasVisitsCount = cbHasVisitiesCount.Checked;
        page.HasPrint = cbHasPrint.Checked;
        page.HasTelFriend = cbHasTelFriend.Checked;
        page.HasSaveAsDocument = cbHasSaveAsDocument.Checked;
        page.HasComments = cbHasComments.Checked;
        page.HasShare = cbHasShare.Checked;
        page.HasRSS = cbHasRSS.Checked;
        page.HasRating = cbHasRating.Checked;
        //---------------------------------------------
        page.HasPhotoExtension = cbHasPhotoExtension.Checked;

        page.PhotoAvailableExtension = txtPhotoAvailableExtension.Text;
        page.PhotoMaxSize = Convert.ToInt32(txtPhotoMaxSize.Text);
        page.HasFileExtension = cbHasFileExtension.Checked;
        page.FileAvailableExtension = txtFileAvailableExtension.Text;
        page.FileMaxSize = Convert.ToInt32(txtFileMaxSize.Text);
        page.HasVideoExtension = cbHasVideoExtension.Checked;
        page.VideoAvailableExtension = txtVideoAvailableExtension.Text;
        page.VideoMaxSize = Convert.ToInt32(txtVideoMaxSize.Text);
        page.HasAudioExtension = cbHasAudioExtension.Checked;
        page.AudioAvailableExtension = txtAudioAvailableExtension.Text;
        page.AudioMaxSize = Convert.ToInt32(txtAudioMaxSize.Text);
        page.HasPhoto2Extension = cbHasPhoto2Extension.Checked;
        page.Photo2AvailableExtension = txtPhoto2AvailableExtension.Text;
        page.Photo2MaxSize = Convert.ToInt32(txtPhoto2MaxSize.Text);
        page.HasMultiPhotos = cbHasMultiPhotos.Checked;
        page.HasMessages = cbHasMessages.Checked;
        page.ResourceFile = txtResourceFile.Text;
        page.DefaultResourceFile = txtDefaultResourceFile.Text;
        
        page.RequiredTitle = cbRequiredTitle.Checked;
        page.RequiredShortDescription = cbRequiredShortDescription.Checked;
        page.RequiredDetails = cbRequiredDetails.Checked;
        page.RequiredAuthorName = cbRequiredAuthorName.Checked;
        page.RequiredHeight = cbRequiredHeight.Checked;
        page.RequiredWidth = cbRequiredWidth.Checked;
        page.RequiredAddress = cbRequiredAddress.Checked;
        page.RequiredMailBox = cbRequiredMailBox.Checked;
        page.RequiredZipCode = cbRequiredZipCode.Checked;
        page.RequiredTels = cbRequiredTels.Checked;
        page.RequiredFax = cbRequiredFax.Checked;
        page.RequiredMobile = cbRequiredMobile.Checked;
        page.RequiredUrl = cbRequiredUrl.Checked;
        page.RequiredEmail = cbRequiredEmail.Checked;
        page.RequiredItemDate = cbRequiredItemDate.Checked;
        page.RequiredPhoto = cbRequiredPhoto.Checked;
        page.RequiredFile = cbRequiredFile.Checked;
        page.RequiredVideo = cbRequiredVideo.Checked;
        page.RequiredAudio = cbRequiredAudio.Checked;
        page.RequiredPhoto2 = cbRequiredPhoto2.Checked;
        //---------------------------------------------------------------------
        //page.ModuleTitle = page.CreateModuleTitleIdentifire();
        //---------------------------------------------------------------------
        page.HasOwenFolder_Admin = cbHasOwenFolder_Admin.Checked;
        page.HasOwenFolder_User = cbHasOwenFolder_User.Checked;
        page.ModuleSpecialPath = txtModuleSpecialPath.Text;
        //----------------------------------------------------------
        page.MailListAutomaticRegistration = cbMailListAutomaticRegistration.Checked;
        page.MailListSendingMailActivation = cbMailListSendingMailActivation.Checked;
        page.MailListAutomaticActivation = cbMailListAutomaticActivation.Checked;
        page.SmsAutomaticRegistration = cbSmsAutomaticRegistration.Checked;
        page.SmsSendingSmsActivation = cbSmsSendingSmsActivation.Checked;
        page.SmsAutomaticActivation = cbSmsAutomaticActivation.Checked;
        page.AddInAdminMenuAutmaticly = cbAddInAdminMenuAutmaticly.Checked;
        //-----------------------------------------------------------------------
        //-------------------
        page.RequiredYoutubeCode = cbRequiredYoutubeCode.Checked;
        //----------------------------------------------------------
        page.HasShortDescriptionInDetailsPage = cbHasShortDescriptionInDetailsPage.Checked;
        page.AdminNote = txtAdminNote.Text;
        //----------------------------------------------------------
        page.HasGoogleLatitude = cbHasGoogleLatitude.Checked;
        page.HasGoogleLongitude = cbHasGoogleLongitude.Checked;
        page.HasPrice = cbHasPrice.Checked;
        page.HasOnlyForRegisered = cbHasOnlyForRegisered.Checked;
        page.HasOwnerID = cbHasOwnerID.Checked;
        //--------------------------
        page.RequiredGoogleLatitude = cbRequiredGoogleLatitude.Checked;
        page.RequiredGoogleLongitude = cbRequiredGoogleLongitude.Checked;
        page.RequiredPrice = cbRequiredPrice.Checked;
        //--------------------------
        page.HasPublishPhoto = cbHasPublishPhoto.Checked;
        page.HasPublishPhoto2 = cbHasPublishPhoto2.Checked;
        page.HasPublishFile = cbHasPublishFile.Checked;
        page.HasPublishAudio = cbHasPublishAudio.Checked;
        page.HasPublishVideo = cbHasPublishVideo.Checked;
        page.HasPublishYoutbe = cbHasPublishYoutbe.Checked;
        //-------------------------------------------------------------------------------------------
        //-----------------------------------------------
        //Visitors Participations
        //----------------------------
        page.AllowVisitorsParticipations = cbAllowVisitorsParticipations.Checked;
        page.SendingOnlyByUsers = cbSendingOnlyByUsers.Checked;

        page.HasSenderName = cbHasSenderName.Checked;
        page.RequiredSenderName = cbRequiredSenderName.Checked;

        page.HasSenderEMail = cbHasSenderEMail.Checked;
        page.RequiredSenderEMail = cbRequiredSenderEMail.Checked;

        page.HasSenderCountryID = cbHasSenderCountryID.Checked;
        page.RequiredSenderCountryID = cbRequiredSenderCountryID.Checked;

        page.HasRedirectToMember = cbHasRedirectToMember.Checked;
        page.MemberRole = txtMemberRole.Text;

        page.HasReply = cbHasReply.Checked;
        page.ReplyInHtmlEditor = cbReplyInHtmlEditor.Checked;
        page.RequiredReply = cbRequiredReply.Checked;
        //-------------------------------------------------------------------------------------------
        page.ShowInSiteDepartments = cbShowInSiteDepartments.Checked;
        //-------------------------------------------------------------------------------------------
        page.HasMetaKeyWords = cbHasMetaKeyWords.Checked;
        page.HasMetaDescription = cbHasMetaDescription.Checked;
        //-------------------------------------------------------------------------------------------
        SiteModulesManager sm = SiteModulesManager.Instance;
        bool status = sm.SavePage(page);
        //-----------------------------------------------------------------------
        if (status)
        {
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
        txtPageID.Text = "";
        txtIdentifire.Text = "";
        txtPageTitle.Text = "";
        //-------------------------------------------
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
        //-------------------------------------------
        cbHasOwenFolder_Admin.Checked = false;
        cbHasOwenFolder_User.Checked = false;
        //-------------------------------------------
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
