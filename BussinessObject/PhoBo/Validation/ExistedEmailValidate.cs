using BussinessObject.PhoBo.Data;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;

namespace BussinessObject.PhoBo.Validation
{
    public class ExistedEmailValidate : ValidationAttribute
    {
        public ExistedEmailValidate()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Debug.WriteLine($"{value} {validationContext}");
            var email = value as string;
            PhoBoContext _context = (PhoBoContext) validationContext
                         .GetService(typeof(PhoBoContext));
            if (_context.User.FirstOrDefault(u => u.Email == email) != null) return new ValidationResult(GetErrorMessage());

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Email existed";
        }
    }
}
