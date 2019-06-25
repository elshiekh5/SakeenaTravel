using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for ProfieProperity
    /// </summary>
    public struct ProfieProperity
    {
        public string PropName;
        public Type PropType;
        public object PropDefaultValue;

        //-------------------------------------------------
        public ProfieProperity(string name)
        {
            PropName = name;
            PropType = typeof(string);
            PropDefaultValue = null;
        }
        public ProfieProperity(string name, Type type)
        {
            PropName = name;
            if (type != null)
            {
                PropType = type;
            }
            else
            {
                PropType = typeof(string);
            }
            PropDefaultValue = null;
        }
        public ProfieProperity(string name, Type type, object defaultValue)
        {
            PropName = name;
            if (type != null)
            {
                PropType = type;
            }
            else
            {
                PropType = typeof(string);
            }
            PropDefaultValue = defaultValue;
        }
        //-------------------------------------------------
    }
    public class ProfieProperityCollection
    {
        //------------------------------------------
        private List<ProfieProperity> _Properities;
        public List<ProfieProperity> Properities
        {
            get
            {
                if (_Properities == null)
                    _Properities = new List<ProfieProperity>();
                return _Properities;
            }
            //set { _Properities = value; }
        }
        //------------------------------------------
        public int Count
        {
            get
            {
                if (_Properities == null)
                    _Properities = new List<ProfieProperity>();
                return _Properities.Count;
            }
        }
        public void Add(string name)
        {
            Properities.Add(new ProfieProperity(name, null));
        }
        public void Add(ProfieProperity prop)
        {
            Properities.Add(prop);
        }
    }
}