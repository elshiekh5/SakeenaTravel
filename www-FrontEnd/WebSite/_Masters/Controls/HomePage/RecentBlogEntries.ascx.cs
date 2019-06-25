using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Footer_RecentBlogEntries : System.Web.UI.UserControl
{
    public ItemsModulesOptions currentModule { get; set; }
    public ItemsEntity itemsObject { get; set; }

    int index = 0;
    int rowsCountOpened = 0;
    int rowsCountClosed = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        LoadData();
    }

    private void LoadData()
    {

        List<ItemsEntity> itemsList = ItemsFactory.GetLast(15, 3, SitesHandler.GetOwnerIDAsGuid());
        if (itemsList != null && itemsList.Count > 0)
        {
            rList.DataSource = itemsList;
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
    }
}