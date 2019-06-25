using System;
using System.Collections.Generic;

using System.Web;
namespace DCCMSNameSpace
{
/// <summary>
/// Summary description for SubSiteHandler
/// </summary>
    public class SubSiteHandler
    {
        //----------------------------------------------------------------------------------------------------------
        public static int GetSubSitPagesCount(SubSiteTypes subeSiteType)
        {
            switch (subeSiteType)
            {
                case SubSiteTypes.None:
                    return 0;
                case SubSiteTypes.Type1:
                    return 1;
                default:
                    return 0;
            }
        }/*
        //----------------------------------------------------------------------------------------------------------
        public static string GetSubSitPagesIDsString(SubSiteTypes subeSiteType)
        {
            string PagesIDsString = "";
            List<int> subSitePagesIDs = GetSubSitPagesIDs(subeSiteType);
            foreach (int id in subSitePagesIDs)
            {
                if(!string.IsNullOrEmpty(PagesIDsString))PagesIDsString+="," ;
                PagesIDsString += id; 
            }
            return PagesIDsString;
        }*/
        //----------------------------------------------------------------------------------------------------------
        public static void AddSubSitePages(UsersDataEntity usersDataObject)
        {
            string PagesIDsString = "";
            int id = 0;
            int subSitePagesIDs = GetSubSitPagesCount(usersDataObject.SubSiteType);
            for (int i = 1; i <= subSitePagesIDs; i++)
            {
                id = AddSubSitePageDetails(i, usersDataObject);
                if (!string.IsNullOrEmpty(PagesIDsString)) PagesIDsString += ",";
                PagesIDsString += id; 
            }
            usersDataObject.SiteStaticPages = PagesIDsString;
        }
        //----------------------------------------------------------------------------------------------------------
        public static int AddSubSitePageDetails(int PageNo ,UsersDataEntity usersDataObject)
        {
            ItemsEntity page = new ItemsEntity();
            page.ModuleTypeID = (int)ModuleTypes.SubSitePages;
            page.OwnerID = usersDataObject.UserId;
            //-----------------------------------------------------
            //AddDetails
            //----------------------------
            ItemsDetailsEntity itemDetailsObject;
            if (SiteSettings.Languages_HasArabicLanguages)
            {
                itemDetailsObject = new ItemsDetailsEntity();
                itemDetailsObject.LangID = Languages.Ar;
                itemDetailsObject.Title = DynamicResource.GetText("SubSites", "Page_" + PageNo); 
                itemDetailsObject.ExtraData.Add("");
                page.Details[Languages.Ar] = itemDetailsObject;
            }
            if (SiteSettings.Languages_HasEnglishLanguages)
            {
                itemDetailsObject = new ItemsDetailsEntity();
                itemDetailsObject.LangID = Languages.En;
                itemDetailsObject.Title = DynamicResource.GetText("SubSites", "Page_" + PageNo); 
                itemDetailsObject.ExtraData.Add("");
                page.Details[Languages.En] = itemDetailsObject;
            }
            //-----------------------------------------------------
            ItemsModulesOptions subSitePagesModule = ItemsModulesOptions.GetType((int)ModuleTypes.SubSitePages);
            ItemsFactory.Create(page, subSitePagesModule);
            //-----------------------------------------------------
            return page.ItemID;
        }
        //----------------------------------------------------------------------------------------------------------
        public static void AddProfilePageDetails(UsersDataEntity usersDataObject)
        {
            ItemsEntity page = new ItemsEntity();
            page.ModuleTypeID = (int)ModuleTypes.UsersProfiles;
            page.OwnerID = usersDataObject.UserId;
            //-----------------------------------------------------
            //AddDetails
            //----------------------------
            ItemsDetailsEntity itemDetailsObject;
            if (SiteSettings.Languages_HasArabicLanguages)
            {
                itemDetailsObject = new ItemsDetailsEntity();
                itemDetailsObject.LangID = Languages.Ar;

                itemDetailsObject.Title = DynamicResource.GetText("Modules", "PageTitle_UserProfilePage");
                itemDetailsObject.ExtraData.Add("");
                page.Details[Languages.Ar] = itemDetailsObject;
            }
            if (SiteSettings.Languages_HasEnglishLanguages)
            {
                itemDetailsObject = new ItemsDetailsEntity();
                itemDetailsObject.LangID = Languages.En;
                itemDetailsObject.Title = DynamicResource.GetText("Modules", "PageTitle_UserProfilePage");
                itemDetailsObject.ExtraData.Add("");
                page.Details[Languages.En] = itemDetailsObject;
            }
            //-----------------------------------------------------
            ItemsModulesOptions UsersProfilesModule = ItemsModulesOptions.GetType((int)ModuleTypes.UsersProfiles);
            ItemsFactory.Create(page, UsersProfilesModule);
            //-----------------------------------------------------
            usersDataObject.ProfilePageID = page.ItemID;
        }
        //----------------------------------------------------------------------------------------------------------
        //----------------------------------------------------------------------------------------------------------
        public static void AddUserRelatedPages(UsersDataEntity usersDataObject)
        {
            UsersDataGlobalOptions usersModuleOptions= UsersDataGlobalOptions.GetType(usersDataObject.ModuleTypeID);
            bool HasProfilePage = usersModuleOptions.HasProfilePage;
            bool doUpdate = false;
            //*--------------------------------------------------------
            if (HasProfilePage && usersDataObject.ProfilePageID<=0)
            {
                SubSiteHandler.AddProfilePageDetails(usersDataObject);
                doUpdate = true;
            }
            //*--------------------------------------------------------
            if (UsersDataFactory.IsSubSubSiteOwner(usersDataObject.UserType) && string.IsNullOrEmpty(usersDataObject.SiteStaticPages))
            {
                SubSiteHandler.AddSubSitePages(usersDataObject);
                doUpdate = true;
            }
            //*--------------------------------------------------------
            if (doUpdate)
            {
                UsersDataFactory.Update(usersDataObject);
            }
        }
        //----------------------------------------------------------------------------------------------------------
        public static void IncreaseSubSiteVisites()
        {
            HttpContext context= HttpContext.Current;
            
           OwnerInterfaceType interfaceType =  SitesHandler.GetOwnerInterfaceType();
           if (interfaceType == OwnerInterfaceType.SubSites)
           {
               Guid OwnerID = SitesHandler.GetOwnerIDAsGuid();
               string OwnerIdentifire = SitesHandler.GetOwnerIdentifire();
               //--------------------------------------
               List<string> visitorSubSites = null;
               try
               {
                   visitorSubSites = (List<string>)context.Session["VisitorSubSites"];
               }
               catch
               { 
               }
               //--------------------------------------
               if (visitorSubSites == null)
               { 
                   visitorSubSites = new List<string>();
               }
               //--------------------------------------
               foreach (string site in visitorSubSites)
               {
                   if (OwnerIdentifire == site)
                       return;
               }
               //--------------------------------------
               UsersDataFactory.IncreaseVisits(OwnerID);
               visitorSubSites.Add(OwnerIdentifire);
               context.Session["VisitorSubSites"] = visitorSubSites;
           }
        }
        //----------------------------------------------------------------------------------------------------------
        public static void IncreaseSubSiteVisites2()
        {
                Guid OwnerID = SitesHandler.GetOwnerIDAsGuid();
                UsersDataFactory.IncreaseVisits(OwnerID);
        }
    }
}