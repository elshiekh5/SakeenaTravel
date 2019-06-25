using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);



        }
        void Application_AcquireRequestState(object sender, EventArgs e)
        {
            // Session is Available here
            HttpContext context = HttpContext.Current;
            HandleCurrentLanguage();
        }
        //---------------------------------------------------------------------------------------
        void HandleCurrentLanguage()
        {
            //HttpApplication Context = (HttpApplication)sender;
            //-----------------------------------------------------------------
            Languages lang = (Languages)SiteSettings.Languages_DefaultLanguageID;
            string culture = "";
            string languageString = "";
            string cookie_name = SiteSettings.Site_CookieName;
            if (Context.Request.Cookies[cookie_name] != null)
            {
                HttpCookie cookie = Context.Request.Cookies[cookie_name];
                languageString = cookie["lang"].ToLower();
                switch (languageString)
                {
                    case "ar":
                        lang = Languages.Ar;
                        break;
                    case "en":
                        lang = Languages.En;
                        break;
                    default:
                        break;
                }
            }
            //-------------------------------------------
            switch (lang)
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
            //-------------------------------------------
            System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo(culture);
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            //-------------------------------------------
        }
        //---------------------------------------------------------------------------------------
    }
}
