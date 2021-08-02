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
                new CRN {ID = 1, code = "24654",students = new SelectList(oop24654students, "ID", "stud_name") },
                new CRN {ID = 2, code = "24655", students = new SelectList(oop24655students, "ID", "stud_name") },
                new CRN {ID = 3, code = "24656"},
            };

            List<CRN> dbcrns = new List<CRN>
            {
                new CRN {ID = 1, code = "25654"},
                new CRN {ID = 2, code = "25655"},
                new CRN {ID = 3, code = "25656"},
            };


            List<Lecture> computerlectures = new List<Lecture>
            {
                new Lecture {ID = 1, name ="Nesne Tabanlı Programlama",crns = new SelectList(oopcrns, "ID", "name")},
                new Lecture {ID = 2, name ="Veri Yapıları",crns = new SelectList(dbcrns, "ID", "name")},
            };

            List<Lecture> electroniclectures = new List<Lecture>
            {
                new Lecture {ID = 1, name ="Elektroniğe Giriş" },
                new Lecture {ID = 2, name ="Mikrokontrol" },
            };

            List<Department> engineering_departments = new List<Department>
            {
                new Department {ID = 1, name = "Bilgisayar Mühendisliği", lectures = new SelectList(computerlectures, "ID", "name") },
                new Department {ID = 2, name = "Elektrik Elektronik", lectures = new SelectList(electroniclectures, "ID", "name")}
            };


            List<Department> law_departments = new List<Department>
            {
                new Department {ID = 1,name= "Hukuk" },
            };


            List<Faculty> faculties = new List<Faculty>
            {
                new Faculty {ID = 1, name = "Mühendislik Fakültesi",departments = new SelectList(engineering_departments, "ID", "name")},
                new Faculty {ID = 2, name = "Hukuk Fakültesi", departments = new SelectList(law_departments, "ID", "name")}
            };

            return new AddFriendPageModel() { Faculties = new SelectList(faculties, "ID", "name") };
        }


        public AddFriendPageModel model = GetModel();

        public ActionResult Index()
        {
            return View(model);
        }

       public JsonResult GetDepartment(int facultyID) {
          
            var faculty = model.Faculties.ToList();
            return Json(faculty[facultyID].JsonRequestBehavior.AllowGet);


       }

       
    }
}