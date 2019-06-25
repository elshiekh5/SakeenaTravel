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

public partial class AdminMessagesConsultingServices_GetAll : AdminMasterPage
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        //-----------------------------------------------
        ItemsModulesOptions currentModule = (ItemsModulesOptions)HttpContext.Current.Items["CurrentItemsModule"];
        MessagesModuleOptions CurrentMessagesModule = MessagesModuleOptions.GetType(currentModule.MessagesModuleID);
        //-----------------------------------------------
        int itemID = -1;
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            itemID = Convert.ToInt32(Request.QueryString["id"]);
        }
        //-----------------------------------------------
        ucGetNew.ModuleTypeID = CurrentMessagesModule.ModuleTypeID;
        ucGetNew.ToItemID = itemID;
        //-----------------------------------------------
        if (!IsPostBack)
        {
            if (currentModule.HasSpecialAdminText)
            {
                this.Page.Title = currentModule.GetModuleAdminSpecialTitle() + " - " + DynamicResource.GetText(currentModule, "Module_NewMessage");
            }
            else
            {
                this.Page.Title = currentModule.GetModuleAdminSpecialTitle() + " - " + Resources.Modules.Module_NewMessage;
            }
        }
        //-----------------------------------------------
    }
    //-----------------------------------------------
    #endregion
}

