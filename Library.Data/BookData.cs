namespace Library.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BookData")]
    public partial class BookData
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int bookid { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(150)]
        public string title { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(70)]
        public string author { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string category { get; set; }
    }
}
