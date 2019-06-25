using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;


namespace DCCMSNameSpace
{
    public class VoteAnswersFactory
    {


        #region --------------Create--------------

        public static bool Create(VoteAnswersEntity voteAnswers)
        {
            return VoteAnswersSqlDataPrvider.Instance.Create(voteAnswers);
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------

        public static bool Delete(int quesID)
        {
            bool status = VoteAnswersSqlDataPrvider.Instance.Delete(quesID);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetQuesAnswers--------------
        public static List<VoteAnswersEntity> GetQuesAnswers(int quesID)
        {
            return VoteAnswersSqlDataPrvider.Instance.GetQuesAnswers(quesID);
        }
        //------------------------------------------
        #endregion

        #region --------------IncreaseHits--------------

        public static bool IncreaseHits(int QuesID, int answerId)
        {
            bool status = VoteAnswersSqlDataPrvider.Instance.IncreaseHits(QuesID, answerId);
            return status;
        }
        //------------------------------------------
        #endregion
    }

}