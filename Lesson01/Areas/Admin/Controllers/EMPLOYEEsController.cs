using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyClass.Model;
using MyClass.DAO;

namespace Lesson01.Areas.Admin.Controllers
{
    public class EMPLOYEEsController : BaseController
    {
        EmployeeDAO employeeDAO = new EmployeeDAO();
        
        // GET: Admin/USERs
        public ActionResult Index()
        {
            return View(employeeDAO.getList());
        }

        // GET: Admin/USERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = employeeDAO.getRow(id ?? 0);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }

        // GET: Admin/USERs/Create
        public ActionResult Create()
        {
            ViewBag.IdRole = new SelectList(employeeDAO.getRole(), "IDRole", "NameRole");
            return View();
        }

        // POST: Admin/USERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUser,IdRole,FullName,UserName,Password,Email,Phone,Address,Created_By,Created_At")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                uSER.Created_At = DateTime.Now;
                uSER.Created_By = (int)Session["AdminID"];
                //uSER.Created_By = 1;
                employeeDAO.Insert(uSER);
                return RedirectToAction("Index");
            }
            ViewBag.IdRole = new SelectList(employeeDAO.getRole(), "IDRole", "NameRole", uSER.IdRole);
            return View(uSER);
        }

        // GET: Admin/USERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = employeeDAO.getRow(id ?? 0);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            DBBanDanContext db = new DBBanDanContext();
            ViewBag.IdRole = new SelectList(employeeDAO.getRole(), "IDRole", "NameRole", uSER.IdRole);
            return View(uSER);
        }

        // POST: Admin/USERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUser,IdRole,FullName,UserName,Password,Email,Phone,Address,Created_By,Created_At")] USER uSER)
        {
            if (ModelState.IsValid)
            {
                employeeDAO.Update(uSER);
                return RedirectToAction("Index");
            }
            ViewBag.IdRole = new SelectList(employeeDAO.getRole(), "IDRole", "NameRole", uSER.IdRole);
            return View(uSER);
        }
        public ActionResult Delete(int id)
        {
            USER uSER = employeeDAO.getRow(id);
            employeeDAO.Delete(uSER);
            return RedirectToAction("Index");
        }
    }
}
