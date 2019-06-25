using System;using DCCMSNameSpace;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Admin_LangSpecification : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies["SiteData"];
        if (cookie != null)
        {
            cookie["LangID"] = Request.QueryString["LangID"];
        }
        else
        {
            cookie = new HttpCookie("SiteData");
            cookie["LangID"] = Request.QueryString["LangID"];
            cookie.Path = "/";
            cookie.Expires = DateTime.Now.AddYears(1);
        }
        HttpContext.Current.Response.Cookies.Add(cookie);

        Response.Redirect("default.aspx");
    }
}




