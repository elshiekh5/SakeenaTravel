using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class SearchSmallControl : ReadyUserControls.UserControl
        {
            TextBox txtSearchKeywords;
            ImageButton ibtnSmallSearch;
            protected void Page_Load(object sender, EventArgs e)
            {
                CatchControls();
                Prepare();
            }
            //-----------------------------------------------------------
            protected void CatchControls()
            {
                txtSearchKeywords = (TextBox)this.FindControl("txtSearchKeywords");
                ibtnSmallSearch = (ImageButton)this.FindControl("ibtnSmallSearch");
            }
            //-----------------------------------------------------------
            protected void ibtnSmallSearch_Click(object sender, ImageClickEventArgs e)
            {
                Response.Redirect("/Website/Search/Default.aspx?keywords=" + txtSearchKeywords.Text);

            }
        }
    }
}