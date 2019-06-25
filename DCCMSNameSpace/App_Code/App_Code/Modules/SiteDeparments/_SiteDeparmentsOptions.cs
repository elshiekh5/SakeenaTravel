using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;

namespace DCCMSNameSpace
{


    public class SiteDeparmentsOptions
    {
        public string _Identifire = "Unknown";
        public string Identifire { get { return _Identifire; } set { _Identifire = value; } }
        //---------------------------------------------
        public int _ModuleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
        public int ModuleTypeID { get { return _ModuleTypeID; } set { _ModuleTypeID = value; } }
        //---------------------------------------------
        //---------------------------------------------
        //SiteDepartments Options
        //---------------------------------------------
        public bool _HasIsAvailable = false;
        public bool HasIsAvailable { get { return _HasIsAvailable; } set { _HasIsAvailable = value; } }
        //---------------------------------------------
        public bool _HasShortDescription = false;
        public bool HasShortDescription { get { return _HasShortDescription; } set { _HasShortDescription = value; } }
        //---------------------------------------------
        public bool _HasTitle = true;
        public bool HasTitle { get { return _HasTitle; } set { _HasTitle = value; } }
        //---------------------------------------------

        public bool _HasDescription = false;
        public bool HasDescription { get { return _HasDescription; } set { _HasDescription = value; } }
        //---------------------------------------------
        public bool _HasUrl = true;
        public bool HasUrl { get { return _HasUrl; } set { _HasUrl = value; } }
        
        //---------------------------------------------
        public int _SiteDepartmentLevel = -1;
        public int SiteDepartmentsLevel { get { return _SiteDepartmentLevel; } set { _SiteDepartmentLevel = value; } }
        //---------------------------------------------
        public bool _HasRelatedModuleTypeID = true;
        public bool HasRelatedModuleTypeID { get { return _HasRelatedModuleTypeID; } set { _HasRelatedModuleTypeID = value; } }

        //---------------------------------------------

        #region --------------HasMetaKeyWords--------------
        private bool _HasMetaKeyWords = true;
        public bool HasMetaKeyWords
        {
            get { return _HasMetaKeyWords; }
            set { _HasMetaKeyWords = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasMetaDescription--------------
        private bool _HasMetaDescription = true;
        public bool HasMetaDescription
        {
            get { return _HasMetaDescription; }
            set { _HasMetaDescription = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------files options----------------
        //---------------------------------------------
        //HasPhoto
        public bool _HasPhotoExtension = true;
        public bool HasPhotoExtension { get { return _HasPhotoExtension; } set { _HasPhotoExtension = value; } }
        //---------------------------------------------
        public string _PhotoAvailableExtension = "";
        public string PhotoAvailableExtension { get { return _PhotoAvailableExtension; } set { _PhotoAvailableExtension = value; } }
        //---------------------------------------------

        public int _PhotoMaxSize = -1;
        public int PhotoMaxSize { get { return _PhotoMaxSize; } set { _PhotoMaxSize = value; } }
        //---------------------------------------

        //---------------------------------------
        #endregion

       #region ************Module Texts************
        //---------------------------------------------
        public string _ResourceFile = "SiteDepartment";
        public string ResourceFile { get { return _ResourceFile; } set { _ResourceFile = value; } }
        //---------------------------------------------
        public string _DefaultResourceFile = "SiteDepartment";
        public string DefaultResourceFile { get { return _DefaultResourceFile; } set { _DefaultResourceFile = value; } }
        #endregion

        

        #region ************Module validation************
        //---------------------------------------------
        //SiteDepartments Options
        //---------------------------------------------
        public bool _RequiredShortDescription = false;
        public bool RequiredShortDescription { get { return _RequiredShortDescription; } set { _RequiredShortDescription = value; } }
        //---------------------------------------------
        public bool _RequiredTitle = true;
        public bool RequiredTitle { get { return _RequiredTitle; } set { _RequiredTitle = value; } }
        //---------------------------------------------
        public bool _RequiredPhoto = false;
        public bool RequiredPhoto { get { return _RequiredPhoto; } set { _RequiredPhoto = value; } }
        //---------------------------------------------
        public bool _RequiredDetails = true;
        public bool RequiredDetails { get { return _RequiredDetails; } set { _RequiredDetails = value; } }
        //---------------------------------------------
        public bool _RequiredUrl = false;
        public bool RequiredUrl { get { return _RequiredUrl; } set { _RequiredUrl = value; } }
        //---------------------------------------------
        #endregion

        //---------------------------------------------
        #region --------------GetPhotoValidationExpression()--------------
        public string GetPhotoValidationExpression()
        {
            return ValidationExpressionBuilder.CreateExpression(PhotoAvailableExtension);
        }
        //------------------------------------------
        #endregion

        /*
        public bool _HasSiteDepartmentIntro = false;
        public bool HasSiteDepartmentIntro { get { return _HasSiteDepartmentIntro; } set { _HasSiteDepartmentIntro = value; } }
        */
        //---------------------------------------
        
        public static SiteDeparmentsOptions GetType(int moduleType)
        {
           // return SiteItemsModules.Instance.GetModule(moduleType);
            return new SiteDeparmentsOptions();
        }
        

    }
    
       

    

    

    
}