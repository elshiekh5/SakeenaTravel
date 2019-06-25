using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using DCCMSNameSpace;
using System.Web.UI.WebControls;


namespace DCCMSNameSpace
{
    public class SiteDeparmentsFactory
    {


        #region --------------Create--------------
        /// <summary>
        /// Creates SiteDeparments object by calling SiteDeparments data provider create method.
        /// <example>[Example]bool status=SiteDeparmentsFactory.Create(siteDeparmentsObject);.</example>
        /// </summary>
        /// <param name="siteDeparmentsObject">The SiteDeparments object.</param>
        /// <returns>Status of create operation.</returns>
        public static ExecuteCommandStatus Create(SiteDeparmentsEntity siteDepartment)
        {
            //Insert user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                siteDepartment.InsertUserName = username;
            }
            //----------------------------------------------------------
            return SiteDeparmentsSqlDataPrvider.Instance.Create(siteDepartment);
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Updates SiteDeparments object by calling SiteDeparments data provider update method.
        /// <example>[Example]bool status=SiteDeparmentsFactory.Update(siteDeparmentsObject);.</example>
        /// </summary>
        /// <param name="siteDeparmentsObject">The SiteDeparments object.</param>
        /// <returns>Status of update operation.</returns>
        public static ExecuteCommandStatus Update(SiteDeparmentsEntity siteDepartment)
        {
            //Update user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                siteDepartment.LastUpdateUserName = username;
            }
            //----------------------------------------------------------
            ExecuteCommandStatus status = SiteDeparmentsSqlDataPrvider.Instance.Update(siteDepartment);

            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single SiteDeparments object .
        /// <example>[Example]bool status=SiteDeparmentsFactory.Delete(departmentID);.</example>
        /// </summary>
        /// <param name="departmentID">The siteDeparmentsObject id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int departmentID)
        {

            bool status = SiteDeparmentsSqlDataPrvider.Instance.Delete(departmentID);
            return status;
        }
        //------------------------------------------

        #endregion

        #region --------------GetAllInDataTable--------------
        public static DataTable GetAllInDataTable(int moduleTypeID, bool isAvailableCondition)
        {

            Languages langID = SiteSettings.GetCurrentLanguage();
            return SiteDeparmentsSqlDataPrvider.Instance.GetSiteDeparmentsInDataTable(moduleTypeID, -1, langID, isAvailableCondition);
        }
        public static DataTable GetAllInDataTable(int moduleTypeID, Languages langID, bool isAvailableCondition)
        {

            return SiteDeparmentsSqlDataPrvider.Instance.GetSiteDeparmentsInDataTable(moduleTypeID, -1, langID, isAvailableCondition);
        }
        //------------------------------------------
        #endregion
        #region --------------GetInDataTable--------------
        public static DataTable GetInDataTable(int moduleTypeID, int parentID, bool isAvailableCondition)
        {

            Languages langID = SiteSettings.GetCurrentLanguage();
            return SiteDeparmentsSqlDataPrvider.Instance.GetSiteDeparmentsInDataTable(moduleTypeID, parentID, langID, isAvailableCondition);
        }
        public static DataTable GetInDataTable(int moduleTypeID, int parentID, Languages langID, bool isAvailableCondition)
        {

            return SiteDeparmentsSqlDataPrvider.Instance.GetSiteDeparmentsInDataTable(moduleTypeID, parentID, langID, isAvailableCondition);
        }
        //------------------------------------------
        #endregion
        //------------------------------------------
        public static List<SiteDeparmentsEntity> GetFullPath(int departmentID)
        {
            Languages lang = SiteSettings.GetCurrentLanguage();
            return SiteDeparmentsSqlDataPrvider.Instance.GetFullPath(departmentID, lang);
        }
        //------------------------------------------
        public static List<SiteDeparmentsEntity> GetFullPathByRelatedModule(int RelatedModuleID)
        {
            Languages lang = SiteSettings.GetCurrentLanguage();
            return SiteDeparmentsSqlDataPrvider.Instance.GetFullPathByRelatedModule(RelatedModuleID, lang);
        }
        //------------------------------------------
        public static List<SiteDeparmentsEntity> GetFullPathByRelatedPageID(int RelatedModuleID)
        {
            Languages lang = SiteSettings.GetCurrentLanguage();
            return SiteDeparmentsSqlDataPrvider.Instance.GetFullPathByRelatedPageID(RelatedModuleID, lang);
        }
        //------------------------------------------

        #region --------------GetAll--------------
        public static List<SiteDeparmentsEntity> GetAll(int moduleTypeID, int parentID, bool isAvailableCondition)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = 0;
            return GetAll(moduleTypeID, parentID, langID, isAvailableCondition, -1, -1, out totalRecords);
        }
        public static List<SiteDeparmentsEntity> GetAll(int moduleTypeID, int parentID, Languages langID, bool isAvailableCondition)
        {
            int totalRecords = 0;
            return GetAll(moduleTypeID, parentID, langID, isAvailableCondition, -1, -1, out totalRecords);
        }
        public static List<SiteDeparmentsEntity> GetAll(int moduleTypeID, int parentID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return SiteDeparmentsSqlDataPrvider.Instance.GetAll(moduleTypeID, parentID, langID, isAvailableCondition, pageIndex, pageSize, out totalRecords);
        }
        public static List<SiteDeparmentsEntity> GetAll(int moduleTypeID, int parentID, Languages langID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords)
        {

            return SiteDeparmentsSqlDataPrvider.Instance.GetAll(moduleTypeID, parentID, langID, isAvailableCondition, pageIndex, pageSize, out totalRecords);
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static SiteDeparmentsEntity GetObject(int departmentID, Languages lang)
        {
            SiteDeparmentsEntity siteDeparmentsObject;
            HttpContext context = HttpContext.Current;
            string cacheKey = "siteDeparmentsObject" + departmentID;

            if (context.Items[cacheKey] == null)
            {
                siteDeparmentsObject = SiteDeparmentsSqlDataPrvider.Instance.GetSiteDeparmentsObject(departmentID, lang);
                context.Items[cacheKey] = siteDeparmentsObject;
            }
            else
            {
                siteDeparmentsObject = (SiteDeparmentsEntity)context.Items[cacheKey];
            }
            return siteDeparmentsObject;

        }
        //------------------------------------------
        #endregion

        #region --------------CreateSiteDeparmentsPhotoName--------------
        public static string CreateSiteDeparmentsPhotoName(int DepartmentID)
        {
            return "SiteDeparments_" + DepartmentID.ToString();
        }
        //------------------------------------------
        #endregion

        #region --------------GetSiteDeparmentsPhotoThumbnail--------------
        public static string GetSiteDeparmentsPhotoThumbnail(object departmentID, object photoExtension, object ownerName)
        {
            if (photoExtension.ToString().Length > 0)
            {
                //return DCSiteUrls.GetPath_SiteDeparmentsPhotoNormalThumbs ((string)ownerName) + CreateSiteDeparmentsPhotoName((int)DepartmentID) + MoversFW.Thumbs.thumbnailExetnsion;
                return "/Thumbnails/Maker1.aspx?file=" + GetSiteDeparmentsPhotoBigThumbnail(departmentID, photoExtension,  ownerName) + "&W=108&H=83";
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //--------------------------------------------

        #endregion

        #region --------------GetSiteDeparmentsPhotoBigThumbnail--------------
        public static string GetSiteDeparmentsPhotoBigThumbnail(object DepartmentID, object photoExtension, object ownerName)
        {
            if (photoExtension.ToString().Length > 0)
            {
                return DCSiteUrls.GetPath_SiteDeparmentsPhotoBigThumbs ((string)ownerName) + CreateSiteDeparmentsPhotoName((int)DepartmentID) + MoversFW.Thumbs.thumbnailExetnsion;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetSiteDeparmentsPhotoOriginal--------------
        public static string GetSiteDeparmentsPhotoOriginal(object DepartmentID, object photoExtension, object ownerName)
        {
            if (photoExtension.ToString().Length > 0)
            {
                return DCSiteUrls.GetPath_SiteDeparmentsPhotoBigThumbs ((string)ownerName) + CreateSiteDeparmentsPhotoName((int)DepartmentID) + photoExtension.ToString();
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion

        public static void AddTitlePath(PathLinksClass pc)
        {
            AddTitlePath(pc, null);
        }
        public static void AddTitlePath(PathLinksClass pc, Label lblTitle)
        {
            if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {
                int siteDepartmentID = Convert.ToInt32(HttpContext.Current.Request.QueryString["id"]);
                Languages lang = SiteSettings.GetCurrentLanguage();
                SiteDeparmentsEntity depObject = SiteDeparmentsFactory.GetObject(siteDepartmentID, lang);

                if (depObject != null)
                {
                    if (pc != null)
                        pc.AddLink(depObject.Title, null);
                    if (lblTitle != null)
                        lblTitle.Text = depObject.Title;
                }
            }
        }

    }


}