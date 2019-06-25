using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
namespace DCCMSNameSpace
{
    public class AdvertismentsSqlDataPrvider
    {

        #region --------------Instance--------------
        private static AdvertismentsSqlDataPrvider _Instance;
        public static AdvertismentsSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AdvertismentsSqlDataPrvider();
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
        public bool Save(AdvertismentsEntity advertisments, SPOperation operation)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Advertisments_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@SPOperation", SqlDbType.Int, 4).Value = (int)operation;
                if (operation == SPOperation.Insert)
                    myCommand.Parameters.Add("@AdvertiseID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                else
                    myCommand.Parameters.Add("@AdvertiseID", SqlDbType.Int, 4).Value = advertisments.AdvertiseID;

                myCommand.Parameters.Add("@PlaceID", SqlDbType.Int, 4).Value = advertisments.PlaceID;
                myCommand.Parameters.Add("@Url", SqlDbType.NVarChar, 256).Value = advertisments.Url;
                myCommand.Parameters.Add("@FileExtension", SqlDbType.VarChar, 50).Value = advertisments.FileExtension;
                myCommand.Parameters.Add("@FileType", SqlDbType.Int, 4).Value = (int)advertisments.FileType;
                myCommand.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = advertisments.IsActive;
                myCommand.Parameters.Add("@Weight", SqlDbType.Int, 4).Value = advertisments.Weight;
                myCommand.Parameters.Add("@MaxApperance", SqlDbType.Int, 4).Value = advertisments.MaxApperance;
                myCommand.Parameters.Add("@MaxClicks", SqlDbType.Int, 4).Value = advertisments.MaxClicks;
                myCommand.Parameters.Add("@ApperanceCount", SqlDbType.Int, 4).Value = advertisments.ApperanceCount;
                myCommand.Parameters.Add("@ClicksCount", SqlDbType.Int, 4).Value = advertisments.ClicksCount;
                myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 256).Value = advertisments.Title;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)advertisments.LangID;
                myCommand.Parameters.Add("@IsSmall", SqlDbType.Bit).Value = (bool)advertisments.IsSmall;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = advertisments.OwnerID;
                myCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = advertisments.OwnerName;
                //----------------------------------------------------------------------------------
                // Execute the command
                bool status = false;
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                    //Get ID value from database and set it in object
                    advertisments.AdvertiseID = (int)myCommand.Parameters["@AdvertiseID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single Advertisments object .
        /// <example>[Example]bool status=AdvertismentsSqlDataPrvider.Instance.Delete(advertiseID);.</example>
        /// </summary>
        /// <param name="advertiseID">The advertisments id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int advertiseID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Advertisments_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@AdvertiseID", SqlDbType.Int, 4).Value = advertiseID;
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
        public List<AdvertismentsEntity> GetAll(Languages langID, int placeID, Guid OwnerID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<AdvertismentsEntity> advertismentsList = new List<AdvertismentsEntity>();
                AdvertismentsEntity advertisments;
                SqlCommand myCommand = new SqlCommand("Advertisments_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@PlaceID", SqlDbType.Int, 4).Value = placeID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit).Value = isAvailableCondition;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //---------------------------------------------------------------------
                if (OwnerID != null)
                {
                    Guid _OwnerID = new Guid(OwnerID.ToString());
                   // if (_OwnerID != Guid.Empty)
                        myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = _OwnerID;
                }
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    (advertisments) = PopulateEntity(dr);
                    advertismentsList.Add(advertisments);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return advertismentsList;
            }
        }
        #endregion

        #region --------------GetObject--------------
        public AdvertismentsEntity GetObject(int advertiseID)
        {
            AdvertismentsEntity advertisments = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Advertisments_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@AdvertiseID", SqlDbType.Int, 4).Value = advertiseID;
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        advertisments = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return advertisments;
            }
        }
        //------------------------------------------
        #endregion

        

        #region --------------UpdateActivity--------------
        public bool UpdateActivity(int advertiseID, int placeID, int isActive)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Advertisments_UpdateActivity", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@AdvertiseID", SqlDbType.Int, 4).Value = advertiseID;
                myCommand.Parameters.Add("@PlaceID", SqlDbType.Int, 4).Value = placeID;
                myCommand.Parameters.Add("@IsActive", SqlDbType.Bit).Value = isActive;
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

        #region --------------GetAdForShow--------------
        public AdvertismentsEntity GetAdForShow(int placeID, Guid OwnerID, Languages langID)
        {
            AdvertismentsEntity advertisment = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Advertisments_GetAdForShow", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@PlaceID", SqlDbType.Int, 4).Value = placeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //---------------------------------------------------------------------
                if (OwnerID != null)
                {
                    Guid _OwnerID = new Guid(OwnerID.ToString());
                    // if (_OwnerID != Guid.Empty)
                    myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = _OwnerID;
                }
                //---------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        advertisment = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                if (advertisment != null)
                    IncreaseApperanceCount(advertisment.AdvertiseID);
                return advertisment;
            }
        }
        public List<AdvertismentsEntity> GetSeparatedAdForShow(int PlaceID, Guid OwnerID, int Count)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<AdvertismentsEntity> advertismentsList = new List<AdvertismentsEntity>();
                AdvertismentsEntity advertisments;
                SqlCommand myCommand = new SqlCommand("Advertisments_GetSeparatedAdForShow", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@PlaceID", SqlDbType.Int, 4).Value = PlaceID;
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = Count;
                //---------------------------------------------------------------------
                if (OwnerID != null)
                {
                    Guid _OwnerID = new Guid(OwnerID.ToString());
                    // if (_OwnerID != Guid.Empty)
                    myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = _OwnerID;
                }
                else
                {
                    myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = Guid.Empty;
                }
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    (advertisments) = PopulateEntity(dr);
                    advertismentsList.Add(advertisments);
                }
                dr.Close();
                myConnection.Close();
                return advertismentsList;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------IncreaseApperanceCount--------------
        public bool IncreaseApperanceCount(int advertiseID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Advertisments_IncreaseApperanceCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@AdvertiseID", SqlDbType.Int, 4).Value = advertiseID;
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

        #region --------------IncreaseClicksCount--------------
        public bool IncreaseClicksCount(int advertiseID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Advertisments_IncreaseClicksCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@AdvertiseID", SqlDbType.Int, 4).Value = advertiseID;
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

        #region --------------PopulateEntity--------------
        private AdvertismentsEntity PopulateEntity(IDataReader reader)
        {
            //Create a new Advertisments object
            AdvertismentsEntity advertisments = new AdvertismentsEntity();
            //Fill the object with data
            //AdvertiseID
            if (reader["AdvertiseID"] != DBNull.Value)
                advertisments.AdvertiseID = (int)reader["AdvertiseID"];
            //PlaceID
            if (reader["PlaceID"] != DBNull.Value)
                advertisments.PlaceID = (int)reader["PlaceID"];
            //Url
            if (reader["Url"] != DBNull.Value)
                advertisments.Url = (string)reader["Url"];
            //FileExtension
            if (reader["FileExtension"] != DBNull.Value)
                advertisments.FileExtension = (string)reader["FileExtension"];
            //FileType
            if (reader["FileType"] != DBNull.Value)
                advertisments.FileType = (AdsTypes)reader["FileType"];
            //IsActive
            if (reader["IsActive"] != DBNull.Value)
                advertisments.IsActive = (bool)reader["IsActive"];
            //Weight
            if (reader["Weight"] != DBNull.Value)
                advertisments.Weight = (int)reader["Weight"];
            //MaxApperance
            if (reader["MaxApperance"] != DBNull.Value)
                advertisments.MaxApperance = (int)reader["MaxApperance"];
            //MaxClicks
            if (reader["MaxClicks"] != DBNull.Value)
                advertisments.MaxClicks = (int)reader["MaxClicks"];
            //ApperanceCount
            if (reader["ApperanceCount"] != DBNull.Value)
                advertisments.ApperanceCount = (int)reader["ApperanceCount"];
            //ClicksCount
            if (reader["ClicksCount"] != DBNull.Value)
                advertisments.ClicksCount = (int)reader["ClicksCount"];
            //Title
            if (reader["Title"] != DBNull.Value)
                advertisments.Title = (string)reader["Title"];

            //Width
            if (reader["Width"] != DBNull.Value)
                advertisments.Width = (int)reader["Width"];
            //Height
            if (reader["Height"] != DBNull.Value)
                advertisments.Height = (int)reader["Height"];
            //LangID
            if (reader["LangID"] != DBNull.Value)
                advertisments.LangID = (Languages)reader["LangID"];
            if (reader["IsSmall"] != DBNull.Value)
                advertisments.IsSmall = (bool)reader["IsSmall"];
            //------------------------------------------------------------------
            //OwnerID
            if (reader["OwnerID"] != DBNull.Value)
                advertisments.OwnerID = (Guid)reader["OwnerID"];
            //------------------------------------------------------------------
            //OwnerName
            if (reader["OwnerName"] != DBNull.Value)
                advertisments.OwnerName = (string)reader["OwnerName"];
            //------------------------------------------------------------------
            //Return the populated object
            return advertisments;
        }
        //------------------------------------------
        #endregion
    }
}

