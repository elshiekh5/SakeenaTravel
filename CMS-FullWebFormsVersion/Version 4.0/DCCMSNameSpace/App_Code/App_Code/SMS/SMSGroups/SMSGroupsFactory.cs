using System;
using System.Collections;
using System.Data;
using System.Collections.Generic;

namespace DCCMSNameSpace
{
    /// <summary>
    /// The class factory of SMSGroups.
    /// </summary>
    public class SMSGroupsFactory
    {

        /// <summary>
        /// Creates SMSGroups object by calling SMSGroups data provider create method.
        /// <example>[Example]bool result=SMSGroupsFactory.Create(smsGroups);.</example>
        /// </summary>
        /// <param name="smsGroups">The SMSGroups object.</param>
        /// <returns>The result of create operation.</returns>
        public static bool Create(SMSGroupsEntity smsGroups)
        {
            return SMSGroupsSqlDataPrvider.Instance.Create(smsGroups);
        }
        //------------------------------------------
        /// <summary>
        /// Updates SMSGroups object by calling SMSGroups data provider update method.
        /// <example>[Example]bool result=SMSGroupsFactory.Update(smsGroups);.</example>
        /// </summary>
        /// <param name="smsGroups">The SMSGroups object.</param>
        /// <returns>The result of update operation.</returns>
        public static bool Update(SMSGroupsEntity smsGroups)
        {
            return SMSGroupsSqlDataPrvider.Instance.Update(smsGroups);
        }
        //------------------------------------------
        /// <summary>
        /// Deletes single SMSGroups object .
        /// <example>[Example]bool result=SMSGroupsFactory.Delete(GroupID);.</example>
        /// </summary>
        /// <param name="GroupID">The smsGroups id.</param>
        /// <returns>The result of delete operation.</returns>
        public static bool Delete(int GroupID)
        {
            return SMSGroupsSqlDataPrvider.Instance.Delete(GroupID);
        }
        //------------------------------------------
        /// <summary>
        /// Gets All SMSGroups.
        /// <example>[Example]DataTable dtSMSGroups=SMSGroupsFactory.GetAll();.</example>
        /// </summary>
        /// <returns>All SMSGroups.</returns>
        public static DataTable GetAll()
        {
            return SMSGroupsSqlDataPrvider.Instance.GetAll();
        }
        public static List<SMSGroupsEntity> GetAllInList()
        {
            return SMSGroupsSqlDataPrvider.Instance.GetAllInList();
        }
        //------------------------------------------
        /// <summary>
        /// Gets single SMSGroups object .
        /// <example>[Example]SMSGroupsEntity smsGroups=SMSGroupsFactory.GetSMSGroupsObject(GroupID);.</example>
        /// </summary>
        /// <param name="GroupID">The smsGroups id.</param>
        /// <returns>SMSGroups object.</returns>
        public static SMSGroupsEntity GetSMSGroupsObject(int GroupID)
        {
            return SMSGroupsSqlDataPrvider.Instance.GetSMSGroupsObject(GroupID);
        }
        //------------------------------------------
        /// <summary>
        /// Populates SMSGroups Entity From DataRowView .
        /// <example>[Example]SMSGroupsEntitysmsGroups=PopulateSMSGroupsEntityFromDataRowView(obj);.</example>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>SMSGroups object.</returns>
        private SMSGroupsEntity PopulateSMSGroupsEntityFromDataRowView(DataRowView obj)
        {
            //Create a new SMSGroups object
            SMSGroupsEntity smsGroups = new SMSGroupsEntity();
            //Fill the object with data
            if (obj["GroupID"] != DBNull.Value)
                smsGroups.GroupID = (int)obj["GroupID"];
            if (obj["Name"] != DBNull.Value)
                smsGroups.Name = (string)obj["Name"];
            //Return the populated object
            return smsGroups;
        }
        //------------------------------------------
    }
}