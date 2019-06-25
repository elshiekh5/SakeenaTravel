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
            LoadFiles();
    }
    #region --------------LoadFiles--------------
    //---------------------------------------------------------
    //LoadFiles
    //---------------------------------------------------------
    protected void LoadFiles()
    {
        if (ItemID>0)
        {
            //Photos
            List<ItemsFilesEntity> list = ItemsFilesFactory.GetAll(ItemID, ItemFileTypes.Video);
            OurLists.LoadDataList<ItemsFilesEntity>(list, dlVideosPhotos, "FileID");
        }
        else
        {
            this.Visible = false;
        }
    }
    //--------------------------------------------------------
    #endregion
}
