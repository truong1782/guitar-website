using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.DAO;
using MyClass.Model;

namespace Lesson01.Areas.Admin.Controllers
{
    public class ORDERsController : BaseController
    {
        public OrderDAO db = new OrderDAO();

        // GET: Admin/ORDER
        public ActionResult Index()
        {
            return View(db.GetList());
        }

        // GET: Admin/ORDER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER order = db.GetRow(id ?? 0);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        public ActionResult Delete(int id)
        {
            ORDER oRDER = db.GetRow(id);
            db.Delete(oRDER);
            return RedirectToAction("Index");
        }
        public ActionResult Status(int id)
        {
            ORDER oRDER = db.GetRow(id);
            oRDER.Status = (oRDER.Status == 1) ? 2 : 1;
            db.Update(oRDER);
            return RedirectToAction("Index");
        }
    }
}
