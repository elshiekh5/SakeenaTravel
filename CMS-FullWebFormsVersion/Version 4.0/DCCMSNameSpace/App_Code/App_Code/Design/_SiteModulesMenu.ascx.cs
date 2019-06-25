using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class SiteModulesMenu : System.Web.UI.UserControl
        {
            protected void Page_Load(object sender, EventArgs e)
            {

            }
            public string BuildDynamicModulesLinks()
            {
                //------------------------------------------------------------------
                string links = "";
                string folder = "";
                string linkIdentifire = "";
                int availableItemsModulesCount = 0;
                int availableMsgsModulesCount = 0;
                int availableUsersModulesCount = 0;
                int availableStaticPagesCount = 0;
                //------------------------------------------------------------------
                string itemsModulesLinks = "";
                string msgsModulesLinks = "";
                string usersModulesLinks = "";
                string staticPagesLinks = "";
                //------------------------------------------------------------------
                SiteModulesManager siteModules = SiteModulesManager.Instance;
                if (siteModules.AllModules.Count > 0)
                {
                    itemsModulesLinks += "<tr><td class=\"menuheader expandable\">موديولات العرض</td></tr>";
                    itemsModulesLinks += "<tr><td><ul class=\"categoryitems\">";
                    itemsModulesLinks += "<li><a href=\"/\">الرئيسية</a></li>";
                    foreach (ItemsModulesOptions module in siteModules.SiteItemsModulesList)
                    {
                        if (module.IsAvailabe)
                        {
                            availableItemsModulesCount += 1;
                            folder = module.Identifire.ToString();
                            linkIdentifire = "1-" + module.ModuleTypeID + "-0-1";
                            //itemsModulesLinks += "<li><a href=\"/WebSite/" + folder + "/default.aspx\">" + module.GetModuleTitle() + "</a></li>";
                            //news/1-12-0-1/maskaznews.aspx
                            itemsModulesLinks += "<li><a href=\"/" + folder + "/" + linkIdentifire + "/" + folder + ".aspx\">" + module.GetModuleTitle() + "</a></li>";
                        }
                    }
                    itemsModulesLinks += "</ul></td></tr>";
                    //------------------------------------------------------------------
                    if (availableItemsModulesCount == 0)
                        itemsModulesLinks = "";
                    //------------------------------------------------------------------
                }

                //------------------------------------------------------------------
                //------------------------------------------------------------------
                if (siteModules.SiteMessagesModulesList.Count > 0)
                {
                    msgsModulesLinks += "<tr><td class=\"menuheader expandable\">موديولات المراسلة</td></tr>";
                    msgsModulesLinks += "<tr><td><ul class=\"categoryitems\">";
                    foreach (MessagesModuleOptions module in siteModules.SiteMessagesModulesList)
                    {
                        if (module.IsAvailabe)
                        {
                            availableMsgsModulesCount += 1;
                            folder = module.Identifire.ToString();
                            if (module.HasIsAvailable)
                                msgsModulesLinks += "<li><a href=\"/WebSite/" + folder + "/Default.aspx\">" + module.GetModuleTitle() + "</a></li>";
                            else
                                msgsModulesLinks += "<li><a href=\"/WebSite/" + folder + "/Send.aspx\">" + module.GetModuleTitle() + "</a></li>";
                        }
                    }
                    msgsModulesLinks += "</ul></td></tr>";
                    //------------------------------------------------------------------
                    if (availableMsgsModulesCount == 0)
                        msgsModulesLinks = "";
                    //------------------------------------------------------------------
                }
                //------------------------------------------------------------------
                //------------------------------------------------------------------

                if (siteModules.SiteUsersDataModulesList.Count > 0)
                {
                    usersModulesLinks += "<tr><td class=\"menuheader expandable\">موديولات التسجيل</td></tr>";
                    usersModulesLinks += "<tr><td><ul class=\"categoryitems\">";
                    foreach (UsersDataGlobalOptions module in siteModules.SiteUsersDataModulesList)
                    {
                        if (module.IsAvailabe)
                        {
                            availableUsersModulesCount += 1;
                            folder = module.Identifire.ToString();
                            usersModulesLinks += "<li><a href=\"/WebSite/UsersData/" + folder + "/ViewMembers.aspx\">" + module.GetModuleTitle() + "</a></li>";
                        }
                    }
                    usersModulesLinks += "</ul></td></tr>";
                    //------------------------------------------------------------------
                    if (availableUsersModulesCount == 0)
                        usersModulesLinks = "";
                    //------------------------------------------------------------------
                }
                //------------------------------------------------------------------
                ItemsModulesOptions SitePagesModule = ItemsModulesOptions.GetType((int)StandardItemsModuleTypes.SitePages);
                if (siteModules.SitePagesList.Count > 0)
                {
                    staticPagesLinks += "<tr><td class=\"menuheader expandable\">الصفحات الثابتة</td></tr>";
                    staticPagesLinks += "<tr><td><ul class=\"categoryitems\">";
                    foreach (SitePageOptions page in siteModules.SitePagesList)
                    {
                        if (page.IsAvailabe)
                        {
                            availableStaticPagesCount += 1;
                            staticPagesLinks += "<li><a href=\"/WebSite/SitePages/page.aspx?id=" + page.PageID + "\">" + page.Title + "</a></li>";
                        }
                    }
                    staticPagesLinks += "</ul></td></tr>";
                    //------------------------------------------------------------------
                    if (availableStaticPagesCount == 0)
                        staticPagesLinks = "";
                    //------------------------------------------------------------------
                }
                links += staticPagesLinks;
                links += itemsModulesLinks;
                links += msgsModulesLinks;
                links += usersModulesLinks;
                return links;
            }
            //----------------------------------------------------------
        }
    }
}