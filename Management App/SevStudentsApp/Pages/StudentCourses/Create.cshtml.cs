using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.StudentCourses
{
    public class CreateModel : PageModel
    {
        private readonly IStudentCourseDAO studentCourseDAO = new StudentCourseDAOImpl();
        private readonly IStudentCourseService? service;

        internal List<Course> courses = new List<Course>();
        internal List<Student> students = new List<Student>();
        public CreateModel()
        {
            service = new StudentCourseServiceImpl(studentCourseDAO);
        }

        internal StudentCourseDTO studentCourseDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {
            try
            {
                students = service!.GetAllStudents();
                courses = service!.GetAllCourses();
            }
            catch (Exception e)
            {

            }

        }

        public void OnPost()
        {
            students = service!.GetAllStudents();
            courses = service!.GetAllCourses();
            errorMessage = "";

            try
            {

                studentCourseDTO.StudentId = int.Parse(Request.Form["studentid"]);
                studentCourseDTO.CourseId = int.Parse(Request.Form["courseid"]);

                service!.InsertStudentCourse(studentCourseDTO);
                Response.Redirect("/StudentCourses/Index");

            }
            catch (Exception e)
            {
                errorMessage = "Wrong Input - Student is already enrolled to the specific Course"; //System.Data.SqlClient.SqlException
                return;
            }
        }
    }
}
