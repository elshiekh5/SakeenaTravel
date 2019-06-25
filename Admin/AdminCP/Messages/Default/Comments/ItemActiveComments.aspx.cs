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


public partial class AdminNews_ItemActiveComments : AdminMasterPage
{

	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
        MessagesModuleOptions CurrentMessagesModule = (MessagesModuleOptions)HttpContext.Current.Items["CurrentMessagesModule"];
        ucComments.ModuleTypeID = CurrentMessagesModule.ModuleTypeID;
        //-----------------------------------------------
        if (!IsPostBack)
        {
            if (CurrentMessagesModule.HasSpecialAdminText)
            {
                this.Page.Title = CurrentMessagesModule.GetModuleAdminSpecialTitle() + " - " + DynamicResource.GetMessageModuleText(CurrentMessagesModule, "Module_CommentsActive");
            }
            else
            {
                this.Page.Title = CurrentMessagesModule.GetModuleAdminSpecialTitle() + " - " + Resources.Modules.Module_CommentsActive;
            }
        }
        //-----------------------------------------------
	}
	//-----------------------------------------------
	#endregion

}

