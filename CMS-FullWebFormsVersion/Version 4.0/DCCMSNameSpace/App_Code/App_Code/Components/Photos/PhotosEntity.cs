

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;



namespace DCCMSNameSpace
{
    public class PhotosEntity
    {
        public PhotosEntity(int id)
        {
            PhotoID = id;
        }

        private int _PhotoID;
        public int PhotoID
        {
            get { return _PhotoID; }
            set { _PhotoID = value; }
        }

        private int _Height;
        public int Height
        {
            get { return _Height; }
            set { _Height = value; }
        }
        private int _Width;
        public int Width
        {
            get { return _Width; }
            set { _Width = value; }
        }

    }
}
