using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson01.Models.Data;
using Lesson01.Models;
namespace Lesson01.Controllers
{
    public class SiteController : Controller
    {
        DBBanDanContext db = new DBBanDanContext();

        // GET: Site
        public ActionResult Index()
        {
            ViewBag.listPr = db.PRODUCTs.ToList();
            ViewBag.listPr_acoustic = db.PRODUCTs.Where(p => p.CATEGORY.NameCategory == "Guitar Acoustic").ToList();
            ViewBag.listPr_classic = db.PRODUCTs.Where(p => p.CATEGORY.NameCategory == "Guitar Classic").ToList();
            ViewBag.listPr_eletric = db.PRODUCTs.Where(p => p.CATEGORY.NameCategory == "Guitar Điện").ToList();
            return View();
        }
    }
}