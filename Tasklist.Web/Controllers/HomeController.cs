﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Tasklist.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
