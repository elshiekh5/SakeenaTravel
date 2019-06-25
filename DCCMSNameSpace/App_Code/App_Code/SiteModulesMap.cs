using System;
using System.Collections.Generic;

using System.Web;

namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for SiteModulesManager
    /// </summary>
    public enum SiteModulesMap
    {
        UnSpecified = -1,
        //----------------------------------
        //Reserved Modules
        //----------------------------------
        /*
        SitePages = 1,
        StaticContents = 2,
        UsersProfiles = 3,
        Authors = 10,
        About_Us = 11,
        News = 12,
        Articles = 13,
        Calendar = 13,
        PhotoGallery = 101,
        */
        //----------------------------------
        //----------------------------------
        //Reserved Modules
        //UsersProfiles = 3,
        About_Us = 11,
        News = 12,
        Products=16,
        TeamWork=17,
        //----------------------------------
        //Artical Modules
        Offers=20,
        Services = 21,
        Clients = 22,
        NewReleases = 22,

        Solutions = 23,

        Portfolio = 24,
        Vedios = 25,
        Events = 26,

        Mobile_Messages = 27,
        Friendly_Sites = 28,
        Projects = 29,
        PhotoGallery = 101,
        FaceBook_Partners = 51,
        //----------------------------------
        //SubSitesModule
        SubSites_UsersSites = 221,
        SubSites_UsersVideos = 222,
        SubSites_UsersPhotos = 223,
        SubSites_UsersFiles = 224,
        //----------------------------------
        //Messages Module
        Contact_Us = 501,
        Consulting_Services = 502,
        Motakhasesen = 511,
        FaceContact_Us = 551,
        //----------------------------------
        //Users module
        SiteUsers=601,
        Consultants=602,
        SiteMembers = 603
        //----------------------------------
    }


    public enum SitePages
    {
        UnSpecified = -1,
        //----------------------------------
        Welcome = 1,
        About_Us = 2,
        Contacts_Data = 3,
        RegistrationConditions = 4,
        //----------------------------------
        AboutUsSlogan = 11,
        TeamWorkIntro = 12,
        ServicesIntro = 13,
        PortfolioIntro=24,
        Consulting_Intro = 14,
        NormalUser_Registration_Intro = 15,
        SubSite_Registration_Intro = 16,

        //----------------------------------
        //Contact_Us = 1,
        //ConventiononTheSite = 2,
        LiveBroadcast = 21,
        Mobile_Messages_Intro =22,
        FBWelcome = 51,
        FBAbout_Us = 52,
        FBContact_UsIntro = 53
    }

}