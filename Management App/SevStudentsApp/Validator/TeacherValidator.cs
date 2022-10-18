using SevStudentsApp.DTO;

namespace SevStudentsApp.Validator
{
    public class TeacherValidator
    {

        private TeacherValidator() { }

        public static string Validate(TeacherDTO? dto)
        {
            if ((dto!.Firstname!.Length < 1) || (dto!.Lastname!.Length < 1))
            {
                return "Firstname or Lastname should not be less than one char";
            }

            return "";
        }
    }
}
