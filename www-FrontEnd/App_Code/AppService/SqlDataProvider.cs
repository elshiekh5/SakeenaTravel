using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Reflection;
using DCCMSNameSpace;


namespace AppService
{
    public class SqlDataProvider
    {
        protected StringDictionary ColumnsNames = null;
        #region --------------GetSqlConnection--------------
        protected SqlConnection GetSqlConnection()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["Connectionstring"].ToString());
        }
        //------------------------------------------
        #endregion

        #region GetColumnsName
        protected StringDictionary GetColumnsSchema(IDataReader reader)
        {
            StringDictionary columnsNames = new StringDictionary();
            DataTable dt = reader.GetSchemaTable();
            //---------------------------------
            foreach (DataColumn c in dt.Columns)
            {
                columnsNames.Add(c.ColumnName, null);
            }
            //---------------------------------
            return columnsNames;
        }
        #endregion

        protected object GetEntity(IDataReader reader, Type t)
        {

            object obj = Activator.CreateInstance(t);
            //object obj = new t();
            StringDictionary columnsNames = new StringDictionary();
            DataTable dt = reader.GetSchemaTable();
            //---------------------------------
            string columnname;
            for (int i = 0; i < reader.FieldCount; i++)
            {
                columnname = reader.GetName(i);
                if (!columnsNames.ContainsKey(columnname))
                {
                    columnsNames.Add(columnname, null);
                    PropertyInfo myPropInfo;
                    myPropInfo = t.GetProperty(columnname);
                    if (reader[columnname] != DBNull.Value && myPropInfo != null)
                    {
                        //myPropInfo.SetValue(obj, Convert.ChangeType(reader[columnname], myPropInfo.PropertyType), null);

                        if (myPropInfo.PropertyType.BaseType == typeof(System.Enum))
                        {
                            //int intVal = Convert.ToInt32(attr.Value);
                            myPropInfo.SetValue(obj, Enum.Parse(myPropInfo.PropertyType, reader[columnname].ToString()), null);
                            //Enum.Parse(typeof(myPropInfo.), "FirstName");   
                        }
                        else if (columnname.ToLower() == "extradata")
                        {
                            string buf = (string)reader[columnname];
                            myPropInfo.SetValue(obj, Convert.ChangeType(OurSerializer.Deserialize(buf), myPropInfo.PropertyType), null);
                        }

                        else
                        {
                            myPropInfo.SetValue(obj, Convert.ChangeType(reader[columnname], myPropInfo.PropertyType), null);
                        }
                    }
                    
                }
            }
           
            //---------------------------------
            return obj;
        }



    }
}