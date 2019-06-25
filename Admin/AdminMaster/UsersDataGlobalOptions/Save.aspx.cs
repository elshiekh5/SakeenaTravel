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


public partial class AdminUsersDataGlobalOptions_Create : MasterAdminMasterPage
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
            Load_ddlUserType();
            Load_ddlSubSiteType();
            LoadData();
		}
	}
	//-----------------------------------------------
	#endregion
    
    #region----------Load_ddlUserType----------
    //-------------------------------------------------
    //Load_ddlUserType
    //-------------------------------------------------
    protected void Load_ddlUserType()
    {
        string[] names = Enum.GetNames(typeof(UsersTypes));
        Array values = Enum.GetValues(typeof(UsersTypes));
        for (int i = 0; i < names.Length; i++)
        {
            ddlUserType.Items.Add(new ListItem(names[i], ((int)values.GetValue(i)).ToString()));
        }
    }
    //-----------------------------------------------
    #endregion

    #region----------Load_ddlSubSiteType----------
    //-------------------------------------------------
    //Load_ddlSubSiteType
    //-------------------------------------------------
    protected void Load_ddlSubSiteType()
    {
        string[] names = Enum.GetNames(typeof(SubSiteTypes));
        Array values = Enum.GetValues(typeof(SubSiteTypes));
        for (int i = 0; i < names.Length; i++)
        {
            ddlSubSiteType.Items.Add(new ListItem(names[i], ((int)values.GetValue(i)).ToString()));
        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        int moduleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            moduleTypeID = (int)Convert.ToInt32(Request.QueryString["id"]);
        }
        UsersDataGlobalOptions usersDataGlobalOptions = UsersDataGlobalOptions.GetType(moduleTypeID);
        //------------------------------------------------------------
        if (moduleTypeID > 0)
        {
            txtModuleTypeID.Text = moduleTypeID.ToString();
        }
        else
        {
            txtModuleTypeID.Text = "";
        }
        if (usersDataGlobalOptions.Identifire.ToLower() != "unknown")
        {
            txtIdentifire.Text = usersDataGlobalOptions.Identifire;
        }
        else
        {
            txtIdentifire.Text = "";
        }
        //------------------------------------------------------------
        cbHasEmpNo.Checked = usersDataGlobalOptions.HasEmpNo;
        cbHasBirthDate.Checked = usersDataGlobalOptions.HasBirthDate;
        cbHasCityID.Checked = usersDataGlobalOptions.HasCityID;
        cbHasCountryID.Checked = usersDataGlobalOptions.HasCountryID;
        cbHasNationalityID.Checked = usersDataGlobalOptions.HasNationalityID;
        cbHasGender.Checked = usersDataGlobalOptions.HasGender;
        cbHasName.Checked = usersDataGlobalOptions.HasName;
        cbNameSeprated.Checked = usersDataGlobalOptions.HasNameSeparated;
        cbHasNotes2.Checked = usersDataGlobalOptions.HasNotes2;
        cbHasNotes1.Checked = usersDataGlobalOptions.HasNotes1;
        cbHasTel.Checked = usersDataGlobalOptions.HasTel;
        cbHasMobile.Checked = usersDataGlobalOptions.HasMobile;
        cbHasUserCityName.Checked = usersDataGlobalOptions.HasUserCityName;
        cbHasUserId.Checked = usersDataGlobalOptions.HasUserId;
        cbHasAgeRang.Checked = usersDataGlobalOptions.HasAgeRang;
        cbHasEducationLevel.Checked = usersDataGlobalOptions.HasEducationLevel;
        cbHasSocialStatus.Checked = usersDataGlobalOptions.HasSocialStatus;
        cbHasFax.Checked = usersDataGlobalOptions.HasFax;
        cbHasMailBox.Checked = usersDataGlobalOptions.HasMailBox;
        cbHasZipCode.Checked = usersDataGlobalOptions.HasZipCode;
        cbHasJobID.Checked = usersDataGlobalOptions.HasJobID;
        cbHasJobText.Checked = usersDataGlobalOptions.HasJobText;
        cbHasUrl.Checked = usersDataGlobalOptions.HasUrl;
        cbHasPhotoExtension.Checked = usersDataGlobalOptions.HasPhotoExtension;
        txtPhotoAvailableExtension.Text = usersDataGlobalOptions.PhotoAvailableExtension;
        txtPhotoMaxSize.Text = usersDataGlobalOptions.PhotoMaxSize.ToString();
        cbHasCompany.Checked = usersDataGlobalOptions.HasCompany;
        cbHasActivitiesID.Checked = usersDataGlobalOptions.HasActivitiesID;
        cbAutomaticApproved.Checked = usersDataGlobalOptions.AutomaticApproved;
        ddlExtraDataCount.SelectedValue = usersDataGlobalOptions.ExtraDataCount.ToString();
        cbRequiredEmpNo.Checked = usersDataGlobalOptions.RequiredEmpNo;
        cbRequiredBirthDate.Checked = usersDataGlobalOptions.RequiredBirthDate;
        cbRequiredCityID.Checked = usersDataGlobalOptions.RequiredCityID;
        cbRequiredCountryID.Checked = usersDataGlobalOptions.RequiredCountryID;
        cbRequiredNationalityID.Checked = usersDataGlobalOptions.RequiredNationalityID;
        cbRequiredGender.Checked = usersDataGlobalOptions.RequiredGender;
        cbRequiredName.Checked = usersDataGlobalOptions.RequiredName;
        cbRequiredNotes2.Checked = usersDataGlobalOptions.RequiredNotes2;
        cbRequiredNotes1.Checked = usersDataGlobalOptions.RequiredNotes1;
        cbRequiredTel.Checked = usersDataGlobalOptions.RequiredTel;
        cbRequiredMobile.Checked = usersDataGlobalOptions.RequiredMobile;
        cbRequiredUserCityName.Checked = usersDataGlobalOptions.RequiredUserCityName;
        cbRequiredAgeRang.Checked = usersDataGlobalOptions.RequiredAgeRang;
        cbRequiredEducationLevel.Checked = usersDataGlobalOptions.RequiredEducationLevel;
        cbRequiredSocialStatus.Checked = usersDataGlobalOptions.RequiredSocialStatus;
        cbRequiredFax.Checked = usersDataGlobalOptions.RequiredFax;
        cbRequiredMailBox.Checked = usersDataGlobalOptions.RequiredMailBox;
        cbRequiredZipCode.Checked = usersDataGlobalOptions.RequiredZipCode;
        cbRequiredJobID.Checked = usersDataGlobalOptions.RequiredJobID;
        cbRequiredJobText.Checked = usersDataGlobalOptions.RequiredJobText;
        cbRequiredUrl.Checked = usersDataGlobalOptions.RequiredUrl;
        cbRequiredPhotoExtension.Checked = usersDataGlobalOptions.RequiredPhotoExtension;
        cbRequiredCompany.Checked = usersDataGlobalOptions.RequiredCompany;
        cbRequiredActivitiesID.Checked = usersDataGlobalOptions.RequiredActivitiesID;
        cbRequiredExtraData1.Checked = usersDataGlobalOptions.RequiredExtraData1;
        cbRequiredExtraData2.Checked = usersDataGlobalOptions.RequiredExtraData2;
        cbRequiredExtraData3.Checked = usersDataGlobalOptions.RequiredExtraData3;
        cbRequiredExtraData4.Checked = usersDataGlobalOptions.RequiredExtraData4;
        cbRequiredExtraData5.Checked = usersDataGlobalOptions.RequiredExtraData5;
        cbRequiredExtraData6.Checked = usersDataGlobalOptions.RequiredExtraData6;
        txtUserRole.Text = usersDataGlobalOptions.UserRole;
        cbHasAddUserInAdmin.Checked = usersDataGlobalOptions.HasAddUserInAdmin;
        //---------------------------------------------------------------------
        cbHasOwenFolder_Admin.Checked = usersDataGlobalOptions.HasOwenFolder_Admin;
        cbHasOwenFolder_User.Checked = usersDataGlobalOptions.HasOwenFolder_User;
        txtModuleSpecialPath.Text = usersDataGlobalOptions.ModuleSpecialPath;
        //---------------------------------------------------------------------
        cbHasExportData.Checked = usersDataGlobalOptions.HasExportData;
        //---------------------------------------------------------------------
        txtResourceFile.Text = usersDataGlobalOptions.ResourceFile;
        txtDefaultResourceFile.Text = usersDataGlobalOptions.DefaultResourceFile;
        cbHasSpecialAdminText.Checked = usersDataGlobalOptions.HasSpecialAdminText;

        cbHasHasEmailService.Checked = usersDataGlobalOptions.HasHasEmailService;
        cbMailListAutomaticRegistration.Checked = usersDataGlobalOptions.MailListAutomaticRegistration;
        cbMailListSendingMailActivation.Checked = usersDataGlobalOptions.MailListSendingMailActivation;
        cbMailListAutomaticActivation.Checked = usersDataGlobalOptions.MailListAutomaticActivation;
        cbSendingAcountDataInActivationMail.Checked = usersDataGlobalOptions.SendingAcountDataInActivationMail;
        cbHasHasSmsService.Checked = usersDataGlobalOptions.HasHasSmsService;
        cbSmsAutomaticRegistration.Checked = usersDataGlobalOptions.SmsAutomaticRegistration;
        cbSmsSendingSmsActivation.Checked = usersDataGlobalOptions.SmsSendingSmsActivation;
        cbSmsAutomaticActivation.Checked = usersDataGlobalOptions.SmsAutomaticActivation;
        txtCategoryLevel.Text = usersDataGlobalOptions.CategoryLevel.ToString();
        cbCanUserAssignHimSelfToCategory.Checked = usersDataGlobalOptions.CanUserAssignHimSelfToCategory;
        cbAddInAdminMenuAutmaticly.Checked = usersDataGlobalOptions.AddInAdminMenuAutmaticly;
        //----------------------------------------------------------
        txtModuleRelatedPageID.Text = usersDataGlobalOptions.ModuleRelatedPageID.ToString();
        //----------------------------------------------------------
        cbHasOwnerID.Checked = usersDataGlobalOptions.HasOwnerID;
        //----------------------------------------------------------
        cbHasProfilePage.Checked = usersDataGlobalOptions.HasProfilePage;
        //-------------------------------------------------------------------------------------------
        txtPageItemCount_UserDefault.Text = usersDataGlobalOptions.PageItemCount_UserDefault.ToString();
        txtPageItemCount_AdminDefault.Text = usersDataGlobalOptions.PageItemCount_AdminDefault.ToString();
        cbShowInSiteDepartments.Checked = usersDataGlobalOptions.ShowInSiteDepartments;
        //-------------------------------------------------------------------------------------------
        cbDisplayCategoriesInAdminMenue.Checked = usersDataGlobalOptions.DisplayCategoriesInAdminMenue;
        txtModuleMetaKeyWords.Text = usersDataGlobalOptions.ModuleMetaKeyWords;
        txtModuleMetaDescription.Text = usersDataGlobalOptions.ModuleMetaDescription;
        cbHasMetaKeyWords.Checked = usersDataGlobalOptions.HasMetaKeyWords;
        cbHasMetaDescription.Checked = usersDataGlobalOptions.HasMetaDescription;
        cbUserCanSendMeta.Checked = usersDataGlobalOptions.UserCanSendMeta;
        //-------------------------------------------------------------------------------------------
        cbHasSearch.Checked = usersDataGlobalOptions.HasSearech;
        //-------------------------------------------------------------------------------------------
        txtListID.Text = usersDataGlobalOptions.ListID;
        //-------------------------------------------------------------------------------------------
        cbHasIsConsultant.Checked = usersDataGlobalOptions.HasIsConsultant;
        //-------------------------------------------------------------------------------------------
        ddlUserType.SelectedValue = ((int)usersDataGlobalOptions.UserType).ToString();
        //-------------------------------------------------------------------------------------------
        //Sub sites options
        //--------------------------------------
        cbHasSiteTitle.Checked = usersDataGlobalOptions.HasSiteTitle;
        cbHasSkinID.Checked = usersDataGlobalOptions.HasSkinID;
        cbHasVisitorsCount.Checked = usersDataGlobalOptions.HasVisitorsCount;
        cbHasSiteModules.Checked = usersDataGlobalOptions.HasSiteModules;
        cbHasSiteStaticPages.Checked = usersDataGlobalOptions.HasSiteStaticPages;
        //-------------------------------------------------------------------------------------------
        cbHasProfile.Checked = usersDataGlobalOptions.HasProfile;
        //-------------------------------------------------------------------------------------------
        ddlSubSiteType.SelectedValue = ((int)usersDataGlobalOptions.SubSiteType).ToString();
        //-------------------------------------------------------------------------------------------
        ResourcesFilesManager rfmArabic = new ResourcesFilesManager(ResourcesFilesManager.ModuleResourceFileArabic);
        txtModuleTitleArabic.Text = rfmArabic.GetNodeValue(usersDataGlobalOptions.ModuleTitle);
        txtModuleAdminSpecialTitleArabic.Text = rfmArabic.GetNodeValue(usersDataGlobalOptions.ModuleAdminSpecialTitle);
        //----------------------------------------------------
        ResourcesFilesManager rfmEnglish = new ResourcesFilesManager(ResourcesFilesManager.ModuleResourceFileEnglish);
        txtModuleTitleEnglish.Text = rfmEnglish.GetNodeValue(usersDataGlobalOptions.ModuleTitle);
        txtModuleAdminSpecialTitleEnglish.Text = rfmEnglish.GetNodeValue(usersDataGlobalOptions.ModuleAdminSpecialTitle);
        //-----------------------------------------------------------


    }
    //-----------------------------------------------
    #endregion

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
        //--------------------------------------------------------
        int moduleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            moduleTypeID = (int)Convert.ToInt32(Request.QueryString["id"]);
        }
        UsersDataGlobalOptions usersDataGlobalOptions = UsersDataGlobalOptions.GetType(moduleTypeID);
        //------------------------------------
        if (moduleTypeID == (int)StandardItemsModuleTypes.UnKnowen)
            usersDataGlobalOptions.ModuleTypeID = Convert.ToInt32(txtModuleTypeID.Text);
        //------------------------------------
        usersDataGlobalOptions.Identifire = txtIdentifire.Text.Trim();
        //--------------------------------------------------------
        usersDataGlobalOptions.HasEmpNo = cbHasEmpNo.Checked;
        usersDataGlobalOptions.HasBirthDate = cbHasBirthDate.Checked;
        usersDataGlobalOptions.HasCityID = cbHasCityID.Checked;
        usersDataGlobalOptions.HasCountryID = cbHasCountryID.Checked;
        usersDataGlobalOptions.HasNationalityID = cbHasNationalityID.Checked;
        usersDataGlobalOptions.HasGender = cbHasGender.Checked;
        usersDataGlobalOptions.HasName = cbHasName.Checked;
        usersDataGlobalOptions.HasNameSeparated = cbNameSeprated.Checked;
        usersDataGlobalOptions.HasNotes2 = cbHasNotes2.Checked;
        usersDataGlobalOptions.HasNotes1 = cbHasNotes1.Checked;
        usersDataGlobalOptions.HasTel = cbHasTel.Checked;
        usersDataGlobalOptions.HasMobile = cbHasMobile.Checked;
        usersDataGlobalOptions.HasUserCityName = cbHasUserCityName.Checked;
        usersDataGlobalOptions.HasUserId = cbHasUserId.Checked;
        usersDataGlobalOptions.HasAgeRang = cbHasAgeRang.Checked;
        usersDataGlobalOptions.HasEducationLevel = cbHasEducationLevel.Checked;
        usersDataGlobalOptions.HasSocialStatus = cbHasSocialStatus.Checked;
        usersDataGlobalOptions.HasFax = cbHasFax.Checked;
        usersDataGlobalOptions.HasMailBox = cbHasMailBox.Checked;
        usersDataGlobalOptions.HasZipCode = cbHasZipCode.Checked;
        usersDataGlobalOptions.HasJobID = cbHasJobID.Checked;
        usersDataGlobalOptions.HasJobText = cbHasJobText.Checked;
        usersDataGlobalOptions.HasUrl = cbHasUrl.Checked;
        usersDataGlobalOptions.HasPhotoExtension = cbHasPhotoExtension.Checked;
        usersDataGlobalOptions.PhotoAvailableExtension = txtPhotoAvailableExtension.Text;
        usersDataGlobalOptions.PhotoMaxSize = Convert.ToInt32(txtPhotoMaxSize.Text);
        usersDataGlobalOptions.HasCompany = cbHasCompany.Checked;
        usersDataGlobalOptions.HasActivitiesID = cbHasActivitiesID.Checked;
        usersDataGlobalOptions.AutomaticApproved = cbAutomaticApproved.Checked;
        usersDataGlobalOptions.ExtraDataCount = Convert.ToInt32(ddlExtraDataCount.SelectedValue);
        usersDataGlobalOptions.RequiredEmpNo = cbRequiredEmpNo.Checked;
        usersDataGlobalOptions.RequiredBirthDate = cbRequiredBirthDate.Checked;
        usersDataGlobalOptions.RequiredCityID = cbRequiredCityID.Checked;
        usersDataGlobalOptions.RequiredCountryID = cbRequiredCountryID.Checked;
        usersDataGlobalOptions.RequiredNationalityID = cbRequiredNationalityID.Checked;
        usersDataGlobalOptions.RequiredGender = cbRequiredGender.Checked;
        usersDataGlobalOptions.RequiredName = cbRequiredName.Checked;
        usersDataGlobalOptions.RequiredNotes2 = cbRequiredNotes2.Checked;
        usersDataGlobalOptions.RequiredNotes1 = cbRequiredNotes1.Checked;
        usersDataGlobalOptions.RequiredTel = cbRequiredTel.Checked;
        usersDataGlobalOptions.RequiredMobile = cbRequiredMobile.Checked;
        usersDataGlobalOptions.RequiredUserCityName = cbRequiredUserCityName.Checked;
        usersDataGlobalOptions.RequiredAgeRang = cbRequiredAgeRang.Checked;
        usersDataGlobalOptions.RequiredEducationLevel = cbRequiredEducationLevel.Checked;
        usersDataGlobalOptions.RequiredSocialStatus = cbRequiredSocialStatus.Checked;
        usersDataGlobalOptions.RequiredFax = cbRequiredFax.Checked;
        usersDataGlobalOptions.RequiredMailBox = cbRequiredMailBox.Checked;
        usersDataGlobalOptions.RequiredZipCode = cbRequiredZipCode.Checked;
        usersDataGlobalOptions.RequiredJobID = cbRequiredJobID.Checked;
        usersDataGlobalOptions.RequiredJobText = cbRequiredJobText.Checked;
        usersDataGlobalOptions.RequiredUrl = cbRequiredUrl.Checked;
        usersDataGlobalOptions.RequiredPhotoExtension = cbRequiredPhotoExtension.Checked;
        usersDataGlobalOptions.RequiredCompany = cbRequiredCompany.Checked;
        usersDataGlobalOptions.RequiredActivitiesID = cbRequiredActivitiesID.Checked;
        usersDataGlobalOptions.RequiredExtraData1 = cbRequiredExtraData1.Checked;
        usersDataGlobalOptions.RequiredExtraData2 = cbRequiredExtraData2.Checked;
        usersDataGlobalOptions.RequiredExtraData3 = cbRequiredExtraData3.Checked;
        usersDataGlobalOptions.RequiredExtraData4 = cbRequiredExtraData4.Checked;
        usersDataGlobalOptions.RequiredExtraData5 = cbRequiredExtraData5.Checked;
        usersDataGlobalOptions.RequiredExtraData6 = cbRequiredExtraData6.Checked;
        usersDataGlobalOptions.UserRole = txtUserRole.Text;
        usersDataGlobalOptions.HasAddUserInAdmin = cbHasAddUserInAdmin.Checked;
        //---------------------------------------------------------------------
        usersDataGlobalOptions.HasOwenFolder_Admin = cbHasOwenFolder_Admin.Checked;
        usersDataGlobalOptions.HasOwenFolder_User = cbHasOwenFolder_User.Checked;
        usersDataGlobalOptions.ModuleSpecialPath = txtModuleSpecialPath.Text;
        //---------------------------------------------------------------------
        usersDataGlobalOptions.HasExportData = cbHasExportData.Checked;
        //---------------------------------------------------------------------
        usersDataGlobalOptions.ModuleTitle = usersDataGlobalOptions.CreateModuleTitleIdentifire();
        usersDataGlobalOptions.ModuleAdminSpecialTitle = usersDataGlobalOptions.CreateModuleAdminSpecialTitleIdentifire();
        //---------------------------------------------------------------------
        usersDataGlobalOptions.ResourceFile = txtResourceFile.Text;
        usersDataGlobalOptions.DefaultResourceFile = txtDefaultResourceFile.Text;
        usersDataGlobalOptions.HasSpecialAdminText = cbHasSpecialAdminText.Checked;

        usersDataGlobalOptions.HasHasEmailService = cbHasHasEmailService.Checked;
        usersDataGlobalOptions.MailListAutomaticRegistration = cbMailListAutomaticRegistration.Checked;
        usersDataGlobalOptions.MailListSendingMailActivation = cbMailListSendingMailActivation.Checked;
        usersDataGlobalOptions.MailListAutomaticActivation = cbMailListAutomaticActivation.Checked;
        usersDataGlobalOptions.SendingAcountDataInActivationMail = cbSendingAcountDataInActivationMail.Checked;
        usersDataGlobalOptions.HasHasSmsService = cbHasHasSmsService.Checked;
        usersDataGlobalOptions.SmsAutomaticRegistration = cbSmsAutomaticRegistration.Checked;
        usersDataGlobalOptions.SmsSendingSmsActivation = cbSmsSendingSmsActivation.Checked;
        usersDataGlobalOptions.SmsAutomaticActivation = cbSmsAutomaticActivation.Checked;
        usersDataGlobalOptions.CategoryLevel = Convert.ToInt32(txtCategoryLevel.Text);
        usersDataGlobalOptions.CanUserAssignHimSelfToCategory = cbCanUserAssignHimSelfToCategory.Checked;
        usersDataGlobalOptions.AddInAdminMenuAutmaticly = cbAddInAdminMenuAutmaticly.Checked;
        //-----------------------------------------------------------------------
        usersDataGlobalOptions.ModuleRelatedPageID = Convert.ToInt32(txtModuleRelatedPageID.Text);
        //-----------------------------------------------------------------------
        usersDataGlobalOptions.HasOwnerID = cbHasOwnerID.Checked;
        //-----------------------------------------------------------------------
        usersDataGlobalOptions.HasProfilePage = cbHasProfilePage.Checked;
        //-------------------------------------------------------------------------------------------
        usersDataGlobalOptions.PageItemCount_UserDefault = Convert.ToInt32(txtPageItemCount_UserDefault.Text);
        usersDataGlobalOptions.PageItemCount_AdminDefault = Convert.ToInt32(txtPageItemCount_AdminDefault.Text);
        usersDataGlobalOptions.ShowInSiteDepartments = cbShowInSiteDepartments.Checked;
        //-------------------------------------------------------------------------------------------
        usersDataGlobalOptions.DisplayCategoriesInAdminMenue = cbDisplayCategoriesInAdminMenue.Checked;
        usersDataGlobalOptions.ModuleMetaKeyWords = txtModuleMetaKeyWords.Text;
        usersDataGlobalOptions.ModuleMetaDescription = txtModuleMetaDescription.Text;
        usersDataGlobalOptions.HasMetaKeyWords = cbHasMetaKeyWords.Checked;
        usersDataGlobalOptions.HasMetaDescription = cbHasMetaDescription.Checked;
        usersDataGlobalOptions.UserCanSendMeta = cbUserCanSendMeta.Checked;
        //-------------------------------------------------------------------------------------------
        usersDataGlobalOptions.HasSearech = cbHasSearch.Checked;
        //-------------------------------------------------------------------------------------------
        usersDataGlobalOptions.ListID = txtListID.Text;
        //-------------------------------------------------------------------------------------------
        usersDataGlobalOptions.HasIsConsultant = cbHasIsConsultant.Checked;
        //-------------------------------------------------------------------------------------------
        usersDataGlobalOptions.UserType = (UsersTypes)Convert.ToInt32(ddlUserType.SelectedValue);
        //-------------------------------------------------------------------------------------------
        //Sub sites options
        //--------------------------------------
        usersDataGlobalOptions.HasSiteTitle = cbHasSiteTitle.Checked;
        usersDataGlobalOptions.HasSkinID = cbHasSkinID.Checked;
        usersDataGlobalOptions.HasVisitorsCount = cbHasVisitorsCount.Checked;
        usersDataGlobalOptions.HasSiteModules = cbHasSiteModules.Checked;
        usersDataGlobalOptions.HasSiteStaticPages = cbHasSiteStaticPages.Checked;
        //-------------------------------------------------------------------------------------------
        usersDataGlobalOptions.HasProfile = cbHasProfile.Checked;
        //-------------------------------------------------------------------------------------------
        usersDataGlobalOptions.SubSiteType = (SubSiteTypes)Convert.ToInt32(ddlSubSiteType.SelectedValue);
        //-------------------------------------------------------------------------------------------
        SiteModulesManager sm = SiteModulesManager.Instance;
        bool status = sm.SaveModule(usersDataGlobalOptions);
        //-----------------------------------------------------------------------
        if (status)
        {
            //--------------------------------------------------------------------
            ResourcesFilesManager.SaveResourcesData(usersDataGlobalOptions.ModuleTitle, txtModuleTitleArabic.Text, txtModuleTitleEnglish.Text);
            //--------------------------------------------------------------------
            if (txtModuleAdminSpecialTitleArabic.Text.Trim().Length == 0)
            { txtModuleAdminSpecialTitleArabic.Text = txtModuleTitleArabic.Text; }
            //--------------------------------------------------------------------
            if (txtModuleAdminSpecialTitleEnglish.Text.Trim().Length == 0)
            { txtModuleAdminSpecialTitleEnglish.Text = txtModuleTitleEnglish.Text; }
            //--------------------------------------------------------------------
            ResourcesFilesManager.SaveResourcesData(usersDataGlobalOptions.ModuleAdminSpecialTitle, txtModuleAdminSpecialTitleArabic.Text, txtModuleAdminSpecialTitleEnglish.Text);
            //--------------------------------------------------------------------
            if (!MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
            {
                lblResult.ForeColor = Color.Blue;
                lblResult.Text = Resources.AdminText.AddingOperationDone;
                ClearControls();
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
        else
        {
            lblResult.ForeColor = Color.Red;
            lblResult.Text = Resources.AdminText.AddingOperationFaild;
        }
    }
    //-----------------------------------------------
    #endregion

    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    private void ClearControls()
    {
        LoadData();
    }
    //--------------------------------------------------------
    #endregion


}
