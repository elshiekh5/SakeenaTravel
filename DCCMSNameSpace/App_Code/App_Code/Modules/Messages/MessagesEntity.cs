using System;
using DCCMSNameSpace;
using System.Collections.Generic;


namespace DCCMSNameSpace
{
    public class MessagesEntity
    {

        #region --------------MessageID--------------
        private int _MessageID;
        public int MessageID
        {
            get { return _MessageID; }
            set { _MessageID = value; }
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

        #region --------------Mobile--------------
        private string _Mobile = "";
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------EMail--------------
        private string _EMail = "";
        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
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

        #region --------------NationalityID--------------
        private int _NationalityID;
        public int NationalityID
        {
            get { return _NationalityID; }
            set { _NationalityID = value; }
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

        #region --------------Address--------------
        private string _Address = "";
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------JobTel--------------
        private string _JobTel = "";
        public string JobTel
        {
            get { return _JobTel; }
            set { _JobTel = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------UserId--------------
        private Guid _UserId = Guid.Empty;
        public Guid UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ToItemID--------------
        private int _ToItemID;
        public int ToItemID
        {
            get { return _ToItemID; }
            set { _ToItemID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Type--------------
        private int _Type;
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Title--------------
        private string _Title = "";
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ShortDescription--------------
        private string _ShortDescription = "";
        public string ShortDescription
        {
            get { return _ShortDescription; }
            set { _ShortDescription = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Details--------------
        private string _Details = "";
        public string Details
        {
            get { return _Details; }
            set { _Details = value; }
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

        #region --------------Reply--------------
        private string _Reply = "";
        public string Reply
        {
            get { return _Reply; }
            set { _Reply = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ReplyDate--------------
        private DateTime _ReplyDate = DateTime.MinValue;
        public DateTime ReplyDate
        {
            get { return _ReplyDate; }
            set { _ReplyDate = value; }
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

        #region --------------IsAvailable--------------
        private bool _IsAvailable;
        public bool IsAvailable
        {
            get { return _IsAvailable; }
            set { _IsAvailable = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------IsSeen--------------
        private bool _IsSeen;
        public bool IsSeen
        {
            get { return _IsSeen; }
            set { _IsSeen = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------IsReplied--------------
        private bool _IsReplied;
        public bool IsReplied
        {
            get { return _IsReplied; }
            set { _IsReplied = value; }
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

        #region --------------LangID--------------
        private Languages _LangID;
        public Languages LangID
        {
            get { return _LangID; }
            set { _LangID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ToUserID--------------
        private Guid _ToUserID = Guid.Empty;
        public Guid ToUserID
        {
            get { return _ToUserID; }
            set { _ToUserID = value; }
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

        #region --------------Tel--------------
        private string _Tel = "";
        public string Tel
        {
            get { return _Tel; }
            set { _Tel = value; }
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
                    return MessagesFactory.CreatePhotoName(_MessageID) + _PhotoExtension;
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
        private List<string> _ExtraData;
        public List<string> ExtraData
        {
            get
            {
                if (_ExtraData == null) _ExtraData = new List<string>();
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

        #region --------------AgeRang--------------
        private int _AgeRang;
        public int AgeRang
        {
            get { return _AgeRang; }
            set { _AgeRang = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------FileExtension--------------
        private string _FileExtension = "";
        public string FileExtension
        {
            get { return _FileExtension; }
            set { _FileExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------File--------------
        public string File
        {
            get
            {
                if (_FileExtension.Length > 0)
                {
                    return MessagesFactory.CreateFileName(_MessageID) + _FileExtension;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetType--------------
        public string GetType(string extension)
        {
            if (extension.Length > 0)
                return extension.Remove(0, 1);
            else
                return "";
        }
        //------------------------------------------
        #endregion

        //------------------------------------------//
        public string PhotoType
        {
            get { return GetType(_PhotoExtension); }
        }
        //------------------------------------------//
        public string FileType
        {
            get { return GetType(_FileExtension); }
        }
        //------------------------------------------//

        #region --------------Vistites_Count--------------
        private int _Vistites_Count;
        public int Vistites_Count
        {
            get { return _Vistites_Count; }
            set { _Vistites_Count = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------IsMain--------------
        private bool _IsMain;
        public bool IsMain
        {
            get { return _IsMain; }
            set { _IsMain = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------VideoExtension--------------
        private string _VideoExtension = "";
        public string VideoExtension
        {
            get { return _VideoExtension; }
            set { _VideoExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Video--------------
        public string Video
        {
            get
            {
                if (_VideoExtension.Length > 0)
                {
                    return MessagesFactory.CreateFileName(_MessageID) + _VideoExtension;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion

        #region --------------AudioExtension--------------
        private string _AudioExtension = "";
        public string AudioExtension
        {
            get { return _AudioExtension; }
            set { _AudioExtension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Audio--------------
        public string Audio
        {
            get
            {
                if (_AudioExtension.Length > 0)
                {
                    return MessagesFactory.CreateFileName(_MessageID) + _AudioExtension;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Priority--------------
        private int _Priority;
        public int Priority
        {
            get { return _Priority; }
            set { _Priority = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Photo2Extension--------------
        private string _Photo2Extension = "";
        public string Photo2Extension
        {
            get { return _Photo2Extension; }
            set { _Photo2Extension = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Photo2--------------
        public string Photo2
        {
            get
            {
                if (_Photo2Extension.Length > 0)
                {
                    return MessagesFactory.CreateFileName(_MessageID) + _Photo2Extension;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Height--------------
        private int _Height;
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Width--------------
        private int _Width;
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ItemDate--------------
        private DateTime _ItemDate = DateTime.MinValue;
        public DateTime ItemDate
        {
            get { return _ItemDate; }
            set { _ItemDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ItemDateString--------------
        public string ItemDateString
        {
            get
            {
                if (_ItemDate == DateTime.MinValue)
                    return "";
                else return _ItemDate.ToString("dd/MM/yyyy");
            }
        }
        //------------------------------------------
        #endregion


        #region --------------InsertUserName--------------
        private string _InsertUserName = "";
        public string InsertUserName
        {
            get { return _InsertUserName; }
            set { _InsertUserName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastUpdateUserName--------------
        private string _LastUpdateUserName = "";
        public string LastUpdateUserName
        {
            get { return _LastUpdateUserName; }
            set { _LastUpdateUserName = value; }
        }
        //------------------------------------------
        #endregion



        #region --------------YoutubeCode--------------
        private string _YoutubeCode = "";
        public string YoutubeCode
        {
            get { return _YoutubeCode; }
            set { _YoutubeCode = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RatingCount--------------
        private int _RatingCount;
        public int RatingCount
        {
            get { return _RatingCount; }
            set { _RatingCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RatingValue--------------
        private int _RatingValue;
        public int RatingValue
        {
            get { return _RatingValue; }
            set { _RatingValue = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------RatingAverage--------------
        public int RatingAverage
        {
            get
            {
                int avr = 1;
                if (RatingCount > 0)
                    avr = RatingValue / RatingCount;
                if (avr == 0) avr = 1;
                return avr;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------ActiveComments--------------
        private int _ActiveComments;
        public int ActiveComments
        {
            get { return _ActiveComments; }
            set { _ActiveComments = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------InactiveComments--------------
        private int _InactiveComments;
        public int InactiveComments
        {
            get { return _InactiveComments; }
            set { _InactiveComments = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------TotalComments--------------

        public int TotalComments
        {
            get { return _ActiveComments + _InactiveComments; }

        }
        //------------------------------------------
        #endregion


        #region --------------GoogleLatitude--------------
        private string _GoogleLatitude = "";
        public string GoogleLatitude
        {
            get { return _GoogleLatitude; }
            set { _GoogleLatitude = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------GoogleLongitude--------------
        private string _GoogleLongitude = "";
        public string GoogleLongitude
        {
            get { return _GoogleLongitude; }
            set { _GoogleLongitude = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Price--------------
        private string _Price = "";
        public string Price
        {
            get { return _Price; }
            set { _Price = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------OnlyForRegisered--------------
        private bool _OnlyForRegisered = false;
        public bool OnlyForRegisered
        {
            get { return _OnlyForRegisered; }
            set { _OnlyForRegisered = value; }
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

        #region --------------PublishPhoto--------------
        private bool _PublishPhoto;
        public bool PublishPhoto
        {
            get { return _PublishPhoto; }
            set { _PublishPhoto = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------PublishPhoto2--------------
        private bool _PublishPhoto2;
        public bool PublishPhoto2
        {
            get { return _PublishPhoto2; }
            set { _PublishPhoto2 = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------PublishFile--------------
        private bool _PublishFile;
        public bool PublishFile
        {
            get { return _PublishFile; }
            set { _PublishFile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------PublishAudio--------------
        private bool _PublishAudio;
        public bool PublishAudio
        {
            get { return _PublishAudio; }
            set { _PublishAudio = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------PublishVideo--------------
        private bool _PublishVideo;
        public bool PublishVideo
        {
            get { return _PublishVideo; }
            set { _PublishVideo = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------PublishYoutbe--------------
        private bool _PublishYoutbe;
        public bool PublishYoutbe
        {
            get { return _PublishYoutbe; }
            set { _PublishYoutbe = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------KeyWords--------------
        private string _KeyWords = "";
        public string KeyWords
        {
            get { return _KeyWords; }
            set { _KeyWords = value; }
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


        #region --------------OwnerName--------------
        private string _OwnerName = SitesHandler.GetOwnerIdentifire();
        public string OwnerName
        {
            get { return _OwnerName; }
            set { _OwnerName = value; }
        }
        //------------------------------------------
        #endregion

    }

}