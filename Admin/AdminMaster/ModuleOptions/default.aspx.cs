using System;using DCCMSNameSpace;
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


public partial class AdminModuleOptions_GetAll : MasterAdminMasterPage
{
	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
        lblActiveModulesResult.Text = "";
        lblActiveModulesResult.Text = "";
		if(!IsPostBack)
		{
            this.Page.Title = "موديولات العرض";
			LoadData();
		}
	}
	//-----------------------------------------------
	#endregion

    #region --------------LoadData--------------
	//---------------------------------------------------------
	//LoadData
	//---------------------------------------------------------
	private void LoadData()
	{
        SiteModulesManager sm = SiteModulesManager.Instance;
        if (sm.SiteItemsModulesList != null && sm.SiteItemsModulesList.Count > 0)
        {
            List<ItemsModulesOptions> activeList = new List<ItemsModulesOptions>();
            List<ItemsModulesOptions> inactiveList = new List<ItemsModulesOptions>();
            foreach (ItemsModulesOptions module in sm.SiteItemsModulesList)
            {
                if (module.IsAvailabe)
                {
                    activeList.Add(module);
                }
                else
                {
                    inactiveList.Add(module);
                }
            }
            //-------------------------------------------------
            LoadGrid(dgActiveModuleOptions, lblActiveModulesResult, activeList);
            LoadGrid(dgInActiveModuleOptions, lblInActiveModulesResult, inactiveList);
            //-------------------------------------------------
        }
	}
	//--------------------------------------------------------
	#endregion

    #region --------------LoadGrid--------------
    //---------------------------------------------------------
    //LoadGrid
	//---------------------------------------------------------
	private void LoadGrid(DataGrid dg,Label lblResult,  List<ItemsModulesOptions> modeulesList)
	{
        if (modeulesList != null && modeulesList.Count > 0)
		{
            dg.DataSource = modeulesList;
            dg.DataKeyField = "ModuleTypeID";
            dg.AllowPaging = false;
            dg.DataBind();
            dg.Visible = true;
		}
		else
		{
            dg.Visible = false;
			lblResult.ForeColor = Color.Red;
			lblResult.Text = Resources.AdminText.ThereIsNoData;
		}
	}
	//--------------------------------------------------------
	#endregion

    #region --------------dgActiveModuleOptions Events handlers--------------
    //---------------------------------------------------------


    #region --------------dgActiveModuleOptions_ItemDataBound--------------
    //---------------------------------------------------------
    //dgActiveModuleOptions_ItemDataBound
    //---------------------------------------------------------
    protected void dgActiveModuleOptions_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        ItemDataBound(source, e);
    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgActiveModuleOptions_DeleteCommand--------------
    //---------------------------------------------------------
    //dgActiveModuleOptions_DeleteCommand
    //---------------------------------------------------------
    protected void dgActiveModuleOptions_DeleteCommand(object source, DataGridCommandEventArgs e)
    {

        DeleteCommand(dgActiveModuleOptions, lblActiveModulesResult, source, e);

    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgActiveModuleOptions_EditCommand--------------
    //---------------------------------------------------------
    //dgActiveModuleOptions_EditCommand
    //---------------------------------------------------------
    protected void dgActiveModuleOptions_EditCommand(object source, DataGridCommandEventArgs e)
    {
        EditCommand(dgActiveModuleOptions, lblActiveModulesResult, source, e);

    }
    //--------------------------------------------------------
    #endregion

    //---------------------------------------------------------
    #endregion

    #region --------------dgInActiveModuleOptions Events handlers--------------

    //---------------------------------------------------------
    #region --------------dgInActiveModuleOptions_ItemDataBound--------------
    //---------------------------------------------------------
    //dgInActiveModuleOptions_ItemDataBound
    //---------------------------------------------------------
    protected void dgInActiveModuleOptions_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        ItemDataBound(source, e);
    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgInActiveModuleOptions_DeleteCommand--------------
    //---------------------------------------------------------
    //dgInActiveModuleOptions_DeleteCommand
    //---------------------------------------------------------
    protected void dgInActiveModuleOptions_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        DeleteCommand(dgInActiveModuleOptions, lblInActiveModulesResult, source, e);
    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgInActiveModuleOptions_EditCommand--------------
    //---------------------------------------------------------
    //dgInActiveModuleOptions_EditCommand
    //---------------------------------------------------------
    protected void dgInActiveModuleOptions_EditCommand(object source, DataGridCommandEventArgs e)
    {
        EditCommand(dgInActiveModuleOptions, lblInActiveModulesResult, source, e);
    }
    //--------------------------------------------------------
    #endregion

    //---------------------------------------------------------
    #endregion

    #region --------------ItemDataBound--------------
    //---------------------------------------------------------
    //ItemDataBound
    //---------------------------------------------------------
    protected void ItemDataBound(object source, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
            lbtnDelete.AlternateText = Resources.AdminText.Delete;
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

    #region --------------DeleteCommand--------------
    //---------------------------------------------------------
    //DeleteCommand
    //---------------------------------------------------------
    protected void DeleteCommand(DataGrid dg, Label lblResult, object source, DataGridCommandEventArgs e)
    {
        //-----------------------------------------------------------------------------------
        int moduleID = Convert.ToInt32(dg.DataKeys[e.Item.ItemIndex]);
        if (SiteModulesManager.Instance.DeleteModule(moduleID))
        {
            lblResult.ForeColor = Color.Blue;
            lblResult.Text = Resources.AdminText.DeletingOprationDone;

            LoadData();
        }
        else
        {
            lblResult.ForeColor = Color.Red;
            lblResult.Text = Resources.AdminText.DeletingOprationFaild;
        }
        //-----------------------------------------------------------------------------------

    }
    //--------------------------------------------------------
    #endregion

    #region --------------EditCommand--------------
    //---------------------------------------------------------
    //EditCommand
    //---------------------------------------------------------
    protected void EditCommand(DataGrid dg, Label lblResult, object source, DataGridCommandEventArgs e)
    {
        ImageButton lbtnUserActivation = (ImageButton)e.Item.FindControl("lbtnUserActivation");
        int ModuleTypeID = (int)dg.DataKeys[e.Item.ItemIndex];
        ItemsModulesOptions moduleOptions = ItemsModulesOptions.GetType(ModuleTypeID);
        SiteModulesManager sm = SiteModulesManager.Instance;

        if (moduleOptions.IsAvailabe)
        {
            //-----------------------------------------------------------------------
            moduleOptions.IsAvailabe = false;
            sm.SaveModule(moduleOptions);
            //-----------------------------------------------------------------------
            lblResult.CssClass = "operation_error";
            lblResult.Text = "Êã ÅáÛÇÁ ÇáÊÝÚíá";
            lbtnUserActivation.ImageUrl = "/Content/images/Boolean/false.gif";
        }
        else
        {
            //-----------------------------------------------------------------------
            moduleOptions.IsAvailabe = true;
            sm.SaveModule(moduleOptions);
            //-----------------------------------------------------------------------
            lblResult.CssClass = "operation_done";
            lblResult.Text = "Êã ÇáÊÝÚíá";
            lbtnUserActivation.ImageUrl = "/Content/images/Boolean/True.gif";
        }
    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetActivationImage--------------
    //---------------------------------------------------------
    //GetActivationImage
    //---------------------------------------------------------
    public string GetActivationImage(object isApproved)
    {
        bool _IsApproved = Convert.ToBoolean(isApproved);
        if (_IsApproved)
            return "/Content/images/Boolean/true.gif";
        else
            return "/Content/images/Boolean/false.gif";

    }
    //--------------------------------------------------------
    #endregion

}
