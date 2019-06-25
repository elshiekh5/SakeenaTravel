using System;


namespace DCCMSNameSpace
{
    public class SmsSettings
    {
        //---------------------------------------------------------
        public static string URL
        {
            get { return SiteSettings.Sms_URL; }
        }
        //---------------------------------------------------------
        public static string UserName
        {
            get { return SiteSettings.Sms_AccountUserName; }
        }
        //---------------------------------------------------------
        public static string Password
        {
            get { return SiteSettings.Sms_AccountPassword; }
        }
        //---------------------------------------------------------
        public static string Numbers
        {
            get { return SiteSettings.Sms_Numbers; }
        }
        //---------------------------------------------------------
        public static string Sender
        {
            get { return SiteSettings.Sms_Sender; }
        }
        //---------------------------------------------------------
        public static string Message
        {
            get { return SiteSettings.Sms_Message; }
        }
        //---------------------------------------------------------
    }
}