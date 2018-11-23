using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using System.Web.Http.Cors;
using System.Configuration;

namespace MyWebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //跨域配置
            //config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
            ////1 限制访问权限
            //var allowedMethods = ConfigurationManager.AppSettings["cors:allowedMethods"];
            //var allowedOrigin = ConfigurationManager.AppSettings["cors:allowedOrigin"];
            //var allowedHeaders = ConfigurationManager.AppSettings["cors:allowedHeaders"];
            //var enableCors = new EnableCorsAttribute(allowedOrigin, allowedHeaders, allowedMethods)
            //{
            //    SupportsCredentials = true
            //};
            //config.EnableCors(enableCors);

            //2、特性标注  [EnableCors(origins: "http://localhost:8081/", headers: "*", methods: "GET,POST,PUT,DELETE")]


            EnableCorsAttribute attribute = new EnableCorsAttribute("http://localhost:16202", "*", "*");
            attribute.Origins.Add("http://localhost:19476");
            config.EnableCors(attribute);


            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
