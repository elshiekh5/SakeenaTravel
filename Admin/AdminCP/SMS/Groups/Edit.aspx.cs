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

public partial class AdminSMSGroups_Update : AdminMasterPage
{

    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            this.Page.Title = Resources.SmsAdmin.SmsModuleTitle;
        }
    }
}
