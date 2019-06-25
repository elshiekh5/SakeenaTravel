using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


namespace DCCMSNameSpace
{
    public class MailListGroupsSqlDataPrvider
    {

        #region --------------Instance--------------
        private static MailListGroupsSqlDataPrvider _Instance;
        public static MailListGroupsSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MailListGroupsSqlDataPrvider();
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

        #region --------------Save--------------

        public ExecuteCommandStatus Save(MailListGroupsEntity mailListGroups, SPOperation operation)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListGroups_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                //GroupID
                if (operation == SPOperation.Insert) myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                else myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = mailListGroups.GroupID;
                //SPOperation
                myCommand.Parameters.Add("@SPOperation", SqlDbType.Int, 4).Value = (int)operation;
                //Name
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 64).Value = mailListGroups.Name;
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
                    mailListGroups.GroupID = (int)myCommand.Parameters["@GroupID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single MailListGroups object .
        /// <example>[Example]bool status=MailListGroupsSqlDataPrvider.Instance.Delete(groupID);.</example>
        /// </summary>
        /// <param name="groupID">The mailListGroups id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int groupID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListGroups_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = groupID;
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
        public List<MailListGroupsEntity> GetAll()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MailListGroupsEntity> mailListGroupsList = new List<MailListGroupsEntity>();
                MailListGroupsEntity mailListGroups;
                SqlCommand myCommand = new SqlCommand("MailListGroups_GetAll", myConnection);
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                myCommand.CommandType = CommandType.StoredProcedure;
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    mailListGroups = PopulateEntity(dr);
                    mailListGroupsList.Add(mailListGroups);
                }
                dr.Close();
                myConnection.Close();
                return mailListGroupsList;
            }
        }
        #endregion


        #region --------------GetObject--------------
        public MailListGroupsEntity GetObject(int groupID)
        {
            MailListGroupsEntity mailListGroups = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListGroups_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@GroupID", SqlDbType.Int, 4).Value = groupID;
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
                        mailListGroups = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return mailListGroups;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateEntity--------------
        private MailListGroupsEntity PopulateEntity(IDataReader reader)
        {
            //Create a new MailListGroups object
            MailListGroupsEntity mailListGroups = new MailListGroupsEntity();
            //Fill the object with data
            //GroupID
            if (reader["GroupID"] != DBNull.Value)
                mailListGroups.GroupID = (int)reader["GroupID"];
            //Name
            if (reader["Name"] != DBNull.Value)
                mailListGroups.Name = (string)reader["Name"];
            //Return the populated object
            return mailListGroups;
        }
        //------------------------------------------
        #endregion
    }

}