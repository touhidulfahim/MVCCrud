namespace MVCCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addDivision : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Divisions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DivisionCode = c.String(nullable: false, maxLength: 10),
                        DivisionName = c.String(nullable: false, maxLength: 100),
                        CountryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId)
                .Index(t => t.DivisionCode, unique: true)
                .Index(t => t.DivisionName, unique: true)
                .Index(t => t.CountryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Divisions", "CountryId", "dbo.Countries");
            DropIndex("dbo.Divisions", new[] { "CountryId" });
            DropIndex("dbo.Divisions", new[] { "DivisionName" });
            DropIndex("dbo.Divisions", new[] { "DivisionCode" });
            DropTable("dbo.Divisions");
        }
    }
}
