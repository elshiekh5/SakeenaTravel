using System;using DCCMSNameSpace;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Net.Mail;
using System.Drawing;

public partial class Admin_MailList_SendMail : System.Web.UI.UserControl
{
    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion
    //----------------------------------------------------
    public FormMailToTypes FormMailTo
    {
        get
        {
            if (ViewState["FormMailTo"] == null)
                return FormMailToTypes.All;
            else return (FormMailToTypes)ViewState["FormMailTo"];
        }
        set { ViewState["FormMailTo"] = value; }
    }
    List<string> attachmentsPathes;
    MailListEmailsEntity mail = null;

    #region --------------Load_ddlMailListGroups()--------------
    //---------------------------------------------------------
    //Load_ddlMailListGroups
    //---------------------------------------------------------
    protected void Load_ddlMailListGroups()
    {
        List<MailListGroupsEntity> mailListGroupsList = MailListGroupsFactory.GetAll();
        OurDropDownList.LoadDropDownList<MailListGroupsEntity>(mailListGroupsList, ddlMailListGroups, "Name", "GroupID", true);

    }
    //--------------------------------------------------------
    #endregion

    #region ---------------HandelControls---------------
    //-----------------------------------------------
    //HandelControls
    //-----------------------------------------------
    protected void HandelControls()
    {
        #region ------------------Languages Handling---------------------
        //Languages Handling
        if (SiteSettings.Languages_HasMultiLanguages)
            SiteSettings.BuildDropDownListForDefaultPage(ddlLanguages);
        else
            trLanguages.Visible = false;
        #endregion
        //-------------------------------------------
        //Groups
        trGroups.Visible = SiteSettings.MailList_HasGroups;
        //-------------------------------------------
        //Attatchments
        trAttatch1.Visible = SiteSettings.MailList_HasAttachments;
        trAttatch2.Visible = SiteSettings.MailList_HasAttachments;
        trAttatch3.Visible = SiteSettings.MailList_HasAttachments;
        //-------------------------------------------
        //SiteSettings.MailList_MaxAttachFilesCount;
        //SiteSettings.MailList_MaxAllAttachSize;
        switch (FormMailTo)
        {
            case FormMailToTypes.All:
                trEmail.Visible = false;
                trGroups.Visible = false;
                break;
            case FormMailToTypes.Group:
                if (!SiteSettings.MailList_HasGroups)
                    Response.Redirect("/Admin");
                Load_ddlMailListGroups();
                trEmail.Visible = false;
                break;
            case FormMailToTypes.One:
                trLanguages.Visible = false;
                trGroups.Visible = false;
                txtEmail.Text = Request.QueryString["mail"];
                break;
            default:
                trEmail.Visible = false;
                trGroups.Visible = false;
                break;
        }
    }
    #endregion

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
            HandelControls();
        }
    }

    #endregion

    //--------------------------------------------------------
    protected void btnSend_Click(object sender, EventArgs e)
    {
        List<string> usersList = null;
        if (FormMailTo != FormMailToTypes.One)
        {
            //-------------------------------------------------------------
            int groupID = -1;// UnSpecified
            if (trGroups.Visible)
                groupID = Convert.ToInt32(ddlMailListGroups.SelectedValue);
            //-------------------------------------------------------------
            Languages langID = Languages.Unknowen;
            if (trLanguages.Visible)
                langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
            //-------------------------------------------------------------
            usersList = MailListUsersFactory.GetAllEmailsOnly(ModuleTypeID, langID, groupID, true);
        }
        //try
        //{
        
        #region Attachments
        if (SiteSettings.MailList_HasAttachments)
        {
            //-----------------------------------------------------------------
            attachmentsPathes = new List<string>();
            MailListEmailsFactory.AddAttatchPath(attachmentsPathes, fuAttach1);
            MailListEmailsFactory.AddAttatchPath(attachmentsPathes, fuAttach2);
            MailListEmailsFactory.AddAttatchPath(attachmentsPathes, fuAttach3);
            //-----------------------------------------------------------------
        }
        #endregion
       //////////////////////////////////////////////////////////////////////////////////////
        int maxBccCount = SiteSettings.MailList_MaxBccCount;
        if (FormMailTo == FormMailToTypes.One)
        {
            //mail = new MailListEmailsEntity();
            BuildEmail(0, txtEmail.Text);
            mail.To.Add(txtEmail.Text);
            MailListEmailsFactory.Send(mail);
            //SaveArchive
            SaveArchive();
        }
        else
        {

            foreach (string userEMail in usersList)
            {
                if (mail == null) BuildEmail(0, userEMail);
                mail.To.Add(userEMail);
                MailListEmailsFactory.Send(mail);
                mail.Dispose();
                mail = null;
            }
            //SaveArchive
            if (usersList.Count > 0)
                SaveArchive();
            /*
            int x = 0;
            foreach (MailListUsersEntity user in usersList)
            {
                ++x;
                if (mail == null) BuildEmail();
                mail.Bcc.Add(user.Email);
                if (x >= maxBccCount)
                {
                    //BuildEmail(mail, attachmentsPathes);
                    MailListEmailsFactory.Send(mail);
                    //Clear Bcc

                    mail.Bcc.Clear();
                    mail.Dispose();
                    mail = null;
                    x = 0;
                }
            }
            if (x > 0)//Send to the last emails
            {
                MailListEmailsFactory.Send(mail);
            }*/
            //-------------------------------------------
        }
        ///////////////////////////////////////////////////////////////////////////////////
        
        lblResult.CssClass = "operation_done";
        lblResult.Text = Resources.MailListAdmin.Result_SendingDone;
    }
    //---------------------------------------
    protected void BuildEmail(int id,string email)
    {
        //-----------------------------------------------------
        mail = new MailListEmailsEntity();
        mail.Subject = txtEMailSubject.Text;
        mail.Body = fckEmailbody.Text;
        //-----------------------------------------------
        if (FormMailTo != FormMailToTypes.One)
        {
            mail.Body += string.Format(Resources.MailList.UnsubscripeLink, new string[] { SitesHandler.GetSiteDomain(), id.ToString(), email });
        }
        //-----------------------------------------------
        if (attachmentsPathes != null)
        {
            foreach (string item in attachmentsPathes)
            {
                mail.AttachmentsFilesPathes.Add(item);
                mail.Attachments.Add(new Attachment(item));
            }
        }
        //-----------------------------------------------

    }
    //--------------------------------------------------------
    /* OldCode
    protected void SaveArchive()
    {
        if (mail == null) BuildEmail(0,"");
        //Save archive 
        if (mail.To != null && mail.To.Count>0)
        mail.To.Clear();
        switch (FormMailTo)
        {
            case FormMailToTypes.All:
                mail.To.Add("AllMailList@OurSite.com");
                break;
            case FormMailToTypes.Group:
                mail.To.Add("Group@OurSite.com");
                break;
            case FormMailToTypes.One:
                mail.To.Add(txtEmail.Text);
                break;
        }

        MailListAchiveFactory.Save(mail);
    }
    */
    //--------------------------------------------------------
    protected void SaveArchive()
    {
        if (mail == null) BuildEmail(0, "");
        //Save archive 
        if (mail.To != null && mail.To.Count > 0)
            mail.To.Clear();
        switch (FormMailTo)
        {
            case FormMailToTypes.All:
                mail.To.Add("AllMailList@OurSite.com");
                break;
            case FormMailToTypes.Group:
                mail.To.Add("Group@OurSite.com");
                break;
            case FormMailToTypes.One:
                mail.To.Add(txtEmail.Text);
                break;
        }
        mail.Body = fckEmailbody.Text;
        MailListAchiveFactory.Save(mail);
    }
}

