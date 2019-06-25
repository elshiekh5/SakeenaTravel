using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite__SharedControls_PageContacts : System.Web.UI.UserControl
{
    public ItemsEntity WhyUs { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (WhyUs == null)
        {
            WhyUs = ItemsFactory.GetObject(3, SiteSettings.GetCurrentLanguage(), UsersTypes.User, SitesHandler.GetOwnerIDAsGuid());
        }
    }
}