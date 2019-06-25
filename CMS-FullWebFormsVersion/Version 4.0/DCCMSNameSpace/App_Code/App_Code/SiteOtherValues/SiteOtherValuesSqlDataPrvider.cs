using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;


namespace DCCMSNameSpace
{
    public class SiteOtherValuesSqlDataPrvider
    {

        #region --------------Instance--------------
        private static SiteOtherValuesSqlDataPrvider _Instance;
        public static SiteOtherValuesSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SiteOtherValuesSqlDataPrvider();
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
        public bool Save(SiteOtherValuesEntity siteOtherValues)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteOtherValues_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@SeetingID", SqlDbType.Int, 4).Value = (int)siteOtherValues.SeetingID;
                myCommand.Parameters.Add("@Value", SqlDbType.NVarChar).Value = siteOtherValues.Value;
                myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar).Value = siteOtherValues.Comment;
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
        public void SaveCollections(List<SiteOtherValuesEntity> siteOtherValuesList)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteOtherValues_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Parameters declaration
                myCommand.Parameters.Add("@SeetingID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@Value", SqlDbType.NVarChar);
                myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar);
                // Execute the command
                myConnection.Open();
                foreach (SiteOtherValuesEntity item in siteOtherValuesList)
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
                SqlCommand myCommand = new SqlCommand("SiteOtherValues_Save", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Parameters declaration
                myCommand.Parameters.Add("@SeetingID", SqlDbType.Int, 4);
                myCommand.Parameters.Add("@Value", SqlDbType.NVarChar);
                myCommand.Parameters.Add("@Comment", SqlDbType.NVarChar);
                // Execute the command
                myConnection.Open();
                int i = -1;
                int x = i;
                foreach (DictionaryEntry key in SiteOtherValues.AllValues)
                {
                    i = i + 1;
                    x = i;
                    //SiteOtherValuesEntity item = (SiteOtherValuesEntity)key.Value;
                    myCommand.Parameters["@SeetingID"].Value = (int)(SiteOtherValuesItems)key.Key;
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
                SiteOtherValuesEntity siteOtherValues;
                SqlCommand myCommand = new SqlCommand("SiteOtherValues_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    (siteOtherValues) = PopulateEntity(dr);
                    //old code
                    SiteOtherValues.AllValues[siteOtherValues.SeetingID] = siteOtherValues.Value;
                    // SiteOtherValues.AllValues[siteOtherValues.SeetingID] = siteOtherValues;
                }
                dr.Close();
                myConnection.Close();
            }
        }

        #endregion

        #region --------------GetObject--------------
        public SiteOtherValuesEntity GetObject(SiteOtherValuesItems seetingID)
        {
            SiteOtherValuesEntity siteOtherValues = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("SiteOtherValues_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@SeetingID", SqlDbType.Int, 4).Value = (int)seetingID;
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    if (dr.Read())
                    {
                        siteOtherValues = PopulateEntity(dr);
                    }
                    dr.Close();
                }
                myConnection.Close();
                return siteOtherValues;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------PopulateEntity--------------
        private SiteOtherValuesEntity PopulateEntity(IDataReader reader)
        {
            //Create a new SiteOtherValues object
            SiteOtherValuesEntity siteOtherValues = new SiteOtherValuesEntity();
            //Fill the object with data

            //SeetingID
            if (reader["SeetingID"] != DBNull.Value)
                siteOtherValues.SeetingID = (SiteOtherValuesItems)reader["SeetingID"];
            //Value
            if (reader["Value"] != DBNull.Value)
                siteOtherValues.Value = (string)reader["Value"];
            //Comment
            if (reader["Comment"] != DBNull.Value)
                siteOtherValues.Comment = (string)reader["Comment"];
            //Return the populated object
            return siteOtherValues;
        }
        //------------------------------------------
        #endregion


    }


}