using System;
using System.Collections;
using System.Collections.Generic;
using DCCMSNameSpace;
namespace DCCMSNameSpace
{
    public class ItemsEntity 
    {

        #region --------------ItemID--------------

        private int _ItemID;
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
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
                    return ItemsFactory.CreateItemsPhotoName(_ItemID) + _PhotoExtension;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion

        #region --------------MicroPhotoThumbs--------------
        public string MicroPhotoThumbs
        {
            get
            {
                if (_PhotoExtension.Length > 0)
                {
                    return ItemsFactory.CreateItemsPhotoName(_ItemID) + MoversFW.Thumbs.thumbnailExetnsion;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion

        #region --------------MiniPhotoThumbs--------------
        public string MiniPhotoThumbs
        {
            get
            {
                if (_PhotoExtension.Length > 0)
                {
                    return ItemsFactory.CreateItemsPhotoName(_ItemID) + MoversFW.Thumbs.thumbnailExetnsion;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion

        #region --------------NormalPhotoThumbs--------------
        public string NormalPhotoThumbs
        {
            get
            {
                if (_PhotoExtension.Length > 0)
                {
                    return ItemsFactory.CreateItemsPhotoName(_ItemID) + MoversFW.Thumbs.thumbnailExetnsion;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion

        #region --------------BigPhotoThumbs--------------
        public string BigPhotoThumbs
        {
            get
            {
                if (_PhotoExtension.Length > 0)
                {
                    return ItemsFactory.CreateItemsPhotoName(_ItemID) + MoversFW.Thumbs.thumbnailExetnsion;
                }
                else
                {
                    return "";
                }
            }
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
                    return ItemsFactory.CreateItemsFileName(_ItemID) + _FileExtension;
                }
                else
                {
                    return "";
                }
            }
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

        #region --------------Url--------------
        public bool HasUrl
        {
            get { return (!string.IsNullOrEmpty(Url)); }
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

        #region --------------Vistites_Count--------------
        private int _Vistites_Count;
        public int Vistites_Count
        {
            get { return _Vistites_Count; }
            set { _Vistites_Count = value; }
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

        #region --------------ModuleTypeID--------------
        private int _ModuleTypeID;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryTitle--------------
        private string _CategoryTitle = "";
        public string CategoryTitle
        {
            get { return _CategoryTitle; }
            set { _CategoryTitle = value; }
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
                    return ItemsFactory.CreateItemsFileName(_ItemID) + _VideoExtension;
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
                    return ItemsFactory.CreateItemsFileName(_ItemID) + _AudioExtension;
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
                    return ItemsFactory.CreateItemsFileName(_ItemID) + _Photo2Extension;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion
        #region --------------Photo2Path--------------
        public string Photo2Path
        {
            get
            {

                if (_Photo2Extension.Length > 0)
                {
                    return "/Content/UpFiles/_Site/ItemCategories/"+CategoryID+"/Items/"+ItemID+"/Files/"+Photo2;
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

        #region --------------ItemEndDate--------------
        private DateTime _ItemEndDate = DateTime.MinValue;
        public DateTime ItemEndDate
        {
            get { return _ItemEndDate; }
            set { _ItemEndDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ItemEndDateString--------------
        public string ItemEndDateString
        {
            get
            {
                if (_ItemEndDate == DateTime.MinValue)
                    return "";
                else return _ItemEndDate.ToString("dd/MM/yyyy");
            }
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

        #region --------------Tels--------------
        private string _Tels = "";
        public string Tels
        {
            get { return _Tels; }
            set { _Tels = value; }
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

        #region --------------Mobile--------------
        private string _Mobile = "";
        public string Mobile
        {
            get { return _Mobile; }
            set { _Mobile = value; }
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

        #region --------------AuthorID--------------

        private int _AuthorID;
        public int AuthorID
        {
            get { return _AuthorID; }
            set { _AuthorID = value; }
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

        public string PhotoType
        {
            get { return GetType(_PhotoExtension); }
        }

        public string FileType
        {
            get { return GetType(_FileExtension); }
        }
        public string AudioType
        {
            get { return GetType(_AudioExtension); }
        }
        public string VideoType
        {
            get { return GetType(_VideoExtension); }
        }






        #region --------------GoogleLatitude--------------
        private double _GoogleLatitude = 0.0;
        public double GoogleLatitude
        {
            get { return _GoogleLatitude; }
            set { _GoogleLatitude = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------GoogleLongitude--------------
        private double _GoogleLongitude = 0.0;
        public double GoogleLongitude
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

        #region ---------------Details---------------

        public string GetTitle(Languages lang)
        {
            if (Details[lang] != null)
            {
                return ((ItemsDetailsEntity)Details[lang]).Title;
            }
            else
                return "";
        }
        //------------------------------------------
        private Hashtable _Details = new Hashtable();
        public Hashtable Details
        {
            get { return _Details; }
            set { _Details = value; }
        }
        //---------------------------------------------
        private List<ItemsDetailsEntity> _DetailsList;//= new List<ItemsDetailsEntity>();
        public List<ItemsDetailsEntity> DetailsList
        {
            get { return _DetailsList; }
            set { _DetailsList = value; }
        }
        //---------------------------------------------
        public bool HasLanguage(Languages lang)
        {
            if (Details[lang] != null)
            {
                return true;
            }
            else
                return false;
        }

        public string ItemTitle
        {
            get
            {
                Languages lang = SiteSettings.GetCurrentLanguage();

                if ((ItemsDetailsEntity)Details[lang] != null)
                {
                    return ((ItemsDetailsEntity)Details[lang]).Title;
                }
                else
                    return "";
            }

        }
        public string ItemShortDescription
        {
            get
            {
                Languages lang = SiteSettings.GetCurrentLanguage();
                if ((ItemsDetailsEntity)Details[lang] != null)
                {
                    return ((ItemsDetailsEntity)Details[lang]).ShortDescription;
                }
                else
                    return "";
            }

        }
        public string ItemKeyWords
        {
            get
            {
                Languages lang = SiteSettings.GetCurrentLanguage();
                if ((ItemsDetailsEntity)Details[lang] != null)
                {
                    return ((ItemsDetailsEntity)Details[lang]).KeyWords;
                }
                else
                    return "";
            }

        }

        #region --------------LangID--------------
        private Languages _LangID;
        public Languages LangID
        {
            get { return _LangID; }
            set { _LangID = value; }
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
        #region --------------Description--------------
        private string _Description = "";
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AuthorName--------------
        private string _AuthorName = "";
        public string AuthorName
        {
            get { return _AuthorName; }
            set { _AuthorName = value; }
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
        #region --------------ExtraData--------------
        private List<string> _ExtraData;
        public List<string> ExtraData
        {
            get
            {
                if (_ExtraData == null)
                    _ExtraData = new List<string>();
                return _ExtraData;
            }
            set { _ExtraData = value; }
        }
        //------------------------------------------
        #endregion;

        #region --------------ExtraText_1--------------
        public string ExtraText_1
        {
            get
            {
                if (_ExtraData != null)
                    return _ExtraData[0];
                else
                    return "";
            }
        }
        //------------------------------------------
        #endregion;

        #region --------------KeyWords--------------
        private string _KeyWords = "";
        public string KeyWords
        {
            get { return _KeyWords; }
            set { _KeyWords = value; }
        }
        //------------------------------------------
        #endregion

        #endregion


        #region --------------IsVisitorsParticipations--------------
        private bool _IsVisitorsParticipations;
        public bool IsVisitorsParticipations
        {
            get { return _IsVisitorsParticipations; }
            set { _IsVisitorsParticipations = value; }
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

        #region --------------SenderName--------------
        private string _SenderName = "";
        public string SenderName
        {
            get { return _SenderName; }
            set { _SenderName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SenderEMail--------------
        private string _SenderEMail = "";
        public string SenderEMail
        {
            get { return _SenderEMail; }
            set { _SenderEMail = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------SenderCountryID--------------
        private int _SenderCountryID;
        public int SenderCountryID
        {
            get { return _SenderCountryID; }
            set { _SenderCountryID = value; }
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

        #region --------------IsSeen--------------
        private bool _IsSeen;
        public bool IsSeen
        {
            get { return _IsSeen; }
            set { _IsSeen = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------IsReviewed--------------
        private bool _IsReviewed;
        public bool IsReviewed
        {
            get { return _IsReviewed; }
            set { _IsReviewed = value; }
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

        #region --------------ToUserID--------------
        private Guid _ToUserID = Guid.Empty;
        public Guid ToUserID
        {
            get { return _ToUserID; }
            set { _ToUserID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ActivatedBy--------------
        private string _ActivatedBy = "";
        public string ActivatedBy
        {
            get { return _ActivatedBy; }
            set { _ActivatedBy = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ReviewedBy--------------
        private string _ReviewedBy = "";
        public string ReviewedBy
        {
            get { return _ReviewedBy; }
            set { _ReviewedBy = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------PhotoPath--------------

        public string PhotoPathThumb
        {
            get { return GetPhotoPath(PhotoTypes.Thumb); }
        }
        //------------------------------------------
        public string PhotoPathOriginal
        {
            get { return GetPhotoPath(PhotoTypes.Original); }
        }
        //------------------------------------------
        public string PhotoPathBig
        {
            get { return GetPhotoPath(PhotoTypes.Big); }
        }
        //------------------------------------------
        #endregion
        #region---------------IPhotoable--------------
        public string GetPhotoPath(PhotoTypes photo)
        {
            if (((string)_PhotoExtension).Length > 0)
            {
                string photoName = ItemsFactory.CreateItemsPhotoName(_ItemID);
                string photoPath = DCSiteUrls.GetPath_ItemsPhotoNormalThumbs (OwnerName,ModuleTypeID,CategoryID,ItemID) + photoName;
                switch (photo)
                {
                    case PhotoTypes.Original:
                        photoPath = DCSiteUrls.GetPath_ItemsPhotoOriginals (OwnerName,ModuleTypeID,CategoryID,ItemID) + Photo;
                        break;
                    case PhotoTypes.Thumb:
                        photoPath = DCSiteUrls.GetPath_ItemsPhotoNormalThumbs (OwnerName,ModuleTypeID,CategoryID,ItemID) + photoName + MoversFW.Thumbs.thumbnailExetnsion;
                        break;
                    case PhotoTypes.Big:
                        photoPath = DCSiteUrls.GetPath_ItemsPhotoBigThumbs (OwnerName,ModuleTypeID,CategoryID,ItemID) + photoName + MoversFW.Thumbs.thumbnailExetnsion;
                        break;
                    default:
                        photoPath = DCSiteUrls.GetPath_ItemsPhotoNormalThumbs (OwnerName,ModuleTypeID,CategoryID,ItemID) + photoName + MoversFW.Thumbs.thumbnailExetnsion;
                        break;
                }

                return photoPath;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        #endregion

        #region --------------SpecialOption--------------
        private bool _SpecialOption;
        public bool SpecialOption
        {
            get { return _SpecialOption; }
            set { _SpecialOption = value; }
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

        #region --------------LastModification--------------
        private DateTime _LastModification = DateTime.MinValue;
        public DateTime LastModification
        {
            get { return _LastModification; }
            set { _LastModification = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequestTotalCount--------------
        private int _RequestTotalCount;
        public int RequestTotalCount
        {
            get { return _RequestTotalCount; }
            set { _RequestTotalCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------RequestNewCount--------------
        private int _RequestNewCount;
        public int RequestNewCount
        {
            get { return _RequestNewCount; }
            set { _RequestNewCount = value; }
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

        #region --------------OwnerName--------------
        private string _OwnerName = SitesHandler.GetOwnerIdentifire();
        public string OwnerName
        {
            get { return _OwnerName; }
            set { _OwnerName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Profile--------------
        private ItemProfile _Profile = new ItemProfile();
        public ItemProfile Profile
        {
            get { return _Profile; }
            set { _Profile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------BuildLink--------------
        //---------------------------------------------------------
        //BuildLink
        //---------------------------------------------------------
        public string BuildLink
        {
            get
            {
                ItemsModulesOptions CurrentModule = ItemsModulesOptions.GetType(ModuleTypeID);
                if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubSites)
                {

                    return DCSiteUrls.Instance.BuildSubSiteItemDetailsLink(ItemID, Title, CurrentModule);
                }
                else
                {
                    return DCSiteUrls.Instance.BuildItemDetailsLink(ItemID, Title, CurrentModule);
                }
            }
        }
        //--------------------------------------------------------
        #endregion

        #region --------------BuildGalleryLink--------------
        //---------------------------------------------------------
        //BuildGalleryLink
        //---------------------------------------------------------
        public string BuildGalleryLink
        {
            get
            {
                ItemsModulesOptions CurrentModule = ItemsModulesOptions.GetType(ModuleTypeID);
                if (SitesHandler.GetOwnerInterfaceType() == OwnerInterfaceType.SubSites)
                {

                    return DCSiteUrls.Instance.BuildSubSiteItemsGalleryHtmlLink(ItemID, Title, CurrentModule);
                }
                else
                {
                    return DCSiteUrls.Instance.BuildItemsGalleryHtmlLink(ItemID, Title, CurrentModule);
                }
            }
        }
        //--------------------------------------------------------
        #endregion

        #region --------------Icon--------------
        private string _Icon = "";
        public string Icon
        {
            get { return _Icon; }
            set { _Icon = value; }
        }
        //------------------------------------------
        #endregion

    }
}

