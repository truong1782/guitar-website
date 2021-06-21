using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson01.Models.Data;
namespace Lesson01.Controllers
{
    public class ContactController : Controller
    {
        DBBanDanContext db = new DBBanDanContext();
        // GET: LienHe
        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult SendContact(FormCollection contactForm)
        {
            if (Session["UserID"] == null)
            {
                CONTACT contact = new CONTACT();
                contact.Title = contactForm[0];
                contact.Detail = contactForm[4];
                contact.FullName = contactForm[1];
                contact.Phone = contactForm[3];
                contact.Email = contactForm[2];
                contact.DateContact = DateTime.Now;
                db.CONTACTs.Add(contact);
                db.SaveChanges();
                ViewBag.Notice = "<div class='alert alert-success text-center text-dark' role='alert'>Gửi liên hệ thành công</div>";
            }
            else
            {
                CONTACT contact = new CONTACT();
                contact.Title = contactForm[0];
                contact.Detail = contactForm[1];
                contact.FullName = Session["UserFullName"].ToString();
                contact.Phone = Session["UserPhone"].ToString();
                contact.Email = Session["UserEmail"].ToString();
                contact.DateContact = DateTime.Now;
                contact.IdUser = Convert.ToInt32(Session["UserID"]);
                db.CONTACTs.Add(contact);
                db.SaveChanges();
                ViewBag.Notice = "<div class='alert alert-success text-center text-dark' role='alert'>Gửi liên hệ thành công</div>";
            }
            return View("Contact");
        }
    }
}