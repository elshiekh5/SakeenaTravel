using System;
using DCCMSNameSpace;
using System.Web;
namespace DCCMSNameSpace
{
    public class MessagesModuleOptions : MasterModule
    {
        #region --------------SendingOnlyByUsers--------------
        private bool _SendingOnlyByUsers;
        public bool SendingOnlyByUsers
        {
            get { return _SendingOnlyByUsers; }
            set { _SendingOnlyByUsers = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasName--------------
        private bool _HasName;
        public bool HasName
        {
            get { return _HasName; }
            set { _HasName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasNameSeparated--------------
        private bool _HasNameSeparated;
        public bool HasNameSeparated
        {
            get { return _HasNameSeparated; }
            set { _HasNameSeparated = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasMobile--------------
        private bool _HasMobile;
        public bool HasMobile
        {
            get { return _HasMobile; }
            set { _HasMobile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasEMail--------------
        private bool _HasEMail;
        public bool HasEMail
        {
            get { return _HasEMail; }
            set { _HasEMail = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasCountryID--------------
        private bool _HasCountryID;
        public bool HasCountryID
        {
            get { return _HasCountryID; }
            set { _HasCountryID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasAddress--------------
        private bool _HasAddress;
        public bool HasAddress
        {
            get { return _HasAddress; }
            set { _HasAddress = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasJobTel--------------
        private bool _HasJobTel;
        public bool HasJobTel
        {
            get { return _HasJobTel; }
            set { _HasJobTel = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasType--------------
        private bool _HasType;
        public bool HasType
        {
            get { return _HasType; }
            set { _HasType = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------TypesCount--------------
        private int _TypesCount;
        public int TypesCount
        {
            get { return _TypesCount; }
            set { _TypesCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasTitle--------------
        private bool _HasTitle;
        public bool HasTitle
        {
            get { return _HasTitle; }
            set { _HasTitle = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasDetails--------------
        private bool _HasDetails;
        public bool HasDetails
        {
            get { return _HasDetails; }
            set { _HasDetails = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------DetailsInHtmlEditor--------------
        private bool _DetailsInHtmlEditor = false;
        public bool DetailsInHtmlEditor
        {
            get { return _DetailsInHtmlEditor; }
            set { _DetailsInHtmlEditor = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasUserId--------------
        private bool _HasUserId;
        public bool HasUserId
        {
            get { return _HasUserId; }
            set { _HasUserId = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasToItemID--------------
        private bool _HasToItemID;
        public bool HasToItemID
        {
            get { return _HasToItemID; }
            set { _HasToItemID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ToItemModuleType--------------
        private int _ToItemModuleType = (int)StandardItemsModuleTypes.UnKnowen;
        public int ToItemModuleType
        {
            get { return _ToItemModuleType; }
            set { _ToItemModuleType = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------EnableSendMailToItem--------------
        private bool _EnableSendMailToItem;
        public bool EnableSendMailToItem
        {
            get { return _EnableSendMailToItem; }
            set { _EnableSendMailToItem = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasShortDescription--------------
        private bool _HasShortDescription;
        public bool HasShortDescription
        {
            get { return _HasShortDescription; }
            set { _HasShortDescription = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasReply--------------
        private bool _HasReply;
        public bool HasReply
        {
            get { return _HasReply; }
            set { _HasReply = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasAttachmentsInReplay--------------
        private bool _HasAttachmentsInReplay;
        public bool HasAttachmentsInReplay
        {
            get { return _HasAttachmentsInReplay; }
            set { _HasAttachmentsInReplay = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------ReplyInHtmlEditor--------------
        private bool _ReplyInHtmlEditor = false;
        public bool ReplyInHtmlEditor
        {
            get { return _ReplyInHtmlEditor; }
            set { _ReplyInHtmlEditor = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasIsAvailable--------------
        private bool _HasIsAvailable;
        public bool HasIsAvailable
        {
            get { return _HasIsAvailable; }
            set { _HasIsAvailable = value; }
        }
        //------------------------------------------
        #endregion
        
        #region --------------HasRedirectToMember--------------
        private bool _HasRedirectToMember;
        public bool HasRedirectToMember
        {
            get { return _HasRedirectToMember; }
            set { _HasRedirectToMember = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MemberRole--------------
        private string _MemberRole = "";
        public string MemberRole
        {
            get { return _MemberRole; }
            set { _MemberRole = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasEmpNo--------------
        private bool _HasEmpNo;
        public bool HasEmpNo
        {
            get { return _HasEmpNo; }
            set { _HasEmpNo = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasBirthDate--------------
        private bool _HasBirthDate;
        public bool HasBirthDate
        {
            get { return _HasBirthDate; }
            set { _HasBirthDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasCityID--------------
        private bool _HasCityID;
        public bool HasCityID
        {
            get { return _HasCityID; }
            set { _HasCityID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasUserCityName--------------
        private bool _HasUserCityName;
        public bool HasUserCityName
        {
            get { return _HasUserCityName; }
            set { _HasUserCityName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasGender--------------
        private bool _HasGender;
        public bool HasGender
        {
            get { return _HasGender; }
            set { _HasGender = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------HasNotes2--------------
        private bool _HasNotes2;
        public bool HasNotes2
        {
            get { return _HasNotes2; }
            set { _HasNotes2 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasNotes1--------------
        private bool _HasNotes1;
        public bool HasNotes1
        {
            get { return _HasNotes1; }
            set { _HasNotes1 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasTel--------------
        private bool _HasTel;
        public bool HasTel
        {
            get { return _HasTel; }
            set { _HasTel = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasAgeRang--------------
        private bool _HasAgeRang;
        public bool HasAgeRang
        {
            get { return _HasAgeRang; }
            set { _HasAgeRang = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasEducationLevel--------------
        private bool _HasEducationLevel;
        public bool HasEducationLevel
        {
            get { return _HasEducationLevel; }
            set { _HasEducationLevel = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasSocialStatus--------------
        private bool _HasSocialStatus;
        public bool HasSocialStatus
        {
            get { return _HasSocialStatus; }
            set { _HasSocialStatus = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasFax--------------
        private bool _HasFax;
        public bool HasFax
        {
            get { return _HasFax; }
            set { _HasFax = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasMailBox--------------
        private bool _HasMailBox;
        public bool HasMailBox
        {
            get { return _HasMailBox; }
            set { _HasMailBox = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasZipCode--------------
        private bool _HasZipCode;
        public bool HasZipCode
        {
            get { return _HasZipCode; }
            set { _HasZipCode = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasJobID--------------
        private bool _HasJobID;
        public bool HasJobID
        {
            get { return _HasJobID; }
            set { _HasJobID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasJobText--------------
        private bool _HasJobText;
        public bool HasJobText
        {
            get { return _HasJobText; }
            set { _HasJobText = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasUrl--------------
        private bool _HasUrl;
        public bool HasUrl
        {
            get { return _HasUrl; }
            set { _HasUrl = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasCompany--------------
        private bool _HasCompany;
        public bool HasCompany
        {
            get { return _HasCompany; }
            set { _HasCompany = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasActivitiesID--------------
        private bool _HasActivitiesID;
        public bool HasActivitiesID
        {
            get { return _HasActivitiesID; }
            set { _HasActivitiesID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasPhotoExtension--------------
        private bool _HasPhotoExtension;
        public bool HasPhotoExtension
        {
            get { return _HasPhotoExtension; }
            set { _HasPhotoExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------PhotoAvailableExtension--------------
        private string _PhotoAvailableExtension = "";
        public string PhotoAvailableExtension
        {
            get { return _PhotoAvailableExtension; }
            set { _PhotoAvailableExtension = value; }
        }
        //------------------------------------------
        #endregion
        
        #region --------------PhotoMaxSize--------------
        private int _PhotoMaxSize = -1;
        public int PhotoMaxSize
        {
            get { return _PhotoMaxSize; }
            set { _PhotoMaxSize = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasFileExtension--------------
        private bool _HasFileExtension;
        public bool HasFileExtension
        {
            get { return _HasFileExtension; }
            set { _HasFileExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------FileAvailableExtension--------------
        private string _FileAvailableExtension = "";
        public string FileAvailableExtension
        {
            get { return _FileAvailableExtension; }
            set { _FileAvailableExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------FileMaxSize--------------
        private int _FileMaxSize = -1;
        public int FileMaxSize
        {
            get { return _FileMaxSize; }
            set { _FileMaxSize = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasExportData--------------
        private bool _HasExportData;
        public bool HasExportData
        {
            get { return _HasExportData; }
            set { _HasExportData = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredName--------------
        private bool _RequiredName;
        public bool RequiredName
        {
            get { return _RequiredName; }
            set { _RequiredName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredMobile--------------
        private bool _RequiredMobile;
        public bool RequiredMobile
        {
            get { return _RequiredMobile; }
            set { _RequiredMobile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredEMail--------------
        private bool _RequiredEMail;
        public bool RequiredEMail
        {
            get { return _RequiredEMail; }
            set { _RequiredEMail = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredCountryID--------------
        private bool _RequiredCountryID;
        public bool RequiredCountryID
        {
            get { return _RequiredCountryID; }
            set { _RequiredCountryID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredAddress--------------
        private bool _RequiredAddress;
        public bool RequiredAddress
        {
            get { return _RequiredAddress; }
            set { _RequiredAddress = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredJobTel--------------
        private bool _RequiredJobTel;
        public bool RequiredJobTel
        {
            get { return _RequiredJobTel; }
            set { _RequiredJobTel = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredType--------------
        private bool _RequiredType;
        public bool RequiredType
        {
            get { return _RequiredType; }
            set { _RequiredType = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredTitle--------------
        private bool _RequiredTitle;
        public bool RequiredTitle
        {
            get { return _RequiredTitle; }
            set { _RequiredTitle = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredDetails--------------
        private bool _RequiredDetails;
        public bool RequiredDetails
        {
            get { return _RequiredDetails; }
            set { _RequiredDetails = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredToItemID--------------
        private bool _RequiredToItemID;
        public bool RequiredToItemID
        {
            get { return _RequiredToItemID; }
            set { _RequiredToItemID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredShortDescription--------------
        private bool _RequiredShortDescription;
        public bool RequiredShortDescription
        {
            get { return _RequiredShortDescription; }
            set { _RequiredShortDescription = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredReply--------------
        private bool _RequiredReply;
        public bool RequiredReply
        {
            get { return _RequiredReply; }
            set { _RequiredReply = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredEmpNo--------------
        private bool _RequiredEmpNo;
        public bool RequiredEmpNo
        {
            get { return _RequiredEmpNo; }
            set { _RequiredEmpNo = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredBirthDate--------------
        private bool _RequiredBirthDate;
        public bool RequiredBirthDate
        {
            get { return _RequiredBirthDate; }
            set { _RequiredBirthDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredCityID--------------
        private bool _RequiredCityID;
        public bool RequiredCityID
        {
            get { return _RequiredCityID; }
            set { _RequiredCityID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredGender--------------
        private bool _RequiredGender;
        public bool RequiredGender
        {
            get { return _RequiredGender; }
            set { _RequiredGender = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredNotes2--------------
        private bool _RequiredNotes2;
        public bool RequiredNotes2
        {
            get { return _RequiredNotes2; }
            set { _RequiredNotes2 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredNotes1--------------
        private bool _RequiredNotes1;
        public bool RequiredNotes1
        {
            get { return _RequiredNotes1; }
            set { _RequiredNotes1 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredTel--------------
        private bool _RequiredTel;
        public bool RequiredTel
        {
            get { return _RequiredTel; }
            set { _RequiredTel = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredUserCityName--------------
        private bool _RequiredUserCityName;
        public bool RequiredUserCityName
        {
            get { return _RequiredUserCityName; }
            set { _RequiredUserCityName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredAgeRang--------------
        private bool _RequiredAgeRang;
        public bool RequiredAgeRang
        {
            get { return _RequiredAgeRang; }
            set { _RequiredAgeRang = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredEducationLevel--------------
        private bool _RequiredEducationLevel;
        public bool RequiredEducationLevel
        {
            get { return _RequiredEducationLevel; }
            set { _RequiredEducationLevel = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredSocialStatus--------------
        private bool _RequiredSocialStatus;
        public bool RequiredSocialStatus
        {
            get { return _RequiredSocialStatus; }
            set { _RequiredSocialStatus = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredFax--------------
        private bool _RequiredFax;
        public bool RequiredFax
        {
            get { return _RequiredFax; }
            set { _RequiredFax = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredMailBox--------------
        private bool _RequiredMailBox;
        public bool RequiredMailBox
        {
            get { return _RequiredMailBox; }
            set { _RequiredMailBox = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredZipCode--------------
        private bool _RequiredZipCode;
        public bool RequiredZipCode
        {
            get { return _RequiredZipCode; }
            set { _RequiredZipCode = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredJobID--------------
        private bool _RequiredJobID;
        public bool RequiredJobID
        {
            get { return _RequiredJobID; }
            set { _RequiredJobID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredJobText--------------
        private bool _RequiredJobText;
        public bool RequiredJobText
        {
            get { return _RequiredJobText; }
            set { _RequiredJobText = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredUrl--------------
        private bool _RequiredUrl;
        public bool RequiredUrl
        {
            get { return _RequiredUrl; }
            set { _RequiredUrl = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredPhotoExtension--------------
        private bool _RequiredPhotoExtension;
        public bool RequiredPhotoExtension
        {
            get { return _RequiredPhotoExtension; }
            set { _RequiredPhotoExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredCompany--------------
        private bool _RequiredCompany;
        public bool RequiredCompany
        {
            get { return _RequiredCompany; }
            set { _RequiredCompany = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredActivitiesID--------------
        private bool _RequiredActivitiesID;
        public bool RequiredActivitiesID
        {
            get { return _RequiredActivitiesID; }
            set { _RequiredActivitiesID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredFile--------------
        private bool _RequiredFile;
        public bool RequiredFile
        {
            get { return _RequiredFile; }
            set { _RequiredFile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredYoutubeCode--------------
        private bool _RequiredYoutubeCode;
        public bool RequiredYoutubeCode
        {
            get { return _RequiredYoutubeCode; }
            set { _RequiredYoutubeCode = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------GetPhotoValidationExpression()--------------
        public string GetPhotoValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(PhotoAvailableExtension);
        }
        //------------------------------------------
        #endregion

        #region --------------GetFileValidationExpression()--------------

        public string GetFileValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(FileAvailableExtension);
        }
        //------------------------------------------
        #endregion

        #region --------------HasIsMain--------------
        private bool _HasIsMain;
        public bool HasIsMain
        {
            get { return _HasIsMain; }
            set { _HasIsMain = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasPriority--------------
        private bool _HasPriority;
        public bool HasPriority
        {
            get { return _HasPriority; }
            set { _HasPriority = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasItemDate--------------
        private bool _HasItemDate;
        public bool HasItemDate
        {
            get { return _HasItemDate; }
            set { _HasItemDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredItemDate--------------
        private bool _RequiredItemDate;
        public bool RequiredItemDate
        {
            get { return _RequiredItemDate; }
            set { _RequiredItemDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasDate_Added--------------
        private bool _HasDate_Added;
        public bool HasDate_Added
        {
            get { return _HasDate_Added; }
            set { _HasDate_Added = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasHeight--------------
        private bool _HasHeight;
        public bool HasHeight
        {
            get { return _HasHeight; }
            set { _HasHeight = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasWidth--------------
        private bool _HasWidth;
        public bool HasWidth
        {
            get { return _HasWidth; }
            set { _HasWidth = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredHeight--------------
        private bool _RequiredHeight;
        public bool RequiredHeight
        {
            get { return _RequiredHeight; }
            set { _RequiredHeight = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredWidth--------------
        private bool _RequiredWidth;
        public bool RequiredWidth
        {
            get { return _RequiredWidth; }
            set { _RequiredWidth = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasVideoExtension--------------
        private bool _HasVideoExtension;
        public bool HasVideoExtension
        {
            get { return _HasVideoExtension; }
            set { _HasVideoExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------VideoAvailableExtension--------------
        private string _VideoAvailableExtension = "";
        public string VideoAvailableExtension
        {
            get { return _VideoAvailableExtension; }
            set { _VideoAvailableExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------VideoMaxSize--------------
        private int _VideoMaxSize = -1;
        public int VideoMaxSize
        {
            get { return _VideoMaxSize; }
            set { _VideoMaxSize = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasAudioExtension--------------
        private bool _HasAudioExtension;
        public bool HasAudioExtension
        {
            get { return _HasAudioExtension; }
            set { _HasAudioExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AudioAvailableExtension--------------
        private string _AudioAvailableExtension = "";
        public string AudioAvailableExtension
        {
            get { return _AudioAvailableExtension; }
            set { _AudioAvailableExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AudioMaxSize--------------
        private int _AudioMaxSize = -1;
        public int AudioMaxSize
        {
            get { return _AudioMaxSize; }
            set { _AudioMaxSize = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasPhoto2Extension--------------
        private bool _HasPhoto2Extension;
        public bool HasPhoto2Extension
        {
            get { return _HasPhoto2Extension; }
            set { _HasPhoto2Extension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Photo2AvailableExtension--------------
        private string _Photo2AvailableExtension = "";
        public string Photo2AvailableExtension
        {
            get { return _Photo2AvailableExtension; }
            set { _Photo2AvailableExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Photo2MaxSize--------------
        private int _Photo2MaxSize = -1;
        public int Photo2MaxSize
        {
            get { return _Photo2MaxSize; }
            set { _Photo2MaxSize = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ListID--------------
        private string _ListID = "dlMessages";
        public string ListID
        {
            get { return _ListID; }
            set { _ListID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ListHasDate--------------
        private bool _ListHasDate;
        public bool ListHasDate
        {
            get { return _ListHasDate; }
            set { _ListHasDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ListHasVisitiesCount--------------
        public bool _ListHasVisitiesCount = false;
        public bool ListHasVisitiesCount { get { return _ListHasVisitiesCount; } set { _ListHasVisitiesCount = value; } }
        //------------------------------------------
        #endregion

        #region --------------RequiredVideo--------------
        private bool _RequiredVideo;
        public bool RequiredVideo
        {
            get { return _RequiredVideo; }
            set { _RequiredVideo = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredAudio--------------
        private bool _RequiredAudio;
        public bool RequiredAudio
        {
            get { return _RequiredAudio; }
            set { _RequiredAudio = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredPhoto2--------------
        private bool _RequiredPhoto2;
        public bool RequiredPhoto2
        {
            get { return _RequiredPhoto2; }
            set { _RequiredPhoto2 = value; }
        }
        //------------------------------------------
        #endregion

        

        #region --------------HasCategoryIntro--------------
        private bool _HasCategoryIntro;
        public bool HasCategoryIntro
        {
            get { return _HasCategoryIntro; }
            set { _HasCategoryIntro = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasYoutubeCode--------------
        private bool _HasYoutubeCode;
        public bool HasYoutubeCode
        {
            get { return _HasYoutubeCode; }
            set { _HasYoutubeCode = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasVisitsCount--------------
        public bool _HasVisitsCount = false;
        public bool HasVisitsCount { get { return _HasVisitsCount; } set { _HasVisitsCount = value; } }
        //------------------------------------------
        #endregion

        #region --------------HasPrint--------------
        private bool _HasPrint;
        public bool HasPrint
        {
            get { return _HasPrint; }
            set { _HasPrint = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasTelFriend--------------
        private bool _HasTelFriend;
        public bool HasTelFriend
        {
            get { return _HasTelFriend; }
            set { _HasTelFriend = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasSaveAsDocument--------------
        private bool _HasSaveAsDocument;
        public bool HasSaveAsDocument
        {
            get { return _HasSaveAsDocument; }
            set { _HasSaveAsDocument = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasComments--------------
        private bool _HasComments;
        public bool HasComments
        {
            get { return _HasComments; }
            set { _HasComments = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasShare--------------
        private bool _HasShare;
        public bool HasShare
        {
            get { return _HasShare; }
            set { _HasShare = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasRSS--------------
        private bool _HasRSS;
        public bool HasRSS
        {
            get { return _HasRSS; }
            set { _HasRSS = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasRating--------------
        private bool _HasRating;
        public bool HasRating
        {
            get { return _HasRating; }
            set { _HasRating = value; }
        }
        //------------------------------------------
        #endregion
        //-----------------------------------

        #region --------------HasShortDescriptionInDetailsPage--------------
        private bool _HasShortDescriptionInDetailsPage;
        public bool HasShortDescriptionInDetailsPage
        {
            get { return _HasShortDescriptionInDetailsPage; }
            set { _HasShortDescriptionInDetailsPage = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ShortDescriptionAllowToUser--------------
        private bool _ShortDescriptionAllowToUser;
        public bool ShortDescriptionAllowToUser
        {
            get { return _ShortDescriptionAllowToUser; }
            set { _ShortDescriptionAllowToUser = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------DetailsAllowHtmlEditorForUser--------------
        private bool _DetailsAllowHtmlEditorForUser;
        public bool DetailsAllowHtmlEditorForUser
        {
            get { return _DetailsAllowHtmlEditorForUser; }
            set { _DetailsAllowHtmlEditorForUser = value; }
        }
        //------------------------------------------
        #endregion

        
        //-----------------------------------

        #region --------------HasGoogleLatitude--------------
        private bool _HasGoogleLatitude;
        public bool HasGoogleLatitude
        {
            get { return _HasGoogleLatitude; }
            set { _HasGoogleLatitude = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasGoogleLongitude--------------
        private bool _HasGoogleLongitude;
        public bool HasGoogleLongitude
        {
            get { return _HasGoogleLongitude; }
            set { _HasGoogleLongitude = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasPrice--------------
        private bool _HasPrice;
        public bool HasPrice
        {
            get { return _HasPrice; }
            set { _HasPrice = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasOnlyForRegisered--------------
        private bool _HasOnlyForRegisered;
        public bool HasOnlyForRegisered
        {
            get { return _HasOnlyForRegisered; }
            set { _HasOnlyForRegisered = value; }
        }
        //------------------------------------------
        #endregion
        
        //------------------------------------------
        #region --------------RequiredGoogleLatitude--------------
        private bool _RequiredGoogleLatitude;
        public bool RequiredGoogleLatitude
        {
            get { return _RequiredGoogleLatitude; }
            set { _RequiredGoogleLatitude = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredGoogleLongitude--------------
        private bool _RequiredGoogleLongitude;
        public bool RequiredGoogleLongitude
        {
            get { return _RequiredGoogleLongitude; }
            set { _RequiredGoogleLongitude = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredPrice--------------
        private bool _RequiredPrice;
        public bool RequiredPrice
        {
            get { return _RequiredPrice; }
            set { _RequiredPrice = value; }
        }
        //------------------------------------------
        #endregion

        //-----------------------------------
        #region --------------HasPublishPhoto--------------
        private bool _HasPublishPhoto;
        public bool HasPublishPhoto
        {
            get { return _HasPublishPhoto; }
            set { _HasPublishPhoto = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------HasPublishPhoto2--------------
        private bool _HasPublishPhoto2;
        public bool HasPublishPhoto2
        {
            get { return _HasPublishPhoto2; }
            set { _HasPublishPhoto2 = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------HasPublishFile--------------
        private bool _HasPublishFile;
        public bool HasPublishFile
        {
            get { return _HasPublishFile; }
            set { _HasPublishFile = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------HasPublishAudio--------------
        private bool _HasPublishAudio;
        public bool HasPublishAudio
        {
            get { return _HasPublishAudio; }
            set { _HasPublishAudio = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------HasPublishVideo--------------
        private bool _HasPublishVideo;
        public bool HasPublishVideo
        {
            get { return _HasPublishVideo; }
            set { _HasPublishVideo = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------HasPublishYoutbe--------------
        private bool _HasPublishYoutbe;
        public bool HasPublishYoutbe
        {
            get { return _HasPublishYoutbe; }
            set { _HasPublishYoutbe = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------HasNationalityID--------------
        private bool _HasNationalityID;
        public bool HasNationalityID
        {
            get { return _HasNationalityID; }
            set { _HasNationalityID = value; }
        }
        //------------------------------------------
        #endregion
        //-----------------------------------
        #region --------------RequiredNationalityID--------------
        private bool _RequiredNationalityID;
        public bool RequiredNationalityID
        {
            get { return _RequiredNationalityID; }
            set { _RequiredNationalityID = value; }
        }
        //------------------------------------------
        #endregion
        

        #region --------------VideoValidationExpression--------------
        public string GetVideoValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(VideoAvailableExtension);
        }
        //------------------------------------------
        #endregion

        #region --------------AudioValidationExpression--------------
        public string GetAudioValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(AudioAvailableExtension);
        }
        //------------------------------------------
        #endregion

        #region --------------Photo2ValidationExpression--------------
        public string GetPhoto2ValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(Photo2AvailableExtension);
        }
        //------------------------------------------
        #endregion

        #region --------------TableRowsPriorities--------------
        private string _TableRowsPriorities = "";
        public string TableRowsPriorities
        {
            get { return _TableRowsPriorities; }
            set { _TableRowsPriorities = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------HasSearech--------------
        private bool _HasSearech;
        public bool HasSearech
        {
            get { return _HasSearech; }
            set { _HasSearech = value; }
        }
        //------------------------------------------
        #endregion
        //----------------------------------------------------------/

        #region --------------Additional MailList options----------------
        #region --------------HasHasEmailService--------------
        private bool _HasHasEmailService;
        public bool HasHasEmailService
        {
            get { return _HasHasEmailService; }
            set { _HasHasEmailService = value; }
        }
        //------------------------------------------
        #endregion

        #endregion

        #region --------------Additional Sms options----------------

        #region --------------HasHasSmsService--------------
        private bool _HasHasSmsService;
        public bool HasHasSmsService
        {
            get { return _HasHasSmsService; }
            set { _HasHasSmsService = value; }
        }
        //------------------------------------------
        #endregion

        #endregion

        #region --------------Additional Seo Options--------------

        #region --------------UserCanSendMeta--------------
        private bool _UserCanSendMeta = false;
        public bool UserCanSendMeta
        {
            get { return _UserCanSendMeta; }
            set { _UserCanSendMeta = value; }
        }
        //------------------------------------------
        #endregion

        #endregion
        //----------------------------------------------------------/
        //----------------------------------------------------------/
        public MessagesModuleOptions()
        {
            ModuleBaseType = ModuleBaseTypes.Messages;
            ModuleType = ModuleTypes.Messages_Only;
            ResourceFile = "Messages";
            DefaultResourceFile = "Messages";

        }
        //----------------------------------------------------------/
        //---------------------------------------------------------
        public static MessagesModuleOptions GetType(int moduleType)
        {
            return SiteModulesManager.Instance.GetMessageModule(moduleType);
        }
        //---------------------------------------------------------
        //---------------------------------------------------------
        public static MessagesModuleOptions GetType(string module)
        {
            return SiteModulesManager.Instance.GetMessageModule(module);
        }
        //---------------------------------------------------------
        

    }

}



