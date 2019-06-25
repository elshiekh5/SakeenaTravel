using System;
using System.Collections;
using System.Collections.Generic;

using DCCMSNameSpace;



namespace DCCMSNameSpace
{
    public class SiteDeparmentsEntity
    {


        #region --------------DepartmentID--------------
        private int _DepartmentID;
        public int DepartmentID
        {
            get { return _DepartmentID; }
            set { _DepartmentID = value; }
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
                    return SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(_DepartmentID) + _PhotoExtension;
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
                    return SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(_DepartmentID) + MoversFW.Thumbs.thumbnailExetnsion;
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
                    return SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(_DepartmentID) + MoversFW.Thumbs.thumbnailExetnsion;
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
                    return SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(_DepartmentID) + MoversFW.Thumbs.thumbnailExetnsion;
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
                    return SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(_DepartmentID) + MoversFW.Thumbs.thumbnailExetnsion;
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
        #region --------------RelatedModuleTypeID--------------
        private int _RelatedModuleTypeID;
        public int RelatedModuleTypeID
        {
            get { return _RelatedModuleTypeID; }
            set { _RelatedModuleTypeID = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------RelatedPageID--------------
        private int _RelatedPageID;
        public int RelatedPageID
        {
            get { return _RelatedPageID; }
            set { _RelatedPageID = value; }
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

        #region --------------ParentID--------------
        private int _ParentID;
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
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
        private SiteDepartmentTypes _TypeID = SiteDepartmentTypes.SiteDeparment;
        public SiteDepartmentTypes TypeID
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
                return ((SiteDeparmentsDetailsEntity)Details[lang]).Title;
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
        private List<SiteDeparmentsDetailsEntity> _DetailsList;//= new List<SiteDeparmentsDetailsEntity>();
        public List<SiteDeparmentsDetailsEntity> DetailsList
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

        public string SiteDepartmentTitle
        {
            get
            {
                Languages lang = SiteSettings.GetCurrentLanguage();

                if ((SiteDeparmentsDetailsEntity)Details[lang] != null)
                {
                    return ((SiteDeparmentsDetailsEntity)Details[lang]).Title;
                }
                else
                    return "";
            }

        }
        public string SiteDepartmentShortDescription
        {
            get
            {
                Languages lang = SiteSettings.GetCurrentLanguage();
                if ((SiteDeparmentsDetailsEntity)Details[lang] != null)
                {
                    return ((SiteDeparmentsDetailsEntity)Details[lang]).ShortDescription;
                }
                else
                    return "";
            }

        }
        public string SiteDepartmentKeyWords
        {
            get
            {
                Languages lang = SiteSettings.GetCurrentLanguage();
                if ((SiteDeparmentsDetailsEntity)Details[lang] != null)
                {
                    return ((SiteDeparmentsDetailsEntity)Details[lang]).KeyWords;
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

        #region --------------KeyWords--------------
        private string _KeyWords = "";
        public string KeyWords
        {
            get { return _KeyWords; }
            set { _KeyWords = value; }
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

    }


}