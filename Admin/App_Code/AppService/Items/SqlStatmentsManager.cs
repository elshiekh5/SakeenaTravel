using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
namespace AppService
{
    /// <summary>
    /// Summary description for SqlStatmentsManager
    /// </summary>
    public class SqlStatmentsManager
    {
        public static Hashtable SqlStatments = new Hashtable();
        static SqlStatmentsManager()
        {
            //-----------------------------------------------------------------------------------------------------
            //Services
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["Services"] =
@"
SELECT     dbo.Items.ItemID, dbo.Items.PhotoExtension, dbo.ItemsDetails.ShortDescription, dbo.ItemsDetails.Title
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID ASC
";
            //-----------------------------------------------------------------------------------------------------
        }
    }

}