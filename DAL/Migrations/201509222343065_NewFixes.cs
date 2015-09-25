using System.Data.Entity.Migrations;

namespace TrainBooking.DAL.Migrations
{
    public partial class NewFixes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Tickets", "StartingStationRoute", c => c.Int(nullable: false));
            AlterColumn("dbo.Tickets", "LastStationRoute", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Tickets", "LastStationRoute", c => c.String());
            AlterColumn("dbo.Tickets", "StartingStationRoute", c => c.String());
        }
    }
}
