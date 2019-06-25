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
    public class MessagesSqlDataPrvider : SqlDataProvider
    {

        #region --------------Instance--------------
        private static MessagesSqlDataPrvider _Instance;
        public static MessagesSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new MessagesSqlDataPrvider();
                }
                return _Instance;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Create--------------
        /// <summary>
        /// Converts the Messages object properties to SQL paramters and executes the create Messages procedure 
        /// and updates the Messages object with the SQL data by reference.
        /// <example>[Example]bool status=MessagesSqlDataPrvider.Instance.Create(msg);.</example>
        /// </summary>
        /// <param name="msg">The Messages object.</param>
        /// <returns>The status of create query.</returns>
        public bool Create(MessagesEntity msg)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Messages_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@MessageID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 128).Value = msg.Name;
                myCommand.Parameters.Add("@Mobile", SqlDbType.NVarChar, 32).Value = msg.Mobile;
                myCommand.Parameters.Add("@EMail", SqlDbType.VarChar, 128).Value = msg.EMail;

                myCommand.Parameters.Add("@NationalityID", SqlDbType.Int, 4).Value = msg.NationalityID;
                myCommand.Parameters.Add("@CountryID", SqlDbType.Int, 4).Value = msg.CountryID;
                myCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 256).Value = msg.Address;
                myCommand.Parameters.Add("@JobTel", SqlDbType.NVarChar, 32).Value = msg.JobTel;
                myCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = msg.Type;
                myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = msg.Title;
                myCommand.Parameters.Add("@Details", SqlDbType.NText).Value = msg.Details;
                myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier).Value = msg.UserId;
                myCommand.Parameters.Add("@ToItemID", SqlDbType.Int, 4).Value = msg.ToItemID;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)msg.ModuleTypeID;
                //------------------------------------------------------
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = msg.CategoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)msg.LangID;
                myCommand.Parameters.Add("@ToUserID", SqlDbType.UniqueIdentifier).Value = msg.ToUserID;
                //------------------------------------------------------
                myCommand.Parameters.Add("@EmpNo", SqlDbType.Int, 4).Value = msg.EmpNo;
                myCommand.Parameters.Add("@Gender", SqlDbType.Int, 4).Value = (int)msg.Gender;
                myCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar, 32).Value = msg.BirthDate;
                myCommand.Parameters.Add("@SocialStatus", SqlDbType.Int, 4).Value = msg.SocialStatus;
                myCommand.Parameters.Add("@EducationLevel", SqlDbType.Int, 4).Value = msg.EducationLevel;
                myCommand.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = msg.CityID;
                myCommand.Parameters.Add("@UserCityName", SqlDbType.NVarChar).Value = msg.UserCityName;
                myCommand.Parameters.Add("@Tel", SqlDbType.NVarChar, 32).Value = msg.Tel;
                myCommand.Parameters.Add("@HasSmsService", SqlDbType.Bit, 1).Value = msg.HasSmsService;
                myCommand.Parameters.Add("@HasEmailService", SqlDbType.Bit, 1).Value = msg.HasEmailService;
                myCommand.Parameters.Add("@AgeRang", SqlDbType.Int, 4).Value = msg.AgeRang;
                //------------------------------------------------------
                myCommand.Parameters.Add("@Notes1", SqlDbType.NVarChar, 512).Value = msg.Notes1;
                myCommand.Parameters.Add("@Notes2", SqlDbType.NVarChar, 512).Value = msg.Notes2;
                //------------------------------------------------------
                myCommand.Parameters.Add("@Fax", SqlDbType.NVarChar, 32).Value = msg.Fax;
                myCommand.Parameters.Add("@MailBox", SqlDbType.NVarChar, 32).Value = msg.MailBox;
                myCommand.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 32).Value = msg.ZipCode;
                myCommand.Parameters.Add("@JobID", SqlDbType.Int, 4).Value = msg.JobID;
                myCommand.Parameters.Add("@JobText", SqlDbType.NVarChar, 64).Value = msg.JobText;
                myCommand.Parameters.Add("@Url", SqlDbType.NVarChar, 128).Value = msg.Url;
                myCommand.Parameters.Add("@PhotoExtension", SqlDbType.VarChar, 5).Value = msg.PhotoExtension;
                //------------------------------------------------------
                myCommand.Parameters.Add("@Company", SqlDbType.NVarChar, 64).Value = msg.Company;
                myCommand.Parameters.Add("@ActivitiesID", SqlDbType.Int, 4).Value = msg.ActivitiesID;
                myCommand.Parameters.Add("@ExtraData", SqlDbType.NVarChar).Value = OurSerializer.Serialize(msg.ExtraData);
                //------------------------------------------------------
                myCommand.Parameters.Add("@FileExtension", SqlDbType.VarChar, 5).Value = msg.FileExtension;
                //------------------------------------------------------
                //New Parameters
                //-----------------
                myCommand.Parameters.Add("@IsMain", SqlDbType.Bit).Value = msg.IsMain;
                myCommand.Parameters.Add("@VideoExtension", SqlDbType.VarChar, 5).Value = msg.VideoExtension;
                myCommand.Parameters.Add("@AudioExtension", SqlDbType.VarChar, 5).Value = msg.AudioExtension;
                myCommand.Parameters.Add("@Priority", SqlDbType.Int, 4).Value = (int)msg.Priority;
                myCommand.Parameters.Add("@Photo2Extension", SqlDbType.VarChar, 5).Value = msg.Photo2Extension;
                myCommand.Parameters.Add("@Height", SqlDbType.Int, 4).Value = msg.Height;
                myCommand.Parameters.Add("@Width", SqlDbType.Int, 4).Value = msg.Width;
                //----------------------------------------------------------------------------------
                if (msg.ItemDate != DateTime.MinValue)
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = (DateTime)msg.ItemDate;
                else
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = DBNull.Value;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@InsertUserName", SqlDbType.NVarChar, 64).Value = (string)msg.InsertUserName;
                myCommand.Parameters.Add("@YoutubeCode", SqlDbType.VarChar, 16).Value = (string)msg.YoutubeCode;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@GoogleLatitude", SqlDbType.NVarChar).Value = msg.GoogleLatitude;
                myCommand.Parameters.Add("@GoogleLongitude", SqlDbType.NVarChar).Value = msg.GoogleLongitude;
                myCommand.Parameters.Add("@Price", SqlDbType.NVarChar, 128).Value = msg.Price;
                myCommand.Parameters.Add("@OnlyForRegisered", SqlDbType.Bit).Value = msg.OnlyForRegisered;
                //-------------------------------------
                myCommand.Parameters.Add("@PublishPhoto", SqlDbType.Bit).Value = msg.PublishPhoto;
                myCommand.Parameters.Add("@PublishPhoto2", SqlDbType.Bit).Value = msg.PublishPhoto2;
                myCommand.Parameters.Add("@PublishFile", SqlDbType.Bit).Value = msg.PublishFile;
                myCommand.Parameters.Add("@PublishAudio", SqlDbType.Bit).Value = msg.PublishAudio;
                myCommand.Parameters.Add("@PublishVideo", SqlDbType.Bit).Value = msg.PublishVideo;
                myCommand.Parameters.Add("@PublishYoutbe", SqlDbType.Bit).Value = msg.PublishYoutbe;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ShortDescription", SqlDbType.NText).Value = msg.ShortDescription;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = msg.OwnerID;
                myCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = msg.OwnerName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@KeyWords", SqlDbType.NVarChar, 256).Value = msg.KeyWords;
                //----------------------------------------------------------------------------------
                

                // Execute the command
                bool status = false;
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                    //Get ID value from database and set it in object
                    msg.MessageID = (int)myCommand.Parameters["@MessageID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Converts the Messages object properties to SQL paramters and executes the update Messages procedure.
        /// <example>[Example]bool  status=MessagesSqlDataPrvider.Instance.Update(msg);.</example>
        /// </summary>
        /// <param name="msg">The Messages object.</param>
        /// <returns>The status of update query.</returns>
        public bool Update(MessagesEntity msg)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Messages_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@MessageID", SqlDbType.Int, 4).Value = msg.MessageID;
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 128).Value = msg.Name;
                myCommand.Parameters.Add("@Mobile", SqlDbType.NVarChar, 32).Value = msg.Mobile;
                myCommand.Parameters.Add("@EMail", SqlDbType.VarChar, 128).Value = msg.EMail;
                myCommand.Parameters.Add("@NationalityID", SqlDbType.Int, 4).Value = msg.NationalityID;
                myCommand.Parameters.Add("@CountryID", SqlDbType.Int, 4).Value = msg.CountryID;
                myCommand.Parameters.Add("@Address", SqlDbType.NVarChar, 256).Value = msg.Address;
                myCommand.Parameters.Add("@JobTel", SqlDbType.NVarChar, 32).Value = msg.JobTel;
                myCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = msg.Type;
                myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128).Value = msg.Title;
                myCommand.Parameters.Add("@Details", SqlDbType.NText).Value = msg.Details;
                myCommand.Parameters.Add("@ToItemID", SqlDbType.Int, 4).Value = msg.ToItemID;
                myCommand.Parameters.Add("@ShortDescription", SqlDbType.NText).Value = msg.ShortDescription;
                myCommand.Parameters.Add("@Reply", SqlDbType.NText).Value = msg.Reply;
                myCommand.Parameters.Add("@IsAvailable", SqlDbType.Bit, 1).Value = msg.IsAvailable;
                myCommand.Parameters.Add("@IsReplied", SqlDbType.Bit, 1).Value = msg.IsReplied;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = msg.CategoryID;
                myCommand.Parameters.Add("@ToUserID", SqlDbType.UniqueIdentifier).Value = msg.ToUserID;
                //----------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@EmpNo", SqlDbType.Int, 4).Value = msg.EmpNo;
                myCommand.Parameters.Add("@Gender", SqlDbType.Int, 4).Value = (int)msg.Gender;
                myCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar, 32).Value = msg.BirthDate;
                myCommand.Parameters.Add("@SocialStatus", SqlDbType.Int, 4).Value = msg.SocialStatus;
                myCommand.Parameters.Add("@EducationLevel", SqlDbType.Int, 4).Value = msg.EducationLevel;
                myCommand.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = msg.CityID;
                myCommand.Parameters.Add("@UserCityName", SqlDbType.NVarChar).Value = msg.UserCityName;
                myCommand.Parameters.Add("@Tel", SqlDbType.NVarChar, 32).Value = msg.Tel;
                myCommand.Parameters.Add("@HasSmsService", SqlDbType.Bit, 1).Value = msg.HasSmsService;
                myCommand.Parameters.Add("@HasEmailService", SqlDbType.Bit, 1).Value = msg.HasEmailService;
                myCommand.Parameters.Add("@AgeRang", SqlDbType.Int, 4).Value = msg.AgeRang;
                //------------------------------------------------------
                myCommand.Parameters.Add("@Notes1", SqlDbType.NVarChar, 512).Value = msg.Notes1;
                myCommand.Parameters.Add("@Notes2", SqlDbType.NVarChar, 512).Value = msg.Notes2;
                //------------------------------------------------------
                myCommand.Parameters.Add("@Fax", SqlDbType.NVarChar, 32).Value = msg.Fax;
                myCommand.Parameters.Add("@MailBox", SqlDbType.NVarChar, 32).Value = msg.MailBox;
                myCommand.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 32).Value = msg.ZipCode;
                myCommand.Parameters.Add("@JobID", SqlDbType.Int, 4).Value = msg.JobID;
                myCommand.Parameters.Add("@JobText", SqlDbType.NVarChar, 64).Value = msg.JobText;
                myCommand.Parameters.Add("@Url", SqlDbType.NVarChar, 128).Value = msg.Url;
                myCommand.Parameters.Add("@PhotoExtension", SqlDbType.VarChar, 5).Value = msg.PhotoExtension;
                //------------------------------------------------------
                myCommand.Parameters.Add("@Company", SqlDbType.NVarChar, 64).Value = msg.Company;
                myCommand.Parameters.Add("@ActivitiesID", SqlDbType.Int, 4).Value = msg.ActivitiesID;
                myCommand.Parameters.Add("@ExtraData", SqlDbType.NVarChar).Value = OurSerializer.Serialize(msg.ExtraData);
                //------------------------------------------------------
                myCommand.Parameters.Add("@FileExtension", SqlDbType.VarChar, 5).Value = msg.FileExtension;
                //------------------------------------------------------
                //New Parameters
                //-----------------
                myCommand.Parameters.Add("@IsMain", SqlDbType.Bit).Value = msg.IsMain;
                myCommand.Parameters.Add("@VideoExtension", SqlDbType.VarChar, 5).Value = msg.VideoExtension;
                myCommand.Parameters.Add("@AudioExtension", SqlDbType.VarChar, 5).Value = msg.AudioExtension;
                myCommand.Parameters.Add("@Priority", SqlDbType.Int, 4).Value = (int)msg.Priority;
                myCommand.Parameters.Add("@Photo2Extension", SqlDbType.VarChar, 5).Value = msg.Photo2Extension;
                myCommand.Parameters.Add("@Height", SqlDbType.Int, 4).Value = msg.Height;
                myCommand.Parameters.Add("@Width", SqlDbType.Int, 4).Value = msg.Width;
                //----------------------------------------------------------------------------------
                if (msg.ItemDate != DateTime.MinValue)
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = (DateTime)msg.ItemDate;
                else
                    myCommand.Parameters.Add("@ItemDate", SqlDbType.DateTime).Value = DBNull.Value;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@LastUpdateUserName", SqlDbType.NVarChar, 64).Value = (string)msg.LastUpdateUserName;
                myCommand.Parameters.Add("@YoutubeCode", SqlDbType.VarChar, 16).Value = (string)msg.YoutubeCode;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@GoogleLatitude", SqlDbType.NVarChar).Value = msg.GoogleLatitude;
                myCommand.Parameters.Add("@GoogleLongitude", SqlDbType.NVarChar).Value = msg.GoogleLongitude;
                myCommand.Parameters.Add("@Price", SqlDbType.NVarChar).Value = msg.Price;
                myCommand.Parameters.Add("@OnlyForRegisered", SqlDbType.Bit).Value = msg.OnlyForRegisered;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@PublishPhoto", SqlDbType.Bit).Value = msg.PublishPhoto;
                myCommand.Parameters.Add("@PublishPhoto2", SqlDbType.Bit).Value = msg.PublishPhoto2;
                myCommand.Parameters.Add("@PublishFile", SqlDbType.Bit).Value = msg.PublishFile;
                myCommand.Parameters.Add("@PublishAudio", SqlDbType.Bit).Value = msg.PublishAudio;
                myCommand.Parameters.Add("@PublishVideo", SqlDbType.Bit).Value = msg.PublishVideo;
                myCommand.Parameters.Add("@PublishYoutbe", SqlDbType.Bit).Value = msg.PublishYoutbe;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = msg.OwnerID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@KeyWords", SqlDbType.NVarChar, 256).Value = msg.KeyWords;
                //----------------------------------------------------------------------------------
                
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
        /// Deletes single Messages object .
        /// <example>[Example]bool status=MessagesSqlDataPrvider.Instance.Delete(messageID);.</example>
        /// </summary>
        /// <param name="messageID">The msg id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int messageID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Messages_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@MessageID", SqlDbType.Int, 4).Value = messageID;
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
        public List<MessagesEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, object toUserIdProviderKey, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, string keyWord)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MessagesEntity> messagesList = new List<MessagesEntity>();
                MessagesEntity msg;
                SqlCommand myCommand = new SqlCommand("Messages_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                //-------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)LangID;
                myCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = type;
                myCommand.Parameters.Add("@ToItemID", SqlDbType.Int, 4).Value = ToItemID;
                //-------------------------------------------------------------------------------------
                if (toUserIdProviderKey != null)
                {
                    Guid userID = new Guid(toUserIdProviderKey.ToString());
                    if (userID != Guid.Empty)
                        myCommand.Parameters.Add("@ToUserId", SqlDbType.UniqueIdentifier).Value = toUserIdProviderKey;
                }
                //-------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@UnRepliedCondition", SqlDbType.Bit, 1).Value = UnRepliedCondition;
                myCommand.Parameters.Add("@NotSeenCondition", SqlDbType.Bit, 1).Value = NotSeenCondition;
                //-------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@KeyWord", SqlDbType.NVarChar, 128).Value = keyWord;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {

                    //(msg) = PopulateEntity(dr);
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return messagesList;
            }
        }
        #endregion

        #region --------------ExportData--------------
        public List<MessagesEntity> ExportData(int ModuleTypeID, int CategoryID, Languages LangID, int type, int ToItemID, object toUserIdProviderKey, bool isAvailableCondition, bool UnRepliedCondition, bool NotSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MessagesEntity> messagesList = new List<MessagesEntity>();
                MessagesEntity msg;
                SqlCommand myCommand = new SqlCommand("Messages_ExportData", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)LangID;
                myCommand.Parameters.Add("@Type", SqlDbType.Int, 4).Value = type;
                myCommand.Parameters.Add("@ToItemID", SqlDbType.Int, 4).Value = ToItemID;
                if (toUserIdProviderKey != null)
                {
                    Guid userID = new Guid(toUserIdProviderKey.ToString());
                    if (userID != Guid.Empty)
                        myCommand.Parameters.Add("@ToUserId", SqlDbType.UniqueIdentifier).Value = toUserIdProviderKey;
                }
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@UnRepliedCondition", SqlDbType.Bit, 1).Value = UnRepliedCondition;
                myCommand.Parameters.Add("@NotSeenCondition", SqlDbType.Bit, 1).Value = NotSeenCondition;
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
                    //(msg) = PopulateEntity(dr);
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return messagesList;
            }
        }
        #endregion

        #region --------------GetMessagesObject--------------
        public MessagesEntity GetMessagesObject(int messageID, UsersTypes viewerType, Guid OwnerID)
        {
            MessagesEntity msg = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Messages_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ViewerType ", SqlDbType.Int, 4).Value = (int)viewerType;
                myCommand.Parameters.Add("@MessageID", SqlDbType.Int, 4).Value = messageID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        //msg = PopulateEntity(dr);
                        msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    }
                    dr.Close();
                }
                myConnection.Close();
                return msg;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetLastFlv--------------
        public List<MessagesEntity> GetLastFlv(Languages langID, Guid OwnerID)
        {
            List<MessagesEntity> messagesList = new List<MessagesEntity>();
            MessagesEntity msg;
            //Hashtable temp = new Hashtable();
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Messages_GetLastFlv", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
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
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return messagesList;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------SearchInMultiModules--------------
        public List<MessagesEntity> SearchInMultiModules(string modules, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, string keyWord, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MessagesEntity> messagesList = new List<MessagesEntity>();
                MessagesEntity msg;
                Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Messages_SearchInMultiModules", myConnection);
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
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);

                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = messagesList.Count;
                //----------------------------------------------------------------
                return messagesList;
            }
        }
        #endregion

        #region --------------GetCount--------------
        public int GetCount(int moduleTypeID, Languages langID, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Messages_GetCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                int messagesCount = (int)myCommand.ExecuteScalar();
                myConnection.Close();
                return messagesCount;
            }
        }
        #endregion

        #region --------------GetLast--------------
        public List<MessagesEntity> GetLast(int moduleTypeID, Languages langID, int count, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MessagesEntity> messagesList = new List<MessagesEntity>();
                MessagesEntity msg;
                SqlCommand myCommand = new SqlCommand("Messages_GetLast", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
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
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);
                }
                dr.Close();
                myConnection.Close();
                return messagesList;
            }
        }
        #endregion

        #region --------------GetLastInMultiModules--------------
        public List<MessagesEntity> GetLastInMultiModules(string Modules, Languages langID, int count, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MessagesEntity> messagesList = new List<MessagesEntity>();
                MessagesEntity msg;
                SqlCommand myCommand = new SqlCommand("Messages_GetLastInMultiModules", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@Modules", SqlDbType.NVarChar, 128).Value = Modules;
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
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);
                }
                dr.Close();
                myConnection.Close();
                return messagesList;
            }
        }
        #endregion

        #region --------------GetLastRandom--------------
        public List<MessagesEntity> GetLastRandom(int moduleTypeID, Languages langID, int count, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MessagesEntity> messagesList = new List<MessagesEntity>();
                MessagesEntity msg;
                SqlCommand myCommand = new SqlCommand("Messages_GetLastRandom", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
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
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);
                }
                dr.Close();
                myConnection.Close();
                return messagesList;
            }
        }
        #endregion

        #region --------------GetLastRandomInMultiModules--------------
        public List<MessagesEntity> GetLastRandomInMultiModules(string Modules, Languages langID, int count, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MessagesEntity> messagesList = new List<MessagesEntity>();
                MessagesEntity msg;
                SqlCommand myCommand = new SqlCommand("Messages_GetLastRandomInMultiModules", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@Modules", SqlDbType.NVarChar, 128).Value = Modules;
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
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);
                }
                dr.Close();
                myConnection.Close();
                return messagesList;
            }
        }
        #endregion

        #region --------------GetMain--------------
        public List<MessagesEntity> GetMain(int moduleTypeID, Languages langID, int count, Guid OwnerID)
        {
            List<MessagesEntity> messagesList = new List<MessagesEntity>();
            MessagesEntity msg;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Messages_GetMain", myConnection);
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
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);
                }
                dr.Close();
                myConnection.Close();
                //----------------------------------------------------------------
                return messagesList;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetNotMain--------------
        public List<MessagesEntity> GetNotMain(int moduleTypeID, Languages langID, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MessagesEntity> messagesList = new List<MessagesEntity>();
                MessagesEntity msg;
                SqlCommand myCommand = new SqlCommand("Messages_GetNotMain", myConnection);
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
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);
                }
                dr.Close();
                myConnection.Close();
                return messagesList;
            }
        }
        #endregion

        #region --------------rate--------------
        public void Rate(int messageID, int rate)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("Messages_Rate", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@MessageID", SqlDbType.Int, 4).Value = messageID;
                myCommand.Parameters.Add("@AddValue", SqlDbType.Int, 4).Value = rate;
                // Execute the command
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetAllFlv--------------
        public List<MessagesEntity> GetAllFlv(int moduleTypeID, Languages langID, int categoryID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<MessagesEntity> messagesList = new List<MessagesEntity>();
                MessagesEntity msg;
                //Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("Messages_GetAllFlv", myConnection);
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
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    msg = (MessagesEntity)GetEntity(dr, typeof(MessagesEntity));
                    messagesList.Add(msg);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = messagesList.Count;
                //----------------------------------------------------------------
                return messagesList;
            }
        }
        #endregion

    }

}