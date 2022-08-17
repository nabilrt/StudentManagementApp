using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Management.Models
{
    public class CourseModel
    {
        public string courseCode { get; set; }
        public string courseName { get; set; }
        public string courseCredit { get; set; }
        public string courseDept { get; set; }
        public string courseStatus { get; set; }
    }
}