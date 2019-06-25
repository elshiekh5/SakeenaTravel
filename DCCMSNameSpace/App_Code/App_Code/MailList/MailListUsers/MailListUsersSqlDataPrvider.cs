using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using DCCMSNameSpace;

namespace DCCMSNameSpace
{
    public class MailListUsersSqlDataPrvider
    {

        #region --------------Instance--------------
        private static MailListUsersSqlDataPrvider _Instance;
        public static MailListUsersSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MailListUsersSqlDataPrvider();
                }
                return _Instance;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetSqlConnection--------------
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ToString());
        }
        //------------------------------------------
        #endregion

        #region --------------Create--------------
        /// <summary>
        /// Converts the MailListUsers object properties to SQL paramters and executes the create MailListUsers procedure 
        /// and updates the MailListUsers object with the SQL data by reference.
        /// <example>[Example]bool status=MailListUsersSqlDataPrvider.Instance.Create(mailListUsers);.</example>
        /// </summary>
        /// <param name="mailListUsers">The MailListUsers object.</param>
        /// <returns>The status of create query.</returns>
        public ExecuteCommandStatus Create(MailListUsersEntity mailListUsers)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListUsers_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 128).Value = mailListUsers.Email;
                myCommand.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = mailListUsers.IsActive;
                //myCommand.Parameters.Add("@JoinDate", SqlDbType.DateTime,8).Value = mailListUsers.JoinDate;
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = mailListUsers.GroupID;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)mailListUsers.ModuleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)mailListUsers.LangID;
                myCommand.Parameters.Add("@Groups", SqlDbType.NVarChar, 128).Value = mailListUsers.Groups;
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
                    mailListUsers.UserID = (int)myCommand.Parameters["@UserID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        public ExecuteCommandStatus Update(MailListUsersEntity mailListUsers)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListUsers_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = mailListUsers.UserID;
                myCommand.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = mailListUsers.IsActive;
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = mailListUsers.GroupID;
                myCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 128).Value = mailListUsers.Email;
                myCommand.Parameters.Add("@Groups", SqlDbType.NVarChar, 128).Value = mailListUsers.Groups;
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

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single MailListUsers object .
        /// <example>[Example]bool status=MailListUsersSqlDataPrvider.Instance.Delete(userID);.</example>
        /// </summary>
        /// <param name="userID">The mailListUsers id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int userID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListUsers_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID;
                // Execute the command
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        public bool Delete(int ModuleTypeID, string Email)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListUsers_DeleteByEmail", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 128).Value = Email;
                // Execute the command
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public List<MailListUsersEntity> GetAll(int ModuleTypeID, Languages LangID, int groupID, bool isAvailableCondition, string emailSearch, int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MailListUsersEntity> mailListUsersList = new List<MailListUsersEntity>();
                MailListUsersEntity mailListUsers;
                SqlCommand myCommand = new SqlCommand("MailListUsers_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)LangID;
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = groupID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit).Value = isAvailableCondition;
                myCommand.Parameters.Add("@EmailSearch", SqlDbType.VarChar).Value = emailSearch;
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
                    (mailListUsers) = PopulateEntity(dr);
                    mailListUsersList.Add(mailListUsers);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return mailListUsersList;
            }
        }
        #endregion

        #region --------------GetAllEmailsOnly--------------
        public List<string> GetAllEmailsOnly(int ModuleTypeID, Languages LangID, int groupID, bool isAvailableCondition)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<string> emailsList = new List<string>();
                string email;
                SqlCommand myCommand = new SqlCommand("MailListUsers_GetAllEmailsOnly", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)LangID;
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = groupID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit).Value = isAvailableCondition;
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
                    email = (string)dr["Email"];
                    emailsList.Add(email);
                }
                dr.Close();
                myConnection.Close();
                return emailsList;
            }
        }
        #endregion

        #region --------------GetCount--------------
        public int GetCount(int ModuleTypeID, Languages LangID, int groupID, bool isAvailableCondition)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListUsers_GetCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)LangID;
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = groupID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit).Value = isAvailableCondition;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                int itemsCount = (int)myCommand.ExecuteScalar();
                myConnection.Close();
                return itemsCount;
            }
        }
        #endregion

        #region --------------GetObject--------------
        public MailListUsersEntity GetObject(int userID)
        {
            MailListUsersEntity mailListUsers = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListUsers_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID;
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
                        mailListUsers = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return mailListUsers;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public MailListUsersEntity GetObject(int ModuleTypeID, string email)
        {
            MailListUsersEntity mailListUsers = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListUsers_GetOneByEmail", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 128).Value = email;
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
                        mailListUsers = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return mailListUsers;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------ActivateAccount--------------
        public bool ActivateAccount(int userID, string email)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListUsers_ActivateAccount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID;
                myCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 128).Value = email;
                // Execute the command
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------UnSubscripe--------------
        public bool UnSubscripe(int userID, string email)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListUsers_UnSubscripe", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserID", SqlDbType.Int, 4).Value = userID;
                myCommand.Parameters.Add("@Email", SqlDbType.NVarChar, 128).Value = email;
                // Execute the command
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateEntity--------------
        private MailListUsersEntity PopulateEntity(IDataReader reader)
        {
            //Create a new MailListUsers object
            MailListUsersEntity mailListUsers = new MailListUsersEntity();
            //Fill the object with data
            //UserID
            if (reader["UserID"] != DBNull.Value)
                mailListUsers.UserID = (int)reader["UserID"];
            //Email
            if (reader["Email"] != DBNull.Value)
                mailListUsers.Email = (string)reader["Email"];
            //IsActive
            if (reader["IsActive"] != DBNull.Value)
                mailListUsers.IsActive = (bool)reader["IsActive"];
            //JoinDate
            if (reader["JoinDate"] != DBNull.Value)
                mailListUsers.JoinDate = (DateTime)reader["JoinDate"];
            //GroupID
            if (reader["GroupID"] != DBNull.Value)
                mailListUsers.GroupID = (int)reader["GroupID"];
            //LangID
            if (reader["LangID"] != DBNull.Value)
                mailListUsers.LangID = (Languages)reader["LangID"];
            //ModuleTypeID
            if (reader["ModuleTypeID"] != DBNull.Value)
                mailListUsers.ModuleTypeID = (int)reader["ModuleTypeID"];
            //Groups
            if (reader["Groups"] != DBNull.Value)
                mailListUsers.Groups = (string)reader["Groups"];
            //Return the populated object
            return mailListUsers;
        }
        //------------------------------------------
        #endregion
    }

}