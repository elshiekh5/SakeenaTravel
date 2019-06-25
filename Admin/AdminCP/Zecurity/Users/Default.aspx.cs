using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class AdminCP_Zecurity_Users_Default : AdminMasterPage
{

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {

        lblResult.Text = "";
        //-----------------------------------------------------------
        if (!Context.User.IsInRole(DCRoles.SiteOverallAdminsRoles))
        {
            Response.Redirect("/AdminCP/Default.aspx");
        }
        //-----------------------------------------------------------
        if (!IsPostBack)
        {
            this.Page.Title = Resources.Zecurity.ZecurityModuleTitle;
            LoadData();

        }
    }
    //-----------------------------------------------
    #endregion

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    private void LoadData()
    {

        MembershipUserCollection ds;
        string[] users = Roles.GetUsersInRole(DCRoles.SiteSubAdminsRoles);
        ds = new MembershipUserCollection();
        foreach (string user in users)
        {
            ds.Add(Membership.GetUser(user));
        }
        if (ds.Count > 0)
        {
            dgUsres.DataSource = ds;
            dgUsres.DataKeyField = "UserName";
            dgUsres.AllowPaging = false;
            dgUsres.DataBind();
            dgUsres.Visible = true;
        }
        else
        {
            dgUsres.Visible = false;
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.ThereIsNoData;
        }

    }
    //--------------------------------------------------------
    #endregion

    protected void ToggleApproved(Object sender, EventArgs e)
    {
        CheckBox isApproved = (CheckBox)sender;
        DataGridItem dgItem = (DataGridItem)isApproved.Parent.Parent;

        string userName = (string)dgUsres.DataKeys[dgItem.ItemIndex];
        MembershipUser userInfo = Membership.GetUser(userName);

        userInfo.IsApproved = isApproved.Checked;
        Membership.UpdateUser(userInfo);
    }

    #region --------------dgUsres_ItemDataBound--------------
    //---------------------------------------------------------
    //dgUsres_ItemDataBound
    //---------------------------------------------------------
    protected void dgUsres_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
            lbtnDelete.AlternateText = Resources.AdminText.Delete;
            #region ---------Index-------
            //Set Index
            int previousRowsCount = 0;
            int currentRow = e.Item.ItemIndex + 1;
            e.Item.Cells[0].Text = (previousRowsCount + currentRow).ToString();
            #endregion
            //---------------------------------------------------------------------------
            string userName = (string)dgUsres.DataKeys[e.Item.ItemIndex];
            if (userName == Context.User.Identity.Name)
            {
                e.Item.Visible = false;
            }
        }
    }
    //--------------------------------------------------------
    #endregion

    

    #region --------------dgUsres_DeleteCommand--------------
    //---------------------------------------------------------
    //dgUsres_DeleteCommand
    //---------------------------------------------------------
    protected void dgUsres_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        string userName = (string)dgUsres.DataKeys[e.Item.ItemIndex];
        Guid id = new Guid(Membership.GetUser(userName).ProviderUserKey.ToString());
        if (Membership.DeleteUser(userName, true))
        {
            ZecurityManager.RemoveUserFromAllgroups(id);
            LoadData();
        }
        else
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.DeletingOprationFaild;
        }
    }
    //--------------------------------------------------------
    #endregion

    protected void ddlRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
}
