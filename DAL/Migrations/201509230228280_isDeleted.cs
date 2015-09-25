using System.Data.Entity.Migrations;

namespace TrainBooking.DAL.Migrations
{
    public partial class isDeleted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Routes", "IsDeleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Routes", "IsDeleted");
        }
    }
}
