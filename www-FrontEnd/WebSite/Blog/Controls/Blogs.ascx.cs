using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite_PortfolioGrid_Controls_Items : System.Web.UI.UserControl
{
    public string LinkPattern = "";
    public List<AppService.FrontItemsModel> ItemsList;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }
    public void LoadData()
    {
        int index = 1;
        int pageSize = 4;
        int totalItemsCount = 0;
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("index"))
        {
            index = Convert.ToInt32(Request.QueryString["index"]);
        }
        ItemsList = AppService.FrontItemsController.GetModuleDataPageByPage(15, "BlogPaging", index, pageSize, out totalItemsCount);
        if (ItemsList != null && ItemsList.Count > 0)
        {
            this.Visible = true;
            ucPager.TotalRecords = totalItemsCount;
            ucPager.PageSize = pageSize;
            ucPager.LinkPattern = this.LinkPattern;
            ucPager.CurrentPage = index;
            //-----------------------------------------
        }
        else
        {
            this.Visible = false;
        }
    }
}