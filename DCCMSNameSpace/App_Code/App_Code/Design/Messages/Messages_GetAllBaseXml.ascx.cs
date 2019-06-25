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
    public class Messages_GetAllBaseXml : ReadyUserControls.XmlBaseUserControl
    {
        #region --------------ModuleTypeID--------------
        //------------------------------------------
        //ModuleTypeID
        //------------------------------------------
        private int _ModuleTypeID;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
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

        #region --------------ToItemID--------------
        private int _ToItemID;
        public int ToItemID
        {
            get { return _ToItemID; }
            set { _ToItemID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Type--------------
        private int _Type = 0;
        public int Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        //------------------------------------------
        #endregion
        
        #region --------------CategoryID--------------
    private int _CategoryID=-1;
    public int CategoryID
    {
        get { return _CategoryID; }
        set { _CategoryID = value; }
    }
    //------------------------------------------
    #endregion
    
        #region --------------TemplateID--------------
        private string _TemplateID = "dlMsgs";
        public string TemplateID
        {
            get { return _TemplateID; }
            set { _TemplateID = value; }
        }
        //------------------------------------------
        #endregion
        //-----------------------------------------------
        MessagesModuleOptions currentModule;
        public DCSiteUrls siteUrls;
        //-----------------------------------------------
        #region ---------------Page_Load---------------
        //-----------------------------------------------
        //Page_Load
        //-----------------------------------------------
        public void Page_Load(object sender, System.EventArgs e)
        {
            //-------------------------------------------------
            currentModule = MessagesModuleOptions.GetType(ModuleTypeID);
            siteUrls = DCSiteUrls.Instance;
            //-------------------------------------------------
            //Prepaare user control
            CatchControls();
            Prepare();
            //-------------------------------------------------
            if (!IsPostBack)
            {
                PrepareBuffer();
                FirstLoad();
            }
        }
        //-----------------------------------------------
        #endregion
        //-----------------------------------------------------------
        protected void CatchControls()
        {
        }
        //-----------------------------------------------------------
        #region ---------------FirstLoad---------------
        //-----------------------------------------------
        //FirstLoad
        //-----------------------------------------------
        public void FirstLoad()
        {
            LoadData();
        }
        //-----------------------------------------------
        #endregion
        #region --------------LoadData--------------
        //---------------------------------------------------------
        //LoadData
        //---------------------------------------------------------
        public new void LoadData()
        {
            Languages langID = SiteSettings.GetCurrentLanguage();
            //List<MessagesEntity> msgList = MessagesFactory.GetAvailable(ModuleTypeID, categoryID, langID, Type, ToItemID, pager.CurrentPage, pager.PageSize, out totalRecords, OwnerID, keywords);
            List<MessagesEntity> msgList = MessagesFactory.GetAvailable(ModuleTypeID, CategoryID, langID, Type, ToItemID, OwnerID, "");
            Repeater r = (Repeater)this.FindControl(TemplateID);
            if (msgList != null && msgList.Count > 0)
            {
                r.DataSource = msgList;
                r.DataBind();
            }
        }
        //--------------------------------------------------------
        #endregion

        
        //--------------------------------------------------------------------------------
        public string GetEducationLevelText(object educationLevel)
        {
            string el = educationLevel.ToString();
            if (el != "0")
            {
                return DynamicResource.GetText("Motakhasesen", "EducationLevel_" + el);
            }
            else
            {
                return "";
            }
        }
        //--------------------------------------------------------------------------------
    }

}