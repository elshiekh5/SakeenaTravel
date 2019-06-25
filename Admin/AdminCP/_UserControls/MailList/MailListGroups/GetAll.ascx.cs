using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using DCCMSNameSpace.Zecurity;

public partial class AdminCP__UserControls_MailList_MailListGroups_GetAll : AdminDefaultUserControl
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        FirstLoad(dgControl, null, lblResult);
        if (!IsPostBack)
        {

        }
    }

    #endregion

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    protected override void LoadData()
    {
        List<MailListGroupsEntity> mailListGroupsList = MailListGroupsFactory.GetAll();
        LoadGrid(mailListGroupsList, "GroupID");
        //-------------------------------------------------------------------------------
        //Security Premession
        //--------------------------
        //Check Edit permission
        if (!ZecurityManager.UserCanExecuteCommand(CommandName.Edit))
            dgControl.Columns[dgControl.Columns.Count - 2].Visible = false;
        //Check Delete permission
        if (!ZecurityManager.UserCanExecuteCommand(CommandName.Delete))
            dgControl.Columns[dgControl.Columns.Count - 1].Visible = false;
        //-------------------------------------------------------------------------------
    }
    //--------------------------------------------------------
    #endregion

    #region --------------DeleteItem--------------

    protected override bool DeleteItem(int id)
    {
        return MailListGroupsFactory.Delete(id);
    }
    //--------------------------------------------------------
    #endregion
}