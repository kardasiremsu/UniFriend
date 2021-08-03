using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniFriend.Models;
using UniFriend.Models.Entities;
namespace UniFriend.Controllers
{

    public class AddFriendController : Controller
    {

        public ActionResult Index()
        {
            return View(Data.model);
        }

       public JsonResult GetFaculty()
        {
            return Json(Data.faculties);
        }
       public JsonResult GetDepartment(int facultyID) {
            List<Department> departments = new List<Department>();

            foreach(int departmentID in Data.faculties[facultyID].departments)
            {
                departments.Add(Data.departments[departmentID]);
            }
            return Json(departments);
       }
      
        public JsonResult GetLecture(int departmentID)
        {
            List<Lecture> lectures = new List<Lecture>();

            foreach (int lecturesID in Data.departments[departmentID].lectures)
            {
                lectures.Add(Data.lectures[lecturesID]);
            }
            return Json(lectures);
        }

        public JsonResult GetCRN(int lectureID)
        {
            List<CRN> crns = new List<CRN>();

            foreach (int crnsID in Data.lectures[lectureID].crns)
            {
                crns.Add(Data.CRNs[crnsID]);
            }
            return Json(crns);
        }

        public JsonResult GetStudent(int CRNID)
        {
            List<Student> students = new List<Student>();

            foreach (int studentID in Data.CRNs[CRNID].students)
            {
                students.Add(Data.students[studentID]);
            }
            return Json(students);
        }

          public bool AddFriend(int StudentID)
          {
              return true;
          }
      
    }   
}