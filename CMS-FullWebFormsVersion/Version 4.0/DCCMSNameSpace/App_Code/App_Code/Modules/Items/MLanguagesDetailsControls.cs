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
    /// Summary description for MLanguagesDetailsControls
    /// </summary>
    public class MLanguagesDetailsControls : System.Web.UI.UserControl
    {
        TextBox txtTitle;
        TextBox txtShortDescription;
        TextBox txtManager;
        TextBox txtContactPerson;
        TextBox txtContactTitle;
        TextBox txtAddress;
        TextBox txtSlogan;
        CuteEditor.Editor txtDescription;
        #region --------------Lang--------------
        private Languages _Lang;
        public Languages Lang
        {
            get { return _Lang; }
            set { _Lang = value; }
        }
        //------------------------------------------
        #endregion
    }
}