using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DCCMSNameSpace;



namespace DCCMSNameSpace
{
    namespace ReadyUserControls
    {
        public partial class PageData : ReadyUserControls.UserControl
        {
            #region --------------RequiredPageType--------------
            private SitePages _RequiredPageType;
            public SitePages RequiredPageType
            {
                get { return _RequiredPageType; }
                set { _RequiredPageType = value; }
            }
            //------------------------------------------
            #endregion

            #region --------------PageID--------------
            public int PageID
            {
                get { return (int)RequiredPageType; }
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

            #region --------------RequiredPage--------------
            private ItemsEntity _RequiredPage = null;
            public ItemsEntity RequiredPage
            {
                get { return _RequiredPage; }
                set { _RequiredPage = value; }
            }
            //------------------------------------------
            #endregion

            ItemsModulesOptions currentModule;
            protected void Page_Load(object sender, EventArgs e)
            {
                Prepare();
                LoadItem();
            }
            //-----------------------------------------------------------
            public void LoadItem()
            {
                //------------------------------------------------------------------------
                Languages langID = SiteSettings.GetCurrentLanguage();
                RequiredPage = ItemsFactory.GetObject(PageID, langID, UsersTypes.User, OwnerID);
                if (RequiredPage != null && RequiredPage.IsAvailable)
                {
                    this.Visible = true;
                }
                else
                {

                    this.Visible = false;
                }
                //----------------------------------------------
            }
        }
    }
}