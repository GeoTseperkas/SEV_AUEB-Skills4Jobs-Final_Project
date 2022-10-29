using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface ITeacherService
    {
        /// <summary>
        /// Returns a list containing all the specified objects from the database
        /// </summary>
        List<Teacher> GetAllTeachers();

        /// <summary>
        /// Inserts a new specified object to the database
        /// </summary>
        void InsertTeacher(TeacherDTO? dto);

        /// <summary>
        /// Updates the values of an already existing object from the database
        /// </summary>
        void UpdateTeacher(TeacherDTO? dto);

        /// <summary>
        /// Returns one specific object from the database
        /// </summary>
        Teacher? GetTeacher(int id);

        /// <summary>
        /// Deletes an already existing object from the database
        /// </summary>
        Teacher? DeleteTeacher(TeacherDTO? dto);
    }
}
