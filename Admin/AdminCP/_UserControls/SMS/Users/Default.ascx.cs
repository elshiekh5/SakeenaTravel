using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using DCCMSNameSpace.Zecurity;

public partial class AdminCP__UserControls_SMS_Users_Default : AdminDefaultUserControl
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            HandelControls();
        }

        FirstLoad(dgControl, pager, lblResult);
    }
    #endregion

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    protected override void LoadData()
    {
        //-------------------------------------------------------------
        int GroupID = -1;// UnSpecified
        if (SiteSettings.Sms_HasGroups)
            GroupID = Convert.ToInt32(ddlSMSGroups.SelectedValue);
        //-------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //-------------------------------------------------------------
        List<SMSNumbersEntity> SmsUserList = SMSNumbersFactory.GetAll((int)StandardItemsModuleTypes.UnKnowen, langID, GroupID, false, txtSearch.Text, pager.CurrentPage, PageSize, out totalRecords);
        LoadGrid(SmsUserList, "NumID");
        //-------------------------------------------------------------------------------
        //Security Premession
        //--------------------------
        //Check Delete permission
        if (!ZecurityManager.UserCanExecuteCommand(CommandName.Delete))
            dgControl.Columns[dgControl.Columns.Count - 1].Visible = false;
        //-------------------------------------------------------------------------------
    }
    //--------------------------------------------------------
    #endregion

    #region --------------DeleteItem--------------

    protected override bool DeleteItem(int id)
    {
        return SMSNumbersFactory.Delete(id);
    }
    //--------------------------------------------------------
    #endregion

    #region --------------Load_ddlSMSGroups()--------------
    //---------------------------------------------------------
    //Load_ddlSMSGroups
    //---------------------------------------------------------
    protected void Load_ddlSMSGroups()
    {
        List<SMSGroupsEntity> SMSGroupsList = SMSGroupsFactory.GetAllInList();
        OurDropDownList.LoadDropDownList<SMSGroupsEntity>(SMSGroupsList, ddlSMSGroups, "Name", "GroupID", true);

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
            Load_ddlSMSGroups();
        else
            trGroups.Visible = false;
        //-------------------------------------------
        btnExport.Visible = SiteSettings.Sms_HasExportToExcellFile;
        //-------------------------------------------

    }
    #endregion

    //---------------------------------------------------------
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        pager.CurrentPage = 1;
        LoadData();
    }
    //---------------------------------------------------------
    protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        pager.CurrentPage = 1;
        LoadData();
    }
    //--------------------------------------------------------------------------
    #region --------------Export--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    protected void Export()
    {
        //-------------------------------------------------------------
        int GroupID = -1;// UnSpecified
        if (SiteSettings.Sms_HasGroups)
            GroupID = Convert.ToInt32(ddlSMSGroups.SelectedValue);
        //-------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //-------------------------------------------------------------
        List<SMSNumbersEntity> SmsUserList = SMSNumbersFactory.GetAll((int)StandardItemsModuleTypes.UnKnowen, langID, GroupID, false, txtSearch.Text, pager.CurrentPage, PageSize, out totalRecords);
        if (SmsUserList != null && SmsUserList.Count > 0)
        {
            dgExport.DataSource = SmsUserList;
            dgExport.DataKeyField = "NumID";
            dgExport.DataBind();
            dgExport.Visible = true;
            //-----------------------------------
            Response.Clear();
            //Response.HeaderEncoding = Encoding.GetEncoding("Windows-1256");
            Response.AddHeader("content-disposition", "attachment;filename=SmsList.xls");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            // Response.Charset = "utf-8";
            Response.Charset = "utf-8";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            dgExport.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
            dgExport.Visible = false;
            //-----------------------------------
        }
        else
        {
            dgExport.Visible = false;
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.ThereIsNoData;
        }

    }
    //--------------------------------------------------------
    #endregion

    protected void btnExport_Click(object sender, EventArgs e)
    {
        Export();
    }
}