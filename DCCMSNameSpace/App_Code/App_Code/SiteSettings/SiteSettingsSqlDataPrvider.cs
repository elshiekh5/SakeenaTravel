using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;

namespace DCCMSNameSpace
{
    public class SiteSettingsSqlDataPrvider
    {

        #region --------------Instance--------------
        private static SiteSettingsSqlDataPrvider _Instance;
        public static SiteSettingsSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SiteSettingsSqlDataPrvider();
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
        public bool Save(SiteSettingsEntity siteSettings)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteOtherValues_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@SeetingID", SqlDbType.Int, 4).Value = (int)siteSettings.SeetingID;
                myCommand.Parameters.Add("@Value", SqlDbType.NVarChar).Value = siteSettings.Value;
                myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = siteSettings.Comment;
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

        #region --------------SaveCollections--------------
        public void SaveCollections(List<SiteSettingsEntity> siteSettingsList)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteSettings_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Parameters declaration
                myCommand.Parameters.Add("@SeetingID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@Value", SqlDbType.NVarChar);
                myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar);
                // Execute the command
                myConnection.Open();
                foreach (SiteSettingsEntity item in siteSettingsList)
                {
                    myCommand.Parameters["@SeetingID"].Value = (int)item.SeetingID;
                    myCommand.Parameters["@Value"].Value = item.Value;
                    myCommand.Parameters["@Comment"].Value = item.Comment;
                    //Execute command 
                    myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
        }
        //------------------------------------------
        #endregion

        #region --------------SaveAllSettingsCollections--------------
        public void SaveAllSettingsCollections()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteSettings_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Parameters declaration
                myCommand.Parameters.Add("@SeetingID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@Value", SqlDbType.NVarChar);
                myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar);
                // Execute the command
                myConnection.Open();
                int i = -1;
                int x = i;
                foreach (DictionaryEntry key in SiteSettings.AllSiteSettings)
                {
                    i = i + 1;
                    x = i;
                    //SiteSettingsEntity item = (SiteSettingsEntity)key.Value;
                    myCommand.Parameters["@SeetingID"].Value = (int)(SiteSettingItems)key.Key;
                    myCommand.Parameters["@Value"].Value = Convert.ToString(key.Value);
                    myCommand.Parameters["@Comment"].Value = "";//item.Comment;
                    //Execute command 
                    myCommand.ExecuteNonQuery();
                }
                myConnection.Close();
            }
        }
        //------------------------------------------
        #endregion

        #region --------------LoadAllSettings--------------
        public void LoadAllSettings()
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SiteSettingsEntity siteSettings;
                SqlCommand myCommand = new SqlCommand("SiteSettings_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    (siteSettings) = PopulateEntity(dr);
                    //old code
                    SiteSettings.AllSiteSettings[siteSettings.SeetingID] = siteSettings.Value;
                    // SiteSettings.AllSiteSettings[siteSettings.SeetingID] = siteSettings;
                }
                dr.Close();
                myConnection.Close();
            }
        }

        #endregion

        #region --------------GetObject--------------
        public SiteSettingsEntity GetObject(SiteSettingItems seetingID)
        {
            SiteSettingsEntity siteSettings = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteSettings_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@SeetingID", SqlDbType.Int, 4).Value = (int)seetingID;
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        siteSettings = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return siteSettings;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateEntity--------------
        private SiteSettingsEntity PopulateEntity(IDataReader reader)
        {
            //Create a new SiteSettings object
            SiteSettingsEntity siteSettings = new SiteSettingsEntity();
            //Fill the object with data

            //SeetingID
            if (reader["SeetingID"] != DBNull.Value)
                siteSettings.SeetingID = (SiteSettingItems)reader["SeetingID"];
            //Value
            if (reader["Value"] != DBNull.Value)
                siteSettings.Value = (string)reader["Value"];
            //Comment
            if (reader["Comment"] != DBNull.Value)
                siteSettings.Comment = (string)reader["Comment"];
            //Return the populated object
            return siteSettings;
        }
        //------------------------------------------
        #endregion


    }

}