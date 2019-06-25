using System;
using System.Collections.Generic;

using System.Web;
using System.Configuration;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for DCProfileEntity
    /// </summary>
    public class ProfilesEntity
    {
        //------------------------------------------
        private string _PropertyNames = "";
        /// <summary>
        /// Gets or sets Profiles PropertyNames. 
        /// </summary>
        public string PropertyNames
        {
            get { return _PropertyNames; }
            set { _PropertyNames = value; }
        }
        //------------------------------------------
        private string _PropertyValuesString = "";
        /// <summary>
        /// Gets or sets Profiles PropertyValuesString. 
        /// </summary>
        public string PropertyValuesString
        {
            get { return _PropertyValuesString; }
            set { _PropertyValuesString = value; }
        }
        //------------------------------------------
        private DateTime _LastUpdatedDate;
        /// <summary>
        /// Gets or sets Profiles LastUpdatedDate. 
        /// </summary>
        public DateTime LastUpdatedDate
        {
            get { return _LastUpdatedDate; }
            set { _LastUpdatedDate = value; }
        }
        //------------------------------------------
        private SettingsPropertyValueCollection _PropertyValueCollection;
        public SettingsPropertyValueCollection PropertyValueCollection
        {
            get
            {
                if (_PropertyValueCollection == null)
                {
                    _PropertyValueCollection = ProfileBuilder.BuildPropertyValueCollection(ProfieProperities);
                }
                return _PropertyValueCollection;
            }
            //set { _LastUpdatedDate= value ; }
        }
        //-----------------------------------------
        private ProfieProperityCollection _ProfieProperities;
        public ProfieProperityCollection ProfieProperities
        {
            get
            {
                return _ProfieProperities;
            }
            set { _ProfieProperities = value; }
        }
        //----------------------------------------
        public object GetPropertyValue(string name)
        {
            return PropertyValueCollection[name].PropertyValue;
        }
        public string GetPropertyValueString(string name)
        {
            return (string)PropertyValueCollection[name].PropertyValue;
        }
        public void SetPropertyValueString(string name, object _value)
        {
            PropertyValueCollection[name].PropertyValue = _value;
        }
    }
}