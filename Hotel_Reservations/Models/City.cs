namespace Reservations
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class City
    {
        public int cityId { get; set; }

        [Column("city")]
        [Required]
        [StringLength(50)]
        public string city1 { get; set; }

        public int region { get; set; }

        public virtual Region Region1 { get; set; }
    }
}
