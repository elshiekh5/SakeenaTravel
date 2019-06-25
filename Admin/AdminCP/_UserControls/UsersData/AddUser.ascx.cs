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

using System.Net.Mail;
using System.IO;
public partial class UserControls_UsersData_AddUser : System.Web.UI.UserControl
{
    //-------------------------------------------------------
    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region --------------OwnerID--------------
    private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
    public Guid OwnerID
    {
        get { return _OwnerID; }
        set { _OwnerID = value; }
    }
    //------------------------------------------
    #endregion
    //-------------------------------------------------------
    UsersDataGlobalOptions currentModule;
    //-------------------------------------------------------
    #region --------------ValidateUser--------------
    private bool _ValidateUser = false;
    public bool ValidateUser
    {
        get { return _ValidateUser; }
        set { _ValidateUser = value; }
    }
    //------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region --------------SendMailToUser--------------
    private bool _SendMailToUser = false;
    public bool SendMailToUser
    {
        get { return _SendMailToUser; }
        set { _SendMailToUser = value; }
    }
    //------------------------------------------
    #endregion
    //-------------------------------------------------------
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
            LoadData();
        }
    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
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
            ddlSystemCountries.SelectedIndexChanged += new EventHandler(this.ddlSystemCountries_SelectedIndexChanged);
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


        trCompany.Visible = currentModule.HasCompany;
        trActivitiesID.Visible = currentModule.HasActivitiesID;
        //*--------------------------------------------------------
       
        //*--------------------------------------------------------
        trMetaKeyWords.Visible = (currentModule.HasMetaKeyWords);
        trShortDescription.Visible = (currentModule.HasMetaDescription);
        //*--------------------------------------------------------
        trIsConsultant.Visible = currentModule.HasIsConsultant;
        //*--------------------------------------------------------
    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
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
        rfvPhoto.Visible = currentModule.RequiredPhotoExtension;
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
        rfvDetails.Visible = false;
        //*--------------------------------------------------------
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
        lblName.Text = DynamicResource.GetUsersDataModuleText(currentModule, "Name");
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
    //-------------------------------------------------------
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
    //-------------------------------------------------------
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
    //-------------------------------------------------------
    #region --------------Load_ddlCities()--------------
    //---------------------------------------------------------
    //Load_ddlCities
    //---------------------------------------------------------
    protected void Load_ddlCities()
    {
        int countryID = SiteSettings.Admininstration_SiteDefaultCountryID;
        if (currentModule.HasCountryID)
        {
            countryID = Convert.ToInt32(ddlSystemCountries.SelectedValue);
        }
        if (countryID > 0)
        {
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
        else
        {
            ddlCities.Items.Clear();
            ddlCities.Items.Insert(0, new ListItem(Resources.AdminText.ThereIsNoData, "-1"));
            ddlCities.Enabled = false;
        }
    }
    //--------------------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        HandleOptionalControls();
        PrepareValidation();
        SetTexts();
    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region ---------------ddlSystemCountries_SelectedIndexChanged---------------
    //-----------------------------------------------
    //ddlSystemCountries_SelectedIndexChanged
    //-----------------------------------------------
    protected void ddlSystemCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_ddlCities();
    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region ---------------CreateUserProfile---------------
    //-----------------------------------------------
    //CreateUserProfile
    //-----------------------------------------------
    protected bool CreateUserProfile(MembershipUser user, out UsersDataEntity usersDataObject)
    {
        usersDataObject = new UsersDataEntity();
        string uploadedPhotoExtension = Path.GetExtension(fuPhoto.FileName);
        
        usersDataObject.UserId = (Guid)user.ProviderUserKey;
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
        usersDataObject.PhotoExtension = uploadedPhotoExtension;
        //------------------------------------------------------------
        usersDataObject.Company = txtCompany.Text;
        if (trActivitiesID.Visible)
            usersDataObject.ActivitiesID = Convert.ToInt32(ddlActivitiesID.SelectedValue);
        //------------------------------------------------------------
        usersDataObject.LangID = (Languages)SiteSettings.Languages_DefaultLanguageID;
        //*--------------------------------------------------------
        //ExtraData
        usersDataObject.ExtraData = txtDetails.Text;
        //*--------------------------------------------------------
        usersDataObject.ModuleTypeID = currentModule.ModuleTypeID;
        //*--------------------------------------------------------
        //usersDataObject.KeyWordsAr = txtMetaKeyWordsAr.Text;
        //usersDataObject.ShortDescriptionAr = txtShortDescriptionAr.Text;
        //*--------------------------------------------------------
        usersDataObject.OwnerID = OwnerID;
        usersDataObject.UserType = currentModule.UserType;
        usersDataObject.SubSiteType = currentModule.SubSiteType;
        //*--------------------------------------------------------
        //if (currentModule.HasProfilePage)
        //{
        //    SubSiteHandler.AddProfilePageDetails(usersDataObject);
        //}
        //*--------------------------------------------------------
        if (UsersDataFactory.IsSubSubSiteOwner(currentModule.UserType))
        {
            usersDataObject.OwnerName = user.UserName;
            //usersDataObject.SiteStaticPages = SubSiteHandler.GetSubSitPagesIDsString(currentModule.SubSiteType);
        }
        //*--------------------------------------------------------
        usersDataObject.UserName = user.UserName;
        //*--------------------------------------------------------
        return UsersDataFactory.Create(user,usersDataObject);
        //*--------------------------------------------------------
    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region ---------------SaveFiles---------------
    //-----------------------------------------------
    //SaveFiles
    //-----------------------------------------------
    protected void SaveFiles(UsersDataEntity userdata)
    {
        #region Save uploaded photo
        //Photo-----------------------------
        if (fuPhoto.HasFile)
        {
            //------------------------------------------------
            //Save new original photo
            fuPhoto.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_UserDataPhotoOriginals(userdata.OwnerName, userdata.ModuleTypeID, userdata.CategoryID,userdata.UserProfileID)) + userdata.Photo);
            //Create new thumbnails
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_UserDataPhotoNormalThumbs(userdata.OwnerName, userdata.ModuleTypeID, userdata.CategoryID,userdata.UserProfileID), UsersDataFactory.CreateUserPhotoName(userdata.UserProfileID), fuPhoto.PostedFile, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight);
            MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_UserDataPhotoBigThumbs(userdata.OwnerName, userdata.ModuleTypeID, userdata.CategoryID,userdata.UserProfileID), UsersDataFactory.CreateUserPhotoName(userdata.UserProfileID), fuPhoto.PostedFile, SiteSettings.Photos_BigThumnailWidth, SiteSettings.Photos_BigThumnailHeight);
            //-------------------------------------------------------

        }
        #endregion

    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region ---------------btnSave_Click---------------
    //-----------------------------------------------
    //btnSave_Click
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
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
        //------------------------------------------------------------------------------------
        string username = txtUserName.Text;
        string pass = txtPassword.Text;
        MembershipCreateStatus createUserStatus;
        MembershipUser user;
        UsersDataEntity usersDataObject = null;
        //------------------------------------------------------------------------------------
        user = Membership.CreateUser(username, pass, txtEmail.Text, null, null, ValidateUser, out createUserStatus);
        switch (createUserStatus)
        {
            case MembershipCreateStatus.Success:
                try
                {
                    //---------------------------------------------------------------
                    Roles.AddUserToRole(user.UserName, currentModule.UserRole);
                    //---------------------------------------------------------------
                    //IsConsultant
                    //-------------------------
                    if (cbIsConsultant.Checked)
                    {
                        Roles.AddUserToRole(user.UserName, DCRoles.ConsultantsRoles);
                    }
                    //---------------------------------------------------------------
                    bool status = CreateUserProfile(user, out usersDataObject);
                    if (status)
                    {
                        //------------------------------------------------------------------------
                        if (usersDataObject.IsApproved)
                        {
                            //Create Sub Site if this user has it-------------------
                            UsersDataFactory.ConfigureSubSiteIfExist(user);
                            //AddUserRelatedPages
                            SubSiteHandler.AddUserRelatedPages(usersDataObject);
                            
                        }
                        //------------------------------------------------------------------------
                        SaveFiles(usersDataObject);
                        //------------------------------------------------------------------------
                        //RegisterInMailList
                        usersDataObject.Email = user.Email;
                        if ((currentModule.MailListAutomaticRegistration || (usersDataObject.HasEmailService)) && !string.IsNullOrEmpty(usersDataObject.Email))
                            UsersDataFactory.RegisterInMailList(usersDataObject);
                        //------------------------------------------------------------------------
                        //RegisterInSms
                        if ((currentModule.SmsAutomaticRegistration || (usersDataObject.HasSmsService)) && !string.IsNullOrEmpty(usersDataObject.Mobile))
                            UsersDataFactory.RegisterInSms(usersDataObject);
                        //------------------------------------------------------------------------
                        if (SendMailToUser)
                            SendMail(user, usersDataObject, username, pass);
                        //------------------------------------------------------------------------
                        lblResult.CssClass = "operation_done";
                        lblResult.Text = Resources.AdminText.AddingOperationDone;
                        tblControls.Visible = false;
                        //------------------------------------------------------------------------
                        ClearControls();
                        //------------------------------------------------------------------------
                    }
                    else
                    {
                        Membership.DeleteUser(user.UserName);
                        lblResult.CssClass = "operation_error";
                        lblResult.Text = Resources.AdminText.AddingOperationFaild;

                    }
                }
                catch (Exception ex)
                {
                    Membership.DeleteUser(user.UserName);
                    throw ex;
                }
                break;
            case MembershipCreateStatus.DuplicateEmail:
                lblResult.Text = Resources.MemberShip.DuplicateEmail;
                break;
            case MembershipCreateStatus.DuplicateProviderUserKey:
                lblResult.Text = Resources.MemberShip.AccountSuccessfullyFailed;
                break;
            case MembershipCreateStatus.DuplicateUserName:
                lblResult.Text = Resources.MemberShip.DuplicateUserName;
                break;
            case MembershipCreateStatus.InvalidAnswer:
                lblResult.Text = Resources.MemberShip.InvalidAnswer;
                break;
            case MembershipCreateStatus.InvalidEmail:
                lblResult.Text = Resources.MemberShip.InvalidEmail;
                break;
            case MembershipCreateStatus.InvalidPassword:
                lblResult.Text = Resources.MemberShip.InvalidPassword;
                break;
            case MembershipCreateStatus.InvalidProviderUserKey:
                lblResult.Text = Resources.MemberShip.AccountSuccessfullyFailed;
                break;
            case MembershipCreateStatus.InvalidQuestion:
                lblResult.Text = Resources.MemberShip.InvalidQuestion;
                break;
            case MembershipCreateStatus.InvalidUserName:
                lblResult.Text = Resources.MemberShip.InvalidUserName;
                break;
            case MembershipCreateStatus.ProviderError:
                lblResult.Text = Resources.MemberShip.AccountSuccessfullyFailed;
                break;
            case MembershipCreateStatus.UserRejected:
                lblResult.Text = Resources.MemberShip.UserRejected;
                break;
            default:
                lblResult.Text = "";
                break;
        }
    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region ---------------SendMail---------------
    //-----------------------------------------------
    //SendMail
    //-----------------------------------------------
    protected void SendMail(MembershipUser user, UsersDataEntity usersData, string username, string pass)
    {
        MailListEmailsEntity mail = new MailListEmailsEntity();
        string subject = "";
        string body = "";
        mail.To.Add(user.Email);
        //---------------------------------------------------------------------------------------------------------------
        subject = Resources.AdminText.AdminMessage_NewUserAccountCreationSubject;
        //---------------------------------------------------------------------------------------------------------------
        if (currentModule.SendingAcountDataInActivationMail)
        {
            string accountData=BuilAccountDataForMail(user, usersData, username, pass); 
            body = string.Format(Resources.AdminText.AdminMessage_NewUserAccountCreationBody2, accountData);
        }
        else
        {
            body = string.Format(Resources.AdminText.AdminMessage_NewUserAccountCreationBody, username, pass);
        }
        //---------------------------------------------------------------------------------------------------------------
        mail.Subject = subject;
        mail.Body = body;
        MailListEmailsFactory.Send(mail);
    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region ---------------BuilAccountDataForMail---------------
    //-----------------------------------------------
    //BuilAccountDataForMail
    //-----------------------------------------------
    protected string BuilAccountDataForMail(MembershipUser user, UsersDataEntity usersData, string username, string pass)
    {
        string str = "<table style='width:auto; direction:" + Resources.Lang.Dir + "'>";
        //-------------------------------------------------------------------
        //UserName
        //-------------------------------------------------------------------
        str += BuildRowOfData(Resources.MemberShip.UserName, username);
        //-------------------------------------------------------------------
        //Password
        //-------------------------------------------------------------------
        str += BuildRowOfData(Resources.MemberShip.Password, pass);
        //-------------------------------------------------------------------
        //Email
        //-------------------------------------------------------------------
        str += BuildRowOfData(Resources.MemberShip.Email, user.Email);
        //-------------------------------------------------------------------
        //Name
        //-------------------------------------------------------------------
        if (currentModule.HasName && !string.IsNullOrEmpty(usersData.Name))
            str += BuildRowOfData(Resources.UsersData.Name, usersData.Name);
        //-------------------------------------------------------------------
        //JobText
        //-------------------------------------------------------------------
        if (currentModule.HasJobText && !string.IsNullOrEmpty(usersData.JobText))
            str += BuildRowOfData(Resources.UsersData.JobText, usersData.JobText);
        //-------------------------------------------------------------------
        //EmpNo
        //-------------------------------------------------------------------
        if (currentModule.HasEmpNo && usersData.EmpNo > 0)
            str += BuildRowOfData(Resources.UsersData.EmpNo, usersData.EmpNo.ToString());
        //-------------------------------------------------------------------
        //CountryID
        //-------------------------------------------------------------------
        if (currentModule.HasCountryID && (Convert.ToInt32(ddlSystemCountries.SelectedValue) > 0))
            str += BuildRowOfData(Resources.UsersData.CountryID, ddlSystemCountries.SelectedItem.Text);
        //-------------------------------------------------------------------
        //CityID
        //-------------------------------------------------------------------
        if (currentModule.HasCityID && (Convert.ToInt32(ddlCities.SelectedValue) > 0))
            str += BuildRowOfData(Resources.UsersData.CityID, ddlCities.SelectedItem.Text);
        //-------------------------------------------------------------------
        //CityName
        //-------------------------------------------------------------------
        if (currentModule.HasUserCityName && !string.IsNullOrEmpty(usersData.UserCityName))
            str += BuildRowOfData(Resources.UsersData.CityID, usersData.UserCityName);
        //-------------------------------------------------------------------
        //Company
        //-------------------------------------------------------------------
        if (currentModule.HasCompany && !string.IsNullOrEmpty(usersData.Company))
            str += BuildRowOfData(Resources.UsersData.Company, usersData.Company);
        //-------------------------------------------------------------------
        //ActivitiesID
        //-------------------------------------------------------------------
        if (currentModule.HasActivitiesID && (Convert.ToInt32(ddlActivitiesID.SelectedValue) > 0))
            str += BuildRowOfData(Resources.UsersData.ActivitiesID, ddlActivitiesID.SelectedItem.Text);
        //-------------------------------------------------------------------
        //Url
        //-------------------------------------------------------------------
        if (currentModule.HasUrl && !string.IsNullOrEmpty(usersData.Url))
            str += BuildRowOfData(Resources.UsersData.Url, usersData.Url);
        //-------------------------------------------------------------------
        //Tel
        //-------------------------------------------------------------------
        if (currentModule.HasTel && !string.IsNullOrEmpty(usersData.Tel))
            str += BuildRowOfData(Resources.UsersData.Tel, usersData.Tel);
        //-------------------------------------------------------------------
        //Mobile
        //-------------------------------------------------------------------
        if (currentModule.HasMobile && !string.IsNullOrEmpty(usersData.Mobile))
            str += BuildRowOfData(Resources.UsersData.Mobile, usersData.Mobile);
        //-------------------------------------------------------------------
        //Fax
        //-------------------------------------------------------------------
        if (currentModule.HasFax && !string.IsNullOrEmpty(usersData.Fax))
            str += BuildRowOfData(Resources.UsersData.Fax, usersData.Fax);
        //-------------------------------------------------------------------
        //MailBox
        //-------------------------------------------------------------------
        if (currentModule.HasMailBox && !string.IsNullOrEmpty(usersData.MailBox))
            str += BuildRowOfData(Resources.UsersData.MailBox, usersData.MailBox);
        //-------------------------------------------------------------------
        //ZipCode
        //-------------------------------------------------------------------
        if (currentModule.HasZipCode && !string.IsNullOrEmpty(usersData.ZipCode))
            str += BuildRowOfData(Resources.UsersData.ZipCode, usersData.ZipCode);
        //-------------------------------------------------------------------
        // str += BuildRowOfData(Resources.UsersData.HasSmsService, usersData.XXXXXXXXX);
        // str += BuildRowOfData(Resources.UsersData.HasEmailService, usersData.XXXXXXXXX);
        //-------------------------------------------------------------------
        //AgeRang
        //-------------------------------------------------------------------
        if (currentModule.HasAgeRang && (Convert.ToInt32(ddlAgeRang.SelectedValue) > 0))
            str += BuildRowOfData(Resources.UsersData.AgeRang, ddlAgeRang.SelectedItem.Text);
        //-------------------------------------------------------------------
        //Gender
        //-------------------------------------------------------------------
        if (currentModule.HasGender && (Convert.ToInt32(ddlGender.SelectedValue) > 0))
            str += BuildRowOfData(Resources.UsersData.Gender, ddlGender.SelectedItem.Text);
        //-------------------------------------------------------------------
        //BirthDate
        //-------------------------------------------------------------------
        if (currentModule.HasBirthDate && !string.IsNullOrEmpty(usersData.BirthDate))
            str += BuildRowOfData(Resources.UsersData.BirthDate, usersData.BirthDate);
        //-------------------------------------------------------------------
        //SocialStatus
        //-------------------------------------------------------------------
        if (currentModule.HasSocialStatus && (Convert.ToInt32(ddlSocialStatus.SelectedValue) > 0))
            str += BuildRowOfData(Resources.UsersData.SocialStatus, ddlSocialStatus.SelectedItem.Text);
        //-------------------------------------------------------------------
        //
        //-------------------------------------------------------------------
        if (currentModule.HasEducationLevel && (Convert.ToInt32(ddlEducationLevel.SelectedValue) > 0))
            str += BuildRowOfData(Resources.UsersData.EducationLevel, ddlEducationLevel.SelectedItem.Text);
        //-------------------------------------------------------------------
        //Category
        //-------------------------------------------------------------------
        if (currentModule.CategoryLevel != 0 && (Convert.ToInt32(ddlCategoryID.SelectedValue) > 0))
            str += BuildRowOfData(Resources.UsersData.CategoryID, ddlCategoryID.SelectedItem.Text);
        //-------------------------------------------------------------------
        //-------------------------------------------------------------------
       
        //-------------------------------------------------------------------
        //JobID
        //-------------------------------------------------------------------
        if (currentModule.HasJobID && !string.IsNullOrEmpty(usersData.JobID.ToString()))
            str += BuildRowOfData(Resources.UsersData.JobID, usersData.JobID.ToString());
        //-------------------------------------------------------------------
        str += BuildRowOfData(Resources.UsersData.ExtraText1, txtDetails.Text);

        /*
        //-------------------------------------------------------------------
        //PhotoExtension
        //-------------------------------------------------------------------
        if (currentModule.Has.XXXXXXXXXXXXXXXXXXXXX && !string.IsNullOrEmpty(usersData.XXXXXXXXXXXXXXXXXXXXX))
            str += BuildRowOfData(Resources.UsersData.XXXXXXXXXXXXXXXXXXXXX, usersData.XXXXXXXXXXXXXXXXXXXXX);
        //-------------------------------------------------------------------
        //HasSmsService
        //-------------------------------------------------------------------
        if (currentModule.Has.XXXXXXXXXXXXXXXXXXXXX && !string.IsNullOrEmpty(usersData.XXXXXXXXXXXXXXXXXXXXX))
            str += BuildRowOfData(Resources.UsersData.XXXXXXXXXXXXXXXXXXXXX, usersData.XXXXXXXXXXXXXXXXXXXXX);
        //-------------------------------------------------------------------
        //HasEmailService
        //-------------------------------------------------------------------
        if (currentModule.Has.XXXXXXXXXXXXXXXXXXXXX && !string.IsNullOrEmpty(usersData.XXXXXXXXXXXXXXXXXXXXX))
            str += BuildRowOfData(Resources.UsersData.XXXXXXXXXXXXXXXXXXXXX, usersData.XXXXXXXXXXXXXXXXXXXXX);
        //-------------------------------------------------------------------
        */
        str += "</table>";
        return str;
    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region ---------------BuildRowOfData---------------
    //-----------------------------------------------
    //BuildRowOfData
    //-----------------------------------------------
    public string BuildRowOfData(string text, string data)
    {
        string row = "<tr><td><b>{0}</b></td><td>{1}</td></tr>";
        return string.Format(row, text, data);
    }
    //-----------------------------------------------
    #endregion
    //-------------------------------------------------------
    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    private void ClearControls()
    {

        
        //--------------------
        txtUserName.Text = "";
        txtPassword.Text = "";
        txtConfirmPassword.Text = "";
        txtEmail.Text = "";
        //txtConfirmEmail.Text = "";
        txtName.Text = "";
        ddlAgeRang.SelectedIndex = -1;
        ddlGender.SelectedIndex = -1;
        ucDateBirthDate.ClearControls();
        ddlSocialStatus.SelectedIndex = -1;
        ddlEducationLevel.SelectedIndex = -1;
        ddlSystemCountries.SelectedIndex = -1;
        ddlCities.SelectedIndex = -1;
        txtUserCityName.Text = "";
        txtTel.Text = "";
        txtMobile.Text = "";
        cbHasSmsService.Checked = false;
        cbHasEmailService.Checked = false;
        //--------------------------------
        txtEmpNo.Text = "";
        //--------------------------------
        ddlSystemCountries.SelectedIndex = -1;
        ddlCities.Items.Clear();
        txtUserCityName.Text = "";
        txtTel.Text = "";
        txtMobile.Text = "";
        cbHasSmsService.Checked = false;
        cbHasEmailService.Checked = false;


        txtFax.Text = "";
        txtMailBox.Text = "";
        txtZipCode.Text = "";
        txtJobID.Text = "";
        txtJobText.Text = "";
        txtUrl.Text = "";
        txtCompany.Text = "";
        ddlActivitiesID.SelectedIndex = -1;
        //--------------------------------
        //ExtraData
        //--------------------------------
        txtDetails.Text = "";
        //--------------------------------

        ddlCategoryID.SelectedIndex = -1;
        //--------------------------------
        //----------------------------------------------------------------------
        txtMetaKeyWordsAr.Text = "";
        txtShortDescriptionAr.Text = "";
        //----------------------------------------------------------------------
        cbIsConsultant.Checked = false;
    }
    //--------------------------------------------------------
    #endregion
    
    
}

