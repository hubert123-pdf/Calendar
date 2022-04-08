namespace Kalendarz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "Date", c => c.DateTime());
            AddColumn("dbo.Events", "Hour", c => c.Int(nullable: false));
            DropColumn("dbo.Events", "Created");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "Created", c => c.DateTime(nullable: false));
            DropColumn("dbo.Events", "Hour");
            DropColumn("dbo.Events", "Date");
        }
    }
}
