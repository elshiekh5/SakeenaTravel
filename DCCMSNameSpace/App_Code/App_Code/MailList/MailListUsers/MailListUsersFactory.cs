using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using DCCMSNameSpace;


namespace DCCMSNameSpace
{
    public class MailListUsersFactory
    {

        #region --------------Create--------------

        public static ExecuteCommandStatus Create(MailListUsersEntity mailListUsers)
        {
            return MailListUsersSqlDataPrvider.Instance.Create(mailListUsers);
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single MailListUsers object .
        /// <example>[Example]bool status=MailListUsersFactory.Delete(userID);.</example>
        /// </summary>
        /// <param name="userID">The mailListUsers id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int userID)
        {
            bool status = MailListUsersSqlDataPrvider.Instance.Delete(userID);
            return status;
        }
        //------------------------------------------
        public static bool Delete(int ModuleTypeID, string Email)
        {
            bool status = MailListUsersSqlDataPrvider.Instance.Delete(ModuleTypeID, Email);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------

        public static ExecuteCommandStatus Update(MailListUsersEntity mailListUsers)
        {
            return MailListUsersSqlDataPrvider.Instance.Update(mailListUsers);
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<MailListUsersEntity> GetAll(int ModuleTypeID, Languages LangID, int groupID, bool isAvailableCondition)
        {
            int totalRecords;
            return MailListUsersSqlDataPrvider.Instance.GetAll(ModuleTypeID, LangID, groupID, isAvailableCondition, "", -1, -1, out  totalRecords);
        }
        //------------------------------------------
        public static List<MailListUsersEntity> GetAll(int ModuleTypeID, Languages LangID, int groupID, bool isAvailableCondition, string emailSearch)
        {
            int totalRecords;
            return MailListUsersSqlDataPrvider.Instance.GetAll(ModuleTypeID, LangID, groupID, isAvailableCondition, emailSearch, -1, -1, out  totalRecords);
        }
        //------------------------------------------
        public static List<MailListUsersEntity> GetAll(int ModuleTypeID, Languages LangID, int groupID, bool isAvailableCondition, string emailSearch, int pageIndex, int pageSize, out int totalRecords)
        {

            return MailListUsersSqlDataPrvider.Instance.GetAll(ModuleTypeID, LangID, groupID, isAvailableCondition, emailSearch, pageIndex, pageSize, out  totalRecords);
        }
        //------------------------------------------
        #endregion
        #region --------------GetAllEmailsOnly--------------
        public static List<string> GetAllEmailsOnly(int ModuleTypeID, Languages LangID, int groupID, bool isAvailableCondition)
        {
            return MailListUsersSqlDataPrvider.Instance.GetAllEmailsOnly(ModuleTypeID, LangID, groupID, isAvailableCondition);
        }
        //------------------------------------------
        #endregion
        #region --------------GetCount--------------
        public static int GetCount(int ModuleTypeID, Languages LangID, bool isAvailableCondition)
        {
            return MailListUsersSqlDataPrvider.Instance.GetCount(ModuleTypeID, LangID, -1, isAvailableCondition);
        }
        public static int GetCount(int ModuleTypeID, Languages LangID, int groupID, bool isAvailableCondition)
        {

            return MailListUsersSqlDataPrvider.Instance.GetCount(ModuleTypeID, LangID, groupID, isAvailableCondition);
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static MailListUsersEntity GetObject(int userID)
        {
            MailListUsersEntity mailListUsers = MailListUsersSqlDataPrvider.Instance.GetObject(userID);
            //return the object
            return mailListUsers;
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static MailListUsersEntity GetObject(int ModuleTypeID, string email)
        {
            MailListUsersEntity mailListUsers = MailListUsersSqlDataPrvider.Instance.GetObject(ModuleTypeID, email);
            //return the object
            return mailListUsers;
        }
        //------------------------------------------
        #endregion

        #region --------------ActivateAccount--------------
        public static bool ActivateAccount(int userID, string email)
        {
            bool status = MailListUsersSqlDataPrvider.Instance.ActivateAccount(userID, email);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------UnSubscripe--------------
        public static bool UnSubscripe(int userID, string email)
        {
            bool status = MailListUsersSqlDataPrvider.Instance.UnSubscripe(userID, email);
            return status;
        }
        //------------------------------------------
        #endregion
        //-----------------------------------------------------------------------
        public static ExecuteCommandStatus RegisterInMailList(int moduleID, string email, Languages langID, bool isActive, bool requiredActivationCode)
        {
            MailListUsersEntity user = new MailListUsersEntity();
            user.ModuleTypeID = moduleID;
            user.Email = email;
            user.LangID = langID;
            user.IsActive = isActive;
            ExecuteCommandStatus status = MailListUsersFactory.Create(user);
            if (status == ExecuteCommandStatus.Done && requiredActivationCode && !isActive)
                SendActivationCodeMessage(user);
            return status;
        }
        //----------------------------------------------------------------------
        public static void SendActivationCodeMessage(MailListUsersEntity user)
        {
            // prepare message
            string body = string.Format(DynamicResource.GetText("MailList","ActivationMailBody"), new string[3] { SitesHandler.GetSiteDomain(), Encryption.Encrypt(user.UserID.ToString()), user.Email });
            //string from =MailListEmailsFactory.MailFrom;
            MailListEmailsEntity mail = new MailListEmailsEntity();
            mail.Subject = DynamicResource.GetText("MailList", "ActivationMailSubject");
            mail.Body = body;
            mail.To.Add(user.Email);
            MailListEmailsFactory.Send(mail);

        }
    }

}