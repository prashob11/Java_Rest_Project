using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Reservations.Validators
{
    public class CreditCardExpDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("The date is invalid");
            }
            DateTime expdate = (DateTime)value;

            if (expdate < DateTime.Today)
            {
                return new ValidationResult("The card is expired");
            }

            if (expdate.Year > 2031 || expdate.Year < 2017)
            {
                return new ValidationResult("Year should be between 2017 and 2031");
            }

            return ValidationResult.Success;
        }
    }
}