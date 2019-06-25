using System;


namespace DCCMSNameSpace
{
    /// <summary>
    /// The class entity of SMSGroups.
    /// </summary>
    public class SMSGroupsEntity
    {

        private int _GroupID;
        /// <summary>
        /// Gets or sets SMSGroups GroupID. 
        /// </summary>
        public int GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        //------------------------------------------
        private string _Name = "";
        /// <summary>
        /// Gets or sets SMSGroups Name. 
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        //------------------------------------------

    }
}