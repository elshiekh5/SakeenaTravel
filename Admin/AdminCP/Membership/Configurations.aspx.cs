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

using System.Drawing;
public partial class Admin_Admin_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (User.Identity.IsAuthenticated)
        {
            /*
            if (Roles.IsUserInRole(DCRoles.SiteAdminsRoles))
                Response.Redirect(SiteUrls.AdminHomePage);
            else
                Response.Redirect(SiteUrls.Instance.HomePage);*/
        }
    }
   
    protected void btnCreateBasicRoles_Click(object sender, EventArgs e)
    {
        try
        {
            Roles.CreateRole(DCRoles.SiteOverallAdminsRoles);
            Roles.CreateRole(DCRoles.SiteSubAdminsRoles);
            Roles.CreateRole(DCRoles.ConsultantsRoles);
            Roles.CreateRole(DCRoles.SiteUsersRoles);
            Membership.CreateUser("Admin","Admin123");
            Roles.AddUserToRole("Admin", DCRoles.SiteOverallAdminsRoles);
            lblResult.CssClass = "operation_done";
            lblResult.Text = "Create basic Roles was done and Site administrator account was created";
        }
        catch (Exception ex)
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = ex.Message;
        }
    }
    protected void btnAddRoles_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
            return;
        if (txtRoleName.Text.Trim().Length > 0)
        {
            try
            {
                Roles.CreateRole(txtRoleName.Text);
                lblResult.CssClass = "operation_done";
                lblResult.Text = txtRoleName.Text+"was added";
            }
            catch (Exception ex)
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = ex.Message;
            }
        }
    }
}


