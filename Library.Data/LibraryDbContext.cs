namespace Library.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
            : base("LibraryDbContext")
        {
        }

        public virtual DbSet<Archive> Archives { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<BookData> BookDatas { get; set; }
        public virtual DbSet<Number_of_reservation> Number_of_reservations { get; set; }
        public virtual DbSet<Reminder> Reminders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configuration.LazyLoadingEnabled = false;
            modelBuilder.Entity<Book>()
                .Property(e => e.ISBN)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Author)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Publisher)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .Property(e => e.Specification)
                .IsUnicode(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Archives)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Book>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Category1)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Pesel)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Sex)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Archives)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Client)
                .WillCascadeOnDelete(false);
            //
            modelBuilder.Entity<BookData>()
                .Property(e => e.title)
                .IsUnicode(false);

            modelBuilder.Entity<BookData>()
                .Property(e => e.author)
                .IsUnicode(false);

            modelBuilder.Entity<BookData>()
                .Property(e => e.category)
                .IsUnicode(false);

            modelBuilder.Entity<Number_of_reservation>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Number_of_reservation>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Reminder>()
                .Property(e => e.First_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Reminder>()
                .Property(e => e.Last_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Reminder>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Reminder>()
                .Property(e => e.Title)
                .IsUnicode(false);
        }
    }
}
