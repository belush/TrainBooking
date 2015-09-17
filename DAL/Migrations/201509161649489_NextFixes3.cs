namespace TrainBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NextFixes3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StationRoutes", "ArrivalDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.StationRoutes", "ArrivalDate");
            DropColumn("dbo.StationRoutes", "ArrivalTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StationRoutes", "ArrivalTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.StationRoutes", "ArrivalDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.StationRoutes", "ArrivalDateTime");
        }
    }
}
