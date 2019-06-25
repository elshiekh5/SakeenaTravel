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
    

    

    int orderID = 0;
	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
    {


        lblResult.Text = "";
		if(!IsPostBack)
		{
            if (orderID <= 0 && MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {
                orderID = Convert.ToInt32(Request.QueryString["id"]);
                SetTexts();
                LoadData();
            }
            else
            {
                Response.Redirect("default.aspx");
            }
			
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
        dgItems.Columns[1].HeaderText = Resources.ItemsOrders.ProductTitle;
        //dgItems.Columns[2].HeaderText = Resources.ItemsOrders.Barcode;
        //dgItems.Columns[3].HeaderText = Resources.ItemsOrders.ByUnit;
       // dgItems.Columns[4].HeaderText = Resources.ItemsOrders.ByCarton;
        dgItems.Columns[5].HeaderText = Resources.ItemsOrders.Quantity;
       
    }
    //-----------------------------------------------
    #endregion

    #region --------------LoadData--------------
	//---------------------------------------------------------
	//LoadData
	//---------------------------------------------------------
    private void LoadData()
    {

        int totalRecords = 0;
        //--------------------------------------------------------------------
        //Languages langID = Languages.Unknowen;
        //if (SiteSettings.Languages_HasMultiLanguages)
        //    langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------------------------------------
        List<ItemsOrdersDetailsModel> itemsList = ItemsOrdersDetailsFactor.Get(orderID);
        if (itemsList != null && itemsList.Count > 0)
        {
            dgItems.DataSource = itemsList;
            dgItems.DataKeyField = "ItemID";
            dgItems.AllowPaging = false;
            dgItems.DataBind();
            dgItems.Visible = true;
            //-------------------------------------------------------------------------------
            //Security Premession
            //--------------------------
            //ZecurityManager.HideGridColumn(dgItems, CommandName.Delete, dgItems.Columns.Count - 1);

            //ZecurityManager.HideGridColumn(dgItems, CommandName.Edit, dgItems.Columns.Count - 2);

            /*if (currentModule.ModuleTypeID == 13)
                dgItems.Columns[dgItems.Columns.Count - 1].Visible = false;*/
            /*End Secu*/
            //-------------------------------------------------------------------------------

        }
        else
        {
            dgItems.Visible = false;
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
		{/*
			ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
			lbtnDelete.Attributes.Add("onclick", "return confirm('"+Resources.AdminText.DeleteActivation+"')");
			lbtnDelete.AlternateText = Resources.AdminText.Delete; */
            #region ---------Index-------
            //Set Index
            int previousRowsCount = 0;
            int currentRow = e.Item.ItemIndex + 1;
            e.Item.Cells[0].Text = (previousRowsCount + currentRow).ToString();
            #endregion
		}
         
	}
	//--------------------------------------------------------
	#endregion

    #region --------------dgItems_DeleteCommand--------------
	//---------------------------------------------------------
	//dgItems_DeleteCommand
	//---------------------------------------------------------
	protected void dgItems_DeleteCommand(object source, DataGridCommandEventArgs e)
	{
        /*
        int ItemID = Convert.ToInt32(dgItems.DataKeys[e.Item.ItemIndex]);
        if (ItemsOrdersFactor.Delete(ItemID))
		{

			lblResult.CssClass = "lblResult_Done";
			lblResult.Text = Resources.AdminText.DeletingOprationDone;
			LoadData();
		}
		else
		{
			lblResult.CssClass = "lblResult_Faild";
			lblResult.Text =Resources.AdminText.DeletingOprationFaild;
		}*/
	}
	//--------------------------------------------------------
	#endregion

    //--------------------------------------------------------------------------
    //protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    LoadData();
    //}
    //--------------------------------------------------------------------------
}

