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
using System.IO;

public partial class Admin_Modules_ELS_UserControls_UsersData_SiteUsers : System.Web.UI.UserControl
{
    #region --------------UserRole--------------
    private string _UserRole = "";
    public string UserRole
    {
        get { return _UserRole; }
        set { _UserRole = value; }
    }
    //------------------------------------------
    #endregion
    
    #region --------------ViewUpdate--------------
    private bool _ViewUpdate = false;
    public bool ViewUpdate
    {
        get { return _ViewUpdate; }
        set { _ViewUpdate = value; }
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

    //-------------------------------------------------------
    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion
    //-------------------------------------------------------
    UsersDataGlobalOptions currentModule;
    //-------------------------------------------------------
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        currentModule = UsersDataGlobalOptions.GetType(ModuleTypeID);
        lblResult.Text = "";
        if (!IsPostBack)
        {
            PagerManager.PrepareAdminPager(pager);
            pager.Visible = false;
            HandelControls();
            SetTexts();
            LoadData();
        }
    }
    //-----------------------------------------------
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
        #region ------------------Type Handling---------------------
        //Type Handling
        if (currentModule.CategoryLevel!=0)
            LoadCategories();
        else
            trCategoryID.Visible = false;
        #endregion
        trExport.Visible = currentModule.HasExportData;

    }
    #endregion

    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
       // dgUsersData.Columns[2].HeaderText = DynamicResource.GetUsersDataModuleText(currentModule, "E");
        lblCategoryID.Text = DynamicResource.GetUsersDataModuleText(currentModule, "CategoryID");
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadCategories---------------
    //-----------------------------------------------
    //LoadCategories
    //-----------------------------------------------
    private void LoadCategories()
    {
        int categoriesDepth = currentModule.CategoryLevel;//NewsSiteSettings.Instance.CategoriesDepth;
        ParentChildDropDownList n = new ParentChildDropDownList();
        DataTable dtSource = ItemCategoriesFactory.GetAllInDataTable(ModuleTypeID, Languages.Ar, false, OwnerID);
        n.DataBind(ddlCategoryID, categoriesDepth, dtSource, "ParentID", "CategoryID", "Title");
        ddlCategoryID.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
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
        //--------------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------------------------------------
        int categoryID = -1;
        if (currentModule.CategoryLevel!=0)
            categoryID = Convert.ToInt32(ddlCategoryID.SelectedValue);
        //--------------------------------------------------------------------
        List<UsersDataEntity> usersDataList;
        usersDataList = UsersDataFactory.GetAll(ModuleTypeID, categoryID, langID, "", UserRole, pager.CurrentPage, pager.PageSize, out totalRecords, OwnerID,false);
        

        if (usersDataList != null && usersDataList.Count > 0)
        {
            dgUsersData.DataSource = usersDataList;
            dgUsersData.DataKeyField = "UserId";
            dgUsersData.AllowPaging = false;
            pager.Visible = true;
            pager.TotalRecords = totalRecords;
            dgUsersData.DataBind();
            dgUsersData.Visible = true;
            dgUsersData.Columns[dgUsersData.Columns.Count - 2].Visible = ViewUpdate; 
            //-------------------------------------------------------------------------------
            //Security Premession
            //--------------------------
            //Check Delete permission
            if (!ZecurityManager.UserCanExecuteCommand(CommandName.Delete))
                dgUsersData.Columns[dgUsersData.Columns.Count - 1].Visible = false;
            //-------------------------------------------------------------------------------
        }
        else
        {
            dgUsersData.Visible = false;
            pager.Visible = false;
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.ThereIsNoData;
        }
    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgUsersData_ItemDataBound--------------
    //---------------------------------------------------------
    //dgUsersData_ItemDataBound
    //---------------------------------------------------------
    protected void dgUsersData_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
            lbtnDelete.AlternateText = Resources.AdminText.Delete;
            //-----------------------------------------------------
            #region ---------Index-------
            //Set Index
            int previousRowsCount = (pager.CurrentPage - 1) * pager.PageSize;
            int currentRow = e.Item.ItemIndex + 1;
            e.Item.Cells[0].Text = (previousRowsCount + currentRow).ToString();
            #endregion
            //-----------------------------------------------------


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

    #region --------------dgUsersData_DeleteCommand--------------
    //---------------------------------------------------------
    //dgUsersData_DeleteCommand
    //---------------------------------------------------------
    protected void dgUsersData_DeleteCommand(object source, DataGridCommandEventArgs e)
    {

      //-------------------------------------------------------------------------------

        Guid userID = (Guid)dgUsersData.DataKeys[e.Item.ItemIndex];
        UsersDataEntity usersDataObject = UsersDataFactory.GetUsersDataObject(userID,OwnerID);
        if (UsersDataFactory.Delete(userID))
        {
            //------------------------------------------------
            //RegisterInMailList
            if ((currentModule.MailListAutomaticRegistration || (usersDataObject.HasEmailService)) && !string.IsNullOrEmpty(usersDataObject.Email))
                UsersDataFactory.UnRegisterInMailList(usersDataObject);
            //------------------------------------------------
            //------------------------------------------------
            //RegisterInSms
            if ((currentModule.SmsAutomaticRegistration || (usersDataObject.HasSmsService)) && !string.IsNullOrEmpty(usersDataObject.Mobile))
                UsersDataFactory.UnRegisterInSms(usersDataObject);
            //------------------------------------------------
            lblResult.CssClass = "operation_done";
            lblResult.Text = Resources.AdminText.DeletingOprationDone;
            //if one item in datagrid
            if (dgUsersData.Items.Count == 1)
            {
                --pager.CurrentPage;
            }
            LoadData();
            /*
            UserControl Users1 = (UserControl)this.Page.FindControl("Users1");
            Label lblUserCounts = (Label)Users1.FindControl("lblUserCounts");
            lblUserCounts.Text = UsersDataFactory.GetCount().ToString();*/
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.DeletingOprationFaild;
        }
    }
    //--------------------------------------------------------
    #endregion

    protected void dgUsersData_EditCommand(object source, DataGridCommandEventArgs e)
    {
        ImageButton lbtnUserActivation = (ImageButton)e.Item.FindControl("lbtnUserActivation");
        Guid userID = (Guid)dgUsersData.DataKeys[e.Item.ItemIndex];
        MembershipUser user = Membership.GetUser(userID);
        UsersDataEntity UsersDataObject = UsersDataFactory.GetUsersDataObject((Guid)user.ProviderUserKey, OwnerID);
        if (user.IsApproved)
        {
            user.IsApproved = false;
            Membership.UpdateUser(user);
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.ActivationCanceled;
            lbtnUserActivation.ImageUrl = "/Content/images/Boolean/false.gif";
        }
        else
        {
            user.IsApproved = true;
            Membership.UpdateUser(user);
            //------------------------------------------------------------------------
            //Create Sub Site if this user has it-------------------
            UsersDataFactory.ConfigureSubSiteIfExist(UsersDataObject);
            //AddUserRelatedPages
            SubSiteHandler.AddUserRelatedPages(UsersDataObject);
            //------------------------------------------------------------------------
            lblResult.CssClass = "operation_done";
            lblResult.Text = Resources.AdminText.ActivationDone;
            lbtnUserActivation.ImageUrl = "/Content/images/Boolean/True.gif";
        }
    }

    public string GetActivationImage(object isApproved)
    {
        bool _IsApproved = Convert.ToBoolean(isApproved);
        if (_IsApproved)
           return "/Content/images/Boolean/true.gif";
        else
            return "/Content/images/Boolean/false.gif";

    }

    //--------------------------------------------------------------------------
    protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
    //--------------------------------------------------------------------------
    protected void ddlCategoryID_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
    //--------------------------------------------------------------------------
    protected void btnExport_Click(object sender, EventArgs e)
    {
        int catID = -1;
        if(currentModule.CategoryLevel!=0)
            catID = Convert.ToInt32(ddlCategoryID.SelectedValue);
        Response.Redirect("/AdminCP/UsersData/" + currentModule.Identifire + "/Export.aspx?id=" + catID);
    }
}

