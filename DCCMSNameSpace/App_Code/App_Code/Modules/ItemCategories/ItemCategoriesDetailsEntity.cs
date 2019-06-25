using System;


namespace DCCMSNameSpace
{
    public class ItemCategoriesDetailsEntity
    {


        #region --------------CategoryID--------------
        private int _CategoryID;
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
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
