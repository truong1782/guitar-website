using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;

namespace Lesson01.Areas.Admin.Controllers
{
    public class TOPICsController : BaseController
    {
        private DBBanDanContext db = new DBBanDanContext();

        // GET: Admin/TOPIC
        public ActionResult Index()
        {
            var tOPICs = db.TOPICs.Include(t => t.USER);
            return View(tOPICs.ToList());
        }

        // GET: Admin/TOPIC/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOPIC tOPIC = db.TOPICs.Find(id);
            if (tOPIC == null)
            {
                return HttpNotFound();
            }
            return View(tOPIC);
        }

        // GET: Admin/TOPIC/Create
        public ActionResult Create()
        {
            ViewBag.IdUser = new SelectList(db.USERs, "IdUser", "FullName");
            return View();
        }

        // POST: Admin/TOPIC/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTopic,NameTopic,Slug,IdUser")] TOPIC tOPIC)
        {
            if (ModelState.IsValid)
            {
                db.TOPICs.Add(tOPIC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUser = new SelectList(db.USERs, "IdUser", "FullName", tOPIC.IdUser);
            return View(tOPIC);
        }

        // GET: Admin/TOPIC/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOPIC tOPIC = db.TOPICs.Find(id);
            if (tOPIC == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUser = new SelectList(db.USERs, "IdUser", "FullName", tOPIC.IdUser);
            return View(tOPIC);
        }

        // POST: Admin/TOPIC/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTopic,NameTopic,Slug,IdUser")] TOPIC tOPIC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOPIC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUser = new SelectList(db.USERs, "IdUser", "FullName", tOPIC.IdUser);
            return View(tOPIC);
        }
        public ActionResult Delete(int id)
        {
            TOPIC tOPIC = db.TOPICs.Find(id);
            db.TOPICs.Remove(tOPIC);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
