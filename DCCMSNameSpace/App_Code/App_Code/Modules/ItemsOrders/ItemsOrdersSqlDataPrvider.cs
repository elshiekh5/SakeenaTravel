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
    /// News SQL data provider which represents the data access layer of ItemsOrders.
    /// </summary>
    public class ItemsOrdersSqlDataPrvider: SqlDataProvider
    {

        #region --------------Instance--------------
        //------------------------------------------------------------------------------------------------------
        private static ItemsOrdersSqlDataPrvider _Instance;
        //--------------------------------------------------------------------
        /// <summary>
        /// Gets instance of ItemsOrdersSqlDataPrvider calss.
        /// <example>ItemsOrdersSqlDataPrvider dp=ItemsOrdersSqlDataPrvider.Instance.</example>
        /// </summary>
        //--------------------------------------------------------------------
        public static ItemsOrdersSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ItemsOrdersSqlDataPrvider();
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
        /// <param name="ItemsOrdersObj">Model object.</param>
        /// <returns>The result of create query.</returns>
        //--------------------------------------------------------------------
        public bool Create(ItemsOrdersModel ItemsOrdersObj, List<ItemsOrdersDetailsModel> productsList)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrders_Create]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OrderID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
				myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ItemsOrdersObj.UserId;
				//myCommand.Parameters.Add("@Status", SqlDbType.Int, 4).Value = ItemsOrdersObj.Status;
				myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar, 500).Value = ItemsOrdersObj.Comment;
                myCommand.Parameters.Add("@CustomerName", SqlDbType.NVarChar, 128).Value = ItemsOrdersObj.CustomerName;
                myCommand.Parameters.Add("@CustomerEmail", SqlDbType.NVarChar, 128).Value = ItemsOrdersObj.CustomerEmail;
                myCommand.Parameters.Add("@CustomerPhone", SqlDbType.NVarChar, 32).Value = ItemsOrdersObj.CustomerPhone;
                myCommand.Parameters.Add("@CustomerMobile", SqlDbType.NVarChar, 32).Value = ItemsOrdersObj.CustomerMobile;
                myCommand.Parameters.Add("@CustomerAddress", SqlDbType.NVarChar, 256).Value = ItemsOrdersObj.CustomerAddress;
				//myCommand.Parameters.Add("@DateAdded", SqlDbType.DateTime2, 8).Value = ItemsOrdersObj.DateAdded;
                //----------------------------------------------------------------------------------------------
                // Execute the command
                //----------------------------------------------------------------------------------------------
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    result = true;
                    //Get ID value from database and set it in object
                    ItemsOrdersObj.OrderID = (int)myCommand.Parameters["@OrderID"].Value;
                SaveDetails(myConnection, ItemsOrdersObj.OrderID, productsList);
                }
                myConnection.Close();
                return result;
                //----------------------------------------------------------------------------------------------
            }
        }
        //------------------------------------------------------------------------------------------------------
        #endregion
        #region /*--------- SaveDetails ---------*\
        //--------------------------------------------------------------------
        public void SaveDetails(SqlConnection myConnection,int orderID, List<ItemsOrdersDetailsModel> productsList)
        {
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrdersDetails_Create]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@OrderID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128);
                myCommand.Parameters.Add("@Price", SqlDbType.NVarChar, 128);
                myCommand.Parameters.Add("@Quantity", SqlDbType.Int, 4);
                //----------------------------------------------------------------------------------------------
                // Set the command
                //----------------------------------------------------------------------------------------------
                foreach (ItemsOrdersDetailsModel item in productsList)
                {
                    myCommand.Parameters["@ItemID"].Value = item.ItemID;
                    myCommand.Parameters["@OrderID"].Value = orderID;
                    myCommand.Parameters["@Title"].Value = item.Title;
                    myCommand.Parameters["@Price"].Value = item.Price;
                    myCommand.Parameters["@Quantity"].Value = item.Quantity;
                    myCommand.ExecuteNonQuery();
                }

        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region /*--------- Updat ---------*\
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Converts the object properties to SQL paramters and executes the update procedure.
        /// </summary>
        /// <param name="ItemsOrdersObj">Model object.</param>
        /// <returns>The result of update query.</returns>
        //--------------------------------------------------------------------
        public bool Updat(ItemsOrdersModel ItemsOrdersObj)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrders_Update]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OrderID", SqlDbType.Int, 4).Value = ItemsOrdersObj.OrderID;
                //myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = ItemsOrdersObj.UserId;
				myCommand.Parameters.Add("@Status", SqlDbType.Int, 4).Value = ItemsOrdersObj.Status;
				myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar, 500).Value = ItemsOrdersObj.Comment;
				//myCommand.Parameters.Add("@DateAdded", SqlDbType.DateTime2, 8).Value = ItemsOrdersObj.DateAdded;

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
        /// <param name="OrderID">The model id.</param>
        /// <returns>The result of delete query.</returns>
        //--------------------------------------------------------------------
        public bool Delete(int OrderID)
        {
            bool result = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrders_Delete]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OrderID", SqlDbType.Int, 4).Value = OrderID;
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
        public List<ItemsOrdersModel> GetPageByPage(int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                //----------------------------------------------------------------------------------------------
                List<ItemsOrdersModel> ItemsOrdersList = new List<ItemsOrdersModel>();
                ItemsOrdersModel ItemsOrdersObj;
                //----------------------------------------------------------------------------------------------
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrders_GetPageByPage]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
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
                    ItemsOrdersObj = PopulateModelFromIDataReader(dr);
                    ItemsOrdersList.Add(ItemsOrdersObj);
                }
                dr.Close();
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                myConnection.Close();
                //----------------------------------------------------------------------------------------------
                return ItemsOrdersList;
                //----------------------------------------------------------------------------------------------
            }
        }
        //------------------------------------------------------------------------------------------------------
        #endregion

        #region /*--------- GetPageByPageForUser ---------*\
        //------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Gets the spesific Records.
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns>The result of query.</returns>
        //--------------------------------------------------------------------
        public List<ItemsOrdersModel> GetPageByPageForUser(Guid userID, int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                //----------------------------------------------------------------------------------------------
                List<ItemsOrdersModel> ItemsOrdersList = new List<ItemsOrdersModel>();
                ItemsOrdersModel ItemsOrdersObj;
                //----------------------------------------------------------------------------------------------
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrders_GetPageByPageForUser]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier, 16).Value = userID;
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
                    ItemsOrdersObj = PopulateModelFromIDataReader(dr);
                    ItemsOrdersList.Add(ItemsOrdersObj);
                }
                dr.Close();
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                myConnection.Close();
                //----------------------------------------------------------------------------------------------
                return ItemsOrdersList;
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
        /// <param name="OrderID">The ItemsOrdersObj id.</param>
        /// <returns>Model object.</returns>
        //--------------------------------------------------------------------
        public List<ItemsOrdersModel> Get(int OrderID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                //----------------------------------------------------------------------------------------------
                List<ItemsOrdersModel> ItemsOrdersList = new List<ItemsOrdersModel>();
                ItemsOrdersModel ItemsOrdersObj;
                //----------------------------------------------------------------------------------------------
                SqlCommand myCommand = new SqlCommand("[dbo].[ItemsOrders_Get]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------------------------------------
                // Set the parameters
                //----------------------------------------------------------------------------------------------
                if(OrderID>0)
                    myCommand.Parameters.Add("@OrderID", SqlDbType.Int, 4).Value = OrderID;
                 // Execute the command
                //----------------------------------------------------------------------------------------------
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    ItemsOrdersObj = PopulateModelFromIDataReader(dr);
                    ItemsOrdersList.Add(ItemsOrdersObj);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------------------------------------
                return ItemsOrdersList;
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
        private ItemsOrdersModel PopulateModelFromIDataReader(IDataReader reader)
        {
            //Create a new object
            ItemsOrdersModel ItemsOrdersObj = new ItemsOrdersModel();
            //Fill the object with data
            //------------------------------------------------
            //OrderID
            //------------------------------------------------
            if (reader["OrderID"] != DBNull.Value)
                ItemsOrdersObj.OrderID = (int)reader["OrderID"];
            //------------------------------------------------

			//------------------------------------------------
			//[UserId]
			//------------------------------------------------
			if (reader["UserId"] != DBNull.Value)
			    ItemsOrdersObj.UserId = (Guid)reader["UserId"];
			//------------------------------------------------
			//------------------------------------------------
			//[Status]
			//------------------------------------------------
			if (reader["Status"] != DBNull.Value)
			    ItemsOrdersObj.Status = (int)reader["Status"];
			//------------------------------------------------
			//------------------------------------------------
			//[Comment]
			//------------------------------------------------
			if (reader["Comment"] != DBNull.Value)
			    ItemsOrdersObj.Comment = (string)reader["Comment"];
			//------------------------------------------------
			//------------------------------------------------
			//[DateAdded]
			//------------------------------------------------
			if (reader["DateAdded"] != DBNull.Value)
			    ItemsOrdersObj.DateAdded = (DateTime)reader["DateAdded"];
			//------------------------------------------------
            //------------------------------------------------
            //[CustomerName]
			//------------------------------------------------
            if (reader["CustomerName"] != DBNull.Value)
                ItemsOrdersObj.CustomerName = (string)reader["CustomerName"];
            //------------------------------------------------
            //[CustomerEmail]
            //------------------------------------------------
            if (reader["CustomerEmail"] != DBNull.Value)
                ItemsOrdersObj.CustomerEmail = (string)reader["CustomerEmail"];
            //------------------------------------------------
            //[CustomerPhone]
            //------------------------------------------------
            if (reader["CustomerPhone"] != DBNull.Value)
                ItemsOrdersObj.CustomerPhone = (string)reader["CustomerPhone"];
            //------------------------------------------------
            //[CustomerMobile]
            //------------------------------------------------
            if (reader["CustomerMobile"] != DBNull.Value)
                ItemsOrdersObj.CustomerMobile = (string)reader["CustomerMobile"];
            //------------------------------------------------
            //[CustomerAddress]
            //------------------------------------------------
            if (reader["CustomerAddress"] != DBNull.Value)
                ItemsOrdersObj.CustomerAddress = (string)reader["CustomerAddress"];
            //------------------------------------------------
            //Return the populated object
            return ItemsOrdersObj;
        }
        //------------------------------------------------------------------------------------------------------
        #endregion
    }
}