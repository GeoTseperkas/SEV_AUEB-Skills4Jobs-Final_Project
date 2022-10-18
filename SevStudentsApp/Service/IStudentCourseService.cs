using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface IStudentCourseService
    {
        List<StudentCourse> GetAllStudentCourses();
        void InsertStudentCourse(StudentCourseDTO? dto);
        void UpdateStudentCourse(StudentCourseDTO? dto);
        StudentCourse? GetStudentCourse(int sid, int cid);
        StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto);
        List<Course> GetAllCourses();
        Course? GetCourse(int id);
        List<Student> GetAllStudents();
        Student? GetStudent(int id);
    }
}
