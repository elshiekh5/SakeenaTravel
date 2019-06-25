using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;


public partial class App_Controls_ItemCategories_Admin_All : System.Web.UI.UserControl
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
    int categoriesDepth;
    DataTable dtSource = null;
    DataTable tempDataTable;
    string parent;
    string child;
    string text;
    ItemsModulesOptions currentModule;
    protected void Page_Load(object sender, EventArgs e)
    {
        currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
        if (!IsPostBack)
        {
            HandleOptionalControls();
            LoadData();
        }
    }
    //---------------------------------------------------------------------------

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

    //---------------------------------------------------------------------------
    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    private void LoadData()
    {
        //--------------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------------------------------------
        dtSource = ItemCategoriesFactory.GetAllInDataTable(ModuleTypeID, langID, false,OwnerID);
        if (dtSource != null && dtSource.Rows.Count > 0)
        {
            categoriesDepth = currentModule.CategoryLevel;
            parent = "ParentID";
            child = "CategoryID";
            text = "Title";
            BuildList();

            dgItemCategories.DataSource = tempDataTable;
            dgItemCategories.DataKeyField = "CategoryID";
            dgItemCategories.AllowPaging = false;
            dgItemCategories.DataBind();
            dgItemCategories.Visible = true;
            //-------------------------------------------------------------------------------
            //Security Premession
            //--------------------------
            ZecurityManager.HideGridColumn(dgItemCategories, CommandName.Delete, dgItemCategories.Columns.Count - 1);
            ZecurityManager.HideGridColumn(dgItemCategories, CommandName.Edit, dgItemCategories.Columns.Count - 2);
            /*End Secu*/
            //-------------------------------------------------------------------------------

        }
        else
        {
            dgItemCategories.Visible = false;
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.ThereIsNoData;
        }
    }
    //--------------------------------------------------------
    #endregion
    
    //--------------------------------------------------------------------------------
    public void DataBind( int depth, DataTable dtSource, string parent, string child, string text)
    {
        
    }
    //--------------------------------------------------------------------------------
    public void BuildList()
    {
        string name = "";
        DataSet ds = new DataSet();
        ds.Tables.Add(dtSource);
        tempDataTable = dtSource.Clone();
        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (Convert.ToInt32(dbRow[parent]) == 0)
                dbRow[parent] = DBNull.Value;
        }
        ds.Relations.Add("ParentChildRelashion", ds.Tables[0].Columns[child], ds.Tables[0].Columns[parent]);

        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (dbRow[parent] == DBNull.Value || Convert.ToInt32(dbRow[parent]) == 0)
            {
                name = dbRow[text].ToString();
               // ddlControl.Items.Add(new ListItem(name, dbRow[child].ToString()));
                AddRowInTempTable(dbRow, name);
                PopulateItem(dbRow, 1);
            }
        }
    }
    //--------------------------------------------------------------------------------
    private void PopulateItem( DataRow dbRow, int ParentDepth)
    {
        if (categoriesDepth == -1 || ParentDepth < categoriesDepth)
        {
            string name;
            
            foreach (DataRow childRow in dbRow.GetChildRows("ParentChildRelashion"))
            {
                name = GetDepth(ParentDepth) + childRow[text];
                AddRowInTempTable(childRow, name);
                PopulateItem(childRow, ParentDepth + 1);
            }

        }
    }
    //--------------------------------------------------------------------------------
    protected void AddRowInTempTable(DataRow drsource,string name)
    {
        DataRow drTemp = tempDataTable.NewRow();
        for (int i = 0; i < dtSource.Columns.Count; i++)
        {
            drTemp[i] = drsource[i];
        }
        drTemp[text] = name;
        tempDataTable.Rows.Add(drTemp);
    }
    //--------------------------------------------------------------------------------
    private string GetDepth(int ParentDepth)
    {
        string space = "";
        for (int i = 0; i < ParentDepth; i++)
        {
            space += "/__";
            //space += "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        }
        return space + "";
    }
    //--------------------------------------------------------------------------------

    #region --------------dgItemCategories_DeleteCommand--------------
    //---------------------------------------------------------
    //dgItemCategories_DeleteCommand
    //---------------------------------------------------------
    protected void dgItemCategories_DeleteCommand(object source, DataGridCommandEventArgs e)
    {

        //Check Delete permission
        //-------------------------------------------------------------------------------

        int categoryID = Convert.ToInt32(dgItemCategories.DataKeys[e.Item.ItemIndex]);

        bool status = ItemCategoriesFactory.Delete(categoryID);
        if (status)
        {
            lblResult.CssClass = "lblResult_Done";
            lblResult.Text = Resources.AdminText.DeletingOprationDone;
            //if one item in datagrid
            /*if (dgItemCategories.Items.Count == 1)
            {
                --pager.CurrentPage;
            }*/
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

    #region --------------dgItemCategories_ItemDataBound--------------
    //---------------------------------------------------------
    //dgItemCategories_ItemDataBound
    //---------------------------------------------------------
    protected void dgItemCategories_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
            lbtnDelete.AlternateText = Resources.AdminText.Delete;
            #region ---------Index-------
            //Set Index
            int previousRowsCount  = 0;//(pager.CurrentPage - 1) * pager.PageSize;
            int currentRow = e.Item.ItemIndex + 1;
            e.Item.Cells[0].Text = (previousRowsCount + currentRow).ToString();
            #endregion
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

}
