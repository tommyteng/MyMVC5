using System.Web.Http;
using WebActivatorEx;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(MyMVC5.Web.SwaggerConfig), "Register")]
namespace MyMVC5.Web
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "MyMVC5.Web");
                        c.IncludeXmlComments(string.Format("{0}/bin/MyMVC5.Web.XML", System.AppDomain.CurrentDomain.BaseDirectory));
                    })
                .EnableSwaggerUi(c =>
                    {
                        c.DocumentTitle("My Swagger UI");
                        //使用中文
                        c.InjectJavaScript(thisAssembly, "MyMVC5.Web.Scripts.Swagger.Swagger_lang.js");
                    });
        }
    }
}
