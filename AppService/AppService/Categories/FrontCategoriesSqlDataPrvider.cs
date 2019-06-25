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
    public class FrontCategoriesSqlDataPrvider : SqlDataProvider
    {

        #region --------------Instance--------------
        private static FrontCategoriesSqlDataPrvider _Instance;
        public static FrontCategoriesSqlDataPrvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new FrontCategoriesSqlDataPrvider();
                }
                return _Instance;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetData--------------
        public List<FrontCategoriesModel> GetData(string sql)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                //-----------------------------------------------------------------
                List<FrontCategoriesModel> itemsList = new List<FrontCategoriesModel>();
                FrontCategoriesModel itemsObject;
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
                    itemsObject = (FrontCategoriesModel)GetEntity(dr, typeof(FrontCategoriesModel));
                    itemsList.Add(itemsObject);

                }
                dr.Close();
                myConnection.Close();
                return itemsList;
            }
        }
        #endregion

        #region --------------GetDataPageByPage--------------
        public List<FrontCategoriesModel> GetDataPageByPage(string sql, int pageIndex, int pageSize, out int totalRecords)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                //-----------------------------------------------------------------
                List<FrontCategoriesModel> itemsList = new List<FrontCategoriesModel>();
                FrontCategoriesModel itemsObject;
                Hashtable temp = new Hashtable();
                SqlCommand myCommand = new SqlCommand("[dbo].New_Items_GetDataPageByPage", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@PageIndex", SqlDbType.Int, 4).Value = pageIndex;
                myCommand.Parameters.Add("@pageSize", SqlDbType.Int, 4).Value = pageSize;
                myCommand.Parameters.Add("@TotalRecords", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                myCommand.Parameters.Add("@SqlStatement", SqlDbType.NVarChar).Value = sql;
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    itemsObject = (FrontCategoriesModel)GetEntity(dr, typeof(FrontCategoriesModel));
                    itemsList.Add(itemsObject);

                }
                dr.Close();
                myConnection.Close();
                //Gets result rows count
                totalRecords = (int)myCommand.Parameters["@TotalRecords"].Value;
                return itemsList;
            }
        }
        #endregion

        #region --------------GetItemsObject--------------
        public FrontCategoriesModel GetItemObject(int itemID, Languages langID)
        {
            FrontCategoriesModel item = null;
            using (SqlConnection myConnection = GetSqlConnection())
            {
                SqlCommand myCommand = new SqlCommand("dbo.New_Items_GetOneByID", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                // Set the parameters
                myCommand.Parameters.Add("@ItemID", SqlDbType.Int, 4).Value = itemID;
                myCommand.Parameters.Add("@LangID", SqlDbType.Int, 4).Value = (int)langID;
                //---------------------------------------------------------------------
                //---------------------------------------------------------------------
                // Execute the command
                myConnection.Open();
                using (SqlDataReader dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    while (dr.Read())
                    {
                        item = (FrontCategoriesModel)GetEntity(dr, typeof(FrontCategoriesModel));
                    }
                    dr.Close();
                }
                myConnection.Close();
                return item;
            }
        }
        //------------------------------------------
        #endregion
    }

}