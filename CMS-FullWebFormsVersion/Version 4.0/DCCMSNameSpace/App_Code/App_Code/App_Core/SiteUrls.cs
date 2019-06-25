using System;
using System.Collections.Generic;

using System.Web;
using System.Collections.Specialized;
using System.Collections;
using System.Xml;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for DCSiteUrls
    /// </summary>
    public class DCSiteUrls
    {
        #region -------Collections Declration-------

        //------------------------------------------
        NameValueCollection paths = null;
        //------------------------------------------
        NameValueCollection parameters = null;
        //------------------------------------------
        ArrayList unrealPaths = null;
        //------------------------------------------

        #endregion

        #region ----------Instance----------
        public static DCSiteUrls Instance
        {
            get { return new DCSiteUrls(); }
        }
        #endregion

        #region ----------Parameters----------
        public string IDParameter
        {
            get { return parameters["##ID##"]; }
        }
        //----------------------
        public string ItemIDParameter
        {
            get { return parameters["##ItemID##"]; }
        }
        //----------------------
        public string CategoryIDParameter
        {
            get { return parameters["##CategoryID##"]; }
        }
        //----------------------
        public string MessageIDParameter
        {
            get { return parameters["##MessageID##"]; }
        }
        //----------------------
        public string OwnerNameParameter
        {
            get { return parameters["##OwnerName##"]; }
        }
        //----------------------
        public string UserIDParameter
        {
            get { return parameters["##UserID##"]; }
        }
        //----------------------
        public string PageIDParameter
        {
            get { return parameters["##PageID##"]; }
        }
        //----------------------
        public string PageIndexParameter
        {
            get { return parameters["##PageIndex##"]; }
        }
        //----------------------
        public string ModuleNameParameter
        {
            get { return parameters["##ModuleName##"]; }
        }
        //----------------------
        public string ModuleIDParameter
        {
            get { return parameters["##ModuleID##"]; }
        }
        //----------------------
        public string ModuleBaseTypeParameter
        {
            get { return parameters["##ModuleBaseType##"]; }
        }
        //----------------------
        //----------------------
        #endregion
        //
        #region -----------Home---------
        public string Home
        {
            get
            {
                return "/";
            }
        }
        #endregion

        #region ----------ItemsPages-----------
        //-------------------------------------------
        public string ItemsDefault
        {
            get { return paths["ItemsDefault"]; }
        }
        //-------------------------------------------
        public string MessagesDefault
        {
            get { return paths["MessagesDefault"]; }
        }
        //-------------------------------------------
        public string ItemsDetails
        {
            get { return paths["ItemsDetails"]; }
        }
        //-------------------------------------------
        public string ItemsCategories
        {
            get { return paths["ItemsCategories"]; }
        }
        //-------------------------------------------
        public string ItemsRss
        {
            get { return paths["ItemsRss"]; }
        }
        //-------------------------------------------
        public string ItemsGalleryHtml
        {
            get { return paths["ItemsGalleryHtml"]; }
        }
        //-------------------------------------------
        private string ItemsGalleryFlash
        {
            get { return paths["ItemsGalleryFlash"]; }
        }
        //-------------------------------------------
        private string ItemsSendComment
        {
            get { return paths["ItemsSendComment"]; }
        }
        //-------------------------------------------
        public string ItemsIndexedPage
        {
            get { return paths["ItemsIndexedPage"]; }
        }
        //-------------------------------------------
        #region ---------------------
        //-------------------------------------------
        /*
        public string GetElMallCompanyHomePage(object insideDomain)
        {
            string regionID="";
            if(SiteUrlsManager.ChechIsValidIntegerParameter(SiteUrls.Instance.RegionID))
                regionID=HttpContext.Current.Request.QueryString[SiteUrls.Instance.RegionID];
             return string.Format(paths["ElMallCompanyHomePage"],insideDomain.ToString(),regionID); 
        }
        */
        #endregion
        #endregion

        #region ----------SubSiteItemsPages-----------
        //-------------------------------------------
        public string SubSiteItemsDefault
        {
            get { return paths["SubSiteItemsDefault"]; }
        }
        //-------------------------------------------
        public string SubSiteItemsDetails
        {
            get { return paths["SubSiteItemsDetails"]; }
        }
        //-------------------------------------------
        public string SubSiteItemsCategories
        {
            get { return paths["SubSiteItemsCategories"]; }
        }
        //-------------------------------------------
        public string SubSiteItemsRss
        {
            get { return paths["SubSiteItemsRss"]; }
        }
        //-------------------------------------------
        public string SubSiteItemsGalleryHtml
        {
            get { return paths["SubSiteItemsGalleryHtml"]; }
        }
        //-------------------------------------------
        private string SubSiteItemsGalleryFlash
        {
            get { return paths["SubSiteItemsGalleryFlash"]; }
        }
        //-------------------------------------------
        private string SubSiteItemsSendComment
        {
            get { return paths["SubSiteItemsSendComment"]; }
        }
        //-------------------------------------------
        #region ---------------------
        //-------------------------------------------
        /*
        public string GetElMallCompanyHomePage(object insideDomain)
        {
            string regionID="";
            if(SiteUrlsManager.ChechIsValidIntegerParameter(SiteUrls.Instance.RegionID))
                regionID=HttpContext.Current.Request.QueryString[SiteUrls.Instance.RegionID];
             return string.Format(paths["ElMallCompanyHomePage"],insideDomain.ToString(),regionID); 
        }
        */
        #endregion
        #endregion

        #region ----------Constructor----------
        //-------------------------------------
        //
        /// <summary>
        /// constractor
        /// </summary>
        public DCSiteUrls()
        {
            //-----------------------------------------------
            string siteURlsConfigFile = DCServer.MapPath("/ConfigrationFiles/SiteUrls.config");
            string cacheKey = "SiteUrls";
            string parametersCacheKey = "SiteParameters";
            string unrealPathsCacheKey = "UnRealSiteUrls";
            //-----------------------------------------------
            if (HttpRuntime.Cache[cacheKey] == null || HttpRuntime.Cache[parametersCacheKey] == null || HttpRuntime.Cache[unrealPathsCacheKey] == null)
            {
                paths = new NameValueCollection();
                parameters = new NameValueCollection();
                unrealPaths = new ArrayList();
                //
                System.Xml.XmlDocument doc = new System.Xml.XmlDocument();

                doc.PreserveWhitespace = false;
                doc.Load(siteURlsConfigFile);
                //----------------------------------------------
                //Loading site Parameters
                XmlNode siteParameters = doc.SelectSingleNode("SiteURLs/QueryStringParameters");
                foreach (XmlNode n in siteParameters.ChildNodes)
                {
                    if (n.NodeType != XmlNodeType.Comment)
                    {
                        string name = n.Attributes["name"].Value;
                        string _value = n.InnerText;
                        parameters.Add(name, _value);
                    }
                }
                //----------------------------------------------
                //Loading site Urls
                XmlNode urls = doc.SelectSingleNode("SiteURLs/Urls");
                foreach (XmlNode n in urls.ChildNodes)
                {
                    if (n.NodeType != XmlNodeType.Comment)
                    {
                        string name = n.Attributes["name"].Value;
                        string path = ResolveUrl(n.Attributes["path"].Value);
                        //Check is unreal path
                        if (n.Attributes["vanity"] != null)
                        {
                            string vanity = ResolveUrl(n.Attributes["vanity"].Value);
                            string pattern = n.Attributes["pattern"].Value;
                            unrealPaths.Add(new ReWrittenUrl(name, pattern, vanity));
                        }

                        paths.Add(name, path);
                    }
                }

                // If the file changes we want to reload it
                //we set 3 cacheDependency because only CacheDependency for one cache item
                System.Web.Caching.CacheDependency dep = new System.Web.Caching.CacheDependency(siteURlsConfigFile);
                System.Web.Caching.CacheDependency dep1 = new System.Web.Caching.CacheDependency(siteURlsConfigFile);
                System.Web.Caching.CacheDependency dep2 = new System.Web.Caching.CacheDependency(siteURlsConfigFile);
                //Cache it
                HttpRuntime.Cache.Insert(cacheKey, paths, dep, DateTime.MaxValue, TimeSpan.Zero);
                HttpRuntime.Cache.Insert(parametersCacheKey, parameters, dep1, DateTime.MaxValue, TimeSpan.Zero);
                HttpRuntime.Cache.Insert(unrealPathsCacheKey, unrealPaths, dep2, DateTime.MaxValue, TimeSpan.Zero);
            }
            paths = (NameValueCollection)HttpRuntime.Cache[cacheKey];
            parameters = (NameValueCollection)HttpRuntime.Cache[parametersCacheKey];
            unrealPaths = (ArrayList)HttpRuntime.Cache[unrealPathsCacheKey];
        }

        #endregion

        #region ----------ResolveUrl----------
        /* private string ResolveUrl(string path)
    {
		
        if (Globals.ApplicationPath.Length > 0)
            path= Globals.ApplicationPath + path;
		
		path=ResolveQueryString(path);
		return path;
    }*/
        private string ResolveUrl(string path)
        {
            path = path.Replace('^', '&');

            foreach (string key in parameters.Keys)
            {
                path = path.Replace(key, parameters[key].ToString());
            }

            return path;
        }
        #endregion

        //---------------------------------------
        public HttpContext Context
        {
            get { return HttpContext.Current; }
        }
        //---------------------------------------

        public string GetUrlByKey(string key)
        {
            if (paths[key] != null)
                return paths[key];
            else
                return "";
        }

        #region ----------ReWriteUrl----------
        public void ReWriteUrl()
        {
            HttpContext context = HttpContext.Current;
            string path = context.Request.Path;
            string queryString = context.Request.Url.Query;
            string newPath = Context.Request.RawUrl;
            foreach (ReWrittenUrl url in unrealPaths)
            {
                if (url.IsMatch(path))
                {
                    newPath = url.Convert(path, queryString);
                    break;
                }
            }
            RewriteUrl2(newPath);
        }
        void RewriteUrl2(string url)
        {
            //string url = Context.Request.RawUrl.ToLower();
            //---------------------------------------------------------
            ModuleBaseTypes ModuleBaseType = ModuleBaseTypes.Unknowen;

            int ModuleID = 0;
            int RequiredId = 0;
            //---------------------------------------------------------
            MasterModule CurrentModule=null;
            ItemsModulesOptions CurrentItemsModule;
            MessagesModuleOptions CurrentMessagesModule;
            UsersDataGlobalOptions CurrentUsersModule;
            SiteModulesManager siteModules = SiteModulesManager.Instance;
            //---------------------------------------------------------

            url = url.ToLower();
            string queryString = "";
            string SubSiteIdentifire = "";
            string moduleName = "";
            int quesMarkIndex = url.IndexOf('?');
            int queryStringLength = 0;
            int queryStringStart = 0;
            string[] QueryStringCollection = null;
            if (quesMarkIndex > -1)
            {
                if (quesMarkIndex < url.Length - 1)
                {
                    queryStringStart = quesMarkIndex + 1;
                    queryStringLength = (url.Length - 1) - quesMarkIndex;
                    queryString = url.Substring(queryStringStart, queryStringLength);
                    QueryStringCollection = queryString.Split(new char[] { '&' });
                    //---------------------------------------------------------------
                    SubSiteIdentifire = GetQueryStringValue(QueryStringCollection, OwnerNameParameter);
                    moduleName = GetQueryStringValue(QueryStringCollection, ModuleNameParameter);


                   

                    RequiredId = GetQueryStringIntegerValue(QueryStringCollection, IDParameter);
                    //---------------------------------------------------------------
                    
                    if (!string.IsNullOrEmpty(moduleName))
                    {
                        CurrentModule = SiteModulesManager.Instance.GetModule(moduleName);
                        if (CurrentModule != null)
                        {
                            ModuleBaseType = CurrentModule.ModuleBaseType;
                            ModuleID = CurrentModule.ModuleTypeID;
                            if(!string.IsNullOrEmpty(CurrentModule.ModuleSpecialPath))
                            {

                                url = url.ToLower().Replace("/website/" + CurrentModule.Identifire.ToLower() + "/", CurrentModule.ModuleSpecialPath);
                            }
                            
                            
                        }
                    }
                    //---------------------------------------------------------------
                     
                }
            }
            //---------------------------------------------------------
            
            //---------------------------------------------------------------------------------------
            OwnerInterfaceType ownerInterfaceType = OwnerInterfaceType.MasterSites;
            if (url.ToLower().IndexOf("/adminsub/") > -1)
            {
                ownerInterfaceType = OwnerInterfaceType.SubAdmin;
            }
            //--------------------------------------------------------------------
            else if (url.IndexOf("/subsite/") > -1 || !string.IsNullOrEmpty(SubSiteIdentifire))
            {
                if (!string.IsNullOrEmpty(SubSiteIdentifire))
                {
                    ownerInterfaceType = OwnerInterfaceType.SubSites;
                }
                else
                {
                    int IndexOfSiteName = -1;
                    char[] Splitter = { '/' };
                    string[] strs = url.Split(Splitter);
                    string[] newUrlSeparated = new string[strs.Length];
                    string newUrl = "";
                    for (int i = 0; i < strs.Length; i++)
                    {
                        if (strs[i] == "subsite")
                        {
                            IndexOfSiteName = i - 1;
                            //return;
                            break;
                        }

                    }
                    //----------------------------------
                    for (int i = 0; i < strs.Length; i++)
                    {
                        if (i != IndexOfSiteName && !string.IsNullOrEmpty(strs[i]))
                        {
                            newUrl += "/" + strs[i];
                        }

                    }
                    url = newUrl;
                    if (IndexOfSiteName > -1)
                    {
                        SubSiteIdentifire = strs[IndexOfSiteName];
                        ownerInterfaceType = OwnerInterfaceType.SubSites;

                    }
                    else
                    {
                        Context.Response.Redirect(SiteSettings.Site_WebsiteDomain);
                    }
                }
                //----------------------------------
            }
            Context.Items["SubSiteIdentifire"] = SubSiteIdentifire;
            Context.Items["OwnerInterfaceType"] = ownerInterfaceType;
            //---------------------------------------------------------------------------------------
            string sitePagesFolderName = SiteDesign.PagesFolderName.ToLower();
            if (ModuleID <= 0)
            {
                //--------------------------------------------------------------------
                //--------------------------------------------------------------------
                //if (url.IndexOf("/" + sitePagesFolderName + "/items/") > -1 || url.IndexOf("/admincp/items/") > -1 || url.IndexOf("/subsite/items/") > -1 || url.IndexOf("/adminsub/items/") > -1)
                if (url.IndexOf("/admincp/items/") > -1 || url.IndexOf("/adminsub/items/") > -1)
                {

                    foreach (ItemsModulesOptions item in siteModules.SiteItemsModulesList)
                    {
                        if (url.IndexOf("/" + item.Identifire.ToLower() + "/") > -1)
                        {
                            ModuleID = item.ModuleTypeID;
                            ModuleBaseType = ModuleBaseTypes.Items;
                            break;
                        }
                    }

                }
                //---------------------------------------------------------------------------------------
                //else if (url.IndexOf("/" + sitePagesFolderName + "/messages/") > -1 || url.IndexOf("/admincp/messages/") > -1 || url.IndexOf("/subsite/messages/") > -1 || url.IndexOf("/adminsub/messages/") > -1)
                else if (url.IndexOf("/admincp/messages/") > -1 || url.IndexOf("/adminsub/messages/") > -1)
                {
                    foreach (MessagesModuleOptions msgModule in siteModules.SiteMessagesModulesList)
                    {
                        if (url.IndexOf("/" + msgModule.Identifire.ToLower() + "/") > -1)
                        {
                            ModuleID = msgModule.ModuleTypeID;
                            ModuleBaseType = ModuleBaseTypes.Messages;

                            break;
                        }
                    }
                }
                //---------------------------------------------------------------------------------------
                //else if (url.IndexOf("/" + sitePagesFolderName + "/usersdata/") > -1 || url.IndexOf("/admincp/usersdata/") > -1 || url.IndexOf("/subsite/usersdata/") > -1 || url.IndexOf("/adminsub/usersdata/") > -1)
                else if (url.IndexOf("/admincp/usersdata/") > -1 ||  url.IndexOf("/adminsub/usersdata/") > -1)
                {

                    foreach (UsersDataGlobalOptions userModule in siteModules.SiteUsersDataModulesList)
                    {
                        if (url.IndexOf("/" + userModule.Identifire.ToLower() + "/") > -1)
                        {
                            ModuleID = userModule.ModuleTypeID;
                            ModuleBaseType = ModuleBaseTypes.UsersData;
                            break;
                        }
                    }
                }
            }
            //---------------------------------------------------------------------------------------
            if (ModuleID > 0)
            {
                switch (ModuleBaseType)
                {
                    case ModuleBaseTypes.Unknowen:
                        break;
                    case ModuleBaseTypes.Items:
                        #region ModuleBaseTypes.Items
                        CurrentItemsModule = ItemsModulesOptions.GetType(ModuleID);
                        Context.Items["CurrentItemsModule"] = CurrentItemsModule;
                        //---------------------------------------------------------------
                        Context.Items["RealPath"] = url;
                        //---------------------------------------------------------------
                        if (url.IndexOf("" + sitePagesFolderName + "/items/sitepages/") == -1 && url.IndexOf("/admincp/items/sitepages/") == -1 && url.IndexOf("/subsite/items/sitepages/") == -1 && url.IndexOf("/adminsub/items/sitepages/") == -1)
                        {
                            if (url.IndexOf("/admincp/") > -1)
                            {
                                if (!CurrentItemsModule.HasOwenFolder_Admin)
                                {
                                    url = url.Replace("/" + CurrentItemsModule.Identifire.ToLower() + "/", "/Default/");
                                    //Context.RewritePath("~" + url);
                                }
                            }
                            else
                            {
                                if (!CurrentItemsModule.HasOwenFolder_User)
                                {
                                    //url = url.Replace("items/" + CurrentItemsModule.Identifire.ToLower() + "/", "/Items/");
                                    url = url.Replace("/" + CurrentItemsModule.Identifire.ToLower() + "/", "/Items/");
                                    //Context.RewritePath("~" + url);
                                }
                            }
                            //---------------------------------------------------------------
                            DCMetaBuilder.InisializeItemModulesMetaTags(CurrentItemsModule);
                            //---------------------------------------------------------------
                        }
                        #endregion
                        Context.RewritePath("~" + url);
                        break;
                    case ModuleBaseTypes.Messages:
                        #region ModuleBaseTypes.Messages

                        //---------------------------------------------------------------
                        CurrentMessagesModule = MessagesModuleOptions.GetType(ModuleID);
                        Context.Items["CurrentMessagesModule"] = CurrentMessagesModule;
                        //---------------------------------------------------------------
                        Context.Items["RealPath"] = url;
                        //---------------------------------------------------------------
                        if (url.IndexOf("/admincp/") > -1)
                        {
                            if (!CurrentMessagesModule.HasOwenFolder_Admin)
                            {
                                url = url.Replace("/" + CurrentMessagesModule.Identifire.ToLower() + "/", "/Default/");
                                //Context.RewritePath("~" + url);
                            }
                        }
                        else
                        {
                            if (!CurrentMessagesModule.HasOwenFolder_User)
                            {
                                url = url.Replace("/" + CurrentMessagesModule.Identifire.ToLower() + "/", "/Messages/");
                                //Context.RewritePath("~" + url);
                            }
                        }
                        //---------------------------------------------------------------
                        DCMetaBuilder.InisializeMessageModulesMetaTags(CurrentMessagesModule);
                        //---------------------------------------------------------------
                        #endregion
                        Context.RewritePath("~" + url);

                        break;
                    case ModuleBaseTypes.UsersData:
                        #region ModuleBaseTypes.UsersData
                        CurrentUsersModule = UsersDataGlobalOptions.GetType(ModuleID);
                        //---------------------------------------------------------------
                        Context.Items["CurrentUsersModule"] = CurrentUsersModule;
                        //---------------------------------------------------------------
                        Context.Items["RealPath"] = url;
                        //---------------------------------------------------------------
                        if (url.IndexOf("/admincp/") > -1)
                        {
                            if (!CurrentUsersModule.HasOwenFolder_Admin)
                            {
                                url = url.Replace("/" + CurrentUsersModule.Identifire.ToLower() + "/", "/Default/");
                                Context.RewritePath("~" + url);
                            }
                        }
                        else
                        {
                            if (!CurrentUsersModule.HasOwenFolder_User)
                            {
                                url = url.Replace("/" + CurrentUsersModule.Identifire.ToLower() + "/", "/UserData/");
                                Context.RewritePath("~" + url);
                            }
                        }
                        //---------------------------------------------------------------
                        DCMetaBuilder.InisializeUsersDataModuleMetaTags(CurrentUsersModule);
                        //---------------------------------------------------------------
                        #endregion
                        Context.RewritePath("~" + url);
                        break;
                    case ModuleBaseTypes.Special:
                        break;
                    default:
                        break;
                }
            }
            //---------------------------------------------------------------------------------------
            else if (url.IndexOf("/subsite/") > -1)
            {
                Context.RewritePath("~" + url);
            }
            //---------------------------------------------------------------------------------------
        }
        #endregion

        #region -----------------------------GetQueryStringValue Methods-----------------------------
        //---------------------------------------------------------------------
        //GetQueryStringValue Methods
        //---------------------------------------------------------------------

        #region -----------------------------GetQueryStringValue-----------------------------
        //---------------------------------------------------------------------
        //GetQueryStringValue
        //---------------------------------------------------------------------
        private string GetQueryStringValue(string[] QueryStringCollection, string queryID)
        {
            queryID = queryID+'=';
            foreach (string parm in QueryStringCollection)
            {
                if (parm.IndexOf(queryID) ==0)
                {
                    return GetQueryStringValue(parm);
                }
            }
            return "";
        }
        //---------------------------------------------------------------------
        #endregion

        #region -----------------------------GetQueryStringIntegerValue-----------------------------
        //---------------------------------------------------------------------
        //GetQueryStringIntegerValue
        //---------------------------------------------------------------------
        private int GetQueryStringIntegerValue(string[] QueryStringCollection, string queryID)
        {
            queryID = queryID + '=';
            foreach (string parm in QueryStringCollection)
            {
                if (parm.IndexOf(queryID) ==0)
                {
                    return GetQueryStringIntegerValue(parm);
                }
            }
            return 0;
        }
        //---------------------------------------------------------------------
        #endregion

        #region -----------------------------GetQueryStringValue-----------------------------
        //---------------------------------------------------------------------
        //GetQueryStringValue
        //---------------------------------------------------------------------
        private string GetQueryStringValue(string fullQuery)
        {
            string qsValue = "";
            try
            {
                string[] strs = fullQuery.Split(new char []{'='});
                qsValue= strs[1];
            }
            catch 
            { }
            return qsValue;
        }
        //---------------------------------------------------------------------
        #endregion

        #region -----------------------------GetQueryStringIntegerValue-----------------------------
        //---------------------------------------------------------------------
        //GetQueryStringIntegerValue
        //---------------------------------------------------------------------
        private int GetQueryStringIntegerValue(string fullQuery)
        {
            int integerValue =0;
            try
            {
                string qsValue = GetQueryStringValue(fullQuery);
                if (!string.IsNullOrEmpty(qsValue))
                    integerValue = Convert.ToInt32(qsValue);
            }
            catch
            { }
            return integerValue;
        }
        //---------------------------------------------------------------------
        #endregion

        //---------------------------------------------------------------------
        #endregion
        
        

        #region -----------------------------Link Builders Methods-----------------------------
        //---------------------------------------------------------------------
        //Link Builders Methods
        //---------------------------------------------------------------------

        #region -----------------------------BuildItemsModuleLink-----------------------------
        //---------------------------------------------------------------------
        //BuildItemsModuleLink
        //---------------------------------------------------------------------
        public string BuildItemsModuleLink(ItemsModulesOptions currentModule)
        {
            
            
            string _id = "0";
            string _title = currentModule.GetModuleTitle().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(ItemsDefault, new string[] { _moduleIdentifire, _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion
        #region -----------------------------BuildItemCategoriesLink-----------------------------
        //---------------------------------------------------------------------
        //BuildItemCategoriesLink
        //---------------------------------------------------------------------
        public string BuildItemCategoriesLink(object id, object title, ItemsModulesOptions currentModule)
        {
            
            
            string _id = id.ToString();
            //string _pageType=((int)SitePagesTypes.ItemsDetails).ToString();
            string _title = title.ToString().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(ItemsCategories, new string[] { _moduleIdentifire, _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion
        #region -----------------------------BuildItemDetailsLink-----------------------------
        //---------------------------------------------------------------------
        //BuildItemDetailsLink
        //---------------------------------------------------------------------
        public string BuildItemDetailsLink(object id, object title, ItemsModulesOptions currentModule)
        {
            
            
            string _id = id.ToString();
            //string _pageType=((int)SitePagesTypes.ItemsDetails).ToString();
            string _title = title.ToString().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(ItemsDetails, new string[] { _moduleIdentifire, _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion
        #region -----------------------------BuildItemsGalleryHtmlLink-----------------------------
        //---------------------------------------------------------------------
        //BuildItemsGalleryHtmlLink
        //---------------------------------------------------------------------
        public string BuildItemsGalleryHtmlLink(object id, object title, ItemsModulesOptions currentModule)
        {
            
            
            string _id = id.ToString();
            //string _pageType=((int)SitePagesTypes.ItemsDetails).ToString();
            string _title = title.ToString().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(ItemsGalleryHtml, new string[] { _moduleIdentifire, _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion
        #region -----------------------------BuildItemsGalleryFlashLink-----------------------------
        //---------------------------------------------------------------------
        //BuildItemsGalleryFlashLink
        //---------------------------------------------------------------------
        public string BuildItemsGalleryFlashLink(object id, object title, ItemsModulesOptions currentModule)
        {
            
            
            string _id = id.ToString();
            //string _pageType=((int)SitePagesTypes.ItemsDetails).ToString();
            string _title = title.ToString().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(ItemsGalleryFlash, new string[] { _moduleIdentifire, _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion
        #region -----------------------------BuildItemsRssLink-----------------------------
        //---------------------------------------------------------------------
        //BuildItemsRssLink
        //---------------------------------------------------------------------
        public string BuildItemsRssLink(object id, object title, ItemsModulesOptions currentModule)
        {
            
            
            string _id = id.ToString();
            //string _pageType=((int)SitePagesTypes.ItemsDetails).ToString();
            string _title = title.ToString().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(ItemsRss, new string[] { _moduleIdentifire,  _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion

        //---------------------------------------------------------------------
        #endregion

        #region ----------------------------- SubSite Link Builders Methods-----------------------------
        //---------------------------------------------------------------------
        //SubSite Link Builders Methods
        //---------------------------------------------------------------------

        #region -----------------------------BuildSubSiteItemsModuleLink-----------------------------
        //---------------------------------------------------------------------
        //BuildSubSiteItemsModuleLink
        //---------------------------------------------------------------------
        public string BuildSubSiteItemsModuleLink(ItemsModulesOptions currentModule)
        {
            string ownerName = SitesHandler.GetOwnerIdentifire();
            
            
            string _id = "0";
            string _title = currentModule.GetModuleTitle().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(SubSiteItemsDefault, new string[] { ownerName, _moduleIdentifire, _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion
        #region -----------------------------BuildSubSiteItemCategoriesLink-----------------------------
        //---------------------------------------------------------------------
        //BuildSubSiteItemCategoriesLink
        //---------------------------------------------------------------------
        public string BuildSubSiteItemCategoriesLink(object id, object title, ItemsModulesOptions currentModule)
        {
            string ownerName = SitesHandler.GetOwnerIdentifire();
            
            
            string _id = id.ToString();
            //string _pageType=((int)SitePagesTypes.ItemsDetails).ToString();
            string _title = title.ToString().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(SubSiteItemsCategories, new string[] { ownerName, _moduleIdentifire, _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion
        #region -----------------------------BuildSubSiteItemDetailsLink-----------------------------
        //---------------------------------------------------------------------
        //BuildSubSiteItemDetailsLink
        //---------------------------------------------------------------------
        public string BuildSubSiteItemDetailsLink(object id, object title, ItemsModulesOptions currentModule)
        {
            string ownerName = SitesHandler.GetOwnerIdentifire();
            
            
            string _id = id.ToString();
            //string _pageType=((int)SitePagesTypes.ItemsDetails).ToString();
            string _title = title.ToString().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(SubSiteItemsDetails, new string[] { ownerName, _moduleIdentifire,  _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion
        #region -----------------------------BuildSubSiteItemsGalleryHtmlLink-----------------------------
        //---------------------------------------------------------------------
        //BuildSubSiteItemsGalleryHtmlLink
        //---------------------------------------------------------------------
        public string BuildSubSiteItemsGalleryHtmlLink(object id, object title, ItemsModulesOptions currentModule)
        {
            string ownerName = SitesHandler.GetOwnerIdentifire();
            
            
            string _id = id.ToString();
            //string _pageType=((int)SitePagesTypes.ItemsDetails).ToString();
            string _title = title.ToString().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(SubSiteItemsGalleryHtml, new string[] { ownerName, _moduleIdentifire,  _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion
        #region -----------------------------BuildSubSiteItemsGalleryFlashLink-----------------------------
        //---------------------------------------------------------------------
        //BuildSubSiteItemsGalleryFlashLink
        //---------------------------------------------------------------------
        public string BuildSubSiteItemsGalleryFlashLink(object id, object title, ItemsModulesOptions currentModule)
        {
            string ownerName = SitesHandler.GetOwnerIdentifire();
            
            
            string _id = id.ToString();
            //string _pageType=((int)SitePagesTypes.ItemsDetails).ToString();
            string _title = title.ToString().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(SubSiteItemsGalleryFlash, new string[] { ownerName, _moduleIdentifire,  _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion
        #region -----------------------------BuildSubSiteItemsRssLink-----------------------------
        //---------------------------------------------------------------------
        //BuildSubSiteItemsRssLink
        //---------------------------------------------------------------------
        public string BuildSubSiteItemsRssLink(object id, object title, ItemsModulesOptions currentModule)
        {
            string ownerName = SitesHandler.GetOwnerIdentifire();
            
            
            string _id = id.ToString();
            //string _pageType=((int)SitePagesTypes.ItemsDetails).ToString();
            string _title = title.ToString().Replace(' ', '_');
            _title = Regex.Replace(_title, @"[^\w+]", "");
            string _moduleIdentifire = currentModule.Identifire;
            //string url = string.Format(siteUrls.ItemsDetails, new string[] { _moduleIdentifire, _moduleBaseType, _ModuleTypeID, _id, _pageType, _title });
            string url = string.Format(SubSiteItemsRss, new string[] { ownerName,_moduleIdentifire,  _id, _title });
            return url;
        }
        //---------------------------------------------------------------------
        #endregion

        //---------------------------------------------------------------------
        #endregion

        //------------------------------------------------------
        private static string SiteDeparmentsDirectory = "/Content/UpFiles/{0}/SiteDeparments/";
        private static string SiteDeparmentsPhotoBigThumbs = "/Content/UpFiles/{0}/SiteDeparments/Photos/Big/";
        private static string SiteDeparmentsPhotoNormalThumbs = "/Content/UpFiles/{0}/SiteDeparments/Photos/Normal/";
        private static string SiteDeparmentsPhotoOriginals = "/Content/UpFiles/{0}/SiteDeparments/Photos/Original/";
        //------------------------------------------------------
        private static string ItemCategoriesDirectory           = "/Content/UpFiles/{0}/ItemCategories/{1}/";
        private static string ItemCategoriesFiles               = "/Content/UpFiles/{0}/ItemCategories/{1}/_Files/";
        private static string ItemCategoriesPhotoBigThumbs      = "/Content/UpFiles/{0}/ItemCategories/{1}/_Photos/Big/";
        private static string ItemCategoriesPhotoNormalThumbs   = "/Content/UpFiles/{0}/ItemCategories/{1}/_Photos/Normal/";
        private static string ItemCategoriesPhotoOriginals      = "/Content/UpFiles/{0}/ItemCategories/{1}/_Photos/Original/";
        //------------------------------------------------------
        private static string ItemsDirectory            = "/Content/UpFiles/{0}/ItemCategories/{1}/Items/{2}/";
        private static string ItemsFiles                = "/Content/UpFiles/{0}/ItemCategories/{1}/Items/{2}/Files/";
        private static string ItemsPhotoBigThumbs       = "/Content/UpFiles/{0}/ItemCategories/{1}/Items/{2}/Photos/Big/";
        private static string ItemsPhotoNormalThumbs    = "/Content/UpFiles/{0}/ItemCategories/{1}/Items/{2}/Photos/Normal/";
        private static string ItemsPhotoOriginals       = "/Content/UpFiles/{0}/ItemCategories/{1}/Items/{2}/Photos/Original/";
        //------------------------------------------------------
        private static string UserDataDirectory         = "/Content/UpFiles/{0}/ItemCategories/{1}/UsersData/{2}/";
        private static string UserDataFiles             = "/Content/UpFiles/{0}/ItemCategories/{1}/UsersData/{2}/Files/";
        private static string UserDataPhotoBigThumbs    = "/Content/UpFiles/{0}/ItemCategories/{1}/UsersData/{2}/Photos/Big/";
        private static string UserDataPhotoNormalThumbs = "/Content/UpFiles/{0}/ItemCategories/{1}/UsersData/{2}/Photos/Normal/";
        private static string UserDataPhotoOriginals    = "/Content/UpFiles/{0}/ItemCategories/{1}/UsersData/{2}/Photos/Original/";
        //-----------------------------------------------------
        private static string MessagesDirectory         = "/Content/UpFiles/{0}/ItemCategories/{1}/Messages/{2}/";
        private static string MessagesFiles             = "/Content/UpFiles/{0}/ItemCategories/{1}/Messages/{2}/Files/";
        private static string MessagesPhotoBigThumbs    = "/Content/UpFiles/{0}/ItemCategories/{1}/Messages/{2}/Photos/Big/";
        private static string MessagesPhotoNormalThumbs = "/Content/UpFiles/{0}/ItemCategories/{1}/Messages/{2}/Photos/Normal/";
        private static string MessagesPhotoOriginals    = "/Content/UpFiles/{0}/ItemCategories/{1}/Messages/{2}/Photos/Original/";
        //-----------------------------------------------------
        private static string UAdvertisments = "/Content/UpFiles/{0}/AdvertiseFiles/";
        //-----------------------------------------------------
        private static string EditorUploadedFolderPath = "/Content/UpFiles/{0}/FCK/";
        //-----------------------------------------------------
        private static string ZecurityConfigurationPath = "/ConfigrationFiles/ZecurityConfig.xml";
        //-----------------------------------------------------
        private static string MailList_AttachmentDir = "/Content/UpFiles/{0}/AttachmentDir/";
        //-----------------------------------------------------
        private static string Sms_SMSFiles = "/Content/UpFiles/{0}/SMSFiles/";
        //-----------------------------------------------------
        
        public static string GetUploadPath(string path,string siteIdentifire)
        {
            if (string.IsNullOrEmpty(siteIdentifire))
            {
                siteIdentifire = "_Site";
            }
            return string.Format(path, siteIdentifire);
        }
        //-----------------------------------------------------
        public static string GetUploadPath(string path, string siteIdentifire,int ModuleTypeID ,int CategoryID)
        {
            if (string.IsNullOrEmpty(siteIdentifire))
            {
                siteIdentifire = "_Site";
            }
            //return string.Format(path, siteIdentifire, ModuleTypeID, CategoryID);
            return string.Format(path, siteIdentifire, CategoryID);
        }
        //-----------------------------------------------------
        public static string GetUploadPath(string path, string siteIdentifire, int ModuleTypeID ,int CategoryID,int ItemID)
        {
            if (string.IsNullOrEmpty(siteIdentifire))
            {
                siteIdentifire = "_Site";
            }
            return string.Format(path, siteIdentifire, CategoryID, ItemID);
        }
        //-----------------------------------------------------
        public static string GetPath_MasterSiteUploadFolder()
        {
            return "/Content/UpFiles/_Site/";
        }
        //-----------------------------------------------------
        public static string GetPath_DefaultSubSiteFolder()
        {
            return "/Content/UpFiles/_DefaultSubSiteFolder/";
        }
        //-----------------------------------------------------
        public static string GetPath_DefaultItemFolder()
        {
            return "/Content/UpFiles/_DefaultItemFolder/";
        }
        //-----------------------------------------------------
        public static string GetPath_DefaultMessageFolder()
        {
            return "/Content/UpFiles/_DefaultMessageFolder/";
        }
        //-----------------------------------------------------
        public static string GetPath_DefaultUserDataFolder()
        {
            return "/Content/UpFiles/_DefaultUsersDataFolder/";
        }
        //-----------------------------------------------------
        public static string GetPath_DefaultCategoryFolder()
        {
            return "/Content/UpFiles/_DefaultCategoryFolder/";
        }
        //-----------------------------------------------------
        //-----------------------------------------------------
        public static string GetPath_SubSiteUploadFolder(string siteIdentifire)
        {
            return "/Content/UpFiles/" + siteIdentifire + "/";
        }
        //-----------------------------------------------------
        //-----------------------------------------------------
        public static string GetPath_ItemCategoriesDirectory(string siteIdentifire,int ModuleTypeID ,int CategoryID)
        {
            return GetUploadPath(ItemCategoriesDirectory, siteIdentifire, ModuleTypeID, CategoryID);
        }
        //-----------------------------------------------------
        public static string GetPath_ItemCategoriesFiles(string siteIdentifire, int ModuleTypeID ,int CategoryID)
        {
            return GetUploadPath(ItemCategoriesFiles, siteIdentifire, ModuleTypeID, CategoryID);
        }
        //-----------------------------------------------------
        public static string GetPath_ItemCategoriesPhotoBigThumbs(string siteIdentifire, int ModuleTypeID ,int CategoryID)
        {
            return GetUploadPath(ItemCategoriesPhotoBigThumbs, siteIdentifire, ModuleTypeID, CategoryID);
        }
        //-----------------------------------------------------
        public static string GetPath_ItemCategoriesPhotoNormalThumbs(string siteIdentifire, int ModuleTypeID ,int CategoryID)
        {
            return GetUploadPath(ItemCategoriesPhotoNormalThumbs, siteIdentifire, ModuleTypeID, CategoryID);
        }
        //-----------------------------------------------------
        public static string GetPath_ItemCategoriesPhotoOriginals(string siteIdentifire, int ModuleTypeID ,int CategoryID)
        {
            return GetUploadPath(ItemCategoriesPhotoOriginals, siteIdentifire, ModuleTypeID, CategoryID);
        }
        //-----------------------------------------------------


        public static string GetPath_SiteDeparmentsDirectory (string siteIdentifire)
        {
            return GetUploadPath(SiteDeparmentsDirectory, siteIdentifire);
        }
        //-----------------------------------------------------
        public static string GetPath_SiteDeparmentsPhotoBigThumbs (string siteIdentifire)
        {
            return GetUploadPath(SiteDeparmentsPhotoBigThumbs, siteIdentifire);
        }
        //-----------------------------------------------------
        public static string GetPath_SiteDeparmentsPhotoNormalThumbs (string siteIdentifire)
        {
            return GetUploadPath(SiteDeparmentsPhotoNormalThumbs, siteIdentifire);
        }
        //-----------------------------------------------------
        public static string GetPath_SiteDeparmentsPhotoOriginals (string siteIdentifire)
        {
            return GetUploadPath(SiteDeparmentsPhotoOriginals, siteIdentifire);
        }
        //-----------------------------------------------------

        //------------------------------------------------------
        public static string GetPath_ItemsDirectory(string siteIdentifire, int ModuleTypeID ,int CategoryID,int ItemID)
        {
            return GetUploadPath(ItemsDirectory, siteIdentifire, ModuleTypeID , CategoryID, ItemID);
        }
        //-----------------------------------------------------
        public static string GetPath_ItemsFiles(string siteIdentifire, int ModuleTypeID ,int CategoryID,int ItemID)
        {
            return GetUploadPath(ItemsFiles, siteIdentifire, ModuleTypeID , CategoryID, ItemID);
        }
        //-----------------------------------------------------
        public static string GetPath_ItemsPhotoBigThumbs(string siteIdentifire, int ModuleTypeID ,int CategoryID,int ItemID)
        {
            return GetUploadPath(ItemsPhotoBigThumbs, siteIdentifire, ModuleTypeID , CategoryID, ItemID);
        }
        //-----------------------------------------------------
        public static string GetPath_ItemsPhotoNormalThumbs(string siteIdentifire, int ModuleTypeID ,int CategoryID,int ItemID)
        {
            return GetUploadPath(ItemsPhotoNormalThumbs, siteIdentifire, ModuleTypeID , CategoryID, ItemID);
        }
        //-----------------------------------------------------
        public static string GetPath_ItemsPhotoOriginals(string siteIdentifire, int ModuleTypeID ,int CategoryID,int ItemID)
        {
            return GetUploadPath(ItemsPhotoOriginals, siteIdentifire, ModuleTypeID , CategoryID, ItemID);
        }
        //-----------------------------------------------------
        //------------------------------------------------------
        public static string GetPath_UserDataDirectory(string siteIdentifire, int ModuleTypeID ,int CategoryID,int UserProfileID)
        {
            return GetUploadPath(UserDataDirectory, siteIdentifire, ModuleTypeID , CategoryID, UserProfileID);
        }
        //-----------------------------------------------------
        public static string GetPath_UserDataFiles(string siteIdentifire, int ModuleTypeID ,int CategoryID,int UserProfileID)
        {
            return GetUploadPath(UserDataFiles, siteIdentifire, ModuleTypeID , CategoryID, UserProfileID);
        }
        //-----------------------------------------------------
        public static string GetPath_UserDataPhotoBigThumbs(string siteIdentifire, int ModuleTypeID ,int CategoryID,int UserProfileID)
        {
            return GetUploadPath(UserDataPhotoBigThumbs, siteIdentifire, ModuleTypeID , CategoryID, UserProfileID);
        }
        //-----------------------------------------------------
        public static string GetPath_UserDataPhotoNormalThumbs(string siteIdentifire, int ModuleTypeID ,int CategoryID,int UserProfileID)
        {
            return GetUploadPath(UserDataPhotoNormalThumbs, siteIdentifire, ModuleTypeID , CategoryID, UserProfileID);
        }
        //-----------------------------------------------------
        public static string GetPath_UserDataPhotoOriginals(string siteIdentifire, int ModuleTypeID ,int CategoryID,int UserProfileID)
        {
            return GetUploadPath(UserDataPhotoOriginals, siteIdentifire, ModuleTypeID , CategoryID, UserProfileID);
        }
        //-----------------------------------------------------
        //-----------------------------------------------------
        public static string GetPath_MessagesDirectory(string siteIdentifire, int ModuleTypeID ,int CategoryID,int MessageID)
        {
            return GetUploadPath(MessagesDirectory, siteIdentifire, ModuleTypeID , CategoryID, MessageID);
        }
        //-----------------------------------------------------
        public static string GetPath_MessagesFiles(string siteIdentifire, int ModuleTypeID ,int CategoryID, int MessageID)
        {
            return GetUploadPath(MessagesFiles, siteIdentifire, ModuleTypeID , CategoryID, MessageID);
        }
        //-----------------------------------------------------
        public static string GetPath_MessagesPhotoBigThumbs(string siteIdentifire, int ModuleTypeID ,int CategoryID,int MessageID)
        {
            return GetUploadPath(MessagesPhotoBigThumbs, siteIdentifire, ModuleTypeID , CategoryID, MessageID);
        }
        //-----------------------------------------------------
        public static string GetPath_MessagesPhotoNormalThumbs(string siteIdentifire, int ModuleTypeID ,int CategoryID,int MessageID)
        {
            return GetUploadPath(MessagesPhotoNormalThumbs, siteIdentifire, ModuleTypeID , CategoryID, MessageID);
        }
        //-----------------------------------------------------
        public static string GetPath_MessagesPhotoOriginals(string siteIdentifire, int ModuleTypeID ,int CategoryID,int MessageID)
        {
            return GetUploadPath(MessagesPhotoOriginals, siteIdentifire, ModuleTypeID , CategoryID, MessageID);
        }
        //-----------------------------------------------------
        //-----------------------------------------------------
        public static string GetPath_UAdvertisments  (string siteIdentifire)
        {
            return GetUploadPath(UAdvertisments, siteIdentifire);
        }
        //-----------------------------------------------------
        //-----------------------------------------------------
        public static string GetPath_EditorUploadedFolderPath(string siteIdentifire)
        {
            return GetUploadPath(EditorUploadedFolderPath, siteIdentifire);
        }
        //-----------------------------------------------------
        public static string GetPath_ZecurityConfigurationPath()
        {
            return ZecurityConfigurationPath;
        }
        //-----------------------------------------------------
        public static string GetPath_MailList_AttachmentDir()
        {
            return GetUploadPath(MailList_AttachmentDir, SitesHandler.GetOwnerIdentifire());
        }
        public static string GetPath_MailList_AttachmentDir(string siteIdentifire)
        {
            return GetUploadPath(MailList_AttachmentDir, siteIdentifire);
        }
        //-----------------------------------------------------
        public static string GetPath_Sms_SMSFiles()
        {
            return GetUploadPath(Sms_SMSFiles, SitesHandler.GetOwnerIdentifire());
        }
        public static string GetPath_Sms_SMSFiles(string siteIdentifire)
        {
            return GetUploadPath(Sms_SMSFiles, siteIdentifire);
        }
        //-----------------------------------------------------
        
    }
}