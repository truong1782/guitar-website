﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson01.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        public ActionResult AllBlog()
        {
            return View();
        }

        public ActionResult TinChiaSe()
        {
            return View();
        }
    }
}