using System;using DCCMSNameSpace;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Drawing;
namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        /// <summary>
        /// Summary description for ItemsGetAllBaseControl
        /// </summary>
        public class UsersData_GetAllBaseXml : ReadyUserControls.XmlBaseUserControl
        {
            #region --------------UserRole--------------
            private string _UserRole = "";
            public string UserRole
            {
                get { return _UserRole; }
                set { _UserRole = value; }
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

            //-------------------------------------------------------
            #region --------------ModuleTypeID--------------
            private int _ModuleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
            public int ModuleTypeID
            {
                get { return _ModuleTypeID; }
                set { _ModuleTypeID = value; }
            }
            //------------------------------------------
            #endregion
            //-------------------------------------------------------
            #region --------------TemplateID--------------
            private string _TemplateID = "dlUsers";
            public string TemplateID
            {
                get { return _TemplateID; }
                set { _TemplateID = value; }
            }
            //------------------------------------------
            #endregion
            //-------------------------------------------------------
            #region --------------CategoryID--------------
            private int _CategoryID = -1;
            public int CategoryID
            {
                get { return _CategoryID; }
                set { _CategoryID = value; }
            }
            //------------------------------------------
            #endregion
            //-------------------------------------------------------
            UsersDataGlobalOptions currentModule;
            public DCSiteUrls siteUrls;
            //-------------------------------------------------------
            #region ---------------Page_Load---------------
            //-----------------------------------------------
            //Page_Load
            //-----------------------------------------------
            private void Page_Load(object sender, System.EventArgs e)
            {
                currentModule = UsersDataGlobalOptions.GetType(ModuleTypeID);
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
            private void LoadData()
            {
                //--------------------------------------------------------------------
                Languages langID = SiteSettings.GetCurrentLanguage();
                //--------------------------------------------------------------------
                //List<UsersDataEntity> usersDataList = UsersDataFactory.GetAll(ModuleTypeID, categoryID, langID, "", UserRole, pager.CurrentPage, pager.PageSize, out totalRecords, OwnerID, true, keywords);
                int totalRecords = 0;
                List<UsersDataEntity> usersDataList = UsersDataFactory.GetAll(ModuleTypeID, CategoryID, langID, "", UserRole, -1, -1, out totalRecords, OwnerID, true, "");
                Repeater r = (Repeater)this.FindControl(TemplateID);
                if (usersDataList != null && usersDataList.Count > 0)
                {
                    r.DataSource = usersDataList;
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
        }
    }
}