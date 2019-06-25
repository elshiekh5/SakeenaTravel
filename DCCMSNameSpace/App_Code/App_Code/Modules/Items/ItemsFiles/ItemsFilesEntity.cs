using System;
using DCCMSNameSpace;


namespace DCCMSNameSpace
{
    public class ItemsFilesEntity //: IPhotoable
    {


        #region --------------FileID--------------
        private int _FileID;
        public int FileID
        {
            get { return _FileID; }
            set { _FileID = value; }
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
                    return FileIdentifre + (_FileID) + _FileExtension;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion

        public static string FileIdentifre = "ItemFiles_";

        #region --------------FileType--------------
        private ItemFileTypes _FileType;
        public ItemFileTypes FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }
        //------------------------------------------
        #endregion

        #region---------------IPhotoable--------------
        #region --------------PhotoExtension--------------
        public string PhotoExtension
        {
            get { return _FileExtension; }
            set { _FileExtension = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------Photo--------------
        public string Photo
        {
            get
            {
                if (_FileExtension.Length > 0)
                {
                    return FileIdentifre + (_FileID) + _FileExtension;
                }
                else
                {
                    return "";
                }
            }
        }
        //------------------------------------------
        #endregion
        public string GetOldOriginalPhotoName(string photoExtension)
        {
            return Photos.GetPhotoName(photoExtension, PhotoTypes.Original, FileIdentifre, _FileID);
        }

        public string GetPhotoName(PhotoTypes photo)
        {
            return Photos.GetPhotoName(_FileExtension, photo, FileIdentifre, _FileID);
        }

        public string GetPhotoPath(PhotoTypes photo)
        {
            if (_FileExtension.Length > 0)
            {
                string photoName = GetPhotoName(photo);
                string path = DCSiteUrls.GetPath_ItemsFiles(OwnerName, ModuleTypeID, CategoryID, ItemID) + photoName;
                string realPath = string.Format(path, ItemID.ToString());
                return realPath;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }


        public static string GetPhotoPath(PhotoTypes photo, object _PhotoID, object _photoExtension, object ownerName, object ModuleTypeID, object CategoryID, object ItemID)
        {
            if (((string)_photoExtension).Length > 0)
            {
                string photoName = Photos.GetPhotoName((string)_photoExtension, photo, FileIdentifre, (int)_PhotoID);

                string path = DCSiteUrls.GetPath_ItemsFiles((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)ItemID) + photoName;
                string realPath = string.Format(path, _PhotoID.ToString());
                return realPath;

            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        public static string GetBiggestPhotoPath(object _PhotoID, object _photoExtension, object ownerName, object ModuleTypeID, object CategoryID, object ItemID)
        {
            if (((string)_photoExtension).Length > 0)
            {
                PhotoTypes photo = PhotoTypes.Original;
            
                string photoName = Photos.GetPhotoName((string)_photoExtension, photo, FileIdentifre, (int)_PhotoID);

                string path = DCSiteUrls.GetPath_ItemsFiles((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)ItemID) + photoName;
                string realPath = string.Format(path, _PhotoID.ToString());
                return realPath;

            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        #endregion

        public string PhotoOiginalPath { get { return GetPhotoPath(PhotoTypes.Original); } }
        public string PhotoBigPath { get { return GetPhotoPath(PhotoTypes.Big); } }

        #region---------------IFileable--------------
        public string GetOldlFileName(string fileExtension)
        {
            return FileIdentifre + _FileID + fileExtension;
        }

        /*
        public string GetFileName()
        {
            return Files.GetFileName(_FileExtension, File, FileIdentifre, _FileID);
        }
        */

        public string GetFilePath()
        {
            if (_FileExtension.Length > 0)
            {
                string FileName = File;
                string path = DCSiteUrls.GetPath_ItemsFiles (OwnerName, ModuleTypeID, CategoryID, ItemID) + FileName;
                string realPath = string.Format(path, ItemID.ToString());
                return realPath;
            }
            else
            {
                return "";
            }
        }

        public string GetFileName(object fileExtension, object fileID)
        {
            return FileIdentifre + fileID + fileExtension;
        }

        public static string GetFilePath(object _FileID, object _FileExtension, object ownerName, object ModuleTypeID, object CategoryID, object ItemID)
        {
            if (((string)_FileExtension).Length > 0)
            {
                string FileName = FileIdentifre + _FileID.ToString() + _FileExtension.ToString();

                string path = DCSiteUrls.GetPath_ItemsFiles((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)ItemID) + FileName;
                string realPath = string.Format(path, _FileID.ToString());
                return realPath;
            }
            else
            {
                //return Files.GetNoFilePath(File);
                return "";
            }
        }
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

        #region --------------ModuleTypeID--------------
        private int _ModuleTypeID;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
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

        #region --------------OwnerID--------------
        private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
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

        #region --------------CategoryID--------------
        private int _CategoryID;
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        //------------------------------------------
        #endregion
    }
}