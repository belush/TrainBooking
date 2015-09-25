using System.Data.Entity.Migrations;

namespace TrainBooking.DAL.Migrations
{
    public partial class Fixes2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.WagonTypes", "Coefficient", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.WagonTypes", "Coefficient", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
