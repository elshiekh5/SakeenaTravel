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

public partial class AdminAdvPlaces_GetAll : MasterAdminDefaultPage
{

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        FirstLoad(dgControl, null, lblResult);
        if (!IsPostBack)
        {
            this.Page.Title = "«·≈⁄·«‰« ";
        }
    }

    #endregion

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    protected override void LoadData()
    {
        List<AdvPlacesEntity> advPlacesList = AdvPlacesFactory.GetAll(AdvPlaceTypes.UnDefined);
        LoadGrid(advPlacesList, "PlaceID");
    }
    //--------------------------------------------------------
    #endregion

    #region --------------DeleteItem--------------

    protected override bool DeleteItem(int id)
    {
        return AdvPlacesFactory.Delete(id);
    }
    //--------------------------------------------------------
    #endregion

}

