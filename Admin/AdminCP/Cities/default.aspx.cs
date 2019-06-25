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

public partial class AdminCities_GetAll : AdminMasterPage
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
            this.Page.Title = Resources.Cities.CitiesModuleTitle;
            PagerManager.PrepareAdminPager(pager);
			pager.Visible = false;
            HandelControls();
            LoadCountries();
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
        BoundColumn  name =(BoundColumn)dgCities.Columns[1];
        if (SiteSettings.Languages_HasArabicLanguages)
            {
                name.DataField = "NameAr";
                
            }
            else
            {
                name.DataField = "NameEn";
                
            }
        #endregion
    }
    #endregion
    //------------------------------------------------------------
    protected void LoadCountries()
    {
        List<SystemCountriesEntity> countriesList = SystemCountriesFactory.GetAll();
        string DataTextField = "country_ar";
        //Languages lang = SiteSettings.GetCurrentLanguage();
        //if (lang != Languages.Ar)
        //    DataTextField = "country";
        OurDropDownList.LoadDropDownList(countriesList, ddlCountries, DataTextField, "id", true);
    }
    //------------------------------------------------------------

	#region --------------LoadData--------------
	//---------------------------------------------------------
	//LoadData
	//---------------------------------------------------------
	private void LoadData()
	{
        int countryID = Convert.ToInt32(ddlCountries.SelectedValue);
        pager.PageSize = 30;//SiteSettings.Instance.AdminPageSize;
		int totalRecords = 0;
        List<CitiesEntity> citiesList = CitiesFactory.GetAllWithPager(countryID,pager.CurrentPage, pager.PageSize, out totalRecords);
		if(citiesList!=null&&citiesList.Count >0)
		{
			dgCities.DataSource= citiesList;
			dgCities.DataKeyField="CityID";
			dgCities.AllowPaging=false;
			pager.Visible = true;
			pager.TotalRecords = totalRecords;
			dgCities.DataBind();
			dgCities.Visible = true;
            //Check Edit permission
            if (!ZecurityManager.UserCanExecuteCommand(CommandName.Edit))
                dgCities.Columns[dgCities.Columns.Count - 2].Visible = false;
            //Check Delete permission
            if (!ZecurityManager.UserCanExecuteCommand(CommandName.Delete))
                dgCities.Columns[dgCities.Columns.Count - 1].Visible = false;
            //-------------------------------------------------------------------------------

		}
		else
		{
			dgCities.Visible=false;
			pager.Visible = false;
			lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.ThereIsNoData;
		}
	}
	//--------------------------------------------------------
	#endregion

	#region --------------dgCities_ItemDataBound--------------
	//---------------------------------------------------------
	//dgCities_ItemDataBound
	//---------------------------------------------------------
	protected void dgCities_ItemDataBound(object source, DataGridItemEventArgs e)
	{
		if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
		{
			ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
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

	#region --------------dgCities_DeleteCommand--------------
	//---------------------------------------------------------
	//dgCities_DeleteCommand
	//---------------------------------------------------------
	protected void dgCities_DeleteCommand(object source, DataGridCommandEventArgs e)
	{
		int cityID = Convert.ToInt32(dgCities.DataKeys[e.Item.ItemIndex]);
		CitiesEntity cities =CitiesFactory.GetObject(cityID);
		if(CitiesFactory.Delete(cityID))
		{
			lblResult.ForeColor = Color.Blue;
            lblResult.Text = Resources.AdminText.DeletingOprationDone;
			//if one item in datagrid
			if (dgCities.Items.Count == 1)
			{
				--pager.CurrentPage;
			}
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
    protected void ddlCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }
}
