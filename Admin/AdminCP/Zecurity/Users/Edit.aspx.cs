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
using System.Text.RegularExpressions;
using System.Collections.Generic;

public partial class Admin_Users_Default : AdminMasterPage
{
	protected override void OnInit(EventArgs e)
	{
		base.OnInit(e);
        if (!Context.User.IsInRole(DCRoles.SiteOverallAdminsRoles))
		{
            Response.Redirect("/AdminCP/Default.aspx");
		}
	}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = Resources.Zecurity.ZecurityModuleTitle;
            LoadData();
        }
    }

	private void LoadData()
	{

		if (!string.IsNullOrEmpty(Request.QueryString["id"]) &&
			Regex.IsMatch(Request.QueryString["id"], @"[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}"))
		{
			Guid id = new Guid(Request.QueryString["id"]);
			MembershipUser usr = Membership.GetUser(id);

			if (usr != null)
			{
				PopulateUserData(usr);
			}
		}
		else
			this.Visible = false;
	}

	private void PopulateUserData(MembershipUser usr)
	{
		lblCreationDate.Text = usr.CreationDate.ToShortDateString();
		txtEmail.Text = usr.Email;
		cbIsApproved.Checked = usr.IsApproved;
		cbIsOnline.Checked = usr.IsOnline;
		lblLastDate.Text = usr.LastLoginDate.ToString("dd/MM/yyyy  (Clock: HH:mm)");
		lblUserName.Text = usr.UserName;

        List<DCCMSNameSpace.Zecurity.Group> groups = ZecurityManager.GetAllGroups();
        if (groups.Count > 0)
        {
            cblGroups.DataSource = groups;
            cblGroups.DataTextField = "Name";
            cblGroups.DataValueField = "ID";
            cblGroups.DataBind();

            List<DCCMSNameSpace.Zecurity.Group> userGroups = ZecurityManager.GetGroupsByUser(new Guid(usr.ProviderUserKey.ToString()));
            if (userGroups.Count > 0)
                foreach (DCCMSNameSpace.Zecurity.Group group in userGroups)
                    foreach (ListItem item in cblGroups.Items)
                        if(item.Value.ToString() == group.ID.ToString()) item.Selected = true;
        }
        else
            cblGroups.Visible = false;

        

        

        
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (!string.IsNullOrEmpty(Request.QueryString["id"]) &&
			Regex.IsMatch(Request.QueryString["id"], @"[0-9a-f]{8}\-([0-9a-f]{4}\-){3}[0-9a-f]{12}"))
		{
			Guid id = new Guid(Request.QueryString["id"]);
			MembershipUser usr = Membership.GetUser(id);

			if (usr != null)
			{
				usr.Email = txtEmail.Text;
				usr.IsApproved = cbIsApproved.Checked;

				Membership.UpdateUser(usr);

                List<Guid> groupIds = new List<Guid>();
                foreach (ListItem item in cblGroups.Items)
                {
                    if (item.Selected)
                        groupIds.Add(new Guid(item.Value));
                }

                ZecurityManager.UpdateUserGroups(id, groupIds);

				if (!string.IsNullOrEmpty(txtPassword.Text) &&
					!string.IsNullOrEmpty(txtConfirmPassword.Text) &&
					txtPassword.Text == txtConfirmPassword.Text)
				{
					string pass = usr.ResetPassword();
					usr.ChangePassword(pass, txtConfirmPassword.Text);
				}
                Response.Redirect("Default.aspx");
			}
			
		}
	}
}