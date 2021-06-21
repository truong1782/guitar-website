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
using System.IO;

namespace Lesson01.Areas.Admin.Controllers
{
    public class SLIDERsController : BaseController
    {
        SliderDAO sliderDAO = new SliderDAO();

        // GET: Admin/SLIDER
        public ActionResult Index()
        {
            var sLIDERs = sliderDAO.getList();
            return View(sLIDERs.ToList());
        }

        // GET: Admin/SLIDER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDER sLIDER = sliderDAO.getRow(id ?? 0);
            if (sLIDER == null)
            {
                return HttpNotFound();
            }
            return View(sLIDER);
        }

        // GET: Admin/SLIDER/Create
        public ActionResult Create()
        {
            return View();  
        }

        // POST: Admin/SLIDER/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SLIDER sLIDER)
        {
            if (ModelState.IsValid)
            {
                var img = Request.Files["Img"];
                String filename = img.FileName;
                string[] FileExtentions = new string[] { ".jpg", ".jepg", ".png", "gif" };
                if (FileExtentions.Contains(filename.Substring(filename.LastIndexOf("."))))
                {
                    string pathDir = Path.Combine(Server.MapPath("~/Public/images/Slider/"), filename);
                    img.SaveAs(pathDir);
                    sLIDER.Img = filename;
                }
                //sLIDER.IdUser = Session[IdUser];
                sLIDER.IdUser = 18  ;
                sLIDER.DateCreate = DateTime.Now;
                sliderDAO.Insert(sLIDER);
                return RedirectToAction("Index");
            }
            return View(sLIDER);
        }

        // GET: Admin/SLIDER/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SLIDER sLIDER = sliderDAO.getRow(id ?? 0);
            if (sLIDER == null)
            {
                return HttpNotFound();
            }
            return View(sLIDER);
        }

        // POST: Admin/SLIDER/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdSlider,Name,Link,Img,DateCreate,IdUser")] SLIDER sLIDER)
        {
            if (ModelState.IsValid)
            {
                var img = Request.Files["Img"];
                String filename = img.FileName;
                string[] FileExtentions = new string[] { ".jpg", ".jepg", ".png", "gif" };
                if (FileExtentions.Contains(filename.Substring(filename.LastIndexOf("."))))
                {
                    string pathDir = Path.Combine(Server.MapPath("~/Public/images/Slider/"), filename);
                    img.SaveAs(pathDir);
                    sLIDER.Img = filename;
                }

                sLIDER.DateCreate = sLIDER.DateCreate;
                sLIDER.IdUser = 1;
                sliderDAO.Update(sLIDER);
                return RedirectToAction("Index");
            }
            return View(sLIDER);
        }

        public ActionResult Delete(int id)
        {
            SLIDER sLIDER = sliderDAO.getRow(id);
            sliderDAO.Delete(sLIDER);
            return RedirectToAction("Index");
        }
    }
}
