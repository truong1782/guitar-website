using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Lesson01
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Session_Start()
        {
            Session["AdminID"] = "";
        }

        protected void Session_Login()
        {
            Session["UserID"] = null;
            Session["UserFullName"] = null;
            Session["UserName"] = null;
            Session["UserEmail"] = null;
            Session["UserPhone"] = null;
            Session["UserAddress"] = null;
        }
    }
}
