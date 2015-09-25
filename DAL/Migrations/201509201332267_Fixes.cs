namespace TrainBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fixes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WagonTypes", "Coefficient", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WagonTypes", "Coefficient", c => c.Double(nullable: false));
        }
    }
}
