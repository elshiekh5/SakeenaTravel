using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Country SQL data provider which represents the data access layer of Transfere.
    /// </summary>
    public class StatisticsSqlDataPrvider
    {
        /// <summary>
        /// Gets instance of StatisticsSqlDataPrvider calss.
        /// <example>StatisticsSqlDataPrvider edp=StatisticsSqlDataPrvider.Instance.</example>
        /// </summary>
        public static StatisticsSqlDataPrvider Instance
        {
            get { return new StatisticsSqlDataPrvider(); }
        }

        /// <summary>
        /// Creates and returns a new SqlConnection Which its connection string depends on AppSettings["Connectionstring"].
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ConnectionString);
        }

        /// <summary>
        /// Country Visitor Counter Create
        /// </summary>
        /// <param name="ctry"></param>
        /// <returns></returns>
        public bool vc_Create(string ctry)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("statistics_vc_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ctry", SqlDbType.Char, 2).Value = ctry;
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
        public bool vc_Delete(string ctry)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("statistics_vc_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ctry", SqlDbType.Char, 2).Value = ctry;
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
        /// <summary>
        /// Get Country Visitors
        /// </summary>
        /// <returns></returns>
        //------------------------------------------------------
        public DataTable GetCountryVisitors()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("statistics_GetCountryVisitors", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                //Execute the command
                myConnection.Open();
                da.Fill(dt);
                myConnection.Close();
                return dt;

            }
        }
        //------------------------------------------------------
        public DataTable GetTopCountryVisitors(int count)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("statistics_GetTopCountryVisitors", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = count;
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                //Execute the command
                myConnection.Open();
                da.Fill(dt);
                myConnection.Close();
                return dt;

            }
        }
        //------------------------------------------------------
        public int GetVisitorsCount()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("statistics_GetVisitorsCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //Execute the command
                myConnection.Open();
                int count = (int)myCommand.ExecuteScalar();
                myConnection.Close();
                return count;
            }
        }
        public void SetZero()
        {

            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("statistics_SetZero", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Execute the command
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        //------------------------------------------------------
    }
}