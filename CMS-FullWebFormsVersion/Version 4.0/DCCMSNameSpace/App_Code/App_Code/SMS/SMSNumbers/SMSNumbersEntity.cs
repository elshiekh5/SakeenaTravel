using System;
using DCCMSNameSpace;

namespace DCCMSNameSpace
{
    /// <summary>
    /// The class entity of SMSNumbers.
    /// </summary>
    public class SMSNumbersEntity
    {

        private long _NumID;
        /// <summary>
        /// Gets or sets SMSNumbers NumID. 
        /// </summary>
        public long NumID
        {
            get { return _NumID; }
            set { _NumID = value; }
        }
        //------------------------------------------
        private string _Numbers = "";
        /// <summary>
        /// Gets or sets SMSNumbers Numbers. 
        /// </summary>
        public string Numbers
        {
            get { return _Numbers; }
            set { _Numbers = value; }
        }

        private string _Name = "";
        /// <summary>
        /// Gets or sets SMSNumbers Numbers. 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        //------------------------------------------
        private int _GroupID;
        /// <summary>
        /// Gets or sets SMSNumbers GroupID. 
        /// </summary>
        public int GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        //------------------------------------------

        #region --------------IsActive--------------
        private bool _IsActive;
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------JoinDate--------------
        private DateTime _JoinDate = DateTime.MinValue;
        public DateTime JoinDate
        {
            get { return _JoinDate; }
            set { _JoinDate = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------ModuleTypeID--------------
        private int _ModuleTypeID = (int)StandardItemsModuleTypes.SMS;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------LangID--------------
        private Languages _LangID;
        public Languages LangID
        {
            get { return _LangID; }
            set { _LangID = value; }
        }
        //------------------------------------------
        #endregion





    }

}