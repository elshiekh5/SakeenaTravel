using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for GalleryThumbs
    /// </summary>
    public class GalleryThumbs
    {
        public GalleryThumbs()
        {
            //
            // TODO: Add constructor logic here
            //
        }
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

        public static Dimensions GetDimensions(string imageFilePhysicalPath)
        {
            try
            {
                Bitmap image = (Bitmap)Bitmap.FromFile(imageFilePhysicalPath, true);
                Dimensions dim = new Dimensions();
                dim.Height = image.Height.ToString();
                dim.Width = image.Width.ToString();
                FileInfo info = new FileInfo(imageFilePhysicalPath);
                dim.Size = info.Length.ToString();
                image.Dispose();
                return dim;
            }
            catch
            {
                return new Dimensions();
            }
        }
        public static void SavePhoto(string phisicalpath, string srcPath, int id, HttpPostedFile postedFile, int width, int height)
        {
            //if (!CheckIsImage(postedFile))
            //	return;
            Bitmap image = (Bitmap)Bitmap.FromFile(srcPath, true);
            string extension = Path.GetExtension(srcPath);
            PhotosEntity PhotosObj = new PhotosEntity(id);
            PhotosObj.Height = image.Height;
            PhotosObj.Width = image.Width;
            Thumb thumb = new Thumb();
            CreateThumb(PhotosObj, new Thumb(width, height), phisicalpath, image);
            image.Dispose();
        }
        public static void CreateThumb(PhotosEntity PhotosObj, Thumb thumb, string path, Bitmap image)
        {
            Thumbs.GetMaintainedRatio(PhotosObj, thumb);


            Graphics graph;
            Bitmap bitmap = new Bitmap(thumb.Width, thumb.Height);
            graph = Graphics.FromImage(bitmap);
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // pre paint white to the background of transparent images
            graph.Clear(Color.White);
            // Set the brightness
            graph.DrawImage(image, 0, 0, thumb.Width, thumb.Height);
            // specify codec
            ImageCodecInfo codec = Thumbs.GetEncoderInfo("image/jpeg");
            // set image quality
            EncoderParameters eps = new EncoderParameters(1);
            eps = new EncoderParameters();
            eps.Param[0] = new EncoderParameter(Encoder.Quality, (long)thumb.Quality);
            //
            bitmap.Save(path + "\\" + PhotosObj.PhotoID + ".jpg", codec, eps);
            //
            bitmap.Dispose();
            graph.Dispose();
            eps.Dispose();

        }
    }
}
