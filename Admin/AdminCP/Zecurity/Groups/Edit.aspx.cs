using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Admin_Modules_Security_Roles_Add : AdminMasterPage
{
    protected List<Permission> Permissions
    {
        get
        {
            if (ViewState["Permissions"] != null)
                return (List<Permission>)ViewState["Permissions"];
            else
                return null;
        }
        set
        {
            ViewState["Permissions"] = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {
            this.Page.Title = Resources.Zecurity.ZecurityModuleTitle;
            LoadModules();
            LoadData();
        }
    }

    private void LoadModules()
    {
        List<Module> modules = ZecurityManager.GetAllModules();

        if (modules.Count > 0)
        {
            ddlModules.DataSource = modules;
            ddlModules.DataTextField = "Name";
            ddlModules.DataValueField = "Path";
            ddlModules.DataBind();
        }
        ddlModules.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
    }

    private void LoadData()
    {
        Guid id = new Guid(Request.QueryString["id"]);
        Group group = ZecurityManager.GetGroupByID(id);
        if (group != null)
        {
            txtRoleName.Text = group.Name;
            Permissions = group.Permissions;
            BindDataGrid();
        }
    }

    private void AddToLocalPermissions(Permission permission)
    {
        if (Permissions == null)
            Permissions = new List<Permission>();
        if (!Permissions.Exists(delegate(Permission p) { return p.Path.ToLower() == permission.Path.ToLower(); }))
            Permissions.Add(permission);
    }

    private void RemoveFromLocalPermissions(Permission permission)
    {
        if (Permissions == null)
            return;
        
        int idx = Permissions.IndexOf(permission);
        if (idx > -1)
            Permissions.RemoveAt(idx);
    }
    
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        Permission permission = new Permission();
        permission.Path = ddlModules.SelectedValue;
        permission.Add = cbAdd.Checked;
        permission.Edit = cbEdit.Checked;
        permission.Delete = cbDelete.Checked;
        permission.Name = ddlModules.SelectedItem.Text;
        //permission.Trusted = cbTrusted.Checked;

        AddToLocalPermissions(permission);
        BindDataGrid();

    }

    private void BindDataGrid()
    {
        if (Permissions.Count > 0)
        {
            dgPermissions.DataSource = Permissions;
            dgPermissions.PageSize = 150;
            dgPermissions.DataBind();
            dgPermissions.PagerStyle.Visible = false;
            dgPermissions.Visible = true;
        }
        else
            dgPermissions.Visible = false;
    }
    
    protected void dgPermissions_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        if (!ZecurityManager.UserCanExecuteCommand(CommandName.Delete))
            Response.Redirect("/Admin/ErrorPage.aspx");
        Guid id = (Guid)(dgPermissions.DataKeys[e.Item.ItemIndex]);
        Permissions.RemoveAll(delegate(Permission p) { return p.ID == id; });

        BindDataGrid();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Permissions != null)
        {
            if (Permissions.Count > 0)
            {
                Guid id = new Guid(Request.QueryString["id"]);
                Group group = ZecurityManager.GetGroupByID(id);
                group.Name = txtRoleName.Text;
                group.Permissions = Permissions;

                if (ZecurityManager.UpdateGroup(group))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblResult.Text = Resources.Zecurity.Result_GroupNameDuplicated;
                    lblResult.CssClass = "lblResult_Faild";
                }
            }
            else
            {
                lblResult.Text = Resources.Zecurity.Result_AddPermissionsAndModule;
                lblResult.CssClass = "lblResult_Faild";
            }
        }
        else
        {
            lblResult.Text = Resources.Zecurity.Result_AddPermissionsAndModule;
            lblResult.CssClass = "lblResult_Faild";
        }
    }

    public string GetModuleName(object path)
    {
        List<Module> modules = ZecurityManager.GetAllModules();
        return
            modules.Find(
                delegate(Module p) { return p.Path.ToLower() == path.ToString().ToLower(); }
            ).Name;
    }
}