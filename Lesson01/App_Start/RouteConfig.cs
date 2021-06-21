using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lesson01
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute(
            //    name: "ThemGioHang",
            //    url: "them-gio-hang",
            //    defaults: new { controller = "Site", action = "ThemGioHang", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "GioHang",
            //    url: "gio-hang",
            //    defaults: new { controller = "Site", action = "GioHang", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "CuaHang",
            //    url: "cua-hang",
            //    defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            //);
            //routes.MapRoute(
            //    name: "LienHe",
            //    url: "lien-he",
            //    defaults: new { controller = "Contact", action = "Index", id = UrlParameter.Optional }
            //);
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Site", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
