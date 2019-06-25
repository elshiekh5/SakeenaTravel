using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using DCCMSNameSpace.Zecurity;

public partial class AdminCP__UserControls_MailList_MailListArchive_GetAll : AdminDefaultUserControl
{
    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        if (!IsPostBack)
        {
        }
        FirstLoad(dgControl, pager, lblResult);

    }

    #endregion

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    protected override void LoadData()
    {
        List<MailListEmailsEntity> archiveList = MailListAchiveFactory.GetAll(pager.CurrentPage, PageSize, out totalRecords);
        LoadGrid(archiveList, "MailID");
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
        return MailListAchiveFactory.Delete(id);
    }
    //--------------------------------------------------------
    #endregion
}