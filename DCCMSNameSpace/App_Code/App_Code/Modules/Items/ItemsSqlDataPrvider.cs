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
    public class ItemsSqlDataPrvider : SqlDataProvider
    {

        #region --------------Instance--------------
        private static ItemsSqlDataPrvider _Instance;
        public static ItemsSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ItemsSqlDataPrvider();
                }
                return _Instance;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Create--------------
        /// <summary>
        /// Converts the Items object properties to SQL paramters and executes the create Items procedure 
        /// and updates the Items object with the SQL data by reference.
        /// <example>[Example]bool status=ItemsSqlDataPrvider.Instance.Create(itemsObject);.</example>
        /// </summary>
        /// <param name="itemsObject">The Items object.</param>
        /// <returns>The status of create query.</returns>
        public ExecuteCommandStatus Create(ItemsEntity itemsObject, ItemsModulesOptions currentModule)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Items_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = itemsObject.CategoryID;
                myCommand.Parameters.Add("@PhotoExtension", SqlDbType.VarChar, 5).Value = itemsObject.PhotoExtension;
                myCommand.Parameters.Add("@FileExtension", SqlDbType.VarChar, 5).Value = itemsObject.FileExtension;
                myCommand.Parameters.Add("@Url", SqlDbType.NVarChar, 128).Value = itemsObject.Url;
                myCommand.Parameters.Add("@IsAvailable", SqlDbType.Bit, 1).Value = itemsObject.IsAvailable;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)itemsObject.ModuleTypeID;
                //
                myCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = itemsObject.Email;
                myCommand.Parameters.Add("@IsMain", SqlDbType.Bit, 1).Value = itemsObject.IsMain;
                myCommand.Parameters.Add("@SpecialOption", SqlDbType.Bit, 1).Value = itemsObject.SpecialOption;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@VideoExtension", SqlDbType.VarChar, 5).Value = itemsObject.VideoExtension;
                myCommand.Parameters.Add("@AudioExtension", SqlDbType.VarChar, 5).Value = itemsObject.AudioExtension;
                myCommand.Parameters.Add("@Priority", SqlDbType.Int, 4).Value = (int)itemsObject.Priority;
                //myCommand.Parameters.Add("@AuthorName", SqlDbType.NVarChar, 128).Value = itemsObject.AuthorName;
                myCommand.Parameters.Add("@Photo2Extension", SqlDbType.VarChar, 5).Value = itemsObject.Photo2Extension;
                //----------------------------------------------------------------------------------

                myCommand.Parameters.Add("@Height", SqlDbType.Int, 4).Value = (int)itemsObject.Height;
                myCommand.Parameters.Add("@Width", SqlDbType.Int, 4).Value = (int)itemsObject.Width;
                //-----------------------------
                if (itemsObject.ItemDate != DateTime.MinValue)
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = (DateTime)itemsObject.ItemDate;
                else
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = DBNull.Value;
                //-----------------------------
                if (itemsObject.ItemEndDate != DateTime.MinValue)
                    myCommand.Parameters.Add("@ItemEndDate", SqlDbType.DateTime).Value = (DateTime)itemsObject.ItemEndDate;
                else
                    myCommand.Parameters.Add("@ItemEndDate", SqlDbType.DateTime).Value = DBNull.Value;
                //-----------------------------
                //myCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 128).Value = (string)itemsObject.Address;
                myCommand.Parameters.Add("@MailBox", SqlDbType.NVarChar).Value = (string)itemsObject.MailBox;
                myCommand.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = (string)itemsObject.ZipCode;
                myCommand.Parameters.Add("@Tels", SqlDbType.NVarChar).Value = (string)itemsObject.Tels;
                myCommand.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = (string)itemsObject.Fax;
                myCommand.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = (string)itemsObject.Mobile;
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = itemsObject.AuthorID;
                myCommand.Parameters.Add("@YoutubeCode", SqlDbType.NVarChar).Value = (string)itemsObject.YoutubeCode;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@InsertUserName", SqlDbType.NVarChar, 64).Value = (string)itemsObject.InsertUserName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@GoogleLatitude", SqlDbType.Float).Value = itemsObject.GoogleLatitude;
                myCommand.Parameters.Add("@GoogleLongitude", SqlDbType.Float).Value = itemsObject.GoogleLongitude;
                myCommand.Parameters.Add("@Price", SqlDbType.NVarChar).Value = itemsObject.Price;
                myCommand.Parameters.Add("@OnlyForRegisered", SqlDbType.Bit).Value = itemsObject.OnlyForRegisered;
                //-------------------------------------
                myCommand.Parameters.Add("@PublishPhoto", SqlDbType.Bit).Value = itemsObject.PublishPhoto;
                myCommand.Parameters.Add("@PublishPhoto2", SqlDbType.Bit).Value = itemsObject.PublishPhoto2;
                myCommand.Parameters.Add("@PublishFile", SqlDbType.Bit).Value = itemsObject.PublishFile;
                myCommand.Parameters.Add("@PublishAudio", SqlDbType.Bit).Value = itemsObject.PublishAudio;
                myCommand.Parameters.Add("@PublishVideo", SqlDbType.Bit).Value = itemsObject.PublishVideo;
                myCommand.Parameters.Add("@PublishYoutbe", SqlDbType.Bit).Value = itemsObject.PublishYoutbe;
                //----------------------------------------------------------------------------------
                //Visitors Participations
                //--------------------------
                myCommand.Parameters.Add("@IsVisitorsParticipations", SqlDbType.Bit).Value = itemsObject.IsVisitorsParticipations;
                myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = itemsObject.UserId;
                myCommand.Parameters.Add("@SenderName", SqlDbType.NVarChar, 128).Value = itemsObject.SenderName;
                myCommand.Parameters.Add("@SenderEMail", SqlDbType.NVarChar, 128).Value = itemsObject.SenderEMail;
                myCommand.Parameters.Add("@SenderCountryID", SqlDbType.Int, 4).Value = itemsObject.SenderCountryID;
                myCommand.Parameters.Add("@ToUserID", SqlDbType.UniqueIdentifier).Value = itemsObject.ToUserID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = itemsObject.OwnerID;
                myCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = itemsObject.OwnerName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = itemsObject.Type;
                //----------------------------------------------------------------------------------
                // Profile parameters
                //----------------------------------------------------------------------------------
                string PropertyNames = System.String.Empty;
                string PropertyValuesString = System.String.Empty;
                ProfileBuilder.PrepareDataForSaving(ref PropertyNames, ref PropertyValuesString, itemsObject.Profile.PropertyValueCollection);
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@PropertyNames", SqlDbType.NText).Value = PropertyNames;
                myCommand.Parameters.Add("@PropertyValuesString", SqlDbType.NText).Value = PropertyValuesString;
                //----------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                if (status == ExecuteCommandStatus.Done)
                {
                    itemsObject.ItemID = (int)myCommand.Parameters["@ItemID"].Value;
                    status = SaveDetails(itemsObject, currentModule.AllowDublicateTitlesInItems, SPOperation.Insert);
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Converts the Items object properties to SQL paramters and executes the update Items procedure.
        /// <example>[Example]bool  status=ItemsSqlDataPrvider.Instance.Update(itemsObject);.</example>
        /// </summary>
        /// <param name="itemsObject">The Items object.</param>
        /// <returns>The status of update query.</returns>
        public ExecuteCommandStatus Update(ItemsEntity itemsObject, ItemsModulesOptions currentModule)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Items_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemsObject.ItemID;
                //myCommand.Parameters.Add("@Title", SqlDbType.NVarChar,128).Value = itemsObject.Title;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = itemsObject.CategoryID;
                //myCommand.Parameters.Add("@ShortDescription", SqlDbType.NVarChar,512).Value = itemsObject.ShortDescription;
                //myCommand.Parameters.Add("@Details", SqlDbType.NText).Value = itemsObject.Details;
                myCommand.Parameters.Add("@PhotoExtension", SqlDbType.VarChar, 5).Value = itemsObject.PhotoExtension;
                myCommand.Parameters.Add("@FileExtension", SqlDbType.VarChar, 5).Value = itemsObject.FileExtension;
                myCommand.Parameters.Add("@Url", SqlDbType.NVarChar, 128).Value = itemsObject.Url;
                myCommand.Parameters.Add("@IsAvailable", SqlDbType.Bit, 1).Value = itemsObject.IsAvailable;
                //
                //myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)itemsObject.ModuleTypeID;
                //
                myCommand.Parameters.Add("@Email", SqlDbType.NVarChar).Value = itemsObject.Email;
                myCommand.Parameters.Add("@IsMain", SqlDbType.Bit, 1).Value = itemsObject.IsMain;
                myCommand.Parameters.Add("@SpecialOption", SqlDbType.Bit, 1).Value = itemsObject.SpecialOption;

                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@VideoExtension", SqlDbType.VarChar, 5).Value = itemsObject.VideoExtension;
                myCommand.Parameters.Add("@AudioExtension", SqlDbType.VarChar, 5).Value = itemsObject.AudioExtension;
                myCommand.Parameters.Add("@Priority", SqlDbType.Int, 4).Value = (int)itemsObject.Priority;
                //myCommand.Parameters.Add("@AuthorName", SqlDbType.NVarChar, 128).Value = itemsObject.AuthorName;
                myCommand.Parameters.Add("@Photo2Extension", SqlDbType.VarChar, 5).Value = itemsObject.Photo2Extension;
                //----------------------------------------------------------------------------------

                myCommand.Parameters.Add("@Height", SqlDbType.Int, 4).Value = (int)itemsObject.Height;
                myCommand.Parameters.Add("@Width", SqlDbType.Int, 4).Value = (int)itemsObject.Width;

                //------------------------------------------------------------
                if (itemsObject.ItemDate != DateTime.MinValue)
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = (DateTime)itemsObject.ItemDate;
                else
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = DBNull.Value;
                //------------------------------------------------------------
                if (itemsObject.ItemEndDate != DateTime.MinValue)
                    myCommand.Parameters.Add("@ItemEndDate", SqlDbType.DateTime).Value = (DateTime)itemsObject.ItemEndDate;
                else
                    myCommand.Parameters.Add("@ItemEndDate", SqlDbType.DateTime).Value = DBNull.Value;
                //------------------------------------------------------------
                //myCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 128).Value = (string)itemsObject.Address;
                myCommand.Parameters.Add("@MailBox", SqlDbType.NVarChar).Value = (string)itemsObject.MailBox;
                myCommand.Parameters.Add("@ZipCode", SqlDbType.NVarChar).Value = (string)itemsObject.ZipCode;
                myCommand.Parameters.Add("@Tels", SqlDbType.NVarChar).Value = (string)itemsObject.Tels;
                myCommand.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = (string)itemsObject.Fax;
                myCommand.Parameters.Add("@Mobile", SqlDbType.NVarChar).Value = (string)itemsObject.Mobile;
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = itemsObject.AuthorID;
                myCommand.Parameters.Add("@YoutubeCode", SqlDbType.VarChar).Value = (string)itemsObject.YoutubeCode;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@LastUpdateUserName", SqlDbType.NVarChar, 64).Value = (string)itemsObject.LastUpdateUserName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@GoogleLatitude", SqlDbType.Float).Value = itemsObject.GoogleLatitude;
                myCommand.Parameters.Add("@GoogleLongitude", SqlDbType.Float).Value = itemsObject.GoogleLongitude;
                myCommand.Parameters.Add("@Price", SqlDbType.NVarChar).Value = itemsObject.Price;
                myCommand.Parameters.Add("@OnlyForRegisered", SqlDbType.Bit).Value = itemsObject.OnlyForRegisered;
                //-------------------------------------
                myCommand.Parameters.Add("@PublishPhoto", SqlDbType.Bit).Value = itemsObject.PublishPhoto;
                myCommand.Parameters.Add("@PublishPhoto2", SqlDbType.Bit).Value = itemsObject.PublishPhoto2;
                myCommand.Parameters.Add("@PublishFile", SqlDbType.Bit).Value = itemsObject.PublishFile;
                myCommand.Parameters.Add("@PublishAudio", SqlDbType.Bit).Value = itemsObject.PublishAudio;
                myCommand.Parameters.Add("@PublishVideo", SqlDbType.Bit).Value = itemsObject.PublishVideo;
                myCommand.Parameters.Add("@PublishYoutbe", SqlDbType.Bit).Value = itemsObject.PublishYoutbe;
                //----------------------------------------------------------------------------------
                //Visitors Participations
                //--------------------------
                //myCommand.Parameters.Add("@IsVisitorsParticipations", SqlDbType.Bit).Value = itemsObject.IsVisitorsParticipations;
                //myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = itemsObject.UserId;
                myCommand.Parameters.Add("@SenderName", SqlDbType.NVarChar, 128).Value = itemsObject.SenderName;
                myCommand.Parameters.Add("@SenderEMail", SqlDbType.NVarChar, 128).Value = itemsObject.SenderEMail;
                myCommand.Parameters.Add("@SenderCountryID", SqlDbType.Int, 4).Value = itemsObject.SenderCountryID;
                myCommand.Parameters.Add("@Reply", SqlDbType.NText).Value = itemsObject.Reply;
                myCommand.Parameters.Add("@IsReplied", SqlDbType.Bit, 1).Value = itemsObject.IsReplied;
                myCommand.Parameters.Add("@IsReviewed", SqlDbType.Bit, 1).Value = itemsObject.IsReviewed;
                myCommand.Parameters.Add("@ToUserID", SqlDbType.UniqueIdentifier).Value = itemsObject.ToUserID;
                myCommand.Parameters.Add("@ActivatedBy", SqlDbType.NVarChar, 128).Value = itemsObject.ActivatedBy;
                myCommand.Parameters.Add("@ReviewedBy", SqlDbType.NVarChar, 128).Value = itemsObject.ReviewedBy;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = itemsObject.OwnerID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = itemsObject.Type;
                //----------------------------------------------------------------------------------
                // Profile parameters
                //----------------------------------------------------------------------------------
                string PropertyNames = System.String.Empty;
                string PropertyValuesString = System.String.Empty;
                ProfileBuilder.PrepareDataForSaving(ref PropertyNames, ref PropertyValuesString, itemsObject.Profile.PropertyValueCollection);
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@PropertyNames", SqlDbType.NText).Value = PropertyNames;
                myCommand.Parameters.Add("@PropertyValuesString", SqlDbType.NText).Value = PropertyValuesString;
                //----------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                if (status == ExecuteCommandStatus.Done)
                {
                    status = SaveDetails(itemsObject, currentModule.AllowDublicateTitlesInItems, SPOperation.Update);
                }

                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single Items object .
        /// <example>[Example]bool status=ItemsSqlDataPrvider.Instance.Delete(itemID);.</example>
        /// </summary>
        /// <param name="itemID">The itemsObject id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int itemID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Items_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID;
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

        #region --------------GetLast--------------
        public List<ItemsEntity> GetLast(int moduleTypeID, int CategoryID, Languages langID, int count, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                SqlCommand myCommand = new SqlCommand("Items_GetLast", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = count;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                return itemsList;
            }
        }
        #endregion

        #region --------------GetLastInMultiModules--------------
        public List<ItemsEntity> GetLastInMultiModules(string Modules, int CategoryID, Languages langID, int count, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                SqlCommand myCommand = new SqlCommand("Items_GetLastInMultiModules", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@Modules", SqlDbType.NVarChar, 128).Value = Modules;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = count;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                return itemsList;
            }
        }
        #endregion

        #region --------------GetLastRandom--------------
        public List<ItemsEntity> GetLastRandom(int moduleTypeID, int CategoryID, Languages langID, int count, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                SqlCommand myCommand = new SqlCommand("Items_GetLastRandom", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = count;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                return itemsList;
            }
        }
        #endregion

        #region --------------GetLastRandomInMultiModules--------------
        public List<ItemsEntity> GetLastRandomInMultiModules(string Modules, int CategoryID, Languages langID, int count, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                SqlCommand myCommand = new SqlCommand("Items_GetLastRandomInMultiModules", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@Modules", SqlDbType.NVarChar, 128).Value = Modules;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = count;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                return itemsList;
            }
        }
        #endregion

        #region --------------GetAll--------------
        public List<ItemsEntity> GetAll(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keyWord, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Items_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@SiteHasMultiLanguages", SqlDbType.Bit).Value = SiteSettings.Languages_HasMultiLanguages;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = (int)categoryID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@KeyWord", SqlDbType.NVarChar, 128).Value = keyWord;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    /*(itemsObject) = PopulateItemsEntityFromIDataReader(dr);
                    if (!temp.Contains(itemsObject.ItemID))
                    {
                        itemsList.Add(itemsObject);
                        temp.Add(itemsObject.ItemID,null);
                    }
                    */
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);

                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = itemsList.Count;
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        #endregion



        #region --------------SearchInMultiModules--------------
        public List<ItemsEntity> SearchInMultiModules(string modules, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keyWord, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Items_SearchInMultiModules", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@Modules", SqlDbType.NVarChar, 128).Value = modules;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = (int)categoryID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@KeyWord", SqlDbType.NVarChar, 128).Value = keyWord;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    /*(itemsObject) = PopulateItemsEntityFromIDataReader(dr);
                    if (!temp.Contains(itemsObject.ItemID))
                    {
                        itemsList.Add(itemsObject);
                        temp.Add(itemsObject.ItemID,null);
                    }
                    */
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);

                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = itemsList.Count;
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        #endregion

        #region --------------GetAllFlv--------------
        public List<ItemsEntity> GetAllFlv(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                //Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Items_GetAllFlv", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = (int)categoryID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    /* (itemsObject) = PopulateItemsEntityFromIDataReader(dr);
                     if (!temp.Contains(itemsObject.ItemID))
                     {
                         itemsList.Add(itemsObject);
                         temp.Add(itemsObject.ItemID,null);
                     }*/
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = itemsList.Count;
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        #endregion

        #region --------------CalendarMethods--------------

        #region --------------CalendarGetByMonth--------------
        public List<ItemsEntity> CalendarGetByMonth(int moduleTypeID, Languages langID, int categoryID, int year, int month, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                //Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Items_CalendarGetByMonth", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = (int)categoryID;
                myCommand.Parameters.Add("@Month", SqlDbType.Int, 4).Value = month;
                myCommand.Parameters.Add("@Year", SqlDbType.Int, 4).Value = year;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    /*(itemsObject) = PopulateItemsEntityFromIDataReader(dr);
                    if (!temp.Contains(itemsObject.ItemID))
                    {
                        itemsList.Add(itemsObject);
                        temp.Add(itemsObject.ItemID, null);
                    }*/
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        #endregion

        #region --------------CalendarGetByDay--------------
        public List<ItemsEntity> CalendarGetByDay(int moduleTypeID, Languages langID, int Day, DateTime From, DateTime To, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Items_CalendarGetByDay", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@Day ", SqlDbType.Int, 4).Value = Day;
                myCommand.Parameters.Add("@From", SqlDbType.DateTime).Value = From;
                myCommand.Parameters.Add("@To", SqlDbType.DateTime).Value = To;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        #endregion

        #region --------------CalendarGetToDay--------------
        public List<ItemsEntity> CalendarGetToDay(int moduleTypeID, Languages langID, DateTime Date, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Items_CalendarGetToDay", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value = Date;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        #endregion

        #region --------------CalendarGetUpComing--------------
        public List<ItemsEntity> CalendarGetUpComing(int moduleTypeID, Languages langID, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Items_CalendarGetUpComing", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        #endregion
        #endregion

        #region --------------GetItemsObject--------------
        public ItemsEntity GetItemsObject(int itemID, Languages langID, UsersTypes viewerType, Guid OwnerID)
        {
            ItemsEntity item = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Items_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ViewerType ", SqlDbType.Int, 4).Value = (int)viewerType;
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID;
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
                        if (item == null)
                        {
                            /*
                            item = PopulateItemsEntityFromIDataReader(dr);
                            ItemsDetailsEntity pd = PopulateItemsDetailsEntity(dr);
                             * */
                            item = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                            ItemsDetailsEntity pd = (ItemsDetailsEntity)GetEntity(dr, typeof(ItemsDetailsEntity));
                            item.Details[pd.LangID] = pd;
                        }
                        else
                        {
                            //ItemsDetailsEntity pd = PopulateItemsDetailsEntity(dr);
                            ItemsDetailsEntity pd = (ItemsDetailsEntity)GetEntity(dr, typeof(ItemsDetailsEntity));
                            item.Details[pd.LangID] = pd;
                        }
                    }
                    dr.Close();
                }
                myConnection.Close();
                return item;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetMain--------------
        public List<ItemsEntity> GetMain(int moduleTypeID, Languages langID, int count, bool isMainValue, int CategoryID, Guid OwnerID, int AuthorID)
        {
            List<ItemsEntity> itemsList = new List<ItemsEntity>();
            ItemsEntity itemsObject;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Items_GetMain", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = count;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@IsMainValue", SqlDbType.Bit).Value = isMainValue;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                //--------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //itemsObject = PopulateItemsEntityFromIDataReader(dr);
                    //itemsList.Add(itemsObject);
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        //------------------------------------------
        #endregion


        #region --------------GetHaveSpecialOption--------------
        public List<ItemsEntity> GetHaveSpecialOption(int moduleTypeID, Languages langID, int count,bool specialOptionValue,int CategoryID, Guid OwnerID, int AuthorID)
        {
            List<ItemsEntity> itemsList = new List<ItemsEntity>();
            ItemsEntity itemsObject;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Items_GetHaveSpecialOption", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = count;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@SpecialOptionValue", SqlDbType.Bit).Value = specialOptionValue;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                //--------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //itemsObject = PopulateItemsEntityFromIDataReader(dr);
                    //itemsList.Add(itemsObject);
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastFlv--------------
        public List<ItemsEntity> GetLastFlv(Languages langID, Guid OwnerID, int AuthorID)
        {
            List<ItemsEntity> itemsList = new List<ItemsEntity>();
            ItemsEntity itemsObject;
            //Hashtable temp = new Hashtable();
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Items_GetLastFlv", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {

                    /* (itemsObject) = PopulateItemsEntityFromIDataReader(dr);
                     if (!temp.Contains(itemsObject.ItemID))
                     {
                         itemsList.Add(itemsObject);
                         temp.Add(itemsObject.ItemID, null);
                     }*/
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetLast--------------
        public List<ItemsEntity> GetInList(string itemsInList, Languages langID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                SqlCommand myCommand = new SqlCommand("[dbo].[Items_GetInList]", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                if (string.IsNullOrEmpty(itemsInList))
                    itemsInList = "0";
                myCommand.Parameters.Add("@ItemsList", SqlDbType.VarChar).Value = itemsInList;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);
                }
                dr.Close();
                myConnection.Close();
                return itemsList;
            }
        }
        #endregion

        #region --------------GetCount--------------
        public int GetCount(int moduleTypeID, int categoryid, Languages langID, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Items_GetCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = categoryid;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                int itemsCount = (int)myCommand.ExecuteScalar();
                myConnection.Close();
                return itemsCount;
            }
        }
        #endregion

        #region --------------rate--------------
        public void Rate(int itemID, int rate)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Items_Rate", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID;
                myCommand.Parameters.Add("@AddValue", SqlDbType.Int, 4).Value = rate;
                // Execute the command
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        //------------------------------------------
        #endregion

        #region --------------SiteSearch--------------
        public List<ItemsEntity> SiteSearch(Languages langID, int pageIndex, int pageSize, out int totalRecords, string keyWord, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Site_Search", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@KeyWord", SqlDbType.NVarChar, 128).Value = keyWord;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    /*(itemsObject) = PopulateItemsEntityFromIDataReader(dr);
                    if (!temp.Contains(itemsObject.ItemID))
                    {
                        itemsList.Add(itemsObject);
                        temp.Add(itemsObject.ItemID,null);
                    }
                    */
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);

                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = itemsList.Count;
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        #endregion

        #region --------------UpdateIsSeen--------------
        public void UpdateIsSeen(int ItemID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Items_UpdateIsSeen", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = ItemID;
                // Execute the command
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        //------------------------------------------
        #endregion


        #region --------------GetVisitorsParticipations--------------
        public List<ItemsEntity> GetVisitorsParticipations(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, bool isAvailable, object UserIdProviderKey, object ToUserIdProviderKey, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, string keyWord, Guid OwnerID, int AuthorID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsEntity> itemsList = new List<ItemsEntity>();
                ItemsEntity itemsObject;
                Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Items_GetVisitorsParticipations", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@SiteHasMultiLanguages", SqlDbType.Bit).Value = SiteSettings.Languages_HasMultiLanguages;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = (int)categoryID;
                myCommand.Parameters.Add("@KeyWord", SqlDbType.NVarChar, 128).Value = keyWord;
                //-------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@IsAvailable", SqlDbType.Bit, 1).Value = isAvailable;
                //-------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@UnRepliedCondition", SqlDbType.Bit, 1).Value = UnRepliedCondition;
                myCommand.Parameters.Add("@NotSeenCondition", SqlDbType.Bit, 1).Value = NotSeenCondition;
                //-------------------------------------------------------------------------------------
                if (UserIdProviderKey != null)
                {
                    Guid UserId = new Guid(UserIdProviderKey.ToString());
                    if (UserId != Guid.Empty)
                        myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = UserId;
                }
                //-------------------------------------------------------------------------------------
                if (ToUserIdProviderKey != null)
                {
                    Guid ToUserId = new Guid(ToUserIdProviderKey.ToString());
                    if (ToUserId != Guid.Empty)
                        myCommand.Parameters.Add("@ToUserId", SqlDbType.UniqueIdentifier).Value = ToUserId;
                }
                //-------------------------------------------------------------------------------------

                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@AuthorID", SqlDbType.Int, 4).Value = AuthorID;
                //---------------------------------------------------------------------

                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (ItemsEntity)GetEntity(dr, typeof(ItemsEntity));
                    itemsList.Add(itemsObject);

                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = itemsList.Count;
                //----------------------------------------------------------------
                return itemsList;
            }
        }
        #endregion

        #region --------------SaveDetails--------------

        public ExecuteCommandStatus SaveDetails(ItemsEntity itemObject, bool AllowDublicateTitlesInItems, SPOperation operation)
        {
            Hashtable categoryDetailsCollection = itemObject.Details;
            ExecuteCommandStatus status = ExecuteCommandStatus.UnknownError;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsDetails_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@SPOperation", SqlDbType.Int, 4).Value = (int)operation;
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@LangID", SqlDbType.Int);
                myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128);
                myCommand.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 512);
                myCommand.Parameters.Add("@Description", SqlDbType.NVarChar);
                myCommand.Parameters.Add("@AuthorName", SqlDbType.NVarChar, 128);
                myCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 128);
                //----------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4);
                //--------------------------------------------------------
                myCommand.Parameters.Add("@ExtraData", SqlDbType.NVarChar);
                //--------------------------------------------------------
                myCommand.Parameters.Add("@AllowDublicateTitlesInItems", SqlDbType.Bit, 1);
                //--------------------------------------------------------
                myCommand.Parameters.Add("@KeyWords", SqlDbType.NVarChar, 256);
                //--------------------------------------------------------
                // Execute the command
                myConnection.Open();
                foreach (DictionaryEntry key in categoryDetailsCollection)
                {
                    ItemsDetailsEntity itemDetails = (ItemsDetailsEntity)key.Value;
                    myCommand.Parameters["@ItemID"].Value = itemObject.ItemID;
                    myCommand.Parameters["@LangID"].Value = (int)itemDetails.LangID;
                    myCommand.Parameters["@Title"].Value = itemDetails.Title;
                    myCommand.Parameters["@ShortDescription"].Value = itemDetails.ShortDescription;
                    myCommand.Parameters["@Description"].Value = itemDetails.Description;
                    myCommand.Parameters["@AuthorName"].Value = itemDetails.AuthorName;
                    myCommand.Parameters["@Address"].Value = itemDetails.Address;
                    //
                    myCommand.Parameters["@ModuleTypeID"].Value = (int)itemObject.ModuleTypeID;
                    myCommand.Parameters["@CategoryID"].Value = itemObject.CategoryID;
                    //--------------------------------------------------------
                    myCommand.Parameters["@ExtraData"].Value = OurSerializer.Serialize(itemDetails.ExtraData);
                    //--------------------------------------------------------
                    myCommand.Parameters["@AllowDublicateTitlesInItems"].Value = AllowDublicateTitlesInItems;
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




    }

}