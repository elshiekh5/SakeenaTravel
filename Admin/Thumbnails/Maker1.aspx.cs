using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Thumbnails_Maker_1 : System.Web.UI.Page
{
    //-------------------------------------------------------------------------------//
    int BaseThmbnailWidth = 128;
    int BaseThmbnailHeight = 128;
    long Quality = 100;
    bool MaintainRatio = true;
    bool upScale = false;
    //-------------------------------------------------------------------------------//

    protected void Page_Load(object sender, EventArgs e)
    {
         BaseThmbnailWidth = Convert.ToInt32(Request.QueryString["W"]);
         BaseThmbnailHeight = Convert.ToInt32(Request.QueryString["H"]);
        string originalPath = Request.QueryString["file"];
        CreateThumb(DCServer.MapPath(originalPath));
    }

    //----------------------------------------------------------------------------
    public  void CreateThumb(string originalPath)
    {
        int width = BaseThmbnailWidth;
        int height = BaseThmbnailHeight;
        bool smallerOriginalSize = false;
        Bitmap originalImage = (Bitmap)Bitmap.FromFile(originalPath);
        GetMaintainedRatio(originalImage, ref width, ref height, ref smallerOriginalSize);


        Graphics graph;

        //////////////////////////////////////////////////////////////////////

        int x = 0; int y = 0;
        //--------------------------------------------------------------------
        //Justify vertical
        //--------------------------------------------------------------------
        if (false)
        {
            if (height < BaseThmbnailHeight)
            {
                y = (BaseThmbnailHeight - height) / 2;
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
        eps.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Quality);
        //if (width > BaseThmbnailWidth || height > BaseThmbnailHeight)
        System.IO.MemoryStream imageStream = new System.IO.MemoryStream();
        if (false)
        {
             x = 0;
             y = 0;
            if (width > BaseThmbnailWidth)
            {
                x = (width - BaseThmbnailWidth) / 2;
            }
            if (height > BaseThmbnailHeight)
            {
                y = (height - BaseThmbnailHeight) / 2;
            }
            
            Rectangle cropRect = new Rectangle(x, y, BaseThmbnailWidth, BaseThmbnailHeight);
            Bitmap target = new Bitmap(cropRect.Width, cropRect.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.Clear(Color.White);
                g.DrawImage(bitmap, new Rectangle(0, 0, target.Width, target.Height),
                                cropRect,
                                GraphicsUnit.Pixel);
                //
                target.Save(imageStream, codec, eps);
                //
                target.Dispose();
                g.Dispose();
            }

        }
        else
        {
            bitmap.Save(imageStream, codec, eps);
        }
        //
        bitmap.Dispose();
        graph.Dispose();
        eps.Dispose();

        originalImage.Dispose();
        //-----------------------------------------------------
        // make byte array the same size as the image
        byte[] imageContent = new Byte[imageStream.Length];

        // rewind the memory stream
        imageStream.Position = 0;

        // load the byte array with the image
        imageStream.Read(imageContent, 0, (int)imageStream.Length);

        // return byte array to caller with image type
        Response.ContentType = "image/jpeg";
        Response.BinaryWrite(imageContent);
        
        //image.Dispose();
        //-----------------------------------------------------
    }
    //-------------------------------------------------------------------------------//

    //----------------------------------------------------------------------------
    public void GetMaintainedRatio(Bitmap image, ref int width, ref int height, ref bool smallerOriginalSize)
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
    public ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        ImageCodecInfo[] myEncoders =
            ImageCodecInfo.GetImageEncoders();

        foreach (ImageCodecInfo myEncoder in myEncoders)
            if (myEncoder.MimeType == mimeType)
                return myEncoder;
        return null;
    }
    //----------------------------------------------------------------------------
    //-----------------------------------------

    //----------------------------------------------------------------------------
}