using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using DCCMSNameSpace;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for SiteStatisticsSqlProvider
    /// </summary>
    public class SiteStatisticsSqlProvider : SqlDataProvider
    {
        public SiteStatisticsSqlProvider()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region --------------Instance--------------
        private static SiteStatisticsSqlProvider _Instance;
        public static SiteStatisticsSqlProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SiteStatisticsSqlProvider();
                }
                return _Instance;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public List<SiteStatisticsEntity> GetAll(int moduleTypeID, Guid OwnerID)
        {
            using (SqlConnection myConnection = GetSqlConnection())
            {
                List<SiteStatisticsEntity> statsList = new List<SiteStatisticsEntity>();
                SiteStatisticsEntity statsObject;
                SqlCommand myCommand = new SqlCommand("SiteStatistics_GetAll", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //---------------------------------------------------------------------
                myCommand.Parameters.Add("@ModuleTypeID", SqlDbType.Int, 4).Value = (int)moduleTypeID;
                //---------------------------------------------------------------------
                if (OwnerID != null)
                {
                    Guid _OwnerID = new Guid(OwnerID.ToString());
                    if (_OwnerID != Guid.Empty)
                        myCommand.Parameters.Add("@OwnerID", SqlDbType.UniqueIdentifier).Value = _OwnerID;
                }
                //---------------------------------------------------------------------
                // Execute the command
                SqlDataReader dr;
                myConnection.Open();
                dr = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    statsObject = (SiteStatisticsEntity)GetEntity(dr, typeof(SiteStatisticsEntity));
                    statsList.Add(statsObject);
                }
                dr.Close();
                myConnection.Close();
                return statsList;
            }
        }
        #endregion
    }

}