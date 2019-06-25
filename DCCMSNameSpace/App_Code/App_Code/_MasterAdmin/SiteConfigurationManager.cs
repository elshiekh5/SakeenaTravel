using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Xml;

namespace DCCMSNameSpace
{
    enum SiteConfigurationItems {
   	SiteItemsModules=1,
	SiteMessagesModules=2,
	SiteUsersDataModules=3,
	SitePages=4,
    }
    class SiteConfigurationEntity
    {
        public int ConfigID { get; set; }
        public string ModulesConfiguration  { get; set; }
    }
    class SiteConfigurationManager : SqlDataProvider
    {
        #region --------------Instance--------------
        private static SiteConfigurationManager _Instance;
        public static SiteConfigurationManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SiteConfigurationManager();
                }
                return _Instance;
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
        public void Update(SiteConfigurationEntity config)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("dbo.SiteConfiguration_Update", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ConfigID", SqlDbType.SmallInt, 2).Value = config.ConfigID;
                myCommand.Parameters.Add("@ModulesConfiguration", SqlDbType.NVarChar).Value = config.ModulesConfiguration;
                //----------------------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                //return status;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Get--------------
        public SiteConfigurationEntity Get(SiteConfigurationItems configID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SiteConfigurationEntity config = new SiteConfigurationEntity();
                SqlCommand myCommand = new SqlCommand("dbo.SiteConfiguration_Get", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@ConfigID", SqlDbType.SmallInt, 2).Value = (int)configID;
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    config = (SiteConfigurationEntity)GetEntity(dr, typeof(SiteConfigurationEntity));
                }
                dr.Close();
                myConnection.Close();
                return config;
            }
        }
        #endregion

        private static XmlDocument LoadConfig(SiteConfigurationItems configType)
        {
            SiteConfigurationEntity config = Instance.Get(configType);
            XmlDocument XmlDoc = new XmlDocument();

            XmlDoc.PreserveWhitespace = true;
            XmlDoc.LoadXml(config.ModulesConfiguration);
            return XmlDoc;

        }
        public static void Update(SiteConfigurationItems configType, XmlDocument xml)
        {
            SiteConfigurationEntity config = new SiteConfigurationEntity();
            config.ConfigID = (int)configType;
            config.ModulesConfiguration = xml.InnerXml;
            Instance.Update(config);
        }

        public static XmlDocument LoadSiteItemsModulesConfig()
        {
            return LoadConfig(SiteConfigurationItems.SiteItemsModules);
        }

        

        public static XmlDocument LoadSiteMessagesModulesConfig()
        {
            return LoadConfig(SiteConfigurationItems.SiteMessagesModules);
        }

        public static XmlDocument LoadSiteUsersDataModulesConfig()
        {
            return LoadConfig(SiteConfigurationItems.SiteUsersDataModules);
        }

        public static XmlDocument LoadSitePagesConfig()
        {
            return LoadConfig(SiteConfigurationItems.SitePages);
        }

        public static void UpdateSiteItemsModules(XmlDocument xml)
        {
            Update(SiteConfigurationItems.SiteItemsModules, xml);
            HttpContext.Current.Cache.Remove("SiteItemsModulesConfig");
        }
        public static void UpdateSiteMessagesModules(XmlDocument xml)
        {
            Update(SiteConfigurationItems.SiteMessagesModules, xml);
            HttpContext.Current.Cache.Remove("SiteMessagesModulesConfig");
        }
        public static void UpdateSiteUsersDataModules(XmlDocument xml)
        {
            Update(SiteConfigurationItems.SiteUsersDataModules, xml);
            HttpContext.Current.Cache.Remove("SiteUsersDataModulesConfig");
        }
        public static void UpdateSitePages(XmlDocument xml)
        {
            Update(SiteConfigurationItems.SitePages, xml);
            HttpContext.Current.Cache.Remove("SitePagesConfig");
        }
    }
}
