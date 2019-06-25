using System;
using System.Collections.Generic;

using System.Web;
namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for MasterModule
    /// </summary>
    public class MasterModule
    {
        #region --------------ModuleTypeID--------------
        private int _ModuleTypeID = (int)StandardItemsModuleTypes.UnKnowen;
        public int ModuleTypeID
        {
            get { return _ModuleTypeID; }
            set { _ModuleTypeID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Identifire--------------
        private string _Identifire = "";
        public string Identifire
        {
            get { return _Identifire; }
            set { _Identifire = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ModuleBaseType--------------
        private ModuleBaseTypes _ModuleBaseType = ModuleBaseTypes.Unknowen;
        public ModuleBaseTypes ModuleBaseType
        {
            get { return _ModuleBaseType; }
            set { _ModuleBaseType = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ModuleType--------------
        private ModuleTypes _ModuleType = ModuleTypes.Unknowen;
        public ModuleTypes ModuleType
        {
            get { return _ModuleType;  }
            set { _ModuleType = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ModuleTitle--------------
        private string _ModuleTitle = "";
        public string ModuleTitle { get { return _ModuleTitle; } set { _ModuleTitle = value; } }

        //------------------------------------------
        #endregion

        #region --------------ModuleAdminSpecialTitle--------------
        private string _ModuleAdminSpecialTitle = "";
        public string ModuleAdminSpecialTitle { get { return _ModuleAdminSpecialTitle; } set { _ModuleAdminSpecialTitle = value; } }

        //------------------------------------------
        #endregion
               
        #region --------------HasOwenFolder_Admin--------------
        private bool _HasOwenFolder_Admin;
        public bool HasOwenFolder_Admin
        {
            get { return _HasOwenFolder_Admin; }
            set { _HasOwenFolder_Admin = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasOwenFolder_User--------------
        private bool _HasOwenFolder_User;
        public bool HasOwenFolder_User
        {
            get { return _HasOwenFolder_User; }
            set { _HasOwenFolder_User = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CategoryLevel--------------
        private int _CategoryLevel = 0;
        public int CategoryLevel
        {
            get { return _CategoryLevel; }
            set { _CategoryLevel = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------DisplayCategoriesInAdminMenue--------------
        private bool _DisplayCategoriesInAdminMenue = true;
        public bool DisplayCategoriesInAdminMenue
        {
            get { return _DisplayCategoriesInAdminMenue; }
            set { _DisplayCategoriesInAdminMenue = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ModuleRelatedPageID--------------
        private int _ModuleRelatedPageID = -1;
        public int ModuleRelatedPageID
        {
            get { return _ModuleRelatedPageID; }
            set { _ModuleRelatedPageID = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ShowInSiteDepartments--------------
        private bool _ShowInSiteDepartments = true;
        public bool ShowInSiteDepartments
        {
            get { return _ShowInSiteDepartments; }
            set { _ShowInSiteDepartments = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasOwnerID--------------
        private bool _HasOwnerID;
        public bool HasOwnerID
        {
            get { return _HasOwnerID; }
            set { _HasOwnerID = value; }
        }
        #endregion

        #region --------------AddInAdminMenuAutmaticly--------------
        private bool _AddInAdminMenuAutmaticly = true;
        public bool AddInAdminMenuAutmaticly
        {
            get { return _AddInAdminMenuAutmaticly; }
            set { _AddInAdminMenuAutmaticly = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MailList options----------------
        
        #region --------------MailListAutomaticRegistration--------------
        private bool _MailListAutomaticRegistration;
        public bool MailListAutomaticRegistration
        {
            get { return _MailListAutomaticRegistration; }
            set { _MailListAutomaticRegistration = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MailListSendingMailActivation--------------
        private bool _MailListSendingMailActivation;
        public bool MailListSendingMailActivation
        {
            get { return _MailListSendingMailActivation; }
            set { _MailListSendingMailActivation = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------MailListAutomaticActivation--------------
        private bool _MailListAutomaticActivation;
        public bool MailListAutomaticActivation
        {
            get { return _MailListAutomaticActivation; }
            set { _MailListAutomaticActivation = value; }
        }
        //------------------------------------------
        #endregion

        #endregion

        #region --------------Sms options----------------
        
        #region --------------SmsAutomaticRegistration--------------
        private bool _SmsAutomaticRegistration;
        public bool SmsAutomaticRegistration
        {
            get { return _SmsAutomaticRegistration; }
            set { _SmsAutomaticRegistration = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SmsSendingSmsActivation--------------
        private bool _SmsSendingSmsActivation;
        public bool SmsSendingSmsActivation
        {
            get { return _SmsSendingSmsActivation; }
            set { _SmsSendingSmsActivation = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------SmsAutomaticActivation--------------
        private bool _SmsAutomaticActivation;
        public bool SmsAutomaticActivation
        {
            get { return _SmsAutomaticActivation; }
            set { _SmsAutomaticActivation = value; }
        }
        //------------------------------------------
        #endregion
        #endregion

        #region --------------AdminNote--------------
        private string _AdminNote = "";
        public string AdminNote
        {
            get { return _AdminNote; }
            set { _AdminNote = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ResourceFile--------------
        private string _ResourceFile = "";
        public string ResourceFile
        {
            get { return _ResourceFile; }
            set { _ResourceFile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------DefaultResourceFile--------------
        private string _DefaultResourceFile = "";
        public string DefaultResourceFile
        {
            get { return _DefaultResourceFile;  }
            set { _DefaultResourceFile = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasSpecialAdminText--------------
        private bool _HasSpecialAdminText = false;
        public bool HasSpecialAdminText
        {
            get { return _HasSpecialAdminText; }
            set { _HasSpecialAdminText = value; }
        }
        //------------------------------------------
        #endregion
        
        #region --------------PageItemCount_UserDefault--------------
        private int _PageItemCount_UserDefault = 15;
        public int PageItemCount_UserDefault
        {
            get { return _PageItemCount_UserDefault; }
            set { _PageItemCount_UserDefault = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------PageItemCount_AdminDefault--------------
        private int _PageItemCount_AdminDefault = 25;
        public int PageItemCount_AdminDefault
        {
            get { return _PageItemCount_AdminDefault; }
            set { _PageItemCount_AdminDefault = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------Seo Options--------------

        #region --------------ModuleMetaKeyWords--------------
        private string _ModuleMetaKeyWords = "";
        public string ModuleMetaKeyWords
        {
            get { return _ModuleMetaKeyWords; }
            set { _ModuleMetaKeyWords = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------ModuleMetaDescription--------------
        private string _ModuleMetaDescription = "";
        public string ModuleMetaDescription
        {
            get { return _ModuleMetaDescription; }
            set { _ModuleMetaDescription = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasMetaKeyWords--------------
        private bool _HasMetaKeyWords = false;
        public bool HasMetaKeyWords
        {
            get { return _HasMetaKeyWords; }
            set { _HasMetaKeyWords = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------HasMetaDescription--------------
        private bool _HasMetaDescription = false;
        public bool HasMetaDescription
        {
            get { return _HasMetaDescription; }
            set { _HasMetaDescription = value; }
        }
        //------------------------------------------
        #endregion
        #endregion

        #region --------------IsAvailabe--------------
        private bool _IsAvailabe;
        public bool IsAvailabe
        {
            get { return _IsAvailabe; }
            set { _IsAvailabe = value; }
        }
        //------------------------------------------
        #endregion

        #region --------------CreateModuleTitleIdentifire--------------
        //------------------------------------------------------
        //CreateModuleTitleIdentifire
        //------------------------------------------------------
        public string CreateModuleTitleIdentifire()
        {
            string title = "";
            if (!string.IsNullOrEmpty(_Identifire))
                title = "ModuleTitle_" + _Identifire;
            else
                title = "ModuleTitle_" + _ModuleTypeID.ToString();

            return title;
        }
        //------------------------------------------------------
        #endregion
        
        #region --------------ModuleAdminSpecialTitleReturner--------------
        //------------------------------------------------------
        //ModuleAdminSpecialTitleReturner
        //------------------------------------------------------
        public string ModuleAdminSpecialTitleReturner
        {
            get
            {
                return GetModuleAdminSpecialTitle();
            }
        }
        //------------------------------------------------------
        #endregion

        #region --------------GetModuleAdminSpecialTitle--------------
        //------------------------------------------------------
        //GetModuleAdminSpecialTitle
        //------------------------------------------------------
        public string GetModuleAdminSpecialTitle()
        {
            string title = "";
            try
            {
                title = (string)HttpContext.GetGlobalResourceObject("Modules", _ModuleAdminSpecialTitle);
                if (title == null)
                {
                    if (!string.IsNullOrEmpty(_ModuleAdminSpecialTitle))
                        title = _ModuleAdminSpecialTitle;
                    else
                        title = GetModuleTitle();
                }
            }
            catch
            {
                if (!string.IsNullOrEmpty(_ModuleAdminSpecialTitle))
                    title = _ModuleAdminSpecialTitle;
                else
                    title = GetModuleTitle();
            }
            return title;
        }
        //------------------------------------------------------
        #endregion

        #region --------------CreateModuleAdminSpecialTitleIdentifire--------------
        //------------------------------------------------------
        //CreateModuleAdminSpecialTitleIdentifire
        //------------------------------------------------------
        public string CreateModuleAdminSpecialTitleIdentifire()
        {
            string title = "";
            if (!string.IsNullOrEmpty(_Identifire))
                title = "ModuleAdminSpecialTitle_" + _Identifire;
            else
                title = "ModuleAdminSpecialTitle_" + _ModuleTypeID.ToString();

            return title;
        }
        //------------------------------------------------------
        #endregion

        #region --------------ModuleTitleReturner--------------
        //------------------------------------------------------
        //ModuleTitleReturner
        //------------------------------------------------------
        public string ModuleTitleReturner
        {
            get
            {
                return GetModuleTitle();
            }
        }
        //------------------------------------------------------
        #endregion

        #region --------------GetModuleTitle--------------
        //------------------------------------------------------
        //GetModuleTitle
        //------------------------------------------------------
        public string GetModuleTitle()
        {
            string title = "";
            try
            {
                title = (string)HttpContext.GetGlobalResourceObject("Modules", _ModuleTitle);
                if (title == null)
                {
                    if (!string.IsNullOrEmpty(_ModuleTitle))
                        title = _ModuleTitle;
                    else
                        title = Identifire;
                }
            }
            catch
            {
                if (!string.IsNullOrEmpty(_ModuleTitle))
                    title = _ModuleTitle;
                else
                    title = Identifire;
            }
            return title;
        }
        //------------------------------------------------------
        #endregion

        #region --------------ModuleSpecialPath--------------
        private string _ModuleSpecialPath = "";
        public string ModuleSpecialPath { get { return _ModuleSpecialPath; } set { _ModuleSpecialPath = value; } }

        //------------------------------------------
        #endregion

        public static MasterModule GetType(int moduleType)
        {
            if (moduleType < 500)
                return (MasterModule)ItemsModulesOptions.GetType(moduleType);
            else if (moduleType < 600)
                return (MasterModule)MessagesModuleOptions.GetType(moduleType);
            else if (moduleType < 700)
                return (MasterModule)UsersDataGlobalOptions.GetType(moduleType);
            else
                return new MasterModule();
        }


        public MasterModule()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string GetModuleIdentifire(object moduleTypeID)
        {
            int moduleid = (int)moduleTypeID;
            if (moduleid < 500)
            {
                ItemsModulesOptions itemModule = ItemsModulesOptions.GetType(moduleid);
                if (itemModule != null)
                    return itemModule.Identifire;
            }
            else
            {
                MessagesModuleOptions msgmodule = MessagesModuleOptions.GetType(moduleid);
                if (msgmodule != null)
                    return msgmodule.Identifire;
            }
            return "";
        }


    }
}