using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.SessionState;
using DCCMSNameSpace;
using System.Globalization;
namespace DCCMSNameSpace
{
    public class BetterUrlRewriter : IHttpHandler, IRequiresSessionState
    {
        const string ORIGINAL_PATHINFO = "UrlRewriterOriginalPathInfo";
        const string ORIGINAL_QUERIES = "UrlRewriterOriginalQueries";
        //---------------------------------------
        public HttpContext Context
        {
            get { return HttpContext.Current; }
        }
        //---------------------------------------
        public void ProcessRequest(HttpContext context)
        {
            /*
            // Check to see if the specified HTML file actual exists and serve it if so..        
            String strReqPath = context.Server.MapPath(context.Request.AppRelativeCurrentExecutionFilePath);
            if (File.Exists(strReqPath))
            {
                context.Response.WriteFile(strReqPath);
                context.Response.End();
                return;
            }

            // Record the original request PathInfo and QueryString information to handle graceful postbacks        
            context.Items[ORIGINAL_PATHINFO] = context.Request.PathInfo;
            context.Items[ORIGINAL_QUERIES] = context.Request.QueryString.ToString();

            // Map the friendly URL to the back-end one..        
            String strVirtualPath = "";
            String strQueryString = "";
            MapFriendlyUrl(context, out strVirtualPath, out strQueryString);
            if (strVirtualPath.Length > 0)
            {
                foreach (string strOriginalQuery in context.Request.QueryString.Keys)
                {
                    // To ensure that any query strings passed in the original request are preserved, we append these                 
                    // to the new query string now, taking care not to add any keys which have been rewritten during the handler..                
                    if (strQueryString.ToLower().IndexOf(strOriginalQuery.ToLower() + "=") < 0)
                    {
                        strQueryString += string.Format("{0}{1}={2}", ((strQueryString.Length > 0) ? "&" : ""), strOriginalQuery, context.Request.QueryString[strOriginalQuery]);
                    }
                }

                // Apply the required query strings to the request            
                context.RewritePath(context.Request.Path, string.Empty, strQueryString);
                // Now get a page handler for the ASPX page required, using this context.              
                Page aspxHandler = (Page)PageParser.GetCompiledPageInstance(strVirtualPath, context.Server.MapPath(strVirtualPath), context);
                // Execute the handler..            
                aspxHandler.PreRenderComplete += new EventHandler(AspxPage_PreRenderComplete);
                aspxHandler.ProcessRequest(context);
            }
            else
            {
                // No mapping was found - emit a 404 response.             
                context.Response.StatusCode = 404;
                context.Response.ContentType = "text/plain";
                context.Response.Write("Page Not Found");
                context.Response.End();
            }*/
            string newPath = Context.Request.RawUrl;
            HandleCurrentLanguage();
            DCMetaBuilder.InisializeMetaTags();
            DCSiteUrls urls = DCSiteUrls.Instance;
            urls.ReWriteUrl();
        }

        void MapFriendlyUrl(HttpContext context, out String strVirtualPath, out String strQueryString)
        {
            strVirtualPath = ""; strQueryString = "";

            // TODO: This routine should examine the context.Request properties and implement        
            //       an appropriate mapping system.        
            //        
            //       Set strVirtualPath to the virtual path of the target aspx page.        
            //       Set strQueryString to any query strings required for the page.         

            if (context.Request.Path.IndexOf("FriendlyPage.html") >= 0)
            {
                // Example hard coded mapping of "FriendlyPage.html" to "UnfriendlyPage.aspx"             

                strVirtualPath = "~/UnfriendlyPage.aspx";
                strQueryString = "FirstQuery=1&SecondQuery=2";
            }
        }

        void AspxPage_PreRenderComplete(object sender, EventArgs e)
        {
            // We need to rewrite the path replacing the original tail and query strings..        
            // This happens AFTER the page has been loaded and setup but has the effect of ensuring        
            // postbacks to the page retain the original un-rewritten pages URL and queries.         

            HttpContext.Current.RewritePath(HttpContext.Current.Request.Path,
            HttpContext.Current.Items[ORIGINAL_PATHINFO].ToString(),
            HttpContext.Current.Items[ORIGINAL_QUERIES].ToString());
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
        //---------------------------------------------------------------------------------------
        void HandleCurrentLanguage()
        {
            //HttpApplication Context = (HttpApplication)sender;
            //-----------------------------------------------------------------
            Languages defaultLang = (Languages)SiteSettings.Languages_DefaultLanguageID;
            string cookie_name = SiteSettings.Site_CookieName + "_lang";
            string culture = "";
            switch (defaultLang)
            {
                case Languages.Ar:
                    culture = Culture.ArabicEgypt;
                    Context.Items["LangID"] = Languages.Ar;
                    break;
                case Languages.En:
                    culture = Culture.EnglishUSA;
                    Context.Items["LangID"] = Languages.En;
                    break;
            }
            //---------------------------------------------------
            if (Context.Request.Cookies[cookie_name] != null)
            {
                culture = Context.Request.Cookies[cookie_name].Value;

                if (culture.ToLower() != "auto")
                {
                    if (culture.ToLower() == "ar")
                    {
                        culture = Culture.ArabicEgypt;
                        Context.Items["LangID"] = Languages.Ar;
                    }
                    else if (culture.ToLower() == "en")
                    {
                        culture = Culture.EnglishUSA;
                        Context.Items["LangID"] = Languages.En;
                    }
                }
            }
            //-------------------------------------------
            string url = Context.Request.RawUrl.ToLower();
            if (url.ToLower().IndexOf("/adminmaster/") > -1)
            {
                culture = Culture.ArabicEgypt;
                Context.Items["LangID"] = Languages.Ar;
            }
            //-------------------------------------------
            if (url.ToLower().IndexOf("/admincp/") > -1 || url.ToLower().IndexOf("/adminsub/") > -1)
            {
                int adminLang = SiteSettings.Languages_AdminLanguageID;
                if (adminLang == 1)
                {
                    culture = Culture.ArabicEgypt;
                    Context.Items["LangID"] = Languages.Ar;
                }
                else if (adminLang == 2)
                {
                    culture = Culture.EnglishUSA;
                    Context.Items["LangID"] = Languages.En;
                }
            }
            //-------------------------------------------
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            //-------------------------------------------
        }
        //---------------------------------------------------------------------------------------
    }
}