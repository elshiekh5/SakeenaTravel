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

public partial class AdminMessagesConsultingServices_Update : AdminMasterPage
{

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        ItemsModulesOptions currentModule = (ItemsModulesOptions)HttpContext.Current.Items["CurrentItemsModule"];
        MessagesModuleOptions CurrentMessagesModule = MessagesModuleOptions.GetType(currentModule.MessagesModuleID);
        ucUpdate.ModuleTypeID = CurrentMessagesModule.ModuleTypeID;
        ucUpdate.DefaultPagePath = "/AdminCP/Items/" + currentModule.Identifire + "/Messages/default.aspx";
        //-----------------------------------------------
        int messageID = -1;
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            messageID = Convert.ToInt32(Request.QueryString["id"]);
        }
        //-----------------------------------------------
        if (messageID > 0)
        {
            MessagesEntity msg = MessagesFactory.GetMessagesObject(messageID, UsersTypes.Admin, SitesHandler.GetOwnerIDAsGuid());
            ucUpdate.DefaultPagePath += "?id=" + msg.ToItemID;
        }
        //-----------------------------------------------
        if (!IsPostBack) { this.Page.Title = CurrentMessagesModule.GetModuleTitle() + " - " + DynamicResource.GetMessageModuleText(CurrentMessagesModule, "Module_MessageData"); }

    }
    //-----------------------------------------------
    #endregion
}

