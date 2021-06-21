using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson01.Models.Data;
using Lesson01.Models;
using Lesson01.DAO;
namespace Lesson01.Controllers
{
    public class UserController : Controller
    {
        DBBanDanContext db = new DBBanDanContext();
        UserDAO userDao = new UserDAO();
        // GET: User
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection thamso)
        {
            string tendn = thamso[0];
            string matkhau = thamso[1];
            USER user_row = userDao.getRow(tendn, matkhau);
            if (user_row != null)
            {
                Session["UserID"] = user_row.IdUser;
                Session["UserFullName"] = user_row.FullName;
                Session["UserName"] = user_row.UserName;
                Session["UserEmail"] = user_row.Email;
                Session["UserPhone"] = user_row.Phone;
                Session["UserAddress"] = user_row.Address;
                return RedirectToActionPermanent("Index", "Site");
            }
            else
            {
                ViewBag.Notice = "<div class='alert alert-danger text-center my-3' role='alert'>Đăng nhập thất bại</div>";
            }
            return View();
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(FormCollection account)
        {          
            USER user = new USER();          
            if (account[0] == "" || account[1] == "" || account[2] == "" || account[3] == "" || account[4] == "" || account[5] == "" || account[6] == "" || account[3] != account[4])
            {
                ViewBag.Notice = "<div class='alert alert-danger text-center text-dark' role='alert'>Vui lòng điền đầy đủ thông tin</div>";
            }
            else if (account[3] == account[4])
            {
                user.IdRole = 5;
                user.FullName = account[1];
                user.UserName = account[2];
                user.Password = account[3];
                user.Email = account[0];
                user.Phone = account[5];
                user.Address = account[6];
                ViewBag.Notice = "<div class='alert alert-success text-center text-dark' role='alert'>Đăng ký thành công</div>";
                db.USERs.Add(user);
                db.SaveChanges();
            }
            else
            {
                ViewBag.Notice = "<div class='alert alert-danger text-center text-dark' role='alert'>Đăng ký thất bại</div>";
            }
            return View("SignUp");
        }

        public ActionResult LogOut()
        {
            Session["UserID"] = null;
            Session["UserFullName"] = null;
            Session["UserName"] = null;
            Session["UserEmail"] = null;
            Session["UserPhone"] = null;
            Session["UserAddress"] = null;
            return RedirectToAction("Index","Site");
        }

    }
}