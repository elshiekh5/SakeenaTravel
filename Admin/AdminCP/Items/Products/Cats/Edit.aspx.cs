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


public partial class Admin_ItemCategories_Update : AdminMasterPage
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        ItemsModulesOptions currentModule = (ItemsModulesOptions)HttpContext.Current.Items["CurrentItemsModule"];
        ucUpdate.ModuleTypeID = currentModule.ModuleTypeID;

        if (!IsPostBack) 
        {
            if (currentModule.HasSpecialAdminText)
            {
                this.Page.Title = currentModule.GetModuleAdminSpecialTitle() + " - " + DynamicResource.GetText(currentModule, "Module_CategoriesEdit");
            }
            else
            {
                this.Page.Title = currentModule.GetModuleAdminSpecialTitle() + " - " + Resources.Modules.Module_CategoriesEdit;
            }
        }
    }
    //-----------------------------------------------
    #endregion
}

