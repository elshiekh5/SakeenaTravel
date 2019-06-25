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

using System.IO;
using System.Text;

public partial class Pages_Website_Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["file"]))
        {
            do_download(Request.QueryString["file"]);
        }
    }

    private void do_download(string completePath)
    {
        completePath = Encryption.Decrypt(completePath);
        string title = Request.QueryString["name"];
        do_download(completePath, title);
    }
    private void do_download(string path, string title)
    {
        System.IO.FileStream fs;
        string physicalPath = DCServer.MapPath(path);
        title = title.Replace(' ','_');
        if (File.Exists(physicalPath))
        {
            try
            {
                //-----------------------------------------------------------------------------------------------------------
                Response.HeaderEncoding = Encoding.GetEncoding(1256);
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-disposition", "attachment; filename=" + title + Path.GetExtension(physicalPath));
                Response.TransmitFile(physicalPath);
                //-----------------------------------------------------------------------------------------------------------
            }
            catch
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "note", "<script>alert('Sorry Try Again Later');history.go(-1);</script>");
                return ;
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "note", "<script>alert('Sorry Try Again Later');history.go(-1);</script>");
        }
    }
}
