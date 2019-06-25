using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using DCCMSNameSpace;
namespace AppService
{
    /// <summary>
    /// Summary description for SqlStatmentsManager
    /// </summary>
    public class FrontItemsController
    {

        public static List<FrontItemsModel> GetModuleData(int moduleID, string sqlKey)
        {
             int langID = (int)SiteSettings.GetCurrentLanguage();
             string sql = (string)SqlStatmentsManager.SqlStatments[sqlKey];
             sql = string.Format(sql, moduleID, langID);
             List<FrontItemsModel> itemsList = ItemsSqlDataPrvider.Instance.GetData(sql);
             return itemsList;
        }
        public FrontItemsController()
        {
        }
    }

}