using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniFriend.Models.Entities
{
    public class Data
    {
        public static List<Student> students = GetStudents();
        public static List<CRN> CRNs = GetCRNs();
        public static List<Lecture> lectures = GetLectures();
        public static List<Department> departments = GetDepartments();
        public static List<Faculty> faculties = GetFaculties();
        public static AddFriendPageModel model = GetModel();
        public static List<Club> clubs = GetClubs();
        public static ClubsPageModel clubmodel = GetClubModel();


        public static ClubsPageModel GetClubModel()
        {
            return new ClubsPageModel { clubs = new List<int> { 0, 1,2,3 } };
        }

        public static AddFriendPageModel GetModel()
        {
            return new AddFriendPageModel { faculties = new List<int> {0,1}};
        }

        public static List<CRN> GetCRNs()
        {
            return new List<CRN>
            {
                new CRN {ID = 0, code = "24600",students = new List<int> { 0, 1, 2 }},
                new CRN {ID = 1, code = "24601",students = new List<int> { 3, 4, 5 }},
                new CRN {ID = 2, code = "24602",students = new List<int> { 6, 7 }},
                new CRN {ID = 3, code = "24603",students = new List<int> { 3, 1, 7 }},
                new CRN {ID = 4, code = "24604",students = new List<int> { 2, 1, 8 }},
                new CRN {ID = 5, code = "52478",students = new List<int> { 0, 5, 2, 4 }}
            };
        }

        public static List<Lecture> GetLectures()
        {
            return new List<Lecture>
            {
                new Lecture{ID = 0, name = "OOP",crns= new List<int> {0,1} },
                new Lecture{ID = 1, name = "DataBase",crns= new List<int> {2,3} },
                new Lecture{ID = 2, name = "İş Hukuku",crns= new List<int> {4} },
                new Lecture{ID = 3, name = "Elektroniğe Giriş",crns= new List<int> {5} }
            };
        }

        public static List<Department> GetDepartments()
        {
            return new List<Department>
            {
                new Department{ID = 0, name = "Bilgisayar Mühendisliği",lectures= new List<int> {0,1} },
                new Department{ID = 1, name = "Elektrik Elektronik Mühendisliği",lectures= new List<int> {3} },
                new Department{ID = 2, name = "Hukuk",lectures= new List<int> {2} }
            };
        }

        public static List<Faculty> GetFaculties()
        { return new List<Faculty> {
            new Faculty { ID = 0, name = "Mühendislik Fakültesi", departments = new List<int> { 0, 1 } },
            new Faculty { ID = 1, name = "Hukuk Fakültesi", departments = new List<int> { 2 } }
        }; }


        public static List<Student> GetStudents()
        {
             return new List<Student>
             {
                new Student {ID = 0, stud_name = "Beyza", stud_gender = 'K', stud_number = "12100"},
                new Student {ID = 1, stud_name = "İremsu", stud_gender = 'K', stud_number = "12000"},
                new Student {ID = 2, stud_name = "Sinan", stud_gender = 'E', stud_number = "12001"},
                new Student {ID = 3, stud_name = "Buğra", stud_gender = 'E', stud_number = "12002"},
                new Student {ID = 4, stud_name = "Mehmet", stud_gender = 'E', stud_number = "12003"},
                new Student {ID = 5, stud_name = "Buket", stud_gender = 'K', stud_number = "12004"},
                new Student {ID = 6, stud_name = "Murat", stud_gender = 'E', stud_number = "12005"},
                new Student {ID = 7, stud_name = "İlayda", stud_gender = 'K', stud_number = "12006"},
                new Student {ID = 8, stud_name = "Can", stud_gender = 'E', stud_number = "12007"},
                new Student {ID = 9, stud_name = "Burcu", stud_gender = 'K', stud_number = "12008"},
                new Student {ID = 10, stud_name = "Burak", stud_gender = 'E', stud_number = "12009"},
            };
            
        }



        public static List<Club> GetClubs()
        {
            return new List<Club>
            {
                new Club {ID = 0, name = "IEEE", students = new List<int> { 0,1,2 } },
                new Club {ID = 1, name = "ACM", students = new List<int> { 3,4,5,2 } },
                new Club {ID = 2, name = "Gastronomi", students = new List<int> { 6,7,8 } },
                new Club {ID = 3, name = "Dans", students = new List<int> { 1,9,10 } }
            };
        }
    }
}