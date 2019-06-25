using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
namespace DCCMSNameSpace
{
    //---------------------------------------------------------
    public enum ModuleBaseTypes
    {
        Unknowen = 0,
        Items = 1,
        Messages = 2,
        UsersData = 3,
        Special = 4
    }
    //---------------------------------------------------------
    public enum SitePagesTypes
    {
        //--------------------------------------
        Unknowen = 0,
        //--------------------------------------
        //Items pages from 1 to 99
        //--------------------------------------
        ItemsDefault = 1,
        ItemsDetails = 2,
        ItemsCategories = 3,
        ItemsRss = 4,
        ItemsGalleryHtml = 5,
        ItemsGalleryFlash = 6,
        ItemsSendComment = 7 
        //--------------------------------------

    }
    //---------------------------------------------------------
    
    //---------------------------------------------------------
    public enum ModuleTypes
    {
        //----------------------
        Unknowen = 0,
        //----------------------
        //Statics
        StaticPages = 1,
        StaticContents = 2,
        UsersProfiles = 3,
        SubSitePages = 4,
        //----------------------
        Artical = 11,
        Categories_Only = 12,
        Gallery = 13,
        Calendar = 14,
        //----------------------
        Messages_Only = 21,
        Messages_DataRegistation = 22,
        Messages_WithShow = 23,

        //----------------------
        UserRegitration = 31,
        Special = 101
        //----------------------
    }
    
    //---------------------------------------------------------
    
    public enum StandardItemsModuleTypes
    {
        UnKnowen = -1,
        //---------------------------------
        SitePages = 1,
        StaticContents = 2,
        UsersProfiles = 3,
        SubSitePages = 4,
        //---------------------------------
        Authors = 10,
        //---------------------------------
        About_Us = 11,
        //---------------------------------
        News = 12,
        Articles = 13,
        //---------------------------------
        Calendar = 14,
        //---------------------------------
        //SiteUrls = 15,
        PhotoGallery = 101,
        //-----------------------------
        //Messages Modules(forms)
        Contact_Us = 501,
        Consulting_Services = 502,
        VisitorSigns = 503,
        //UsersArticles = 504,
        //-----------------------------
        //User Modules
        Registration_User = 601,
        Registration_Consultant = 602,
        ////---------------------------
        //Specia Modules
        MailList = 1001,
        SMS = 1002,
        Vote = 1003,
        Advertisments = 1004,
        Cities = 1005,
        ShareLinks =1006,
        AdmininstrationMails=1007
    }
    //--------------------------------
    public enum OwnerInterfaceType
    {
        UnDefined = -1,
        MasterAdmin = 01,
        SubAdmin = 02,
        MasterSites = 11,
        SubSites = 12
    }


}
