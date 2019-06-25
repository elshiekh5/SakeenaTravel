using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using DCCMSNameSpace.Zecurity;
using System.Web.UI.HtmlControls;

public partial class AdminCP__UserControls_Voting_VoteQuestions_Default : System.Web.UI.UserControl
{
    List<VoteQuestionsEntity> voteQuestionsList;

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {
            HandelControls();
            PagerManager.PrepareAdminPager(pager);
            pager.Visible = false;
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
        #region ------------------Languages Handling---------------------
        //Languages Handling
        if (SiteSettings.Languages_HasMultiLanguages)
            SiteSettings.BuildDropDownListForDefaultPage(ddlLanguages);
        else
            trLanguages.Visible = false;
        #endregion
    }
    #endregion

    #region --------------LoadData--------------
    //---------------------------------------------------------
    //LoadData
    //---------------------------------------------------------
    protected void LoadData()
    {
        //------------------------------------------------------------------------
        Languages langID = Languages.Unknowen;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //------------------------------------------------------------------------
        int pageSize = 10;//SiteSettings.Site_AdminPageSize;
        int totalRecords = 0;
        pager.PageSize = pageSize;
        voteQuestionsList = VoteQuestionsFactory.GetAll(langID, pager.CurrentPage, pager.PageSize, out totalRecords);
        //------------------------------------------------------------------------
        if (voteQuestionsList != null && voteQuestionsList.Count > 0)
        {
            dgControl.DataSource = voteQuestionsList;
            dgControl.DataKeyField = "QuesID";
            dgControl.AllowPaging = false;
            pager.Visible = true;
            pager.TotalRecords = totalRecords;
            dgControl.DataBind();
            dgControl.Visible = true;

        }
        else
        {
            dgControl.Visible = false;
            pager.Visible = false;
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.ThereIsNoData;
        }
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

    #region --------------dgControl_ItemDataBound--------------
    //---------------------------------------------------------
    //dgControl_ItemDataBound
    //---------------------------------------------------------
    public void dgControl_ItemDataBound(object source, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            ImageButton lbtnDelete = (ImageButton)e.Item.FindControl("lbtnDelete");
            lbtnDelete.Attributes.Add("onclick", "return confirm('" + Resources.AdminText.DeleteActivation + "')");
            lbtnDelete.AlternateText = Resources.AdminText.Delete;
            #region ---------Index-------
            //Set Index
            int previousRowsCount = 0;
            if (pager != null)
                previousRowsCount = (pager.CurrentPage - 1) * pager.PageSize;
            int currentRow = e.Item.ItemIndex + 1;
            e.Item.Cells[0].Text = (previousRowsCount + currentRow).ToString();
            #endregion
            //New options 
            System.Web.UI.WebControls.Image imgStatus = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgStatus");
            ImageButton lbtnOpen = (ImageButton)e.Item.FindControl("lbtnOpen");
            ImageButton lbtnClose = (ImageButton)e.Item.FindControl("lbtnClose");
            HtmlAnchor aViewResult = (HtmlAnchor)e.Item.FindControl("aViewResult");
            HtmlAnchor aUpdate = (HtmlAnchor)e.Item.FindControl("aUpdate");
            VoteQuestionsEntity vote = voteQuestionsList[e.Item.ItemIndex];
            VoteStatus vStatus = VoteQuestionsFactory.GetVoteStatus(vote.IsClosed, vote.IsMain);
            SetStatus(vStatus, imgStatus);
            lbtnOpen.Visible = CheckOpenAvilabilty(vStatus);
            lbtnClose.Visible = CheckCloseAvilabilty(vStatus);
            aUpdate.Visible = CheckOpenAvilabilty(vStatus);
            if (vStatus != VoteStatus.WaitForOpening)
                aViewResult.Visible = true;
            else
                aViewResult.Visible = false;

        }
    }
    //--------------------------------------------------------
    #endregion

    #region --------------SetStatus--------------

    protected void SetStatus(VoteStatus vStatus, System.Web.UI.WebControls.Image imgStatus)
    {
        switch (vStatus)
        {
            case VoteStatus.Open:
                imgStatus.ImageUrl = "/Content/AdminDesign/global/images/Icons/unlock green.png";
                imgStatus.Width = 20;
                imgStatus.Height = 20;
                imgStatus.AlternateText = Resources.Vote.Status_Active;
                break;
            case VoteStatus.Closed:
                imgStatus.ImageUrl = "/Content/AdminDesign/global/images/Icons/Lock_black.png";
                imgStatus.Width = 20;
                imgStatus.Height = 20;
                imgStatus.AlternateText = Resources.Vote.Status_Closed;
                break;
            case VoteStatus.WaitForOpening:
                imgStatus.ImageUrl = "/Content/AdminDesign/global/images/Icons/clock_alarm.png";
                imgStatus.Width = 20;
                imgStatus.Height = 20;
                imgStatus.AlternateText = Resources.Vote.Status_Waiting;
                break;
            default:
                imgStatus.ImageUrl = "/Content/AdminDesign/global/images/Icons/lock red.png";
                imgStatus.Width = 20;
                imgStatus.Height = 20;
                imgStatus.AlternateText = Resources.Vote.Status_Close;
                break;
        }
    }
    //--------------------------------------------------------
    #endregion

    public bool CheckOpenAvilabilty(VoteStatus vStatus)
    {
        switch (vStatus)
        {
            case VoteStatus.Open:
                return false;
            case VoteStatus.Closed:
                return true;
            case VoteStatus.WaitForOpening:
                return true;
            default:
                return false;
        }
    }

    public bool CheckCloseAvilabilty(VoteStatus vStatus)
    {
        switch (vStatus)
        {
            case VoteStatus.Open:
                return true;
            case VoteStatus.Closed:
                return false;
            case VoteStatus.WaitForOpening:
                return false;
            default:
                return false;
        }
    }
    protected void dgControl_ItemCommand(object source, DataGridCommandEventArgs e)
    {
        int id = Convert.ToInt32(dgControl.DataKeys[e.Item.ItemIndex]);
        VoteQuestionsEntity voteQuestions = VoteQuestionsSqlDataPrvider.Instance.GetObject(id);
        if (voteQuestions != null)
        {

            if (e.CommandName == "Open")
            {
                VoteQuestionsFactory.Open(id);
            }
            else if (e.CommandName == "Close")
            {
                VoteQuestionsFactory.Close(id);

            }
            LoadData();
        }
    }
    protected void ddlLanguages_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadData();
    }

    #region --------------dgControl_DeleteCommand--------------
    //---------------------------------------------------------
    //dgControl_DeleteCommand
    //---------------------------------------------------------
    public void dgControl_DeleteCommand(object source, DataGridCommandEventArgs e)
    {
        int id = Convert.ToInt32(dgControl.DataKeys[e.Item.ItemIndex]);
        bool status = VoteQuestionsFactory.Delete(id);
        if (status)
        {
            //if one item in datagrid
            if (dgControl.Items.Count == 1 && pager.CurrentPage > 1)
            {
                --pager.CurrentPage;
            }
            LoadData();
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.DeletingOprationFaild;
        }
    }
    //--------------------------------------------------------
    #endregion

    #region --------------Pager_PageIndexChang--------------
    //---------------------------------------------------------
    //Pager_PageIndexChang
    //---------------------------------------------------------
    public void Pager_PageIndexChang()
    {
        LoadData();
    }
    //--------------------------------------------------------
    #endregion
}