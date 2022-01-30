namespace YachtsWebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "EmailAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "EmailAddress");
        }
    }
}
