namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Archive",
                c => new
                    {
                        ReservationId = c.Int(nullable: false),
                        ClientId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        ReservationEnd = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Book", t => t.BookId)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .Index(t => t.ClientId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        ISBN = c.String(nullable: false, maxLength: 13, unicode: false),
                        Author = c.String(nullable: false, maxLength: 70, unicode: false),
                        Title = c.String(nullable: false, maxLength: 150, unicode: false),
                        ReleaseDate = c.Int(nullable: false),
                        Publisher = c.String(nullable: false, maxLength: 50, unicode: false),
                        Pages = c.Int(nullable: false),
                        Specification = c.String(unicode: false, storeType: "text"),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        Category = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        ReservationId = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        ReservationDate = c.DateTime(nullable: false),
                        ReservationDateLimit = c.DateTime(),
                    })
                .PrimaryKey(t => t.ReservationId)
                .ForeignKey("dbo.Client", t => t.ClientId)
                .ForeignKey("dbo.Book", t => t.BookId)
                .Index(t => t.ClientId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25, unicode: false),
                        LastName = c.String(nullable: false, maxLength: 25, unicode: false),
                        Pesel = c.String(nullable: false, maxLength: 11, unicode: false),
                        Sex = c.String(nullable: false, maxLength: 1, unicode: false),
                        City = c.String(nullable: false, maxLength: 30, unicode: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 12, unicode: false),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.BookData",
                c => new
                    {
                        bookid = c.Int(nullable: false),
                        title = c.String(nullable: false, maxLength: 150, unicode: false),
                        author = c.String(nullable: false, maxLength: 70, unicode: false),
                        category = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.bookid, t.title, t.author, t.category });
            
            CreateTable(
                "dbo.Number of reservations",
                c => new
                    {
                        ClientID = c.Int(name: "Client ID", nullable: false),
                        FirstName = c.String(name: "First Name", nullable: false, maxLength: 25, unicode: false),
                        LastName = c.String(name: "Last Name", nullable: false, maxLength: 25, unicode: false),
                        Reservations = c.Int(),
                    })
                .PrimaryKey(t => new { t.ClientID, t.FirstName, t.LastName });
            
            CreateTable(
                "dbo.Reminders",
                c => new
                    {
                        ClientID = c.Int(name: "Client ID", nullable: false),
                        FirstName = c.String(name: "First Name", nullable: false, maxLength: 25, unicode: false),
                        LastName = c.String(name: "Last Name", nullable: false, maxLength: 25, unicode: false),
                        Email = c.String(nullable: false, maxLength: 30, unicode: false),
                        Title = c.String(nullable: false, maxLength: 150, unicode: false),
                        ReservationEnd = c.DateTime(name: "Reservation End"),
                    })
                .PrimaryKey(t => new { t.ClientID, t.FirstName, t.LastName, t.Email, t.Title });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reservation", "BookId", "dbo.Book");
            DropForeignKey("dbo.Reservation", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Archive", "ClientId", "dbo.Client");
            DropForeignKey("dbo.Book", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Archive", "BookId", "dbo.Book");
            DropIndex("dbo.Reservation", new[] { "BookId" });
            DropIndex("dbo.Reservation", new[] { "ClientId" });
            DropIndex("dbo.Book", new[] { "CategoryId" });
            DropIndex("dbo.Archive", new[] { "BookId" });
            DropIndex("dbo.Archive", new[] { "ClientId" });
            DropTable("dbo.Reminders");
            DropTable("dbo.Number of reservations");
            DropTable("dbo.BookData");
            DropTable("dbo.Client");
            DropTable("dbo.Reservation");
            DropTable("dbo.Categories");
            DropTable("dbo.Book");
            DropTable("dbo.Archive");
        }
    }
}
