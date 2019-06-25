using System;using DCCMSNameSpace;
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

public partial class Admin_Consulting_ServicesCategories_Create : AdminMasterPage
{

	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
    {
        UsersDataGlobalOptions CurrentUsersModule = (UsersDataGlobalOptions)HttpContext.Current.Items["CurrentUsersModule"];
        ucCreate.ModuleTypeID = CurrentUsersModule.ModuleTypeID;
        //-----------------------------------------------
        if (!IsPostBack)
        {
            if (CurrentUsersModule.HasSpecialAdminText)
            {
                this.Page.Title = CurrentUsersModule.GetModuleAdminSpecialTitle() + " - " + DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "Module_CategoriesAdd");
            }
            else
            {
                this.Page.Title = CurrentUsersModule.GetModuleAdminSpecialTitle() + " - " + Resources.Modules.Module_CategoriesAdd;
            }
        }
        //----------------------------------------------
    }
	//-----------------------------------------------
	#endregion



}

