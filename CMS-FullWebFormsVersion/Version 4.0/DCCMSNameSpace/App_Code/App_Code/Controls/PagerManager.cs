using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MoversFW;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for PagerManager
    /// </summary>
    public class PagerManager
    {
        public static void PrepareUserPager(OurPager pgr)
        {
            Languages pagerLanguage = SiteSettings.GetCurrentLanguage();

            pgr.CurrentPageCss = "Pager-Active";
            if (pagerLanguage != Languages.Ar)
                pgr.Dir = MoversFW.OurPager.Direction.ltr;
            else
                pgr.Dir = MoversFW.OurPager.Direction.rtl;

            //FristLinkActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.FristLinkActiveImageUrl = SiteDesign.Pager + "FirstEnable.gif";
            else
                pgr.FristLinkActiveImageUrl = SiteDesign.Pager + "LastEnable.gif";
            //FristLinkInActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.FristLinkInActiveImageUrl = SiteDesign.Pager + "FirstDisable.gif";
            else
                pgr.FristLinkInActiveImageUrl = SiteDesign.Pager + "LastDisable.gif";
            //
            pgr.FristLinkText = DynamicResource.GetText("User","PagerFrist");
            //-------------------------------------
            pgr.ImageClass = "PagerImage";
            //NextLinkText
            pgr.NextLinkText = DynamicResource.GetText("User","PagerNext");
            //NextLinkActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.NextLinkActiveImageUrl = SiteDesign.Pager + "NextEnable.gif";
            else
                pgr.NextLinkActiveImageUrl = SiteDesign.Pager + "PreviousEnable.gif";
            //NextLinkInActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.NextLinkInActiveImageUrl = SiteDesign.Pager + "NextDisable.gif";
            else
                pgr.NextLinkInActiveImageUrl = SiteDesign.Pager + "PreviousDisable.gif";
            //--------------------------------------
            //LastLinkText
            pgr.LastLinkText = DynamicResource.GetText("User","PagerLast");
            //LastLinkActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.LastLinkActiveImageUrl = SiteDesign.Pager + "LastEnable.gif";
            else
                pgr.LastLinkActiveImageUrl = SiteDesign.Pager + "FirstEnable.gif";
            //
            if (pagerLanguage != Languages.Ar)
                pgr.LastLinkInActiveImageUrl = SiteDesign.Pager + "LastDisable.gif";
            else
                pgr.LastLinkInActiveImageUrl = SiteDesign.Pager + "FirstDisable.gif";
            //--------------------------------------
            //PreviousLinkText
            pgr.PreviousLinkText = DynamicResource.GetText("User","PagerPrevious");
            //PreviousLinkActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.PreviousLinkActiveImageUrl = SiteDesign.Pager + "PreviousEnable.gif";
            else
                pgr.PreviousLinkActiveImageUrl = SiteDesign.Pager + "NextEnable.gif";
            //PreviousLinkInActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.PreviousLinkInActiveImageUrl = SiteDesign.Pager + "PreviousDisable.gif";
            else
                pgr.PreviousLinkInActiveImageUrl = SiteDesign.Pager + "NextDisable.gif";
            //--------------------------------------


            //Details
            pgr.TextCss = "PagerText";
            pgr.FromText = DynamicResource.GetText("User","PagerFrom");
            pgr.PageNoText = DynamicResource.GetText("User", "PagerPageNO");
        }
        public static void PrepareAdminPager(OurPager pgr)
        {
            //Languages pagerLanguage = (Languages)ResourceManager.GetCurrentLanguage();
            Languages pagerLanguage = Languages.Ar;

            pgr.CurrentPageCss = "Pager-Active";
            if (pagerLanguage != Languages.Ar)
                pgr.Dir = MoversFW.OurPager.Direction.ltr;
            else
                pgr.Dir = MoversFW.OurPager.Direction.rtl;

            //FristLinkActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.FristLinkActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/FirstEnable.gif";
            else
                pgr.FristLinkActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/LastEnable.gif";
            //FristLinkInActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.FristLinkInActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/FirstDisable.gif";
            else
                pgr.FristLinkInActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/LastDisable.gif";
            //
            pgr.FristLinkText = DynamicResource.GetText("AdminText","PagerFrist");
            //-------------------------------------
            pgr.ImageClass = "PagerImage";
            //NextLinkText
            pgr.NextLinkText = DynamicResource.GetText("AdminText","PagerNext");
            //NextLinkActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.NextLinkActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/NextEnable.gif";
            else
                pgr.NextLinkActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/PreviousEnable.gif";
            //NextLinkInActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.NextLinkInActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/NextDisable.gif";
            else
                pgr.NextLinkInActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/PreviousDisable.gif";
            //--------------------------------------
            //LastLinkText
            pgr.LastLinkText = DynamicResource.GetText("AdminText","PagerLast");
            //LastLinkActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.LastLinkActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/LastEnable.gif";
            else
                pgr.LastLinkActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/FirstEnable.gif";
            //
            if (pagerLanguage != Languages.Ar)
                pgr.LastLinkInActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/LastDisable.gif";
            else
                pgr.LastLinkInActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/FirstDisable.gif";
            //--------------------------------------
            //PreviousLinkText
            pgr.PreviousLinkText = DynamicResource.GetText("AdminText","PagerPrevious");
            //PreviousLinkActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.PreviousLinkActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/PreviousEnable.gif";
            else
                pgr.PreviousLinkActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/NextEnable.gif";
            //PreviousLinkInActiveImageUrl
            if (pagerLanguage != Languages.Ar)
                pgr.PreviousLinkInActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/PreviousDisable.gif";
            else
                pgr.PreviousLinkInActiveImageUrl = "/Content/AdminDesign/Ar/css/images/Pager/NextDisable.gif";
            //--------------------------------------


            //Details
            pgr.TextCss = "PagerText";
            pgr.FromText = DynamicResource.GetText("AdminText","PagerFrom");
            pgr.PageNoText = DynamicResource.GetText("AdminText","PagerPageNO");
        }
        public static void PreparePager(Languages pagerLanguage, OurPager pgr)
        {


        }
    }
}







