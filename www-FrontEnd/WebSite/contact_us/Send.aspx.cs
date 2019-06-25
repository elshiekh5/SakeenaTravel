using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite_contact_us_Send : System.Web.UI.Page
{
    //=============================================================================== 
    //Server side start 
    //===============================================================================
    public MessagesModuleOptions currentModule;
    protected void Page_Load(object sender, EventArgs e)
    {
        currentModule = (MessagesModuleOptions)HttpContext.Current.Items["CurrentMessagesModule"];
        //ucSend.ModuleTypeID = CurrentMessagesModule.ModuleTypeID;
        if (!IsPostBack)
        {
           // BuilMessagesDefaultPathesLinks();
        }
    }
    //=============================================================================== 
}