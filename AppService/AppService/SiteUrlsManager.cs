using DCCMSNameSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace AppService
{
    //------------------------------------------
    public class SiteUrlsManager
    {
        static string ModulePage_Default = "/{0}/all/{1}/";
        static string ModulePage_Details = "/{0}/page/{1}/";
        public static string GetDefaultPageLink(MasterModule currentModule)
        {
            return GetDefaultPageLink(currentModule.Identifire, "{0}");
        
        }
        public static string identifire(MasterModule currentModule, int pageIndex)
        {
            return GetDefaultPageLink(currentModule.Identifire, pageIndex.ToString());

        }
        public static string GetDefaultPageLink(string identifire, string pageIndex)
        {
            return string.Format(ModulePage_Default, identifire, pageIndex.ToString());

        }
        public static string GetSinglesPageLink(MasterModule currentModule)
        {
            return GetSinglesPageLink(currentModule.Identifire, "{0}");
        }
        public static string GetSinglesPageLink(MasterModule currentModule, int id)
        {
            return GetSinglesPageLink(currentModule.Identifire, id.ToString());
        }
        public static string GetSinglesPageLink(string identifire, string id)
        {
            return string.Format(ModulePage_Details, identifire, id.ToString());
        }
    }
}