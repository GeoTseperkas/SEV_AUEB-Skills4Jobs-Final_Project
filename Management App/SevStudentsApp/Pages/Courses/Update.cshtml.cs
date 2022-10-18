using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Courses
{
    public class UpdateModel : PageModel
    {
        private readonly ICourseDAO courseDAO = new CourseDAOImpl();
        private readonly ICourseService? service;

        internal List<Teacher> teachers = new();
        public UpdateModel()
        {
            service = new CourseServiceImpl(courseDAO);
        }

        internal CourseDTO courseDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {
            errorMessage = "";

            try
            {
                Course? course;

                int id = int.Parse(Request.Query["id"]);
                course = service!.GetCourse(id);
                if (course != null)
                {
                    courseDTO = ConvertToDTO(course);
                }
                teachers = service!.GetAllTeachers();
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            errorMessage = "";
            teachers = service!.GetAllTeachers();

            courseDTO.Id = int.Parse(Request.Form["id"]);
            courseDTO.Description = Request.Form["description"];
            courseDTO.TeacherId = int.Parse(Request.Form["teacherid"]);

            errorMessage = CourseValidator.Validate(courseDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service!.UpdateCourse(courseDTO);
                Response.Redirect("/Courses/Index");
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private CourseDTO ConvertToDTO(Course dto)
        {
            return new CourseDTO()
            {
                Id = dto.Id,
                Description = dto.Description!.Trim()
            };
        }
    }
}
