using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DCCMSNameSpace;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for SiteConfiguration
    /// </summary>
    public class DynamicResource
    {
        //-------------------------------------------

        public static string GetText(object ModuleTypeObject, string resourceKey)
        {
            int moduleType = (int)ModuleTypeObject;
            return GetText(moduleType, resourceKey);
        }
        public static string GetText(int moduleType, string resourceKey)
        {
            ItemsModulesOptions itemsModule = ItemsModulesOptions.GetType(moduleType);
            return GetText(itemsModule, resourceKey);
        }
        public static string GetText(ItemsModulesOptions itemsModule, string resourceKey)
        {
            //check itemsModule has resource file or works with default resource file 
            string resourceFile = itemsModule.ResourceFile;
            if (string.IsNullOrEmpty(itemsModule.ResourceFile))
                resourceFile = itemsModule.DefaultResourceFile;
            //------------------------------------------------------------------
            //Get value of resource key
            string resourceValue = GetText(resourceFile, resourceKey);
            if (string.IsNullOrEmpty(resourceValue))//this case happen if the itemsModule has a resource file but it hasn't this resourcr key
            { resourceValue = GetText(itemsModule.DefaultResourceFile, resourceKey); }
            //------------------------------------------------------------------
            return resourceValue;

        }
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        public static string GetMessageModuleText(object MessagesModuleTypeObject, string resourceKey)
        {
            int messageModuleType = (int)MessagesModuleTypeObject;
            return GetMessageModuleText(messageModuleType, resourceKey);
        }
        public static string GetMessageModuleText(int messageModuleType, string resourceKey)
        {
            MessagesModuleOptions messageModuleOptions = MessagesModuleOptions.GetType(messageModuleType);
            return GetMessageModuleText(messageModuleOptions, resourceKey);
        }
        public static string GetMessageModuleText(MessagesModuleOptions messageModuleOptions, string resourceKey)
        {
            //check itemsModule has resource file or works with default resource file 
            string resourceFile = messageModuleOptions.ResourceFile;
            if (string.IsNullOrEmpty(messageModuleOptions.ResourceFile))
                resourceFile = messageModuleOptions.DefaultResourceFile;
            //------------------------------------------------------------------
            //Get value of resource key
            string resourceValue = GetText(resourceFile, resourceKey);
            if (string.IsNullOrEmpty(resourceValue))//this case happen if the itemsModule has a resource file but it hasn't this resourcr key
            { resourceValue = GetText(messageModuleOptions.DefaultResourceFile, resourceKey); }
            //------------------------------------------------------------------
            return resourceValue;

        }
        //    //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        public static string GetUsersDataModuleText(object UsersDataModuleTypeObject, string resourceKey)
        {
            int usersDataModuleType = (int)UsersDataModuleTypeObject;
            return GetUsersDataModuleText(usersDataModuleType, resourceKey);
        }
        public static string GetUsersDataModuleText(int usersDataModuleType, string resourceKey)
        {
            UsersDataGlobalOptions usersDataModuleOptions = UsersDataGlobalOptions.GetType(usersDataModuleType);
            return GetUsersDataModuleText(usersDataModuleOptions, resourceKey);
        }
        public static string GetUsersDataModuleText(UsersDataGlobalOptions usersDataModuleOptions, string resourceKey)
        {
            //check itemsModule has resource file or works with default resource file 
            string resourceFile = usersDataModuleOptions.ResourceFile;
            if (string.IsNullOrEmpty(usersDataModuleOptions.ResourceFile))
                resourceFile = usersDataModuleOptions.DefaultResourceFile;
            //------------------------------------------------------------------
            //Get value of resource key
            string resourceValue = GetText(resourceFile, resourceKey);
            if (string.IsNullOrEmpty(resourceValue))//this case happen if the itemsModule has a resource file but it hasn't this resourcr key
            { resourceValue = GetText(usersDataModuleOptions.DefaultResourceFile, resourceKey); }
            //------------------------------------------------------------------
            return resourceValue;

        }
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        public static string GetText(string resourceFile, string resourceKey)
        {
            return (string)HttpContext.GetGlobalResourceObject(resourceFile, resourceKey);
        }
    }
}



