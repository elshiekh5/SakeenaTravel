using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;


namespace DCCMSNameSpace
{
    public class SiteSettingsFactory
    {



        #region --------------Save--------------
        /// <summary>
        /// Updates SiteSettings object by calling SiteSettings data provider update method.
        /// <example>[Example]bool status=SiteSettingsFactory.Update(siteSettings);.</example>
        /// </summary>
        /// <param name="siteSettings">The SiteSettings object.</param>
        /// <returns>Status of update operation.</returns>
        public static bool Save(SiteSettingsEntity siteSettings)
        {
            bool status = SiteSettingsSqlDataPrvider.Instance.Save(siteSettings);
            //Reload Site Settings
            if (status) LoadAllSettings();
            //return result
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------SaveCollections--------------
        public static void SaveCollections(List<SiteSettingsEntity> siteSettingsList)
        {
            SiteSettingsSqlDataPrvider.Instance.SaveCollections(siteSettingsList);
        }
        //------------------------------------------
        #endregion

        #region --------------SaveAllSettingsCollections--------------
        public static void SaveAllSettingsCollections()
        {
            SiteSettingsSqlDataPrvider.Instance.SaveAllSettingsCollections();
            LoadAllSettings();
        }
        //------------------------------------------
        #endregion

        #region --------------LoadAllSettings--------------
        public static void LoadAllSettings()
        {

            SiteSettingsSqlDataPrvider.Instance.LoadAllSettings();
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static SiteSettingsEntity GetObject(SiteSettingItems seetingID)
        {

            SiteSettingsEntity siteSettings = SiteSettingsSqlDataPrvider.Instance.GetObject(seetingID);
            //return the object
            return siteSettings;
        }
        //------------------------------------------
        #endregion

        #region --------------IncreaseVisitors--------------
        public static void IncreaseVisitors()
        {
            SiteSettingsEntity siteSettings = new SiteSettingsEntity();
            siteSettings.SeetingID = SiteSettingItems.Site_VisitorsCount;
            siteSettings.Value = (SiteSettings.Site_VisitorsCount + 1).ToString();
            SiteSettingsSqlDataPrvider.Instance.Save(siteSettings);

        }
        //------------------------------------------
        #endregion
        #region --------------GetVisitorsCount--------------
        public static string GetVisitorsCount()
        {
            SiteSettingsEntity siteSettings = SiteSettingsSqlDataPrvider.Instance.GetObject(SiteSettingItems.Site_VisitorsCount);
            return siteSettings.Value;


        }
        //------------------------------------------
        #endregion
        /*public static Languages GetCurrentLanguages()
    {
        Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
        HttpContext context = HttpContext.Current;
        if (context.Session["LangID"] != null)
        {
            langID = (Languages)context.Session["LangID"];
        }
        return langID;
    }
    public static Languages GetCurrentLanguages()
    {
        if(SiteSettings.Languages_LanguagesCount>0)
            return SiteSettings.GetCurrentLanguage();
        else
          return  (Languages)SiteSettings.Languages_DefaultLanguageID;
    }
    */
        /*
         *#region --------------Create--------------
        /// <summary>
        /// Creates SiteSettings object by calling SiteSettings data provider create method.
        /// <example>[Example]bool status=SiteSettingsFactory.Create(siteSettings);.</example>
        /// </summary>
        /// <param name="siteSettings">The SiteSettings object.</param>
        /// <returns>Status of create operation.</returns>
        public static bool Create(SiteSettingsEntity siteSettings)
        {
            return SiteSettingsSqlDataPrvider.Instance.Create(siteSettings);
        }
        //------------------------------------------
        #endregion
        #region --------------Delete--------------
        /// <summary>
        /// Deletes single SiteSettings object .
        /// <example>[Example]bool status=SiteSettingsFactory.Delete(seetingID);.</example>
        /// </summary>
        /// <param name="seetingID">The siteSettings id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int seetingID)
        {
            bool status =SiteSettingsSqlDataPrvider.Instance.Delete(seetingID);
		
            return status;
        }
        //------------------------------------------
        #endregion
     

       #region --------------GetAll--------------
        public static List<SiteSettingsEntity> GetAll()
        {
		
            return SiteSettingsSqlDataPrvider.Instance.GetAll();
        }
        //------------------------------------------
        #endregion
     
        */
    }

}