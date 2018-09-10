namespace MVCCRUDApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookGenres",
                c => new
                    {
                        BookGenreId = c.Int(nullable: false, identity: true),
                        BookGenreName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BookGenreId)
                .Index(t => t.BookGenreName, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BookGenres", new[] { "BookGenreName" });
            DropTable("dbo.BookGenres");
        }
    }
}
