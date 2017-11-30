using Hotel_Reservations.ws;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Reservations.Validators
{
    public class CreditCardValidation : ValidationAttribute
    {
        /*
         * get a Regex pattern for selected credit card type from DB and check the entered credit card number against the pattern
         */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            string creditCardNumber = value.ToString();
            int cctId = Convert.ToInt32(validationContext.ObjectType.GetProperty("CreditCardType").GetValue(validationContext.ObjectInstance, null).ToString());

            var selectedCreditCardType = new CreditCardTypeWSClient().GetAllCreditCardTypes().Where(cct => cct.cctId == cctId).First();
            string cardNumberPattern = selectedCreditCardType.cardNumberPattern;

            if (Regex.IsMatch(creditCardNumber, cardNumberPattern))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(String.Format("Credit card number is invalid. Please make sure that you entered a valid {0} card number",
                              selectedCreditCardType.type));
            }

        }
    }
}