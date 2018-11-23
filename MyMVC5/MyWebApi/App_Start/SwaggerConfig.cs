using System.Web.Http;
using WebActivatorEx;
using MyWebApi;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace MyWebApi
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                 .EnableSwagger(c =>
                 {
                     c.SingleApiVersion("v1", "MyWebApi");
                     c.IncludeXmlComments(string.Format("{0}/bin/MyWebApi.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                 })
                .EnableSwaggerUi(c =>
                {
                    c.DocumentTitle("MyWebApi");
                    c.InjectJavaScript(thisAssembly, "MyWebApi.Scripts.swagger.swagger_lang.js");

                });
        }
    }
}
