using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface ICourseService
    {
        /// <summary>
        /// Returns a list containing all the specified objects from the database
        /// </summary>
        List<Course> GetAllCourses();

        /// <summary>
        /// Inserts a new specified object to the database
        /// </summary>
        void InsertCourse(CourseDTO? dto);

        /// <summary>
        /// Updates the values of an already existing object from the database
        /// </summary>
        void UpdateCourse(CourseDTO? dto);

        /// <summary>
        /// Returns one specific object from the database
        /// </summary>
        Course? GetCourse(int id);

        /// <summary>
        /// Deletes an already existing object from the database
        /// </summary>
        Course? DeleteCourse(CourseDTO? dto);

        /// <summary>
        /// Returns one specific object from the database
        /// </summary>
        Teacher? GetTeacher(int id);

        /// <summary>
        /// Returns a list containing all the specified objects from the database
        /// </summary>
        List<Teacher> GetAllTeachers();
    }
}
