using System;
using System.Collections;
using System.Data;
using DCCMSNameSpace;
using System.Collections.Generic;


namespace DCCMSNameSpace
{
    /// <summary>
    /// The class factory of SMSNumbers.
    /// </summary>
    public class SMSNumbersFactory
    {

        /// <summary>
        /// Creates SMSNumbers object by calling SMSNumbers data provider create method.
        /// <example>[Example]bool result=SMSNumbersFactory.Create(sMSNumbers);.</example>
        /// </summary>
        /// <param name="sMSNumbers">The SMSNumbers object.</param>
        /// <returns>The result of create operation.</returns>
        public static ExecuteCommandStatus Create(SMSNumbersEntity sMSNumbers)
        {
            return SMSNumbersSqlDataPrvider.Instance.Create(sMSNumbers);
        }
        //------------------------------------------
        /// <summary>
        /// Updates SMSNumbers object by calling SMSNumbers data provider update method.
        /// <example>[Example]bool result=SMSNumbersFactory.Update(sMSNumbers);.</example>
        /// </summary>
        /// <param name="sMSNumbers">The SMSNumbers object.</param>
        /// <returns>The result of update operation.</returns>
        public static ExecuteCommandStatus Update(SMSNumbersEntity sMSNumbers)
        {
            return SMSNumbersSqlDataPrvider.Instance.Update(sMSNumbers);
        }
        //------------------------------------------
        /// <summary>
        /// Deletes single SMSNumbers object .
        /// <example>[Example]bool result=SMSNumbersFactory.Delete(numID);.</example>
        /// </summary>
        /// <param name="numID">The sMSNumbers id.</param>
        /// <returns>The result of delete operation.</returns>
        public static bool Delete(long numID)
        {
            return SMSNumbersSqlDataPrvider.Instance.Delete(numID);
        }
        public static bool Delete(int ModuleTypeID, string mobileNo)
        {
            return SMSNumbersSqlDataPrvider.Instance.Delete(ModuleTypeID, mobileNo);
        }
        //------------------------------------------
        public static List<SMSNumbersEntity> GetAll(int ModuleTypeID, Languages LangID, int GroupID, bool isAvailableCondition)
        {
            int totalRecords = 0;
            return SMSNumbersSqlDataPrvider.Instance.GetAll(ModuleTypeID, LangID, GroupID, isAvailableCondition, "", -1, -1, out  totalRecords);
        }
        public static List<SMSNumbersEntity> GetAll(int ModuleTypeID, Languages LangID, int GroupID, bool isAvailableCondition, string searchText)
        {
            int totalRecords = 0;
            return SMSNumbersSqlDataPrvider.Instance.GetAll(ModuleTypeID, LangID, GroupID, isAvailableCondition, searchText, -1, -1, out  totalRecords);
        }
        public static List<SMSNumbersEntity> GetAll(int ModuleTypeID, Languages LangID, int GroupID, bool isAvailableCondition, string searchText, int pageIndex, int pageSize, out int totalRecords)
        {
            return SMSNumbersSqlDataPrvider.Instance.GetAll(ModuleTypeID, LangID, GroupID, isAvailableCondition, searchText, pageIndex, pageSize, out  totalRecords);
        }
        //------------------------------------------
        #region --------------GetAllNumbersOnly--------------
        public static List<string> GetAllNumbersOnly(int ModuleTypeID, Languages LangID, int GroupID, bool isAvailableCondition)
        {
            return SMSNumbersSqlDataPrvider.Instance.GetAllNumbersOnly(ModuleTypeID, LangID, GroupID, isAvailableCondition, "");
        }
        //---------------------------------------------------
        public static List<string> GetAllNumbersOnly(int ModuleTypeID, Languages LangID, int GroupID, bool isAvailableCondition, string SearchText)
        {
            return SMSNumbersSqlDataPrvider.Instance.GetAllNumbersOnly(ModuleTypeID, LangID, GroupID, isAvailableCondition, SearchText);
        }
        //------------------------------------------
        #endregion
        /// <summary>
        /// Gets single SMSNumbers object .
        /// <example>[Example]SMSNumbersEntity sMSNumbers=SMSNumbersFactory.GetObject(numID);.</example>
        /// </summary>
        /// <param name="numID">The sMSNumbers id.</param>
        /// <returns>SMSNumbers object.</returns>
        public static SMSNumbersEntity GetObject(long numID)
        {
            return SMSNumbersSqlDataPrvider.Instance.GetObject(numID);
        }
        //------------------------------------------
        public static SMSNumbersEntity GetObject(int ModuleTypeID, string mobileNo)
        {
            return SMSNumbersSqlDataPrvider.Instance.GetSMSNumbersObjectByNumber(ModuleTypeID, mobileNo);
        }
        //------------------------------------------
        /// <summary>
        /// Populates SMSNumbers Entity From DataRowView .
        /// <example>[Example]SMSNumbersEntitysMSNumbers=PopulateSMSNumbersEntityFromDataRowView(obj);.</example>
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>SMSNumbers object.</returns>
        private SMSNumbersEntity PopulateSMSNumbersEntityFromDataRowView(DataRowView obj)
        {
            //Create a new SMSNumbers object
            SMSNumbersEntity sMSNumbers = new SMSNumbersEntity();
            //Fill the object with data
            if (obj["NumID"] != DBNull.Value)
                sMSNumbers.NumID = (long)obj["NumID"];
            if (obj["Numbers"] != DBNull.Value)
                sMSNumbers.Numbers = (string)obj["Numbers"];
            if (obj["GroupID"] != DBNull.Value)
                sMSNumbers.GroupID = (int)obj["GroupID"];
            //Return the populated object
            return sMSNumbers;
        }
        //------------------------------------------


        //-----------------------------------------------------------------------
        public static ExecuteCommandStatus RegisterInSms(int moduleID, string mobile, Languages langID, bool isActive)
        {
            SMSNumbersEntity newSmsUser = new SMSNumbersEntity();
            newSmsUser.Numbers = mobile;
            newSmsUser.LangID = langID;
            newSmsUser.ModuleTypeID = moduleID;
            newSmsUser.IsActive = isActive;
            ExecuteCommandStatus status = SMSNumbersFactory.Create(newSmsUser);
            return status;
        }
        //----------------------------------------------------------------------

    }
}