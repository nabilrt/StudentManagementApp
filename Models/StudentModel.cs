using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Management.Models
{
    public class StudentModel
    {
        public string studentID { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string studentName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string studentEmail { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string studentPass { get; set; }
        [Required(ErrorMessage = "Date of Birth is Required")]
        public string studentDOB { get; set; }
    }
}