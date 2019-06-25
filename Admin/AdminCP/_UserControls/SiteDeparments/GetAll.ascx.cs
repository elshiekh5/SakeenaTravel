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
using System.Drawing;
using System.Collections.Generic;


public partial class App_Controls_SiteDeparments_Admin_All : System.Web.UI.UserControl
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

    #region --------------ParentID--------------
    private int _ParentID = -1;
    public int ParentID
    {
        get { return _ParentID; }
        set { _ParentID = value; }
    }
    //------------------------------------------
    #endregion

    int siteDepartmentDepth;
    DataTable dtSource = null;
    DataTable tempDataTable;
    string parent;
    string child;
    string text;
    SiteDeparmentsOptions currentModule;
    protected void Page_Load(object sender, EventArgs e)
    {
        currentModule = SiteDeparmentsOptions.GetType(ModuleTypeID);
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    private void LoadData()
    {
        dtSource = SiteDeparmentsFactory.GetInDataTable(ModuleTypeID, ParentID, Languages.Unknowen, false);
        if (dtSource != null && dtSource.Rows.Count > 0)
        {
            siteDepartmentDepth = currentModule.SiteDepartmentsLevel;
            parent = "ParentID";
            child = "DepartmentID";
            text = "Title";
            BuildList();

            dgSiteDeparments.DataSource = tempDataTable;
            dgSiteDeparments.DataKeyField = "DepartmentID";
            dgSiteDeparments.AllowPaging = false;
            dgSiteDeparments.DataBind();
            dgSiteDeparments.Visible = true;
            //-------------------------------------------------------------------------------
            //Security Premession
            //--------------------------
            ZecurityManager.HideGridColumn(dgSiteDeparments, CommandName.Delete, dgSiteDeparments.Columns.Count - 1);
            ZecurityManager.HideGridColumn(dgSiteDeparments, CommandName.Edit, dgSiteDeparments.Columns.Count - 2);
            /*End Secu*/
            //-------------------------------------------------------------------------------
        }
        else
        {
            dgSiteDeparments.Visible = false;
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
        int noneParentID = 0;
        //-----------------------------------------------
        if (ParentID > 0) noneParentID = ParentID;
        //-----------------------------------------------
        string name = "";
        DataSet ds = new DataSet();
        ds.Tables.Add(dtSource);
        tempDataTable = dtSource.Clone();
        foreach (DataRow dbRow in ds.Tables[0].Rows)
        {
            if (Convert.ToInt32(dbRow[parent]) == noneParentID)
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
        if (siteDepartmentDepth == -1 || ParentDepth < siteDepartmentDepth)
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

    #region --------------dgSiteDeparments_DeleteCommand--------------
    //---------------------------------------------------------
    //dgSiteDeparments_DeleteCommand
    //---------------------------------------------------------
    protected void dgSiteDeparments_DeleteCommand(object source, DataGridCommandEventArgs e)
    {

        //Check Delete permission
        //-------------------------------------------------------------------------------

        int departmentID = Convert.ToInt32(dgSiteDeparments.DataKeys[e.Item.ItemIndex]);

        bool status = SiteDeparmentsFactory.Delete(departmentID);
        if (status)
        {
            lblResult.CssClass = "lblResult_Done";
            lblResult.Text = Resources.AdminText.DeletingOprationDone;
            //if one item in datagrid
            /*if (dgSiteDeparments.Items.Count == 1)
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

    int itemIndex = 0;
    #region --------------dgSiteDeparments_ItemDataBound--------------
    //---------------------------------------------------------
    //dgSiteDeparments_ItemDataBound
    //---------------------------------------------------------
    protected void dgSiteDeparments_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
            lbtnDelete.AlternateText = Resources.AdminText.Delete;
            #region ---------Index-------
            if (tempDataTable.Rows[e.Item.ItemIndex][parent] == DBNull.Value)
            {
                e.Item.Cells[0].Text = (++itemIndex).ToString();
                e.Item.BackColor = Color.FromName("#4FBAE7");//Color.BurlyWood; //Color.Bisque;
                e.Item.BorderColor = Color.FromName("#fff");//Color.White;
                e.Item.BorderWidth = 1;
            }

            #endregion
        }
    }
    //--------------------------------------------------------
    #endregion
}

