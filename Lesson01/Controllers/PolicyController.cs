using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lesson01.Controllers
{
    public class PolicyController : Controller
    {
        // GET: Policy
        public ActionResult Purchase_Policy()
        {
            return View();
        }

        public ActionResult Warranty_Policy()
        {
            return View();
        }

        public ActionResult Return_Policy()
        {
            return View();
        }

        public ActionResult Shipping_Policy()
        {
            return View();
        }
    }
}