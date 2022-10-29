using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface IStudentService
    {
        /// <summary>
        /// Returns a list containing all the specified objects from the database
        /// </summary>
        List<Student> GetAllStudents();

        /// <summary>
        /// Inserts a new specified object to the database
        /// </summary>
        void InsertStudent(StudentDTO? dto);

        /// <summary>
        /// Updates the values of an already existing object from the database
        /// </summary>
        void UpdateStudent(StudentDTO? dto);

        /// <summary>
        /// Returns one specific object from the database
        /// </summary>
        Student? GetStudent(int id);

        /// <summary>
        /// Deletes an already existing object from the database
        /// </summary>
        Student? DeleteStudent(StudentDTO? dto);


    }
}
