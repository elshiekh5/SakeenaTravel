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
using DCCMSNameSpace;


namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class Messages_GetLast : ReadyUserControls.UserControl
        {
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

            #region --------------ItemsCount--------------
            private int _ItemsCount=1;
            public int ItemsCount
            {
                get { return _ItemsCount; }
                set { _ItemsCount = value; }
            }
            //------------------------------------------
            #endregion

            #region ---------------Page_Load---------------
            //-----------------------------------------------
            //Page_Load
            //-----------------------------------------------
            public void Page_Load(object sender, System.EventArgs e)
            {
                Prepare();
                LoadData();
            }
            //-----------------------------------------------
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

            #region --------------LoadData--------------
            //---------------------------------------------------------
            //LoadData
            //---------------------------------------------------------
            public void LoadData()
            {
                List<MessagesEntity> msgsList = MessagesFactory.GetLast(ModuleTypeID, ItemsCount, OwnerID);
                Repeater rList = (Repeater)this.FindControl("rList");
                //----------------------------------

                if (msgsList != null && msgsList.Count > 0 && rList != null)
                {
                    //-----------------------------------------
                    rList.DataSource = msgsList;
                    rList.DataBind();
                    rList.Visible = true;
                    //-----------------------------------------
                }
                else
                {
                    rList.Visible = false;
                }
            }
            //--------------------------------------------------------
            #endregion



        }

    }
}