using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AppService;

public partial class App_Design_masters_InnerMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = NavigationManager.Instance.PageTitle;
        form1.Action = Request.RawUrl;
        if (!IsPostBack)
        {
            //cssEls.Href = SiteDesign.CssFolder + "Els.css";
            //cssInner.Href = SiteDesign.CssFolder + "inner_default2.css";

        }
    }

    protected override void Render(HtmlTextWriter output)
    {
        //------------------------------------------------------
        DCMetaBuilder.Instance.BuildMetaTags(this.Page);
        //------------------------------------------------------
        base.Render(output);
        //------------------------------------------------------
    }
}
