using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Owin;

namespace OwinHostWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            //初始化StartOptions参数
            StartOptions options = new StartOptions();
            options.Urls.Add("http://192.168.1.93:9000");
            options.Urls.Add("http://192.168.1.93:9001");

            options.ServerFactory = "Microsoft.Owin.Host.HttpListener";

            using (WebApp.Start(options, Startup)) {
                //显示启动信息,通过ReadLine驻留当前进程
                Console.WriteLine("Owin Host/Server started,press enter to exit it...");
                Console.ReadLine();
            }
        }

        private static void Startup(Owin.IAppBuilder app)
        {
            //加载Sample Middleware
            Console.WriteLine("Sample Middleware loaded...");
            app.Use<SampleMiddleware>();
        }
    }
}
