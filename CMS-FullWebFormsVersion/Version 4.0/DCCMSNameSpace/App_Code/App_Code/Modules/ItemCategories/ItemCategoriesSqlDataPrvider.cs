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
    public class ItemCategoriesSqlDataPrvider : SqlDataProvider
    {

        #region --------------Instance--------------
        private static ItemCategoriesSqlDataPrvider _Instance;
        public static ItemCategoriesSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ItemCategoriesSqlDataPrvider();
                }
                return _Instance;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Create--------------
        /// <summary>
        /// Converts the ItemCategories object properties to SQL paramters and executes the create ItemCategories procedure 
        /// and updates the ItemCategories object with the SQL data by reference.
        /// <example>[Example]bool status=ItemCategoriesSqlDataPrvider.Instance.Create(itemCategoriesObject);.</example>
        /// </summary>
        /// <param name="itemCategoriesObject">The ItemCategories object.</param>
        /// <returns>The status of create query.</returns>
        public ExecuteCommandStatus Create(ItemCategoriesEntity itemCategoriesObject, ItemsModulesOptions currentModule)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemCategories_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@PhotoExtension", SqlDbType.VarChar, 5).Value = itemCategoriesObject.PhotoExtension;
                myCommand.Parameters.Add("@IsAvailable", SqlDbType.Bit, 1).Value = itemCategoriesObject.IsAvailable;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)itemCategoriesObject.ModuleTypeID;
                myCommand.Parameters.Add("@ParentID", SqlDbType.Int, 4).Value = (int)itemCategoriesObject.ParentID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@InsertUserName", SqlDbType.NVarChar, 64).Value = (string)itemCategoriesObject.InsertUserName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = itemCategoriesObject.TypeID;
                //----------------------------------------------------------------------------------
                //New Columns
                //--------------------------------------
                //-----------------------------
                if (itemCategoriesObject.ItemDate != DateTime.MinValue)
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = (DateTime)itemCategoriesObject.ItemDate;
                else
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = DBNull.Value;
                //-----------------------------
                myCommand.Parameters.Add("@IsMain", SqlDbType.Bit, 1).Value = itemCategoriesObject.IsMain;
                myCommand.Parameters.Add("@Priority", SqlDbType.Int, 4).Value = (int)itemCategoriesObject.Priority;
                myCommand.Parameters.Add("@Photo2Extension", SqlDbType.VarChar, 5).Value = itemCategoriesObject.Photo2Extension;
                myCommand.Parameters.Add("@VideoExtension", SqlDbType.VarChar, 5).Value = itemCategoriesObject.VideoExtension;
                myCommand.Parameters.Add("@AudioExtension", SqlDbType.VarChar, 5).Value = itemCategoriesObject.AudioExtension;
                myCommand.Parameters.Add("@FileExtension", SqlDbType.VarChar, 5).Value = itemCategoriesObject.FileExtension;
                myCommand.Parameters.Add("@Height", SqlDbType.Int, 4).Value = (int)itemCategoriesObject.Height;
                myCommand.Parameters.Add("@Width", SqlDbType.Int, 4).Value = (int)itemCategoriesObject.Width;
                myCommand.Parameters.Add("@YoutubeCode", SqlDbType.VarChar).Value = (string)itemCategoriesObject.YoutubeCode;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@GoogleLatitude", SqlDbType.Float).Value = itemCategoriesObject.GoogleLatitude;
                myCommand.Parameters.Add("@GoogleLongitude", SqlDbType.Float).Value = itemCategoriesObject.GoogleLongitude;
                myCommand.Parameters.Add("@OnlyForRegisered", SqlDbType.Bit).Value = itemCategoriesObject.OnlyForRegisered;
                //-------------------------------------
                myCommand.Parameters.Add("@PublishPhoto", SqlDbType.Bit).Value = itemCategoriesObject.PublishPhoto;
                myCommand.Parameters.Add("@PublishPhoto2", SqlDbType.Bit).Value = itemCategoriesObject.PublishPhoto2;
                myCommand.Parameters.Add("@PublishFile", SqlDbType.Bit).Value = itemCategoriesObject.PublishFile;
                myCommand.Parameters.Add("@PublishAudio", SqlDbType.Bit).Value = itemCategoriesObject.PublishAudio;
                myCommand.Parameters.Add("@PublishVideo", SqlDbType.Bit).Value = itemCategoriesObject.PublishVideo;
                myCommand.Parameters.Add("@PublishYoutbe", SqlDbType.Bit).Value = itemCategoriesObject.PublishYoutbe;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = itemCategoriesObject.OwnerID;
                myCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = itemCategoriesObject.OwnerName;
                //----------------------------------------------------------------------------------
                
                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                if (status == ExecuteCommandStatus.Done)
                {
                    itemCategoriesObject.CategoryID = (int)myCommand.Parameters["@CategoryID"].Value;
                    status = SaveDetails(itemCategoriesObject, currentModule.AllowDublicateTitlesInCategories, SPOperation.Insert);
                }
                myConnection.Close();
                return status;
                //----------------------------------------------------------------------------------
            }

        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Converts the ItemCategories object properties to SQL paramters and executes the update ItemCategories procedure.
        /// <example>[Example]bool  status=ItemCategoriesSqlDataPrvider.Instance.Update(itemCategoriesObject);.</example>
        /// </summary>
        /// <param name="itemCategoriesObject">The ItemCategories object.</param>
        /// <returns>The status of update query.</returns>
        public ExecuteCommandStatus Update(ItemCategoriesEntity itemCategoriesObject, ItemsModulesOptions currentModule)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemCategories_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = itemCategoriesObject.CategoryID;
                myCommand.Parameters.Add("@PhotoExtension", SqlDbType.VarChar, 5).Value = itemCategoriesObject.PhotoExtension;
                myCommand.Parameters.Add("@IsAvailable", SqlDbType.Bit, 1).Value = itemCategoriesObject.IsAvailable;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@LastUpdateUserName", SqlDbType.NVarChar, 64).Value = (string)itemCategoriesObject.LastUpdateUserName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ParentID", SqlDbType.Int, 4).Value = (int)itemCategoriesObject.ParentID;
                //----------------------------------------------------------------------------------
                //New Columns
                //--------------------------------------
                //-----------------------------
                if (itemCategoriesObject.ItemDate != DateTime.MinValue)
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = (DateTime)itemCategoriesObject.ItemDate;
                else
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = DBNull.Value;
                //-----------------------------
                myCommand.Parameters.Add("@IsMain", SqlDbType.Bit, 1).Value = itemCategoriesObject.IsMain;
                myCommand.Parameters.Add("@Priority", SqlDbType.Int, 4).Value = (int)itemCategoriesObject.Priority;
                myCommand.Parameters.Add("@Photo2Extension", SqlDbType.VarChar, 5).Value = itemCategoriesObject.Photo2Extension;
                myCommand.Parameters.Add("@VideoExtension", SqlDbType.VarChar, 5).Value = itemCategoriesObject.VideoExtension;
                myCommand.Parameters.Add("@AudioExtension", SqlDbType.VarChar, 5).Value = itemCategoriesObject.AudioExtension;
                myCommand.Parameters.Add("@FileExtension", SqlDbType.VarChar, 5).Value = itemCategoriesObject.FileExtension;
                myCommand.Parameters.Add("@Height", SqlDbType.Int, 4).Value = (int)itemCategoriesObject.Height;
                myCommand.Parameters.Add("@Width", SqlDbType.Int, 4).Value = (int)itemCategoriesObject.Width;
                myCommand.Parameters.Add("@YoutubeCode", SqlDbType.VarChar).Value = (string)itemCategoriesObject.YoutubeCode;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@GoogleLatitude", SqlDbType.Float).Value = itemCategoriesObject.GoogleLatitude;
                myCommand.Parameters.Add("@GoogleLongitude", SqlDbType.Float).Value = itemCategoriesObject.GoogleLongitude;
                myCommand.Parameters.Add("@OnlyForRegisered", SqlDbType.Bit).Value = itemCategoriesObject.OnlyForRegisered;
                //-------------------------------------
                myCommand.Parameters.Add("@PublishPhoto", SqlDbType.Bit).Value = itemCategoriesObject.PublishPhoto;
                myCommand.Parameters.Add("@PublishPhoto2", SqlDbType.Bit).Value = itemCategoriesObject.PublishPhoto2;
                myCommand.Parameters.Add("@PublishFile", SqlDbType.Bit).Value = itemCategoriesObject.PublishFile;
                myCommand.Parameters.Add("@PublishAudio", SqlDbType.Bit).Value = itemCategoriesObject.PublishAudio;
                myCommand.Parameters.Add("@PublishVideo", SqlDbType.Bit).Value = itemCategoriesObject.PublishVideo;
                myCommand.Parameters.Add("@PublishYoutbe", SqlDbType.Bit).Value = itemCategoriesObject.PublishYoutbe;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = itemCategoriesObject.OwnerID;
                //----------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                if (status == ExecuteCommandStatus.Done)
                {
                    status = SaveDetails(itemCategoriesObject, currentModule.AllowDublicateTitlesInCategories, SPOperation.Update);
                }

                myConnection.Close();
                return status;
                //----------------------------------------------------------------------------------
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single ItemCategories object .
        /// <example>[Example]bool status=ItemCategoriesSqlDataPrvider.Instance.Delete(categoryID);.</example>
        /// </summary>
        /// <param name="categoryID">The itemCategoriesObject id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int categoryID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemCategories_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = categoryID;
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



        #region -------------GetAllItemCategoriesInDataTable---------------
        public DataTable GetAllItemCategoriesInDataTable(int moduleTypeID, Languages langID, bool isAvailableCondition, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemCategories_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@ParentID", SqlDbType.Int, 4).Value = -1;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@SiteHasMultiLanguages", SqlDbType.Bit).Value = SiteSettings.Languages_HasMultiLanguages;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = -1;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = -1;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataAdapter da = new SqlDataAdapter(myCommand);
                DataTable dt = new DataTable();
                myConnection.Open();
                da.Fill(dt);
                myConnection.Close();
                return dt;
                //----------------------------------------------------------------
            }
        }
        #endregion

        #region --------------GetAll--------------
        public List<ItemCategoriesEntity> GetAll(int moduleTypeID, int parentID, Languages langID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemCategoriesEntity> itemCategoriesList = new List<ItemCategoriesEntity>();
                ItemCategoriesEntity itemCategoriesObject;
                //Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("ItemCategories_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@ParentID", SqlDbType.Int, 4).Value = parentID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@SiteHasMultiLanguages", SqlDbType.Bit).Value = SiteSettings.Languages_HasMultiLanguages;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    /*itemCategoriesObject = PopulateItemCategoriesEntity(dr);
                    if (!temp.Contains(itemCategoriesObject.CategoryID))
                    {
                        itemCategoriesList.Add(itemCategoriesObject);
                        temp.Add(itemCategoriesObject.CategoryID, null);
                    }*/
                    itemCategoriesObject = (ItemCategoriesEntity)GetEntity(dr, typeof(ItemCategoriesEntity));
                    itemCategoriesList.Add(itemCategoriesObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = itemCategoriesList.Count;
                return itemCategoriesList;
                //----------------------------------------------------------------
            }
        }
        #endregion

        #region --------------GetLast--------------
        public List<ItemCategoriesEntity> GetLast(int moduleTypeID, int parentID, int Count, Languages langID, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemCategoriesEntity> itemCategoriesList = new List<ItemCategoriesEntity>();
                ItemCategoriesEntity itemCategoriesObject;
                //Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("ItemCategories_GetLast", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@ParentID", SqlDbType.Int, 4).Value = parentID;
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = Count;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    /*itemCategoriesObject = PopulateItemCategoriesEntity(dr);
                    if (!temp.Contains(itemCategoriesObject.CategoryID))
                    {
                        itemCategoriesList.Add(itemCategoriesObject);
                        temp.Add(itemCategoriesObject.CategoryID, null);
                    }*/
                    itemCategoriesObject = (ItemCategoriesEntity)GetEntity(dr, typeof(ItemCategoriesEntity));
                    itemCategoriesList.Add(itemCategoriesObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                return itemCategoriesList;
                //----------------------------------------------------------------
            }
        }
        #endregion

        #region --------------GetFullPath--------------
        public List<ItemCategoriesEntity> GetFullPath(int categoryID, Languages langID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemCategoriesEntity> itemCategoriesList = new List<ItemCategoriesEntity>();
                ItemCategoriesEntity itemCategoriesObject = null;
                SqlCommand myCommand = new SqlCommand("ItemCategories_GetFullPath", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = categoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //----------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //itemCategoriesObject = PopulateItemCategoriesEntity(dr);
                    itemCategoriesObject = (ItemCategoriesEntity)GetEntity(dr, typeof(ItemCategoriesEntity));
                    itemCategoriesList.Add(itemCategoriesObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                return itemCategoriesList;
                //----------------------------------------------------------------
            }
        }
        #endregion


        #region --------------GetItemCategoriesObject--------------
        public ItemCategoriesEntity GetItemCategoriesObject(int categoryID, Languages langID, Guid OwnerID)
        {
            ItemCategoriesEntity itemCategoriesObject = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemCategories_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = categoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        if (itemCategoriesObject == null)
                        {
                            itemCategoriesObject = (ItemCategoriesEntity)GetEntity(dr, typeof(ItemCategoriesEntity));
                            ItemCategoriesDetailsEntity pd = (ItemCategoriesDetailsEntity)GetEntity(dr, typeof(ItemCategoriesDetailsEntity));
                            itemCategoriesObject.Details[pd.LangID] = pd;
                        }
                        else
                        {
                            ItemCategoriesDetailsEntity pd = (ItemCategoriesDetailsEntity)GetEntity(dr, typeof(ItemCategoriesDetailsEntity));
                            itemCategoriesObject.Details[pd.LangID] = pd;
                        }
                    }
                    dr.Close();
                }

                myConnection.Close();
                return itemCategoriesObject;

            }
        }
        //------------------------------------------
        #endregion

        #region --------------SaveDetails--------------

        public ExecuteCommandStatus SaveDetails(ItemCategoriesEntity itemCategoriesObject, bool AllowDublicateTitlesInCategories, SPOperation operation)
        {
            Hashtable categoryDetailsCollection = itemCategoriesObject.Details;
            ExecuteCommandStatus status = ExecuteCommandStatus.UnknownError;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemCategoriesDetails_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@SPOperation", SqlDbType.Int, 4).Value = (int)operation;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@LangID", SqlDbType.Int);
                myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128);
                myCommand.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 512);
                myCommand.Parameters.Add("@Description", SqlDbType.NVarChar);
                //----------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@ParentID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@AllowDublicateTitlesInCategories", SqlDbType.Bit, 1);
                //--------------------------------------------------------
                myCommand.Parameters.Add("@KeyWords", SqlDbType.NVarChar, 256);
                //--------------------------------------------------------
                // Execute the command
                myConnection.Open();
                foreach (DictionaryEntry key in categoryDetailsCollection)
                {
                    ItemCategoriesDetailsEntity itemDetails = (ItemCategoriesDetailsEntity)key.Value;
                    myCommand.Parameters["@CategoryID"].Value = itemCategoriesObject.CategoryID;
                    myCommand.Parameters["@LangID"].Value = (int)itemDetails.LangID;
                    myCommand.Parameters["@Title"].Value = itemDetails.Title;
                    myCommand.Parameters["@ShortDescription"].Value = itemDetails.ShortDescription;
                    myCommand.Parameters["@Description"].Value = itemDetails.Description;
                    //
                    myCommand.Parameters["@ModuleTypeID"].Value = (int)itemCategoriesObject.ModuleTypeID;
                    myCommand.Parameters["@ParentID"].Value = itemCategoriesObject.ParentID;
                    myCommand.Parameters["@AllowDublicateTitlesInCategories"].Value = AllowDublicateTitlesInCategories;
                    //--------------------------------------------------------
                    myCommand.Parameters["@KeyWords"].Value = itemDetails.KeyWords;
                    //--------------------------------------------------------
                    status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                    if (status != ExecuteCommandStatus.Done)
                        break;
                }

                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////
        #region --------------GetMain--------------
        public List<ItemCategoriesEntity> GetMain(int moduleTypeID, Languages langID, int count, Guid OwnerID)
        {
            List<ItemCategoriesEntity> categoriesList = new List<ItemCategoriesEntity>();
            ItemCategoriesEntity itemCategoriesObject;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemCategories_GetMain", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = count;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemCategoriesObject = (ItemCategoriesEntity)GetEntity(dr, typeof(ItemCategoriesEntity));
                    categoriesList.Add(itemCategoriesObject);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return categoriesList;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetNotMain--------------
        public List<ItemCategoriesEntity> GetNotMain(int moduleTypeID, Languages langID, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemCategoriesEntity> categoriesList = new List<ItemCategoriesEntity>();
                ItemCategoriesEntity itemCategoriesObject;
                SqlCommand myCommand = new SqlCommand("ItemCategories_GetNotMain", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemCategoriesObject = (ItemCategoriesEntity)GetEntity(dr, typeof(ItemCategoriesEntity));
                    categoriesList.Add(itemCategoriesObject);
                }
                dr.Close();
                myConnection.Close();
                return categoriesList;
            }
        }
        #endregion

        #region --------------GetCount--------------
        public int GetCount(int moduleTypeID, Languages langID, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemCategories_GetCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                int categoriesCount = (int)myCommand.ExecuteScalar();
                myConnection.Close();
                return categoriesCount;
            }
        }
        #endregion

        ///////////////////////////////////////////////////////////////////////////////////////////
    }

}