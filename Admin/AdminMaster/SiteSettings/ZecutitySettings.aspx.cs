using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
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


public partial class AdminSiteSettings_Comments : MasterAdminMasterPage
{

    #region ---------------Page_Load---------------
    //-----------------------------------------------
    //Page_Load
    //-----------------------------------------------
    private void Page_Load(object sender, System.EventArgs e)
    {
        lblResult.Text = "";
        if (!IsPostBack)
        {
            this.Page.Title = "≈⁄œ«œ«  „ÊœÊÌ· √„‰ «·‰Ÿ«„";
            LoadData();
        }
    }
    //-----------------------------------------------
    #endregion

    #region ---------------LoadData---------------
    //-----------------------------------------------
    //LoadData
    //-----------------------------------------------
    protected void LoadData()
    {
        //-----------------------------------------------
        SiteSettingsFactory.LoadAllSettings();
        //----------------------------------------------------------------------------------------------------------------
        //Zecurity Options
        txtZecurityUnSafePathes.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.ZecurityUnSafePathes];
        txtZecurityAdminFolder.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.ZecurityAdminFolder];
        txtZecurityAdminDefaultPage.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.ZecurityAdminDefaultPage];
        txtZecurityErrorPagePath.Text = (string)SiteSettings.AllSiteSettings[SiteSettingItems.ZecurityErrorPagePath];
        //----------------------------------------------------------------------------------------------------------------
    }
    //-----------------------------------------------
    #endregion

    #region ---------------Save---------------
    //-----------------------------------------------
    //Save
    //-----------------------------------------------
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (!Page.IsValid)
        {
            return;
        }
       
        //----------------------------------------------------------------------------------------------------------------
        //Zecurity Options
        SiteSettings.AllSiteSettings[SiteSettingItems.ZecurityUnSafePathes] = txtZecurityUnSafePathes.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.ZecurityAdminFolder] = txtZecurityAdminFolder.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.ZecurityAdminDefaultPage] = txtZecurityAdminDefaultPage.Text;
        SiteSettings.AllSiteSettings[SiteSettingItems.ZecurityErrorPagePath] = txtZecurityErrorPagePath.Text;
        //----------------------------------------------------------------------------------------------------------------
        SiteSettingsFactory.SaveAllSettingsCollections();
        //-----------------------------------------------
        lblResult.CssClass = "operation_done";
        lblResult.Text = " „ «·Õ›Ÿ »‰Ã«Õ";

    }
    //-----------------------------------------------
    #endregion

    protected void lbSecurityBuilder_Click(object sender, EventArgs e)
    {
        Module zecurityModule;
        ZecurityManager.ClearDocument();
        //------------------------------------------------------------------
        SiteModulesManager siteModules = SiteModulesManager.Instance;
        foreach (ItemsModulesOptions module in siteModules.SiteItemsModulesList)
        {
            if (module.IsAvailabe && module.ModuleType != ModuleTypes.Categories_Only && !module.HasOwnerID)
            {
                zecurityModule = new Module();
                zecurityModule.ID = module.ModuleTypeID.ToString();
                zecurityModule.Name = module.GetModuleAdminSpecialTitle();
                zecurityModule.Path = "/AdminCP/Items/" + module.Identifire + "/";
                ZecurityManager.AddModule(zecurityModule);
            }
        }
        //------------------------------------------------------------------
        foreach (MessagesModuleOptions module in siteModules.SiteMessagesModulesList)
        {
            if (module.IsAvailabe && !module.HasOwnerID)
            {
                zecurityModule = new Module();
                zecurityModule.ID = module.ModuleTypeID.ToString();
                zecurityModule.Name = module.GetModuleAdminSpecialTitle();
                zecurityModule.Path = "/AdminCP/Messages/" + module.Identifire + "/";
                ZecurityManager.AddModule(zecurityModule);
            }
        }
        //------------------------------------------------------------------
        foreach (UsersDataGlobalOptions module in siteModules.SiteUsersDataModulesList)
        {
            if (module.IsAvailabe && !module.HasOwnerID)
            {
                zecurityModule = new Module();
                zecurityModule.ID = module.ModuleTypeID.ToString();
                zecurityModule.Name = module.GetModuleAdminSpecialTitle();
                zecurityModule.Path = "/AdminCP/UsersData/" + module.Identifire + "/";
                ZecurityManager.AddModule(zecurityModule);
            }
        }
        //------------------------------------------------------------------
        //------------------------------------------------------------------
        //MailList
        if (SiteSettings.MailList_HasMaillist)
        {
            zecurityModule = new Module();
            zecurityModule.ID = ((int)StandardItemsModuleTypes.MailList).ToString();
            zecurityModule.Name = Resources.MailListAdmin.MailListTitle;
            zecurityModule.Path = "/AdminCP/MailList/";
            ZecurityManager.AddModule(zecurityModule);
        }
        //-------------------------------------------
        //Sms
        if (SiteSettings.Sms_HasSms)
        {
            zecurityModule = new Module();
            zecurityModule.ID = ((int)StandardItemsModuleTypes.SMS).ToString();
            zecurityModule.Name = Resources.SmsAdmin.SmsModuleTitle;
            zecurityModule.Path = "/AdminCP/SMS/";
            ZecurityManager.AddModule(zecurityModule);
        }
        //-------------------------------------------
        //Advertisments
        if (SiteSettings.SpecialModules_AdvertismentsEnabled)
        {
            zecurityModule = new Module();
            zecurityModule.ID = ((int)StandardItemsModuleTypes.Advertisments).ToString();
            zecurityModule.Name = Resources.AdminText.ModuleAdmin_AdvModules;
            zecurityModule.Path = "/AdminCP/Adv/Advertisments/";
            ZecurityManager.AddModule(zecurityModule);
        }
        //-------------------------------------------
        //Vote
        if (SiteSettings.Vote_Enabled)
        {
            zecurityModule = new Module();
            zecurityModule.ID = ((int)StandardItemsModuleTypes.Vote).ToString();
            zecurityModule.Name = Resources.Vote.VoteModuleTitle;
            zecurityModule.Path = "/AdminCP/Voting/VoteQuestions/";
            ZecurityManager.AddModule(zecurityModule);
        }
        //-------------------------------------------
        //Citis
        if (SiteSettings.SpecialModules_CitisEnabled)
        {
            zecurityModule = new Module();
            zecurityModule.ID = ((int)StandardItemsModuleTypes.Cities).ToString();
            zecurityModule.Name = Resources.Cities.CitiesModuleTitle;
            zecurityModule.Path = "/AdminCP/Cities/";
            ZecurityManager.AddModule(zecurityModule);
        }
        //-------------------------------------------
        //-------------------------------------------
        //ShareLinks
        if (SiteSettings.SpecialModules_ShareLinksEnabled)
        {
            zecurityModule = new Module();
            zecurityModule.ID = ((int)StandardItemsModuleTypes.ShareLinks).ToString();
            zecurityModule.Name = Resources.SocialLinks.SocialLinksModuleTitle;
            zecurityModule.Path = "/AdminCP/ShareLinks/";
            ZecurityManager.AddModule(zecurityModule);
        }
        //-------------------------------------------
        //AdmininstrationMails
        if (SiteSettings.Admininstration_HasAdminEmail)
        {
            zecurityModule = new Module();
            zecurityModule.ID = ((int)StandardItemsModuleTypes.AdmininstrationMails).ToString();
            zecurityModule.Name = Resources.AdmininstrationData.Page_AdminEmails;
            zecurityModule.Path = "/AdminCP/AdminData/";
            ZecurityManager.AddModule(zecurityModule);
        }
        //-------------------------------------------
    }

}

