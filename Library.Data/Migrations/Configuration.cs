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
            var cat1 = new Category() { Category1 = "Krymina³" };
            var cat2 = new Category() { Category1 = "Powieœæ historyczna" };
            var cat3 = new Category() { Category1 = "Sci-Fi" };
            var cat4 = new Category() { Category1 = "Czasopismo" };

            context.Categories.Add(cat1);
            context.Categories.Add(cat2);
            context.Categories.Add(cat3);
            context.Categories.Add(cat4);

            context.SaveChanges();
        }
    }
}
