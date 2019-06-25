using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using DCCMSNameSpace;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;


namespace DCCMSNameSpace
{
    public class MessagesFactory
    {




        #region --------------Create--------------
        /// <summary>
        /// Creates Messages object by calling Messages data provider create method.
        /// <example>[Example]bool status=MessagesFactory.Create(msg);.</example>
        /// </summary>
        /// <param name="msg">The Messages object.</param>
        /// <returns>Status of create operation.</returns>
        public static bool Create(MessagesEntity msg,bool createMsgFolder)
        {
            //Insert user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                msg.InsertUserName = username;
            }
            //----------------------------------------------------------
            bool status = MessagesSqlDataPrvider.Instance.Create(msg);
            //-------------------------------------
            if (status && createMsgFolder)
            {
                // Create msg folder
                string folder = DCSiteUrls.GetPath_MessagesDirectory(msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID);
                string folderPhysicalPath = DCServer.MapPath(folder);
                if (!Directory.Exists(folderPhysicalPath))
                {
                    string defaultFolder = DCSiteUrls.GetPath_DefaultMessageFolder();
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
        /// Updates Messages object by calling Messages data provider update method.
        /// <example>[Example]bool status=MessagesFactory.Update(msg);.</example>
        /// </summary>
        /// <param name="msg">The Messages object.</param>
        /// <returns>Status of update operation.</returns>
        public static bool Update(MessagesEntity msg)
        {
            //Update user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                msg.LastUpdateUserName = username;
            }
            //----------------------------------------------------------
            bool status = MessagesSqlDataPrvider.Instance.Update(msg);

            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single Messages object .
        /// <example>[Example]bool status=MessagesFactory.Delete(messageID);.</example>
        /// </summary>
        /// <param name="messageID">The msg id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int messageID)
        {
            MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, SitesHandler.GetOwnerIDAsGuid());
            bool status = MessagesSqlDataPrvider.Instance.Delete(messageID);
            //-------------------------------------
            if (status)
            {
                //delete message folder
                //-------------------------------------
                string folder = DCSiteUrls.GetPath_MessagesDirectory(msg.OwnerName, msg.ModuleTypeID, msg.CategoryID, msg.MessageID);
                string folderPhysicalPath = DCServer.MapPath(folder);
                if (Directory.Exists(folderPhysicalPath))
                {
                    DirectoryInfo dir = new DirectoryInfo(folderPhysicalPath);
                    DcDirectoryManager.DeletDirectory(dir);
                }
            }
            //-------------------------------------
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        #region --------------GetAvailableMessages--------------
        public static List<MessagesEntity> GetAvailable(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, Guid OwnerID)
        {
            int totalRecords = 0;
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID,null, true, false, false, -1, -1, out  totalRecords, OwnerID,"");
        }
        public static List<MessagesEntity> GetAvailable(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID,null, true, false, false, pageIndex, pageSize, out  totalRecords, OwnerID,"");
        }
        //------------------------------------------
        #endregion
        public static List<MessagesEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID)
        {
            int totalRecords = 0;
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, null, isAvailableCondition, UnRepliedCondition, NotSeenCondition, -1, -1, out  totalRecords, OwnerID,"");
        }
        public static List<MessagesEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, null, isAvailableCondition, UnRepliedCondition, NotSeenCondition, pageIndex, pageSize, out  totalRecords, OwnerID,"");
        }
        public static List<MessagesEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, object toUserIdProviderKey, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID)
        {
            int totalRecords = 0;
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, toUserIdProviderKey, isAvailableCondition, UnRepliedCondition, NotSeenCondition, -1, -1, out  totalRecords, OwnerID,"");
        }
        public static List<MessagesEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, object toUserIdProviderKey, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {

               return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, toUserIdProviderKey, isAvailableCondition, UnRepliedCondition, NotSeenCondition, pageIndex, pageSize, out  totalRecords, OwnerID,"");
        }
        #region --------------GetAvailableMessages--------------
        public static List<MessagesEntity> GetAvailable(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, Guid OwnerID, string keywords)
        {
            int totalRecords = 0;
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID,null, true, false, false, -1, -1, out  totalRecords, OwnerID, keywords);
        }
        public static List<MessagesEntity> GetAvailable(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, string keywords)
        {
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID,null, true, false, false, pageIndex, pageSize, out  totalRecords, OwnerID, keywords);
        }
        //------------------------------------------
        #endregion
        public static List<MessagesEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID, string keywords)
        {
            int totalRecords = 0;
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, null, isAvailableCondition, UnRepliedCondition, NotSeenCondition, -1, -1, out  totalRecords, OwnerID, keywords);
        }
        public static List<MessagesEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, string keywords)
        {
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, null, isAvailableCondition, UnRepliedCondition, NotSeenCondition, pageIndex, pageSize, out  totalRecords, OwnerID, keywords);
        }
        public static List<MessagesEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, object toUserIdProviderKey, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID, string keywords)
        {
            int totalRecords = 0;
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, toUserIdProviderKey, isAvailableCondition, UnRepliedCondition, NotSeenCondition, -1, -1, out  totalRecords, OwnerID, keywords);
        }
        public static List<MessagesEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, object toUserIdProviderKey, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, string keywords)
        {

            //
            return MessagesSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, toUserIdProviderKey, isAvailableCondition, UnRepliedCondition, NotSeenCondition, pageIndex, pageSize, out  totalRecords, OwnerID, keywords);
        }

        //------------------------------------------
        #endregion

        
        #region --------------GetNew--------------
        public static List<MessagesEntity> GetNew(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, Guid OwnerID)
        {
            int totalRecords = 0;
            return GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, false, false, true, -1, -1, out  totalRecords, OwnerID);
        }
        public static List<MessagesEntity> GetNew(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {

            return GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, false, false, true, pageIndex, pageSize, out  totalRecords, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetUnReplied--------------
        public static List<MessagesEntity> GetUnReplied(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, Guid OwnerID)
        {
            int totalRecords = 0;
            return GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, false, true, false, -1, -1, out  totalRecords, OwnerID);
        }
        public static List<MessagesEntity> GetUnReplied(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {

            return GetAll(ModuleTypeID, CategoryID, LangID, type, ToItemID, false, true, false, pageIndex, pageSize, out  totalRecords, OwnerID);
        }
        //------------------------------------------
        #endregion

        

        #region --------------ExportData--------------
        public static List<MessagesEntity> ExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID)
        {
            int totalRecords = 0;
            return ExportData(ModuleTypeID, CategoryID, LangID, type, ToItemID, null, isAvailableCondition, UnRepliedCondition, NotSeenCondition, -1, -1, out  totalRecords, OwnerID);
        }
        public static List<MessagesEntity> ExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            return ExportData(ModuleTypeID, CategoryID, LangID, type, ToItemID, null, isAvailableCondition, UnRepliedCondition, NotSeenCondition, pageIndex, pageSize, out  totalRecords, OwnerID);
        }
        public static List<MessagesEntity> ExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, object toUserIdProviderKey, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, Guid OwnerID)
        {
            int totalRecords = 0;
            return ExportData(ModuleTypeID, CategoryID, LangID, type, ToItemID, toUserIdProviderKey, isAvailableCondition, UnRepliedCondition, NotSeenCondition, -1, -1, out  totalRecords, OwnerID);
        }
        public static List<MessagesEntity> ExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, object toUserIdProviderKey, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            return MessagesSqlDataPrvider.Instance.ExportData(ModuleTypeID, CategoryID, LangID, type, ToItemID, toUserIdProviderKey, isAvailableCondition, UnRepliedCondition, NotSeenCondition, pageIndex, pageSize, out  totalRecords, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetNewToExportData--------------
        public static List<MessagesEntity> GetNewToExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, Guid OwnerID)
        {
            int totalRecords = 0;
            return ExportData(ModuleTypeID, CategoryID, LangID, type, ToItemID, false, false, true, -1, -1, out  totalRecords, OwnerID);
        }
        public static List<MessagesEntity> GetNewToExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {

            return ExportData(ModuleTypeID, CategoryID, LangID, type, ToItemID, false, false, true, pageIndex, pageSize, out  totalRecords, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetUnRepliedToExportData--------------
        public static List<MessagesEntity> GetUnRepliedToExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, Guid OwnerID)
        {
            int totalRecords = 0;
            return ExportData(ModuleTypeID, CategoryID, LangID, type, ToItemID, false, true, false, -1, -1, out  totalRecords, OwnerID);
        }
        public static List<MessagesEntity> GetUnRepliedToExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {

            return ExportData(ModuleTypeID, CategoryID, LangID, type, ToItemID, false, true, false, pageIndex, pageSize, out  totalRecords, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAvailableMessagesToExportData--------------
        public static List<MessagesEntity> GetAvailableToExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, Guid OwnerID)
        {
            int totalRecords = 0;
            return ExportData(ModuleTypeID, CategoryID, LangID, type, ToItemID, true, false, false, -1, -1, out  totalRecords, OwnerID);
        }
        public static List<MessagesEntity> GetAvailableToExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            return ExportData(ModuleTypeID, CategoryID, LangID, type, ToItemID, true, false, false, pageIndex, pageSize, out  totalRecords, OwnerID);
        }
        //------------------------------------------
        #endregion


        #region --------------GetMessagesObject--------------
        public static MessagesEntity GetMessagesObject(int messageID, UsersTypes viewerType, Guid OwnerID)
        {
            MessagesEntity msg = MessagesSqlDataPrvider.Instance.GetMessagesObject(messageID, viewerType, OwnerID);

            //return the object
            return msg;
        }
        //------------------------------------------
        #endregion


        #region --------------GetLastFlv--------------
        public static List<MessagesEntity> GetLastFlv(Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return MessagesSqlDataPrvider.Instance.GetLastFlv(langID, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------SearchInMultiModules--------------
        public static List<MessagesEntity> SearchInMultiModules(string modules, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return MessagesSqlDataPrvider.Instance.SearchInMultiModules(modules, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID);
        }
        //------------------------------------------
        public static List<MessagesEntity> SearchInMultiModules(string modules, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keywords, Guid OwnerID)
        {
            return MessagesSqlDataPrvider.Instance.SearchInMultiModules(modules, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, keywords, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetCount--------------
        public static int GetCount(int moduleTypeID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();

            return MessagesSqlDataPrvider.Instance.GetCount(moduleTypeID, langID, OwnerID);
        }
        //------------------------------------------
        public static int GetCount(int moduleTypeID, Languages langID, Guid OwnerID)
        {

            return MessagesSqlDataPrvider.Instance.GetCount(moduleTypeID, langID, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLast--------------
        public static List<MessagesEntity> GetLast(int moduleTypeID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return MessagesSqlDataPrvider.Instance.GetLast(moduleTypeID, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<MessagesEntity> GetLast(int moduleTypeID, Languages langID, int count, Guid OwnerID)
        {

            return MessagesSqlDataPrvider.Instance.GetLast(moduleTypeID, langID, count, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastRandom--------------
        public static List<MessagesEntity> GetLastRandom(int moduleTypeID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return MessagesSqlDataPrvider.Instance.GetLastRandom(moduleTypeID, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<MessagesEntity> GetLastRandom(int moduleTypeID, Languages langID, int count, Guid OwnerID)
        {

            return MessagesSqlDataPrvider.Instance.GetLastRandom(moduleTypeID, langID, count, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastInMultiModules--------------
        public static List<MessagesEntity> GetLastInMultiModules(string Modules, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return MessagesSqlDataPrvider.Instance.GetLastInMultiModules(Modules, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<MessagesEntity> GetLastInMultiModules(string Modules, Languages langID, int count, Guid OwnerID)
        {

            return MessagesSqlDataPrvider.Instance.GetLastInMultiModules(Modules, langID, count, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastRandomInMultiModules--------------
        public static List<MessagesEntity> GetLastRandomInMultiModules(string Modules, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return MessagesSqlDataPrvider.Instance.GetLastRandomInMultiModules(Modules, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<MessagesEntity> GetLastRandomInMultiModules(string Modules, Languages langID, int count, Guid OwnerID)
        {

            return MessagesSqlDataPrvider.Instance.GetLastRandomInMultiModules(Modules, langID, count, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetMain--------------
        public static List<MessagesEntity> GetMain(int moduleTypeID, int count, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return MessagesSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count, OwnerID);
        }
        //------------------------------------------
        public static List<MessagesEntity> GetMain(int moduleTypeID, Languages langID, int count, Guid OwnerID)
        {

            return MessagesSqlDataPrvider.Instance.GetMain(moduleTypeID, langID, count, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetNotMain--------------
        public static List<MessagesEntity> GetNotMain(int moduleTypeID, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return MessagesSqlDataPrvider.Instance.GetNotMain(moduleTypeID, langID, OwnerID);
        }
        //------------------------------------------
        public static List<MessagesEntity> GetNotMain(int moduleTypeID, Languages langID, Guid OwnerID)
        {
            return MessagesSqlDataPrvider.Instance.GetNotMain(moduleTypeID, langID, OwnerID);
        }
        //------------------------------------------

        #endregion

        #region --------------Rate--------------
        public static void Rate(int messageID, int rate)
        {
            MessagesSqlDataPrvider.Instance.Rate(messageID, rate);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllFlv--------------
        public static List<MessagesEntity> GetAllFlv(int moduleTypeID, int categoryID, bool isAvailableCondition, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            int totalRecords = -1;
            return MessagesSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, -1, -1, out totalRecords, OwnerID);
        }
        //------------------------------------------
        public static List<MessagesEntity> GetAllFlv(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, Guid OwnerID)
        {
            int totalRecords = -1;
            return MessagesSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, -1, -1, out totalRecords, OwnerID);
        }
        //------------------------------------------
        public static List<MessagesEntity> GetAllFlv(int moduleTypeID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            return MessagesSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, OwnerID);
        }
        //------------------------------------------
        public static List<MessagesEntity> GetAllFlv(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            return MessagesSqlDataPrvider.Instance.GetAllFlv(moduleTypeID, langID, categoryID, isAvailableCondition, pageIndex, pageSize, out totalRecords, OwnerID);
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
                int messageID = Convert.ToInt32(HttpContext.Current.Request.QueryString["id"]);
                Languages lang = SiteSettings.GetCurrentLanguage();
                MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, SitesHandler.GetOwnerIDAsGuid());

                if (msg != null)
                {
                    if (pc != null)
                        pc.AddLink(msg.Title, null);
                    if (lblTitle != null)
                        lblTitle.Text = msg.Title;
                }
            }
        }


        #region --------------CreatePhotoName--------------
        public static string CreatePhotoName(int messageID)
        {
            return "Message_Photo_" + messageID.ToString();
        }
        //------------------------------------------
        #endregion

        #region --------------GetPhotoThumbnail--------------
        /*public static string GetPhotoThumbnail(object messageID, object photoExtension)
	{
		return GetPhotoThumbnail( messageID,  photoExtension , 110,85)
	}*/
        //------------------------------------------
        #endregion

        #region --------------GetPhotoThumbnail--------------
        public static string GetPhotoThumbnail(object messageID, object photoExtension, int width, int height, object ownerName, object ModuleTypeID, object CategoryID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                return "/Thumbnails/Maker1.aspx?file=" + GetPhotoOriginal(messageID, photoExtension, ownerName,  ModuleTypeID,  CategoryID) + "&W=" + width + "&H=" + height;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------GetPhotoBigThumbnail--------------
        public static string GetPhotoBigThumbnail(object messageID, object photoExtension, object ownerName, object ModuleTypeID, object CategoryID)
        {
            int width = SiteSettings.Photos_BigThumnailWidth, height = SiteSettings.Photos_BigThumnailHeight;
            if (photoExtension.ToString().Length > 0)
            {
                return "/Thumbnails/Maker1.aspx?file=" + GetPhotoOriginal(messageID, photoExtension, ownerName, ModuleTypeID,  CategoryID) + "&W=" + width + "&H=" + height;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------GetPhotoOriginal--------------
        public static string GetPhotoOriginal(object messageID, object photoExtension, object ownerName,object ModuleTypeID, object CategoryID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                return DCSiteUrls.GetPath_MessagesPhotoOriginals((string)ownerName, (int)ModuleTypeID, (int)CategoryID,(int)messageID) + CreatePhotoName((int)messageID) + photoExtension;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------CreateFileName--------------
        public static string CreateFileName(int messageID)
        {
            return "Message_File_" + messageID.ToString();
        }
        //------------------------------------------
        #endregion


        #region ---------------------------RegisterInMailList---------------------------
        //---------------------------------------------------------------------------
        public static void RegisterInMailList(MessagesEntity msg)
        {
            MessagesModuleOptions msgModule = MessagesModuleOptions.GetType(msg.ModuleTypeID);
            Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
            MailListUsersFactory.RegisterInMailList(msg.ModuleTypeID, msg.EMail, langID, msgModule.MailListAutomaticActivation, msgModule.MailListSendingMailActivation);
        }
        //---------------------------------------------------------------------------
        public static void UnRegisterInMailList(MessagesEntity msg)
        {
            MailListUsersFactory.Delete(msg.ModuleTypeID, msg.EMail);
        }
        //---------------------------------------------------------------------------
        public static void UpdateMailListEmail(string oldEmail, MessagesEntity msg)
        {
            MailListUsersEntity mlUser = MailListUsersFactory.GetObject(msg.ModuleTypeID, oldEmail);
            if (mlUser != null)
            {
                if (!string.IsNullOrEmpty(msg.EMail))
                {
                    mlUser.Email = msg.EMail;
                    MailListUsersFactory.Update(mlUser);
                }
                else
                {
                    MailListUsersFactory.Delete(mlUser.UserID);
                }
            }
            else
            {
                MessagesFactory.RegisterInMailList(msg);
            }
        }
        //---------------------------------------------------------------------------
        #endregion


        #region ---------------------------RegisterInSms---------------------------
        //---------------------------------------------------------------------------
        public static void RegisterInSms(MessagesEntity msg)
        {
            MessagesModuleOptions msgModule = MessagesModuleOptions.GetType(msg.ModuleTypeID);
            Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
            SMSNumbersFactory.RegisterInSms(msg.ModuleTypeID, msg.Mobile, langID, msgModule.SmsAutomaticActivation);
        }
        //---------------------------------------------------------------------------
        public static void UnRegisterInSms(MessagesEntity msg)
        {
            SMSNumbersFactory.Delete(msg.ModuleTypeID, msg.Mobile);
        }
        //---------------------------------------------------------------------------
        public static void UpdateSmsMobileNo(string oldMobile, MessagesEntity msg)
        {
            SMSNumbersEntity smsUser = SMSNumbersFactory.GetObject(msg.ModuleTypeID, oldMobile);
            if (smsUser != null)
            {
                if (!string.IsNullOrEmpty(msg.Mobile))
                {
                    smsUser.Numbers = msg.Mobile;
                    SMSNumbersFactory.Update(smsUser);
                }
                else
                {
                    SMSNumbersFactory.Delete(smsUser.NumID);
                }
            }
            else
            {
                MessagesFactory.RegisterInSms(msg);
            }
        }
        //---------------------------------------------------------------------------
        #endregion


        #region --------------ReArrangeTable--------------
        //---------------------------------------------------------
        //ReArrangeTable
        //---------------------------------------------------------
        public static void ReArrangeTable(MessagesModuleOptions currentModule, HtmlTable tblControls)
        {
            string asdArray = currentModule.TableRowsPriorities;
            if (!string.IsNullOrEmpty(asdArray))
            {
                //----------------------------------------------------
                string[] Arr = asdArray.Split(new char[] { ',' });
                ArrayList teempRowsCollection = new ArrayList();
                HtmlTableRow tr;
                int index;
                ArrayList arrangedRows = new ArrayList();
                string id1 = "";
                //----------------------------------------------------
                for (int i = 0; i < Arr.Length; i++)
                {
                    index = Convert.ToInt32(Arr[i]) - 1;
                    tr = tblControls.Rows[index];
                    teempRowsCollection.Add(tr);
                    arrangedRows.Add(index);
                    id1 = tr.ID;
                }
                //----------------------------------------------------
                bool existsInArrangedRows = false;
                for (int i = 0; i < tblControls.Rows.Count; i++)
                {
                    for (int b = 0; b < arrangedRows.Count; b++)
                    {
                        if ((int)arrangedRows[b] == i)
                        {
                            existsInArrangedRows = true;
                            break;
                        }
                    }
                    if (!existsInArrangedRows)
                    {
                        teempRowsCollection.Add(tblControls.Rows[i]);
                    }
                    existsInArrangedRows = false;
                }
                //----------------------------------------------------
                tblControls.Rows.Clear();
                for (int i = 0; i < teempRowsCollection.Count; i++)
                {
                    tr = (HtmlTableRow)teempRowsCollection[i];
                    tblControls.Rows.Add(tr);
                }
                //----------------------------------------------------
            }
        }

        //--------------------------------------------------------
        #endregion

    }

}