using System;
using System.Collections.Generic;

using System.Web;
namespace DCCMSNameSpace
{
    /// <summary>
    /// Summary description for TestingDataFactor
    /// </summary>
    public class TestingDataFactor
    {
        //----------------------------------------------------------------------------------
        string ArCategoryTitle = @"تصنيف تجريبي";
        string ArItemTitle = @"بيان تجريبي";
        string ArMessageTitle = @"رسالة تجريبية";
        string ArCommentTitle = @"تعليق تجريبي";
        string ArItemShortDescrpyion = @"نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا";
        string ArItemDetails = @"نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم";
        string ArItemSeoKeyWords = @"كلمات ,مفتاحية ,تجريبة ,للبيان ,التجريبي";
        string ArItemSeoDescrption = @"نبذة تجريبة للبيان التجريبي لإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا";
        string ArItemAddress = @"عنوان تجريبي نأسف للإزعاج";
        string ArItemAuthorName = @"د محروس الدهشوري";

        //----------------------------------------------------------------------------------
        string EnCategoryTitle = @"Testing Category Data";
        string EnItemTitle = @"Testing Data";
        string EnMessageTitle = @"Testing Message";
        string EnCommentTitle = @"Testing Comment";
        string EnItemShortDescrpyion = @"Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismod Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismod Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismodFusce euismod consequat";
        string EnItemDetails = @"Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismod Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismod Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismodFusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismodFusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismod Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismod Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismodFusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismodFusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismod Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismod Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismodFusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismod";
        string EnItemSeoKeyWords = @"Testing, keywords, for, testing";
        string EnItemSeoDescrption = @"Fusce euismod consequat ante.elit. Pellentesque sed dolor. Ali Fusce euismod Fusce euismod consequat ante.elit. Pellentesque sed dolor.";
        string EnItemAddress = @"Testing address";
        string EnItemAuthorName = @"Mahmoud El-Dahshoury";
        //----------------------------------------------------------------------------------
        string YoutubeCode = "FpSwGLkZ1D0";
        string Url = "http://www.google.com";
        string Email = "mail@domain.com";
        string MailBox = "12345";
        string ZipCode = "12345";
        string Tels = "09657564565666";
        string Fax = "09657564565666";
        string Mobile = "09657564565666";
        DateTime ItemDate = DateTime.Now;
        DateTime ItemEndDate = DateTime.Now;
        bool IsAvailable = true;
        double GoogleLatitude = 20.0;
        double GoogleLongitude = 40.0;
        string Price = "150";
        string ArSenderName = "محمود أحمد سالم";
        string EnSenderName = "Mahmoud Ahmed Salim";
        string SenderEMail = "mail@domain.com";
        int SenderCountryID = SiteSettings.Admininstration_SiteDefaultCountryID;
        //string ArReply = @"نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم نص تجريبي للإختبار نشكركم لحسن تعاونكم معنا نحن هنا نقوم بإختبار أداء الموقع عبر قسم الجودة شكر لكم";
        DateTime ReplyDate = DateTime.Now;
        bool IsSeen = true;
        bool IsReplied = true;
        bool IsReviewed = true;
        int Type = 1;
        //-------------------------------------------------------
        string UserCityNameAr = "الرياض";
        string JobTextAr = "محامي";
        string CompanyAr = "الخطوط الرقمية";
        //------------------------
        string UserCityNameEn = "Al-Riahd";
        string JobTextEn = "Lawer";
        string CompanyEn = "Digital Lines";
        //------------------------
        string BirthDate = "10/10/1981";
        int JobID = 0;
        int ActivitiesID = 1;
        int SocialStatus = 1;
        int EducationLevel = 1;
        int EmpNo = 101;
        bool HasSmsService = false;
        bool HasEmailService = false;
        int AgeRang = 1;
        int CityID = 0;
        string JobTel = "09657564565666";
        //-------------------------------------------------------
        ItemsEntity InitialItem;
        ItemsDetailsEntity InitialItemArDetails;
        ItemsDetailsEntity InitialItemEnDetails;
        //-------------------------------------------------------
        ItemCategoriesEntity InitialCategory;
        ItemCategoriesEntity InitialCategoryParent;
        ItemCategoriesDetailsEntity InitialCategoryArDetails;
        ItemCategoriesDetailsEntity InitialCategoryEnDetails;
        //-------------------------------------------------------
        ItemsCommentsEntity InitialArComment;
        ItemsCommentsEntity InitialEnComment;
        //-------------------------------------------------------
        MessagesEntity InitialArMessages;
        MessagesEntity InitialEnMessages;
        //-------------------------------------------------------

        public void InitializeAllOpjects()
        {
            #region Initial lItem
            InitialItem = new ItemsEntity();
            //InitialItem.CategoryID = xxxx;
            //InitialItem.ItemID	
            //InitialItem.CategoryID	
            //InitialItem.ModuleTypeID = moduleType;
            //InitialItem.PhotoExtension	
            InitialItem.Url = Url;
            InitialItem.Email = Email;
            InitialItem.MailBox = MailBox;
            InitialItem.ZipCode = ZipCode;
            InitialItem.Tels = Tels;
            InitialItem.Fax = Fax;
            InitialItem.Mobile = Mobile;
            InitialItem.ItemDate = ItemDate;
            InitialItem.ItemEndDate = ItemEndDate;
            InitialItem.IsAvailable = IsAvailable;
            InitialItem.YoutubeCode = YoutubeCode;
            InitialItem.GoogleLatitude = GoogleLatitude;
            InitialItem.GoogleLongitude = GoogleLongitude;
            InitialItem.Price = Price;
            /*
InitialItem.SenderName		
InitialItem.SenderEMail		
InitialItem.SenderCountryID		
InitialItem.Reply	
InitialItem.ReplyDate		
InitialItem.IsSeen	
InitialItem.IsReplied	
InitialItem.IsReviewed	
InitialItem.ToUserID	
InitialItem.ActivatedBy
InitialItem.ReviewedBy	
InitialItem.OwnerID	*/
            InitialItem.Type = Type;
            #endregion
            #region InitialItemArDetails
            InitialItemArDetails = new ItemsDetailsEntity();
            //InitialItemArDetails.ItemID = InitialItem.ItemID;
            InitialItemArDetails.LangID = Languages.Ar;
            InitialItemArDetails.Title = ArItemTitle;
            InitialItemArDetails.ShortDescription = ArItemShortDescrpyion;
            InitialItemArDetails.Description = ArItemDetails;
            InitialItemArDetails.KeyWords = ArItemSeoKeyWords;
            InitialItemArDetails.Address = ArItemAddress;
            InitialItemArDetails.AuthorName = ArItemAuthorName;
            #endregion
            #region InitialItemArDetails

            InitialItemEnDetails = new ItemsDetailsEntity();
            //InitialItemEnDetails.ItemID = InitialItem.ItemID;
            InitialItemEnDetails.LangID = Languages.En;
            InitialItemEnDetails.Title = EnItemTitle;
            InitialItemEnDetails.ShortDescription = EnItemShortDescrpyion;
            InitialItemEnDetails.Description = EnItemDetails;
            InitialItemEnDetails.KeyWords = EnItemSeoKeyWords;
            InitialItemEnDetails.Address = EnItemAddress;
            InitialItemEnDetails.AuthorName = EnItemAuthorName;
            #endregion




            #region Initial Category
            InitialCategory = new ItemCategoriesEntity();
            //InitialCategory.CategoryID;
            //InitialCategory.PhotoExtension;
            //InitialCategory.ModuleTypeID;
            //InitialCategory.ParentID;
            //InitialCategory.TypeID	=Type;
            InitialCategory.ItemDate = ItemDate;
            InitialCategory.IsAvailable = IsAvailable;
            InitialCategory.YoutubeCode = YoutubeCode;
            InitialCategory.GoogleLatitude = GoogleLatitude;
            InitialCategory.GoogleLongitude = GoogleLongitude;
            #endregion
            #region Initial Category Parent
            InitialCategoryParent = new ItemCategoriesEntity();
            //InitialCategoryParent.CategoryID;
            //InitialCategoryParent.PhotoExtension;
            //InitialCategoryParent.ModuleTypeID;
            //InitialCategoryParent.ParentID;
            //InitialCategoryParent.TypeID	=Type;
            InitialCategoryParent.ItemDate = ItemDate;
            InitialCategoryParent.IsAvailable = IsAvailable;
            InitialCategoryParent.YoutubeCode = YoutubeCode;
            InitialCategoryParent.GoogleLatitude = GoogleLatitude;
            InitialCategoryParent.GoogleLongitude = GoogleLongitude;
            #endregion

            #region InitialCategoryArDetails
            InitialCategoryArDetails = new ItemCategoriesDetailsEntity();
            //InitialCategoryArDetails.CategoryID = InitialCategory.CategoryID;
            InitialCategoryArDetails.LangID = Languages.Ar;
            InitialCategoryArDetails.Title = ArCategoryTitle;
            InitialCategoryArDetails.ShortDescription = ArItemShortDescrpyion;
            InitialCategoryArDetails.Description = ArItemDetails;
            InitialCategoryArDetails.KeyWords = ArItemSeoKeyWords;
            #endregion
            #region InitialCategoryEnDetails

            InitialCategoryEnDetails = new ItemCategoriesDetailsEntity();
            //InitialCategoryEnDetails.CategoryID = InitialCategory.CategoryID;
            InitialCategoryEnDetails.LangID = Languages.En;
            InitialCategoryEnDetails.Title = EnCategoryTitle;
            InitialCategoryEnDetails.ShortDescription = EnItemShortDescrpyion;
            InitialCategoryEnDetails.Description = EnItemDetails;
            InitialCategoryEnDetails.KeyWords = EnItemSeoKeyWords;
            #endregion

            #region InitialArComment
            InitialArComment = new ItemsCommentsEntity();
            //InitialArComment.CommentID
            //InitialArComment.ItemID	
            InitialArComment.LangID = Languages.Ar;
            //InitialArComment.ModuleTypeID	
            //InitialArComment.BaseModuleType	
            InitialArComment.SenderName = ArSenderName;
            InitialArComment.CountryID = SenderCountryID;
            //InitialArComment.CtryShort	
            InitialArComment.SendingDate = DateTime.Now;
            InitialArComment.SenderEmail = SenderEMail;
            InitialArComment.CommentTitle = ArCommentTitle;
            InitialArComment.CommentText = ArItemDetails;
            InitialArComment.IsActive = IsAvailable;
            InitialArComment.IsSeen = IsSeen;
            #endregion
            #region InitialEnComment
            InitialEnComment = new ItemsCommentsEntity();
            //InitialEnComment.CommentID
            //InitialEnComment.ItemID	
            InitialEnComment.LangID = Languages.En;
            //InitialEnComment.ModuleTypeID	
            //InitialEnComment.BaseModuleType	
            InitialEnComment.SenderName = EnSenderName;
            InitialEnComment.CountryID = SenderCountryID;
            //InitialEnComment.CtryShort	
            InitialEnComment.SendingDate = DateTime.Now;
            InitialEnComment.SenderEmail = SenderEMail;
            InitialEnComment.CommentTitle = EnCommentTitle;
            InitialEnComment.CommentText = EnItemDetails;
            InitialArComment.IsActive = IsAvailable;
            InitialArComment.IsSeen = IsSeen;
            #endregion

            #region InitialArMessages
            InitialArMessages = new MessagesEntity();
            //InitialArMessages.MessageID=;
            //InitialArMessages.ModuleTypeID	
            //InitialArMessages.CategoryID	;
            InitialArMessages.Name = ArSenderName;
            InitialArMessages.Mobile = Mobile;
            InitialArMessages.EMail = Email;
            InitialArMessages.NationalityID = SiteSettings.Admininstration_SiteDefaultCountryID;
            InitialArMessages.CountryID = SiteSettings.Admininstration_SiteDefaultCountryID;
            InitialArMessages.Address = ArItemAddress;
            InitialArMessages.JobTel = JobTel;
            InitialArMessages.Type = Type;
            InitialArMessages.Title = ArMessageTitle;
            InitialArMessages.Details = ArItemDetails;
            InitialArMessages.ShortDescription = ArItemShortDescrpyion;
            InitialArMessages.Reply = ArItemDetails;
            InitialArMessages.ReplyDate = DateTime.Now;
            InitialArMessages.IsAvailable = IsAvailable;
            InitialArMessages.IsSeen = IsSeen;
            InitialArMessages.IsReplied = IsReplied;
            InitialArMessages.LangID = Languages.Ar;
            InitialArMessages.Gender = Gender.Male;
            InitialArMessages.BirthDate = BirthDate;
            InitialArMessages.CityID = CityID;
            InitialArMessages.UserCityName = UserCityNameAr;
            InitialArMessages.Tel = Tels;
            InitialArMessages.Fax = Fax;
            InitialArMessages.MailBox = MailBox;
            InitialArMessages.ZipCode = ZipCode;
            InitialArMessages.JobID = JobID;
            InitialArMessages.JobText = JobTextAr;
            InitialArMessages.Company = CompanyAr;
            InitialArMessages.ActivitiesID = ActivitiesID;
            InitialArMessages.Url = Url;
            //InitialArMessages.PhotoExtension	
            InitialArMessages.SocialStatus = SocialStatus;
            InitialArMessages.EducationLevel = EducationLevel;
            InitialArMessages.EmpNo = EmpNo;
            InitialArMessages.HasSmsService = HasSmsService;
            InitialArMessages.HasEmailService = HasEmailService;
            //InitialArMessages.Notes1	
            //InitialArMessages.Notes2	
            InitialArMessages.AgeRang = AgeRang;
            InitialArMessages.ItemDate = ItemDate;
            InitialArMessages.YoutubeCode = YoutubeCode;
            InitialArMessages.GoogleLatitude = GoogleLatitude.ToString();
            InitialArMessages.GoogleLongitude = GoogleLongitude.ToString();
            InitialArMessages.Price = Price;
            InitialArMessages.KeyWords = ArItemSeoKeyWords;
            InitialArMessages.LastModification = DateTime.Now;
            #endregion

            #region InitialEnMessages
            InitialEnMessages = new MessagesEntity();
            //InitialEnMessages.MessageID=;
            //InitialEnMessages.ModuleTypeID	
            //InitialEnMessages.CategoryID	;
            InitialEnMessages.Name = EnSenderName;
            InitialEnMessages.Mobile = Mobile;
            InitialEnMessages.EMail = Email;
            InitialEnMessages.NationalityID = SiteSettings.Admininstration_SiteDefaultCountryID;
            InitialEnMessages.CountryID = SiteSettings.Admininstration_SiteDefaultCountryID;
            InitialEnMessages.Address = EnItemAddress;
            InitialEnMessages.JobTel = JobTel;
            InitialEnMessages.Type = Type;
            InitialEnMessages.Title = EnMessageTitle;
            InitialEnMessages.Details = EnItemDetails;
            InitialEnMessages.ShortDescription = EnItemShortDescrpyion;
            InitialEnMessages.Reply = EnItemDetails;
            InitialEnMessages.ReplyDate = DateTime.Now;
            InitialEnMessages.IsAvailable = IsAvailable;
            InitialEnMessages.IsSeen = IsSeen;
            InitialEnMessages.IsReplied = IsReplied;
            InitialEnMessages.LangID = Languages.En;
            InitialEnMessages.Gender = Gender.Male;
            InitialEnMessages.BirthDate = BirthDate;
            InitialEnMessages.CityID = CityID;
            InitialEnMessages.UserCityName = UserCityNameEn;
            InitialEnMessages.Tel = Tels;
            InitialEnMessages.Fax = Fax;
            InitialEnMessages.MailBox = MailBox;
            InitialEnMessages.ZipCode = ZipCode;
            InitialEnMessages.JobID = JobID;
            InitialEnMessages.JobText = JobTextEn;
            InitialEnMessages.Company = CompanyEn;
            InitialEnMessages.ActivitiesID = ActivitiesID;
            InitialEnMessages.Url = Url;
            //InitialEnMessages.PhotoExtension	
            InitialEnMessages.SocialStatus = SocialStatus;
            InitialEnMessages.EducationLevel = EducationLevel;
            InitialEnMessages.EmpNo = EmpNo;
            InitialEnMessages.HasSmsService = HasSmsService;
            InitialEnMessages.HasEmailService = HasEmailService;
            //InitialEnMessages.Notes1	
            //InitialEnMessages.Notes2	
            InitialEnMessages.AgeRang = AgeRang;
            InitialEnMessages.ItemDate = ItemDate;
            InitialEnMessages.YoutubeCode = YoutubeCode;
            InitialEnMessages.GoogleLatitude = GoogleLatitude.ToString();
            InitialEnMessages.GoogleLongitude = GoogleLongitude.ToString();
            InitialEnMessages.Price = Price;
            InitialEnMessages.KeyWords = EnItemSeoKeyWords;
            InitialEnMessages.LastModification = DateTime.Now;
            #endregion
        }
        
        public void InsertTestingDataForAllSiteModules()
        {
            InitializeAllOpjects();
            UpdateTestingDataForStaticPages();
            //------------------------------------------------------------------
            SiteModulesManager siteModules = SiteModulesManager.Instance;
            bool TempAllowDublicateTitlesInCategories;
            bool TempAllowDublicateTitlesInItems;
            foreach (ItemsModulesOptions module in siteModules.SiteItemsModulesList)
            {

                if (module.IsAvailabe && module.ModuleType != ModuleTypes.Categories_Only && !module.HasOwnerID && module.ModuleTypeID>9)
                {
                    TempAllowDublicateTitlesInCategories = module.AllowDublicateTitlesInCategories;
                    TempAllowDublicateTitlesInItems = module.AllowDublicateTitlesInItems;
                    module.AllowDublicateTitlesInCategories = true;
                    module.AllowDublicateTitlesInItems = true;
                    InsertTestingDataForItemsModule(module.ModuleTypeID);
                    module.AllowDublicateTitlesInCategories = TempAllowDublicateTitlesInCategories;
                    module.AllowDublicateTitlesInItems = TempAllowDublicateTitlesInItems;
                }
            }
            //------------------------------------------------------------------
            //------------------------------------------------------------------
            foreach (MessagesModuleOptions module in siteModules.SiteMessagesModulesList)
            {
                if (module.IsAvailabe && !module.HasOwnerID)
                {
                    InsertTestingDataForMessageModule(module.ModuleTypeID);
                }
            }
            //------------------------------------------------------------------
            //------------------------------------------------------------------
            /*SiteUsersDataModules usersModules = SiteUsersDataModules.Instance;
            foreach (UsersDataGlobalOptions module in usersModules.SiteUsersDataModulesList)
            {
            }*/
            //------------------------------------------------------------------
            //MailList
            if (SiteSettings.MailList_HasMaillist)
            {
            InsertTestingDataForEmailList();
            }
            //-------------------------------------------
            //Sms
            if (SiteSettings.Sms_HasSms)
            {
            InsertTestingDataForSmsList();
            }
            //-------------------------------------------
            //Advertisments
           /* if (SiteSettings.SpecialModules_AdvertismentsEnabled)
                links += BuildAdvertismentsLinks();*/
            //-------------------------------------------
            //Vote
            if (SiteSettings.Vote_Enabled)
            {
            InsertTestingDataForVoteModule();
            }
            //-------------------------------------------
            //Citis
            if (SiteSettings.SpecialModules_CitisEnabled)
            {
            BuildCitiesLinks();
            }
            //-------------------------------------------
            /*//ShareLinks
            if (SiteSettings.SpecialModules_ShareLinksEnabled)
                links += BuildShareLinks();
            //-------------------------------------------
            //Admin Mails
            if (SiteSettings.Admininstration_HasAdminEmail)
                links += AdmininstrationMailsLinks();
            //-------------------------------------------

            //Security
            if (SiteSettings.SpecialModules_SecurityEnabled)
                links += BuildSecurityLinks();*/
            //-------------------------------------------
        }
        //----------------------------------------------------------
        #region ----------------InsertTestingDataForItemsModule---------------
        //----------------------------------------------------------
        //InsertTestingDataForItemsModule
        //----------------------------------------------------------
        public void InsertTestingDataForItemsModule(int ModuleTypeID)
        {
            ItemsModulesOptions itemsModule = ItemsModulesOptions.GetType(ModuleTypeID);
           // int parentCategoryID=0;
            //int CategoryID=0;
            //int ItemID=0;
            if(itemsModule.CategoryLevel>1||itemsModule.CategoryLevel<0)
            {
                AddParentCategories(itemsModule, ModuleBaseTypes.Items);
            }
            else if (itemsModule.CategoryLevel == 1)
            {
                AddCategories(itemsModule, 0, ModuleBaseTypes.Items);

            }
            else
            {
                AddItems(itemsModule, 0);
            }

        }
        //----------------------------------------------------------
        #endregion
        public void AddParentCategories(ItemsModulesOptions itemsModule, ModuleBaseTypes ModuleBaseType)
        {
            //-------------------------------------------------------------
            InitialCategoryParent.ParentID = 0;
            InitialCategoryParent.ModuleTypeID = itemsModule.ModuleTypeID;
            //-------------------------------------------------------------
            for (int i = 0; i < 3; i++)
            {
                if (SiteSettings.Languages_HasArabicLanguages)
                {
                    InitialCategoryParent.Details[Languages.Ar] = InitialCategoryArDetails;
                }
                if (SiteSettings.Languages_HasEnglishLanguages)
                {
                    InitialCategoryParent.Details[Languages.En] = InitialCategoryEnDetails;
                }
               ExecuteCommandStatus status= ItemCategoriesFactory.Create(InitialCategoryParent, itemsModule);
               if (status == ExecuteCommandStatus.Done)
               {
                   AddCategories(itemsModule, InitialCategoryParent.CategoryID, ModuleBaseType);
                   
               }
            }
        }
        //----------------------------------------------------------
        public void AddCategories(ItemsModulesOptions ItemsModule, int ParentID, ModuleBaseTypes ModuleBaseType)
        {
            //-------------------------------------------------------------
            InitialCategory.ParentID = ParentID;
            InitialCategory.ModuleTypeID = ItemsModule.ModuleTypeID;
            //-------------------------------------------------------------
            for (int i = 0; i < 3; i++)
            {
                if (SiteSettings.Languages_HasArabicLanguages)
                {
                    InitialCategory.Details[Languages.Ar] = InitialCategoryArDetails;
                }
                if (SiteSettings.Languages_HasEnglishLanguages)
                {
                    InitialCategory.Details[Languages.En] = InitialCategoryEnDetails;
                }
                ExecuteCommandStatus status = ItemCategoriesFactory.Create(InitialCategory, ItemsModule);
                if (status == ExecuteCommandStatus.Done)
                {
                    if (ModuleBaseType == ModuleBaseTypes.Items)
                    {
                        AddItems(ItemsModule, InitialCategory.CategoryID);
                    }
                    else if (ModuleBaseType == ModuleBaseTypes.Messages)
                    {
                      AddMessages(ItemsModule.ModuleTypeID, InitialCategory.CategoryID);
                    }
                }
            }
        }
        //----------------------------------------------------------
        public void AddItems(ItemsModulesOptions itemsModule, int categoryID)
        {
            //-------------------------------------------------------------
            InitialItem.CategoryID = categoryID;
            InitialItem.ModuleTypeID = itemsModule.ModuleTypeID;
            //-------------------------------------------------------------
            for (int i = 0; i < 15; i++)
            {
                if (SiteSettings.Languages_HasArabicLanguages)
                {
                    InitialItem.Details[Languages.Ar] = InitialItemArDetails;
                }
                if (SiteSettings.Languages_HasEnglishLanguages)
                {
                    InitialItem.Details[Languages.En] = InitialItemEnDetails;
                }
                ExecuteCommandStatus status = ItemsFactory.Create(InitialItem, itemsModule);
                if (status == ExecuteCommandStatus.Done)
                {
                    if(itemsModule.HasComments)
                    {
                        AddComments(itemsModule.ModuleTypeID, InitialItem.ItemID, ModuleBaseTypes.Items);
                    }
                }
            }
        }
        //----------------------------------------------------------
        public void AddComments(int ModuleTypeID, int itemID, ModuleBaseTypes ModuleBaseType)
        {
            //-------------------------------------------------------------
            InitialArComment.ItemID = itemID;
            InitialArComment.BaseModuleType = ModuleBaseType;
            InitialArComment.ModuleTypeID = ModuleTypeID;
            //-------------------------------------------------------------
            InitialEnComment.ItemID = itemID;
            InitialEnComment.BaseModuleType = ModuleBaseType;
            InitialEnComment.ModuleTypeID = ModuleTypeID;
            //-------------------------------------------------------------
            for (int i = 0; i < 2; i++)
            {
                if (SiteSettings.Languages_HasArabicLanguages)
                {
                    ExecuteCommandStatus ArStatus = ItemsCommentsFactory.Create(InitialArComment);
                }
                if (SiteSettings.Languages_HasEnglishLanguages)
                {
                    ExecuteCommandStatus EnStatus = ItemsCommentsFactory.Create(InitialEnComment);
                }
            }
        }
        #region ----------------InsertTestingDataForMessageModule---------------
        //----------------------------------------------------------
        //InsertTestingDataForMessageModule
        //----------------------------------------------------------
        public void InsertTestingDataForMessageModule(int ModuleTypeID)
        {
            //----------------------------------------------------------
            MessagesModuleOptions MsgModule = MessagesModuleOptions.GetType(ModuleTypeID);
            //----------------------------------------------------------
            ItemsModulesOptions CategoriesModule = ItemsModulesOptions.GetType(ModuleTypeID);
            //----------------------------------------------------------
            bool TempAllowDublicateTitlesInCategories=true;
            bool TempAllowDublicateTitlesInItems = true;
            //----------------------------------------------------------
            if (MsgModule.CategoryLevel != 0)
            {
                
                TempAllowDublicateTitlesInCategories = CategoriesModule.AllowDublicateTitlesInCategories;
                TempAllowDublicateTitlesInItems = CategoriesModule.AllowDublicateTitlesInItems;
                //
                CategoriesModule.AllowDublicateTitlesInCategories = true;
                CategoriesModule.AllowDublicateTitlesInItems = true;
                //---------------------------
                CategoriesModule = ItemsModulesOptions.GetType(ModuleTypeID);

               
            }
            //----------------------------------------------------------
            if (MsgModule.CategoryLevel > 1 || MsgModule.CategoryLevel < 0)
            {
                AddParentCategories(CategoriesModule, ModuleBaseTypes.Messages);
                CategoriesModule.AllowDublicateTitlesInCategories = TempAllowDublicateTitlesInCategories;
                CategoriesModule.AllowDublicateTitlesInItems = TempAllowDublicateTitlesInItems;
            }
            else if (MsgModule.CategoryLevel == 1)
            {
                AddCategories(CategoriesModule, 0, ModuleBaseTypes.Messages);
                CategoriesModule.AllowDublicateTitlesInCategories = TempAllowDublicateTitlesInCategories;
                CategoriesModule.AllowDublicateTitlesInItems = TempAllowDublicateTitlesInItems;
            }
            else
            {
                AddMessages(MsgModule, 0);
            }

        }
        //----------------------------------------------------------
        #endregion
        //----------------------------------------------------------
        public void AddMessages(int MsgModuleTypeID, int CategoryID)
        {
            MessagesModuleOptions MsgModule = MessagesModuleOptions.GetType(MsgModuleTypeID);
            AddMessages(MsgModule, CategoryID);
        }
        public void AddMessages(MessagesModuleOptions MsgModule, int CategoryID)
        {
            //-------------------------------------------------------------
            InitialArMessages.CategoryID = CategoryID;
            InitialArMessages.ModuleTypeID = MsgModule.ModuleTypeID;
            //-------------------------------------------------------------
            InitialEnMessages.CategoryID = CategoryID;
            InitialEnMessages.ModuleTypeID = MsgModule.ModuleTypeID;
            //-------------------------------------------------------------
            for (int i = 0; i < 3; i++)
            {
                if (SiteSettings.Languages_HasArabicLanguages)
                {
                    bool createMessageFolder =(MsgModule.HasFileExtension||MsgModule.HasPhotoExtension||MsgModule.HasPhoto2Extension||MsgModule.HasVideoExtension||MsgModule.HasAudioExtension);
                    bool ArStatus = MessagesFactory.Create(InitialArMessages,createMessageFolder);
                    if (ArStatus)
                    {
                        if (MsgModule.HasComments)
                        {
                            AddComments(MsgModule.ModuleTypeID, InitialArMessages.MessageID, ModuleBaseTypes.Messages);
                        }
                    }
                }
                if (SiteSettings.Languages_HasEnglishLanguages)
                {
                    bool createMessageFolder = (MsgModule.HasFileExtension || MsgModule.HasPhotoExtension || MsgModule.HasPhoto2Extension || MsgModule.HasVideoExtension || MsgModule.HasAudioExtension);
                    bool EnStatus = MessagesFactory.Create(InitialEnMessages, createMessageFolder);
                    if (EnStatus)
                    {
                        if (MsgModule.HasComments)
                        {
                            AddComments(MsgModule.ModuleTypeID, InitialEnMessages.MessageID, ModuleBaseTypes.Messages);
                        }
                    }
                }
            }
        }
        #region ----------------UpdateTestingDataForStaticPages---------------
        //----------------------------------------------------------
        //UpdateTestingDataForStaticPages
        //----------------------------------------------------------
        public void UpdateTestingDataForStaticPages()
        {
            ItemsModulesOptions SitePagesModule = ItemsModulesOptions.GetType((int)StandardItemsModuleTypes.SitePages);
            //-------------------------------------------------------------
            InitialItem.CategoryID = 0;
            InitialItem.ModuleTypeID = SitePagesModule.ModuleTypeID;
            //-------------------------------------------------------------
            foreach (SitePageOptions page in SiteModulesManager.Instance.SitePagesList)
            {

                if (page.IsAvailabe)
                {
                    InitialItem.ItemID = page.PageID;
                    if (SiteSettings.Languages_HasArabicLanguages)
                    {
                        InitialItem.Details[Languages.Ar] = InitialItemArDetails;
                    }
                    if (SiteSettings.Languages_HasEnglishLanguages)
                    {
                        InitialItem.Details[Languages.En] = InitialItemEnDetails;
                    }
                    ExecuteCommandStatus status = ItemsFactory.Update(InitialItem, SitePagesModule);
                    if (status == ExecuteCommandStatus.Done)
                    {
                        if (page.HasComments)
                        {
                            AddComments(SitePagesModule.ModuleTypeID, page.PageID, ModuleBaseTypes.Items);
                        }
                    }
                }
            }

        }
        //----------------------------------------------------------
        #endregion







        #region ----------------InsertTestingDataForEmailList---------------
        //----------------------------------------------------------
        //InsertTestingDataForEmailList
        //----------------------------------------------------------
        public void InsertTestingDataForEmailList()
        {

            //----------------------------------------------------------------------
            MailListUsersEntity ArMailListUsers = new MailListUsersEntity();
            string arEmail = "armail{0}@site.com";
            ArMailListUsers.IsActive = true;
            ArMailListUsers.ModuleTypeID = (int)StandardItemsModuleTypes.MailList;
            ArMailListUsers.LangID = Languages.Ar;
            //----------------------------------------------------------------------
            MailListUsersEntity EnMailListUsers = new MailListUsersEntity();
            string enEmail = "enmail{0}@site.com";
            EnMailListUsers.IsActive = true;
            EnMailListUsers.ModuleTypeID = (int)StandardItemsModuleTypes.MailList;
            EnMailListUsers.LangID = Languages.Ar;
            //----------------------------------------------------------------------
            for (int i = 1; i <= 5; i++)
            {
                 if (SiteSettings.Languages_HasArabicLanguages)
                    {
                        ArMailListUsers.Email = string.Format(arEmail, i.ToString());
                        MailListUsersFactory.Create(ArMailListUsers);
                    }
                    if (SiteSettings.Languages_HasEnglishLanguages)
                    {
                        EnMailListUsers.Email = string.Format(enEmail, i.ToString());
                        MailListUsersFactory.Create(EnMailListUsers);
                    }
            }
        }
        //----------------------------------------------------------
        #endregion

        #region ----------------InsertTestingDataForSmsList---------------
        //----------------------------------------------------------
        //InsertTestingDataForSmsList
        //----------------------------------------------------------
        public void InsertTestingDataForSmsList()
        {

            //----------------------------------------------------------------------
            SMSNumbersEntity ArSmsListUsers = new SMSNumbersEntity();
            string arNumber = "0111234567{0}";
            string arName   = "إسم {0}";
            ArSmsListUsers.IsActive = true;
            ArSmsListUsers.ModuleTypeID = (int)StandardItemsModuleTypes.SMS;
            ArSmsListUsers.LangID = Languages.Ar;
            //----------------------------------------------------------------------
            SMSNumbersEntity EnSmsListUsers = new SMSNumbersEntity();
            string enNumber = "09661234567{0}";
            string enName   = "Name {0}";
            EnSmsListUsers.IsActive = true;
            EnSmsListUsers.ModuleTypeID = (int)StandardItemsModuleTypes.SMS;
            EnSmsListUsers.LangID = Languages.Ar;
            //----------------------------------------------------------------------
            for (int i = 1; i <= 5; i++)
            {
                if (SiteSettings.Languages_HasArabicLanguages)
                {
                    ArSmsListUsers.Numbers = string.Format(arNumber, i.ToString());
                    ArSmsListUsers.Name = string.Format(arName, i.ToString());
                    SMSNumbersFactory.Create(ArSmsListUsers);
                }
                if (SiteSettings.Languages_HasEnglishLanguages)
                {
                    EnSmsListUsers.Numbers = string.Format(enNumber, i.ToString());
                    EnSmsListUsers.Name = string.Format(enName, i.ToString());
                    SMSNumbersFactory.Create(EnSmsListUsers);
                }
            }
        }
        //----------------------------------------------------------
        #endregion


        #region ----------------InsertTestingDataForVoteModule---------------
        //----------------------------------------------------------
        //InsertTestingDataForVoteModule
        //----------------------------------------------------------
        public void InsertTestingDataForVoteModule()
        {

            //---------------------------------------------------------------------
            VoteQuestionsEntity ArVoteQuestions = new VoteQuestionsEntity();
            string ArQuestionText = "سؤال تجريبي {0} ؟";
            ArVoteQuestions.AnswersCount = 4;
            ArVoteQuestions.IsMain = true;
            ArVoteQuestions.LangID = Languages.Ar;
            //---------------------------------------------------------------------
            string ArAnswer = "إجابة رقم ";
            VoteAnswersEntity ArVoteAnswer = new VoteAnswersEntity();
            //---------------------------------------------------------------------
            //---------------------------------------------------------------------
            VoteQuestionsEntity EnVoteQuestions = new VoteQuestionsEntity();
            string EnQuestionText = "Testing Question {0} ?";
            EnVoteQuestions.AnswersCount = 4;
            EnVoteQuestions.IsMain = true;
            EnVoteQuestions.LangID = Languages.En;
            //---------------------------------------------------------------------
            string EnAnswer = "Answer no ";
            VoteAnswersEntity EnVoteAnswer = new VoteAnswersEntity();
            //---------------------------------------------------------------------
            for (int i = 1; i <= 2; i++)
            {
                if (SiteSettings.Languages_HasArabicLanguages)
                {
                    ArVoteQuestions.QuestionText = string.Format(ArQuestionText, i.ToString());
                    bool ArResult = VoteQuestionsFactory.Save(ArVoteQuestions, SPOperation.Insert);
                    if (ArResult)
                    {
                        for (int b = 1; b <= 4; b++)
                        {
                            ArVoteAnswer.QuesID = ArVoteQuestions.QuesID;
                            ArVoteAnswer.AnswerText = ArAnswer + b.ToString();
                            VoteAnswersFactory.Create(ArVoteAnswer);
                        }
                    }
                }
                if (SiteSettings.Languages_HasEnglishLanguages)
                {
                    EnVoteQuestions.QuestionText = string.Format(EnQuestionText, i.ToString());
                    bool EnResult = VoteQuestionsFactory.Save(EnVoteQuestions, SPOperation.Insert);
                    if (EnResult)
                    {
                        for (int b = 1; b <= 4; b++)
                        {
                            EnVoteAnswer.QuesID = EnVoteQuestions.QuesID;
                            EnVoteAnswer.AnswerText = EnAnswer + b.ToString();
                            VoteAnswersFactory.Create(EnVoteAnswer);
                        }
                    }
                }
            }
        }
        //----------------------------------------------------------
        #endregion
        

        
        
        #region ----------------BuildCitiesLinks---------------
        //----------------------------------------------------------
        //BuildCitiesLinks
        //----------------------------------------------------------
        public void BuildCitiesLinks()
        {

            CitiesEntity cities = new CitiesEntity();
            string NameAr = "مدينة ";
            string NameEn = "City ";
            cities.CountryID = SiteSettings.Admininstration_SiteDefaultCountryID;
            cities.GoogleMapHorizontal = GoogleLatitude;
            cities.GoogleMapVertical = GoogleLongitude;
            for (int i = 1; i <= 2; i++)
            {
                cities.NameAr = NameAr + i.ToString();
                cities.NameEn = NameEn + i.ToString();
                CitiesFactory.Create(cities);
            }
        }
        //----------------------------------------------------------
        #endregion

        

        

        

    }
}