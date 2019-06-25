using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;

public partial class AdminCP__UserControls_SMS_Users_Add : System.Web.UI.UserControl
{

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
        }
    }

    #endregion


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

    

    #region ---------------HandelControls---------------
    //-----------------------------------------------
    //HandelControls
    //-----------------------------------------------
    protected void HandelControls()
    {
        #region ------------------Languages Handling---------------------
        //Languages Handling
        if (SiteSettings.Languages_HasMultiLanguages)
            SiteSettings.BuildDropDownListForDefaultPage(ddlLanguages);
        else
            trLanguages.Visible = false;
        #endregion
        //-------------------------------------------
        if (SiteSettings.Sms_HasGroups)
            Load_ddlSmsGroups();
        else
            trGroups.Visible = false;
        //-------------------------------------------
    }
    #endregion

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
        SMSNumbersEntity smsUser = new SMSNumbersEntity();
        smsUser.Name = txtName.Text;
        smsUser.Numbers = txtNumber.Text;
        smsUser.IsActive = cbIsActive.Checked;
        if (SiteSettings.Sms_HasGroups)
        {
            smsUser.GroupID = Convert.ToInt32(ddlSmsGroups.SelectedValue);
        }
        smsUser.ModuleTypeID = (int)StandardItemsModuleTypes.SMS;
        //---------------------------------------------------------------------
        //Language
        //---------------------------------------------------------------------
        Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------
        smsUser.LangID = langID;
        //---------------------------------------------------------------------
        ExecuteCommandStatus status = SMSNumbersFactory.Create(smsUser);
        if (status == ExecuteCommandStatus.Done)
        {
            lblResult.CssClass = "operation_done";
            lblResult.Text = Resources.AdminText.SavingDataSuccessfuly;
            ClearControls();

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

    private void ClearControls()
    {
        ddlLanguages.SelectedIndex = -1;
        ddlSmsGroups.SelectedIndex = -1;
        txtNumber.Text = "";
        txtName.Text = "";
        cbIsActive.Checked = false;
    }
}