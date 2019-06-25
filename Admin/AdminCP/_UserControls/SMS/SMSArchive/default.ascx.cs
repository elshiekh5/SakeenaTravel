using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DCCMSNameSpace;

public partial class AdminCP__UserControls_SMS_SMSArchive_default : System.Web.UI.UserControl
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
        DataTable dtSource = SMSArchiveFactory.GetAll();
        if (dtSource != null && dtSource.Rows.Count > 0)
        {
            dgSMSArchive.DataSource = dtSource;
            dgSMSArchive.DataKeyField = "ID";
            dgSMSArchive.PageSize = 50;
            if (dgSMSArchive.PageSize >= dtSource.Rows.Count)
            {
                dgSMSArchive.AllowPaging = false;
            }
            //if (!Security.IsInRole(SiteRoles.D))
            //{
            //    dgSMSArchive.Columns[dgSMSArchive.Columns.Count - 1].Visible = false;
            //}
            dgSMSArchive.DataBind();
            dgSMSArchive.Visible = true;
            lblMsg.Visible = false;
        }
        else
        {
            dgSMSArchive.Visible = false;
            lblMsg.Visible = true;
        }
    }

    protected void dgSMSArchive_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
        }
    }

    protected void dgSMSArchive_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
    {
        dgSMSArchive.CurrentPageIndex = e.NewPageIndex;
        LoadData();
    }

    protected void dgSMSArchive_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        int id = Convert.ToInt32(dgSMSArchive.DataKeys[e.Item.ItemIndex]);
        if (SMSArchiveFactory.Delete(id))
        {
            LoadData();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (SMSArchiveFactory.DeleteAll())
        {
            LoadData();
        }
    }
}