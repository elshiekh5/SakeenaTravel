using System;using DCCMSNameSpace;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for ItemsGetAllBaseControl
    /// </summary>
    public class ItemFiles_GetLastXml : ReadyUserControls.XmlBaseUserControl
    {
        #region --------------ModuleTypeID--------------
        //------------------------------------------
        //ModuleTypeID
        //------------------------------------------
        private int _ModuleTypeID=-1;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------ItemID--------------
        //------------------------------------------
        //ItemID
        //------------------------------------------
        private int _ItemID = -1;
        public int ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------Count--------------
        //------------------------------------------
        //Count
        //------------------------------------------
        private int _Count = 1;
        public int Count
        {
            get { return _Count; }
            set { _Count = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------FileType--------------
        //------------------------------------------
        //FileType
        //------------------------------------------
        private ItemFileTypes _FileType = ItemFileTypes.Photo;
        public ItemFileTypes FileType
        {
            get { return _FileType; }
            set { _FileType = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------TemplateID--------------
        private string _TemplateID = "dlPhotos";
        public string TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }
        //------------------------------------------
        #endregion
        public void Page_Load(object sender, System.EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    PrepareBuffer();
                }
                catch
                {
                }
                LoadData();
            }
        }

        public void LoadData()
        {
            List<ItemsFilesEntity> ItemsFilesList = ItemsFilesFactory.GetLast(ItemID, ModuleTypeID, FileType, Count);
            Repeater r = (Repeater)this.FindControl(TemplateID);
            if (ItemsFilesList != null && ItemsFilesList.Count > 0)
            {
                r.DataSource = ItemsFilesList;
                r.DataBind();
            }
           /* if (photosList != null && photosList.Count > 0)
            {
                foreach (ItemsFilesEntity photo in photosList)
                {
                    string bigpath = ItemsFilesEntity.GetPhotoPath(PhotoTypes.Original, photo.FileID, photo.FileExtension);
                    string smallPath = ItemsFilesEntity.GetPhotoPath(PhotoTypes.Thumb, photo.FileID, photo.FileExtension);

                    ltrPhotos.Text += "<slide jpegURL=\"" + FormatForXML(smallPath.Remove(0, 1)) + "\" d_URL=\"" + FormatForXML(bigpath.Remove(0, 1)) + "\" transition=\"29\" panzoom=\"1\" URLTarget=\"0\" phototime=\"3\" url=\"\" title=\"\" width=\"645\" height=\"169\"/>";
                }
            }*/
        }
        
    }
}