using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DCCMSNameSpace
{
    public class SiteModulesManager
    {

        private Hashtable _AllModules;
        public Hashtable AllModules
        {
            get
            {
                if (_AllModules == null)
                    _AllModules = new Hashtable();
                return _AllModules;
            }
            set { _AllModules = value; }
        }
        //-----------------------------------------------------------------
        private Hashtable _IdentifireAndIDs;
        public Hashtable IdentifireAndIDs
        {
            get
            {
                if (_IdentifireAndIDs == null)
                    _IdentifireAndIDs = new Hashtable();
                return _IdentifireAndIDs;
            }
            set { _IdentifireAndIDs = value; }
        }
        //-----------------------------------------------------------------
        private Hashtable _ItemsModulesKeys;
        public Hashtable ItemsModulesKeys
        {
            get
            {
                if (_ItemsModulesKeys == null)
                    _ItemsModulesKeys = new Hashtable();
                return _ItemsModulesKeys;
            }
            set { _ItemsModulesKeys = value; }
        }
        SiteItemsModulesManager itemsModules = null;
        SiteMessagesModulesManager messagesModules = null;
        SiteUsersDataModulesManager usersModules = null;
        SitePagesManager sitePages = null;

        #region -----------------Instance-----------------
        //-----------------------------------------------------------------
        private static SiteModulesManager _Instance;
        public static SiteModulesManager Instance
        {
            get
            {
                if (HttpContext.Current.Cache["AllModules"] != null)
                    _Instance = (SiteModulesManager)HttpContext.Current.Cache["AllModules"];
                else
                {
                    _Instance = new SiteModulesManager();
                    _Instance.LoadAllModules();
                    //CacheDependency dep = new CacheDependency(path);
                    HttpContext.Current.Cache.Insert("AllModules", _Instance);
                }

                return _Instance;
            }
        }
        #endregion
        //----------------------------------------------------------------- 
        private List<ItemsModulesOptions> _SiteItemsModulesList;
        public List<ItemsModulesOptions> SiteItemsModulesList
        {
            get
            {
                if (_SiteItemsModulesList == null)
                    _SiteItemsModulesList = new List<ItemsModulesOptions>();
                return _SiteItemsModulesList;
            }
            set { _SiteItemsModulesList = value; }
        }
        //-----------------------------------------------------------------
        private List<MessagesModuleOptions> _SiteMessagesModulesList;
        public List<MessagesModuleOptions> SiteMessagesModulesList
        {
            get
            {
                if (_SiteMessagesModulesList == null)
                    _SiteMessagesModulesList = new List<MessagesModuleOptions>();
                return _SiteMessagesModulesList;
            }
            set { _SiteMessagesModulesList = value; }
        }

        private List<UsersDataGlobalOptions> _SiteUsersDataModulesList;
        public List<UsersDataGlobalOptions> SiteUsersDataModulesList
        {
            get
            {
                if (_SiteUsersDataModulesList == null)
                    _SiteUsersDataModulesList = new List<UsersDataGlobalOptions>();
                return _SiteUsersDataModulesList;
            }
            set { _SiteUsersDataModulesList = value; }
        }

        private List<SitePageOptions> _SitePagesList;
        public List<SitePageOptions> SitePagesList
        {
            get
            {
                if (_SitePagesList == null)
                    _SitePagesList = new List<SitePageOptions>();
                return _SitePagesList;
            }
            set { _SitePagesList = value; }
        }


        #region -----------------LoadAllModules-----------------
        //-----------------------------------------------------------------
        public void LoadAllModules()
        {
            AllModules.Clear();
            itemsModules = new SiteItemsModulesManager();
            messagesModules = new SiteMessagesModulesManager();
            usersModules = new SiteUsersDataModulesManager();
            sitePages = new SitePagesManager();
            itemsModules.LoadAllModules(SiteItemsModulesList);
            messagesModules.LoadAllModules(SiteMessagesModulesList);
            usersModules.LoadAllModules(SiteUsersDataModulesList);
            sitePages.LoadAllPages(SitePagesList);
            foreach (ItemsModulesOptions item in SiteItemsModulesList)
            {
                AllModules.Add(item.Identifire.ToLower(), item);
                IdentifireAndIDs.Add(item.ModuleTypeID, item.Identifire);
                //_ItemsModulesKeys.Add(item.Identifire, item.ModuleTypeID);
            }
            foreach (MessagesModuleOptions msg in SiteMessagesModulesList)
            {
                AllModules.Add(msg.Identifire.ToLower(), msg);
                IdentifireAndIDs.Add(msg.ModuleTypeID, msg.Identifire);
            }
            foreach (UsersDataGlobalOptions user in SiteUsersDataModulesList)
            {
                AllModules.Add(user.Identifire.ToLower(), user);
                IdentifireAndIDs.Add(user.ModuleTypeID, user.Identifire);
            }
        }
        #endregion
        //------------------------------------------------------------------
        public MasterModule GetModule(int moduleID)
        {
            if (_IdentifireAndIDs.ContainsKey(moduleID))
            {
                string identifire = (string)_IdentifireAndIDs[moduleID];
                return GetModule(identifire);
            }
            else
                return null;
        }
        //------------------------------------------------------------------
        public MasterModule GetModule(string identifire)
        {
            return (MasterModule)_AllModules[identifire.ToLower()];
        }
        //------------------------------------------------------------------
        public ItemsModulesOptions GetItemsModule(int moduleID)
        {
            if(_IdentifireAndIDs.ContainsKey(moduleID))
            {
                string identifire =(string) _IdentifireAndIDs[moduleID];
                return (ItemsModulesOptions)_AllModules[identifire.ToLower()];
            }
            else
            return new ItemsModulesOptions();
        }
        //------------------------------------------------------------------
        public ItemsModulesOptions GetItemsModule(string moduleIdentifir)
        {
            moduleIdentifir = moduleIdentifir.ToLower();
            if (_AllModules.ContainsKey(moduleIdentifir))
            {
                return (ItemsModulesOptions)_AllModules[moduleIdentifir];
            }
            else
                return new ItemsModulesOptions();
        }
        //------------------------------------------------------------------
        public MessagesModuleOptions GetMessageModule(int moduleID)
        {
            if (_IdentifireAndIDs.ContainsKey(moduleID))
            {
                string identifire = (string)_IdentifireAndIDs[moduleID];
                return (MessagesModuleOptions)_AllModules[identifire.ToLower()];
            }
            else
                return new MessagesModuleOptions();
        }
        //------------------------------------------------------------------
        public MessagesModuleOptions GetMessageModule(string moduleIdentifir)
        {
            moduleIdentifir = moduleIdentifir.ToLower();

            if (_AllModules.ContainsKey(moduleIdentifir))
            {
                return (MessagesModuleOptions)_AllModules[moduleIdentifir];
            }
            else
            {
                return new MessagesModuleOptions();
            }
        }
        //------------------------------------------------------------------
        public UsersDataGlobalOptions GetUserDataModule(int moduleID)
        {
            if (_IdentifireAndIDs.ContainsKey(moduleID))
            {
                string identifire = (string)_IdentifireAndIDs[moduleID];
                return (UsersDataGlobalOptions)_AllModules[identifire.ToLower()];
            }
            else
                return new UsersDataGlobalOptions();




       
        }
        //------------------------------------------------------------------
        public bool SaveModule(ItemsModulesOptions itemsModule)
        {
            return itemsModules.SaveModule(itemsModule);
        }
        //------------------------------------------------------------------
        public bool AddModule(ItemsModulesOptions itemsModule)
        {
            return itemsModules.AddModule(itemsModule);
        }
        //------------------------------------------------------------------
        public bool UpdateModule(ItemsModulesOptions itemsModule)
        {
            return itemsModules.UpdateModule(itemsModule);
        }
        //------------------------------------------------------------------
        public bool DeleteModule(int moduleID)
        {
            bool result = false;
            if(_IdentifireAndIDs.ContainsKey(moduleID))
            {
                string identifire =(string) _IdentifireAndIDs[moduleID];
                MasterModule module = (MasterModule)_AllModules[identifire.ToLower()];
                switch (module.ModuleBaseType)
                {
                    case ModuleBaseTypes.Unknowen:
                        result = false;
                        break;
                    case ModuleBaseTypes.Items:
                        result = itemsModules.DeleteModule(moduleID);
                        break;
                    case ModuleBaseTypes.Messages:
                        result = messagesModules.DeleteModule(moduleID);
                        break;
                    case ModuleBaseTypes.UsersData:
                        result = usersModules.DeleteModule(moduleID);
                        break;
                    case ModuleBaseTypes.Special:
                         result = false;
                        break;
                    default:
                         result = false;
                        break;
                }
            }
            return result;
            
            
            
        }
        //*********************************
        //*********************************
        //*********************************
        //------------------------------------------------------------------
        public bool SaveModule(MessagesModuleOptions messagesModule)
        {
            return messagesModules.SaveModule(messagesModule);
        }
        //------------------------------------------------------------------
        public bool AddModule(MessagesModuleOptions messagesModule)
        {
            return messagesModules.AddModule(messagesModule);
        }
        //------------------------------------------------------------------
        public bool UpdateModule(MessagesModuleOptions messagesModule)
        {
            return messagesModules.UpdateModule(messagesModule);
        }
        //------------------------------------------------------------------
        //*********************************
        //*********************************
        //********************************* //------------------------------------------------------------------
        public bool SaveModule(UsersDataGlobalOptions usersDataModule)
        {
            return usersModules.SaveModule(usersDataModule);
        }
        //------------------------------------------------------------------
        public bool AddModule(UsersDataGlobalOptions usersDataModule)
        {
            return usersModules.AddModule(usersDataModule);
        }
        //------------------------------------------------------------------
        public bool UpdateModule(UsersDataGlobalOptions usersDataModule)
        {
            return usersModules.UpdateModule(usersDataModule);
        }
        //------------------------------------------------------------------
        public SitePageOptions GetPage(int pageID)
        {
            foreach (SitePageOptions page in SitePagesList)
            {
                if (page.PageID == pageID)
                    return page;
            }
            return new SitePageOptions();
        }
        //-----------------------------------------------------------------
        public bool SavePage(SitePageOptions page)
        {
            return sitePages.SavePage(page);
        }
        public bool AddPage(SitePageOptions page)
        {
            return sitePages.AddPage(page);
        }
        //------------------------------------------------------------------
        public bool UpdatePage(SitePageOptions page)
        {
            return sitePages.UpdatePage(page);
        }
        //------------------------------------------------------------------
        public bool DeletePage(int pageID)
        {
            return sitePages.DeletePage(pageID);

        }
    }
      
}
