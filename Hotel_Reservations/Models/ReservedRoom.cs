namespace Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReservedRoom
    {
        [Key]
        public int rrId { get; set; }

        public int reservationId { get; set; }

        public int roomId { get; set; }

        public virtual Reservation Reservation { get; set; }

        public virtual Room Room { get; set; }
    }
}
