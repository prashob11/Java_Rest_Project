using Hotel_Reservations.ws;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reservations.Validators
{
    public class NumberOfGuestsValidation : ValidationAttribute
    {
        private IEnumerable<Room> rooms;
        private IEnumerable<RoomType> roomTypes;

        /*
         * check if number of guests does not exceed hotel capacity for the selected room type
         */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //ModelReservations m = new ModelReservations();
            if(this.rooms == null)
            {
                this.rooms = new RoomWSClient().GetAllRooms();
            }

            if (this.roomTypes == null)
            {
                this.roomTypes = new RoomTypesWsClient().GetAllRoomTypes();
            }

            int numberOfGuests = Convert.ToInt32(value.ToString());
            if (numberOfGuests < 1)
            {
                return new ValidationResult("At least 1 guest should be selected");
            }

            int roomTypeSelected = Convert.ToInt32(validationContext.ObjectType.GetProperty("roomType").GetValue(validationContext.ObjectInstance, null).ToString());

            var rooms = from r in this.rooms
                        join rt in this.roomTypes on r.type equals rt.rtId
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
                    ". We can accomodate only up to {2} guests in the seleted room types", 
                    numberOfGuests, this.roomTypes.Where(rt => rt.rtId == roomTypeSelected).First().roomType1, maxGuests));
            }

        }
    }
}