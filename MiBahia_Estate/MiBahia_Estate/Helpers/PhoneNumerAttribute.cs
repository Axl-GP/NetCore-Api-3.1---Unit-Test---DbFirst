using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MiBahia_Estate.Helpers
{
    public class PhoneNumerAttribute:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value== null)
            {
                return ValidationResult.Success;
            }
             if (!(value.ToString().Length < 11 && value.ToString().Length > 9))
            {
                return new ValidationResult("debe incluir los 10 digitos que componen el telefono");
            }
            return ValidationResult.Success;

        }
    }
}
