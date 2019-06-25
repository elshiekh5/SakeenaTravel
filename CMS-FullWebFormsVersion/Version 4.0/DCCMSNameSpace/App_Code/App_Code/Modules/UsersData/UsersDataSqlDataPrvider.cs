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
    public class UsersDataSqlDataPrvider
    {

        #region --------------Instance--------------
        private static UsersDataSqlDataPrvider _Instance;
        public static UsersDataSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UsersDataSqlDataPrvider();
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
        /// Converts the UsersData object properties to SQL paramters and executes the create UsersData procedure 
        /// and updates the UsersData object with the SQL data by reference.
        /// <example>[Example]bool status=UsersDataSqlDataPrvider.Instance.Create(usersDataObject);.</example>
        /// </summary>
        /// <param name="usersDataObject">The UsersData object.</param>
        /// <returns>The status of create query.</returns>
        public bool Create(UsersDataEntity usersDataObject)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("UsersData_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserProfileID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier, 16).Value = usersDataObject.UserId;
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 128).Value = usersDataObject.Name;
                myCommand.Parameters.Add("@EmpNo", SqlDbType.Int, 4).Value = usersDataObject.EmpNo;
                myCommand.Parameters.Add("@Gender", SqlDbType.Int, 4).Value = (int)usersDataObject.Gender;
                myCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar, 32).Value = usersDataObject.BirthDate;
                myCommand.Parameters.Add("@SocialStatus", SqlDbType.Int, 4).Value = usersDataObject.SocialStatus;
                myCommand.Parameters.Add("@EducationLevel", SqlDbType.Int, 4).Value = usersDataObject.EducationLevel;
                myCommand.Parameters.Add("@CountryID", SqlDbType.Int, 4).Value = usersDataObject.CountryID;
                myCommand.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = usersDataObject.CityID;
                myCommand.Parameters.Add("@UserCityName", SqlDbType.NVarChar).Value = usersDataObject.UserCityName;
                myCommand.Parameters.Add("@Tel", SqlDbType.NVarChar, 32).Value = usersDataObject.Tel;
                myCommand.Parameters.Add("@Mobile", SqlDbType.NVarChar, 32).Value = usersDataObject.Mobile;
                myCommand.Parameters.Add("@HasSmsService", SqlDbType.Bit, 1).Value = usersDataObject.HasSmsService;
                myCommand.Parameters.Add("@HasEmailService", SqlDbType.Bit, 1).Value = usersDataObject.HasEmailService;
                myCommand.Parameters.Add("@AgeRang", SqlDbType.Int, 4).Value = usersDataObject.AgeRang;
                //------------------------------------------------------
                myCommand.Parameters.Add("@Notes1", SqlDbType.NVarChar, 512).Value = usersDataObject.Notes1;
                myCommand.Parameters.Add("@Notes2", SqlDbType.NVarChar, 512).Value = usersDataObject.Notes2;
                //------------------------------------------------------
                myCommand.Parameters.Add("@Fax", SqlDbType.NVarChar, 32).Value = usersDataObject.Fax;
                myCommand.Parameters.Add("@MailBox", SqlDbType.NVarChar, 32).Value = usersDataObject.MailBox;
                myCommand.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 32).Value = usersDataObject.ZipCode;
                myCommand.Parameters.Add("@JobID", SqlDbType.Int, 4).Value = usersDataObject.JobID;
                myCommand.Parameters.Add("@JobText", SqlDbType.NVarChar, 64).Value = usersDataObject.JobText;
                myCommand.Parameters.Add("@Url", SqlDbType.NVarChar, 128).Value = usersDataObject.Url;
                myCommand.Parameters.Add("@PhotoExtension", SqlDbType.VarChar, 5).Value = usersDataObject.PhotoExtension;
                //------------------------------------------------------
                myCommand.Parameters.Add("@Company", SqlDbType.NVarChar, 64).Value = usersDataObject.Company;
                myCommand.Parameters.Add("@ActivitiesID", SqlDbType.Int, 4).Value = usersDataObject.ActivitiesID;
                myCommand.Parameters.Add("@ExtraData", SqlDbType.NVarChar).Value = usersDataObject.ExtraData;
                //------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)usersDataObject.ModuleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)usersDataObject.LangID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = usersDataObject.CategoryID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = usersDataObject.OwnerID;
                myCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = usersDataObject.OwnerName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ProfilePageID", SqlDbType.Int, 4).Value = (int)usersDataObject.ProfilePageID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@KeyWordsAr", SqlDbType.NVarChar, 256).Value = usersDataObject.KeyWordsAr;
                myCommand.Parameters.Add("@ShortDescriptionAr", SqlDbType.NVarChar, 512).Value = usersDataObject.ShortDescriptionAr;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@KeyWordsEn", SqlDbType.NVarChar, 256).Value = usersDataObject.KeyWordsEn;
                myCommand.Parameters.Add("@ShortDescriptionEn", SqlDbType.NVarChar, 512).Value = usersDataObject.ShortDescriptionEn;
                myCommand.Parameters.Add("@SiteTitleAr", SqlDbType.NVarChar, 128).Value = usersDataObject.SiteTitleAr;
                myCommand.Parameters.Add("@SiteTitleEn", SqlDbType.NVarChar, 128).Value = usersDataObject.SiteTitleEn;
                myCommand.Parameters.Add("@SkinID", SqlDbType.VarChar, 64).Value = usersDataObject.SkinID;
                myCommand.Parameters.Add("@UserType", SqlDbType.Int, 4).Value = (int)usersDataObject.UserType;
                myCommand.Parameters.Add("@SubSiteType", SqlDbType.Int, 4).Value = (int)usersDataObject.SubSiteType;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@SiteModulesManager", SqlDbType.VarChar, 512).Value = usersDataObject.SiteModulesManager;
                myCommand.Parameters.Add("@SiteStaticPages", SqlDbType.VarChar, 512).Value = usersDataObject.SiteStaticPages;
                //----------------------------------------------------------------------------------
                // Profile parameters
                //----------------------------------------------------------------------------------
                string PropertyNames = System.String.Empty;
                string PropertyValuesString = System.String.Empty;
                ProfileBuilder.PrepareDataForSaving(ref PropertyNames, ref PropertyValuesString, usersDataObject.Profile.PropertyValueCollection);
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@PropertyNames", SqlDbType.NText).Value = PropertyNames;
                myCommand.Parameters.Add("@PropertyValuesString", SqlDbType.NText).Value = PropertyValuesString;
                //----------------------------------------------------------------------------------
                // Execute the command
                bool status = false;
                myConnection.Open();
                ExecuteCommandStatus result = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                if (result == ExecuteCommandStatus.Done)
                {
                    status = true;
                    //Get ID value from database and set it in object
                    usersDataObject.UserProfileID = (int)myCommand.Parameters["@UserProfileID"].Value;
                }

                myConnection.Close();
                return status;
            }
        }


        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Converts the UsersData object properties to SQL paramters and executes the update UsersData procedure.
        /// <example>[Example]bool  status=UsersDataSqlDataPrvider.Instance.Update(usersDataObject);.</example>
        /// </summary>
        /// <param name="usersDataObject">The UsersData object.</param>
        /// <returns>The status of update query.</returns>
        public bool Update(UsersDataEntity usersDataObject)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("UsersData_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier, 16).Value = usersDataObject.UserId;
                myCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 128).Value = usersDataObject.Name;
                myCommand.Parameters.Add("@EmpNo", SqlDbType.Int, 4).Value = usersDataObject.EmpNo;
                myCommand.Parameters.Add("@Gender", SqlDbType.Int, 4).Value = (int)usersDataObject.Gender;
                myCommand.Parameters.Add("@BirthDate", SqlDbType.VarChar, 32).Value = usersDataObject.BirthDate;
                myCommand.Parameters.Add("@SocialStatus", SqlDbType.Int, 4).Value = usersDataObject.SocialStatus;
                myCommand.Parameters.Add("@EducationLevel", SqlDbType.Int, 4).Value = usersDataObject.EducationLevel;
                myCommand.Parameters.Add("@CountryID", SqlDbType.Int, 4).Value = usersDataObject.CountryID;
                myCommand.Parameters.Add("@CityID", SqlDbType.Int, 4).Value = usersDataObject.CityID;
                myCommand.Parameters.Add("@UserCityName", SqlDbType.NVarChar).Value = usersDataObject.UserCityName;
                myCommand.Parameters.Add("@Tel", SqlDbType.NVarChar, 32).Value = usersDataObject.Tel;
                myCommand.Parameters.Add("@Mobile", SqlDbType.NVarChar, 32).Value = usersDataObject.Mobile;
                myCommand.Parameters.Add("@HasSmsService", SqlDbType.Bit, 1).Value = usersDataObject.HasSmsService;
                myCommand.Parameters.Add("@HasEmailService", SqlDbType.Bit, 1).Value = usersDataObject.HasEmailService;
                myCommand.Parameters.Add("@AgeRang", SqlDbType.Int, 4).Value = usersDataObject.AgeRang;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@Notes1", SqlDbType.NVarChar, 512).Value = usersDataObject.Notes1;
                myCommand.Parameters.Add("@Notes2", SqlDbType.NVarChar, 512).Value = usersDataObject.Notes2;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@Fax", SqlDbType.NVarChar, 32).Value = usersDataObject.Fax;
                myCommand.Parameters.Add("@MailBox", SqlDbType.NVarChar, 32).Value = usersDataObject.MailBox;
                myCommand.Parameters.Add("@ZipCode", SqlDbType.NVarChar, 32).Value = usersDataObject.ZipCode;
                myCommand.Parameters.Add("@JobID", SqlDbType.Int, 4).Value = usersDataObject.JobID;
                myCommand.Parameters.Add("@JobText", SqlDbType.NVarChar, 64).Value = usersDataObject.JobText;
                myCommand.Parameters.Add("@Url", SqlDbType.NVarChar, 128).Value = usersDataObject.Url;
                myCommand.Parameters.Add("@PhotoExtension", SqlDbType.VarChar, 5).Value = usersDataObject.PhotoExtension;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@Company", SqlDbType.NVarChar, 64).Value = usersDataObject.Company;
                myCommand.Parameters.Add("@ActivitiesID", SqlDbType.Int, 4).Value = usersDataObject.ActivitiesID;
                myCommand.Parameters.Add("@ExtraData", SqlDbType.NVarChar).Value = usersDataObject.ExtraData;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = usersDataObject.CategoryID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = usersDataObject.OwnerID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)usersDataObject.ModuleTypeID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@KeyWordsAr", SqlDbType.NVarChar, 256).Value = usersDataObject.KeyWordsAr;
                myCommand.Parameters.Add("@ShortDescriptionAr", SqlDbType.NVarChar, 512).Value = usersDataObject.ShortDescriptionAr;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@KeyWordsEn", SqlDbType.NVarChar, 256).Value = usersDataObject.KeyWordsEn;
                myCommand.Parameters.Add("@ShortDescriptionEn", SqlDbType.NVarChar, 512).Value = usersDataObject.ShortDescriptionEn;
                myCommand.Parameters.Add("@SiteTitleAr", SqlDbType.NVarChar, 128).Value = usersDataObject.SiteTitleAr;
                myCommand.Parameters.Add("@SiteTitleEn", SqlDbType.NVarChar, 128).Value = usersDataObject.SiteTitleEn;
                myCommand.Parameters.Add("@SkinID", SqlDbType.VarChar, 64).Value = usersDataObject.SkinID;
                myCommand.Parameters.Add("@UserType", SqlDbType.Int, 4).Value = (int)usersDataObject.UserType;
                myCommand.Parameters.Add("@SubSiteType", SqlDbType.Int, 4).Value = (int)usersDataObject.SubSiteType;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ProfilePageID", SqlDbType.Int, 4).Value = (int)usersDataObject.ProfilePageID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@SiteModulesManager", SqlDbType.VarChar, 512).Value = usersDataObject.SiteModulesManager;
                myCommand.Parameters.Add("@SiteStaticPages", SqlDbType.VarChar, 512).Value = usersDataObject.SiteStaticPages;
                //----------------------------------------------------------------------------------
                // Profile parameters
                //----------------------------------------------------------------------------------
                string PropertyNames = System.String.Empty;
                string PropertyValuesString = System.String.Empty;
                ProfileBuilder.PrepareDataForSaving(ref PropertyNames, ref PropertyValuesString, usersDataObject.Profile.PropertyValueCollection);
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@PropertyNames", SqlDbType.NText).Value = PropertyNames;
                myCommand.Parameters.Add("@PropertyValuesString", SqlDbType.NText).Value = PropertyValuesString;
                //---------------------------------------------------------------------------------
                // Execute the command
                bool status = false;
                myConnection.Open();
                ExecuteCommandStatus result = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                if (result == ExecuteCommandStatus.Done)
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
        /// Deletes single UsersData object .
        /// <example>[Example]bool status=UsersDataSqlDataPrvider.Instance.Delete(userProfileID);.</example>
        /// </summary>
        /// <param name="userProfileID">The usersDataObject id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(Guid usereID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("UsersData_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier, 16).Value = usereID;
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

        #region --------------IncreaseVisits--------------
       
        public void IncreaseVisits(Guid usereID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("UsersData_IncreaseVisits", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier, 16).Value = usereID;
                // Execute the command
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public List<UsersDataEntity> GetAll(int ModuleTypeID, int CategoryID, Languages LangID, string conditionStatement, string roleName, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, bool IsAvailableCondition, string keyWord)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<UsersDataEntity> usersDataList = new List<UsersDataEntity>();
                UsersDataEntity usersDataObject;
                SqlCommand myCommand = new SqlCommand("UsersData_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //---------------------------------------------------------------------------------------------------
                // Set the parameters
                //---------------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)LangID;
                myCommand.Parameters.Add("@ConditionsStatement", SqlDbType.NVarChar, 1024).Value = conditionStatement;
                myCommand.Parameters.Add("@LoweredRoleName", SqlDbType.NVarChar, 256).Value = roleName.ToLower();
                //---------------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = IsAvailableCondition;
                //---------------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@KeyWord", SqlDbType.NVarChar, 128).Value = keyWord;
                //---------------------------------------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    usersDataObject = PopulateUsersDataEntityFromIDataReader(dr);
                    usersDataList.Add(usersDataObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return usersDataList;
            }
        }
        #endregion

        #region --------------GetAll--------------
        public List<UsersDataEntity> GetLast(int ModuleTypeID, int CategoryID, Languages LangID, string conditionStatement, string roleName, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID, int Count)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<UsersDataEntity> usersDataList = new List<UsersDataEntity>();
                UsersDataEntity usersDataObject;
                SqlCommand myCommand = new SqlCommand("UsersData_GetLast", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //---------------------------------------------------------------------------------------------------
                // Set the parameters
                //---------------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)LangID;
                myCommand.Parameters.Add("@ConditionsStatement", SqlDbType.NVarChar, 1024).Value = conditionStatement;
                myCommand.Parameters.Add("@LoweredRoleName", SqlDbType.NVarChar, 256).Value = roleName.ToLower();
                //---------------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //---------------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@Count", SqlDbType.Int, 4).Value = Count;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    usersDataObject = PopulateUsersDataEntityFromIDataReader(dr);
                    usersDataList.Add(usersDataObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return usersDataList;
            }
        }
        #endregion

        #region --------------GetCount--------------
        public int GetCount(int ModuleTypeID, int CategoryID, Languages LangID, string conditionStatement, string roleName, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("UsersData_GetCount", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //---------------------------------------------------------------------------------------------------
                // Set the parameters
                //---------------------------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)ModuleTypeID;
                myCommand.Parameters.Add("@CategoryID", SqlDbType.Int, 4).Value = CategoryID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)LangID;
                myCommand.Parameters.Add("@ConditionsStatement", SqlDbType.NVarChar, 1024).Value = conditionStatement;
                myCommand.Parameters.Add("@LoweredRoleName", SqlDbType.NVarChar, 256).Value = roleName.ToLower();
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                int usersCount = (int)myCommand.ExecuteScalar();
                myConnection.Close();
                return usersCount;
            }
        }
        #endregion

        #region --------------RetrivePassword--------------
        public string RetrivePassword(string UserName)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("UsersData_RetrivePassword", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = UserName.ToLower();
                // Execute the command
                myConnection.Open();
                string password = (string)myCommand.ExecuteScalar();
                myConnection.Close();
                return password;
            }
        }
        #endregion

        #region --------------GetUsersDataObject--------------
        public UsersDataEntity GetUsersDataObject(Guid userID, Guid OwnerID)
        {
            UsersDataEntity usersDataObject = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("UsersData_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@UserId", SqlDbType.UniqueIdentifier, 16).Value = userID;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = OwnerID;
                //---------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        usersDataObject = PopulateUsersDataEntityFromIDataReader(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return usersDataObject;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateUsersDataEntityFromIDataReader--------------
        private UsersDataEntity PopulateUsersDataEntityFromIDataReader(IDataReader reader)
        {
            //Create a new UsersData object
            UsersDataEntity usersDataObject = new UsersDataEntity();
            //Fill the object with data
            //----------------------------------------------------------------
            //UserProfileID
            if (reader["UserProfileID"] != DBNull.Value)
                usersDataObject.UserProfileID = (int)reader["UserProfileID"];
            //----------------------------------------------------------------
            //UserId
            if (reader["UserId"] != DBNull.Value)
                usersDataObject.UserId = (Guid)reader["UserId"];
            //----------------------------------------------------------------
            //Name
            if (reader["Name"] != DBNull.Value)
                usersDataObject.Name = (string)reader["Name"];
            //----------------------------------------------------------------
            //EmpNo
            if (reader["EmpNo"] != DBNull.Value)
                usersDataObject.EmpNo = (int)reader["EmpNo"];
            //Gender
            if (reader["Gender"] != DBNull.Value)
                usersDataObject.Gender = (Gender)reader["Gender"];
            //----------------------------------------------------------------
            //BirthDate
            if (reader["BirthDate"] != DBNull.Value)
                usersDataObject.BirthDate = (string)reader["BirthDate"];
            //----------------------------------------------------------------
            //SocialStatus
            if (reader["SocialStatus"] != DBNull.Value)
                usersDataObject.SocialStatus = (int)reader["SocialStatus"];
            //----------------------------------------------------------------
            //EducationLevel
            if (reader["EducationLevel"] != DBNull.Value)
                usersDataObject.EducationLevel = (int)reader["EducationLevel"];
            //----------------------------------------------------------------
            //CountryID
            if (reader["CountryID"] != DBNull.Value)
                usersDataObject.CountryID = (int)reader["CountryID"];
            //----------------------------------------------------------------
            //CityID
            if (reader["CityID"] != DBNull.Value)
                usersDataObject.CityID = (int)reader["CityID"];
            //----------------------------------------------------------------
            //UserCityName
            if (reader["UserCityName"] != DBNull.Value)
                usersDataObject.UserCityName = (string)reader["UserCityName"];
            //----------------------------------------------------------------
            //Tel
            if (reader["Tel"] != DBNull.Value)
                usersDataObject.Tel = (string)reader["Tel"];
            //----------------------------------------------------------------
            //Mobile
            if (reader["Mobile"] != DBNull.Value)
                usersDataObject.Mobile = (string)reader["Mobile"];
            //----------------------------------------------------------------
            //HasSmsService
            if (reader["HasSmsService"] != DBNull.Value)
                usersDataObject.HasSmsService = (bool)reader["HasSmsService"];
            //----------------------------------------------------------------
            //HasEmailService
            if (reader["HasEmailService"] != DBNull.Value)
                usersDataObject.HasEmailService = (bool)reader["HasEmailService"];
            //----------------------------------------------------------------
            //Fax
            if (reader["Fax"] != DBNull.Value)
                usersDataObject.Fax = (string)reader["Fax"];
            //----------------------------------------------------------------
            //MailBox
            if (reader["MailBox"] != DBNull.Value)
                usersDataObject.MailBox = (string)reader["MailBox"];
            //----------------------------------------------------------------
            //ZipCode
            if (reader["ZipCode"] != DBNull.Value)
                usersDataObject.ZipCode = (string)reader["ZipCode"];
            //----------------------------------------------------------------
            //JobID
            if (reader["JobID"] != DBNull.Value)
                usersDataObject.JobID = (int)reader["JobID"];
            //----------------------------------------------------------------
            //JobText
            if (reader["JobText"] != DBNull.Value)
                usersDataObject.JobText = (string)reader["JobText"];
            //----------------------------------------------------------------
            //Url
            if (reader["Url"] != DBNull.Value)
                usersDataObject.Url = (string)reader["Url"];
            //----------------------------------------------------------------
            //PhotoExtension
            if (reader["PhotoExtension"] != DBNull.Value)
                usersDataObject.PhotoExtension = (string)reader["PhotoExtension"];
            //----------------------------------------------------------------
            //Company
            if (reader["Company"] != DBNull.Value)
                usersDataObject.Company = (string)reader["Company"];
            //----------------------------------------------------------------
            //ActivitiesID
            if (reader["ActivitiesID"] != DBNull.Value)
                usersDataObject.ActivitiesID = (int)reader["ActivitiesID"];
            //----------------------------------------------------------------
            //ExtraData
            if (reader["ExtraData"] != DBNull.Value)
            {
                usersDataObject.ExtraData = (string)reader["ExtraData"];
            }
            //----------------------------------------------------------------
            //Notes1
            if (reader["Notes1"] != DBNull.Value)
                usersDataObject.Notes1 = (string)reader["Notes1"];
            //----------------------------------------------------------------
            //Notes2
            if (reader["Notes2"] != DBNull.Value)
                usersDataObject.Notes2 = (string)reader["Notes2"];
            //----------------------------------------------------------------
            //CityName
            if (reader["CityName"] != DBNull.Value)
                usersDataObject.CityName = (string)reader["CityName"];
            //----------------------------------------------------------------
            //CountryName
            if (reader["CountryName"] != DBNull.Value)
                usersDataObject.CountryName = (string)reader["CountryName"];
            //----------------------------------------------------------------
            //IsApproved
            if (reader["IsApproved"] != DBNull.Value)
                usersDataObject.IsApproved = (bool)reader["IsApproved"];
            //----------------------------------------------------------------
            //AgeRang
            if (reader["AgeRang"] != DBNull.Value)
                usersDataObject.AgeRang = (int)reader["AgeRang"];
            //----------------------------------------------------------------
            //UserName
            if (reader["UserName"] != DBNull.Value)
                usersDataObject.UserName = (string)reader["UserName"];
            //----------------------------------------------------------------
            //ModuleTypeID
            if (reader["ModuleTypeID"] != DBNull.Value)
                usersDataObject.ModuleTypeID = (int)reader["ModuleTypeID"];
            //----------------------------------------------------------------
            //Email
            if (reader["Email"] != DBNull.Value)
                usersDataObject.Email = (string)reader["Email"];
            //----------------------------------------------------------------
            //LangID
            if (reader["LangID"] != DBNull.Value)
                usersDataObject.LangID = (Languages)reader["LangID"];
            //----------------------------------------------------------------
            //CategoryID
            if (reader["CategoryID"] != DBNull.Value)
                usersDataObject.CategoryID = (int)reader["CategoryID"];
            //----------------------------------------------------------------
            //OwnerID
            if (reader["OwnerID"] != DBNull.Value)
                usersDataObject.OwnerID = (Guid)reader["OwnerID"];
            //----------------------------------------------------------------
            //OwnerName
            if (reader["OwnerName"] != DBNull.Value)
                usersDataObject.OwnerName = (string)reader["OwnerName"];
            //----------------------------------------------------------------
            //ProfilePageID
            if (reader["ProfilePageID"] != DBNull.Value)
                usersDataObject.ProfilePageID = (int)reader["ProfilePageID"];
            //----------------------------------------------------------------
            
            //Date_Added
            if (reader["Date_Added"] != DBNull.Value)
                usersDataObject.Date_Added = (DateTime)reader["Date_Added"];
            //----------------------------------------------------------------
            //LastModification
            if (reader["LastModification"] != DBNull.Value)
                usersDataObject.LastModification = (DateTime)reader["LastModification"];
            //----------------------------------------------------------------
            //MessagesTotalCount
            if (reader["MessagesTotalCount"] != DBNull.Value)
                usersDataObject.MessagesTotalCount = (int)reader["MessagesTotalCount"];
            //----------------------------------------------------------------
            //MessagesNewCount
            if (reader["MessagesNewCount"] != DBNull.Value)
                usersDataObject.MessagesNewCount = (int)reader["MessagesNewCount"];
            //----------------------------------------------------------------
            //KeyWordsAr
            if (reader["KeyWordsAr"] != DBNull.Value)
                usersDataObject.KeyWordsAr = (string)reader["KeyWordsAr"];
            //----------------------------------------------------------------
            //ShortDescriptionAr
            if (reader["ShortDescriptionAr"] != DBNull.Value)
                usersDataObject.ShortDescriptionAr = (string)reader["ShortDescriptionAr"];
            //----------------------------------------------------------------
            //KeyWordsEn
            if (reader["KeyWordsEn"] != DBNull.Value)
                usersDataObject.KeyWordsEn = (string)reader["KeyWordsEn"];
            //----------------------------------------------------------------
            //ShortDescriptionEn
            if (reader["ShortDescriptionEn"] != DBNull.Value)
                usersDataObject.ShortDescriptionEn = (string)reader["ShortDescriptionEn"];
            //----------------------------------------------------------------
            //SiteTitleAr
            if (reader["SiteTitleAr"] != DBNull.Value)
                usersDataObject.SiteTitleAr = (string)reader["SiteTitleAr"];
            //----------------------------------------------------------------
            //SiteTitleEn
            if (reader["SiteTitleEn"] != DBNull.Value)
                usersDataObject.SiteTitleEn = (string)reader["SiteTitleEn"];
            //----------------------------------------------------------------
            //SkinID
            if (reader["SkinID"] != DBNull.Value)
                usersDataObject.SkinID = (string)reader["SkinID"];
            //----------------------------------------------------------------
            //VisitorsCount
            if (reader["VisitorsCount"] != DBNull.Value)
                usersDataObject.VisitorsCount = (int)reader["VisitorsCount"];
            //----------------------------------------------------------------
            //UserType
            if (reader["UserType"] != DBNull.Value)
                usersDataObject.UserType = (UsersTypes)reader["UserType"];
            //----------------------------------------------------------------
            //SubSiteType
            if (reader["SubSiteType"] != DBNull.Value)
                usersDataObject.SubSiteType = (SubSiteTypes)reader["SubSiteType"];
            //----------------------------------------------------------------
            //SiteModulesManager
            if (reader["SiteModulesManager"] != DBNull.Value)
                usersDataObject.SiteModulesManager = (string)reader["SiteModulesManager"];
            //----------------------------------------------------------------
            //SiteStaticPages
            if (reader["SiteStaticPages"] != DBNull.Value)
                usersDataObject.SiteStaticPages = (string)reader["SiteStaticPages"];
            //----------------------------------------------------------------
            //Profile 
            //----------------------------------------------------------------
            //PropertyNames 
                if (reader["PropertyNames"] != DBNull.Value)
                    usersDataObject.Profile.PropertyNames = (string)reader["PropertyNames"];
            //PropertyValuesString 
                if (reader["PropertyValuesString"] != DBNull.Value)
                    usersDataObject.Profile.PropertyValuesString = (string)reader["PropertyValuesString"];

            ProfileBuilder.ParseProfileData(usersDataObject.Profile.PropertyNames, usersDataObject.Profile.PropertyValuesString, usersDataObject.Profile.PropertyValueCollection);
            //Return the populated object
            return usersDataObject;
            //----------------------------------------------------------------
        }
        //------------------------------------------
        #endregion
    }
}

