using System;
using System.Collections.Generic;

using System.Web;
using System.Text;
namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        /// <summary>
        /// Summary description for XmlControlsBase
        /// </summary>
        public class XmlBaseUserControl : ReadyUserControls.UserControl
        {

            public void PrepareBuffer()
            {

                Response.Expires = 0;
                TimeSpan ts = new TimeSpan(1, 0, 0, 0);
                Response.ExpiresAbsolute = DateTime.Now.Date - ts;
                Response.AddHeader("pragma", "no-cache");
                Response.AddHeader("cache-control", "private");
                Response.CacheControl = "no-cache";
                Response.ContentEncoding = Encoding.UTF8;
            }
            public string FlipText(string arText)
            {
                char[] spl = { ' ' };
                string[] normalText = arText.Split(spl);
                string back = "";
                for (int i = normalText.Length - 1; i >= 0; i--)
                {
                    back += " " + normalText[i] + " ";
                }
                return back;
            }
            public string FormatForXML(string input)
            {
                string data = input;		// cast the input to a string
                if (data != null && data.Length > 0)
                {
                    // replace those characters disallowed in XML documents
                    data = data.Replace("&", "&amp;");
                    data = data.Replace("\"", "&quot;");
                    data = data.Replace("'", "&apos;");
                    data = data.Replace("<", "&lt;");
                    data = data.Replace(">", "&gt;");
                }
                return data;
            }

        }
    }
}