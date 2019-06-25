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


public partial class App_Design_masters_MainMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.Page.Title = SiteTextsManager.Instance.SiteName;
        form1.Action = Request.RawUrl;
        if (!IsPostBack)
        {
            // cssEls.Href = SiteDesign.CssFolder + "Els.css";
            //cssStyle.Href = SiteDesign.CssFolder + "Main.css";
            cssStyle.Href = "/WebSite/_Assets/Interface/main." + Resources.Lang.LangIdentifire + ".css";
            if (Request.UrlReferrer == null)
            {
            }
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
