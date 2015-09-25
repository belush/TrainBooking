using System.Data.Entity.Migrations;

namespace TrainBooking.DAL.Migrations
{
    public partial class SomeChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Routes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Name = c.String(),
                        DepatureDate = c.DateTime(nullable: false),
                        DepatureTime = c.Time(nullable: false, precision: 7),
                        ArrivalDate = c.DateTime(nullable: false),
                        ArrivalTime = c.Time(nullable: false, precision: 7),
                        FullPrice = c.Double(nullable: false),
                        StartingStation = c.String(),
                        LastStation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StationRoutes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepatureDate = c.DateTime(nullable: false),
                        DepatureTime = c.Time(nullable: false, precision: 7),
                        ArrivalDate = c.DateTime(nullable: false),
                        ArrivalTime = c.Time(nullable: false, precision: 7),
                        Route_Id = c.Int(),
                        Station_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .ForeignKey("dbo.Stations", t => t.Station_Id)
                .Index(t => t.Route_Id)
                .Index(t => t.Station_Id);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wagons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        WagonType_Id = c.Int(),
                        Route_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WagonTypes", t => t.WagonType_Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .Index(t => t.WagonType_Id)
                .Index(t => t.Route_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceNumber = c.Int(nullable: false),
                        StartingStation = c.String(),
                        LastStation = c.String(),
                        Route_Id = c.Int(),
                        Wagon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Routes", t => t.Route_Id)
                .ForeignKey("dbo.Wagons", t => t.Wagon_Id)
                .Index(t => t.Route_Id)
                .Index(t => t.Wagon_Id);
            
            CreateTable(
                "dbo.WagonTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        NumberOfPlaces = c.Int(nullable: false),
                        Coefficient = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wagons", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.Wagons", "WagonType_Id", "dbo.WagonTypes");
            DropForeignKey("dbo.Tickets", "Wagon_Id", "dbo.Wagons");
            DropForeignKey("dbo.Tickets", "Route_Id", "dbo.Routes");
            DropForeignKey("dbo.StationRoutes", "Station_Id", "dbo.Stations");
            DropForeignKey("dbo.StationRoutes", "Route_Id", "dbo.Routes");
            DropIndex("dbo.Tickets", new[] { "Wagon_Id" });
            DropIndex("dbo.Tickets", new[] { "Route_Id" });
            DropIndex("dbo.Wagons", new[] { "Route_Id" });
            DropIndex("dbo.Wagons", new[] { "WagonType_Id" });
            DropIndex("dbo.StationRoutes", new[] { "Station_Id" });
            DropIndex("dbo.StationRoutes", new[] { "Route_Id" });
            DropTable("dbo.WagonTypes");
            DropTable("dbo.Tickets");
            DropTable("dbo.Wagons");
            DropTable("dbo.Stations");
            DropTable("dbo.StationRoutes");
            DropTable("dbo.Routes");
        }
    }
}
