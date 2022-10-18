using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public class CourseServiceImpl : ICourseService
    {
        private readonly ICourseDAO dao;

        public CourseServiceImpl(ICourseDAO dao)
        {
            this.dao = dao;
        }
        public Course? DeleteCourse(CourseDTO? dto)
        {
            if (dto == null) return null;

            try
            {
                Course? course = ConvertCourse(dto);
                return dao.Delete(course);

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
                return dao.GetAll();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Course>();
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            try
            {
                return dao.GetAllT();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new List<Teacher>();
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

        public Teacher? GetTeacher(int id)
        {
            try
            {
                return dao.GetTeacher(id);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void InsertCourse(CourseDTO? dto)
        {
            if (dto == null) return;

            try
            {
                Course? course = ConvertCourse(dto);
                dao.Insert(course);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void UpdateCourse(CourseDTO? dto)
        {
            if (dto == null) return;

            try
            {
                Course? course = ConvertCourse(dto);
                dao.Update(course);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        private Course? ConvertCourse(CourseDTO dto)
        {
            if (dto == null) return null;

            return new Course()
            {
                Id = dto.Id,
                Description = dto.Description,
                TeacherId = dto.TeacherId
            };
        }
    }
}
