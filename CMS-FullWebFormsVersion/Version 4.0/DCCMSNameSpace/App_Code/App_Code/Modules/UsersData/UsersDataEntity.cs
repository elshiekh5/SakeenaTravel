using System;
using System.Collections.Generic;
using DCCMSNameSpace;


namespace DCCMSNameSpace
{
    public class UsersDataEntity
    {
        #region --------------UserName--------------
        private string _UserName = "";
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Password--------------
        private string _Password = "";
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Email--------------
        private string _Email = "";
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------UserProfileID--------------
        private int _UserProfileID;
        public int UserProfileID
        {
            get { return _UserProfileID; }
            set { _UserProfileID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------UserId--------------
        private Guid _UserId = Guid.NewGuid();
        public Guid UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Name--------------
        private string _Name = "";
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------EmpNo--------------
        private int _EmpNo;
        public int EmpNo
        {
            get { return _EmpNo; }
            set { _EmpNo = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Gender--------------
        private Gender _Gender;
        public Gender Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------BirthDate--------------
        private string _BirthDate = "";
        public string BirthDate
        {
            get { return _BirthDate; }
            set { _BirthDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SocialStatus--------------
        private int _SocialStatus;
        public int SocialStatus
        {
            get { return _SocialStatus; }
            set { _SocialStatus = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------EducationLevel--------------
        private int _EducationLevel;
        public int EducationLevel
        {
            get { return _EducationLevel; }
            set { _EducationLevel = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CountryID--------------
        private int _CountryID;
        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CityID--------------
        private int _CityID;
        public int CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------UserCityName--------------
        private string _UserCityName = "";
        public string UserCityName
        {
            get { return _UserCityName; }
            set { _UserCityName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Tel--------------
        private string _Tel = "";
        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Mobile--------------
        private string _Mobile = "";
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasSmsService--------------
        private bool _HasSmsService;
        public bool HasSmsService
        {
            get { return _HasSmsService; }
            set { _HasSmsService = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasEmailService--------------
        private bool _HasEmailService;
        public bool HasEmailService
        {
            get { return _HasEmailService; }
            set { _HasEmailService = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Fax--------------
        private string _Fax = "";
        public string Fax
        {
            get { return _Fax; }
            set { _Fax = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MailBox--------------
        private string _MailBox = "";
        public string MailBox
        {
            get { return _MailBox; }
            set { _MailBox = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ZipCode--------------
        private string _ZipCode = "";
        public string ZipCode
        {
            get { return _ZipCode; }
            set { _ZipCode = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------JobID--------------
        private int _JobID;
        public int JobID
        {
            get { return _JobID; }
            set { _JobID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------JobText--------------
        private string _JobText = "";
        public string JobText
        {
            get { return _JobText; }
            set { _JobText = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Url--------------
        private string _Url = "";
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------PhotoExtension--------------
        private string _PhotoExtension = "";
        public string PhotoExtension
        {
            get { return _PhotoExtension; }
            set { _PhotoExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Photo--------------
        public string Photo
        {
            get
            {
                if (_PhotoExtension.Length > 0)
                {
                    return UsersDataFactory.CreateUserPhotoName(_UserProfileID) + _PhotoExtension;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion


        #region --------------Company--------------
        private string _Company = "";
        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ActivitiesID--------------
        private int _ActivitiesID;
        public int ActivitiesID
        {
            get { return _ActivitiesID; }
            set { _ActivitiesID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ExtraData--------------
        private string _ExtraData;
        public string ExtraData
        {
            get
            {
                return _ExtraData;
            }
            set { _ExtraData = value; }
        }
        //------------------------------------------
        #endregion;

        #region --------------Notes1--------------
        private string _Notes1 = "";
        public string Notes1
        {
            get { return _Notes1; }
            set { _Notes1 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Notes2--------------
        private string _Notes2 = "";
        public string Notes2
        {
            get { return _Notes2; }
            set { _Notes2 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CityName--------------
        private string _CityName = "";
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CountryName--------------
        private string _CountryName = "";
        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------IsApproved--------------
        private bool _IsApproved = false;
        public bool IsApproved
        {
            get
            {
                return _IsApproved;
            }
            set
            {
                _IsApproved = value;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------AgeRang--------------
        private int _AgeRang;
        public int AgeRang
        {
            get { return _AgeRang; }
            set { _AgeRang = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ModuleTypeID--------------
        private int _ModuleTypeID;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LangID--------------
        private Languages _LangID;
        public Languages LangID
        {
            get { return _LangID; }
            set { _LangID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryID--------------
        private int _CategoryID;
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------City--------------

        public string City
        {
            get
            {
                if (!string.IsNullOrEmpty(CityName))
                    return CityName;
                else
                    return UserCityName;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------OwnerID--------------
        private Guid _OwnerID=Guid.Empty;
        public Guid OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ProfilePageID--------------
        private int _ProfilePageID;
        public int ProfilePageID
        {
            get { return _ProfilePageID; }
            set { _ProfilePageID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Date_Added--------------
        private DateTime _Date_Added = DateTime.MinValue;
        public DateTime Date_Added
        {
            get { return _Date_Added; }
            set { _Date_Added = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastModification--------------
        private DateTime _LastModification = DateTime.MinValue;
        public DateTime LastModification
        {
            get { return _LastModification; }
            set { _LastModification = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MessagesTotalCount--------------
        private int _MessagesTotalCount;
        public int MessagesTotalCount
        {
            get { return _MessagesTotalCount; }
            set { _MessagesTotalCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MessagesNewCount--------------
        private int _MessagesNewCount;
        public int MessagesNewCount
        {
            get { return _MessagesNewCount; }
            set { _MessagesNewCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------KeyWordsAr--------------
        private string _KeyWordsAr = "";
        public string KeyWordsAr
        {
            get { return _KeyWordsAr; }
            set { _KeyWordsAr = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ShortDescriptionAr--------------
        private string _ShortDescriptionAr = "";
        public string ShortDescriptionAr
        {
            get { return _ShortDescriptionAr; }
            set { _ShortDescriptionAr = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------KeyWordsEn--------------
        private string _KeyWordsEn = "";
        public string KeyWordsEn
        {
            get { return _KeyWordsEn; }
            set { _KeyWordsEn = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ShortDescriptionEn--------------
        private string _ShortDescriptionEn = "";
        public string ShortDescriptionEn
        {
            get { return _ShortDescriptionEn; }
            set { _ShortDescriptionEn = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SiteTitleAr--------------
        private string _SiteTitleAr = "";
        public string SiteTitleAr
        {
            get { return _SiteTitleAr; }
            set { _SiteTitleAr = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SiteTitleEn--------------
        private string _SiteTitleEn = "";
        public string SiteTitleEn
        {
            get { return _SiteTitleEn; }
            set { _SiteTitleEn = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SkinID--------------
        private string _SkinID = "";
        public string SkinID
        {
            get { return _SkinID; }
            set { _SkinID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------VisitorsCount--------------
        private int _VisitorsCount;
        public int VisitorsCount
        {
            get { return _VisitorsCount; }
            set { _VisitorsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------UserType--------------
        private UsersTypes _UserType= UsersTypes.User;
        public UsersTypes UserType
        {
            get { return _UserType; }
            set { _UserType = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SiteModulesManager--------------
        private string _SiteModules = "";
        public string SiteModulesManager
        {
            get { return _SiteModules; }
            set { _SiteModules = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SiteStaticPages--------------
        private string _SiteStaticPages = "";
        public string SiteStaticPages
        {
            get { return _SiteStaticPages; }
            set { _SiteStaticPages = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SubSiteType--------------
        private SubSiteTypes _SubSiteType = SubSiteTypes.None;
        public SubSiteTypes SubSiteType
        {
            get { return _SubSiteType; }
            set { _SubSiteType = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------OwnerName--------------
        private string _OwnerName = "";
        public string OwnerName
        {
            get { return _OwnerName; }
            set { _OwnerName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Profile--------------
        private UsersDataProfile _Profile = new UsersDataProfile();
        public UsersDataProfile Profile
        {
            get { return _Profile; }
            set { _Profile = value; }
        }
        //------------------------------------------
        #endregion
    }

}