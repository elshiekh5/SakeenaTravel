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
    public class FrontCategoriesController
    {

        public FrontCategoriesController()
        {
        }
        public static List<FrontCategoriesModel> GetModuleData(int moduleID, string sqlKey)
        {
             int langID = (int)SiteSettings.GetCurrentLanguage();
             string sql = (string)SqlStatmentsManager.SqlStatments[sqlKey];
             sql = string.Format(sql, moduleID, langID);
             List<FrontCategoriesModel> itemsList = FrontCategoriesSqlDataPrvider.Instance.GetData(sql);
             return itemsList;
        }
        public static List<FrontCategoriesModel> GetLatestData(int moduleID, string sqlKey,int count)
        {
            int langID = (int)SiteSettings.GetCurrentLanguage();
            string sql = (string)SqlStatmentsManager.SqlStatments[sqlKey];
            sql = string.Format(sql, moduleID, langID, count);
            List<FrontCategoriesModel> itemsList = FrontCategoriesSqlDataPrvider.Instance.GetData(sql);
            return itemsList;
        }

        public static List<FrontCategoriesModel> GetModuleDataPageByPage(int moduleID, string sqlKey, int pageIndex, int pageSize, out int totalRecords)
        {
            int langID = (int)SiteSettings.GetCurrentLanguage();
            string sql = (string)SqlStatmentsManager.SqlStatments[sqlKey];
            sql = string.Format(sql, moduleID, langID);
            List<FrontCategoriesModel> itemsList = FrontCategoriesSqlDataPrvider.Instance.GetDataPageByPage(sql, pageIndex, pageSize, out totalRecords);
            return itemsList;
        }

        #region --------------GetObject--------------
        public static FrontCategoriesModel GetItemObject(int itemID, Languages langID)
        {
            FrontCategoriesModel itemsObject;
            HttpContext context = HttpContext.Current;
            string cacheKey = "itemsObject" + itemID;
            if (context.Items[cacheKey] == null)
            {
                itemsObject = FrontCategoriesSqlDataPrvider.Instance.GetItemObject(itemID, langID);
                context.Items[cacheKey] = itemsObject;
            }
            else
            {
                itemsObject = (FrontCategoriesModel)context.Items[cacheKey];
            }
            //return the object
            return itemsObject;
        }
        //------------------------------------------
        #endregion



        public static List<FrontCategoriesModel> GetModuleCategoriesData(int moduleID, string sqlKey)
        {
            int langID = (int)SiteSettings.GetCurrentLanguage();
            string sql = (string)SqlStatmentsManager.SqlStatments[sqlKey];
            sql = string.Format(sql, moduleID, langID);
            List<FrontCategoriesModel> itemsList = FrontCategoriesSqlDataPrvider.Instance.GetData(sql);
            return itemsList;
        }


    }

}