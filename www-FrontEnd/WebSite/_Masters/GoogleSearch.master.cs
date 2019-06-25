﻿using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


public partial class App_Design_masters_Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = SiteTextsManager.Instance.SiteName;
        if (!IsPostBack)
        {
            cssEls.Href = SiteDesign.CssFolder + "Els.css";
            cssStyle.Href = SiteDesign.CssFolder + "Main.css";
        }
    }
}
