using MyMVC5.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MyMVC5.Web.Controllers
{

    /// <summary>
    ///  今天讨论的问题：
    /// 1、在浏览器输入 http://www.baidu.com 到浏览器响应 这期间都发生了什么？
    ///2、.net核心运行机制：.net framework 是怎么处理http请求的？
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            HttpApplication app = base.HttpContext.ApplicationInstance;

            List<SysEvent> sysEventsList = new List<SysEvent>();
            int i = 1;
            foreach (EventInfo e in app.GetType().GetEvents())
            {
                sysEventsList.Add(new SysEvent()
                {
                    Id = i++,
                    Name = e.Name,
                    TypeName = e.GetType().Name
                });
            }

            return View(sysEventsList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Main()
        {
            return View();
        }
    }
}