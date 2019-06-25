using System;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace DCCMSNameSpace
{
    public class Thumbs
    {
        //----------------------------------------------------------------------------
        public static void GetMaintainedRatio(PhotosEntity PhotosObj, Thumb thumb)
        {
            // See if we want to maintain the image ratio
            if (thumb.MaintainRatio == true)
            {
                //Check to make sure we have a height and width on the attachemnet (if not check the data)
                if (PhotosObj.Height == 0 || PhotosObj.Width == 0)
                    return;

                double heightRatio = (double)PhotosObj.Height / PhotosObj.Width;
                double widthRatio = (double)PhotosObj.Width / PhotosObj.Height;

                int desiredHeight = thumb.Height;
                int desiredWidth = thumb.Width;


                thumb.Height = desiredHeight;
                if (widthRatio > 0)
                    thumb.Width = Convert.ToInt32(thumb.Height * widthRatio);

                if (thumb.Width > desiredWidth)
                {
                    thumb.Width = desiredWidth;
                    thumb.Height = Convert.ToInt32(thumb.Width * heightRatio);
                }
            }

            // In some instances, we might not want to scale it larger
            if ((thumb.UpScale == false) && (thumb.Height > PhotosObj.Height || thumb.Width > PhotosObj.Width))
            {
                // TODO: Not perfect
                thumb.Height = PhotosObj.Height;
                thumb.Width = PhotosObj.Width;
                thumb.OriginalSize = true;
                return;
            }
        }
        //----------------------------------------------------------------------------

        //
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
            ImageCodecInfo codec = GetEncoderInfo("image/jpeg");
            // set image quality
            EncoderParameters eps = new EncoderParameters(1);
            eps = new EncoderParameters();
            eps.Param[0] = new EncoderParameter(Encoder.Quality, (long)thumb.Quality);
            //
            bitmap.Save(path + "\\" + PhotosObj.PhotoID + "thumb.jpg", codec, eps);
            //
            bitmap.Dispose();
            graph.Dispose();
            eps.Dispose();

        }
        public static void CreateSmallThumb(PhotosEntity PhotosObj, Thumb thumb, string path, Bitmap image)
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
            ImageCodecInfo codec = GetEncoderInfo("image/jpeg");
            // set image quality
            EncoderParameters eps = new EncoderParameters(1);
            eps = new EncoderParameters();
            eps.Param[0] = new EncoderParameter(Encoder.Quality, (long)thumb.Quality);
            //
            bitmap.Save(path + "\\" + PhotosObj.PhotoID + "thumb2.jpg", codec, eps);
            //
            bitmap.Dispose();
            graph.Dispose();
            eps.Dispose();

        }
        public static void CreateCategoriesThumb(PhotosEntity PhotosObj, Thumb thumb, string path, Bitmap image)
        {
            //Thumbs.GetMaintainedRatio(PhotosObj, thumb);


            Graphics graph;
            Bitmap bitmap = new Bitmap(thumb.Width, thumb.Height);
            graph = Graphics.FromImage(bitmap);
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // pre paint white to the background of transparent images
            graph.Clear(Color.White);
            // Set the brightness
            graph.DrawImage(image, 0, 0, thumb.Width, thumb.Height);
            // specify codec
            ImageCodecInfo codec = GetEncoderInfo("image/jpeg");
            // set image quality
            EncoderParameters eps = new EncoderParameters(1);
            eps = new EncoderParameters();
            eps.Param[0] = new EncoderParameter(Encoder.Quality, (long)thumb.Quality);
            //
            bitmap.Save(path + "\\" + PhotosObj.PhotoID + "thumb2.jpg", codec, eps);
            //
            bitmap.Dispose();
            graph.Dispose();
            eps.Dispose();

        }

        //----------------------------------------
        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] myEncoders =
                ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo myEncoder in myEncoders)
                if (myEncoder.MimeType == mimeType)
                    return myEncoder;
            return null;
        }



    }
}
