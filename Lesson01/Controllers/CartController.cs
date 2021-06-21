using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lesson01.Models.Data;
namespace Lesson01.Controllers
{
    public class CartController : Controller
    {
        DBBanDanContext db = new DBBanDanContext();
        // GET: Cart
        public ActionResult Cart()
        {
            return View();
        }

        public ActionResult AddToCart(string slug)
        {
            if (slug == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            if (Session["cart"] == null)
            {
                List<Cart> lscart = new List<Cart>();
                PRODUCT row = db.PRODUCTs.Where(p => p.Slug == slug).FirstOrDefault();
                Cart cart = new Cart(row, 1);
                lscart.Add(cart);
                Session["cart"] = lscart;
            }
            else
            {
                List<Cart> lscart = (List<Cart>)Session["cart"];
                int check = isExistingCheck(slug);
                if (check == -1)
                {
                    PRODUCT row = db.PRODUCTs.Where(p => p.Slug == slug).FirstOrDefault();
                    Cart cart = new Cart(row, 1);
                    lscart.Add(cart);
                }
                else
                {
                    lscart[check].quantity++;
                }
                Session["cart"] = lscart;
            }
            return RedirectToAction("Cart");
        }
        private int isExistingCheck(string slug) //Kiem tra xem sản phẩm có tồn tại không
        {
            List<Cart> lscart = (List<Cart>)Session["cart"];
            for (int i = 0; i < lscart.Count; i++)
            {
                if (lscart[i].PRODUCT.Slug == slug)
                {
                    return i;
                }
            }
            return -1;
        }

        public ActionResult DeleteProduct(string slug) //Xóa sản phẩm 
        {
            if (slug == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            List<Cart> lscart = (List<Cart>)Session["cart"];
            int check = isExistingCheck(slug);
            lscart.RemoveAt(check);
            return RedirectToAction("Cart");
        }

        public ActionResult DeleteAllProduct() //Xóa tất cả sản phẩm
        {
            List<Cart> lscart = (List<Cart>)Session["cart"];
            for (int i = 0; i < lscart.Count; i++)
            {
                Cart item = lscart[i];
                lscart.Remove(item);
            }
            return RedirectToAction("Cart");
        }

        public ActionResult UpdateQuantity(FormCollection fc) //Xóa sản phẩm
        {
            string[] quantities = fc.GetValues("quantity");
            List<Cart> lscart = (List<Cart>)Session["cart"];
            for (int i = 0; i < lscart.Count; i++)
            {
                lscart[i].quantity = Convert.ToInt32(quantities[i]);
            }
            Session["cart"] = lscart;
            return RedirectToAction("Cart");
        }

        public ActionResult CheckOut()
        {
            return View();
        }

        public ActionResult Order()
        {
            //Tạo Order
            ORDER order = new ORDER();
            order.DateOrder = DateTime.Now;
            order.IdUser = Convert.ToInt32(Session["UserID"]);
            db.ORDERs.Add(order);
            db.SaveChanges();

            //Tạo Order Detail
            List<Cart> lscart = (List<Cart>)Session["cart"];
            foreach (Cart item in lscart)
            {
                ORDER_DETAIL order_detail = new ORDER_DETAIL();
                order_detail.IdProduct = item.PRODUCT.IdProduct;
                order_detail.IdOrder = order.IdOrder;
                order_detail.Quantity = item.quantity;
                order_detail.PriceBuy = (item.PRODUCT.PriceBuy * item.quantity);
                db.ORDER_DETAIL.Add(order_detail);
                db.SaveChanges();
            }

            //Xóa session Cart
            Session.Remove("cart");
            return View("Order");
        }
    }
}