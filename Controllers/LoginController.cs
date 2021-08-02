using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UniFriend.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult LoginCheck(string mail, string password )
        {
            if(mail == "a@a.com" && password == "a")
            {
                return Json(Url.Action("Index", "Home"));
            }
            else
            {
                return Json(false);
            }
        }
    }
}