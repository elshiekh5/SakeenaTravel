using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public class DCServer
{

/// <summary>
/// Summary description for DCServer
/// </summary>

    public DCServer()
    {//HttpServerUtility
        //
        // TODO: Add constructor logic here
        //
    }
    public static string MapPath(string path)
    {

        char firstCharInPath = path[0];
        if (firstCharInPath == '/')
        {
            path = "~" + path;
        }
        return HttpContext.Current.Server.MapPath(path);
    }
}
