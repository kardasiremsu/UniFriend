﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniFriend.Models;
using UniFriend.Models.Entities;
namespace UniFriend.Controllers {
    public class ProfileController : Controller {/*
        public ActionResult Edit()
        {
            Student user = Data.students[(int)Session["ID"]];
            ProfileEditModel EditModel = new ProfileEditModel { ID = user.ID, stud_name = user.stud_name, stud_number = user.stud_number, stud_gender = user.stud_gender, lecture = user.lecture, crn = user.crn, faculty = user.faculty, department = user.department };

            return View(EditModel);
        }*/


        public ActionResult Index() {
            ViewData["LayoutViewModel"] = (LayoutViewModel)Session["LayoutModel"];

            Student student = Data.students[(int)Session["ID"]];

            Dictionary<int, string> friends = new Dictionary<int, string>();
            foreach(int i in student.friends) {

                friends.Add(i, Data.students[i].stud_name);
            }

            Dictionary<int, string> faculties = new Dictionary<int, string>();

            foreach(int faculty in student.faculty) {
                faculties.Add(faculty, Data.faculties[faculty].name);
            }

            Dictionary<int, string> departments = new Dictionary<int, string>();

            foreach(int department in student.department) {
                departments.Add(department, Data.departments[department].name);
            }

            ProfilePageModel profile = new ProfilePageModel { stud_name = student.stud_name, stud_gender = student.stud_gender, faculty = faculties, department = departments, friends = friends };

            return View(profile);
        }

        public JsonResult GetLectures(string text) {
            List<Lecture> outOf = new List<Lecture>();
            foreach(Lecture lecture in Data.lectures) {
                if(!Data.students[(int)Session["ID"]].lecture.Contains(lecture.ID)) {
                    outOf.Add(lecture);
                }
            }

            text = text.ToLower();
            if(string.IsNullOrEmpty(text)) {
                return Json(outOf);
            }

            List<Lecture> result = new List<Lecture>();
            foreach(Lecture lecture in outOf) {
                if(lecture.name.ToLower().Contains(text)) {
                    result.Add(lecture);
                }
            }

            return Json(result);
        }

        public JsonResult AddLecture(int lectureID) {
            Data.students[(int)Session["ID"]].lecture.Add(lectureID);
            return Json(true);
        }

        public JsonResult DeleteLecture(int lectureID) {
            Data.students[(int)Session["ID"]].lecture.Remove(lectureID);
            return Json(true);
        }

        public JsonResult GetStudentLectures() {
            List<Lecture> lectures = new List<Lecture>();
            foreach(var lectureID in Data.students[(int)Session["ID"]].lecture) {
                lectures.Add(Data.lectures[lectureID]);
            }
            return Json(lectures);
        }
    }
}