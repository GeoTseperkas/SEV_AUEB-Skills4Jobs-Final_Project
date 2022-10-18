using SevStudentsApp.DTO;
using SevStudentsApp.Models;

namespace SevStudentsApp.Service
{
    public interface ITeacherService
    {
        List<Teacher> GetAllTeachers();
        void InsertTeacher(TeacherDTO? dto);
        void UpdateTeacher(TeacherDTO? dto);
        Teacher? GetTeacher(int id);
        Teacher? DeleteTeacher(TeacherDTO? dto);
    }
}
