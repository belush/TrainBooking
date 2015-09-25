using System.Data.Entity.Migrations;

namespace TrainBooking.DAL.Migrations
{
    public partial class SomeSuperChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "User_UserId", c => c.Int());
            CreateIndex("dbo.Tickets", "User_UserId");
            AddForeignKey("dbo.Tickets", "User_UserId", "dbo.User", "UserId");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "User_UserId", "dbo.User");
            DropIndex("dbo.Tickets", new[] { "User_UserId" });
            DropColumn("dbo.Tickets", "User_UserId");
        }
    }
}
