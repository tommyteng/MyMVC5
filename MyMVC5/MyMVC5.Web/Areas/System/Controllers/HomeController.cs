﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMVC5.Web.Areas.System.Controllers
{
    public class HomeController : Controller
    {
        // GET: System/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}