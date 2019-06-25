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
using System.Text.RegularExpressions;

public partial class Admin_Users_Default : AdminMasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = Resources.MemberShip.ChangePassword;
            LoadData();
        }
    }

    private void LoadData()
    {

        MembershipUser usr = Membership.GetUser();
        if (usr != null)
        {
            PopulateUserData(usr);
        }
    }

    private void PopulateUserData(MembershipUser usr)
    {

        lblCreationDate.Text = usr.CreationDate.ToShortDateString();
        //txtEmail.Text = usr.Email;
        //cbIsApproved.Checked = usr.IsApproved;
        lblLastDate.Text = usr.LastLoginDate.ToString("dd/MM/yyyy  (HH:mm)");
        lblUserName.Text = usr.UserName;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //-----------------------------------------------------------------------
        if (!IsValid)
            return;
        //-----------------------------------------------------------------------
        MembershipUser user = Membership.GetUser();
        //-----------------------------------------------------------------------
        if (!Membership.ValidateUser(user.UserName, txtCurrentPassword.Text))
        {
            lblResult.Text = Resources.MemberShip.InvalidCurrentPassword;
            return;
        }
        //-----------------------------------------------------------------------
        bool result = user.ChangePassword(txtCurrentPassword.Text, txtNewPassword.Text);
        //-----------------------------------------------------------------------
        if (result)
        {

            lblResult.CssClass = "operation_done";
            lblResult.Text = Resources.MemberShip.ChangingPasswordDone;
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.MemberShip.ChangingPasswordFaild;
        }
        //-----------------------------------------------------------------------

    }
}