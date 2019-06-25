using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;


public partial class Pages_Website_Advs_ViewAd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
            {
                int advID = Convert.ToInt32(Request.QueryString["id"]);
                AdvertismentsEntity advertisment =AdvertismentsFactory.GetObject(advID);
                if (advertisment != null)
                {
                    AdvertismentsFactory.IncreaseClicksCount(advertisment.AdvertiseID);
                    Response.Redirect(advertisment.Url);
                }
                else
                {
                    Response.Redirect(SiteUrls.HomePage);
                }
            }
        }
    }
}

