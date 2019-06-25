using System;
namespace DCCMSNameSpace
{
    public enum AdvPlaceTypes
    {
        UnDefined = -1,
        MasterWebSite = 1,
        SubSite=2
    }
    public class AdvPlacesEntity
    {

        #region --------------PlaceID--------------
        private int _PlaceID;
        public int PlaceID
        {
            get { return _PlaceID; }
            set { _PlaceID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------PlaceIdentifier--------------
        private string _PlaceIdentifier = "";
        public string PlaceIdentifier
        {
            get { return _PlaceIdentifier; }
            set { _PlaceIdentifier = value; }
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
        #region --------------Width--------------
        private int _Width;
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------Height--------------
        private int _Height;
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------DefaultFilePath--------------
        private string _DefaultFilePath = "";
        public string DefaultFilePath
        {
            get { return _DefaultFilePath; }
            set { _DefaultFilePath = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------DefaultFileType--------------
        private AdsTypes _DefaultFileType = AdsTypes.Unknowen;
        public AdsTypes DefaultFileType
        {
            get { return _DefaultFileType; }
            set { _DefaultFileType = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------ActiveAdvertiseID--------------
        private int _ActiveAdvertiseID;
        public int ActiveAdvertiseID
        {
            get { return _ActiveAdvertiseID; }
            set { _ActiveAdvertiseID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------IsRandom--------------
        private bool _IsRandom;
        public bool IsRandom
        {
            get { return _IsRandom; }
            set { _IsRandom = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------EnableSeparatedAd--------------
        private bool _EnableSeparatedAd;
        public bool EnableSeparatedAd
        {
            get { return _EnableSeparatedAd; }
            set { _EnableSeparatedAd = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------EnableSeparatedCount--------------
        private int _EnableSeparatedCount;
        public int EnableSeparatedCount
        {
            get { return _EnableSeparatedCount; }
            set { _EnableSeparatedCount = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------PlaceType--------------
        private AdvPlaceTypes _PlaceType = AdvPlaceTypes.MasterWebSite;
        public AdvPlaceTypes PlaceType
        {
            get { return _PlaceType; }
            set { _PlaceType = value; }
        }
        //------------------------------------------
        #endregion
        

    }
}
