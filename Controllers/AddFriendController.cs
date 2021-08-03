using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniFriend.Models;

namespace UniFriend.Controllers
{

    public class AddFriendController : Controller
    {

        public static AddFriendPageModel GetModel()
        {

            List<Student> oop24655students = new List<Student>
            {
                new Student {ID = 1, stud_name = "İrem", stud_gender = 'K', stud_number = "12383"},
                new Student {ID = 2, stud_name = "Sinan", stud_gender = 'E', stud_number = "12845"},
            };

            List<Student> oop24654students = new List<Student>
            {
                new Student {ID = 1, stud_name = "İremsu", stud_gender = 'K', stud_number = "12313"},
                new Student {ID = 2, stud_name = "Buğra", stud_gender = 'E', stud_number = "121454"},
            };

            List<CRN> oopcrns = new List<CRN>
            {
                new CRN {ID = 1, code = "24654",students = oop24654students},
                new CRN {ID = 2, code = "24655", students = oop24655students},
                new CRN {ID = 3, code = "24656", students = new List<Student>() },
            };

            List<CRN> dbcrns = new List<CRN>
            {
                new CRN {ID = 1, code = "25654"},
                new CRN {ID = 2, code = "25655"},
            };


            List<Lecture> computerlectures = new List<Lecture>
            {
                new Lecture {ID = 1, name ="Nesne Tabanlı Programlama",crns = oopcrns},
                new Lecture {ID = 2, name ="Veri Yapıları",crns = dbcrns},
            };

            List<Lecture> electroniclectures = new List<Lecture>
            {
                new Lecture {ID = 1, name ="Elektroniğe Giriş" },
                new Lecture {ID = 2, name ="Mikrokontrol" },
            };

            List<Department> engineering_departments = new List<Department>
            {
                new Department {ID = 1, name = "Bilgisayar Mühendisliği", lectures = computerlectures },
                new Department {ID = 2, name = "Elektrik Elektronik", lectures = electroniclectures}
            };


            List<Department> law_departments = new List<Department>
            {
                new Department {ID = 1,name= "Hukuk" },
            };


            List<Faculty> faculties = new List<Faculty>
            {
                new Faculty {ID = 1, name = "Mühendislik Fakültesi",departments = engineering_departments },
                new Faculty {ID = 2, name = "Hukuk Fakültesi", departments = law_departments }
            };

            return new AddFriendPageModel() { Faculties = faculties };
        }


        public AddFriendPageModel model = GetModel();

        public ActionResult Index()
        {
            return View(model);
        }

       public JsonResult GetDepartment(int facultyID) {
            return Json(model.Faculties[facultyID-1].departments);
       }
       public JsonResult GetLecture(int facultyID, int departmentID)
        {
            return Json(model.Faculties[facultyID - 1].departments[departmentID-1].lectures);
        }

        public JsonResult GetCRN(int facultyID, int departmentID, int LectureID)
        {
            return Json(model.Faculties[facultyID - 1].departments[departmentID - 1].lectures[LectureID-1].crns);
        }

        public JsonResult GetStudent(int facultyID, int departmentID, int LectureID, int CRNID)
        {
            return Json(model.Faculties[facultyID - 1].departments[departmentID - 1].lectures[LectureID-1].crns[CRNID-1].students);
        }
        public bool AddFriend(int StudentID)
        {
            return true;
        }
    }   
}