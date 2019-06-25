using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Admin_Modules_Security_Groups_Default : AdminMasterPage
{
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
            dgPermissionGroups.DataSource = ds;
            dgPermissionGroups.DataBind();
            dgPermissionGroups.Visible = true;
        }
        else
        {
            dgPermissionGroups.Visible = false;
        }
        
    }
    
    protected void dgPermissionGroups_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            Group group = (Group)e.Item.DataItem;
            if (group.Permissions.Count > 0)
            {
                DataGrid dgPermissions = (DataGrid)e.Item.FindControl("dgPermissions");
                dgPermissions.DataSource = group.Permissions;
                dgPermissions.PagerStyle.Visible = false;
                dgPermissions.Width = Unit.Percentage(80);
                dgPermissions.DataBind();
            }

            if (group.Users != null)
            {
                if (group.Users.Count > 0)
                {
                    Repeater rptUsers = (Repeater)e.Item.FindControl("rptUsers");
                    rptUsers.DataSource = group.Users;
                    rptUsers.DataBind();
                }
            }
        }
    }
    
    protected void dgPermissionGroups_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        if (!ZecurityManager.UserCanExecuteCommand(CommandName.Delete))
            Response.Redirect("/Admin/ErrorPage.aspx");
        Guid id = new Guid(dgPermissionGroups.DataKeys[e.Item.ItemIndex].ToString());
        if (ZecurityManager.DeleteGroup(id))
        {
            LoadData();
        }
    }

    public string GetUserNameByID(object id)
    {
        MembershipUser user = Membership.GetUser(id);
        if (user != null)
            return user.UserName;
        else
            return "";
    }
}
