using Hotel_Reservations.ws;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reservations.Validators
{
    public class NumberOfRoomsValidation : ValidationAttribute
    {

        private IEnumerable<Room> rooms;
        private IEnumerable<RoomType> roomTypes;
        /*
         * check if:
         * 1) selected number of rooms does not exceed max number of rooms of the selected room type available in the hotel
         * 2) selectd number of guests can be accomodated in the selected number of rooms
         */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //ModelReservations m = new ModelReservations();

            if (this.rooms == null)
            {
                this.rooms = new RoomWSClient().GetAllRooms();
            }

            if (this.roomTypes == null)
            {
                this.roomTypes = new RoomTypesWsClient().GetAllRoomTypes();
            }

            int numberOfRoomsSelected = Convert.ToInt32(value.ToString());
            if (numberOfRoomsSelected < 1)
            {
                return new ValidationResult("At least 1 room should be selected");
            }
            int roomTypeSelected = Convert.ToInt32(validationContext.ObjectType.GetProperty("roomType").GetValue(validationContext.ObjectInstance, null).ToString());
            int numberOfGuestsSelected = Convert.ToInt32(validationContext.ObjectType.GetProperty("numberOfGuests").GetValue(validationContext.ObjectInstance, null).ToString());

            var roomsCount = this.rooms.Where(room => room.type == roomTypeSelected).Count();
            int maxGuests = numberOfRoomsSelected * this.roomTypes.Where(rt => rt.rtId == roomTypeSelected).First().maxGuests;
            string roomType = this.roomTypes.Where(rt => rt.rtId == roomTypeSelected).First().roomType1;


            if (numberOfRoomsSelected > roomsCount)
            {
                return new ValidationResult(String.Format("There are only {0} {1} rooms available in our hotel", roomsCount, roomType));
            }

            if (numberOfGuestsSelected > maxGuests)
            {
                return new ValidationResult(String.Format("It's impossible to accomodate {0} guests in {1} {2} rooms. Please select more rooms", 
                    numberOfGuestsSelected, numberOfRoomsSelected, roomType));
            }

            return ValidationResult.Success;
                        

        }
    }
}