namespace Library.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Reminder
    {
        [Key]
        [Column("Client ID", Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Client_ID { get; set; }

        [Key]
        [Column("First Name", Order = 1)]
        [StringLength(25)]
        public string First_Name { get; set; }

        [Key]
        [Column("Last Name", Order = 2)]
        [StringLength(25)]
        public string Last_Name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(150)]
        public string Title { get; set; }

        [Column("Reservation End")]
        public DateTime? Reservation_End { get; set; }
    }
}
