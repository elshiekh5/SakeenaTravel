using System;
using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml;
using System.Drawing;

public partial class Admin_Modules_AppSettings_HijriDate : AdminMasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadData();
        }
    }

    private void LoadData()
    {
        
        int i = GetConfigSettings();
        txtOffset.Text = i.ToString();
        lblHijriDate.Text = DateFormat.HijriNow();
        lblHijriDate2.Text = DateFormat.Hijri();
        
    }

    
    private int GetConfigSettings()
    {
        string path = DCServer.MapPath("/ConfigrationFiles/hijri.xml");
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(path);
        XmlNode node = xDoc.SelectSingleNode("hijriDate/offset");

        int i =0;
        int.TryParse(node.InnerText, out i);

        return i;
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        int i = 0;
        if (!int.TryParse(txtOffset.Text, out i))
        {
            lblMessage.CssClass = "operation_error";
            lblMessage.Text = "أدخل رقم صحيح";
            return;
        }

        string path = DCServer.MapPath("/ConfigrationFiles/hijri.xml");
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(path);
        XmlNode node = xDoc.SelectSingleNode("hijriDate/offset");
        node.InnerText = i.ToString();
        xDoc.Save(path);


      
        LoadData();
        lblMessage.CssClass = "operation_done";
        lblMessage.Text = "تم تعديل التقويم بنجاح";
    }
}
