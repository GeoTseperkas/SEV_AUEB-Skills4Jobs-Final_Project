using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public class StudentCourseServiceImpl : IStudentCourseService
    {
        private readonly IStudentCourseDAO dao;

        public StudentCourseServiceImpl(IStudentCourseDAO dao)
        {
            this.dao = dao;
        }
        public StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto)
        {
            if (dto == null) return null;

            try
            {
                StudentCourse? studentCourse = ConvertStudentCourse(dto);
                return dao.Delete(studentCourse);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Course> GetAllCourses()
        {
            try
            {
                return dao.GetAllC();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Course>();
            }
        }

        public List<StudentCourse> GetAllStudentCourses()
        {
            try
            {
                return dao.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<StudentCourse>();
            }
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                return dao.GetAllS();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Student>();
            }
        }

        public Course? GetCourse(int id)
        {
            try
            {
                return dao.GetCourse(id);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public Student? GetStudent(int id)
        {
            try
            {
                return dao.GetStudent(id);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public StudentCourse? GetStudentCourse(int sid, int cid)
        {
            try
            {
                return dao.GetStudentCourse(sid, cid);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertStudentCourse(StudentCourseDTO? dto)
        {
            if (dto == null) return;

            try
            {
                StudentCourse? studentCourse = ConvertStudentCourse(dto);
                dao.Insert(studentCourse);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateStudentCourse(StudentCourseDTO? dto)
        {
            if (dto == null) return;

            try
            {
                StudentCourse? studentCourse = ConvertStudentCourse(dto);
                dao.Update(studentCourse);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private StudentCourse? ConvertStudentCourse(StudentCourseDTO dto)
        {
            if (dto == null) return null;

            return new StudentCourse()
            {
                StudentId = dto.StudentId,
                CourseId = dto.CourseId
            };
        }
    }
}
