using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SevStudentsApp.DAO;
using SevStudentsApp.DTO;
using SevStudentsApp.Models;
using SevStudentsApp.Service;
using SevStudentsApp.Validator;
using System.Runtime.CompilerServices;

namespace SevStudentsApp.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly IStudentDAO studentDAO = new StudentDAOImpl();
        private readonly IStudentService service;

        public CreateModel()
        {
            service = new StudentServiceImpl(studentDAO);
        }

        internal StudentDTO studentDTO = new();
        public string errorMessage = "";

        public void OnGet()
        {

        }

        public void OnPost()
        {
            errorMessage = "";

            studentDTO.Firstname = Request.Form["firstname"];
            studentDTO.Lastname = Request.Form["lastname"];

            errorMessage = StudentValidator.Validate(studentDTO);

            if (!errorMessage.Equals("")) return;

            try
            {
                service.InsertStudent(studentDTO);
                Response.Redirect("/Students/Index");

            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return;
            }

        }

            private void ResetFields()
            {
                studentDTO.Firstname = "";
                studentDTO.Lastname = "";
            }
        
    }
}
