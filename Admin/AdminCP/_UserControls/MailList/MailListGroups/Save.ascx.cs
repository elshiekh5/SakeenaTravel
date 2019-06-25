using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;

public partial class AdminCP__UserControls_MailList_MailListGroups_Save : AdminAddEditUserControl
{

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        FirstLoad(lblResult, this.btnSave);
        if (!IsPostBack)
        {
        }
    }

    #endregion

    #region ---------------LoadControls---------------
    //-----------------------------------------------
    //LoadControls
    //-----------------------------------------------
    protected override bool LoadControls()
    {
        int groupID = Convert.ToInt32(Request.QueryString["id"]);
        MailListGroupsEntity mailListGroups = MailListGroupsFactory.GetObject(groupID);
        if (mailListGroups != null)
        {
            txtName.Text = mailListGroups.Name;
            return true;
        }

        else
        {
            return false;
        }
    }
    #endregion

    #region ---------------LoadObject---------------
    //-----------------------------------------------
    //LoadObject
    //-----------------------------------------------
    protected override object LoadObject()
    {
        MailListGroupsEntity mailListGroups = new MailListGroupsEntity();
        mailListGroups.GroupID = Convert.ToInt32(Request.QueryString["id"]);
        mailListGroups.Name = txtName.Text;
        return mailListGroups;
    }
    #endregion

    #region ---------------SaveData---------------
    //-----------------------------------------------
    //SaveData
    //-----------------------------------------------
    protected override object SaveData()
    {
        MailListGroupsEntity mailListGroups = (MailListGroupsEntity)LoadObject();
        if (mailListGroups != null)
        {
            SPOperation operation;
            if (pageType == PagesTypes.AdminAdd)
                operation = SPOperation.Insert;
            else
                operation = SPOperation.Update;

            status = MailListGroupsFactory.Save(mailListGroups, operation);
        }
        return mailListGroups;
    }
    #endregion
}