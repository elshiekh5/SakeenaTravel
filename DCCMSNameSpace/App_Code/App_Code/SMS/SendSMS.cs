using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class SendSMSMSG
    {
        private string _UserName = "";
        /// <summary>
        /// Gets or sets User name. 
        /// </summary>
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        private string _password = "";
        /// <summary>
        /// Gets or sets Password. 
        /// </summary>
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        private string _PhoneNumber = "";
        /// <summary>
        /// Gets or sets Phone number. 
        /// </summary>
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }

        private string _TextMsg = "";
        /// <summary>
        /// Gets or sets SMS message. 
        /// </summary>
        public string TextMsg
        {
            get { return _TextMsg; }
            set { _TextMsg = value; }
        }
        private string _StrSender = "";
        /// <summary>
        /// Gets or sets Send Name or Number. 
        /// </summary>
        public string StrSender
        {
            get { return _StrSender; }
            set { _StrSender = value; }
        }


    }

}