using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using static System.Net.Mime.MediaTypeNames;
using WebGrease.Css.Ast.Selectors;

namespace Student_Management.Models
{
    public class StudentOperations
    {
        string cs = ConfigurationManager.ConnectionStrings["sdb"].ConnectionString;
        SqlConnection con;
        int count;
        public bool AddStudent(StudentModel student)
        {
            con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("Insert into Student Values(@studentID,@studentName,@studentEmail,@studentPass,@studentDOB)", con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@studentID", generateID());
            cmd.Parameters.AddWithValue("@studentName", student.studentName);
            cmd.Parameters.AddWithValue("@studentEmail", student.studentEmail);
            cmd.Parameters.AddWithValue("@studentPass", student.studentPass);
            cmd.Parameters.AddWithValue("@studentDOB", student.studentDOB);
            con.Open();
            int a=cmd.ExecuteNonQuery();
            con.Close();
            if (a > 0)
            {
                return true;
            }

            return false;
        }

        public string generateID()
        {
            SqlConnection c = new SqlConnection(cs);
            string query = "Select count(*) from Student";
            SqlCommand cmd = new SqlCommand(query, c);
            c.Open();
            count = Convert.ToInt32(cmd.ExecuteScalar()) + 1;
            c.Close();
            return "AIUB-STD-" + count;

        }

        public bool loginCheck(StudentModel student)
        {
            SqlConnection c = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("select * from Student where studentID=@studentID and studentPass=@studentPass", c);
            cmd.Parameters.AddWithValue("@studentID", student.studentID);
            cmd.Parameters.AddWithValue("@studentPass", student.studentPass);
            c.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                return true;
            }

            return false;

        }

        public StudentModel getStudentDetails(string id)
        {
            StudentModel student = new StudentModel();
            SqlConnection c = new SqlConnection(cs);
            c.Open();
            SqlCommand cmd = new SqlCommand("select * from Student where studentID=@studentID", c);
            cmd.Parameters.AddWithValue("@studentID", id);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows == true)
            {
                while (dr.Read())
                {
                    student.studentID= Convert.ToString(dr.GetValue(0));
                    student.studentName= Convert.ToString(dr.GetValue(1));
                    student.studentEmail= Convert.ToString(dr.GetValue(2));
                    student.studentPass= Convert.ToString(dr.GetValue(3));
                    student.studentDOB=Convert.ToString(dr.GetValue(4));
                }
                dr.Close();
            }
            c.Close();

            return student;

        }
    }
}