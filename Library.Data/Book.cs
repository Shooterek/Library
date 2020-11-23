namespace Library.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Book()
        {
            Archives = new HashSet<Archive>();
            Reservations = new HashSet<Reservation>();
        }

        public int BookId { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        [StringLength(70)]
        public string Author { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        public int ReleaseDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Publisher { get; set; }

        public int Pages { get; set; }

        [Column(TypeName = "text")]
        public string Specification { get; set; }

        public int CategoryId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Archive> Archives { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
