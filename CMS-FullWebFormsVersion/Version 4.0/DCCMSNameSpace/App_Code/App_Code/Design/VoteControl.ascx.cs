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

namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class VoteControl : ReadyUserControls.UserControl
        {
            ReadyUserControls.Voting ucVoting;
            ReadyUserControls.VoteResults ucVoteResult;
            protected void Page_Load(object sender, EventArgs e)
            {
                //-------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                if (!IsPostBack)
                {
                    if (SiteSettings.Vote_Enabled)
                        LoadData();
                }
            }

            #region ---------------CatchControls---------------
            //-----------------------------------------------
            //CatchControls
            //-----------------------------------------------
            protected void CatchControls()
            {
                ucVoting = (ReadyUserControls.Voting)this.FindControl("ucVoting");
                ucVoteResult = (ReadyUserControls.VoteResults)this.FindControl("ucVoteResult");
            }
            //-----------------------------------------------
            #endregion

            protected void LoadData()
            {
                VoteQuestionsEntity CurrentVote = VoteQuestionsFactory.GetMain();
                HttpContext.Current.Items["CurrentVote"] = CurrentVote;
                if (CurrentVote == null)
                {
                    this.Visible = false;
                    return;

                }
                if (CurrentVote != null && !CurrentVote.IsClosed)
                {

                    ucVoting.Visible = true;
                    ucVoting.QuesID = CurrentVote.QuesID;
                    ucVoting.LoadData();
                    //-----------------------------
                    ucVoteResult.Visible = false;
                }
                else
                {
                    ucVoteResult.Visible = true;
                    ucVoteResult.QuesID = CurrentVote.QuesID;
                    ucVoteResult.LoadData();
                    ucVoting.Visible = false;
                }

                //-----------------------------
            }
        }
    }
}