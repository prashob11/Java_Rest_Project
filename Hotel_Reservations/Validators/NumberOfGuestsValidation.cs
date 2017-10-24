using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reservations.Validators
{
    public class NumberOfGuestsValidation : ValidationAttribute
    {
        /*
         * check if number of guests does not exceed hotel capacity for the selected room type
         */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ModelReservations m = new ModelReservations();

            int numberOfGuests = Convert.ToInt32(value.ToString());
            int roomTypeSelected = Convert.ToInt32(validationContext.ObjectType.GetProperty("roomType").GetValue(validationContext.ObjectInstance, null).ToString());

            var rooms = from r in m.Rooms
                        join rt in m.RoomTypes on r.type equals rt.rtId
                        where rt.rtId == roomTypeSelected
                        select new { maxGuests = rt.maxGuests };

            int maxGuests = rooms.Sum(r => r.maxGuests);
            
            if (numberOfGuests <= maxGuests)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(String.Format("Sorry, our hotel cannot accomodate {0} guests in {1} rooms" +
                    ". We can accomodate up to {2} guests in the seleted room types only", 
                    numberOfGuests, m.RoomTypes.Where(rt => rt.rtId == roomTypeSelected).First().roomType1, maxGuests));
            }

        }
    }
}