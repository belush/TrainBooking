using System.Data.Entity.Migrations;

namespace TrainBooking.DAL.Migrations
{
    public partial class NextFixes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "DepatureDateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.StationRoutes", "DepatureDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Routes", "DepatureDate");
            DropColumn("dbo.Routes", "DepatureTime");
            DropColumn("dbo.StationRoutes", "DepatureDate");
            DropColumn("dbo.StationRoutes", "DepatureTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StationRoutes", "DepatureTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.StationRoutes", "DepatureDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Routes", "DepatureTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Routes", "DepatureDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.StationRoutes", "DepatureDateTime");
            DropColumn("dbo.Routes", "DepatureDateTime");
        }
    }
}
