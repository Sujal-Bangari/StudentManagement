using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Net.Configuration;

namespace StudentLibrary
{
    public class StudentRepository
    {
        private readonly string conns = "Server=WIN2019;Database=StudentDB;Trusted_Connection=True;";
        public void AddStudent(Student student)
        {
            using (SqlConnection sq = new SqlConnection(conns))
            {
                string query = "INSERT INTO Students(Name, Age,Email)VALUES(@Name,@Age,@Email);";
                SqlCommand cmd = new SqlCommand(query, sq);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                sq.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection sq = new SqlConnection(conns))
            {
                string query = "SELECT * FROM Students";
                SqlCommand cmd = new SqlCommand(query, sq);
                sq.Open();
                SqlDataReader sd = cmd.ExecuteReader();
                while (sd.Read())
                {
                    students.Add(new Student
                    {
                        Id = Convert.ToInt32(sd["Id"]),
                        Name = sd["Name"].ToString(),
                        Age = Convert.ToInt32(sd["Age"]),
                        Email = sd["Email"].ToString()
                    });
                }

            }
            return students;
        }
        public void UpdateStudent(Student student)
        {
            using (SqlConnection sq = new SqlConnection(conns))
            {
                string query = "UPDATE Students SET Name=@Name, Age=@Age, Email=@Email WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, sq);
                cmd.Parameters.AddWithValue("@Id", student.Id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                sq.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteStudent(int id)
        {
            using (SqlConnection conn = new SqlConnection(conns))
            {
                string Query = "DELETE FROM Students WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(Query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
