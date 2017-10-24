using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Reservations.Validators
{
    public class PostalValidation : ValidationAttribute
    {
        /*
         * get a Postal Code pattern for selected country from DB and check the zip/postal code against the pattern
        */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ModelReservations m = new ModelReservations();

            string zipPostal = value.ToString();
            int countryId = Convert.ToInt32(validationContext.ObjectType.GetProperty("country").GetValue(validationContext.ObjectInstance, null).ToString());
            var selectedCountry = m.Countries.Where(c => c.countryId == countryId).First();


            if (Regex.IsMatch(zipPostal, selectedCountry.postalPattern))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(String.Format("Postal Code is invalid. Please make sure that you entered a correct zip/postal code for {0}",
                              selectedCountry.country1));
            }

        }
    }
}