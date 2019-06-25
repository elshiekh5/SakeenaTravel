using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using DCCMSNameSpace;
using System.IO;


namespace DCCMSNameSpace
{
    public class UsersDataFactory
    {
        #region --------------Create--------------
        /// <summary>
        /// Creates UsersData object by calling UsersData data provider create method.
        /// <example>[Example]bool status=UsersDataFactory.Create(usersDataObject);.</example>
        /// </summary>
        /// <param name="usersDataObject">The UsersData object.</param>
        /// <returns>Status of create operation.</returns>
        public static bool Create(MembershipUser user,UsersDataEntity usersDataObject)
        {

            bool status =UsersDataSqlDataPrvider.Instance.Create(usersDataObject);
            if (status)
            {
                UsersDataFactory.CreateUserFolder(user, usersDataObject);
                //------------------------------------------------------------------------
            }
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Updates UsersData object by calling UsersData data provider update method.
        /// <example>[Example]bool status=UsersDataFactory.Update(usersDataObject);.</example>
        /// </summary>
        /// <param name="usersDataObject">The UsersData object.</param>
        /// <returns>Status of update operation.</returns>
        public static bool Update(UsersDataEntity usersDataObject)
        {
            bool status = UsersDataSqlDataPrvider.Instance.Update(usersDataObject);

            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single UsersData object .
        /// <example>[Example]bool status=UsersDataFactory.Delete(userProfileID);.</example>
        /// </summary>
        /// <param name="userProfileID">The usersDataObject id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(Guid userID)
        {
            UsersDataEntity usersDataObject = GetUsersDataObject(userID, SitesHandler.GetOwnerIDAsGuid());
            bool status = UsersDataSqlDataPrvider.Instance.Delete(userID);
            if (status)
            {
                MembershipUser user = Membership.GetUser(userID);
                Membership.DeleteUser(user.UserName, true);
                //------------------------------------------------
                //DeleteFiles(usersDataObject);
                //------------------------------------------------
                UsersDataFactory.DeleteUserFolder(user, usersDataObject);
                //------------------------------------------------------------------------
            }
            return status;
        }
        //------------------------------------------
        #endregion


        /*
        public static void DeleteFiles(UsersDataEntity userdata)
        {
            if (userdata != null)
            {
                if (UsersDataFactory.IsSubSubSiteOwner(userdata.UserType))
                {
                    string subSiteFolder = DCSiteUrls.GetPath_SubSiteUploadFolder(userdata.UserName);
                    string subSiteFolderPhysicalPath = DCServer.MapPath(subSiteFolder);
                    if (Directory.Exists(subSiteFolderPhysicalPath))
                    {
                        DirectoryInfo dir = new DirectoryInfo(subSiteFolderPhysicalPath);
                        DcDirectoryManager.DeletDirectory(dir);
                    }
                }
                else
                {
                    string subSiteFolder = DCSiteUrls.GetPath_UserDataDirectory(userdata.OwnerName, userdata.ModuleTypeID, userdata.CategoryID, userdata.UserProfileID);
                    string subSiteFolderPhysicalPath = DCServer.MapPath(subSiteFolder);
                    if (Directory.Exists(subSiteFolderPhysicalPath))
                    {
                        DirectoryInfo dir = new DirectoryInfo(subSiteFolderPhysicalPath);
                        DcDirectoryManager.DeletDirectory(dir);
                    }
                }
            }
            //HttpContext context = HttpContext.Current;
            //if (userdata != null && !string.IsNullOrEmpty(userdata.PhotoExtension))
            //{
            //    //Delete old original photo
            //    File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoOriginals(userdata.OwnerName, userdata.ModuleTypeID, userdata.CategoryID,userdata.UserProfileID)) + userdata.Photo);
            //    //Delete old Thumbnails
            //    File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoNormalThumbs(userdata.OwnerName, userdata.ModuleTypeID, userdata.CategoryID,userdata.UserProfileID)) + UsersDataFactory.CreateUserPhotoName(userdata.UserProfileID) + MoversFW.Thumbs.thumbnailExetnsion);
            //    File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoBigThumbs(userdata.OwnerName, userdata.ModuleTypeID, userdata.CategoryID,userdata.UserProfileID)) + UsersDataFactory.CreateUserPhotoName(userdata.UserProfileID) + MoversFW.Thumbs.thumbnailExetnsion);
            //    //------------------------------------------------
            //}
        }
        */
        #region --------------IncreaseVisits--------------

        public static void IncreaseVisits(Guid userID)
        {

             UsersDataSqlDataPrvider.Instance.IncreaseVisits(userID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<UsersDataEntity> GetAllByRole(string roleName, Guid OwnerID)
        {
            int totalRecords = -1;
            return UsersDataSqlDataPrvider.Instance.GetAll((int)StandardItemsModuleTypes.UnKnowen, -1, Languages.Unknowen, "", roleName, -1, -1, out totalRecords, OwnerID, true,"");
        }
        public static List<UsersDataEntity> GetAllByRole(string roleName, Guid OwnerID, bool IsAvailableCondition)
        {
            int totalRecords = -1;
            return UsersDataSqlDataPrvider.Instance.GetAll((int)StandardItemsModuleTypes.UnKnowen, -1, Languages.Unknowen, "", roleName, -1, -1, out totalRecords, OwnerID, IsAvailableCondition,"");
        }
        public static List<UsersDataEntity> GetAllByRole(int ModuleTypeID, int CategoryID, Languages LangID, string roleName, Guid OwnerID, bool IsAvailableCondition)
        {
            int totalRecords = -1;
            return UsersDataSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, "", roleName, -1, -1, out totalRecords, OwnerID, IsAvailableCondition,"");
        }
        public static List<UsersDataEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, Guid OwnerID, bool IsAvailableCondition)
        {
            int totalRecords = -1;
            return UsersDataSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, "", "", -1, -1, out totalRecords, OwnerID, IsAvailableCondition,"");
        }


        public static List<UsersDataEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, bool IsAvailableCondition)
        {

            return UsersDataSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, "", "", pageIndex, pageSize, out totalRecords, OwnerID, IsAvailableCondition,"");
        }
        public static List<UsersDataEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, string conditionStatement, string roleName, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, bool IsAvailableCondition)
        {

            return UsersDataSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, conditionStatement, roleName, pageIndex, pageSize, out totalRecords, OwnerID, IsAvailableCondition,"");
        }
        //------------------------------------------
        public static List<UsersDataEntity> GetAllByRole(string roleName, Guid OwnerID, string keyWord)
        {
            int totalRecords = -1;
            return UsersDataSqlDataPrvider.Instance.GetAll((int)StandardItemsModuleTypes.UnKnowen, -1, Languages.Unknowen, "", roleName, -1, -1, out totalRecords, OwnerID, true,  keyWord);
        }
        public static List<UsersDataEntity> GetAllByRole(string roleName, Guid OwnerID, bool IsAvailableCondition, string keyWord)
        {
            int totalRecords = -1;
            return UsersDataSqlDataPrvider.Instance.GetAll((int)StandardItemsModuleTypes.UnKnowen, -1, Languages.Unknowen, "", roleName, -1, -1, out totalRecords, OwnerID, IsAvailableCondition,  keyWord);
        }
        public static List<UsersDataEntity> GetAllByRole(int ModuleTypeID, int CategoryID, Languages LangID, string roleName, Guid OwnerID, bool IsAvailableCondition,  string keyWord)
        {
            int totalRecords = -1;
            return UsersDataSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, "", roleName, -1, -1, out totalRecords, OwnerID, IsAvailableCondition,  keyWord);
        }
        public static List<UsersDataEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, Guid OwnerID, bool IsAvailableCondition, string keyWord)
        {
            int totalRecords = -1;
            return UsersDataSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, "", "", -1, -1, out totalRecords, OwnerID, IsAvailableCondition,  keyWord);
        }


        public static List<UsersDataEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, bool IsAvailableCondition, string keyWord)
        {

            return UsersDataSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, "", "", pageIndex, pageSize, out totalRecords, OwnerID, IsAvailableCondition,  keyWord);
        }
        public static List<UsersDataEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, string conditionStatement, string roleName, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, bool IsAvailableCondition, string keyWord)
        {

            return UsersDataSqlDataPrvider.Instance.GetAll(ModuleTypeID, CategoryID, LangID, conditionStatement, roleName, pageIndex, pageSize, out totalRecords, OwnerID, IsAvailableCondition, keyWord);
        }
        //------------------------------------------
        #endregion

        #region --------------GetLast--------------
        public static List<UsersDataEntity> GetLast(int ModuleTypeID, int CategoryID, Languages LangID, string conditionStatement, string roleName, Guid OwnerID, int count)
        {
            int totalRecords = -1;
            return UsersDataSqlDataPrvider.Instance.GetLast(ModuleTypeID, CategoryID, LangID, conditionStatement, roleName, -1, -1, out totalRecords, OwnerID, count);
        }
        //------------------------------------------
        public static List<UsersDataEntity> GetLast(int ModuleTypeID, int CategoryID, Languages LangID, string conditionStatement, string roleName, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int count)
        {

            return UsersDataSqlDataPrvider.Instance.GetLast(ModuleTypeID, CategoryID, LangID, conditionStatement, roleName, pageIndex, pageSize, out totalRecords, OwnerID, count);
        }
        //------------------------------------------
        #endregion

        #region --------------GetUsersDataObject--------------
        public static UsersDataEntity GetUsersDataObject(Guid userID, Guid OwnerID)
        {
            UsersDataEntity usersDataObject = UsersDataSqlDataPrvider.Instance.GetUsersDataObject(userID, OwnerID);

            //return the object
            return usersDataObject;
        }
        //------------------------------------------
        #endregion

        #region --------------GetCount--------------
        //----------------------------------------------------------

        public static int GetCount(int ModuleTypeID, int CategoryID, Languages LangID, Guid OwnerID)
        {

            return UsersDataSqlDataPrvider.Instance.GetCount(ModuleTypeID, CategoryID, LangID, "", "", OwnerID);
        }
        //----------------------------------------------------------
        public static int GetCount(int ModuleTypeID, int CategoryID, Languages LangID, string roleName, Guid OwnerID)
        {

            return UsersDataSqlDataPrvider.Instance.GetCount(ModuleTypeID, CategoryID, LangID, "", roleName, OwnerID);
        }
        //------------------------------------------
        public static int GetCount(int ModuleTypeID, int CategoryID, Languages LangID, string conditionStatement, string roleName, Guid OwnerID)
        {

            return UsersDataSqlDataPrvider.Instance.GetCount(ModuleTypeID, CategoryID, LangID, conditionStatement, roleName, OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------RetrivePassword--------------
        public static string RetrivePassword(string UserName)
        {

            return UsersDataSqlDataPrvider.Instance.RetrivePassword(UserName);
        }
        //------------------------------------------
        #endregion

        //---------------------------------------------------------------------------
        public static bool IsCurrentUserTheAdmin()
        {
            if (Roles.IsUserInRole(DCRoles.SiteSubAdminsRoles) || Roles.IsUserInRole(DCRoles.SiteOverallAdminsRoles))
                return true;
            else
                return false;
        }
        //---------------------------------------------------------------------------
        //---------------------------------------------------------------------------
        public static bool IsSubSubSiteOwner(UsersTypes userType)
        {
            if (userType == UsersTypes.SiteOwner)
                return true;
            else
                return false;
        }
        //---------------------------------------------------------------------------
        //-----------------------------------------------------------

        #region --------------CreateUserPhotoName--------------
        public static string CreateUserPhotoName(int UserProfileID)
        {
            return "User_Photo_" + UserProfileID.ToString();
        }
        //------------------------------------------
        #endregion

        #region --------------GetUserPhotoThumbnail--------------
        /*public static string GetUserPhotoThumbnail(object UserProfileID, object photoExtension)
	{
		return GetUserPhotoThumbnail( UserProfileID,  photoExtension , 110,85)
	}*/
        //------------------------------------------
        #endregion
        #region --------------GetUserPhotoThumbnail--------------
        public static string GetUserPhotoThumbnail(object UserProfileID, object photoExtension, int width, int height, object ownerName, object ModuleTypeID, object CategoryID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                //return SiteSettings.UserPhotoNormalThumbs + CreateUserPhotoName((int)UserProfileID) + MoversFW.Thumbs.thumbnailExetnsion;
                return "/Thumbnails/Maker1.aspx?file=" + GetUserPhotoOriginal(UserProfileID, photoExtension, ownerName,  ModuleTypeID,  CategoryID) + "&W=" + width + "&H=" + height;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------GetUserPhotoBigThumbnail--------------
        public static string GetUserPhotoBigThumbnail(object UserProfileID, object photoExtension, object ownerName, object ModuleTypeID, object CategoryID)
        {
            int width = SiteSettings.Photos_BigThumnailWidth, height = SiteSettings.Photos_BigThumnailHeight;
            if (photoExtension.ToString().Length > 0)
            {
                return "/Thumbnails/Maker1.aspx?file=" + GetUserPhotoOriginal(UserProfileID, photoExtension, ownerName,  ModuleTypeID,  CategoryID) + "&W=" + width + "&H=" + height;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------GetUserPhotoOriginal--------------
        public static string GetUserPhotoOriginal(object UserProfileID, object photoExtension,object ownerName, object ModuleTypeID, object CategoryID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                return DCSiteUrls.GetPath_UserDataPhotoOriginals((string)ownerName, (int)ModuleTypeID, (int)CategoryID,(int)UserProfileID) + CreateUserPhotoName((int)UserProfileID) + photoExtension;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------CreateUserFileName--------------
        public static string CreateUserFileName(int UserProfileID)
        {
            return "User_File_" + UserProfileID.ToString();
        }
        //------------------------------------------
        #endregion

        #region ---------------------------RegisterInMailList---------------------------
        //---------------------------------------------------------------------------
        public static void RegisterInMailList(UsersDataEntity usersDataObject)
        {
            UsersDataGlobalOptions userDataModule = UsersDataGlobalOptions.GetType(usersDataObject.ModuleTypeID);
            Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
            MailListUsersFactory.RegisterInMailList(userDataModule.ModuleTypeID, usersDataObject.Email, langID, userDataModule.MailListAutomaticActivation, userDataModule.MailListSendingMailActivation);
        }
        //---------------------------------------------------------------------------
        public static void UnRegisterInMailList(UsersDataEntity usersDataObject)
        {
            MailListUsersFactory.Delete(usersDataObject.ModuleTypeID, usersDataObject.Email);

        }
        //---------------------------------------------------------------------------
        public static void UpdateMailListEmail(string oldEmail, UsersDataEntity usersDataObject)
        {
            MailListUsersEntity mlUser = MailListUsersFactory.GetObject(usersDataObject.ModuleTypeID, oldEmail);
            if (mlUser != null)
            {
                if (!string.IsNullOrEmpty(usersDataObject.Email))
                {
                    mlUser.Email = usersDataObject.Email;
                    MailListUsersFactory.Update(mlUser);
                }
                else
                {
                    MailListUsersFactory.Delete(mlUser.UserID);
                }
            }
            else
            {
                UsersDataFactory.RegisterInMailList(usersDataObject);
            }
        }
        //---------------------------------------------------------------------------
        #endregion

        #region ---------------------------RegisterInSms---------------------------
        //---------------------------------------------------------------------------
        public static void RegisterInSms(UsersDataEntity usersDataObject)
        {
            UsersDataGlobalOptions userDataModule = UsersDataGlobalOptions.GetType(usersDataObject.ModuleTypeID);
            Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
            SMSNumbersFactory.RegisterInSms(userDataModule.ModuleTypeID, usersDataObject.Mobile, langID, userDataModule.SmsAutomaticActivation);
        }
        //---------------------------------------------------------------------------
        public static void UnRegisterInSms(UsersDataEntity usersDataObject)
        {
            SMSNumbersFactory.Delete(usersDataObject.ModuleTypeID, usersDataObject.Mobile);

        }
        //---------------------------------------------------------------------------
        public static void UpdateSmsMobileNo(string oldMobile, UsersDataEntity usersDataObject)
        {
            SMSNumbersEntity smsUser = SMSNumbersFactory.GetObject(usersDataObject.ModuleTypeID, oldMobile);
            if (smsUser != null)
            {
                if (!string.IsNullOrEmpty(usersDataObject.Mobile))
                {
                    smsUser.Numbers = usersDataObject.Mobile;
                    SMSNumbersFactory.Update(smsUser);
                }
                else
                {
                    SMSNumbersFactory.Delete(smsUser.NumID);
                }
            }
            else
            {
                UsersDataFactory.RegisterInSms(usersDataObject);
            }
        }
        //---------------------------------------------------------------------------
        #endregion
        public static void ConfigureSubSiteIfExist(MembershipUser user)
        {
            if (user != null)
            {
                UsersDataEntity userdata = UsersDataFactory.GetUsersDataObject((Guid)user.ProviderUserKey, Guid.Empty);
                CreateUserFolder(user, userdata);
            }
        }
        public static void ConfigureSubSiteIfExist(UsersDataEntity userdata)
        {
            if (userdata != null)
            {
                MembershipUser user = Membership.GetUser(userdata.UserId);
                CreateUserFolder(user, userdata);
            }
        }
        public static void CreateUserFolder(MembershipUser user, UsersDataEntity userdata)
        {
            if (user != null && userdata != null)
            {
                if (user.IsApproved && UsersDataFactory.IsSubSubSiteOwner(userdata.UserType))
                {
                    string subSiteFolder = DCSiteUrls.GetPath_SubSiteUploadFolder(user.UserName);
                    string subSiteFolderPhysicalPath = DCServer.MapPath(subSiteFolder);
                    if (!Directory.Exists(subSiteFolderPhysicalPath))
                    {
                        string subSiteEmptyFolderPhysicalPath = DCServer.MapPath(DCSiteUrls.GetPath_DefaultSubSiteFolder());
                        DirectoryInfo diSource = new DirectoryInfo(subSiteEmptyFolderPhysicalPath);
                        DirectoryInfo diTarget = new DirectoryInfo(subSiteFolderPhysicalPath);
                        DcDirectoryManager.CopyAll(diSource, diTarget);
                    }
                }
                else
                {
                    // Create msg folder
                    string folder = DCSiteUrls.GetPath_UserDataDirectory(userdata.OwnerName, userdata.ModuleTypeID, userdata.CategoryID, userdata.UserProfileID);
                    string folderPhysicalPath = DCServer.MapPath(folder);
                    if (!Directory.Exists(folderPhysicalPath))
                    {
                        string defaultFolder = DCSiteUrls.GetPath_DefaultUserDataFolder();
                        string defaultFolderPhysicalPath = DCServer.MapPath(defaultFolder);
                        DirectoryInfo diSource = new DirectoryInfo(defaultFolderPhysicalPath);
                        DirectoryInfo diTarget = new DirectoryInfo(folderPhysicalPath);
                        DcDirectoryManager.CopyAll(diSource, diTarget);
                    }
                }
            }


        }


        public static void DeleteUserFolder(MembershipUser user)
        {
            if (user != null)
            {
                UsersDataEntity userdata = UsersDataFactory.GetUsersDataObject((Guid)user.ProviderUserKey, Guid.Empty);
                DeleteUserFolder(user, userdata);
            }
        }
        public static void DeleteUserFolder(UsersDataEntity userdata)
        {
            if (userdata != null)
            {
                MembershipUser user = Membership.GetUser(userdata.UserId);
                DeleteUserFolder(user, userdata);
            }
        }
        public static void DeleteUserFolder(MembershipUser user, UsersDataEntity userdata)
        {
            if (user != null && userdata != null)
            {
                if (user.IsApproved && UsersDataFactory.IsSubSubSiteOwner(userdata.UserType))
                {
                    string subSiteFolder = DCSiteUrls.GetPath_SubSiteUploadFolder(user.UserName);
                    string subSiteFolderPhysicalPath = DCServer.MapPath(subSiteFolder);
                    if (Directory.Exists(subSiteFolderPhysicalPath))
                    {
                        DirectoryInfo dir = new DirectoryInfo(subSiteFolderPhysicalPath);
                        DcDirectoryManager.DeletDirectory(dir);
                    }
                }
                else
                {
                    string folder = DCSiteUrls.GetPath_UserDataDirectory(userdata.OwnerName, userdata.ModuleTypeID, userdata.CategoryID, userdata.UserProfileID);
                    string folderPhysicalPath = DCServer.MapPath(folder);
                    if (Directory.Exists(folderPhysicalPath))
                    {
                        DirectoryInfo dir = new DirectoryInfo(folderPhysicalPath);
                        DcDirectoryManager.DeletDirectory(dir);
                    }
                }
            }


        }
    }

}