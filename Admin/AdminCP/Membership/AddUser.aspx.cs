using System;using DCCMSNameSpace;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;

public partial class AdminSitesUsers_Create : AdminMasterPage
{

    #region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
        lblResult.Text="";
		
	}
	//-----------------------------------------------
	#endregion

	#region ---------------btnCreate_Click---------------
	//-----------------------------------------------
	//btnCreate_Click
	//-----------------------------------------------
    protected void btnCreate_Click(object sender, System.EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        MembershipCreateStatus Status;
        MembershipUser user = Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text, null, null, true, out Status);

        if (Status == MembershipCreateStatus.DuplicateEmail)
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.MemberShip.DuplicateEmail;
            return;
        }
        else if (Status == MembershipCreateStatus.DuplicateUserName)
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.MemberShip.DuplicateUserName;
            return;
        }
        else if (Status == MembershipCreateStatus.InvalidAnswer)
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.MemberShip.InvalidAnswer;
            return;
        }
        else if (Status == MembershipCreateStatus.InvalidEmail)
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.MemberShip.InvalidEmail;
            return;
        }
        else if (Status == MembershipCreateStatus.InvalidPassword)
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.MemberShip.InvalidPassword;
            return;
        }
        else if (Status == MembershipCreateStatus.InvalidQuestion)
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.MemberShip.InvalidQuestion;
            return;
        }
        else if (Status == MembershipCreateStatus.InvalidUserName)
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.MemberShip.InvalidUserName;
            return;
        }
        else if (Status == MembershipCreateStatus.UserRejected)
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.MemberShip.UserRejected;
            return;
        }
        else if (Status == MembershipCreateStatus.Success)
        {
            Roles.AddUserToRole(user.UserName, ddlAccountType.SelectedValue);
            lblResult.CssClass = "operation_done";
            lblResult.Text = Resources.AdminText.AddingOperationDone;
            ClearControls();
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.AddingOperationFaild;
        }

    }
	//-----------------------------------------------
	#endregion

	#region --------------ClearControls()--------------
	//---------------------------------------------------------
	//ClearControls()
	//---------------------------------------------------------
	private void ClearControls()
	{
        //-------------------------------------
        //Admin
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        //txtQuestion.Text = "";
        //txtAnswer.Text = "";
        txtEmail.Text = "";
        //-------------------------------------
        txtName.Text = "";
        txtTelephones.Text = "";
       
        //-------------------------------------
    }
	//--------------------------------------------------------
	#endregion
}


