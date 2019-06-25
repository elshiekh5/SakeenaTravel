using System;
using DCCMSNameSpace;


namespace DCCMSNameSpace
{
    public class MailListUsersEntity
    {

        #region --------------UserID--------------
        private int _UserID;
        public int UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------Email--------------
        private string _Email = "";
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------IsActive--------------
        private bool _IsActive;
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------JoinDate--------------
        private DateTime _JoinDate = DateTime.MinValue;
        public DateTime JoinDate
        {
            get { return _JoinDate; }
            set { _JoinDate = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------GroupID--------------
        private int _GroupID;
        public int GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------ModuleTypeID--------------
        private int _ModuleTypeID = (int)StandardItemsModuleTypes.MailList;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
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
        #region --------------Groups--------------
        private string _Groups = "";
        public string Groups
        {
            get { return _Groups; }
            set { _Groups = value; }
        }
        //------------------------------------------
        #endregion
        
    }
}
