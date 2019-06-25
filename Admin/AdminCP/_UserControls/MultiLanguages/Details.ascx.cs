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
using DC;

public partial class MLanguagesDetailsControls2 : MLanguagesDetailsControls
{
    ItemsModulesOptions currentModule;

    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion
    #region --------------Sender--------------
    private UsersTypes _Sender = UsersTypes.Admin;
    public UsersTypes Sender
    {
        get { return _Sender; }
        set { _Sender = value; }
    }
    //------------------------------------------
    #endregion
    #region --------------TypeOfDetails--------------
    DetailsTypes _TypeOfDetails = DetailsTypes.Items;
    public DetailsTypes TypeOfDetails
    {
        get { return _TypeOfDetails; }
        set { _TypeOfDetails = value; }
    }
    //------------------------------------------
    #endregion
    #region --------------ItemID--------------
    private int _ItemID = 0;
    public int ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }
    //------------------------------------------
    #endregion
	#region ---------------Page_Load---------------
	//-----------------------------------------------
	//Page_Load
	//-----------------------------------------------
	private void Page_Load(object sender, System.EventArgs e)
	{


        currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
        PrepareValidation();
        //------------------------------------------------------------------------
        //New code for pages
        //------------------------------
        if (currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.SitePages || currentModule.ModuleTypeID == (int)StandardItemsModuleTypes.StaticContents)
        {
            if (ItemID <= 0 && MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {
                ItemID = Convert.ToInt32(Request.QueryString["id"]);
                currentModule = SitePageOptions.GetPage(ItemID);
            }

        }
        //------------------------------------------------------------------------
        if (!IsPostBack)
		{
            PrepareValidation();
            //trTitle.Visible = ViewTitle;
            txtShortDescription.Attributes.Add("onfocus", "return ismaxlength(this,document.forms[0]." + txtSDLengthControler.ClientID + ")");
            txtShortDescription.Attributes.Add("onkeyup", "return ismaxlength(this,document.forms[0]." + txtSDLengthControler.ClientID + ")");
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
        switch (Lang)
        {
            case Languages.Ar:
                //fckDescription.ContentLangDirection = FredCK.FCKeditorV2.LanguageDirection.RightToLeft;
                txtDescription.Style.Add(HtmlTextWriterStyle.Direction, "rtl");
                trTitle.Style.Add(HtmlTextWriterStyle.Direction, "rtl");
                trShortDescription.Style.Add(HtmlTextWriterStyle.Direction, "rtl");
                trAuthorName.Style.Add(HtmlTextWriterStyle.Direction, "rtl");
                trAddress.Style.Add(HtmlTextWriterStyle.Direction, "rtl");
                trExtraText_1.Style.Add(HtmlTextWriterStyle.Direction, "rtl");
                trMetaKeyWords.Style.Add(HtmlTextWriterStyle.Direction, "rtl");
                break;
            case Languages.En:
                //fckDescription.ContentLangDirection = FredCK.FCKeditorV2.LanguageDirection.LeftToRight;
                txtDescription.Style.Add(HtmlTextWriterStyle.Direction, "ltr");
                trTitle.Style.Add(HtmlTextWriterStyle.Direction, "ltr");
                trShortDescription.Style.Add(HtmlTextWriterStyle.Direction, "ltr");
                trAuthorName.Style.Add(HtmlTextWriterStyle.Direction, "ltr");
                trAddress.Style.Add(HtmlTextWriterStyle.Direction, "ltr");
                trExtraText_1.Style.Add(HtmlTextWriterStyle.Direction, "ltr");
                trMetaKeyWords.Style.Add(HtmlTextWriterStyle.Direction, "ltr");
                break;
            default:
                break;
        }
        if (TypeOfDetails == DetailsTypes.Items)
        {
            trTitle.Visible = currentModule.HasTitle;
            //rfvTitle=
            trMetaKeyWords.Visible = currentModule.HasMetaKeyWords;
            trShortDescription.Visible = (currentModule.HasShortDescription || currentModule.HasMetaDescription);
            trDetailsText.Visible = currentModule.HasDetails;
            trDetailsControl.Visible = currentModule.HasDetails;
            trAuthorName.Visible = currentModule.HasAuthorName;
            trAddress.Visible = currentModule.HasAddress;
            trExtraText_1.Visible = currentModule.HasExtraText_1;
            if (!currentModule.HasTitle
                 && !currentModule.HasShortDescription
                 && !currentModule.HasDetails
                 && !currentModule.HasAuthorName
                 && !currentModule.HasAddress
                 && !currentModule.HasExtraText_1)
            { this.Visible = false; }
        }
        else if (TypeOfDetails == DetailsTypes.Category)
        {
            trTitle.Visible = currentModule.CategoryHasTitle;
            //rfvTitle=
            trMetaKeyWords.Visible = currentModule.HasMetaKeyWords;
            trShortDescription.Visible = (currentModule.CategoryHasShortDescription || currentModule.HasMetaDescription);
            trDetailsText.Visible = currentModule.CategoryHasDetails;
            trDetailsControl.Visible = currentModule.CategoryHasDetails;
            trAuthorName.Visible = false;
            trAddress.Visible = false;
            trExtraText_1.Visible = false;
            if (!currentModule.CategoryHasTitle
                 && !currentModule.CategoryHasShortDescription
                 && !currentModule.CategoryHasDetails
                )
            { this.Visible = false; }
        }
        else if (TypeOfDetails == DetailsTypes.SiteDepartment)
        {
            SiteDeparmentsOptions sdo = SiteDeparmentsOptions.GetType(ModuleTypeID);
            trTitle.Visible = sdo.HasTitle;
            //rfvTitle=
            trMetaKeyWords.Visible = sdo.HasMetaKeyWords;
            trShortDescription.Visible = (sdo.HasShortDescription || sdo.HasMetaDescription);
            trDetailsText.Visible = sdo.HasDescription;
            trDetailsControl.Visible = sdo.HasDescription;
            trAuthorName.Visible = false;
            trAddress.Visible = false;
            trExtraText_1.Visible = false;
            if (!sdo.HasTitle
                 && !sdo.HasShortDescription
                 && !sdo.HasDescription
                )
            { this.Visible = false; }
        }

        //-----------------------------------------------
        //DetailsInHtmlEditor
        //----------------------
        if (currentModule.DetailsInHtmlEditor && Sender == UsersTypes.Admin)
        {
            fckDescription.Visible = true;
            txtDescription.Visible = false;
        }
        else
        {
            fckDescription.Visible = false;
            txtDescription.Visible = true;
        }
        //-----------------------------------------------
    }
    //-----------------------------------------------
    #endregion
    #region ---------------SetTexts---------------
    //-----------------------------------------------
    //SetTexts
    //-----------------------------------------------
    private void SetTexts()
    {
        if (TypeOfDetails == DetailsTypes.SiteDepartment)
        {
            lblTitle.Text = Resources.SiteDepartments.Title;
            lblShortDescription.Text = Resources.SiteDepartments.ShortDescription;
            lblDetails.Text = Resources.SiteDepartments.Details;
            lblMetaKeyWords.Text = Resources.SiteDepartments.MetaKeyWords;
        }
        
        else
        {
            int id = currentModule.ModuleTypeID;
            string res = currentModule.ResourceFile;
            string dres = currentModule.DefaultResourceFile;

            lblTitle.Text = DynamicResource.GetText(currentModule, "Title");
            lblShortDescription.Text = DynamicResource.GetText(currentModule, "ShortDescription");
            lblDetails.Text = DynamicResource.GetText(currentModule, "Details");
            lblAuthorName.Text = DynamicResource.GetText(currentModule, "AuthorName");
            lblAddress.Text = DynamicResource.GetText(currentModule, "Address");
            lblExtraText_1.Text = DynamicResource.GetText(currentModule, "ExtraText_1");
            lblMetaKeyWords.Text = DynamicResource.GetText(currentModule, "MetaKeyWords");
        }
        //-----------------------------------------------
    }
    //-----------------------------------------------
    #endregion
	#region ---------------LoadData---------------
	//-----------------------------------------------
	//LoadData
	//-----------------------------------------------
	protected void LoadData()
	{
		HandleOptionalControls();
        SetTexts();
	}
	//-----------------------------------------------
	#endregion

	#region --------------ClearControls()--------------
	//---------------------------------------------------------
	//ClearControls()
	//---------------------------------------------------------
	public void ClearControls()
	{
		txtTitle.Text = "";
        txtShortDescription.Text = "";
        fckDescription.Text = "";
        txtDescription.Text = "";
        txtAuthorName.Text = "";
        txtAddress.Text = "";
        txtExtraText_1.Text = "";
        txtMetaKeyWords.Text = "";
	}
	//--------------------------------------------------------
	#endregion


    public void PrepareValidation()
    {
        //RequiredTitle
        if ((TypeOfDetails == DetailsTypes.Items && currentModule.RequiredTitle) || (TypeOfDetails == DetailsTypes.Category && currentModule.CategoryRequiredTitle))
        {
            PrepareCustomValidation(txtTitle, cvTitle);
        }
        //---------------------------------------------------
        //RequiredShortDescription
        if ((TypeOfDetails == DetailsTypes.Items && currentModule.RequiredShortDescription) || (TypeOfDetails == DetailsTypes.Category && currentModule.CategoryRequiredShortDescription))
        {
            PrepareCustomValidation(txtShortDescription, cvShortDescription);
        }
        //RequiredDetails
        //---------------------------------------------------
        if ((TypeOfDetails == DetailsTypes.Items && currentModule.RequiredDetails))
        {
            if (!currentModule.DetailsInHtmlEditor)
                PrepareCustomValidation(txtDescription, cvDescription);
        }
        //---------------------------------------------------
        //RequiredAuthorName
        if ((TypeOfDetails == DetailsTypes.Items && currentModule.RequiredAuthorName))
        {
            PrepareCustomValidation(txtAuthorName, cvAuthorName);
        }
        //---------------------------------------------------
        //RequiredAddress
        if ((TypeOfDetails == DetailsTypes.Items && currentModule.RequiredAddress))
        {
            PrepareCustomValidation(txtAddress, cvAddress);
        }
        //---------------------------------------------------
        //RequiredExtraText_1
        if ((TypeOfDetails == DetailsTypes.Items && currentModule.RequiredExtraText_1))
        {
            PrepareCustomValidation(txtExtraText_1, cvExtraText_1);
        }
            //------------------------------------------------------
           
        //------------------------------------------------------
        /* if (Lang == Languages.Ar)
         {
             CustomValidator1.ClientValidationFunction = "CheckVlidation";
         }
         else
         {
             CustomValidator1.ClientValidationFunction = "CheckVlidation";
             CustomValidator1.Visible = false;
         }*/
        /*
        DCValidationManager.SetClientValidationFunction(rfvTitle, Lang);
        rfvTitle.Visible = currentModule.HasTitle && currentModule.RequiredTitle;

       DCValidationManager.SetClientValidationFunction(rfvShortDescription, Lang);
        rfvShortDescription.Visible = currentModule.HasShortDescription && currentModule.RequiredShortDescription;
        
        DCValidationManager.SetClientValidationFunction(rfvDescription, Lang);
        trDetailsControl.Visible = currentModule.HasDetails;

        DCValidationManager.SetClientValidationFunction(rfvAuthorName, Lang);
        rfvAuthorName.Visible = currentModule.HasAuthorName && currentModule.RequiredAuthorName;

        DCValidationManager.SetClientValidationFunction(rfvAddress, Lang);
        rfvAddress.Visible = currentModule.HasAddress && currentModule.RequiredAddress;*/
    }
    public void PrepareCustomValidation(Control c, CustomValidator cv)
    {
        string ClientMethod = "Check" + c.ID + Lang;
        ltrScript.Text += "<script type=\"text/javascript\">";

        ltrScript.Text += "function " + ClientMethod + "(sender,args){";
        ltrScript.Text += "CheckVlidation(document.getElementById('" + c.ClientID + "').value, args ," + (int)Lang + ");  } ";
        ltrScript.Text += "function CheckTitleEn(sender,args){ }</script>";
        cv.ClientValidationFunction = ClientMethod;
    }
    protected void cusCustom_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        if (e.Value.Length > 0)
            e.IsValid = true;
        else
            e.IsValid = false;
    }
}
