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


public partial class Admin_SiteDeparments_Organization_Update : AdminMasterPage
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        ucUpdate.ParentID = (int)ParentsOfSiteDepartments.Organization;
        if (!IsPostBack) { this.Page.Title = Resources.SiteDepartments.ModuleTitle_Departments + " - " + Resources.SiteDepartments.Department_Edit; }
    }
    //-----------------------------------------------
    #endregion
}

