using AppService;
using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite_Solutions_Slider_Details : DynamicInnerMasterPage
{
    public ItemsModulesOptions currentModule;
    public FrontItemsModel itemsObject;
    public int ItemID = 0;
    //=============================================================================== 
    //Server side start 
    //===============================================================================
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            NavigationManager.Instance.BuilDefaultPathesLinks();
            LoadData();
        }
    }
    //=============================================================================== 
    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            ItemID = Convert.ToInt32(Request.QueryString["id"]);
        }
        Languages langID = SiteSettings.GetCurrentLanguage();
        itemsObject = FrontItemsController.GetItemObject(ItemID, langID);
        if (itemsObject != null)
        {
            currentModule = ItemsModulesOptions.GetType(itemsObject.ModuleTypeID);
            ucItemDetails.itemsObject = itemsObject;
            ucItemDetails.currentModule = currentModule;
        }
        else
        {
            throw new Exception("404");
        }

    }
    //-----------------------------------------------
    #endregion
}