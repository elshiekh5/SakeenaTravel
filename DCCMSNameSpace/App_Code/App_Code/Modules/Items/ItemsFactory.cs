using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using System.IO;
using DCCMSNameSpace;
using System.Web.UI.WebControls;


namespace DCCMSNameSpace
{
    public class ItemsFactory
    {

        #region --------------Create--------------
        /// <summary>
        /// Creates Items object by calling Items data provider create method.
        /// <example>[Example]bool status=ItemsFactory.Create(itemsObject);.</example>
        /// </summary>
        /// <param name="itemsObject">The Items object.</param>
        /// <returns>Status of create operation.</returns>
        public static ExecuteCommandStatus Create(ItemsEntity item, ItemsModulesOptions currentModule)
        {
            //Insert user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                item.InsertUserName = username;
            }
            //----------------------------------------------------------
            ExecuteCommandStatus Status =  ItemsSqlDataPrvider.Instance.Create(item, currentModule);
            if (Status == ExecuteCommandStatus.Done)
            {
                //-------------------------------------
                //Create Item Folder
                //-------------------------------------
                string folder = DCSiteUrls.GetPath_ItemsDirectory(item.OwnerName, item.ModuleTypeID, item.CategoryID, item.ItemID);
                string folderPhysicalPath = DCServer.MapPath(folder);
                if (!Directory.Exists(folderPhysicalPath))
                {
                    string defaultFolder = DCSiteUrls.GetPath_DefaultItemFolder();
                    string defaultFolderPhysicalPath = DCServer.MapPath(defaultFolder);
                    DirectoryInfo diSource = new DirectoryInfo(defaultFolderPhysicalPath);
                    DirectoryInfo diTarget = new DirectoryInfo(folderPhysicalPath);
                    DcDirectoryManager.CopyAll(diSource, diTarget);
                }
                //-------------------------------------
            }
            return Status;
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Updates Items object by calling Items data provider update method.
        /// <example>[Example]bool status=ItemsFactory.Update(itemsObject);.</example>
        /// </summary>
        /// <param name="itemsObject">The Items object.</param>
        /// <returns>Status of update operation.</returns>
        public static ExecuteCommandStatus Update(ItemsEntity item, ItemsModulesOptions currentModule)
        {
            //Update user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                item.LastUpdateUserName = username;
            }
            //----------------------------------------------------------
            ExecuteCommandStatus status = ItemsSqlDataPrvider.Instance.Update(item, currentModule);
            //-------------------------------------
            //Create Item Folder
            //-------------------------------------
            string folder = DCSiteUrls.GetPath_ItemsDirectory(item.OwnerName, item.ModuleTypeID, item.CategoryID, item.ItemID);
            string folderPhysicalPath = DCServer.MapPath(folder);
            if (!Directory.Exists(folderPhysicalPath))
            {
                string defaultFolder = DCSiteUrls.GetPath_DefaultItemFolder();
                string defaultFolderPhysicalPath = DCServer.MapPath(defaultFolder);
                DirectoryInfo diSource = new DirectoryInfo(defaultFolderPhysicalPath);
                DirectoryInfo diTarget = new DirectoryInfo(folderPhysicalPath);
                DcDirectoryManager.CopyAll(diSource, diTarget);
            }
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single Items object .
        /// <example>[Example]bool status=ItemsFactory.Delete(itemID);.</example>
        /// </summary>
        /// <param name="itemID">The itemsObject id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int itemID)
        {
            ItemsEntity itemsObject = ItemsFactory.GetObject(itemID, Languages.Unknowen, UsersTypes.Admin, SitesHandler.GetOwnerIDAsGuid());
            bool status = Delete(itemsObject);
            return status;
        }
        public static bool Delete(ItemsEntity itemsObject)
        {
            bool status = ItemsSqlDataPrvider.Instance.Delete(itemsObject.ItemID);
            if (status)
            {
                //------------------------------------------------
                //DeleteFiles
                DeleteFiles(itemsObject);
                //------------------------------------------------
              /*  
                List<ItemsFilesEntity> childfiles = ItemsFilesFactory.GetAll(itemsObject.ItemID, (int)StandardItemsModuleTypes.PhotoGallery, ItemFileTypes.Photo);
                foreach (ItemsFilesEntity File in childfiles)
                {
                    ItemsFilesFactory.DeleteFiles(File);
                }
               
                //------------------------------------------------
                //RegisterInMailList
                ItemsModulesOptions currentModule = ItemsModulesOptions.GetType(itemsObject.ModuleTypeID);

                if ((currentModule.MailListAutomaticRegistration) && !string.IsNullOrEmpty(itemsObject.Email))
                    ItemsFactory.UnRegisterInMailList(itemsObject);
                //------------------------------------------------
                //RegisterSms
                if ((currentModule.SmsAutomaticRegistration) && !string.IsNullOrEmpty(itemsObject.Mobile))
                    ItemsFactory.UnRegisterInSms(itemsObject);
                //------------------------------------------------
               */
            }
            return status;
        }
        //------------------------------------------

        public static void DeleteFiles(ItemsEntity itemsObject)
        {
            //-------------------------------------
            //Delete Item Folder
            //-------------------------------------
            string folder = DCSiteUrls.GetPath_ItemsDirectory(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID);
            string folderPhysicalPath = DCServer.MapPath(folder);
            if (Directory.Exists(folderPhysicalPath))
            {
                DirectoryInfo dir = new DirectoryInfo(folderPhysicalPath);
                DcDirectoryManager.DeletDirectory(dir);
            }
            //-------------------------------------
           /*
            HttpContext context = HttpContext.Current;
            //Photo-----------------------------
            if (!string.IsNullOrEmpty(itemsObject.PhotoExtension))
            {
                //Delete old original photo
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoOriginals(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Photo);
                //Delete old Thumbnails
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoNormalThumbs(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + ItemsFactory.CreateItemsPhotoName(itemsObject.ItemID) + MoversFW.Thumbs.thumbnailExetnsion);
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsPhotoBigThumbs(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + ItemsFactory.CreateItemsPhotoName(itemsObject.ItemID) + MoversFW.Thumbs.thumbnailExetnsion);
                //------------------------------------------------
            }
            if (!string.IsNullOrEmpty(itemsObject.FileExtension))
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.File);

            if (!string.IsNullOrEmpty(itemsObject.VideoExtension))
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Video);

            if (!string.IsNullOrEmpty(itemsObject.AudioExtension))
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles(itemsObject.OwnerName, itemsObject.ModuleTypeID, itemsObject.CategoryID, itemsObject.ItemID)) + itemsObject.Audio);
            */
        }
        #endregion

        #region --------------GetLast--------------
        public static List<ItemsEntity> GetLast(int moduleTypeID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return GetLast(moduleTypeID, -1, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLast(int moduleTypeID, int CategoryID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return GetLast(moduleTypeID, CategoryID, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLast(int moduleTypeID, Languages langID, int count, Guid OwnerID)
        {

            return GetLast(moduleTypeID, -1, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLast(int moduleTypeID, int CategoryID, Languages langID, int count, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetLast(moduleTypeID, CategoryID, langID, count, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastInMultiModules--------------
        public static List<ItemsEntity> GetLastInMultiModules(string Modules, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return GetLastInMultiModules(Modules, -1, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastInMultiModules(string Modules, int CategoryID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return GetLastInMultiModules(Modules, CategoryID, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastInMultiModules(string Modules, Languages langID, int count, Guid OwnerID)
        {

            return GetLastInMultiModules(Modules, -1, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastInMultiModules(string Modules, int CategoryID, Languages langID, int count, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetLastInMultiModules(Modules, CategoryID, langID, count, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastRandom--------------
        public static List<ItemsEntity> GetLastRandom(int moduleTypeID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetLastRandom(moduleTypeID, -1, langID, count, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastRandom(int moduleTypeID, int CategoryID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetLastRandom(moduleTypeID, CategoryID, langID, count, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastRandom(int moduleTypeID, int CategoryID, Languages langID, int count, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetLastRandom(moduleTypeID, CategoryID, langID, count, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastRandomInMultiModules--------------
        public static List<ItemsEntity> GetLastRandomInMultiModules(string Modules, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetLastRandomInMultiModules(Modules, -1, langID, count, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastRandomInMultiModules(string Modules, int CategoryID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetLastRandomInMultiModules(Modules, CategoryID, langID, count, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastRandomInMultiModules(string Modules, int CategoryID, Languages langID, int count, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetLastRandomInMultiModules(Modules, CategoryID, langID, count, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllForAdmin--------------
        public static List<ItemsEntity> GetAllForAdmin(int moduleTypeID, Guid OwnerID)
        {
            //Languages langID = SiteSettings.GetCurrentLanguage();
            return GetAll(moduleTypeID, Languages.Unknowen, false, OwnerID);
        }
        //------------------------------------------------
        public static List<ItemsEntity> GetAllForAdmin(int moduleTypeID, Languages langID, Guid OwnerID)
        {

            return GetAll(moduleTypeID, langID, false, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllForUser--------------
        public static List<ItemsEntity> GetAllForUser(int moduleTypeID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return GetAll(moduleTypeID, langID, true, OwnerID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAllForUser(int moduleTypeID, Languages langID, Guid OwnerID)
        {
            return GetAll(moduleTypeID, langID, true, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, bool isAvailableCondition, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, -1, isAvailableCondition, -1, -1, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, Languages langID, bool isAvailableCondition, Guid OwnerID)
        {
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, -1, isAvailableCondition, -1, -1, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllForAdmin--------------
        //------------------------------------------
        public static List<ItemsEntity> GetAllForAdmin(int moduleTypeID, Languages langID, int categoryID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {

            return GetAll(moduleTypeID, langID, categoryID, false, pageIndex, pageSize, out totalRecords, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllForUser--------------
        public static List<ItemsEntity> GetAllForUser(int moduleTypeID, int categoryID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return GetAll(moduleTypeID, langID, categoryID, true, pageIndex, pageSize, out totalRecords, OwnerID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAllForUser(int moduleTypeID, Languages langID, int categoryID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {

            return GetAll(moduleTypeID, langID, categoryID, true, pageIndex, pageSize, out totalRecords, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, int categoryID, bool isAvailableCondition, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, -1, -1, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, Guid OwnerID)
        {
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, -1, -1, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetInList--------------
        //------------------------------------------
        public static List<ItemsEntity> GetInList(string itemsInList)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetInList(itemsInList, langID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllFlv--------------
        public static List<ItemsEntity> GetAllFlv(int moduleTypeID, int categoryID, bool isAvailableCondition, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, -1, -1, out totalRecords, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAllFlv(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, Guid OwnerID)
        {
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, -1, -1, out totalRecords, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAllFlv(int moduleTypeID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAllFlv(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            return ItemsSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------CalendarMethods--------------

        #region --------------CalendarGetByMonth--------------
        public static List<ItemsEntity> CalendarGetByMonth(int moduleTypeID, int categoryID, int year, int month, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.CalendarGetByMonth(moduleTypeID, langID, categoryID, year, month, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> CalendarGetByMonth(int moduleTypeID, Languages langID, int categoryID, int year, int month, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.CalendarGetByMonth(moduleTypeID, langID, categoryID, year, month, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------CalendarGetByDay--------------
        public static List<ItemsEntity> CalendarGetByDay(int moduleTypeID, int Day, DateTime From, DateTime To, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.CalendarGetByDay(moduleTypeID, langID, Day, From, To, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> CalendarGetByDay(int moduleTypeID, Languages langID, int Day, DateTime From, DateTime To, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.CalendarGetByDay(moduleTypeID, langID, Day, From, To, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------CalendarGetToDay--------------
        public static List<ItemsEntity> CalendarGetToDay(int moduleTypeID, DateTime Date, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.CalendarGetToDay(moduleTypeID, langID, Date, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> CalendarGetToDay(int moduleTypeID, Languages langID, DateTime Date, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.CalendarGetToDay(moduleTypeID, langID, Date, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #endregion


        #region --------------Search--------------
        public static List<ItemsEntity> Search(int moduleTypeID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> Search(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID)
        {
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID, -1);
        }
        //------------------------------------------
        #endregion




        #region --------------Search--------------
        public static List<ItemsEntity> SearchInMultiModules(string modules, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.SearchInMultiModules(modules, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> SearchInMultiModules(string modules, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID)
        {
            return ItemsSqlDataPrvider.Instance.SearchInMultiModules(modules, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------Search--------------
        public static List<ItemsEntity> SiteSearch(int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.SiteSearch(langID, pageIndex, pageSize, out totalRecords, keywords, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> SiteSearch(Languages langID, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID)
        {
            return ItemsSqlDataPrvider.Instance.SiteSearch(langID, pageIndex, pageSize, out totalRecords, keywords, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static ItemsEntity GetObject(int itemID, Languages langID, UsersTypes viewerType, Guid OwnerID)
        {
            ItemsEntity itemsObject;
            HttpContext context = HttpContext.Current;
            string cacheKey = "itemsObject" + itemID;
            if (context.Items[cacheKey] == null)
            {
                itemsObject = ItemsSqlDataPrvider.Instance.GetItemsObject(itemID, langID, viewerType, OwnerID);
                context.Items[cacheKey] = itemsObject;
            }
            else
            {
                itemsObject = (ItemsEntity)context.Items[cacheKey];
            }
            //return the object
            return itemsObject;
        }
        //------------------------------------------
        #endregion


        #region --------------GetMain--------------
        //------------------------------------------
        public static List<ItemsEntity> GetMain(int moduleTypeID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count, true, -1, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetMain(int moduleTypeID, int count, int CategoryID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count, true, CategoryID, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetMain(int moduleTypeID, int count, bool isMainValue, int CategoryID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count, isMainValue, CategoryID, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetMain(int moduleTypeID, Languages langID, int count, bool isMainValue, int CategoryID, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count, isMainValue, CategoryID, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetHaveSpecialOption--------------
        public static List<ItemsEntity> GetHaveSpecialOption(int moduleTypeID, int count,bool specialOptionValue,int CategoryID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetHaveSpecialOption(moduleTypeID, langID, count, specialOptionValue, CategoryID, OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetHaveSpecialOption(int moduleTypeID, Languages langID, int count, bool specialOptionValue, int CategoryID, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetHaveSpecialOption(moduleTypeID, langID, count, specialOptionValue, CategoryID, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        

        #region --------------GetLastFlv--------------
        public static List<ItemsEntity> GetLastFlv(Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetLastFlv(langID, OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------Rate--------------
        public static void Rate(int itemID, int rate)
        {
            ItemsSqlDataPrvider.Instance.Rate(itemID, rate);
        }
        //------------------------------------------
        #endregion

        #region --------------UpdateIsSeen--------------
        //------------------------------------------
        public static void UpdateIsSeen(int ItemID)
        {
            ItemsSqlDataPrvider.Instance.UpdateIsSeen(ItemID);
        }
        //------------------------------------------
        #endregion

        #region --------------CreateItemsPhotoName--------------
        public static string CreateItemsPhotoName(int itemID)
        {
            return "Items_" + itemID.ToString();
        }
        //------------------------------------------
        #endregion

        #region --------------GetItemsPhotoThumbnail--------------
        public static string GetItemsPhotoThumbnail(object itemID, object photoExtension, object ownerName, object ModuleTypeID, object CategoryID)
        {
            return GetItemsPhotoThumbnail(itemID, photoExtension, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight, ownerName,  ModuleTypeID,  CategoryID);
        }
        //------------------------------------------
        #endregion
        #region --------------GetItemsPhotoThumbnail--------------
        public static string GetItemsPhotoThumbnail(object itemID, object photoExtension, int width, int height, object ownerName, object ModuleTypeID, object CategoryID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                //return DCSiteUrls.GetPath_ItemsPhotoNormalThumbs ((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)ItemID)+ CreateItemsPhotoName((int)itemID) + MoversFW.Thumbs.thumbnailExetnsion;
                return "/Thumbnails/Maker1.aspx?file=" + GetItemsPhotoOriginal(itemID, photoExtension, ownerName,  ModuleTypeID,  CategoryID) + "&W=" + width + "&H=" + height;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------GetItemsPhotoBigThumbnail--------------
        public static string GetItemsPhotoBigThumbnail(object itemID, object photoExtension, object ownerName, object ModuleTypeID, object CategoryID)
        {
            int width = SiteSettings.Photos_BigThumnailWidth, height = SiteSettings.Photos_BigThumnailHeight;
            if (photoExtension.ToString().Length > 0)
            {
                return "/Thumbnails/Maker1.aspx?file=" + GetItemsPhotoOriginal(itemID, photoExtension, ownerName,  ModuleTypeID,  CategoryID) + "&W=" + width + "&H=" + height;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------GetItemsPhotoOriginal--------------
        public static string GetItemsPhotoOriginal(object itemID, object photoExtension, object ownerName, object ModuleTypeID, object CategoryID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                return DCSiteUrls.GetPath_ItemsPhotoOriginals ((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)itemID)+ CreateItemsPhotoName((int)itemID) + photoExtension;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetThumbnailPhysicaly--------------
        #region --------------GetItemsPhotoThumbnail--------------
        public static string GetItemsPhotoThumbnailPhysicaly(object itemID, object photoExtension, object ownerName, object ModuleTypeID, object CategoryID)
        {
            return GetItemsPhotoThumbnailPhysicaly(itemID, photoExtension, PhotoTypes.Thumb, ownerName,  ModuleTypeID,  CategoryID);
        }
        //------------------------------------------
        #endregion
        #region --------------GetItemsPhotoThumbnailPhysicaly--------------
        public static string GetItemsPhotoThumbnailPhysicaly(object itemID, object photoExtension, PhotoTypes thumpType, object ownerName, object ModuleTypeID, object CategoryID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                switch (thumpType)
                {
                    case PhotoTypes.Original:
                        return DCSiteUrls.GetPath_ItemsPhotoOriginals ((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)itemID)+ CreateItemsPhotoName((int)itemID) + photoExtension.ToString();
                    case PhotoTypes.Big:
                        return DCSiteUrls.GetPath_ItemsPhotoBigThumbs ((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)itemID)+ CreateItemsPhotoName((int)itemID) + MoversFW.Thumbs.thumbnailExetnsion;
                    case PhotoTypes.Thumb:
                        return DCSiteUrls.GetPath_ItemsPhotoNormalThumbs ((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)itemID)+ CreateItemsPhotoName((int)itemID) + MoversFW.Thumbs.thumbnailExetnsion;
                    case PhotoTypes.MiniThumb:
                        return DCSiteUrls.GetPath_ItemsPhotoNormalThumbs ((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)itemID)+ CreateItemsPhotoName((int)itemID) + MoversFW.Thumbs.thumbnailExetnsion;
                    case PhotoTypes.MicroThumb:
                        return DCSiteUrls.GetPath_ItemsPhotoNormalThumbs ((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)itemID)+ CreateItemsPhotoName((int)itemID) + MoversFW.Thumbs.thumbnailExetnsion;
                    default:
                        return DCSiteUrls.GetPath_ItemsPhotoNormalThumbs ((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)itemID)+ CreateItemsPhotoName((int)itemID) + MoversFW.Thumbs.thumbnailExetnsion;
                }
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------GetItemsPhotoBigThumbnailPhysicaly--------------
        public static string GetItemsPhotoBigThumbnailPhysicaly(object itemID, object photoExtension, object ownerName, object ModuleTypeID, object CategoryID)
        {
            int width = SiteSettings.Photos_BigThumnailWidth, height = SiteSettings.Photos_BigThumnailHeight;
            if (photoExtension.ToString().Length > 0)
            {
                return DCSiteUrls.GetPath_ItemsPhotoBigThumbs ((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)itemID)+ CreateItemsPhotoName((int)itemID) + MoversFW.Thumbs.thumbnailExetnsion;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------GetItemsPhotoOriginalPhysicaly--------------
        public static string GetItemsPhotoOriginalPhysicaly(object itemID, object photoExtension, object ownerName, object ModuleTypeID, object CategoryID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                return DCSiteUrls.GetPath_ItemsPhotoOriginals ((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)itemID)+ CreateItemsPhotoName((int)itemID) + photoExtension;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion

        //------------------------------------------
        #endregion

        #region --------------CreateItemsFileName--------------
        public static string CreateItemsFileName(int itemID)
        {
            return "Items_" + itemID.ToString();
        }
        //------------------------------------------
        #endregion


        #region --------------GetCount--------------
        public static int GetCount(int moduleTypeID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.GetCount(moduleTypeID,-1, langID, OwnerID, -1);
        }
        //------------------------------------------
        public static int GetCount(int moduleTypeID, int categoryID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.GetCount(moduleTypeID, categoryID, langID, OwnerID, -1);
        }
        //------------------------------------------
        public static int GetCount(int moduleTypeID, Languages langID, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetCount(moduleTypeID,-1, langID, OwnerID, -1);
        }
        //------------------------------------------
        public static int GetCount(int moduleTypeID,int categoryID, Languages langID, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetCount(moduleTypeID, categoryID, langID, OwnerID, -1);
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
                int itemID = Convert.ToInt32(HttpContext.Current.Request.QueryString["id"]);
                Languages lang = SiteSettings.GetCurrentLanguage();
                ItemsEntity itemsObject = ItemsFactory.GetObject(itemID, lang, UsersTypes.User, SitesHandler.GetOwnerIDAsGuid());

                if (itemsObject != null)
                {
                    if (pc != null)
                        pc.AddLink(itemsObject.Title, null);
                    if (lblTitle != null)
                        lblTitle.Text = itemsObject.Title;
                }
            }
        }
        #region --------------CreateFileName--------------
        public static string CreateFileName(int ItemID)
        {
            return "Items_" + ItemID.ToString();
        }
        //------------------------------------------
        #endregion

        #region --------------GetUrlOrDetailsPage--------------
        public static string GetUrlOrDetailsPage(object url, object detailsPage)
        {
            string _url = url.ToString();
            string _detailsPage = detailsPage.ToString();
            if (!string.IsNullOrEmpty(_url))
                return _url;
            else
                return _detailsPage;
        }
        //------------------------------------------
        #endregion

        /*
    #region --------------GetUrlOrDetailsOnClick--------------
    public static string GetUrlOrDetailsOnClick(object url, object detailsPage)
    {
        string _url = url.ToString();
        string _detailsPage = detailsPage.ToString();
        if (!string.IsNullOrEmpty(_url))
            return "return popup(this, '')";
        else
            return "";
    }
    //------------------------------------------
    #endregion
    */
        #region ---------------------------RegisterInMailList---------------------------
        //---------------------------------------------------------------------------
        public static void RegisterInMailList(ItemsEntity item)
        {
            ItemsModulesOptions itemModule = ItemsModulesOptions.GetType(item.ModuleTypeID);
            Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
            MailListUsersFactory.RegisterInMailList(item.ModuleTypeID, item.Email, langID, itemModule.MailListAutomaticActivation, itemModule.MailListSendingMailActivation);
        }
        //---------------------------------------------------------------------------
        public static void UnRegisterInMailList(ItemsEntity item)
        {
            MailListUsersFactory.Delete(item.ModuleTypeID, item.Email);
        }
        //---------------------------------------------------------------------------
        public static void UpdateMailListEmail(string oldEmail, ItemsEntity item)
        {
            MailListUsersEntity mlUser = MailListUsersFactory.GetObject(item.ModuleTypeID, oldEmail);
            if (mlUser != null)
            {
                if (!string.IsNullOrEmpty(item.Email))
                {
                    mlUser.Email = item.Email;
                    MailListUsersFactory.Update(mlUser);
                }
                else
                {
                    MailListUsersFactory.Delete(mlUser.UserID);
                }
            }
            else
            {
                ItemsFactory.RegisterInMailList(item);
            }
        }
        //---------------------------------------------------------------------------
        #endregion


        #region ---------------------------RegisterInSMS---------------------------
        //---------------------------------------------------------------------------
        public static void RegisterInSms(ItemsEntity item)
        {
            ItemsModulesOptions itemModule = ItemsModulesOptions.GetType(item.ModuleTypeID);
            Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
            SMSNumbersFactory.RegisterInSms(item.ModuleTypeID, item.Email, langID, itemModule.SmsAutomaticActivation);
        }
        //---------------------------------------------------------------------------
        public static void UnRegisterInSms(ItemsEntity item)
        {
            SMSNumbersFactory.Delete(item.ModuleTypeID, item.Mobile);
        }
        //--------------------
        public static void UnRegisterInSms(int ModuleTypeID, string mobile)
        {
            SMSNumbersFactory.Delete(ModuleTypeID, mobile);
        }
        //---------------------------------------------------------------------------
        public static void UpdateSmsMobileNo(string oldMobileNo, ItemsEntity item)
        {
            SMSNumbersEntity smsUser = SMSNumbersFactory.GetObject(item.ModuleTypeID, oldMobileNo);
            if (smsUser != null)
            {
                if (!string.IsNullOrEmpty(item.Mobile))
                {
                    smsUser.Numbers = item.Mobile;
                    SMSNumbersFactory.Update(smsUser);
                }
                else
                {
                    SMSNumbersFactory.Delete(smsUser.NumID);
                }
            }
            else
            {
                ItemsFactory.RegisterInSms(item);
            }
        }
        //---------------------------------------------------------------------------
        #endregion



        #region --------------GetVisitorsParticipations--------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, -1, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, -1, -1, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, Languages langID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID)
        {
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, -1, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, -1, -1, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetVisitorsParticipations--------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, int categoryID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, categoryID, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, -1, -1, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID)
        {
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, categoryID, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, -1, -1, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        #endregion

        #region --------------GetVisitorsParticipations--------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, int categoryID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, categoryID, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, pageIndex, pageSize, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {

            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, categoryID, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, pageIndex, pageSize, out totalRecords, "", OwnerID, -1);
        }
        //------------------------------------------
        #endregion


        #region --------------GetLast--------------
        public static List<ItemsEntity> GetLast(int moduleTypeID, int count, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return GetLast(moduleTypeID, -1, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLast(int moduleTypeID, int CategoryID, int count, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return GetLast(moduleTypeID, CategoryID, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLast(int moduleTypeID, Languages langID, int count, Guid OwnerID, int AuthorID)
        {

            return GetLast(moduleTypeID, -1, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLast(int moduleTypeID, int CategoryID, Languages langID, int count, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.GetLast(moduleTypeID, CategoryID, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastInMultiModules--------------
        public static List<ItemsEntity> GetLastInMultiModules(string Modules, int count, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return GetLastInMultiModules(Modules, -1, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastInMultiModules(string Modules, int CategoryID, int count, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return GetLastInMultiModules(Modules, CategoryID, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastInMultiModules(string Modules, Languages langID, int count, Guid OwnerID, int AuthorID)
        {

            return GetLastInMultiModules(Modules, -1, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastInMultiModules(string Modules, int CategoryID, Languages langID, int count, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.GetLastInMultiModules(Modules, CategoryID, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastRandom--------------
        public static List<ItemsEntity> GetLastRandom(int moduleTypeID, int count, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetLastRandom(moduleTypeID, -1, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastRandom(int moduleTypeID, int CategoryID, int count, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetLastRandom(moduleTypeID, CategoryID, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastRandom(int moduleTypeID, int CategoryID, Languages langID, int count, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.GetLastRandom(moduleTypeID, CategoryID, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastRandomInMultiModules--------------
        public static List<ItemsEntity> GetLastRandomInMultiModules(string Modules, int count, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetLastRandomInMultiModules(Modules, -1, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastRandomInMultiModules(string Modules, int CategoryID, int count, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetLastRandomInMultiModules(Modules, CategoryID, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetLastRandomInMultiModules(string Modules, int CategoryID, Languages langID, int count, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.GetLastRandomInMultiModules(Modules, CategoryID, langID, count, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllForAdmin--------------
        public static List<ItemsEntity> GetAllForAdmin(int moduleTypeID, Guid OwnerID, int AuthorID)
        {
            //Languages langID = SiteSettings.GetCurrentLanguage();
            return GetAll(moduleTypeID, Languages.Unknowen, false, OwnerID, AuthorID);
        }
        //------------------------------------------------
        public static List<ItemsEntity> GetAllForAdmin(int moduleTypeID, Languages langID, Guid OwnerID, int AuthorID)
        {

            return GetAll(moduleTypeID, langID, false, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllForUser--------------
        public static List<ItemsEntity> GetAllForUser(int moduleTypeID, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return GetAll(moduleTypeID, langID, true, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAllForUser(int moduleTypeID, Languages langID, Guid OwnerID, int AuthorID)
        {
            return GetAll(moduleTypeID, langID, true, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, bool isAvailableCondition, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, -1, isAvailableCondition, -1, -1, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, Languages langID, bool isAvailableCondition, Guid OwnerID, int AuthorID)
        {
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, -1, isAvailableCondition, -1, -1, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllForAdmin--------------
        //------------------------------------------
        public static List<ItemsEntity> GetAllForAdmin(int moduleTypeID, Languages langID, int categoryID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int AuthorID)
        {

            return GetAll(moduleTypeID, langID, categoryID, false, pageIndex, pageSize, out totalRecords, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllForUser--------------
        public static List<ItemsEntity> GetAllForUser(int moduleTypeID, int categoryID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return GetAll(moduleTypeID, langID, categoryID, true, pageIndex, pageSize, out totalRecords, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAllForUser(int moduleTypeID, Languages langID, int categoryID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int AuthorID)
        {

            return GetAll(moduleTypeID, langID, categoryID, true, pageIndex, pageSize, out totalRecords, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, int categoryID, bool isAvailableCondition, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, -1, -1, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, Guid OwnerID, int AuthorID)
        {
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, -1, -1, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAll(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllFlv--------------
        public static List<ItemsEntity> GetAllFlv(int moduleTypeID, int categoryID, bool isAvailableCondition, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, -1, -1, out totalRecords, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAllFlv(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, Guid OwnerID, int AuthorID)
        {
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, -1, -1, out totalRecords, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAllFlv(int moduleTypeID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetAllFlv(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int AuthorID)
        {
            return ItemsSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------CalendarMethods--------------

        #region --------------CalendarGetByMonth--------------
        public static List<ItemsEntity> CalendarGetByMonth(int moduleTypeID, int categoryID, int year, int month, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.CalendarGetByMonth(moduleTypeID, langID, categoryID, year, month, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> CalendarGetByMonth(int moduleTypeID, Languages langID, int categoryID, int year, int month, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.CalendarGetByMonth(moduleTypeID, langID, categoryID, year, month, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------CalendarGetByDay--------------
        public static List<ItemsEntity> CalendarGetByDay(int moduleTypeID, int Day, DateTime From, DateTime To, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.CalendarGetByDay(moduleTypeID, langID, Day, From, To, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> CalendarGetByDay(int moduleTypeID, Languages langID, int Day, DateTime From, DateTime To, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.CalendarGetByDay(moduleTypeID, langID, Day, From, To, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------CalendarGetToDay--------------
        public static List<ItemsEntity> CalendarGetToDay(int moduleTypeID, DateTime Date, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.CalendarGetToDay(moduleTypeID, langID, Date, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> CalendarGetToDay(int moduleTypeID, Languages langID, DateTime Date, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.CalendarGetToDay(moduleTypeID, langID, Date, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #endregion

        #region --------------Search--------------
        public static List<ItemsEntity> Search(int moduleTypeID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> Search(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID, int AuthorID)
        {
            return ItemsSqlDataPrvider.Instance.GetAll(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------Search--------------
        public static List<ItemsEntity> SearchInMultiModules(string modules, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.SearchInMultiModules(modules, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> SearchInMultiModules(string modules, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID, int AuthorID)
        {
            return ItemsSqlDataPrvider.Instance.SearchInMultiModules(modules, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------Search--------------
        public static List<ItemsEntity> SiteSearch(int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.SiteSearch(langID, pageIndex, pageSize, out totalRecords, keywords, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> SiteSearch(Languages langID, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID, int AuthorID)
        {
            return ItemsSqlDataPrvider.Instance.SiteSearch(langID, pageIndex, pageSize, out totalRecords, keywords, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetMain--------------
        public static List<ItemsEntity> GetMain(int moduleTypeID, int count, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count,  true, -1, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetMain(int moduleTypeID, int count, int CategoryID, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count, true, CategoryID, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetMain(int moduleTypeID, int count, bool isMainValue, int CategoryID, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count,  isMainValue,  CategoryID, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetMain(int moduleTypeID, Languages langID, int count, bool isMainValue, int CategoryID, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count,  isMainValue,  CategoryID, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetHaveSpecialOption--------------
        public static List<ItemsEntity> GetHaveSpecialOption(int moduleTypeID, int count, bool specialOptionValue, int CategoryID, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetHaveSpecialOption(moduleTypeID, langID, count, specialOptionValue, CategoryID, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetHaveSpecialOption(int moduleTypeID, Languages langID, int count, bool specialOptionValue, int CategoryID, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.GetHaveSpecialOption(moduleTypeID, langID, count, specialOptionValue, CategoryID, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        

        #region --------------GetLastFlv--------------
        public static List<ItemsEntity> GetLastFlv(Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return ItemsSqlDataPrvider.Instance.GetLastFlv(langID, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetCount--------------
        public static int GetCount(int moduleTypeID, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.GetCount(moduleTypeID,-1, langID, OwnerID, AuthorID);
        }
        //------------------------------------------ 
        public static int GetCount(int moduleTypeID, int categoryID, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.GetCount(moduleTypeID, categoryID, langID, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static int GetCount(int moduleTypeID, Languages langID, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.GetCount(moduleTypeID, -1, langID, OwnerID, AuthorID);
        }
        //------------------------------------------
        public static int GetCount(int moduleTypeID, int categoryID, Languages langID, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.GetCount(moduleTypeID, categoryID, langID, OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetVisitorsParticipations--------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, -1, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, -1, -1, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, Languages langID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID, int AuthorID)
        {
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, -1, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, -1, -1, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetVisitorsParticipations--------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, int categoryID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, categoryID, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, -1, -1, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID, int AuthorID)
        {
            int totalRecords = -1;
            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, categoryID, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, -1, -1, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetVisitorsParticipations--------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, int categoryID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int AuthorID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, categoryID, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, pageIndex, pageSize, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        public static List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int AuthorID)
        {

            return ItemsSqlDataPrvider.Instance.GetVisitorsParticipations(moduleTypeID, langID, categoryID, isAvailableCondition, isAvailable, UserIdProviderKey, ToUserIdProviderKey, UnRepliedCondition, NotSeenCondition, pageIndex, pageSize, out totalRecords, "", OwnerID, AuthorID);
        }
        //------------------------------------------
        #endregion
    }

}