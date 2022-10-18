using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Courses
{
    public class CreateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService? service;

        internal List<Teacher> teachers = new();
        public CreateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDTO= new();
        public string errorMessage = "";

        public void OnGet()
        {
            try
            {

            }
            catch (Exception e)
            {

            }
            teachers = service!.GetAllTeachers();

        }

        public void OnPost()
        {
            errorMessage = "";
            teachers = service!.GetAllTeachers();

            courseDTO.Description = Request.Form["description"];
            courseDTO.TeacherId = int.Parse(Request.Form["teacherid"]);

            errorMessage = CourseValidator.Validate(courseDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service!.InsertCourse(courseDTO);
                Response.Redirect("/Courses/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }

        }

        private void ResetFields()
        {
            courseDTO.Description = "";
        }
    }
}
