using System;
using System.Collections;
using System.Net.Mail;


namespace DCCMSNameSpace
{
    public class MailListEmailsEntity : MailMessage
    {
        #region --------------MailID--------------
        private int _MailID;
        public int MailID
        {
            get { return _MailID; }
            set { _MailID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ToCollectionSting--------------
        public string ToCollectionSting
        {
            get { return MailListEmailsFactory.GetCollectionStringFromMailAddressCollection(To); }
            set { MailListEmailsFactory.GetMailAddressCollectionFromCollectionString(value, To); }
        }
        //------------------------------------------
        #endregion

        #region --------------CCCollectionSting--------------
        public string CCCollectionSting
        {
            get { return MailListEmailsFactory.GetCollectionStringFromMailAddressCollection(CC); }
            set { MailListEmailsFactory.GetMailAddressCollectionFromCollectionString(value, CC); }
        }
        //------------------------------------------
        #endregion

        #region --------------BccCollectionSting--------------
        public string BccCollectionSting
        {
            get { return MailListEmailsFactory.GetCollectionStringFromMailAddressCollection(Bcc); }
            set { MailListEmailsFactory.GetMailAddressCollectionFromCollectionString(value, Bcc); }
        }
        #endregion
        /*
	#region --------------FromAddress--------------
    private string _FromAddress = "";
    public string FromAddress
	{
        get { return _FromAddress; }
        set { _FromAddress = value; }
	}
	//------------------------------------------
	#endregion

    #region --------------FromName--------------
    private string _FromName = "";
    public string FromName
    {
        get { return _FromName; }
        set { _FromName = value; }
    }
    //------------------------------------------
    #endregion
    
    #region --------------From--------------
    public new MailAddress From
	{
		get {   return  new MailAddress(_FromAddress,FromName) ; }
	}
    //------------------------------------------
    #endregion
    */
        #region --------------Trials--------------
        private int _Trials;
        public int Trials
        {
            get { return _Trials; }
            set { _Trials = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------IsBeingSent--------------
        private bool _IsBeingSent;
        public bool IsBeingSent
        {
            get { return _IsBeingSent; }
            set { _IsBeingSent = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AttachmentsFilesPathes--------------
        private ArrayList _AttachmentsFilesPathes = new ArrayList();
        public ArrayList AttachmentsFilesPathes
        {
            get { return _AttachmentsFilesPathes; }
            set { _AttachmentsFilesPathes = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------AttachmentsString--------------
        public string AttachmentsString
        {
            get
            {
                string attachmentsString = "";
                foreach (object item in AttachmentsFilesPathes)
                {
                    if (attachmentsString.Length > 0)
                        attachmentsString += ",";

                    attachmentsString += (string)item;
                }

                return attachmentsString;
            }
            set
            {
                if (!string.IsNullOrEmpty(value) && value.Contains(","))
                {
                    string attachmentsString = value;
                    string[] attachmentsFiles = attachmentsString.Split(new Char[] { ',' });
                    //clear previous list
                    AttachmentsFilesPathes.Clear();
                    //add new items
                    for (int i = 0; i < attachmentsFiles.Length; i++)
                    {
                        AttachmentsFilesPathes.Add(attachmentsFiles[i]);
                        Attachments.Add(new Attachment(attachmentsFiles[i]));

                    }
                }
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Date_Added--------------
        private DateTime _Date_Added = DateTime.MinValue;
        public DateTime Date_Added
        {
            get { return _Date_Added; }
            set { _Date_Added = value; }
        }
        //------------------------------------------
        #endregion

        

    }

}