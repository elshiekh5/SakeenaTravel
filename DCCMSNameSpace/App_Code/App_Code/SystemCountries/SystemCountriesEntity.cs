using System;

namespace DCCMSNameSpace
{
    public class SystemCountriesEntity
    {

        #region --------------id--------------
        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------country_code--------------
        private string _country_code = "";
        public string country_code
        {
            get { return _country_code; }
            set { _country_code = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------country--------------
        private string _country = "";
        public string country
        {
            get { return _country; }
            set { _country = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------country_ar--------------
        private string _country_ar = "";
        public string country_ar
        {
            get { return _country_ar; }
            set { _country_ar = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------TIMEZONE_H--------------
        private int _TIMEZONE_H;
        public int TIMEZONE_H
        {
            get { return _TIMEZONE_H; }
            set { _TIMEZONE_H = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------TIMEZONE_M--------------
        private int _TIMEZONE_M;
        public int TIMEZONE_M
        {
            get { return _TIMEZONE_M; }
            set { _TIMEZONE_M = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------reg_id--------------
        private int _reg_id;
        public int reg_id
        {
            get { return _reg_id; }
            set { _reg_id = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------SimpleEnName--------------
        private string _SimpleEnName = "";
        public string SimpleEnName
        {
            get { return _SimpleEnName; }
            set { _SimpleEnName = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SimpleArName--------------
        private string _SimpleArName = "";
        public string SimpleArName
        {
            get { return _SimpleArName; }
            set { _SimpleArName = value; }
        }
        //------------------------------------------
        #endregion

    }
}