using System;using DCCMSNameSpace;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;


public partial class Admin_ItemsComments_Edit : System.Web.UI.UserControl
{
    string pageFile = "InActive.aspx";
    #region --------------ModuleTypeID--------------
    private int _ModuleTypeID;
    public int ModuleTypeID
    {
        get { return _ModuleTypeID; }
        set { _ModuleTypeID = value; }
    }
    //------------------------------------------
    #endregion
    #region --------------Identifire--------------
    private string _Identifire;
    public string Identifire
    {
        get { return _Identifire; }
        set { _Identifire = value; }
    }
    //------------------------------------------
    #endregion
    #region --------------ModuleBaseTypes--------------
    private ModuleBaseTypes _BaseModuleType = ModuleBaseTypes.Items;
    public ModuleBaseTypes BaseModuleType
    {
        get { return _BaseModuleType; }
        set { _BaseModuleType = value; }
    }
    //------------------------------------------
    #endregion
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!string.IsNullOrEmpty(Request.QueryString["page"]))
        {
            pageFile = Request.QueryString["page"];
            if (!string.IsNullOrEmpty(Request.QueryString["forItem"]))
            {
                pageFile += "?id=" + Request.QueryString["forItem"];
            }
        }
        if (!IsPostBack)
        {
            HandleOptionalControls();
            LoadData();
        }
    }
    //-----------------------------------------------
    #endregion


    #region ---------------HandleOptionalControls---------------
    //-----------------------------------------------
    //HandleOptionalControls
    //-----------------------------------------------
    protected void HandleOptionalControls()
    {/*
		//HasItemID
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasItemID))
		{
			trItemID.Visible = false;
		}
		//-----------------------------------
		//HasSenderName
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasSenderName))
		{
			trSenderName.Visible = false;
		}
		//-----------------------------------
		//HasCountryID
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasCountryID))
		{
			trCountryID.Visible = false;
		}
		//-----------------------------------
		//HasCtryShort
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasCtryShort))
		{
			trCtryShort.Visible = false;
		}
		//-----------------------------------
		//HasSendingDate
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasSendingDate))
		{
			trSendingDate.Visible = false;
		}
		//-----------------------------------
		//HasSenderEmail
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasSenderEmail))
		{
			trSenderEmail.Visible = false;
		}
		//-----------------------------------
		//HasCommentTitle
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasCommentTitle))
		{
			trCommentTitle.Visible = false;
		}
		//-----------------------------------
		//HasCommentText
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasCommentText))
		{
			trCommentText.Visible = false;
		}
		//-----------------------------------
		//HasIsActive
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasIsActive))
		{
			trIsActive.Visible = false;
		}
		//-----------------------------------
		//HasIsSeen
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasIsSeen))
		{
			trIsSeen.Visible = false;
		}
		//-----------------------------------
		//HasBadComment
		if (!SiteOptions.CheckOption(Resources.CommentsOptions.HasBadComment))
		{
			trBadComment.Visible = false;
		}
		//-----------------------------------*/
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("CommentID"))
        {
            int commentID = Convert.ToInt32(Request.QueryString["CommentID"]);
            ItemsCommentsEntity comments = ItemsCommentsFactory.GetObject(commentID);
            if (comments != null)
            {
                txtSenderName.Text = comments.SenderName;
                lblDate.Text = comments.SendingDate.ToString();
                txtSenderEmail.Text = comments.SenderEmail;
                txtCommentTitle.Text = comments.CommentTitle;
                txtCommentText.Text = comments.CommentText;
                cbIsActive.Checked = comments.IsActive;
            }
            else
            {
                //------------------------------------------------
                if (BaseModuleType== ModuleBaseTypes.Items)
                Response.Redirect("/AdminCP/Items/" + Identifire  + "/Comments/" + pageFile);
                
                else if (BaseModuleType== ModuleBaseTypes.Messages)
                    Response.Redirect("/AdminCP/Messages/" + Identifire + "/Comments/" + pageFile);

                //------------------------------------------------
            }
        }
        else
        {
            //------------------------------------------------
            if (BaseModuleType == ModuleBaseTypes.Items)
                Response.Redirect("/AdminCP/Items/" + Identifire + "/Comments/" + pageFile);
            else if (BaseModuleType == ModuleBaseTypes.Messages)
                Response.Redirect("/AdminCP/Messages/" + Identifire + "/Comments/" + pageFile);
            //------------------------------------------------
        }
    }
    //-----------------------------------------------
    #endregion


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("CommentID"))
        {
            if (!Page.IsValid)
            {
                return;
            }
            ItemsCommentsEntity comments = new ItemsCommentsEntity();
            comments.CommentID = Convert.ToInt32(Request.QueryString["CommentID"]);
            comments.SenderName = txtSenderName.Text;
            comments.SenderEmail = txtSenderEmail.Text;
            comments.CommentTitle = txtCommentTitle.Text;
            comments.CommentText = txtCommentText.Text;
            comments.IsActive = cbIsActive.Checked;
            ExecuteCommandStatus status = ItemsCommentsFactory.Update(comments);

            if (status == ExecuteCommandStatus.Done)
            {
                //------------------------------------------------
                if (BaseModuleType == ModuleBaseTypes.Items)
                    Response.Redirect("/AdminCP/Items/" + Identifire + "/Comments/" + pageFile);
                else if (BaseModuleType == ModuleBaseTypes.Messages)
                    Response.Redirect("/AdminCP/Messages/" + Identifire + "/Comments/" + pageFile);
                //------------------------------------------------
            }
            else
            {
                lblResult.CssClass = "lblResult_Faild";
                lblResult.Text = Resources.AdminText.SavingDataFaild;
            }
        }
        else
        {
            //------------------------------------------------
            if (BaseModuleType == ModuleBaseTypes.Items)
                Response.Redirect("/AdminCP/Items/" + Identifire + "/Comments/" + pageFile);
            else if (BaseModuleType == ModuleBaseTypes.Messages)
                Response.Redirect("/AdminCP/Messages/" + Identifire + "/Comments/" + pageFile);

            //------------------------------------------------
        }
    }
}