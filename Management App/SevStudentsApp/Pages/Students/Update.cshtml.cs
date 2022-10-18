using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;

namespace SevStudentsApp.Pages.Students
{
    public class UpdateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        public UpdateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        internal string errorMessage = "";


        public void OnGet()
        {
            errorMessage = "";

            try
            {
                Student? student;

                int id = int.Parse(Request.Query["id"]);
                student = service.GetStudent(id);
                if (student != null)
                {
                    studentDTO = ConvertToDTO(student);
                }
            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        public void OnPost()
        {
            errorMessage = "";

            studentDTO.Id = int.Parse(Request.Form["id"]);
            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            errorMessage = StudentValidator.Validate(studentDTO);

            if (!errorMessage.Equals(""))  return; 

            try
            {
                service.UpdateStudent(studentDTO);
                Response.Redirect("/Students/Index");
            } catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }
        }

        private StudentDTO ConvertToDTO(Student dto)
        {
            return new StudentDTO()
            {
                Id = dto.Id,
                Firstname = dto.Firstname!.Trim(),
                Lastname = dto.Lastname!.Trim()
            };
        }
    }
}
