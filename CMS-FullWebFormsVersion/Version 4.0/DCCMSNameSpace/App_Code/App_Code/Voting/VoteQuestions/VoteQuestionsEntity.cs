using System;


namespace DCCMSNameSpace
{
    public class VoteQuestionsEntity
    {

        #region --------------QuesID--------------
        private int _QuesID;
        public int QuesID
        {
            get { return _QuesID; }
            set { _QuesID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------QuestionText--------------
        private string _QuestionText = "";
        public string QuestionText
        {
            get { return _QuestionText; }
            set { _QuestionText = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------LangID--------------
        private Languages _LangID;
        public Languages LangID
        {
            get { return _LangID; }
            set { _LangID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CreatedOn--------------
        private DateTime _CreatedOn = DateTime.MinValue;
        public DateTime CreatedOn
        {
            get { return _CreatedOn; }
            set { _CreatedOn = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------IsClosed--------------
        private bool _IsClosed;
        public bool IsClosed
        {
            get { return _IsClosed; }
            set { _IsClosed = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------AnswersCount--------------
        private int _AnswersCount;
        public int AnswersCount
        {
            get { return _AnswersCount; }
            set { _AnswersCount = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------IsMain--------------
        private bool _IsMain;
        public bool IsMain
        {
            get { return _IsMain; }
            set { _IsMain = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------TotalHits--------------
        private int _TotalHits;
        public int TotalHits
        {
            get { return _TotalHits; }
            set { _TotalHits = value; }
        }
        //------------------------------------------
        #endregion
    }

}