using System;using DCCMSNameSpace;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Drawing;

using System.IO;
public partial class UsersData_AdminEdit : System.Web.UI.UserControl
{

    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
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

    UsersDataGlobalOptions currentModule;

    string oldPhotoExtension;
    string oldEmail;
    string oldMobile;

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        currentModule = UsersDataGlobalOptions.GetType(ModuleTypeID);
        
        lblResult.Text = "";
        if (!IsPostBack)
        {
            FirstLoad();
        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------FirstLoad---------------
    //-----------------------------------------------
    //FirstLoad
    //-----------------------------------------------
    public void FirstLoad()
    {
        HandleOptionalControls();
        PrepareValidation();
        SetTexts();
        LoadData();
    }
    //-----------------------------------------------
    #endregion

    #region ---------------HandleOptionalControls---------------
    //-----------------------------------------------
    //HandleOptionalControls
    //-----------------------------------------------
    protected void HandleOptionalControls()
    {
        //----------------------------------------
        if (currentModule.CategoryLevel != 0)
        {
            trCategoryID.Visible = true;
            LoadCategories();
        }
        else
        {
            trCategoryID.Visible = false;
        }
        //----------------------------------------
        trName.Visible = currentModule.HasName;
        trAgeRang.Visible = currentModule.HasAgeRang;
        trGender.Visible = currentModule.HasGender;
        trBirthDate.Visible = currentModule.HasBirthDate;
        trSocialStatus.Visible = currentModule.HasSocialStatus;
        trEducationLevel.Visible = currentModule.HasEducationLevel;

        trEmpNo.Visible = currentModule.HasEmpNo;

        //----------------------------
        //HasCountryID
        //----------------------------
        trCountryID.Visible = currentModule.HasCountryID;
        if (currentModule.HasCountryID)
        {
            Load_ddlSystemCountries();
        }
        //----------------------------
        //HasCityID
        //----------------------------
        if (currentModule.HasCityID)
        {
            Load_ddlCities();
            trCityID.Visible = true;
            ddlSystemCountries.AutoPostBack = true;
            //ddlSystemCountries.SelectedIndexChanged += new EventHandler(this.ddlSystemCountries_SelectedIndexChanged);
        }
        else
        {
            trCityID.Visible = false;
        }
        //----------------------------
        trUserCityName.Visible = currentModule.HasUserCityName;
        trTel.Visible = currentModule.HasTel;
        trMobile.Visible = currentModule.HasMobile;
        trHasSmsService.Visible = currentModule.HasHasSmsService;
        trHasEmailService.Visible = currentModule.HasHasEmailService;


        trFax.Visible = currentModule.HasFax;
        trMailBox.Visible = currentModule.HasMailBox;
        trZipCode.Visible = currentModule.HasZipCode;
        trJobID.Visible = currentModule.HasJobID;
        trJobText.Visible = currentModule.HasJobText;
        trUrl.Visible = currentModule.HasUrl;
        trPhotoExtension.Visible = currentModule.HasPhotoExtension;
        trPhotoPreview.Visible = currentModule.HasPhotoExtension;

        trCompany.Visible = currentModule.HasCompany;
        trActivitiesID.Visible = currentModule.HasActivitiesID;
        //*--------------------------------------------------------
        //ExtraData
        //*--------------------------------------------------------
        //-----------------------------------
        trMetaKeyWords.Visible = (currentModule.HasMetaKeyWords);
        trShortDescription.Visible = (currentModule.HasMetaDescription);
        //-----------------------------------
        trIsConsultant.Visible = currentModule.HasIsConsultant;
        //-----------------------------------

    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadCategories---------------
    //-----------------------------------------------
    //LoadCategories
    //-----------------------------------------------
    private void LoadCategories()
    {
        int categoriesDepth = currentModule.CategoryLevel;//NewsSiteSettings.Instance.CategoriesDepth;
        ParentChildDropDownList n = new ParentChildDropDownList();
        DataTable dtSource = ItemCategoriesFactory.GetAllInDataTable(ModuleTypeID, Languages.Ar, false, OwnerID);
        n.DataBind(ddlCategoryID, categoriesDepth, dtSource, "ParentID", "CategoryID", "Title");
        ddlCategoryID.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
    }
    //-----------------------------------------------
    #endregion

    #region ---------------PrepareValidation---------------
    //-----------------------------------------------
    //PrepareValidation
    //-----------------------------------------------
    public void PrepareValidation()
    {
        rfvName.Visible = currentModule.RequiredName;
        rfvJobID.Visible = currentModule.RequiredJobID;
        rfvJobText.Visible = currentModule.RequiredJobText;
        rfvEmpNo.Visible = currentModule.RequiredEmpNo;
        rfvCountryID.Visible = currentModule.RequiredCountryID;
        rfvCityID.Visible = currentModule.RequiredCityID;
        rfvUserCityName.Visible = currentModule.RequiredUserCityName;
        rfvCompany.Visible = currentModule.RequiredCompany;
        rfvActivitiesID.Visible = currentModule.RequiredActivitiesID;
        rfvPhoto.Visible = false;
        //************************************************************************
        if (!string.IsNullOrEmpty(currentModule.PhotoAvailableExtension))
        {
            //Photo
            rxpPhoto.ValidationExpression = currentModule.GetPhotoValidationExpression();
            rxpPhoto.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.PhotoAvailableExtension;
        }
        else
        {
            rxpPhoto.Visible = false;
        }
        //-------------------------------
        btnDeletePhoto.Visible = currentModule.RequiredPhotoExtension;
        rfvUrl.Visible = currentModule.RequiredUrl;
        rfvTel.Visible = currentModule.RequiredTel;
        rfvMobile.Visible = currentModule.RequiredMobile;
        rfvFax.Visible = currentModule.RequiredFax;
        rfvMailBox.Visible = currentModule.RequiredMailBox;
        rfvZipCode.Visible = currentModule.RequiredZipCode;
        rfvAgeRang.Visible = currentModule.RequiredAgeRang;
        rfvGender.Visible = currentModule.RequiredGender;
        // ucDateBirthDate = currentModule.Required.XXXXXXXXXX;
        rfvSocialStatus.Visible = currentModule.RequiredSocialStatus;
        rfvEducationLevel.Visible = currentModule.RequiredEducationLevel;
        //*--------------------------------------------------------
        //ExtraData
        //*--------------------------------------------------------
    }
    //-----------------------------------------------
    #endregion

    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
        lblName.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Name");
        lblEmail.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Email");
        lblCategoryID.Text = DynamicResource.GetUsersDataModuleText(currentModule, "CategoryID");
        lblBirthDate.Text = DynamicResource.GetUsersDataModuleText(currentModule, "BirthDate");
        lblGender.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Gender");
        lblJobID.Text = DynamicResource.GetUsersDataModuleText(currentModule, "JobID");
        lblJobText.Text = DynamicResource.GetUsersDataModuleText(currentModule, "JobText");
        lblCompany.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Company");
        lblEmpNo.Text = DynamicResource.GetUsersDataModuleText(currentModule, "EmpNo");
        lblMailBox.Text = DynamicResource.GetUsersDataModuleText(currentModule, "MailBox");
        lblZipCode.Text = DynamicResource.GetUsersDataModuleText(currentModule, "ZipCode");
        lblCountryID.Text = DynamicResource.GetUsersDataModuleText(currentModule, "CountryID");
        lblCityID.Text = DynamicResource.GetUsersDataModuleText(currentModule, "CityID");
        lblUserCityName.Text = DynamicResource.GetUsersDataModuleText(currentModule, "UserCityName");
        lblActivitiesID.Text = DynamicResource.GetUsersDataModuleText(currentModule, "ActivitiesID");
        lblPhotoExtension.Text = DynamicResource.GetUsersDataModuleText(currentModule, "PhotoExtension");
        lblUrl.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Url");
        lblTel.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Tel");
        lblMobile.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Mobile");
        lblFax.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Fax");
        lblHasEmailService.Text = DynamicResource.GetUsersDataModuleText(currentModule, "HasEmailService");
        lblHasSmsService.Text = DynamicResource.GetUsersDataModuleText(currentModule, "HasSmsService");
        lblAgeRang.Text = DynamicResource.GetUsersDataModuleText(currentModule, "AgeRang");
        lblSocialStatus.Text = DynamicResource.GetUsersDataModuleText(currentModule, "SocialStatus");
        lblEducationLevel.Text = DynamicResource.GetUsersDataModuleText(currentModule, "EducationLevel");



        lblDetails.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Details");
        //----------------------------------------------------------------------------------------
        lblMetaKeyWords.Text = DynamicResource.GetUsersDataModuleText(currentModule, "MetaKeyWords");
        lblShortDescription.Text = DynamicResource.GetUsersDataModuleText(currentModule, "ShortDescription");
        //----------------------------------------------------------------------------------------
        lblIsConsultant.Text = DynamicResource.GetUsersDataModuleText(currentModule, "IsConsultant");
        //----------------------------------------------------------------------------------------
        /*
        lblAddress.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Address");
        lblJobTel.Text = DynamicResource.GetUsersDataModuleText(currentModule, "JobTel");
        lblType.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Type");
        lblTitle.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Title");
        lblToItemID.Text = DynamicResource.GetUsersDataModuleText(currentModule, "ToItemID");
        lblDetails.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Details");
        lblNotes2.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Notes2");
        lblNotes1.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Notes1");
        lblFileExtension.Text = DynamicResource.GetUsersDataModuleText(currentModule, "FileExtension");
        */


    }
    //-----------------------------------------------
    #endregion

    #region --------------Load_ddlSystemCountries()--------------
    //---------------------------------------------------------
    //Load_ddlSystemCountries
    //---------------------------------------------------------
    protected void Load_ddlSystemCountries()
    {
        List<SystemCountriesEntity> SystemCountriesList = SystemCountriesFactory.GetAll();
        if (SystemCountriesList != null && SystemCountriesList.Count > 0)
        {
            ddlSystemCountries.DataSource = SystemCountriesList;
            ddlSystemCountries.DataTextField = "country_ar";
            ddlSystemCountries.DataValueField = "id";
            ddlSystemCountries.DataBind();
            // ddlSystemCountries.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
            ddlSystemCountries.SelectedValue = SiteSettings.Admininstration_SiteDefaultCountryID.ToString();
            ddlSystemCountries.Enabled = true;
        }
        else
        {
            ddlSystemCountries.Items.Clear();
            ddlSystemCountries.Items.Insert(0, new ListItem(Resources.AdminText.ThereIsNoData, "-1"));
            ddlSystemCountries.Enabled = false;
        }

    }
    //--------------------------------------------------------
    #endregion

    #region --------------Load_ddlCities()--------------
    //---------------------------------------------------------
    //Load_ddlCities
    //---------------------------------------------------------
    protected void Load_ddlCities()
    {
        int countryID = 0;
        if (currentModule.HasCountryID)
            countryID = Convert.ToInt32(ddlSystemCountries.SelectedValue);
        List<CitiesEntity> CitiesList = CitiesFactory.GetAll(countryID);
        if (CitiesList != null && CitiesList.Count > 0)
        {
            ddlCities.DataSource = CitiesList;
            ddlCities.DataTextField = "NameAr";
            ddlCities.DataValueField = "CityID";
            ddlCities.DataBind();
            ddlCities.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "-1"));
            ddlCities.Enabled = true;
        }
        else
        {
            ddlCities.Items.Clear();
            ddlCities.Items.Insert(0, new ListItem(Resources.AdminText.ThereIsNoData, "-1"));
            ddlCities.Enabled = false;
        }
    }
    //--------------------------------------------------------
    #endregion

    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        if (MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
        {
            
            Guid userid = new Guid(Request.QueryString["id"]);
            UsersDataEntity usersDataObject = UsersDataFactory.GetUsersDataObject(userid, OwnerID);
            if (usersDataObject != null)
            {
                //----------------------------------------------------------------------
                if (currentModule.HasName)
                    txtName.Text = usersDataObject.Name;
                //----------------------------------------------------------------------
                txtEmail.Text = usersDataObject.Email;
                //----------------------------------------------------------------------
                if (currentModule.CategoryLevel != 0)
                    ddlCategoryID.SelectedValue = usersDataObject.CategoryID.ToString();
                //----------------------------------------------------------------------
                if (currentModule.HasEmpNo)
                    txtEmpNo.Text = usersDataObject.EmpNo.ToString();
                //----------------------------------------------------------------------
                #region ----------Photo----------
                //-------------------------------------------
                //Photo
                //-------------------------------------------
                if (currentModule.HasPhotoExtension && !string.IsNullOrEmpty(usersDataObject.PhotoExtension))
                {
                    imgPhoto.ImageUrl = UsersDataFactory.GetUserPhotoThumbnail(usersDataObject.UserProfileID, usersDataObject.PhotoExtension, 100, 100, usersDataObject.OwnerName, usersDataObject.ModuleTypeID, usersDataObject.CategoryID);
                    ancor.HRef = UsersDataFactory.GetUserPhotoBigThumbnail(usersDataObject.UserProfileID, usersDataObject.PhotoExtension, usersDataObject.OwnerName, usersDataObject.ModuleTypeID, usersDataObject.CategoryID);
                    //imgPhoto.AlternateText = itemsObject.Title;
                }
                else
                {
                    trPhotoPreview.Visible = false;

                }
                //------------------------------------------
                //------------------------------------------
                #endregion
                //------------------------------------------------------------
                if (currentModule.HasAgeRang)
                    ddlAgeRang.SelectedValue = usersDataObject.AgeRang.ToString();
                //----------------------------------------------------------------------
                if (currentModule.HasGender)
                    ddlGender.SelectedValue = ((int)usersDataObject.Gender).ToString();
                //----------------------------------------------------------------------
                if (currentModule.HasBirthDate)
                    ucDateBirthDate.Date = Convert.ToDateTime(usersDataObject.BirthDate);
                //----------------------------------------------------------------------
                if (currentModule.HasSocialStatus)
                    ddlSocialStatus.SelectedValue = usersDataObject.SocialStatus.ToString();
                //----------------------------------------------------------------------
                if (currentModule.HasEducationLevel)
                    ddlEducationLevel.SelectedValue = usersDataObject.EducationLevel.ToString();
                //----------------------------------------------------------------------
                if (currentModule.HasCountryID)
                    ddlSystemCountries.SelectedValue = usersDataObject.CountryID.ToString();
                //----------------------------------------------------------------------
                if (currentModule.HasCityID)
                    ddlCities.SelectedValue = usersDataObject.CityID.ToString();
                //------------------------------------------------------------
                if (currentModule.HasUserCityName)
                    txtUserCityName.Text = usersDataObject.UserCityName.ToString();
                //----------------------------------------------------------------------
                if (currentModule.HasTel)
                    txtTel.Text = usersDataObject.Tel;
                //----------------------------------------------------------------------
                if (currentModule.HasMobile)
                    txtMobile.Text = usersDataObject.Mobile;
                //----------------------------------------------------------------------
                if (currentModule.HasHasSmsService)
                    cbHasSmsService.Checked = usersDataObject.HasSmsService;
                //----------------------------------------------------------------------
                if (currentModule.HasHasEmailService)
                    cbHasEmailService.Checked = usersDataObject.HasEmailService;
                //------------------------------------------------------------
                if (currentModule.HasFax)
                    txtFax.Text = usersDataObject.Fax;
                //----------------------------------------------------------------------
                if (currentModule.HasMailBox)
                    txtMailBox.Text = usersDataObject.MailBox;
                //----------------------------------------------------------------------
                if (currentModule.HasZipCode)
                    txtZipCode.Text = usersDataObject.ZipCode;
                //----------------------------------------------------------------------
                if (currentModule.HasJobID)
                    txtJobID.Text = usersDataObject.JobID.ToString();
                //----------------------------------------------------------------------
                if (currentModule.HasJobText)
                    txtJobText.Text = usersDataObject.JobText;
                //----------------------------------------------------------------------
                if (currentModule.HasUrl)
                    txtUrl.Text = usersDataObject.Url;
                //----------------------------------------------------------------------
                if (currentModule.HasCompany)
                    txtCompany.Text = usersDataObject.Company;
                //----------------------------------------------------------------------
                if (currentModule.HasActivitiesID)
                    ddlActivitiesID.SelectedValue = usersDataObject.ActivitiesID.ToString();
                //----------------------------------------------------------------------
                //*--------------------------------------------------------

                txtDetails.Text = usersDataObject.ExtraData;
                //*--------------------------------------------------------
                //----------------------------------------------------------------------
                txtMetaKeyWordsAr.Text = usersDataObject.KeyWordsAr;
                txtShortDescriptionAr.Text = usersDataObject.ShortDescriptionAr;
                //----------------------------------------------------------------------
                //----------------------------------------------------------------------
                //IsConsultant
                //-------------------------
                cbIsConsultant.Checked = Roles.IsUserInRole(usersDataObject.UserName, DCRoles.ConsultantsRoles);
                //----------------------------------------------------------------------
            }
            else
            {
                //Response.Redirect("default.aspx");
                Response.Redirect("../" + currentModule.Identifire + "/default.aspx");
            }
        }
    }
    //-----------------------------------------------
    #endregion

    
    //---------------------------------------------------------------
    protected void ibtnRegister_Click(object sender, ImageClickEventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
    }
    //---------------------------------------------------------------
    protected void CreateUser(MembershipUser user)
    {


    }
    //---------------------------------------------------------------

    #region ---------------SaveFiles---------------
    //-----------------------------------------------
    //SaveFiles
    //-----------------------------------------------
    protected void SaveFiles(UsersDataEntity UserDataObject)
    {
        #region Save uploaded photo
        //Photo-----------------------------
        if (fuPhoto.HasFile)
        {
            //if has an old photo
            if (!string.IsNullOrEmpty(oldPhotoExtension))
            {
                //Delete old original photo
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoOriginals(UserDataObject.OwnerName, UserDataObject.ModuleTypeID, UserDataObject.CategoryID, UserDataObject.UserProfileID)) + UsersDataFactory.CreateUserPhotoName(UserDataObject.UserProfileID) + oldPhotoExtension);
                //Delete old Thumbnails
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoNormalThumbs (UserDataObject.OwnerName, UserDataObject.ModuleTypeID, UserDataObject.CategoryID, UserDataObject.UserProfileID)) + UsersDataFactory.CreateUserPhotoName(UserDataObject.UserProfileID) + MoversFW.Thumbs.thumbnailExetnsion);
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoBigThumbs (UserDataObject.OwnerName, UserDataObject.ModuleTypeID, UserDataObject.CategoryID, UserDataObject.UserProfileID)) + UsersDataFactory.CreateUserPhotoName(UserDataObject.UserProfileID) + MoversFW.Thumbs.thumbnailExetnsion);
            }
            //------------------------------------------------
            //Save new original photo
            fuPhoto.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoOriginals(UserDataObject.OwnerName, UserDataObject.ModuleTypeID, UserDataObject.CategoryID, UserDataObject.UserProfileID)) + UserDataObject.Photo);
            //Create new thumbnails
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_UserDataPhotoNormalThumbs (UserDataObject.OwnerName, UserDataObject.ModuleTypeID, UserDataObject.CategoryID, UserDataObject.UserProfileID), UsersDataFactory.CreateUserPhotoName(UserDataObject.UserProfileID), fuPhoto.PostedFile, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight);
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_UserDataPhotoBigThumbs (UserDataObject.OwnerName, UserDataObject.ModuleTypeID, UserDataObject.CategoryID, UserDataObject.UserProfileID), UsersDataFactory.CreateUserPhotoName(UserDataObject.UserProfileID), fuPhoto.PostedFile, SiteSettings.Photos_BigThumnailWidth, SiteSettings.Photos_BigThumnailHeight);
        }
        //------------------------------------------------
        #endregion
    }
    //-----------------------------------------------
    #endregion

    protected void ddlSystemCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        //----------------------------
        //HasCityID
        //----------------------------
        if (currentModule.HasCityID)
        {
            Load_ddlCities();
        }
        else
        {
            return;
        }
        //----------------------------
    }


    protected void btnDeletePhoto_Click(object sender, EventArgs e)
    {
        if (MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
        {
            Guid userid = new Guid(Request.QueryString["id"]);
            UsersDataEntity usersDataObject = UsersDataFactory.GetUsersDataObject(userid, OwnerID);
            if (usersDataObject != null)
            {
                //Photo-----------------------------
                if (!string.IsNullOrEmpty(usersDataObject.PhotoExtension))
                {
                    //Delete old original photo
                    File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoOriginals(usersDataObject.OwnerName, usersDataObject.ModuleTypeID, usersDataObject.CategoryID, usersDataObject.UserProfileID)) + usersDataObject.Photo);
                    //Delete old Thumbnails
                    File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoNormalThumbs (usersDataObject.OwnerName, usersDataObject.ModuleTypeID, usersDataObject.CategoryID, usersDataObject.UserProfileID)) + UsersDataFactory.CreateUserPhotoName(usersDataObject.UserProfileID) + MoversFW.Thumbs.thumbnailExetnsion);
                    File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoBigThumbs (usersDataObject.OwnerName, usersDataObject.ModuleTypeID, usersDataObject.CategoryID, usersDataObject.UserProfileID)) + UsersDataFactory.CreateUserPhotoName(usersDataObject.UserProfileID) + MoversFW.Thumbs.thumbnailExetnsion);
                }
                //------------------------------------------------

                trPhotoPreview.Visible = false;
                //-----------------------------

                usersDataObject.PhotoExtension = "";
                bool status = UsersDataFactory.Update(usersDataObject);
                if (status)
                {

                    lblResult.CssClass = "lblResult_Done";
                    lblResult.Text = Resources.AdminText.DeletingOprationDone;
                }

                else
                {
                    lblResult.CssClass = "lblResult_Faild";
                    lblResult.Text = Resources.AdminText.DeletingOprationFaild;
                }

            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
        {
            Guid userid = new Guid(Request.QueryString["id"]);
            UsersDataEntity usersDataObject = UsersDataFactory.GetUsersDataObject(userid, OwnerID);
            
            oldPhotoExtension = usersDataObject.PhotoExtension;
            string uploadedPhotoExtension = Path.GetExtension(fuPhoto.FileName);

            oldEmail = usersDataObject.Email;
            oldMobile = usersDataObject.Mobile;
            #region Uploaded photo file checks
            if (fuPhoto.HasFile)
            {
                if (!MoversFW.Photos.CheckIsImage(fuPhoto.PostedFile))
                {
                    lblResult.CssClass = "lblResult_Faild";
                    lblResult.Text = Resources.AdminText.InvalidPhotoFile;
                    return;
                }
                /*
                //Check suported extention
                if (!SiteSettings.CheckUploadedFileExtension(uploadedPhotoExtension, currentModule.PhotoAvailableExtension))
                {
                    lblResult.CssClass = "lblResult_Faild";
                    lblResult.Text = Resources.AdminText.NotSuportedFileExtention + currentModule.PhotoAvailableExtension;
                    return;
                }*/
                //Check max length
                if (!SiteSettings.CheckUploadedFileLength(fuPhoto.PostedFile.ContentLength, currentModule.PhotoMaxSize))
                {
                    lblResult.CssClass = "lblResult_Faild";
                    lblResult.Text = Resources.AdminText.UploadedFileGreaterThanMaxLength + currentModule.PhotoMaxSize;
                    return;
                }
                //--------------------------------------------------------------------
            }
            #endregion

            usersDataObject.Name = txtName.Text;
            if (currentModule.CategoryLevel != 0)
                usersDataObject.CategoryID = Convert.ToInt32(ddlCategoryID.SelectedValue);
            if (trEmpNo.Visible && !string.IsNullOrEmpty(txtEmpNo.Text))
                usersDataObject.EmpNo = Convert.ToInt32(txtEmpNo.Text);
            //------------------------------------------------------------
            if (trAgeRang.Visible)
                usersDataObject.AgeRang = Convert.ToInt32(ddlAgeRang.SelectedValue);
            if (trGender.Visible)
                usersDataObject.Gender = (Gender)Convert.ToInt32(ddlGender.SelectedValue);
            if (trBirthDate.Visible)
            {
                usersDataObject.BirthDate = ucDateBirthDate.Date.ToShortDateString();
            }
            if (trSocialStatus.Visible)
                usersDataObject.SocialStatus = Convert.ToInt32(ddlSocialStatus.SelectedValue);
            if (trEducationLevel.Visible)
                usersDataObject.EducationLevel = Convert.ToInt32(ddlEducationLevel.SelectedValue);
            if (trCountryID.Visible)
                usersDataObject.CountryID = Convert.ToInt32(ddlSystemCountries.SelectedValue);
            if (trCityID.Visible)
                usersDataObject.CityID = Convert.ToInt32(ddlCities.SelectedValue);
            //------------------------------------------------------------
            usersDataObject.UserCityName = txtUserCityName.Text;
            usersDataObject.Tel = txtTel.Text;
            usersDataObject.Mobile = txtMobile.Text;
            usersDataObject.HasSmsService = cbHasSmsService.Checked;
            usersDataObject.HasEmailService = cbHasEmailService.Checked;
            //------------------------------------------------------------
            usersDataObject.Fax = txtFax.Text;
            usersDataObject.MailBox = txtMailBox.Text;
            usersDataObject.ZipCode = txtZipCode.Text;
            if (trJobID.Visible && !string.IsNullOrEmpty(txtJobID.Text))
                usersDataObject.JobID = Convert.ToInt32(txtJobID.Text);
            usersDataObject.JobText = txtJobText.Text;
            usersDataObject.Url = txtUrl.Text;
            //------------------------------------------------------------
            usersDataObject.Company = txtCompany.Text;
            if (trActivitiesID.Visible)
                usersDataObject.ActivitiesID = Convert.ToInt32(ddlActivitiesID.SelectedValue);
            //------------------------------------------------------------
            //*--------------------------------------------------------
            //ExtraData
            usersDataObject.ExtraData=txtDetails.Text;
            //*--------------------------------------------------------
            //Photo
            if (fuPhoto.HasFile)
                usersDataObject.PhotoExtension = uploadedPhotoExtension;
            else
                usersDataObject.PhotoExtension = oldPhotoExtension;
            //----------------------------------------------------------------------
            usersDataObject.KeyWordsAr = txtMetaKeyWordsAr.Text;
            usersDataObject.ShortDescriptionAr = txtShortDescriptionAr.Text;
            //----------------------------------------------------------------------
            bool status = UsersDataFactory.Update(usersDataObject);
            if (status)
            {
                //---------------------------------------------------------------
                //IsConsultant
                //-------------------------
                bool isConsultant = Roles.IsUserInRole(usersDataObject.UserName, DCRoles.ConsultantsRoles);
                if (isConsultant && !cbIsConsultant.Checked)
                {
                    Roles.RemoveUserFromRole(usersDataObject.UserName, DCRoles.ConsultantsRoles);
                }
                else if (!isConsultant && cbIsConsultant.Checked)
                {
                    Roles.AddUserToRole(usersDataObject.UserName, DCRoles.ConsultantsRoles);
                }
                //---------------------------------------------------------------
                SaveFiles(usersDataObject);
                //RegisterInMailList--------------------------------------------------------------//
                if (currentModule.MailListAutomaticRegistration || usersDataObject.HasEmailService)
                    UsersDataFactory.UpdateMailListEmail(oldEmail, usersDataObject);
                //--------------------------------------------------------------------------------//
                //RegisterInSms--------------------------------------------------------------//
                if (currentModule.SmsAutomaticRegistration || usersDataObject.HasSmsService)
                    UsersDataFactory.UpdateSmsMobileNo(oldMobile, usersDataObject);
                //--------------------------------------------------------------------------------//
                Response.Redirect("../"+currentModule.Identifire+"/default.aspx");
            }
            else
            {
                lblResult.CssClass = "operation_error";
                lblResult.Text = Resources.AdminText.UpdatingOperationFaild;

            }
        }
    }
}

