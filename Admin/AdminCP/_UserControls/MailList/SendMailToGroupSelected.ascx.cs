using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using System.Net.Mail;

public partial class AdminCP__UserControls_MailList_SendMailToGroupSelected : System.Web.UI.UserControl
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

    List<string> attachmentsPathes;
    MailListEmailsEntity mail = null;

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {

            trselectedusers.Visible = false;

            HandelControls();
        }
    }

    #endregion

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
        if (!SiteSettings.MailList_HasGroups)
            Response.Redirect("/Admin");
        Load_ddlMailListGroups();
    }
    #endregion



    //--------------------------------------------------------
    protected void btnSend_Click(object sender, EventArgs e)
    {

        if (Chkusers.SelectedIndex < 0)
        {
            lblResult.Text = Resources.MailListAdmin.Result_ChoesOneUserAtLeast;
            return;
        }
        //-------------------------------------------------------------
        int groupID = -1;// UnSpecified
        if (trGroups.Visible)
            groupID = Convert.ToInt32(ddlMailListGroups.SelectedValue);
        //-------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (trLanguages.Visible)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //-------------------------------------------------------------


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
        foreach (ListItem item in Chkusers.Items)
        {
            if (item.Selected)
            {
                if (!string.IsNullOrEmpty(item.Text)) BuildEmail();
                mail.To.Add(item.Text);
                MailListEmailsFactory.Send(mail);
                mail.Dispose();
                mail = null;
            }
        }
        //SaveArchive
        //if (usersList.Count > 0)
        SaveArchive();

        //-------------------------------------------

        ///////////////////////////////////////////////////////////////////////////////////

        lblResult.CssClass = "operation_done";
        lblResult.Text = Resources.MailListAdmin.Result_SendingDone;
    }
    //---------------------------------------
    protected void BuildEmail()
    {
        //-----------------------------------------------------
        mail = new MailListEmailsEntity();
        mail.Subject = txtEMailSubject.Text;
        mail.Body = fckEmailbody.Text;
        mail.Body += Resources.MailList.UnsubscripeLink;
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
    protected void SaveArchive()
    {
        if (mail == null) BuildEmail();
        //Save archive 
        if (mail.To != null && mail.To.Count > 0)
            mail.To.Clear();
        mail.To.Add("Group@OurSite.com");
        MailListAchiveFactory.Save(mail);
    }
    protected void ddlMailListGroups_SelectedIndexChanged(object sender, EventArgs e)
    {
        Languages langID = Languages.Unknowen;
        if (trLanguages.Visible)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        Chkusers.Items.Clear();
        if (ddlMailListGroups.SelectedValue != "" && ddlMailListGroups.SelectedValue != "-1")
        {
            int groupID = Convert.ToInt32(ddlMailListGroups.SelectedValue);

            List<string> users = MailListUsersFactory.GetAllEmailsOnly(ModuleTypeID, langID, groupID, true);

            foreach (string email in users)
            {
                Chkusers.Items.Add(email);
            }
            trselectedusers.Visible = true;
        }
        else
        { trselectedusers.Visible = false; }
    }
}