using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for ProfileBuilder
    /// </summary>
    public class ProfileBuilder
    {
        //------------------------------------------------------------------
        //BuildPropertyValueCollection
        //------------------------------------------------------------------
        public static SettingsPropertyValueCollection BuildPropertyValueCollection(ProfieProperityCollection propCollection)
        {

            SettingsPropertyValueCollection propertyValueCollection = new SettingsPropertyValueCollection();
            SettingsProperty p;
            SettingsPropertyValue p_Value;
            foreach (ProfieProperity prop in propCollection.Properities)
            {
                //------------------------------------
                p = new SettingsProperty(prop.PropName);
                p.PropertyType = prop.PropType;
                p.DefaultValue = prop.PropDefaultValue;
                //------------------------------------------------------------
                //For retriving
                //if (p.SerializeAs == SettingsSerializeAs.ProviderSpecific)
                //{
                //    if (p.PropertyType.IsPrimitive || (p.PropertyType == typeof(string)))
                //        p.SerializeAs = SettingsSerializeAs.String;
                //    else
                //        p.SerializeAs = SettingsSerializeAs.Xml;
                //}
                //-------------------------------------------------------------
                //Value
                p_Value = new SettingsPropertyValue(p);
                //p_Value.PropertyValue = txtName.Text;
                propertyValueCollection.Add(p_Value);
                //------------------------------------
            }
            return propertyValueCollection;
        }
        //-----------------------------------------------------------------

        #region --------------PrepareDataForSaving--------------
        //------------------------------------------------------
        //PrepareDataForSaving
        //------------------------------------------------------
        internal static void PrepareDataForSaving(ref string allNames, ref string allValues, System.Configuration.SettingsPropertyValueCollection properties)
        {
            System.Text.StringBuilder stringBuilder1 = new System.Text.StringBuilder();
            System.Text.StringBuilder stringBuilder2 = new System.Text.StringBuilder();
            try
            {
                try
                {
                    foreach (System.Configuration.SettingsPropertyValue settingsPropertyValue2 in properties)
                    {
                        if (settingsPropertyValue2.IsDirty || !settingsPropertyValue2.UsingDefaultValue)
                        {
                            int i1 = 0, i2 = 0;
                            string s = null;
                            if (settingsPropertyValue2.PropertyValue == null)
                            {
                                i1 = -1;
                            }
                            else
                            {
                                object obj = settingsPropertyValue2.PropertyValue;
                                if (obj == null)
                                {
                                    i1 = -1;
                                }
                                else
                                {
                                    s = obj.ToString();
                                    i1 = s.Length;
                                    i2 = stringBuilder2.Length;

                                }
                            }
                            stringBuilder1.Append(settingsPropertyValue2.Name + ":" + (s != null ? "S" : "B") + ":" + i2.ToString() + ":" + i1.ToString() + ":");
                            if (s != null)
                            {
                                stringBuilder2.Append(s);
                            }
                        }
                    }

                }
                finally
                {

                }
            }
            catch
            {
                throw;
            }
            allNames = stringBuilder1.ToString();
            allValues = stringBuilder2.ToString();
        }
        //------------------------------------------------------
        #endregion
        internal static void ParseProfileData(string PropertyNames, string PropertyValuesString, System.Configuration.SettingsPropertyValueCollection properties)
        {
            //-------------------------------------------------------------
            string[] names = null;
            string values = null;

            char[] chArr = new char[] { ':' };
            names = PropertyNames.Split(chArr);
            values = PropertyValuesString;
            //-------------------------------------------------------------
            if ((names == null) || (values == null) || (properties == null))
                return;
            try
            {
                for (int i1 = 0; i1 < (names.Length / 4); i1++)
                {
                    string s = names[i1 * 4];
                    System.Configuration.SettingsPropertyValue settingsPropertyValue = properties[s];
                    if (settingsPropertyValue != null)
                    {
                        //int i2 = System.Int32.Parse(names[(i1 * 4) + 2], System.Globalization.CultureInfo.InvariantCulture);
                        //int i3 = System.Int32.Parse(names[(i1 * 4) + 3], System.Globalization.CultureInfo.InvariantCulture);
                        int i2 = System.Int32.Parse(names[(i1 * 4) + 2]);
                        int i3 = System.Int32.Parse(names[(i1 * 4) + 3]);
                        if ((i3 == -1) && !settingsPropertyValue.Property.PropertyType.IsValueType)
                        {
                            settingsPropertyValue.PropertyValue = null;
                            settingsPropertyValue.IsDirty = false;
                            //settingsPropertyValue.Deserialized = false;
                        }
                        //if (names[(i1 * 4) + 1] == "S\uFFFD" && (i2 >= 0) && (i3 > 0) && (values.Length >= (i2 + i3)))
                        if (names[(i1 * 4) + 1] == "S" && (i2 >= 0) && (i3 > 0) && (values.Length >= (i2 + i3)))
                            settingsPropertyValue.PropertyValue = values.Substring(i2, i3);
                        //if (names[(i1 * 4) + 1] == "B\uFFFD" && (i2 >= 0) && (i3 > 0) && (buf.Length >= (i2 + i3)))

                    }
                }
            }
            catch
            {
            }
        }
        
 
    }
}