using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;


namespace DCCMSNameSpace
{
    public class SiteOtherValuesFactory
    {



        #region --------------Save--------------
        /// <summary>
        /// Updates SiteOtherValues object by calling SiteOtherValues data provider update method.
        /// <example>[Example]bool status=SiteOtherValuesFactory.Update(siteOtherValues);.</example>
        /// </summary>
        /// <param name="siteOtherValues">The SiteOtherValues object.</param>
        /// <returns>Status of update operation.</returns>
        public static bool Save(SiteOtherValuesEntity siteOtherValues)
        {
            bool status = SiteOtherValuesSqlDataPrvider.Instance.Save(siteOtherValues);
            //Reload Site Settings
            if (status) LoadAllSettings();
            //return result
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------SaveCollections--------------
        public static void SaveCollections(List<SiteOtherValuesEntity> siteOtherValuesList)
        {
            SiteOtherValuesSqlDataPrvider.Instance.SaveCollections(siteOtherValuesList);
        }
        //------------------------------------------
        #endregion

        #region --------------SaveAllSettingsCollections--------------
        public static void SaveAllSettingsCollections()
        {
            SiteOtherValuesSqlDataPrvider.Instance.SaveAllSettingsCollections();
            LoadAllSettings();
        }
        //------------------------------------------
        #endregion

        #region --------------LoadAllSettings--------------
        public static void LoadAllSettings()
        {

            SiteOtherValuesSqlDataPrvider.Instance.LoadAllSettings();
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static SiteOtherValuesEntity GetObject(SiteOtherValuesItems seetingID)
        {

            SiteOtherValuesEntity siteOtherValues = SiteOtherValuesSqlDataPrvider.Instance.GetObject(seetingID);
            //return the object
            return siteOtherValues;
        }
        //------------------------------------------
        #endregion





    }


}