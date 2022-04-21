namespace Kalendarz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Events", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Events", "Date", c => c.DateTime());
        }
    }
}
