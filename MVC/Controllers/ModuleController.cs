using AppService;
using DCCMSNameSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class ModuleController : Controller
    {
         //[OutputCache(Duration = int.MaxValue, VaryByParam = "*")]
        public ActionResult Defaule(int? pageId, string module)
        {
            int pageIndex = 1;
            if (pageId.HasValue) pageIndex = pageId.Value;
            ItemsModulesOptions currentModule = ItemsModulesOptions.GetType(module);

            ViewBag.PageIndex = pageIndex;
            ViewBag.CurrentModule = currentModule;
            //pageIndex = (int)ViewData["PageIndex"];
            NavigationManager.Instance.BuilDefaultPathesLinks(currentModule);
            ViewBag.Title = NavigationManager.Instance.PageTitle;
            return View("~/Views/" + module + "/index.cshtml");

        }
         //[OutputCache(Duration = int.MaxValue, VaryByParam = "*")]
        public ActionResult Category(int? categoryId, int? pageId, string module)
         {
             int categoryID = 0;
             int pageIndex = 1;

             if (pageId.HasValue) pageIndex = pageId.Value;
             if (categoryId.HasValue) categoryID = categoryId.Value;
             ItemsModulesOptions currentModule = ItemsModulesOptions.GetType(module);

             ViewBag.PageIndex = pageIndex;
             ViewBag.CategoryID = categoryID;
             ViewBag.CurrentModule = currentModule;
             //pageIndex = (int)ViewData["PageIndex"];
             NavigationManager.Instance.BuilDefaultPathesLinks(currentModule);
             ViewBag.Title = NavigationManager.Instance.PageTitle;
             return View("~/Views/" + module + "/Items.cshtml");

         }
         //[OutputCache(Duration = int.MaxValue, VaryByParam = "*")]
         public ActionResult Details(int? id, string module)
        {
            //module
            ItemsModulesOptions currentModule = ItemsModulesOptions.GetType(module);
            if (id.HasValue)
            {
                ViewBag.Message = "Your application description page.";
                FrontItemsModel currentItem = FrontItemsController.GetItemObject(id.Value, SiteSettings.GetCurrentLanguage());
                ViewData["CurrentItem"] = currentItem;
                ViewData["CurrentItemsModule"] = currentModule;
                ViewBag.CurrentModule = currentModule;

                NavigationManager.Instance.BuilDetailsPathesLinks(currentModule, currentItem);
                ViewBag.Title = NavigationManager.Instance.PageTitle;
                if (id.HasValue)
                {
                    ViewBag.ActiveID = id.Value;
                }
                return View("~/Views/" + module + "/details.cshtml", currentItem);
            }
            else
            {
                return HttpNotFound();
            }
        }

    }
}