namespace fwTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RunningTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "RuningTime", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "RuningTime");
        }
    }
}
