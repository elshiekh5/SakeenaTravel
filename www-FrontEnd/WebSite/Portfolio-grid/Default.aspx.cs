using AppService;
using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite_PortfolioGrid_Default : DCCMSNameSpace.DynamicInnerMasterPage
{
    //=============================================================================== 
    //Page_Load
    //===============================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        ItemsModulesOptions currentModule = ItemsModulesOptions.GetType(24);
        if (!IsPostBack)
        {
            NavigationManager.Instance.BuilDefaultPathesLinks();
        }
        ucPortfolioFull.LinkPattern = string.Format("/{0}/page/{1}.aspx", currentModule.Identifire, "{0}");
    }
    //=============================================================================== 
}