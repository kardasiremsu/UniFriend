using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniFriend.Models;
using UniFriend.Models.Entities;
namespace UniFriend.Controllers {



    public class AddFriendController : Controller {

        public LayoutViewModel LayoutModel { get; set; }
        public AddFriendController()
        {
            this.LayoutModel = new LayoutViewModel();//has property PageTitle

        }
        public ActionResult Index(int id) {
            Data.model.userid = id;
            List<Club> clubs = new List<Club>();
            
            //Adding clubs to dictionary
            foreach (int clubid in Data.students[id].club)
            {
                clubs.Add(Data.clubs[clubid]);
            }
            
            LayoutModel.Clubs = clubs;
            this.ViewData["LayoutViewModel"] = this.LayoutModel;
            Session["LayoutModel"] = LayoutModel;
            return View(Data.model);
        }

        public JsonResult GetCategories() {
            return Json(new List<KeyValuePair<int, string>> { new KeyValuePair<int, string>(0, "Faculty"), new KeyValuePair<int, string>(1, "Club") });
        }

        public JsonResult GetFaculty() {
            return Json(Data.faculties);
        }

        public JsonResult GetDepartment(int facultyID) {
            List<Department> departments = new List<Department>();

            foreach(int departmentID in Data.faculties[facultyID].departments) {
                departments.Add(Data.departments[departmentID]);
            }
            return Json(departments);
        }

        public JsonResult GetLecture(int departmentID) {
            List<Lecture> lectures = new List<Lecture>();

            foreach(int lecturesID in Data.departments[departmentID].lectures) {
                lectures.Add(Data.lectures[lecturesID]);
            }
            return Json(lectures);
        }

        public JsonResult GetCRN(int lectureID) {
            List<CRN> crns = new List<CRN>();

            foreach(int crnsID in Data.lectures[lectureID].crns) {
                crns.Add(Data.CRNs[crnsID]);
            }
            return Json(crns);
        }

        public JsonResult GetStudent(int CRNID) {
            List<Student> students = new List<Student>();

            foreach(int studentID in Data.CRNs[CRNID].students) {
                students.Add(Data.students[studentID]);
            }
            return Json(students);
        }

        public JsonResult GetClubStudent(int clubID) {
            List<Student> students = new List<Student>();

            foreach(int studentID in Data.clubs[clubID].students) {
                students.Add(Data.students[studentID]);
            }
            return Json(students);
        }

        public JsonResult AddFriend(int ID) {
            Student user = Data.students[Data.model.userid];
            user.friends.Add(ID);
            return Json(true);
        }

        public JsonResult GetClubs() {
            return Json(Data.clubs);
        }
    }
}