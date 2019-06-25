using System;
namespace DCCMSNameSpace
{
    public class AdvertismentsEntity
    {

        #region --------------AdvertiseID--------------
        private int _AdvertiseID;
        public int AdvertiseID
        {
            get { return _AdvertiseID; }
            set { _AdvertiseID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------PlaceID--------------
        private int _PlaceID;
        public int PlaceID
        {
            get { return _PlaceID; }
            set { _PlaceID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------Url--------------
        private string _Url = "";
        public string Url
        {
            get { return _Url; }
            set { _Url = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------FileExtension--------------
        private string _FileExtension = "";
        public string FileExtension
        {
            get { return _FileExtension; }
            set { _FileExtension = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------File--------------
        public string File
        {
            get
            {
                if (_FileExtension.Length > 0)
                {
                    return GetFileName(_FileExtension);
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion
        public string GetFileName(string extension)
        {
            return AdvertiseID + extension;
        }

        public string GetFileVirtualPath()
        {
            return GetFileVirtualPath(_FileExtension);
        }

        public string GetFileVirtualPath(string extension)
        {
            string fileName = GetFileName(extension);
            return DCSiteUrls.GetPath_UAdvertisments (OwnerName) + fileName;
        }
        #region --------------FileType--------------
        private AdsTypes _FileType = AdsTypes.Unknowen;
        public AdsTypes FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
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

        #region --------------Weight--------------
        private int _Weight;
        public int Weight
        {
            get { return _Weight; }
            set { _Weight = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MaxApperance--------------
        private int _MaxApperance;
        public int MaxApperance
        {
            get { return _MaxApperance; }
            set { _MaxApperance = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MaxClicks--------------
        private int _MaxClicks;
        public int MaxClicks
        {
            get { return _MaxClicks; }
            set { _MaxClicks = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ApperanceCount--------------
        private int _ApperanceCount;
        public int ApperanceCount
        {
            get { return _ApperanceCount; }
            set { _ApperanceCount = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ClicksCount--------------
        private int _ClicksCount;
        public int ClicksCount
        {
            get { return _ClicksCount; }
            set { _ClicksCount = value; }
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

        #region --------------LangID--------------
        private Languages _LangID;
        public Languages LangID
        {
            get { return _LangID; }
            set { _LangID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------IsSmall--------------
        private bool _IsSmall;
        public bool IsSmall
        {
            get { return _IsSmall; }
            set { _IsSmall = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------OwnerID--------------
        private Guid _OwnerID = Guid.Empty;
        public Guid OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------OwnerName--------------
        private string _OwnerName = SitesHandler.GetOwnerIdentifire();
        public string OwnerName
        {
            get { return _OwnerName; }
            set { _OwnerName = value; }
        }
        //------------------------------------------
        #endregion

    }
}

