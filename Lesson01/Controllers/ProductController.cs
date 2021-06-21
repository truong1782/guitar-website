using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson01.Controllers;
using Lesson01.Models.Data;
namespace Lesson01.Controllers
{
    public class ProductController : Controller
    {
        // GET: CuaHang
        DBBanDanContext db = new DBBanDanContext();
        public ActionResult Allproduct(string category_slug)
        {
            if (category_slug != null)
            {
                List<PRODUCT> listProduct = new List<PRODUCT>();
                listProduct = db.PRODUCTs.Where(p => p.CATEGORY.Slug == category_slug).ToList();
                ViewBag.listProduct = listProduct; // lấy sản phẩm
                ViewBag.title_product = db.CATEGORies.Where(p => p.Slug == category_slug).FirstOrDefault(); //lấy tiêu đề
            }
            else
            {
                List<PRODUCT> listProduct = new List<PRODUCT>();
                listProduct = db.PRODUCTs.ToList(); 
                ViewBag.listProduct = listProduct;// lấy sản phẩm
                ViewBag.title_product = "Tất cả sản phẩm"; // lấy tiêu đề
            }
            return View();
        }

        public ActionResult ProductDetail(string slug)
        {
            if (slug == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            List<PRODUCT> listproduct = new List<PRODUCT>();
            listproduct = db.PRODUCTs.ToList();       
            foreach (var item in listproduct)
            {
                if (item.Slug == slug)
                {
                    ViewBag.productdetail = item;
                }
            }       
            return View();
        }
    }
}