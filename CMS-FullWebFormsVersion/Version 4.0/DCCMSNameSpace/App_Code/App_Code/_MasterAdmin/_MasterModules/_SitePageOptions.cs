using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
namespace DCCMSNameSpace
{

    public class SitePageOptions : ItemsModulesOptions
    {


        #region --------------_PageID--------------
        private int _PageID = -1;
        public int PageID
        {
            get { return _PageID; }
            set { _PageID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Title--------------
        private string _Title = "";
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        //------------------------------------------
        #endregion


        #region --------------AddInAdminMenuAutmaticly--------------
        private bool _AddInAdminMenuAutmaticly;
        public bool AddInAdminMenuAutmaticly
        {
            get { return _AddInAdminMenuAutmaticly; }
            set { _AddInAdminMenuAutmaticly = value; }
        }
        //------------------------------------------
        #endregion
        public SitePageOptions()
        {
            ModuleType = ModuleTypes.StaticPages;
        }
        public static SitePageOptions GetPage(int pageID)
        {
            return SiteModulesManager.Instance.GetPage(pageID);
        }


    }
    
       

    

    

    
}