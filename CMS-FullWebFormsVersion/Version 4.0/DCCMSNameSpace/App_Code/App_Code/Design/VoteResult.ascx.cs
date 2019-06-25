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
namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {

        public partial class VoteResults : ReadyUserControls.UserControl
        {
            //---------------------------------------
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
            //---------------------------------------
            public bool ViewPreviousVotesLink
            {
                get
                {
                    if (ViewState["ViewPreviousVotesLink"] != null)
                        return (bool)ViewState["ViewPreviousVotesLink"];
                    else
                        return true;
                }
                set { ViewState["ViewPreviousVotesLink"] = value; }
            }
            //---------------------------------------
            public List<VoteAnswersEntity> answersList;
            //---------------------------------------
            public double TotalHits = 0;
            //---------------------------------------
            Label lblQuestion;
            Repeater rAnswers;
            HtmlAnchor aPreviousVotes;
            //-----------------------------------------------------------
            bool IsControlsLoaded = false;
            //-----------------------------------------------------------
            protected void Page_Load(object sender, EventArgs e)
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
                rAnswers = (Repeater)this.FindControl("rAnswers");
                aPreviousVotes = (HtmlAnchor)this.FindControl("aPreviousVotes");
            }
            //-----------------------------------------------
            #endregion

            public void LoadData()
            {
                //-----------------------------------------------------------
                LoadControls();
                //-----------------------------------------------------------
                aPreviousVotes.Visible = ViewPreviousVotesLink;
                //-------------------------------------------------
                VoteQuestionsEntity vote;
                if (HttpContext.Current.Items["CurrentVote"] != null)
                    vote = (VoteQuestionsEntity)HttpContext.Current.Items["CurrentVote"];
                else
                    vote = VoteQuestionsFactory.GetMain();
                //-------------------------------------------------
                if (vote != null)
                {
                    lblQuestion.Text = vote.QuestionText;
                    answersList = VoteAnswersFactory.GetQuesAnswers(vote.QuesID);
                    //TotalHits
                    /*foreach (VoteAnswersEntity answer in answersList)
                    {
                        TotalHits += answer.HitsCount;
                    }*/
                    TotalHits = vote.TotalHits;
                    //----------------------------------
                    rAnswers.DataSource = answersList;
                    rAnswers.DataBind();
                    if (aPreviousVotes != null)
                    {
                        // aPreviousVotes.HRef = "/Website/AdditionalModules/Vote/flash.aspx?id=" + vote.QuesID;
                        aPreviousVotes.HRef = "/Website/AdditionalModules/Vote/PreviousVotes.aspx";
                    }
                    //-----------------------------
                }
                else
                {
                    this.Visible = false;
                }
            }
            //---------------------------------------
            protected void rAnswers_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if (TotalHits > 0)
                {
                    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                    {
                        VoteAnswersEntity answer = answersList[e.Item.ItemIndex];
                        /*double MaxLength = SiteSettings.Vote_ImageMaxLength;*/
                        double imageWidth = (100 * (answer.HitsCount / TotalHits));
                        //double MinLength = SiteSettings.Vote_ImageMinLength;
                        decimal roundWidth = Math.Round((decimal)imageWidth, 2);
                        //if (imageWidth < 1 && answer.HitsCount > 0)
                        //    imageWidth = MinLength;
                        //Image imgAnswerImage = (Image)e.Item.FindControl("imgAnswerImage");
                        //imgAnswerImage.Style.Add(HtmlTextWriterStyle.Width, roundWidth.ToString());
                        Label lblImage = (Label)e.Item.FindControl("lblImage");
                        lblImage.Style.Add(HtmlTextWriterStyle.Width, roundWidth.ToString() + "%");

                        Label lblRate = (Label)e.Item.FindControl("lblRate");
                        lblRate.Text = roundWidth.ToString() + "%";

                    }
                }
            }
            //---------------------------------------
        }

    }
}