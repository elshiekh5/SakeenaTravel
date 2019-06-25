using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
namespace DCCMSNameSpace
{
    public class AdvPlacesSqlDataPrvider
    {

        #region --------------Instance--------------
        private static AdvPlacesSqlDataPrvider _Instance;
        public static AdvPlacesSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AdvPlacesSqlDataPrvider();
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

        public ExecuteCommandStatus Save(AdvPlacesEntity advPlaces, SPOperation operation)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("AdvPlaces_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                //PlaceID
                myCommand.Parameters.Add("@SPOperation", SqlDbType.Int, 4).Value = (int)operation;
                myCommand.Parameters.Add("@PlaceID", SqlDbType.Int, 4).Value = advPlaces.PlaceID;
                myCommand.Parameters.Add("@PlaceIdentifier", SqlDbType.VarChar, 32).Value = advPlaces.PlaceIdentifier;
                myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 64).Value = advPlaces.Title;
                myCommand.Parameters.Add("@Width", SqlDbType.Int, 4).Value = advPlaces.Width;
                myCommand.Parameters.Add("@Height", SqlDbType.Int, 4).Value = advPlaces.Height;
                myCommand.Parameters.Add("@DefaultFilePath", SqlDbType.NVarChar, 128).Value = advPlaces.DefaultFilePath;
                myCommand.Parameters.Add("@DefaultFileType", SqlDbType.Int, 4).Value = (AdsTypes)advPlaces.DefaultFileType;
                myCommand.Parameters.Add("@ActiveAdvertiseID", SqlDbType.Int, 4).Value = advPlaces.ActiveAdvertiseID;
                myCommand.Parameters.Add("@IsRandom", SqlDbType.Bit, 1).Value = advPlaces.IsRandom;
                myCommand.Parameters.Add("@EnableSeparatedAd", SqlDbType.Bit, 1).Value = advPlaces.EnableSeparatedAd;
                myCommand.Parameters.Add("@EnableSeparatedCount", SqlDbType.Int, 4).Value = advPlaces.EnableSeparatedCount;
                myCommand.Parameters.Add("@PlaceType", SqlDbType.Int, 4).Value = (int)advPlaces.PlaceType;
                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single AdvPlaces object .
        /// <example>[Example]bool status=AdvPlacesSqlDataPrvider.Instance.Delete(placeID);.</example>
        /// </summary>
        /// <param name="placeID">The advPlaces id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int placeID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("AdvPlaces_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@PlaceID", SqlDbType.Int, 4).Value = placeID;
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
        public List<AdvPlacesEntity> GetAll(AdvPlaceTypes PlaceType,int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<AdvPlacesEntity> advPlacesList = new List<AdvPlacesEntity>();
                AdvPlacesEntity advPlaces;
                SqlCommand myCommand = new SqlCommand("AdvPlaces_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@PlaceType", SqlDbType.Int, 4).Value = (int)PlaceType;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    (advPlaces) = PopulateEntity(dr);
                    advPlacesList.Add(advPlaces);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return advPlacesList;
            }
        }
        #endregion

        #region --------------GetCountAdvPlaces--------------
        public int GetCountAdvPlaces()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("AdvPlaces_GetCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Execute the command
                myConnection.Open();
                int itemsCount = (int)myCommand.ExecuteScalar();
                myConnection.Close();
                return itemsCount;
            }
        }
        #endregion

        #region --------------GetObject--------------
        public AdvPlacesEntity GetObject(int placeID)
        {
            AdvPlacesEntity advPlaces = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("AdvPlaces_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@PlaceID", SqlDbType.Int, 4).Value = placeID;
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        advPlaces = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return advPlaces;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateEntity--------------
        private AdvPlacesEntity PopulateEntity(IDataReader reader)
        {
            //Create a new AdvPlaces object
            AdvPlacesEntity advPlaces = new AdvPlacesEntity();
            //Fill the object with data
            //PlaceID
            if (reader["PlaceID"] != DBNull.Value)
                advPlaces.PlaceID = (int)reader["PlaceID"];
            //PlaceIdentifier
            if (reader["PlaceIdentifier"] != DBNull.Value)
                advPlaces.PlaceIdentifier = (string)reader["PlaceIdentifier"];
            //Title
            if (reader["Title"] != DBNull.Value)
                advPlaces.Title = (string)reader["Title"];
            //Width
            if (reader["Width"] != DBNull.Value)
                advPlaces.Width = (int)reader["Width"];
            //Height
            if (reader["Height"] != DBNull.Value)
                advPlaces.Height = (int)reader["Height"];
            //DefaultFilePath
            if (reader["DefaultFilePath"] != DBNull.Value)
                advPlaces.DefaultFilePath = (string)reader["DefaultFilePath"];
            //DefaultFileType
            if (reader["DefaultFileType"] != DBNull.Value)
                advPlaces.DefaultFileType = (AdsTypes)reader["DefaultFileType"];
            //ActiveAdvertiseID
            if (reader["ActiveAdvertiseID"] != DBNull.Value)
                advPlaces.ActiveAdvertiseID = (int)reader["ActiveAdvertiseID"];
            //IsRandom
            if (reader["IsRandom"] != DBNull.Value)
                advPlaces.IsRandom = (bool)reader["IsRandom"];
            //EnableSeparatedAd
            if (reader["EnableSeparatedAd"] != DBNull.Value)
                advPlaces.EnableSeparatedAd = (bool)reader["EnableSeparatedAd"];
            //EnableSeparatedCount
            if (reader["EnableSeparatedCount"] != DBNull.Value)
                advPlaces.EnableSeparatedCount = (int)reader["EnableSeparatedCount"];
            //PlaceType
            if (reader["PlaceType"] != DBNull.Value)
                advPlaces.PlaceType = (AdvPlaceTypes)reader["PlaceType"];
            //Return the populated object
            return advPlaces;
        }
        //------------------------------------------
        #endregion
    }
}

