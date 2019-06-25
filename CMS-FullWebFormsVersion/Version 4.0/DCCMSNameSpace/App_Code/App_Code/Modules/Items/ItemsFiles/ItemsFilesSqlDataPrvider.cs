using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using DCCMSNameSpace;


namespace DCCMSNameSpace
{
    public class ItemsFilesSqlDataPrvider
    {

        #region --------------Instance--------------
        private static ItemsFilesSqlDataPrvider _Instance;
        public static ItemsFilesSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ItemsFilesSqlDataPrvider();
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
        /// Converts the ItemsFiles object properties to SQL paramters and executes the create ItemsFiles procedure 
        /// and updates the ItemsFiles object with the SQL data by reference.
        /// <example>[Example]bool status=ItemsFilesSqlDataPrvider.Instance.Create(ItemsFiles);.</example>
        /// </summary>
        /// <param name="ItemsFiles">The ItemsFiles object.</param>
        /// <returns>The status of create query.</returns>
        public bool Create(ItemsFilesEntity ItemsFiles)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsFiles_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@FileID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = ItemsFiles.ItemID;
                myCommand.Parameters.Add("@FileExtension", SqlDbType.VarChar).Value = ItemsFiles.FileExtension;
                myCommand.Parameters.Add("@FileType", SqlDbType.Int, 4).Value = (int)ItemsFiles.FileType;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ItemsFiles.ModuleTypeID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@InsertUserName", SqlDbType.NVarChar, 64).Value = (string)ItemsFiles.InsertUserName;
                myCommand.Parameters.Add("@Title", SqlDbType.VarChar).Value = ItemsFiles.Title;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = ItemsFiles.OwnerID;
                myCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = ItemsFiles.OwnerName;
                //----------------------------------------------------------------------------------------------
                // Execute the command
                bool status = false;
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                    //Get ID value from database and set it in object
                    ItemsFiles.FileID = (int)myCommand.Parameters["@FileID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        public bool Update(ItemsFilesEntity ItemsFiles)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsFiles_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@FileID", SqlDbType.Int, 4).Value = ItemsFiles.FileID;
                myCommand.Parameters.Add("@FileExtension", SqlDbType.VarChar).Value = ItemsFiles.FileExtension;
                myCommand.Parameters.Add("@FileType", SqlDbType.Int, 4).Value = (int)ItemsFiles.FileType;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@LastUpdateUserName", SqlDbType.NVarChar, 64).Value = (string)ItemsFiles.LastUpdateUserName;
                myCommand.Parameters.Add("@Title", SqlDbType.VarChar).Value = ItemsFiles.Title;
                //----------------------------------------------------------------------------------------------
                //OwnerID
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = ItemsFiles.OwnerID;
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
        /// Deletes single ItemsFiles object .
        /// <example>[Example]bool status=ItemsFilesSqlDataPrvider.Instance.Delete(FileID);.</example>
        /// </summary>
        /// <param name="FileID">The ItemsFiles id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int FileID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsFiles_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@FileID", SqlDbType.Int, 4).Value = FileID;
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
        public List<ItemsFilesEntity> GetAll(int itemID, int moduleTypeID, ItemFileTypes FileType, int pageIndex, int pageSize, out int totalRecords, int CategoryID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsFilesEntity> ItemsFilesList = new List<ItemsFilesEntity>();
                ItemsFilesEntity ItemsFiles;
                SqlCommand myCommand = new SqlCommand("ItemsFiles_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@FileType", SqlDbType.Int, 4).Value = (int)FileType;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 8).Value = (int)moduleTypeID;
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
                    (ItemsFiles) = PopulateItemsFilesEntityFromIDataReader(dr);
                    ItemsFilesList.Add(ItemsFiles);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = ItemsFilesList.Count;
                //----------------------------------------------------------------
                return ItemsFilesList;
            }
        }
        #endregion

        #region --------------GetLast--------------
        public List<ItemsFilesEntity> GetLast(int itemID, int moduleTypeID, ItemFileTypes fileType, int count, int CategoryID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsFilesEntity> ItemsFilesList = new List<ItemsFilesEntity>();
                ItemsFilesEntity ItemsFiles;
                SqlCommand myCommand = new SqlCommand("ItemsFiles_GetLast", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@FileType", SqlDbType.Int, 4).Value = (int)fileType;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 8).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = count;
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
                    (ItemsFiles) = PopulateItemsFilesEntityFromIDataReader(dr);
                    ItemsFilesList.Add(ItemsFiles);
                }
                dr.Close();
                myConnection.Close();
                return ItemsFilesList;
            }
        }
        #endregion

        #region --------------GetObject--------------
        public ItemsFilesEntity GetObject(int FileID)
        {
            ItemsFilesEntity ItemsFiles = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsFiles_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@FileID", SqlDbType.Int, 4).Value = FileID;
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
                        ItemsFiles = PopulateItemsFilesEntityFromIDataReader(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return ItemsFiles;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateItemsFilesEntityFromIDataReader--------------
        private ItemsFilesEntity PopulateItemsFilesEntityFromIDataReader(IDataReader reader)
        {
            //Create a new ItemsFiles object
            ItemsFilesEntity ItemsFiles = new ItemsFilesEntity();
            //Fill the object with data

            //FileID
            if (reader["FileID"] != DBNull.Value)
                ItemsFiles.FileID = (int)reader["FileID"];
            //ItemID
            if (reader["ItemID"] != DBNull.Value)
                ItemsFiles.ItemID = (int)reader["ItemID"];
            //FileExtension
            if (reader["FileExtension"] != DBNull.Value)
                ItemsFiles.FileExtension = (string)reader["FileExtension"];
            //FileType
            if (reader["FileType"] != DBNull.Value)
                ItemsFiles.FileType = (ItemFileTypes)reader["FileType"];
            //------------------------------------------------------------------
            //InsertUserName
            if (reader["InsertUserName"] != DBNull.Value)
                ItemsFiles.InsertUserName = (string)reader["InsertUserName"];
            //------------------------------------------------------------------ 
            //ModuleTypeID
            if (reader["ModuleTypeID"] != DBNull.Value)
                ItemsFiles.ModuleTypeID = (int)reader["ModuleTypeID"];
            //------------------------------------------------------------------ 
            //LastUpdateUserName
            if (reader["LastUpdateUserName"] != DBNull.Value)
                ItemsFiles.LastUpdateUserName = (string)reader["LastUpdateUserName"];
            //------------------------------------------------------------------
            //Title
            if (reader["Title"] != DBNull.Value)
                ItemsFiles.Title = (string)reader["Title"];
            //------------------------------------------------------------------
            //OwnerID
            if (reader["OwnerID"] != DBNull.Value)
                ItemsFiles.OwnerID = (Guid)reader["OwnerID"];
            //------------------------------------------------------------------
            //OwnerName
            if (reader["OwnerName"] != DBNull.Value)
                ItemsFiles.OwnerName = (string)reader["OwnerName"];
            //------------------------------------------------------------------
            //CategoryID
            if (reader["CategoryID"] != DBNull.Value)
                ItemsFiles.CategoryID = (int)reader["CategoryID"];
            //------------------------------------------------------------------ 
            //Return the populated object
            return ItemsFiles;
        }
        //------------------------------------------
        #endregion
    }
}