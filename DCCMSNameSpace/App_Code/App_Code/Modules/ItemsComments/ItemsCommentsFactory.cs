using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Caching;
using DCCMSNameSpace;


namespace DCCMSNameSpace
{
    public class ItemsCommentsFactory
    {
        #region --------------Create--------------
        /// <summary>
        /// Creates Comments object by calling Comments data provider create method.
        /// <example>[Example]bool status=ItemsCommentsFactory.Create(comments);.</example>
        /// </summary>
        /// <param name="comments">The Comments object.</param>
        /// <returns>Status of create operation.</returns>
        public static ExecuteCommandStatus Create(ItemsCommentsEntity comments)
        {
            //Insert user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                comments.InsertUserName = username;
            }
            //----------------------------------------------------------
            return ItemsCommentsSqlDataPrvider.Instance.Create(comments);
        }
        //----------------------------------------------------------
        #endregion

        public static ExecuteCommandStatus Update(ItemsCommentsEntity comments)
        {
            //Update user name------------------------------------------
            string username = "";
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                username = HttpContext.Current.User.Identity.Name;
                comments.LastUpdateUserName = username;
            }
            //----------------------------------------------------------
            return ItemsCommentsSqlDataPrvider.Instance.Update(comments);
        }
        //------------------------------------------

        #region --------------Delete--------------
        /// <summary>
        /// Deletes single Comments object .
        /// <example>[Example]bool status=ItemsCommentsFactory.Delete(commentID);.</example>
        /// </summary>
        /// <param name="commentID">The comments id.</param>
        /// <returns>Status of delete operation.</returns>
        public static ExecuteCommandStatus Delete(int commentID)
        {
            return ItemsCommentsSqlDataPrvider.Instance.Delete(commentID);

        }
        //------------------------------------------
        #endregion

        #region --------------GetAll--------------
        public static List<ItemsCommentsEntity> GetAll(int itemID, Languages langID, int moduleTypeID, bool isAvailableCondition, bool isActive, bool notSeenCondition, int pageIndex, int pageSize, out int totalRecords, Guid OwnerID)
        {
            return ItemsCommentsSqlDataPrvider.Instance.GetAll(itemID, langID, moduleTypeID, isAvailableCondition, isActive, notSeenCondition, pageIndex, pageSize, out totalRecords,  OwnerID);
        }
        //------------------------------------------
        #endregion

        #region --------------GetCount--------------
        public static int GetCount(int itemID, Languages langID, int moduleTypeID, bool isAvailableCondition, bool isActive, bool notSeenCondition, Guid OwnerID)
        {
            return ItemsCommentsSqlDataPrvider.Instance.GetCount(itemID, langID, moduleTypeID, isAvailableCondition, isActive, notSeenCondition,  OwnerID);
        }
        //------------------------------------------
        #endregion
        #region --------------AddBadCommnetAlert--------------
        public static void AddBadCommnetAlert(int commentID)
        {
            HttpCookie cookie;
            cookie = HttpContext.Current.Request.Cookies["ww44AA-ddd-rrTT-017" + commentID.ToString()];
            if (cookie == null)
            {
                int availableAlertsCount = SiteSettings.Comments_RefuseLimmets;
                ItemsCommentsSqlDataPrvider.Instance.AddBadCommnetAlert(commentID, availableAlertsCount);
                cookie = new HttpCookie("ww44AA-ddd-rrTT-017" + commentID.ToString(), "true");
                cookie.Expires = DateTime.Now.AddDays(2);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        //------------------------------------------
        #endregion
        #region --------------GetObject--------------
        public static ItemsCommentsEntity GetObject(int commentID)
        {
            ItemsCommentsEntity itemComment;
            HttpContext context = HttpContext.Current;
            string cacheKey = "itemComment" + commentID;

            if (context.Items[cacheKey] == null)
            {
                itemComment = ItemsCommentsSqlDataPrvider.Instance.GetObject(commentID, SitesHandler.GetOwnerIDAsGuid());
                context.Items[cacheKey] = itemComment;
            }
            else
            {
                itemComment = (ItemsCommentsEntity)context.Items[cacheKey];
            }
            //return the object
            return itemComment;
        }
        //------------------------------------------
        #endregion
        #region --------------ActivateComment--------------
        public static ExecuteCommandStatus ActivateComment(int commentID)
        {
            return ItemsCommentsSqlDataPrvider.Instance.ActivateComment(commentID);
        }
        //------------------------------------------
        #endregion
        //----------------------------------------------
        /*  public static bool GetCommentsIsEnableValue()
          {
              return SiteSettings.Comments_Enable;
          }
          //----------------------------------------------
          public static int GetCommentsRefuseLimmets()
          {
              return  ;
          }
          //----------------------------------------------
          public static int GetCommentsAllowDays()
          {
              return SiteSettings.Comments_AllowDays;
          }
          //----------------------------------------------*/
    }

}