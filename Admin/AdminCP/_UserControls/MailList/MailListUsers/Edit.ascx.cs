using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using System.Drawing;

public partial class AdminCP__UserControls_MailList_MailListUsers_Edit : System.Web.UI.UserControl
{

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        //-------------------------
        lblResult.Text = "";

        if (!IsPostBack)
        {
            HandelControls();
            LoadData();
        }
    }

    #endregion
    #region ---------------HandelControls---------------
    //-----------------------------------------------
    //HandelControls
    //-----------------------------------------------
    protected void HandelControls()
    {

        //-------------------------------------------
        if (SiteSettings.MailList_HasGroups)
            Load_ddlMailListGroups();
        else
            trGroups.Visible = false;
        //-------------------------------------------
    }
    #endregion
    #region --------------Load_ddlMailListGroups()--------------
    //---------------------------------------------------------
    //Load_ddlMailListGroups
    //---------------------------------------------------------
    protected void Load_ddlMailListGroups()
    {
        List<MailListGroupsEntity> mailListGroupsList = MailListGroupsFactory.GetAll();
        ddlMailListGroups.DataSource = mailListGroupsList;
        ddlMailListGroups.DataTextField = "Name";
        ddlMailListGroups.DataValueField = "GroupID";
        ddlMailListGroups.DataBind();
    }
    //--------------------------------------------------------
    #endregion
    #region --------------LoadData()--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    protected void LoadData()
    {
        if (MoversFW.Components.UrlManager.ChechIsValidParameter("id"))
        {
            int userID = Convert.ToInt32(Request.QueryString["id"]);
            MailListUsersEntity mailListUser = MailListUsersFactory.GetObject(userID);
            if (mailListUser != null)
            {
                txtEmail.Text = mailListUser.Email;
                cbIsActive.Checked = mailListUser.IsActive;
                if (SiteSettings.MailList_HasGroups)
                {
                    //ddlMailListGroups.SelectedValue = mailListUser.GroupID.ToString();
                    //string groupsText = mailListUser.Groups.Replace("##", "#");
                    string[] groups = mailListUser.Groups.Split(new char[] { '#' });
                    foreach (string group in groups)
                    {
                        if (!string.IsNullOrEmpty(group))
                        {
                            foreach (ListItem item in ddlMailListGroups.Items)
                            {
                                if (item.Value == group)
                                    item.Selected = true;
                            }
                        }
                    }
                }
            }
        }
        else
        {
            Response.Redirect("default.aspx");
        }
    }
    //--------------------------------------------------------
    #endregion
    #region ---------------btnSave_Click---------------
    //-----------------------------------------------
    //btnSave_Click
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }

        int userID = Convert.ToInt32(Request.QueryString["id"]);
        MailListUsersEntity mailListUser = MailListUsersFactory.GetObject(userID);
        mailListUser.UserID = userID;
        mailListUser.Email = txtEmail.Text;
        mailListUser.IsActive = cbIsActive.Checked;
        if (SiteSettings.MailList_HasGroups)
        {
            //mailListUser.GroupID = Convert.ToInt32(ddlMailListGroups.SelectedValue);
            string groups = "";
            foreach (ListItem item in ddlMailListGroups.Items)
            {
                if (item.Selected)
                {
                    groups += "#" + item.Value + "#";
                }
            }
            mailListUser.Groups = groups;
        }
        ExecuteCommandStatus status = MailListUsersFactory.Update(mailListUser);

        if (status == ExecuteCommandStatus.Done)
        {


            lblResult.Text = Resources.AdminText.SavingDataSuccessfuly;
            Response.Redirect("default.aspx");
        }
        else if (status == ExecuteCommandStatus.AllreadyExists)
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.DuplicateItem;
        }
        else
        {
            lblResult.CssClass = "lblResult_Faild";
            lblResult.Text = Resources.AdminText.SavingDataFaild;
        }

    }

    #endregion
}