namespace Library.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Archive")]
    public partial class Archive
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReservationId { get; set; }

        public int ClientId { get; set; }

        public int BookId { get; set; }

        public DateTime ReservationDate { get; set; }

        public DateTime ReservationEnd { get; set; }

        public virtual Book Book { get; set; }

        public virtual Client Client { get; set; }
    }
}
