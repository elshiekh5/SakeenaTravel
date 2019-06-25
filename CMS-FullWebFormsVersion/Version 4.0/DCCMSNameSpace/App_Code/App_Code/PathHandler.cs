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
using System.Collections.Generic;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for PathHandler
    /// </summary>
    public class PathHandler
    {
        private PathLinksClass _PathControl;
        public PathLinksClass PathControl { get { return _PathControl; } set { _PathControl = value; } }

        #region --------------PathHandler--------------
        //---------------------------------------------------------
        //PathHandler
        //---------------------------------------------------------
        public PathHandler(PathLinksClass pc)
        {
            _PathControl = pc;
        }
        #endregion

        #region --------------GetSiteDepartment--------------
        //---------------------------------------------------------
        //GetSiteDepartment
        //---------------------------------------------------------
        public void GetSiteDepartment(int moduleTypeID, out int moduleDepartment, out int BaseDepartment)
        {
            moduleDepartment = 0;
            BaseDepartment = 0;
        }
        #endregion

        #region --------------BuildDepartmentsPathLinks--------------
        //---------------------------------------------------------
        //BuildDepartmentsPathLinks
        //---------------------------------------------------------
        public bool BuildDepartmentsPathLinks(int moduleDepartment, bool lastLink)
        {
            return BuildDepartmentsPathLinks(moduleDepartment, lastLink, true);
        
        }
        //---------------------------------------------------------
        //BuildDepartmentsPathLinks
        //---------------------------------------------------------
        public bool BuildDepartmentsPathLinks(int moduleDepartment, bool lastLink,bool setTags)
        {
            bool hasLinks = false;
            if (moduleDepartment > 0)
            {
                List<SiteDeparmentsEntity> sdp = SiteDeparmentsFactory.GetFullPath(moduleDepartment);
                if (sdp.Count > 0)
                {
                    hasLinks = true;
                    SiteDeparmentsEntity lastDep = null;
                    SiteDeparmentsEntity tempdep = null;
                    string url = "";
                    for (int i = 0; i < sdp.Count; i++)
                    {
                        tempdep = sdp[i];
                        if (lastLink && i == sdp.Count - 1)
                        {
                            lastDep = tempdep;
                            _PathControl.AddLink(tempdep.Title, null);
                             if (setTags)
                            {
                                DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
                                metaBuilder.Section = tempdep.Title;
                                metaBuilder.Title = tempdep.Title;
                            }
                        }
                        else
                        {
                            url = GetSiteDepartmentsURl(tempdep.Url, tempdep.RelatedModuleTypeID, tempdep.RelatedPageID, tempdep.DepartmentID);
                            _PathControl.AddLink(tempdep.Title, url);
                        }
                    }
                }

            }
            return hasLinks;
        }
        #endregion

        #region --------------BuildDepartmentsPathLinksByRelatedModuleID--------------
        //---------------------------------------------------------
        //BuildDepartmentsPathLinksByRelatedModuleID
        //---------------------------------------------------------
        public bool BuildDepartmentsPathLinksByRelatedModuleID(int RelatedModuleID, bool lastLink)
        {
            return BuildDepartmentsPathLinksByRelatedModuleID(RelatedModuleID, lastLink, true);
        }
        //--------------------------------------------
        //---------------------------------------------------------
        //BuildDepartmentsPathLinksByRelatedModuleID
        //---------------------------------------------------------
        public bool BuildDepartmentsPathLinksByRelatedModuleID(int RelatedModuleID, bool lastLink, bool setTags)
        {
            bool hasLinks = false;
            if (RelatedModuleID > 0)
            {
                List<SiteDeparmentsEntity> sdp = SiteDeparmentsFactory.GetFullPathByRelatedModule(RelatedModuleID);
                if (sdp.Count > 0)
                {
                    hasLinks = true;
                    SiteDeparmentsEntity lastDep = null;
                    SiteDeparmentsEntity tempdep = null;
                    string url = "";
                    for (int i = 0; i < sdp.Count; i++)
                    {

                        tempdep = sdp[i];
                        if (lastLink && i == sdp.Count - 1)
                        {
                            lastDep = tempdep;
                            _PathControl.AddLink(tempdep.Title, null);
                            if (setTags)
                            {
                                DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
                                metaBuilder.Section = tempdep.Title;
                                metaBuilder.Title = tempdep.Title;
                            }
                        }
                        else
                        {
                            url = url = GetSiteDepartmentsURl(tempdep.Url, tempdep.RelatedModuleTypeID, tempdep.RelatedPageID, tempdep.DepartmentID);
                            _PathControl.AddLink(tempdep.Title, url);
                        }
                    }
                }
            }
            return hasLinks;
        }
        #endregion

        #region --------------BuildDepartmentsPathLinksByRelatedPageID--------------
        //---------------------------------------------------------
        //BuildDepartmentsPathLinksByRelatedPageID
        //---------------------------------------------------------
        public bool BuildDepartmentsPathLinksByRelatedPageID(int RelatedPageID, bool lastLink)
        {
            return BuildDepartmentsPathLinksByRelatedPageID(RelatedPageID, lastLink, true);
        
        }
        //---------------------------------------------------------
        //BuildDepartmentsPathLinksByRelatedPageID
        //---------------------------------------------------------
        public bool BuildDepartmentsPathLinksByRelatedPageID(int RelatedPageID, bool lastLink, bool setTags)
        {
            bool hasLinks = false;
            if (RelatedPageID > 0)
            {
                List<SiteDeparmentsEntity> sdp = SiteDeparmentsFactory.GetFullPathByRelatedPageID(RelatedPageID);
                if (sdp.Count > 0)
                {
                    hasLinks = true;
                    SiteDeparmentsEntity lastDep = null;
                    SiteDeparmentsEntity tempdep = null;
                    string url = "";
                    for (int i = 0; i < sdp.Count; i++)
                    {

                        tempdep = sdp[i];
                        if (lastLink && i == sdp.Count - 1)
                        {
                            lastDep = tempdep;
                            _PathControl.AddLink(tempdep.Title, null);
                            if (setTags)
                            {
                                DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
                                metaBuilder.Section = tempdep.Title;
                                metaBuilder.Title = tempdep.Title;
                            }
                        }
                        else
                        {
                            url = url = GetSiteDepartmentsURl(tempdep.Url, tempdep.RelatedModuleTypeID, tempdep.RelatedPageID, tempdep.DepartmentID);
                            _PathControl.AddLink(tempdep.Title, url);
                        }
                    }
                }
            }
            return hasLinks;
        }
        #endregion

        #region --------------BuildCategoriesPathLinks--------------
        //---------------------------------------------------------
        //BuildCategoriesPathLinks
        //---------------------------------------------------------
        public bool BuildCategoriesPathLinks(int categoryID, bool lastLink)
        {
        return BuildCategoriesPathLinks( categoryID,  lastLink,true);
        }
        //---------------------------------------------------------
        //BuildCategoriesPathLinks
        //---------------------------------------------------------
        public bool BuildCategoriesPathLinks(int categoryID, bool lastLink,bool setTags)
        {
            bool hasLinks = false;
            if (categoryID > 0)
            {
                List<ItemCategoriesEntity> cdp = ItemCategoriesFactory.GetFullPath(categoryID);
                if (cdp.Count > 0)
                {
                    hasLinks = true;
                    ItemCategoriesEntity lastCat = null;
                    ItemsModulesOptions currentModule = ItemsModulesOptions.GetType(cdp[0].ModuleTypeID);
                    string url = "";
                    for (int i = 0; i < cdp.Count; i++)
                    {
                        if (lastLink && i == cdp.Count - 1)
                        {
                            lastCat = cdp[i];
                            _PathControl.AddLink(lastCat.Title, null);
                            if (setTags)
                            {
                                DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
                                metaBuilder.SubSection = lastCat.Title;
                                metaBuilder.Title = lastCat.Title;
                            }
                        }
                        else
                        {
                            //url = "default.aspx?id=" + cdp[i].CategoryID;
                           url= DCSiteUrls.Instance.BuildItemCategoriesLink(cdp[i].CategoryID, cdp[i].Title, currentModule);
                            _PathControl.AddLink(cdp[i].Title, url);
                        }
                    }
                }
            }
            return hasLinks;
        }
        //---------------------------------------------------------
        #endregion

        #region --------------BuildCategoriesPathLinksInSubFolder--------------
        //---------------------------------------------------------
        //BuildCategoriesPathLinksInSubFolder
        //---------------------------------------------------------
        public bool BuildCategoriesPathLinksInSubFolder(int categoryID, bool lastLink)
        {
        return BuildCategoriesPathLinksInSubFolder( categoryID,  lastLink, true);
        }
        //---------------------------------------------------------
        //BuildCategoriesPathLinksInSubFolder
        //---------------------------------------------------------
        public bool BuildCategoriesPathLinksInSubFolder(int categoryID, bool lastLink, bool setTags)
        {
            bool hasLinks = false;
            if (categoryID > 0)
            {
                List<ItemCategoriesEntity> cdp = ItemCategoriesFactory.GetFullPath(categoryID);
                if (cdp.Count > 0)
                {
                    hasLinks = true;
                    ItemCategoriesEntity lastCat = null;
                    ItemsModulesOptions currentModule = ItemsModulesOptions.GetType(cdp[0].ModuleTypeID);
                    string url = "";
                    for (int i = 0; i < cdp.Count; i++)
                    {
                        if (lastLink && i == cdp.Count - 1)
                        {
                            lastCat = cdp[i];
                            _PathControl.AddLink(lastCat.Title, null);
                             if (setTags)
                            {
                                DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
                                metaBuilder.SubSection = lastCat.Title;
                                metaBuilder.Title = lastCat.Title;
                            }
                        }
                        else
                        {
                            //url = "../default.aspx?id=" + cdp[i].CategoryID;
                            DCSiteUrls.Instance.BuildItemCategoriesLink(cdp[i].CategoryID, cdp[i].Title, currentModule);
                            _PathControl.AddLink(cdp[i].Title, url);
                        }
                    }
                }
            }
            return hasLinks;
        }
        #endregion

        #region --------------GetSiteDepartmentsURl--------------
        //---------------------------------------------------------
        //GetSiteDepartmentsURl
        //---------------------------------------------------------
        public string GetSiteDepartmentsURl(string Url, int RelatedModuleTypeID, int RelatedPageID, int DepartmentID)
        {
            if (!string.IsNullOrEmpty(Url))
            {
                return Url;
            }
            else if (RelatedPageID > 0)
            {
                return SiteUrls.CreateStaticPageLink(RelatedPageID);
            }
            else if (RelatedModuleTypeID > 0)
            {
                return SiteUrls.CreateModuleLink(RelatedModuleTypeID);
            }
            else
            {
                return "/Website/SiteDepartments/default.aspx?id=" + DepartmentID.ToString();
            }


        }
        #endregion
        
        #region --------------SetForSubMenu--------------
        //---------------------------------------------------------
        //SetForSubMenu
        //---------------------------------------------------------
        public void SetForSubMenu(int BaseDepartment)
        {
            HttpContext context = HttpContext.Current;
            if (context.Request.RawUrl.ToLower().IndexOf("default.aspx") > -1)
                context.Items["SubMenu_ParentID"] = BaseDepartment;

        }
        #endregion

    }
}