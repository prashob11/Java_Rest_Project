using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reservations.Validators
{
    public class RegionValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ModelReservations m = new ModelReservations();

            int regionId = Convert.ToInt32(value.ToString());
            int countryId = Convert.ToInt32(validationContext.ObjectType.GetProperty("country").GetValue(validationContext.ObjectInstance, null).ToString());

            string selectedRegion = m.Regions.Where(r => r.regionId == regionId).First().region1;
            string selectedCountry = m.Countries.Where(c => c.countryId == countryId).First().country1;

            if (m.Regions.Where(e => e.regionId == regionId).First().country == countryId)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(String.Format("Region {0} is not in {1}. Please select a valid Country and Region",
                              selectedRegion, selectedCountry));
            }

        }
    }
}