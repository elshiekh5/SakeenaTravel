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

public partial class Admin_SMS_Send : System.Web.UI.UserControl
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
    public FormSMSToTypes FormSmsTo
    {
        get
        {
            if (ViewState["FormSmsTo"] == null)
                return FormSMSToTypes.All;
            else return (FormSMSToTypes)ViewState["FormSmsTo"];
        }
        set { ViewState["FormSmsTo"] = value; }
    }
   
    SMSNumbersEntity sms = null;

    #region --------------Load_ddlSMSGroups()--------------
    //---------------------------------------------------------
    //Load_ddlSMSGroups
    //---------------------------------------------------------
    protected void Load_ddlSMSGroups()
    {
        List<SMSGroupsEntity> SMSGroupsList = SMSGroupsFactory.GetAllInList();
        OurDropDownList.LoadDropDownList<SMSGroupsEntity>(SMSGroupsList, ddlSMSGroups, "Name", "GroupID", true);

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
        trGroups.Visible = SiteSettings.Sms_HasGroups;
        //-------------------------------------------
        switch (FormSmsTo)
        {
            case FormSMSToTypes.All:
                trNumbers.Visible = false;
                trGroups.Visible = false;
                break;
            case FormSMSToTypes.Group:
                if (!SiteSettings.Sms_HasGroups)
                    Response.Redirect("/Admin");
                Load_ddlSMSGroups();
                trNumbers.Visible = false;
                break;
            case FormSMSToTypes.One:
                trLanguages.Visible = false;
                trGroups.Visible = false;
                txtNumbers.Text = Request.QueryString["sms"];
                break;
            default:
                trNumbers.Visible = false;
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
            //fckEmailbody.ContentLangDirection = FredCK.FCKeditorV2.LanguageDirection.RightToLeft;
            HandelControls();
        }
    }

    #endregion

    //--------------------------------------------------------
    protected void btnSend_Click(object sender, EventArgs e)
    {
        //////////////////////////////////////////////////////////////////////////////////////
        bool result = false;

        if (FormSmsTo == FormSMSToTypes.One)
        {
            result = SendToNumbers();
        }
        else
        {
            result = SendToUsers();
        }
        ///////////////////////////////////////////////////////////////////////////////////
        if (result)
        {
            lblResult.CssClass = "operation_done";
            lblResult.Text = Resources.AdminText.SendingOperationDone;
        }
        else
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.SendingOperationFaild;
        }
        ///////////////////////////////////////////////////////////////////////////////////
    }
    public bool SendToNumbers()
    {
        
        string str = txtNumbers.Text;
        str = str.Trim();
        str = str.Replace(" ", null).Replace("~", null);
        str = str.Replace("!", null).Replace("@", null);
        str = str.Replace("#", null).Replace("$", null);
        str = str.Replace("%", null).Replace("^", null);
        str = str.Replace("&", null).Replace("*", null);
        str = str.Replace("(", null).Replace(")", null);
        str = str.Replace("`", null).Replace("-", null);
        str = str.Replace("_", null).Replace("=", null);
        str = str.Replace("|", null).Replace(@"\", null);
        str = str.Replace(@"/", null).Replace("{", null);
        str = str.Replace("[", null).Replace("]", null);
        str = str.Replace("}", null).Replace(")", null);
        str = str.Replace(":", null).Replace("'", null);
        str = str.Replace("?", null).Replace(">", null);
        str = str.Replace(".", null).Replace("<", null);
        str = str.Replace(";", null);
        char[] Splitter = { ',' };
        string[] numbers = str.Split(Splitter);
        bool result = false;
        foreach (string number in numbers)
        {
		 result = Send(number);
        }
        //----------------------------
        //Save Archive
        //----------------------------
        if (result)
            SaveArchive();
        //----------------------------
        return result;
    }
    //---------------------------------------
    public bool SendToUsers()
    {
        List<string> usersList = null;
        if (FormSmsTo != FormSMSToTypes.One)
        {
            //-------------------------------------------------------------
            int groupID = -1;// UnSpecified
            if (trGroups.Visible)
                groupID = Convert.ToInt32(ddlSMSGroups.SelectedValue);
            //-------------------------------------------------------------
            Languages langID = Languages.Unknowen;
            if (trLanguages.Visible)
                langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
            //-------------------------------------------------------------
            usersList = SMSNumbersFactory.GetAllNumbersOnly(ModuleTypeID, langID, groupID, true);
        }
        bool result = false;
        foreach (string number in usersList)
        {
		 result = Send(number);
        }
       //----------------------------
        //Save Archive
        //----------------------------
        if (result)
            SaveArchive();
        //----------------------------
        return result;

    }
    //---------------------------------------

    protected  bool Send(string mobilenumber)
    {
        int result = 0;
        result = SMS.SendMessage("","", txtMsg.Text, SmsSettings.Sender, mobilenumber);
        if (result > 0) return true;
        else return false;
    }
    //--------------------------------------------------------
    protected void SaveArchive()
    {
        Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
        if (trLanguages.Visible)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //-------------------------------------------------------------
        SMSArchiveEntity smsArchive = new SMSArchiveEntity();
        smsArchive.LangID = langID;
		smsArchive.Message = txtMsg.Text;
		smsArchive.RecieverMobile = txtNumbers.Text;
		smsArchive.Sender = SmsSettings.Sender;
        SMSArchiveFactory.Create(smsArchive);
    }

}

