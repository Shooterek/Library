namespace Library.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveConstraintFromISBNField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Book", "ISBN", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Book", "ISBN", c => c.String(nullable: false, maxLength: 13, unicode: false));
        }
    }
}
