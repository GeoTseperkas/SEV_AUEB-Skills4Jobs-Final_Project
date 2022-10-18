using SevStudentsApp.Models;

namespace SevStudentsApp.DAO
{
    public interface IStudentCourseDAO
    {
        void Insert(StudentCourse? studentCourse);
        void Update(StudentCourse? studentCourse);
        StudentCourse? Delete(StudentCourse? studentCourse);
        StudentCourse? GetStudentCourse (int studentId, int courseId);
        List<StudentCourse> GetAll();
        Student? GetStudent(int id);
        List<Student> GetAllS();
        Course? GetCourse(int id);
        List<Course> GetAllC();
    }
}
