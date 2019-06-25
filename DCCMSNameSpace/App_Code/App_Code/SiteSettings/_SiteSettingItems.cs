using System;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web;
using DCCMSNameSpace;
using System.Web.Security;


namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for SiteSettingItems
    /// </summary>
    public enum DateTypes
    {
        Georgian = 1,
        Islamic = 2,
        GeorgianAndIslamic = 3
    }
    public enum SiteSettingItems
    {
        //Site Comments
        Comments_Enable = 1,
        Comments_RefuseLimmets = 2,
        Comments_AllowDays = 3,
        Comments_CommentsPerPage = 4,
        Comments_HasCommentTitle = 5,
        Comments_HasCountry = 6,
        Comments_HasSenderEmail = 7,
        //---------------------------------------
        //MailList Options
        MailList_HasMaillist = 100,
        MailList_MailSMTP = 101,
        MailList_MailSMTPPort = 102,
        MailList_MailUserName = 103,
        MailList_MailPassWord = 104,
        MailList_MailFrom = 105,
        MailList_MailFromCon = 106,
        MailList_MailFromName = 107,
        MailList_MailMaxNoOfTries = 108,
        //MailList_TempEmailsPath = 112,
        MailList_HasGroups = 113,
        MailList_MaxBccCount = 114,
        MailList_SendingTo = 115,//(for sending as bcc)
        MailList_HasAttachments = 116,
        MailList_MaxAttachFilesCount = 117,
        MailList_MaxAllAttachSize = 118,
        MailList_SendingIntervalBySeconds = 119,
        MailList_HasArchive = 120,
        MailList_HasImportFromTxtFile = 121,
        MailList_HasImportFromExcellFile = 122,
        MailList_HasExportToExcellFile =123,
        MailList_HasEmailDesign = 124,
        //---------------------------------------
        //Site Options--------------------------- 
        Site_SiteTitle = 200,//string
        Site_WebsiteDomain = 201,
        Site_AdminPageSize = 202,//int
        Site_AllowDublicateTitles = 203,//bool
        Site_Comment = 204,//string
        Site_HasMultiLanguageDesign = 205,//string
        Site_HasAdminMainImages = 206,//string
        Site_IpWebServicePassword = 207,
        Site_IpCountryService = 208,
        Site_VisitorsCount = 210,
        Site_WebsiteDesignFolder = 211,
        //---------------------------------------
        Site_LastModification = 212,
        Site_CookieName = 213,
        //---------------------------------------
        Site_AdminUrl = 253,
        //---------------------------------------
        //---------------------------------------
        //Advertisments Options
        Adv_HasAdvertisments = 301,
        Adv_HasDefaultFile = 302,
        Adv_HasIsRandom = 303,
        Adv_HasMaxApperance = 304,
        Adv_HasMaxClicks = 305,
        Adv_HasWeight = 306,
        Adv_EnablePlacesControl = 307,
        Adv_EnableSeparatedAd = 308,
        //---------------------------------------
        //Vote Options 
        Vote_Enabled = 401,
        Vote_MaxChoices = 402,
        Vote_ImageMaxLength = 403,
        Vote_ImageMinLength = 404,
        Vote_CloseDuplicateVotingByCookie = 405,
        //---------------------------------------
        //Photos options 
        //---------------------------------------
        Photos_PhotosAvailbleExtensions = 501,
        Photos_SavePhotoDimensions = 502,
        //---------------------------------------
        Photos_WebSite_MicroThumnailWidth = 503,
        Photos_WebSite_MicroThumnailHeight = 504,
        Photos_WebSite_MiniThumnailWidth = 505,
        Photos_WebSite_MiniThumnailHeight = 506,
        Photos_WebSite_NormalThumnailWidth = 507,
        Photos_WebSite_NormalThumnailHeight = 508,
        Photos_WebSite_BigThumnailWidth = 509,
        Photos_WebSite_BigThumnailHeight = 5010,
        //-----------------
        Photos_WebSite_VListWidth = 511,
        Photos_WebSite_VListHeight = 512,
        Photos_WebSite_HListWidth = 513,
        Photos_WebSite_HListHeight = 514,
        Photos_WebSite_DetailsPageWidth = 515,
        Photos_WebSite_DetailsPageHeight = 516,
        //---------------------------------------
      
        //SpecialModules options
        SpecialModules_AdvertismentsEnabled = 601,//int
        SpecialModules_CitisEnabled = 602,
        SpecialModules_ShareLinksEnabled = 603,
        SpecialModules_SecurityEnabled = 604,
        SpecialModules_VisitorsCountEnabled = 605,
        SpecialModules_StatisticsEnabled = 606,
        SpecialModules_GoogleStatisticsEnabled = 607,
        //----------------------------------------
        //Languages options
        Languages_DefaultLanguageID = 701,//int
        Languages_HasArabicLanguages = 702,//int
        Languages_HasEnglishLanguages = 703,//int
        Languages_AdminLanguageID = 704,//int
        //-----------------------------------------
        //SMS
        Sms_HasSms = 801,
        Sms_HasGroups = 802,
        Sms_HasArchive = 803,
        Sms_URL = 804,
        Sms_AccountUserName = 805,
        Sms_AccountPassword = 806,
        Sms_Numbers = 807,
        Sms_Sender = 808,
        Sms_Message = 809,
        Sms_SMSKey = 810,
        Sms_HasImportFromTxtFile = 812,
        Sms_HasImportFromExcellFile = 813,
        Sms_HasExportToExcellFile =814,
        //-----------------------------------------
        //Zecurity
        ZecurityUnSafePathes = 901,
        ZecurityAdminFolder = 902,
        ZecurityAdminDefaultPage = 903,
        ZecurityErrorPagePath = 904,
        //-----------------------------------------
        Captcha_AllowInMessagesModules = 1001,
        Captcha_AllowInSendComment = 1002,
        Captcha_AllowInTellAFfiend = 1003,
        //-----------------------------------------
        OtherLinks_Facebook = 10001,
        OtherLinks_Twitter = 10002,
        OtherLinks_YouTube = 10003,
        OtherLinks_LinkedIn = 10004,
        OtherLinks_GooglePlus = 10005,
        //-----------------------------------------
        SiteInterface_InnerWebsiteWidth = 1101,
        SiteInterface_InnerFacebookWidth = 1102,
        SiteInterface_InnerMobileSiteWidth = 1103,
        SiteInterface_InnerMobileAppWidth = 1104,
        SiteInterface_HasWebsiteBaseControls = 1105,

        //-----------------------------------------
        Admininstration_HasAdminEmail = 1201,
        Admininstration_HasAdminBccEmail = 1202,
        Admininstration_AdminEmail = 1203,
        Admininstration_AdminBccEmail = 1204,
        Admininstration_SiteDefaultCountryID = 1205,
        //-----------------------------------------
    }
    //---------------------------------------------

    public class SiteSettings
    {

        #region ----------------Comments Options----------------
        //---------------------------------------
        //Comments Options
        //---------------------------------------
        #region ----------------Comments_Enable----------------
        //---------------------------------------
        //Comments_Enable
        //---------------------------------------
        public static bool Comments_Enable
        {
            get
            {
                return Convert.ToBoolean(GetValue(SiteSettingItems.Comments_Enable));
            }
        }
        #endregion

        #region ----------------Comments_RefuseLimmets----------------
        //---------------------------------------
        //Comments_RefuseLimmets
        //---------------------------------------
        public static int Comments_RefuseLimmets
        {
            get
            {
                return Convert.ToInt32(GetValue(SiteSettingItems.Comments_RefuseLimmets));
            }
        }
        #endregion

        #region ----------------Comments_AllowDays----------------
        //---------------------------------------
        //Comments_AllowDays
        //---------------------------------------
        public static int Comments_AllowDays
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Comments_AllowDays));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Comments_CommentsPerPage----------------
        //---------------------------------------
        //Comments_CommentsPerPage
        //---------------------------------------
        public static int Comments_CommentsPerPage
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Comments_CommentsPerPage));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Comments_HasCommentTitle----------------
        //---------------------------------------
        //Comments_HasCommentTitle
        //---------------------------------------
        public static bool Comments_HasCommentTitle
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Comments_HasCommentTitle));
            }
        }
        #endregion

        #region ----------------Comments_HasCountry----------------
        //---------------------------------------
        //Comments_HasCountry
        //---------------------------------------
        public static bool Comments_HasCountry
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Comments_HasCountry));
            }
        }
        #endregion

        #region ----------------Comments_HasSenderEmail----------------
        //---------------------------------------
        //Comments_HasSenderEmail
        //---------------------------------------
        public static bool Comments_HasSenderEmail
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Comments_HasSenderEmail));
            }
        }
        #endregion
        //---------------------------------------
        #endregion

        #region ----------------MailList Options----------------
        //---------------------------------------
        //MailList Options
        //---------------------------------------
        #region ----------------MailList_MailSMTP----------------
        //---------------------------------------
        //MailList_MailSMTP
        //---------------------------------------
        public static string MailList_MailSMTP
        {
            get
            {


                return (string)GetValue(SiteSettingItems.MailList_MailSMTP);
            }
        }
        #endregion

        #region ----------------MailList_HasMaillist----------------
        //---------------------------------------
        //MailList_HasMaillist
        //---------------------------------------
        public static bool MailList_HasMaillist
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.MailList_HasMaillist));
            }
        }
        #endregion

        #region ----------------MailList_MailSMTPPort----------------
        //---------------------------------------
        //MailList_MailSMTPPort
        //---------------------------------------
        public static int MailList_MailSMTPPort
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.MailList_MailSMTPPort));
            }
        }
        #endregion

        #region ----------------MailList_MailUserName----------------
        //---------------------------------------
        //MailList_MailUserName
        //---------------------------------------
        public static string MailList_MailUserName
        {
            get
            {


                return (string)GetValue(SiteSettingItems.MailList_MailUserName);
            }
        }
        #endregion

        #region ----------------MailList_MailPassWord----------------
        //---------------------------------------
        //MailList_MailPassWord
        //---------------------------------------
        public static string MailList_MailPassWord
        {
            get
            {


                return (string)GetValue(SiteSettingItems.MailList_MailPassWord);
            }
        }
        #endregion

        #region ----------------MailList_MailFrom----------------
        //---------------------------------------
        //MailList_MailFrom
        //---------------------------------------
        public static string MailList_MailFrom
        {
            get
            {


                return (string)GetValue(SiteSettingItems.MailList_MailFrom);
            }
        }
        #endregion

        #region ----------------MailList_MailFromCon----------------
        //---------------------------------------
        //MailList_MailFromCon
        //---------------------------------------
        public static string MailList_MailFromCon
        {
            get
            {


                return (string)GetValue(SiteSettingItems.MailList_MailFromCon);
            }
        }
        #endregion

        #region ----------------MailList_MailFromName----------------
        //---------------------------------------
        //MailList_MailFromName
        //---------------------------------------
        public static string MailList_MailFromName
        {
            get
            {


                return (string)GetValue(SiteSettingItems.MailList_MailFromName);
            }
        }
        #endregion

        #region ----------------MailList_MailMaxNoOfTries----------------
        //---------------------------------------
        //MailList_MailMaxNoOfTries
        //---------------------------------------
        public static int MailList_MailMaxNoOfTries
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.MailList_MailMaxNoOfTries));
            }
        }
        #endregion

        



        #region ----------------MailList_HasGroups----------------
        //---------------------------------------
        //MailList_HasGroups
        //---------------------------------------
        public static bool MailList_HasGroups
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.MailList_HasGroups));
            }
        }
        #endregion

        #region ----------------MailList_MaxBccCount----------------
        //---------------------------------------
        //MailList_MaxBccCount
        //---------------------------------------
        public static int MailList_MaxBccCount
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.MailList_MaxBccCount));
            }
        }
        #endregion

        #region ----------------MailList_SendingTo----------------
        //---------------------------------------
        //MailList_SendingTo
        //---------------------------------------
        public static string MailList_SendingTo
        {
            get
            {


                return (string)GetValue(SiteSettingItems.MailList_SendingTo);
            }
        }
        #endregion

        #region ----------------MailList_HasAttachments----------------
        //---------------------------------------
        //MailList_HasAttachments
        //---------------------------------------
        public static bool MailList_HasAttachments
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.MailList_HasAttachments));
            }
        }
        #endregion

        #region ----------------MailList_MaxAttachFiles----------------
        //---------------------------------------
        //MailList_MaxAttachFiles
        //---------------------------------------
        public static int MailList_MaxAttachFiles
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.MailList_MaxAttachFilesCount));
            }
        }
        #endregion

        #region ----------------MailList_MaxAllAttachSize----------------
        //---------------------------------------
        //MailList_MaxAllAttachSize
        //---------------------------------------
        public static int MailList_MaxAllAttachSize
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.MailList_MaxAllAttachSize));
            }
        }
        #endregion



        #region ----------------MailList_SendingIntervalBySeconds----------------
        //---------------------------------------
        //MailList_SendingIntervalBySeconds
        //---------------------------------------
        public static int MailList_SendingIntervalBySeconds
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.MailList_SendingIntervalBySeconds));
            }
        }
        #endregion

        #region ----------------MailList_HasArchive----------------
        //---------------------------------------
        //MailList_HasArchive
        //---------------------------------------
        public static bool MailList_HasArchive
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.MailList_HasArchive));
            }
        }
        #endregion


        #region ----------------MailList_HasImportFromTxtFile----------------
        //---------------------------------------
        //MailList_HasImportFromTxtFile
        //---------------------------------------
        public static bool MailList_HasImportFromTxtFile
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.MailList_HasImportFromTxtFile));
            }
        }
        #endregion


        #region ----------------MailList_HasImportFromExcellFile----------------
        //---------------------------------------
        //MailList_HasImportFromExcellFile
        //---------------------------------------
        public static bool MailList_HasImportFromExcellFile
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.MailList_HasImportFromExcellFile));
            }
        }
        #endregion
        //---------------------------------------

        #region ----------------MailList_HasExportToExcellFile----------------
        //---------------------------------------
        //MailList_HasExportToExcellFile
        //---------------------------------------
        public static bool MailList_HasExportToExcellFile
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.MailList_HasExportToExcellFile));
            }
        }
        #endregion
        //---------------------------------------
        #region ----------------MailList_HasEmailDesign----------------
        //---------------------------------------
        //MailList_HasEmailDesign
        //---------------------------------------
        public static bool MailList_HasEmailDesign
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.MailList_HasEmailDesign));
            }
        }
        #endregion
        //---------------------------------------

        #endregion

        #region ----------------Sms Options----------------
        //---------------------------------------
        //Sms Options
        //---------------------------------------
        #region ----------------Sms_HasSms----------------
        //---------------------------------------
        //Sms_HasSms
        //---------------------------------------
        public static bool Sms_HasSms
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Sms_HasSms));
            }
        }
        #endregion

        #region ----------------Sms_HasGroups----------------
        //---------------------------------------
        //Sms_HasGroups
        //---------------------------------------
        public static bool Sms_HasGroups
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Sms_HasGroups));
            }
        }
        #endregion

        #region ----------------Sms_HasArchive----------------
        //---------------------------------------
        //Sms_HasArchive
        //---------------------------------------
        public static bool Sms_HasArchive
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Sms_HasArchive));
            }
        }
        #endregion

        #region ----------------Sms_URL----------------
        //---------------------------------------
        //Sms_URL
        //---------------------------------------
        public static string Sms_URL
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Sms_URL);
            }
        }
        #endregion

        #region ----------------Sms_AccountUserName----------------
        //---------------------------------------
        //Sms_AccountUserName
        //---------------------------------------
        public static string Sms_AccountUserName
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Sms_AccountUserName);
            }
        }
        #endregion

        #region ----------------Sms_AccountPassword----------------
        //---------------------------------------
        //Sms_AccountPassword
        //---------------------------------------
        public static string Sms_AccountPassword
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Sms_AccountPassword);
            }
        }
        #endregion

        #region ----------------Sms_Numbers----------------
        //---------------------------------------
        //Sms_Numbers
        //---------------------------------------
        public static string Sms_Numbers
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Sms_Numbers);
            }
        }
        #endregion

        #region ----------------Sms_Sender----------------
        //---------------------------------------
        //Sms_Sender
        //---------------------------------------
        public static string Sms_Sender
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Sms_Sender);
            }
        }
        #endregion

        #region ----------------Sms_Message----------------
        //---------------------------------------
        //Sms_Message
        //---------------------------------------
        public static string Sms_Message
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Sms_Message);
            }
        }
        #endregion

        #region ----------------Sms_SMSKey----------------
        //---------------------------------------
        //Sms_SMSKey
        //---------------------------------------
        public static string Sms_SMSKey
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Sms_SMSKey);
            }
        }
        #endregion

        #region ----------------Sms_HasImportFromTxtFile----------------
        //---------------------------------------
        //Sms_HasImportFromTxtFile
        //---------------------------------------
        public static bool Sms_HasImportFromTxtFile
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Sms_HasImportFromTxtFile));
            }
        }
        #endregion

        #region ----------------Sms_HasImportFromExcellFile----------------
        //---------------------------------------
        //Sms_HasImportFromExcellFile
        //---------------------------------------
        public static bool Sms_HasImportFromExcellFile
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Sms_HasImportFromExcellFile));
            }
        }
        #endregion

        #region ----------------Sms_HasExportToExcellFile----------------
        //---------------------------------------
        //Sms_HasExportToExcellFile
        //---------------------------------------
        public static bool Sms_HasExportToExcellFile
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Sms_HasExportToExcellFile));
            }
        }
        #endregion

        //---------------------------------------
        #endregion

        #region ----------------Global Site Options----------------
        //---------------------------------------
        //Global Site Options
        //---------------------------------------

        #region ----------------Site_SiteTitle----------------
        //---------------------------------------
        //Site_SiteTitle
        //---------------------------------------
        public static string Site_SiteTitle
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Site_SiteTitle);
            }
        }
        #endregion

        #region ----------------Site_AdminPageSize----------------
        //---------------------------------------
        //Site_AdminPageSize
        //---------------------------------------
        public static int Site_AdminPageSize
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Site_AdminPageSize));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Site_AllowDublicateTitles----------------
        //---------------------------------------
        //Site_AllowDublicateTitles
        //---------------------------------------
        public static bool Site_AllowDublicateTitles
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Site_AllowDublicateTitles));
            }
        }
        #endregion

        #region ----------------Site_Comment----------------
        //---------------------------------------
        //Site_Comment
        //---------------------------------------
        public static string Site_Comment
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Site_Comment);
            }
        }
        #endregion

        #region ----------------Site_HasMultiLanguageDesign----------------
        //---------------------------------------
        //Site_HasMultiLanguageDesign
        //---------------------------------------
        public static bool Site_HasMultiLanguageDesign
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Site_HasMultiLanguageDesign));
            }
        }
        #endregion

        #region ----------------Site_HasAdminMainImages----------------
        //---------------------------------------
        //Site_HasAdminMainImages
        //---------------------------------------
        public static bool Site_HasAdminMainImages
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Site_HasAdminMainImages));
            }
        }
        #endregion

        #region ----------------Site_VisitorsCount----------------
        //---------------------------------------
        //Site_VisitorsCount
        //---------------------------------------
        public static int Site_VisitorsCount
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Site_VisitorsCount));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Site_IpWebServicePassword----------------
        //---------------------------------------
        //Site_IpWebServicePassword
        //---------------------------------------
        public static string Site_IpWebServicePassword
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Site_IpWebServicePassword);
            }
        }
        #endregion

        #region ----------------Site_IpCountryService----------------
        //---------------------------------------
        //Site_IpCountryService
        //---------------------------------------
        public static string Site_IpCountryService
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Site_IpCountryService);
            }
        }
        #endregion
        //---------------------------------------

        #region ----------------Site_AdminUrl----------------
        //---------------------------------------
        //Site_AdminUrl
        //---------------------------------------
        public static string Site_AdminUrl
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Site_AdminUrl);
            }
        }
        #endregion
        #endregion

        #region ----------------Site_WebsiteDomain----------------
        //---------------------------------------
        //Site_WebsiteDomain
        //---------------------------------------
        public static string Site_WebsiteDomain
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Site_WebsiteDomain);
            }
        }
        #endregion

        #region ----------------Site_WebsiteDesignFolder----------------
        //---------------------------------------
        //Site_WebsiteDesignFolder
        //---------------------------------------
        public static string Site_WebsiteDesignFolder
        {
            get
            {
                //return (string)GetValue(SiteSettingItems.Site_WebsiteDesignFolder);
                return "/WebSite/";
            }
        }
        #endregion

        #region ----------------Site_CookieName----------------
        //---------------------------------------
        //Site_CookieName
        //---------------------------------------
        public static string Site_CookieName
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Site_CookieName);
            }
        }
        #endregion


        

        

        

        

        #region ----------------Site_LastModification----------------
        //---------------------------------------
        //Site_LastModification
        //---------------------------------------
        public static string Site_LastModification
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Site_LastModification);
            }
        }
        #endregion

        #region ----------------Photos Options In WebSite----------------
        //---------------------------------------
        //Photos Options In WebSite
        //---------------------------------------

        #region ----------------Photos_WebSite_MicroThumnailWidth----------------
        //---------------------------------------
        //Photos_WebSite_MicroThumnailWidth
        //---------------------------------------
        public static int Photos_WebSite_MicroThumnailWidth
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_MicroThumnailWidth));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_MicroThumnailHeight----------------
        //---------------------------------------
        //Photos_WebSite_MicroThumnailHeight
        //---------------------------------------
        public static int Photos_WebSite_MicroThumnailHeight
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_MicroThumnailHeight));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_MiniThumnailWidth----------------
        //---------------------------------------
        //Photos_WebSite_MiniThumnailWidth
        //---------------------------------------
        public static int Photos_WebSite_MiniThumnailWidth
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_MiniThumnailWidth));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_MiniThumnailHeight----------------
        //---------------------------------------
        //Photos_WebSite_MiniThumnailHeight
        //---------------------------------------
        public static int Photos_WebSite_MiniThumnailHeight
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_MiniThumnailHeight));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_NormalThumnailWidth----------------
        //---------------------------------------
        //Photos_WebSite_NormalThumnailWidth
        //---------------------------------------
        public static int Photos_WebSite_NormalThumnailWidth
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_NormalThumnailWidth));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_NormalThumnailHeight----------------
        //---------------------------------------
        //Photos_WebSite_NormalThumnailHeight
        //---------------------------------------
        public static int Photos_WebSite_NormalThumnailHeight
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_NormalThumnailHeight));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_BigThumnailWidth----------------
        //---------------------------------------
        //Photos_WebSite_BigThumnailWidth
        //---------------------------------------
        public static int Photos_WebSite_BigThumnailWidth
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_BigThumnailWidth));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_BigThumnailHeight----------------
        //---------------------------------------
        //Photos_WebSite_BigThumnailHeight
        //---------------------------------------
        public static int Photos_WebSite_BigThumnailHeight
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_BigThumnailHeight));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_VListWidth----------------
        //---------------------------------------
        //Photos_WebSite_VListWidth
        //---------------------------------------
        public static int Photos_WebSite_VListWidth
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_VListWidth));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_VListHeight----------------
        //---------------------------------------
        //Photos_WebSite_VListHeight
        //---------------------------------------
        public static int Photos_WebSite_VListHeight
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_VListHeight));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_HListWidth----------------
        //---------------------------------------
        //Photos_WebSite_HListWidth
        //---------------------------------------
        public static int Photos_WebSite_HListWidth
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_HListWidth));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_HListHeight----------------
        //---------------------------------------
        //Photos_WebSite_HListHeight
        //---------------------------------------
        public static int Photos_WebSite_HListHeight
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_HListHeight));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_DetailsPageWidth----------------
        //---------------------------------------
        //Photos_WebSite_DetailsPageWidth
        //---------------------------------------
        public static int Photos_WebSite_DetailsPageWidth
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_DetailsPageWidth));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_WebSite_DetailsPageHeight----------------
        //---------------------------------------
        //Photos_WebSite_DetailsPageHeight
        //---------------------------------------
        public static int Photos_WebSite_DetailsPageHeight
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Photos_WebSite_DetailsPageHeight));
            }

        }
        //---------------------------------------
        #endregion

        #endregion


        



        #region ----------------Advertisments Options----------------
        //---------------------------------------
        //Advertisments Options
        //---------------------------------------
        #region ----------------Adv_HasAdvertisments----------------
        //---------------------------------------
        //Adv_HasAdvertisments
        //---------------------------------------
        public static bool Adv_HasAdvertisments
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Adv_HasAdvertisments));
            }
        }
        #endregion

        #region ----------------Adv_HasDefaultFile----------------
        //---------------------------------------
        //Adv_HasDefaultFile
        //---------------------------------------
        public static bool Adv_HasDefaultFile
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Adv_HasDefaultFile));
            }
        }
        #endregion

        #region ----------------Adv_HasIsRandom----------------
        //---------------------------------------
        //Adv_HasIsRandom
        //---------------------------------------
        public static bool Adv_HasIsRandom
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Adv_HasIsRandom));
            }
        }
        #endregion

        #region ----------------Adv_HasMaxApperance----------------
        //---------------------------------------
        //Adv_HasMaxApperance
        //---------------------------------------
        public static bool Adv_HasMaxApperance
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Adv_HasMaxApperance));
            }
        }
        #endregion

        #region ----------------Adv_HasMaxClicks----------------
        //---------------------------------------
        //Adv_HasMaxClicks
        //---------------------------------------
        public static bool Adv_HasMaxClicks
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Adv_HasMaxClicks));
            }
        }
        #endregion

        #region ----------------Adv_HasWeight----------------
        //---------------------------------------
        //Adv_HasWeight
        //---------------------------------------
        public static bool Adv_HasWeight
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Adv_HasWeight));
            }
        }
        #endregion

        #region ----------------Adv_EnablePlacesControl----------------
        //---------------------------------------
        //Adv_EnablePlacesControl
        //---------------------------------------
        public static bool Adv_EnablePlacesControl
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Adv_EnablePlacesControl));
            }
        }
        #endregion

        #region ----------------Adv_EnableSeparatedAd----------------
        //---------------------------------------
        //Adv_EnableSeparatedAd
        //---------------------------------------
        public static bool Adv_EnableSeparatedAd
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Adv_EnableSeparatedAd));
            }
        }
        #endregion


        //---------------------------------------
        #endregion

        #region ----------------Vote----------------
        //---------------------------------------
        //Vote
        //---------------------------------------

        #region ----------------Vote_Enabled----------------
        //---------------------------------------
        //Vote_Enabled
        //---------------------------------------
        public static bool Vote_Enabled
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Vote_Enabled));
            }
        }
        #endregion

        #region ----------------Vote_MaxChoices----------------
        //---------------------------------------
        //Vote_MaxChoices
        //---------------------------------------
        public static int Vote_MaxChoices
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Vote_MaxChoices));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Vote_ImageMaxLength----------------
        //---------------------------------------
        //Vote_ImageMaxLength
        //---------------------------------------
        public static int Vote_ImageMaxLength
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Vote_ImageMaxLength));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Vote_ImageMinLength----------------
        //---------------------------------------
        //Vote_ImageMinLength
        //---------------------------------------
        public static int Vote_ImageMinLength
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Vote_ImageMinLength));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Vote_CloseDuplicateVotingByCookie----------------
        //---------------------------------------
        //Vote_CloseDuplicateVotingByCookie
        //---------------------------------------
        public static bool Vote_CloseDuplicateVotingByCookie
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Vote_CloseDuplicateVotingByCookie));
            }
        }
        #endregion

        #endregion

        #region ----------------SpecialModules Options----------------
        //---------------------------------------
        //SpecialModules Options
        //---------------------------------------
        #region ----------------SpecialModules_AdvertismentsEnabled----------------
        //---------------------------------------
        //SpecialModules_AdvertismentsEnabled
        //---------------------------------------
        public static bool SpecialModules_AdvertismentsEnabled
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.SpecialModules_AdvertismentsEnabled));
            }
        }
        #endregion

        #region ----------------SpecialModules_CitisEnabled----------------
        //---------------------------------------
        //SpecialModules_CitisEnabled
        //---------------------------------------
        public static bool SpecialModules_CitisEnabled
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.SpecialModules_CitisEnabled));
            }
        }
        #endregion

        #region ----------------SpecialModules_ShareLinksEnabled----------------
        //---------------------------------------
        //SpecialModules_ShareLinksEnabled
        //---------------------------------------
        public static bool SpecialModules_ShareLinksEnabled
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.SpecialModules_ShareLinksEnabled));
            }
        }
        #endregion

        #region ----------------SpecialModules_SecurityEnabled----------------
        //---------------------------------------
        //SpecialModules_SecurityEnabled
        //---------------------------------------
        public static bool SpecialModules_SecurityEnabled
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.SpecialModules_SecurityEnabled));
            }
        }
        #endregion

        #region ----------------SpecialModules_VisitorsCountEnabled----------------
        //---------------------------------------
        //SpecialModules_VisitorsCountEnabled
        //---------------------------------------
        public static bool SpecialModules_VisitorsCountEnabled
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.SpecialModules_VisitorsCountEnabled));
            }
        }
        #endregion

        #region ----------------SpecialModules_StatisticsEnabled----------------
        //---------------------------------------
        //SpecialModules_StatisticsEnabled
        //---------------------------------------
        public static bool SpecialModules_StatisticsEnabled
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.SpecialModules_StatisticsEnabled));
            }
        }
        #endregion

        #region ----------------SpecialModules_GoogleStatisticsEnabled----------------
        //---------------------------------------
        //SpecialModules_GoogleStatisticsEnabled
        //---------------------------------------
        public static bool SpecialModules_GoogleStatisticsEnabled
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.SpecialModules_GoogleStatisticsEnabled));
            }
        }
        #endregion

        //---------------------------------------
        #endregion

        #region ----------------OtherLinks Options----------------
        //---------------------------------------
        //Comments Options
        //---------------------------------------


        #region ----------------OtherLinks_Facebook----------------
        //---------------------------------------
        //OtherLinks_Facebook
        //---------------------------------------
        public static string OtherLinks_Facebook
        {
            get
            {


                return (string)GetValue(SiteSettingItems.OtherLinks_Facebook);
            }
        }
        #endregion



        #region ----------------OtherLinks_Twitter----------------
        //---------------------------------------
        //OtherLinks_Twitter
        //---------------------------------------
        public static string OtherLinks_Twitter
        {
            get
            {


                return (string)GetValue(SiteSettingItems.OtherLinks_Twitter);
            }
        }
        #endregion

        #region ----------------OtherLinks_YouTube----------------
        //---------------------------------------
        //OtherLinks_YouTube
        //---------------------------------------
        public static string OtherLinks_YouTube
        {
            get
            {


                return (string)GetValue(SiteSettingItems.OtherLinks_YouTube);
            }
        }
        #endregion

        #region ----------------OtherLinks_LinkedIn----------------
        //---------------------------------------
        //OtherLinks_LinkedIn
        //---------------------------------------
        public static string OtherLinks_LinkedIn
        {
            get
            {


                return (string)GetValue(SiteSettingItems.OtherLinks_LinkedIn);
            }
        }
        #endregion

        #region ----------------OtherLinks_GooglePlus----------------
        //---------------------------------------
        //OtherLinks_GooglePlus
        //---------------------------------------
        public static string OtherLinks_GooglePlus
        {
            get
            {


                return (string)GetValue(SiteSettingItems.OtherLinks_GooglePlus);
            }
        }
        #endregion

        //---------------------------------------
        #endregion

        #region ----------------Zecurity----------------
        //---------------------------------------
        //Zecurity
        //---------------------------------------

        #region ----------------ZecurityUnSafePathes----------------
        //---------------------------------------
        //ZecurityUnSafePathes
        //---------------------------------------
        public static string ZecurityUnSafePathes
        {
            get
            {


                return (string)GetValue(SiteSettingItems.ZecurityUnSafePathes);
            }
        }
        #endregion

        #region ----------------ZecurityAdminFolder----------------
        //---------------------------------------
        //ZecurityAdminFolder
        //---------------------------------------
        public static string ZecurityAdminFolder
        {
            get
            {


                return (string)GetValue(SiteSettingItems.ZecurityAdminFolder);
            }
        }
        #endregion

        #region ----------------ZecurityAdminDefaultPage----------------
        //---------------------------------------
        //ZecurityAdminDefaultPage
        //---------------------------------------
        public static string ZecurityAdminDefaultPage
        {
            get
            {


                return (string)GetValue(SiteSettingItems.ZecurityAdminDefaultPage);
            }
        }
        #endregion

        #region ----------------ZecurityErrorPagePath----------------
        //---------------------------------------
        //ZecurityErrorPagePath
        //---------------------------------------
        public static string ZecurityErrorPagePath
        {
            get
            {


                return (string)GetValue(SiteSettingItems.ZecurityErrorPagePath);
            }
        }
        #endregion

        #endregion

        #region ----------------Captcha Options----------------
        //---------------------------------------
        //Captcha Options
        //---------------------------------------
        #region ----------------Captcha_AllowInMessagesModules----------------
        //---------------------------------------
        //Captcha_AllowInMessagesModules
        //---------------------------------------
        public static bool Captcha_AllowInMessagesModules
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Captcha_AllowInMessagesModules));
            }
        }
        #endregion

        #region ----------------Captcha_AllowInSendComment----------------
        //---------------------------------------
        //Captcha_AllowInSendComment
        //---------------------------------------
        public static bool Captcha_AllowInSendComment
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Captcha_AllowInSendComment));
            }
        }
        #endregion

        #region ----------------Captcha_AllowInTellAFfiend----------------
        //---------------------------------------
        //Captcha_AllowInTellAFfiend
        //---------------------------------------
        public static bool Captcha_AllowInTellAFfiend
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Captcha_AllowInTellAFfiend));
            }
        }
        #endregion

        #endregion

        #region ----------------SiteInterface Options----------------
        #region ----------------SiteInterface_HasWebsiteBaseControls----------------
        //---------------------------------------
        //SiteInterface_HasWebsiteBaseControls
        //---------------------------------------
        public static bool SiteInterface_HasWebsiteBaseControls
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.SiteInterface_HasWebsiteBaseControls));
            }
        }
        #endregion
        #region ----------------SiteInterface_InnerWebsiteWidth----------------
        //---------------------------------------
        //SiteInterface_InnerWebsiteWidth
        //---------------------------------------
        public static int SiteInterface_InnerWebsiteWidth
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.SiteInterface_InnerWebsiteWidth));
            }
        }
        #endregion

        #region ----------------SiteInterface_InnerFacebookWidth----------------
        //---------------------------------------
        //SiteInterface_InnerFacebookWidth
        //---------------------------------------
        public static int SiteInterface_InnerFacebookWidth
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.SiteInterface_InnerFacebookWidth));
            }
        }
        #endregion

        #region ----------------SiteInterface_InnerMobileSiteWidth----------------
        //---------------------------------------
        //SiteInterface_InnerMobileSiteWidth
        //---------------------------------------
        public static int SiteInterface_InnerMobileSiteWidth
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.SiteInterface_InnerMobileSiteWidth));
            }
        }
        #endregion

        
        #endregion



        #region ----------------Admininstration Options----------------

        #region ----------------Admininstration_HasAdminEmail----------------
        //---------------------------------------
        //Admininstration_HasAdminEmail
        //---------------------------------------
        public static bool Admininstration_HasAdminEmail
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Admininstration_HasAdminEmail));
            }
        }
        #endregion

        #region ----------------Admininstration_HasAdminBccEmail----------------
        //---------------------------------------
        //Admininstration_HasAdminBccEmail
        //---------------------------------------
        public static bool Admininstration_HasAdminBccEmail
        {
            get
            {


                return  Convert.ToBoolean(GetValue(SiteSettingItems.Admininstration_HasAdminBccEmail));
            }
        }
        #endregion

        #region ----------------Admininstration_AdminEmail----------------
        //---------------------------------------
        //Admininstration_AdminEmail
        //---------------------------------------
        public static string Admininstration_AdminEmail
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Admininstration_AdminEmail);
            }
        }
        #endregion

        #region ----------------Admininstration_AdminBccEmail----------------
        //---------------------------------------
        //Admininstration_AdminBccEmail
        //---------------------------------------
        public static string Admininstration_AdminBccEmail
        {
            get
            {


                return (string)GetValue(SiteSettingItems.Admininstration_AdminBccEmail);
            }
        }
        #endregion
        #region ----------------Admininstration_SiteDefaultCountryID----------------
        //---------------------------------------
        //Admininstration_SiteDefaultCountryID
        //---------------------------------------
        public static int Admininstration_SiteDefaultCountryID
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Admininstration_SiteDefaultCountryID));
            }
        }
        #endregion
        #endregion

        private static Hashtable _AllSiteSettings = new Hashtable();
        public static Hashtable AllSiteSettings
        {
            get
            {
                return _AllSiteSettings;
            }
            set { _AllSiteSettings = value; }
        }
        //----------------------------------------------------------//
        public static DateTypes SiteDateType = DateTypes.Georgian;
        //----------------------------------------------------------//
        #region ----------------Languages Options----------------
        //---------------------------------------
        //Languages Options
        //---------------------------------------
        #region ----------------Languages_DefaultLanguageID----------------
        //---------------------------------------
        //Languages_DefaultLanguageID
        //---------------------------------------
        public static int Languages_DefaultLanguageID
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Languages_DefaultLanguageID));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Languages_AdminLanguageID----------------
        //---------------------------------------
        //Languages_AdminLanguageID
        //---------------------------------------
        public static int Languages_AdminLanguageID
        {
            get
            {


                return Convert.ToInt32(GetValue(SiteSettingItems.Languages_AdminLanguageID));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Languages_HasArabicLanguages----------------
        //---------------------------------------
        //Languages_HasArabicLanguages
        //---------------------------------------
        public static bool Languages_HasArabicLanguages
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Languages_HasArabicLanguages));
            }
        }
        #endregion
        #region ----------------Languages_HasEnglishLanguages----------------
        //---------------------------------------
        //Languages_HasEnglishLanguages
        //---------------------------------------
        public static bool Languages_HasEnglishLanguages
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Languages_HasEnglishLanguages));
            }
        }
        #endregion

        #region ----------------Languages_HasMultiLanguages----------------
        //---------------------------------------
        //Languages_HasMultiLanguages
        //---------------------------------------
        public static bool Languages_HasMultiLanguages
        {
            get
            {
                return (Languages_HasArabicLanguages && Languages_HasEnglishLanguages);
            }
        }
        #endregion

        #endregion

        #region ----------------BuildDropDownListForDefaultPage(DropDownList ddlLanguages)----------------
        //---------------------------------------
        //BuildDropDownListForDefaultPage
        //---------------------------------------
        //--------------------------------------------------------------------------------------
        public static void BuildDropDownListForDefaultPage(DropDownList ddlLanguages)
        {
            //--------------------------------------------------------------------------
            //Arabic
            //--------------------------------------------------------------------------
            if (Languages_HasArabicLanguages && Languages_AdminLanguageID == (int)Languages.Ar)
                ddlLanguages.Items.Insert(0, new ListItem(DynamicResource.GetText("Sitelanguages", "Arabic"), ((int)Languages.Ar).ToString()));
            else
                ddlLanguages.Items.Add(new ListItem(DynamicResource.GetText("Sitelanguages", "Arabic"), ((int)Languages.Ar).ToString()));
            //--------------------------------------------------------------------------

            //--------------------------------------------------------------------------
            //English
            //--------------------------------------------------------------------------
            if (Languages_HasEnglishLanguages && Languages_AdminLanguageID == (int)Languages.En)
                ddlLanguages.Items.Insert(0, new ListItem(DynamicResource.GetText("Sitelanguages", "English"), ((int)Languages.En).ToString()));
            else
                ddlLanguages.Items.Add(new ListItem(DynamicResource.GetText("Sitelanguages", "English"), ((int)Languages.En).ToString()));
            //--------------------------------------------------------------------------

            //ddlLanguages.Items.Insert(0, new ListItem(DynamicResource.GetText("AdminText","Choose"), "-1"));
        }
        //--------------------------------------------------------------------------------------
        #endregion

        //----------------------------------------------------------//


        public static Languages GetCurrentLanguage()
        {
            Languages langID;
            HttpContext context = HttpContext.Current;
            if (context.Items["LangID"] != null)
            {
                langID = (Languages)context.Items["LangID"];
            }
            else
            {
                langID = (Languages)SiteSettings.Languages_DefaultLanguageID;
                context.Items["LangID"] = langID;
            }
            return langID;
        }
        //-------------------------------------------------------------

        #region ---------- CheckUploadedFileExtension ---------
        //---------------------------------
        //CheckUploadedFileExtension
        //---------------------------------
        public static bool CheckUploadedFileExtension(string fileExtension, string availbleExtension)
        {
            if (availbleExtension.Length == 0)
            {
                return true;
            }
            fileExtension = fileExtension.ToLower();

            if (availbleExtension.ToLower().IndexOf(fileExtension) > -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ---------- CheckUploadedFileLength ---------
        //---------------------------------
        //CheckUploadedFileLength
        //---------------------------------
        public static bool CheckUploadedFileLength(int filelength, string maxAvailableLength)
        {
            int maxLength;
            if (!string.IsNullOrEmpty(maxAvailableLength))
            {
                maxLength = Convert.ToInt32(maxAvailableLength);
                return CheckUploadedFileLength(filelength, maxLength);
            }
            else
            {
                return true;
            }
        }
        public static bool CheckUploadedFileLength(int filelength, int maxAvailableLength)
        {
            //kilo
            filelength = filelength / 1024;
            if (maxAvailableLength < 0)
            {
                return true;
            }


            if (filelength <= maxAvailableLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion




        
        #region ----------------Photos Options----------------
        //---------------------------------------
        //Photos Site Options
        //---------------------------------------
        #region ----------------Photos_MicroThumnailWidth----------------
        //---------------------------------------
        //Photos_MicroThumnailWidth
        //---------------------------------------
        public static int Photos_MicroThumnailWidth
        {
            get
            {
                return Photos_WebSite_MicroThumnailWidth;
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_MicroThumnailHeight----------------
        //---------------------------------------
        //Photos_MicroThumnailHeight
        //---------------------------------------
        public static int Photos_MicroThumnailHeight
        {
            get
            {
                return Photos_WebSite_MicroThumnailHeight;
            }
        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_MiniThumnailWidth----------------
        //---------------------------------------
        //Photos_MiniThumnailWidth
        //---------------------------------------
        public static int Photos_MiniThumnailWidth
        {
            get
            {
                return Photos_WebSite_MiniThumnailWidth;
            }
        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_MiniThumnailHeight----------------
        //---------------------------------------
        //Photos_MiniThumnailHeight
        //---------------------------------------
        public static int Photos_MiniThumnailHeight
        {
            get
            {
                return Photos_WebSite_MiniThumnailHeight;
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_NormalThumnailWidth----------------
        //---------------------------------------
        //Photos_NormalThumnailWidth
        //---------------------------------------
        public static int Photos_NormalThumnailWidth
        {
            get
            {
                return Photos_WebSite_NormalThumnailWidth;
            }

        }
        //---------------------------------------
        #endregion


        #region ----------------Photos_NormalThumnailHeight----------------
        //---------------------------------------
        //Photos_NormalThumnailHeight
        //---------------------------------------
        public static int Photos_NormalThumnailHeight
        {
            get
            {
                return Photos_WebSite_NormalThumnailHeight;
            }
        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_BigThumnailWidth----------------
        //---------------------------------------
        //Photos_BigThumnailWidth
        //---------------------------------------
        public static int Photos_BigThumnailWidth
        {
            get
            {
                return Photos_WebSite_BigThumnailWidth;
            }

        }
        //---------------------------------------
        #endregion


        #region ----------------Photos_BigThumnailHeight----------------
        //---------------------------------------
        //Photos_BigThumnailHeight
        //---------------------------------------
        public static int Photos_BigThumnailHeight
        {
            get
            {
                return Photos_WebSite_BigThumnailHeight;
            }

        }
        //---------------------------------------
        #endregion



        #region ----------------Photos_VListWidth----------------
        //---------------------------------------
        //Photos_VListWidth
        //---------------------------------------
        public static int Photos_VListWidth
        {
            get
            {
                return Photos_WebSite_VListWidth;
            }

        }
        //---------------------------------------
        #endregion
        #region ----------------Photos_VListHeight----------------
        //---------------------------------------
        //Photos_VListHeight
        //---------------------------------------
        public static int Photos_VListHeight
        {
            get
            {
                return Photos_WebSite_VListHeight;
            }

        }
        //---------------------------------------
        #endregion
        #region ----------------Photos_HListWidth----------------
        //---------------------------------------
        //Photos_HListWidth
        //---------------------------------------
        public static int Photos_HListWidth
        {
            get
            {
                        return Photos_WebSite_HListWidth;
            }

        }
        //---------------------------------------
        #endregion
        #region ----------------Photos_HListHeight----------------
        //---------------------------------------
        //Photos_HListHeight
        //---------------------------------------
        public static int Photos_HListHeight
        {
            get
            {
                return Photos_WebSite_HListHeight;
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_DetailsPageWidth----------------
        //---------------------------------------
        //Photos_DetailsPageWidth
        //---------------------------------------
        public static int Photos_DetailsPageWidth
        {
            get
            {
                return Photos_WebSite_DetailsPageWidth;
            }
        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_DetailsPageHeight----------------
        //---------------------------------------
        //Photos_DetailsPageHeight
        //---------------------------------------
        public static int Photos_DetailsPageHeight
        {
            get
            {
                return Photos_WebSite_DetailsPageHeight;
            }

        }
        //---------------------------------------
        #endregion



        #region ----------------Photos_SavePhotoDimensions----------------
        //---------------------------------------
        //Photos_SavePhotoDimensions
        //---------------------------------------
        public static bool Photos_SavePhotoDimensions
        {
            get
            {


                return Convert.ToBoolean(GetValue(SiteSettingItems.Photos_SavePhotoDimensions));
            }

        }
        //---------------------------------------
        #endregion

        #region ----------------Photos_PhotosAvailbleExtensions----------------
        //---------------------------------------
        //Photos_PhotosAvailbleExtensions
        //---------------------------------------
        public static string Photos_PhotosAvailbleExtensions
        {
            get
            {
                return (string)GetValue(SiteSettingItems.Photos_PhotosAvailbleExtensions);
            }
        }
        #endregion
        #endregion

        public static object GetValue(object key)
        {
            if (AllSiteSettings.Count == 0)
                SiteSettingsFactory.LoadAllSettings();
            if (AllSiteSettings.Contains(key))
                return AllSiteSettings[key];
            else
                return null;
        }
    }

}