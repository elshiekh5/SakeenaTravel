using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;


namespace DCCMSNameSpace
{
    public class MailListGroupsFactory
    {

        #region --------------Save--------------

        public static ExecuteCommandStatus Save(MailListGroupsEntity mailListGroups, SPOperation operation)
        {
            return MailListGroupsSqlDataPrvider.Instance.Save(mailListGroups, operation);
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single MailListGroups object .
        /// <example>[Example]bool status=MailListGroupsFactory.Delete(groupID);.</example>
        /// </summary>
        /// <param name="groupID">The mailListGroups id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int groupID)
        {
            bool status = MailListGroupsSqlDataPrvider.Instance.Delete(groupID);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<MailListGroupsEntity> GetAll()
        {

            return MailListGroupsSqlDataPrvider.Instance.GetAll();
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static MailListGroupsEntity GetObject(int groupID)
        {

            MailListGroupsEntity mailListGroups = MailListGroupsSqlDataPrvider.Instance.GetObject(groupID);

            //return the object
            return mailListGroups;
        }
        //------------------------------------------
        #endregion
    }
}
