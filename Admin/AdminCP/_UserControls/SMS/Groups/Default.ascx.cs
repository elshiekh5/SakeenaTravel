using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DCCMSNameSpace;

public partial class AdminCP__UserControls_SMS_Groups_Default : System.Web.UI.UserControl
{
    private void Page_Load(object sender, System.EventArgs e)
    {

        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        DataTable dtSource = SMSGroupsFactory.GetAll();
        if (dtSource != null && dtSource.Rows.Count > 0)
        {
            dgSMSGroups.DataSource = dtSource;
            dgSMSGroups.DataKeyField = "GroupID";
            if (dgSMSGroups.PageSize >= dtSource.Rows.Count)
            {
                dgSMSGroups.AllowPaging = false;
            }
            //Check Roles----------------------------
            //if (!Security.IsInRole(SiteRoles.U))
            //{
            //    dgSMSGroups.Columns[dgSMSGroups.Columns.Count - 2].Visible = false;
            //}
            //if (!Security.IsInRole(SiteRoles.D))
            //{
            //    dgSMSGroups.Columns[dgSMSGroups.Columns.Count - 1].Visible = false;
            //}

            //---------------------------------------
            dgSMSGroups.DataBind();
            dgSMSGroups.Visible = true;
            lblMsg.Visible = false;
        }
        else
        {
            dgSMSGroups.Visible = false;
            lblMsg.Visible = true;
        }
    }

    protected void dgSMSGroups_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('Do you want to delete ?')");
        }
    }

    protected void dgSMSGroups_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgSMSGroups.CurrentPageIndex = e.NewPageIndex;
        LoadData();
    }

    protected void dgSMSGroups_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        int GroupID = Convert.ToInt32(dgSMSGroups.DataKeys[e.Item.ItemIndex]);
        if (SMSGroupsFactory.Delete(GroupID))
        {
            LoadData();
        }
    }
}