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


public partial class Admin_Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (User.Identity.IsAuthenticated)
        {
            if (Roles.IsUserInRole(DCRoles.SiteOverallAdminsRoles) || Roles.IsUserInRole(DCRoles.SiteSubAdminsRoles))
                Response.Redirect(SiteUrls.AdminHomePage);
            else
                Response.Redirect(SiteUrls.HomePage);
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (Membership.ValidateUser(txtUserName.Text, txtPassword.Text))
        {
            MembershipUser user = Membership.GetUser(txtUserName.Text);
            FormsAuthentication.SetAuthCookie(txtUserName.Text, cbRememberMe.Checked);
            Response.Redirect(SiteUrls.AdminHomePage);
        }
        else
        {
            lblResult.Text = Resources.MemberShip.LoginFailed;
        }
    }
}


