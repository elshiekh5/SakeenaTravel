using System;using DCCMSNameSpace;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using System.Collections.Generic;
namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public class Items_GetLast : ReadyUserControls.UserControl
        {
            Repeater rList;
            //--------------------------------------------------
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
            
            #region --------------ItemsCount--------------
            private int _ItemsCount=1;
            public int ItemsCount
            {
                get { return _ItemsCount; }
                set { _ItemsCount = value; }
            }
            //------------------------------------------
            #endregion

            //--------------------------------------------------
            public ItemsModulesOptions currentModule;
            public DCSiteUrls siteUrls;
            //--------------------------------------------------
            protected void Page_Load(object sender, EventArgs e)
            {
                //---------------------------------------------------
                currentModule = ItemsModulesOptions.GetType(ModuleTypeID);
                siteUrls = DCSiteUrls.Instance;
                //---------------------------------------------------
                //Prepaare user control
                CatchControls();
                Prepare();
                //-------------------------------------------------
                if (!IsPostBack)
                { LoadData(); }
            }
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

            #region ---------------LoadData---------------
            //-----------------------------------------------
            //LoadData
            //-----------------------------------------------
            protected void LoadData()
            {
                List<ItemsEntity> itemsList = ItemsFactory.GetLast(ModuleTypeID, ItemsCount, OwnerID);
                if (itemsList != null && itemsList.Count > 0)
                {
                    rList.DataSource = itemsList;
                    rList.DataBind();
                }
                else
                {
                    this.Visible = false;
                }
            }
            //-----------------------------------------------
            #endregion

            

        }
    }
}