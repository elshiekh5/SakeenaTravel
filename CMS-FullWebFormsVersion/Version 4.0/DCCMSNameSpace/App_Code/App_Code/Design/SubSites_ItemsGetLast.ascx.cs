using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DCCMSNameSpace;
namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class SubSites_ItemsGetLast : ReadyUserControls.UserControl
        {
            Repeater rList;
            #region --------------UserRole--------------
            private string _UserRole = "SubAdmins";
            public string UserRole
            {
                get { return _UserRole; }
                set { _UserRole = value; }
            }
            //------------------------------------------
            #endregion
            #region --------------RequiredModule--------------
            private SiteModulesMap _RequiredModule = SiteModulesMap.UnSpecified;
            public SiteModulesMap RequiredModule
            {
                get { return _RequiredModule; }
                set { _RequiredModule = value; }
            }
            //------------------------------------------
            #endregion

            #region --------------ModuleTypeID--------------
            public int ModuleTypeID
            {
                get { return (int)RequiredModule; }
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
            #region --------------CategoryID--------------
            private int _CategoryID=-1;
            public int CategoryID
            {
                get { return _CategoryID; }
                set { _CategoryID = value; }
            }
            //------------------------------------------
            #endregion
            #region --------------ItemsCount--------------
            private int _ItemsCount=1;
            public int ItemsCount
            {
                get { return _ItemsCount; }
                set { _ItemsCount = value; }
            }
            //------------------------------------------
            #endregion
            #region --------------ConditionStatement--------------
            private string _ConditionStatement="";
            public string ConditionStatement
            {
                get { return _ConditionStatement; }
                set { _ConditionStatement = value; }
            }
            //------------------------------------------
            #endregion
            //-------------------------------------------------------
            UsersDataGlobalOptions currentModule;
            //-------------------------------------------------------
            #region ---------------Page_Load---------------
            //-----------------------------------------------
            //Page_Load
            //-----------------------------------------------
            private void Page_Load(object sender, System.EventArgs e)
            {
                //-------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                if (!IsPostBack)
                {
                    LoadData();
                }
            }
            //-----------------------------------------------
            #endregion

            #region ---------------CatchControls---------------
            //-----------------------------------------------
            //CatchControls
            //-----------------------------------------------
            protected void CatchControls()
            {
                rList = (Repeater)this.FindControl("rList");
            }
            //-----------------------------------------------
            #endregion

            #region --------------LoadData--------------
            //---------------------------------------------------------
            //LoadData
            //---------------------------------------------------------
            private void LoadData()
            {
                Languages langID = SiteSettings.GetCurrentLanguage();
                //--------------------------------------------------------------------
                //--------------------------------------------------------------------
                List<UsersDataEntity> usersDataList;
                usersDataList = UsersDataFactory.GetLast(ModuleTypeID, CategoryID, langID, ConditionStatement, UserRole, OwnerID, ItemsCount);

                if (usersDataList != null && usersDataList.Count > 0)
                {
                    rList.DataSource = usersDataList;
                    rList.DataBind();
                    rList.Visible = true;
                }
                else
                {
                    this.Visible = false;
                }
            }
            //--------------------------------------------------------
            #endregion

        }
    }
}