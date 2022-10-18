using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;

namespace SevStudentsApp.Pages.StudentCourses
{
    public class DeleteModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService? service;

        internal List<Course> courses = new List<Course>();
        internal List<Student> students = new List<Student>();
        public DeleteModel()
        {
            service = new StudentCourseServiceImpl(studentCourseDAO);
        }

        internal StudentCourseDTO studentCourseDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {

            try
            {
                StudentCourse? studentCourse;

                int id = int.Parse(Request.Query["id"]);
                int id1 = int.Parse(Request.Query["id1"]);
                studentCourseDTO.StudentId = id;
                studentCourseDTO.CourseId = id1;

                studentCourse = service!.DeleteStudentCourse(studentCourseDTO);
                Response.Redirect("/StudentCourses/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }


    }
}
