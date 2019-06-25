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
    public class MailListAchiveSqlDataPrvider
    {

        #region --------------Instance--------------
        private static MailListAchiveSqlDataPrvider _Instance;
        public static MailListAchiveSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MailListAchiveSqlDataPrvider();
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

        public bool Save(MailListEmailsEntity mail)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListAchive_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@MailID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@Subject", SqlDbType.NVarChar, 200).Value = mail.Subject;
                myCommand.Parameters.Add("@Body", SqlDbType.NVarChar).Value = mail.Body;
                myCommand.Parameters.Add("@To", SqlDbType.NVarChar).Value = mail.ToCollectionSting;
                myCommand.Parameters.Add("@CC", SqlDbType.NVarChar).Value = mail.CCCollectionSting;
                myCommand.Parameters.Add("@BCC", SqlDbType.NVarChar).Value = mail.BccCollectionSting;
                myCommand.Parameters.Add("@FromAddress", SqlDbType.NVarChar).Value = mail.From.Address;
                myCommand.Parameters.Add("@FromName", SqlDbType.NVarChar).Value = mail.From.DisplayName;
                myCommand.Parameters.Add("@Attachments", SqlDbType.NVarChar).Value = mail.AttachmentsString;
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
                    mail.MailID = (int)myCommand.Parameters["@MailID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        public bool Delete(int id)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListAchive_Delete", myConnection);
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
        public List<MailListEmailsEntity> GetAll(int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MailListEmailsEntity> mailListEmailsList = new List<MailListEmailsEntity>();
                MailListEmailsEntity mailListEmails;
                SqlCommand myCommand = new SqlCommand("MailListAchive_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
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
                    (mailListEmails) = PopulateEntity(dr);
                    mailListEmailsList.Add(mailListEmails);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return mailListEmailsList;
            }
        }
        #endregion

        #region --------------GetCountMailListAchive--------------
        public int GetCountMailListAchive()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListAchive_GetCount", myConnection);
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
            MailListEmailsEntity mail = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("MailListAchive_GetOneByID", myConnection);
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
                        mail = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return mail;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateEntity--------------
        private MailListEmailsEntity PopulateEntity(IDataReader reader)
        {
            //Create a new mail object
            string fromAddress = "";
            string fromName = "";
            MailListEmailsEntity mail = new MailListEmailsEntity();
            //Fill the object with data
            //MailID
            if (reader["MailID"] != DBNull.Value)
                mail.MailID = (int)reader["MailID"];
            //Subject
            if (reader["Subject"] != DBNull.Value)
                mail.Subject = (string)reader["Subject"];
            //Body
            if (reader["Body"] != DBNull.Value)
                mail.Body = (string)reader["Body"];
            //To
            if (reader["To"] != DBNull.Value)
                mail.ToCollectionSting = (string)reader["To"];
            //CC
            if (reader["CC"] != DBNull.Value)
                mail.CCCollectionSting = (string)reader["CC"];
            //BCC
            if (reader["BCC"] != DBNull.Value)
                mail.BccCollectionSting = (string)reader["BCC"];

            //FromAddress
            if (reader["FromAddress"] != DBNull.Value)
                fromAddress = (string)reader["FromAddress"];
            //FromName
            if (reader["FromName"] != DBNull.Value)
                fromName = (string)reader["FromName"];

            mail.From = new MailAddress(fromAddress, fromName);

            //Attachments
            if (reader["Attachments"] != DBNull.Value)
                mail.AttachmentsString = (string)reader["Attachments"];
            //Date_Added
            if (reader["Date_Added"] != DBNull.Value)
                mail.Date_Added = (DateTime)reader["Date_Added"];
            //Return the populated object
            return mail;
        }
        //------------------------------------------
        #endregion



    }

}