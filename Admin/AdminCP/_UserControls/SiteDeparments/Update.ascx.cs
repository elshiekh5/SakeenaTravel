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


public partial class SiteDeparments_Update : System.Web.UI.UserControl
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
            PrepareValidation();
            HandleOptionalControls();
			LoadData();
		}
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
        //-------------------------------------------------------------------
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
        trTitle.Visible = currentModule.SiteDepartmentHasTitle;
        rfvTitle.Visible = currentModule.SiteDepartmentHasTitle && currentModule.RequiredSiteDepartmentTitle;
        //-----------------------------------
        //HasShortDescription
        trShortDescription.Visible = currentModule.SiteDepartmentHasShortDescription;
        rfvShortDescription.Visible = currentModule.SiteDepartmentHasShortDescription && currentModule.RequiredSiteDepartmentShortDescription;
        */
        //-----------------------------------
        //HasIsAvailable
        trIsAvailable.Visible = currentModule.HasIsAvailable;
        //-----------------------------------
        //HasPhotoExtension
        trPhotoExtension.Visible = currentModule.HasPhotoExtension;
        trPhotoPreview.Visible = currentModule.HasPhotoExtension;
        //-----------------------------------
        trDeletePhoto.Visible = !currentModule.RequiredPhoto;
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
        LoadParents();
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadParents---------------
    //-----------------------------------------------
    //LoadParents
    //-----------------------------------------------
    private void LoadParents()
    {
        int siteDepartmentDepth = currentModule.SiteDepartmentsLevel;//NewsSiteSettings.Instance.SiteDepartmentDepth;
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
        string moduleText = "";
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

	#region ---------------LoadData---------------
	//-----------------------------------------------
	//LoadData
	//-----------------------------------------------
	protected void LoadData()
	{
		if(MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
		{
			int departmentID = Convert.ToInt32(Request.QueryString["id"]);
            SiteDeparmentsEntity siteDepartment = SiteDeparmentsFactory.GetObject(departmentID, Languages.Unknowen);
			if (siteDepartment != null)
			{
				//txtTitle.Text = siteDepartment.Title;
				//txtShortDescription.Text = siteDepartment.ShortDescription;
                if (trParents.Visible)
                    ddlParents.SelectedValue = siteDepartment.ParentID.ToString();
                //-------------------------------
                txtUrl.Text = siteDepartment.Url;
                //-------------------------------
                ddlRelatedModuleTypeID.SelectedValue = siteDepartment.RelatedModuleTypeID.ToString();
                //-------------------------------
                if (siteDepartment.RelatedPageID > 0)
                {
                    Load_ddlRelatedPageID();
                    trDeletePhoto.Visible = true;
                    siteDepartment.RelatedPageID = Convert.ToInt32(ddlRelatedPageID.SelectedValue);
                }
                //-------------------------------
                LoadDetails(siteDepartment);
                //-------------------------------
                
				cbIsAvailable.Checked = siteDepartment.IsAvailable;
                if (!string.IsNullOrEmpty(siteDepartment.PhotoExtension))
                {
                    imgPhoto.ImageUrl = DCSiteUrls.GetPath_SiteDeparmentsPhotoNormalThumbs(siteDepartment.OwnerName) + siteDepartment.NormalPhotoThumbs;
                    ancor.HRef = DCSiteUrls.GetPath_SiteDeparmentsPhotoBigThumbs(siteDepartment.OwnerName) + siteDepartment.BigPhotoThumbs;
                    //imgPhoto.AlternateText = siteDepartment.Title;
                }
                else
                {
                    trPhotoPreview.Visible = false;
                }
                //------------------------------------------
                //------------------------------------------
			}
			else
			{
				Response.Redirect("default.aspx");
			}
		}
		else
		{
			Response.Redirect("default.aspx");
		}
	}
	//-----------------------------------------------
	#endregion


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            if (!Page.IsValid)
            {
                return;
            }
            int id = Convert.ToInt32(Request.QueryString["id"]);
            SiteDeparmentsEntity siteDepartment = SiteDeparmentsFactory.GetObject(id, Languages.Unknowen);
            if (siteDepartment != null)
            {
                //siteDepartment.Title = txtTitle.Text;
               // siteDepartment.ShortDescription = txtShortDescription.Text;
                if (trParents.Visible)
                    siteDepartment.ParentID =Convert.ToInt32(ddlParents.SelectedValue);
                //-------------------------------
                siteDepartment.Url = txtUrl.Text;
                //-------------------------------
                siteDepartment.RelatedModuleTypeID = Convert.ToInt32(ddlRelatedModuleTypeID.SelectedValue);
                //-------------------------------
                if (ddlRelatedPageID.Items.Count > 0)
                    siteDepartment.RelatedPageID = Convert.ToInt32(ddlRelatedPageID.SelectedValue);
                //-------------------------------
                //Details -----------------------
                AddDetails(siteDepartment);
                //-------------------------------
                //-------------
                string photoExtension = siteDepartment.PhotoExtension;
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
                    siteDepartment.PhotoExtension = Path.GetExtension(fuPhoto.FileName);
                }
                else
                {
                    siteDepartment.PhotoExtension = photoExtension;
                }
                //-----------------------------------------------------------------
                //Check is  available 
                // logic of is available "if the module hasn't IsAvailable -> then  All items ara vailable "
                if (currentModule.HasIsAvailable)
                    siteDepartment.IsAvailable = cbIsAvailable.Checked;
                else
                    siteDepartment.IsAvailable = true;
                //------------------------------------------------------------------------------------------
                ExecuteCommandStatus status = SiteDeparmentsFactory.Update(siteDepartment);
                if (status == ExecuteCommandStatus.Done)
                {
                    //Photo-----------------------------
                    if (fuPhoto.HasFile)
                    {
                        //if has an old photo
                        if (photoExtension.Length > 0)
                        {
                            //Delete old original photo
                            File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_SiteDeparmentsPhotoOriginals(siteDepartment.OwnerName)) + SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(siteDepartment.DepartmentID) + photoExtension);
                            //Delete old Thumbnails
                            File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_SiteDeparmentsPhotoNormalThumbs(siteDepartment.OwnerName)) + SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(siteDepartment.DepartmentID) + MoversFW.Thumbs.thumbnailExetnsion);
                            File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_SiteDeparmentsPhotoBigThumbs(siteDepartment.OwnerName)) + SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(siteDepartment.DepartmentID) + MoversFW.Thumbs.thumbnailExetnsion);
                        }
                        //------------------------------------------------
                        //Save new original photo
                        fuPhoto.PostedFile.SaveAs(DCServer.MapPath(DCSiteUrls.GetPath_SiteDeparmentsPhotoOriginals(siteDepartment.OwnerName)) + siteDepartment.Photo);
                        //Create new thumbnails
                        MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_SiteDeparmentsPhotoNormalThumbs(siteDepartment.OwnerName), SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(siteDepartment.DepartmentID), fuPhoto.PostedFile, SiteSettings.Photos_NormalThumnailWidth, SiteSettings.Photos_NormalThumnailHeight);
                        MoversFW.Thumbs.CreateThumb(DCSiteUrls.GetPath_SiteDeparmentsPhotoBigThumbs(siteDepartment.OwnerName), SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(siteDepartment.DepartmentID), fuPhoto.PostedFile, SiteSettings.Photos_BigThumnailWidth, SiteSettings.Photos_BigThumnailHeight);
                    }
                    //------------------------------------------------
                    Response.Redirect("default.aspx");
                }
                else if (status == ExecuteCommandStatus.AllreadyExists)
                {
                    lblResult.CssClass = "lblResult_Faild";
                    lblResult.Text = Resources.AdminText.DuplicateItem;
                }
                else
                {
                    lblResult.CssClass = "lblResult_Faild";
                    lblResult.Text = Resources.AdminText.UpdatingOperationFaild;
                }
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
        else
        {
            Response.Redirect("default.aspx");
        }
    }
    protected void btnDeletePhoto_Click(object sender, EventArgs e)
    {

        int departmentID = Convert.ToInt32(Request.QueryString["id"]);
        SiteDeparmentsEntity siteDepartment = SiteDeparmentsFactory.GetObject(departmentID, Languages.Unknowen);
        if (siteDepartment != null)
        {
            if (trParents.Visible)
                siteDepartment.ParentID = Convert.ToInt32(ddlParents.SelectedValue);
            //Photo-----------------------------
            if (!string.IsNullOrEmpty(siteDepartment.PhotoExtension))
            {
                //Delete old original photo
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_SiteDeparmentsPhotoOriginals(siteDepartment.OwnerName)) + siteDepartment.Photo);
                //Delete old Thumbnails
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_SiteDeparmentsPhotoNormalThumbs(siteDepartment.OwnerName)) + SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(siteDepartment.DepartmentID) + MoversFW.Thumbs.thumbnailExetnsion);
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_SiteDeparmentsPhotoBigThumbs(siteDepartment.OwnerName)) + SiteDeparmentsFactory.CreateSiteDeparmentsPhotoName(siteDepartment.DepartmentID) + MoversFW.Thumbs.thumbnailExetnsion);
            }
            //------------------------------------------------

            trPhotoPreview.Visible = false;
            //-----------------------------

            siteDepartment.PhotoExtension = "";
            
            ExecuteCommandStatus status = SiteDeparmentsFactory.Update(siteDepartment);
            if (status == ExecuteCommandStatus.Done)
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
    //-------------------------------------------------------------------------------------------------------------------------------------
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
    //-------------------------------------------------------------------------------------------------------------------------------------
    protected void LoadDetails(SiteDeparmentsEntity siteDepartment)
    {
        MLanguagesDetailsControls ucArDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucArDetails");
        MLanguagesDetailsControls ucEnDetails = (MLanguagesDetailsControls)MLangsDetails1.FindControl("ucEnDetails");
        //if(HasArabic)
        LoadDetails(siteDepartment, ucArDetails);
        //if(HasEngrabic)
        LoadDetails(siteDepartment, ucEnDetails);
    }
    //-------------------------------------------------------------------------------------------------------------------------------------
    protected void LoadDetails(SiteDeparmentsEntity siteDepartment, MLanguagesDetailsControls ucDetails)
    {
        LoadDetailsControls(ucDetails);
        if (siteDepartment.Details[ucDetails.Lang] != null)
        {
            SiteDeparmentsDetailsEntity siteDeparmentsDetailsObject = (SiteDeparmentsDetailsEntity)siteDepartment.Details[ucDetails.Lang];
            txtTitle.Text = siteDeparmentsDetailsObject.Title;
            txtShortDescription.Text = siteDeparmentsDetailsObject.ShortDescription;
            txtMetaKeyWords.Text = siteDeparmentsDetailsObject.KeyWords;
            fckDescription.Text = siteDeparmentsDetailsObject.Description;
        }
    }
    //-------------------------------------------------------------------------------------------------------------------------------------
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
    //-------------------------------------------------------------------------------------------------------------------------------------
}


