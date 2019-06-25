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

public partial class AdminSitePages_Page : AdminMasterPage
{

	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
        if (!IsPostBack)
        {

            if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {
                int itemID = Convert.ToInt32(Request.QueryString["id"]);
                Guid OwnerID = SitesHandler.GetOwnerIDAsGuid();
                ItemsEntity itemsObject = ItemsFactory.GetObject(itemID, Languages.Unknowen, UsersTypes.Admin, OwnerID);
                this.Page.Title = itemsObject.Title;
            }
        }
    }
	//-----------------------------------------------
	#endregion

	
	
}

