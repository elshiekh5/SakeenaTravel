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

        public FrontItemsController()
        {
        }
        public static List<FrontItemsModel> GetModuleData(int moduleID, string sqlKey)
        {
             int langID = (int)SiteSettings.GetCurrentLanguage();
             string sql = (string)SqlStatmentsManager.SqlStatments[sqlKey];
             sql = string.Format(sql, moduleID, langID);
             List<FrontItemsModel> itemsList = FrontItemsSqlDataPrvider.Instance.GetData(sql);
             return itemsList;
        }
        public static List<FrontItemsModel> GetModuleDataPageByPage(int moduleID, string sqlKey, int pageIndex, int pageSize, out int totalRecords)
        {
            int langID = (int)SiteSettings.GetCurrentLanguage();
            string sql = (string)SqlStatmentsManager.SqlStatments[sqlKey];
            sql = string.Format(sql, moduleID, langID);
            List<FrontItemsModel> itemsList = FrontItemsSqlDataPrvider.Instance.GetDataPageByPage(sql, pageIndex, pageSize, out totalRecords);
            return itemsList;
        }

        #region --------------GetObject--------------
        public static FrontItemsModel GetItemObject(int itemID, Languages langID)
        {
            FrontItemsModel itemsObject;
            HttpContext context = HttpContext.Current;
            string cacheKey = "itemsObject" + itemID;
            if (context.Items[cacheKey] == null)
            {
                itemsObject = FrontItemsSqlDataPrvider.Instance.GetItemObject(itemID, langID);
                context.Items[cacheKey] = itemsObject;
            }
            else
            {
                itemsObject = (FrontItemsModel)context.Items[cacheKey];
            }
            //return the object
            return itemsObject;
        }
        //------------------------------------------
        #endregion

    }

}