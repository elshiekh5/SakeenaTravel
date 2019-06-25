using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;
using DCCMSNameSpace;

public partial class AdminItems_SitePages_InActiveComments : AdminMasterPage
{

	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
        ItemsModulesOptions currentModule = (ItemsModulesOptions)HttpContext.Current.Items["CurrentItemsModule"];
        ucComments.ModuleTypeID = currentModule.ModuleTypeID;
        if (!IsPostBack)
        {
            if (currentModule.ModuleTypeID != (int)ModuleTypes.StaticPages && currentModule.ModuleTypeID != (int)ModuleTypes.StaticContents)
            {
                this.Page.Title = currentModule.GetModuleAdminSpecialTitle() + " - " + Resources.Modules.Module_CommentsInactive;
            }
            else if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {
                int pageid = Convert.ToInt32(Request.QueryString["id"]);
                SitePageOptions page = SitePageOptions.GetPage(pageid);
                this.Page.Title = page.Title + " - " + Resources.Modules.Module_CommentsInactive;

            }
            else
            {
                this.Page.Title = Resources.Modules.Module_CommentsInactive;

            }
        }
	}
	//-----------------------------------------------
	#endregion

}

