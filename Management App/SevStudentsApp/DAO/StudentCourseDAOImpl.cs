using SevStudentsApp.DAO.DBUtil;
using SevStudentsApp.Models;
using System.Data.SqlClient;

namespace SevStudentsApp.DAO
{
    public class StudentCourseDAOImpl : IStudentCourseDAO
    {
        public StudentCourse? Delete(StudentCourse? studentCourse)
        {
            if (studentCourse == null) return null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();

                }
                else { return null; }

                string sql = "DELETE FROM STUDENTCOURSES WHERE STUDENTID = @sid AND COURSEID = @cid";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@sid", studentCourse.StudentId);
                command.Parameters.AddWithValue("@cid", studentCourse.CourseId);

                int rowsAffected = command.ExecuteNonQuery();
                return (rowsAffected > 0) ? studentCourse : null;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<StudentCourse> GetAll()
        {
            List<StudentCourse> studentCourses = new List<StudentCourse>();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM STUDENTCOURSES";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    StudentCourse studentCourse = new StudentCourse()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1)
                    };

                    studentCourses.Add(studentCourse);
                }

                return studentCourses;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Course> GetAllC()
        {
            List<Course> courses = new List<Course>();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM COURSES";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Course course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        TeacherId = reader.GetInt32(2)
                    };

                    courses.Add(course);
                }

                return courses;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public List<Student> GetAllS()
        {
            List<Student> students = new List<Student>();
            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM STUDENTS";

                using SqlCommand command = new SqlCommand(sql, conn);
                using SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Student student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                    students.Add(student);
                }

                return students;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Course? GetCourse(int id)
        {
            Course? course = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM COURSES WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    course = new Course()
                    {
                        Id = reader.GetInt32(0),
                        Description = reader.GetString(1),
                        TeacherId = reader.GetInt32(2)
                    };

                }

                return course;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public Student? GetStudent(int id)
        {
            Student? student = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM STUDENTS WHERE ID = @id";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@id", id);

                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    student = new Student()
                    {
                        Id = reader.GetInt32(0),
                        Firstname = reader.GetString(1),
                        Lastname = reader.GetString(2)
                    };

                }

                return student;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public StudentCourse? GetStudentCourse(int studentId, int courseId)
        {
            StudentCourse? studentCourse = null;

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();
                }

                string sql = "SELECT * FROM STUDENTS WHERE STUDENTID = @sid AND COURSEID = @cid";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@sid", studentId);
                command.Parameters.AddWithValue("@cid", studentId);


                using SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    studentCourse = new StudentCourse()
                    {
                        StudentId = reader.GetInt32(0),
                        CourseId = reader.GetInt32(1)
                    };

                }

                return studentCourse;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Insert(StudentCourse? studentCourse)
        {
            if (studentCourse == null) { return; }

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();

                }
                else { return; }

                string sql = "INSERT INTO STUDENTCOURSES " +
                    "(STUDENTID, COURSEID) VALUES " +
                    "(@sid, @cid)";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@sid", studentCourse.StudentId);
                command.Parameters.AddWithValue("@cid", studentCourse.CourseId);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }

        public void Update(StudentCourse? studentCourse)
        {
            if (studentCourse == null) { return; }

            try
            {
                using SqlConnection? conn = DBHelper.GetConnection();

                if (conn is not null)
                {
                    conn.Open();

                }
                else { return; }

                string sql = "UPDATE STUDENTCOURSES SET STUDENTID = @stuid, " +
                             "COURSEID = @couid WHERE STUDENTID = @sid AND COURSEID = @cid";

                using SqlCommand command = new SqlCommand(sql, conn);

                command.Parameters.AddWithValue("@stuid", studentCourse.StudentId);
                command.Parameters.AddWithValue("@teacherid", studentCourse.CourseId);
                command.Parameters.AddWithValue("@sid", studentCourse.StudentId);
                command.Parameters.AddWithValue("@cid", studentCourse.CourseId);

                command.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
        }
    }
}
