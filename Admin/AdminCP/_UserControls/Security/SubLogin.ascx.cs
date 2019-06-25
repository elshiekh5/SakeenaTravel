using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
public partial class UserControls_login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //-------------------------------------------------
        txtUserName.Attributes.Add("onkeypress", " if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + ibtnLogin.ClientID + "').click();return false;}} else {return true}; ");
        txtPassword.Attributes.Add("onkeypress", " if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + ibtnLogin.ClientID + "').click();return false;}} else {return true}; ");
        //-------------------------------------------------
        if (!IsPostBack)
        {
            //--------------------------------------------------------------------------------------------
            if (this.Page.User != null && this.Page.User.Identity.IsAuthenticated)
            {
                //------------------------
                if (Roles.IsUserInRole(ZecurityManager.UserName, DCRoles.SubAdminsRole ))
                    Response.Redirect("/AdminSub/");
                else
                    Response.Redirect(SiteUrls.RoleErrorPage);
                //------------------------
            }
            //--------------------------------------------------------------------------------------------
            //Admin Images
            //--------------------------
            string adminImagesFolder = SiteDesign.AdminImagesFolder;
            //if (File.Exists(DCServer.MapPath(adminImagesFolder + "login-title.gif")))
            if (SiteSettings.Site_HasAdminMainImages)
                divLogin_title.Style.Add(HtmlTextWriterStyle.BackgroundImage, "'" + adminImagesFolder + "login-title.png" + "'");
            //--------------------------
            //if (File.Exists(DCServer.MapPath(adminImagesFolder + "login-bg-photo.gif")))
            if (SiteSettings.Site_HasAdminMainImages)
                divWarpper.Style.Add(HtmlTextWriterStyle.BackgroundImage, "'" + adminImagesFolder + "login-bg-photo.gif" + "'");
            //--------------------------------------------------------------------------------------------
        }

    }


    protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        if (Membership.ValidateUser(txtUserName.Text, txtPassword.Text))
        {
            MembershipUser user = Membership.GetUser(txtUserName.Text);
            FormsAuthentication.SetAuthCookie(txtUserName.Text, false);
            //------------------------
            if (Roles.IsUserInRole(txtUserName.Text, DCRoles.SubAdminsRole))
                Response.Redirect("/AdminSub/");
            else
                Response.Redirect(SiteUrls.RoleErrorPage);
            //------------------------
        }
        else
        {
            ltrFailureText.Text = Resources.MemberShip.LoginFailed;
        }
    }
}
