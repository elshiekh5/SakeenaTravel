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
using DCCMSNameSpace;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for DynamicInnerMasterPage
    /// </summary>
    /// 
    //-----------------------------------------------------------------------
    public class AdminMasterPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.Page.MasterPageFile = "~/Content/AdminDesign/admin.master";
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            Languages langID = SiteSettings.GetCurrentLanguage();
            this.Page.Theme = "AdminSite." + langID.ToString();

            base.OnPreInit(e);
        }
    }
    //-----------------------------------------------------------------------
    public class MasterAdminMasterPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.Page.MasterPageFile = "~/AdminMaster/MasterAdmin.master";
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            Languages langID = SiteSettings.GetCurrentLanguage();
            this.Page.Theme = "AdminSite." + langID.ToString();
            base.OnPreInit(e);
        }
    }
    //-----------------------------------------------------------------------
    public class SubAdminMasterPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.Page.MasterPageFile = "~/Design/SubAdmin/SubAdmin.master";
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            Languages langID = SiteSettings.GetCurrentLanguage();
            this.Page.Theme = "AdminSite." + langID.ToString();
            base.OnPreInit(e);
        }
    }
    //-----------------------------------------------------------------------
    public class DynamicInnerMasterPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            OwnerInterfaceType interFaceType = SitesHandler.GetOwnerInterfaceType();
            if (interFaceType == OwnerInterfaceType.SubSites )
            {
                this.Page.MasterPageFile = "~" + SiteDesign.MastersFolder + "SubSite.master";
            }
            else
            {
                this.Page.MasterPageFile = "~" + SiteDesign.MastersFolder + "Inner.master";
            }
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            this.EnableViewState = false;
            base.OnPreInit(e);
        }
        protected void BuilDefaultPathesLinks()
        {
            /*
            ItemsModulesOptions currentModule = (ItemsModulesOptions)HttpContext.Current.Items["CurrentItemsModule"];


            string homeText=(string)HttpContext.GetGlobalResourceObject("Modules", "_Home");
                PathLinksClass pc = (PathLinksClass)this.Master.FindControl("Pathes");
                pc.AddLink(homeText, "/Default.aspx");
                pc.AddLink(currentModule.GetModuleTitle(), null);         
             * */
        }

        protected void BuilMessagesDefaultPathesLinks()
        {
            /*
            MessagesModuleOptions CurrentMessagesModule = (MessagesModuleOptions)HttpContext.Current.Items["CurrentMessagesModule"];
            string homeText = (string)HttpContext.GetGlobalResourceObject("Modules", "_Home");
            PathLinksClass pc = (PathLinksClass)this.Master.FindControl("Pathes");
            pc.AddLink(homeText, "/Default.aspx");
            pc.AddLink(CurrentMessagesModule.GetModuleTitle(), null);
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
    //-----------------------------------------------------------------------
    public class DynamicDefaultMasterPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.Page.MasterPageFile = "~" + SiteDesign.MastersFolder + "Main.master";
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            base.OnPreInit(e);
        }
    }
    //-----------------------------------------------------------------------

    public class DynamicPopupMasterPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.Page.MasterPageFile = "~" + SiteDesign.MastersFolder + "Popup.master";
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            base.OnPreInit(e);
        }
    }
    //-----------------------------------------------------------------------
    public class DynamicSubSiteMasterPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.Page.MasterPageFile = "~" + SiteDesign.MastersFolder + "SubSite.master";
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            base.OnPreInit(e);
        }
    }
    //-----------------------------------------------------------------------
    //-----------------------------------------------------------------------
    public class DynamicGoogleSearchMasterPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            OwnerInterfaceType interFaceType = SitesHandler.GetOwnerInterfaceType();
            if (interFaceType == OwnerInterfaceType.SubSites )
            {
                this.Page.MasterPageFile = "~" + SiteDesign.MastersFolder + "GoogleSearch.master";
            }
            else
            {
                this.Page.MasterPageFile = "~" + SiteDesign.MastersFolder + "GoogleSearch.master";
            }
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            base.OnPreInit(e);
        }
    }
    public class DynamicUserMasterPage : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            this.Page.MasterPageFile = "~" + SiteDesign.MastersFolder + "User.master";
            //this.SmartNavigation = true;
            this.MaintainScrollPositionOnPostBack = true;
            base.OnPreInit(e);
        }
    }
    //-----------------------------------------------------------------------
}
