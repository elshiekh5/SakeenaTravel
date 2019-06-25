using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;

public partial class AdminCP__UserControls_MailList_MailListUsers_Add : AdminAddEditUserControl
{


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

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        FirstLoad(lblResult, this.btnSave);
        if (!IsPostBack)
        {

            HandelControls();
        }
    }

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
        if (SiteSettings.MailList_HasGroups)
            Load_ddlMailListGroups();
        else
            trGroups.Visible = false;
        //-------------------------------------------
    }
    #endregion

    #region ---------------LoadObject---------------
    //-----------------------------------------------
    //LoadObject
    //-----------------------------------------------
    protected override object LoadObject()
    {
        MailListUsersEntity mailListUsers = new MailListUsersEntity();
        mailListUsers.Email = txtEmail.Text;
        mailListUsers.IsActive = cbIsActive.Checked;
        if (SiteSettings.MailList_HasGroups)
        {
            //-------------------------------------------------------
            string groups = "";
            foreach (ListItem item in ddlMailListGroups.Items)
            {
                if (item.Selected)
                {
                    groups += "#" + item.Value + "#";
                }
            }
            mailListUsers.Groups = groups;
        }

        mailListUsers.ModuleTypeID = (int)StandardItemsModuleTypes.MailList;
        //---------------------------------------------------------------------
        //Language
        //---------------------------------------------------------------------
        Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------
        mailListUsers.LangID = langID;
        //---------------------------------------------------------------------
        return mailListUsers;
    }
    #endregion

    #region ---------------SaveData---------------
    //-----------------------------------------------
    //SaveData
    //-----------------------------------------------
    protected override object SaveData()
    {
        MailListUsersEntity mailListUser = (MailListUsersEntity)LoadObject();
        if (mailListUser != null)
        {
            status = MailListUsersFactory.Create(mailListUser);
        }
        return mailListUser;
    }
    #endregion
}