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

namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class LoginLogOutControl : ReadyUserControls.UserControl
        {
            ReadyUserControls.UserControl ucLogin;
            ReadyUserControls.UserControl ucLogOut;
            protected void Page_Load(object sender, EventArgs e)
            {
                //-------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                if (this.Page.User != null && this.Page.User.Identity.IsAuthenticated)
                {
                    ucLogin.Visible = false;
                    ucLogOut.Visible = true;
                }
                else
                {
                    ucLogin.Visible = true;
                    ucLogOut.Visible = false;
                }
            }

            #region ---------------CatchControls---------------
            //-----------------------------------------------
            //CatchControls
            //-----------------------------------------------
            protected void CatchControls()
            {
                ucLogin = (ReadyUserControls.UserControl)this.FindControl("ucLogin");
                ucLogOut    = (ReadyUserControls.UserControl)this.FindControl("ucLogOut");
            }
            //-----------------------------------------------
            #endregion

        }
    }
}