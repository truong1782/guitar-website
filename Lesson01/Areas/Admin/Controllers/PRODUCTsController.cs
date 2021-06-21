using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MyClass.Model;
using MyClass.DAO;
using System.IO;
using MyClass.Helper;

namespace Lesson01.Areas.Admin.Controllers
{
    public class PRODUCTsController : BaseController
    {
        ProductDAO db = new ProductDAO();

        // GET: Admin/PRODUCT
        public ActionResult Index()
        {
            var pRODUCTs = db.getList();
            return View(pRODUCTs.ToList());
        }

        // GET: Admin/PRODUCT/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.getRow(id ?? 0);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT);
        }

        // GET: Admin/PRODUCT/Create
        public ActionResult Create()
        {
            DBBanDanContext db1 = new DBBanDanContext();
            ViewBag.IdCategory = new SelectList(db1.CATEGORies, "IdCategory", "NameCategory");
            return View();
        }

        // POST: Admin/PRODUCT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                var img = Request.Files["Img"];
                String filename = img.FileName;
                string[] FileExtentions = new string[] { ".jpg", ".jepg", ".png", "gif" };
                if (FileExtentions.Contains(filename.Substring(filename.LastIndexOf("."))))
                {
                    string pathDir = Path.Combine(Server.MapPath("~/Public/images/Product/"), filename);
                    img.SaveAs(pathDir);
                    pRODUCT.Img = filename;
                }
                pRODUCT.Created_By = (int)Session["AdminID"];
                //pRODUCT.Created_By = 1;
                pRODUCT.Slug = Slug.GenerateSlug(pRODUCT.NameProduct);
                pRODUCT.Created_At = DateTime.Now;
                db.Insert(pRODUCT);
                return RedirectToAction("Index");
            }
            DBBanDanContext db1 = new DBBanDanContext();
            ViewBag.IdCategory = new SelectList(db1.CATEGORies, "IdCategory", "NameCategory", pRODUCT.IdCategory);
            return View(pRODUCT);
        }

        // GET: Admin/PRODUCT/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT pRODUCT = db.getRow(id ?? 0);
            if (pRODUCT == null)
            {
                return HttpNotFound();
            }
            DBBanDanContext db1 = new DBBanDanContext();
            ViewBag.IdCategory = new SelectList(db1.CATEGORies, "IdCategory", "NameCategory", pRODUCT.IdCategory);
            return View(pRODUCT);
        }

        // POST: Admin/PRODUCT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PRODUCT pRODUCT)
        {
            if (ModelState.IsValid)
            {
                var img = Request.Files["Img"];
                String filename = img.FileName;
                string[] FileExtentions = new string[] { ".jpg", ".jepg", ".png", "gif" };
                if (FileExtentions.Contains(filename.Substring(filename.LastIndexOf("."))))
                {
                    string pathDir = Path.Combine(Server.MapPath("~/Public/images/Product/"), filename);
                    img.SaveAs(pathDir);
                    pRODUCT.Img = filename;
                }
                pRODUCT.Created_By = (int)Session["AdminID"];
                pRODUCT.Created_By = pRODUCT.Created_By;
                pRODUCT.Created_At = pRODUCT.Created_At;
                pRODUCT.Slug = Slug.GenerateSlug(pRODUCT.NameProduct);
                db.Update(pRODUCT);
                return RedirectToAction("Index");
            }
            DBBanDanContext db1 = new DBBanDanContext();
            ViewBag.IdCategory = new SelectList(db1.CATEGORies, "IdCategory", "NameCategory", pRODUCT.IdCategory);
            return View(pRODUCT);
        }
        public ActionResult Delete(int id)
        {
            PRODUCT pRODUCT = db.getRow(id);
            db.Delete(pRODUCT);
            return RedirectToAction("Index");
        }

    }
}
