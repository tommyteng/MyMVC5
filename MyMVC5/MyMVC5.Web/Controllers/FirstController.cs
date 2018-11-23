using MyMVC5.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC5.Web.Controllers
{
    /// <summary>
    /// MVC5路由、区域、传值、razor、扩展控件
    /// </summary>
    public class FirstController : Controller
    {
        public ActionResult Razor()
        {
            return View();
        }

        public ActionResult RazorShow ()
        { 
          return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Data(int? id)
        {
            //数据传值  ViewData,ViewBag,TempData,Model
            ViewData.Add(new KeyValuePair<string, object>("ID", 1));
            ViewData["Name"] = "Tommy";

            ViewBag.CurrentUser = new CurrentUser() {
                Id = 2,
                Account = "666666",
                Email = "666666@qq.com", 
                Name="zhuuo",
                Password = "666666", 
                LoginTime= DateTime.Now,
            };
            ViewBag.Name = "tony";

            TempData["Name"] = "Tommy_new";
            TempData["CurrentUser"] = new CurrentUser()
            {
                Id =3,
                Account = "8888888",
                Email = "888888@qq.com",
                Name = "yuyuy",
                Password = "666666",
                LoginTime = DateTime.Now,
            };
            if (id == null)
                return this.Redirect("/First/Temp");
            else if (id == 1)
                return View("~/Views/First/Data2.cshtml");
            else if (id == 2)
                return View("~/Views/First/Data3.cshtml", new CurrentUser()
                {
                    Id = 4,
                    Account = "999999",
                    Email = "999999@qq.com",
                    Name = "jiujiu",
                    Password = "999999",
                    LoginTime = DateTime.Now,
                });
            else if (id == 3)
                return View("~/Views/First/Data4.cshtml", new List<CurrentUser>(){  new CurrentUser()
                {
                    Id = 5,
                    Account = "111111",
                    Email = "111111@qq.com",
                    Name = "ssssss",
                    Password = "111111",
                    LoginTime = DateTime.Now,
                }});
            return View();
        }


        public string Date5(int year, int month, int day)
        {
            return string.Format("{0}-{1}-{2}", year, month, day);
        }

        public ActionResult Temp()
        {
            return View();
        }


        public ActionResult NoPara(int? id)
        {
            int k = id ?? 0;
            return View();
        }

        public ViewResult Para(int id)
        {
            return View();
        }

        public string String()
        {
            return "K";
        }

        public JsonResult GetJson()
        {
            return Json(new
            {
                Id = 123,
                Name = "风在飘动"
            }, JsonRequestBehavior.AllowGet);
        }

    }
}