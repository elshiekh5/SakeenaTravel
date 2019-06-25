using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace DCCMSNameSpace
{
    /// <summary>
    /// News SQL data provider which represents the data access layer of ItemsOrdersDetails.
    /// </summary>
    public class ItemsOrdersDetailsSqlDataPrvider : SqlDataProvider
    {

        #region --------------Instance--------------
        //------------------------------------------------------------------------------------------------------
        private static ItemsOrdersDetailsSqlDataPrvider _Instance;
        //--------------------------------------------------------------------
        /// <summary>
        /// Gets instance of ItemsOrdersDetailsSqlDataPrvider calss.
        /// <example>ItemsOrdersDetailsSqlDataPrvider dp=ItemsOrdersDetailsSqlDataPrvider.Instance.</example>
        /// </summary>
        //--------------------------------------------------------------------
        public static ItemsOrdersDetailsSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ItemsOrdersDetailsSqlDataPrvider();
                }
                return _Instance;
            }
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        

        #region /*--------- Create ---------*\
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Converts the  object properties to SQL paramters and executes the create  procedure 
        /// and updates the object with the SQL data by reference.
        /// </summary>
        /// <param name="ItemsOrdersDetailsObj">Model object.</param>
        /// <returns>The result of create query.</returns>
        //--------------------------------------------------------------------
        public bool Create(ItemsOrdersDetailsModel ItemsOrdersDetailsObj)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrdersDetails_Create]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
				myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = ItemsOrdersDetailsObj.Title;
				myCommand.Parameters.Add("@Price", SqlDbType.NVarChar, 128).Value = ItemsOrdersDetailsObj.Price;
				myCommand.Parameters.Add("@Quantity", SqlDbType.Int, 4).Value = ItemsOrdersDetailsObj.Quantity;

                //----------------------------------------------------------------------------------------------
                // Execute the command
                //----------------------------------------------------------------------------------------------
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                    //Get ID value from database and set it in object
                    ItemsOrdersDetailsObj.ItemID = (int)myCommand.Parameters["@ItemID"].Value;
                }
                myConnection.Close();
                return result;
                //----------------------------------------------------------------------------------------------
            }
        }
        //------------------------------------------------------------------------------------------------------
        #endregion
        
        #region /*--------- Updat ---------*\
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Converts the object properties to SQL paramters and executes the update procedure.
        /// </summary>
        /// <param name="ItemsOrdersDetailsObj">Model object.</param>
        /// <returns>The result of update query.</returns>
        //--------------------------------------------------------------------
        public bool Updat(ItemsOrdersDetailsModel ItemsOrdersDetailsObj)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrdersDetails_Update]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = ItemsOrdersDetailsObj.ItemID;
				myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = ItemsOrdersDetailsObj.Title;
				myCommand.Parameters.Add("@Price", SqlDbType.NVarChar, 128).Value = ItemsOrdersDetailsObj.Price;
				myCommand.Parameters.Add("@Quantity", SqlDbType.Int, 4).Value = ItemsOrdersDetailsObj.Quantity;

                //----------------------------------------------------------------------------------------------
                // Execute the command
                //----------------------------------------------------------------------------------------------
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                myConnection.Close();
                return result;
                //----------------------------------------------------------------------------------------------
            }
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region /*--------- Delete ---------*\
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Deletes single object .
        /// </summary>
        /// <param name="ItemID">The model id.</param>
        /// <returns>The result of delete query.</returns>
        //--------------------------------------------------------------------
        public bool Delete(int ItemID)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrdersDetails_Delete]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = ItemID;
                //----------------------------------------------------------------------------------------------
                // Execute the command
                //----------------------------------------------------------------------------------------------
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                }
                myConnection.Close();
                return result;
                //----------------------------------------------------------------------------------------------
            }
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region /*--------- GetPageByPage ---------*\
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the spesific Records.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns>The result of query.</returns>
        //--------------------------------------------------------------------
        public List<ItemsOrdersDetailsModel> GetPageByPage(int OrderID,int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                //----------------------------------------------------------------------------------------------
                List<ItemsOrdersDetailsModel> ItemsOrdersDetailsList = new List<ItemsOrdersDetailsModel>();
                ItemsOrdersDetailsModel ItemsOrdersDetailsObj;
                //----------------------------------------------------------------------------------------------
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrdersDetails_GetPageByPage]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OrderID", SqlDbType.Int, 4).Value = OrderID;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //----------------------------------------------------------------------------------------------
                // Execute the command
                //----------------------------------------------------------------------------------------------
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    ItemsOrdersDetailsObj = PopulateModelFromIDataReader(dr);
                    ItemsOrdersDetailsList.Add(ItemsOrdersDetailsObj);
                }
                dr.Close();
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                myConnection.Close();
                //----------------------------------------------------------------------------------------------
                return ItemsOrdersDetailsList;
                //----------------------------------------------------------------------------------------------
            }
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region /*--------- Get ---------*\
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the spesific Records.
        /// </summary>
        /// <param name="ItemID">The ItemsOrdersDetailsObj id.</param>
        /// <returns>Model object.</returns>
        //--------------------------------------------------------------------
        public List<ItemsOrdersDetailsModel> Get(int orderID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                //----------------------------------------------------------------------------------------------
                List<ItemsOrdersDetailsModel> ItemsOrdersDetailsList = new List<ItemsOrdersDetailsModel>();
                ItemsOrdersDetailsModel ItemsOrdersDetailsObj;
                //----------------------------------------------------------------------------------------------
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrdersDetails_Get]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                    myCommand.Parameters.Add("@OrderID", SqlDbType.Int, 4).Value = orderID;
                 // Execute the command
                //----------------------------------------------------------------------------------------------
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    ItemsOrdersDetailsObj = PopulateModelFromIDataReader(dr);
                    ItemsOrdersDetailsList.Add(ItemsOrdersDetailsObj);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------------------------------------
                return ItemsOrdersDetailsList;
                //----------------------------------------------------------------------------------------------
            }
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region /*--------- PopulateModelFromIDataReader ---------*\
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Populates model from IDataReader .
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Model object.</returns>
        //--------------------------------------------------------------------
        private ItemsOrdersDetailsModel PopulateModelFromIDataReader(IDataReader reader)
        {
            //Create a new object
            ItemsOrdersDetailsModel ItemsOrdersDetailsObj = new ItemsOrdersDetailsModel();
            //Fill the object with data
            //------------------------------------------------
            //ItemID
            //------------------------------------------------
            if (reader["ItemID"] != DBNull.Value)
                ItemsOrdersDetailsObj.ItemID = (int)reader["ItemID"];
            //------------------------------------------------

			//------------------------------------------------
			//[Title]
			//------------------------------------------------
			if (reader["Title"] != DBNull.Value)
			    ItemsOrdersDetailsObj.Title = (string)reader["Title"];
			//------------------------------------------------
			//------------------------------------------------
			//[Price]
			//------------------------------------------------
			if (reader["Price"] != DBNull.Value)
			    ItemsOrdersDetailsObj.Price = (string)reader["Price"];
			//------------------------------------------------
			//------------------------------------------------
			//[Quantity]
			//------------------------------------------------
			if (reader["Quantity"] != DBNull.Value)
			    ItemsOrdersDetailsObj.Quantity = (int)reader["Quantity"];
            //------------------------------------------------
            //[CurrentPrice]
            //------------------------------------------------
            if (reader["CurrentPrice"] != DBNull.Value)
                ItemsOrdersDetailsObj.CurrentPrice = (string)reader["CurrentPrice"];
            //------------------------------------------------
            //[Barcode]
            //------------------------------------------------
            if (reader["Barcode"] != DBNull.Value)
                ItemsOrdersDetailsObj.Barcode = (string)reader["Barcode"];
            //------------------------------------------------
            //[ByUnit]
            //------------------------------------------------
            if (reader["ByUnit"] != DBNull.Value)
                ItemsOrdersDetailsObj.ByUnit = (string)reader["ByUnit"];
            //------------------------------------------------
            //[ByCarton]
            //------------------------------------------------
            if (reader["ByCarton"] != DBNull.Value)
                ItemsOrdersDetailsObj.ByCarton = (string)reader["ByCarton"];
            //------------------------------------------------
            //Return the populated object
            return ItemsOrdersDetailsObj;
        }
        //------------------------------------------------------------------------------------------------------
        #endregion
    }
}