namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Data.LibraryDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Library.Data.LibraryDbContext context)
        {
            var client = context.Clients.Single(client1 => client1.Email == "bartek9614@gmail.com");
            context.Reservations.AddOrUpdate(new Reservation() {ClientId = client.ClientId, BookId = 1, ReservationDate = DateTime.Now.AddDays(-50)});
        }
    }
}
