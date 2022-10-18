using SevStudentsApp.DTO;

namespace SevStudentsApp.Validator
{
    public class CourseValidator
    {

        private CourseValidator() { }

        public static string Validate(CourseDTO? dto)
        {
            if (dto!.Description!.Length < 1)
            {
                return "Description should not be less than one char";
            }

            return "";
        }
    }
}
