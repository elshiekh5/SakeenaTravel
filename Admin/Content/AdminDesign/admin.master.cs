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
using System.IO;

public partial class App_AdminMaster : System.Web.UI.MasterPage
{
    //--------------------------------------------------
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if(lblTitle!=null)
                lblTitle.Text = Page.Title;
            Page.Title =  "ادارة الموقع";
            //--------------------------------------------------------------------------------------------
            //Admin Images
            //--------------------------
            string adminImagesFolder = SiteDesign.AdminImagesFolder ;
            //if (File.Exists(DCServer.MapPath(adminImagesFolder + "admin-header.gif")))
            if (SiteSettings.Site_HasAdminMainImages)
                divHeaderHoler.Style.Add(HtmlTextWriterStyle.BackgroundImage, "'" + adminImagesFolder + "admin-header.gif" + "'");
            //--------------------------------------------------------------------------------------------
            cssAdmin.Href = Resources.AdminText.AdminCss;
        }
    }
    //--------------------------------------------------
    protected void LoadPageFiles()
    {
        /*   cssAdmin.Href = Resources.Lang.AdminCssMaster;*/
    }
    //--------------------------------------------------
    protected void ibtnLogOut_Click(object sender, ImageClickEventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("/Login.aspx");
    }
    //--------------------------------------------------
    protected void btnlogout_Click(object sender, ImageClickEventArgs e)
    {
        FormsAuthentication.SignOut();
        Response.Redirect("/Login.aspx");
    }
}
