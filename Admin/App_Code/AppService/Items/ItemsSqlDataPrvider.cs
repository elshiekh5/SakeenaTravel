using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using DCCMSNameSpace;

namespace AppService
{
    public class ItemsSqlDataPrvider : SqlDataProvider
    {

        #region --------------Instance--------------
        private static ItemsSqlDataPrvider _Instance;
        public static ItemsSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ItemsSqlDataPrvider();
                }
                return _Instance;
            }
        }
        //------------------------------------------
        #endregion



        #region --------------GetData--------------
        public List<FrontItemsModel> GetData(string sql)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                //-----------------------------------------------------------------
                List<FrontItemsModel> itemsList = new List<FrontItemsModel>();
                FrontItemsModel itemsObject;
                Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand(sql, myConnection);
                myCommand.CommandType = CommandType.Text;
                // Set the parameters
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (FrontItemsModel)GetEntity(dr, typeof(FrontItemsModel));
                    itemsList.Add(itemsObject);

                }
                dr.Close();
                myConnection.Close();
                return itemsList;
            }
        }
        #endregion


    }

}