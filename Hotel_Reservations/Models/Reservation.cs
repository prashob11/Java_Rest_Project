namespace Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reservation()
        {
            ReservedRooms = new HashSet<ReservedRoom>();
        }

        public int reservationId { get; set; }

        public int numberOfGuests { get; set; }

        public int numberOfRooms { get; set; }

        public int roomType { get; set; }

        [Column(TypeName = "date")]
        public DateTime checkin { get; set; }

        [Column(TypeName = "date")]
        public DateTime checkout { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[^;:!@#$%\^*+?\\/<>1234567890]*$", ErrorMessage = @"First Name should not contain the following characters: ;:!@#$%^*+?\/<>1234567890")]
        public string firstName { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[^;:!@#$%\^*+?\\/<>1234567890]*$", ErrorMessage = @"Last Name should not contain the following characters: ;:!@#$%^*+?\/<>1234567890")]
        public string lastName { get; set; }

        [Required]
        [StringLength(10)]
        public string streetNumber { get; set; }

        [Required]
        [StringLength(255)]
        public string streetName { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression(@"^[^;:!@#$%\^*+?\\/<>1234567890]*$", ErrorMessage = @"City should not contain the following characters: ;:!@#$%^*+?\/<>1234567890")]
        public string city { get; set; }

        [Validators.RegionValidation]
        public int region { get; set; }

        public int country { get; set; }

        [Required]
        [Validators.PostalValidation]
        public string postalCode { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-]?([0-9]{3})[-]?([0-9]{4})$", ErrorMessage = "Phone number is not valid")]
        public string phoneNumber { get; set; }

        [Required]
        [StringLength(255)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string emailAddress { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[^;:!@#$%\^*+?\\/<>1234567890]*$", ErrorMessage = @"Credit card holder's name should not contain the following characters: ;:!@#$%^*+?\/<>1234567890")]
        public string nameOnTheCard { get; set; }

        [Required]
        [StringLength(50)]
        [Validators.CreditCardValidation]
        public string CreditCardnumber { get; set; }

        public int CreditCardType { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreditCardExpDate { get; set; }

        public virtual Country Country1 { get; set; }

        public virtual CreditCardType CreditCardType1 { get; set; }

        public virtual Region Region1 { get; set; }

        public virtual RoomType RoomType1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReservedRoom> ReservedRooms { get; set; }
    }
}
