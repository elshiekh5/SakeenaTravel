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
    public class ItemsCommentsSqlDataPrvider
    {
        #region --------------Instance--------------
        private static ItemsCommentsSqlDataPrvider _Instance;
        public static ItemsCommentsSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ItemsCommentsSqlDataPrvider();
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
        /// Converts the Comments object properties to SQL paramters and executes the create Comments procedure 
        /// and updates the Comments object with the SQL data by reference.
        /// <example>[Example]bool status=ItemsCommentsSqlDataPrvider.Instance.Create(comments);.</example>
        /// </summary>
        /// <param name="comments">The Comments object.</param>
        /// <returns>The status of create query.</returns>
        public ExecuteCommandStatus Create(ItemsCommentsEntity comments)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsComments_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CommentID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = comments.ItemID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int).Value = (int)comments.LangID;
                myCommand.Parameters.Add("@SenderName", SqlDbType.NVarChar, 255).Value = comments.SenderName;
                myCommand.Parameters.Add("@CountryID", SqlDbType.Int, 4).Value = comments.CountryID;
                myCommand.Parameters.Add("@CtryShort", SqlDbType.Char, 2).Value = comments.CtryShort;
                myCommand.Parameters.Add("@SendingDate", SqlDbType.DateTime, 8).Value = comments.SendingDate;
                myCommand.Parameters.Add("@SenderEmail", SqlDbType.NVarChar, 100).Value = comments.SenderEmail;
                myCommand.Parameters.Add("@CommentTitle", SqlDbType.NVarChar, 200).Value = comments.CommentTitle;
                myCommand.Parameters.Add("@CommentText", SqlDbType.NVarChar, 1000).Value = comments.CommentText;
                myCommand.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = comments.IsActive;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@InsertUserName", SqlDbType.NVarChar, 64).Value = (string)comments.InsertUserName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int).Value = comments.ModuleTypeID;
                myCommand.Parameters.Add("@BaseModuleType", SqlDbType.Int).Value = (int)comments.BaseModuleType;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = comments.OwnerID;
                //----------------------------------------------------------------------------------

                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                if (status == ExecuteCommandStatus.Done)
                {
                    //Get ID value from database and set it in object
                    comments.CommentID = (int)myCommand.Parameters["@CommentID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------

        public ExecuteCommandStatus Update(ItemsCommentsEntity comments)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsComments_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CommentID", SqlDbType.Int, 4).Value = comments.CommentID;
                //myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = comments.ItemID;
                // myCommand.Parameters.Add("@LangID", SqlDbType.Int).Value = (int)comments.LangID;
                myCommand.Parameters.Add("@SenderName", SqlDbType.NVarChar, 255).Value = comments.SenderName;
                //myCommand.Parameters.Add("@CountryID", SqlDbType.Int, 4).Value = comments.CountryID;
                //myCommand.Parameters.Add("@CtryShort", SqlDbType.Char, 2).Value = comments.CtryShort;
                //myCommand.Parameters.Add("@SendingDate", SqlDbType.DateTime, 8).Value = comments.SendingDate;
                myCommand.Parameters.Add("@SenderEmail", SqlDbType.NVarChar, 100).Value = comments.SenderEmail;
                myCommand.Parameters.Add("@CommentTitle", SqlDbType.NVarChar, 200).Value = comments.CommentTitle;
                myCommand.Parameters.Add("@CommentText", SqlDbType.NVarChar, 1000).Value = comments.CommentText;
                myCommand.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = comments.IsActive;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@LastUpdateUserName", SqlDbType.NVarChar, 64).Value = (string)comments.LastUpdateUserName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = comments.OwnerID;
                //----------------------------------------------------------------------------------

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
        /// Deletes single Comments object .
        /// <example>[Example]bool status=ItemsCommentsSqlDataPrvider.Instance.Delete(commentID);.</example>
        /// </summary>
        /// <param name="commentID">The comments id.</param>
        /// <returns>The status of delete query.</returns>
        public ExecuteCommandStatus Delete(int commentID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsComments_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CommentID", SqlDbType.Int, 4).Value = commentID;
                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------ActivateComment--------------
        public ExecuteCommandStatus ActivateComment(int commentID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsComments_ActivateComment", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CommentID", SqlDbType.Int, 4).Value = commentID;
                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                myConnection.Close();
                return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------AddBadCommnetAlert--------------

        public void AddBadCommnetAlert(int commentID, int availableAlertsCount)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsComments_AddBadCommnetAlert", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CommentID", SqlDbType.Int, 4).Value = commentID;
                myCommand.Parameters.Add("@AvailableAlertsCount", SqlDbType.Int, 4).Value = availableAlertsCount;
                // Execute the command
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public List<ItemsCommentsEntity> GetAll(int itemID, Languages langID, int moduleTypeID, bool isAvailableCondition, bool isActive, bool notSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<ItemsCommentsEntity> commentsList = new List<ItemsCommentsEntity>();
                ItemsCommentsEntity comments;
                SqlCommand myCommand = new SqlCommand("ItemsComments_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 8).Value = itemID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 8).Value = (int)langID;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 8).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = isActive;
                myCommand.Parameters.Add("@NotSeenCondition", SqlDbType.Bit, 1).Value = notSeenCondition;
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
                    (comments) = PopulateEntity(dr);
                    commentsList.Add(comments);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = commentsList.Count;
                //----------------------------------------------------------------
                return commentsList;
            }
        }
        #endregion

        #region --------------GetCount--------------
        public int GetCount(int itemID, Languages langID, int moduleTypeID, bool isAvailableCondition, bool isActive, bool notSeenCondition, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsComments_GetCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 8).Value = itemID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 8).Value = (int)langID;
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 8).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@IsActive", SqlDbType.Bit, 1).Value = isActive;
                myCommand.Parameters.Add("@NotSeenCondition", SqlDbType.Bit, 1).Value = notSeenCondition;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                int itemsCount = (int)myCommand.ExecuteScalar();
                myConnection.Close();
                return itemsCount;
            }
        }
        #endregion

        #region --------------GetObject--------------
        public ItemsCommentsEntity GetObject(int commentID, Guid OwnerID)
        {
            ItemsCommentsEntity comments = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("ItemsComments_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@CommentID", SqlDbType.Int, 4).Value = commentID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //----------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        comments = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return comments;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateEntity--------------
        private ItemsCommentsEntity PopulateEntity(IDataReader reader)
        {
            //Create a new Comments object
            ItemsCommentsEntity comments = new ItemsCommentsEntity();
            //Fill the object with data
            //CommentID
            if (reader["CommentID"] != DBNull.Value)
                comments.CommentID = (int)reader["CommentID"];
            //ItemID
            if (reader["ItemID"] != DBNull.Value)
                comments.ItemID = (int)reader["ItemID"];
            //LangID
            if (reader["LangID"] != DBNull.Value)
                comments.LangID = (Languages)reader["LangID"];
            //ModuleTypeID
            if (reader["ModuleTypeID"] != DBNull.Value)
                comments.ModuleTypeID = (int)reader["ModuleTypeID"];
            //SenderName
            if (reader["SenderName"] != DBNull.Value)
                comments.SenderName = (string)reader["SenderName"];
            //CountryID
            if (reader["CountryID"] != DBNull.Value)
                comments.CountryID = (int)reader["CountryID"];
            //CtryShort
            if (reader["CtryShort"] != DBNull.Value)
                comments.CtryShort = (string)reader["CtryShort"];
            //SendingDate
            if (reader["SendingDate"] != DBNull.Value)
                comments.SendingDate = (DateTime)reader["SendingDate"];
            //SenderEmail
            if (reader["SenderEmail"] != DBNull.Value)
                comments.SenderEmail = (string)reader["SenderEmail"];
            //CommentTitle
            if (reader["CommentTitle"] != DBNull.Value)
                comments.CommentTitle = (string)reader["CommentTitle"];
            //CommentText
            if (reader["CommentText"] != DBNull.Value)
                comments.CommentText = (string)reader["CommentText"];
            //IsActive
            if (reader["IsActive"] != DBNull.Value)
                comments.IsActive = (bool)reader["IsActive"];
            //IsSeen
            if (reader["IsSeen"] != DBNull.Value)
                comments.IsSeen = (bool)reader["IsSeen"];
            //BadAlertsCount
            if (reader["BadAlertsCount"] != DBNull.Value)
                comments.BadAlertsCount = (int)reader["BadAlertsCount"];
            //------------------------------------------------------------------
            //InsertUserName
            if (reader["InsertUserName"] != DBNull.Value)
                comments.InsertUserName = (string)reader["InsertUserName"];
            //------------------------------------------------------------------ 
            //LastUpdateUserName
            if (reader["LastUpdateUserName"] != DBNull.Value)
                comments.LastUpdateUserName = (string)reader["LastUpdateUserName"];
            //------------------------------------------------------------------
            //Return the populated object
            return comments;
        }
        //------------------------------------------
        #endregion
    }

}