using System;
using System.Collections.Generic;
using System.Web;


namespace DCCMSNameSpace
{
    namespace Zecurity
    {
        /// <summary>
        /// Summary description for Permission
        /// </summary>
        [Serializable()]
        public class Permission
        {
            private Guid _ID = Guid.NewGuid();
            public Guid ID
            {
                get { return _ID; }
                set { _ID = value; }
            }

            private string _Path;
            public string Path
            {
                get { return _Path; }
                set { _Path = value; }
            }
            private string _Name;
            public string Name
            {
                get { return _Name; }
                set { _Name = value; }
            }

            private bool _Add;
            public bool Add
            {
                get { return _Add; }
                set { _Add = value; }
            }

            private bool _Edit;
            public bool Edit
            {
                get { return _Edit; }
                set { _Edit = value; }
            }

            private bool _Delete;
            public bool Delete
            {
                get { return _Delete; }
                set { _Delete = value; }
            }

            private bool _Trusted;
            public bool Trusted
            {
                get { return _Trusted; }
                set { _Trusted = value; }
            }
        }
    }
}