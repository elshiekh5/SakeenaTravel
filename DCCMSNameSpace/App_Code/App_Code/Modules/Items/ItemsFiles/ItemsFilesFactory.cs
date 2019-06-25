using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using System.IO;
using DCCMSNameSpace;


namespace DCCMSNameSpace
{
    public class ItemsFilesFactory
    {

        #region --------------Create--------------
        /// <summary>
        /// Creates ItemsFiles object by calling ItemsFiles data provider create method.
        /// <example>[Example]bool status=ItemsFilesFactory.Create(ItemsFiles);.</example>
        /// </summary>
        /// <param name="ItemsFiles">The ItemsFiles object.</param>
        /// <returns>Status of create operation.</returns>
        public static bool Create(ItemsFilesEntity itemFile)
        {
            //Insert user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                itemFile.InsertUserName = username;
            }
            //----------------------------------------------------------
            return ItemsFilesSqlDataPrvider.Instance.Create(itemFile);
        }
        //------------------------------------------
        #endregion

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single ItemsFiles object .
        /// <example>[Example]bool status=ItemsFilesFactory.Delete(photoID);.</example>
        /// </summary>
        /// <param name="photoID">The ItemsFiles id.</param>
        /// <returns>Status of delete operation.</returns>
        public static bool Delete(int fileID)
        {
            ItemsFilesEntity itemFile = GetObject(fileID);
            bool status = ItemsFilesSqlDataPrvider.Instance.Delete(fileID);
            if (status)
            {
                DeleteFiles( itemFile);
            }
            return status;
        }
        //------------------------------------------
        #endregion

        public static void DeleteFiles(ItemsFilesEntity itemFile)
        {
            HttpContext context = HttpContext.Current;
            //ItemsEntity item = ItemsFactory.GetObject(itemFile.ItemID,
            //-----------------------------
            if (!string.IsNullOrEmpty(itemFile.FileExtension))
            {
                if (itemFile.FileType == ItemFileTypes.Photo)

                    //Delete old Thumbnails
                    File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles(itemFile.OwnerName, itemFile.ModuleTypeID, itemFile.CategoryID, itemFile.ItemID)) + itemFile.GetPhotoName(PhotoTypes.Thumb));
                File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles(itemFile.OwnerName, itemFile.ModuleTypeID, itemFile.CategoryID, itemFile.ItemID)) + itemFile.GetPhotoName(PhotoTypes.Big));
                //------------------------------------------------
            }
            //Delete old original photo
            File.Delete(DCServer.MapPath(DCSiteUrls.GetPath_ItemsFiles(itemFile.OwnerName, itemFile.ModuleTypeID, itemFile.CategoryID, itemFile.ItemID)) + itemFile.File);

        }

        #region --------------GetAll--------------
        public static List<ItemsFilesEntity> GetAll(int itemID, ItemFileTypes fileType)
        {
            return GetAll(itemID, fileType, -1);
        }
        public static List<ItemsFilesEntity> GetAll(int itemID, ItemFileTypes fileType, int CategoryID)
        {
            int totalRecords = 0;
            return ItemsFilesSqlDataPrvider.Instance.GetAll(itemID, (int)StandardItemsModuleTypes.UnKnowen, fileType, -1, -1, out totalRecords, CategoryID);
        }
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        public static List<ItemsFilesEntity> GetAll(int itemID, int moduleTypeID, ItemFileTypes fileType)
        {
            return GetAll(itemID, moduleTypeID, fileType, -1);
        }
        public static List<ItemsFilesEntity> GetAll(int itemID, int moduleTypeID, ItemFileTypes fileType, int CategoryID)
        {
            int totalRecords = 0;
            return ItemsFilesSqlDataPrvider.Instance.GetAll(itemID, moduleTypeID, fileType, -1, -1, out totalRecords, CategoryID);
        }
        //XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
        public static List<ItemsFilesEntity> GetAll(int itemID, ItemFileTypes fileType, int pageIndex, int pageSize, out int totalRecords)
        {
            return GetAll(itemID, (int)StandardItemsModuleTypes.UnKnowen, fileType, pageIndex, pageSize, out totalRecords, -1);
        }
        public static List<ItemsFilesEntity> GetAll(int itemID, ItemFileTypes fileType, int pageIndex, int pageSize, out int totalRecords, int CategoryID)
        {
            return GetAll(itemID, (int)StandardItemsModuleTypes.UnKnowen, fileType, pageIndex, pageSize, out totalRecords, CategoryID);
        }
        //------------------------------------
        public static List<ItemsFilesEntity> GetAll(int itemID, int moduleTypeID, ItemFileTypes fileType, int pageIndex, int pageSize, out int totalRecords)
        {
            return GetAll(itemID, moduleTypeID, fileType, pageIndex, pageSize, out totalRecords, -1);
        }
        public static List<ItemsFilesEntity> GetAll(int itemID, int moduleTypeID, ItemFileTypes fileType, int pageIndex, int pageSize, out int totalRecords, int CategoryID)
        {
            return ItemsFilesSqlDataPrvider.Instance.GetAll(itemID, moduleTypeID, fileType, pageIndex, pageSize, out totalRecords, CategoryID);
        }
        //------------------------------------------
        #endregion

        public static List<ItemsFilesEntity> GetLast(int itemID, int moduleTypeID, ItemFileTypes fileType, int count)
        {
            return ItemsFilesSqlDataPrvider.Instance.GetLast(itemID, moduleTypeID, fileType, count, -1);
        }
        public static List<ItemsFilesEntity> GetLast(int itemID, int moduleTypeID, ItemFileTypes fileType, int count, int CategoryID)
        {
            return ItemsFilesSqlDataPrvider.Instance.GetLast(itemID, moduleTypeID, fileType, count, CategoryID);
        }
        #region --------------GetObject--------------
        public static ItemsFilesEntity GetObject(int fileID)
        {
            ItemsFilesEntity ItemsFiles;
            HttpContext context = HttpContext.Current;
            string cacheKey = "ItemsFiles" + fileID;

            if (context.Items[cacheKey] == null)
            {
                ItemsFiles = ItemsFilesSqlDataPrvider.Instance.GetObject(fileID);
                context.Items[cacheKey] = ItemsFiles;
            }
            else
            {
                ItemsFiles = (ItemsFilesEntity)context.Items[cacheKey];
            }
            //return the object
            return ItemsFiles;
        }
        //------------------------------------------
        #endregion

        #region --------------Update--------------
        /// <summary>
        /// Creates ItemsFiles object by calling ItemsFiles data provider create method.
        /// <example>[Example]bool status=ItemsFilesFactory.Create(ItemsFiles);.</example>
        /// </summary>
        /// <param name="ItemsFiles">The ItemsFiles object.</param>
        /// <returns>Status of create operation.</returns>
        public static bool Update(ItemsFilesEntity itemFile)
        {
            //Insert user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                itemFile.InsertUserName = username;
            }
            //----------------------------------------------------------
            return ItemsFilesSqlDataPrvider.Instance.Update(itemFile);
        }
        //------------------------------------------
        #endregion

        #region --------------GetItemsPhotoThumbnail--------------
        public static string GetPhotoThumbnail(object photoID, object photoExtension, int width, int height, object ownerName, object ModuleTypeID, object CategoryID, object ItemID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                string photoName = Photos.GetPhotoName((string)photoExtension, PhotoTypes.Big, ItemsFilesEntity.FileIdentifre, (int)photoID);
                string path = DCSiteUrls.GetPath_ItemsFiles ((string)ownerName, (int)ModuleTypeID, (int)CategoryID,(int)ItemID) + photoName;

                //return DCSiteUrls.GetPath_ItemsPhotoNormalThumbs ((string)ownerName) + CreateItemsPhotoName((int)itemID) + MoversFW.Thumbs.thumbnailExetnsion;
                return "/Thumbnails/Maker1.aspx?file=" + path + "&W=" + width + "&H=" + height;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        /*
        #region --------------GetItemsPhotoThumbnail--------------
        public static string GetPhotoThumbnail2(object photoID, object photoExtension, int width, int height, object ownerName, object ModuleTypeID, object CategoryID, object ItemID)
        {
            if (photoExtension.ToString().Length > 0)
            {
                string photoName = Photos.GetPhotoName((string)photoExtension, PhotoTypes.Original, ItemsFilesEntity.FileIdentifre, (int)photoID);
                string path = DCSiteUrls.GetPath_ItemsFiles((string)ownerName, (int)ModuleTypeID, (int)CategoryID, (int)ItemID) + photoName;

                //return DCSiteUrls.GetPath_ItemsPhotoNormalThumbs ((string)ownerName) + CreateItemsPhotoName((int)itemID) + MoversFW.Thumbs.thumbnailExetnsion;
                return "/Thumbnails/Maker1.aspx?file=" + path + "&W=" + width + "&H=" + height;
            }
            else
            {
                return SiteDesign.NoPhotoPath;
            }
        }
        //------------------------------------------
        #endregion
        */
    }
}