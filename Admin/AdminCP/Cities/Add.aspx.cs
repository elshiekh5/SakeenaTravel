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

public partial class AdminCities_Create : AdminMasterPage
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
            HandelControls();
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
        if (!SiteSettings.Languages_HasMultiLanguages)
        {
            if (!SiteSettings.Languages_HasArabicLanguages)
            {
                trArabicText.Visible = false;
            }
            else
            {
                trEnglishText.Visible = false;
            }
        }
        #endregion

        trCountryID.Visible = CitiesOptions.HasCountryID;
    }
    #endregion

    #region ---------------LoadCountries---------------
    //-----------------------------------------------
    //LoadCountries
    //-----------------------------------------------
    protected void LoadCountries()
    {
        List<SystemCountriesEntity> countriesList = SystemCountriesFactory.GetAll();
        string DataTextField = "country_ar";
        //Languages lang = SiteSettings.GetCurrentLanguage();
        //if (lang != Languages.Ar)
        //    DataTextField = "country";
        OurDropDownList.LoadDropDownList(countriesList, ddlCountries, DataTextField, "id", true);
    }
    //-----------------------------------------------
    #endregion
    
	#region ---------------LoadData---------------
	//-----------------------------------------------
	//LoadData
	//-----------------------------------------------
	protected void LoadData()
	{
        LoadCountries();
	}
	//-----------------------------------------------
	#endregion
	
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        CitiesEntity cities = new CitiesEntity();
        if (CitiesOptions.HasCountryID)
        cities.CountryID = Convert.ToInt32(ddlCountries.SelectedValue);
        cities.NameAr = txtNameAr.Text;
        cities.NameEn = txtNameEn.Text;
        if (!string.IsNullOrEmpty(txtGoogleMapHorizontal.Text))
            cities.GoogleMapHorizontal = Convert.ToDouble(txtGoogleMapHorizontal.Text);
        if (!string.IsNullOrEmpty(txtGoogleMapVertical.Text))
            cities.GoogleMapVertical = Convert.ToDouble(txtGoogleMapVertical.Text);
        bool status = CitiesFactory.Create(cities);
        if (status)
        {
            lblResult.ForeColor = Color.Blue;
            lblResult.Text = Resources.AdminText.SavingDataSuccessfuly;
            ClearControls();
        }
        else
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.SavingDataFaild;
        }
    }
    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    private void ClearControls()
    {
        ddlCountries.SelectedIndex = -1;
        txtNameAr.Text = "";
        txtNameEn.Text = "";
        txtGoogleMapHorizontal.Text = "";
        txtGoogleMapVertical.Text = "";
    }
    //--------------------------------------------------------
    #endregion
}
