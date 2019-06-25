using System;

namespace DCCMSNameSpace
{
    /// <summary>
    /// The class entity of Country.
    /// </summary>
    [Serializable()]
    public class CountryEntity
    {

        private int _ID;
        /// <summary>
        /// Gets or sets Country ID. 
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        //------------------------------------------
        private string _Name = "";
        /// <summary>
        /// Gets or sets Country Name. 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        //------------------------------------------
        private string _EnName = "";
        /// <summary>
        /// Gets or sets Country EnName. 
        /// </summary>
        public string EnName
        {
            get { return _EnName; }
            set { _EnName = value; }
        }
        //------------------------------------------
        private string _Short = "";
        /// <summary>
        /// Gets or sets Country Short. 
        /// </summary>
        public string Short
        {
            get { return _Short; }
            set { _Short = value; }
        }
        //------------------------------------------
        private int _ContID;
        /// <summary>
        /// Gets or sets Country ID. 
        /// </summary>
        public int ContID
        {
            get { return _ContID; }
            set { _ContID = value; }
        }
    }
}
