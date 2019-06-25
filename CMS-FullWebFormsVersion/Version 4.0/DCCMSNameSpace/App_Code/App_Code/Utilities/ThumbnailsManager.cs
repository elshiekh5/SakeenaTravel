using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web;

namespace DCCMSNameSpace
{
    public class ThumbnailsManager
    {
        long Quality = 100;
        static bool MaintainRatio = true;
        static bool upScale = false;
        public static string thumbnailDirectoryPattern  = "/Content/Thumbnails/{0}x{1}/";
        public static string thumbnailPathPattern       = "/Content/Thumbnails/{0}x{1}/{2}.jpg";
        public static string GetThumb(string originalPath,int width,int height,long quality)
        {
            string fileName =  VirtualPathUtility.GetFileName(originalPath);
            fileName = Path.GetFileNameWithoutExtension(fileName);

            

            string thubPath = string.Format(thumbnailPathPattern,width,height,fileName);
            string physicalThumbPath = DCServer.MapPath(thubPath);

            

            if (!File.Exists(physicalThumbPath))
            {
                string physicalOriginalPath = DCServer.MapPath(originalPath);
                if (File.Exists(physicalOriginalPath))
                {
                    //----------------------------------
                    //check does directory exists 
                    //----------------------------------
                    string thumbDirectoryPath = string.Format(thumbnailDirectoryPattern, width, height);
                    string physicalthumbDirectoryPath = DCServer.MapPath(thumbDirectoryPath);

                    if (!Directory.Exists(physicalthumbDirectoryPath))
                        Directory.CreateDirectory(physicalthumbDirectoryPath);
                    //----------------------------------

                    CreateThumb(physicalOriginalPath, physicalThumbPath, width, height, quality);
                }
            }
            return thubPath;
        }

        //----------------------------------------------------------------------------
        public static void CreateThumb(string originalPath, string targetPath, int wantedWidth, int wantedHeight, long quality)
        {
            int width = wantedWidth;
            int height = wantedHeight;
            bool smallerOriginalSize = false;
            Bitmap originalImage = (Bitmap)Bitmap.FromFile(originalPath);
            GetMaintainedRatio(originalImage, ref width, ref height, ref smallerOriginalSize);
            Graphics graph;
            int x = 0; int y = 0;
            //--------------------------------------------------------------------
            //Justify vertical
            //--------------------------------------------------------------------
            if (false)
            {
                if (height < wantedHeight)
                {
                    y = (wantedHeight - height) / 2;
                    if (y < 0) y = y * -1;
                    height += y;
                }
            }
            //--------------------------------------------------------------------


            Bitmap bitmap = new Bitmap(width, height);
            graph = Graphics.FromImage(bitmap);
            graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // pre paint white to the background of transparent images
            graph.Clear(Color.White);
            // Set the brightness
            graph.DrawImage(originalImage, 0, y, width, height);
            // specify codec
            ImageCodecInfo codec = GetEncoderInfo("image/jpeg");
            // set image quality
            EncoderParameters eps = new EncoderParameters(1);
            eps = new EncoderParameters();
            eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
            //if (width > wantedWidth || height > wantedHeight)
            //System.IO.MemoryStream imageStream = new System.IO.MemoryStream();
            if (true)
            {
                x = 0;
                y = 0;
                if (width > wantedWidth)
                {
                    x = (width - wantedWidth) / 2;
                }
                if (height > wantedHeight)
                {
                    y = (height - wantedHeight) / 2;
                }

                Rectangle cropRect = new Rectangle(0, 0, wantedWidth, wantedHeight);
                Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);
                using (Graphics g = Graphics.FromImage(target))
                {
                    g.Clear(Color.White);
                    g.DrawImage(bitmap, new Rectangle(0, 0, target.Width, target.Height),
                                    cropRect,
                                    GraphicsUnit.Pixel);
                    //
                    target.Save(targetPath, codec, eps);
                    //
                    target.Dispose();
                    g.Dispose();
                }

            }
            else
            {
                bitmap.Save(targetPath, codec, eps);
            }
            //
            bitmap.Dispose();
            graph.Dispose();
            eps.Dispose();
            originalImage.Dispose();
            //-----------------------------------------------------
            // make byte array the same size as the image
            /*byte[] imageContent = new Byte[imageStream.Length];

            // rewind the memory stream
            imageStream.Position = 0;

            // load the byte array with the image
            imageStream.Read(imageContent, 0, (int)imageStream.Length);

            File.WriteAllBytes(targetPath, imageContent);*/

        }
        //-------------------------------------------------------------------------------//

        //----------------------------------------------------------------------------
        public static void GetMaintainedRatio(Bitmap image, ref int width, ref int height, ref bool smallerOriginalSize)
        {
            // See if we want to maintain the image ratio
            if (MaintainRatio == true)
            {
                //Check to make sure we have a height and width on the attachemnet (if not check the data)
                if (image.Height == 0 || image.Width == 0)
                    return;

                double heightRatio = (double)image.Height / image.Width;
                double widthRatio = (double)image.Width / image.Height;

                int desiredHeight = height;
                int desiredWidth = width;


                height = desiredHeight;
                if (widthRatio > 0)
                    width = Convert.ToInt32(height * widthRatio);

                if (width != desiredWidth)
                {
                    width = desiredWidth;
                    height = Convert.ToInt32(width * heightRatio);
                }
            }

            // In some instances, we might not want to scale it larger
            if ((upScale == false) && (height > image.Height || width > image.Width))
            {
                // TODO: Not perfect
                height = image.Height;
                width = image.Width;
                smallerOriginalSize = true;
                return;
            }
        }
        //----------------------------------------------------------------------------
        public static ImageCodecInfo  GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] myEncoders =
                ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo myEncoder in myEncoders)
                if (myEncoder.MimeType == mimeType)
                    return myEncoder;
            return null;
        }
        //----------------------------------------------------------------------------


    }
}
