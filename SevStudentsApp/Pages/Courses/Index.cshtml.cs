using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService? service;

        internal List<Course> courses = new();
        internal List<Teacher> teachers = new();
        public IndexModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }
        public IActionResult OnGet()
        {
            try
            {

            }
            catch (Exception e)
            {

            }
            courses = service!.GetAllCourses();
            teachers = service!.GetAllTeachers();
            return Page();
        }
    }
}
