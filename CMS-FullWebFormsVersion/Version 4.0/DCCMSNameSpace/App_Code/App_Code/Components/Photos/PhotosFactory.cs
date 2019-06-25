

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

using System.Web;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for WebForumsDataProvider
    /// </summary>
    public class PhotosFactory
    {
        //-----------------------------------------
        public static bool SavePhoto(string path, PhotosEntity PhotosObj, HttpPostedFile postedFile)
        {
            bool result = false;
            try
            {
                if (!CheckIsImage(postedFile))
                    return false;
                //To Get The Photo Data----------------------------------
                Bitmap image = (Bitmap)Bitmap.FromStream(postedFile.InputStream, true);
                string extension = Path.GetExtension(postedFile.FileName);
                postedFile.InputStream.Position = 0;
                PhotosObj.Height = image.Height;
                PhotosObj.Width = image.Width;
                //
                Thumb thumb = new Thumb();
                //
                string phisycalPath = DCServer.MapPath(path);
                postedFile.SaveAs(phisycalPath + PhotosObj.PhotoID + extension);
                Thumbs.CreateThumb(PhotosObj, new Thumb(190, 125), phisycalPath, image);
                image.Dispose();
                postedFile.InputStream.Close();
                result = true;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        //-----------------------------------------
        public static bool CheckIsImage(HttpPostedFile postedFile)
        {
            if (postedFile.ContentLength > 0)
                return (postedFile.ContentType.IndexOf("image") > -1);
            else
                return false;


        }

    }
}