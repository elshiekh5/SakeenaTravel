using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;



namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for SiteDesign
    /// </summary>

    //--------------------------------------------------
    public class SiteDesign
    {
        #region --------------MasterDesignFolder--------------
        public static string MasterDesignFolder
        {
            get { return SiteSettings.Site_WebsiteDesignFolder; }

        }
        //------------------------------------------
        #endregion


        #region --------------DesignFolder--------------
        public static string DesignFolder
        {
            get { return GetSiteDeignFolder(); }

        }
        //------------------------------------------
        #endregion

        #region --------------PagesFolderName--------------
        public static string PagesFolderName
        {
            get { return "website"; }

        }
        //------------------------------------------
        #endregion

      
        #region --------------MastersFolder--------------
        public static string MastersFolder
        {
            get
            {
                return  "/WebSite/_Masters/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------MastersInterface--------------
        public static string MastersInterface
        {
            get
            {
                return "/WebSite/_Assets/Interface/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------LangaugeFolder--------------
        public static string LangaugeFolder
        {
            get
            {

                Languages currentLang = SiteSettings.GetCurrentLanguage();
                return "/WebSite/_Assets/Interface/" + currentLang.ToString() + "/";

            }
        }
        //------------------------------------------
        #endregion

        #region --------------DefaultLangFolder--------------
        public static string DefaultLangFolder
        {
            get
            {
                if (SiteSettings.Site_HasMultiLanguageDesign)
                {
                    Languages currentLang = (Languages)SiteSettings.Languages_DefaultLanguageID;
                    return MastersInterface + currentLang.ToString() + "/";
                }
                else
                {
                    return MastersInterface;

                }
            }
        }
        //------------------------------------------
        #endregion

        #region --------------LangImageFolder--------------
        public static string LangImageFolder
        {
            get
            {
                return LangaugeFolder + "images/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------ImagesFolder--------------
        public static string ImagesFolder
        {
            get
            {

                return LangImageFolder;
            }
        }
        //------------------------------------------
        #endregion

        #region --------------FlashFolder--------------
        public static string FlashFolder
        {
            get
            {
                return LangaugeFolder + "Flash/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------DefaultLangImageFolder--------------
        public static string DefaultLangImageFolder
        {
            get
            {
                return DefaultLangFolder + "images/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------CssFolder--------------
        public static string CssFolder
        {
            get
            {
                return LangaugeFolder + "Css/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Icons--------------
        public static string GeneralIcons
        {
            get
            {
                return SiteDesign.ImagesFolder + "Icons/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Buttons--------------
        public static string Buttons
        {
            get
            {
                return SiteDesign.ImagesFolder + "Inner/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------Pager--------------
        public static string Pager
        {
            get
            {
                return SiteDesign.ImagesFolder + "Pager/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------NoPhotoPath--------------
        public static string NoPhotoPath
        {
            get
            {
                return ImagesFolder + "no-photo.jpg";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------EmailTemplateFolder--------------
        public static string EmailTemplateFolder
        {
            get
            {
                return SitesHandler.GetSiteDomain() + ImagesFolder + "Inner/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------EmailTemplateFile--------------
        public static string EmailTemplateFile
        {
            get
            {
                return "/WebSite/_Assets/Interface/html/EmailDesign.htm";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------AdminImagesFolder--------------
        public static string AdminImagesFolder
        {
            get
            {
                return "/WebSite/_Assets/Interface/Admin/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------XmlFilesFolder--------------
        public static string XmlFilesFolder
        {
            get
            {
                return "/WebSite/_Xml/";
            }
        }
        //------------------------------------------
        #endregion

        #region --------------BaseControls--------------
        public static string BaseControlsFolder
        {
            get { return "/WebSite/_BaseControls/"; }

        }
        //------------------------------------------
        public static string ItemsLists
        {
            get { return "/WebSite/_BaseControls/Lists/Items.ascx"; }

        }
        //------------------------------------------
        public static string CategoriesLists
        {
            get { return "/WebSite/_BaseControls/Lists/Categories.ascx"; }

        }
        //------------------------------------------
        public static string MessagesLists
        {
            get { return "/WebSite/_BaseControls/Lists/Messages.ascx"; }

        }
        //------------------------------------------
        public static string SubSiteItemsLists
        {
            get { return "/WebSite/_BaseControls/Lists/SubSiteItems.ascx"; }

        }
        //------------------------------------------
        public static string SiteUsersLists
        {
            get { return "/WebSite/_BaseControls/Lists/SiteUsers.ascx"; }

        }
        //------------------------------------------
        public static string SiteUsersUrlsLists
        {
            get { return "/WebSite/_BaseControls/Lists/SiteUsersUrls.ascx"; }

        }
        //------------------------------------------
        #endregion
        //----------------------------------------------------------------------------------
        public static string GetSiteDeignFolder()
        {

            return SiteSettings.Site_WebsiteDesignFolder;
        }
        //----------------------------------------------------------------------------------
        public static int GetInnreWidth()
        {
            return SiteSettings.SiteInterface_InnerWebsiteWidth;
         
        }
        //----------------------------------------------------------------------------------
    }
}