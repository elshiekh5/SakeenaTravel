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



public partial class UserControls_Items_ItemPhotos : System.Web.UI.UserControl
{
    public int ItemID
    {
        get
        {
            if (ViewState["ItemID"] != null)
                return (int)ViewState["ItemID"];
            else
                return 0;
        }
        set { ViewState["ItemID"] = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
            LoadPhotos();
    }
    #region --------------LoadPhotos--------------
    //---------------------------------------------------------
    //LoadPhotos
    //---------------------------------------------------------
    protected void LoadPhotos()
    {
        if (ItemID>0)
        {
            //Photos
            List<ItemsFilesEntity> photosList = ItemsFilesFactory.GetAll(ItemID, ItemFileTypes.Photo);
            OurLists.LoadDataList<ItemsFilesEntity>(photosList, dlPhotos, "FileID");
            /* //Maps
             List<ItemsFilesEntity> mapsList = ItemsFilesFactory.GetAll(itemid, ItemFileTypes.Map);
             OurLists.LoadDataList<ItemsFilesEntity>(mapsList, dlMaps, "FileID");*/
        }
        else
        {
            this.Visible = false;
        }
    }
    //--------------------------------------------------------
    #endregion
}
