using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
using System.Web.UI.HtmlControls;

public partial class AdminCP__UserControls_Voting_VoteQuestions_Add : System.Web.UI.UserControl
{
    //------------------------------------------------------------------//
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
            load_ddlAnswersCount();
        }
    }
    //-----------------------------------------------
    #endregion
    //------------------------------------------------------------------//
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
    //------------------------------------------------------------------//
    protected void load_ddlAnswersCount()
    {
        int maxVotechoice = SiteSettings.Vote_MaxChoices;
        string itemValue;
        ddlAnswersCount.Items.Add(new ListItem(Resources.AdminText.Choose, "-1"));
        for (int i = 2; i <= maxVotechoice; i++)
        {
            itemValue = i.ToString();
            ddlAnswersCount.Items.Add(new ListItem(itemValue, itemValue));
        }
    }
    //------------------------------------------------------------------//
    protected void LoadAnswers(VoteQuestionsEntity voteQuestions)
    {
        List<VoteAnswersEntity> voteAnswersList = VoteAnswersFactory.GetQuesAnswers(voteQuestions.QuesID);
        int answersCount = Convert.ToInt32(ddlAnswersCount.SelectedValue);
        TextBox txt = new TextBox();
        VoteAnswersEntity answer;
        for (int i = 1; i <= voteAnswersList.Count; i++)
        {
            txt = (TextBox)phAnswers.FindControl("txt" + i);
            answer = voteAnswersList[i - 1];
            txt.Text = answer.AnswerText;
        }


    }
    //------------------------------------------------------------------//
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);
        LoadAnswesControls();
    }
    //------------------------------------------------------------------//
    #region LoadAnswesControls
    protected void LoadAnswesControls()
    {
        int maxVotechoice = SiteSettings.Vote_MaxChoices;
        for (int i = 1; i <= maxVotechoice; i++)
        {
            GenerateAnswer(i.ToString());

        }
    }
    protected void GenerateAnswer(string i)
    {
        HtmlTableRow tr = new HtmlTableRow();
        tr.ID = "tr" + i;
        tr.Visible = false;
        HtmlTableCell tdText = new HtmlTableCell();
        tdText.Attributes.Add("class", "Text");
        Label lblText = new Label();
        lblText.Text = i;
        tdText.Controls.Add(lblText);
        tr.Controls.Add(tdText);
        HtmlTableCell tdControls = new HtmlTableCell();
        tdControls.Attributes.Add("class", "Control");
        //----------------------------------
        Literal ltrStart = new Literal();

        //ltrStart.Text += "<div id=\"div\" style=\"display:none;\">";
        //trStart.Text += "<tr><td class=\"Text\">"+i+"</td>";
        //ltrStart.Text += "<td class=\"Control\">";
        //----------------------------------
        //Literal ltrEnd = new Literal();
        //ltrEnd.Text = "</td></tr></div>";
        //----------------------------------
        TextBox txt = new TextBox();
        txt.CssClass = "Controls";
        txt.ValidationGroup = "Vote";
        txt.ID = "txt" + i;
        //----------------------------------
        Literal ltrSpace = new Literal();
        ltrSpace.Text = "&nbsp;";
        //----------------------------------
        RequiredFieldValidator rfv = new RequiredFieldValidator();
        rfv.ID = "rfv" + i;
        rfv.ControlToValidate = txt.ID;
        rfv.ValidationGroup = "Vote";
        rfv.Display = ValidatorDisplay.Dynamic;
        rfv.Text = "*";
        //-----------------------------------------

        //phAnswers.Controls.Add(ltrStart);
        tdControls.Controls.Add(txt);
        tdControls.Controls.Add(ltrSpace);
        tdControls.Controls.Add(rfv);
        tr.Controls.Add(tdControls);
        phAnswers.Controls.Add(tr);
        //phAnswers.RenderControl(writer);
    }
    #endregion
    //------------------------------------------------------------------//
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


        VoteQuestionsEntity voteQuestions = new VoteQuestionsEntity();
        voteQuestions.QuesID = Convert.ToInt32(Request.QueryString["id"]);
        voteQuestions.QuestionText = txtQuestionText.Text;
        voteQuestions.AnswersCount = Convert.ToInt32(ddlAnswersCount.SelectedValue);
        voteQuestions.IsMain = cbIsMain.Checked;
        //---------------------------------------------------------------------
        //Language
        //---------------------------------------------------------------------
        Languages langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
        if (SiteSettings.Languages_HasMultiLanguages)
            langID = (Languages)Convert.ToInt32(ddlLanguages.SelectedValue);
        //--------------------------------------
        voteQuestions.LangID = langID;
        //---------------------------------------------------------------------
        bool result = VoteQuestionsFactory.Save(voteQuestions, SPOperation.Insert);
        if (result)
        {
            int answersCount = Convert.ToInt32(ddlAnswersCount.SelectedValue);
            TextBox txt = new TextBox();
            VoteAnswersEntity answer;
            for (int i = 1; i <= answersCount; i++)
            {
                txt = (TextBox)phAnswers.FindControl("txt" + i);
                answer = new VoteAnswersEntity();
                answer.QuesID = voteQuestions.QuesID;
                answer.AnswerText = txt.Text;
                VoteAnswersFactory.Create(answer);
            }
            lblResult.CssClass = "operation_done";
            lblResult.Text = Resources.AdminText.SavingDataSuccessfuly;
            ClearControls(voteQuestions.AnswersCount);
        }
        else
        {
            lblResult.CssClass = "operation_error";
            lblResult.Text = Resources.AdminText.SavingDataFaild;
        }
    }
    #endregion
    //------------------------------------------------------------------//
    protected void ddlAnswersCount_SelectedIndexChanged(object sender, EventArgs e)
    {
        int answersCount = Convert.ToInt32(ddlAnswersCount.SelectedValue);
        AnsewrsApperingControl(answersCount);
    }
    //------------------------------------------------------------------//
    protected void AnsewrsApperingControl(int answersCount)
    {
        int maxVotechoice = SiteSettings.Vote_MaxChoices;
        HtmlTableRow tr = new HtmlTableRow();
        if (answersCount < 0) answersCount = 0;
        for (int i = 1; i <= answersCount; i++)
        {
            tr = (HtmlTableRow)phAnswers.FindControl("tr" + i);
            tr.Visible = true;
        }
        for (int i = answersCount + 1; i <= maxVotechoice; i++)
        {
            tr = (HtmlTableRow)phAnswers.FindControl("tr" + i);
            tr.Visible = false;
        }
    }
    //------------------------------------------------------------------//
    protected void ClearControls(int answersCount)
    {
        txtQuestionText.Text = "";
        cbIsMain.Checked = false;
        ddlAnswersCount.SelectedIndex = -1;
        ClearAnsewrsControl(answersCount);
    }

    protected void ClearAnsewrsControl(int answersCount)
    {
        int maxVotechoice = SiteSettings.Vote_MaxChoices;
        HtmlTableRow tr = new HtmlTableRow();
        TextBox txt = new TextBox();

        for (int i = 1; i <= answersCount; i++)
        {
            tr = (HtmlTableRow)phAnswers.FindControl("tr" + i);
            txt = (TextBox)phAnswers.FindControl("txt" + i);
            txt.Text = "";
            tr.Visible = false;
        }
        /*
        for (int i = answersCount + 1; i <= maxVotechoice; i++)
        {
            tr = (HtmlTableRow)phAnswers.FindControl("tr" + i);
            tr.Visible = false;
        }*/
    }
}