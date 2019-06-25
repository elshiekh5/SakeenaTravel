using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



public partial class UserControls_MLangsDetails : System.Web.UI.UserControl
{
    ItemsModulesOptions currentModule;
    public bool ViewTaps
    {
        get {
            if (ViewState["ViewTaps"] == null) ViewState["ViewTaps"] = true;
            return (bool)ViewState["ViewTaps"];

            }
        set { ViewState["ViewTaps"] = value; }
    }
    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
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
    #region --------------Sender--------------
    private UsersTypes _Sender = UsersTypes.Admin;
    public UsersTypes Sender
    {
        get { return _Sender; }
        set { _Sender = value; }
    }
    //------------------------------------------
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
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
            CheckVisibility();
        }
    }
    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    public void ClearControls()
    {
        ucArDetails.ClearControls();
        ucEnDetails.ClearControls();
    }
    //--------------------------------------------------------
    #endregion

    public void CheckVisibility()
    {
        //--------------------------------------------------------------------
        if (!SiteSettings.Languages_HasMultiLanguages)
        { ViewTaps = false; }
        else if (TypeOfDetails == DetailsTypes.Items)
        {
            if (!currentModule.HasTitle
           && !currentModule.HasShortDescription
           && !currentModule.HasDetails
           && !currentModule.HasAuthorName
           && !currentModule.HasAddress
           && !currentModule.HasExtraText_1)
            { ViewTaps = false; }
            else
            { ViewTaps = true; }
        }
        else if (TypeOfDetails == DetailsTypes.Category)
        {
            if (!currentModule.CategoryHasTitle
                    && !currentModule.CategoryHasShortDescription
                    && !currentModule.CategoryHasDetails
                   )
            { ViewTaps = false; }
            else
            { ViewTaps = true; }
        }
        else if (TypeOfDetails == DetailsTypes.SiteDepartment)
        {
            SiteDeparmentsOptions sdo = SiteDeparmentsOptions.GetType(ModuleTypeID);
            if (!sdo.HasTitle
                 && !sdo.HasShortDescription
                 && !sdo.HasDescription
                )
            { ViewTaps = false; }
            else
            { ViewTaps = true; }
        }
        //--------------------------------------------------------------------
        //--------------------------------------
        //Arabic
        //--------------------------------------
        ucArDetails.ModuleTypeID = ModuleTypeID;
        ucArDetails.TypeOfDetails = TypeOfDetails;
        ucArDetails.Sender = Sender;
        if (SiteSettings.Languages_HasArabicLanguages)
        {
            tbArabic.Visible = true;
            ucArDetails.Visible = true;

        }
        else
        {
            tbArabic.Visible = false;
            ucArDetails.Visible = false;
        }
        //--------------------------------------
        //English
        //--------------------------------------
        ucEnDetails.ModuleTypeID = ModuleTypeID;
        ucEnDetails.TypeOfDetails = TypeOfDetails;
        ucEnDetails.Sender = Sender;
        if (SiteSettings.Languages_HasEnglishLanguages)
        {
            tbEnglish.Visible = true;
            ucEnDetails.Visible = true;
            
        }
        else
        {
            tbEnglish.Visible = false;
            ucEnDetails.Visible = false;
        }
    }

    public string GetTabStyle(Languages langID)
    {
        if ((Languages)SiteSettings.Languages_DefaultLanguageID == langID)
        {
            return "tabActive";
        }
        else
        {
            return "tab";
        }
    }
}
