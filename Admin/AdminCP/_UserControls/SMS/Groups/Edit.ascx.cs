using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;

public partial class AdminCP__UserControls_SMS_Groups_Edit : System.Web.UI.UserControl
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
        if (Request.QueryString["GroupID"] != null)
        {
            int GroupID = Convert.ToInt32(Request.QueryString["GroupID"]);
            SMSGroupsEntity smsGroups = SMSGroupsFactory.GetSMSGroupsObject(GroupID);
            txtName.Text = smsGroups.Name;
        }
        else
            this.Visible = false;
    }

    protected void btnUpdate_Click(object sender, System.EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        SMSGroupsEntity smsGroups = new SMSGroupsEntity();
        smsGroups.GroupID = Convert.ToInt32(Request.QueryString["GroupID"]);
        smsGroups.Name = txtName.Text;
        if (SMSGroupsFactory.Update(smsGroups))
        {
            Response.Redirect("default.aspx");
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.SavingDataFaild;
        }
    }
}