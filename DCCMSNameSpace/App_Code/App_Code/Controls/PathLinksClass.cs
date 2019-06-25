using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for PathLinksClass
    /// </summary>
    public class PathLinksClass : System.Web.UI.UserControl
    {
        //---------------------------------------------------------
        private List<HyperLink> _Links = new List<HyperLink>();
        public List<HyperLink> Links
        {
            get { return _Links; }
            set { _Links = value; }
        }
        public HyperLink LastLink
        {
            get
            {
                if (_Links.Count > 0)
                {
                    return _Links[_Links.Count - 1];
                }
                else
                {
                    return new HyperLink();
                }

            }
        }
        //---------------------------------------------------------
        public string PageTitle = SiteTextsManager.Instance.SiteName;
        public void AddLink(string text, string url)
        {
            HyperLink newLink = new HyperLink();
            newLink.Text = text;
            newLink.NavigateUrl = url;
            _Links.Add(newLink);
        }
        public string BuildHtml()
        {
            string htmlLinks = "";
            HyperLink h;
            
            
            for (int i = 0; i < _Links.Count; i++)
            {
                h = _Links[i];
                if (!string.IsNullOrEmpty(h.NavigateUrl))
                {
                    if (i < _Links.Count - 1)
                    {
                        htmlLinks += "<li><a href=\"" + h.NavigateUrl + "\">" + h.Text + "</a><span class=\"divider\">/</span></li>";
                    }
                    else
                    {
                        htmlLinks += "<li><a href=\"" + h.NavigateUrl + "\">" + h.Text + "</a>/li>";
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
        public string GetPageTitle()
        {
            return (string)ViewState["PageTitle"];
        }
    }
}
