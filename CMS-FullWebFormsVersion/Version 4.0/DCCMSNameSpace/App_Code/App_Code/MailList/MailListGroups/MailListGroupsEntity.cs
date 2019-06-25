using System;


namespace DCCMSNameSpace
{
    public class MailListGroupsEntity
    {

        #region --------------GroupID--------------
        private int _GroupID;
        public int GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------Name--------------
        private string _Name = "";
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        //------------------------------------------
        #endregion
        

    }
}
