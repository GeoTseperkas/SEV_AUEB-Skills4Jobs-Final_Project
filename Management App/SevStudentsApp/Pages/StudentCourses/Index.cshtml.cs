using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.StudentCourses
{
    public class IndexModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService? service;

        internal List<Course> courses = new();
        internal List<Student> students = new();
        internal List<StudentCourse> studentCourses = new();
        public IndexModel()
        {
            service = new StudentCourseServiceImpl(studentCourseDAO);
        }
        public IActionResult OnGet()
        {
            try
            {
                courses = service!.GetAllCourses();
                students = service!.GetAllStudents();
                studentCourses = service!.GetAllStudentCourses();
            }
            catch (Exception e)
            {

            }
            return Page();
        }
    }
}
