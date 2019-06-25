using System;


namespace DCCMSNameSpace
{
    /// <summary>
    /// The class entity of SMSArchive.
    /// </summary>
    public class SMSArchiveEntity
    {

        private int _ID;
        /// <summary>
        /// Gets or sets SMSArchive ID. 
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //------------------------------------------
        private string _Sender = "";
        /// <summary>
        /// Gets or sets SMSArchive Sender. 
        /// </summary>
        public string Sender
        {
            get { return _Sender; }
            set { _Sender = value; }
        }
        //------------------------------------------
        private string _RecieverMobile = "";
        /// <summary>
        /// Gets or sets SMSArchive RecieverMobile. 
        /// </summary>
        public string RecieverMobile
        {
            get { return _RecieverMobile; }
            set { _RecieverMobile = value; }
        }
        //------------------------------------------
        private string _Message = "";
        /// <summary>
        /// Gets or sets SMSArchive Message. 
        /// </summary>
        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }
        //------------------------------------------
        private Languages _LangID;
        /// <summary>
        /// Gets or sets SMSArchive LangID. 
        /// </summary>
        public Languages LangID
        {
            get { return _LangID; }
            set { _LangID = value; }
        }
        //------------------------------------------

    }
}