using System;
using System.Collections.Generic;

using System.Web;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for ItemsSampleProfile
    /// </summary>
    public class ItemProfile : ProfilesEntity
    {
        //------------------------------------------
        public int No
        {
            get { return Convert.ToInt32(GetPropertyValue("No")); }
            set { SetPropertyValueString("No", value.ToString()); }
        }
        //------------------------------------------
        public string Name
        {
            get { return GetPropertyValueString("Name"); }
            set { SetPropertyValueString("Name", value); }
        }
        //------------------------------------------
        public string Mobile
        {
            get { return GetPropertyValueString("Mobile"); }
            set { SetPropertyValueString("Mobile", value); }
        }
        //------------------------------------------
        public string UserName
        {
            get { return GetPropertyValueString("UserName"); }
            set { SetPropertyValueString("UserName", value); }
        }
        //------------------------------------------
        public string Password
        {
            get { return GetPropertyValueString("Password"); }
            set { SetPropertyValueString("Password", value); }
        }
        //------------------------------------------
        public string Email
        {
            get { return GetPropertyValueString("Email"); }
            set { SetPropertyValueString("Email", value); }
        }
        //------------------------------------------
        public ItemProfile()
        {
            ProfieProperities = new ProfieProperityCollection();
            ProfieProperities.Add(new ProfieProperity("No", typeof(int)));
            ProfieProperities.Add("Name");
            ProfieProperities.Add("Mobile");
            ProfieProperities.Add("UserName");
            ProfieProperities.Add("Password");
            ProfieProperities.Add("Email");
        }
    }
}