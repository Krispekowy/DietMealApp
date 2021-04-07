using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietMealApp.Core.Validators
{
    public class PhoneNumberValidator: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var allowedChars = "+1234567890 ";
            if (value == null)
            {
                return new ValidationResult("Podaj swój numer telefonu");
            }
            if (String.IsNullOrEmpty(value.ToString()))
            {
                return new ValidationResult("Podaj swój numer telefonu");
            }
            if (value.ToString().Any(c => !allowedChars.Contains(c)))
            {
                return new ValidationResult("Podany numer telefonu zawiera nieodpowiednie znaki");
            }
            if (value.ToString().Length < 9)
            {
                return new ValidationResult("Podany numer telefonu jest za krótki");
            }
            if (value.ToString().Length > 12)
            {
                return new ValidationResult("Podany numer telefonu jest za długi");
            }
            return ValidationResult.Success;
        }
    }
}
