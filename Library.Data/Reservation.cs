namespace Library.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        public int ReservationId { get; set; }

        public int ClientId { get; set; }

        public int BookId { get; set; }

        public DateTime ReservationDate { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? ReservationDateLimit { get; set; }

        public virtual Book Book { get; set; }

        public virtual Client Client { get; set; }
    }
}
