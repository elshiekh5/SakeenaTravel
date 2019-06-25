using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebSite__SharedControls_ItemsGallery : System.Web.UI.UserControl
{
    public int ModuleTypeID { get; set; }

   public int index = 0;
   public int rowsCountOpened = 0;
   public int rowsCountClosed = 0;
   public string LinkPattern = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    public void LoadData()
    {
        int index = 1;
        int pageSize=4;
        int totalItemsCount=0;
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("index"))
        {
            index = Convert.ToInt32(Request.QueryString["index"]);
        }
        List<ItemsEntity> photosList = ItemsFactory.GetAll(ModuleTypeID, 0, true, index, pageSize, out totalItemsCount, SitesHandler.GetOwnerIDAsGuid());
        if (photosList != null && photosList.Count > 0)
        {
            rList.DataSource = photosList;
            rList.DataBind();
            rList.Visible = true;
            this.Visible = true;
            ucPager.TotalRecords = totalItemsCount;
            ucPager.PageSize = pageSize;
            ucPager.LinkPattern = this.LinkPattern;
            ucPager.CurrentPage = index;
            //-----------------------------------------
        }
        else
        {
            rList.Visible = false;
            this.Visible = false;
        }
    }
    //--------------------------------------------------------
    #endregion

    /*
     
      if (photosList != null && photosList.Count > 0)
        {
            rList.DataSource = photosList;
            rList.DataBind();
            rList.Visible = true;
            this.Visible = true;
            //-----------------------------------------
        }
        else
        {
            rList.Visible = false;
            this.Visible = false;
        }
     
     */
}