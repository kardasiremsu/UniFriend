using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniFriend.Models;

namespace UniFriend.Controllers
{
    public class HomeController : Controller
    {
        

        public ActionResult Index()
        {
       
            this.ViewData["LayoutViewModel"] = (LayoutViewModel)Session["LayoutModel"];
            return View();
        }
    }
}