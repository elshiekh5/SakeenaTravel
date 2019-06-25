using System;
using DCCMSNameSpace;


namespace DCCMSNameSpace
{
    public class ItemsCommentsEntity
    {

        #region --------------CommentID--------------
        private int _CommentID;
        public int CommentID
        {
            get { return _CommentID; }
            set { _CommentID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ItemID--------------
        private int _ItemID;
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
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

        #region --------------ModuleTypeID--------------
        private int _ModuleTypeID;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SenderName--------------
        private string _SenderName = "";
        public string SenderName
        {
            get { return _SenderName; }
            set { _SenderName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CountryID--------------
        private int _CountryID;
        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CtryShort--------------
        private string _CtryShort = "";
        public string CtryShort
        {
            get { return _CtryShort; }
            set { _CtryShort = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SendingDate--------------
        private DateTime _SendingDate = DateTime.MinValue;
        public DateTime SendingDate
        {
            get { return _SendingDate; }
            set { _SendingDate = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SenderEmail--------------
        private string _SenderEmail = "";
        public string SenderEmail
        {
            get { return _SenderEmail; }
            set { _SenderEmail = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CommentTitle--------------
        private string _CommentTitle = "";
        public string CommentTitle
        {
            get { return _CommentTitle; }
            set { _CommentTitle = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CommentText--------------
        private string _CommentText = "";
        public string CommentText
        {
            get { return _CommentText; }
            set { _CommentText = value; }
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

        #region --------------IsSeen--------------
        private bool _IsSeen;
        public bool IsSeen
        {
            get { return _IsSeen; }
            set { _IsSeen = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------BadAlertsCount--------------
        private int _BadAlertsCount;
        public int BadAlertsCount
        {
            get { return _BadAlertsCount; }
            set { _BadAlertsCount = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------InsertUserName--------------
        private string _InsertUserName = "";
        public string InsertUserName
        {
            get { return _InsertUserName; }
            set { _InsertUserName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------LastUpdateUserName--------------
        private string _LastUpdateUserName = "";
        public string LastUpdateUserName
        {
            get { return _LastUpdateUserName; }
            set { _LastUpdateUserName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------BaseModuleType--------------
        private ModuleBaseTypes _BaseModuleType;
        public ModuleBaseTypes BaseModuleType
        {
            get { return _BaseModuleType; }
            set { _BaseModuleType = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------OwnerID--------------
        private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
        public Guid OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
        }
        //------------------------------------------
        #endregion
    }

}