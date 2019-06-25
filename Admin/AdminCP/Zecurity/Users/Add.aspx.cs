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
using System.Collections.Generic;

public partial class Admin_Users_CreateUser : AdminMasterPage
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
        List<Group> ds = ZecurityManager.GetAllGroups();
        if (ds.Count > 0)
        {
            cblGroups.DataSource = ds;
            cblGroups.DataValueField = "ID";
            cblGroups.DataTextField = "Name";
            cblGroups.DataBind();
        }
    }
	
	protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
	{
        Roles.AddUserToRole(CreateUserWizard1.UserName, DCRoles.SiteSubAdminsRoles);
        foreach (ListItem item in cblGroups.Items)
        {
            if (item.Selected)
            {
                Guid groupid = new Guid(item.Value);
                Guid usrid = new Guid(Membership.GetUser(CreateUserWizard1.UserName).ProviderUserKey.ToString());
                ZecurityManager.AddUserToGroup(usrid, groupid);
            }
        }
	}
}
