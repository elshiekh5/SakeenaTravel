using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;

public partial class AdminCP__UserControls_SMS_Groups_Add : System.Web.UI.UserControl
{
    private void Page_Load(object sender, System.EventArgs e)
    {
        //Security.CheckAutherization(SiteRoles.A);
        lblResult.Text = "";
        if (!IsPostBack) { }
    }



    protected void btnCreate_Click(object sender, System.EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        SMSGroupsEntity smsGroups = new SMSGroupsEntity();
        smsGroups.Name = txtName.Text;
        if (SMSGroupsFactory.Create(smsGroups))
        {
            lblResult.CssClass = "operation_done";
            lblResult.Text = Resources.AdminText.SavingDataSuccessfuly;
            ClearControls();
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.SavingDataFaild;
        }
    }

    private void ClearControls()
    {
        txtName.Text = "";
    }
}