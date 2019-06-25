using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;

public partial class WebSite__SharedControls_SendMessage : System.Web.UI.UserControl
{
    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID=501;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion

    #region --------------OwnerID--------------
    private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
    public Guid OwnerID
    {
        get { return _OwnerID; }
        set { _OwnerID = value; }
    }
    //------------------------------------------
    #endregion

    MessagesModuleOptions currentModule;
    int categoryID = 0;
    string rowTemplate = "<tr><td><b>{0}</b></td>:<td>{1}</td></tr>";
    protected void Page_Load(object sender, EventArgs e)
    {
        //---------------------------------------------------------------------//
        currentModule = MessagesModuleOptions.GetType(ModuleTypeID);
        //---------------------------------------------------------------------//
        lblResult.Text = "";
        if (!IsPostBack)
        {
            //tblControls.Visible = true;
            lblResult.Text = "";
            btnSend.Text = Resources.User.Send;
        }
        //---------------------------------------------------------------------//
    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        Send();
    }

    //------------------------------------------------------------------------------------
    protected void SendMailToSiteAdmin(string mailBody)
    {
        MailListEmailsEntity mail = new MailListEmailsEntity();
        //------------------------------------------------------------------------
        string to = SiteSettings.Admininstration_AdminEmail;
        mail.To.Add(to);
        //------------------------------------------------------------------------
        if (SiteSettings.Admininstration_HasAdminBccEmail)
        {
            string AdminbccMail = SiteSettings.Admininstration_AdminBccEmail;
            mail.Bcc.Add(AdminbccMail);
        }
        //------------------------------------------------------------------------
        mail.Subject = DynamicResource.GetMessageModuleText(currentModule, "NewMessageRecieved");
        //-------------------------------------
        mail.Body = mailBody;
        //------------------------------------------------------------------------
        mail.IsBodyHtml = true;

        MailListEmailsFactory.Send(mail);

    }
    //------------------------------------------------------------------------------------

    //------------------------------------------------------------------------------------
    protected void Send()
    {
        if (!Page.IsValid)
        {
            return;
        }
        //-----------------------------------------------------------------




        //Preparing admin notification email
        string mailBody = "<table style='width:auto; direction:" + Resources.Lang.Dir + "'>";
        MessagesEntity msg = new MessagesEntity();
        
        //-------------------------------------
        msg.ModuleTypeID = ModuleTypeID;
        //--------------------------------------------------------------------------
        msg.Name = txtName.Text;
        mailBody += string.Format(rowTemplate, DynamicResource.GetMessageModuleText(currentModule, "Name"), msg.Name);
        msg.EMail = txtEMail.Text;
        mailBody += string.Format(rowTemplate, DynamicResource.GetMessageModuleText(currentModule, "Email"), msg.EMail);
        msg.Details = txtDetails.Text;
        mailBody += string.Format(rowTemplate, DynamicResource.GetMessageModuleText(currentModule, "Details"), txtDetails.Text);
        //-------------------------------------

        msg.LangID = SiteSettings.GetCurrentLanguage();
        bool status = MessagesFactory.Create(msg);
        if (status)
        {
            //-------------------------------------------------------------------------
            //RegisterInMailList
            if ((currentModule.MailListAutomaticRegistration || (msg.HasEmailService)) && !string.IsNullOrEmpty(msg.EMail))
                MessagesFactory.RegisterInMailList(msg);
            //------------------------------------------------------------------------
            //RegisterInSms
            if ((currentModule.SmsAutomaticRegistration || (msg.HasSmsService)) && !string.IsNullOrEmpty(msg.Mobile))
                MessagesFactory.RegisterInSms(msg);
            //------------------------------------------------------------------------
            //------------------------------------------------------------------------
            if (SiteSettings.Admininstration_HasAdminEmail)
            {
                SendMailToSiteAdmin(mailBody);
            }
            //------------------------------------------------------------------------
            lblResult.CssClass = "operation_done";
            lblResult.Text = DynamicResource.GetMessageModuleText(currentModule, "SendinogOperationDone");
            //tblControls.Visible = false;
            ClearControls();
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = DynamicResource.GetMessageModuleText(currentModule, "SendinogOperationFaild");
            //tblControls.Visible = true;
        }
    }

    #region --------------ClearControls()--------------
    //---------------------------------------------------------
    //ClearControls()
    //---------------------------------------------------------
    private void ClearControls()
    {
        txtName.Text = "";
        txtEMail.Text = "";
        txtDetails.Text = "";
    }
    //--------------------------------------------------------
    #endregion
}