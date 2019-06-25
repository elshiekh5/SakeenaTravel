using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Threading;
using System.Globalization;
using DCCMSNameSpace;
using System.IO;


namespace DCCMSNameSpace
{
    //using DCCMSNameSpace.Utilities;

    /// <summary>
    /// Summary description for LangSettingsModule
    /// </summary>
    public class DCModuleHandler : IHttpModule
    {
        //---------------------------------------
        public HttpContext Context 
        {
            get { return HttpContext.Current; }
        }
        //---------------------------------------
        public DCModuleHandler()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region IHttpModule Members

        void IHttpModule.Dispose()
        {

        }

        void IHttpModule.Init(HttpApplication app)
        {
            app.BeginRequest += new EventHandler(context_BeginRequest);
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            string newPath = Context.Request.RawUrl;
            HandleCurrentLanguage();
            DCMetaBuilder.InisializeMetaTags();
            DCSiteUrls urls = DCSiteUrls.Instance;
            urls.ReWriteUrl();
            //DCCMSNameSpace.SubSiteHandler.IncreaseSubSiteVisites();

            //RewriteUrl();
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

        #endregion
    }
}