using System;
using System.Data;
using System.Configuration;

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
        /// <summary>
        /// Summary description for ReadyUserControls.UserControl
        /// </summary>
        public class UserControl : System.Web.UI.UserControl
        {
            public virtual void Prepare()
            {

            }
        }

        public class Page : System.Web.UI.Page
        {
            public virtual void Prepare()
            {

            }
        }
    }
}