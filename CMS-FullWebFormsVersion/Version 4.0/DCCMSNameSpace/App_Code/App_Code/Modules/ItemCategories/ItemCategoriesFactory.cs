using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using DCCMSNameSpace;
using System.IO;
using System.Web.UI;

namespace DCCMSNameSpace
{
    public class ItemCategoriesFactory
    {

        #region --------------Create--------------
        /// <summary>
        /// Creates ItemCategories object by calling ItemCategories data provider create method.
        /// <example>[Example]bool status=ItemCategoriesFactory.Create(itemCategoriesObject);.</example>
        /// </summary>
        /// <param name="itemCategoriesObject">The ItemCategories object.</param>
        /// <returns>Status of create operation.</returns>
        public static ExecuteCommandStatus Create(ItemCategoriesEntity category, ItemsModulesOptions currentModule)
        {
            //Insert user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                category.InsertUserName = username;
            }
            //----------------------------------------------------------
            ExecuteCommandStatus status =ItemCategoriesSqlDataPrvider.Instance.Create(category, currentModule);
            //-------------------------------------
            if (status == ExecuteCommandStatus.Done)
            {
                string folder = DCSiteUrls.GetPath_ItemCategoriesDirectory(category.OwnerName, category.ModuleTypeID, category.CategoryID);
                string folderPhysicalPath = DCServer.MapPath(folder);
                if (!Directory.Exists(folderPhysicalPath))
                {
                    string defaultFolder = DCSiteUrls.GetPath_DefaultCategoryFolder();
                    string defaultFolderPhysicalPath = DCServer.MapPath(defaultFolder);
                    DirectoryInfo diSource = new DirectoryInfo(defaultFolderPhysicalPath);
                    DirectoryInfo diTarget = new DirectoryInfo(folderPhysicalPath);
                    DcDirectoryManager.CopyAll(diSource, diTarget);
                }
            }
            //-------------------------------------
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Updates ItemCategories object by calling ItemCategories data provider update method.
        /// <example>[Example]bool status=ItemCategoriesFactory.Update(itemCategoriesObject);.</example>
        /// </summary>
        /// <param name="itemCategoriesObject">The ItemCategories object.</param>
        /// <returns>Status of update operation.</returns>
        public static ExecuteCommandStatus Update(ItemCategoriesEntity category, ItemsModulesOptions currentModule)
        {
            //Update user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                category.LastUpdateUserName = username;
            }
            //----------------------------------------------------------
            ExecuteCommandStatus status = ItemCategoriesSqlDataPrvider.Instance.Update(category, currentModule);

            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single ItemCategories object .
        /// <example>[Example]bool status=ItemCategoriesFactory.Delete(categoryID);.</example>
        /// </summary>
        /// <param name="categoryID">The itemCategoriesObject id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int CategoryID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            ItemCategoriesEntity category = GetObject(CategoryID, langID, SitesHandler.GetOwnerIDAsGuid());
            bool status = ItemCategoriesSqlDataPrvider.Instance.Delete(CategoryID);
            if (status)
            {
                //-------------------------------------
                //delete category folder
                //-------------------------------------
                string folder = DCSiteUrls.GetPath_ItemCategoriesDirectory(category.OwnerName, category.ModuleTypeID,category.CategoryID);
                string folderPhysicalPath = DCServer.MapPath(folder);
                if (Directory.Exists(folderPhysicalPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(folderPhysicalPath);
                    DcDirectoryManager.DeletDirectory(dir);
                }
                //-------------------------------------
            }
            return status;
        }
        //------------------------------------------

        #endregion

        #region --------------GetAllInDataTable--------------
        public static DataTable GetAllInDataTable(int moduleTypeID, bool isAvailableCondition, Guid OwnerID)
        {

            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemCategoriesSqlDataPrvider.Instance.GetAllItemCategoriesInDataTable(moduleTypeID, langID, isAvailableCondition, OwnerID);
        }
        public static DataTable GetAllInDataTable(int moduleTypeID, Languages langID, bool isAvailableCondition, Guid OwnerID)
        {

            return ItemCategoriesSqlDataPrvider.Instance.GetAllItemCategoriesInDataTable(moduleTypeID, langID, isAvailableCondition, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<ItemCategoriesEntity> GetAll(int moduleTypeID, int parentID, bool isAvailableCondition, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = 0;
            return GetAll(moduleTypeID, parentID, langID, isAvailableCondition, -1, -1, out totalRecords, OwnerID);
        }
        public static List<ItemCategoriesEntity> GetAll(int moduleTypeID, int parentID, Languages langID, bool isAvailableCondition, Guid OwnerID)
        {
            int totalRecords = 0;
            return GetAll(moduleTypeID, parentID, langID, isAvailableCondition, -1, -1, out totalRecords, OwnerID);
        }
        public static List<ItemCategoriesEntity> GetAll(int moduleTypeID, int parentID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemCategoriesSqlDataPrvider.Instance.GetAll(moduleTypeID, parentID, langID, isAvailableCondition, pageIndex, pageSize, out totalRecords, OwnerID);
        }
        public static List<ItemCategoriesEntity> GetAll(int moduleTypeID, int parentID, Languages langID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {

            return ItemCategoriesSqlDataPrvider.Instance.GetAll(moduleTypeID, parentID, langID, isAvailableCondition, pageIndex, pageSize, out totalRecords, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLast--------------
        public static List<ItemCategoriesEntity> GetLast(int moduleTypeID, int Count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = 0;
            return GetLast(moduleTypeID, -1, Count, langID, OwnerID);
        }
        //------------------------------------------
        public static List<ItemCategoriesEntity> GetLast(int moduleTypeID, int parentID, int Count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = 0;
            return GetLast(moduleTypeID, parentID, Count, langID, OwnerID);
        }
        //------------------------------------------
        public static List<ItemCategoriesEntity> GetLast(int moduleTypeID, int Count, Languages langID, Guid OwnerID)
        {
            int totalRecords = 0;
            return GetLast(moduleTypeID, -1, Count, langID, OwnerID);
        }
        //------------------------------------------
        public static List<ItemCategoriesEntity> GetLast(int moduleTypeID, int parentID, int Count, Languages langID, Guid OwnerID)
        {
            int totalRecords = 0;
            return ItemCategoriesSqlDataPrvider.Instance.GetLast(moduleTypeID, parentID, Count, langID, OwnerID);
        }
        //------------------------------------------

        #endregion

        //------------------------------------------
        public static List<ItemCategoriesEntity> GetFullPath(int categoryID)
        {
            Languages lang = SiteSettings.GetCurrentLanguage();
            return ItemCategoriesSqlDataPrvider.Instance.GetFullPath(categoryID, lang);
        }
        //------------------------------------------

        #region --------------GetObject--------------
        public static ItemCategoriesEntity GetObject(int categoryID, Languages langID, Guid OwnerID)
        {
            ItemCategoriesEntity itemCategoriesObject;
            HttpContext context = HttpContext.Current;
            string cacheKey = "itemCategoriesObject" + categoryID;

            if (context.Items[cacheKey] == null)
            {
                itemCategoriesObject = ItemCategoriesSqlDataPrvider.Instance.GetItemCategoriesObject(categoryID, langID, OwnerID);
                context.Items[cacheKey] = itemCategoriesObject;
            }
            else
            {
                itemCategoriesObject = (ItemCategoriesEntity)context.Items[cacheKey];
            }
            return itemCategoriesObject;

        }
        //------------------------------------------
        #endregion

        #region --------------CreateItemCategoriesPhotoName--------------
        public static string CreateItemCategoriesPhotoName(int CategoryID)
        {
            return "ItemCategories_" + CategoryID.ToString();
        }
        //------------------------------------------
        #endregion



        #region --------------GetItemCategoriesPhotoThumbnail--------------
        public static string GetItemCategoriesPhotoThumbnail(object categoryID, object photoExtension, int width, int height, object ownerName, object ModuleTypeID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                //return DCSiteUrls.GetPath_ItemCategoriesPhotoNormalThumbs ((string)ownerName) + CreateItemCategoriesPhotoName((int)CategoryID) + MoversFW.Thumbs.thumbnailExetnsion;
                return "/Thumbnails/Maker1.aspx?file=" + GetItemCategoriesPhotoBigThumbnail(categoryID, photoExtension, (string)ownerName, (int)ModuleTypeID) + "&W=" + width + "&H=" + height;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //--------------------------------------------

        #endregion

        #region --------------GetItemCategoriesPhotoBigThumbnail--------------
        public static string GetItemCategoriesPhotoBigThumbnail(object CategoryID, object photoExtension, object ownerName, object ModuleTypeID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                return DCSiteUrls.GetPath_ItemCategoriesPhotoBigThumbs((string)ownerName, (int)ModuleTypeID, (int)CategoryID) + CreateItemCategoriesPhotoName((int)CategoryID) + MoversFW.Thumbs.thumbnailExetnsion;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion


        ////////////////////////////////////////////////////////////////////////

        #region --------------CreateFileName--------------
        public static string CreateFileName(int CategoryID)
        {
            return "ItemCategories_" + CategoryID.ToString();
        }
        //------------------------------------------
        #endregion

        #region --------------GetCount--------------
        public static int GetCount(int moduleTypeID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemCategoriesSqlDataPrvider.Instance.GetCount(moduleTypeID, langID, OwnerID);
        }
        //------------------------------------------
        public static int GetCount(int moduleTypeID, Languages langID, Guid OwnerID)
        {

            return ItemCategoriesSqlDataPrvider.Instance.GetCount(moduleTypeID, langID, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetMain--------------
        public static List<ItemCategoriesEntity> GetMain(int moduleTypeID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemCategoriesSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<ItemCategoriesEntity> GetMain(int moduleTypeID, Languages langID, int count, Guid OwnerID)
        {

            return ItemCategoriesSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count, OwnerID);
        }
        //------------------------------------------
        #endregion


        #region --------------GetNotMain--------------
        public static List<ItemCategoriesEntity> GetNotMain(int moduleTypeID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemCategoriesSqlDataPrvider.Instance.GetNotMain(moduleTypeID, langID, OwnerID);
        }
        //------------------------------------------
        public static List<ItemCategoriesEntity> GetNotMain(int moduleTypeID, Languages langID, Guid OwnerID)
        {
            return ItemCategoriesSqlDataPrvider.Instance.GetNotMain(moduleTypeID, langID, OwnerID);
        }
        //------------------------------------------

        #endregion


       

    }

}