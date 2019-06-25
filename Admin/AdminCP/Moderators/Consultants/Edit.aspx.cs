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


public partial class AdminMessagesConsulting_Services_EditConsultant : AdminMasterPage
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        ucEditData.ModuleTypeID = (int)StandardItemsModuleTypes.Registration_Consultant;
        if (!IsPostBack) { this.Page.Title = "«·Œœ„«  «·≈” ‘«—Ì… - ≈÷«›… ≈” ‘«—Ì"; }
    }
    //-----------------------------------------------
    #endregion
}

