using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
namespace DCCMSNameSpace
{
    public class CitiesSqlDataPrvider : SqlDataProvider
    {

        #region --------------Instance--------------
        private static CitiesSqlDataPrvider _Instance;
        public static CitiesSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new CitiesSqlDataPrvider();
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
        /// Converts the Cities object properties to SQL paramters and executes the create Cities procedure 
        /// and updates the Cities object with the SQL data by reference.
        /// <example>[Example]bool status=CitiesSqlDataPrvider.Instance.Create(cities);.</example>
        /// </summary>
        /// <param name="cities">The Cities object.</param>
        /// <returns>The status of create query.</returns>
        public bool Create(CitiesEntity cities)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Cities_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CityID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@CountryID", SqlDbType.Int, 4).Value = cities.CountryID;
                myCommand.Parameters.Add("@NameAr", SqlDbType.NVarChar, 32).Value = cities.NameAr;
                myCommand.Parameters.Add("@NameEn", SqlDbType.VarChar, 32).Value = cities.NameEn;
                myCommand.Parameters.Add("@GoogleMapHorizontal", SqlDbType.VarChar, 64).Value = cities.GoogleMapHorizontal;
                myCommand.Parameters.Add("@GoogleMapVertical", SqlDbType.VarChar, 64).Value = cities.GoogleMapVertical;
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
                    //Get ID value from database and set it in object
                    cities.CityID = (int)myCommand.Parameters["@CityID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }

        //------------------------------------------------------------------
        public bool Create2(CitiesEntity cities)
        {
            bool result = Createko(typeof(CitiesEntity), cities, "Cities");
            return result;
        }
        //------------------------------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Converts the Cities object properties to SQL paramters and executes the update Cities procedure.
        /// <example>[Example]bool  status=CitiesSqlDataPrvider.Instance.Update(cities);.</example>
        /// </summary>
        /// <param name="cities">The Cities object.</param>
        /// <returns>The status of update query.</returns>
        public bool Update(CitiesEntity cities)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Cities_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = cities.CityID;
                myCommand.Parameters.Add("@CountryID", SqlDbType.Int, 4).Value = cities.CountryID;
                myCommand.Parameters.Add("@NameAr", SqlDbType.NVarChar, 32).Value = cities.NameAr;
                myCommand.Parameters.Add("@NameEn", SqlDbType.VarChar, 32).Value = cities.NameEn;
                myCommand.Parameters.Add("@GoogleMapHorizontal", SqlDbType.VarChar, 64).Value = cities.GoogleMapHorizontal;
                myCommand.Parameters.Add("@GoogleMapVertical", SqlDbType.VarChar, 64).Value = cities.GoogleMapVertical;
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
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single Cities object .
        /// <example>[Example]bool status=CitiesSqlDataPrvider.Instance.Delete(cityID);.</example>
        /// </summary>
        /// <param name="cityID">The cities id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int cityID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Cities_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = cityID;
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
        public List<CitiesEntity> GetAll(int countryID, int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<CitiesEntity> citiesList = new List<CitiesEntity>();
                CitiesEntity cities;
                SqlCommand myCommand = new SqlCommand("Cities_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CountryID", SqlDbType.Int, 4).Value = countryID;
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
                    (cities) = PopulateCitiesEntityFromIDataReader(dr);
                    citiesList.Add(cities);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return citiesList;
            }
        }
        #endregion

        #region --------------GoogleSearch-------------
        public List<CitiesEntity> GoogleSearch(double NorthEast_Latitude, double NorthEast_Longitude, double SouthWest_Latitude, double SouthWest_Longitude)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<CitiesEntity> CitiesList = new List<CitiesEntity>();
                CitiesEntity city;
                SqlCommand myCommand = new SqlCommand("Cities_GoogleSearch", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@NorthEast_Latitude", SqlDbType.Float).Value = NorthEast_Latitude;
                myCommand.Parameters.Add("@NorthEast_Longitude", SqlDbType.Float).Value = NorthEast_Longitude;
                myCommand.Parameters.Add("@SouthWest_Latitude", SqlDbType.Float).Value = SouthWest_Latitude;
                myCommand.Parameters.Add("@SouthWest_Longitude", SqlDbType.Float).Value = SouthWest_Longitude;
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

                    city = PopulateCitiesEntityFromIDataReader(dr);
                    CitiesList.Add(city);
                }
                dr.Close();
                myConnection.Close();
                return CitiesList;
            }
        }
        #endregion

        #region --------------GetObject--------------
        public CitiesEntity GetObject(int cityID)
        {
            CitiesEntity cities = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Cities_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = cityID;
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
                        cities = PopulateCitiesEntityFromIDataReader(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return cities;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateCitiesEntityFromIDataReader--------------
        private CitiesEntity PopulateCitiesEntityFromIDataReader(IDataReader reader)
        {
            //Create a new Cities object
            CitiesEntity cities = new CitiesEntity();
            //Fill the object with data

            //CityID
            if (reader["CityID"] != DBNull.Value)
                cities.CityID = (int)reader["CityID"];
            //CountryID
            if (reader["CountryID"] != DBNull.Value)
                cities.CountryID = (int)reader["CountryID"];
            //NameAr
            if (reader["NameAr"] != DBNull.Value)
                cities.NameAr = (string)reader["NameAr"];
            //NameEn
            if (reader["NameEn"] != DBNull.Value)
                cities.NameEn = (string)reader["NameEn"];
            //GoogleMapHorizontal
            if (reader["GoogleMapHorizontal"] != DBNull.Value)
                cities.GoogleMapHorizontal = (double)reader["GoogleMapHorizontal"];
            //GoogleMapVertical
            if (reader["GoogleMapVertical"] != DBNull.Value)
                cities.GoogleMapVertical = (double)reader["GoogleMapVertical"];
            //Details -------------------------------------------------------
            //Return the populated object
            return cities;
        }
        //------------------------------------------
        #endregion
    }
}
