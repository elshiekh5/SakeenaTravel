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
    namespace Zecurity
    {
        /// <summary>
        /// Summary description for Module
        /// </summary>
        public class Module
        {
            private string _ID;
            public string ID
            {
                get { return _ID; }
                set { _ID = value; }
            }

            private string _Name;
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }

            private string _Path;
            public string Path
            {
                get { return _Path; }
                set { _Path = value; }
            }
        }
    }
}