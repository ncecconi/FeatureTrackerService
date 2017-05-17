namespace FeatureTrackerService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertedPriority : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "Priority", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Features", "Priority");
        }
    }
}
