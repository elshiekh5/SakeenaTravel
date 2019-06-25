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


public partial class PathLinksControl : PathLinksClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            BuildPathesLink();
        else
            Page.Title = GetPageTitle();

        
    }
    public new string BuildHtml()
    {
        string htmlLinks = "";
        HyperLink h;
        List<HyperLink> _Links = base.Links;

        for (int i = 0; i < _Links.Count; i++)
        {
            h = _Links[i];
            if (!string.IsNullOrEmpty(h.NavigateUrl))
            {
                if (i < _Links.Count - 1)
                {
                    htmlLinks += "<li><a href=\"" + h.NavigateUrl + "\">" + h.Text + "</a></li>";
                }
            }
            else
            {
                htmlLinks += "<li class=\"active\">" + h.Text + "</li> ";
                PageTitle += " | " + h.Text;
            }
        }
        ViewState["PageTitle"] = PageTitle;
        Page.Title = PageTitle;
        return htmlLinks;
    }

    public void BuildPathesLink()
    {
        ltrLinks.Text = BuildHtml();
    }
    
}
