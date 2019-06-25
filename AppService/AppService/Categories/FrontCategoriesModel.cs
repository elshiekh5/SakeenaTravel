using System;
using System.Collections;
using System.Collections.Generic;
using DCCMSNameSpace;
namespace AppService
{
    public class FrontCategoriesModel
    {


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
                    return ItemCategoriesFactory.CreateItemCategoriesPhotoName(_CategoryID) + _PhotoExtension;
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
                    return ItemCategoriesFactory.CreateItemCategoriesPhotoName(_CategoryID) + MoversFW.Thumbs.thumbnailExetnsion;
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
                    return ItemCategoriesFactory.CreateItemCategoriesPhotoName(_CategoryID) + MoversFW.Thumbs.thumbnailExetnsion;
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
                    return ItemCategoriesFactory.CreateItemCategoriesPhotoName(_CategoryID) + MoversFW.Thumbs.thumbnailExetnsion;
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
                    return ItemCategoriesFactory.CreateItemCategoriesPhotoName(_CategoryID) + MoversFW.Thumbs.thumbnailExetnsion;
                }
                else
                {
                    return "";
                }
            }
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



        #region --------------ParentID--------------
        private int _ParentID;
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AllItemsCount--------------
        private int _AllItemsCount;
        public int AllItemsCount
        {
            get { return _AllItemsCount; }
            set { _AllItemsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ActiveItemsCount--------------
        private int _ActiveItemsCount;
        public int ActiveItemsCount
        {
            get { return _ActiveItemsCount; }
            set { _ActiveItemsCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------TypeID--------------
        private CategoriesType _TypeID = CategoriesType.ItemCategories;
        public CategoriesType TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }
        //------------------------------------------
        #endregion
        #region ---------------Details---------------

        public string GetTitle(Languages lang)
        {
            if (Details[lang] != null)
            {
                return ((ItemCategoriesDetailsEntity)Details[lang]).Title;
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
        private List<ItemCategoriesDetailsEntity> _DetailsList;//= new List<ItemCategoriesDetailsEntity>();
        public List<ItemCategoriesDetailsEntity> DetailsList
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

        public string CategoryTitle
        {
            get
            {
                Languages lang = SiteSettings.GetCurrentLanguage();

                if ((ItemCategoriesDetailsEntity)Details[lang] != null)
                {
                    return ((ItemCategoriesDetailsEntity)Details[lang]).Title;
                }
                else
                    return "";
            }

        }
        public string CategoryShortDescription
        {
            get
            {
                Languages lang = SiteSettings.GetCurrentLanguage();
                if ((ItemCategoriesDetailsEntity)Details[lang] != null)
                {
                    return ((ItemCategoriesDetailsEntity)Details[lang]).ShortDescription;
                }
                else
                    return "";
            }

        }
        public string CategoryKeyWords
        {
            get
            {
                Languages lang = SiteSettings.GetCurrentLanguage();

                if ((ItemCategoriesDetailsEntity)Details[lang] != null)
                {
                    return ((ItemCategoriesDetailsEntity)Details[lang]).KeyWords;
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



        #region --------------Path--------------
        private string _Path = "";
        public string Path
        {
            get { return _Path; }
            set { _Path = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------TotalSubItems--------------
        private int _TotalSubItems;
        public int TotalSubItems
        {
            get { return _TotalSubItems; }
            set { _TotalSubItems = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MostRecentSubItemDate--------------
        private DateTime _MostRecentSubItemDate = DateTime.MinValue;
        public DateTime MostRecentSubItemDate
        {
            get { return _MostRecentSubItemDate; }
            set { _MostRecentSubItemDate = value; }
        }
        //------------------------------------------
        #endregion


        //New Columns start////////////////////////////////////////////////

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

        #region --------------IsMain--------------
        private bool _IsMain;
        public bool IsMain
        {
            get { return _IsMain; }
            set { _IsMain = value; }
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
                    return ItemCategoriesFactory.CreateFileName(_CategoryID) + _Photo2Extension;
                }
                else
                {
                    return "";
                }
            }
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
                    return ItemCategoriesFactory.CreateFileName(_CategoryID) + _VideoExtension;
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
                    return ItemCategoriesFactory.CreateFileName(_CategoryID) + _AudioExtension;
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
                    return ItemCategoriesFactory.CreateFileName(_CategoryID) + _FileExtension;
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

        #region --------------YoutubeCode--------------
        private string _YoutubeCode = "";
        public string YoutubeCode
        {
            get { return _YoutubeCode; }
            set { _YoutubeCode = value; }
        }
        //------------------------------------------
        #endregion


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

        /*
        #region --------------OwnerID--------------
        private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
        public Guid OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
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
        */

        #region --------------OwnerName--------------
        private string _OwnerName = SitesHandler.GetOwnerIdentifire();
        public string OwnerName
        {
            get { return _OwnerName; }
            set { _OwnerName = value; }
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

                    return DCSiteUrls.Instance.BuildSubSiteItemCategoriesLink(CategoryID, Title, CurrentModule);
                }
                else
                {
                    return DCSiteUrls.Instance.BuildItemCategoriesLink(CategoryID, Title, CurrentModule);
                }
            }
        }
        //--------------------------------------------------------
        #endregion
    }
}

