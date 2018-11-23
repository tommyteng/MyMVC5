using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MyMVC5.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();//注册区域
            GlobalConfiguration.Configure(WebApiConfig.Register); //webapi路由注册
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//filter
            RouteConfig.RegisterRoutes(RouteTable.Routes);//注册路由
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
