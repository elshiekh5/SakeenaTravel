using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;
namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class Voting : ReadyUserControls.UserControl
        {
            public int QuesID
            {
                get
                {
                    if (ViewState["QuesID"] != null)
                        return (int)ViewState["QuesID"];
                    else
                        return 0;
                }
                set { ViewState["QuesID"] = value; }
            }
            //-----------------------------------------------------------
            public double TotalHits = 0;
            //-----------------------------------------------------------
            Label lblQuestion;
            Label lblResult;
            RadioButtonList rbtlAnswers;
            ImageButton ibtnVote;
            HtmlAnchor aPreviousVotes;
            //-----------------------------------------------------------
            bool IsControlsLoaded = false;
            //-----------------------------------------------------------
            public void Page_Load(object sender, EventArgs e)
            {
                //-----------------------------------------------------------
                LoadControls();
                //-----------------------------------------------------------
            }
            #region ---------------LoadControls---------------
            //-----------------------------------------------
            //LoadControls
            //-----------------------------------------------
            protected void LoadControls()
            {
                //-------------------------------------------------
                //Prepaare user control
                if (!IsControlsLoaded)
                {
                    CatchControls();
                    Prepare();
                }
                //-------------------------------------------------
            }
            //-----------------------------------------------
            #endregion
            #region ---------------CatchControls---------------
            //-----------------------------------------------
            //CatchControls
            //-----------------------------------------------
            protected void CatchControls()
            {
                lblQuestion = (Label)this.FindControl("lblQuestion");
                lblResult = (Label)this.FindControl("lblResult");
                rbtlAnswers = (RadioButtonList)this.FindControl("rbtlAnswers");
                ibtnVote = (ImageButton)this.FindControl("ibtnVote");
                aPreviousVotes = (HtmlAnchor)this.FindControl("aPreviousVotes");
            }
            //-----------------------------------------------
            #endregion

            //-----------------------------------------------------------
            public void LoadData()
            {

                //-----------------------------------------------------------
                LoadControls();
                //-----------------------------------------------------------

                VoteQuestionsEntity vote;
                if (HttpContext.Current.Items["CurrentVote"] != null)
                    vote = (VoteQuestionsEntity)HttpContext.Current.Items["CurrentVote"];
                else
                    vote = VoteQuestionsFactory.GetMain();
                //-------------------------------------------------
                if (vote != null)
                {
                    if (!vote.IsClosed)
                    {

                        lblQuestion.Text = vote.QuestionText;
                        QuesID = vote.QuesID;
                        List<VoteAnswersEntity> answersList = VoteAnswersFactory.GetQuesAnswers(vote.QuesID);
                        rbtlAnswers.DataSource = answersList;
                        rbtlAnswers.DataTextField = "AnswerText";
                        rbtlAnswers.DataValueField = "AnswerId";
                        rbtlAnswers.DataBind();
                        //-------------------------
                        TotalHits = vote.TotalHits;
                        //-------------------------
                        if (SiteSettings.Vote_CloseDuplicateVotingByCookie && Request.Cookies["VoteCookie" + QuesID] != null)
                        {
                            rbtlAnswers.Enabled = false;
                        }
                        if (aPreviousVotes != null)
                        {
                            aPreviousVotes.HRef = "/Website/AdditionalModules/Vote/flash.aspx?id=" + vote.QuesID;
                            //aPreviousVotes.HRef = "/Website/AdditionalModules/Vote/PreviousVotes.aspx";
                        }
                    }
                    else
                    {

                        rbtlAnswers.Visible = false;
                    }

                }
                else
                {
                    this.Visible = false;
                }
            }
            public void ibtnVote_Click(object sender, ImageClickEventArgs e)
            {
                if (!Page.IsValid)
                    return;
                //-----------------------------------------------------------
                LoadControls();
                //-----------------------------------------------------------

                if (SiteSettings.Vote_CloseDuplicateVotingByCookie && Request.Cookies["VoteCookie" + QuesID] != null)
                {
                    lblResult.CssClass = "lblResult_Faild";
                    lblResult.Text = DynamicResource.GetText("Vote","YouAlreadyVoted");
                }
                else
                {
                    Response.Cookies.Set(new HttpCookie("VoteCookie" + QuesID, "DefaultValue" + QuesID));
                    Response.Cookies["VoteCookie"].Expires = DateTime.Now.AddYears(1);
                    int answerId = Convert.ToInt32(rbtlAnswers.SelectedValue);
                    if (answerId > 0)
                    {
                        VoteAnswersFactory.IncreaseHits(QuesID, answerId);
                        lblResult.CssClass = "lblResult_Done";
                        lblResult.Text = DynamicResource.GetText("Vote","Thanks4Voting");
                        rbtlAnswers.Enabled = false;
                        rbtlAnswers.SelectedIndex = -1;
                        GenScript();
                        //Response.Redirect("/Website/AdditionalModules/Vote/default.aspx?id=" + QuesID);

                    }
                }
            }
            public void GenScript()
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "popup", "<script language=javascript>FireResultLinker()</script>");
            }
        }
    }
}