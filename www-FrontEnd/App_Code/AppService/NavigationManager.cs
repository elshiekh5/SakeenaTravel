using DCCMSNameSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace AppService
{
    /// <summary>
    /// Summary description for NavigationManager
    /// </summary>
    /// 


    public class HttpStore {

        public static IDictionary Items
        {
            get {
            return HttpContext.Current.Items;
        } }
    
    }


    public class NavigationLink {
        public string Title { get; set; }
        public string Href { get; set; }

        public bool LastTitle { get; set; }

        public NavigationLink(string title, string href, bool islast) { this.Title = title; this.Href = href; this.LastTitle = islast; }
    }
    public class NavigationManager
    {

        #region --------------Instance--------------
        private static NavigationManager _Instance;
        public static NavigationManager Instance
        {
            get
            {
                    if (!HttpStore.Items.Contains("NavigationManager") || HttpStore.Items["NavigationManager"]==null)
                    {
                        HttpStore.Items["NavigationManager"] = new NavigationManager();

                    }
                    _Instance = (NavigationManager)HttpStore.Items["NavigationManager"];
                return _Instance;
            }
        }
        //------------------------------------------
        #endregion

        public string PageTitle { get; set; }
        public string TopHeader { get; set; }

        public List<NavigationLink> Links { get; set; }
        public NavigationManager()
        {
            Links = new List<NavigationLink>();
        }

        public void AddLink(NavigationLink newLink)
        {
            Links.Add(newLink);
        }
        public void AddLink(string title, string href)
        {
            Links.Add(new NavigationLink(title, href,false));
        }
        public void AddLastTitle(string title)
        {
            Links.Add(new NavigationLink(title, null,true));
        }




        public void BuilDefaultPathesLinks()
        {
            ItemsModulesOptions currentModule = (ItemsModulesOptions)HttpStore.Items["CurrentItemsModule"];
            string homeText = (string)HttpContext.GetGlobalResourceObject("Modules", "_Home");
            string moduleTitle=currentModule.GetModuleTitle();
            this.AddLink(homeText, "/Default.aspx");
            this.AddLastTitle(moduleTitle);

            this.PageTitle = moduleTitle;
            this.TopHeader = moduleTitle;

        }

        protected void BuilMessagesDefaultPathesLinks()
        {

            MessagesModuleOptions CurrentMessagesModule = (MessagesModuleOptions)HttpStore.Items["CurrentMessagesModule"];
            string homeText = (string)HttpContext.GetGlobalResourceObject("Modules", "_Home");
            string moduleTitle = CurrentMessagesModule.GetModuleTitle();
            this.AddLink(homeText, "/Default.aspx");
            this.AddLastTitle(moduleTitle);
            this.PageTitle = moduleTitle;
            this.TopHeader = moduleTitle;
            /*
            //------------------------------------------------------
            int moduleDepartment, BaseDepartment = 0;
            //------------------------------------------------------
            int categoryID = 0;
            if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {
                categoryID = Convert.ToInt32(Request.QueryString["id"]);
            }
            //------------------------------------------------------
            PathHandler ph = new PathHandler(pc);
            ph.GetSiteDepartment(currentModule.ModuleTypeID, out moduleDepartment, out BaseDepartment);
            ph.BuildDepartmentsPathLinks(moduleDepartment, false);
            ph.BuildCategoriesPathLinks(categoryID, true);
            //------------------------------------------------------
            Label lblTitle = (Label)this.Master.FindControl("lblTitle");
            //ItemsFactory.AddTitlePath(pc, lblTitle);
            lblTitle.Text = currentModule.GetModuleTitle();
            */

        }


    }
}