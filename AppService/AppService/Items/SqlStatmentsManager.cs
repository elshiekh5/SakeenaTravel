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
SELECT     dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.ShortDescription, dbo.ItemsDetails.Title
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID ASC
";
            //-----------------------------------------------------------------------------------------------------
            //Header
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["Header"] =
@"
SELECT     dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.Photo2Extension,  dbo.ItemsDetails.Title
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID ASC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion
            #region Services Statement
            //-----------------------------------------------------------------------------------------------------
            //Services
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["Clients"] =
@"
SELECT     dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.Items.Photo2Extension, dbo.ItemsDetails.Title
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
SELECT     dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.ShortDescription, dbo.ItemsDetails.Title
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID DESC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region Team Statement

            //-----------------------------------------------------------------------------------------------------
            //Team
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["Team"] =
@"
SELECT     dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.ShortDescription, dbo.ItemsDetails.Title, dbo.ItemsDetails.AuthorName, dbo.Items.Email, 
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
    Order By dbo.Items.ItemID DESC
    -------------------------------------------
    SELECT @Total= @@ROWCOUNT
	-------------------------------------------

	SELECT  dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title

	FROM         #PageIndexTable inner join  Items
	on Items.ItemID =#PageIndexTable.ID  INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID  And (dbo.ItemsDetails.LangID = {1})

";

            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region Blog Statement
            //-----------------------------------------------------------------------------------------------------
            //Blog
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["Blog"] =
@"
SELECT     dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title, dbo.ItemsDetails.ShortDescription, dbo.ItemsDetails.AuthorName, dbo.Items.Date_Added
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1}) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID DESC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region BlogPaging Statement
            //-----------------------------------------------------------------------------------------------------
            //BlogPaging
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["BlogPaging"] =
@"

    INSERT INTO #PageIndexTable (ID) 
	SELECT  dbo.Items.ItemID 
	FROM dbo.Items   INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
    WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})
    Order By dbo.Items.ItemID DESC
	-------------------------------------------
    SELECT @Total= @@ROWCOUNT
	-------------------------------------------
	SELECT  dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title, dbo.ItemsDetails.ShortDescription, dbo.ItemsDetails.AuthorName, dbo.Items.Date_Added

	FROM         #PageIndexTable inner join  Items
	on Items.ItemID =#PageIndexTable.ID  INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID  

";

            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region OffersPaging Statement
            //-----------------------------------------------------------------------------------------------------
            //PortFolio
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["OffersPaging"] =
@"

    INSERT INTO #PageIndexTable (ID) 
	SELECT  dbo.Items.ItemID 
	FROM dbo.Items   INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
    WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})
    Order By dbo.Items.ItemID DESC
    -------------------------------------------
    SELECT @Total= @@ROWCOUNT
	-------------------------------------------

	SELECT  dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title, dbo.Items.Price

	FROM         #PageIndexTable inner join  Items
	on Items.ItemID =#PageIndexTable.ID  INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID  And (dbo.ItemsDetails.LangID = {1})

";

            //-----------------------------------------------------------------------------------------------------
            #endregion
            #region SupervisorPaging Statement
            //-----------------------------------------------------------------------------------------------------
            //PortFolio
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["SupervisorPaging"] =
@"

    INSERT INTO #PageIndexTable (ID) 
	SELECT  dbo.Items.ItemID 
	FROM dbo.Items   INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
    WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})
    Order By dbo.Items.ItemID DESC
    -------------------------------------------
    SELECT @Total= @@ROWCOUNT
	-------------------------------------------

	SELECT  dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title, dbo.ItemsDetails.ShortDescription

	FROM         #PageIndexTable inner join  Items
	on Items.ItemID =#PageIndexTable.ID  INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID  And (dbo.ItemsDetails.LangID = {1})

";

            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region YoutubePaging Statement
            //-----------------------------------------------------------------------------------------------------
            //PortFolio
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["YoutubePaging"] =
@"

    INSERT INTO #PageIndexTable (ID) 
	SELECT  dbo.Items.ItemID 
	FROM dbo.Items   INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
    WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})
    Order By dbo.Items.ItemID DESC
    -------------------------------------------
    SELECT @Total= @@ROWCOUNT
	-------------------------------------------

	SELECT  dbo.Items.ItemID,dbo.Items.YoutubeCode, dbo.Items.CategoryID,  dbo.ItemsDetails.Title

	FROM         #PageIndexTable inner join  Items
	on Items.ItemID =#PageIndexTable.ID  INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID  And (dbo.ItemsDetails.LangID = {1})

";

            //-----------------------------------------------------------------------------------------------------
            #endregion


            #region PortFolio Statement
            //-----------------------------------------------------------------------------------------------------
            //PortFolio
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["ArticlesPagingByCategory"] =
@"

    INSERT INTO #PageIndexTable (ID) 
	SELECT  dbo.Items.ItemID 
	FROM dbo.Items   INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
    WHERE (dbo.Items.ModuleTypeID = {0} ) And({2}=0 OR Items.CategoryID={2}) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})
    Order By dbo.Items.ItemID DESC
    -------------------------------------------
    SELECT @Total= @@ROWCOUNT
	-------------------------------------------

	SELECT  dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title, dbo.Items.Price

	FROM         #PageIndexTable inner join  Items
	on Items.ItemID =#PageIndexTable.ID  INNER JOIN  dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID  And (dbo.ItemsDetails.LangID = {1})

";

            //-----------------------------------------------------------------------------------------------------
            #endregion
            #region TopTitlesPhotos
            //-----------------------------------------------------------------------------------------------------
            //TopTitlesPhotos
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["TopTitlesPhotos"] =
@"
SELECT   Top({2})  dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID DESC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region TopFeatured
            //-----------------------------------------------------------------------------------------------------
            //TopTitlesPhotos
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["TopFeatured"] =
@"
SELECT   Top(3)  dbo.Items.ItemID, dbo.ItemsDetails.Title, dbo.ItemsDetails.ShortDescription, dbo.Items.MailBox
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID DESC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion


            #region LatestOffers
            //-----------------------------------------------------------------------------------------------------
            //TopTitlesPhotos
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["LatestOffers"] =
@"
SELECT   Top({2})  dbo.Items.ItemID, dbo.ItemsDetails.Title
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID DESC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region TopTitlesPhotosShortDescription
            //-----------------------------------------------------------------------------------------------------
            //TopTitlesPhotos
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["TopTitlesPhotosShortDescription"] =
@"
SELECT   Top({2})  dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title , dbo.ItemsDetails.ShortDescription
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID DESC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region TopTitlesPhotosPrice
            //-----------------------------------------------------------------------------------------------------
            //TopTitlesPhotos
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["TopTitlesPhotosPrice"] =
@"
SELECT   Top({2})  dbo.Items.ItemID, dbo.Items.CategoryID, dbo.Items.PhotoExtension, dbo.ItemsDetails.Title , dbo.Items.Price
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID DESC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region AllTitles
            //-----------------------------------------------------------------------------------------------------
            //TopTitlesPhotos
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["AllTitles"] =
@"
SELECT   dbo.Items.ItemID, dbo.ItemsDetails.Title
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID DESC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion

            #region AllTitlesDescription
            //-----------------------------------------------------------------------------------------------------
            //TopTitlesPhotos
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["AllTitlesDescription"] =
@"
SELECT   dbo.Items.ItemID, dbo.ItemsDetails.Title, dbo.ItemsDetails.Description
FROM         dbo.Items INNER JOIN
                      dbo.ItemsDetails ON dbo.Items.ItemID = dbo.ItemsDetails.ItemID
WHERE (dbo.Items.ModuleTypeID = {0} ) And ( Items.[IsAvailable] = 1 ) And (dbo.ItemsDetails.LangID = {1})

Order By dbo.Items.ItemID DESC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion


            #region AllCategoriesTitles
            //-----------------------------------------------------------------------------------------------------
            //AllCategoriesTitles
            //-----------------------------------------------------------------------------------------------------
            SqlStatments["AllCategoriesTitles"] =
@"
SELECT   dbo.ItemCategories.CategoryID, dbo.ItemCategoriesDetails.Title
FROM         dbo.ItemCategories INNER JOIN
                      dbo.ItemCategoriesDetails ON dbo.ItemCategories.CategoryID = dbo.ItemCategoriesDetails.CategoryID 
WHERE (dbo.ItemCategories.ModuleTypeID = {0} ) And ( ItemCategories.[IsAvailable] = 1 ) And (dbo.ItemCategoriesDetails.LangID = {1})

Order By dbo.ItemCategories.CategoryID ASC
";
            //-----------------------------------------------------------------------------------------------------
            #endregion

        }
    }

}