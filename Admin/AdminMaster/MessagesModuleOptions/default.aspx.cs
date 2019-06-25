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


public partial class AdminMessagesModuleOptions_GetAll : MasterAdminMasterPage
{
	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
		lblResult.Text="";
		if(!IsPostBack)
		{
            this.Page.Title = "„ÊœÌÊ·«  «·—”«∆·";
            PagerManager.PrepareAdminPager(pager);
			pager.Visible = false;
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
		pager.PageSize = 1000;
		int totalRecords = 0;
        SiteModulesManager sm = SiteModulesManager.Instance;
        if (sm.SiteMessagesModulesList != null && sm.SiteMessagesModulesList.Count > 0)
		{
            dgMessagesModuleOptions.DataSource = sm.SiteMessagesModulesList;
			dgMessagesModuleOptions.DataKeyField="ModuleTypeID";
			dgMessagesModuleOptions.AllowPaging=false;
			pager.Visible = true;
			pager.TotalRecords = totalRecords;
			dgMessagesModuleOptions.DataBind();
			dgMessagesModuleOptions.Visible = true;
		}
		else
		{
			dgMessagesModuleOptions.Visible=false;
			pager.Visible = false;
			lblResult.ForeColor = Color.Red;
			lblResult.Text = Resources.AdminText.ThereIsNoData;
		}
	}
	//--------------------------------------------------------
	#endregion

	#region --------------dgMessagesModuleOptions_ItemDataBound--------------
	//---------------------------------------------------------
	//dgMessagesModuleOptions_ItemDataBound
	//---------------------------------------------------------
	protected void dgMessagesModuleOptions_ItemDataBound(object source, DataGridItemEventArgs e)
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

	#region --------------dgMessagesModuleOptions_DeleteCommand--------------
	//---------------------------------------------------------
	//dgMessagesModuleOptions_DeleteCommand
	//---------------------------------------------------------
	protected void dgMessagesModuleOptions_DeleteCommand(object source, DataGridCommandEventArgs e)
	{
        //-----------------------------------------------------------------------------------
        int moduleID = Convert.ToInt32(dgMessagesModuleOptions.DataKeys[e.Item.ItemIndex]);
        if (SiteModulesManager.Instance.DeleteModule(moduleID))
        {
            lblResult.ForeColor = Color.Blue;
            lblResult.Text = Resources.AdminText.DeletingOprationDone;
            //if one item in datagrid
            if (dgMessagesModuleOptions.Items.Count == 1)
            {
                --pager.CurrentPage;
            }
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

    #region --------------dgMessagesModuleOptions_EditCommand--------------
    //---------------------------------------------------------
    //dgMessagesModuleOptions_EditCommand
    //---------------------------------------------------------
    protected void dgMessagesModuleOptions_EditCommand(object source, DataGridCommandEventArgs e)
    {
        ImageButton lbtnUserActivation = (ImageButton)e.Item.FindControl("lbtnUserActivation");
        int ModuleTypeID = (int)dgMessagesModuleOptions.DataKeys[e.Item.ItemIndex];
        MessagesModuleOptions messagesModuleOptions = MessagesModuleOptions.GetType(ModuleTypeID);
        SiteModulesManager sm = SiteModulesManager.Instance;

        if (messagesModuleOptions.IsAvailabe)
        {
            //-----------------------------------------------------------------------
            messagesModuleOptions.IsAvailabe = false;
            sm.SaveModule(messagesModuleOptions);
            //-----------------------------------------------------------------------
            lblResult.CssClass = "operation_error";
            lblResult.Text = " „ ≈·€«¡ «· ›⁄Ì·";
            lbtnUserActivation.ImageUrl = "/Content/images/Boolean/false.gif";
        }
        else
        {
            //-----------------------------------------------------------------------
            messagesModuleOptions.IsAvailabe = true;
            sm.SaveModule(messagesModuleOptions);
            //-----------------------------------------------------------------------
            lblResult.CssClass = "operation_done";
            lblResult.Text = " „ «· ›⁄Ì·";
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
