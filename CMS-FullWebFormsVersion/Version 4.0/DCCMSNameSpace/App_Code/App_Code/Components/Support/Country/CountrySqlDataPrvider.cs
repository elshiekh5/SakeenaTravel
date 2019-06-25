using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Collections.Generic;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Country SQL data provider which represents the data access layer of Country.
    /// </summary>
    public class CountrySqlDataPrvider
    {
        /// <summary>
        /// Gets instance of CountrySqlDataPrvider calss.
        /// <example>CountrySqlDataPrvider edp=CountrySqlDataPrvider.Instance.</example>
        /// </summary>
        public static CountrySqlDataPrvider Instance
        {
            get
            {
                return new CountrySqlDataPrvider();
            }
        }
        //------------------------------------------
        /// <summary>
        /// Creates and returns a new SqlConnection Which its connection string depends on AppSettings["Connectionstring"].
        /// </summary>
        /// <returns></returns>
        public SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        }
        //------------------------------------------
        /// <summary>
        /// Converts the Country object properties to SQL paramters and executes the create Country procedure 
        /// and updates the Country object with the SQL data by reference.
        /// <example>[Example]bool result=CountrySqlDataPrvider.Instance.Create(country);.</example>
        /// </summary>
        /// <param name="country">The Country object.</param>
        /// <returns>The result of create query.</returns>
        public bool Create(CountryEntity country)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Country_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = country.Name;
                myCommand.Parameters.Add("@EnName", SqlDbType.NVarChar, 50).Value = country.EnName;
                myCommand.Parameters.Add("@Short", SqlDbType.Char, 5).Value = country.Short;
                // Execute the command
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                    //Get ID value from database and set it in object
                    country.ID = (int)myCommand.Parameters["@ID"].Value;
                }
                myConnection.Close();
                return result;
            }
        }
        //------------------------------------------
        /// <summary>
        /// Converts the Country object properties to SQL paramters and executes the update Country procedure.
        /// <example>[Example]bool result=CountrySqlDataPrvider.Instance.Update(country);.</example>
        /// </summary>
        /// <param name="country">The Country object.</param>
        /// <returns>The result of update query.</returns>
        public bool Update(CountryEntity country)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Country_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ID", SqlDbType.Int, 4).Value = country.ID;
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = country.Name;
                myCommand.Parameters.Add("@EnName", SqlDbType.NVarChar, 50).Value = country.EnName;
                myCommand.Parameters.Add("@Short", SqlDbType.Char, 5).Value = country.Short;
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
        /// Deletes single Country object .
        /// <example>[Example]bool result=CountrySqlDataPrvider.Instance.Delete(id);.</example>
        /// </summary>
        /// <param name="id">The country id.</param>
        /// <returns>The result of delete query.</returns>
        public bool Delete(int id)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Country_Delete", myConnection);
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
        //------------------------------------------
        public DataTable GetAllCountryByContID(int ContID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Country_GetAllByContID", myConnection);
                myCommand.Parameters.Add("@ContID", SqlDbType.Int, 4).Value = ContID;

                myCommand.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                // Execute the command
                myConnection.Open();
                da.Fill(dt);
                myConnection.Close();
                return dt;
            }
        }
        /// <summary>
        /// Gets All Country Records.
        /// <example>[Example]DataTable dtCountry=CountrySqlDataPrvider.Instance.GetAllCountry();.</example>
        /// </summary>
        /// <returns>The result of query.</returns>
        public DataTable GetAllCountry()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Country_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
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
        public DataTable GetTopCountriesForStatistics()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Country_GetTopCountriesForStatistics", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
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
        public DataTable GetRestCountriesForStatistics()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Country_GetRestCountriesForStatistics", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
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
        public List<CountryEntity> GetAllinList()
        {
            List<CountryEntity> res = new List<CountryEntity>();
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Country_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myConnection.Open();

                SqlDataReader dr = myCommand.ExecuteReader();
                while (dr.Read())
                {
                    res.Add(PopulateCountryEntityFromIDataReader(dr));
                }

                myConnection.Close();
                return res;
            }
        }


        //------------------------------------------
        /// <summary>
        /// Gets single Country object .
        /// <example>[Example]CountryEntitycountry=CountrySqlDataPrvider.Instance.GetCountryObject(id);.</example>
        /// </summary>
        /// <param name="id">The country id.</param>
        /// <returns>Country object.</returns>
        public CountryEntity GetCountryObject(int id)
        {
            CountryEntity country = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Country_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ID", SqlDbType.Int, 4).Value = id;
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        country = PopulateCountryEntityFromIDataReader(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return country;
            }
        }
        //------------------------------------------
        /// <summary>
        /// Populates Country Entity From IDataReader .
        /// <example>[Example]CountryEntitycountry=PopulateCountryEntityFromIDataReader(reader);.</example>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Country object.</returns>
        private CountryEntity PopulateCountryEntityFromIDataReader(IDataReader reader)
        {
            //Create a new Country object
            CountryEntity country = new CountryEntity();
            //Fill the object with data
            if (reader["ID"] != DBNull.Value)
                country.ID = (int)reader["ID"];
            if (reader["Name"] != DBNull.Value)
                country.Name = (string)reader["Name"];
            if (reader["EnName"] != DBNull.Value)
                country.EnName = (string)reader["EnName"];
            if (reader["Short"] != DBNull.Value)
                country.Short = (string)reader["Short"];
            if (reader["ContID"] != DBNull.Value)
                country.ContID = (int)reader["ContID"];
            //Return the populated object
            return country;
        }
        //------------------------------------------
        //------------------------------------------
        /// <summary>
        /// Gets All Countries Records Whitch Has Charities.
        /// <example>[Example]DataTable dtCountries=CountriesSqlDataPrvider.Instance.GetAllCountriesWhitchHasCharities();.</example>
        /// </summary>
        /// <returns>The result of query.</returns>

    }
}
