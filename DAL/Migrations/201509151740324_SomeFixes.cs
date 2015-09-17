namespace TrainBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SomeFixes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tickets", "Route_Id", "dbo.Routes");
            DropIndex("dbo.Tickets", new[] { "Route_Id" });
            AddColumn("dbo.Routes", "LastStation_Id", c => c.Int());
            AddColumn("dbo.Routes", "StartingStation_Id", c => c.Int());
            AddColumn("dbo.StationRoutes", "Route_Id1", c => c.Int());
            CreateIndex("dbo.Routes", "LastStation_Id");
            CreateIndex("dbo.Routes", "StartingStation_Id");
            CreateIndex("dbo.StationRoutes", "Route_Id1");
            AddForeignKey("dbo.Routes", "LastStation_Id", "dbo.StationRoutes", "Id");
            AddForeignKey("dbo.Routes", "StartingStation_Id", "dbo.StationRoutes", "Id");
            AddForeignKey("dbo.StationRoutes", "Route_Id1", "dbo.Routes", "Id");
            DropColumn("dbo.Routes", "StartingStation");
            DropColumn("dbo.Routes", "LastStation");
            DropColumn("dbo.Tickets", "Route_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Tickets", "Route_Id", c => c.Int());
            AddColumn("dbo.Routes", "LastStation", c => c.String());
            AddColumn("dbo.Routes", "StartingStation", c => c.String());
            DropForeignKey("dbo.StationRoutes", "Route_Id1", "dbo.Routes");
            DropForeignKey("dbo.Routes", "StartingStation_Id", "dbo.StationRoutes");
            DropForeignKey("dbo.Routes", "LastStation_Id", "dbo.StationRoutes");
            DropIndex("dbo.StationRoutes", new[] { "Route_Id1" });
            DropIndex("dbo.Routes", new[] { "StartingStation_Id" });
            DropIndex("dbo.Routes", new[] { "LastStation_Id" });
            DropColumn("dbo.StationRoutes", "Route_Id1");
            DropColumn("dbo.Routes", "StartingStation_Id");
            DropColumn("dbo.Routes", "LastStation_Id");
            CreateIndex("dbo.Tickets", "Route_Id");
            AddForeignKey("dbo.Tickets", "Route_Id", "dbo.Routes", "Id");
        }
    }
}
