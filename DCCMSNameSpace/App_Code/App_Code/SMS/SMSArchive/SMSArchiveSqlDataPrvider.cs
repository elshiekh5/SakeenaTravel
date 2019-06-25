using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using DCCMSNameSpace.Utilities;


namespace DCCMSNameSpace
{
    /// <summary>
    /// SMSArchive SQL data provider which represents the data access layer of SMSArchive.
    /// </summary>
    public class SMSArchiveSqlDataPrvider
    {
        /// <summary>
        /// Gets instance of SMSArchiveSqlDataPrvider calss.
        /// <example>SMSArchiveSqlDataPrvider edp=SMSArchiveSqlDataPrvider.Instance.</example>
        /// </summary>
        public static SMSArchiveSqlDataPrvider Instance
        {
            get
            {
                return new SMSArchiveSqlDataPrvider();
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
        /// Converts the SMSArchive object properties to SQL paramters and executes the create SMSArchive procedure 
        /// and updates the SMSArchive object with the SQL data by reference.
        /// <example>[Example]bool result=SMSArchiveSqlDataPrvider.Instance.Create(sMSArchive);.</example>
        /// </summary>
        /// <param name="sMSArchive">The SMSArchive object.</param>
        /// <returns>The result of create query.</returns>
        public bool Create(SMSArchiveEntity sMSArchive)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSArchive_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@Sender", SqlDbType.NVarChar, 20).Value = sMSArchive.Sender;
                myCommand.Parameters.Add("@RecieverMobile", SqlDbType.NVarChar, 20).Value = sMSArchive.RecieverMobile;
                myCommand.Parameters.Add("@Message", SqlDbType.NVarChar, 500).Value = sMSArchive.Message;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)sMSArchive.LangID;
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
                    sMSArchive.ID = (int)myCommand.Parameters["@ID"].Value;
                }
                myConnection.Close();
                return result;
            }
        }

        //------------------------------------------
        /// <summary>
        /// Deletes single SMSArchive object .
        /// <example>[Example]bool result=SMSArchiveSqlDataPrvider.Instance.Delete(id);.</example>
        /// </summary>
        /// <param name="id">The sMSArchive id.</param>
        /// <returns>The result of delete query.</returns>
        public bool Delete(int id)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSArchive_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ID", SqlDbType.Int, 4).Value = id;
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
        public bool DeleteAll()
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSArchive_Delete_all", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                
                // Set the parameters
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
        /// Gets All SMSArchive Records.
        /// <example>[Example]DataTable dtSMSArchive=SMSArchiveSqlDataPrvider.Instance.GetAllSMSArchive();.</example>
        /// </summary>
        /// <returns>The result of query.</returns>
        public DataTable GetAllSMSArchive()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSArchive_GetAll", myConnection);
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
        //------------------------------------------
        /// <summary>
        /// Gets single SMSArchive object .
        /// <example>[Example]SMSArchiveEntity sMSArchive=SMSArchiveSqlDataPrvider.Instance.GetSMSArchiveObject(id);.</example>
        /// </summary>
        /// <param name="id">The sMSArchive id.</param>
        /// <returns>SMSArchive object.</returns>
        public SMSArchiveEntity GetSMSArchiveObject(int id)
        {
            SMSArchiveEntity sMSArchive = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSArchive_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ID", SqlDbType.Int, 4).Value = id;
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
                        sMSArchive = PopulateSMSArchiveEntityFromIDataReader(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return sMSArchive;
            }
        }
        //------------------------------------------
        /// <summary>
        /// Populates SMSArchive Entity From IDataReader .
        /// <example>[Example]SMSArchiveEntitysMSArchive=PopulateSMSArchiveEntityFromIDataReader(reader);.</example>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>SMSArchive object.</returns>
        private SMSArchiveEntity PopulateSMSArchiveEntityFromIDataReader(IDataReader reader)
        {
            //Create a new SMSArchive object
            SMSArchiveEntity sMSArchive = new SMSArchiveEntity();
            //Fill the object with data
            if (reader["ID"] != DBNull.Value)
                sMSArchive.ID = (int)reader["ID"];
            if (reader["Sender"] != DBNull.Value)
                sMSArchive.Sender = (string)reader["Sender"];
            if (reader["RecieverMobile"] != DBNull.Value)
                sMSArchive.RecieverMobile = (string)reader["RecieverMobile"];
            if (reader["Message"] != DBNull.Value)
                sMSArchive.Message = (string)reader["Message"];
            if (reader["LangID"] != DBNull.Value)
                sMSArchive.LangID = (Languages)reader["LangID"];
            //Return the populated object
            return sMSArchive;
        }
        //------------------------------------------
    }
}