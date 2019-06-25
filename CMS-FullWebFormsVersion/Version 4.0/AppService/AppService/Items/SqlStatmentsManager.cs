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
            #region Services Statement
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
            #endregion

            #region Solutions Statement
            //-----------------------------------------------------------------------------------------------------
            //Services
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["Solutions"] =
@"
SELECT     dbo.Items.ItemID, dbo.Items.PhotoExtension, dbo.ItemsDetails.ShortDescription, dbo.ItemsDetails.Title
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID ASC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion
            #region Team Statement

            //-----------------------------------------------------------------------------------------------------
            //Team
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["Team"] =
@"
SELECT     dbo.Items.ItemID, dbo.Items.PhotoExtension, dbo.ItemsDetails.ShortDescription, dbo.ItemsDetails.Title, dbo.ItemsDetails.AuthorName, dbo.Items.Email, 
                      dbo.Items.Url, dbo.Items.MailBox, dbo.Items.ZipCode, dbo.Items.Tels, dbo.Items.Fax, dbo.Items.Mobile
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID ASC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region PortFolio Statement
            //-----------------------------------------------------------------------------------------------------
            //PortFolio
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["PortFolioPaging"] =
@"

    INSERT INTO #PageIndexTable (ID) 
	SELECT  dbo.Items.ItemID 
	FROM dbo.Items   INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
    WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})
    Order By dbo.Items.ItemID ASC
    
	-------------------------------------------
	SELECT  dbo.Items.ItemID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title

	FROM         #PageIndexTable inner join  Items
	on Items.ItemID =#PageIndexTable.ID  INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID  

";

            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region Blog Statement
            //-----------------------------------------------------------------------------------------------------
            //Blog
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["Blog"] =
@"
SELECT     dbo.Items.ItemID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title, dbo.ItemsDetails.ShortDescription, dbo.ItemsDetails.AuthorName, dbo.Items.Date_Added
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID ASC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region PortFolio Statement
            //-----------------------------------------------------------------------------------------------------
            //PortFolio
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["BlogPaging"] =
@"

    INSERT INTO #PageIndexTable (ID) 
	SELECT  dbo.Items.ItemID 
	FROM dbo.Items   INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
    WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})
    Order By dbo.Items.ItemID ASC
    
	-------------------------------------------
	SELECT  dbo.Items.ItemID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title, dbo.ItemsDetails.ShortDescription, dbo.ItemsDetails.AuthorName, dbo.Items.Date_Added

	FROM         #PageIndexTable inner join  Items
	on Items.ItemID =#PageIndexTable.ID  INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID  

";

            //-----------------------------------------------------------------------------------------------------
            #endregion

        }
    }

}