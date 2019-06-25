using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


namespace DCCMSNameSpace
{
    public class SystemCountriesSqlDataPrvider
    {

        #region --------------Instance--------------
        private static SystemCountriesSqlDataPrvider _Instance;
        public static SystemCountriesSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SystemCountriesSqlDataPrvider();
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
        /// Converts the SystemCountries object properties to SQL paramters and executes the create SystemCountries procedure 
        /// and updates the SystemCountries object with the SQL data by reference.
        /// <example>[Example]bool status=SystemCountriesSqlDataPrvider.Instance.Create(systemCountriesObject);.</example>
        /// </summary>
        /// <param name="systemCountriesObject">The SystemCountries object.</param>
        /// <returns>The status of create query.</returns>
        public bool Create(SystemCountriesEntity systemCountriesObject)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SystemCountries_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@id", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@country", SqlDbType.NVarChar, 255).Value = systemCountriesObject.country;
                // Execute the command
                bool status = false;
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                    //Get ID value from database and set it in object
                    systemCountriesObject.id = (int)myCommand.Parameters["@id"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Converts the SystemCountries object properties to SQL paramters and executes the update SystemCountries procedure.
        /// <example>[Example]bool  status=SystemCountriesSqlDataPrvider.Instance.Update(systemCountriesObject);.</example>
        /// </summary>
        /// <param name="systemCountriesObject">The SystemCountries object.</param>
        /// <returns>The status of update query.</returns>
        public bool Update(SystemCountriesEntity systemCountriesObject)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SystemCountries_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@id", SqlDbType.Int, 4).Value = systemCountriesObject.id;
                myCommand.Parameters.Add("@country", SqlDbType.NVarChar, 255).Value = systemCountriesObject.country;
                // Execute the command
                bool status = false;
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

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single SystemCountries object .
        /// <example>[Example]bool status=SystemCountriesSqlDataPrvider.Instance.Delete(id);.</example>
        /// </summary>
        /// <param name="id">The systemCountriesObject id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int id)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SystemCountries_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@id", SqlDbType.Int, 4).Value = id;
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

        #region --------------GetAllSystemCountries--------------
        public List<SystemCountriesEntity> GetAllSystemCountries()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<SystemCountriesEntity> systemCountriesList = new List<SystemCountriesEntity>();
                SystemCountriesEntity systemCountriesObject;
                SqlCommand myCommand = new SqlCommand("SystemCountries_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    systemCountriesObject = PopulateSystemCountriesEntityFromIDataReader(dr);
                    systemCountriesList.Add(systemCountriesObject);
                }
                dr.Close();
                myConnection.Close();
                return systemCountriesList;
            }
        }
        #endregion

        #region --------------GetAllSystemCountriesWithPager--------------
        public List<SystemCountriesEntity> GetAllSystemCountriesWithPager(int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<SystemCountriesEntity> systemCountriesList = new List<SystemCountriesEntity>();
                SystemCountriesEntity systemCountriesObject;
                SqlCommand myCommand = new SqlCommand("SystemCountries_GetAllWithPager", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    (systemCountriesObject) = PopulateSystemCountriesEntityFromIDataReader(dr);
                    systemCountriesList.Add(systemCountriesObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return systemCountriesList;
            }
        }
        #endregion

        #region --------------GetObject--------------
        public SystemCountriesEntity GetObject(int id)
        {
            SystemCountriesEntity systemCountriesObject = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SystemCountries_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@id", SqlDbType.Int, 4).Value = id;
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        systemCountriesObject = PopulateSystemCountriesEntityFromIDataReader(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return systemCountriesObject;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateSystemCountriesEntityFromIDataReader--------------
        private SystemCountriesEntity PopulateSystemCountriesEntityFromIDataReader(IDataReader reader)
        {
            //Create a new SystemCountries object
            SystemCountriesEntity systemCountriesObject = new SystemCountriesEntity();
            //Fill the object with data

            //id
            if (reader["id"] != DBNull.Value)
                systemCountriesObject.id = (int)reader["id"];
            //country_code
            if (reader["country_code"] != DBNull.Value)
                systemCountriesObject.country_code = (string)reader["country_code"];
            //country
            if (reader["country"] != DBNull.Value)
                systemCountriesObject.country = (string)reader["country"];
            //country_ar
            if (reader["country_ar"] != DBNull.Value)
                systemCountriesObject.country_ar = (string)reader["country_ar"];
            //TIMEZONE_H
            if (reader["TIMEZONE_H"] != DBNull.Value)
                systemCountriesObject.TIMEZONE_H = (int)reader["TIMEZONE_H"];
            //TIMEZONE_M
            if (reader["TIMEZONE_M"] != DBNull.Value)
                systemCountriesObject.TIMEZONE_M = (int)reader["TIMEZONE_M"];
            //reg_id
            if (reader["reg_id"] != DBNull.Value)
                systemCountriesObject.reg_id = (int)reader["reg_id"];
            //SimpleEnName
            if (reader["SimpleEnName"] != DBNull.Value)
                systemCountriesObject.SimpleEnName = (string)reader["SimpleEnName"];
            //SimpleArName
            if (reader["SimpleArName"] != DBNull.Value)
                systemCountriesObject.SimpleArName = (string)reader["SimpleArName"];
            //Return the populated object
            return systemCountriesObject;
        }
        //------------------------------------------
        #endregion
    }
}