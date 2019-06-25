using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;


public partial class Items_GetAll : System.Web.UI.UserControl
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

    #region --------------OwnerID--------------
    private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
    public Guid OwnerID
    {
        get { return _OwnerID; }
        set { _OwnerID = value; }
    }
    //------------------------------------------
    #endregion

    ItemsModulesOptions currentModule;

	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
    {

        currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
        lblResult.Text = "";
		if(!IsPostBack)
		{
			PagerManager.PrepareAdminPager(pager);
			pager.Visible = false;
            HandleOptionalControls();
            SetTexts();
			LoadData();
            dgItems.Columns[1].Visible = currentModule.HasTitle;
            if(currentModule.ModuleType!= ModuleTypes.Gallery)
                dgItems.Columns[2].Visible = false;//Photo
            dgItems.Columns[4].Visible = currentModule.HasIsAvailable;//Photo
            dgItems.Columns[5].Visible = currentModule.HasMultiPhotos;
            dgItems.Columns[6].Visible = currentModule.HasComments;
            dgItems.Columns[7].Visible = currentModule.HasComments;
            dgItems.Columns[8].Visible = currentModule.HasMessages;
            dgItems.Columns[9].Visible = currentModule.HasMessages;
        }
	}
	//-----------------------------------------------
	#endregion

    #region ---------------Load_ddlItemCategories---------------
    //-----------------------------------------------
    //Load_ddlItemCategories
    //-----------------------------------------------
    private void Load_ddlItemCategories()
    {
        int categoriesDepth = currentModule.CategoryLevel;//NewsSiteSettings.Instance.CategoriesDepth;
        ParentChildDropDownList n = new ParentChildDropDownList();
        DataTable dtSource = ItemCategoriesFactory.GetAllInDataTable(ModuleTypeID, Languages.Unknowen, false, OwnerID);
        n.DataBind(ddlItemCategories, categoriesDepth, dtSource, "ParentID", "CategoryID", "Title");
        ddlItemCategories.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
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
        //HasCategoryID
        if (currentModule.CategoryLevel != 0)
        {
            trCategoryID.Visible = true;
            Load_ddlItemCategories();
        }
        else
        {
            trCategoryID.Visible = false;
        }


    }
    //-----------------------------------------------
    #endregion

    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
        dgItems.Columns[1].HeaderText = DynamicResource.GetText(currentModule, "Title");
        dgItems.Columns[2].HeaderText = DynamicResource.GetText(currentModule, "PhotoExtension");
        dgItems.Columns[8].HeaderText = DynamicResource.GetText(currentModule, "RequestTotalCount");
        dgItems.Columns[9].HeaderText = DynamicResource.GetText(currentModule, "RequestNewCount");
        lblCategoryID.Text = DynamicResource.GetText(currentModule, "CategoryID");
       
    }
    //-----------------------------------------------
    #endregion

    #region --------------LoadData--------------
	//---------------------------------------------------------
	//LoadData
	//---------------------------------------------------------
    private void LoadData()
    {
        
        int categoryID =-1;
        if (currentModule.CategoryLevel > 0)
        {
            categoryID = Convert.ToInt32(ddlItemCategories.SelectedValue);
        }
        LoadGrid(categoryID);
    }
	//--------------------------------------------------------
	#endregion

    #region --------------LoadGrid--------------
    //---------------------------------------------------------
    //LoadGrid
    //---------------------------------------------------------
    private void LoadGrid(int categoryID)
    {
        pager.PageSize = currentModule.PageItemCount_AdminDefault;
        int totalRecords = 0;
        //--------------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------------------------------------
        List<ItemsEntity> itemsList;
        itemsList = ItemsFactory.GetAllForAdmin(ModuleTypeID, langID, categoryID, pager.CurrentPage, pager.PageSize, out totalRecords, OwnerID);
        if (itemsList != null && itemsList.Count > 0)
        {
            dgItems.DataSource = itemsList;
            dgItems.DataKeyField = "ItemID";
            dgItems.AllowPaging = false;
            pager.Visible = true;
            pager.TotalRecords = totalRecords;
            dgItems.DataBind();
            dgItems.Visible = true;
            //-------------------------------------------------------------------------------
            //Security Premession
            //--------------------------
            ZecurityManager.HideGridColumn(dgItems, CommandName.Delete, dgItems.Columns.Count - 1);
            
            ZecurityManager.HideGridColumn(dgItems, CommandName.Edit, dgItems.Columns.Count -2);
            
            /*if (currentModule.ModuleTypeID == 13)
                dgItems.Columns[dgItems.Columns.Count - 1].Visible = false;*/
            /*End Secu*/
            //-------------------------------------------------------------------------------
            
        }
        else
        {
            dgItems.Visible = false;
            pager.Visible = false;
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.ThereIsNoData;
        }
     


    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgItems_ItemDataBound--------------
	//---------------------------------------------------------
	//dgItems_ItemDataBound
	//---------------------------------------------------------
	protected void dgItems_ItemDataBound(object source, DataGridItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
			lbtnDelete.Attributes.Add("onclick", "return confirm('"+Resources.AdminText.DeleteActivation+"')");
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

    #region --------------dgItems_DeleteCommand--------------
	//---------------------------------------------------------
	//dgItems_DeleteCommand
	//---------------------------------------------------------
	protected void dgItems_DeleteCommand(object source, DataGridCommandEventArgs e)
	{
		int itemID = Convert.ToInt32(dgItems.DataKeys[e.Item.ItemIndex]);
		if(ItemsFactory.Delete(itemID))
		{

			lblResult.CssClass = "lblResult_Done";
			lblResult.Text = Resources.AdminText.DeletingOprationDone;
			//if one item in datagrid
			if (dgItems.Items.Count == 1)
			{
				--pager.CurrentPage;
			}
			LoadData();
		}
		else
		{
			lblResult.CssClass = "lblResult_Faild";
			lblResult.Text =Resources.AdminText.DeletingOprationFaild;
		}
	}
	//--------------------------------------------------------
	#endregion

    //--------------------------------------------------------------------------
    protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
    //--------------------------------------------------------------------------
    protected void ddlItemCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        int categoryID = Convert.ToInt32(ddlItemCategories.SelectedValue);
        LoadGrid(categoryID);
    }
    //--------------------------------------------------------------------------
}

