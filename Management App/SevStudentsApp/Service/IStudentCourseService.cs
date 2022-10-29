using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface IStudentCourseService
    {
        /// <summary>
        /// Returns a list containing all the specified objects from the database
        /// </summary>
        List<StudentCourse> GetAllStudentCourses();

        /// <summary>
        /// Inserts a new specified object to the database
        /// </summary>
        void InsertStudentCourse(StudentCourseDTO? dto);

        /// <summary>
        /// Updates the values of an already existing object from the database
        /// </summary>
        void UpdateStudentCourse(StudentCourseDTO? dto);

        /// <summary>
        /// Returns one specific object from the database
        /// </summary>
        StudentCourse? GetStudentCourse(int sid, int cid);

        /// <summary>
        /// Deletes an already existing object from the database
        /// </summary>
        StudentCourse? DeleteStudentCourse(StudentCourseDTO? dto);

        /// <summary>
        /// Returns a list containing all the specified objects from the database
        /// </summary>
        List<Course> GetAllCourses();

        /// <summary>
        /// Returns one specific object from the database
        /// </summary>
        Course? GetCourse(int id);

        /// <summary>
        /// Returns a list containing all the specified objects from the database
        /// </summary>
        List<Student> GetAllStudents();

        /// <summary>
        /// Returns one specific object from the database
        /// </summary>
        Student? GetStudent(int id);
    }
}
