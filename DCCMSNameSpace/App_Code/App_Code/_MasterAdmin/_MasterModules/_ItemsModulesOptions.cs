using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
namespace DCCMSNameSpace
{

    public class ItemsModulesOptions : MasterModule
    {



        #region --------------Categories Options--------------



        #region --------------CategoryHasIsAvailable--------------
        private bool _CategoryHasIsAvailable;
        public bool CategoryHasIsAvailable
        {
            get { return _CategoryHasIsAvailable; }
            set { _CategoryHasIsAvailable = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasShortDescription--------------
        private bool _CategoryHasShortDescription;
        public bool CategoryHasShortDescription
        {
            get { return _CategoryHasShortDescription; }
            set { _CategoryHasShortDescription = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasTitle--------------
        private bool _CategoryHasTitle;
        public bool CategoryHasTitle
        {
            get { return _CategoryHasTitle; }
            set { _CategoryHasTitle = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredTitle--------------
        private bool _CategoryRequiredTitle;
        public bool CategoryRequiredTitle
        {
            get { return _CategoryRequiredTitle; }
            set { _CategoryRequiredTitle = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredShortDescription--------------
        private bool _CategoryRequiredShortDescription;
        public bool CategoryRequiredShortDescription
        {
            get { return _CategoryRequiredShortDescription; }
            set { _CategoryRequiredShortDescription = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredPhoto--------------
        private bool _CategoryRequiredPhoto;
        public bool CategoryRequiredPhoto
        {
            get { return _CategoryRequiredPhoto; }
            set { _CategoryRequiredPhoto = value; }
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

        //////////////////////////////////////////////////////////////

        #region --------------CategoryHasDetails--------------
        private bool _CategoryHasDetails;
        public bool CategoryHasDetails
        {
            get { return _CategoryHasDetails; }
            set { _CategoryHasDetails = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryDetailsInHtmlEditor--------------
        private bool _CategoryDetailsInHtmlEditor = true;
        public bool CategoryDetailsInHtmlEditor
        {
            get { return _CategoryDetailsInHtmlEditor; }
            set { _CategoryDetailsInHtmlEditor = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryListID--------------
        private string _CategoryListID = "dlCategories";
        public string CategoryListID
        {
            get { return _CategoryListID; }
            set { _CategoryListID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryListHasVisitiesCount--------------
        public bool _CategoryListHasVisitiesCount = false;
        public bool CategoryListHasVisitiesCount { get { return _CategoryListHasVisitiesCount; } set { _CategoryListHasVisitiesCount = value; } }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasItemDate--------------
        private bool _CategoryHasItemDate;
        public bool CategoryHasItemDate
        {
            get { return _CategoryHasItemDate; }
            set { _CategoryHasItemDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasDate_Added--------------
        private bool _CategoryHasDate_Added;
        public bool CategoryHasDate_Added
        {
            get { return _CategoryHasDate_Added; }
            set { _CategoryHasDate_Added = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasVisitsCount--------------
        public bool _CategoryHasVisitsCount = false;
        public bool CategoryHasVisitsCount { get { return _CategoryHasVisitsCount; } set { _CategoryHasVisitsCount = value; } }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasIsMain--------------
        private bool _CategoryHasIsMain;
        public bool CategoryHasIsMain
        {
            get { return _CategoryHasIsMain; }
            set { _CategoryHasIsMain = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasPriority--------------
        private bool _CategoryHasPriority;
        public bool CategoryHasPriority
        {
            get { return _CategoryHasPriority; }
            set { _CategoryHasPriority = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasPhotoExtension--------------
        private bool _CategoryHasPhotoExtension;
        public bool CategoryHasPhotoExtension
        {
            get { return _CategoryHasPhotoExtension; }
            set { _CategoryHasPhotoExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryPhotoAvailableExtension--------------
        private string _CategoryPhotoAvailableExtension = "";
        public string CategoryPhotoAvailableExtension
        {
            get { return _CategoryPhotoAvailableExtension; }
            set { _CategoryPhotoAvailableExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryPhotoMaxSize--------------
        private int _CategoryPhotoMaxSize = -1;
        public int CategoryPhotoMaxSize
        {
            get { return _CategoryPhotoMaxSize; }
            set { _CategoryPhotoMaxSize = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasFileExtension--------------
        private bool _CategoryHasFileExtension;
        public bool CategoryHasFileExtension
        {
            get { return _CategoryHasFileExtension; }
            set { _CategoryHasFileExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryFileAvailableExtension--------------
        private string _CategoryFileAvailableExtension = "";
        public string CategoryFileAvailableExtension
        {
            get { return _CategoryFileAvailableExtension; }
            set { _CategoryFileAvailableExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryFileMaxSize--------------
        private int _CategoryFileMaxSize = -1;
        public int CategoryFileMaxSize
        {
            get { return _CategoryFileMaxSize; }
            set { _CategoryFileMaxSize = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasVideoExtension--------------
        private bool _CategoryHasVideoExtension;
        public bool CategoryHasVideoExtension
        {
            get { return _CategoryHasVideoExtension; }
            set { _CategoryHasVideoExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryVideoAvailableExtension--------------
        private string _CategoryVideoAvailableExtension = "";
        public string CategoryVideoAvailableExtension
        {
            get { return _CategoryVideoAvailableExtension; }
            set { _CategoryVideoAvailableExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryVideoMaxSize--------------
        private int _CategoryVideoMaxSize = -1;
        public int CategoryVideoMaxSize
        {
            get { return _CategoryVideoMaxSize; }
            set { _CategoryVideoMaxSize = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasAudioExtension--------------
        private bool _CategoryHasAudioExtension;
        public bool CategoryHasAudioExtension
        {
            get { return _CategoryHasAudioExtension; }
            set { _CategoryHasAudioExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryAudioAvailableExtension--------------
        private string _CategoryAudioAvailableExtension = "";
        public string CategoryAudioAvailableExtension
        {
            get { return _CategoryAudioAvailableExtension; }
            set { _CategoryAudioAvailableExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryAudioMaxSize--------------
        private int _CategoryAudioMaxSize = -1;
        public int CategoryAudioMaxSize
        {
            get { return _CategoryAudioMaxSize; }
            set { _CategoryAudioMaxSize = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasPhoto2Extension--------------
        private bool _CategoryHasPhoto2Extension;
        public bool CategoryHasPhoto2Extension
        {
            get { return _CategoryHasPhoto2Extension; }
            set { _CategoryHasPhoto2Extension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryPhoto2AvailableExtension--------------
        private string _CategoryPhoto2AvailableExtension = "";
        public string CategoryPhoto2AvailableExtension
        {
            get { return _CategoryPhoto2AvailableExtension; }
            set { _CategoryPhoto2AvailableExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryPhoto2MaxSize--------------
        private int _CategoryPhoto2MaxSize = -1;
        public int CategoryPhoto2MaxSize
        {
            get { return _CategoryPhoto2MaxSize; }
            set { _CategoryPhoto2MaxSize = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasWidth--------------
        private bool _CategoryHasWidth;
        public bool CategoryHasWidth
        {
            get { return _CategoryHasWidth; }
            set { _CategoryHasWidth = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasHeight--------------
        private bool _CategoryHasHeight;
        public bool CategoryHasHeight
        {
            get { return _CategoryHasHeight; }
            set { _CategoryHasHeight = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasYoutubeCode--------------
        private bool _CategoryHasYoutubeCode;
        public bool CategoryHasYoutubeCode
        {
            get { return _CategoryHasYoutubeCode; }
            set { _CategoryHasYoutubeCode = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasGoogleLatitude--------------
        private bool _CategoryHasGoogleLatitude;
        public bool CategoryHasGoogleLatitude
        {
            get { return _CategoryHasGoogleLatitude; }
            set { _CategoryHasGoogleLatitude = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasGoogleLongitude--------------
        private bool _CategoryHasGoogleLongitude;
        public bool CategoryHasGoogleLongitude
        {
            get { return _CategoryHasGoogleLongitude; }
            set { _CategoryHasGoogleLongitude = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasOnlyForRegisered--------------
        private bool _CategoryHasOnlyForRegisered;
        public bool CategoryHasOnlyForRegisered
        {
            get { return _CategoryHasOnlyForRegisered; }
            set { _CategoryHasOnlyForRegisered = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryHasOwnerID--------------
        private bool _CategoryHasOwnerID;
        public bool CategoryHasOwnerID
        {
            get { return _CategoryHasOwnerID; }
            set { _CategoryHasOwnerID = value; }
        }
        #endregion

        //-----------------------------------
        #region --------------CategoryHasPublishPhoto--------------
        private bool _CategoryHasPublishPhoto;
        public bool CategoryHasPublishPhoto
        {
            get { return _CategoryHasPublishPhoto; }
            set { _CategoryHasPublishPhoto = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------CategoryHasPublishPhoto2--------------
        private bool _CategoryHasPublishPhoto2;
        public bool CategoryHasPublishPhoto2
        {
            get { return _CategoryHasPublishPhoto2; }
            set { _CategoryHasPublishPhoto2 = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------CategoryHasPublishFile--------------
        private bool _CategoryHasPublishFile;
        public bool CategoryHasPublishFile
        {
            get { return _CategoryHasPublishFile; }
            set { _CategoryHasPublishFile = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------CategoryHasPublishAudio--------------
        private bool _CategoryHasPublishAudio;
        public bool CategoryHasPublishAudio
        {
            get { return _CategoryHasPublishAudio; }
            set { _CategoryHasPublishAudio = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------CategoryHasPublishVideo--------------
        private bool _CategoryHasPublishVideo;
        public bool CategoryHasPublishVideo
        {
            get { return _CategoryHasPublishVideo; }
            set { _CategoryHasPublishVideo = value; }
        }
        #endregion
        //-----------------------------------
        #region --------------CategoryHasPublishYoutbe--------------
        private bool _CategoryHasPublishYoutbe;
        public bool CategoryHasPublishYoutbe
        {
            get { return _CategoryHasPublishYoutbe; }
            set { _CategoryHasPublishYoutbe = value; }
        }
        #endregion
        //-----------------------------------

        #region --------------CategoryRequiredDetails--------------
        private bool _CategoryRequiredDetails;
        public bool CategoryRequiredDetails
        {
            get { return _CategoryRequiredDetails; }
            set { _CategoryRequiredDetails = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredItemDate--------------
        private bool _CategoryRequiredItemDate;
        public bool CategoryRequiredItemDate
        {
            get { return _CategoryRequiredItemDate; }
            set { _CategoryRequiredItemDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredFile--------------
        private bool _CategoryRequiredFile;
        public bool CategoryRequiredFile
        {
            get { return _CategoryRequiredFile; }
            set { _CategoryRequiredFile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredVideo--------------
        private bool _CategoryRequiredVideo;
        public bool CategoryRequiredVideo
        {
            get { return _CategoryRequiredVideo; }
            set { _CategoryRequiredVideo = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredAudio--------------
        private bool _CategoryRequiredAudio;
        public bool CategoryRequiredAudio
        {
            get { return _CategoryRequiredAudio; }
            set { _CategoryRequiredAudio = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredPhoto2--------------
        private bool _CategoryRequiredPhoto2;
        public bool CategoryRequiredPhoto2
        {
            get { return _CategoryRequiredPhoto2; }
            set { _CategoryRequiredPhoto2 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredYoutubeCode--------------
        private bool _CategoryRequiredYoutubeCode;
        public bool CategoryRequiredYoutubeCode
        {
            get { return _CategoryRequiredYoutubeCode; }
            set { _CategoryRequiredYoutubeCode = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------CategoryRequiredWidth--------------
        private bool _CategoryRequiredWidth;
        public bool CategoryRequiredWidth
        {
            get { return _CategoryRequiredWidth; }
            set { _CategoryRequiredWidth = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredHeight--------------
        private bool _CategoryRequiredHeight;
        public bool CategoryRequiredHeight
        {
            get { return _CategoryRequiredHeight; }
            set { _CategoryRequiredHeight = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredGoogleLatitude--------------
        private bool _CategoryRequiredGoogleLatitude;
        public bool CategoryRequiredGoogleLatitude
        {
            get { return _CategoryRequiredGoogleLatitude; }
            set { _CategoryRequiredGoogleLatitude = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryRequiredGoogleLongitude--------------
        private bool _CategoryRequiredGoogleLongitude;
        public bool CategoryRequiredGoogleLongitude
        {
            get { return _CategoryRequiredGoogleLongitude; }
            set { _CategoryRequiredGoogleLongitude = value; }
        }
        //------------------------------------------
        #endregion

        //------------------------------------------

        #region --------------CategoryPageItemCount_UserDefault--------------
        private int _CategoryPageItemCount_UserDefault = 15;
        public int CategoryPageItemCount_UserDefault
        {
            get { return _CategoryPageItemCount_UserDefault; }
            set { _CategoryPageItemCount_UserDefault = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryPageItemCount_AdminDefault--------------
        private int _CategoryPageItemCount_AdminDefault = 25;
        public int CategoryPageItemCount_AdminDefault
        {
            get { return _CategoryPageItemCount_AdminDefault; }
            set { _CategoryPageItemCount_AdminDefault = value; }
        }
        //------------------------------------------
        #endregion
        //------------------------------------------
        #region --------------CategoryAdminNote--------------
        private string _CategoryAdminNote = "";
        public string CategoryAdminNote
        {
            get { return _CategoryAdminNote; }
            set { _CategoryAdminNote = value; }
        }
        //------------------------------------------
        #endregion
        //------------------------------------------

        #region --------------CategoryPhotoValidationExpression--------------
        public string CategoryGetPhotoValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(CategoryPhotoAvailableExtension);
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryFileValidationExpression--------------
        public string CategoryGetFileValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(CategoryFileAvailableExtension);
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryVideoValidationExpression--------------
        public string CategoryGetVideoValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(CategoryVideoAvailableExtension);
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryAudioValidationExpression--------------
        public string CategoryGetAudioValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(CategoryAudioAvailableExtension);
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryPhoto2ValidationExpression--------------
        public string CategoryGetPhoto2ValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(CategoryPhoto2AvailableExtension);
        }
        //------------------------------------------
        #endregion
        //////////////////////////////////////////////////////////////

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
        private bool _DetailsInHtmlEditor = true;
        public bool DetailsInHtmlEditor
        {
            get { return _DetailsInHtmlEditor; }
            set { _DetailsInHtmlEditor = value; }
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

        #region --------------HasTitle--------------
        private bool _HasTitle;
        public bool HasTitle
        {
            get { return _HasTitle; }
            set { _HasTitle = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasTitleInDetailsPage--------------
        private bool _HasTitleInDetailsPage = true;
        public bool HasTitleInDetailsPage
        {
            get { return _HasTitleInDetailsPage; }
            set { _HasTitleInDetailsPage = value; }
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

        #region --------------HasAddress--------------
        private bool _HasAddress;
        public bool HasAddress
        {
            get { return _HasAddress; }
            set { _HasAddress = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasExtraText_1--------------
        private bool _HasExtraText_1;
        public bool HasExtraText_1
        {
            get { return _HasExtraText_1; }
            set { _HasExtraText_1 = value; }
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

        #region --------------HasTels--------------
        private bool _HasTels;
        public bool HasTels
        {
            get { return _HasTels; }
            set { _HasTels = value; }
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

        #region --------------HasMobile--------------
        private bool _HasMobile;
        public bool HasMobile
        {
            get { return _HasMobile; }
            set { _HasMobile = value; }
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

        #region --------------HasEmail--------------
        private bool _HasEmail;
        public bool HasEmail
        {
            get { return _HasEmail; }
            set { _HasEmail = value; }
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
        #region --------------HasItemEndDate--------------
        private bool _HasItemEndDate;
        public bool HasItemEndDate
        {
            get { return _HasItemEndDate; }
            set { _HasItemEndDate = value; }
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

        #region --------------HasIsAvailable--------------
        private bool _HasIsAvailable;
        public bool HasIsAvailable
        {
            get { return _HasIsAvailable; }
            set { _HasIsAvailable = value; }
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

        #region --------------HasAuthorID--------------
        private bool _HasAuthorID;
        public bool HasAuthorID
        {
            get { return _HasAuthorID; }
            set { _HasAuthorID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasAuthorName--------------
        private bool _HasAuthorName;
        public bool HasAuthorName
        {
            get { return _HasAuthorName; }
            set { _HasAuthorName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ListID--------------
        private string _ListID = "dlItems";
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

        #region --------------HasMultiPhotos--------------
        private bool _HasMultiPhotos;
        public bool HasMultiPhotos
        {
            get { return _HasMultiPhotos; }
            set { _HasMultiPhotos = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasMessages--------------
        private bool _HasMessages;
        public bool HasMessages
        {
            get { return _HasMessages; }
            set { _HasMessages = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MessagesModuleID--------------
        private int _MessagesModuleID = (int)StandardItemsModuleTypes.UnKnowen;
        public int MessagesModuleID
        {
            get { return _MessagesModuleID; }
            set { _MessagesModuleID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------_HasSpecialOption--------------
        private bool _HasSpecialOption;
        public bool HasSpecialOption
        {
            get { return _HasSpecialOption; }
            set { _HasSpecialOption = value; }
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

        #region --------------RequiredShortDescription--------------
        private bool _RequiredShortDescription;
        public bool RequiredShortDescription
        {
            get { return _RequiredShortDescription; }
            set { _RequiredShortDescription = value; }
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

        #region --------------RequiredAuthorName--------------
        private bool _RequiredAuthorName;
        public bool RequiredAuthorName
        {
            get { return _RequiredAuthorName; }
            set { _RequiredAuthorName = value; }
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

        #region --------------RequiredAddress--------------
        private bool _RequiredAddress;
        public bool RequiredAddress
        {
            get { return _RequiredAddress; }
            set { _RequiredAddress = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredExtraText_1--------------
        private bool _RequiredExtraText_1;
        public bool RequiredExtraText_1
        {
            get { return _RequiredExtraText_1; }
            set { _RequiredExtraText_1 = value; }
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

        #region --------------RequiredTels--------------
        private bool _RequiredTels;
        public bool RequiredTels
        {
            get { return _RequiredTels; }
            set { _RequiredTels = value; }
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

        #region --------------RequiredMobile--------------
        private bool _RequiredMobile;
        public bool RequiredMobile
        {
            get { return _RequiredMobile; }
            set { _RequiredMobile = value; }
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

        #region --------------RequiredEmail--------------
        private bool _RequiredEmail;
        public bool RequiredEmail
        {
            get { return _RequiredEmail; }
            set { _RequiredEmail = value; }
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
        #region --------------RequiredItemEndDate--------------
        private bool _RequiredItemEndDate;
        public bool RequiredItemEndDate
        {
            get { return _RequiredItemEndDate; }
            set { _RequiredItemEndDate = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------RequiredPhoto--------------
        private bool _RequiredPhoto;
        public bool RequiredPhoto
        {
            get { return _RequiredPhoto; }
            set { _RequiredPhoto = value; }
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

        #region --------------RequiredYoutubeCode--------------
        private bool _RequiredYoutubeCode;
        public bool RequiredYoutubeCode
        {
            get { return _RequiredYoutubeCode; }
            set { _RequiredYoutubeCode = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------HasShortDescriptionInDetailsPage--------------
        private bool _HasShortDescriptionInDetailsPage;
        public bool HasShortDescriptionInDetailsPage
        {
            get { return _HasShortDescriptionInDetailsPage; }
            set { _HasShortDescriptionInDetailsPage = value; }
        }
        //------------------------------------------
        #endregion

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
        //-----------------------------------

        //-----------------------------------

        //-----------------------------------
        #region --------------AllowDublicateTitlesInItems--------------
        private bool _AllowDublicateTitlesInItems;
        public bool AllowDublicateTitlesInItems
        {
            get { return _AllowDublicateTitlesInItems; }
            set { _AllowDublicateTitlesInItems = value; }
        }
        //------------------------------------------
        #endregion
        //-----------------------------------
        #region --------------AllowDublicateTitlesInCategories--------------
        private bool _AllowDublicateTitlesInCategories;
        public bool AllowDublicateTitlesInCategories
        {
            get { return _AllowDublicateTitlesInCategories; }
            set { _AllowDublicateTitlesInCategories = value; }
        }
        //------------------------------------------
        #endregion
        //-----------------------------------

        #region --------------PhotoValidationExpression--------------
        public string GetPhotoValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(PhotoAvailableExtension);
        }
        //------------------------------------------
        #endregion

        #region --------------FileValidationExpression--------------
        public string GetFileValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(FileAvailableExtension);
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
        //----------------------------------------------------------/
        //Visitors Participations
        //----------------------------------------------------------/

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

        #region --------------RequiredType--------------
        private bool _RequiredType;
        public bool RequiredType
        {
            get { return _RequiredType; }
            set { _RequiredType = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AllowVisitorsParticipations--------------
        private bool _AllowVisitorsParticipations;
        public bool AllowVisitorsParticipations
        {
            get { return _AllowVisitorsParticipations; }
            set { _AllowVisitorsParticipations = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SendingOnlyByUsers--------------
        private bool _SendingOnlyByUsers;
        public bool SendingOnlyByUsers
        {
            get { return _SendingOnlyByUsers; }
            set { _SendingOnlyByUsers = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasSenderName--------------
        private bool _HasSenderName;
        public bool HasSenderName
        {
            get { return _HasSenderName; }
            set { _HasSenderName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredSenderName--------------
        private bool _RequiredSenderName;
        public bool RequiredSenderName
        {
            get { return _RequiredSenderName; }
            set { _RequiredSenderName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasSenderEMail--------------
        private bool _HasSenderEMail;
        public bool HasSenderEMail
        {
            get { return _HasSenderEMail; }
            set { _HasSenderEMail = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredSenderEMail--------------
        private bool _RequiredSenderEMail;
        public bool RequiredSenderEMail
        {
            get { return _RequiredSenderEMail; }
            set { _RequiredSenderEMail = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasSenderCountryID--------------
        private bool _HasSenderCountryID;
        public bool HasSenderCountryID
        {
            get { return _HasSenderCountryID; }
            set { _HasSenderCountryID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredSenderCountryID--------------
        private bool _RequiredSenderCountryID;
        public bool RequiredSenderCountryID
        {
            get { return _RequiredSenderCountryID; }
            set { _RequiredSenderCountryID = value; }
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

        #region --------------HasReply--------------
        private bool _HasReply;
        public bool HasReply
        {
            get { return _HasReply; }
            set { _HasReply = value; }
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

        #region --------------RequiredReply--------------
        private bool _RequiredReply;
        public bool RequiredReply
        {
            get { return _RequiredReply; }
            set { _RequiredReply = value; }
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


        #region --------------HasFontIcon--------------
        private bool _HasFontIcon;
        public bool HasFontIcon
        {
            get { return _HasFontIcon; }
            set { _HasFontIcon = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------RequiredFontIcon--------------
        private bool _RequiredFontIcon;
        public bool RequiredFontIcon
        {
            get { return _RequiredFontIcon; }
            set { _RequiredFontIcon = value; }
        }
        //------------------------------------------
        #endregion
        //----------------------------------------------------------/
        public ItemsModulesOptions()
        {
            ModuleBaseType = ModuleBaseTypes.Items;
            ModuleType = ModuleTypes.Artical;
            ResourceFile = "Items";
            DefaultResourceFile = "Items";

        }
        //----------------------------------------------------------/
        public static ItemsModulesOptions GetType(int moduleType)
        {

            return SiteModulesManager.Instance.GetItemsModule(moduleType);
        }
        //----------------------------------------------------------/
        public static ItemsModulesOptions GetType(string moduleIdentifire)
        {

            return SiteModulesManager.Instance.GetItemsModule(moduleIdentifire);
        }
    }








}