using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using System.IO;
using DCCMSNameSpace;
using System.Web.UI.WebControls;

namespace DCCMSNameSpace
{
    public class SiteStatisticsFactory
    {
        #region --------------GetAll--------------
        public static List<SiteStatisticsEntity> GetAll(int moduleTypeID, Guid OwnerID)
        {
            return SiteStatisticsSqlProvider.Instance.GetAll( moduleTypeID,  OwnerID);
        }
        #endregion
    }
}