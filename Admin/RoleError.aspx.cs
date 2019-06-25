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


public partial class RoleError : DynamicInnerMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PathLinksClass pc = (PathLinksClass)this.Master.FindControl("Pathes");
            pc.AddLink(Resources.Modules._Home, "/Default.aspx");
            pc.AddLink(Resources.User.Error, null);
            Label lblTitle = (Label)this.Master.FindControl("lblTitle");
            lblTitle.Text = Resources.User.Error;
        }
    }
}
