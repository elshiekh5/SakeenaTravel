using AppService;
using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
         const int CacheDuration = 0;//int.MaxValue

        //[OutputCache(Duration = CacheDuration, VaryByParam = "*")]
        public ActionResult Index()
        {
            return View();
        }

        //[OutputCache(Duration = CacheDuration, VaryByParam = "*")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View("~/Views/About_Us/index.cshtml");
        }


        //[OutputCache(Duration = CacheDuration, VaryByParam = "*")]
        public ActionResult Module(int? id, string module)
        {
            //module
            ItemsModulesOptions currentModule = ItemsModulesOptions.GetType(module);
            if (id.HasValue)
            {

                ViewBag.Message = "Your application description page.";
                FrontItemsModel currentItem = FrontItemsController.GetItemObject(id.Value, SiteSettings.GetCurrentLanguage());
                ViewData["CurrentItem"] = currentItem;
                ViewData["CurrentItemsModule"] = currentModule;
                NavigationManager.Instance.BuilDetailsPathesLinks(currentModule, currentItem);
                return View("~/Views/" + module + "/details.cshtml", currentItem);
            }
            else
            {
                ViewBag.Message = "Your application description page.";
                NavigationManager.Instance.BuilDefaultPathesLinks(currentModule);
                ViewBag.Title = NavigationManager.Instance.PageTitle;
                return View("~/Views/" + module + "/index.cshtml");
            }
        }
        //[OutputCache(Duration = CacheDuration, VaryByParam = "*")]
        public ActionResult Message(int? id, string module)
        {
            //module
            MessagesModuleOptions currentModule = MessagesModuleOptions.GetType(module);
            if (id.HasValue)
            {
                ViewBag.Message = "Your application description page.";
                FrontItemsModel currentItem = FrontItemsController.GetItemObject(id.Value, SiteSettings.GetCurrentLanguage());
                ViewData["CurrentItem"] = currentItem;
                ViewData["CurrentMessagesModule"] = currentModule;
               // NavigationManager.Instance.BuilDetailsPathesLinks(currentModule, currentItem);
                return View("~/Views/" + module + "/details.cshtml", currentItem);
            }
            else
            {
                ViewBag.Message = "Your application description page.";
                NavigationManager.Instance.BuilDefaultPathesLinks(currentModule);
                ViewBag.Title = NavigationManager.Instance.PageTitle;
                return View("~/Views/" + module + "/index.cshtml");
            }
        }

        public ActionResult Language(string id)
        {
            id = id.ToLower();
            Languages lang = (Languages)SiteSettings.Languages_DefaultLanguageID;
            switch (id)
            {
                case "ar":
                    lang = Languages.Ar;
                    break;
                case "en":
                    lang = Languages.En;
                    break;
                default:
                    break;
            }
            string cookie_name = SiteSettings.Site_CookieName;
            HttpCookie cookie=null;
            if (Request.Cookies[cookie_name] != null)
            {
                cookie = Response.Cookies[cookie_name];
                cookie["lang"] = lang.ToString();
               
            }
            else
            {
                cookie = new HttpCookie(cookie_name);
                cookie["lang"] = lang.ToString();
                cookie.Expires = DateTime.Now.AddYears(1);
                Response.SetCookie(cookie);
            }

            return RedirectToAction("Index");
        }
        //[OutputCache(Duration = CacheDuration, VaryByParam = "*")]
        public ActionResult Solutions()
        {
            ViewBag.Message = "Your application description page.";

            return View("~/Views/Solutions/index.cshtml");
        }
        //[OutputCache(Duration = CacheDuration, VaryByParam = "*")]
        public ActionResult Portfolio()
        {
            ViewBag.Message = "Your application description page.";

            return View("~/Views/Portfolio/index.cshtml");
        }
        //[OutputCache(Duration = CacheDuration, VaryByParam = "*")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("~/Views/Portfolio/index.cshtml");
        }
        [HttpPost]
        public JsonResult ContactUs(ContactUsModel message)
        {
            string resultMessage = null;
            bool SendingResult = MessagesController.ContactUS(message, out resultMessage);
            return Json(new { Message = resultMessage }, JsonRequestBehavior.AllowGet);
        }
         
    }
}