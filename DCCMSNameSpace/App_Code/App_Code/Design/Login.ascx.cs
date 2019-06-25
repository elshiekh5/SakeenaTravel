using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


namespace DCCMSNameSpace
{

    namespace ReadyUserControls
    {
        public partial class LoginControl : ReadyUserControls.UserControl
        {

            TextBox txtUserName;
            TextBox txtPassword;
            Label lblResult;
            ImageButton ibtnLogin;
            CheckBox cbRememberMe;
            //-----------------------------------------------------------
            protected void Page_Load(object sender, EventArgs e)
            {
                //-------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                txtUserName.Attributes.Add("onkeypress", " if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + ibtnLogin.ClientID + "').click();return false;}} else {return true}; ");
                txtPassword.Attributes.Add("onkeypress", " if(event.which || event.keyCode){if ((event.which == 13) || (event.keyCode == 13)) {document.getElementById('" + ibtnLogin.ClientID + "').click();return false;}} else {return true}; ");
                ////-------------------------------------------------

            }
            //-----------------------------------------------------------
            protected void CatchControls()
            {
                lblResult = (Label)this.FindControl("lblResult");
                txtUserName = (TextBox)this.FindControl("txtUserName");
                txtPassword = (TextBox)this.FindControl("txtPassword");
                ibtnLogin = (ImageButton)this.FindControl("ibtnLogin");
                cbRememberMe = (CheckBox)this.FindControl("cbRememberMe");
            }
            //-----------------------------------------------------------
            protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
            {
                if (Membership.ValidateUser(txtUserName.Text, txtPassword.Text))
                {
                    MembershipUser user = Membership.GetUser(txtUserName.Text);
                    FormsAuthentication.SetAuthCookie(txtUserName.Text, cbRememberMe.Checked);
                    Response.Redirect("/WebSite/User/Agency.aspx");
                }
                else
                {
                    lblResult.Text = DynamicResource.GetText("MemberShip","LoginFailed");
                }
            }
        }
    }

}