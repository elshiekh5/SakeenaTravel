using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using DCCMSNameSpace.Utilities;
using DCCMSNameSpace;
using System.Collections.Generic;


namespace DCCMSNameSpace
{
    /// <summary>
    /// SMSNumbers SQL data provider which represents the data access layer of SMSNumbers.
    /// </summary>
    public class SMSNumbersSqlDataPrvider
    {
        /// <summary>
        /// Gets instance of SMSNumbersSqlDataPrvider calss.
        /// <example>SMSNumbersSqlDataPrvider edp=SMSNumbersSqlDataPrvider.Instance.</example>
        /// </summary>
        public static SMSNumbersSqlDataPrvider Instance
        {
            get
            {
                return new SMSNumbersSqlDataPrvider();
            }
        }
        //------------------------------------------
        /// <summary>
        /// Creates and returns a new SqlConnection Which its connection string depends on AppSettings["Connectionstring"].
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetSqlConnection()
        {
            return Shared.GetSqlConnection();
        }
        //------------------------------------------
        /// <summary>
        /// Converts the SMSNumbers object properties to SQL paramters and executes the create SMSNumbers procedure 
        /// and updates the SMSNumbers object with the SQL data by reference.
        /// <example>[Example]bool result=SMSNumbersSqlDataPrvider.Instance.Create(sMSNumbers);.</example>
        /// </summary>
        /// <param name="sMSNumbers">The SMSNumbers object.</param>
        /// <returns>The result of create query.</returns>
        public ExecuteCommandStatus Create(SMSNumbersEntity sMSNumbers)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSNumbers_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@NumID", SqlDbType.BigInt, 8).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@Numbers", SqlDbType.NVarChar, 20).Value = sMSNumbers.Numbers;
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 200).Value = sMSNumbers.Name;
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = sMSNumbers.GroupID;
                //--------------------------------------------------------------------------------
                myCommand.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = sMSNumbers.IsActive;
                //myCommand.Parameters.Add("@JoinDate", SqlDbType.DateTime,8).Value = mailListUsers.JoinDate;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)sMSNumbers.ModuleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)sMSNumbers.LangID;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                if (status == ExecuteCommandStatus.Done)
                {
                    //Get ID value from database and set it in object
                    sMSNumbers.NumID = (long)myCommand.Parameters["@NumID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        /// <summary>
        /// Converts the SMSNumbers object properties to SQL paramters and executes the update SMSNumbers procedure.
        /// <example>[Example]bool result=SMSNumbersSqlDataPrvider.Instance.Update(sMSNumbers);.</example>
        /// </summary>
        /// <param name="sMSNumbers">The SMSNumbers object.</param>
        /// <returns>The result of update query.</returns>
        public ExecuteCommandStatus Update(SMSNumbersEntity sMSNumbers)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSNumbers_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@NumID", SqlDbType.BigInt, 8).Value = sMSNumbers.NumID;
                myCommand.Parameters.Add("@Numbers", SqlDbType.NVarChar, 20).Value = sMSNumbers.Numbers;
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = sMSNumbers.GroupID;
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 200).Value = sMSNumbers.Name;
                myCommand.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = sMSNumbers.IsActive;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)sMSNumbers.ModuleTypeID;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        /// <summary>
        /// Deletes single SMSNumbers object .
        /// <example>[Example]bool result=SMSNumbersSqlDataPrvider.Instance.Delete(numID);.</example>
        /// </summary>
        /// <param name="numID">The sMSNumbers id.</param>
        /// <returns>The result of delete query.</returns>
        public bool Delete(long numID)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSNumbers_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@NumID", SqlDbType.BigInt, 8).Value = numID;
                // Execute the command
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                myConnection.Close();
                return result;
            }
        }
        //------------------------------------------
        public bool Delete(int ModuleTypeID, string mobileNo)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSNumbers_DeleteByNo", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@Numbers", SqlDbType.NVarChar, 20).Value = mobileNo;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                myConnection.Close();
                return result;
            }
        }
        //------------------------------------------
        public List<SMSNumbersEntity> GetAll(int ModuleTypeID, Languages LangID, int GroupID, bool isAvailableCondition, string searchText, int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<SMSNumbersEntity> smsUsersList = new List<SMSNumbersEntity>();
                SMSNumbersEntity smsUser;
                SqlCommand myCommand = new SqlCommand("SMSNumbers_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)LangID;
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = GroupID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit).Value = isAvailableCondition;
                myCommand.Parameters.Add("@SearchText", SqlDbType.VarChar).Value = searchText;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    (smsUser) = PopulateEntity(dr);
                    smsUsersList.Add(smsUser);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return smsUsersList;
            }
        }
        //---------------------------------------------------------------------------------------
        #region --------------GetAllNumbersOnly--------------
        public List<string> GetAllNumbersOnly(int ModuleTypeID, Languages LangID, int groupID, bool isAvailableCondition, string SearchText)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<string> numbersList = new List<string>();
                string Numbers;
                SqlCommand myCommand = new SqlCommand("SMSNumbers_GetNumbersOnly", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)LangID;
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = groupID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit).Value = isAvailableCondition;
                myCommand.Parameters.Add("@SearchText", SqlDbType.VarChar).Value = SearchText;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    Numbers = (string)dr["Numbers"];
                    numbersList.Add(Numbers);
                }
                dr.Close();
                myConnection.Close();
                return numbersList;
            }
        }
        #endregion
        //----------------------------------------------------------------------------
        /// <summary>
        /// Gets single SMSNumbers object .
        /// <example>[Example]SMSNumbersEntity sMSNumbers=SMSNumbersSqlDataPrvider.Instance.GetObject(numID);.</example>
        /// </summary>
        /// <param name="numID">The sMSNumbers id.</param>
        /// <returns>SMSNumbers object.</returns>
        public SMSNumbersEntity GetObject(long numID)
        {
            SMSNumbersEntity sMSNumbers = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSNumbers_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@NumID", SqlDbType.BigInt, 8).Value = numID;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        sMSNumbers = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return sMSNumbers;
            }
        }
        //------------------------------------------
        public SMSNumbersEntity GetSMSNumbersObjectByNumber(int ModuleTypeID, string mobileNo)
        {
            SMSNumbersEntity sMSNumbers = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSNumbers_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@Numbers", SqlDbType.NVarChar, 20).Value = mobileNo;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        sMSNumbers = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return sMSNumbers;
            }
        }
        /// <summary>
        /// Populates SMSNumbers Entity From IDataReader .
        /// <example>[Example]SMSNumbersEntitysMSNumbers=PopulateEntity(reader);.</example>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>SMSNumbers object.</returns>
        private SMSNumbersEntity PopulateEntity(IDataReader reader)
        {
            //Create a new SMSNumbers object
            SMSNumbersEntity sMSNumbers = new SMSNumbersEntity();
            //Fill the object with data
            if (reader["NumID"] != DBNull.Value)
                sMSNumbers.NumID = (long)reader["NumID"];
            if (reader["Numbers"] != DBNull.Value)
                sMSNumbers.Numbers = (string)reader["Numbers"];
            if (reader["GroupID"] != DBNull.Value)
                sMSNumbers.GroupID = (int)reader["GroupID"];
            if (reader["Name"] != DBNull.Value)
                sMSNumbers.Name = (string)reader["Name"];
            //IsActive
            if (reader["IsActive"] != DBNull.Value)
                sMSNumbers.IsActive = (bool)reader["IsActive"];
            //JoinDate
            if (reader["JoinDate"] != DBNull.Value)
                sMSNumbers.JoinDate = (DateTime)reader["JoinDate"];
            //LangID
            if (reader["LangID"] != DBNull.Value)
                sMSNumbers.LangID = (Languages)reader["LangID"];
            //ModuleTypeID
            if (reader["ModuleTypeID"] != DBNull.Value)
                sMSNumbers.ModuleTypeID = (int)reader["ModuleTypeID"];
            //Return the populated object
            return sMSNumbers;
        }
        //------------------------------------------
    }
}
