<%@ Page language="c#" %>
<script runat="server">
    private void Page_Load(object sender, System.EventArgs e)
    {
        try
        {
            // get the file name -- fall800.jpg
            string file = Request.QueryString["file"];

            // create an image object, using the filename we just retrieved
            System.Drawing.Image image = System.Drawing.Image.FromFile(DCServer.MapPath(file));

            //-----------------------------------------------------------------------
            int thumbWidth = Convert.ToInt32(Request.QueryString["W"]);
            int thumbHeight = Convert.ToInt32(Request.QueryString["H"]);
            if (SiteSettings.Photos_SavePhotoDimensions)
            {
                GetMaintainedRatio(image, ref  thumbWidth, ref  thumbHeight, false);
            }
            //-----------------------------------------------------------------------
            // create the actual thumbnail image
            System.Drawing.Image thumbnailImage = image.GetThumbnailImage(thumbWidth, thumbHeight, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);

            // make a memory stream to work with the image bytes
            System.IO.MemoryStream imageStream = new System.IO.MemoryStream();

            // put the image into the memory stream
            thumbnailImage.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            // make byte array the same size as the image
            byte[] imageContent = new Byte[imageStream.Length];

            // rewind the memory stream
            imageStream.Position = 0;

            // load the byte array with the image
            imageStream.Read(imageContent, 0, (int)imageStream.Length);

            // return byte array to caller with image type
            Response.ContentType = "image/jpeg";
            Response.BinaryWrite(imageContent);
            image.Dispose();
        }
        catch { }
    }

    /// <summary>
    /// Required, but not used
    /// </summary>
    /// <returns>true</returns>
    public bool ThumbnailCallback()
    {
        return true;
    }

    #region Web Form Designer generated code
    override protected void OnInit(EventArgs e)
    {
        //
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        //
        InitializeComponent();
        base.OnInit(e);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.Load += new System.EventHandler(this.Page_Load);
    }
    #endregion

    //----------------------------------------------------------------------------
    public static void GetMaintainedRatio(System.Drawing.Image image, ref int thumbWidth, ref int thumbHeight, bool upScale)
    {
        // See if we want to maintain the image ratio
        if (SiteSettings.Photos_SavePhotoDimensions)
        {
            //Check to make sure we have a height and width on the attachemnet (if not check the data)
            if (image.Height == 0 || image.Width == 0)
                return;

            double heightRatio = (double)image.Height / image.Width;
            double widthRatio = (double)image.Width / image.Height;

            int desiredHeight = thumbHeight;
            int desiredWidth = thumbWidth;


            thumbHeight = desiredHeight;
            if (widthRatio > 0)
                thumbWidth = Convert.ToInt32(thumbHeight * widthRatio);

            if (thumbWidth > desiredWidth)
            {
                thumbWidth = desiredWidth;
                thumbHeight = Convert.ToInt32(thumbWidth * heightRatio);
            }
        }

        // In some instances, we might not want to scale it larger
        if ((upScale == false) && (thumbHeight > image.Height || thumbWidth > image.Width))
        {
            // TODO: Not perfect
            thumbHeight = image.Height;
            thumbWidth = image.Width;
            //thumb.OriginalSize = true;
            return;
        }
    }
        //----------------------------------------------------------------------------

</script>