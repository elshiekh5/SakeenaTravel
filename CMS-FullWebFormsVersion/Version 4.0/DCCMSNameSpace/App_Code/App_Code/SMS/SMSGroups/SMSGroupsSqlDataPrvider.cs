using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using DCCMSNameSpace.Utilities;
using System.Collections.Generic;

namespace DCCMSNameSpace
{
    /// <summary>
    /// SMSGroups SQL data provider which represents the data access layer of SMSGroups.
    /// </summary>
    public class SMSGroupsSqlDataPrvider
    {
        /// <summary>
        /// Gets instance of SMSGroupsSqlDataPrvider calss.
        /// <example>SMSGroupsSqlDataPrvider edp=SMSGroupsSqlDataPrvider.Instance.</example>
        /// </summary>
        public static SMSGroupsSqlDataPrvider Instance
        {
            get
            {
                return new SMSGroupsSqlDataPrvider();
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
        /// Converts the SMSGroups object properties to SQL paramters and executes the create SMSGroups procedure 
        /// and updates the SMSGroups object with the SQL data by reference.
        /// <example>[Example]bool result=SMSGroupsSqlDataPrvider.Instance.Create(smsGroups);.</example>
        /// </summary>
        /// <param name="smsGroups">The SMSGroups object.</param>
        /// <returns>The result of create query.</returns>
        public bool Create(SMSGroupsEntity smsGroups)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSGroups_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = smsGroups.Name;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                    //Get ID value from database and set it in object
                    smsGroups.GroupID = (int)myCommand.Parameters["@GroupID"].Value;
                }
                myConnection.Close();
                return result;
            }
        }
        //------------------------------------------
        /// <summary>
        /// Converts the SMSGroups object properties to SQL paramters and executes the update SMSGroups procedure.
        /// <example>[Example]bool result=SMSGroupsSqlDataPrvider.Instance.Update(smsGroups);.</example>
        /// </summary>
        /// <param name="smsGroups">The SMSGroups object.</param>
        /// <returns>The result of update query.</returns>
        public bool Update(SMSGroupsEntity smsGroups)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSGroups_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = smsGroups.GroupID;
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 100).Value = smsGroups.Name;
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
        /// <summary>
        /// Deletes single SMSGroups object .
        /// <example>[Example]bool result=SMSGroupsSqlDataPrvider.Instance.Delete(GroupID);.</example>
        /// </summary>
        /// <param name="GroupID">The smsGroups id.</param>
        /// <returns>The result of delete query.</returns>
        public bool Delete(int GroupID)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSGroups_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = GroupID;
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
        /// <summary>
        /// Gets All SMSGroups Records.
        /// <example>[Example]DataTable dtSMSGroups=SMSGroupsSqlDataPrvider.Instance.GetAllSMSGroups();.</example>
        /// </summary>
        /// <returns>The result of query.</returns>
        public DataTable GetAll()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSGroups_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                // Execute the command
                myConnection.Open();
                da.Fill(dt);
                myConnection.Close();
                return dt;
            }
        }
        public List<SMSGroupsEntity> GetAllInList()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<SMSGroupsEntity> smsGroupsList = new List<SMSGroupsEntity>();
                SMSGroupsEntity smsCategoryObject;
                SqlCommand myCommand = new SqlCommand("SMSGroups_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
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
                    (smsCategoryObject) = PopulateEntity(dr);
                    smsGroupsList.Add(smsCategoryObject);
                }
                dr.Close();
                myConnection.Close();
                return smsGroupsList;
            }
        }
        //------------------------------------------
        /// <summary>
        /// Gets single SMSGroups object .
        /// <example>[Example]SMSGroupsEntity smsGroups=SMSGroupsSqlDataPrvider.Instance.GetSMSGroupsObject(GroupID);.</example>
        /// </summary>
        /// <param name="GroupID">The smsGroups id.</param>
        /// <returns>SMSGroups object.</returns>
        public SMSGroupsEntity GetSMSGroupsObject(int GroupID)
        {
            SMSGroupsEntity smsGroups = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSGroups_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = GroupID;
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
                        smsGroups = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return smsGroups;
            }
        }
        //------------------------------------------
        /// <summary>
        /// Populates SMSGroups Entity From IDataReader .
        /// <example>[Example]SMSGroupsEntitysmsGroups=PopulateEntity(reader);.</example>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>SMSGroups object.</returns>
        private SMSGroupsEntity PopulateEntity(IDataReader reader)
        {
            //Create a new SMSGroups object
            SMSGroupsEntity smsGroups = new SMSGroupsEntity();
            //Fill the object with data
            if (reader["GroupID"] != DBNull.Value)
                smsGroups.GroupID = (int)reader["GroupID"];
            if (reader["Name"] != DBNull.Value)
                smsGroups.Name = (string)reader["Name"];
            //Return the populated object
            return smsGroups;
        }
        //------------------------------------------
    }
}