using System;

namespace DCCMSNameSpace
{
    public class Thumb
    {
        public Thumb()
        {
        }
        public Thumb(int width, int height)
        {
            Width = width;
            Height = height;
        }
        private int width = 190;
        /// <summary>
        /// Get or set  Width
        /// </summary>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        //-----------------------

        private int height = 150;
        /// <summary>
        /// Get or set  Height 
        /// </summary>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        //-----------------------
        private bool upScale = false;
        /// <summary>
        /// Get or set  Width
        /// </summary>
        public bool UpScale
        {
            get { return upScale; }
            set { upScale = value; }
        }
        //-----------------------
        private bool originalSize = false;
        public bool OriginalSize
        {
            get { return originalSize; }
            set { originalSize = value; }
        }
        //-----------------------
        bool maintainRatio = false;
        public bool MaintainRatio
        {
            get { return maintainRatio; }
            set { maintainRatio = value; }
        }
        int quality = 80;
        public int Quality
        {
            get { return quality; }
            set { quality = value; }
        }
    }
}