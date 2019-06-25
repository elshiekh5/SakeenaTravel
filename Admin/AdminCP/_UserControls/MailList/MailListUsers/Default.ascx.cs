using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using DCCMSNameSpace.Zecurity;

public partial class AdminCP__UserControls_MailList_MailListUsers_Default : AdminDefaultUserControl
{

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = Resources.MailList.MailListTitle;
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
        int groupID = -1;// UnSpecified
        if (SiteSettings.MailList_HasGroups)
            groupID = Convert.ToInt32(ddlMailListGroups.SelectedValue);
        //-------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //-------------------------------------------------------------
        List<MailListUsersEntity> mailListUserList = MailListUsersFactory.GetAll((int)StandardItemsModuleTypes.UnKnowen, langID, groupID, false, txtEmail.Text, pager.CurrentPage, PageSize, out totalRecords);
        LoadGrid(mailListUserList, "UserID");
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
        return MailListUsersFactory.Delete(id);
    }
    //--------------------------------------------------------
    #endregion

    #region --------------Load_ddlMailListGroups()--------------
    //---------------------------------------------------------
    //Load_ddlMailListGroups
    //---------------------------------------------------------
    protected void Load_ddlMailListGroups()
    {
        List<MailListGroupsEntity> mailListGroupsList = MailListGroupsFactory.GetAll();
        OurDropDownList.LoadDropDownList<MailListGroupsEntity>(mailListGroupsList, ddlMailListGroups, "Name", "GroupID", true);

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
        if (SiteSettings.MailList_HasGroups)
            Load_ddlMailListGroups();
        else
            trGroups.Visible = false;
        //-------------------------------------------
        btnExport.Visible = SiteSettings.MailList_HasExportToExcellFile;
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
        int groupID = -1;// UnSpecified
        if (SiteSettings.MailList_HasGroups)
            groupID = Convert.ToInt32(ddlMailListGroups.SelectedValue);
        //-------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //-------------------------------------------------------------
        List<MailListUsersEntity> mailListUserList = MailListUsersFactory.GetAll((int)StandardItemsModuleTypes.UnKnowen, langID, groupID, false, txtEmail.Text, pager.CurrentPage, PageSize, out totalRecords);

        if (mailListUserList != null && mailListUserList.Count > 0)
        {
            dgExport.DataSource = mailListUserList;
            dgExport.DataKeyField = "UserID";
            dgExport.DataBind();
            dgExport.Visible = true;
            //-----------------------------------
            Response.Clear();
            //Response.HeaderEncoding = Encoding.GetEncoding("Windows-1256");
            Response.AddHeader("content-disposition", "attachment;filename=MailList.xls");
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