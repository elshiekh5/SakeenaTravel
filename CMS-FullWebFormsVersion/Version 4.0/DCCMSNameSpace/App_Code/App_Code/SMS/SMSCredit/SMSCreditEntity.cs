using System;


namespace DCCMSNameSpace
{
    /// <summary>
    /// The class entity of SMSCredit.
    /// </summary>
    public class SMSCreditEntity
    {

        private int _ID;
        /// <summary>
        /// Gets or sets SMSCredit ID. 
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //------------------------------------------
        private int _Credit;
        /// <summary>
        /// Gets or sets SMSCredit Credit. 
        /// </summary>
        public int Credit
        {
            get { return _Credit; }
            set { _Credit = value; }
        }
        //------------------------------------------

    }
}