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


public partial class SiteDeparments_Create : System.Web.UI.UserControl
{
    TextBox txtTitle;
    TextBox txtShortDescription;
    TextBox txtMetaKeyWords;

    CuteEditor.Editor fckDescription;
    TextBox txtDescription;

    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------TypeID--------------
    private SiteDepartmentTypes _TypeID = SiteDepartmentTypes.SiteDeparment;
    public SiteDepartmentTypes TypeID
    {
        get { return _TypeID; }
        set { _TypeID = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------ParentID--------------
    private int _ParentID = -1;
    public int ParentID
    {
        get { return _ParentID; }
        set { _ParentID = value; }
    }
    //------------------------------------------
    #endregion

    SiteDeparmentsOptions currentModule;

	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{
        currentModule = SiteDeparmentsOptions.GetType(ModuleTypeID);
        MLangsDetails1.ModuleTypeID = ModuleTypeID;
        MLangsDetails1.TypeOfDetails = DetailsTypes.SiteDepartment;
        lblResult.Text = "";
		if(!IsPostBack)
		{
			LoadData();
		}
	}
	//-----------------------------------------------
	#endregion

    #region ---------------HandleOptionalControls---------------
	//-----------------------------------------------
	//HandleOptionalControls
	//-----------------------------------------------
    protected void HandleOptionalControls()
    {
        /*
        //HasTitle
        trTitle.Visible = currentModule.HasTitle;
        rfvTitle.Visible = currentModule.HasTitle&&currentModule.RequiredSiteDepartmentTitle;
        //-----------------------------------
        //HasShortDescription

        trShortDescription.Visible = currentModule.HasShortDescription;
        rfvShortDescription.Visible = currentModule.HasShortDescription && currentModule.RequiredSiteDepartmentShortDescription;
        *///-----------------------------------
        //HasPhotoExtension
        trPhotoExtension.Visible = currentModule.HasPhotoExtension;
        rfvPhoto.Visible = currentModule.HasPhotoExtension && currentModule.RequiredPhoto;
        //-----------------------------------
        //HasIsAvailable
        trIsAvailable.Visible = currentModule.HasIsAvailable;
        //-----------------------------------
        //-----------------------------------
        //HasUrl
        trUrl.Visible = currentModule.HasUrl;
        rfvUrl.Visible = currentModule.HasUrl && currentModule.RequiredUrl;
        revUrl.ValidationExpression = DCValidation.GetUrlExpression();
        //-----------------------------------
        if (currentModule.HasRelatedModuleTypeID)
        {
            trRelatedModuleTypeID.Visible = true;
            LoadddlRelatedModuleTypeID();
        }
        else
        {
            trRelatedModuleTypeID.Visible = false;
        }
        //-----------------------------------
        trRelatedPageID.Visible = false;
        //-----------------------------------
        LoadParents();
    }
	//-----------------------------------------------
	#endregion

	#region ---------------LoadData---------------
	//-----------------------------------------------
	//LoadData
	//-----------------------------------------------
	protected void LoadData()
	{
        PrepareValidation();
        HandleOptionalControls();
	}
	//-----------------------------------------------
	#endregion

    #region ---------------PrepareValidation---------------
    //-----------------------------------------------
    //PrepareValidation
    //-----------------------------------------------
    protected void PrepareValidation()
    {
        //Photo
        if (!string.IsNullOrEmpty(currentModule.GetPhotoValidationExpression()))
        {
            rxpPhoto.ValidationExpression = currentModule.GetPhotoValidationExpression();
            rxpPhoto.ErrorMessage = Resources.AdminText.NotSuportedFileExtention + currentModule.PhotoAvailableExtension;
        }
        else
        {
            rxpPhoto.Visible = false;
        }
        //-------------------------------------------
    }
    //-----------------------------------------------
    #endregion

	#region ---------------LoadParents---------------
	//-----------------------------------------------
    //LoadParents
	//-----------------------------------------------
	private void LoadParents()
	{
        int siteDepartmentDepth = currentModule.SiteDepartmentsLevel;
        int depthLevel = siteDepartmentDepth - 1;
        if (depthLevel < -1) depthLevel = -1;
        /*if (!currentModule.HasDepartmentID)
        {
            Response.Redirect("/admincp");
        }
        else*/
        if (siteDepartmentDepth == 1)
        {
            trParents.Visible = false;
        }
        else
        {
            string selectedDep = "-1";
            if (ddlParents.SelectedValue != null)
                selectedDep = ddlParents.SelectedValue;
            ddlParents.Items.Clear();
            ParentChildDropDownList n = new ParentChildDropDownList();
            DataTable dtSource = SiteDeparmentsFactory.GetInDataTable(ModuleTypeID, ParentID, Languages.Unknowen, false);
            n.DataBind(ddlParents,ParentID, depthLevel, dtSource, "ParentID", "DepartmentID", "Title");
            //--------------------------------------------------------//
            int defaultID = 0;
            if (ParentID > 0)
                defaultID = ParentID;
            //--------------------------------------------------------//
            ddlParents.Items.Insert(0, new ListItem(Resources.AdminText.Choose, defaultID.ToString()));
            //--------------------------------------------------------//
            ddlParents.SelectedValue = selectedDep;
        }
	}
	//-----------------------------------------------
	#endregion


    #region ---------------LoadddlRelatedModuleTypeID---------------
    //-----------------------------------------------
    //LoadddlRelatedModuleTypeID
	//-----------------------------------------------
    private void LoadddlRelatedModuleTypeID()
	{
        //-----------------------------------------------------------------
        SiteModulesManager siteModules = SiteModulesManager.Instance;
        //-----------------------------------------------------------------
        string moduleText="";
        foreach (ItemsModulesOptions module in siteModules.SiteItemsModulesList)
        {
            if (module.ShowInSiteDepartments)
            {
                moduleText = module.GetModuleAdminSpecialTitle();
                ddlRelatedModuleTypeID.Items.Add(new ListItem(moduleText, module.ModuleTypeID.ToString()));
            }

        }
        foreach (MessagesModuleOptions msgModule in siteModules.SiteMessagesModulesList)
        {
            if (msgModule.ShowInSiteDepartments)
            {
                moduleText = msgModule.GetModuleAdminSpecialTitle();
                ddlRelatedModuleTypeID.Items.Add(new ListItem(moduleText, msgModule.ModuleTypeID.ToString()));
            }
        }
        foreach (UsersDataGlobalOptions userModule in siteModules.SiteUsersDataModulesList)
        {
            if (userModule.ShowInSiteDepartments)
            {
                moduleText = userModule.GetModuleAdminSpecialTitle();
                ddlRelatedModuleTypeID.Items.Add(new ListItem(moduleText, userModule.ModuleTypeID.ToString()));
            }
        }
        ddlRelatedModuleTypeID.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "0"));
	}
	//-----------------------------------------------
	#endregion

    #region ---------------Load_ddlRelatedPageID---------------
    //-----------------------------------------------
    //Load_ddlRelatedPageID
    //-----------------------------------------------
    private void Load_ddlRelatedPageID()
    {
        //-----------------------------------------------------------------
        SiteModulesManager siteModules = SiteModulesManager.Instance;
        //-----------------------------------------------------------------
        string moduleText = "";
        foreach (SitePageOptions page in siteModules.SitePagesList)
        {
            if (page.ShowInSiteDepartments)
            {
                moduleText = page.Title;
                ddlRelatedPageID.Items.Add(new ListItem(moduleText, page.PageID.ToString()));
            }

        }
        ddlRelatedPageID.Items.Insert(0, new ListItem(Resources.AdminText.Choose, "0"));
    }
    //-----------------------------------------------
    #endregion

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
        SiteDeparmentsEntity siteDeparmentsObject = new SiteDeparmentsEntity();
        //siteDeparmentsObject.Title = txtTitle.Text;
        //siteDeparmentsObject.ShortDescription = txtShortDescription.Text;
        siteDeparmentsObject.ModuleTypeID = ModuleTypeID;
        if (trParents.Visible)
            siteDeparmentsObject.ParentID = Convert.ToInt32(ddlParents.SelectedValue);
        //-------------------------------
        siteDeparmentsObject.Url = txtUrl.Text;
        //-------------------------------
        siteDeparmentsObject.TypeID = TypeID;
        //-------------------------------
        siteDeparmentsObject.RelatedModuleTypeID = Convert.ToInt32(ddlRelatedModuleTypeID.SelectedValue);
        //-------------------------------
        if (ddlRelatedPageID.Items.Count>0)
            siteDeparmentsObject.RelatedPageID = Convert.ToInt32(ddlRelatedPageID.SelectedValue);
        //Details -----------------------
        AddDetails(siteDeparmentsObject);
        //------------------------------
        //-------------
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
        }
        siteDeparmentsObject.PhotoExtension = Path.GetExtension(fuPhoto.FileName);
        //-----------------------------------------------------------------
        if (currentModule.HasIsAvailable)
            siteDeparmentsObject.IsAvailable = cbIsAvailable.Checked;
        else
            siteDeparmentsObject.IsAvailable = true;
        //-----------------------------------------------------------------
        ExecuteCommandStatus status = SiteDeparmentsFactory.Create(siteDeparmentsObject);
        if (status == ExecuteCommandStatus.Done)
        {
            //Photo-----------------------------
            if (fuPhoto.HasFile)
            {
                //------------------------------------------------
                //Save new original photo
                fuPhoto.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_SiteDeparmentsPhotoOriginals(siteDeparmentsObject.OwnerName)) + siteDeparmentsObject.Photo);
                //Create new thumbnails
                MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_SiteDeparmentsPhotoNormalThumbs(siteDeparmentsObject.OwnerName), SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(siteDeparmentsObject.DepartmentID), fuPhoto.PostedFile, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight);
                MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_SiteDeparmentsPhotoBigThumbs(siteDeparmentsObject.OwnerName), SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(siteDeparmentsObject.DepartmentID), fuPhoto.PostedFile, SiteSettings.Photos_BigThumnailWidth, SiteSettings.Photos_BigThumnailHeight);
            }
            lblResult.CssClass = "lblResult_Done";
            lblResult.Text = Resources.AdminText.AddingOperationDone;
            ClearControls();
        }
        else if (status == ExecuteCommandStatus.AllreadyExists)
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.DuplicateItem;
        }
        else
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.AddingOperationFaild;
        }
    }
    //--------------------------------------------
    protected void AddDetails(SiteDeparmentsEntity siteDepartment)
    {
        MLanguagesDetailsControls ucArDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucArDetails");
        MLanguagesDetailsControls ucEnDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucEnDetails");
        //if(HasArabic)
        GetDetails(siteDepartment, ucArDetails);
        //if(HasEngrabic)
        GetDetails(siteDepartment, ucEnDetails);
        //----------------------------
    }
    //--------------------------------------------
    protected void GetDetails(SiteDeparmentsEntity siteDepartment, MLanguagesDetailsControls ucDetails)
    {
        LoadDetailsControls(ucDetails);
        if (txtTitle.Text.Length > 0)
        {
            SiteDeparmentsDetailsEntity siteDeparmentsDetailsObject = new SiteDeparmentsDetailsEntity();
            siteDeparmentsDetailsObject.LangID = ucDetails.Lang;
            siteDeparmentsDetailsObject.Title = txtTitle.Text;
            siteDeparmentsDetailsObject.ShortDescription = txtShortDescription.Text;
            siteDeparmentsDetailsObject.KeyWords = txtMetaKeyWords.Text;
            siteDeparmentsDetailsObject.Description = fckDescription.Text;
            siteDepartment.Details[siteDeparmentsDetailsObject.LangID] = siteDeparmentsDetailsObject;

        }
    }

    #region ---------------LoadDetailsControls---------------
    //-----------------------------------------------
    //LoadDetailsControls
    //-----------------------------------------------
    protected void LoadDetailsControls(MLanguagesDetailsControls ucDetails)
    {
        txtTitle = (TextBox)ucDetails.FindControl("txtTitle");
        txtShortDescription = (TextBox)ucDetails.FindControl("txtShortDescription");
        txtMetaKeyWords = (TextBox)ucDetails.FindControl("txtMetaKeyWords");
        txtDescription = (TextBox)ucDetails.FindControl("txtDescription");
        fckDescription = (CuteEditor.Editor)ucDetails.FindControl("fckDescription");
    }
    //-----------------------------------------------
    #endregion
    
    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    private void ClearControls()
    {
        txtUrl.Text = "";
        cbIsAvailable.Checked = true;
        ddlRelatedModuleTypeID.SelectedIndex = -1;
        ddlRelatedPageID.SelectedIndex = -1;
        //-----------------------------------
        MLangsDetails1.ClearControls();
        //-----------------------------------
        LoadParents();
    }
    //--------------------------------------------------------
    #endregion
    protected void ddlRelatedModuleTypeID_SelectedIndexChanged(object sender, EventArgs e)
    {
        int moduleID = Convert.ToInt32(ddlRelatedModuleTypeID.SelectedValue);
        if (moduleID == (int)ModuleTypes.StaticPages)
        {
            trRelatedPageID.Visible = true;
            Load_ddlRelatedPageID();
        }
        else
        {
            trRelatedPageID.Visible = false;
        
        }
    }
}


