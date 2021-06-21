using MyClass.DAO;
using MyClass.Model;
using System.Web.Mvc;


namespace Lesson01.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        UserDAO userDAO = new UserDAO();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection thamso)
        {
            string tendn = thamso["username"];
            string matkhau = thamso["password"];
            USER row_user = userDAO.getRow(tendn, matkhau);
            if(row_user != null)
            {
                Session["AdminID"] = row_user.IdUser;
                Response.Redirect("~/Admin");
            }
            ViewBag.Error = "(*) Sai thông tin đăng nhập";
            return View();
        }
        public ActionResult Logout()
        {
            Session["AdminID"] = "";
            Response.Redirect("~/Admin/Login");
            return null;
        }
    }
}