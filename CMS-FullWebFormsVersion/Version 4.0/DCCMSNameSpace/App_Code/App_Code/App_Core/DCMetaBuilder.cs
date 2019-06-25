using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using System.Web;

namespace DCCMSNameSpace
{

    /// <summary>
    /// Summary description for DCMetaBuilder
    /// </summary>
    public class DCMetaBuilder
    {
        #region -----------------Instance-----------------
        private static DCMetaBuilder _Instance = null;
        public static DCMetaBuilder Instance
        {
            get
            {
                HttpContext context = HttpContext.Current;
                if (context.Items["DCMetaBuilder"] == null)
                {
                    context.Items["DCMetaBuilder"] = new DCMetaBuilder(); 
                }
                _Instance = (DCMetaBuilder)context.Items["DCMetaBuilder"];

                return _Instance;
            }
        }
        #endregion

        #region -----------------ContentType-----------------
        private string _ContentType = SiteTextsManager.Instance.ContentType.Trim();
        public string ContentType
        {
            get
            {
                return _ContentType;
            }
            set
            {
                _ContentType = value;
            }
        }
        #endregion

        #region -----------------ContentLanguage-----------------
        private string _ContentLanguage = SiteTextsManager.Instance.ContentLanguage.Trim();
        public string ContentLanguage
        {
            get
            {
                return _ContentLanguage;
            }
            set
            {
                _ContentLanguage = value;
            }
        }
        #endregion

        #region -----------------GlobalLastModification-----------------
        private string _GlobalLastModification = "";
        public string GlobalLastModification
        {
            get
            {
                return _GlobalLastModification;
            }
            set
            {
                _GlobalLastModification = value;
            }
        }
        #endregion

        #region -----------------Robots-----------------
        private string _Robots = "index,follow";
        public string Robots
        {
            get
            {
                return _Robots;
            }
            set
            {
                _Robots = value;
            }
        }
        #endregion

        #region -----------------GoogleBot-----------------
        private string _GoogleBot = "noarchive";
        public string GoogleBot
        {
            get
            {
                return _GoogleBot;
            }
            set
            {
                _GoogleBot = value;
            }
        }
        #endregion

        #region -----------------ViewPort-----------------
        private string _ViewPort = "";
        public string ViewPort
        {
            get
            {
                return _ViewPort;
            }
            set
            {
                _ViewPort = value;
            }
        }
        #endregion

        #region -----------------Medium-----------------
        private string _Medium = "";
        public string Medium
        {
            get
            {
                return _Medium;
            }
            set
            {
                _Medium = value;
            }
        }
        #endregion

        #region -----------------Title-----------------
        private string _Title = "";
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }
        #endregion

        #region -----------------Description-----------------
        private string _Description = "";
        public string Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        #endregion

        #region -----------------Keywords-----------------
        private string _Keywords = "";
        public string Keywords
        {
            get
            {
                return _Keywords;
            }
            set
            {
                _Keywords = value;
            }
        }
        #endregion

        #region -----------------Author-----------------
        private string _Author = "";
        public string Author
        {
            get
            {
                return _Author;
            }
            set
            {
                _Author = value;
            }
        }
        #endregion

        #region -----------------Section-----------------
        private string _Section = "";
        public string Section
        {
            get
            {
                return _Section;
            }
            set
            {
                _Section = value;
            }
        }
        #endregion

        #region -----------------SubSection-----------------
        private string _SubSection = "";
        public string SubSection
        {
            get
            {
                return _SubSection;
            }
            set
            {
                _SubSection = value;
            }
        }
        #endregion

        #region -----------------PubDate-----------------
        private string _PubDate = "";
        public string PubDate
        {
            get
            {
                return _PubDate;
            }
            set
            {
                _PubDate = value;
            }
        }
        #endregion

        #region -----------------LastModification-----------------
        private string _LastModification = "";
        public string LastModification
        {
            get
            {
                return _LastModification;
            }
            set
            {
                _LastModification = value;
            }
        }
        #endregion

        #region -----------------Source-----------------
        private string _Source = "";
        public string Source
        {
            get
            {
                return _Source;
            }
            set
            {
                _Source = value;
            }
        }
        #endregion
        

        public DCMetaBuilder()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region -----------------BuildMetaTags-----------------
        //--------------------------------------------------------------------------------
        //BuildMetaTags
        //--------------------------------------------------------------------------------
        public void BuildMetaTags(System.Web.UI.Page page)
        {
            HtmlMeta newMeta = null;
            int i = 1;

            //-------------------------------------------------
            //ContentType
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(ContentType))
            {
                newMeta = BuildSingleMeta("", "content-type", ContentType);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //ContentLanguage
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(ContentLanguage))
            {
                newMeta = BuildSingleMeta("", "content-language", ContentLanguage);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //GlobalLastModification
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(GlobalLastModification))
            {
                newMeta = BuildSingleMeta("", "last-modified", GlobalLastModification);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //Robots
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(Robots))
            {
                newMeta = BuildSingleMeta("robots", "", Robots);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //GoogleBot
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(GoogleBot))
            {
                newMeta = BuildSingleMeta("googlebot", "", GoogleBot);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //ViewPort
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(ViewPort))
            {
                newMeta = BuildSingleMeta("viewport", "", ViewPort);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //Medium
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(Medium))
            {
                newMeta = BuildSingleMeta("medium", "", Medium);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //Title
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(Title))
            {
                newMeta = BuildSingleMeta("title", "", Title);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //Keywords
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(Keywords))
            {
                newMeta = BuildSingleMeta("keywords", "", Keywords);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //Description
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(Description))
            {
                newMeta = BuildSingleMeta("description", "", Description);
                page.Header.Controls.AddAt(i++, newMeta);
            }
            //-------------------------------------------------
            //Author
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(Author))
            {
                newMeta = BuildSingleMeta("author", "", Author);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //Section
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(Section))
            {
                newMeta = BuildSingleMeta("section", "", Section);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //SubSection
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(SubSection))
            {
                newMeta = BuildSingleMeta("subsection", "", SubSection);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //PubDate
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(PubDate))
            {
                newMeta = BuildSingleMeta("pubdate", "", PubDate);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //LastModification
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(LastModification))
            {
                newMeta = BuildSingleMeta("lastmod", "", LastModification);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------
            //Source
            //-------------------------------------------------
            if (!string.IsNullOrEmpty(Source))
            {
                newMeta = BuildSingleMeta("source", "", Source);
                page.Header.Controls.AddAt(i++,newMeta);
            }
            //-------------------------------------------------

        }
        //--------------------------------------------------------------------------------
        #endregion
        //--------------------------------------------------------------------------------
        #region --------------------------InisializePageMetaTags----------------------------
        //----------------------------------------------------------------------------
        //InisializePageMetaTags
        //----------------------------------------------------------------------------
        private HtmlMeta BuildSingleMeta(string name, string httpEquiv, string content)
        {
            HtmlMeta newMeta = new HtmlMeta();
            newMeta.Name = name;
            newMeta.Content = content;
            newMeta.HttpEquiv = httpEquiv;
            return newMeta;

        }
        //--------------------------------------------------------------------------------
        #endregion

        #region --------------------------InisializeItemModulesMetaTags----------------------------
        //----------------------------------------------------------------------------
        //InisializeItemModulesMetaTags
        //----------------------------------------------------------------------------
        public static void InisializeItemModulesMetaTags(ItemsModulesOptions currentModule)
        {
            DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
            string moduleTitle = currentModule.GetModuleTitle();
            metaBuilder.Title = moduleTitle;
            metaBuilder.Section = currentModule.GetModuleTitle();
            metaBuilder.Keywords = currentModule.ModuleMetaKeyWords;
            metaBuilder.Description = currentModule.ModuleMetaDescription;
            metaBuilder.GlobalLastModification = SiteSettings.Site_LastModification;
        }
        //----------------------------------------------------------------------------
        #endregion

        #region --------------------------InisializeMessageModulesMetaTags----------------------------
        //----------------------------------------------------------------------------
        //InisializeMessageModulesMetaTags
        //----------------------------------------------------------------------------
        public static void InisializeMessageModulesMetaTags(MessagesModuleOptions currentModule)
        {
            DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
            string moduleTitle = currentModule.GetModuleTitle();
            metaBuilder.Title = moduleTitle;
            metaBuilder.Section = currentModule.GetModuleTitle();
            metaBuilder.Keywords = currentModule.ModuleMetaKeyWords;
            metaBuilder.Description = currentModule.ModuleMetaDescription;
            metaBuilder.GlobalLastModification = SiteSettings.Site_LastModification;
        }
        //----------------------------------------------------------------------------
        #endregion



        #region --------------------------InisializeUsersDataModuleMetaTags----------------------------
        //----------------------------------------------------------------------------
        //InisializeUsersDataModuleMetaTags
        //----------------------------------------------------------------------------
        public static void InisializeUsersDataModuleMetaTags(UsersDataGlobalOptions currentModule)
        {
            DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
            string moduleTitle = currentModule.GetModuleTitle();
            metaBuilder.Title = moduleTitle;
            metaBuilder.Section = currentModule.GetModuleTitle();
            metaBuilder.Keywords = currentModule.ModuleMetaKeyWords;
            metaBuilder.Description = currentModule.ModuleMetaDescription;
            metaBuilder.GlobalLastModification = SiteSettings.Site_LastModification;
        }
        //----------------------------------------------------------------------------
        #endregion

        #region --------------------------InisializeMetaTags----------------------------
        //----------------------------------------------------------------------------
        //InisializeMetaTags
        //----------------------------------------------------------------------------
        public static void InisializeMetaTags()
        {
            //------------------------------------------------------
            DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
            metaBuilder.GlobalLastModification = SiteSettings.Site_LastModification;
            metaBuilder.Keywords = SiteTextsManager.Instance.KeyWords.Trim();
            metaBuilder.Description = SiteTextsManager.Instance.SiteDescription.Trim(); 
            //------------------------------------------------------
        }
        //----------------------------------------------------------------------------
        #endregion


        #region --------------------------SetMetaTags----------------------------
        //----------------------------------------------------------------------------
        //SetMetaTags
        //----------------------------------------------------------------------------
        public static void SetMetaTags(ItemsEntity item)
        {
            DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
            string siteName = SiteTextsManager.Instance.SiteName.Trim();
            //------------------------------------------------------------
            metaBuilder.Title = item.Title;
            //------------------------------------------------------------
            if (!string.IsNullOrEmpty(item.KeyWords))
                metaBuilder.Keywords = item.KeyWords;
            //------------------------------------------------------------
            if (!string.IsNullOrEmpty(item.ShortDescription))
                metaBuilder.Description = item.ShortDescription;
            //------------------------------------------------------------
            if (!string.IsNullOrEmpty(item.AuthorName))
                metaBuilder.Author = item.AuthorName + " , " + siteName;
            //------------------------------------------------------------
            metaBuilder.PubDate = item.Date_Added.ToUniversalTime().ToString();
            //------------------------------------------------------------
            metaBuilder.LastModification = item.LastModification.ToUniversalTime().ToString();
            //------------------------------------------------------------
            metaBuilder.Source = siteName;
            //------------------------------------------------------------
        }
        //----------------------------------------------------------------------------
        #endregion



        #region --------------------------SetMetaTags----------------------------
        //----------------------------------------------------------------------------
        //SetMetaTags
        //----------------------------------------------------------------------------
        public static void SetMetaTags(ItemCategoriesEntity category)
        {
            DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
            //------------------------------------------------------------
            metaBuilder.Title = category.Title;
            //------------------------------------------------------------
            if (!string.IsNullOrEmpty(category.KeyWords))
                metaBuilder.Keywords = category.KeyWords;
            //------------------------------------------------------------
            if (!string.IsNullOrEmpty(category.ShortDescription))
                metaBuilder.Description = category.ShortDescription;
            //------------------------------------------------------------
            metaBuilder.SubSection = category.Title;
            //------------------------------------------------------------
            metaBuilder.LastModification = category.LastModification.ToUniversalTime().ToString();
            //------------------------------------------------------------
        }
        //----------------------------------------------------------------------------
        #endregion

        #region --------------------------SetMetaTags----------------------------
        //----------------------------------------------------------------------------
        //SetMetaTags
        //----------------------------------------------------------------------------
        public static void SetMetaTags(MessagesEntity msg)
        {
            DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
            string siteName = SiteTextsManager.Instance.SiteName.Trim();
            //------------------------------------------------------------
            metaBuilder.Title = msg.Title;
            //------------------------------------------------------------
            if (!string.IsNullOrEmpty(msg.KeyWords))
                metaBuilder.Keywords = msg.KeyWords;
            //------------------------------------------------------------
            if (!string.IsNullOrEmpty(msg.ShortDescription))
                metaBuilder.Description = msg.ShortDescription;
            //------------------------------------------------------------
            if (!string.IsNullOrEmpty(msg.Name))
                metaBuilder.Author = msg.Name + " , " + siteName;
            //------------------------------------------------------------
            metaBuilder.PubDate = msg.Date_Added.ToUniversalTime().ToString();
            //------------------------------------------------------------
            metaBuilder.LastModification = msg.LastModification.ToUniversalTime().ToString();
            //------------------------------------------------------------
            metaBuilder.Source = siteName;
            //------------------------------------------------------------
        }
        //----------------------------------------------------------------------------
        #endregion

        #region --------------------------SetMetaTags----------------------------
        //----------------------------------------------------------------------------
        //SetMetaTags
        //----------------------------------------------------------------------------
        public static void SetMetaTags(SiteDeparmentsEntity siteDepartment)
        {
            DCMetaBuilder metaBuilder = DCMetaBuilder.Instance;
            string siteName = SiteTextsManager.Instance.SiteName.Trim();
            //------------------------------------------------------------
            metaBuilder.Title = siteDepartment.Title;
            //------------------------------------------------------------
            if (!string.IsNullOrEmpty(siteDepartment.KeyWords))
                metaBuilder.Keywords = siteDepartment.KeyWords;
            //------------------------------------------------------------
            if (!string.IsNullOrEmpty(siteDepartment.ShortDescription))
                metaBuilder.Description = siteDepartment.ShortDescription;
            //------------------------------------------------------------
            metaBuilder.Author = siteName;
            //------------------------------------------------------------
            metaBuilder.PubDate = siteDepartment.Date_Added.ToUniversalTime().ToString();
            //------------------------------------------------------------
            metaBuilder.LastModification = siteDepartment.LastModification.ToUniversalTime().ToString();
            //------------------------------------------------------------
            metaBuilder.Source = siteName;
            //------------------------------------------------------------
        }
        //----------------------------------------------------------------------------
        #endregion

    }






}