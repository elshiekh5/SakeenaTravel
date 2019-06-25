using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //-------------------------------------------------------------------------------------
            //Module
            routes.MapRoute(
                name: "ModuleDefautPage",
                url: "{module}/all/{pageId}",
                defaults: new { controller = "Module", action = "Defaule", pageId = UrlParameter.Optional, module = UrlParameter.Optional }
            );
            //-------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "ModuleCategoryPage",
                url: "{module}/cat/{categoryId}/page/{pageId}",
                defaults: new { controller = "Module", action = "Category", categoryId = UrlParameter.Optional, pageId = UrlParameter.Optional, module = UrlParameter.Optional }
            );
            //-------------------------------------------------------------------------------------
            //Module
            routes.MapRoute(
                name: "ModuleDetailsPage",
                url: "{module}/page/{id}",
                defaults: new { controller = "Module", action = "Details", id = UrlParameter.Optional, module = UrlParameter.Optional }
            );
            //-------------------------------------------------------------------------------------
            //Module
            /*routes.MapRoute(
                 name: "Module",
                 url: "Module/{module}/{id}",
                 defaults: new { controller = "Home", action = "Module", id = UrlParameter.Optional, module = UrlParameter.Optional }
             );*/
            //-------------------------------------------------------------------------------------
            //Message Module
            routes.MapRoute(
                name: "MessageModules",
                url: "Message/{module}/{id}",
                defaults: new { controller = "Home", action = "Message", id = UrlParameter.Optional, module = UrlParameter.Optional }
            );
            //-------------------------------------------------------------------------------------
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            //-------------------------------------------------------------------------------------
        }
    }
}
