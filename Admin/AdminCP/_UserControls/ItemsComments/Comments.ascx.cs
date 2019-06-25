using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Drawing;


public partial class Admin_Comments_Comments : System.Web.UI.UserControl
{
    

    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------IsAvilableCondition--------------
    public bool IsAvilableCondition
    {
        get
        {
            if (ViewState["IsAvilableCondition"] != null)
                return (bool)ViewState["IsAvilableCondition"];
            else
                return false;
        }
        set { ViewState["IsAvilableCondition"] = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------IsActive--------------
    public bool IsActive
    {
        get
        {
            if (ViewState["IsActive"] != null)
                return (bool)ViewState["IsActive"];
            else
                return false;
        }
        set { ViewState["IsActive"] = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------NotSeenCondition--------------
    public bool NotSeenCondition
    {
        get
        {
            if (ViewState["NotSeenCondition"] != null)
                return (bool)ViewState["NotSeenCondition"];
            else
                return false;
        }
        set { ViewState["NotSeenCondition"] = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------OwnerID--------------
    private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
    public Guid OwnerID
    {
        get { return _OwnerID; }
        set { _OwnerID = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------PageFile--------------
    private string _PageFile;
    public string PageFile
    {
        get { return _PageFile; }
        set { _PageFile = value; }
    }
    //------------------------------------------
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
            //SiteOptions.CheckModuleWithHandling(Resources.SiteOptions.HasComments, UsersTypes.Admin);
            PagerManager.PrepareAdminPager(pager);
            pager.Visible = false;
            HandleOptionalControls();
            LoadData();
        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------HandleOptionalControls---------------
    //-----------------------------------------------
    //HandleOptionalControls
    //-----------------------------------------------
    protected void HandleOptionalControls()
    {
        #region ------------------Languages Handling---------------------
        //Languages Handling
        if (SiteSettings.Languages_HasMultiLanguages)
            SiteSettings.BuildDropDownListForDefaultPage(ddlLanguages);
        else
            trLanguages.Visible = false;
        #endregion
        //-----------------------------------

    }
    //-----------------------------------------------
    #endregion

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    private void LoadData()
    {
        pager.PageSize = SiteSettings.Site_AdminPageSize;
        int totalRecords = 0;
        int itemID = -1;
        if (MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
        {
            itemID = Convert.ToInt32(Request.QueryString["id"]);
        }
        //--------------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------------------------------------
        List<ItemsCommentsEntity> commentsList = ItemsCommentsFactory.GetAll(itemID, langID, ModuleTypeID, IsAvilableCondition, IsActive, NotSeenCondition, pager.CurrentPage, pager.PageSize, out totalRecords, OwnerID);
        if (commentsList != null && commentsList.Count > 0)
        {
            dgComments.DataSource = commentsList;
            dgComments.DataKeyField = "CommentID";
            dgComments.AllowPaging = false;
            pager.Visible = true;
            pager.TotalRecords = totalRecords;
            dgComments.DataBind();
            dgComments.Visible = true;
            //-------------------------------------------------------------------------------
            //Security Premession
            //--------------------------
            ZecurityManager.HideGridColumn(dgComments, CommandName.Delete, dgComments.Columns.Count - 1);
            ZecurityManager.HideGridColumn(dgComments, CommandName.Edit, dgComments.Columns.Count - 2);
            /*End Secu*/
            //-------------------------------------------------------------------------------
        }
        else
        {
            dgComments.Visible = false;
            pager.Visible = false;
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.ThereIsNoData;
        }
    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgComments_ItemDataBound--------------
    //---------------------------------------------------------
    //dgComments_ItemDataBound
    //---------------------------------------------------------
    protected void dgComments_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
            lbtnDelete.AlternateText = Resources.AdminText.Delete;
            #region ---------Index-------
            //Set Index
            int previousRowsCount = (pager.CurrentPage - 1) * pager.PageSize;
            int currentRow = e.Item.ItemIndex + 1;
            e.Item.Cells[0].Text = (previousRowsCount + currentRow).ToString();
            #endregion
        }
    }
    //--------------------------------------------------------
    #endregion

    #region --------------Pager_PageIndexChang--------------
    //---------------------------------------------------------
    //Pager_PageIndexChang
    //---------------------------------------------------------
    protected void Pager_PageIndexChang()
    {
        LoadData();
    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgComments_DeleteCommand--------------
    //---------------------------------------------------------
    //dgComments_DeleteCommand
    //---------------------------------------------------------
    protected void dgComments_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        int commentID = Convert.ToInt32(dgComments.DataKeys[e.Item.ItemIndex]);
        ItemsCommentsEntity comments = ItemsCommentsFactory.GetObject(commentID);
        ExecuteCommandStatus status = ItemsCommentsFactory.Delete(commentID);
        if (status == ExecuteCommandStatus.Done)
        {
            lblResult.CssClass = "lblResult_Done";
            lblResult.Text = Resources.AdminText.DeletingOprationDone;
            //if one item in datagrid
            if (dgComments.Items.Count == 1)
            {
                --pager.CurrentPage;
            }
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
    protected void dgComments_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        if (e.CommandName == "Activate")
        {
            int commentID = Convert.ToInt32(dgComments.DataKeys[e.Item.ItemIndex]);
            ExecuteCommandStatus status = ItemsCommentsFactory.ActivateComment(commentID);
            if (status == ExecuteCommandStatus.Done)
            {
                LoadData();
            }
        }
    }

    //--------------------------------------------------------------------------
    protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
    //--------------------------------------------------------------------------
}

