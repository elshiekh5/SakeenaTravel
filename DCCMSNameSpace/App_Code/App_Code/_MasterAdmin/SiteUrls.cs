using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DCCMSNameSpace;
namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for SiteUrls
    /// </summary>
    public class SiteUrls
    {
        //-----------------------------------------------------------------------
        public static string AdminHomePage = "/admincp/";
        public static string HomePage = "/default.aspx";
        public static string RoleErrorPage = "/RoleError.aspx";
        //-----------------------------------------------------------------------
        public static string ItemsModuleLink = "/WebSite/{0}/Default.aspx";
        //-----------------------------------------------------------------------
        public static string MessagesModuleLink = "/WebSite/{0}/Default.aspx";
        //-----------------------------------------------------------------------
        public static string UsersDataModuleLink = "/WebSite/{0}/Default.aspx";
        //-----------------------------------------------------------------------
        public static string StaticPageLink = "/WebSite/SitePages/Page.aspx?id={0}";
        //-----------------------------------------------------------------------
        public static string CreateModuleLink(int ModuleTypeID)
        {
            if (ModuleTypeID < 500)
            {
                return CreateItemsModuleLink(ModuleTypeID);
            }
            else if (ModuleTypeID < 600)
            {
                return CreateMessagesModuleLink(ModuleTypeID);

            }
            /*
            else if (ModuleTypeID < 700)
            {
                UsersDataGlobalOptions currentModule = UsersDataGlobalOptions.GetType(ModuleTypeID);
                return string.Format(ItemsModuleLink, new string[] { currentModule.Identifire });
            }*/
            else
            {
                return SiteUrls.HomePage;
            }
        }
        //---------------------------------------------------------------------------------------------
        public static string CreateItemsModuleLink(int ModuleTypeID)
        {
            if (ModuleTypeID < 500)
            {
                ItemsModulesOptions currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
                return string.Format(ItemsModuleLink, new string[] { currentModule.Identifire });
            }
            else
            {
                return SiteUrls.HomePage;
            }
        }
        //---------------------------------------------------------------------------------------------
        public static string CreateItemsModuleLink(ItemsModulesOptions currentModule)
        {
            return string.Format(ItemsModuleLink, new string[] { currentModule.Identifire });
        }
        //---------------------------------------------------------------------------------------------
        public static string CreateStaticPageLink(int PageID)
        {
            return string.Format(StaticPageLink, new string[] { PageID.ToString() });
        }
        //---------------------------------------------------------------------------------------------
        public static string CreateMessagesModuleLink(int ModuleTypeID)
        {
            if (ModuleTypeID > 500 && ModuleTypeID < 600)
            {
                MessagesModuleOptions currentModule = MessagesModuleOptions.GetType(ModuleTypeID);
                return string.Format(MessagesModuleLink, new string[] { currentModule.Identifire });
            }
            else
            {
                return SiteUrls.HomePage;
            }
        }
        //---------------------------------------------------------------------------------------------
        public static string CreateMessagesModuleLink(MessagesModuleOptions currentModule)
        {
            return string.Format(MessagesModuleLink, new string[] { currentModule.Identifire });
        }
        //---------------------------------------------------------------------------------------------
    }
}