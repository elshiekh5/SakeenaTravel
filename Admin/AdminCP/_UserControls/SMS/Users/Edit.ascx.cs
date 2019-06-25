using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;

public partial class AdminCP__UserControls_SMS_Users_Edit : System.Web.UI.UserControl
{
    #region --------------Load_ddlSmsGroups()--------------
    //---------------------------------------------------------
    //Load_ddlSmsGroups
    //---------------------------------------------------------
    protected void Load_ddlSmsGroups()
    {
        List<SMSGroupsEntity> SmsGroupsList = SMSGroupsFactory.GetAllInList();
        OurDropDownList.LoadDropDownList<SMSGroupsEntity>(SmsGroupsList, ddlSmsGroups, "Name", "GroupID", true);

    }
    //--------------------------------------------------------
    #endregion

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {

            HandelControls();
            LoadData();

        }
    }

    #endregion

    #region ---------------HandelControls---------------
    //-----------------------------------------------
    //HandelControls
    //-----------------------------------------------
    protected void HandelControls()
    {

        //-------------------------------------------
        if (SiteSettings.Sms_HasGroups)
            Load_ddlSmsGroups();
        else
            trGroups.Visible = false;
        //-------------------------------------------
    }
    #endregion

    protected void LoadData()
    {
        if (MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
        {
            long numID = Convert.ToInt64(Request.QueryString["id"]);
            SMSNumbersEntity smsUser = SMSNumbersFactory.GetObject(numID);
            if (smsUser != null)
            {
                txtName.Text = smsUser.Name;
                txtNumber.Text = smsUser.Numbers;
                cbIsActive.Checked = smsUser.IsActive;
                ddlSmsGroups.SelectedValue = smsUser.GroupID.ToString();
            }
        }
        else
        {
            Response.Redirect("default.aspx");
        }
    }

    #region ---------------btnSave_Click---------------
    //-----------------------------------------------
    //btnSave_Click
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        long numID = Convert.ToInt64(Request.QueryString["id"]);
        SMSNumbersEntity smsUser = SMSNumbersFactory.GetObject(numID);
        smsUser.Name = txtName.Text;
        smsUser.Numbers = txtNumber.Text;
        smsUser.IsActive = cbIsActive.Checked;
        if (SiteSettings.Sms_HasGroups)
            smsUser.GroupID = Convert.ToInt32(ddlSmsGroups.SelectedValue);
        //---------------------------------------------------------------------
        ExecuteCommandStatus status = SMSNumbersFactory.Update(smsUser);
        if (status == ExecuteCommandStatus.Done)
        {
            Response.Redirect("default.aspx");
        }
        else if (status == ExecuteCommandStatus.AllreadyExists)
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.DuplicateItem;
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.SavingDataFaild;
        }
    }

    #endregion
}