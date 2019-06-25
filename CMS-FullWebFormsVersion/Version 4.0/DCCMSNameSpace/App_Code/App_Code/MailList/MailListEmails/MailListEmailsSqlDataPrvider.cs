using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Net.Mail;


namespace DCCMSNameSpace
{
    public class MailListEmailsSqlDataPrvider
    {

        #region --------------Instance--------------
        private static MailListEmailsSqlDataPrvider _Instance;
        public static MailListEmailsSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MailListEmailsSqlDataPrvider();
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
        /// Converts the MailListEmails object properties to SQL paramters and executes the create MailListEmails procedure 
        /// and updates the MailListEmails object with the SQL data by reference.
        /// <example>[Example]bool status=MailListEmailsSqlDataPrvider.Instance.Create(mailListEmails);.</example>
        /// </summary>
        /// <param name="mailListEmails">The MailListEmails object.</param>
        /// <returns>The status of create query.</returns>
        public bool Create(MailListEmailsEntity mailListEmails)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListEmails_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@MailID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@Subject", SqlDbType.NVarChar, 200).Value = mailListEmails.Subject;
                myCommand.Parameters.Add("@Body", SqlDbType.NVarChar).Value = mailListEmails.Body;
                myCommand.Parameters.Add("@To", SqlDbType.NVarChar).Value = mailListEmails.ToCollectionSting;
                myCommand.Parameters.Add("@CC", SqlDbType.NVarChar).Value = mailListEmails.CCCollectionSting;
                myCommand.Parameters.Add("@BCC", SqlDbType.NVarChar).Value = mailListEmails.BccCollectionSting;
                myCommand.Parameters.Add("@FromAddress", SqlDbType.NVarChar).Value = mailListEmails.From.Address;
                myCommand.Parameters.Add("@FromName", SqlDbType.NVarChar).Value = mailListEmails.From.DisplayName;
                myCommand.Parameters.Add("@Attachments", SqlDbType.NVarChar).Value = mailListEmails.AttachmentsString;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                bool status = false;
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                    //Get MailID value from database and set it in object
                    mailListEmails.MailID = (int)myCommand.Parameters["@MailID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single MailListEmails object .
        /// <example>[Example]bool status=MailListEmailsSqlDataPrvider.Instance.Delete(id);.</example>
        /// </summary>
        /// <param name="id">The mailListEmails id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int id)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListEmails_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@MailID", SqlDbType.Int, 4).Value = id;
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
        public List<MailListEmailsEntity> GetAll()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MailListEmailsEntity> mailListEmailsList = new List<MailListEmailsEntity>();
                MailListEmailsEntity mailListEmails;
                SqlCommand myCommand = new SqlCommand("MailListEmails_GetAll", myConnection);
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
                    (mailListEmails) = PopulateEntity(dr);
                    mailListEmailsList.Add(mailListEmails);
                }
                dr.Close();
                myConnection.Close();
                return mailListEmailsList;
            }
        }
        #endregion

        #region --------------GetCountMailListEmails--------------
        public int GetCountMailListEmails()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListEmails_GetCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
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
        public MailListEmailsEntity GetObject(int id)
        {
            MailListEmailsEntity mailListEmails = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListEmails_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@MailID", SqlDbType.Int, 4).Value = id;
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
                        mailListEmails = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return mailListEmails;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateEntity--------------
        private MailListEmailsEntity PopulateEntity(IDataReader reader)
        {
            //Create a new MailListEmails object
            string fromAddress = "";
            string fromName = "";
            MailListEmailsEntity mailListEmails = new MailListEmailsEntity();
            //Fill the object with data
            //MailID
            if (reader["MailID"] != DBNull.Value)
                mailListEmails.MailID = (int)reader["MailID"];
            //Subject
            if (reader["Subject"] != DBNull.Value)
                mailListEmails.Subject = (string)reader["Subject"];
            //Body
            if (reader["Body"] != DBNull.Value)
                mailListEmails.Body = (string)reader["Body"];
            //To
            if (reader["To"] != DBNull.Value)
                mailListEmails.ToCollectionSting = (string)reader["To"];
            //CC
            if (reader["CC"] != DBNull.Value)
                mailListEmails.CCCollectionSting = (string)reader["CC"];
            //BCC
            if (reader["BCC"] != DBNull.Value)
                mailListEmails.BccCollectionSting = (string)reader["BCC"];

            //FromAddress
            if (reader["FromAddress"] != DBNull.Value)
                fromAddress = (string)reader["FromAddress"];
            //FromName
            if (reader["FromName"] != DBNull.Value)
                fromName = (string)reader["FromName"];

            mailListEmails.From = new MailAddress(fromAddress, fromName);

            //Trials
            if (reader["Trials"] != DBNull.Value)
                mailListEmails.Trials = (int)reader["Trials"];
            //IsBeingSent
            if (reader["IsBeingSent"] != DBNull.Value)
                mailListEmails.IsBeingSent = (bool)reader["IsBeingSent"];

            //Attachments
            if (reader["Attachments"] != DBNull.Value)
                mailListEmails.AttachmentsString = (string)reader["Attachments"];
            //Date_Added
            if (reader["Date_Added"] != DBNull.Value)
                mailListEmails.Date_Added = (DateTime)reader["Date_Added"];
            //Return the populated object
            return mailListEmails;
        }
        //------------------------------------------
        #endregion

        //------------------------------------------
        public void IncreaseTrials(int id)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListEmails_IncreaseTrials", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@MailID", SqlDbType.Int, 4).Value = id;
                // Execute the command
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                }
                myConnection.Close();
            }
        }
        //------------------------------------------

    }
}

