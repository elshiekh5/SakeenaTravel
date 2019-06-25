using System;


namespace DCCMSNameSpace
{
    public class VoteAnswersEntity
    {

        #region --------------AnswerId--------------
        private int _AnswerId;
        public int AnswerId
        {
            get { return _AnswerId; }
            set { _AnswerId = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------QuesID--------------
        private int _QuesID;
        public int QuesID
        {
            get { return _QuesID; }
            set { _QuesID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------AnswerText--------------
        private string _AnswerText = "";
        public string AnswerText
        {
            get { return _AnswerText; }
            set { _AnswerText = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------HitsCount--------------
        private int _HitsCount;
        public int HitsCount
        {
            get { return _HitsCount; }
            set { _HitsCount = value; }
        }
        //------------------------------------------
        #endregion

    }

}