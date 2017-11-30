namespace Reservations
{
    using Hotel_Reservations.ws;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Web.Script.Serialization;

    public partial class Reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservation()
        {
            ReservedRooms = new HashSet<ReservedRoom>();
        }
        public int reservationId { get; set; }

        [Validators.NumberOfGuestsValidation]
        [Display(Name = "Number Of Guests")]
        public int numberOfGuests { get; set; }

        [Validators.NumberOfRoomsValidation]
        [Display(Name = "Number Of Rooms")]
        public int numberOfRooms { get; set; }

        [Display(Name = "Room Type")]
        public int roomType { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Check-In Date")]
        [DisplayFormat(DataFormatString = @"{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime checkin { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Check-Out Date")]
        [DisplayFormat(DataFormatString = @"{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Validators.ReservationDatesValidation]
        public DateTime checkout { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[^;:!@#$%\^*+?\\/<>1234567890]*$", ErrorMessage = @"First Name should not contain the following characters: ;:!@#$%^*+?\/<>1234567890")]
        public string firstName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[^;:!@#$%\^*+?\\/<>1234567890]*$", ErrorMessage = @"Last Name should not contain the following characters: ;:!@#$%^*+?\/<>1234567890")]
        public string lastName { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Street Number")]
        public string streetNumber { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Street Name")]
        public string streetName { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "City")]
        [RegularExpression(@"^[^;:!@#$%\^*+?\\/<>1234567890]*$", ErrorMessage = @"City should not contain the following characters: ;:!@#$%^*+?\/<>1234567890")]
        public string city { get; set; }

        //[Validators.RegionValidation] don't need it as we have a correct cascading list of regions!
        [Display(Name = "Province/State")]
        public int region { get; set; }

        [Display(Name = "Country")]
        public int country { get; set; }

        [Required]
        [Validators.PostalValidation]
        [Display(Name = "Zip/Postal Code")]
        public string postalCode { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-]?([0-9]{3})[-]?([0-9]{4})$", ErrorMessage = "Phone number is not valid")]
        public string phoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email Address")]
        public string emailAddress { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[^;:!@#$%\^*+?\\/<>1234567890]*$", ErrorMessage = @"Credit card holder's name should not contain the following characters: ;:!@#$%^*+?\/<>1234567890")]
        [Display(Name = "Name on the Card")]
        public string nameOnTheCard { get; set; }

        [Required]
        [StringLength(50)]
        [Validators.CreditCardValidation]
        [Display(Name = "Credit Card Number")]
        public string CreditCardnumber { get; set; }

        [Display(Name = "Credit Card Type")]
        public int CreditCardType { get; set; }

        [Column(TypeName = "date")]
        [Validators.CreditCardExpDateValidation]
        [Display(Name = "Expiration Date (MM/YYYY)")]
        [DisplayFormat(DataFormatString = @"{0:MM\/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreditCardExpDate { get; set; }

        [ScriptIgnore]
        public virtual Country Country1 { get; set; }

        [ScriptIgnore]
        public virtual CreditCardType CreditCardType1 { get; set; }

        [ScriptIgnore]
        public virtual Region Region1 { get; set; }

        [ScriptIgnore]
        public virtual RoomType RoomType1 { get; set; }

        [ScriptIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservedRoom> ReservedRooms { get; set; }

        [ScriptIgnore]
        [NotMapped]
        [Display(Name = "Room Numbers")]
        public string RoomNumbers
        {
            get
            {
                RoomWSClient ws = new RoomWSClient();
                var reservedRooms = this.ReservedRooms.Select(rr => rr.roomId).ToList();
                var roomNumbers = ws.GetAllRooms().Where(r => reservedRooms.Contains(r.roomId))
                    .Select(r => r.roomNumber)
                    .ToList();

                return String.Join(", ", roomNumbers); 
            }
        }

    }
}
