using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;

public partial class AdminCP__UserControls_MailList_MailListArchive_Show : System.Web.UI.UserControl
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadObject();
        }
    }

    #endregion



    #region ---------------LoadObject---------------
    //-----------------------------------------------
    //LoadObject
    //-----------------------------------------------
    protected void LoadObject()
    {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
        {
            int mailID = Convert.ToInt32(Request.QueryString["id"]);
            MailListEmailsEntity email = MailListAchiveFactory.GetObject(mailID);
            lblSubject.Text = email.Subject;
            lblbody.Text = email.Body;
            lblTo.Text = email.ToCollectionSting;
            lblDate_Added.Text = email.Date_Added.ToLongTimeString();
        }
    }
    #endregion
}