using System;
using DCCMSNameSpace;
using System.Web;

namespace DCCMSNameSpace
{
    public class UsersDataGlobalOptions : MasterModule
    {
        

        
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

        #region --------------HasCountryID--------------
        private bool _HasCountryID;
        public bool HasCountryID
        {
            get { return _HasCountryID; }
            set { _HasCountryID = value; }
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

        #region --------------HasMobile--------------
        private bool _HasMobile;
        public bool HasMobile
        {
            get { return _HasMobile; }
            set { _HasMobile = value; }
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

        #region --------------HasUserId--------------
        private bool _HasUserId;
        public bool HasUserId
        {
            get { return _HasUserId; }
            set { _HasUserId = value; }
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
        private int _PhotoMaxSize;
        public int PhotoMaxSize
        {
            get { return _PhotoMaxSize; }
            set { _PhotoMaxSize = value; }
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

        #region --------------AutomaticApproved--------------
        private bool _AutomaticApproved;
        public bool AutomaticApproved
        {
            get { return _AutomaticApproved; }
            set { _AutomaticApproved = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ExtraDataCount--------------
        private int _ExtraDataCount;
        public int ExtraDataCount
        {
            get { return _ExtraDataCount; }
            set { _ExtraDataCount = value; }
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

        #region --------------RequiredCountryID--------------
        private bool _RequiredCountryID;
        public bool RequiredCountryID
        {
            get { return _RequiredCountryID; }
            set { _RequiredCountryID = value; }
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

        #region --------------RequiredName--------------
        private bool _RequiredName;
        public bool RequiredName
        {
            get { return _RequiredName; }
            set { _RequiredName = value; }
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

        #region --------------RequiredMobile--------------
        private bool _RequiredMobile;
        public bool RequiredMobile
        {
            get { return _RequiredMobile; }
            set { _RequiredMobile = value; }
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

        #region --------------RequiredExtraData1--------------
        private bool _RequiredExtraData1;
        public bool RequiredExtraData1
        {
            get { return _RequiredExtraData1; }
            set { _RequiredExtraData1 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredExtraData2--------------
        private bool _RequiredExtraData2;
        public bool RequiredExtraData2
        {
            get { return _RequiredExtraData2; }
            set { _RequiredExtraData2 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredExtraData3--------------
        private bool _RequiredExtraData3;
        public bool RequiredExtraData3
        {
            get { return _RequiredExtraData3; }
            set { _RequiredExtraData3 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredExtraData4--------------
        private bool _RequiredExtraData4;
        public bool RequiredExtraData4
        {
            get { return _RequiredExtraData4; }
            set { _RequiredExtraData4 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredExtraData5--------------
        private bool _RequiredExtraData5;
        public bool RequiredExtraData5
        {
            get { return _RequiredExtraData5; }
            set { _RequiredExtraData5 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredExtraData6--------------
        private bool _RequiredExtraData6;
        public bool RequiredExtraData6
        {
            get { return _RequiredExtraData6; }
            set { _RequiredExtraData6 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------UserRole--------------
        private string _UserRole = "";
        public string UserRole
        {
            get { return _UserRole; }
            set { _UserRole = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasAddUserInAdmin--------------
        private bool _HasAddUserInAdmin;
        public bool HasAddUserInAdmin
        {
            get { return _HasAddUserInAdmin; }
            set { _HasAddUserInAdmin = value; }
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

        #region --------------SendingAcountDataInActivationMail--------------
        private bool _SendingAcountDataInActivationMail;
        public bool SendingAcountDataInActivationMail
        {
            get { return _SendingAcountDataInActivationMail; }
            set { _SendingAcountDataInActivationMail = value; }
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
        
        #region --------------CanUserAssignHimSelfToCategory--------------
        private bool _CanUserAssignHimSelfToCategory;
        public bool CanUserAssignHimSelfToCategory
        {
            get { return _CanUserAssignHimSelfToCategory; }
            set { _CanUserAssignHimSelfToCategory = value; }
        }
        //------------------------------------------
        #endregion

        //------------------------------------------------------
        #region --------------HasNationalityID--------------
        private bool _HasNationalityID;
        public bool HasNationalityID
        {
            get { return _HasNationalityID; }
            set { _HasNationalityID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequiredNationalityID--------------
        private bool _RequiredNationalityID;
        public bool RequiredNationalityID
        {
            get { return _RequiredNationalityID; }
            set { _RequiredNationalityID = value; }
        }
        //------------------------------------------
        #endregion
        
        #region --------------HasProfilePage--------------
        private bool _HasProfilePage;
        public bool HasProfilePage
        {
            get { return _HasProfilePage; }
            set { _HasProfilePage = value; }
        }
        #endregion
        //-----------------------------------

        #region --------------TableRowsPriorities--------------
        private string _TableRowsPriorities = "";
        public string TableRowsPriorities
        {
            get { return _TableRowsPriorities; }
            set { _TableRowsPriorities = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------PhotoValidationExpression--------------
        public string GetPhotoValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(PhotoAvailableExtension);
        }
        //------------------------------------------
        #endregion

        //----------------------------------------------------------/
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
        #region --------------ListID--------------
        private string _ListID = "dlUsers";
        public string ListID
        {
            get { return _ListID; }
            set { _ListID = value; }
        }
        //------------------------------------------
        #endregion
        //----------------------------------------------------------/
        #region --------------HasIsConsultant--------------
        private bool _HasIsConsultant;
        public bool HasIsConsultant
        {
            get { return _HasIsConsultant; }
            set { _HasIsConsultant = value; }
        }
        //------------------------------------------
        #endregion
        //----------------------------------------------------------/


        #region --------------UserType--------------
        private UsersTypes _UserType = UsersTypes.User;
        public UsersTypes UserType
        {
            get { return _UserType; }
            set { _UserType = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------HasSiteTitle--------------
        private bool _HasSiteTitle ;
        public bool HasSiteTitle
        {
            get { return _HasSiteTitle; }
            set { _HasSiteTitle = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasSkinID--------------
        private bool _HasSkinID ;
        public bool HasSkinID
        {
            get { return _HasSkinID; }
            set { _HasSkinID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasVisitorsCount--------------
        private bool _HasVisitorsCount;
        public bool HasVisitorsCount
        {
            get { return _HasVisitorsCount; }
            set { _HasVisitorsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasSiteModules--------------
        private bool _HasSiteModules;
        public bool HasSiteModules
        {
            get { return _HasSiteModules; }
            set { _HasSiteModules = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasSiteStaticPages--------------
        private bool _HasSiteStaticPages;
        public bool HasSiteStaticPages
        {
            get { return _HasSiteStaticPages; }
            set { _HasSiteStaticPages = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasProfile--------------
        private bool _HasProfile;
        public bool HasProfile
        {
            get { return _HasProfile; }
            set { _HasProfile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SubSiteType--------------
        private SubSiteTypes _SubSiteType= SubSiteTypes.None;
        public SubSiteTypes SubSiteType
        {
            get { return _SubSiteType; }
            set { _SubSiteType = value; }
        }
        //------------------------------------------
        #endregion
        

        //----------------------------------------------------------/
        public UsersDataGlobalOptions()
        {
            ModuleBaseType = ModuleBaseTypes.UsersData;
            ModuleType = ModuleTypes.UserRegitration;
            ResourceFile = "UsersData";
            DefaultResourceFile = "UsersData";

        }
        //----------------------------------------------------------/
        public static UsersDataGlobalOptions GetType(int moduleType)
        {
            return SiteModulesManager.Instance.GetUserDataModule(moduleType);
        }
        //----------------------------------------------------------/

    }
}

