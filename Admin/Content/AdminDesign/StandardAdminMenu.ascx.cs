using System;using DCCMSNameSpace;using DCCMSNameSpace.Zecurity;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class App_Design_masters_AdminMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public string BuildDynamicModulesLinks()
    {
        string links = "";
        links += BuildStaticPagesLinks();
        links += BuildStaticPageWithCommentsLinks();
        //------------------------------------------------------------------
        SiteModulesManager siteModules = SiteModulesManager.Instance;
        foreach (ItemsModulesOptions module in siteModules.SiteItemsModulesList)
        {
            if (module.IsAvailabe && module.AddInAdminMenuAutmaticly && module.ModuleType != ModuleTypes.Categories_Only && !module.HasOwnerID)
            {
                links += BuildItemsModuleLinks(module.ModuleTypeID);
            }
        }
        //------------------------------------------------------------------
        //------------------------------------------------------------------
        foreach (MessagesModuleOptions module in siteModules.SiteMessagesModulesList)
        {
            if (module.IsAvailabe && module.AddInAdminMenuAutmaticly && !module.HasOwnerID && module.ToItemModuleType <= 0)
            {
                links += BuildMessagesModuleLinks(module.ModuleTypeID);
            }
        }
        //------------------------------------------------------------------
        //------------------------------------------------------------------
        foreach (UsersDataGlobalOptions module in siteModules.SiteUsersDataModulesList)
        {
            if (module.IsAvailabe && module.AddInAdminMenuAutmaticly && !module.HasOwnerID)
            {
                links += BuildUserRegistrationsLinks(module.ModuleTypeID);
            }
        }
        //------------------------------------------------------------------
        //MailList
        if (SiteSettings.MailList_HasMaillist)
            links+=BuildEmailListLinks();
        //-------------------------------------------
        //Sms
        if (SiteSettings.Sms_HasSms)
            links += BuildSmsLinks();
        //-------------------------------------------
        //Advertisments
        if (SiteSettings.SpecialModules_AdvertismentsEnabled)
            links += BuildAdvertismentsLinks();
        //-------------------------------------------
        //Vote
        if (SiteSettings.Vote_Enabled)
            links += BuildVoteLinks();
        //-------------------------------------------
        //Citis
        if (SiteSettings.SpecialModules_CitisEnabled)
            links += BuildCitiesLinks();
        //-------------------------------------------
        //ShareLinks
        if (SiteSettings.SpecialModules_ShareLinksEnabled)
            links += BuildShareLinks();
        //-------------------------------------------
        //Admin Mails
        if (SiteSettings.Admininstration_HasAdminEmail)
            links += AdmininstrationMailsLinks();
        //-------------------------------------------
        
        //Security
        if (SiteSettings.SpecialModules_SecurityEnabled)
            links += BuildSecurityLinks();
        //-------------------------------------------
        return links;
    }
    //----------------------------------------------------------
    #region ----------------BuildItemsModuleLinks---------------
    //----------------------------------------------------------
    //BuildItemsModuleLinks
    //----------------------------------------------------------
    public string BuildItemsModuleLinks(int moduleType)
    {
        ItemsModulesOptions itemsModule = ItemsModulesOptions.GetType(moduleType);
        string moduleTitleText = itemsModule.GetModuleTitle();
        string categoriesAddText = Resources.Modules.Module_CategoriesAdd;
        string categoriesDefaultText = Resources.Modules.Module_CategoriesDefault;
        string itemsAddText = Resources.Modules.Module_ItemsAdd;
        string itemsDefaultText = Resources.Modules.Module_ItemsDefault;
        string itemsPhotosAddText = Resources.Modules.Module_ItemsPhotosAdd;
        //string Module_NewMessage = DynamicResource.GetText(itemsModule, "Module_NewMessage");
        //string Module_AllMessage = DynamicResource.GetText(itemsModule, "Module_AllMessage");
        string commentsInactiveText = Resources.Modules.Module_CommentsInactive;
        string newMessageText = Resources.Modules.Module_NewMessage;
        string allMessageText = Resources.Modules.Module_AllMessage;
        if (itemsModule.HasSpecialAdminText)
        {
            //moduleTitleText = itemsModule.GetModuleTitle();
            categoriesAddText = DynamicResource.GetText(itemsModule, "Module_CategoriesAdd");
            categoriesDefaultText = DynamicResource.GetText(itemsModule, "Module_CategoriesDefault");
            itemsAddText = DynamicResource.GetText(itemsModule, "Module_ItemsAdd");
            itemsDefaultText = DynamicResource.GetText(itemsModule, "Module_ItemsDefault");
            itemsPhotosAddText = DynamicResource.GetText(itemsModule, "Module_ItemsPhotosAdd");
            commentsInactiveText = DynamicResource.GetText(itemsModule, "Module_CommentsInactive");
            newMessageText = DynamicResource.GetText(itemsModule, "Module_NewMessage");
            allMessageText = DynamicResource.GetText(itemsModule, "Module_AllMessage");
        }
        string links = "";
        string folder = itemsModule.Identifire.ToString();
        if (ZecurityManager.CheckFolderPermission("/AdminCP/Items/" + folder + "/"))
        {
            links += "<tr><td class=\"menuheader expandable\">" + itemsModule.GetModuleTitle() + "</td></tr>";
            links += "<tr><td><ul class=\"categoryitems\">";
            if (itemsModule.CategoryLevel != 0 && itemsModule.DisplayCategoriesInAdminMenue)
            {

                links += "<li><a href=\"/AdminCP/Items/" + folder + "/Cats/Add.aspx\">" + categoriesAddText + "</a></li>";
                links += "<li><a href=\"/AdminCP/Items/" + folder + "/Cats/default.aspx\">" + categoriesDefaultText + "</a></li>";
            }

            links += "<li><a href=\"/AdminCP/Items/" + folder + "/Add.aspx\">" + itemsAddText + "</a></li>";
            links += "<li><a href=\"/AdminCP/Items/" + folder + "/default.aspx\">" + itemsDefaultText + "</a></li>";
            if (itemsModule.HasMultiPhotos)
            {
                links += "<li><a href=\"/AdminCP/Items/" + folder + "/AddPhoto.aspx\">" + itemsPhotosAddText + "</a></li>";
            }
            if (itemsModule.MessagesModuleID > 0)
            {
                links += "<li><a href=\"/AdminCP/Items/" + folder + "/Messages/New.aspx\">" + newMessageText + "</a></li>";
                links += "<li><a href=\"/AdminCP/Items/" + folder + "/Messages/default.aspx\">" + DynamicResource.GetText(itemsModule, "Module_AllMessage") + "</a></li>";

            }
            if (itemsModule.HasComments)
            {
                int inactiveCommentsCount = ItemsCommentsFactory.GetCount(-1, Languages.Unknowen, itemsModule.ModuleTypeID, true, false, false, SitesHandler.GetOwnerIDAsGuid());
                links += "<li><a href=\"/AdminCP/Items/" + folder + "/Comments/InActive.aspx\">" + commentsInactiveText + " -" + inactiveCommentsCount + "</a></li>";
                links += "    ";
            }
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildStaticPagesLinks---------------
    //----------------------------------------------------------
    //BuildStaticPagesLinks
    //----------------------------------------------------------
    public string BuildStaticPagesLinks()
    {
         
        ItemsModulesOptions SitePagesModule = ItemsModulesOptions.GetType((int)StandardItemsModuleTypes.SitePages);

        string links = "";
        string folder = SitePagesModule.Identifire.ToString();
        if (SitePagesModule.IsAvailabe &&ZecurityManager.CheckFolderPermission("/AdminCP/Items/" + folder + "/"))
        {
            links += "<tr><td class=\"menuheader expandable\">"+Resources.AdminText.StaticContents+"</td></tr>";
            links += "<tr><td><ul class=\"categoryitems\">";
            //-------------------------------------------------------------------
            SiteModulesManager siteModules = SiteModulesManager.Instance;
            foreach (SitePageOptions page in siteModules.SitePagesList)
            {
                if (page.IsAvailabe && page.AddInAdminMenuAutmaticly && !page.HasComments)
                {
                        links += "<li><a href=\"/AdminCP/Items/" + folder + "/StaticContents.aspx?id=" + page.PageID + "\">" + page.Title + "</a></li>";
                }
            }
            //-------------------------------------------------------------------
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildStaticPageWithCommentsLinks---------------
    //----------------------------------------------------------
    //BuildStaticPageWithCommentsLinks
    //----------------------------------------------------------
    public string BuildStaticPageWithCommentsLinks()
    {
        string links = "";
        string folder = "SitePages";
        SiteModulesManager sitePages = SiteModulesManager.Instance;
        int inactiveCommentsCount = 0;
        int activeCommentsCount = 0;
        foreach (SitePageOptions page in sitePages.SitePagesList)
        {
            if (page.IsAvailabe && page.AddInAdminMenuAutmaticly && page.HasComments)
            {
                links += "<tr><td class=\"menuheader expandable\">" + page.Title + "</td></tr>";
                links += "<tr><td><ul class=\"categoryitems\">";
                //---------------------------------------------------
                inactiveCommentsCount = ItemsCommentsFactory.GetCount(page.PageID, Languages.Unknowen, page.ModuleTypeID, true, false, false, SitesHandler.GetOwnerIDAsGuid());
                activeCommentsCount = ItemsCommentsFactory.GetCount(page.PageID, Languages.Unknowen, page.ModuleTypeID, true, true, false, SitesHandler.GetOwnerIDAsGuid());
                //---------------------------------------------------
                links += "<li><a href=\"/AdminCP/Items/" + folder + "/StaticContents.aspx?id=" + page.PageID + "\">" + page.Title + "</a></li>";
                //---------------------------------------------------
                links += "<li><a href=\"/AdminCP/Items/" + folder + "/Comments/ItemInActiveComments.aspx?id=" + page.PageID + "\">" + Resources.Modules.Module_CommentsInactive + " -" + inactiveCommentsCount + "</a></li>";
                links += "<li><a href=\"/AdminCP/Items/" + folder + "/Comments/ItemActiveComments.aspx?id=" + page.PageID + "\">" + Resources.Modules.Module_CommentsActive + " -" + activeCommentsCount + "</a></li>";
                links += "    ";
                //---------------------------------------------------
                links += "</ul></td></tr>";
            }
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildMessagesModuleLinks---------------
    //----------------------------------------------------------
    //BuildMessagesModuleLinks
    //----------------------------------------------------------
    public string BuildMessagesModuleLinks(int moduleType)
    {
        //------------------------------------------------------------------------------------------------
        MessagesModuleOptions msgsModule = MessagesModuleOptions.GetType(moduleType);
        //------------------------------------------------------------------------------------------------
        string moduleTitleText = msgsModule.GetModuleTitle();
        string categoriesAddText = Resources.Modules.Module_CategoriesAdd;
        string categoriesDefaultText = Resources.Modules.Module_CategoriesDefault;
        string exportData = Resources.Modules.Module_ExportData;
        string newMessageText = Resources.Modules.Module_NewMessage;
        string allMessageText = Resources.Modules.Module_AllMessage;
        //------------------------------------------------------------------------------------------------
        if (msgsModule.HasSpecialAdminText)
        {
            //moduleTitleText = itemsModule.GetModuleTitle();
            categoriesAddText = DynamicResource.GetMessageModuleText(msgsModule, "Module_CategoriesAdd");
            categoriesDefaultText = DynamicResource.GetMessageModuleText(msgsModule, "Module_CategoriesDefault");
            exportData = DynamicResource.GetMessageModuleText(msgsModule, "Module_ExportData");
            newMessageText = DynamicResource.GetMessageModuleText(msgsModule, "Module_NewMessage");
            allMessageText = DynamicResource.GetMessageModuleText(msgsModule, "Module_AllMessage");
        }
        //------------------------------------------------------------------------------------------------
        string links = "";
        string folder = msgsModule.Identifire.ToString();
        if (ZecurityManager.CheckFolderPermission("/AdminCP/Messages/" + folder + "/"))
        {
            links += "<tr><td class=\"menuheader expandable\">" + moduleTitleText + "</td></tr>";
            links += "<tr><td><ul class=\"categoryitems\">";
            if (msgsModule.CategoryLevel != 0 && msgsModule.DisplayCategoriesInAdminMenue)
            {
                links += "<li><a href=\"/AdminCP/Messages/" + folder + "/Cats/Add.aspx\">" + categoriesAddText + "</a></li>";
                links += "<li><a href=\"/AdminCP/Messages/" + folder + "/Cats/default.aspx\">" + categoriesDefaultText + "</a></li>";
            }
            links += "<li><a href=\"/AdminCP/Messages/" + folder + "/New.aspx\">" + newMessageText + "</a></li>";
            links += "<li><a href=\"/AdminCP/Messages/" + folder + "/default.aspx\">" + allMessageText + "</a></li>";
            if (msgsModule.HasExportData)
            {
                links += "<li><a href=\"/AdminCP/Messages/" + folder + "/Export.aspx\">" + exportData + "</a></li>";
            }
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildUserRegistrationsLinks---------------
    //----------------------------------------------------------
    //BuildUserRegistrationsLinks
    //----------------------------------------------------------
    public string BuildUserRegistrationsLinks(int moduleType)
    {
        //------------------------------------------------------------------------------------------------
        UsersDataGlobalOptions userdataModule = UsersDataGlobalOptions.GetType(moduleType);
        //------------------------------------------------------------------------------------------------
        string moduleTitleText = userdataModule.GetModuleTitle();
        string categoriesAddText = Resources.Modules.Module_CategoriesAdd;
        string categoriesDefaultText = Resources.Modules.Module_CategoriesDefault;
        string itemsAddText = Resources.Modules.Module_ItemsAdd;
        string itemsDefaultText = Resources.Modules.Module_ItemsDefault;
        //------------------------------------------------------------------------------------------------
        if (userdataModule.HasSpecialAdminText)
        {
            //moduleTitleText = itemsModule.GetModuleTitle();
            categoriesAddText = DynamicResource.GetUsersDataModuleText(userdataModule, "Module_CategoriesAdd");
            categoriesDefaultText = DynamicResource.GetUsersDataModuleText(userdataModule, "Module_CategoriesDefault");
            itemsAddText = DynamicResource.GetUsersDataModuleText(userdataModule, "Module_ItemsAdd");
            itemsDefaultText = DynamicResource.GetUsersDataModuleText(userdataModule, "Module_ItemsDefault");
        }
        //------------------------------------------------------------------------------------------------
        string folder = userdataModule.Identifire.ToString();
        string links = "";
        if (ZecurityManager.CheckFolderPermission("/AdminCP/UsersData/" + folder + "/"))
        {
            links += "<tr><td class='menuheader expandable'>" + userdataModule.GetModuleTitle() + "</td></tr>";
            links += "<tr><td><ul class='categoryitems' >";
            if (userdataModule.CategoryLevel != 0 && userdataModule.DisplayCategoriesInAdminMenue)
            {
                links += "<li><a href=\"/AdminCP/UsersData/" + folder + "/Cats/Add.aspx\">" + categoriesAddText + "</a></li>";
                links += "<li><a href=\"/AdminCP/UsersData/" + folder + "/Cats/default.aspx\">" + categoriesDefaultText + "</a></li>";
            }
            if (userdataModule.HasAddUserInAdmin)
            {
                links += "<li><a href='/AdminCP/UsersData/" + folder + "/Add.aspx'>" + itemsAddText + "</a></li>";
            }
            links += "<li><a href='/AdminCP/UsersData/" + folder + "/default.aspx'>" + itemsDefaultText + "</a></li>";
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildEmailListLinks---------------
    //----------------------------------------------------------
    //BuildEmailListLinks
    //----------------------------------------------------------
    public string BuildEmailListLinks()
    {

        string links = "";
        if (SiteSettings.MailList_HasMaillist)
        {
            if (ZecurityManager.CheckFolderPermission("/AdminCP/MailList/"))
            {

                links += "<tr><td class='menuheader expandable'>" + Resources.MailListAdmin.MailListTitle + "</td></tr>";
                links += "<tr><td><ul class='categoryitems' >";
                /******************************************************************************/
                if (SiteSettings.MailList_HasGroups)
                {
                    links += "<li><a href='/AdminCP/MailList/MailListGroups/Save.aspx'>" + Resources.MailListAdmin.Page_AddGroup + "</a></li>";
                    links += "<li><a href='/AdminCP/MailList/MailListGroups/default.aspx'>" + Resources.MailListAdmin.Page_AllGroups + "</a></li>";
                }
                links += "<li><a href='/AdminCP/MailList/MailListUsers/Add.aspx'>" + Resources.MailListAdmin.Page_AddUser + "</a></li>";
                links += "<li><a href='/AdminCP/MailList/MailListUsers/default.aspx'>" + Resources.MailListAdmin.Page_AllUsers + "</a></li>";
                if (SiteSettings.MailList_HasImportFromTxtFile)
                {
                    links += "<li><a href='/AdminCP/MailList/MailListUsers/Import-Export/ImportFromTextFile.aspx'>" + Resources.MailListAdmin.Page_ImportFromTxtFile + "</a></li>";
                }
                if (SiteSettings.MailList_HasImportFromExcellFile)
                {
                    links += "<li><a href='/AdminCP/MailList/MailListUsers/Import-Export/ImportFromExcelFile.aspx'>" + Resources.MailListAdmin.Page_ImportFromExcellFile + "</a></li>";
                }
                if (SiteSettings.MailList_HasArchive)
                {
                    links += "<li><a href='/AdminCP/MailList/MailListArchive/default.aspx'>" + Resources.MailListAdmin.Page_Archive + "</a></li>";
                }
                links += "<li><a href='/AdminCP/MailList/SendMailToAll.aspx'>" + Resources.MailListAdmin.Page_SendToAllMailList + "</a></li>";
                if (SiteSettings.MailList_HasGroups)
                {
                    links += "<li><a href='/AdminCP/MailList/SendMailToGroup.aspx'>" + Resources.MailListAdmin.Page_SendToGroup + "</a></li>";
                    links += "<li><a href='/AdminCP/MailList/SendMailToGroups.aspx'>" + Resources.MailListAdmin.Page_SendToMultiGroup + "</a></li>";
                    links += "<li><a href='/AdminCP/MailList/SendMailToGroupSelected.aspx'>" + Resources.MailListAdmin.Page_SendToMultiUsersInGroup + "</a></li>";
                }
                links += "<li><a href='/AdminCP/MailList/SendMailToOne.aspx'>" + Resources.MailListAdmin.Page_SendToUser + "</a></li>";
                links += "</ul></td></tr>";
            }

            
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildSmsLinks---------------
    //----------------------------------------------------------
    //BuildSmsLinks
    //----------------------------------------------------------
    public string BuildSmsLinks()
    {
        string links = "";
        if (ZecurityManager.CheckFolderPermission("/AdminCP/SMS/"))
        {
            links += "<tr><td class='menuheader expandable'>" + Resources.SmsAdmin.SmsModuleTitle + "</td></tr>";
            links += "<tr><td><ul class='categoryitems' >";
            if (SiteSettings.Sms_HasGroups)
            {
                links += "<li><a href='/AdminCP/SMS/Groups/Add.aspx'>" + Resources.SmsAdmin.Page_AddGroup + "</a></li>";
                links += "<li><a href='/AdminCP/SMS/Groups/default.aspx'>" + Resources.SmsAdmin.Page_AllGroups + "</a></li>";
            }
            links += "<li><a href='/AdminCP/SMS/Users/add.aspx'>" + Resources.SmsAdmin.Page_AddUser + "</a></li>";
            links += "<li><a href='/AdminCP/SMS/Users/default.aspx'>" + Resources.SmsAdmin.Page_AllUsers + "</a></li>";
            if (SiteSettings.Sms_HasImportFromTxtFile)
            {
                links += "<li><a href='/AdminCP/SMS/Users/Import-Export/ImportFromTextFile.aspx'>" + Resources.SmsAdmin.Page_ImportFromTxtFile + "</a></li>";
            }
            if (SiteSettings.Sms_HasImportFromExcellFile)
            {
                links += "<li><a href='/AdminCP/SMS/Users/Import-Export/ImportFromExcelFile.aspx'>" + Resources.SmsAdmin.Page_ImportFromExcellFile + "</a></li>";
            }
            links += "<li><a href='/AdminCP/SMS/Send/ToAll.aspx'>" + Resources.SmsAdmin.Page_SendToAllSmsList + "</a></li>";
            links += "<li><a href='/AdminCP/SMS/Send/ToGroup.aspx'>" + Resources.SmsAdmin.Page_SendToGroup + "</a></li>";
            links += "<li><a href='/AdminCP/SMS/Send/ToOne.aspx'>" + Resources.SmsAdmin.Page_SendToUser + "</a></li>";
            if (SiteSettings.Sms_HasArchive)
            {
                links += "<li><a href='/AdminCP/SMS/SMSArchive/'>" + Resources.SmsAdmin.Page_Archive + "</a></li>";
            }
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildAdvertismentsLinks---------------
    //----------------------------------------------------------
    //BuildAdvertismentsLinks
    //----------------------------------------------------------
    public string BuildAdvertismentsLinks()
    {
        string itemsAddText = Resources.Modules.Module_ItemsAdd;
        string itemsDefaultText = Resources.Modules.Module_ItemsDefault;
        string links = "";
        if (ZecurityManager.CheckFolderPermission("/AdminCP/Adv/Advertisments/"))
        {
            links += "<tr><td class='menuheader expandable'>" + Resources.AdminText.ModuleAdmin_AdvModules + "</td></tr>";
            links += "<tr><td><ul class='categoryitems' >";
            links += "<li><a href='/AdminCP/Adv/Advertisments/Save.aspx'>" + itemsAddText + "</a></li>";
            links += "<li><a href='/AdminCP/Adv/Advertisments/default.aspx'>" + itemsDefaultText + "</a></li>";
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildVoteLinks---------------
    //----------------------------------------------------------
    //BuildVoteLinks
    //----------------------------------------------------------
    public string BuildVoteLinks()
    {

        string links = "";
        if (ZecurityManager.CheckFolderPermission("/AdminCP/Voting/VoteQuestions/"))
        {
            links += "<tr><td class='menuheader expandable'>" + Resources.Vote.VoteModuleTitle + "</td></tr>";
            links += "<tr><td><ul class='categoryitems' >";
            links += "<li><a href='/AdminCP/Voting/VoteQuestions/add.aspx'>" + Resources.Vote.AdminPageAdd + "</a></li>";
            links += "<li><a href='/AdminCP/Voting/VoteQuestions/default.aspx'>" + Resources.Vote.AdminPageDefault + "</a></li>";
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildCitiesLinks---------------
    //----------------------------------------------------------
    //BuildCitiesLinks
    //----------------------------------------------------------
    public string BuildCitiesLinks()
    {

        string links = "";
        if (ZecurityManager.CheckFolderPermission("/AdminCP/Cities/"))
        {
            links += "<tr><td class='menuheader expandable'>"+Resources.Cities.CitiesModuleTitle+"</td></tr>";
            links += "<tr><td><ul class='categoryitems' >";
            links += "<li><a href='/AdminCP/Cities/Add.aspx'>" + Resources.Cities.AdminPage_AddCity + "</a></li>";
            links += "<li><a href='/AdminCP/Cities/default.aspx'>" + Resources.Cities.AdminPage_AllCities + "</a></li>";
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------AdmininstrationMailsLinks---------------
    //----------------------------------------------------------
    //AdmininstrationMailsLinks
    //----------------------------------------------------------
    public string AdmininstrationMailsLinks()
    {

        string links = "";
        if (ZecurityManager.CheckFolderPermission("/AdminCP/AdminData/"))
        {
            links += "<tr><td class='menuheader expandable'>" + Resources.AdmininstrationData.Page_AdminEmails + "</td></tr>";
            links += "<tr><td><ul class='categoryitems' >";
            links += "<li><a href='/AdminCP/AdminData/AdminEmail.aspx'>" + Resources.AdmininstrationData.Page_AdminEmails + "</a></li>";
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildSecurityLinks---------------
    //----------------------------------------------------------
    //BuildSecurityLinks
    //----------------------------------------------------------
    public string BuildSecurityLinks()
    {
        string links = "";
        if (ZecurityManager.CheckFolderPermission("/AdminCP/Zecurity/"))
        {
            links += "<tr><td class='menuheader expandable'>" + Resources.AdminText.ModuleAdmin_SecurityModule + "</td></tr>";
            links += "<tr><td><ul class='categoryitems' >";
            links += "<li><a href=\"/AdminCP/Zecurity/Groups/Add.aspx\">" + Resources.AdminText.ModuleAdmin_SecurityAddGroup + "</a></li>";
            links += "<li><a href=\"/AdminCP/Zecurity/Groups/Default.aspx\">" + Resources.AdminText.ModuleAdmin_SecurityAllGroups + "</a></li>";
            links += "<li><a href=\"/AdminCP/Zecurity/Users/Add.aspx\">" + Resources.AdminText.ModuleAdmin_SecurityAddUser + "</a></li>";
            links += "<li><a href=\"/AdminCP/Zecurity/Users/Default.aspx\">" + Resources.AdminText.ModuleAdmin_SecurityAllUsers + "</a></li>";
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

    #region ----------------BuildShareLinks---------------
    //----------------------------------------------------------
    //BuildShareLinks
    //----------------------------------------------------------
    public string BuildShareLinks()
    {

        string links = "";
        if (ZecurityManager.CheckFolderPermission("/AdminCP/ShareLinks/"))
        {
            links += "<tr><td class='menuheader expandable'>" + Resources.SocialLinks.SocialLinksModuleTitle + "</td></tr>";
            links += "<tr><td><ul class='categoryitems' >";
            links += "<li><a href='/AdminCP/ShareLinks/default.aspx'>" + Resources.SocialLinks.AdminPage_Default + "</a></li>";
            links += "</ul></td></tr>";
        }
        return links;
    }
    //----------------------------------------------------------
    #endregion

}
