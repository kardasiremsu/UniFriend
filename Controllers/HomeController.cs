using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniFriend.Models;
using UniFriend.Models.Entities;

namespace UniFriend.Controllers
{
    public class HomeController : Controller
    {
        public LayoutViewModel LayoutModel { get; set; }
        
        public HomeController()
        {
            this.LayoutModel = new LayoutViewModel();
        }

        public ActionResult Index()
        {
            int ID = (int)Session["ID"];
            List<Club> clubs = new List<Club>();

            //Adding clubs to dictionary
            foreach (int clubid in Data.students[ID].club)
            {
                clubs.Add(Data.clubs[clubid]);
            }

            LayoutModel.Clubs = clubs;
            ViewData["LayoutViewModel"] = LayoutModel;
          

            Session["LayoutModel"] = LayoutModel;
           
            return View();
        }

        public JsonResult ReturnFlow()
        {
            return Json(Data.posts);
        }
    }
}