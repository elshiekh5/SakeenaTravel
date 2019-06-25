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

public partial class MasterAdmin_Add_Admin : MasterAdminMasterPage
{

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {
            this.Page.Title = "≈÷«›… √œ„‰";
            LoadRoels();
        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadRoels---------------
    //-----------------------------------------------
    //LoadRoels
    //-----------------------------------------------
    protected void LoadRoels()
    {
        string[] roles = System.Web.Security.Roles.GetAllRoles();
        cblRoels.DataSource = roles;
        cblRoels.DataBind();
    }
    //-----------------------------------------------
    #endregion

    #region ---------------Save---------------
    //-----------------------------------------------
    //Save
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        MembershipUser user = Membership.CreateUser(txtUserName.Text, txtPassword.Text, txtEmail.Text);
        foreach (ListItem li in cblRoels.Items)
        {
            if (li.Selected)
            {
                Roles.AddUserToRole(user.UserName, li.Text);
            }
        }
        lblResult.Text = " „ ≈‰‘«¡ «·Õ”«»";
        lblResult.CssClass = "operation_done";
        ClearControls();

    }
    //-----------------------------------------------
    #endregion


    #region ---------------ClearControls---------------
    //-----------------------------------------------
    //Save
    //-----------------------------------------------
    public void ClearControls()
    {
        cblRoels.SelectedIndex = -1;
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtEmail.Text = "";
    }
    //-----------------------------------------------
    #endregion
}

