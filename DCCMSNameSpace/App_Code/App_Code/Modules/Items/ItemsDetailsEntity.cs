using System;
using System.Collections.Generic;
namespace DCCMSNameSpace
{
    public class ItemsDetailsEntity
    {


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
        #region --------------Title--------------
        private string _Title = "";
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------ShortDescription--------------
        private string _ShortDescription = "";
        public string ShortDescription
        {
            get { return _ShortDescription; }
            set { _ShortDescription = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------Description--------------
        private string _Description = "";
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AuthorName--------------
        private string _AuthorName = "";
        public string AuthorName
        {
            get { return _AuthorName; }
            set { _AuthorName = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------Address--------------
        private string _Address = "";
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------ExtraData--------------
        private List<string> _ExtraData;
        public List<string> ExtraData
        {
            get
            {
                if (_ExtraData == null) _ExtraData = new List<string>();
                return _ExtraData;
            }
            set { _ExtraData = value; }
        }
        //------------------------------------------
        #endregion;

        #region --------------KeyWords--------------
        private string _KeyWords = "";
        public string KeyWords
        {
            get { return _KeyWords; }
            set { _KeyWords = value; }
        }
        //------------------------------------------
        #endregion
    }
}
