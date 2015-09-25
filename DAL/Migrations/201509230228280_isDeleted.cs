namespace TrainBooking.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
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
