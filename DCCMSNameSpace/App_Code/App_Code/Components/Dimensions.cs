using System;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class Dimensions
    {
        private string _wid;
        public string Width
        {
            get { return _wid; }
            set { _wid = value; }
        }

        private string hei;
        public string Height
        {
            get { return hei; }
            set { hei = value; }
        }

        private string siz;
        public string Size
        {
            get { return siz; }
            set { siz = value; }
        }
    }
}