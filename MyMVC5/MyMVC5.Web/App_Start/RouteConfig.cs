using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyMVC5.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //忽略路由：只要url满足这个正则规则  就不使用路由
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}"); 

            //路由扩展
            //1、短地址
            routes.MapRoute(
                name: "About",
                url: "About",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional },
                namespaces: new string[] { "MyMVC5.Web.Controllers" }
            );
            //2、修改控制器
            routes.MapRoute(
               name: "Test",
               url: "Test/{action}/{id}",
               defaults: new { controller = "First", action = "Index", id = UrlParameter.Optional },
               namespaces: new string[] { "MyMVC5.Web.Controllers" }
            );

            //3、约束
            routes.MapRoute(
              name: "Regex",
              url: "{controller}/{action}_{year}_{month}_{day}",
              defaults: new { controller = "First", action = "Index", id = UrlParameter.Optional },
              constraints: new { year = @"\d{4}", month = @"\d{2}", day = @"\d{2}" },
              namespaces: new string[] { "MyMVC5.Web.Controllers" }
           );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new string[] { "MyMVC5.Web.Controllers" }
            );
        }
    }
}
