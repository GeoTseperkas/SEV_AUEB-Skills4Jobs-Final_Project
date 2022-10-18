using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface ICourseService
    {
        List<Course> GetAllCourses();
        void InsertCourse(CourseDTO? dto);
        void UpdateCourse(CourseDTO? dto);
        Course? GetCourse(int id);
        Course? DeleteCourse(CourseDTO? dto);
        Teacher? GetTeacher(int id);
        List<Teacher> GetAllTeachers();
    }
}
