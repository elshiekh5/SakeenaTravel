﻿using System;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web;
using DCCMSNameSpace;
using System.Web.Security;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for SitesHandler
    /// </summary>
    public class SitesHandler
    {

        //-------------------------------------------------------------
        public static UsersDataEntity GetOwnerData()
        {
            UsersDataEntity SiteOwner = null;
            HttpContext context = HttpContext.Current;
            if (context.Items["SiteOwnerData"] != null)
            {
                SiteOwner = (UsersDataEntity)context.Items["SiteOwnerData"];
            }
            else
            {
                if (context.Items["OwnerInterfaceType"] != null)
                {

                    OwnerInterfaceType ownerInterfaceType = (OwnerInterfaceType)context.Items["OwnerInterfaceType"];
                    if (ownerInterfaceType == OwnerInterfaceType.SubAdmin)
                    {
                        MembershipUser user = Membership.GetUser(context.User.Identity.Name);
                        if (user != null)
                        {
                            SiteOwner = UsersDataFactory.GetUsersDataObject((Guid)user.ProviderUserKey, Guid.Empty);
                            if (SiteOwner != null)
                            {
                                context.Items["OwnerID"] = new Guid(SiteOwner.UserId.ToString());
                                context.Items["OwnerIdentifire"] = SiteOwner.UserName;
                                context.Items["OwnerTitle"] = SiteOwner.Name;
                            }
                            else
                            {
                                context.Response.Redirect(SiteSettings.Site_WebsiteDomain);
                            }
                        }
                    }
                    else if (ownerInterfaceType == OwnerInterfaceType.SubSites)
                    {
                        string SubSiteIdentifire = (string)context.Items["SubSiteIdentifire"];
                        if (!string.IsNullOrEmpty(SubSiteIdentifire))
                        {
                            MembershipUser user = Membership.GetUser(SubSiteIdentifire);
                            if (user != null)
                            {
                                SiteOwner = UsersDataFactory.GetUsersDataObject((Guid)user.ProviderUserKey, Guid.Empty);
                                if (SiteOwner != null)
                                {
                                    context.Items["OwnerID"] = new Guid(SiteOwner.UserId.ToString());
                                    context.Items["OwnerIdentifire"] = SiteOwner.UserName;
                                    context.Items["OwnerTitle"] = SiteOwner.Name;
                                }
                            }
                            else
                            {
                                context.Response.Redirect(SiteSettings.Site_WebsiteDomain);
                            }
                        }
                    }
                }
            }
            //---------------------------------------------------------
            //
            if (SiteOwner == null)
            {
                context.Items["OwnerID"] = Guid.Empty;
                context.Items["OwnerIdentifire"] = "";
                context.Items["OwnerTitle"] = "";
            }
            //---------------------------------------------------------
            return SiteOwner;
            //---------------------------------------------------------
        }
        //-------------------------------------------------------------
        public static Guid GetOwnerIDAsGuid()
        {
            //-------------------------------------
            UsersDataEntity SiteOwner = GetOwnerData();
            HttpContext context = HttpContext.Current;
            return (Guid)context.Items["OwnerID"];
            //-------------------------------------
        }
        //-------------------------------------------------------------
        public static string GetOwnerIdentifire()
        {
            //-------------------------------------
            UsersDataEntity SiteOwner = GetOwnerData();
            HttpContext context = HttpContext.Current;
            return (string)context.Items["OwnerIdentifire"];
            //-------------------------------------
        }
        //-------------------------------------------------------------
        public static string GetOwnerTitle()
        {
            //-------------------------------------
            UsersDataEntity SiteOwner = GetOwnerData();
            HttpContext context = HttpContext.Current;
            return (string)context.Items["OwnerTitle"];
            //-------------------------------------
        }
        //-------------------------------------------------------------
        public static OwnerInterfaceType GetOwnerInterfaceType()
        {
            HttpContext context = HttpContext.Current;
            return (OwnerInterfaceType)context.Items["OwnerInterfaceType"];
        }
        //-------------------------------------------------------------

        //----------------------------------------------------------------------------------
        #region --------------SiteInterfaceType--------------
        public static SiteInterfaceTypes SiteInterfaceType
        {
            get
            {
                if (HttpContext.Current.Items["SiteInterfaceType"] == null)
                {
                    HttpContext.Current.Items["SiteInterfaceType"] = GetSiteInterfaceType();
                }
                return (SiteInterfaceTypes)HttpContext.Current.Items["SiteInterfaceType"];
            }

        }
        //------------------------------------------
        #endregion

        public static string GetSiteDomain()
        {
            switch (SiteInterfaceType)
            {
                case SiteInterfaceTypes.Website:
                    return SiteSettings.Site_WebsiteDomain;

                case SiteInterfaceTypes.MobileSite:
                    return SiteSettings.Site_MobileSiteDomain;

                default:
                    return SiteSettings.Site_WebsiteDomain;
            }


        }
        //------------------------------------------

        public static SiteInterfaceTypes GetSiteInterfaceType()
        {
            string url = HttpContext.Current.Request.Url.ToString();
            
             if
                (!string.IsNullOrEmpty(SiteSettings.Site_MobileSiteDomain) && url.Contains(SiteSettings.Site_MobileSiteDomain))
                return SiteInterfaceTypes.MobileSite;
           
            else
                return SiteInterfaceTypes.Website;
        }
    }
}