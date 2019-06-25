using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using System.Collections;
using DCCMSNameSpace.Zecurity;

public partial class AdminCP__UserControls_Advertisments_GetAll : System.Web.UI.UserControl
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
    #region --------------PlaceType--------------
    private AdvPlaceTypes _PlaceType = AdvPlaceTypes.MasterWebSite;
    public AdvPlaceTypes PlaceType
    {
        get { return _PlaceType; }
        set { _PlaceType = value; }
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



    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {
            Load_ddlAdvPlaces();
            if (pager != null)
            {
                PagerManager.PrepareAdminPager(pager);
                pager.Visible = false;
            }
            HandelControls();
            LoadData();
        }

    }
    #endregion

    //-----------------------------------------------
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
    }
    #endregion

    #region --------------Load_ddlAdvPlaces()--------------
    //---------------------------------------------------------
    //Load_ddlAdvPlaces
    //---------------------------------------------------------
    protected void Load_ddlAdvPlaces()
    {
        List<AdvPlacesEntity> AdvPlacesList = AdvPlacesFactory.GetAll(PlaceType);
        OurDropDownList.LoadDropDownList<AdvPlacesEntity>(AdvPlacesList, ddlAdvPlaces, "Title", "PlaceID", true);
    }
    //--------------------------------------------------------
    #endregion

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    protected void LoadData()
    {
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------------------------------------
        int palceID = Convert.ToInt32(ddlAdvPlaces.SelectedValue);
        List<AdvertismentsEntity> AdvertismentsList = AdvertismentsFactory.GetAll(langID, palceID, OwnerID, false, pager.CurrentPage, PageSize, out totalRecords);
        LoadGrid(AdvertismentsList, "AdvertiseID");
        //-------------------------------------------------------------------------------
        //Security Premession
        //--------------------------
        //Check Edit permission
        if (!ZecurityManager.UserCanExecuteCommand(CommandName.Edit))
            dgControl.Columns[dgControl.Columns.Count - 2].Visible = false;
        //Check Delete permission
        if (!ZecurityManager.UserCanExecuteCommand(CommandName.Delete))
            dgControl.Columns[dgControl.Columns.Count - 1].Visible = false;
        //-------------------------------------------------------------------------------
    }
    //--------------------------------------------------------
    #endregion

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
            lblResult.Text = Resources.AdminText.ThereIsNoData;
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
            if (((int)dgControl.DataKeys[e.Item.ItemIndex]) == 45)
            { lbtnDelete.Visible = false; }
            else
            {
                lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
                lbtnDelete.AlternateText = Resources.AdminText.Delete;
            }
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
            lblResult.Text = Resources.AdminText.DeletingOprationFaild;
        }
    }
    //--------------------------------------------------------
    #endregion*/

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


    #region --------------DeleteItem--------------

    protected bool DeleteItem(int id)
    {
        return AdvertismentsFactory.Delete(id);
    }
    //--------------------------------------------------------
    #endregion

    //--------------------------------------------------------------------------
    protected void ddlAdvPlaces_SelectedIndexChanged(object sender, EventArgs e)
    {
        pager.CurrentPage = 1;
        LoadData();
    }
    //--------------------------------------------------------------------------
    protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        pager.CurrentPage = 1;
        LoadData();
    }
}