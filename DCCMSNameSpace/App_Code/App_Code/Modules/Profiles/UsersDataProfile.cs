using System;
using System.Collections.Generic;

using System.Web;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for ItemsSampleProfile
    /// </summary>
    public class UsersDataProfile : ProfilesEntity
    {
        //------------------------------------------
        public string PersonalPhoto
        {
            get { return GetPropertyValueString("PersonalPhoto"); }
            set { SetPropertyValueString("PersonalPhoto", value); }
        }
        //------------------------------------------
        public string Facebook
        {
            get { return GetPropertyValueString("Facebook"); }
            set { SetPropertyValueString("Facebook", value); }
        }
        //------------------------------------------
        public string Twitter
        {
            get { return GetPropertyValueString("Twitter"); }
            set { SetPropertyValueString("Twitter", value); }
        }
        //------------------------------------------
        public string Youtube
        {
            get { return GetPropertyValueString("Youtube"); }
            set { SetPropertyValueString("Youtube", value); }
        }
        //------------------------------------------
        public string GooglePlus
        {
            get { return GetPropertyValueString("GooglePlus"); }
            set { SetPropertyValueString("GooglePlus", value); }
        }
        //------------------------------------------
        public UsersDataProfile()
        {
            ProfieProperities = new ProfieProperityCollection();
            ProfieProperities.Add("PersonalPhoto");
            ProfieProperities.Add("Facebook");
            ProfieProperities.Add("Twitter");
            ProfieProperities.Add("Youtube");
            ProfieProperities.Add("GooglePlus");
        }
        //------------------------------------------
    }
}