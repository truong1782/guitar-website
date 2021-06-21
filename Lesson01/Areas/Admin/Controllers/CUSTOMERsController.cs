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
    public class CUSTOMERsController : BaseController
    {
        CustomerDAO customerDAO = new CustomerDAO();

        // GET: Admin/CUSTOMER
        public ActionResult Index()
        {
            return View(customerDAO.getList());
        }

        // GET: Admin/CUSTOMER/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            USER uSER = customerDAO.getRow(id ?? 0);
            if (uSER == null)
            {
                return HttpNotFound();
            }
            return View(uSER);
        }
        public ActionResult Delete(int id)
        {
            USER uSER = customerDAO.getRow(id);
            customerDAO.Delete(uSER);
            return RedirectToAction("Index");
        }
    }
}
