using Student_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Management.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        public ActionResult Index()
        {
            CourseOperations courseOperations = new CourseOperations();
            List<CourseModel> allCourses = new List<CourseModel>();
            allCourses = courseOperations.getCourses();
            return View("AllCourses",allCourses);
        }
        [HttpGet]
        public ActionResult Enroll()
        {
            string code = Request["code"];
            CourseOperations courseOps = new CourseOperations();
            CourseModel course = new CourseModel();
            course=courseOps.getCourse(code);

            return View("CourseInfo", course); 

        }

        [HttpPost]
        public ActionResult EnrollStudent()
        {
            CourseOperations courseOps = new CourseOperations();
            CourseModel course = new CourseModel();
            string code = Request["code"];
            course = courseOps.getCourse(code);
            StudentOperations operations = new StudentOperations();
            StudentModel student = new StudentModel();
            student = operations.getStudentDetails(Session["studentID"].ToString());
            if (courseOps.EnrollLearner(student, course))
            {
                return RedirectToAction("EnrolledCourses");
            }

            return Content("Unable to Enroll");
            
        }

        public ActionResult EnrolledCourses()
        {
            CourseOperations operations = new CourseOperations();
            List<EnrollmentDetailsModel> enrollments = new List<EnrollmentDetailsModel>();
            enrollments = operations.getAllEnrollments(Session["studentID"].ToString());
            return View("EnrolledCoursesLearner", enrollments);
        }

    }
}