using System;
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
using MoversFW;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for AdminDefaultPage
    /// </summary>
    public class AdminDefaultPage : AdminMasterPage
    {
        //-----------------------------
        //PageSize
        //-----------------------------
        private int pageSize = SiteSettings.Site_AdminPageSize;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        //----------------------------
        //-----------------------------
        //TotlaRecords
        //-----------------------------
        protected int totalRecords = 0;
        //----------------------------
        DataGrid dgControl;
        Label lblResult;
        OurPager pager;
        protected virtual void LoadData() { }
        //----------------------------
        protected virtual bool DeleteItem(int id)
        { return false; }
        //----------------------------
        //-----------------------------------------------
        protected void FirstLoad(DataGrid dgControl, OurPager pager, Label lblResult)
        {
            //----------------------------------------
            //LoadControls
            this.dgControl = dgControl;
            this.lblResult = lblResult;
            this.pager = pager;
            //----------------------------------------
            lblResult.Text = "";
            if (!IsPostBack)
            {
                if (pager != null)
                {
                    PagerManager.PrepareAdminPager(pager);
                    pager.Visible = false;
                }
                LoadData();
            }
        }
        //-----------------------------------------------
        #region --------------LoadGrid--------------
        //---------------------------------------------------------
        //LoadGrid
        //---------------------------------------------------------
        protected void LoadGrid(IList list, string dataKeyField)
        {

            if (pager != null) pager.PageSize = PageSize;
            if (list != null && list.Count > 0)
            {
                dgControl.DataSource = list;
                dgControl.DataKeyField = dataKeyField;
                dgControl.AllowPaging = false;
                if (pager != null)
                {
                    pager.Visible = true;
                    pager.TotalRecords = totalRecords;
                }
                dgControl.DataBind();
                dgControl.Visible = true;
            }
            else
            {
                dgControl.Visible = false;
                if (pager != null)
                    pager.Visible = false;
                lblResult.CssClass = "operation_error";
                lblResult.Text = DynamicResource.GetText("AdminText","ThereIsNoData");
            }
        }
        //--------------------------------------------------------
        #endregion

        #region --------------dgControl_ItemDataBound--------------
        //---------------------------------------------------------
        //dgControl_ItemDataBound
        //---------------------------------------------------------
        public void dgControl_ItemDataBound(object source, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
                lbtnDelete.Attributes.Add("onclick", "return confirm('" + DynamicResource.GetText("AdminText","DeleteActivation") + "')");
                lbtnDelete.AlternateText = DynamicResource.GetText("AdminText","Delete");
                #region ---------Index-------
                //Set Index
                int previousRowsCount = 0;
                if (pager != null)
                    previousRowsCount = (pager.CurrentPage - 1) * pager.PageSize;
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
        public void Pager_PageIndexChang()
        {
            LoadData();
        }
        //--------------------------------------------------------
        #endregion

        #region --------------dgControl_DeleteCommand--------------
        //---------------------------------------------------------
        //dgControl_DeleteCommand
        //---------------------------------------------------------
        public void dgControl_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int id = Convert.ToInt32(dgControl.DataKeys[e.Item.ItemIndex]);
            if (DeleteItem(id))
            {
                //if one item in datagrid
                if (dgControl.Items.Count == 1 && pager.CurrentPage > 1)
                {
                    --pager.CurrentPage;
                }
                LoadData();
            }
            else
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = DynamicResource.GetText("AdminText","DeletingOprationFaild");
            }
        }
        //--------------------------------------------------------
        #endregion


        #region --------------Load_ddl()--------------
        //---------------------------------------------------------
        //Load_ddlItemsCategories
        //---------------------------------------------------------
        protected void Load_ddlItemsCategories(DropDownList dl, IList list, string dataTextField, string dataValueField)
        {
            if (list != null && list.Count > 0)
            {
                dl.DataSource = list;
                dl.DataTextField = dataTextField;
                dl.DataValueField = dataValueField;
                dl.DataBind();
                dl.Items.Insert(0, new ListItem(DynamicResource.GetText("AdminText","Choose"), "-1"));
                dl.Enabled = true;
            }
            else
            {
                dl.Items.Clear();
                dl.Items.Insert(0, new ListItem(DynamicResource.GetText("AdminText","ThereIsNoData"), "-1"));
                dl.Enabled = false;
            }
        }
        //--------------------------------------------------------
        #endregion
    }
    public class AdminDefaultUserControl : UserControl
    {
        //-----------------------------
        //PageSize
        //-----------------------------
        private int pageSize = SiteSettings.Site_AdminPageSize;
        public int PageSize
        {
            get { return pageSize; }
            set { pageSize = value; }
        }
        //----------------------------
        //-----------------------------
        //TotlaRecords
        //-----------------------------
        protected int totalRecords = 0;
        //----------------------------
        DataGrid dgControl;
        Label lblResult;
        OurPager pager;
        protected virtual void LoadData() { }
        //----------------------------
        protected virtual bool DeleteItem(int id)
        { return false; }
        //----------------------------
        //-----------------------------------------------
        protected void FirstLoad(DataGrid dgControl, OurPager pager, Label lblResult)
        {
            //----------------------------------------
            //LoadControls
            this.dgControl = dgControl;
            this.lblResult = lblResult;
            this.pager = pager;
            //----------------------------------------
            lblResult.Text = "";
            if (!IsPostBack)
            {
                if (pager != null)
                {
                    PagerManager.PrepareAdminPager(pager);
                    pager.Visible = false;
                }
                LoadData();
            }
        }
        //-----------------------------------------------
        #region --------------LoadGrid--------------
        //---------------------------------------------------------
        //LoadGrid
        //---------------------------------------------------------
        protected void LoadGrid(IList list, string dataKeyField)
        {

            if (pager != null) pager.PageSize = PageSize;
            if (list != null && list.Count > 0)
            {
                dgControl.DataSource = list;
                dgControl.DataKeyField = dataKeyField;
                dgControl.AllowPaging = false;
                if (pager != null)
                {
                    pager.Visible = true;
                    pager.TotalRecords = totalRecords;
                }
                dgControl.DataBind();
                dgControl.Visible = true;
            }
            else
            {
                dgControl.Visible = false;
                if (pager != null)
                    pager.Visible = false;
                lblResult.CssClass = "operation_error";
                lblResult.Text = DynamicResource.GetText("AdminText", "ThereIsNoData");
            }
        }
        //--------------------------------------------------------
        #endregion

        #region --------------dgControl_ItemDataBound--------------
        //---------------------------------------------------------
        //dgControl_ItemDataBound
        //---------------------------------------------------------
        public void dgControl_ItemDataBound(object source, DataGridItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
                lbtnDelete.Attributes.Add("onclick", "return confirm('" + DynamicResource.GetText("AdminText", "DeleteActivation") + "')");
                lbtnDelete.AlternateText = DynamicResource.GetText("AdminText", "Delete");
                #region ---------Index-------
                //Set Index
                int previousRowsCount = 0;
                if (pager != null)
                    previousRowsCount = (pager.CurrentPage - 1) * pager.PageSize;
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
        public void Pager_PageIndexChang()
        {
            LoadData();
        }
        //--------------------------------------------------------
        #endregion

        #region --------------dgControl_DeleteCommand--------------
        //---------------------------------------------------------
        //dgControl_DeleteCommand
        //---------------------------------------------------------
        public void dgControl_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            int id = Convert.ToInt32(dgControl.DataKeys[e.Item.ItemIndex]);
            if (DeleteItem(id))
            {
                //if one item in datagrid
                if (dgControl.Items.Count == 1 && pager.CurrentPage > 1)
                {
                    --pager.CurrentPage;
                }
                LoadData();
            }
            else
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = DynamicResource.GetText("AdminText", "DeletingOprationFaild");
            }
        }
        //--------------------------------------------------------
        #endregion


        #region --------------Load_ddl()--------------
        //---------------------------------------------------------
        //Load_ddlItemsCategories
        //---------------------------------------------------------
        protected void Load_ddlItemsCategories(DropDownList dl, IList list, string dataTextField, string dataValueField)
        {
            if (list != null && list.Count > 0)
            {
                dl.DataSource = list;
                dl.DataTextField = dataTextField;
                dl.DataValueField = dataValueField;
                dl.DataBind();
                dl.Items.Insert(0, new ListItem(DynamicResource.GetText("AdminText", "Choose"), "-1"));
                dl.Enabled = true;
            }
            else
            {
                dl.Items.Clear();
                dl.Items.Insert(0, new ListItem(DynamicResource.GetText("AdminText", "ThereIsNoData"), "-1"));
                dl.Enabled = false;
            }
        }
        //--------------------------------------------------------
        #endregion
    }

    public class MasterAdminDefaultPage : AdminDefaultPage
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            this.Page.MasterPageFile = "~/AdminMaster/MasterAdmin.master";
        }
    }
}
