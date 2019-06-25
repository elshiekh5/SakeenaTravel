using System;
using System.Collections.Generic;
using System.Web;


namespace DCCMSNameSpace
{
    namespace Zecurity
    {
        /// <summary>
        /// Summary description for Group
        /// </summary>
        public class Group
        {
            private Guid _ID = Guid.NewGuid();
            public Guid ID
            {
                get { return _ID; }
                set { _ID = value; }
            }

            private string _Name;
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }

            private List<User> _Users;
            public List<User> Users
            {
                get { return _Users; }
                set { _Users = value; }
            }

            private List<Permission> _Permissions;
            public List<Permission> Permissions
            {
                get { return _Permissions; }
                set { _Permissions = value; }
            }
        }
    }
}