using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniFriend.Models;
using UniFriend.Models.Entities;

namespace UniFriend.Controllers
{
    public class ClubsController : Controller
    {
        public ActionResult Index()
        {
            return View(Data.model);
        }


        public JsonResult GetStudent(int clubID)
        {
            List<Student> students = new List<Student>();

            foreach (int studentID in Data.clubs[clubID].students)
            {
                students.Add(Data.students[studentID]);
            }
            return Json(students);
        }

        public JsonResult GetClubs()
        {
            return Json(Data.clubs);
        }
        public JsonResult AddFriend()
        {
            return Json(true);
        }
    } 
}