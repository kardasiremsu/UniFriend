using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniFriend.Models.Entities;
using UniFriend.Models;
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
            Student student = Data.students.Find(c => (c.mail == mail) && (c.password == password));
            if (student != null)
            {
                return Json(Url.Action("Index", "AddFriend", new  { id = student.ID}));
            }
            else
            {
                return Json(false);
            }
        }

        public JsonResult Register(string mail, string password1)
        {
            Student user = new Student() { ID= Data.students.Count, mail = mail, password = password1 };
            Data.students.Add(user);
            return Json(Url.Action("Index", "Home"));
        }

    }
}