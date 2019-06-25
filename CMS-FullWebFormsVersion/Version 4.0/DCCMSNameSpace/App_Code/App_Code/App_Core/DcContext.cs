using System;
using System.Collections.Generic;

using System.Web;
namespace DCCMSNameSpace
{

    /// <summary>
    /// Summary description for DcContext
    /// </summary>
    public class DcContext
    {
        HttpContext _Context;
        int _CategoryID = -1;
        int _UserProfileID = -1;
        int _ItemID = -1;
        int _MessageID = -1;
        DateTime requestStartTime = DateTime.Now;
        /*
        int threadID = -1;
        int userID = -1;

        string userName = "";
        int pageIndex = -1;
        int roleID = -1;
        string queryText = "";
        string returnUrl = "";
        */

        // *********************************************************************
        public DcContext()
        {
            _Context = HttpContext.Current;
            if (_Context == null)
                return;
            else HttpContext.Current.Items["SiteContext"] = _Context; 
            /*_CategoryID = -1;
            _UserProfileID = -1;
            _ItemID = -1;
            _MessageID = -1;*/
            /*postID = GetIntFromQueryString(context, "PostID");
            forumID = GetIntFromQueryString(context, "ForumID");
            forumGroupID = GetIntFromQueryString(context, "ForumGroupID");
            userID = GetIntFromQueryString(context, "UserID");
            messageID = GetIntFromQueryString(context, "MessageID");
            pageIndex = GetIntFromQueryString(context, "PageIndex");
            roleID = GetIntFromQueryString(context, "RoleID");
            queryText = context.Request.QueryString["q"];
            returnUrl = context.Request.QueryString["returnUrl"];*/
        }
        // *********************************************************************
        public static DcContext Current
        {
            get
            {
                if (HttpContext.Current == null)
                    return new DcContext();

                return (DcContext)HttpContext.Current.Items["SiteContext"];
            }

        }
        // *********************************************************************
        //  GetIntFromQueryString
        //
        /// <summary>
        /// Retrieves a value from the query string and returns it as an int.
        /// </summary>
        // *********************************************************************
        public static int GetIntFromQueryString(HttpContext context, string key)
        {
            int returnValue = -1;
            string queryStringValue;

            // Attempt to get the value from the query string
            //
            queryStringValue = context.Request.QueryString[key];

            // If we didn't find anything, just return
            //
            if (queryStringValue == null)
                return returnValue;

            // Found a value, attempt to conver to integer
            //
            try
            {

                // Special case if we find a # in the value
                //
                if (queryStringValue.IndexOf("#") > 0)
                    queryStringValue = queryStringValue.Substring(0, queryStringValue.IndexOf("#"));

                returnValue = Convert.ToInt32(queryStringValue);
            }
            catch { }

            return returnValue;

        }
        // *********************************************************************
        // *********************************************************************
        //  GetForumFromForumLookupTable //
        //
        /// <summary>
        /// Attempts to use forum lookup table. Capable of flushing lookup table
        /// </summary>
        // ***********************************************************************/
       /* public Forum GetForumFromForumLookupTable(int forumID)
        {
            Forum f = (Forum)this.ForumLookupTable[forumID];

            if (f != null)
                return f;

            // Null out the cached list and attempt to reload
            //
            if ((f == null) && (context.Cache["ForumsTable"] != null))
                context.Cache.Remove("ForumsTable");

            f = (Forum)ForumLookupTable[forumID];

            if (f == null)
            {
                throw new Exception("Forum ID is invalid");
            }

            return f;
        }

        public Hashtable ForumLookupTable
        {

            get
            {

                if (HttpRuntime.Cache["ForumsTable"] == null)
                    HttpRuntime.Cache.Insert("ForumsTable", Forums.GetForums(this, 0, true, false), null, DateTime.Now.AddMinutes(120), TimeSpan.Zero);

                return (Hashtable)HttpRuntime.Cache["ForumsTable"];
            }

        }
        */
        public static string GetApplicationName()
        {
            return GetApplicationName(HttpContext.Current);
        }

        public static string GetApplicationName(HttpContext context)
        {
            if (context == null)
                return "";

            string hostName = context.Request.Url.Host;
            string applicationPath = context.Request.ApplicationPath;

            return hostName + applicationPath;
        }

        public HttpContext Context
        {
            get
            {
                if (_Context == null)
                    return new HttpContext(null);

                return _Context;
            }
        }
    }
}