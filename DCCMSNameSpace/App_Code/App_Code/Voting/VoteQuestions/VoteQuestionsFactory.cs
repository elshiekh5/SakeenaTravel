using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;


namespace DCCMSNameSpace
{
    public class VoteQuestionsFactory
    {
        #region --------------Save--------------

        public static bool Save(VoteQuestionsEntity voteQuestions, SPOperation operation)
        {
            return VoteQuestionsSqlDataPrvider.Instance.Save(voteQuestions, operation);
        }
        //------------------------------------------
        #endregion

        #region --------------Open--------------
        public static bool Open(int quesID)
        {
            bool status = VoteQuestionsSqlDataPrvider.Instance.Open(quesID);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Close--------------
        public static bool Close(int quesID)
        {
            bool status = VoteQuestionsSqlDataPrvider.Instance.Close(quesID);
            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single VoteQuestions object .
        /// <example>[Example]bool status=VoteQuestionsFactory.Delete(quesID);.</example>
        /// </summary>
        /// <param name="quesID">The voteQuestions id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int quesID)
        {
            bool status = VoteQuestionsSqlDataPrvider.Instance.Delete(quesID);

            return status;
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<VoteQuestionsEntity> GetAll(Languages langID)
        {
            int totalRecords = 0;
            return VoteQuestionsSqlDataPrvider.Instance.GetAll(false, langID, -1, -1, out totalRecords);
        }
        public static List<VoteQuestionsEntity> GetAll(Languages langID, int pageIndex, int pageSize, out int totalRecords)
        {

            return VoteQuestionsSqlDataPrvider.Instance.GetAll(false, langID, pageIndex, pageSize, out totalRecords);
        }
        public static List<VoteQuestionsEntity> GetPrevious(Languages langID, int pageIndex, int pageSize, out int totalRecords)
        {

            return VoteQuestionsSqlDataPrvider.Instance.GetAll(true, langID, pageIndex, pageSize, out totalRecords);
        }
        //------------------------------------------
        #endregion

        #region --------------GetObject--------------
        public static VoteQuestionsEntity GetObject(int quesID)
        {
            VoteQuestionsEntity voteQuestions = VoteQuestionsSqlDataPrvider.Instance.GetObject(quesID);
            //return the object
            return voteQuestions;
        }
        //------------------------------------------
        #endregion


        #region --------------GetMain--------------
        public static VoteQuestionsEntity GetMain()
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            VoteQuestionsEntity voteQuestions = VoteQuestionsSqlDataPrvider.Instance.GetMain(langID);
            //return the object
            return voteQuestions;
        }
        //------------------------------------------
        #endregion


        public static VoteStatus GetVoteStatus(object isClosed, object isMain)
        {
            return GetVoteStatus((bool)isClosed, (bool)isMain);
        }
        public static VoteStatus GetVoteStatus(bool isClosed, bool isMain)
        {
            if (isClosed)
                return VoteStatus.Closed;
            else if (isMain)
                return VoteStatus.Open;
            else
                return VoteStatus.WaitForOpening;
        }
    }

}