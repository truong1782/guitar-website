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
    public class POSTsController : BaseController
    {
        private DBBanDanContext db = new DBBanDanContext();

        // GET: Admin/POST
        public ActionResult Index()
        {
            var pOSTs = db.POSTs.Include(p => p.TOPIC).Include(p => p.USER);
            return View(pOSTs.ToList());
        }

        // GET: Admin/POST/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POST pOST = db.POSTs.Find(id);
            if (pOST == null)
            {
                return HttpNotFound();
            }
            return View(pOST);
        }

        // GET: Admin/POST/Create
        public ActionResult Create()
        {
            ViewBag.IdTopic = new SelectList(db.TOPICs, "IdTopic", "NameTopic");
            ViewBag.IdUser = new SelectList(db.USERs, "IdUser", "FullName");
            return View();
        }

        // POST: Admin/POST/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPost,IdUser,IdTopic,Slug,Title,Img,Sumary,PostType,Detail,DateCreate")] POST pOST)
        {
            if (ModelState.IsValid)
            {
                db.POSTs.Add(pOST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdTopic = new SelectList(db.TOPICs, "IdTopic", "NameTopic", pOST.IdTopic);
            ViewBag.IdUser = new SelectList(db.USERs, "IdUser", "FullName", pOST.IdUser);
            return View(pOST);
        }

        // GET: Admin/POST/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POST pOST = db.POSTs.Find(id);
            if (pOST == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdTopic = new SelectList(db.TOPICs, "IdTopic", "NameTopic", pOST.IdTopic);
            ViewBag.IdUser = new SelectList(db.USERs, "IdUser", "FullName", pOST.IdUser);
            return View(pOST);
        }

        // POST: Admin/POST/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPost,IdUser,IdTopic,Slug,Title,Img,Sumary,PostType,Detail,DateCreate")] POST pOST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pOST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdTopic = new SelectList(db.TOPICs, "IdTopic", "NameTopic", pOST.IdTopic);
            ViewBag.IdUser = new SelectList(db.USERs, "IdUser", "FullName", pOST.IdUser);
            return View(pOST);
        }

        // GET: Admin/POST/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            POST pOST = db.POSTs.Find(id);
            if (pOST == null)
            {
                return HttpNotFound();
            }
            return View(pOST);
        }

        // POST: Admin/POST/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            POST pOST = db.POSTs.Find(id);
            db.POSTs.Remove(pOST);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
