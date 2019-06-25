using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for DCAttributes
    /// </summary>
    public class DCAttributes : System.Attribute
    {
        #region --------------PropType--------------

        private SqlDbType _PropType;
        public SqlDbType PropType
        {
            get { return _PropType; }
            set { _PropType = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------PropLength--------------
        private int _PropLength;
        public int PropLength
        {
            get { return _PropLength; }
            set { _PropLength = value; }
        }
        //------------------------------------------
        #endregion
        //---------------------------
        public DCAttributes()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DCAttributes(SqlDbType sqlType, int sqlLength)
        {
            _PropType = sqlType;
            _PropLength = sqlLength;
        }

    }
    public class DCNonInsertable : System.Attribute
    {


        //#region --------------AddInInsert--------------
        //private bool _AddInInsert=true;
        //public bool AddInInsert
        //{
        //    get { return _AddInInsert; }
        //    set { _AddInInsert = value; }
        //}
        ////------------------------------------------
        //#endregion
        //---------------------------
        public DCNonInsertable()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}

