using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniFriend.Models;

namespace UniFriend.Controllers
{
    public class ClubsController : Controller
    {
        public ClubsPageModel model = GetModel();
        // GET: Clubs
        public ActionResult Index()
        {
            return View(model);
        }
        public static ClubsPageModel GetModel()
        {
            List<int> IEEEstudents = new List<int> { 1, 2, 3 };
            List<int> ACMStudents = new List<int> { 4, 5, 6 };

            List<Club> clubs = new List<Club>
            {
                new Club {ID = 1, name = "IEEE", students = IEEEstudents },
                new Club {ID = 2, name = "ACM", students = ACMStudents },
            };
            return new ClubsPageModel() { clubs = clubs };
        }

        public JsonResult GetStudent(int clubID)
        {
            return Json(model.clubs[clubID - 1].students);
        }

    } 
}