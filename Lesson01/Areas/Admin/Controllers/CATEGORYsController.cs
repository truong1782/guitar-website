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
using MyClass.Helper;

namespace Lesson01.Areas.Admin.Controllers
{
    public class CATEGORYsController : BaseController
    {
        CategoryDAO categoryDAO = new CategoryDAO();

        // GET: Admin/CATEGORY
        public ActionResult Index()
        {
            return View(categoryDAO.getList());
        }

        // GET: Admin/CATEGORY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = categoryDAO.getRow(id ?? 0);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // GET: Admin/CATEGORY/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CATEGORY/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCategory,NameCategory,Slug,MetaKey,MetaDesc,Created_By,Created_At")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                cATEGORY.Slug = Slug.GenerateSlug(cATEGORY.NameCategory);
                categoryDAO.Insert(cATEGORY);
                return RedirectToAction("Index");
            }

            return View(cATEGORY);
        }

        // GET: Admin/CATEGORY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = categoryDAO.getRow(id ?? 0);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: Admin/CATEGORY/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCategory,NameCategory,Slug,MetaKey,MetaDesc,Created_By,Created_At")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                cATEGORY.Slug = "1";
                categoryDAO.Update(cATEGORY);
                return RedirectToAction("Index");
            }
            return View(cATEGORY);
        }

        public ActionResult Delete(int id)
        {
            CATEGORY cATEGORY = categoryDAO.getRow(id);
            categoryDAO.Delete(cATEGORY);
            return RedirectToAction("Index");
        }
    }
}
