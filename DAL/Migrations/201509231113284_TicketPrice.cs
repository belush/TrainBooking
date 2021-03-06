using System.Data.Entity.Migrations;

namespace TrainBooking.DAL.Migrations
{
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
