using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Text;
using AppService;


public partial class PathLinksControl : PathLinksClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public string BuildLinks() {
        
        StringBuilder linksString = new StringBuilder();
        List<NavigationLink> links = NavigationManager.Instance.Links;
        foreach (NavigationLink l in links)
        {
            if (!l.LastTitle)
            {
                linksString.Append(string.Format("<li><a href=\"{0}\">{1}</a></li>",l.Href,l.Title));
            }
            else
            {
                linksString.Append(string.Format("<li class=\"active\">{0}</li>", l.Title));
            }
        }
        return linksString.ToString();
    }
    
}
