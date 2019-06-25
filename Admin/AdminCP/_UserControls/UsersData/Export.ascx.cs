using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;

public partial class AdminCP__UserControls_UsersData_Export : System.Web.UI.UserControl
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
    UsersDataGlobalOptions CurrentUsersModule;
    #region --------------Page_Load--------------
    //---------------------------------------------------------
    //Page_Load
    //---------------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        CurrentUsersModule = UsersDataGlobalOptions.GetType(ModuleTypeID);
        lblResult.Text = "";
        if (!IsPostBack)
        {
            HandleOptionalControls();
            SetTexts();
            Export();
        }
    }
    //--------------------------------------------------------
    #endregion

    

    //-------------------------------------------------------
    #region ---------------HandleOptionalControls---------------
    //-----------------------------------------------
    //HandleOptionalControls
    //-----------------------------------------------
    protected void HandleOptionalControls()
    {
        dgUsers.Columns[1].Visible = CurrentUsersModule.HasName;
        //dgUsers.Columns[2].Visible = CurrentUsersModule.hase;
        dgUsers.Columns[3].Visible =(CurrentUsersModule.CategoryLevel!=0);
        dgUsers.Columns[4].Visible = CurrentUsersModule.HasJobText;
        dgUsers.Columns[5].Visible = CurrentUsersModule.HasCountryID;
        dgUsers.Columns[6].Visible = CurrentUsersModule.HasCityID||CurrentUsersModule.HasUserCityName;
        dgUsers.Columns[7].Visible = CurrentUsersModule.HasCompany;
        dgUsers.Columns[8].Visible = CurrentUsersModule.HasActivitiesID;
        dgUsers.Columns[9].Visible = CurrentUsersModule.HasUrl;
        dgUsers.Columns[10].Visible = CurrentUsersModule.HasTel;
        dgUsers.Columns[11].Visible = CurrentUsersModule.HasMobile;
        dgUsers.Columns[12].Visible = CurrentUsersModule.HasFax;
        dgUsers.Columns[13].Visible = CurrentUsersModule.HasMailBox;
        dgUsers.Columns[14].Visible = CurrentUsersModule.HasHasEmailService;
        dgUsers.Columns[15].Visible = CurrentUsersModule.HasHasSmsService;
        //----------------------------------------
        /*
        trAgeRang.Visible = CurrentUsersModule.HasAgeRang;
        trGender.Visible = CurrentUsersModule.HasGender;
        trBirthDate.Visible = CurrentUsersModule.HasBirthDate;
        trSocialStatus.Visible = CurrentUsersModule.HasSocialStatus;
        trEducationLevel.Visible = CurrentUsersModule.HasEducationLevel;
        trEmpNo.Visible = CurrentUsersModule.HasEmpNo;
        trZipCode.Visible = CurrentUsersModule.HasZipCode;
        trJobID.Visible = CurrentUsersModule.HasJobID;
        trJobText.Visible = CurrentUsersModule.HasJobText;
        trPhotoExtension.Visible = CurrentUsersModule.HasPhotoExtension;
        //*--------------------------------------------------------
        //ExtraData
        trExtraText1.Visible = (CurrentUsersModule.ExtraDataCount > 0);
        trExtraText2.Visible = (CurrentUsersModule.ExtraDataCount > 1);
        trExtraText3.Visible = (CurrentUsersModule.ExtraDataCount > 2);
        trExtraText4.Visible = (CurrentUsersModule.ExtraDataCount > 3);
        trExtraText5.Visible = (CurrentUsersModule.ExtraDataCount > 4);
        trExtraText6.Visible = (CurrentUsersModule.ExtraDataCount > 5);
        //*--------------------------------------------------------
        //-----------------------------------
        trMetaKeyWords.Visible = (CurrentUsersModule.HasMetaKeyWords);
        trShortDescription.Visible = (CurrentUsersModule.HasMetaDescription);
        //-----------------------------------
        */
    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
        dgUsers.Columns[1].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "Name"); 
        dgUsers.Columns[2].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "Email"); 
        dgUsers.Columns[3].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "CategoryID"); 
        dgUsers.Columns[4].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "JobText"); 
        dgUsers.Columns[5].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "CountryID"); 
        dgUsers.Columns[6].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "CityID");
        dgUsers.Columns[7].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "Company");
        dgUsers.Columns[8].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "ActivitiesID"); 
        dgUsers.Columns[9].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "Url"); 
        dgUsers.Columns[10].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "Tel"); 
        dgUsers.Columns[11].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "Mobile"); 
        dgUsers.Columns[12].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "Fax"); 
        dgUsers.Columns[13].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "MailBox"); 
        dgUsers.Columns[14].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "HasEmailService"); 
        dgUsers.Columns[15].HeaderText = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "HasSmsService"); 
        /*
        lblBirthDate.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "BirthDate");
        lblGender.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "Gender");
        lblJobID.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "JobID");
        lblEmpNo.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "EmpNo");
        lblZipCode.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "ZipCode");
        lblCityID.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "CityID");
        lblUserCityName.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "UserCityName");
        lblPhotoExtension.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "PhotoExtension");
        lblAgeRang.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "AgeRang");
        lblSocialStatus.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "SocialStatus");
        lblEducationLevel.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "EducationLevel");
        lblExtraText1.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "ExtraText1");
        lblExtraText2.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "ExtraText2");
        lblExtraText3.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "ExtraText3");
        lblExtraText4.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "ExtraText4");
        lblExtraText5.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "ExtraText5");
        lblExtraText6.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "ExtraText6");
        //----------------------------------------------------------------------------------------
        lblMetaKeyWords.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "MetaKeyWords");
        lblShortDescription.Text = DynamicResource.GetUsersDataModuleText(CurrentUsersModule, "ShortDescription");
        //----------------------------------------------------------------------------------------
        */
    }
    //-----------------------------------------------
    #endregion

    #region ---------------Export---------------
    //-----------------------------------------------
    //Export
    //-----------------------------------------------
    private void Export()
    {
        int catID = Convert.ToInt32(Request.QueryString["id"]);
        Languages langID = (Languages)Convert.ToInt32(Request.QueryString["lang"]);
        List<UsersDataEntity> usersDataList = UsersDataFactory.GetAll(CurrentUsersModule.ModuleTypeID, catID, langID, OwnerID,false);
        if (usersDataList != null && usersDataList.Count > 0)
        {
            dgUsers.DataSource = usersDataList;
            dgUsers.DataKeyField = "UserProfileID";
            dgUsers.DataBind();
            dgUsers.Visible = true;
            //-----------------------------------
            Response.Clear();
            //Response.HeaderEncoding = Encoding.GetEncoding("Windows-1256");
            Response.AddHeader("content-disposition", "attachment;filename=SiteUsers.xls");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
            // Response.Charset = "utf-8";
            Response.Charset = "utf-8";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = "application/vnd.ms-excel";
            System.IO.StringWriter stringWrite = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            dgUsers.RenderControl(htmlWrite);
            Response.Write(stringWrite.ToString());
            Response.End();
            dgUsers.Visible = false;
            //-----------------------------------
        }
        else
        {
            dgUsers.Visible = false;
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.ThereIsNoData;
        }

    }
    #endregion

    #region --------------GetJobIDText--------------
    //---------------------------------------------------------
    //GetJobIDText
    //---------------------------------------------------------
    protected string GetJobIDText(object job)
    {
        string text = "";
        if (job != null && job.ToString().Length > 0)
            text = DynamicResource.GetText("UsersData", "Job_" + job);
        if (string.IsNullOrEmpty(text))
            text = "";
        return text;

    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetActivitiesIDText--------------
    //---------------------------------------------------------
    //GetActivitiesIDText
    //---------------------------------------------------------
    protected string GetActivitiesIDText(object ActivitiesID)
    {
        string text = "";
        if (ActivitiesID != null && ActivitiesID.ToString().Length > 0)
            text = DynamicResource.GetText("UsersData", "ActivitiesID_" + ActivitiesID);
        if (string.IsNullOrEmpty(text))
            text = "";
        return text;

    }
    //--------------------------------------------------------
    #endregion


    #region --------------GetBooleanText--------------
    //---------------------------------------------------------
    //GetBooleanText
    //---------------------------------------------------------
    public string GetBooleanText(object _value)
    {
        bool x = Convert.ToBoolean(_value);
        if (x) return Resources.User.True;
        else return Resources.User.False;
    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetCityText--------------
    //---------------------------------------------------------
    //GetCityText
    //---------------------------------------------------------
    public string GetCityText(object cityName, object usercityName)
    {
        if (cityName != null && (!string.IsNullOrEmpty(cityName.ToString())))
            return cityName.ToString();
        else if (usercityName != null && (!string.IsNullOrEmpty(usercityName.ToString())))
            return usercityName.ToString();
        else
            return "";

    }
    //--------------------------------------------------------
    #endregion

    #region --------------GetCategoryText--------------
    //---------------------------------------------------------
    //GetCategoryText
    //---------------------------------------------------------
    public string GetCategoryText(object catID)
    {
        int categoryID = Convert.ToInt32(catID);
        if (categoryID > 0)
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            ItemCategoriesEntity category = ItemCategoriesFactory.GetObject(categoryID,langID,OwnerID);
            if (category != null)
            {
                ItemCategoriesDetailsEntity pd = null;
                if (category.Details.Contains(Languages.Ar))
                    pd = (ItemCategoriesDetailsEntity)category.Details[Languages.Ar];
                else
                    pd = (ItemCategoriesDetailsEntity)category.Details[Languages.En];
                if (pd != null)
                    return pd.Title;
            }
        }
        return "";

    }
    //--------------------------------------------------------
    #endregion

    #region --------------btnExport_Click--------------
    //---------------------------------------------------------
    //btnExport_Click
    //---------------------------------------------------------
    protected void btnExport_Click(object sender, EventArgs e)
    {
        Export();
    }
    //--------------------------------------------------------
    #endregion

    #region --------------dgUsers_ItemDataBound--------------
    //---------------------------------------------------------
    //dgUsers_ItemDataBound
    //---------------------------------------------------------
    protected void dgUsers_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            #region ---------Index-------
            //Set Index
            int currentRow = e.Item.ItemIndex + 1;
            e.Item.Cells[0].Text = (currentRow).ToString();
            #endregion
        }
    }
    //--------------------------------------------------------
    #endregion
}