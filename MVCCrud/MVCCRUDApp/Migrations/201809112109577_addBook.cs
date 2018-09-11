namespace MVCCRUDApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false, maxLength: 100),
                        AuthorName = c.String(nullable: false, maxLength: 100),
                        BookGenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId)
                .ForeignKey("dbo.BookGenres", t => t.BookGenreId, cascadeDelete: true)
                .Index(t => t.BookGenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "BookGenreId", "dbo.BookGenres");
            DropIndex("dbo.Books", new[] { "BookGenreId" });
            DropTable("dbo.Books");
        }
    }
}
