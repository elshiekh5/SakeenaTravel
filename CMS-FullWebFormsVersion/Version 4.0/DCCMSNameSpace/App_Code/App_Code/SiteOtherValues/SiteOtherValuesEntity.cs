using System;
using System.Collections;



namespace DCCMSNameSpace
{
    public class SiteOtherValuesEntity
    {

        #region --------------SeetingID--------------
        private SiteOtherValuesItems _SeetingID;
        public SiteOtherValuesItems SeetingID
        {
            get { return _SeetingID; }
            set { _SeetingID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------Value--------------
        private string _Value = "";
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------Comment--------------
        private string _Comment = "";
        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }
        //------------------------------------------
        #endregion


        public bool GetBolleanValue()
        {
            //int tempInt = Convert.ToInt32();
            return Convert.ToBoolean(_Value);
        }


    }



}