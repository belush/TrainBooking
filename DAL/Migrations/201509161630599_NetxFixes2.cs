namespace TrainBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NetxFixes2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "ArrivalDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Routes", "ArrivalDate");
            DropColumn("dbo.Routes", "ArrivalTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Routes", "ArrivalTime", c => c.Time(nullable: false, precision: 7));
            AddColumn("dbo.Routes", "ArrivalDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Routes", "ArrivalDateTime");
        }
    }
}
