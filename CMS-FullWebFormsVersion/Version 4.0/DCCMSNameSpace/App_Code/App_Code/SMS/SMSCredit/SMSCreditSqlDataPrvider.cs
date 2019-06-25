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
    /// SMSCredit SQL data provider which represents the data access layer of SMSCredit.
    /// </summary>
    public class SMSCreditSqlDataPrvider
    {
        /// <summary>
        /// Gets instance of SMSCreditSqlDataPrvider calss.
        /// <example>SMSCreditSqlDataPrvider edp=SMSCreditSqlDataPrvider.Instance.</example>
        /// </summary>
        public static SMSCreditSqlDataPrvider Instance
        {
            get
            {
                return new SMSCreditSqlDataPrvider();
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
        /// <summary>
        /// Gets All SMSCredit Records.
        /// <example>[Example]DataTable dtSMSCredit=SMSCreditSqlDataPrvider.Instance.GetAllSMSCredit();.</example>
        /// </summary>
        /// <returns>The result of query.</returns>
        public DataTable GetAllSMSCredit()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSCredit_GetAll", myConnection);
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

        public void Decrease()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SMSCredit_Decrease", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                int x = myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }
    }
}