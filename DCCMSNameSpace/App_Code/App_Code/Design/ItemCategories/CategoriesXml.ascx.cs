using System;using DCCMSNameSpace;
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
    public class ItemCategories_GetAllBaseXml : ReadyUserControls.XmlBaseUserControl
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
        
        #region --------------ParentID--------------
        public int ParentID
        {
            get
            {
                if (MoversFW.Components.UrlManager.ChechIsValidIntegerParameter("id"))
                    return Convert.ToInt32(Request.QueryString["id"]);
                else
                    return 0;
            }
        }
        //------------------------------------------
        #endregion
        #region --------------TemplateID--------------
        private string _TemplateID = "dlCategories";
        public string TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }
        //------------------------------------------
        #endregion
        #region --------------ListDir--------------
        public string ListDir
        {
            get
            {

                Languages langID = SiteSettings.GetCurrentLanguage();
                if (langID == Languages.Ar)
                    return "rtl";
                else
                    return "ltr";
            }
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
        //---------------------------------------------
        public ItemsModulesOptions currentModule;
        public DCSiteUrls siteUrls;
        //---------------------------------------------
        #region ---------------Page_Load---------------
        //-----------------------------------------------
        //Page_Load
        //-----------------------------------------------
        public void Page_Load(object sender, System.EventArgs e)
        {
            //---------------------------------------------
            currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
            siteUrls = DCSiteUrls.Instance;
            //-------------------------------------------------
            //Prepaare user control
            CatchControls();
            Prepare();
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
        public new void LoadData()
        {

            List<ItemCategoriesEntity> categoriesList = ItemCategoriesFactory.GetAll(ModuleTypeID, ParentID, true, OwnerID);
            Repeater r = (Repeater)this.FindControl(TemplateID);
            if (categoriesList != null && categoriesList.Count > 0)
            {
                r.DataSource = categoriesList;
                r.DataBind();
            }
        }

        //--------------------------------------------------------
        #endregion


        


     

    }

}