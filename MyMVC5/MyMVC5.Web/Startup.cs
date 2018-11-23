using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMVC5.Web.Startup))]
namespace MyMVC5.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
