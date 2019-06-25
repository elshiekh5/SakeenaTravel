using System;using DCCMSNameSpace;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;
using System.Data.OleDb;
using System.Data;
using System.Collections.Generic;

public partial class Admin_SMSN_ImportFromExcelFile : AdminMasterPage
{


    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {

            this.Page.Title = Resources.SmsAdmin.SmsModuleTitle;
        }
    }

    #endregion


}
    

