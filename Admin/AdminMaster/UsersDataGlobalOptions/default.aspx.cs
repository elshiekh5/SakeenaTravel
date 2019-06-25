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


public partial class AdminUsersDataGlobalOptions_GetAll : MasterAdminMasterPage
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
            this.Page.Title = "„ÊœÌÊ·«  „” Œœ„Ì «·„Êﬁ⁄";
            
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
        if (sm.SiteUsersDataModulesList != null && sm.SiteUsersDataModulesList.Count > 0)
		{
			dgUsersDataGlobalOptions.DataSource= sm.SiteUsersDataModulesList;
			dgUsersDataGlobalOptions.DataKeyField="ModuleTypeID";
			dgUsersDataGlobalOptions.AllowPaging=false;
			pager.Visible = true;
			pager.TotalRecords = totalRecords;
			dgUsersDataGlobalOptions.DataBind();
			dgUsersDataGlobalOptions.Visible = true;
		}
		else
		{
			dgUsersDataGlobalOptions.Visible=false;
			pager.Visible = false;
			lblResult.ForeColor = Color.Red;
			lblResult.Text = Resources.AdminText.ThereIsNoData;
		}
	}
	//--------------------------------------------------------
	#endregion

	#region --------------dgUsersDataGlobalOptions_ItemDataBound--------------
	//---------------------------------------------------------
	//dgUsersDataGlobalOptions_ItemDataBound
	//---------------------------------------------------------
	protected void dgUsersDataGlobalOptions_ItemDataBound(object source, DataGridItemEventArgs e)
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

	#region --------------dgUsersDataGlobalOptions_DeleteCommand--------------
	//---------------------------------------------------------
	//dgUsersDataGlobalOptions_DeleteCommand
	//---------------------------------------------------------
	protected void dgUsersDataGlobalOptions_DeleteCommand(object source, DataGridCommandEventArgs e)
	{
        //-----------------------------------------------------------------------------------
        int moduleID = Convert.ToInt32(dgUsersDataGlobalOptions.DataKeys[e.Item.ItemIndex]);
        if (SiteModulesManager.Instance.DeleteModule(moduleID))
        {
            lblResult.ForeColor = Color.Blue;
            lblResult.Text = Resources.AdminText.DeletingOprationDone;
            //if one item in datagrid
            if (dgUsersDataGlobalOptions.Items.Count == 1)
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


    #region --------------dgUsersDataGlobalOptions_EditCommand--------------
    //---------------------------------------------------------
    //dgUsersDataGlobalOptions_EditCommand
    //---------------------------------------------------------
    protected void dgUsersDataGlobalOptions_EditCommand(object source, DataGridCommandEventArgs e)
    {
        ImageButton lbtnUserActivation = (ImageButton)e.Item.FindControl("lbtnUserActivation");
        int moduleTypeID = (int)dgUsersDataGlobalOptions.DataKeys[e.Item.ItemIndex];
        UsersDataGlobalOptions usersDataGlobalOptions = UsersDataGlobalOptions.GetType(moduleTypeID);

        SiteModulesManager sm = SiteModulesManager.Instance;
        if (usersDataGlobalOptions.IsAvailabe)
        {
            //-----------------------------------------------------------------------
            usersDataGlobalOptions.IsAvailabe = false;
            sm.SaveModule(usersDataGlobalOptions);
            //-----------------------------------------------------------------------
            lblResult.CssClass = "operation_error";
            lblResult.Text = " „ ≈·€«¡ «· ›⁄Ì·";
            lbtnUserActivation.ImageUrl = "/Content/images/Boolean/false.gif";
        }
        else
        {
            //-----------------------------------------------------------------------
            usersDataGlobalOptions.IsAvailabe = true;
            sm.SaveModule(usersDataGlobalOptions);
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
