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
    public class CONTACTsController : BaseController
    {
        public ContactDAO db = new ContactDAO();

        // GET: Admin/CONTACT
        public ActionResult Index()
        {

            return View(db.getList());
        }

        // GET: Admin/CONTACT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACT cONTACT = db.getRow(id ?? 0);
            if (cONTACT == null)
            {
                return HttpNotFound();
            }
            return View(cONTACT);
        }

        // GET: Admin/CONTACT/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CONTACT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CONTACT cONTACT)
        {
            if (ModelState.IsValid)
            {
                db.Insert(cONTACT);
                return RedirectToAction("Index");
            }
            return View(cONTACT);
        }

        // GET: Admin/CONTACT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONTACT cONTACT = db.getRow(id ?? 0);
            if (cONTACT == null)
            {
                return HttpNotFound();
            }
            return View(cONTACT);
        }

        // POST: Admin/CONTACT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdContact,Title,Detail,FullName,Phone,Email,DateContact,Status,IdUser")] CONTACT cONTACT)
        {
            if (ModelState.IsValid)
            {
                db.Update(cONTACT);
                return RedirectToAction("Index");
            }
            return View(cONTACT);
        }
        public ActionResult Delete(int id)
        {
            CONTACT cONTACT = db.getRow(id);
            db.Delete(cONTACT);
            return RedirectToAction("Index");
        }
        public ActionResult Status(int id)
        {
            CONTACT cONTACT = db.getRow(id);
            cONTACT.Status = (cONTACT.Status == 1) ? 2 : 1;
            //cONTACT.IdUser = Session["IdUser"];
            db.Update(cONTACT);
            return RedirectToAction("Index");
        }
    }
}
