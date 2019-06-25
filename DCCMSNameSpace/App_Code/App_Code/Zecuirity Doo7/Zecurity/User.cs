using System;
using System.Collections.Generic;
using System.Web;


namespace DCCMSNameSpace
{
    namespace Zecurity
    {
        /// <summary>
        /// Summary description for User
        /// </summary>
        public class User
        {
            private Guid _ID;
            public Guid ID
            {
                get { return _ID; }
                set { _ID = value; }
            }
        }
    }
}