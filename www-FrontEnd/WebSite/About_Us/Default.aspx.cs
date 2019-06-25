using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using AppService;
public partial class WebSite_Items_About_Us_Default : DynamicInnerMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NavigationManager.Instance.BuilDefaultPathesLinks();
        }
    }
}