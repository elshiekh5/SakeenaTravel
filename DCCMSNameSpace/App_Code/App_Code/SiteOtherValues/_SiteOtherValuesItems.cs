using System;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web;



namespace DCCMSNameSpace
{
    public enum SiteOtherValuesItems
    {
        SettingNo1 = 1//as sample
    }

    public class SiteOtherValues
    {
        private static Hashtable _AllValues = new Hashtable();
        public static Hashtable AllValues
        {
            get
            {
                return _AllValues;
            }
            // set { _AllValues = value; }
        }
        public static object GetValue(object key)
        {
            if (SiteOtherValues.AllValues.Count == 0)
                SiteOtherValuesFactory.LoadAllSettings();
            if (AllValues.Contains(key))
                return AllValues[key];
            else
                return null;
        }

    }


}