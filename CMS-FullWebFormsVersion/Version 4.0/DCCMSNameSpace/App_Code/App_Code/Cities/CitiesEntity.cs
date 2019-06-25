using System;
using System.Data;
namespace DCCMSNameSpace
{
    public class CitiesEntity
    {

        #region --------------CityID--------------
        private int _CityID;
        [DCNonInsertable]
        [DCAttributes(SqlDbType.Int, 4)]
        public int CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CountryID--------------
        private int _CountryID;
        [DCAttributes(SqlDbType.Int, 4)]
        public int CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------NameAr--------------
        private string _NameAr = "";
        [DCAttributes(SqlDbType.NVarChar, 32)]
        public string NameAr
        {
            get { return _NameAr; }
            set { _NameAr = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------NameEn--------------
        private string _NameEn = "";
        [DCAttributes(SqlDbType.NVarChar, 32)]
        public string NameEn
        {
            get { return _NameEn; }
            set { _NameEn = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------GoogleMapHorizontal--------------
        private double _GoogleMapHorizontal = 0.0;
        [DCAttributes(SqlDbType.VarChar, 64)]
        public double GoogleMapHorizontal
        {
            get { return _GoogleMapHorizontal; }
            set { _GoogleMapHorizontal = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------GoogleMapVertical--------------
        private double _GoogleMapVertical = 0.0;
        [DCAttributes(SqlDbType.VarChar, 64)]
        public double GoogleMapVertical
        {
            get { return _GoogleMapVertical; }
            set { _GoogleMapVertical = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------GoogleMapVertical--------------
        private string _yy = "";
        public string yy
        {
            get { return _yy; }
            set { _yy = value; }
        }
        //------------------------------------------
        #endregion
    }
}