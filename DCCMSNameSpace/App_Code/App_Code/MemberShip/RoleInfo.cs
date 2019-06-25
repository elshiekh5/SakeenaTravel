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
    /// <summary>
    /// Summary description for RoleInfo
    /// </summary>
    public class RoleInfo
    {
        #region --------------RoleName--------------
        private string _RoleName = "";
        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }
        //------------------------------------------
        #endregion


        public RoleInfo(string roleName)
        {
            _RoleName = roleName;
        }
    }


}