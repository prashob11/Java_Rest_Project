using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Reservations.Validators
{
    public class ReservationDatesValidation : ValidationAttribute
    {
        /*
        * check if:
        * 1) checkout date is after checkin date
        * 2) there are rooms available on that dates
        */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ModelReservations m = new ModelReservations();
            int numberOfRoomsSelected = Convert.ToInt32(validationContext.ObjectType.GetProperty("numberOfRooms").GetValue(validationContext.ObjectInstance, null).ToString());
            int roomTypeSelected = Convert.ToInt32(validationContext.ObjectType.GetProperty("roomType").GetValue(validationContext.ObjectInstance, null).ToString());
            string roomType = m.RoomTypes.Where(rt => rt.rtId == roomTypeSelected).First().roomType1;
            DateTime checkinSelected = (DateTime)validationContext.ObjectType.GetProperty("checkin").GetValue(validationContext.ObjectInstance, null);
            DateTime checkoutSelected = (DateTime)validationContext.ObjectType.GetProperty("checkout").GetValue(validationContext.ObjectInstance, null);
            int reservationId = (int)validationContext.ObjectType.GetProperty("reservationId").GetValue(validationContext.ObjectInstance, null);


            //if (checkinSelected < DateTime.Now || checkoutSelected < DateTime.Now)
            //{
            //    return new ValidationResult("Check in and check out dates cannot be in the past");
            //}

            if (checkinSelected > checkoutSelected)
            {
                return new ValidationResult("Checkout date should be after checkin date");
            }

            int roomsAvailableCount =  GetAvailableRooms(m, checkinSelected, checkoutSelected, roomTypeSelected, reservationId).Count;
            

            if (roomsAvailableCount == 0)
            {
                return new ValidationResult(String.Format("There are no {0} rooms available for these dates", roomType));
            }

            if (roomsAvailableCount < numberOfRoomsSelected)
            {
                return new ValidationResult(String.Format("There are only {0} {1} rooms available for these dates", roomsAvailableCount, roomType));
            }

            
            return ValidationResult.Success;


        }

        public static List<int> GetAvailableRooms(ModelReservations db, DateTime checkin, DateTime checkout, int roomType, int reservationId)
        {
            //select rooms that are not available
            var reservedRooms = from rsv in db.Reservations
                                join rr in db.ReservedRooms on rsv.reservationId equals rr.reservationId
                                where rsv.checkin <= checkout && rsv.checkout >= checkin
                                && rsv.roomType == roomType
                                && rsv.reservationId != reservationId
                                select new { rr.roomId };

            //select rooms that are available
            return db.Rooms.Where(room => room.type == roomType)
                .Select(room => room.roomId).Except(reservedRooms.Select(rr => rr.roomId)).ToList();

        }

    }
}