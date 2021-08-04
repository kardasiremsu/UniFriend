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
    {

        public ActionResult Index()
        {
            Student student = Data.students[Data.model.userid];
            
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
                departments.Add(department, Data.faculties[department].name);
            }


            ProfilePageModel profile = new ProfilePageModel { stud_name = student.stud_name, stud_gender = student.stud_gender, faculty = faculties, department = departments, friends = friends };

            return View(profile);
        }


    }
}