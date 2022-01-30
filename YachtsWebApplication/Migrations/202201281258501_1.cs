namespace YachtsWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        YachtId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Yachts", t => t.YachtId, cascadeDelete: true)
                .Index(t => t.YachtId);
            
            CreateTable(
                "dbo.Yachts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductionYear = c.Int(nullable: false),
                        ProductionCountry = c.String(),
                        Model = c.String(),
                        CabinsNumber = c.Int(nullable: false),
                        MaxCrewNumber = c.Int(nullable: false),
                        PricePerDay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Image = c.String(),
                        YachtCategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.YachtCategories", t => t.YachtCategoryId, cascadeDelete: true)
                .Index(t => t.YachtCategoryId);
            
            CreateTable(
                "dbo.YachtCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "YachtId", "dbo.Yachts");
            DropForeignKey("dbo.Yachts", "YachtCategoryId", "dbo.YachtCategories");
            DropIndex("dbo.Yachts", new[] { "YachtCategoryId" });
            DropIndex("dbo.Bookings", new[] { "YachtId" });
            DropTable("dbo.YachtCategories");
            DropTable("dbo.Yachts");
            DropTable("dbo.Bookings");
        }
    }
}
