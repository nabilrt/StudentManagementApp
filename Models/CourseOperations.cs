using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Student_Management.Models
{
    public class CourseOperations
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        SqlConnection con;

        public List<CourseModel> getCourses()
        {
            List<CourseModel> courses = new List<CourseModel>();
            con= new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("select * from Course where courseStatus=@courseStatus", con);
            cmd.Parameters.AddWithValue("@courseStatus", "Available");
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                courses.Add(
                    new CourseModel
                    {
                        courseCode = Convert.ToString(dr["courseCode"]),
                        courseName = Convert.ToString(dr["courseName"]),
                        courseCredit = Convert.ToString(dr["courseCredit"]),
                        courseDept = Convert.ToString(dr["courseDept"]),
                        courseStatus = Convert.ToString(dr["courseStatus"])
                    });
            }
            return courses;

        }

        public CourseModel getCourse(string id)
        {
            CourseModel course = new CourseModel();
            con=new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Course where courseCode=@courseCode", con);
            cmd.Parameters.AddWithValue("@courseCode", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    course.courseCode = Convert.ToString(dr.GetValue(0));
                    course.courseName = Convert.ToString(dr.GetValue(1));
                    course.courseCredit = Convert.ToString(dr.GetValue(2));
                    course.courseDept = Convert.ToString(dr.GetValue(3));
                    course.courseStatus = Convert.ToString(dr.GetValue(4));
                }
                dr.Close();
            }
            con.Close();

            return course;

        }

        public bool EnrollLearner(StudentModel student,CourseModel course)
        {
            con= new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into EnrollmentDetails Values(@studentID,@courseID)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@studentID", student.studentID);
            cmd.Parameters.AddWithValue("@courseID", course.courseCode);
            int a = cmd.ExecuteNonQuery();
            if (a > 0)
            {
                return true;
            }
            return false;
        }

        public List<EnrollmentDetailsModel> getAllEnrollments(string id)
        {
            List<EnrollmentDetailsModel> enrollments = new List<EnrollmentDetailsModel>();
            con= new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from EnrollmentDetails where studentID=@studentID", con)
            {
                CommandType = CommandType.Text
            };
            cmd.Parameters.AddWithValue("@studentID", id);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                enrollments.Add(
                    new EnrollmentDetailsModel
                    {
                        courseCode = Convert.ToString(dr["courseCode"]),
                        studentID = Convert.ToString(dr["studentID"])

                    });
            }
            return enrollments;
        }
    }
}