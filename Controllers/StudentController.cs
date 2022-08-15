using Student_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View("Registration");
        }

        [HttpPost]
        public ActionResult createStudent()
        {
                string name = Request["name"];
                string email = Request["mail"];
                string pass = Request["pass"];
                string dob = Request["dob"].ToString();
                StudentOperations studentOperations = new StudentOperations();
                StudentModel studentModel = new StudentModel() { studentName=name, studentEmail=email,studentPass=pass, studentDOB=dob};
                if (studentOperations.AddStudent(studentModel))
                {
                    return View("Confirmation");
                }
                return Content("Error");

        }

        public ActionResult login()
        {
            return View("Login");
        }

        [HttpPost]
        public ActionResult studentLogin()
        {
            string id = Request["id"];
            string pass = Request["pass"];
            StudentOperations studentOperations = new StudentOperations();
            StudentModel studentModel = new StudentModel() { studentID = id, studentPass = pass };
            if (studentOperations.loginCheck(studentModel))
            {
                Session["studentID"] = id;
                return RedirectToAction("dashboard");
            }

            return Content("Wrong ID or Password");
        }

        public ActionResult dashboard()
        {
            StudentModel studentModel = new StudentModel();
            StudentOperations studentOperations = new StudentOperations();
            if (Session["studentID"] != null)
            {
                string name = Session["studentID"].ToString();
                studentModel = studentOperations.getStudentDetails(name);
                return View("Dashboard", studentModel);
            }

            return RedirectToAction("login");


        }

        public ActionResult logout()
        {
            Session.Abandon();
            return View("Login");
        }

       
    }
}