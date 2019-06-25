using System;


using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Drawing;
using System.IO;

namespace DCCMSNameSpace.ReadyUserControls
{
    /// <summary>
    /// Summary description for ItemsGetAllBaseControl
    /// </summary>
    public class Items_GetAllBaseXml : ReadyUserControls.XmlBaseUserControl
    {
        #region --------------ModuleTypeID--------------
        private int _ModuleTypeID;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------TemplateID--------------
        private string _TemplateID = "dlItems";
        public string TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------OwnerID--------------
        private Guid _OwnerID = SitesHandler.GetOwnerIDAsGuid();
        public Guid OwnerID
        {
            get { return _OwnerID; }
            set { _OwnerID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ListDir--------------
        private string _ListDir = "ltr";
        public string ListDir
        {
            get { return _ListDir; }
            set { _ListDir = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryID--------------
        private int _CategoryID = -1;
        public int CategoryID
        {
            get { return _CategoryID; }
            set { _CategoryID = value; }
        }
        //------------------------------------------
        #endregion

        public ItemsModulesOptions currentModule;
        public DCSiteUrls siteUrls;

        #region ---------------Page_Load---------------
        //-----------------------------------------------
        //Page_Load
        //-----------------------------------------------
        public void Page_Load(object sender, System.EventArgs e)
        {
            //-------------------------------------------------
            currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
            siteUrls = DCSiteUrls.Instance;
            //-------------------------------------------------
            //Prepaare user control
            CatchControls();
            Prepare();
            //-------------------------------------------------
            //-------------------------------------------------
            if (!IsPostBack)
            {
                PrepareBuffer();
                LoadData();
            }
        }
        //-----------------------------------------------
        #endregion

        //-----------------------------------------------------------
        protected void CatchControls()
        {
           
        }
        //-----------------------------------------------------------

        #region --------------LoadData--------------
        //---------------------------------------------------------
        //LoadData
        //---------------------------------------------------------
        public void LoadData()
        {

            List<ItemsEntity> itemsList = ItemsFactory.GetAll(ModuleTypeID, CategoryID, true, OwnerID);
            Repeater r = (Repeater)this.FindControl(TemplateID);
            if (itemsList != null && itemsList.Count > 0)
            {
                r.DataSource = itemsList;
                r.DataBind();
            }
        }
        //--------------------------------------------------------
        #endregion

        public bool CheckUrl(object _url)
        {
            string url = _url.ToString();
            return !string.IsNullOrEmpty(url);
        }
        public bool CheckFile(object VideoExtension)
        {
            if (!string.IsNullOrEmpty((string)VideoExtension))
                return true;
            else
                return false;
        }
        public bool CheckYouTube(object VideoExtension, object YouTubeCode)
        {
            if (string.IsNullOrEmpty((string)VideoExtension) && !string.IsNullOrEmpty((string)YouTubeCode))
                return true;
            else
                return false;
        }
        public bool CheckSwf(object Extension, object RequiredExtension)
        {
            string exten = (string)Extension;
            string rExten = (string)RequiredExtension;
            if (exten.ToLower() == rExten.ToLower())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        public string GetPureExtension(object Extension)
        {
            if (!string.IsNullOrEmpty(Extension.ToString()))
                return Extension.ToString().Remove(0, 1);
            else
                return "---";
        }
    }
}