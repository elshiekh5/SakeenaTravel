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


namespace DCCMSNameSpace
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
            ProfilesEntity profile = null;
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
                        /*
                   else if (reader[columnname].GetType() == typeof(Byte[]))
                   {
                       byte[] buf = (byte[])reader[columnname];
                       myPropInfo.SetValue(obj, Convert.ChangeType(OurSerializer.Deserialize(buf), myPropInfo.PropertyType), null);
                   }*/
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
                    else
                    {
                        if (columnname.ToLower() == "propertynames")
                        {
                            if (profile == null) profile = new ProfilesEntity();
                            if (reader["PropertyNames"] != DBNull.Value)
                                profile.PropertyNames = (string)reader["PropertyNames"];
                        }
                        else if (columnname.ToLower() == "propertyvaluesstring")
                        {
                            if (profile == null) profile = new ProfilesEntity();
                            if (reader["PropertyValuesString"] != DBNull.Value)
                                profile.PropertyValuesString = (string)reader["PropertyValuesString"];

                        }
                        
                    }
                }
            }
            if (profile != null)
            {
                PropertyInfo myPropInfo = t.GetProperty("Profile");
                if (myPropInfo!=null)
                {
                    //-------------------------------------------------------------
                    object objProfile = Activator.CreateInstance(myPropInfo.PropertyType);
                    //-------------------------------------------------------------
                    //-------------------------------------------------------------
                     ProfilesEntity Tempprofile = (ProfilesEntity)objProfile;
                    Tempprofile.PropertyNames = profile.PropertyNames;
                    Tempprofile.PropertyValuesString = profile.PropertyValuesString;
                    //-------------------------------------------------------------
                    ProfileBuilder.ParseProfileData(Tempprofile.PropertyNames, Tempprofile.PropertyValuesString, Tempprofile.PropertyValueCollection);
                    //-------------------------------------------------------------
                    myPropInfo.SetValue(obj, objProfile, null);
                    //-------------------------------------------------------------
                }
                
            }
            //---------------------------------
            return obj;
        }


        protected bool Createko(Type myType, object obj, string tableName)
        {
            //Type myType = typeof(t);
            PropertyInfo[] piT = myType.GetProperties();
            object PropValue;
            DCAttributes[] dcattr;
            DCNonInsertable[] dcNonInsertable;
            //object defaultValue;
            /*string strQry =
                    " Count(*) FROM Users WHERE UserName=@username " +
                    "AND Password=@password";*/

            using (SqlConnection myConnection = GetSqlConnection())
            {
                string columns = "";
                string parameters = "";
                SqlParameter prm;

                SqlCommand myCommand = new SqlCommand("", myConnection);
                myCommand.CommandType = CommandType.Text;
                // Set the parameters
                myCommand.Parameters.Add("@DCID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                foreach (PropertyInfo myPropInfo in piT)
                {
                    if (myPropInfo.CanWrite)
                    {
                        PropValue = myPropInfo.GetValue(obj, null);
                        dcattr = (DCAttributes[])myPropInfo.GetCustomAttributes(typeof(DCAttributes), false);
                        dcNonInsertable = (DCNonInsertable[])myPropInfo.GetCustomAttributes(typeof(DCNonInsertable), false);
                        if (dcNonInsertable.Length == 0)
                        {
                            if (columns.Length > 0)
                            {
                                columns += ",";
                                parameters += ",";
                            }
                            columns += "[" + myPropInfo.Name + "]";
                            parameters += "@" + myPropInfo.Name;

                            if (dcattr.Length > 0)
                            {
                                prm = new SqlParameter("@" + myPropInfo.Name, dcattr[0].PropType, dcattr[0].PropLength);
                                prm.Value = PropValue;
                            }
                            else
                            {
                                prm = new SqlParameter("@" + myPropInfo.Name, PropValue);

                            }
                            myCommand.Parameters.Add(prm);
                        }
                    }
                }
                prm = new SqlParameter();
                prm.ParameterName = "@DCID";
                prm.Direction = ParameterDirection.Output;
                string InsertQuery = "INSERT INTO [" + tableName + "] (" + columns + ")VALUES (" + parameters + ")";
                InsertQuery += "SET @DCID = @@Identity";
                myCommand.CommandText = InsertQuery;

                // Execute the command
                bool status = false;
                myConnection.Open();
                if (myCommand.ExecuteNonQuery() > 0)
                {
                    status = true;
                    //Get ID value from database and set it in object
                    int dcID = (int)myCommand.Parameters["@DCID"].Value;
                }
                myConnection.Close();
                return status;
            }
        }

    }
}