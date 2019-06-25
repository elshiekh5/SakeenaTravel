using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using DCCMSNameSpace;
using System.Collections.Specialized;
using System.Reflection;


namespace DCCMSNameSpace
{
    public class SiteDeparmentsSqlDataPrvider : SqlDataProvider
    {

        #region --------------Instance--------------
        private static SiteDeparmentsSqlDataPrvider _Instance;
        public static SiteDeparmentsSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SiteDeparmentsSqlDataPrvider();
                }
                return _Instance;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Create--------------
        /// <summary>
        /// Converts the SiteDeparments object properties to SQL paramters and executes the create SiteDeparments procedure 
        /// and updates the SiteDeparments object with the SQL data by reference.
        /// <example>[Example]bool status=SiteDeparmentsSqlDataPrvider.Instance.Create(siteDeparmentsObject);.</example>
        /// </summary>
        /// <param name="siteDeparmentsObject">The SiteDeparments object.</param>
        /// <returns>The status of create query.</returns>
        public ExecuteCommandStatus Create(SiteDeparmentsEntity siteDeparmentsObject)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteDeparments_Create", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@DepartmentID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@PhotoExtension", SqlDbType.VarChar, 5).Value = siteDeparmentsObject.PhotoExtension;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@IsAvailable", SqlDbType.Bit, 1).Value = siteDeparmentsObject.IsAvailable;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = siteDeparmentsObject.ModuleTypeID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ParentID", SqlDbType.Int, 4).Value = (int)siteDeparmentsObject.ParentID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@RelatedModuleTypeID", SqlDbType.Int, 4).Value = siteDeparmentsObject.RelatedModuleTypeID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@RelatedPageID", SqlDbType.Int, 4).Value = siteDeparmentsObject.RelatedPageID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@InsertUserName", SqlDbType.NVarChar, 64).Value = (string)siteDeparmentsObject.InsertUserName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@TypeID", SqlDbType.Int, 4).Value = siteDeparmentsObject.TypeID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@Url", SqlDbType.NVarChar, 128).Value = siteDeparmentsObject.Url;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = siteDeparmentsObject.OwnerID;
                myCommand.Parameters.Add("@OwnerName", SqlDbType.VarChar).Value = siteDeparmentsObject.OwnerName;
                //----------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                if (status == ExecuteCommandStatus.Done)
                {
                    siteDeparmentsObject.DepartmentID = (int)myCommand.Parameters["@DepartmentID"].Value;
                    status = SaveDetails(siteDeparmentsObject, SPOperation.Insert);
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
        /// Converts the SiteDeparments object properties to SQL paramters and executes the update SiteDeparments procedure.
        /// <example>[Example]bool  status=SiteDeparmentsSqlDataPrvider.Instance.Update(siteDeparmentsObject);.</example>
        /// </summary>
        /// <param name="siteDeparmentsObject">The SiteDeparments object.</param>
        /// <returns>The status of update query.</returns>
        public ExecuteCommandStatus Update(SiteDeparmentsEntity siteDeparmentsObject)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteDeparments_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@DepartmentID", SqlDbType.Int, 4).Value = siteDeparmentsObject.DepartmentID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@PhotoExtension", SqlDbType.VarChar, 5).Value = siteDeparmentsObject.PhotoExtension;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@IsAvailable", SqlDbType.Bit, 1).Value = siteDeparmentsObject.IsAvailable;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@RelatedModuleTypeID", SqlDbType.Int, 4).Value = siteDeparmentsObject.RelatedModuleTypeID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@RelatedPageID", SqlDbType.Int, 4).Value = siteDeparmentsObject.RelatedPageID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@LastUpdateUserName", SqlDbType.NVarChar, 64).Value = (string)siteDeparmentsObject.LastUpdateUserName;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@ParentID", SqlDbType.Int, 4).Value = (int)siteDeparmentsObject.ParentID;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@Url", SqlDbType.NVarChar, 128).Value = siteDeparmentsObject.Url;
                //----------------------------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = siteDeparmentsObject.OwnerID;
                //----------------------------------------------------------------------------------

                // Execute the command
                myConnection.Open();
                ExecuteCommandStatus status = (ExecuteCommandStatus)myCommand.ExecuteScalar();
                if (status == ExecuteCommandStatus.Done)
                {
                    status = SaveDetails(siteDeparmentsObject, SPOperation.Update);
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
        /// Deletes single SiteDeparments object .
        /// <example>[Example]bool status=SiteDeparmentsSqlDataPrvider.Instance.Delete(departmentID);.</example>
        /// </summary>
        /// <param name="departmentID">The siteDeparmentsObject id.</param>
        /// <returns>The status of delete query.</returns>
        public bool Delete(int departmentID)
        {
            bool status = false;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteDeparments_Delete", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@DepartmentID", SqlDbType.Int, 4).Value = departmentID;
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

        #region -------------GetSiteDeparmentsInDataTable---------------
        public DataTable GetSiteDeparmentsInDataTable(int moduleTypeID, int parentID, Languages langID, bool isAvailableCondition)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteDeparments_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //----------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                myCommand.Parameters.Add("@ParentID", SqlDbType.Int, 4).Value = parentID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                myCommand.Parameters.Add("@SiteHasMultiLanguages", SqlDbType.Bit).Value = SiteSettings.Languages_HasMultiLanguages;
                myCommand.Parameters.Add("@IsAvailableCondition", SqlDbType.Bit, 1).Value = isAvailableCondition;
                myCommand.Parameters.Add("@pageIndex", SqlDbType.Int, 4).Value = -1;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = -1;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                //----------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------
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
        public List<SiteDeparmentsEntity> GetAll(int moduleTypeID, int parentID, Languages langID, bool isAvailableCondition, int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<SiteDeparmentsEntity> siteDeparmentsList = new List<SiteDeparmentsEntity>();
                SiteDeparmentsEntity siteDeparmentsObject;
                //Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("SiteDeparments_GetAll", myConnection);
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
                 //----------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //siteDeparmentsObject = PopulateSiteDeparmentsEntity(dr);
                    //if (!temp.Contains(siteDeparmentsObject.DepartmentID))
                    //{
                    //    siteDeparmentsList.Add(siteDeparmentsObject);
                    //    temp.Add(siteDeparmentsObject.DepartmentID, null);
                    //}
                    siteDeparmentsObject = (SiteDeparmentsEntity)GetEntity(dr, typeof(SiteDeparmentsEntity));
                    siteDeparmentsList.Add(siteDeparmentsObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                if (totalRecords < 0) totalRecords = siteDeparmentsList.Count;
                return siteDeparmentsList;
                //----------------------------------------------------------------
            }
        }
        #endregion
        #region --------------GetFullPath--------------
        public List<SiteDeparmentsEntity> GetFullPath(int departmentID, Languages langID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<SiteDeparmentsEntity> siteDeparmentsList = new List<SiteDeparmentsEntity>();
                SiteDeparmentsEntity siteDeparmentsObject = null;
                SqlCommand myCommand = new SqlCommand("SiteDeparments_GetFullPath", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@DepartmentID", SqlDbType.Int, 4).Value = departmentID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                 //----------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //siteDeparmentsObject = PopulateSiteDeparmentsEntity(dr);
                    siteDeparmentsObject = (SiteDeparmentsEntity)GetEntity(dr, typeof(SiteDeparmentsEntity));
                    siteDeparmentsList.Add(siteDeparmentsObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                return siteDeparmentsList;
                //----------------------------------------------------------------
            }
        }
        #endregion
        #region --------------GetFullPathByRelatedModule--------------
        public List<SiteDeparmentsEntity> GetFullPathByRelatedModule(int RelatedModuleTypeID, Languages langID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<SiteDeparmentsEntity> siteDeparmentsList = new List<SiteDeparmentsEntity>();
                SiteDeparmentsEntity siteDeparmentsObject = null;
                SqlCommand myCommand = new SqlCommand("SiteDeparments_GetFullPathByRelatedModule", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@RelatedModuleTypeID", SqlDbType.Int, 4).Value = RelatedModuleTypeID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                 //----------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //siteDeparmentsObject = PopulateSiteDeparmentsEntity(dr);
                    siteDeparmentsObject = (SiteDeparmentsEntity)GetEntity(dr, typeof(SiteDeparmentsEntity));
                    siteDeparmentsList.Add(siteDeparmentsObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                return siteDeparmentsList;
                //----------------------------------------------------------------
            }
        }
        #endregion
        #region --------------GetFullPathByRelatedPageID--------------
        public List<SiteDeparmentsEntity> GetFullPathByRelatedPageID(int RelatedPageID, Languages langID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<SiteDeparmentsEntity> siteDeparmentsList = new List<SiteDeparmentsEntity>();
                SiteDeparmentsEntity siteDeparmentsObject = null;
                SqlCommand myCommand = new SqlCommand("SiteDeparments_GetFullPathByRelatedPageID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@RelatedPageID", SqlDbType.Int, 4).Value = RelatedPageID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                 //----------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    //siteDeparmentsObject = PopulateSiteDeparmentsEntity(dr);
                    siteDeparmentsObject = (SiteDeparmentsEntity)GetEntity(dr, typeof(SiteDeparmentsEntity));
                    siteDeparmentsList.Add(siteDeparmentsObject);
                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                return siteDeparmentsList;
                //----------------------------------------------------------------
            }
        }
        #endregion
        #region --------------GetSiteDeparmentsObject--------------
        public SiteDeparmentsEntity GetSiteDeparmentsObject(int departmentID, Languages langID)
        {
            SiteDeparmentsEntity siteDeparmentsObject = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteDeparments_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@DepartmentID", SqlDbType.Int, 4).Value = departmentID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                 //----------------------------------------------------------------
                myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = SitesHandler.GetOwnerIDAsGuid();
                //----------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        if (siteDeparmentsObject == null)
                        {
                            /* siteDeparmentsObject = PopulateSiteDeparmentsEntity(dr);
                             SiteDeparmentsDetailsEntity pd = PopulateSiteDeparmentsDetailsEntity(dr);
                             */
                            siteDeparmentsObject = (SiteDeparmentsEntity)GetEntity(dr, typeof(SiteDeparmentsEntity));
                            SiteDeparmentsDetailsEntity pd = (SiteDeparmentsDetailsEntity)GetEntity(dr, typeof(SiteDeparmentsDetailsEntity));
                            siteDeparmentsObject.Details[pd.LangID] = pd;
                        }
                        else
                        {
                            //SiteDeparmentsDetailsEntity pd = PopulateSiteDeparmentsDetailsEntity(dr);
                            SiteDeparmentsDetailsEntity pd = (SiteDeparmentsDetailsEntity)GetEntity(dr, typeof(SiteDeparmentsDetailsEntity));
                            siteDeparmentsObject.Details[pd.LangID] = pd;
                        }
                    }
                    dr.Close();
                }

                myConnection.Close();
                return siteDeparmentsObject;
            }
        }
        //------------------------------------------
        #endregion
        
        #region --------------SaveDetails--------------

        public ExecuteCommandStatus SaveDetails(SiteDeparmentsEntity siteDeparmentsObject, SPOperation operation)
        {
            Hashtable siteDepartmentDetailsCollection = siteDeparmentsObject.Details;
            ExecuteCommandStatus status = ExecuteCommandStatus.UnknownError;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteDeparmentsDetails_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@SPOperation", SqlDbType.Int, 4).Value = (int)operation;
                myCommand.Parameters.Add("@DepartmentID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@LangID", SqlDbType.Int);
                myCommand.Parameters.Add("@Title", SqlDbType.NVarChar, 128);
                myCommand.Parameters.Add("@ShortDescription", SqlDbType.NVarChar, 512);
                myCommand.Parameters.Add("@Description", SqlDbType.NVarChar);
                //----------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@ParentID", SqlDbType.Int, 4);
                //--------------------------------------------------------
                myCommand.Parameters.Add("@KeyWords", SqlDbType.NVarChar, 256);
                    //--------------------------------------------------------
                // Execute the command
                myConnection.Open();
                foreach (DictionaryEntry key in siteDepartmentDetailsCollection)
                {
                    SiteDeparmentsDetailsEntity itemDetails = (SiteDeparmentsDetailsEntity)key.Value;
                    myCommand.Parameters["@DepartmentID"].Value = siteDeparmentsObject.DepartmentID;
                    myCommand.Parameters["@LangID"].Value = (int)itemDetails.LangID;
                    myCommand.Parameters["@Title"].Value = itemDetails.Title;
                    myCommand.Parameters["@ShortDescription"].Value = itemDetails.ShortDescription;
                    myCommand.Parameters["@Description"].Value = itemDetails.Description;
                    //
                    myCommand.Parameters["@ModuleTypeID"].Value = (int)siteDeparmentsObject.ModuleTypeID;
                    myCommand.Parameters["@ParentID"].Value = siteDeparmentsObject.ParentID;
                    myCommand.Parameters["@KeyWords"].Value = itemDetails.KeyWords;

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