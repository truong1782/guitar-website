using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson01.DAO;
using Lesson01.Models.Data;
namespace Lesson01.Controllers
{
    public class ModuleController : Controller
    {
        DBBanDanContext db = new DBBanDanContext();
        // GET: Module
        public ActionResult Slide()
        {
            return View();
        }

        public ActionResult MainMenu()
        {
            List<CATEGORY> listcategory = new List<CATEGORY>();
            listcategory = db.CATEGORies.ToList();
            return View("MainMenu", listcategory);
        }

        public ActionResult ListCategory()
        {
            categoryDAO categoryDao = new categoryDAO();
            List<CATEGORY> listCategory = categoryDao.getlist();
            return View("ListCategory", listCategory);
        }



    }
}