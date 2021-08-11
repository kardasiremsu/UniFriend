using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniFriend.Models;
using UniFriend.Models.Entities;
namespace UniFriend.Controllers
{
    public class ProfileController : Controller
    {/*
        public ActionResult Edit()
        {
            Student user = Data.students[(int)Session["ID"]];
            ProfileEditModel EditModel = new ProfileEditModel { ID = user.ID, stud_name = user.stud_name, stud_number = user.stud_number, stud_gender = user.stud_gender, lecture = user.lecture, crn = user.crn, faculty = user.faculty, department = user.department };

            return View(EditModel);
        }*/
      

        public ActionResult Index()
        {
            ViewData["LayoutViewModel"] = (LayoutViewModel)Session["LayoutModel"];
        
            Student student = Data.students[(int)Session["ID"]];
            
            Dictionary<int, string> friends = new Dictionary<int, string>();
            foreach (int i in student.friends)
            {
                
                friends.Add(i, Data.students[i].stud_name);
            }

            Dictionary<int, string> faculties = new Dictionary<int, string>();
        
            foreach (int faculty in student.faculty)
            {
                faculties.Add(faculty,Data.faculties[faculty].name);
            }

            Dictionary<int, string> departments = new Dictionary<int, string>();

            foreach (int department in student.department)
            {
                departments.Add(department, Data.departments[department].name);
            }

            ProfilePageModel profile = new ProfilePageModel { stud_name = student.stud_name, stud_gender = student.stud_gender, faculty = faculties, department = departments, friends = friends };

            return View(profile);
        }

        public JsonResult GetLectures(string text)
        {
           

            if (string.IsNullOrEmpty(text))
            {
                return Json(Data.lectures);
            }

           
            IEnumerable<Lecture> result = Data.lectures.Where(s => s.name.Contains(text));
        
            return Json(result);
        }


    }
}