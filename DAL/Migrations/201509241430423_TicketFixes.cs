namespace TrainBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketFixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "StartingStationRoute", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "LastStationRoute", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "StartingStation");
            DropColumn("dbo.Tickets", "LastStation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "LastStation", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "StartingStation", c => c.Int(nullable: false));
            DropColumn("dbo.Tickets", "LastStationRoute");
            DropColumn("dbo.Tickets", "StartingStationRoute");
        }
    }
}
