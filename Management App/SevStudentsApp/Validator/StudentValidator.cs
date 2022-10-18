using SevStudentsApp.DTO;

namespace SevStudentsApp.Validator
{
    public class StudentValidator
    {
        // no instances should be available
        private StudentValidator() { }

        public static string Validate(StudentDTO? dto)
        {
            if ((dto!.Firstname!.Length < 1) || (dto!.Lastname!.Length < 1))
            {
                return "Firstname or Lastname should not be less than one char";
            }

            return "";
        }
    }
}
