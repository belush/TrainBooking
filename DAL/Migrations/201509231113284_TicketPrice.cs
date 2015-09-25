namespace TrainBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicketPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Price");
        }
    }
}
